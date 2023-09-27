using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MODEL
{
    public static class ConnectionInfo
    {
        static ConnectionInfo()
        {
            if (ConnectionString == null)
            {

                try
                {  
                    string xmlFileName = "";
                    if (ApplicationDeployment.IsNetworkDeployed)
                    {
                        xmlFileName = ApplicationDeployment.CurrentDeployment.DataDirectory + @"\Setting.xml";
                    }
                    else
                    { 
                        string assemblyFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                        xmlFileName = Path.Combine(assemblyFolder, "Setting.xml");
                    }

                    ReadXml(xmlFileName);

                    ConnectionStringBuilder = new SqlConnectionStringBuilder()
                    {
                        DataSource = DataSource,
                        UserID = UserID,
                        Password = Password,
                        InitialCatalog = InitialCatalog,
                        IntegratedSecurity = false
                      
                        
                    };
                    ConnectionString = ConnectionStringBuilder.ConnectionString;
                }
                catch
                {
                    throw;
                }
            }

        }

        private static string dataSource;
        public static string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }


        private static string userid;
        public static string UserID
        {
            get { return userid; }
            set { userid = value; }
        }
        private static string password;
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        private static string initialCatalog;
        public static string InitialCatalog
        {
            get { return initialCatalog; }
            set { initialCatalog = value; }
        }

        private static  string logoUser;
        public static string LogoUser
        {
            get { return logoUser; }
            set { logoUser = value; }
        }

        private static string logoPassword;
        public static string LogoPassword
        {
            get { return logoPassword; }
            set { logoPassword = value; }
        }


        private static string firmNo;
        public static string FirmNo
        {
            get { return firmNo; }
            set { firmNo = value; }
        }

        private static SqlConnectionStringBuilder connectionStringBuilder;
        public static SqlConnectionStringBuilder ConnectionStringBuilder
        {
            get { return connectionStringBuilder; }
            set { connectionStringBuilder = value; }
        }

        private static string connectionString = null;
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private static void ReadXml(string path)
        {
            try
            {
                XmlTextReader xmlDocument = new XmlTextReader(path);
                while (xmlDocument.Read())
                {
                    if (xmlDocument.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlDocument.Name)
                        {
                            case "DataSource":
                                DataSource = Convert.ToString(xmlDocument.ReadString());
                                break;
                            case "UserID":
                                UserID = Convert.ToString(xmlDocument.ReadString());
                                break;
                            case "Password":
                                Password = Convert.ToString(xmlDocument.ReadString());
                                break;
                            case "InitialCatalog":
                                InitialCatalog = Convert.ToString(xmlDocument.ReadString());
                                break;
                            case "FirmNo":
                                FirmNo = Convert.ToString(xmlDocument.ReadString());
                                break;
                        }
                    }
                }
                xmlDocument.Close();
            }
            catch
            {
                throw;
            }

        }
    }
}
