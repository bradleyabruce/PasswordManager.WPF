using PasswordManager.WPF.DataAccess;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PasswordManager.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Variables

        DataLogin login = new DataLogin();
        DataUtility dataUtility = new DataUtility();

        #endregion

        #region Events

        #region Login Events

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Name == "ButtonLoginSwitch")
            {
                TextBlockButtonLoginSwitch.TextDecorations = TextDecorations.Underline;
            }
            if (btn.Name == "ButtonLoginTrouble")
            {
                TextBlockButtonLoginTrouble.TextDecorations = TextDecorations.Underline;
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "ButtonLoginSwitch")
            {
                TextBlockButtonLoginSwitch.TextDecorations = null;
            }
            if (btn.Name == "ButtonLoginTrouble")
            {
                TextBlockButtonLoginTrouble.TextDecorations = null;
            }
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxLoginEmail.Text;
            string password = TextBoxLoginPassword.Password;

            if (email == "")
            {
                LabelLoginEmailError.Visibility = Visibility.Visible;
                LabelLoginPasswordError.Visibility = Visibility.Collapsed;
                LabelLoginFail.Visibility = Visibility.Collapsed;
            }
            else if (password == "")
            {
                LabelLoginEmailError.Visibility = Visibility.Collapsed;
                LabelLoginPasswordError.Visibility = Visibility.Visible;
                LabelLoginFail.Visibility = Visibility.Collapsed;
            }
            else
            {
                LabelLoginEmailError.Visibility = Visibility.Collapsed;
                LabelLoginPasswordError.Visibility = Visibility.Collapsed;

                string hashedPass = dataUtility.EncodePassword(password);

                Task<bool> loginAsync = login.UserLogin(email, hashedPass);

                //show loading bar

                bool loginResult = await loginAsync;

                if (loginResult)
                {

                    EntryView entryView = new EntryView();
                    entryView.ShowDialog();
                    this.Close();
                }
                else
                {
                    LabelLoginFail.Visibility = Visibility.Visible;
                }

                //hide loading bar

            }

            #endregion

            #endregion


        }
    }
}
