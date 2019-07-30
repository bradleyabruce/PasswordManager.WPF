using System.Configuration;
using System.Windows;

namespace PasswordManager.WPF
{
    /// <summary>
    /// Interaction logic for AdvancedLogin.xaml
    /// </summary>
    public partial class AdvancedLogin : Window
    {
        public AdvancedLogin()
        {
            InitializeComponent();
            TextBoxServerAddress.Text = ConfigurationManager.AppSettings["ServerAddress"];
            TextBoxPortNumber.Text = ConfigurationManager.AppSettings["Port"];
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationManager.AppSettings["ServerAddress"] = TextBoxServerAddress.Text;
            ConfigurationManager.AppSettings["Port"] = TextBoxPortNumber.Text;
            this.Close();
        }
    }
}
