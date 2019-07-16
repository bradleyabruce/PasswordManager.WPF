using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WPF.DataAccess
{
    class DataSignUp
    {
        #region Variables

        DataUtility dataUtility = new DataUtility();

        #endregion

        #region Events

        public async Task<bool> UserSignUp(string email, string hashedPassword)
        {
            DataUtility.IgnoreBadCertificates();

            string signUpUrl = ConfigurationManager.AppSettings["BaseUrl"] + ConfigurationManager.AppSettings["SignUpFunction"];
            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, signUpUrl));

            //validate
            if (request == null)
            {
                return false;
            }

            bool signupResult = await Task.Run(() => ReceiveSignUpHttp(request));

            //validate
            if (signupResult == false)
            {
                return false;
            }

            return signupResult;
        }

        public bool ReceiveSignUpHttp(HttpWebRequest request)
        {
            string result;
            List<string> returnedList = new List<string>();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            try
            {
                if (result == "Email and password Required")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        #endregion
    }
}
