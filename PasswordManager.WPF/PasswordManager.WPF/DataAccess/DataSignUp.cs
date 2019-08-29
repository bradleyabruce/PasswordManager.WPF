using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace PasswordManager.WPF.DataAccess
{
   class DataSignUp
    {
        #region Variables

        DataUtility dataUtility = new DataUtility();

        #endregion

        #region Events

        public async Task<int> UserSignUp(string email, string hashedPassword)
        {
            DataUtility.IgnoreBadCertificates();

            string signUpUrl = ConfigurationManager.AppSettings["ServerAddress"] + ConfigurationManager.AppSettings["SignUpFunction"];
            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, signUpUrl));

            //validate
            if (request == null)
            {
                return -1;
            }

            bool signupResult = await Task.Run(() => ReceiveSignUpHttp(request));

            //validate
            if (signupResult == false)
            {
                return 0;
            }

            return 1;
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
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
