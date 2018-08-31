using MyLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace PublicTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            String longitude = "5.726744267129334";
            String latitude = "45.18521853612248";
            Int32 distance = 600;

            //Instance de DataDetailsTransport avec une véritable connexion
            DataDetailsTransport detail = new DataDetailsTransport(new Connexion());
                       
            
            //2ème connexion api pour récupérer les détails de chaque ligne
            Connexion tag = new Connexion();
            String urlTag = "http://data.metromobilite.fr/api/routers/default/index/routes";
            List<DetailsTransport> detailStation = JsonConvert.DeserializeObject<List<DetailsTransport>>(tag.ApiConnexion(urlTag));

            //remove doublons
            Unduplicate lb = new Unduplicate(new Connexion());
            Dictionary<string, List<string>> resultat = lb.removeDuplicate(latitude, longitude, distance);

            //affichage du resultat
            foreach (KeyValuePair<string, List<string>> kvp in resultat)
            {
                Console.WriteLine("Arret = " + kvp.Key);
                foreach (string line in kvp.Value)
                {
                   Console.WriteLine("      Ligne = " + detail.GetDetailsLine(line).shortName + "       couleur ligne = " + detail.GetDetailsLine(line).color + " nom ligne = " + detail.GetDetailsLine(line).longName);
                }

            }

        }

    }
}
