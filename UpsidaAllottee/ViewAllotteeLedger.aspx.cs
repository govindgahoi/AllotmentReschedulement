using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Text;

namespace UpsidaAllottee
{
    public partial class ViewAllotteeLedger : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
       
        string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                bindRegionalOffice();
                DlIA.Enabled = false;
                txtaltNo.Enabled = false;
                lblMsg.Visible = false;
                btnDemand.Visible = false;
                btnLedger.Visible = false;
                gridAllotDetail.Visible = false;
                btnDemand.Visible = false;
                btnLedger.Visible = false;
                lblLedger.Visible = false;
                Label1.Visible = false;
                lblDemandNote.Visible = false;
                lbldebit.Visible = false;
                lblcredit.Visible = false;
                totransection.Visible = false;
                GridViewledger.Visible = false;
                //Label2.Visible = false;
                //bindPaymentHead();
            }
        }
        private void bindRegionalOffice()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            ListItem liRegional = new ListItem("--Select--", "-1");
            dlRO.Items.Insert(0, liRegional);
        }
        private void bindIndustrialArea()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Indust_Area", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@regionalOffice", dlRO.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DlIA.DataSource = dt;
            DlIA.DataTextField = "IAName";
            DlIA.DataValueField = "IAName";
            DlIA.DataBind();
            ListItem liIArea = new ListItem("--Select--", "-1");
            DlIA.Items.Insert(0, liIArea);
        }
        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dlRO.SelectedIndex == 0)
            {
                DlIA.SelectedIndex = 0;
                DlIA.Enabled = false;
                txtaltNo.Text = null;
                txtaltNo.Enabled = false;
                lblMsg.Visible = false;
                gridAllotDetail.Visible = false;
                btnDemand.Visible = false;
                btnLedger.Visible = false;
                lblLedger.Visible = false;
                lblDemandNote.Visible = false;
                lbldebit.Visible = false;
                lblcredit.Visible = false;
                totransection.Visible = false;
                GridViewledger.Visible = false;
                //Label2.Visible = false;
            }
            else
            {
                DlIA.Enabled = true;
                bindIndustrialArea();
                lblMsg.Visible = false;
                lblDemandNote.Visible = false;
                lbldebit.Visible = false;
                lblcredit.Visible = false;
                totransection.Visible = false;
                GridViewledger.Visible = false;
                btnDemand.Visible = false;
                //Label2.Visible = false;
            }


        }

        protected void DlIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DlIA.SelectedIndex == 0)
            {
                txtaltNo.Text = null;
                txtaltNo.Enabled = false;
                lblMsg.Visible = false;
                gridAllotDetail.Visible = false;
                btnDemand.Visible = false;
                btnLedger.Visible = false;
                lblLedger.Visible = false;
                lbldebit.Visible = false;
                lblcredit.Visible = false;
                totransection.Visible = false;
                GridViewledger.Visible = false;

            }
            else
            {
                GridViewledger.Visible = false;
                txtaltNo.Enabled = true;
                lblMsg.Visible = false;
                lblDemandNote.Visible = false;
                lbldebit.Visible = false;
                lblcredit.Visible = false;
                totransection.Visible = false;
                btnDemand.Visible = false;
                //Label2.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (dlRO.SelectedIndex != 0 && DlIA.SelectedIndex != 0 && txtaltNo.Text != null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_Allotment_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Allotmentletterno", txtaltNo.Text);
                cmd.Parameters.AddWithValue("@IndustrialArea", DlIA.SelectedValue);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Label2.Visible = false;
                    GridViewledger.Visible = false;
                    gridAllotDetail.Visible = true;
                    gridAllotDetail.DataSource = dt;
                    gridAllotDetail.DataBind();
                    lblMsg.Visible = false;
                    btnDemand.Visible = true;
                    btnLedger.Visible = true;
                    lblLedger.Visible = false;
                    Label1.Visible = false;
                    lblDemandNote.Visible = false;
                    lbldebit.Visible = false;
                    lblcredit.Visible = false;
                    totransection.Visible = false;
                }
                else
                {
                    Label1.Visible = false;
                    GridViewledger.Visible = false;
                    //Label2.Visible = false;
                    btnDemand.Visible = false;
                    btnLedger.Visible = false;
                    gridAllotDetail.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Allotment letter no. is not valid. Try again.";
                    lblLedger.Visible = false;
                    btnLedger.Visible = false;
                    lblLedger.Visible = false;
                    lblDemandNote.Visible = false;
                    lbldebit.Visible = false;
                    lblcredit.Visible = false;
                    totransection.Visible = false;
                }

            }
        }

        //protected void TextBox1_TextChanged(object sender, System.EventArgs e)
        //{

        //    //gridAllotDetail.Visible = false;
        //    //lblMsg.Visible = false;
        //   // btnDemand.Visible = false;
        //    //btnLedger.Visible = false;
        //    lblLedger.Visible = false;
        //    GridViewledger.Visible = false;
        //    totransection.Visible = false;
        //    lbldebit.Visible = false;
        //    lblcredit.Visible = false;
        //    Label1.Visible = false;
        //    lblDemandNote.Visible = false;
        //    Placeholder.Visible = false;
        //}

        protected void btnLedger_Click(object sender, EventArgs e)
        {
            if (dlRO.SelectedIndex != 0 && DlIA.SelectedIndex != 0 && txtaltNo.Text != null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_allottee_journal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Allotmentletterno", txtaltNo.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string txtltr = txtaltNo.Text;
                if (dt.Rows.Count > 0)
                {
                    DataTable tbl = totalTransection(txtltr);

                    lbldebit.Visible = true;
                    lblcredit.Visible = true;
                    lbldebit.Text = tbl.Rows[0]["Total_Debit"].ToString();
                    lblcredit.Text = tbl.Rows[0]["Total_Credit"].ToString();

                    GridViewledger.Visible = true;
                    lblDemandNote.Visible = false;
                    //Label2.Visible = true;
                    gridAllotDetail.Visible = true;
                    GridViewledger.DataSource = dt;
                    GridViewledger.DataBind();
                    lblMsg.Visible = false;
                    //btnDemandNote.Visible = true;
                    btnLedger.Visible = true;
                    lblLedger.Visible = true;
                    Placeholder.Visible = false;
                    Label1.Visible = false;
                    totransection.Visible = true;
                }
                else
                {
                    lbldebit.Visible = false;
                    lblcredit.Visible = false;
                    lbldebit.Text = "";
                    lblcredit.Text = "";
                    GridViewledger.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = "Invalid Details.";
                    //btnLedger.Visible = false;
                    lblLedger.Visible = false;
                    lblDemandNote.Visible = false;
                    totransection.Visible = false;
                }

            }
        }

        public DataTable totalTransection(string textallotteeltr)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_sum_credit_debit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Allotmentletterno", textallotteeltr);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        protected void btnRaise_Click(object sender, EventArgs e)
        {

            byte[] PdfInBytes = HtmlToByte();
            if (PdfInBytes != null)
            {
                String base64EncodedPdf = System.Convert.ToBase64String(PdfInBytes);

                string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""100%""  height=""550px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										  </object>";


                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
                Placeholder.Controls.Add(ltEmbed);
                Label1.Visible = false;
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid Details.";
                lblDemandNote.Visible = false;
                //lblMsg.Visible = true;
                //lblMsg.Text = "Invalid Details.";
            }
        }
        protected byte[] HtmlToByte()
        {
            string htmlContent = "";
            byte[] pdfBytes = null;

            DataSet ds = new DataSet();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_demandNote", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Allotmentletterno", txtaltNo.Text); //usp_demo_demand usp_demandNote

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //cmd.Dispose();
                //DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {
                    GridViewledger.Visible = false;
                    lblLedger.Visible = false;
                    Placeholder.Visible = true;
                    lblDemandNote.Visible = true;
                    pdfBytes = (Byte[])dt.Rows[0]["DemandDoc"];
                    PreviousServiceDiv.Visible = true;
                    lbldebit.Visible = false;
                    lblcredit.Visible = false;
                    totransection.Visible = false;
                    //GridViewledger

                }
                else
                {
                    lblDemandNote.Visible = false;
                    GridViewledger.Visible = false;
                    lblLedger.Visible = false;
                    //var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    //pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
                    PreviousServiceDiv.Visible = true;
                    Label1.Visible = true;
                    Label1.Text = "Invalid Details.";
                    lbldebit.Visible = false;
                    lblcredit.Visible = false;
                    totransection.Visible = false;

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

            return pdfBytes;
        }

    }

}