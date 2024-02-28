using BEL_Allotment;
using BLL_Allotment;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Collections;

namespace UpsidaAllottee
{
    public partial class OTSAllotteeLedgerSummary : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        string level = "";
        string IndustrialArea = "";
        #endregion
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexPhoneNo = new Regex(@"^[0-9]{10}$");
        Hashtable htControls = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            htControls.Add("LinkButton", "Text");
            htControls.Add("HyperLink", "Text");
            htControls.Add("DropDownList", "SelectedItem");
            htControls.Add("CheckBox", "Checked");
            try
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
                level = Convert.ToString(Session["Level"]);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                if (level == "Admin1" || level == "MD" || level == "JMD")
                {
                    dlRO.Enabled = true;
                }
                else
                {
                    dlRO.Enabled = true;
                    //dlRO.Enabled = false;
                }
            }
            catch
            {
                Response.Redirect("/loginpage.aspx");
            }

            if (lblname.Text == "")
            {
                Response.Redirect("/loginpage.aspx");
            }
            else
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
            }
            if (!IsPostBack)
            {
                if (level == "RM")
                {
                    //Grid_OTSscheme1.Visible = false;
                    GetUserRecord(lblname.Text, Session["Type"].ToString().Trim());
                    bindRegionalOffice_RM(lblname.Text);
                   // GetIAAssociatedWithRM(UserName, Session["Type"].ToString().Trim());
                    //GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                }
                else
                {
                    //Grid_OTSscheme.Visible = false;
                    
                    bindRegionalOffice();
                    //GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                }

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
                {
                    //lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    //lblDataManager.Text = ds.Tables[0].Rows[0]["DataManager"].ToString();
                    int userID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    LoginInfo _objLoginInfo = new LoginInfo(username, category, userID);
                    Session["objLoginInfo"] = _objLoginInfo;

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        

         private void bindRegionalOffice_RM(string userName)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office_RM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", userName);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            dlRO.Items.Insert(0, liRegional);
        }
        private void bindRegionalOffice()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            dlRO.Items.Insert(0, liRegional);
        }

        protected DataSet ViewFillPlots(string RegOff)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("select count(p.PlotNumber) as PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId=B.ID  WHERE P.status IN ('3','4','5','6','7') and b.RegionalOffice  ='" + RegOff + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
            }
            return ds;
        }
        protected DataSet FillTotAllotte(string RegOff)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("select  count(A.AllotteeID) AS Allottee  from   AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea=B.IAName  WHERE a.isActive='0' AND A.isCompleted='1' and b.RegionalOffice  ='" + RegOff + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
            }
            return ds;
        }

        protected DataSet FillTotDemands(string RegOff)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("select   sum(isnull(Debit,0.00)) 'Demanded',Sum(ISNULL(Credit,0.00)) 'Paid',(sum(isnull(Debit,0.00))-sum(ISnull(Credit,0.00))) 'Outstanding' from tbl_AllotteePaymentJournal T inner join AllotteeMaster A on t.AllotteeID=a.AllotteeID inner join IndustrialArea B on A.IndustrialArea=B.IAName WHERE  A.isCompleted='1' AND A.isActive = '0' AND B.RegionalOffice='" + RegOff + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
            }
            return ds;
        }

        protected DataSet FillGridDemands(string RegOff)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,B.IANAme,A.PlotNo,A.AllotteeID,case when isnull(A.AllotteeName,'')>'' then A.AllotteeName else A.CompanyName end 'AllotteeName', sum(isnull(Debit,0.00)) 'Demanded',Sum(ISNULL(Credit,0.00)) 'Paid', (sum(isnull(Debit,0.00))-sum(ISnull(Credit,0.00))) 'Outstanding',  (select top 1 ModifiedOn from tbl_AllotteePaymentJournal where AllotteeID=A.AllotteeID order by id desc )as ModifiedOn from AllotteeMaster A Left join tbl_AllotteePaymentJournal T  on t.AllotteeID=a.AllotteeID inner join IndustrialArea B on A.IndustrialArea=B.IAName WHERE A.isCompleted='1' AND A.isActive = '0' AND  B.RegionalOffice='" + RegOff + "' group by B.RegionalOffice,B.IANAme,AllotteeName ,CompanyName,A.AllotteeID,A.PlotNo order by B.RegionalOffice,B.IANAme,AllotteeName,A.AllotteeID,A.PlotNo ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
            }
            return ds;
        }

        protected DataSet FillGridDemandsB(string RegOff)
        {
            DataSet ds = new DataSet();
            try
            {
                //SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,B.IANAme,A.PlotNo,A.AllotteeID,case when isnull(A.AllotteeName,'')>'' then A.AllotteeName else A.CompanyName end 'AllotteeName', sum(isnull(Debit,0.00)) 'Demanded',Sum(ISNULL(Credit,0.00)) 'Paid', (sum(isnull(Debit,0.00))-sum(ISnull(Credit,0.00))) 'Outstanding',  (select top 1 ModifiedOn from tbl_AllotteePaymentJournal where AllotteeID=A.AllotteeID order by id desc )as ModifiedOn from tbl_AllotteePaymentJournal T inner join AllotteeMaster A on t.AllotteeID=a.AllotteeID inner join IndustrialArea B on A.IndustrialArea=B.IAName WHERE  B.RegionalOffice='" + RegOff + "' group by B.RegionalOffice,B.IANAme,AllotteeName ,CompanyName,A.AllotteeID,A.PlotNo order by B.RegionalOffice,B.IANAme,AllotteeName,A.AllotteeID,A.PlotNo  ", con);
                SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,(select count(p.PlotNumber) as PlotNumber  FROM PlotMaster P Left join  IndustrialArea I on P.IAId=I.ID  WHERE P.status IN ('3','4','5','6','7')  AND I.RegionalOffice='" + RegOff + "') AS PlotNo, (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isCompleted='1' AND A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') AS Allottee, (select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where A.isCompleted='1' AND A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN (SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where A.isCompleted='1' AND B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS Modified,  (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isCompleted='1' AND A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') -(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where A.isCompleted='1' AND B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN (SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where A.isCompleted='1' AND A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS ModifiedREmain from AllotteeMaster A   inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isCompleted='1' AND  B.RegionalOffice = '" + RegOff + "' GROUP BY B.RegionalOffice", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
            }
            return ds;
        }

        protected DataSet FillGridDemandsBINDUSTRIAL(string RegOff)
        {
            DataSet ds = new DataSet();
            try
            {
                //SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,B.IANAme,A.PlotNo,A.AllotteeID,case when isnull(A.AllotteeName,'')>'' then A.AllotteeName else A.CompanyName end 'AllotteeName', sum(isnull(Debit,0.00)) 'Demanded',Sum(ISNULL(Credit,0.00)) 'Paid', (sum(isnull(Debit,0.00))-sum(ISnull(Credit,0.00))) 'Outstanding',  (select top 1 ModifiedOn from tbl_AllotteePaymentJournal where AllotteeID=A.AllotteeID order by id desc )as ModifiedOn from tbl_AllotteePaymentJournal T inner join AllotteeMaster A on t.AllotteeID=a.AllotteeID inner join IndustrialArea B on A.IndustrialArea=B.IAName WHERE  B.RegionalOffice='" + RegOff + "' group by B.RegionalOffice,B.IANAme,AllotteeName ,CompanyName,A.AllotteeID,A.PlotNo order by B.RegionalOffice,B.IANAme,AllotteeName,A.AllotteeID,A.PlotNo  ", con);
                //SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,(select count(p.PlotNumber) as PlotNumber  FROM PlotMaster P Left join  IndustrialArea I on P.IAId=I.ID  WHERE P.status IN ('3','4','5','6','7') and P.landuseCode='2'  AND I.RegionalOffice='" + RegOff + "') AS PlotNo, (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') AS Allottee, (select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN(SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS Modified,  (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') -(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN (SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS ModifiedREmain from AllotteeMaster A   inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE  B.RegionalOffice = '" + RegOff + "' GROUP BY B.RegionalOffice", con);
                SqlCommand cmd = new SqlCommand(" select  B.RegionalOffice,(select count(p.PlotNumber) as PlotNumber  FROM PlotMaster P Left join  IndustrialArea I on P.IAId = I.ID  WHERE P.status IN('3', '4', '5', '6', '7') and P.landuseCode = '2'  AND I.RegionalOffice = '" + RegOff + "') AS PlotNo, (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isCompleted='1' AND  A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "' AND a.PlotNo IN(select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID  WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2') ) AS Allottee,(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where A.isCompleted='1' AND A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "'  AND A.allotteeID IN(SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where A.isCompleted='1' AND B.RegionalOffice = '" + RegOff + "' and ModifiedOn BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID) AND a.PlotNo IN(select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID   WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2') ) AS Modified,  (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isCompleted='1' AND A.isActive = '0' AND  B.RegionalOffice = '" + RegOff + "' AND a.PlotNo IN(select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2')) -(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea= B.IAName where A.isCompleted='1' AND A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN (SELECT  t.AllotteeID FROM tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID) AND a.PlotNo IN (select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID  WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2')) AS ModifiedREmain from AllotteeMaster A   inner join IndustrialArea B on A.IndustrialArea = B.IAName    WHERE  A.isCompleted='1' AND  B.RegionalOffice = '" + RegOff + "' GROUP BY B.RegionalOffice", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
            }
            return ds;
        }

        //protected DataSet FillGridDemandsNotTrans(string RegOff)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        //SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,B.IANAme,A.PlotNo,A.AllotteeID,case when isnull(A.AllotteeName,'')>'' then A.AllotteeName else A.CompanyName end 'AllotteeName', sum(isnull(Debit,0.00)) 'Demanded',Sum(ISNULL(Credit,0.00)) 'Paid', (sum(isnull(Debit,0.00))-sum(ISnull(Credit,0.00))) 'Outstanding',  (select top 1 ModifiedOn from tbl_AllotteePaymentJournal where AllotteeID=A.AllotteeID order by id desc )as ModifiedOn from tbl_AllotteePaymentJournal T inner join AllotteeMaster A on t.AllotteeID=a.AllotteeID inner join IndustrialArea B on A.IndustrialArea=B.IAName WHERE  B.RegionalOffice='" + RegOff + "' group by B.RegionalOffice,B.IANAme,AllotteeName ,CompanyName,A.AllotteeID,A.PlotNo order by B.RegionalOffice,B.IANAme,AllotteeName,A.AllotteeID,A.PlotNo  ", con);
        //        //SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,(select count(p.PlotNumber) as PlotNumber  FROM PlotMaster P Left join  IndustrialArea I on P.IAId=I.ID  WHERE P.status IN ('3','4','5','6','7') and P.landuseCode='2'  AND I.RegionalOffice='" + RegOff + "') AS PlotNo, (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') AS Allottee, (select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN(SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS Modified,  (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') -(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN (SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS ModifiedREmain from AllotteeMaster A   inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE  B.RegionalOffice = '" + RegOff + "' GROUP BY B.RegionalOffice", con);
        //        SqlCommand cmd = new SqlCommand(" select  B.RegionalOffice,(select count(p.PlotNumber) as PlotNumber  FROM PlotMaster P Left join  IndustrialArea I on P.IAId = I.ID  WHERE P.status IN('3', '4', '5', '6', '7') and P.landuseCode = '2'  AND I.RegionalOffice = '" + RegOff + "') AS PlotNo, (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE  A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "' AND a.PlotNo IN(select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID  WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2') ) AS Allottee,(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN(SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID) AND a.PlotNo IN(select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID   WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2') ) AS Modified,  (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isActive = '0' AND  B.RegionalOffice = '" + RegOff + "' AND a.PlotNo IN(select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2')) -(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea= B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN (SELECT  t.AllotteeID FROM tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID) AND a.PlotNo IN (select p.PlotNumber  FROM PlotMaster P Left join  IndustrialArea B on P.IAId = B.ID  WHERE b.RegionalOffice = '" + RegOff + "' AND   P.landuseCode = '2')) AS ModifiedREmain from AllotteeMaster A   inner join IndustrialArea B on A.IndustrialArea = B.IAName    WHERE    B.RegionalOffice = '" + RegOff + "' GROUP BY B.RegionalOffice", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        adp.Fill(ds);
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
        //    }
        //    return ds;
        //}
    
        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlRO.SelectedIndex > 0)
            {
                DataSet ds1 = new DataSet();
                ds1 = ViewFillPlots(dlRO.SelectedValue);
                DataTable dtDoc1 = ds1.Tables[0];
                lblTotalPlot.Text = dtDoc1.Rows[0]["PlotNumber"].ToString().Trim();

                DataSet ds2 = new DataSet();
                ds2 = FillTotAllotte(dlRO.SelectedValue);
                DataTable dtDoc2 = ds2.Tables[0];
                lblTotalAllottee.Text = dtDoc2.Rows[0]["Allottee"].ToString().Trim();


                DataSet ds3 = new DataSet();
                ds3 = FillTotDemands(dlRO.SelectedValue);
                DataTable dtDoc3 = ds3.Tables[0];
                lblTotalDemand.Text = dtDoc3.Rows[0]["Demanded"].ToString().Trim();
                lblTotalPaid.Text = dtDoc3.Rows[0]["Paid"].ToString().Trim();
                lblTotalOutstandingDue.Text = dtDoc3.Rows[0]["Outstanding"].ToString().Trim();

                

                DataSet ds4 = new DataSet();
                ds4 = FillGridDemands(dlRO.SelectedValue);
                DataTable dtDoc4 = ds4.Tables[0];
                if (dtDoc4.Rows.Count > 0)                 
                {
                    GridView_TransactionReport.DataSource = dtDoc4;
                    GridView_TransactionReport.DataBind();
                    //btnSave.Visible = true;
                }
                else
                {
                    GridView_TransactionReport.DataSource = null;
                    GridView_TransactionReport.DataBind();
                }

                DataSet ds5 = new DataSet();
                ds5 = FillGridDemandsB(dlRO.SelectedValue);
                DataTable dtDoc5 = ds5.Tables[0];
                if (dtDoc4.Rows.Count > 0)
                {
                    GridView1.DataSource = dtDoc5;
                    GridView1.DataBind();
                    //btnSave.Visible = true;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

                DataSet ds6 = new DataSet();
                ds6 = FillGridDemandsBINDUSTRIAL(dlRO.SelectedValue);
                DataTable dtDoc6 = ds6.Tables[0];
                if (dtDoc4.Rows.Count > 0)
                {
                    GridView3.DataSource = dtDoc6;
                    GridView3.DataBind();
                    //btnSave.Visible = true;
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }

                //DataSet ds7 = new DataSet();
                //ds7 = FillGridDemandsNotTrans(dlRO.SelectedValue);
                //DataTable dtDoc7 = ds7.Tables[0];
                //if (dtDoc4.Rows.Count > 0)
                //{
                //    GridView2.DataSource = dtDoc7;
                //    GridView2.DataBind();
                //    //btnSave.Visible = true;
                //}
                //else
                //{
                //    GridView2.DataSource = null;
                //    GridView2.DataBind();
                //}
            }
        }

        protected void ExportExcel(object sender, EventArgs e)
        {
            //PrepareGridViewForExport(GridView_TransactionReport);
            //ExportGridView();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xlsx"));
            Response.ContentType = "application/ms-excel";
            DataSet ds4 = new DataSet();
            ds4 = FillGridDemands(dlRO.SelectedValue);
           // DataTable dtDoc4 = ds4.Tables[0];
            DataTable dt = ds4.Tables[0];
            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }         

       
    }

    
}