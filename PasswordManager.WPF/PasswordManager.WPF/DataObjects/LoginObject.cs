namespace PasswordManager.WPF.DataAccessObject
{
    public class LoginObject
    {
        #region Constructors

        public LoginObject()
        {
            UserID = null;
            UserLoginEmail = null;
            UserLoginPassword = null;
            Result = null;
        }

        #endregion

        #region Properties

        public string UserID { get; set; }
        public string UserLoginEmail { get; set; }
        public string UserLoginPassword { get; set; }
        public bool? Result { get; set; }

        #endregion
    }
}
