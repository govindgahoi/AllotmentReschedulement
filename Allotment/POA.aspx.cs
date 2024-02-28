using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;
using System.IO;
using System.Text;
using System.Drawing;

using System.Globalization;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net;


namespace Allotment
{
    public partial class POA : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        #endregion
        string UserName = string.Empty;
        int UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;

            if (!IsPostBack)
            {
                RegisterPostBackControl();
                //bindgrid();
                bindregion("");
                bindgrid("", "");
            }
        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(imgdocuments);
            scriptManager.RegisterPostBackControl(LinkButton1);
        }


        private void bindgrid(string IAId, string p)
        {
            SqlCommand cmd = new SqlCommand("spGetPOAdetails '" + IAId + "','" + p + "','" + UserName + "','" + txtSearch.Text.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            gridPOA.DataSource = dt;
            gridPOA.DataBind();




        }
        private void gridFunc()
        {

            if (ddlIA.SelectedIndex > 0)
            {
                SqlCommand cmd = new SqlCommand("spGetPOAdetails '" + ddlIA.SelectedValue.Trim() + "','S','" + UserName + "','" + txtSearch.Text.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                gridPOA.DataSource = dt;
                gridPOA.DataBind();
            }
            else
            {
                bindgrid("", "");
            }

        }

        //public void bindgrid()

        //{
        //    belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        //DataSet ds = new DataSet();
        //    try
        //    {
        //ds = objServiceTimelinesBLL.GetgridPOA();
        //        if (ds != null)
        //        {
        //            gridPOA.DataSource = ds;
        //            gridPOA.DataBind();
        //        }
        //        else
        //        {
        //            gridPOA.DataSource = null;
        //            gridPOA.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        objServiceTimelinesBEL = null;
        //        objServiceTimelinesBLL = null;
        //    }
        //}
        protected void Home_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DashboardI.aspx");
        }
        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            try
            {
                ddlregion.SelectedValue = "0";
                ddlIA.SelectedValue = "0";
                txtPOAName.Text = string.Empty;
                txtPOAemailID.Text = string.Empty;
                txtPOAmobile.Text = string.Empty;
                lbluploadingMsg.Text = string.Empty;
                lbluploadingMsgs.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtPOAemailID.Text.Length<=0)
                {
                    MessageBox1.ShowWarning("Email ID is required");
                    return;
                }
                if (txtPOAmobile.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Mobile No is required");
                    return;
                }

                if (btnSubmit.Text == "Submit")
                {
                    //objServiceTimelinesBEL.POARegion = Convert.ToInt32(ddlregion.SelectedValue.Trim());
                    objServiceTimelinesBEL.POAIAID = Int32.Parse(ddlIA.SelectedValue.Trim());
                    objServiceTimelinesBEL.POAName = txtPOAName.Text.Trim();
                    objServiceTimelinesBEL.POAEmailID = txtPOAemailID.Text.Trim();
                    objServiceTimelinesBEL.POAMobileNo = txtPOAmobile.Text.Trim();
                    objServiceTimelinesBEL.POARegion = ddlregion.SelectedItem.Text.Trim();

                 

                    objServiceTimelinesBEL.POAPhoto = (Session["File"]) as byte[];
                    objServiceTimelinesBEL.POAPhotoContent = Convert.ToString(Session["FileExt"]);
                    objServiceTimelinesBEL.POAPhotoName = Convert.ToString(Session["FileName"]);
                    objServiceTimelinesBEL.POASign = (Session["POAFile"]) as byte[];
                    objServiceTimelinesBEL.POASignContent = Convert.ToString(Session["POAFileName"]);
                    objServiceTimelinesBEL.POASignName = Convert.ToString(Session["POAFileExt"]);

                    DataSet result = objServiceTimelinesBLL.InsertPOADetails(objServiceTimelinesBEL);

                    if (result.Tables.Count > 0)
                    {
                        MessageBox1.ShowSuccess(result.Tables[0].Rows[0][0].ToString());
                        clear();
                        gridFunc();
                        //bindgrid();
                    }
                }



                else
                {
                    int ID = Convert.ToInt32(ViewState["id"].ToString());
                    objServiceTimelinesBEL.PID = Convert.ToInt32(ID);
                    objServiceTimelinesBEL.POARegion = ddlregion.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.POAIAID = Int32.Parse(ddlIA.SelectedValue.Trim());
                    objServiceTimelinesBEL.POAName = txtPOAName.Text.Trim();
                    objServiceTimelinesBEL.POAEmailID = txtPOAemailID.Text.Trim();
                    objServiceTimelinesBEL.POAMobileNo = txtPOAmobile.Text.Trim();                    
                    objServiceTimelinesBEL.POAPhoto = (Session["File"]) as byte[];
                    objServiceTimelinesBEL.POAPhotoContent = Convert.ToString(Session["FileExt"]);
                    objServiceTimelinesBEL.POAPhotoName = Convert.ToString(Session["FileName"]);
                    objServiceTimelinesBEL.POASign = (Session["POAFile"]) as byte[];
                    objServiceTimelinesBEL.POASignContent = Convert.ToString(Session["POAFileName"]);
                    objServiceTimelinesBEL.POASignName = Convert.ToString(Session["POAFileExt"]);


                    DataSet result = objServiceTimelinesBLL.UpdatePOADetails(objServiceTimelinesBEL);

                    if (result.Tables.Count > 0)
                    {
                        MessageBox1.ShowSuccess(result.Tables[0].Rows[0][0].ToString());
                        clear();
                        gridFunc();
                        // bindgrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        protected void gridPOA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["POAPhoto"]);
                (e.Row.FindControl("POAPhoto") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;
                string imageUrl2 = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["POASign"]);
                (e.Row.FindControl("POASign") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl2;
            }
        }
        private void bindregion(string reg)
        {


            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[spGetRegionalDetail] '" + UserName + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlregion.DataSource = dt;
                ddlregion.DataTextField = "a";
                ddlregion.DataValueField = "b";
                ddlregion.DataBind();
                ddlregion.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void ddlregion_SelectedIndexChanged(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.RegionalOffice = (ddlregion.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords1(objServiceTimelinesBEL);
                ddlIA.DataSource = ds;
                ddlIA.DataTextField = "IAName";
                ddlIA.DataValueField = "Id";
                ddlIA.DataBind();
                ddlIA.Items.Insert(0, new ListItem("--Select--", "0"));


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

        protected void imgdocuments_Click(object sender, EventArgs e)
        {

            if (POAPhotoUpload.HasFile)
            {
                // Read the file and convert it to Byte Array
                string filePath = POAPhotoUpload.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;

                //Set the contenttype based on File Extension
                switch (ext)
                {
                   
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                                     
                }
                if (contenttype != String.Empty)
                {

                    Stream fs = POAPhotoUpload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                   

                    objServiceTimelinesBEL.POAPhoto = bytes;
                    objServiceTimelinesBEL.POAPhotoContent = contenttype;
                    objServiceTimelinesBEL.POAPhotoName = filename;
                    Session["File"] = objServiceTimelinesBEL.POAPhoto;
                    Session["FileName"] = objServiceTimelinesBEL.POAPhotoName;
                    Session["FileExt"] = objServiceTimelinesBEL.POAPhotoContent;
                    lbluploadingMsg.Text = "File uploaded Successfully";
                    lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsg.Visible = true;


                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "File format not recognised." +
                      " Upload Image JPG formats";

                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (POASignupload.HasFile)
            {

                // Read the file and convert it to Byte Array
                string filePath = POASignupload.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;

                //Set the contenttype based on File Extension
                switch (ext)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                }
                if (contenttype != String.Empty)
                {

                    Stream fs = POASignupload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                    objServiceTimelinesBEL.POASign = bytes;
                    objServiceTimelinesBEL.POASignContent = contenttype;
                    objServiceTimelinesBEL.POASignName = filename;                   
                    Session["POAFile"] = objServiceTimelinesBEL.POASign;
                    Session["POAFileName"] = objServiceTimelinesBEL.POASignName;                   
                    Session["POAFileExt"] = objServiceTimelinesBEL.POASignContent;
                    lbluploadingMsgs.Text = "File uploaded Successfully";
                    lbluploadingMsgs.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsgs.Visible = true;


                }
                else
                {
                    lblStatus1.ForeColor = System.Drawing.Color.Red;
                    lblStatus1.Text = "File format not recognised." +
                      " Upload Image JPG formats";

                }
            }
        }

        private void Delete_POAdetals(string id)
        {
            try
            {
                int result = objServiceTimelinesBLL.Delete_POAdetals(id);
                if (result > 0)
                {
                    MessageBox1.ShowSuccess("POA Delete successfully");
                    Response.Redirect("/POA.aspx");
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void get_POAdetals(string id)
        {
            DataSet ds = new DataSet();
            ds = objServiceTimelinesBLL.GetEditDetails(id);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlregion.SelectedItem.Text= ds.Tables[0].Rows[0]["POARegion"].ToString();
                   // ddlregion_SelectedIndexChanged(null, null);
                    ddlIA.SelectedValue = ds.Tables[0].Rows[0]["Id"].ToString();
                    // ddlIA.SelectedItem.Text = ds.Tables[0].Rows[0]["IAName"].ToString();                   
                    txtPOAName.Text = ds.Tables[0].Rows[0]["POAName"].ToString();
                    txtPOAemailID.Text = ds.Tables[0].Rows[0]["POAEmailID"].ToString();                    
                    txtPOAmobile.Text = ds.Tables[0].Rows[0]["POAMobileNo"].ToString();
                    lbluploadingMsg.Text = string.Empty;
                    lbluploadingMsgs.Text = string.Empty;
                    btnSubmit.Text = "Update";
                    //bindgrid();
                    gridFunc();
                }
                else
                {
                    clear();
                    btnSubmit.Text = "Submit";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }

        }
        protected void gridPOA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Process")
                {

                    string rowid = e.CommandArgument.ToString();
                    ViewState["id"] = rowid;
                    get_POAdetals(rowid); 
                    btnSubmit.Text = "Update";

                }
                if (e.CommandName == "Delete")
                {
                    string rowid = e.CommandArgument.ToString();
                    Delete_POAdetals(rowid);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void gridPOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPOA.PageIndex = e.NewPageIndex;
            gridFunc();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetgridPOAforSearch(txtSearch.Text);
                if (ds != null)
                {
                    gridPOA.DataSource = ds;
                    gridPOA.DataBind();
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
}