using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QueryStringEncryption;

namespace Allotment.Masters
{
    public partial class CreateServiceChecklist : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ClearAll();
                BindCategory();
                Disabled();



                string strReq = "";
                strReq = Request.RawUrl;
                strReq = strReq.Substring(strReq.IndexOf('?') + 1);

                if (!strReq.Equals(""))
                {
                    strReq = DecryptQueryString(strReq);

                    //Parse the value... this is done is very raw format.. you can add loops or so to get the values out of the query string...
                    string[] arrMsgs = strReq.Split('&');
                    string[] arrIndMsg;

                    string strid = "", strLandUse = "", strActivity = "", strTimeLines = "", strApprover = "";
                    arrIndMsg = arrMsgs[0].Split('='); //Get the ID
                    strid = arrIndMsg[1].ToString().Trim();
                    arrIndMsg = arrMsgs[1].Split('='); //Get the LandUse
                    strLandUse = arrIndMsg[1].ToString().Trim();
                    arrIndMsg = arrMsgs[2].Split('='); //Get the Activity
                    strActivity = arrIndMsg[1].ToString().Trim();
                    arrIndMsg = arrMsgs[3].Split('='); //Get the TimeLines
                    strTimeLines = arrIndMsg[1].ToString().Trim();
                    arrIndMsg = arrMsgs[4].Split('='); //Get the TimeLines
                    strApprover = arrIndMsg[1].ToString().Trim();

                    lblServiceID.Text = strid;
                    txtServiceID.Text = strid;
                    txtActivity.Text = strActivity;
                    txtTimelines.Text = strTimeLines;
                    txtApprover.Text = strApprover;
                    drplanduse.SelectedIndex = drplanduse.Items.IndexOf(drplanduse.Items.FindByText(strLandUse));
                }
                else
                {
                    Response.Redirect("../Masters/ServiceTimelinesCreate.aspx");
                }
                BindServiceCheckListGridView();

            }
        }

        public void ClearAll()
        {
            txtNorms.Text = "";
            txtChecklist.Text = "";
            Session["FileName"] = "";
            Session["File"] = "";
            Session["FileExt"] = "";
            lbluploadingMsg.Text = "";
        }
        public void Enabled()
        {
            lblServiceID.Enabled = true;
            txtServiceID.Enabled = true;
            txtActivity.Enabled = true;
            txtTimelines.Enabled = true;
            txtApprover.Enabled = true;
            drplanduse.Enabled = true;
        }

        public void Disabled()
        {
            lblServiceID.Enabled = false;
            txtServiceID.Enabled = false;
            txtActivity.Enabled = false;
            txtTimelines.Enabled = false;
            txtApprover.Enabled = false;
            drplanduse.Enabled = false;
        }

        public void BindCategory()
        {
            drplanduse.Items.Clear();
            drplanduse.Items.Add("---Select Category---");
            drplanduse.Items.Add("Industrial");
            drplanduse.Items.Add("Institutional");
            drplanduse.Items.Add("Commercial");
            drplanduse.Items.Add("Residential");
            drplanduse.Items.Add("Group Housing");
            drplanduse.Items.Add("Builders");
        }

        public void BindServiceCheckListGridView()
        {
            objServiceTimelinesBEL.ServiceChecklistId = lblServiceID.Text;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceMasterChecklists(objServiceTimelinesBEL);
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
        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{



        //    if (e.CommandName == "Delete")
        //    {
        //        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
        //        try
        //        {
        //            int retVal = objServiceTimelinesBLL.DeleteCheckListDocument(objServiceTimelinesBEL);
        //            if (retVal > 0)
        //            {
        //                string message = "Checklist Document deleted successfully ";
        //                string script = "window.onload = function(){ alert('";
        //                script += message;
        //                script += "')};";
        //                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //            }
        //            else
        //            {
        //                string message = "Checklist Document couldn't be deleted";
        //                string script = "window.onload = function(){ alert('";
        //                script += message;
        //                script += "')};";
        //                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //}

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            // check if any documents to be uploaded
            if (fileupload.HasFile)
            {

                // Read the file and convert it to Byte Array
                string filePath = fileupload.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;

                //Set the contenttype based on File Extension
                switch (ext)
                {
                    case ".doc":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".docx":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".xls":
                        contenttype = "application/vnd.ms-excel";
                        break;
                    case ".xlsx":
                        contenttype = "application/vnd.ms-excel";
                        break;
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".gif":
                        contenttype = "image/gif";
                        break;
                    case ".pdf":
                        contenttype = "application/pdf";
                        break;
                }
                if (contenttype != String.Empty)
                {

                    Stream fs = fileupload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    objServiceTimelinesBEL.filename = filename;
                    objServiceTimelinesBEL.content = contenttype;
                    objServiceTimelinesBEL.Uploadfile = bytes;

                    Session["FileName"] = objServiceTimelinesBEL.filename;
                    Session["File"] = objServiceTimelinesBEL.Uploadfile;
                    Session["FileExt"] = objServiceTimelinesBEL.content;
                    lbluploadingMsg.Text = "File uploaded Successfully";
                    lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsg.Visible = true;
                    //var a = lblCheckListID.Text.Trim();
                    //objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(txtServiceID.Text);
                    //objServiceTimelinesBEL.ServiceChecklistId = lblCheckListID.Text;
                    //objServiceTimelinesBEL.CreatedBy = "System";
                    //objServiceTimelinesBEL.CreatedDate = System.DateTime.Now;
                    //objServiceTimelinesBEL.ModifiedBy = "System";
                    //objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;

                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "File format not recognised." +
                      " Upload Image/Word/PDF/Excel formats";

                }
            }
        }
        private string DecryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
        }




        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.ServiceTimeLinesDepartMent = drplanduse.SelectedItem.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLinesActivity = txtActivity.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLines = txtTimelines.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLinesApprovingLevel = txtApprover.Text.Trim();
            objServiceTimelinesBEL.filename = Convert.ToString(Session["FileName"]);
            objServiceTimelinesBEL.Uploadfile = Session["File"] as byte[];
            objServiceTimelinesBEL.content = Convert.ToString(Session["FileExt"]);
            objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);
            objServiceTimelinesBEL.CreatedDate = System.DateTime.Now;
            objServiceTimelinesBEL.ModifiedBy = Convert.ToString(Session["UserName"]);
            objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;
            var a = lblServiceID.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(txtServiceID.Text.Trim());
            objServiceTimelinesBEL.ServiceTimeLinesCondition = txtNorms.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLinesDocuments = txtChecklist.Text.Trim();
            try
            {
                if (btnSubmit.Text == "Save")
                {
                    int retVal = objServiceTimelinesBLL.SaveServiceChecklist(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        MessageBox1.ShowSuccess("Record Inserted successfully");
                        ClearAll();
                        BindServiceCheckListGridView();
                        BindCategory();
                    }
                    else
                    {
                        MessageBox1.ShowError("Some Error Occured");
                        return;
                    }
                }

                if (btnSubmit.Text == "Update")
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Convert.ToInt32(lblCheckListID.Text.Trim());
                    int retVal = objServiceTimelinesBLL.UpdateServiceChecklistDetails(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        MessageBox1.ShowSuccess("Record Inserted successfully");
                        BindServiceCheckListGridView();
                        ClearAll();
                        BindCategory();
                    }
                    else
                    {

                        MessageBox1.ShowError("Some Error Occured");
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

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindServiceCheckListGridView();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView2.PageSize;

                int Service_Id = Convert.ToInt32(GridView2.Rows[index].Cells[1].Text);
                int Service_TimeLine_ID = Convert.ToInt32(GridView2.Rows[index].Cells[2].Text);
                //Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds = objServiceTimelinesBLL.GetCheckListDocumentList(objServiceTimelinesBEL);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
            if (e.CommandName == "EditRow")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView2.PageSize;
                var a = GridView2.Rows[index].Cells[1].Text;
                var b = GridView2.Rows[index].Cells[3].Text;
                // drplanduse.SelectedIndex = drplanduse.Items.IndexOf(drplanduse.Items.FindByText(b));
                txtNorms.Text = GridView2.Rows[index].Cells[4].Text;
                txtChecklist.Text = GridView2.Rows[index].Cells[5].Text;

                //lblServiceID.Text = a;
                lblCheckListID.Text = a;

                //pnlCheckList.Enabled = true;
                //lnkChecklist.Visible = true;
                btnSubmit.Text = "Update";
            }
            if (e.CommandName == "DeleteRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int Service_Id = Convert.ToInt32(GridView2.Rows[index].Cells[0].Text);
                objServiceTimelinesBEL.ServiceTimeLinesID = Service_Id;
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                }

                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteServiceRecord(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        lblStatus.Text = "ServiceTimelines deleted successfully";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        ClearAll();
                        //BindServiceTimelinesGridView();
                        BindCategory();
                    }
                    else
                    {
                        lblStatus.Text = "ServiceTimelines couldn't be deleted";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
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

        }
        private void download(DataTable dt)
        {
            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["contentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[0]["ColName"].ToString() + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    string AllottementLetterNo = _objLoginInfo.userName;
                    objServiceTimelinesBEL.UserName = AllottementLetterNo;
                    int Service_Id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceCheckListsID"));
                    int Service_TimeLine_ID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceTimeLinesID"));
                    //int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    //int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds1 = objServiceTimelinesBLL.GetCheckListDocumentList(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                    }
                }
            }
            catch
            {

            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}