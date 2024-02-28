using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;
using Newtonsoft.Json.Linq;

namespace UpsidaAllottee.RMPanel
{
    public partial class MainUser : System.Web.UI.MasterPage
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string lbldesignationid = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getinfomobileview();
                lblname.Text = Convert.ToString(Session["UserName"]);
            }
            catch
            {
                Response.Redirect("/RMPanel/RMLogin");
            }

            if (lblname.Text == "")
            {
                Response.Redirect("/RMPanel/RMLogin");
            }
            else
            {             

                lblname.Text = Convert.ToString(Session["UserName"]);
                if (!IsPostBack)
                {
                    GetUserRecord(lblname.Text, Session["Type"].ToString().Trim());                   
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            // Page.RegisterRequiresControlState(this);
            getinfomobileview();
        }
        public void getinfomobileview()
        {
            try
            {
                if (Request.QueryString.AllKeys.Contains("Request_Source") && Request.QueryString.AllKeys.Contains("Token"))
                {
                    if (Request.QueryString["Request_Source"] == "Mobile" && Request.QueryString["Token"] != "")
                    {
                        try
                        {
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                            string json = "";
                            string url = "https://upsidc.infoneotech.com/api/UserProfile";
                            using (var webClient = new System.Net.WebClient())
                            {
                                webClient.Headers.Add("Authorization", "Bearer " + Request.QueryString["Token"]);// ED272819-145C-4790-B9E5-98A3AF7F4C33-3");
                                json = webClient.UploadString(url, "Post", "");
                            }
                            // dynamic dynObj = JsonConvert.DeserializeObject(json);
                            var details = JObject.Parse(json);
                            string mydata = details["data"].ToString();
                            var metadata = JObject.Parse(mydata);
                            string strType = "1";
                            int userId = int.Parse(metadata["Id"].ToString());
                            string strName = metadata["UserName"].ToString();
                            LoginInfo _objLoginInfo = new LoginInfo(strName, strType, userId);
                            Session["objLoginInfo"] = _objLoginInfo;
                            Session["UserName"] = strName;
                            Session["Type"] = strType;

                            // create a new GUID and save into the session
                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;
                            // now create a new cookie with this guid value
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            Response.Cookies["AuthToken"].Secure = true;
                        }
                        catch (Exception ex)
                        {
                            getinfomobileview();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

        public void GetUserRecord(string username, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = username;
            // LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {/// lblempname.Text = ds.Tables[0].Rows[0][2].ToString();
                    //lblempcode.Text = ds.Tables[0].Rows[0][3].ToString();
                    lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    lblDataManager.Text = ds.Tables[0].Rows[0]["DataManager"].ToString();
                    //lblGrade.Text = ds.Tables[0].Rows[0][5].ToString();
                    //lblQualification.Text = ds.Tables[0].Rows[0][6].ToString();
                    //lblemail.Text = ds.Tables[0].Rows[0][7].ToString();
                    //lblPhone.Text = ds.Tables[0].Rows[0][8].ToString();
                    int userID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    LoginInfo _objLoginInfo = new LoginInfo(username, category, userID);
                    Session["objLoginInfo"] = _objLoginInfo;

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                //objServiceTimelinesBEL = null;
                //objServiceTimelinesBLL = null;
            }


            //masterMenu(Session["Type"].ToString().Trim());
        }       

    }
}