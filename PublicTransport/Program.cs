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



            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
                  "http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            //Console.WriteLine(responseFromServer);
            
            List<BusStationObject> busStation = JsonConvert.DeserializeObject<List<BusStationObject>>(responseFromServer);
            //cette ligne convertit la réponse qui est au format json en collection d'objets C#

            Dictionary<string, List<string>> leilaReveilleToi =
                new Dictionary<string, List<string>>();

            // Clean up the streams and the response.  
            reader.Close();
            response.Close();
            dataStream.Close();
            
        }
       

    }
}
