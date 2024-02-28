namespace DigitaleSigner
{
    class StaticClass
    {
        private static string _CN_Name = "";
        public static string CN_Name
        {
            get { return _CN_Name; }
            set { _CN_Name = value; }
        }

        private static string _OU_Name = "";
        public static string OU_Name
        {
            get { return _OU_Name; }
            set { _OU_Name = value; }
        }

        private static string _O_Name = "";
        public static string O_Name
        {
            get { return _O_Name; }
            set { _O_Name = value; }
        }

        private static string _SerialNumber = "";
        public static string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }

        public static int UserRecno { get; set; }
        public static string UserID { get; set; }
        public static string Password { get; set; }
        public static string UserDesignation { get; set; }
        public static string UserName { get; set; }
        public static string UserMobile { get; set; }
        public static string UserEmail { get; set; }

        public static string OTP { get; set; }
        public static string OTPEmail { get; set; }

        #region SMSGetway

        public const string UID = "5349494443554c";
        public const string PIN = "098e0e924c45ed4c2108c43a24505016";
        public const string SENDER = "SIDCUL";
        public const string ROUTE = "5";
        public const string DOMAIN = "www.smsalertbox.com";

        #endregion

        #region Email

        public const string defaultPswd = "upsidc12345";
        public const string fromMail = "eodbupsidc@gmail.com";
        public const string fromMailPwd = "upsidc12345";
        public const string mailHost = "smtp.gmail.com";

        public const int mailPort = 587;

        #endregion

    }
}
