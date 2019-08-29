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
      #region Variables

      DataUtility du = new DataUtility();

      #endregion Variables

      #region Methods

      public async Task<BitmapImage> GetImage(string domain, double size)
      {
         try
         {
            string url = "https://logo.clearbit.com/" + domain + "?size=" + size + "&format=png";
            Uri uri = new Uri(url);
            var builder = new UriBuilder(uri);
            uri = builder.Uri;

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

      public static BitmapImage BitmapToImageSource(Bitmap bitmap)
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
            bitmapimage.Freeze();

            return bitmapimage;
         }
      }

      public BitmapImage getResponse(HttpWebRequest request)
      {
         try
         {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            //get image from stream 
            //because bitmaps do not take into consideration transparency, we need to modify it a bit
            Bitmap bmp = new Bitmap(stream);
            Bitmap transparent = DataGetLogo.ModifyTransparency(bmp);

            BitmapImage image = BitmapToImageSource(transparent);
            return image;
         }
         catch
         {
            return null;
         }
      }

      public static Bitmap ModifyTransparency(Bitmap image)
      {
         var b = new Bitmap(image.Width, image.Height);
         b.SetResolution(image.HorizontalResolution, image.VerticalResolution);
         var g = Graphics.FromImage(b);
         g.Clear(System.Drawing.Color.White);
         g.DrawImageUnscaled(image, 0, 0);

         return b;
      }

      #endregion Methods
   }
}
