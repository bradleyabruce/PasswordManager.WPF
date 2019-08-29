using PasswordManager.WPF.DataObjects;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PasswordManager.WPF.DataAccess
{
   class DataPasswordRetrieval
   {
      #region Variables

      DataUtility dataUtility = new DataUtility();

      #endregion

      #region Methods

      public async Task<List<PasswordEntryObject>> RetreivePasswords(string userID, string categoryID)
      {
         DataUtility.IgnoreBadCertificates();

         string retreivalUrl = ConfigurationManager.AppSettings["ServerAddress"] + ConfigurationManager.AppSettings["RetrievalFunction"];
         string json = "{\"userid\": \"" + userID + "\", \"categoryid\": \"" + categoryID + "\"}";

         HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, retreivalUrl));

         //validate
         if (request == null)
         {
            return null;
         }
         List<PasswordEntryObject> passwords = await Task.Run(() => ReceiveRetreivalHttp(request));

         return passwords;
      }

      public List<PasswordEntryObject> ReceiveRetreivalHttp(HttpWebRequest request)
      {
         List<PasswordEntryObject> passwords = new List<PasswordEntryObject>();
         string result;

         HttpWebResponse response = (HttpWebResponse)request.GetResponse();

         using (var streamReader = new StreamReader(response.GetResponseStream()))
         {
            result = streamReader.ReadToEnd();
         }

         try
         {
            var serializer = new JavaScriptSerializer();
            var passwordObjects = serializer.Deserialize<List<PasswordEntryObject>>(result);

            foreach (PasswordEntryObject password in passwordObjects)
            {
               passwords.Add(password);
            }
         }
         catch
         {
            return null;
         }

         return passwords;
      }

      #endregion Mathods
   }
}
