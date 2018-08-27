using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Connexion : IConnexion
    {
       public String ApiConnexion(string url)
        {
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(url);
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


            // Clean up the streams and the response.  
            reader.Close();
            response.Close();
            dataStream.Close();
            return responseFromServer;

        }
    }
}
