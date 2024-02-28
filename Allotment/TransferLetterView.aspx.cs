using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class TransferLetterView : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string id = Request.QueryString["AllotteeId"];


            if (string.IsNullOrEmpty(id))
            {

                DocumentViewer(txt1.Text);

            }
            else
            {
                txt1.Text = id;
                DocumentViewer(txt1.Text);

            }

        }
        protected void DocumentViewer(string ServiceRequestNo)
        {
            Placeholder.Controls.Clear();

            SqlCommand cmd = new SqlCommand(@"select Id , ContentType , Document from 
                                              [dbo].[Repository] where ServiceRequestNo = '" + ServiceRequestNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    byte[] Document = (byte[])dt.Rows[0]["Document"];
                    String base64EncodedPdf = System.Convert.ToBase64String(Document);
                    string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
                    Placeholder.Controls.Add(ltEmbed);

                }
            }
        }








        //public void view(string id)
        //{

        //    SqlCommand cmd = new SqlCommand("sp_getDetailsForTransferLetter '" + id+"'", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    adp.Fill(ds);
        //    DataTable dt1 = ds.Tables[0];             
        //    if(dt1.Rows.Count>0)
        //    {
        //        lblTransfereename.Text    = dt1.Rows[0]["TransfreeName"].ToString();
        //        lblTransfereeAddress.Text = dt1.Rows[0]["SignatoryAddress"].ToString();
        //        lblRefno.Text             = dt1.Rows[0]["ref_AllotmentNo"].ToString();
        //        lblIAName.Text            = dt1.Rows[0]["IndustrialArea"].ToString(); 
        //        lblPlotNo.Text            = dt1.Rows[0]["PlotNo"].ToString();
        //        lblDate.Text              = dt1.Rows[0]["IssueDate"].ToString();
        //        lbldate1.Text             = dt1.Rows[0]["ApplicationDate"].ToString();
        //        lblIndustrialPlotNo.Text  = dt1.Rows[0]["PlotNo"].ToString();
        //        lblPlotlength.Text        = dt1.Rows[0]["TotalAllottedplotArea"].ToString();
        //        lblIAName1.Text           = dt1.Rows[0]["IndustrialArea"].ToString();
        //        lblTransfereename1.Text   = dt1.Rows[0]["TransfreeName"].ToString();
        //        lblallotmentletterno.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
        //        lblallotmentdated1.Text   = dt1.Rows[0]["IssueDate"].ToString();

        //    }



        //    cmd.Dispose();




        //}

        protected void btn_Click(object sender, EventArgs e)
        {
            DocumentViewer(txt1.Text);
        }
    }




}
