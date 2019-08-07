using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PasswordManager.WPF;
using PasswordManager.WPF.DataAccess;

namespace PasswordManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EntryView : Window
    {
        #region Variables

        private bool _menuCollapsed;
        public bool MenuCollapsed
        {
            get
            {
                return _menuCollapsed;
            }
            set
            {
                _menuCollapsed = value;
                if (_menuCollapsed)
                {
                    GridLength gl = new GridLength(110);
                    ColumnDefinitionMenu.Width = gl;
                    IconMenuOpen.Icon = FontAwesome.WPF.FontAwesomeIcon.ArrowRight;
                }
                else
                {
                    GridLength gl = new GridLength(320);
                    ColumnDefinitionMenu.Width = gl;
                    IconMenuOpen.Icon = FontAwesome.WPF.FontAwesomeIcon.ArrowLeft;
                }
            }
        }

        private bool _userSettingsCollapsed;
        public bool UserSettingsCollapsed
        {
            get
            {
                return _userSettingsCollapsed;
            }
            set
            {
                _userSettingsCollapsed = value;
                if (_userSettingsCollapsed)
                {
                    BorderUserSettings.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BorderUserSettings.Visibility = Visibility.Visible;
                }
            }
        }

        private string _gridSort;
        public string GridSort
        {
            get { return _gridSort; }
            set
            {
                _gridSort = value;
                //TODO do sort stuff
            }
        }

        private bool _resultsGrid;
        public bool ResultsGrid
        {
            get { return _resultsGrid; }
            set
            {
                _resultsGrid = value;
                var converter = new BrushConverter();
                if (_resultsGrid)
                {
                    GridView.Foreground = Brushes.White;
                    BorderButtonGridView.Background = (Brush)converter.ConvertFrom("#0066ff");

                    IconView.Foreground = Brushes.Gray;
                    BorderButtonIconView.Background = (Brush)converter.ConvertFrom("#e6e6e6");

                    //TODO add grid change
                }
                else
                {
                    IconView.Foreground = Brushes.White;
                    BorderButtonIconView.Background = (Brush)converter.ConvertFrom("#0066ff");

                    GridView.Foreground = Brushes.Gray;
                    BorderButtonGridView.Background = (Brush)converter.ConvertFrom("#e6e6e6");

                    //TODO add grid change
                }
            }
        }

        public string[] sortOptionsArray = { "Category A-Z", "Category Z-A", "Website A-Z", "Website Z-A", "Newest to Oldest", "Oldest to Neweset" };

        public bool UserChanged = true;

        #endregion Variables




        #region Constructors

        public EntryView()
        {
            InitializeComponent();
            MenuCollapsed = true;
            UserSettingsCollapsed = true;
            GridSort = "ASC";
            ResultsGrid = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string userID = "test";//App.Current.Properties["UserID"].ToString();
                string email = "test"; //App.Current.Properties["UserEmail"].ToString();
                ButtonUser.Content = ":)";
                UserSettingsEmailLabel.Content = email;
                UserSettingsUserNameLabel.Content = email;


                SetsortOptions(sortOptionsArray);
            }
            catch
            {
                //let user know there is an issue
                DialogWindow dialog = new DialogWindow("Application Error", "Could not Load Application Data", "Error");
                dialog.Owner = this;
                dialog.ShowDialog();

                //go back to sign in screen
                LoginWindow loginWindow = new LoginWindow();
                this.Close();
                loginWindow.ShowDialog();

            }
        }

        #endregion

        #region Nav Events

        private void ButtonUserMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            //textboxUserName.Background = (Brush)converter.ConvertFrom("#BEE6FD");
        }

        private void ButtonUserMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            //textboxUserName.Background = Brushes.LightBlue;
        }

        #endregion

        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserSettingsCollapsed)
            {
                UserSettingsCollapsed = false;
            }
            else
            {
                UserSettingsCollapsed = true;
            }
        }

        #region Menu Events

        #endregion

        private void Menu_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null)
            {
                var converter = new BrushConverter();
                grid.Background = (Brush)converter.ConvertFrom("#666666");
            }
            this.Cursor = Cursors.Hand;
        }

        private void Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null)
            {
                var converter = new BrushConverter();
                grid.Background = (Brush)converter.ConvertFrom("#808080");
            }
            this.Cursor = Cursors.Arrow;
        }

        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;
            string name = grid.Name;

            if (name == "MenuCollapse")
            {
                if (MenuCollapsed)
                {
                    MenuCollapsed = false;
                }
                else
                {
                    MenuCollapsed = true;
                }
            }
            else
            {
                //do nothing
            }
        }

        private void TextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                textBlock.TextDecorations = TextDecorations.Underline;
                this.Cursor = Cursors.Hand;
            }
        }

        private void TextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                textBlock.TextDecorations = null; ;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void UserSettingsSignOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["UserID"] = null;
            App.Current.Properties["UserEmail"] = null;

            LoginWindow login = new LoginWindow();
            this.Close();
            login.ShowDialog();
            login.HorizontalAlignment = HorizontalAlignment.Center;
            login.VerticalAlignment = VerticalAlignment.Center;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void ButtonSort_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (GridSort == "ASC")
            {
                GridSort = "DESC";
            }
            else if (GridSort == "DESC")
            {
                GridSort = "ASC";
            }
        }

        private void ResultIconView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResultsGrid = false;
        }

        private void ResultGridView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResultsGrid = true;
        }


        #region Methods

        public void SetsortOptions(string[] array)
        {
            ComboBoxSort.ItemsSource = array;

            ComboBoxSort.SelectedIndex = 0;
        }


        #endregion Methods

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridSort = ComboBoxSort.SelectedItem.ToString();
        }
    }
}
