using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PasswordManager.WPF.DataObjects
{
   public class PasswordEntryObject
   {
      public PasswordEntryObject()
      {
         EntryID = null;
         WebsiteDomain = null;
         WebsiteUsername = null;
         WebsitePassword = null;
         CategoryID = null;
         image = null;
      }

      #region Properties

      public string EntryID { get; set; }
      public string WebsiteDomain { get; set; }
      public string WebsiteUsername { get; set; }
      public string WebsitePassword { get; set; }
      public string CategoryID { get; set; }
      public BitmapImage image { get; set; }

      #endregion Properties

   }
}
