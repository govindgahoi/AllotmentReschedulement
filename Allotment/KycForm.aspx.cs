using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class KycForm : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string id = "";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            id = Request.QueryString["AllotteeId"];


            if (id == "")
            {

            }
            else
            {

                FillKycToPrint();
            }
        }
        public void view(string id)
        {

            //SqlCommand cmd = new SqlCommand("DetailsForAllotment '" + id + "'", con);
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);

            //DataTable dt1 = ds.Tables[0];

            //if (dt1.Rows.Count > 0)
            {



            }



            //cmd.Dispose();




        }

        protected void btn_Click(object sender, EventArgs e)
        {
            view(txt1.Text);
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {

                command = new SqlCommand("[InsertAllotteeKYCDetails_sp]", con, transaction);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AllotteeTempId", id);
                command.Parameters.AddWithValue("@AllotteeName", txtAllotteeName.Text);
                command.Parameters.AddWithValue("@PropertyNo", txtPlotNo.Text);
                command.Parameters.AddWithValue("@Father_SpouseName", txtFatherName.Text);
                command.Parameters.AddWithValue("@Sector", txtSector.Text);
                command.Parameters.AddWithValue("@AllotmentDate", txtAllotmentDate.Text);
                command.Parameters.AddWithValue("@AllotmentNo", txtAllotmentNo.Text);
                command.Parameters.AddWithValue("@PlotSize", txtPlotsize.Text);
                command.Parameters.AddWithValue("@AllotteeName1", txtAllotteeName1.Text);
                command.Parameters.AddWithValue("@AllotteeName2", txtAllotteeName2.Text);
                command.Parameters.AddWithValue("@CorrespondenceAddress", txtlblCorrAddress.Text);
                command.Parameters.AddWithValue("@PermanentAddress", txtPermanentAddress.Text);
                command.Parameters.AddWithValue("@Contact1", txtContact1.Text);
                command.Parameters.AddWithValue("@Contact2", txtContact2.Text);
                command.Parameters.AddWithValue("@DOB1", txtBirth1.Text);
                command.Parameters.AddWithValue("@DOB2", txtBirth2.Text);
                command.Parameters.AddWithValue("@EmailID1", txtEmail1.Text);
                command.Parameters.AddWithValue("@EmailID2", txtEmail2.Text);
                command.Parameters.AddWithValue("@PanCard1", txtPan1.Text);
                command.Parameters.AddWithValue("@PanCard2", txtPan2.Text);
                command.Parameters.AddWithValue("@AddharCardNo1", txtAdhaar1.Text);
                command.Parameters.AddWithValue("@AddharCardNo2", txtAdhaar2.Text);
                command.Parameters.AddWithValue("@VoterIDCardNo1", txtVote1.Text);
                command.Parameters.AddWithValue("@VoterIDCardNo2", txtVote2.Text);
                command.Parameters.AddWithValue("@DrivingLicense1", txtDL1.Text);
                command.Parameters.AddWithValue("@DrivingLicense2", txtDL2.Text);

                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));



                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Your KYC Submitted Successfully.Send the Hard Copy Of this form along with your signature to the mentioned address";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage('" + message + "');", true);
                    FillKycToPrint();
                }
                else
                {
                    transaction.Rollback();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myalert", "ShowPopup('Error');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }

        public void FillKycToPrint()
        {

            SqlCommand cmd = new SqlCommand("[GetAllotteeKYCDetails]'" + id + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DivP.Visible = false;
                DivP1.Visible = true;
                lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString().Trim();
                lblPropertyNo.Text = dt.Rows[0]["PropertyNo"].ToString().Trim();
                lblFatherName.Text = dt.Rows[0]["Father_SpouseName"].ToString().Trim();
                lblBlockState.Text = dt.Rows[0]["Block_Estate"].ToString().Trim();
                lblSector.Text = dt.Rows[0]["Sector"].ToString().Trim();
                lblAllotmentDate.Text = dt.Rows[0]["AllotmentDate"].ToString().Trim();
                lblAllotmentNo.Text = dt.Rows[0]["AllotmentNo"].ToString().Trim();
                lblPlotsize.Text = dt.Rows[0]["PlotSize"].ToString().Trim();
                lblAllotmentNo1name.Text = dt.Rows[0]["AllotteeName1"].ToString().Trim();
                lblAllotmentNo2name.Text = dt.Rows[0]["AllotteeName2"].ToString().Trim();
                lblEmailAllottee1.Text = dt.Rows[0]["EmailId1"].ToString().Trim();
                lblEmailAllottee2.Text = dt.Rows[0]["EmailId2"].ToString().Trim();
                lblCorrAddress.Text = dt.Rows[0]["CorrespondenceAddress"].ToString().Trim();
                lblPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString().Trim();
                lblAllottee1date.Text = dt.Rows[0]["DOB1"].ToString().Trim();
                lblAllottee2date.Text = dt.Rows[0]["DOB2"].ToString().Trim();
                lblPhoneAllotNo1.Text = dt.Rows[0]["Contact1"].ToString().Trim();
                lblPhoneAllotNo2.Text = dt.Rows[0]["Contact2"].ToString();
                lblPanNo1.Text = dt.Rows[0]["PanCard1"].ToString();
                lblPanNo2.Text = dt.Rows[0]["PanCard2"].ToString();
                lblAdhaarAllottee1.Text = dt.Rows[0]["AddharCardNo1"].ToString();
                lblAdhaarAllottee2.Text = dt.Rows[0]["AddharCardNo2"].ToString();
                lblVoterIDAllottee1.Text = dt.Rows[0]["VoterIDCardNo1"].ToString();
                lblVoterIDAllottee2.Text = dt.Rows[0]["VoterIDCardNo2"].ToString();
                lblDLNoAllottee1.Text = dt.Rows[0]["DrivingLicense1"].ToString();
                lblDLNoAllottee2.Text = dt.Rows[0]["DrivingLicense2"].ToString();
            }






        }
    }
}