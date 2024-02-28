using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QueryStringEncryption;

namespace Allotment
{
    public partial class OfficeOrderMaster : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string UserName = string.Empty;
        int UserID;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserID = _objLoginInfo.userid;

                if (!Page.IsPostBack)
                {
                    
                    BindOfficeOrders();
                }

            }
            catch (Exception ex)
            {

                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        #region "Bind  Office Orders Records in GridView"
        private void BindOfficeOrders()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetOfficeOrdersList();
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
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }
        #endregion
        #region "Save Office Orders Record"
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (btnSubmit.Text == "Save")
                {

                  
                    
                    if (Convert.ToString(Session["TracingName"]).Length<=0)
                    {
                        string msg = "Kindly upload copy of office order";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                    
                    string filePath = "~/OfficeOrders/" + Convert.ToString(Session["TracingName"]);
                    string date_to_be = DateTime.ParseExact(txtIssuedDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.OrderRefNo = txtOrderRefNo.Text.Trim();
                    objServiceTimelinesBEL.IssuedDate = Convert.ToDateTime(date_to_be);
                    objServiceTimelinesBEL.Section = drpSection.SelectedValue.Trim();
                    objServiceTimelinesBEL.SubjectOrder = txtSubject.Text.Trim();
                    objServiceTimelinesBEL.IssuedBy = txtIssuedBy.Text.Trim();
                    objServiceTimelinesBEL.PublicPrivate = drpPrivate.SelectedValue.Trim();
                    objServiceTimelinesBEL.Description = txtDescription.Text.Trim();
                    objServiceTimelinesBEL.OrderFilePath = filePath.Trim();
                    objServiceTimelinesBEL.OrderCategory = drpCategory.SelectedValue.Trim();
                    objServiceTimelinesBEL.CreatedBy = UserName.Trim();

                    int retVal = objServiceTimelinesBLL.SaveOfficeOrder(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        File.WriteAllBytes(Server.MapPath(filePath), Session["Tracing"] as byte[]);
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
                    string filePath = "";
                    if (Convert.ToString(Session["TracingName"]).Length>0)
                    {
                         filePath = "~/OfficeOrders/" + Convert.ToString(Session["TracingName"]);
                    }
                    else
                    {
                        filePath = lblFilePath.Text.Trim();
                    }
                    string date_to_be = DateTime.ParseExact(txtIssuedDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.OfficeOrderID = lblServiceID.Text.Trim();
                    objServiceTimelinesBEL.OrderRefNo    = txtOrderRefNo.Text.Trim();
                    objServiceTimelinesBEL.IssuedDate    = Convert.ToDateTime((date_to_be)); 
                    objServiceTimelinesBEL.Section       = drpSection.SelectedValue.Trim();
                    objServiceTimelinesBEL.SubjectOrder  = txtSubject.Text.Trim();
                    objServiceTimelinesBEL.IssuedBy      = txtIssuedBy.Text.Trim();
                    objServiceTimelinesBEL.PublicPrivate = drpPrivate.SelectedValue.Trim();
                    objServiceTimelinesBEL.Description   = txtDescription.Text.Trim();
                    objServiceTimelinesBEL.OrderFilePath = filePath.Trim();
                    objServiceTimelinesBEL.OrderCategory = drpCategory.SelectedValue.Trim();
                    objServiceTimelinesBEL.CreatedBy     = UserName.Trim();
                    int retVal = objServiceTimelinesBLL.UpdateOfficeOrderMaster(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        if (Convert.ToString(Session["TracingName"]).Length > 0)
                        {                         
                            File.Delete(Server.MapPath(lblFilePath.Text));
                            File.WriteAllBytes(Server.MapPath(filePath), Session["Tracing"] as byte[]);
                        }
                      
                        string msg = "Office Order details Updated successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('"+msg+"');", true);                      
                        ClearAll();
                        BindOfficeOrders();
                       
                        return;
                    }
                    else
                    {
                        string msg = "Office Order details couldn't be Updated";
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
        #endregion
        #region "Common Operations"
        public void ClearAll()
        {
            txtDescription.Text = "";
            txtOrderRefNo.Text = "";
            txtSubject.Text = "";
            drpSection.SelectedIndex = 0;
            drpPrivate.SelectedIndex = 0;
            drpCategory.SelectedIndex = 0;    
            txtIssuedBy.Text = "";
            txtIssuedDate.Text = "";
            lblServiceID.Text = "";
            lbluploadingMsg.Text = "";
            lblStatus.Text = "";
            lblFilePath.Text = "";
            btnSubmit.Text = "Save";
            Session["TracingName"] = "";
            Session["TracingExt"] = "";
            Session["Tracing"] = "";


        }
        

        #endregion
      
    
        #region "GridView Operations"
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            var a = GridView2.SelectedRow.Cells[1].Text;
            var b = GridView2.SelectedRow.Cells[2].Text;

           
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
                lblServiceID.Text         = GridView2.DataKeys[index].Values[0].ToString();
                lblFilePath.Text          = GridView2.DataKeys[index].Values[1].ToString();
                txtOrderRefNo.Text        = GridView2.Rows[index].Cells[1].Text;
                drpCategory.SelectedValue = GridView2.Rows[index].Cells[2].Text;
                txtIssuedDate.Text        = GridView2.Rows[index].Cells[3].Text;
                txtIssuedBy.Text          = GridView2.Rows[index].Cells[4].Text;
                drpSection.SelectedValue  = GridView2.Rows[index].Cells[5].Text;
                txtSubject.Text           = GridView2.Rows[index].Cells[6].Text;
                txtDescription.Text       = GridView2.Rows[index].Cells[7].Text;
                drpPrivate.SelectedValue  = GridView2.Rows[index].Cells[8].Text;
               
                btnSubmit.Text = "Update";
            }
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % GridView2.PageSize;
                string OrderId  = GridView2.DataKeys[rowIndex].Values[0].ToString();
                string filePath = GridView2.DataKeys[rowIndex].Values[1].ToString();
                objServiceTimelinesBEL.OfficeOrderID = OrderId;
                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteOfficeOrder(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        File.Delete(Server.MapPath(filePath));
                        string msg = "Office Order details deleted successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);

                        ClearAll();
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
            if(e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % GridView2.PageSize;
                string filePath = GridView2.DataKeys[rowIndex].Values[1].ToString();

                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }

        }

        #endregion
     
         public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
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

                    bool exist = Directory.EnumerateFiles(Server.MapPath("OfficeOrders"), filename).Any();

                    if(exist==true)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Office order with same file name already exists');", true);
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

                        objServiceTimelinesBEL.LAName = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;

                        Session["TracingName"] = objServiceTimelinesBEL.LAName;
                        Session["TracingExt"] = objServiceTimelinesBEL.content;
                        Session["Tracing"] = objServiceTimelinesBEL.Uploadfile;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}