using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Exit Event
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //reset app config file
            ConfigurationManager.AppSettings["ServerAddress"] = "https://74.140.136.128";
            ConfigurationManager.AppSettings["Port"] = "1337";
        }
        #endregion
    }
}
