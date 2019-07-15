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

            //set images to buttons
            ImageSource imageSourcebuttonUserMenuDropDownArrow = new BitmapImage(new Uri("/img/DropDownArrow.png", UriKind.Relative));
            buttonUserMenuDropDownArrowImage.Source = imageSourcebuttonUserMenuDropDownArrow;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        #endregion

        #region

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridLength gl = new GridLength(500);
            ColumnDefinitionMenu.Width = gl;
        }

        private void ButtonUserMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            textboxUserName.Background = (Brush)converter.ConvertFrom("#BEE6FD");
        }

        private void ButtonUserMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            textboxUserName.Background = Brushes.LightBlue;
        }

        #endregion
    }
}
