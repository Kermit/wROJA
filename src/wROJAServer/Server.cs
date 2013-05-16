using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.services;

namespace wROJAServer
{
    // Główna klasa zarządzająca całym serwerem.
    public class Server
    {
        // Połączenie z bazą
        public SQLiteConnection databaseConnection { get; private set; }
        ServiceHost linesServiceHost;
        ServiceHost stopsServiceHost;
        ServiceHost searchServiceHost;

        private static Server instance = null;

        private Server() { }

        public static Server getInstance()
        {
            if (instance == null)
            {
                instance = new Server();
            }

            return instance;
        }

        private void ConnectToDatabase()
        {            
            databaseConnection = new SQLiteConnection(@"Data Source=resources/RojaDatabase.db.sqlite");
            databaseConnection.Open();                                        
        }

        private void StartAllServices()
        {
            ServiceMetadataBehavior linesServiceSMB = new ServiceMetadataBehavior();
            linesServiceSMB.HttpGetEnabled = true;
            linesServiceSMB.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            Uri linesServiceAddress = new Uri("http://localhost:8080/LinesService");
            linesServiceHost = new ServiceHost(typeof(LinesService), linesServiceAddress);
            linesServiceHost.Description.Behaviors.Add(linesServiceSMB);
            linesServiceHost.Open();

            ServiceMetadataBehavior stopsServiceSMB = new ServiceMetadataBehavior();
            stopsServiceSMB.HttpGetEnabled = true;
            stopsServiceSMB.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            Uri stopsServiceAddress = new Uri("http://localhost:8080/StopsService");
            stopsServiceHost = new ServiceHost(typeof(StopsService), stopsServiceAddress);
            stopsServiceHost.Description.Behaviors.Add(stopsServiceSMB);
            stopsServiceHost.Open();

            ServiceMetadataBehavior searchServiceSMB = new ServiceMetadataBehavior();
            searchServiceSMB.HttpGetEnabled = true;
            searchServiceSMB.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            Uri searchServiceAddress = new Uri("http://localhost:8080/SearchService");
            searchServiceHost = new ServiceHost(typeof(SearchService), searchServiceAddress);
            searchServiceHost.Description.Behaviors.Add(searchServiceSMB);
            searchServiceHost.Open();
        }

        private void StopAllServices()
        {
            linesServiceHost.Close();
            stopsServiceHost.Close();
            searchServiceHost.Close();
        }

        private void DisconnectFromDatabase()
        {
            databaseConnection.Close();
        }


        public void StartUp()
        {
            ConnectToDatabase();
            StartAllServices();
        }

        public void CleanUp()
        {
            StopAllServices();
        }
    }
}
