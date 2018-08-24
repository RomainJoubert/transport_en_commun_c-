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

            Connexion cx = new Connexion();
            String url = "http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true";
            List<BusStationObject> busStation = JsonConvert.DeserializeObject<List<BusStationObject>>(cx.ApiConnexion(url));
            //cette ligne convertit la réponse qui est au format json en collection d'objets C#

            //2ème connexion api pour récupérer les détails de chaque ligne
            Connexion tag = new Connexion();
            String urlTag = "http://data.metromobilite.fr/api/routers/default/index/routes";
            List<DetailsTransport> detailStation = JsonConvert.DeserializeObject<List<DetailsTransport>>(tag.ApiConnexion(urlTag));

            //remove doublons
            Unduplicate lb = new Unduplicate();
            Dictionary<string, List<string>> resultat = lb.removeDuplicate(busStation);

            //affichage du resultat
            foreach (KeyValuePair<string, List<string>> kvp in resultat)
            {
                Console.WriteLine("Arret = " + kvp.Key);

                foreach (string line in kvp.Value)
                {

                    foreach (DetailsTransport detail in detailStation)
                    {
                        if (detail.id.Equals(line))
                        {
                           // int delimiter = line.IndexOf(":");
                            Console.WriteLine("      Ligne = " + detail.shortName + "       couleur ligne = " + detail.color + " nom ligne = " +detail.longName);
                        }
                    }
                }
            }

        }

    }
}
