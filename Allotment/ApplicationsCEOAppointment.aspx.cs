using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
//using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class ApplicationsCEOAppointment : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Received" });
                sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Approved" });
                sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Completed" });
                sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Rejected" });
                sub_menu.DataBind();
              
                if (ApplicationView.ActiveViewIndex <= 0)
                {
                    ApplicationView.ActiveViewIndex = 0;

                }
                Bind_Announcement_List_GridView();
                BindAppointmentApproved();
                BindAppointmentCompleted();
                BindAppointmentRejected();
            }
        }




     

     
        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }


    
        private void Bind_Announcement_List_GridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;


                ds = objServiceTimelinesBLL.GetAppointmentRecieved(objServiceTimelinesBEL);
                


                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_Recieved.DataSource = ds.Tables[0];
                    Grid_Recieved.DataBind();

                }
                else
                {
                    Grid_Recieved.DataSource = null;
                    Grid_Recieved.DataBind();

                }
                

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void BindAppointmentApproved()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
              
                ds = objServiceTimelinesBLL.GetAppointmentApproved(objServiceTimelinesBEL);



                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_Approved.DataSource = ds.Tables[0];
                    Grid_Approved.DataBind();

                }
                else
                {
                    Grid_Approved.DataSource = null;
                    Grid_Approved.DataBind();

                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void BindAppointmentCompleted()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                ds = objServiceTimelinesBLL.GetAppointmentCompleted(objServiceTimelinesBEL);



                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_Completed.DataSource = ds.Tables[0];
                    Grid_Completed.DataBind();

                }
                else
                {
                    Grid_Completed.DataSource = null;
                    Grid_Completed.DataBind();

                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void BindAppointmentRejected()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
               
                ds = objServiceTimelinesBLL.GetAppointmentRejected(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_Rejected.DataSource = ds.Tables[0];
                    Grid_Rejected.DataBind();

                }
                else
                {
                    Grid_Rejected.DataSource = null;
                    Grid_Rejected.DataBind();

                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private DataTable Getdata1
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnReject);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button2);
     

        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   string ID = Grid_Recieved.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    string Doc = Grid_Recieved.DataKeys[e.Row.RowIndex].Values[1].ToString();
                    LinkButton lnk = (LinkButton)e.Row.FindControl("btnDownload");

                    if(Doc.Length<=0)
                    {
                        lnk.Visible = false;
                    }
                    e.Row.Cells[10].Attributes.Add("onclick", "ShowPopupChange('" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[1].Text) + "','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text) + "'); return false;");
                    e.Row.Cells[10].Attributes.Add("style", "background: green !important;cursor:pointer;");
                    e.Row.Cells[11].Attributes.Add("onclick", "ShowPopupChange1('" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[1].Text) + "','"+ HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text) + "'); return false;");
                    e.Row.Cells[11].Attributes.Add("style", "background: red !important;cursor:pointer;");

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


       

        protected void Grid_Recieved_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % Grid_Recieved.PageSize;
                string filePath = Grid_Recieved.DataKeys[rowIndex].Values[1].ToString();

                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            
        }

        private void SendMailRejection(string ID)
        {

            try
            {

                DataTable dt = AppointeeDetails(ID);
                string Name = dt.Rows[0]["Name"].ToString();
                string Mail = dt.Rows[0]["EmailID"].ToString();
                string Phone = dt.Rows[0]["PhoneNo"].ToString();

              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto   = new MailAddress(Mail);
                MailMessage newmsg   = new MailMessage(mailfrom, mailto);

                //newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/CEOAppointmentRejection.html"));
                StrContent = reader.ReadToEnd();
                StrContent = StrContent.Replace("{UserName}", Name.Trim());
                StrContent = StrContent.Replace("{Table}", txtRejReason.Text.Trim());
                newmsg.Subject = "Intimation of Rejection of Appointment id '"+ ID.Trim() + "' with CEO UPSIDA";
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

                GeneralMethod gm = new GeneralMethod();
                String message = HttpUtility.UrlEncode("Dear " + Name.Trim() + " your appointment with CEO UPSIDA has been rejected. For rejection reason kindly go through your registered mail id.");
                string s = gm.SendOTP("OTP", Phone.Trim(), Name.Trim(), message);

            }
            catch (Exception ex)
            {

            }
        }
        private void SendMailApproval(string ID)
        {

            try
            {

                DataTable dt = AppointeeDetails(ID);
                string Name = dt.Rows[0]["Name"].ToString();
                string Mail = dt.Rows[0]["EmailID"].ToString();
                string Phone = dt.Rows[0]["PhoneNo"].ToString();
                string Time = dt.Rows[0]["Time"].ToString();
                string Date = dt.Rows[0]["AppDate"].ToString();
                string Remarks = dt.Rows[0]["Remarks"].ToString();

              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto   = new MailAddress(Mail);
                MailMessage newmsg   = new MailMessage(mailfrom, mailto);

                //newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/CEOAppointmentApproval.html"));
                StrContent = reader.ReadToEnd();
                StrContent = StrContent.Replace("{UserName}", Name.Trim());
                StrContent = StrContent.Replace("{Date}", Date.Trim());
                StrContent = StrContent.Replace("{Time}", Time.Trim());
                StrContent = StrContent.Replace("{Remarks}", Remarks.Trim());
                newmsg.Subject = "Intimation of Approval of Appointment id " + ID.Trim() + " with CEO UPSIDA";
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

                GeneralMethod gm = new GeneralMethod();
                String message = HttpUtility.UrlEncode("Dear " + Name.Trim() + " your appointment with CEO UPSIDA has been scheduled on "+Date.Trim()+" at "+Time.Trim()+".");
                string s = gm.SendOTP("OTP", Phone.Trim(), Name.Trim(), message);


            }
            catch (Exception ex)
            {

            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRejReason.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowRejectionModal();", true);
                    return;
                }


                
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "CallButtonEventReject();", true);

                //int retval = 0;
                //objServiceTimelinesBEL.CaseID = Request.Form[hfName.UniqueID]; 
                //objServiceTimelinesBEL.Comments = txtRejReason.Text;
                //retval = objServiceTimelinesBLL.RejectCeoAppointment(objServiceTimelinesBEL);
                //if (retval > 0)
                //{
                //    SendMailRejection(Request.Form[hfName.UniqueID].Trim());
                //    string message1 = "Appointment Rejected Successfully";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);         
                //    Bind_Announcement_List_GridView();
                //    BindAppointmentRejected();
                //    BindAppointmentCompleted();
                //    BindAppointmentApproved();
                //    txtRejReason.Text = "";
                //}
            }
            catch (Exception ex)
            {

            }
        }

        
        


        private DataTable AppointeeDetails( string ID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.IAID = ID;


                ds = objServiceTimelinesBLL.GetAppointeeDetails(objServiceTimelinesBEL);

               
                dt = ds.Tables[0];


                return dt;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
                return dt;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAppDate.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowApprovalModal('Please provide date of appointment');", true);
                    return;
                }
                if (txtTime.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowApprovalModal('Please provide time of appointment');", true);
                    return;
                }

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "CallButtonEventApprove();", true);


                //    int retval = 0;
                //    string date_to_be = DateTime.ParseExact(txtAppDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                //    objServiceTimelinesBEL.CaseID = Request.Form[hfName1.UniqueID];
                //    objServiceTimelinesBEL.Date = Convert.ToDateTime(date_to_be);
                //    objServiceTimelinesBEL.AppointmentTime = TimeSpan.Parse(txtTime.Text);
                //    retval = objServiceTimelinesBLL.ApproveCeoAppointment(objServiceTimelinesBEL);
                //    if (retval > 0)
                //    {
                //        SendMailApproval(Request.Form[hfName1.UniqueID].Trim());
                //        string message1 = "Appointment Approved Successfully";
                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);

                //        Bind_Announcement_List_GridView();
                //        BindAppointmentRejected();
                //        BindAppointmentCompleted();
                //        BindAppointmentApproved();
                //        txtAppDate.Text = "";
                //        txtTime.Text = "";

                //    }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Grid_Approved_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ID = Grid_Approved.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string Doc = Grid_Approved.DataKeys[e.Row.RowIndex].Values[1].ToString();
                LinkButton lnk = (LinkButton)e.Row.FindControl("btnDownload");

                if (Doc.Length <= 0)
                {
                    lnk.Visible = false;
                }

                DataTable dt = AppointeeDetails(ID);
               
                string Time = dt.Rows[0]["Time"].ToString();
                string Date = dt.Rows[0]["AppDate"].ToString();
                string Remarks = dt.Rows[0]["Remarks"].ToString();

                e.Row.Cells[11].Attributes.Add("onclick", "ShowPopupChange2('" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[1].Text) + "','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text) + "'); return false;");
                e.Row.Cells[11].Attributes.Add("style", "background: antiquewhite !important;cursor:pointer;");
                e.Row.Cells[1].Attributes.Add("onclick", "ShowPopupChange3('" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[1].Text) + "','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text) + "','"+Date.Trim()+"','"+Time.Trim()+"','"+Remarks.Trim()+"'); return false;");
                e.Row.Cells[1].Attributes.Add("style", "background: antiquewhite !important;cursor:pointer;");

            }
        }

        protected void Grid_Approved_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % Grid_Approved.PageSize;
                string filePath = Grid_Approved.DataKeys[rowIndex].Values[1].ToString();

                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
        }

        protected void Grid_Rejected_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Doc = Grid_Rejected.DataKeys[e.Row.RowIndex].Values[1].ToString();
                LinkButton lnk = (LinkButton)e.Row.FindControl("btnDownload");

                if (Doc.Length <= 0)
                {
                    lnk.Visible = false;
                }

            }
        }

        protected void Grid_Rejected_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % Grid_Rejected.PageSize;
                string filePath = Grid_Rejected.DataKeys[rowIndex].Values[1].ToString();

                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
        }

        protected void Grid_Completed_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ID = Grid_Completed.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string Doc = Grid_Completed.DataKeys[e.Row.RowIndex].Values[1].ToString();
                LinkButton lnk = (LinkButton)e.Row.FindControl("btnDownload");

                if (Doc.Length <= 0)
                {
                    lnk.Visible = false;
                }
                DataTable dt = AppointeeDetails(ID);

                string Time = dt.Rows[0]["Time"].ToString();
                string Date = dt.Rows[0]["AppDate"].ToString();
                string Remarks = dt.Rows[0]["Remarks"].ToString();
                e.Row.Cells[1].Attributes.Add("onclick", "ShowPopupChange3('" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[1].Text) + "','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text) + "','" + Date.Trim() + "','" + Time.Trim() + "','"+Remarks.Trim()+"'); return false;");
                e.Row.Cells[1].Attributes.Add("style", "background: antiquewhite !important;cursor:pointer;");

            }
        }

        protected void Grid_Completed_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % Grid_Completed.PageSize;
                string filePath = Grid_Completed.DataKeys[rowIndex].Values[1].ToString();

                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
               
              
                int retval = 0;
                objServiceTimelinesBEL.CaseID = Request.Form[hfName2.UniqueID].Trim();
                retval = objServiceTimelinesBLL.CloseCeoAppointment(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    
                    string message1 = "Appointment Closed Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    Bind_Announcement_List_GridView();
                    BindAppointmentApproved();
                    BindAppointmentCompleted();
                    BindAppointmentRejected();
                    ApplicationView.ActiveViewIndex = 1;
                   
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnReject1_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                objServiceTimelinesBEL.CaseID = Request.Form[hfName.UniqueID];
                objServiceTimelinesBEL.Comments = txtRejReason.Text;
                retval = objServiceTimelinesBLL.RejectCeoAppointment(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    SendMailRejection(Request.Form[hfName.UniqueID].Trim());
                    string message1 = "Appointment Rejected Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    Bind_Announcement_List_GridView();
                    BindAppointmentRejected();
                    BindAppointmentCompleted();
                    BindAppointmentApproved();
                    txtRejReason.Text = "";
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnApprove1_Click(object sender, EventArgs e)
        {
            try
            {
               

                int retval = 0;
                string date_to_be = DateTime.ParseExact(txtAppDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                objServiceTimelinesBEL.CaseID = Request.Form[hfName1.UniqueID];
                objServiceTimelinesBEL.Date = Convert.ToDateTime(date_to_be);
                objServiceTimelinesBEL.AppointmentTime = TimeSpan.Parse(txtTime.Text);
                objServiceTimelinesBEL.Remarks = txtRemarks.Text.Trim();
                retval = objServiceTimelinesBLL.ApproveCeoAppointment(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    SendMailApproval(Request.Form[hfName1.UniqueID].Trim());
                    string message1 = "Appointment Approved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);

                    Bind_Announcement_List_GridView();
                    BindAppointmentRejected();
                    BindAppointmentCompleted();
                    BindAppointmentApproved();
                    txtAppDate.Text = "";
                    txtTime.Text = "";

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}