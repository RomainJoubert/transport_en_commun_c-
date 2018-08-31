using MyLibrary;
using PublicTransport;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransportWPF.Model;

namespace TransportWPF.ViewModel
{
    public class TransportViewModel : INotifyPropertyChanged
    {
        private string longitude;
        private string latitude;
        private int distance;
        private ObservableCollection<Transport> transports;


        public TransportViewModel()
        {
            longitude = "5.726744267129334";
            latitude = "45.18521853612248";
            distance = 600;
            LoadTransports();
        }

        public ObservableCollection<Transport> Transports
        {
            get
            {
                return transports;
            }
            set
            {
                if (transports != value)
                {
                    transports = value;
                    RaisePropertyChanged("Transports");

                }
            }
        }


        public String MyTitle
        {
            get;
            set;
        }

        public String Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    LoadTransports();
                    RaisePropertyChanged("Longitude");

                }
            }

        }
        public String Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    LoadTransports();
                    RaisePropertyChanged("Latitude");

                }
            }
        }
        public Int32 Distance
        {
            get
            {
                return distance;
            }
            set
            {
                if (distance != value)
                {
                    distance = value;
                    LoadTransports();
                    RaisePropertyChanged("Distance");

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void LoadTransports()
        {
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
            foreach (KeyValuePair<string, List<string>> kvp in dico)
            {
                Transport transport = new Transport(kvp.Key, kvp.Value);
                listToReturn.Add(transport);
            }
            return listToReturn;
        }
    }
}
