using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using DataSource = Microsoft.ReportingServices.ReportProcessing.ReportObjectModel.DataSource;

namespace Supermarket
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
   

        }
        protected override void OnAfterInstall(IDictionary savedState)
        {
            //Installer.cs 
            string dataSource = "Data Source =" + Context.Parameters["DataSource"];
            string initialcatalog = "Initial Catalog=" + Context.Parameters["InitialCatalog"];
            dataSource = dataSource + ";" + initialcatalog;
            dataSource = dataSource + ";Integrated Security=SSPI;";
            MessageBox.Show("instance=" + dataSource);
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            MessageBox.Show(Assembly.GetExecutingAssembly().Location + ".config");
            //Getting the path location 
            string configFile = string.Concat(Assembly.GetExecutingAssembly().Location, ".config");
            map.ExeConfigFilename = configFile;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.
            OpenMappedExeConfiguration(map, System.Configuration.ConfigurationUserLevel.None);
            string connectionsection = config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString;
            //SqlConnectionString
            ConnectionStringSettings connectionstring = null;
            if (connectionsection != null)
            {
                config.ConnectionStrings.ConnectionStrings.Remove("SqlConnectionString");
                MessageBox.Show("removing existing Connection String");
            }
            //connectionstring -3
            connectionstring = new ConnectionStringSettings("SqlConnectionString", dataSource);
            config.ConnectionStrings.ConnectionStrings.Add(connectionstring);

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("ConnectionStrings");
            /*
            string dataSource = "Data Source =" + Context.Parameters["DataSource"];
            string initialcatalog = "Initial Catalog=" + Context.Parameters["InitialCatalog"];
            dataSource = dataSource + ";" + initialcatalog;
            dataSource = dataSource + ";Integrated Security=SSPI;";
            MessageBox.Show("instance=" + dataSource);
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            MessageBox.Show(Assembly.GetExecutingAssembly().Location + ".config");
            //Getting the path location 
            string configFile = string.Concat(Assembly.GetExecutingAssembly().Location, ".config");
            map.ExeConfigFilename = configFile;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.
            OpenMappedExeConfiguration(map, System.Configuration.ConfigurationUserLevel.None);
            string myconnstrng = config.ConnectionStrings.ConnectionStrings["connstrng"].ConnectionString;

            ConnectionStringSettings connectionstring = null;
            if (myconnstrng != null)
            {
                config.ConnectionStrings.ConnectionStrings.Remove("connstrng");
                MessageBox.Show("removing existing Connection String");
            }

            connectionstring = new ConnectionStringSettings("connstrng", dataSource);
            config.ConnectionStrings.ConnectionStrings.Add(connectionstring);

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("ConnectionStrings");
            */
        }


    }
}
