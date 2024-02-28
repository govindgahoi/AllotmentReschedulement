using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
//using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class UC_Document_Report_VG_IA_Service : System.Web.UI.UserControl
    {

        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        public string SerRequestNo { get; set; }
        public string StrSender { get; set; }
        int ServiceID, UserId = 0;
        string AppDate = "";
        string IAName = "";
        string PlotArea = "";
        string PlotNumber = "";
        string AllotteeID = "";
        string TEFTimeperiod = "";
        string TEFdate = "";
        string TEFApprovalDatee_str = "";
        decimal Totalfees = 0;

        public void Page_Load(object sender, EventArgs e)
        {
            StrSender = "NewSystem";

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserId = _objLoginInfo.userid;

            }
            catch { Response.Redirect("Default.aspx", false); }




            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd;


            checkAllotment();





            if (SerRequestNo.Length > 0)
            {
                string[] SerArray = SerRequestNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);

                GetAllotteeDetail(SerRequestNo);
            }

        }


        private void checkAllotment()
        {
            string[] SerArray = SerRequestNo.Split('/');
            ServiceID = int.Parse(SerArray[1]);
            try
            {
                SqlCommand cmd1 = new SqlCommand();

                if (ServiceID == 1003)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='ChangeOfProject'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1004)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='AdditionOfProduct'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1009)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='CompletionCertificate'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1010)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='OccupancyCertificate'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1002)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Timeextensionfee'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1005)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='nocmortgage'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1006)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Jointmortgage'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1007)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='secondcharge'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1011)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='transferofleasedeed'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1023)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='NoDues'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1027)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='OutstandingDues'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                #region by manish Rastogi
                //reconstruction
                if (ServiceID == 1008)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='ReconstitutionOfCompany'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                //hand over lease deed
                if (ServiceID == 1017)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='HandOverleasedeed'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                //Reconstitution for legal heir
                if (ServiceID == 1021)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Reconstitutionforlegalheir'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                //water connection
                if (ServiceID == 1022)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='waterconnection'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }

                #endregion
                if (ServiceID == 1029)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='AmalgamationPostAllotment'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                if (ServiceID == 1030)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='SubDivisionPostAllotment'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                 
                #region Manish Shukla
                // startofproduction
                if (ServiceID == 1014)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Startofproduction'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }

                // startofproduction
                if (ServiceID == 1013)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Cancelatonofplot'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = false;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }

                //Restoration of plot
                if (ServiceID == 1012)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Restoration'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                //Subleting of Plot
                if (ServiceID == 1026)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Subleting'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                //Additional of Plot
                if (ServiceID == 1025)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Additional'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                //Surrender of Plot
                if (ServiceID == 1024)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Surrender'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void btn_Sign_Click(object sender, EventArgs e)
        {

            string[] SerArray = SerRequestNo.Split('/');
            ServiceID = int.Parse(SerArray[1]);

            if (ServiceID == 1003)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=COP");
            }
            if (ServiceID == 1004)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=AOP");
            }
            if (ServiceID == 1009)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=CC");
            }
            if (ServiceID == 1010)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=OC");
            }
            if (ServiceID == 1005)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=NM");
            }
            if (ServiceID == 1006)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=MO");
            }
            if (ServiceID == 1007)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=SC");
            }
            if (ServiceID == 1011)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=TLD");
            }
            if (ServiceID == 1002)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=TEF");
            }

            // startofproduction
            if (ServiceID == 1014)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=STOP");
            }
            // startofproduction
            if (ServiceID == 1013)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=COP");
            }
            if (ServiceID == 1029)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=APA");
            }
            if (ServiceID == 1030)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=SBDPA");
            }
            #region Newservice
            //Restoration of plot
            if (ServiceID == 1012)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=ROP");
            }
            //Surrender of Plot

            if (ServiceID == 1024)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=SOP");
            }
            //Additional of Plot
            if (ServiceID == 1025)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=AOP");
            }
            //Subleting of Plot
            if (ServiceID == 1026)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=SUOP");
            }
            #endregion

            #region Add by manish Rastogi
            if (ServiceID == 1008)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=RF");
            }
            if (ServiceID == 1017)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=HLD");
            }
            if (ServiceID == 1021)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=RLF");
            }
            if (ServiceID == 1022)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=WC");
            }
            if (ServiceID == 1023)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=NDC");
            }
            if (ServiceID == 1027)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=ODC");
            }
            #endregion
        }

        public void GetAllotteeDetail(string SerRequestNo)
        {
            byte[] PdfInBytes = HtmlToByte();
            String base64EncodedPdf = System.Convert.ToBase64String(PdfInBytes);

            string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""110%""  height=""550px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										  </object>";


            Literal ltEmbed = new Literal();
            ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
            Placeholder.Controls.Add(ltEmbed);
        }


        protected void btnSave_Genrate_Click(object sender, EventArgs e)
        {
            byte[] PdfInBytes = HtmlToByte();

            SqlCommand command;
            SqlTransaction transaction;
            bool transactionResult = true;



            if (ServiceID == 1029)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("[AmalgamationPlotApproval]", con, transaction);
                    //SqlCommand cmd = new SqlCommand("[OutstandingDuesCertificateApproval]", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        transaction.Commit();
                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }


            if (ServiceID == 1023)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("[NoDuesCertificateApproval]", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        transaction.Commit();
                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            if (ServiceID == 1027)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("[OutstandingDuesCertificateApproval]", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        transaction.Commit();
                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }
            // Change Of Project
            if (ServiceID == 1003)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ChangeOfProjectApproval", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            if (ServiceID == 1004)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("AdditionOfProductApproval", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            if (ServiceID == 1009)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("CompletionCertificateApproval", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            if (ServiceID == 1010)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("OccupancyCertificateApproval", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            // Time Extension fee

            if (ServiceID == 1002)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("FinalDetailsForTimeextension '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    if (dt0.Rows.Count > 0)
                    {
                        TEFdate = dt0.Rows[0]["TEFDate"].ToString();
                        TEFTimeperiod = (dt0.Rows[0]["TEFPeriod"].ToString());
                        TEFApprovalDatee_str = DateTime.ParseExact(TEFdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    }
                    if (dt1.Rows.Count > 0)
                    {
                        Totalfees = Convert.ToDecimal(dt1.Rows[0]["TotalAmount"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {
                    con.Close();
                }

                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_Timeextension", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@TEFApprovalDate", TEFApprovalDatee_str);
                    cmd.Parameters.AddWithValue("@TEFPeriod", TEFTimeperiod);
                    cmd.Parameters.AddWithValue("@TEFFees", Totalfees);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        string ControlID = dt.Rows[0]["ControlId"].ToString();
                        string UnitId = dt.Rows[0]["UnitId"].ToString();
                        string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();


                        transaction.Commit();
                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }
            }

            // Noc Mortgage

            if (ServiceID == 1005)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_NocMortgage", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        string ControlID = dt.Rows[0]["ControlId"].ToString();
                        string UnitId = dt.Rows[0]["UnitId"].ToString();
                        string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();


                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }
            // Joint Mortgage

            if (ServiceID == 1006)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_JointMortgage", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        string ControlID = dt.Rows[0]["ControlId"].ToString();
                        string UnitId = dt.Rows[0]["UnitId"].ToString();
                        string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();


                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            // transferofleasedeed

            if (ServiceID == 1011)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_transferofleasedeed", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        string ControlID = dt.Rows[0]["ControlId"].ToString();
                        string UnitId = dt.Rows[0]["UnitId"].ToString();
                        string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();


                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            // SecondCharge
            if (ServiceID == 1007)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_SecondCharges", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        string ControlID = dt.Rows[0]["ControlId"].ToString();
                        string UnitId = dt.Rows[0]["UnitId"].ToString();
                        string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();


                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            // startofproduction

            if (ServiceID == 1014)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_Startofproduction", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {


                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }
            }


            // Canclation of Plot

            if (ServiceID == 1013)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_PlotCancelation", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }
            }



            //Surrender of Plot
            if (ServiceID == 1024)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_Surrender", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {


                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            //Additional Unit
            if (ServiceID == 1025)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_Additional", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            //Subleting
            if (ServiceID == 1026)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_Subleting", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        transaction.Commit();
                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            //Restoration of plot
            if (ServiceID == 1012)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_Restoration", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {


                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }

            }


            #region  Add By Manish Rastogi
            //  reconstruction
            if (ServiceID == 1008)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("reconstitutionApproval", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }
            //  Hand over lease deed
            if (ServiceID == 1017)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("Handoverleasedeed", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }
            //  reconstruction for legal hier
            if (ServiceID == 1021)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("reconstitutionApprovalforlegal", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            //  reconstruction for legal hier
            if (ServiceID == 1022)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_waterconnection", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {



                        transaction.Commit();



                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }




            }

            #endregion


        }

        protected byte[] HtmlToByte()
        {
            string htmlContent = "";
            decimal Outstanding = 0;

            // Change Of Project
            if (ServiceID == 1003)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Change_Of_Project_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForChangeOfProjectLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt8 = ds.Tables[3];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Change Of Project";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }

                    if (dt8.Rows.Count > 0)
                    {
                        string lblIndustrytype = dt8.Rows[0]["IndustryType"].ToString();
                        string lblPlotRequiredExpansion = dt8.Rows[0]["ExpansionOfLand"].ToString();
                        string lblExportOrientedIndustry = dt8.Rows[0]["ExportOriented"].ToString();
                        string lblRelevantExperience = dt8.Rows[0]["WorkExperience"].ToString();
                        string lblTimelimitSetup = dt8.Rows[0]["ProjectStartMonths"].ToString();
                        string lblLandCost = dt8.Rows[0]["LandDetails"].ToString();
                        string lblBuildingCost = dt8.Rows[0]["BuildingDetails"].ToString();
                        string lblPlantMachineryCost = dt8.Rows[0]["MachineryEquipmentsDetails"].ToString();
                        string lblTotalProjectCost = dt8.Rows[0]["EstimatedCostOfProject"].ToString();
                        string lblCoveredarea = dt8.Rows[0]["CoveredArea"].ToString();
                        string lblOpenArea = dt8.Rows[0]["OpenAreaRequired"].ToString();
                        string lblSolidQuantity = dt8.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                        string lblSolidComposition = dt8.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                        string lblLiquidQuantity = dt8.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                        string lblLiquidComposition = dt8.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                        string lblGasQuantity = dt8.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                        string lblGasComposition = dt8.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                        string lblEstimatedEmployment = dt8.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                        string lblInvestmentOtherAssets = dt8.Rows[0]["OtherFixedAssets"].ToString();
                        string lblInvestmentOtherExpenses = dt8.Rows[0]["OtherExpenses"].ToString();
                        string lblProposedEffluents1 = dt8.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                        string lblProposedEffluents2 = dt8.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                        string lblProposedEffluents3 = dt8.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                        string lblPowerrequirement = dt8.Rows[0]["PowerReqInKW"].ToString();
                        string lblNetWorthTurnover = dt8.Rows[0]["NetWorth"].ToString();
                        string lblpriorityCategory = dt8.Rows[0]["ApplicantPrioritySpecification"].ToString();
                        string lblTypeOfIndustryy = dt8.Rows[0]["IAClasification"].ToString();
                        string lblIndustrialCategory = dt8.Rows[0]["PollutionCategory"].ToString();
                        string lblEtp = dt8.Rows[0]["EtpRequired"].ToString();
                        string IACategory = dt8.Rows[0]["IACategory"].ToString();
                        string lblTurnOver = dt8.Rows[0]["NetTurnover"].ToString().Trim();


                        htmlContent = htmlContent.Replace("{{lblIndustrytype}}", lblIndustrytype);
                        htmlContent = htmlContent.Replace("{{lblPlotRequiredExpansion}}", lblPlotRequiredExpansion);
                        htmlContent = htmlContent.Replace("{{lblExportOrientedIndustry}}", lblExportOrientedIndustry);
                        htmlContent = htmlContent.Replace("{{lblRelevantExperience}}", lblRelevantExperience);
                        htmlContent = htmlContent.Replace("{{lblTimelimitSetup}}", lblTimelimitSetup);
                        htmlContent = htmlContent.Replace("{{lblLandCost}}", lblLandCost);
                        htmlContent = htmlContent.Replace("{{lblBuildingCost}}", lblBuildingCost);
                        htmlContent = htmlContent.Replace("{{lblPlantMachineryCost}}", lblPlantMachineryCost);
                        htmlContent = htmlContent.Replace("{{lblTotalProjectCost}}", lblTotalProjectCost);
                        htmlContent = htmlContent.Replace("{{lblCoveredarea}}", lblCoveredarea);
                        htmlContent = htmlContent.Replace("{{lblOpenArea}}", lblOpenArea);
                        htmlContent = htmlContent.Replace("{{lblTypeOfIndustryy}}", lblTypeOfIndustryy);
                        htmlContent = htmlContent.Replace("{{lblEstimatedEmployment}}", lblEstimatedEmployment);
                        htmlContent = htmlContent.Replace("{{lblInvestmentOtherAssets}}", lblInvestmentOtherAssets);
                        htmlContent = htmlContent.Replace("{{lblInvestmentOtherExpenses}}", lblInvestmentOtherExpenses);

                    }


                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }






                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }



            }

            if (ServiceID == 1004)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Addition_Of_Product_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForAdditionOfProductLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt8 = ds.Tables[3];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Addition Of Product";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }

                    if (dt8.Rows.Count > 0)
                    {
                        string ProductName = dt8.Rows[0]["AdditionalProduct"].ToString();
                        string ProductDescription = dt8.Rows[0]["ProductDescription"].ToString();
                        htmlContent = htmlContent.Replace("{{ProductName}}", ProductName);
                        htmlContent = htmlContent.Replace("{{ProductDescription}}", ProductDescription);

                    }

                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }






                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }



            }
            if (ServiceID == 1009)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/CompletionCertificate.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForCompletionSCertificate '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Change Of Project";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }


                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }






                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }



            }
            if (ServiceID == 1010)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/OccupancyCertificate.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForCompletionSCertificate '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];




                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Change Of Project";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }



                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }






                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }



            }

            //NoDues Certificate
            if (ServiceID == 1023)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/NoDuesCertificate_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    SqlCommand cmd = new SqlCommand("DetailsForNoDuesCertificate '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];




                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Change Of Project";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }



                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }






                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }



            }

            //Outstanding Dues Certificate
            if (ServiceID == 1027)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/OutstandingDuesCertificate_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    SqlCommand cmd = new SqlCommand("DetailsForOutstandingDuesCertificate '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt3 = ds.Tables[3];




                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Change Of Project";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }



                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }


                    if (dt3.Rows.Count > 0)
                    {

                        string html = @"<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Payment Head </th><th> Demanded </th><th> Paid </th><th> Oustanding </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt3.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["PaymentName"].ToString() + " </ td><td> " + dr["Demanded"].ToString() + " </ td><td> " + dr["Paid"].ToString() + " </ td><td> " + dr["Outstanding"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";
                        htmlContent = htmlContent.Replace("{{Ledger}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{Ledger}}", "");
                    }



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }



            }


    

            // Time Extension fees
            if (ServiceID == 1002)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/TEF_Letter_View.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForTEFLetter '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt3 = ds.Tables[3];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        AppDate = dt0.Rows[0]["DateOfTEFRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        PlotNumber = dt0.Rows[0]["PlotNo"].ToString();
                        PlotArea = dt0.Rows[0]["TotalAllottedplotArea"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        AllotteeID = dt0.Rows[0]["AllotteeID"].ToString();
                        TEFTimeperiod = dt0.Rows[0]["TEFTimeperiod"].ToString();
                        TEFdate = dt0.Rows[0]["tefDate"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotNumber);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{tefDate}}", TEFdate);
                        htmlContent = htmlContent.Replace("{{TEFTimeperiod}}", TEFTimeperiod);
                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }
                    }
                    if (dt3.Rows.Count > 0)
                    {
                        Outstanding = Convert.ToDecimal(dt3.Compute("SUM(Outstanding)", string.Empty));
                        htmlContent = htmlContent.Replace("{{Outstanding}}", Convert.ToDecimal(Outstanding).ToString());
                    }
                    if (dt3.Rows.Count > 0)
                    {

                        string html = @"<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Payment Head </th><th> Demanded </th><th> Paid </th><th> Oustanding </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt3.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["PaymentName"].ToString() + " </ td><td> " + dr["Demanded"].ToString() + " </ td><td> " + dr["Paid"].ToString() + " </ td><td> " + dr["Outstanding"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";
                        htmlContent = htmlContent.Replace("{{Ledger}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{Ledger}}", "");
                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexres}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexres}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }

            // second Charges Construction
            if (ServiceID == 1007)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/SecondCharges_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForSecondchargeLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        string SanctionletternoSecond = dt0.Rows[0]["SanctionletternoSecond"].ToString();
                        string SanctionletterDate = dt0.Rows[0]["SanctionletterDate"].ToString();
                        string PremimAmountSecond = dt0.Rows[0]["PremimAmountSecond"].ToString();
                        string firstNameofbank = dt0.Rows[0]["firstNameofbank"].ToString();
                        string firstBranch = dt0.Rows[0]["firstBranch"].ToString();
                        string secondNameofbank = dt0.Rows[0]["secondNameofbank"].ToString();
                        string secondBranch = dt0.Rows[0]["secondBranch"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                        htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                        htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);

                        htmlContent = htmlContent.Replace("{{secondNameofbank}}", secondNameofbank);
                        htmlContent = htmlContent.Replace("{{secondBranch}}", secondBranch);
                        htmlContent = htmlContent.Replace("{{firstNameofbank}}", firstNameofbank);
                        htmlContent = htmlContent.Replace("{{firstBranch}}", firstBranch);
                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }

            //Noc Mortgage
            if (ServiceID == 1005)
            {

                StreamReader reader = new StreamReader(Server.MapPath("/html/NocMortgage_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForNocMortgageLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        string SanctionletternoSecond = dt0.Rows[0]["letterNo"].ToString();
                        string SanctionletterDate = dt0.Rows[0]["letterDate"].ToString();
                        string PremimAmountSecond = dt0.Rows[0]["PremimAmount"].ToString();

                        string NOCBankName = dt0.Rows[0]["BankName"].ToString();
                        string NOCBranchName = dt0.Rows[0]["BranchName"].ToString();
                        string NOCDiginationName = dt0.Rows[0]["LetterFrom"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                        htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                        htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);
                        htmlContent = htmlContent.Replace("{{BankName}}", NOCBankName);
                        htmlContent = htmlContent.Replace("{{BranchName}}", NOCBranchName);
                        htmlContent = htmlContent.Replace("{{LetterFrom}}", NOCDiginationName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }

            //Joint Mortgage
            if (ServiceID == 1006)
            {

                StreamReader reader = new StreamReader(Server.MapPath("/html/JointMortgage_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForJointMortgageLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt30 = ds.Tables[3];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        string SanctionletternoSecond = dt0.Rows[0]["letterNo"].ToString();
                        string SanctionletterDate = dt0.Rows[0]["letterDate"].ToString();
                        string PremimAmountSecond = dt0.Rows[0]["PremimAmount"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                        htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                        htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        //By Sunil
                        if (dt30.Rows.Count > 0)
                        {
                            
                            string BankName = dt30.Rows[0]["BankName"].ToString();
                            string BranchName = dt30.Rows[0]["BranchName"].ToString();
                            htmlContent = htmlContent.Replace("{{BankName}}", BankName);
                            htmlContent = htmlContent.Replace("{{BranchName}}", BranchName);
                            
                        }
                        // By Sunil

                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }
            //Transfer of lease deed 

            if (ServiceID == 1011)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Transferofleasedeed_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsFortransferofleasedeedLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string SanctionletternoSecond = dt0.Rows[0]["letterNo"].ToString();
                        string SanctionletterDate = dt0.Rows[0]["letterDate"].ToString();
                        string PremimAmountSecond = dt0.Rows[0]["PremimAmount"].ToString();


                        string letterfrom = dt0.Rows[0]["letterfrom"].ToString();
                        string BankName = dt0.Rows[0]["BankName"].ToString();
                        string BankAddress = dt0.Rows[0]["BankAddress"].ToString();


                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                        htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                        htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);

                        htmlContent = htmlContent.Replace("{{letterfrom}}", letterfrom);
                        htmlContent = htmlContent.Replace("{{BankName}}", BankName);
                        htmlContent = htmlContent.Replace("{{BankAddress}}", BankAddress);


                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }
            //Start of Production 

            if (ServiceID == 1014)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Startofproduction_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForstartofproduction '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string IssueDate = dt0.Rows[0]["IssueDate"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string StartofproductionDate = dt0.Rows[0]["StartofproductionDate"].ToString();


                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{StartofproductionDate}}", StartofproductionDate);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }

            //Plot Cancelation  

            if (ServiceID == 1013)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Plot_Cancelation.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    int i = 0;
                    int j = 0;
                    string html = "";
                    string html1 = "";
                    SqlCommand cmd = new SqlCommand("DetailsForPlotCancellation '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt2 = ds.Tables[2];
                    DataTable dt3 = ds.Tables[3];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ServiceRequestNO"].ToString();
                        string IssueDate = dt0.Rows[0]["IssueDate"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string AllotmentLetterNo = dt0.Rows[0]["AllotmentLetterNo"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{AllotmentLetterNo}}", AllotmentLetterNo);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                        html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Service Request No </th><th>Notice Number/th><th>Notice Date/th><th>Notice Desc/th></tr>";
                        foreach (DataRow dr in dt2.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ServiceRequestNo"].ToString() + "</td><td>" + dr["NoticeID"] + "</td><td>" + dr["CreationDate"] + "</td><td>" + dr["AppointmentDesc"] + "</td></tr>";
                        }


                        html += "</table>";


                        html1 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>";

                        foreach (DataRow dr in dt3.Rows)
                        {
                            j++;
                            html1 += "<tr><td style='width: 4 %;'>" + j.ToString() + "</td><td>" + dr["Annexures"].ToString() + "</td></tr>";
                        }


                        html1 += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofNotices}}", html);
                        htmlContent = htmlContent.Replace("{{ListofClause}}", html1);



                    }



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }

            //Subleting

            if (ServiceID == 1026)
            {

                StreamReader reader = new StreamReader(Server.MapPath("/html/Sublettingofplot_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForSublettingtLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt8 = ds.Tables[3];
                    DataTable dt4 = ds.Tables[4];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        if (dt4.Rows.Count > 0)
                        {

                            string SublettingYear = dt4.Rows[0]["sublettingyear"].ToString();
                            string sublettingcharge = dt4.Rows[0]["sublettingcharge"].ToString();
                            string leasedeedDate = dt4.Rows[0]["leasedeedDate"].ToString();
                            htmlContent = htmlContent.Replace("{{sublettingyear}}", SublettingYear);
                            htmlContent = htmlContent.Replace("{{sublettingcharge}}", sublettingcharge);
                            htmlContent = htmlContent.Replace("{{leasedeedDate}}", leasedeedDate);
                        }
                        if (dt8.Rows.Count > 0)
                        {
                            string lblIndustrytype = dt8.Rows[0]["ProjectName"].ToString();
                            string SublettingAllotteeAddress = dt8.Rows[0]["SublettingAllotteeAddress"].ToString();
                            string SublettingAllotteeName = dt8.Rows[0]["SublettingAllotteeName"].ToString();
                            string SublettingPlotArea = dt8.Rows[0]["SublettingPlotArea"].ToString();
                            string AreaRate = dt8.Rows[0]["RateofPlot"].ToString();
                            string SublettingCharge = dt8.Rows[0]["SublettingCharge"].ToString();
                            string SublettingChargeGST = dt8.Rows[0]["SublettingChargeGST"].ToString();

                            htmlContent = htmlContent.Replace("{{ProjectName}}", lblIndustrytype);
                            htmlContent = htmlContent.Replace("{{SublettingAllotteeAddress}}", SublettingAllotteeAddress);
                            htmlContent = htmlContent.Replace("{{SublettingAllotteeName}}", SublettingAllotteeName);
                            htmlContent = htmlContent.Replace("{{SublettingPlotArea}}", SublettingPlotArea);
                            htmlContent = htmlContent.Replace("{{RateofPlot}}", AreaRate);
                            htmlContent = htmlContent.Replace("{{SublettingCharge}}", SublettingCharge);
                            htmlContent = htmlContent.Replace("{{SublettingChargeGST}}", SublettingChargeGST);

                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }

            //Additional Unit

            if (ServiceID == 1025)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/AdditionalUnit_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForAdditionalUnitLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }

            //Restoration of plot

            if (ServiceID == 1012)
            {
                decimal SumTotal = 0;
                StreamReader reader = new StreamReader(Server.MapPath("/html/Restorationofplot_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForRestorationofplotLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt2 = ds.Tables[3];
                    DataTable dt4 = ds.Tables[4];


                    if (dt0.Rows.Count > 0)
                    {

                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string TotalPlotArea = dt0.Rows[0]["PlotArea"].ToString();
                        string RateofPlot = dt0.Rows[0]["RateofPlot"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{PlotArea}}", TotalPlotArea);
                        htmlContent = htmlContent.Replace("{{RateofPlot}}", RateofPlot);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    if (dt4.Rows.Count > 0)
                    {

                        string txtRestorationlevypercentage = dt4.Rows[0]["Restorationlevypercentage"].ToString();
                        string txtbuildingDate = dt4.Rows[0]["buildingPlanDate"].ToString();
                        string txtProductionDate = dt4.Rows[0]["ProductionStartDate"].ToString();
                        string Totalrestorationlevyamount = dt4.Rows[0]["Totalrestorationlevyamount"].ToString();
                        //lblTotalrestorationlevyamount.Text = Totalrestorationlevyamount;

                        htmlContent = htmlContent.Replace("{{Restorationlevypercentage}}", txtRestorationlevypercentage);
                        htmlContent = htmlContent.Replace("{{buildingPlanDate}}", txtbuildingDate);
                        htmlContent = htmlContent.Replace("{{ProductionStartDate}}", txtProductionDate);
                        htmlContent = htmlContent.Replace("{{lblTotalrestorationlevyamount}}", Totalrestorationlevyamount);
                    }
                    if (dt2.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>The detail of outstanding dues are as under";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of outstanding dues </th><th> Rs </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt2.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["PaymentName"].ToString() + " </ td><td> " + dr["Outstanding"].ToString() + " </ td></tr> ";
                            SumTotal = SumTotal + Convert.ToDecimal(dr["Outstanding"].ToString());
                        }

                        html += @"<tr style='background:#f7f7f7;' >
                                          <th></th>
                                          <th ><span >Total </span></th>
                                          <th >" + SumTotal + @"</th>
                                          </tr>";

                        html += " </table>";

                        htmlContent = htmlContent.Replace("{{Listofoutstandingdues}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }


            //Surrender of Plot

            if (ServiceID == 1024)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/SurrenderofPlot_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForSurrenderofPlotLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }


            if (ServiceID == 1029)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Amalgamation_Post_Allotment_NOC.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForAmalgamationPostAllotmentLetter '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt8 = ds.Tables[3];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotNo = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string AmalgamatedPlots = dt0.Rows[0]["AmalgamatedPlots"].ToString();
                        string AmalgamatedPlotsArea = dt0.Rows[0]["AmalgamatedPlotsArea"].ToString();
                        string AppNo = SerRequestNo.Trim();
                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{AppNo}}", AppNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{AmalgamatedPlotsArea}}", AmalgamatedPlotsArea);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotNo);
                        htmlContent = htmlContent.Replace("{{AmalgamatedPlots}}", AmalgamatedPlots);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Change Of Project";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }

                    if (dt8.Rows.Count > 0)
                    {

                        string html11 = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Plot No </th><th> Plot Area </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt8.Rows)
                        {
                            i++;
                            html11 += "<tr><td> " + i.ToString() + " </td><td> " + dr["PlotNumber"].ToString() + " </ td><td> " + dr["PlotArea"].ToString() + " </ td></tr> ";

                        }
                        html11 += "<tr><th colspan='2'></th><th>" + dt8.Compute("Sum(PlotArea)", string.Empty).ToString() + "</th></tr></table>";

                        htmlContent = htmlContent.Replace("{{PlotDetails}}", html11);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{PlotDetails}}", "");

                    }



                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }






                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }



            }

            #region Add Manish Rastogi
            if (ServiceID == 1008)
            {

                StreamReader reader = new StreamReader(Server.MapPath("/html/ReconstitutionOfAllottee.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForreconstitutionforallotte '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string AllottmentDate = dt0.Rows[0]["AllotmentDate"].ToString();

                        htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllottmentDate);
                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);



                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }
            if (ServiceID == 1017)
            {

                StreamReader reader = new StreamReader(Server.MapPath("/html/Requestforhandoverofleasedeedtolease.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForhandoverofleasedeedtolease '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        //string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        //htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);



                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }
            if (ServiceID == 1021)
            {

                StreamReader reader = new StreamReader(Server.MapPath("/html/RecognitionoftheLegalHeir.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForreconstitutionforallotte '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string AllottmentDate = dt0.Rows[0]["AllotmentDate"].ToString();

                        htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllottmentDate);
                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);



                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }
            if (ServiceID == 1022)
            {

                StreamReader reader = new StreamReader(Server.MapPath("/html/WaterConnection.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForWaterConnection '" + SerRequestNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        //string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        //htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);



                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }
            #endregion

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            byte[] pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            return pdfBytes;

        }

        private void SendMailToApplicant(byte[] PdfInBytes)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeMaster where ref_AllotmentNo= '" + SerRequestNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string EmaiID = dt.Rows[0]["SignatoryEmail"].ToString();
                string PhoneNo = dt.Rows[0]["SignatoryPhone"].ToString();
                string Name = dt.Rows[0]["AuthorisedSignatory"].ToString();
                string letterno = dt.Rows[0]["Allotmentletterno"].ToString();
                string PlotNo = dt.Rows[0]["PlotNo"].ToString();

                try
                {

                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(EmaiID.Trim());
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);


                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ServiceReqNoMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", Name.Trim());
                    StrContent = StrContent.Replace("{Description}", "Dear Applicant Your request for plot allotment is Completed.Your Plot No is " + PlotNo + " and Allotment letter No is " + letterno + "<br/><br/>We respect your patronage with us. ");



                    newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to register for Land Allotment ";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(PdfInBytes), "" + Name + ".pdf"));

                    //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                    //smtp.EnableSsl = true;
                    //smtp.Send(newmsg);

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    String message = HttpUtility.UrlEncode("Dear Applicant Your Plot No is " + PlotNo + " and Allotment letter No is " + letterno + "");
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                                        {
                                        {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                                        {"numbers" , PhoneNo},
                                        {"message" , message}
                        //              {"sender" , "UPSIDC"}
                                        });
                        resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    }



                }
                catch (Exception ex)
                {

                }

            }
        }


    }
}