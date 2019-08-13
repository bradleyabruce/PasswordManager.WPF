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

namespace PasswordManager.WPF.UserControls
{
   /// <summary>
   /// Interaction logic for PasswordCard.xaml
   /// </summary>
   public partial class PasswordCard : UserControl
   {
      #region Variables

      private string _domain;
      public string Domain
      {
         get { return _domain; }
         set
         {
            _domain = value;
            TextBoxDomainName.Text = _domain;
         }
      }


      #endregion Variables


      public PasswordCard(string entryid, string domain, string username, string password, string category)
      {
         InitializeComponent();
         Domain = domain;

         //TODO look up website icon

         //otherwise set default icon
         ImageBox.Visibility = Visibility.Collapsed;
         IconBox.Visibility = Visibility.Visible;
         IconBox.Icon = FontAwesome.WPF.FontAwesomeIcon.Key;
      }

      private void Border_MouseEnter(object sender, MouseEventArgs e)
      {
         Border border = sender as Border;
         border.Background = Brushes.LightBlue;
         TextBoxDomainName.Background = Brushes.LightBlue;
         this.Cursor = Cursors.Hand;
      }

      private void Border_MouseLeave(object sender, MouseEventArgs e)
      {
         Border border = sender as Border;
         border.Background = Brushes.White;
         TextBoxDomainName.Background = Brushes.White;
         this.Cursor = Cursors.Arrow;
      }
   }
}
