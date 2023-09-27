using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Xml;

namespace MODEL
{
    public static class ConnectionInfo
    {
        public static RegistrySecurity rs = new RegistrySecurity();
        static ConnectionInfo()
        {
            if (ConnectionString == null )
            {

                try
                {  
                    string xmlFileName = "";
                    //ReadFromRegistery();
                    if (ApplicationDeployment.IsNetworkDeployed)
                    {
                        ReadFromRegistery();
                        //xmlFileName = ApplicationDeployment.CurrentDeployment.DataDirectory + @"\Setting.xml";
                    }
                    else
                    {

                        string assemblyFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                        xmlFileName = Path.Combine(assemblyFolder, "Setting.xml");
                        
                        ReadXml(xmlFileName);

                    }

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
        private static void ReadFromRegistery()
        {

            //Crypto crypt = new Crypto();
            //try
            //{
            //    string user = Environment.UserDomainName + "\\" + Environment.UserName;
            //    rs.AddAccessRule(new RegistryAccessRule(user,
            //    RegistryRights.FullControl,
            //    InheritanceFlags.None,
            //    PropagationFlags.None,
            //    AccessControlType.Allow));
            //    RegistryKey regkey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\BOSFOR\\FITAP", RegistryKeyPermissionCheck.ReadSubTree, rs);

            //    if (regkey.GetValue("Encrypted").ToString() == "0")
            //    {
            //        RegistryKey regkeyWrite = Registry.CurrentUser.CreateSubKey("SOFTWARE\\BOSFOR\\FITAP", RegistryKeyPermissionCheck.ReadWriteSubTree, rs);
            //        regkeyWrite.SetValue("Settings", crypt.EncryptString(regkey.GetValue("Settings").ToString()));
            //        regkeyWrite.SetValue("Encrypted", crypt.EncryptString(regkey.GetValue("Encrypted").ToString()));

            //        regkey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\BOSFOR\\FITAP", RegistryKeyPermissionCheck.ReadSubTree, rs);
            //    }

            //    //string user = Environment.UserDomainName + "\\" + Environment.UserName;
            //    //string subkey = "SOFTWARE\\BOSFOR\\FITAP";  
            //    //RegistryKey regkey = Registry.CurrentUser.OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree,RegistryRights.ReadKey); 
            //    //if (regkey.GetValue("Encrypted").ToString() == "0")
            //    //{
            //    //    RegistryKey regkey2 = Registry.CurrentUser.OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.WriteKey);
            //    //    regkey2.SetValue("Settings", crypt.EncryptString(regkey.GetValue("Settings").ToString()));
            //    //    regkey2.SetValue("Encrypted", crypt.EncryptString(regkey.GetValue("Encrypted").ToString()));
            //    //} 

            //    string strsettings = crypt.DecryptString(regkey.GetValue("Settings").ToString());
            //    String[] strsetttingsarray = strsettings.Split(',');

            //    ConnectionInfo.DataSource = strsetttingsarray[0].ToString();
            //    ConnectionInfo.InitialCatalog = strsetttingsarray[1].ToString();
            //    ConnectionInfo.UserID = strsetttingsarray[2].ToString();
            //    ConnectionInfo.Password = strsetttingsarray[3].ToString();
            //    ConnectionInfo.LogoDatabase = strsetttingsarray[4].ToString();
            //    ConnectionInfo.ServiceDatabase = strsetttingsarray[1].ToString();
            //    ConnectionInfo.ConnectionStringBuilder = new SqlConnectionStringBuilder()
            //    {
            //        DataSource = ConnectionInfo.DataSource,
            //        UserID = ConnectionInfo.UserID,
            //        Password = ConnectionInfo.Password,
            //        InitialCatalog = ConnectionInfo.InitialCatalog,
            //        IntegratedSecurity = false

            //    };
            //    ConnectionInfo.ConnectionString = ConnectionInfo.ConnectionStringBuilder.ConnectionString;
            //}
            //catch 
            //{
            //    throw;
            //}

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


        private static string serviceDatabase;
        public static string ServiceDatabase
        {
            get { return serviceDatabase; }
            set { serviceDatabase = value; }
        }

        private static string logoDatabase;
        public static string LogoDatabase
        {
            get { return logoDatabase; }
            set { logoDatabase = value; }
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

        private static string oracleConnectionString = null;
        public static string OracleConnectionString
        {
            get { return oracleConnectionString; }
            set { oracleConnectionString = value; }
        }

        

        private static void ReadXml(string path)
        {
            try
            { 
                Crypto crypt = new Crypto();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                string encrypted = "0";
                XmlNodeList userNodes = xmlDoc.SelectNodes("//CHANNEL/ITEM"); 
                foreach (XmlNode userNode in userNodes)
                {

                    if ( userNode["Encrypted"]!=null)
                    { 
                        encrypted = userNode["Encrypted"].InnerText.ToString();  
                    } 
                }
                if (encrypted == "0")
                {
                    foreach (XmlNode userNode in userNodes)
                    {
                        foreach (XmlElement element in userNode) 
                        {
                            element.InnerText = crypt.EncryptString(element.InnerText.ToString());
                        } 
                    }

                    xmlDoc.Save(path);
                    // WriteXml(xmlDoc);
                }

                foreach (XmlNode userNode in userNodes)
                {
                    foreach (XmlElement element in userNode)
                    { 
                        switch(element.Name)
                        { 
                            case "DataSource":
                                DataSource = crypt.DecryptString((element.InnerText.ToString()));
                            break;
                            case "UserID":
                                UserID = crypt.DecryptString((element.InnerText.ToString()));
                                break;
                            case "Password":
                                Password = crypt.DecryptString((element.InnerText.ToString()));
                                break;
                            case "InitialCatalog":
                                InitialCatalog = crypt.DecryptString((element.InnerText.ToString()));
                                break;
                            case "ServiceDatabase":
                                ServiceDatabase = crypt.DecryptString((element.InnerText.ToString()));
                                break;
                            case "LogoDatabase":
                                LogoDatabase = crypt.DecryptString((element.InnerText.ToString()));
                                break; 
                            case "OracleConnectionString":
                                OracleConnectionString = crypt.DecryptString((element.InnerText.ToString()));
                                break;
                        }

                    }
                     
                  
                }
                
               

                //XmlTextReader xmlDocument = new XmlTextReader(path);


                //while (xmlDocument.Read())
                //{
                //    if (xmlDocument.NodeType == XmlNodeType.Element)
                //    {
                //        switch (xmlDocument.Name)
                //        {
                //            case "DataSource":
                //                DataSource = Convert.ToString(xmlDocument.ReadString());
                //                break;
                //            case "UserID":
                //                UserID = Convert.ToString(xmlDocument.ReadString());
                //                break;
                //            case "Password":
                //                Password = Convert.ToString(xmlDocument.ReadString());
                //                break;
                //            case "InitialCatalog":
                //                InitialCatalog = Convert.ToString(xmlDocument.ReadString());
                //                break;
                //            case "ServiceDatabase":
                //                ServiceDatabase = Convert.ToString(xmlDocument.ReadString());
                //                break;
                //            case "LogoDatabase":
                //                LogoDatabase = Convert.ToString(xmlDocument.ReadString());
                //                break;

                //            case "OracleConnectionString":
                //                OracleConnectionString = Convert.ToString(xmlDocument.ReadString());
                //                break;
                //        }
                //    }
                //}
                //xmlDocument.Close();
            }
            catch (Exception ex)
            {
                string err = "";
                if(ex.InnerException!=null)
                {
                    err = ex.Message + " - " + ex.InnerException.Message;
                }
                else
                {
                    err = ex.Message;
                }
                StreamWriter SW;
                //SW = File.AppendText("C:\\Log.txt");
                //SW.WriteLine(err + " " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                //SW.Close();
                throw;
            }

        }
        public static string WriteXml(XmlDocument xml)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    xml.WriteTo(xmlTextWriter);
                    return stringWriter.ToString();
                }

            }
        }
    }
}
