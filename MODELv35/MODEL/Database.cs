using System;
using System.Deployment.Application;
using System.IO;

namespace MODEL
{
    public static class Database
    {
       

        private static string GetSettingFilePath()
        {

            string filename = "";
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                filename = ApplicationDeployment.CurrentDeployment.DataDirectory + @"\LOGO_WCF.sql";
            }
            else
            {
                string assemblyFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                filename = Path.Combine(assemblyFolder, "LOGO_WCF.sql");
            }
            return filename;
        }
    }
}
