using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using PasswordManager.WPF.DataAccessObject;
using System.IO;
using System.Web.Script.Serialization;

namespace PasswordManager.WPF.DataAccess
{
    class DataLogin
    {
        #region Variables

        DataUtility dataUtility = new DataUtility();

        #endregion

        #region Methods

        public async Task<int> UserLogin(string email, string hashedPassword)
        {
            DataUtility.IgnoreBadCertificates();

            string userID = "";
            string userEmail = "";
            string userPassword = "";

            string loginUrl = ConfigurationManager.AppSettings["BaseUrl"] + ConfigurationManager.AppSettings["LoginFunction"];
            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, loginUrl));

            //validate
            if (request == null)
            {
                return -1;
            }

            LoginObject loginObject = await Task.Run(() => ReceiveLoginHttp(request));

            //validate
            if (loginObject.Result == false)
            {
                return 0;
            }
            else
            {
                userID = loginObject.UserID;
                userEmail = loginObject.UserLoginEmail;
                userPassword = loginObject.UserLoginPassword;

                if (userEmail == email && userPassword == hashedPassword)
                {
                    if (userID != "")
                    {
                        App.Current.Properties["UserID"] = userID;
                        App.Current.Properties["UserEmail"] = userEmail;
                    }
                    else { return 0; }
                }
                else { return 0; }

                return 1;
            }
        }

        public LoginObject ReceiveLoginHttp(HttpWebRequest request)
        {
            string result;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            try
            {
                var serializer = new JavaScriptSerializer();
                var loginObjects = serializer.Deserialize<List<LoginObject>>(result);

                loginObjects[0].Result = true;
                return loginObjects[0];
            }
            catch (Exception Ex)
            {
                LoginObject errorObject = new LoginObject();
                errorObject.Result = false;
                return errorObject;
            }
        }
        #endregion
    }
}
