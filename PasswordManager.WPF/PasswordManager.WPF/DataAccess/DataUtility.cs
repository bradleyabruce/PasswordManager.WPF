using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.WPF.DataAccess
{
    class DataUtility
    {
        #region Methods

        public HttpWebRequest SendHttp(string json, string url)
        {
            try
            {
                Uri uri = CreateURI(url);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                return request;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Uri CreateURI(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                var builder = new UriBuilder(uri);
                builder.Port = Int32.Parse(ConfigurationManager.AppSettings["Port"]);
                uri = builder.Uri;
                return uri;
            }
            catch { return null; }
        }

        public string EncodePassword(string password)
        {
            byte[] tempSource;
            byte[] tempHash;

            tempSource = UTF8Encoding.UTF8.GetBytes(password);

            //compute hash
            tempHash = new SHA1CryptoServiceProvider().ComputeHash(tempSource);

            StringBuilder build = new StringBuilder(tempHash.Length);
            for (int i = 0; i < tempHash.Length; i++)
            {
                build.Append(tempHash[i].ToString("X2"));
            }

            return build.ToString();
        }

        #endregion

        #region Certificates

        public static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        #endregion
    }
}
