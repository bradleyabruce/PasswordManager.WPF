using PasswordManager.WPF.DataAccess;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PasswordManager.WPF.UserControls
{
   /// <summary>
   /// Interaction logic for PasswordCard.xaml
   /// </summary>
   public partial class PasswordCard : UserControl
   {
      #region Variables
      DataGetLogo dgl = new DataGetLogo();


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


      public async PasswordCard(string entryid, string domain, string username, string password, string category)
      {
         InitializeComponent();
         Domain = domain;

         Task<BitmapImage> imageasync = dgl.GetImage(domain);

         //loading

         BitmapImage image = await imageasync;
         if (image != null)
         {
            ImageBox.Visibility = Visibility.Visible;
            IconBox.Visibility = Visibility.Collapsed;
            ImageBox.Source = image;
         }
         else
         {
            //otherwise set default icon
            ImageBox.Visibility = Visibility.Collapsed;
            IconBox.Visibility = Visibility.Visible;
            IconBox.Icon = FontAwesome.WPF.FontAwesomeIcon.Key;
         }
      }

      private void Border_MouseEnter(object sender, MouseEventArgs e)
      {
         Border border = sender as Border;
         border.Background = System.Windows.Media.Brushes.LightBlue;
         TextBoxDomainName.Background = System.Windows.Media.Brushes.LightBlue;
         this.Cursor = Cursors.Hand;
      }

      private void Border_MouseLeave(object sender, MouseEventArgs e)
      {
         Border border = sender as Border;
         border.Background = System.Windows.Media.Brushes.White;
         TextBoxDomainName.Background = System.Windows.Media.Brushes.White;
         this.Cursor = Cursors.Arrow;
      }
   }
}
