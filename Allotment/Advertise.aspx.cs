using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
//using System.Net.Mail;
using Newtonsoft.Json.Linq;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;
namespace Allotment
{
    public partial class Advertise : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = string.Empty;
        ArrayList ar1 = new ArrayList();
        ArrayList ar2 = new ArrayList();
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                this.RegisterPostBackControl();
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            if (!IsPostBack)
            {
                UserSpecificBinding();
                // BindGrid();
            }

        }

        protected void UserSpecificBinding()
        {
            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                Regional_Changed(null, null);
                if (dsR.Tables[1].Rows[0][0].ToString() == "View")
                {
                    //         Allottee_master_grid.Columns[9].Visible = true;
                }
                else
                {
                    //       Allottee_master_grid.Columns[9].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }

            //   Refesh(true);
            //   ResetControl();

        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));


                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }

                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }
                //      GetNewAllotteeDetails();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from IndustrialArea where ID='" + drpdwnIA.SelectedValue.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string Status = dt.Rows[0]["PlotPublishing"].ToString();
                if (Status == "True")
                {
                    BindParentListBox();
                }
                else
                {
                    ListParent.Items.Clear();
                    ListParent.DataSource = null;
                    ListParent.DataBind();
                    ListSelected.Items.Clear();
                    ListSelected.DataSource = null;
                    ListSelected.DataBind();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('As per order allotment for this industrial area is allowed through e-auction only');", true);
                    return;
                }
            }

        }

        private DataTable Getdata1
        {
            get; set;
        }

        public void BindParentListBox()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";


                ds = objServiceTimelinesBLL.PlotBankAvailableForAllotment(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    ListParent.DataSource = Getdata1;
                    ListParent.DataTextField = "plots";
                    ListParent.DataValueField = "PlotMasterId";
                    ListParent.DataBind();
                }
                else
                {
                    ListParent.Items.Clear();
                    ListParent.DataSource = null;
                    ListParent.DataBind();
                }
            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }

        }

        protected void btnSingleForward_Click(object sender, EventArgs e)
        {


            if (ListParent.SelectedIndex >= 0)
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.PlotID = Convert.ToInt32(ListParent.SelectedValue.Trim());
                ds = objServiceTimelinesBLL.CheckTracingDoc(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];
                string Status = dtDoc.Rows[0][0].ToString();
                if (Status == "PendingT")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Tracing is not available kindly upload tracing !');", true);
                    return;
                }
                else if (Status == "Pending")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Joint certificate is not available kindly upload certificate !');", true);
                    return;
                }
                else
                {
                    for (int i = 0; i < ListParent.Items.Count; i++)
                    {
                        if (ListParent.Items[i].Selected)
                        {
                            if (!ar1.Contains(ListParent.Items[i]))
                            {
                                ar1.Add(ListParent.Items[i]);
                            }
                        }
                    }
                    for (int i = 0; i < ar1.Count; i++)
                    {
                        if (!ListSelected.Items.Contains(((ListItem)ar1[i])))
                        {
                            ListSelected.Items.Add(((ListItem)ar1[i]));
                        }
                        ListParent.Items.Remove(((ListItem)ar1[i]));
                    }
                    ListSelected.SelectedIndex = -1;
                }
            }
            else
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select atleast one plot to publish for Advertisement !');", true);
                return;
            }

        }

        protected void btnDoubleForward_Click(object sender, EventArgs e)
        {

            while (ListParent.Items.Count != 0)
            {
                for (int i = 0; i < ListParent.Items.Count; i++)
                {
                    ListSelected.Items.Add(ListParent.Items[i]);
                    ListParent.Items.Remove(ListParent.Items[i]);
                }
            }
            lblmsg.Text = "All data added for Advertisement";
            lblmsg.ForeColor = System.Drawing.Color.ForestGreen;



        }

        protected void btnDoubleBack_Click(object sender, EventArgs e)
        {

            while (ListSelected.Items.Count != 0)
            {
                for (int i = 0; i < ListSelected.Items.Count; i++)
                {
                    ListParent.Items.Add(ListSelected.Items[i]);
                    ListSelected.Items.Remove(ListSelected.Items[i]);
                }
            }
            lblmsg.Text = "All data removed from Advertisement.";
            lblmsg.ForeColor = System.Drawing.Color.ForestGreen;
        }

        protected void btnSingleBack_Click(object sender, EventArgs e)
        {

            if (ListSelected.SelectedIndex >= 0)
            {
                for (int i = 0; i < ListSelected.Items.Count; i++)
                {
                    if (ListSelected.Items[i].Selected)
                    {
                        if (!ar2.Contains(ListSelected.Items[i]))
                        {
                            ar2.Add(ListSelected.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ar2.Count; i++)
                {
                    if (!ListParent.Items.Contains(((ListItem)ar2[i])))
                    {
                        ListParent.Items.Add(((ListItem)ar2[i]));
                    }
                    ListSelected.Items.Remove(((ListItem)ar2[i]));
                }
                ListParent.SelectedIndex = -1;
            }
            else
            {
                lblmsg.Text = "Data removed from Advertisement";
                lblmsg.ForeColor = System.Drawing.Color.ForestGreen;

            }

        }

        protected void btnpublish_Click(object sender, EventArgs e)
        {

            if (ListSelected.Items.Count <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose any plot to publish !');", true);
                return;
            }

            else
            {
                Publishadvertisement();
            }


        }

        private void Publishadvertisement()
        {

            objServiceTimelinesBEL.IAId = Int32.Parse(drpdwnIA.SelectedValue.ToString());

            try
            {
                string str = string.Empty;

                str += "Plot Number:";

                for (int i = 0; i < ListSelected.Items.Count; i++)
                {
                    if (ListSelected.Items[i].Selected)
                    {
                        objServiceTimelinesBEL.PlotID = Int32.Parse(ListSelected.SelectedItem.Value);
                        objServiceTimelinesBEL.UserName = UserName;
                        if (objServiceTimelinesBEL.PlotID >= 0)
                        {
                            // int retVal = objServiceTimelinesBLL.InsertUpdateAllotteeDetails(objServiceTimelinesBEL);
                            int retVal = objServiceTimelinesBLL.AdvertisePlots(objServiceTimelinesBEL);
                            if (retVal > 0)
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot Publish for Advertisement');", true);
                                str += ListSelected.SelectedItem.Text.ToString();
                                ListSelected.Items.RemoveAt(i);
                                btnpublish.Enabled = false;

                            }
                        }



                    }
                }
                if (str.Length > 12)
                {
                    lblmsg.Text = str;
                    lblmsg.ForeColor = System.Drawing.Color.ForestGreen;
                }
                else { lblmsg.Text = "No plot published for advertisement"; }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        protected void btnGenerateOTP_Click(object sender, EventArgs e)
        {
            string PhoneNo, UserID,EmailID;
            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {


                if (ListSelected.Items.Count <= 0)
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select atleast one Plot to Advertise');", true); return;
                }



                dsR = objServiceTimelinesBLL.GetPhoneNoOfUser(objServiceTimelinesBEL);
                DataTable dt = new DataTable();
                dt = dsR.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    PhoneNo = dt.Rows[0]["phoneNo"].ToString();
                    UserID  = dt.Rows[0]["UserID"].ToString();
                    EmailID = dt.Rows[0]["emailID"].ToString();

                    if (EmailID.Length > 0)
                    {

                        //string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        //string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
                        string numbers = "1234567890";


                        string characters = numbers;
                        int length = 5;
                        string otp = string.Empty;
                        for (int i = 0; i < length; i++)
                        {
                            string character = string.Empty;
                            do
                            {
                                int index = new Random().Next(0, characters.Length);
                                character = characters.ToCharArray()[index].ToString();
                            } while (otp.IndexOf(character) != -1);
                            otp += character;
                        }

                        //string resultmsg = "";

                        //String message = HttpUtility.UrlEncode("Your OTP for Plot Publishing is " + otp + "");
                        //using (var wb = new WebClient())
                        //{
                        //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                        //                {
                        //                {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                        //                {"numbers" , PhoneNo},
                        //                {"message" , message}
                        ////              {"sender" , "UPSIDC"}
                        //                });
                        //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                        //}
                       
                        //var res = JObject.Parse(resultmsg);
                        
                        //if (res["status"].ToString().Trim() == "success")
                        //{
                            objServiceTimelinesBEL.UserId = Convert.ToInt32(UserID);
                            objServiceTimelinesBEL.PhoneNumber = PhoneNo;
                            objServiceTimelinesBEL.OTP = otp;
                            objServiceTimelinesBEL.ReferenceNumber = "RefPlot";
                            objServiceTimelinesBEL.OTPFor = "PlotPublish";

                            int result = objServiceTimelinesBLL.SaveOTP(objServiceTimelinesBEL);
                            if (result > 0)
                            {

                          MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                            MailAddress mailto = new MailAddress(EmailID);
                            MailMessage newmsg = new MailMessage(mailfrom, mailto);

                            //newmsg.IsBodyHtml = true;
                            string StrContent = "";
                            StreamReader reader = new StreamReader(Server.MapPath("~/OTPMail.html"));
                            StrContent = reader.ReadToEnd();

                            StrContent = StrContent.Replace("{UserName}", UserName.Trim());
                            StrContent = StrContent.Replace("{OTP}", otp.Trim());
                            StrContent = StrContent.Replace("{PlotNo}", ListSelected.SelectedItem.Text.Trim());
                            StrContent = StrContent.Replace("{IAName}", drpdwnIA.SelectedItem.Text.Trim());
                            newmsg.Subject = "UPSIDAeService:OTP for publishing of plot  ";
                            newmsg.BodyHtml = StrContent;


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
                            string message1 = "OTP Send To Your Registered Email ID";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                                divOTP.Visible = true;


                            }

                        //}
                        //else
                        //{
                        //    string message1 = "Error Sending OTP";
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);

                        //}

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('User Email ID Not Exist');", true);
                        return;
                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('User Not Exist');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }







        }

        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.UserName = UserName;
            objServiceTimelinesBEL.OTP = txtOTP.Text.Trim();
            objServiceTimelinesBEL.OTPFor = "PlotPublish";

            DataSet dsR = new DataSet();
            try
            {

                dsR = objServiceTimelinesBLL.VerifyOTP(objServiceTimelinesBEL);
                DataTable dt = new DataTable();
                dt = dsR.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string message = dt.Rows[0]["message"].ToString();
                    string status = dt.Rows[0]["status"].ToString();

                    if (status == "2")
                    {
                        divOTP.Visible = false;
                        btnpublish.Enabled = true;
                    }
                    else
                    {
                        btnpublish.Enabled = false;
                    }
                    //if (status == "1")
                    //{
                    //    btnResend.Visible = true;
                    //}
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    txtOTP.Text = "";
                    return;

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }

        protected void btnResend_Click(object sender, EventArgs e)
        {

        }

        protected void ListParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ListParent.SelectedItem.Text.Trim().IndexOf("|");
            string PlotNo = ListParent.SelectedItem.Text.Trim().Substring(0, index);
            GeneralMethod gm = new GeneralMethod();
            string msg = "You have selected plot " + PlotNo.Trim() + " for publishing which will be displayed on nivesh mitra and will be open for application from " + gm.GetPlotDisplayDate().Rows[0][0].ToString(); ;
            MessageBox1.ShowInfo(msg);
           
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                if (ListParent.SelectedIndex == -1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose any plot !');", true);
                    return;
                }
                else
                {
                    int retval = 0;
                    if (fileupload1.HasFile)
                    {
                        string filePath = fileupload1.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fileupload1.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        switch (fleUpload)
                        {
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;

                        }
                        if (contenttype != String.Empty)
                        {
                            Stream fs = fileupload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;



                        }
                    }
                    else
                    {
                        objServiceTimelinesBEL.filename = String.Empty;
                        objServiceTimelinesBEL.content = String.Empty;
                        objServiceTimelinesBEL.Uploadfile = null;
                    }
                    objServiceTimelinesBEL.PlotID = Convert.ToInt32(ListParent.SelectedValue.Trim());

                    retval = objServiceTimelinesBLL.UploadTracing(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Tracing Uploaded Successfully !');", true);
                        return;
                    }
                    else
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                if (ListParent.SelectedIndex == -1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose any plot !');", true);
                    return;
                }
                else
                {

                    int retval = 0;
                    if (fileupload2.HasFile)
                    {
                        string filePath = fileupload2.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fileupload2.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        switch (fleUpload)
                        {
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;

                        }
                        if (contenttype != String.Empty)
                        {
                            Stream fs = fileupload2.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;



                        }
                    }
                    else
                    {
                        objServiceTimelinesBEL.filename = String.Empty;
                        objServiceTimelinesBEL.content = String.Empty;
                        objServiceTimelinesBEL.Uploadfile = null;
                    }
                    objServiceTimelinesBEL.PlotID = Convert.ToInt32(ListParent.SelectedValue.Trim());

                    retval = objServiceTimelinesBLL.UploadJointCertificate(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Joint Certificate Uploaded Successfully !');", true);
                        return;
                    }
                    else
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ListParent.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose any plot !');", true);
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.PlotID = Convert.ToInt32(ListParent.SelectedValue.Trim());
                objServiceTimelinesBEL.Doctype = "T";

                ds = objServiceTimelinesBLL.GetTracingDocView(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];
                string Name = dtDoc.Rows[0]["TracingName"].ToString();
                if (Name.Length > 0)
                {
                    String js = "window.open('TracingDocViewer.aspx?PlotID=" + ListParent.SelectedValue.Trim() + "&DocType=T', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "TracingDocViewer.aspx", js, true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Tracing Uploaded yet !');", true);
                    return;
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ListParent.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose any plot !');", true);
                return;
            }
            else
            {

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.PlotID = Convert.ToInt32(ListParent.SelectedValue.Trim());
                objServiceTimelinesBEL.Doctype = "JC";

                ds = objServiceTimelinesBLL.GetTracingDocView(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];
                string Name = dtDoc.Rows[0]["JoinCertificateName"].ToString();
                if (Name.Length > 0)
                {
                    String js = "window.open('TracingDocViewer.aspx?PlotID=" + ListParent.SelectedValue.Trim() + "&DocType=JC', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "TracingDocViewer.aspx", js, true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Joint Certificate Uploaded yet !');", true);
                    return;
                }
            }
        }
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnupload);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button2);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ListParent.ClearSelection();
        }
    }
}