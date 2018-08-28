using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class DataDetailsTransport
    {
        private IConnexion connectApi;

        //Méthode permettant de récupérer le détail d'une ligne 
        public DetailsTransport GetDetailsLine(String idLine)
        {
            string url = "https://data.metromobilite.fr/api/routers/default/index/routes?codes="+idLine;
            String cx = connectApi.ApiConnexion(url);
            List<DetailsTransport> detailsLine = JsonConvert.DeserializeObject<List<DetailsTransport>>(cx);
            return detailsLine[0];
        }

        public DataDetailsTransport(IConnexion connexion)
        {
            connectApi = connexion;
        }
    }
}
