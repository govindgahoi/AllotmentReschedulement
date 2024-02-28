using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_OutsideCorrespondencePIP : System.Web.UI.UserControl
    {
        SqlConnection con;

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        public string DocID { get; set; }

        string UserName = "";

        int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.RegisterPostBackControl();

                Page.Form.Enctype = "multipart/form-data";
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
                    DataManager = dt.Rows[0][1].ToString();
                }
                BindOfficeOrders();

            }
            catch (Exception ex)
            {

            }

        }



        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnupload);

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

                    bool exist = Directory.EnumerateFiles(Server.MapPath("PIPCorrespondenceLetters"), filename).Any();

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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                if (btnSubmit.Text == "Save")
                {
                    if (txtLetterNo.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter letter no");
                        return;
                    }
                    if (txtLetterTo.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter whom letter is marked");
                        return;
                    }
                    if (txtLetterDate.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter Letter issue date");
                        return;
                    }
                    if (txtRemarks.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter Remarks/Subject Line");
                        return;
                    }
                    if (Convert.ToString(Session["Name"]).Length <= 0)
                    {
                        string msg = "Kindly upload copy of letter in pdf format";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }

                    string filePath = "~/PIPCorrespondenceLetters/" + Convert.ToString(Session["Name"]);
                    string date_to_be = DateTime.ParseExact(txtLetterDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.LetterNo = txtLetterNo.Text;
                    objServiceTimelinesBEL.LetterDate = Convert.ToDateTime((date_to_be));
                    objServiceTimelinesBEL.LetterFrom = txtLetterTo.Text;
                    objServiceTimelinesBEL.Remarks = txtRemarks.Text;
                    objServiceTimelinesBEL.LAWDocPath = filePath.Trim();
                    objServiceTimelinesBEL.CreatedBy = UserName.Trim();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                    int retVal = objServiceTimelinesBLL.InsertCorrespondenceLetters(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                        string msg = "Office Order details saved successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        ClearAll();
                        BindOfficeOrders();
                        return;
                    }
                    else
                    {
                        string msg = "Office Order Details couldn't be saved";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                }

                if (btnSubmit.Text == "Update")
                {

                    if (txtLetterNo.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter letter no");
                        return;
                    }
                    if (txtLetterTo.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter whom letter is marked");
                        return;
                    }

                    if (txtLetterDate.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter Letter issue date");
                        return;
                    }
                    if (txtRemarks.Text.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Enter Remarks/Subject Line");
                        return;
                    }


                    string filePath = "";
                    if (Convert.ToString(Session["Name"]).Length > 0)
                    {
                        filePath = "~/PIPCorrespondenceLetters/" + Convert.ToString(Session["Name"]);
                    }
                    else
                    {
                        filePath = lblFilePath.Text.Trim();
                    }
                    string date_to_be = DateTime.ParseExact(txtLetterDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.OfficeOrderID = lblServiceID.Text.Trim();
                    objServiceTimelinesBEL.LetterNo = txtLetterNo.Text;
                    objServiceTimelinesBEL.LetterDate = Convert.ToDateTime((date_to_be));
                    objServiceTimelinesBEL.LetterFrom = txtLetterTo.Text;
                    objServiceTimelinesBEL.Remarks = txtRemarks.Text;
                    objServiceTimelinesBEL.LAWDocPath = filePath.Trim();
                    objServiceTimelinesBEL.CreatedBy = UserName.Trim();
                    int retVal = objServiceTimelinesBLL.UpdateCorrespondenceDetails(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        if (Convert.ToString(Session["Name"]).Length > 0)
                        {
                            File.Delete(Server.MapPath(lblFilePath.Text));
                            File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                        }

                        string msg = "Record Updated successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        ClearAll();
                        BindOfficeOrders();

                        return;
                    }
                    else
                    {
                        string msg = "details couldn't be Updated";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        private void BindOfficeOrders()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetAllCorrespondenceLetters(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView2.PageSize;
                lblServiceID.Text = GridView2.DataKeys[index].Values[0].ToString();
                lblFilePath.Text = GridView2.DataKeys[index].Values[1].ToString();
                txtLetterNo.Text = GridView2.Rows[index].Cells[1].Text;
                txtLetterDate.Text = GridView2.Rows[index].Cells[2].Text;
                txtLetterTo.Text = GridView2.Rows[index].Cells[3].Text;
                txtRemarks.Text = GridView2.Rows[index].Cells[4].Text;


                btnSubmit.Text = "Update";
            }
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % GridView2.PageSize;
                string OrderId = GridView2.DataKeys[rowIndex].Values[0].ToString();
                string filePath = GridView2.DataKeys[rowIndex].Values[1].ToString();
                objServiceTimelinesBEL.OfficeOrderID = OrderId;
                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteCorrespondenceLetters(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        File.Delete(Server.MapPath(filePath));
                        string msg = "Letter deleted successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);


                        BindOfficeOrders();

                        return;
                    }
                    else
                    {

                        string msg = "Office Order details couldn't be deleted";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }

            }
            if (e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % GridView2.PageSize;
                string filePath = GridView2.DataKeys[rowIndex].Values[1].ToString();
                Response.Write("<script>window.open ('" + filePath.Trim().Remove(0, 2) + "','_blank');</script>");

            }

        }

        public void ClearAll()
        {
            txtRemarks.Text = "";
            txtLetterDate.Text = "";
            txtRemarks.Text = "";
            txtLetterTo.Text = "";
            txtLetterNo.Text = "";
            lblServiceID.Text = "";
            lbluploadingMsg.Text = "";
            lblFilePath.Text = "";
            btnSubmit.Text = "Save";
            Session["Name"] = "";
            Session["Ext"] = "";
            Session["Doc"] = "";
        }
    }
}