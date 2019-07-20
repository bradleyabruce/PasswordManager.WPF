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

namespace PasswordManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EntryView : Window
    {
        #region Constructors

        public EntryView()
        {
            InitializeComponent();          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string userID = App.Current.Properties["UserID"].ToString();
            string email = App.Current.Properties["UserEmail"].ToString();

            ButtonUser.Content = email + " ⯆";

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
            if (BorderUserSettings.Visibility == Visibility.Collapsed)
            {
                BorderUserSettings.Visibility = Visibility.Visible;
            }
            else
            {
                BorderUserSettings.Visibility = Visibility.Collapsed;
            }
        }

        #region Menu Events

        #endregion

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            var converter = new BrushConverter();
            grid.Background = (Brush)converter.ConvertFrom("#666666");
            this.Cursor = Cursors.Hand;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            var converter = new BrushConverter();
            grid.Background = (Brush)converter.ConvertFrom("#808080");
            this.Cursor = Cursors.Arrow;
        }
    }
}
