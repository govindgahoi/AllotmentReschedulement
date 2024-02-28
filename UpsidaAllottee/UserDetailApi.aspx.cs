using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class UserDetailApi : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //GetUserDertails("mayank.mangal", "1");
        }

        [WebMethod()]
        public static string GetUserDetails(string UserName, string role)
        {
            int userID;
            string result;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_GetUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@userID", UserName);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            userID = Convert.ToInt32(dt.Rows[0][0].ToString());

            //List<string> result = new List<string>();
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd1 = new SqlCommand("Select Level from UserAssociationMaster where UserID='" + userID + "' and isNull(ActiveStatus,0)=1", con);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            result=dt1.Rows[0]["Level"].ToString().Trim();
            return result;

        }
        //public static string TestService(string UserName)
        //{

        //    return "Service is Running :- "+ UserName;

        //}
        [WebMethod()]
        public uploadingResponse uploadSignedCopy(string serReqNo, string Tp, HttpPostedFile fUpload, string fName, string FileExtention)
        {
            uploadingResponse Uresponse = new uploadingResponse();
            string ProcessIndustryID = "";
            string ApplicationID = "";
            string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
            string Status_Code = "";
            string Remarks = "";
            string Fee_Amount = "";
            string Fee_Status = "";
            string Transaction_ID = "";
            string Transaction_Date = "";
            string Transaction_Date_Time = "";
            string NOC_Certificate_Number = "";
            string NOC_URL = "";
            string ISNOC_URL_ActiveYesNO = "";
            string Request_ID = "";
            string Pendancy_level = "";
            string Objection_Rejection_Code = "";
            string Certificate_EXP_Date_DDMMYYYY = "";
            string Is_Certificate_Valid_Life_Time = "";
            string D1 = "";
            string D2 = "";
            string D3 = "";
            string D4 = "";
            string D5 = "";
            string D6 = "";
            string D7 = "";
            string SerReqNo;
            string Type = "";
            string SWCControlID = "";
            string SWCUnitID = "";
            string SWCServiceID = "";

            string NewAllotteeID = "";
            string ControlID = "";
            string UnitID = "";
            string ServiceID = "";
            string AllotteeID = "";
            string status = "";
            string Flag = "";
            string DocType = "";
            string Reason = "";
            bool uploadStatus = false;
            //int index = Convert.ToInt32(e.CommandArgument);
            //index = index % GridView2.PageSize;
            SerReqNo = serReqNo;
            Type = Tp;
            string Service = "Letter";

            try
            {



                switch (Type)
                {


                    case "APA":
                        Flag = "Completed";
                        DocType = "AmalgamationPostAllotment";
                        break;
                    case "APAR":
                        Flag = "Rejected";
                        DocType = "Rejection";
                        break;
                }


                if (Type == "APA" || Type == "APAR")
                {


                    //LinkButton bts = e.CommandSource as LinkButton;
                    //IFormFile fu = fUpload as IFormFile;

                    //if (fu.HasFile)
                    //{
                    //string filePath = fUpload;
                    //string filePath = fUpload;
                    string fleUpload = FileExtention;
                        string filename = fName;
                        string contenttype = String.Empty;
                        switch (fleUpload)
                        {

                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;
                        }
                        if (contenttype != String.Empty)
                        {
                            Stream fs = fUpload.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string content = contenttype;
                            Byte[] Uploadfile = bytes;
                            string ServiceRequestNO = SerReqNo;
                            string Doctype = Service;
                            Flag = Flag;

                            try
                            {

                                int retVal = UploadSignedCopyLetter(filename, content, Uploadfile, ServiceRequestNO, Doctype, Flag);
                                if (retVal > 0)
                                {


                                    if (Flag == "Completed")
                                    {
                                        Status_Code = "15";
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_Certificate_Number = SerReqNo;
                                        NOC_URL = "https://services.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=" + DocType + "";
                                    }
                                    if (Flag == "Rejected")
                                    {
                                        Objection_Rejection_Code = GetNMSWPRejectionID(SerReqNo);
                                        Status_Code = "07";
                                        Remarks = "RM Rejected Application and Issued Rejection Letter to | Applicant";
                                        NOC_Certificate_Number = SerReqNo;
                                        NOC_URL = "https://services.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Rejection";
                                    }
                                    string NMSWP_Result = UpdateNOCStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, Status_Code, Remarks, NOC_URL, NOC_Certificate_Number, Request_ID, Objection_Rejection_Code);
                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += NMSWP_Result;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                                   // BindGridView(Type,serReqNo);
                                    DataSet ds = new DataSet();
                                   SerReqNo.Trim();
                                    ds = ViewSignedCopyLetter(SerReqNo, Service);

                                    DataTable dtDoc = ds.Tables[0];

                                    if (dtDoc != null)
                                    {
                                        uploadStatus = true;
                                        string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                                        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";
                                        Uresponse.contype = contype;
                                        Uresponse.uploadStatus = uploadStatus;
                                        Uresponse.embed = embed;

                                       // ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&DocType=" + Service + ""));

                                    }
                                    
                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    Uresponse.contype = "";
                                    Uresponse.uploadStatus = uploadStatus;
                                    Uresponse.embed = "";
                                    //return Uresponse;
                                }
                            }
                            catch (Exception ex)
                            {

                                //string message = ex.ToString();
                                //string script = "window.onload = function(){ alert('";
                                //script += message;
                                //script += "')};";
                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                Uresponse.contype = "";
                                Uresponse.uploadStatus = uploadStatus;
                                Uresponse.embed = "";
                               // return Uresponse;
                            }
                            finally
                            {
                                
                            }

                        //}
                        //else
                        //{
                        //    string message = "File format not recognised." +
                        //      " Upload PDF formats";
                        //    string script = "window.onload = function(){ alert('";
                        //    script += message;
                        //    script += "')};";
                        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                           
                        //}
                    }

                }
                return Uresponse;
            }
            catch (Exception ex)
            {

                Uresponse.contype = "";
                Uresponse.uploadStatus = uploadStatus;
                Uresponse.embed = "";
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                return Uresponse;
            }
        }
              public Int32 UploadSignedCopyLetter(string filename, string content, Byte[] Uploadfile, string ServiceRequestNO,string Doctype, string Flag)
        {
            int result;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("[SP_UploadSignedCopyOfLetter]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", filename);
                cmd.Parameters.AddWithValue("@ContentType", content);
                cmd.Parameters.AddWithValue("@Documents", Uploadfile);
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNO);
                cmd.Parameters.AddWithValue("@DocType", Doctype);
                cmd.Parameters.AddWithValue("@Flag", Flag);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public string GetNMSWPRejectionID(string ServiceReqNo)
        {
            GetConnection();
            string NMSWPIDs = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDRejectionType] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    NMSWPIDs = dt.Rows[0][0].ToString();
                }

                return NMSWPIDs;
            }
            catch (Exception ex)
            {
                return "failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string UpdateNOCStatusAtNMSWP(string ControlID, string UnitID, string ServiceID, string Status_Code, string Remarks, string NOC_URL, string Certificate_Number, string Request_ID, string Objection_Rejection_Code)
        {

            string ProcessIndustryID = "";
            string ApplicationID = "";
            string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
            string Fee_Amount = "";
            string Fee_Status = "";
            string Transaction_ID = "";
            string Transaction_Date = "";
            string Transaction_Date_Time = "";
            string NOC_Certificate_Number = Certificate_Number;
            string ISNOC_URL_ActiveYesNO = "Yes";
            string Update_Result = "";

            string Certificate_EXP_Date_DDMMYYYY = "";

            string D1 = "";
            string D2 = "";
            string D3 = "";
            string D4 = "";
            string D5 = "";
            string D6 = "";
            string D7 = "";

            try
            {
                if (ControlID.Length > 0)
                {
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    Update_Result = webService.WReturn_CUSID_STATUS(
                    ControlID,
                    UnitID,
                    ServiceID,
                    ProcessIndustryID,
                    ApplicationID,
                    Status_Code,
                    Remarks,
                    "Applicant",
                    Fee_Amount,
                    Fee_Status,
                    Transaction_ID,
                    Transaction_Date,
                    Transaction_Date_Time,
                    NOC_Certificate_Number,
                    NOC_URL,
                    ISNOC_URL_ActiveYesNO,
                    passsalt,
                    Request_ID,
                    Objection_Rejection_Code,
                    "Yes",
                    Certificate_EXP_Date_DDMMYYYY,
                    D1,
                    D2,
                    D3,
                    D4,
                    D5,
                    D6,
                    D7

                    );
                }

                return Update_Result;
            }
            catch (Exception ex)
            {
                return "Failed";
            }

        }

        public DataSet ViewSignedCopyLetter(string ServiceRequestNO, string Doctype)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("GetSignedCopyLetter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNO", ServiceRequestNO);
                cmd.Parameters.AddWithValue("@Service", Doctype);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //    throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try { con.Open(); } catch { };
            return con;
        }

        public void BindGridView(string Type, string serReqNo)
        {
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("GetSignedChecklist '" + Type + "','" + serReqNo + "'", con);


            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    GridView2.DataSource = dt;
            //    GridView2.DataBind();
            //}
            //else
            //{
            //    GridView2.DataSource = null;
            //    GridView2.DataBind();
            //}

        }

    }

    public class uploadingResponse
    {
        public bool uploadStatus { get; set; }
        public string contype { get; set; }
        public string embed { get; set; }
    }
}
