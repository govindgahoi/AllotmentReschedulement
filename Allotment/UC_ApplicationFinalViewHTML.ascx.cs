using System;
using System.Data;
using System.IO;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ApplicationFinalViewHTML : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        public string ServiceRequestNo { get; set; }
        public string Parameter { get; set; }
        #endregion
        public void Page_Load(object sender, EventArgs e)
        {

            GetApplicantDetails(ServiceRequestNo);

        }


        private void GetApplicantDetails(String ID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ID;
                ds = objServiceTimelinesBLL.GetNewApplicantDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID = dt.Rows[0]["ApplicantId"].ToString();
                    lblApplicantId.Text = dt.Rows[0]["FormNo"].ToString();
                    lblDate.Text = dt.Rows[0]["ApplicationDate"].ToString();
                    lblDistrict.Text = dt.Rows[0]["District"].ToString();
                    lblIA.Text = dt.Rows[0]["IndustrialAreaName"].ToString();
                    lblPlotRange.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblPlotArea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblName.Text = dt.Rows[0]["ApplicantName"].ToString();
                    lblTelephone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblPlotpreference1.Text = dt.Rows[0]["PlotPreference1"].ToString();
                    lblPlotpreference2.Text = dt.Rows[0]["PlotPreference2"].ToString();
                    lblPlotpreference3.Text = dt.Rows[0]["PlotPreference3"].ToString();

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {
                        GridView6.Visible = true;
                        Headerlbl.Text = "Individual/Sole Proprietorship firm Details";
                        GridView6.DataSource = dt1; GridView6.DataBind();
                    }
                    else
                    {
                        GridView6.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                    {
                        GridView7.Visible = true;
                        Headerlbl.Text = "Directors Details";
                        GridView7.DataSource = dt1; GridView7.DataBind();
                    }
                    else
                    {
                        GridView7.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                    {
                        GridView8.Visible = true;
                        Headerlbl.Text = "ShareHolders Details";
                        GridView8.DataSource = dt1; GridView8.DataBind();
                    }
                    else
                    {
                        GridView8.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                    {
                        GridView9.Visible = true;
                        Headerlbl.Text = "Partners Details";
                        GridView9.DataSource = dt; GridView9.DataBind();
                    }
                    else
                    {
                        GridView9.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                    {
                        GridView10.Visible = true;
                        Headerlbl.Text = "Trustee Details";
                        GridView10.DataSource = dt; GridView10.DataBind();
                    }
                    else
                    {
                        GridView10.Visible = false;
                    }

                    string Imagetype = dt.Rows[0]["ApplicantImageType"].ToString().Trim();
                    string ImageName = dt.Rows[0]["ApplicantImageName"].ToString().Trim();
                    string img = dt.Rows[0]["ApplicantImage"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImageSrc.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);
                        BinaryWriter Writer = null;
                        string Name = @"C:\Users\Priyanshu.Dixit\Desktop\UPSIDC\UPSIDC\UPSIDC\Allotment\Allotment\TempPdf\" + ImageName;
                        Writer = new BinaryWriter(File.OpenWrite(Name));
                        // Writer raw data                
                        Writer.Write(bytes);
                        Writer.Flush();
                        Writer.Close();

                    }

                }
                if (dt_project.Rows.Count > 0)
                {
                    lblIndustrytype.Text = dt_project.Rows[0]["IndustryType"].ToString();
                    lblExpansion.Text = dt_project.Rows[0]["ExpansionOfLand"].ToString();
                    lblexportoriented.Text = dt_project.Rows[0]["ExportOriented"].ToString();
                    lblRelevantExperience.Text = dt_project.Rows[0]["WorkExperience"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
    }
}