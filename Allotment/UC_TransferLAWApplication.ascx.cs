using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_TransferLAWApplication : System.Web.UI.UserControl
    {
        SqlConnection con;
      
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        Classes.Class1 cs = new Classes.Class1();
        #endregion
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        public string   UserName    = "";
        public int      UserId      = 0;
        public string   Level       = "";
        public string   DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
               
                Page.Form.Enctype = "multipart/form-data";
                this.RegisterPostBackControl();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    lblLevel.Text= dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();

                 

                }

                BindTransferToDdl();
                BindUsersList();
               
            }
            catch (Exception ex) 
            { 
            }


           
        }


        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnupload);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnReminder);
        }
        private void BindTransferToDdl()
        {
            SqlCommand cmd = new SqlCommand("service_request_track_LAW '" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
       
            DataTable dt    = ds.Tables[0];
  
            if (dt.Rows.Count > 0)
            {

                drpSendto.DataSource = dt;
                drpSendto.DataBind();
                drpSendto.DataTextField = "drp_text";
                drpSendto.DataValueField = "drp_value";
                drpSendto.DataBind();
                

            }else
            {
                drpSendto.ClearSelection();
                drpSendto.DataSource = dt;
                drpSendto.DataBind();
            }

        }


        private void BindReminderFor()
        {
            SqlCommand cmd = new SqlCommand("SELECT ToUser,id FROM ServiceRequest_Track_LAW WHERE isActive=1 AND ServiceId='" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                ddlFrom.DataSource = dt;
                ddlFrom.DataBind();
                ddlFrom.DataTextField = "ToUser";
                ddlFrom.DataValueField = "id";
                ddlFrom.DataBind();
                ddlFrom.Items.Insert(0, "Reminder To");


            }
            else
            {
                ddlFrom.ClearSelection();
                ddlFrom.DataSource = dt;
                ddlFrom.DataBind();
            }

        }






        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                if (drpSendto.SelectedValue.Length<=0)
                {
                    MessageBox1.ShowWarning("No recipient to forward");
                    return;
                }
                if(txtComment.Text.Length<=0)
                {
                    MessageBox1.ShowWarning("Enter Comments in the comments box");
                    return;
                }


                int retVal = 0;
                if (Convert.ToString(Session["Name"]).Length <= 0)
                {
                    filePath = "";

                }
                else
                {
                    filePath = "~/LAWCorrespondenceLetters/" + Convert.ToString(Session["Name"]);
                }

                foreach (ListItem drpSendto in this.drpSendto.Items)
                {
                    if (drpSendto.Selected == true)
                    {
                        DataSet ds = new DataSet();
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        objServiceTimelinesBEL.TransferFrom     = lblLevel.Text.Trim();
                        objServiceTimelinesBEL.TransferTo       = drpSendto.Value.Trim();
                        objServiceTimelinesBEL.FromUser         = UserName.Trim();
                        objServiceTimelinesBEL.Comments         = txtComment.Text.Trim();
                        objServiceTimelinesBEL.LAWDocPath       = filePath.Trim();

                        retVal += objServiceTimelinesBLL.TransferApplicationLAW(objServiceTimelinesBEL);                        
                    }
                }

                if (retVal > 0)
                {
                    if (filePath.Length > 0)
                    {
                        File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                    }
                    lbluploadingMsg.Text = "";

                    MessageBox1.ShowSuccess("Application forwarded successfully");
                    txtComment.Text = "";
                    Session["Name"] = "";
                    BindTransferToDdl();
                }
                else
                {
                    MessageBox1.ShowSuccess("Erron In Transferring Application");
                    return;
                }




            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
                return;
            }
        }



        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {

                int maxFileSize = 1;

                 
                    if (fileupload1.HasFile)
                    {

                        // Read the file and convert it to Byte Array
                        string filePath = fileupload1.PostedFile.FileName;
                        string filename = Path.GetFileName(filePath);
                        string ext = Path.GetExtension(filename);
                        string contenttype = String.Empty;
                        int fileSize = fileupload1.PostedFile.ContentLength;
                        if (fileSize > (maxFileSize * 1024 * 1024))
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                            return;
                        }

                        bool exist = Directory.EnumerateFiles(Server.MapPath("LAWCorrespondenceLetters"), filename).Any();

                        if (exist == true)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Letter with same file name already exists');", true);
                            return;
                        }

                        //Set the contenttype based on File Extension
                        switch (ext)
                        {

                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;

                        }

                        if (contenttype != String.Empty && ext == ".pdf")
                        {

                            Stream fs = fileupload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                            Session["Name"] = filename;
                            Session["Ext"] = contenttype;
                            Session["Doc"] = bytes;
                            lbluploadingMsg.Text = "File uploaded Successfully";
                            lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                            lbluploadingMsg.Visible = true;
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                            lbluploadingMsg.Visible = true;
                            return;

                        }

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose file to upload');", true);
                        lbluploadingMsg.Visible = true;
                        return;
                    }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void BindUsersList()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetUserForwardedList(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["reminder1"] = "~/LogisticAndWareHousing/Reminder/" + ds.Tables[0].Rows[i]["Reminder1"].ToString();
                        ds.Tables[0].Rows[i]["reminder2"] = "~/LogisticAndWareHousing/Reminder/" + ds.Tables[0].Rows[i]["Reminder2"].ToString();
                        ds.Tables[0].Rows[i]["reminder3"] = "~/LogisticAndWareHousing/Reminder/" + ds.Tables[0].Rows[i]["Reminder3"].ToString();
                        ds.Tables[0].Rows[i]["reminder4"] = "~/LogisticAndWareHousing/Reminder/" + ds.Tables[0].Rows[i]["Reminder4"].ToString();
                        ds.Tables[0].Rows[i]["reminder5"] = "~/LogisticAndWareHousing/Reminder/" + ds.Tables[0].Rows[i]["Reminder5"].ToString();

                    }
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    cs.str = "SELECT top 1 isnull(remCount,0) FROM ServiceRequest_Track_LAW WHERE ServiceId='" + ServiceReqNo + "' and IsActive='1' order by id desc ";
                    int count = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                    if (count < 5)
                    {
                        BindReminderFor();
                        PanelReminder.Visible = true;
                        //FileUpload1.Visible = true;
                        //btnReminder.Visible = true;
                    }
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void btnUploadReminder_Click(object sender, EventArgs e)
        {
            int maxFileSize = 1;
            if (ddlFrom.SelectedIndex>0)
            {
                if (FileUploadReminder.HasFile)
                {

                    // Read the file and convert it to Byte Array
                    string filePath = FileUploadReminder.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = FileUploadReminder.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                        return;
                    }
                    //Set the contenttype based on File Extension
                    switch (ext)
                    {

                        case ".pdf":
                            contenttype = "application/pdf";
                            break;
                        case ".PDF":
                            contenttype = "application/pdf";
                            break;

                    }

                    if (contenttype != String.Empty && ext == ".pdf")
                    {

                        Stream fs = FileUploadReminder.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        objServiceTimelinesBEL.LAName = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;

                        Session["LAFileName"] = objServiceTimelinesBEL.LAName;
                        Session["LAFileExt"] = objServiceTimelinesBEL.content;
                        Session["LAFile"] = objServiceTimelinesBEL.Uploadfile;
                        lbluploadingMsg.Text = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible = true;

                        if (Convert.ToString(Session["LAFileName"]).Length <= 0)
                        {
                            filePath = "";

                        }
                        else
                        {
                            filePath = "~/LogisticAndWareHousing/Reminder/" + Convert.ToString(Session["LAFileName"]);

                        }
                        cs.str = "select   id,isnull(remCount,0)as remCount from ServiceRequest_Track_LAW where ServiceId='" + ServiceReqNo.Trim() + "' and id='" + ddlFrom.SelectedValue + "' and IsActive='1' order by id desc";
                        //int ids = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                        DataTable dt = new DataTable();
                        dt = cs.GetDataTable(cs.str);
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 0)
                            {
                                cs.str = "update ServiceRequest_Track_LAW set remCount=1,Reminder1='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy1='" + UserName + "',remDate1='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 1)
                            {
                                cs.str = "update ServiceRequest_Track_LAW set remCount=2,Reminder2='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy2='" + UserName + "',remDate2='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 2)
                            {
                                cs.str = "update ServiceRequest_Track_LAW set remCount=3,Reminder3='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy3='" + UserName + "',remDate3='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 3)
                            {
                                cs.str = "update ServiceRequest_Track_LAW set remCount=4,Reminder4='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy4='" + UserName + "',remDate4='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 4)
                            {
                                cs.str = "update ServiceRequest_Track_LAW set remCount=5,Reminder5='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy5='" + UserName + "',remDate5='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }

                            if (filePath.Length > 0)
                            {
                                File.WriteAllBytes(Server.MapPath(filePath), Session["LAFile"] as byte[]);

                            }

                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Reminder File uploaded Successfully');", true);

                            BindUsersList();

                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                        return;

                    }

                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Reminder To');", true);
                lbluploadingMsg.Visible = true;
                return;
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ID = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();

                SqlCommand cmd = new SqlCommand("select Comments, Convert(varchar,CommentDate,103),ToUser from ServiceRequest_Track_LAW where ID='" + ID.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                   

                    if(dt.Rows[0][0].ToString().Length<=0)
                    {
                        lblComments.Text = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        lblComments.Text = "Comments Pending";
                    }
                    change_title.Text = "Comments Received From "+dt.Rows[0][2].ToString();


                }
                else
                {
                    lblComments.Text = "Comments Pending";

                    change_title.Text = "Comments Received From " + dt.Rows[0][2].ToString();

                }






                e.Row.Cells[4].Attributes.Add("onclick", "ShowPopup()");
                e.Row.Cells[4].Attributes.Add("style", "background: antiquewhite !important;width: 200px !important;cursor:pointer;");

            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView2.PageSize;
                string ID = GridView2.DataKeys[index].Values[0].ToString();

                SqlCommand cmd = new SqlCommand("select Comments, Convert(varchar,CommentDate,103),ToUser from ServiceRequest_Track_LAW where ID='" + ID.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {



                    if (dt.Rows[0][0].ToString().Length <= 0)
                    {
                        lblComments.Text = "Comments Pending";
                    }
                    else
                    {
                        lblComments.Text = dt.Rows[0][0].ToString();

                    }
                    change_title.Text = "Comments Received From " + dt.Rows[0][2].ToString();


                }
                else
                {
                    lblComments.Text = "Comments Pending";

                    change_title.Text = "Comments Received From " + dt.Rows[0][2].ToString();

                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowPopup()", true);
                
            }
        }
    }
}