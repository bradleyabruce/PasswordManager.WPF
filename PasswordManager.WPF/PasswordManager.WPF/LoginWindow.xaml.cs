using PasswordManager.WPF.DataAccess;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PasswordManager.WPF
{
    public partial class LoginWindow : Window
    {
        #region Variables

        DataLogin login = new DataLogin();
        DataSignUp signup = new DataSignUp();
        DataUtility dataUtility = new DataUtility();

        #endregion

        #region Constructors

        public LoginWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        #region Login Events

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "ButtonLoginSwitch")
            {
                TextBlockButtonLoginSwitch.TextDecorations = TextDecorations.Underline;
            }
            if (btn.Name == "ButtonLoginTrouble")
            {
                TextBlockButtonLoginTrouble.TextDecorations = TextDecorations.Underline;
            }
            if (btn.Name == "ButtonSignUpSwitch")
            {
                TextBlockButtonSignUpSwitch.TextDecorations = TextDecorations.Underline;
            }
            if (btn.Name == "ButtonSignUpShowPassword")
            {
                TextBlockButtonSignUpShowPassword.TextDecorations = TextDecorations.Underline;
            }
            if (btn.Name == "ButtonSignUpHidePassword")
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
            //modifier for advanced options
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift) && Keyboard.IsKeyDown(Key.D))
            {
                AdvancedLogin advLogin = new AdvancedLogin();
                advLogin.Owner = this;
                advLogin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                advLogin.ShowDialog();
            }

            else
            {
                string email = TextBoxLoginEmail.Text.ToLower();
                string password = TextBoxLoginPassword.Password;

                if (email == "")
                {
                    LabelLoginEmailError.Visibility = Visibility.Visible;
                    LabelLoginPasswordError.Visibility = Visibility.Collapsed;
                }
                else if (password == "")
                {
                    LabelLoginEmailError.Visibility = Visibility.Collapsed;
                    LabelLoginPasswordError.Visibility = Visibility.Visible;
                }
                else
                {
                    LabelLoginEmailError.Visibility = Visibility.Collapsed;
                    LabelLoginPasswordError.Visibility = Visibility.Collapsed;

                    string hashedPass = dataUtility.EncodePassword(password);

                    Task<int> loginAsync = login.UserLogin(email, hashedPass);

                    LoginLoading.Visibility = Visibility.Visible;
                    ButtonLogin.Content = "";

                    int loginResult = await loginAsync;

                    LoginLoading.Visibility = Visibility.Collapsed;
                    ButtonLogin.Content = "Sign In";

                    if (loginResult == 1)
                    {
                        EntryView entryView = new EntryView();
                        this.Close();
                        entryView.ShowDialog();
                    }
                    else if (loginResult == 0)
                    {
                        DialogWindow dialog = new DialogWindow("Login Failed.", "Incorrect email or password.", "Error");
                        dialog.Owner = this;
                        dialog.ShowDialog();
                    }
                    else if (loginResult == -1)
                    {
                        DialogWindow dialog = new DialogWindow("Could not connect.", "Try again later.", "Error");
                        dialog.Owner = this;
                        dialog.ShowDialog();
                    }
                }
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
            TextBoxSignUpPassword.Focus();
            TextBoxSignUpPassword.SelectionStart = TextBoxSignUpPassword.Text.Length;
        }

        private void ButtonSignUpHidePassword_Click(object sender, RoutedEventArgs e)
        {
            string hiddenPassword = TextBoxSignUpPassword.Text;
            PassBoxSignUpPassword.Visibility = Visibility.Visible;
            TextBoxSignUpPassword.Visibility = Visibility.Collapsed;
            PassBoxSignUpPassword.Password = hiddenPassword;
            ButtonSignUpHidePassword.Visibility = Visibility.Collapsed;
            ButtonSignUpShowPassword.Visibility = Visibility.Visible;
            PassBoxSignUpPassword.Focus();
        }

        private void SignUpPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                BorderPasswordHint.Visibility = Visibility.Visible;
                ValidatePassword(textbox.Text, true);
            }
            else
            {
                PasswordBox passbox = sender as PasswordBox;
                BorderPasswordHint.Visibility = Visibility.Visible;
                ValidatePassword(passbox.Password, true);
            }
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                ValidatePassword(textbox.Text, true);
            }
            else
            {
                PasswordBox passbox = sender as PasswordBox;
                ValidatePassword(passbox.Password, true);
            }
        }

        private void SignUpPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
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

        private async void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxSignUpEmail.Text;
            string password = null;
            if (PassBoxSignUpPassword.Visibility == Visibility.Visible)
            {
                password = PassBoxSignUpPassword.Password;
            }
            else
            {
                password = TextBoxSignUpPassword.Text;
            }

            if (email == "" || email == null)
            {
                LabelSignUpEmailError.Visibility = Visibility.Visible;
                LabelSignUpPasswordError.Visibility = Visibility.Collapsed;
            }
            else if (ValidatePassword(password, false) == false)
            {
                LabelSignUpEmailError.Visibility = Visibility.Collapsed;
                LabelSignUpPasswordError.Visibility = Visibility.Visible;
            }
            else
            {
                string hashedPassword = dataUtility.EncodePassword(password);

                Task<int> SignUpAsync = signup.UserSignUp(email, hashedPassword);

                SignUpLoading.Visibility = Visibility.Visible;
                ButtonSignUp.Content = "";

                int signupResult = await SignUpAsync;

                SignUpLoading.Visibility = Visibility.Collapsed;
                ButtonSignUp.Content = "Create Account";

                if (signupResult < 1)
                {
                    BorderPasswordHint.Visibility = Visibility.Collapsed;
                    DialogWindow dialog = new DialogWindow("Account not created.", "Unable to create account. Try again later.", "Error");
                    dialog.Owner = this;
                    dialog.ShowDialog();
                }
                else
                {
                    BorderSignUp.Visibility = Visibility.Collapsed;
                    BorderLogin.Visibility = Visibility.Visible;

                    TextBoxSignUpEmail.Text = "";
                    PassBoxSignUpPassword.Password = "";
                    PassBoxSignUpPassword.Visibility = Visibility.Visible;
                    TextBoxSignUpPassword.Visibility = Visibility.Collapsed;
                    TextBoxLoginEmail.Text = "";
                    TextBoxLoginPassword.Password = "";

                    DialogWindow dialog = new DialogWindow("Success!", "You have been signed up.", "Checkmark");
                    dialog.Owner = this;
                    dialog.ShowDialog();
                }
            }
        }

        #endregion

        #endregion

        #region Methods

        public bool ValidatePassword(string password, bool changeLabels)
        {
            bool length = false;
            bool cap = false;
            bool num = false;
            bool special = false;

            if (password != "")
            {
                if (password.Length >= 8) length = true;
                else length = false;

                if (password.Any(char.IsUpper)) cap = true;
                else cap = false;

                if (password.Any(char.IsDigit)) num = true;
                else num = false;

                if (password.Any(ch => !Char.IsLetterOrDigit(ch))) special = true;
                else special = false;
            }
            else
            {
                length = false;
                cap = false;
                num = false;
                special = false;
            }

            if (changeLabels == true)
            {
                if (length) TextBlockPasswordLength.Foreground = Brushes.Green;
                else TextBlockPasswordLength.Foreground = Brushes.Red;

                if (cap) TextBlockPasswordCapitilize.Foreground = Brushes.Green;
                else TextBlockPasswordCapitilize.Foreground = Brushes.Red;

                if (num) TextBlockPasswordNumber.Foreground = Brushes.Green;
                else TextBlockPasswordNumber.Foreground = Brushes.Red;

                if (special) TextBlockPasswordSpecial.Foreground = Brushes.Green;
                else TextBlockPasswordSpecial.Foreground = Brushes.Red;
            }
            else
            {
                if (length == true && cap == true && num == true && special == true) return true;
                else return false;
            }
            return false;
        }

        #endregion

    }
}

