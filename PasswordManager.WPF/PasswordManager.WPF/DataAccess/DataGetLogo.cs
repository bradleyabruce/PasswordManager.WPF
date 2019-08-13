using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace PasswordManager.WPF.DataAccess
{
   class DataGetLogo
   {
      DataUtility du = new DataUtility();


      public async Task<BitmapImage> GetImage(string domain)
      {
         try
         {

            string url = "https://logo.clearbit.com/" + domain + "?size=200&format=png";
            Uri uri = du.CreateURI(url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";

            BitmapImage image = await Task.Run(() => getResponse(request));
            return image;
         }
         catch
         {
            return null;
         }
      }

      BitmapImage BitmapToImageSource(Bitmap bitmap)
      {
         using (MemoryStream memory = new MemoryStream())
         {
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            memory.Position = 0;
            BitmapImage bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = memory;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();

            return bitmapimage;
         }
      }

      public BitmapImage getResponse(HttpWebRequest request)
      {
         HttpWebResponse response = (HttpWebResponse)request.GetResponse();
         Stream stream = response.GetResponseStream();

         Bitmap bmp = new Bitmap(stream);

         BitmapImage image = BitmapToImageSource(bmp);

         return image;
      }
   }
}
