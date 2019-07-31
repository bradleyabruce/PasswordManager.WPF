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
using System.Windows.Shapes;

namespace PasswordManager.WPF
{
    /// <summary>
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow(string title, string message, string icon)
        {
            InitializeComponent();
            TextBoxTitle.Text = title;
            TextBoxDetails.Text = message;

            switch (icon)
            {
                case "Error":
                    DialogIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.PlusCircle;
                    DialogIcon.Rotation = 45;
                    DialogIcon.Foreground = Brushes.Red;
                    break;

                case "Checkmark":
                    DialogIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.CheckCircle;
                    DialogIcon.Foreground = Brushes.Green;
                    break;
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
