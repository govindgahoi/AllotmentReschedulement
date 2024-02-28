using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;

namespace Allotment
{
    public partial class DemandNoteTesting1 : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        public string ServiceReqNo;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch
            {
            }

            ServiceReqNo = Request.QueryString["ViewID"];
            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();

            }

            if (ServiceReqNo != null)
            {
                if (ServiceReqNo.Length > 0)
                {
                    divSearch.Visible = false;

                }

            }
            else
            {
                divSearch.Visible = true;
            }
        }

        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
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


            Literal ltEmbed = new Literal();
            ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
            Placeholder.Controls.Add(ltEmbed);
        }
        protected byte[] HtmlToByte()
        {
            string htmlContent = "";

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(lblAllotteeID.Text.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GEtdemandNoteOFAllottee(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];

                if (dt.Rows.Count > 0)
                {
                    PreviousServiceDiv.Visible = true;
                    string DueDate = dt1.Rows[0]["DueDate"].ToString();
                    string RMName = dt1.Rows[0]["RMName"].ToString();
                    StreamReader reader = new StreamReader(Server.MapPath("/html/DemandNote.html"));
                    htmlContent = reader.ReadToEnd();
                    reader.Close();

                    htmlContent = htmlContent.Replace("{{AllotteeName}}", lblAllotteeName.Text);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", lblPlotNo.Text);
                    htmlContent = htmlContent.Replace("{{Address}}", lblAddress.Text);
                    htmlContent = htmlContent.Replace("{{AllotteeID}}", lblAllotmentLetterNo.Text);
                    htmlContent = htmlContent.Replace("{{IAName}}", lblIndustrialArea.Text);
                    htmlContent = htmlContent.Replace("{{Date}}", System.DateTime.Now.ToString("dd-MMM-yyyy"));
                    htmlContent = htmlContent.Replace("{{RefNo}}", "DEM/" + System.DateTime.Now.Year.ToString() + "/" + lblAllotteeID.Text.Trim());
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
                        if (Convert.ToDecimal(dr["Amount"].ToString()) > 0)
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

                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            byte[] pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            return pdfBytes;
        }

    }
}