using MyLibrary;
using PublicTransport;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransportWPF.Model;

namespace TransportWPF.ViewModel
{
    public class TransportViewModel
    {
        public TransportViewModel()
        {
            LoadTransports();
        }
           
        public ObservableCollection<Transport> Transports
        {
            get;
            set;
        }


        public String MyTitle
        {
            get;
            set;
        }  
        
        //public void OnClick(object sender, RoutedEventArgs e)
        //{
        //    String sSelectedText = tbSelectSomeText.SelectedText;
        //}

        public void LoadTransports()
        {
            String longitude = "5.726744267129334";
            String latitude = "45.18521853612248";
            Int32 distance = 600;

            Unduplicate lb = new Unduplicate(new Connexion());
            Dictionary<string, List<string>> resultat = lb.removeDuplicate(latitude, longitude, distance);

            MyTitle = "Lignes de transport de l'agglomération";
          
             ObservableCollection<Transport> transports = new ObservableCollection<Transport>();
            transports = transformToCollection(resultat);

            //transports.Add(new Transport { BusStation = "Caserne de Bonne" , BusLine = "SEM:16" });
            //transports.Add(new Transport { BusStation = "Caserne de Bonne", BusLine = "SEM:12" });
            //transports.Add(new Transport { BusStation = "Caserne de Bonne", BusLine = "SEM:14" });

            Transports = transports;
        }

        public ObservableCollection<Transport> transformToCollection(Dictionary<string, List<string>> dico)
        {
            ObservableCollection<Transport> listToReturn = new ObservableCollection<Transport>();
            foreach(KeyValuePair<string, List<string>> kvp in dico)
            {
                Transport transport = new Transport(kvp.Key, kvp.Value);
                    listToReturn.Add(transport);
            }
            return listToReturn;
        }
    }
}
