using PasswordManager.WPF.DataAccess;
using PasswordManager.WPF.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace PasswordManager.WPF.UserControls
{
   /// <summary>
   /// Interaction logic for PasswordRow.xaml
   /// </summary>
   public partial class PasswordRow : UserControl
   {

      #region Variables 
      DataGetLogo dgl = new DataGetLogo();

      private BitmapImage _image;
      public BitmapImage Image
      {
         get { return _image; }
         set
         {
           _image = value;
            if (_image != null)
            {
               ImageWebsiteIcon.Source = _image;
                  //ImageWebsiteIcon.Visibility = Visibility.Visible;
                  //LoadingImage.Visibility = Visibility.Collapsed;

            }
            else
            {
               //show generic icon
               //LoadingImage.Visibility = Visibility.Collapsed;
            }
         }
      }


      #endregion End Variables


      public PasswordRow(PasswordEntryObject passwordEntry)
      {
         InitializeComponent();
         TextboxDomainName.Text = passwordEntry.WebsiteDomain;
         TextboxUsername.Text = passwordEntry.WebsiteUsername;


         GetImage(passwordEntry.WebsiteDomain);

      }

      public async void GetImage(string domain)
      {

            Task<BitmapImage> asyncImage = dgl.GetImage(domain, this.Height);
            BitmapImage image = await asyncImage;
         if(image != null)
         {
            ImageWebsiteIcon.Source = image;
            ImageWebsiteIcon.Visibility = Visibility.Visible;
            LoadingImage.Visibility = Visibility.Collapsed;
         }
         else
         {
            LoadingImage.Visibility = Visibility.Collapsed;
            ErrorImage.Visibility = Visibility.Visible;
         }





      }

      public void SetImage(BitmapImage image)
      {

      }

   }
}
