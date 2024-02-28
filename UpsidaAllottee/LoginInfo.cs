using System;

namespace UpsidaAllottee
{
    [Serializable]
    public class LoginInfo
    {


        //Default Constructor
        public LoginInfo()
        {

        }

        public LoginInfo(string strName, string strRoll)
        {
            this.Roll = strRoll;
            this.userName = strName;
        }

        public LoginInfo(string strName, string strRoll, int struserid)
        {
            this.Roll = strRoll;
            this.userName = strName;
            this.userid = struserid;
        }

        private string strRoll;
        private string strName;

        private int struserid;


        public string Roll
        {
            get
            {
                return strRoll;
            }
            set
            {
                strRoll = value;
            }
        }

        public int userid
        {
            get
            {
                return struserid;
            }
            set
            {
                struserid = value;
            }
        }


        public string userName
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }


    }


}