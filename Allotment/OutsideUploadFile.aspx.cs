using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class OutsideUploadFile : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        }

        #region UploadDocument Process

        protected void btnAllotmentLetter_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            string formattedDate = "";
            try
            {
                try
                {
                    string Datec = txtalltLetterIssueDate.Text.Trim();
                    dateTime = Convert.ToDateTime(Datec).Date;
                    formattedDate = dateTime.ToString("dd MMM yyyy");
                }
                catch
                {

                }

                if (FileUploadAllotmentLetter.HasFile)
                {
                    HttpPostedFile file = FileUploadAllotmentLetter.PostedFile;
                    objServiceTimelinesBEL.UploadAllotmentLetter = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.UploadAllotmentLetter, 0, file.ContentLength);
                    objServiceTimelinesBEL.AllotmentLetterFile = Path.GetFileName(FileUploadAllotmentLetter.PostedFile.FileName);
                    objServiceTimelinesBEL.AllotmentLetterExt = FileUploadAllotmentLetter.PostedFile.ContentType;
                    objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text;
                    objServiceTimelinesBEL.AllotmentIssueDate = dateTime;
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    int retVal = objServiceTimelinesBLL.UpdateAllotmentLetterDocument(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "File uploaded Successfully.";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    }
                    else
                    {
                        string message = "File Not  uploaded ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                        //lblStatus.Text = "Allottee details couldn't be saved";
                        //lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFuLeaseDeed_Click(object sender, EventArgs e)
        {
            try
            {
                string DateleaseDate = txtLeaseDeed.Text.Trim();
                string DateleaseExecDate = txtExecLeaseDeed.Text.Trim();

                DateTime dateTimeLease = new DateTime();
                DateTime dateTimeExeLease = new DateTime();
                dateTimeLease = Convert.ToDateTime(DateleaseDate).Date;
                dateTimeExeLease = Convert.ToDateTime(DateleaseExecDate).Date;

                //string formattedDate = dateTime.ToString("dd MMM yyyy");

                if (FuLeaseDeed.HasFile)
                {
                    HttpPostedFile file = FuLeaseDeed.PostedFile;
                    objServiceTimelinesBEL.UploadLeaseDeed = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.UploadLeaseDeed, 0, file.ContentLength);
                    objServiceTimelinesBEL.LeaseDeedFile = Path.GetFileName(FileUploadAllotmentLetter.PostedFile.FileName);
                    objServiceTimelinesBEL.LeaseDeedExt = FileUploadAllotmentLetter.PostedFile.ContentType;
                    objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text;
                    objServiceTimelinesBEL.LeaseDeedDate = dateTimeLease;
                    objServiceTimelinesBEL.LeaseAgrementExecDate = dateTimeExeLease;
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;

                    int retVal = objServiceTimelinesBLL.UpdateAllotmentLetterDocument(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        // Bind the Document Grid

                        string message = "File uploaded Successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                        //lblStatus.Text = "Allottee detail saved successfully";
                        //lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        string message = "File couldn't be  uploaded ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                        //lblStatus.Text = "Allottee details couldn't be saved";
                        //lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {

                    string message1 = "Allottee Id couldn't be  Supplied ";
                    string script1 = "window.onload = function(){ alert('";
                    script1 += message1;
                    script1 += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script1, true);
                }

                //lbluploadingMsg.Visible = true;
                //lbluploadingMsg.Text = "File uploaded Successfully.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnUploadInspection_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUploadInspection.HasFile)
                {
                    HttpPostedFile file = FileUploadInspection.PostedFile;
                    objServiceTimelinesBEL.InspectionLetter = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.InspectionLetter, 0, file.ContentLength);
                    objServiceTimelinesBEL.InsepectionfilenameExt = FileUploadInspection.PostedFile.ContentType;
                    objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text;
                    objServiceTimelinesBEL.InspectionDate = Convert.ToDateTime(txtInspectionDate.Text);

                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;

                    int retVal = objServiceTimelinesBLL.UpdateInspectionDocument(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {

                        string message = "File uploaded Successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }
                    else
                    {
                        string message = "File couldn't be  uploaded ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                        //lblStatus.Text = "Allottee details couldn't be saved";
                        //lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBuildingPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (FudBuildingPlan.HasFile)
                {
                    HttpPostedFile file = FudBuildingPlan.PostedFile;
                    objServiceTimelinesBEL.BuildingPlanDocument = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.BuildingPlanDocument, 0, file.ContentLength);
                    objServiceTimelinesBEL.BuildingPlanDocumentExt = FudBuildingPlan.PostedFile.ContentType;
                    objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text;
                    objServiceTimelinesBEL.BuldingPlanSubmissionDate = Convert.ToDateTime(txtBuildingDate.Text);
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;

                    int retVal = objServiceTimelinesBLL.UpdateBuildingPlanDocument(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "File uploaded Successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                    }
                    else
                    {
                        string message = "File couldn't be  uploaded ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                        //lblStatus.Text = "Allottee details couldn't be saved";
                        //lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCompletion_Click(object sender, EventArgs e)
        {
            try
            {
                if (FudCompletion.HasFile)
                {
                    HttpPostedFile file = FudCompletion.PostedFile;
                    objServiceTimelinesBEL.CompletionCertificate = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.CompletionCertificate, 0, file.ContentLength);
                    objServiceTimelinesBEL.CompletionCertificateExt = FudCompletion.PostedFile.ContentType;
                    objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text;
                    //objServiceTimelinesBEL.CompletionDate = Convert.ToDateTime(txtDateCompletion.Text);
                    objServiceTimelinesBEL.ReleaseofCompletionDate = Convert.ToDateTime(txtcomcertificate.Text);
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    int retVal = objServiceTimelinesBLL.UpdateBuildingPlanDocument(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "File uploaded Successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                    }
                    else
                    {
                        string message = "File couldn't be  uploaded ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                        //lblStatus.Text = "Allottee details couldn't be saved";
                        //lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnOccupancy_Click(object sender, EventArgs e)
        {
            try
            {
                if (FudOccupancy.HasFile)
                {
                    HttpPostedFile file = FudOccupancy.PostedFile;
                    objServiceTimelinesBEL.OccupancyCertificate = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.OccupancyCertificate, 0, file.ContentLength);
                    objServiceTimelinesBEL.OccupancyCertificateExt = FudOccupancy.PostedFile.ContentType;
                    objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text;
                    //objServiceTimelinesBEL.RequestofOccupancyCertificateDate = Convert.ToDateTime(txtoccertificate.Text);
                    objServiceTimelinesBEL.ReleaseofOccupancyCertificateDate = Convert.ToDateTime(txtReloccertificate.Text);
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;

                    int retVal = objServiceTimelinesBLL.UpdateBuildingPlanDocument(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "File uploaded Successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                    }
                    else
                    {
                        string message = "File couldn't be  uploaded ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }




}
