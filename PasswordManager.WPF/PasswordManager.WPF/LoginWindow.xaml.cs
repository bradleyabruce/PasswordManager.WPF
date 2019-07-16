using PasswordManager.WPF.DataAccess;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            if(btn.Name == "ButtonSignUpSwitch")
            {
                TextBlockButtonSignUpSwitch.TextDecorations = TextDecorations.Underline;
            }
            if (btn.Name == "ButtonSignUpShowPassword")
            {
                TextBlockButtonSignUpShowPassword.TextDecorations = TextDecorations.Underline;
            }
            if(btn.Name == "ButtonSignUpHidePassword")
            {
                TextBlockButtonSignUpHidePassword.TextDecorations = TextDecorations.Underline;
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
            if (btn.Name == "ButtonSignUpSwitch")
            {
                TextBlockButtonSignUpSwitch.TextDecorations = null;
            }
            if (btn.Name == "ButtonSignUpShowPassword")
            {
                TextBlockButtonSignUpShowPassword.TextDecorations = null;
            }
            if (btn.Name == "ButtonSignUpHidePassword")
            {
                TextBlockButtonSignUpHidePassword.TextDecorations = null;
            }
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxLoginEmail.Text.ToLower();
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

                LoginLoading.Visibility = Visibility.Visible;
                ButtonLogin.Content = "";

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

                LoginLoading.Visibility = Visibility.Collapsed;
                ButtonLogin.Content = "Sign In";
            }
        }

        #endregion

        #region Sign Up

        private void ButtonSignUpSwitch_Click(object sender, RoutedEventArgs e)
        {
            BorderSignUp.Visibility = Visibility.Collapsed;
            BorderLogin.Visibility = Visibility.Visible;
        }

        private void ButtonLoginSwitch_Click(object sender, RoutedEventArgs e)
        {
            BorderSignUp.Visibility = Visibility.Visible;
            BorderLogin.Visibility = Visibility.Collapsed;
        }

        private void ButtonSignUpShowPassword_Click(object sender, RoutedEventArgs e)
        {
            string hiddenPassword = PassBoxSignUpPassword.Password;
            PassBoxSignUpPassword.Visibility = Visibility.Collapsed;
            TextBoxSignUpPassword.Visibility = Visibility.Visible;
            TextBoxSignUpPassword.Text = hiddenPassword;
            ButtonSignUpHidePassword.Visibility = Visibility.Visible;
            ButtonSignUpShowPassword.Visibility = Visibility.Collapsed;
        }

        private void ButtonSignUpHidePassword_Click(object sender, RoutedEventArgs e)
        {
            string hiddenPassword = TextBoxSignUpPassword.Text;
            PassBoxSignUpPassword.Visibility = Visibility.Visible;
            TextBoxSignUpPassword.Visibility = Visibility.Collapsed;
            PassBoxSignUpPassword.Password = hiddenPassword;
            ButtonSignUpHidePassword.Visibility = Visibility.Collapsed;
            ButtonSignUpShowPassword.Visibility = Visibility.Visible;
        }






        #endregion

        #endregion

        private void SignUpPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if(textbox != null)
            {
                BorderPasswordHint.Visibility = Visibility.Visible;
                ValidatePassword(textbox.Text);
            }
            else
            {
                PasswordBox passbox = sender as PasswordBox;
                BorderPasswordHint.Visibility = Visibility.Visible;
                ValidatePassword(passbox.Password);
            }
        }

        public void ValidatePassword(string password)
        {
            if (password != "")
            {
                if (password.Length >= 8)
                {
                    TextBlockPasswordLength.Foreground = Brushes.Green;
                }
                else
                {
                    TextBlockPasswordLength.Foreground = Brushes.Red;
                }
                if (password.Any(char.IsDigit))
                {
                    TextBlockPasswordNumber.Foreground = Brushes.Green;
                }
                else
                {
                    TextBlockPasswordNumber.Foreground = Brushes.Red;
                }
                //var regexItem = new Regex("[a-z0-9 ]+", RegexOptions.IgnoreCase);
                if (password.Any(ch => !Char.IsLetterOrDigit(ch)))
                {
                    TextBlockPasswordSpecial.Foreground = Brushes.Green;
                }
                else
                {
                    TextBlockPasswordSpecial.Foreground = Brushes.Red;
                }
            }
            else
            {
                TextBlockPasswordSpecial.Foreground = Brushes.Red;
            }
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                ValidatePassword(textbox.Text);
            }
            else
            {
                PasswordBox passbox = sender as PasswordBox;
                ValidatePassword(passbox.Password);
            }
        }

        private void SignUpPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void SignUpPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                BorderPasswordHint.Visibility = Visibility.Collapsed;
            }
            else
            {
                PasswordBox passbox = sender as PasswordBox;
                BorderPasswordHint.Visibility = Visibility.Collapsed;
            }
        }
    }
}
