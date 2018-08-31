using Newtonsoft.Json;
using PublicTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Unduplicate
    {
        private IConnexion connexion;
        private List<BusStationObject> convertJsonList(String latitude, String longitude, Int32 distance)
        {
            string url = "http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true";
            String cx = connexion.ApiConnexion(url);
            List<BusStationObject> busStation = JsonConvert.DeserializeObject<List<BusStationObject>>(cx);
            return busStation;
        }
        public Dictionary<string, List<string>> removeDuplicate(String latitude, String longitude, Int32 distance)
        {
            List<BusStationObject> liste = convertJsonList(latitude, longitude, distance);
            Dictionary<string, List<string>> myDictionary =
                new Dictionary<string, List<string>>();

            foreach (BusStationObject station in liste)
            {
                try
                {
                    if (!myDictionary.ContainsKey(station.name))
                    {
                        myDictionary.Add(station.name, station.lines);
                    }
                    else
                    {
                        foreach (string line in station.lines)
                        {
                            if (!myDictionary[station.name].Contains(line))
                            {
                                myDictionary[station.name].Add(line);
                            }
                        }
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("An element with Key = " + station.name + " already exists.");
                }
                myDictionary[station.name] = myDictionary[station.name].Distinct().ToList(); //pour enlever les doublons qui viennent de l'
            }
            return myDictionary;
        }

        //Méthode créant un dictionary <String, list<DetailsTransport>> 
        public Dictionary<String, List<DetailsTransport>> GetProximityLines (String latitude, String longitude, Int32 distance)
        {
            //Instance d'un nouveau dictionary 
            Dictionary<String, List<DetailsTransport>> dicoProximityLines = new Dictionary<String, List<DetailsTransport>>();
            //Récupérer le dictionnaire de base 
            Dictionary<String, List<String>> dicoSimple = removeDuplicate(latitude, longitude, distance);

            foreach (KeyValuePair<String, List<String>> kvp in dicoSimple)
            {
                List<DetailsTransport> listeLignes = new List<DetailsTransport>();
                foreach (string line in kvp.Value)
                {
                    DataDetailsTransport dataDetailsTransport = new DataDetailsTransport(new Connexion());
                    DetailsTransport objetLigne = dataDetailsTransport.GetDetailsLine(line);
                    listeLignes.Add(objetLigne);
                }
                dicoProximityLines.Add(kvp.Key, listeLignes);
            }
            return dicoProximityLines;
        }

        public Unduplicate(IConnexion co)
        {
            this.connexion = co;
        }
    }
    
}

