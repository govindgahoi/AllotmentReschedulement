using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;

namespace Allotment
{
    public partial class DemandNoteGeneration : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string Username;
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                Username = _objLoginInfo.userName;
            }
            catch
            {
            }


            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();

            }




        }


        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                drpIndusrialArea.DataSource = ds;
                drpIndusrialArea.DataTextField = "IAName";
                drpIndusrialArea.DataValueField = "Id";
                drpIndusrialArea.DataBind();
                drpIndusrialArea.Items.Insert(0, new ListItem("--Select--", "0"));
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




        protected void txtServiceReqNo_TextChanged(object sender, EventArgs e)
        {

        }


        protected void radioByPlotNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = true;
            DivFilterLetter.Visible = false;

        }

        protected void radioByAllotmentNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = false;
            DivFilterLetter.Visible = true;
        }

        protected void drpIndusrialArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.IAID = (drpIndusrialArea.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForIAServices(objServiceTimelinesBEL);
                drpPlotNo.DataSource = ds;
                drpPlotNo.DataTextField = "PlotNumber";
                drpPlotNo.DataValueField = "PlotNumber";
                drpPlotNo.DataBind();
                drpPlotNo.Items.Insert(0, new ListItem("--Select--", ""));



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void drpPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetApplicantDetails();

        }


        private void GetApplicantDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            string Paid = "";
            try
            {
                if (radioByAllotmentNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = txtServiceReqNo.Text;
                    objServiceTimelinesBEL.IAName = "";
                    objServiceTimelinesBEL.PlotNo = "";

                }

                if (radioByPlotNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = "";
                    objServiceTimelinesBEL.IAName = drpIndusrialArea.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = drpPlotNo.SelectedItem.Text.Trim();
                }

                ds = objServiceTimelinesBLL.GetAllotteeRecordToBindForLeaseDeed(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    AllotteeDiv.Visible = true;
                    lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    btnGenerate.Visible = false;

                }
                else
                {
                    AllotteeDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        protected void btnRaise_Click(object sender, EventArgs e)
        {

            byte[] PdfInBytes = HtmlToByte();
            String base64EncodedPdf = System.Convert.ToBase64String(PdfInBytes);

            string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""100%""  height=""550px"">
            		  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
            		  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
            		  </object>";
            //string embed = "";

            Literal ltEmbed = new Literal();
            ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
            Placeholder.Controls.Add(ltEmbed);
        }
        protected byte[] HtmlToByte()
        {
            string htmlContent = "";
            byte[] pdfBytes = null;
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(lblAllotteeID.Text.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GEtdemandNoteOFAllottee(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

                if (dt2.Rows.Count > 0)
                {
                    PreviousServiceDiv.Visible = true;
                    btnGenerate.Visible = false;

                    pdfBytes = (Byte[])dt2.Rows[0]["DemandDoc"];

                }
                else
                {



                    if (dt.Rows.Count > 0)
                    {
                        PreviousServiceDiv.Visible = true;
                        btnGenerate.Visible = true;
                        //btnGenerate.Visible = false;
                        string DueDate = dt1.Rows[0]["DueDate"].ToString();
                        string RMName  = dt1.Rows[0]["RMName"].ToString();
                        StreamReader reader = new StreamReader(Server.MapPath("/html/DemandNote.html"));
                        htmlContent = reader.ReadToEnd();
                        reader.Close();

                        htmlContent = htmlContent.Replace("{{AllotteeName}}", lblAllotteeName.Text);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", lblPlotNo.Text);
                        htmlContent = htmlContent.Replace("{{Address}}", lblAddress.Text);
                        htmlContent = htmlContent.Replace("{{AllotteeID}}", lblAllotmentLetterNo.Text);
                        htmlContent = htmlContent.Replace("{{IAName}}", lblIndustrialArea.Text);
                        htmlContent = htmlContent.Replace("{{Date}}", System.DateTime.Now.ToString("dd-MMM-yyyy"));
                        htmlContent = htmlContent.Replace("{{RefNo}}", "DEM/" + System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + lblAllotteeID.Text.Trim());
                        htmlContent = htmlContent.Replace("{{dueDate}}", DueDate);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);


                        string html = @"<style>.request-table tr{
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
                                <tr><th> Dues </th><th> Amount </th></tr>";
                        int i = 0;

                        foreach (DataRow dr in dt.Rows)
                        {
                            i++;
                            if (Convert.ToDecimal(dr["Amount"].ToString()) != 0)
                            {

                                html += "<tr><td> " + dr["PaymentHead"].ToString() + " </td><td> " + dr["Amount"].ToString() + " </ td></tr> ";
                            }
                        }
                        decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                        html += "<tr><td>Total</td><td>" + total.ToString() + "</td></tr></table>";

                        htmlContent = htmlContent.Replace("{{table}}", html);



                        string code = "ApplicationNo:" + lblAllotmentLetterNo.Text + "|ApplicantName:" + lblAllotteeName + "|IAName:" + lblIndustrialArea + "|DocType:DemandNote";

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

                       
                    }
                    else
                    {
                        PreviousServiceDiv.Visible = false;
                        btnGenerate.Visible = false;

                    }

                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
                    
                }
              
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

            return pdfBytes;
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            byte[] PdfInBytes = HtmlToByte();

            SqlCommand command;
            SqlTransaction transaction;
           
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {
                    SqlCommand cmd = new SqlCommand("GenerateDemandNote_sp", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DemandID", "DEM/" + System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + lblAllotteeID.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreatedBy", Username);
                    cmd.Parameters.AddWithValue("@AllotteeID", lblAllotteeID.Text);
                    cmd.Parameters.AddWithValue("@DemandDocName", "DemandNote_"+lblAllotteeID.Text+"_"+ System.DateTime.Now.Year.ToString()+'_'+ System.DateTime.Now.Month.ToString());
                    cmd.Parameters.AddWithValue("@DemandDocType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DemandDoc", PdfInBytes);                

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {              
                        transaction.Commit();                      
                        string message = "Demand Generated Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        btnGenerate.Visible = false;
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
    }
}