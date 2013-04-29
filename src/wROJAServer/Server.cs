using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public DbConnection databaseConnection {get; private set;}
        ServiceHost linesServiceHost;

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

        public void ConnectToDatabase()
        {
            DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");
            databaseConnection = fact.CreateConnection();
            databaseConnection.ConnectionString = "Data Source=test.db3";
            databaseConnection.Open();                                        
        }

        public void StartAllServices()
        {
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;

            Uri linesServiceAddress = new Uri("http://localhost:8080/LinesService");

            linesServiceHost = new ServiceHost(typeof(LinesService), linesServiceAddress);
            linesServiceHost.Description.Behaviors.Add(smb);
            linesServiceHost.Open();
        }

        public void StopAllServices()
        {
            linesServiceHost.Close();
        }
    }
}
