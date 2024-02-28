using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class AllotteeApplicationVew : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            int id = Convert.ToInt32(Request.QueryString["UserId"]);
            LblAllotteeId.Text = Request.QueryString["UserId"];




            view(id);

        }



        public void view(int id)
        {


            SqlCommand cmd = new SqlCommand("spc_GetAllAllotteeApplicationDetailsByIdTemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AllotteeID", id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];

            if (dt1.Rows.Count > 0)
            {

                Label28.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                Label24.Text = dt1.Rows[0]["CompanyName"].ToString();
                Label25.Text = dt1.Rows[0]["FirmConstitution"].ToString();
                Label30.Text = dt1.Rows[0]["SignatoryEmail"].ToString();
                Label29.Text = dt1.Rows[0]["SignatoryPhone"].ToString();
                Label31.Text = dt1.Rows[0]["SignatoryAddress"].ToString();
                Label26.Text = dt1.Rows[0]["PanNo"].ToString();
                Label27.Text = dt1.Rows[0]["CinNo"].ToString();
                Label14.Text = dt1.Rows[0]["PlotSize"].ToString();
                Label23.Text = dt1.Rows[0]["IndustrialArea"].ToString();
                Label1.Text = dt1.Rows[0]["Status_Name"].ToString();
                Label13.Text = dt1.Rows[0]["DateofAllotmentNo"].ToString();




                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Individual/Sole Proprietorship firm")
                {
                    GridView6.Visible = true;
                    P2.InnerText = "Individual/Sole Proprietorship firm Details";
                    GridView6.DataSource = dt2; GridView6.DataBind();
                }
                else
                {
                    GridView6.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Public Limited")
                {
                    GridView7.Visible = true;
                    P2.InnerText = "Directors Details";
                    GridView7.DataSource = dt2; GridView7.DataBind();
                }
                else
                {
                    GridView7.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Private Limited")
                {
                    GridView8.Visible = true;
                    P2.InnerText = "ShareHolders Details";
                    GridView8.DataSource = dt2; GridView8.DataBind();
                }
                else
                {
                    GridView8.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Partnership Firm")
                {
                    GridView9.Visible = true;
                    P2.InnerText = "Partners Details";
                    GridView9.DataSource = dt2; GridView9.DataBind();
                }
                else
                {
                    GridView9.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Society & Trust")
                {
                    GridView10.Visible = true;
                    P2.InnerText = "Trustee Details";
                    GridView10.DataSource = dt2; GridView10.DataBind();
                }
                else
                {
                    GridView10.Visible = false;
                }




                Label12.Text = dt3.Rows[0]["IndustryType"].ToString();
                Label33.Text = dt3.Rows[0]["EstimatedCostOfProject"].ToString();
                Label34.Text = dt3.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                Label35.Text = dt3.Rows[0]["CoveredArea"].ToString();
                Label36.Text = dt3.Rows[0]["OpenAreaRequired"].ToString();
                Label37.Text = dt3.Rows[0]["LandDetails"].ToString();
                Label38.Text = dt3.Rows[0]["BuildingDetails"].ToString();
                Label39.Text = dt3.Rows[0]["MachineryEquipmentsDetails"].ToString();
                Label40.Text = dt3.Rows[0]["OtherFixedAssets"].ToString();
                Label41.Text = dt3.Rows[0]["OtherExpenses"].ToString();
                Label44.Text = dt3.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                Label45.Text = dt3.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                Label46.Text = dt3.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                Label47.Text = dt3.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                Label48.Text = dt3.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                Label49.Text = dt3.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                if (dt3.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                {
                    Span1.InnerText = "Yes";
                    Div1.Visible = true;
                    Label43.Text = dt3.Rows[0]["FumeQuantity"].ToString();
                    Label42.Text = dt3.Rows[0]["FumeNature"].ToString();
                }
                else
                {
                    Span1.InnerText = "No";
                    Div1.Visible = false;
                    Label43.Text = "";
                    Label42.Text = "";
                }
                Label50.Text = dt3.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                Label51.Text = dt3.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                Label52.Text = dt3.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                Label53.Text = dt3.Rows[0]["PowerReqInKW"].ToString();
                Label54.Text = dt3.Rows[0]["TelephoneReqFirstYear1"].ToString();
                Label55.Text = dt3.Rows[0]["TelephoneReqFirstYear2"].ToString();
                Label56.Text = dt3.Rows[0]["TelephoneReqUltimate1"].ToString();
                Label57.Text = dt3.Rows[0]["TelephoneReqUltimate2"].ToString();
                if (dt3.Rows[0]["ApplicantPrioritySpecification"].ToString() == "True")
                {
                    Span2.InnerText = "Yes";
                    Div2.Visible = true;
                    Label58.Text = dt3.Rows[0]["ApplicantPrioritySpecification"].ToString();
                }
                else
                {
                    Span2.InnerText = "No";
                    Div2.Visible = false;
                    Label58.Text = "";
                }

                Label2.Text = dt3.Rows[0]["NetTurnOver"].ToString();
                Label3.Text = dt3.Rows[0]["ExpansionOfLand"].ToString();
                Label4.Text = dt3.Rows[0]["ExportOriented"].ToString();
            }


            cmd.Dispose();




        }







        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeApplicationDoc where AllotteeId='" + LblAllotteeId.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Document1"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType1"].ToString();
                    Response.AddHeader("content-disposition", "inline; filename="
                    + dt.Rows[0]["FileName1"].ToString());
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeApplicationDoc where AllotteeId='" + LblAllotteeId.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Document2"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType2"].ToString();
                    Response.AddHeader("content-disposition", "inline; filename="
                    + dt.Rows[0]["FileName2"].ToString());
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                string message = "No Document Exists";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('" + message + "');", true);
                return;
            }
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeApplicationDoc where AllotteeId='" + LblAllotteeId.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Document3"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType3"].ToString();
                    Response.AddHeader("content-disposition", "inline; filename="
                    + dt.Rows[0]["FileName3"].ToString());
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
            else
            {
                string message = "No Document Exists";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeApplicationDoc where AllotteeId='" + LblAllotteeId.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Document4"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType4"].ToString();
                    Response.AddHeader("content-disposition", "inline; filename="
                    + dt.Rows[0]["FileName4"].ToString());
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
            else
            {
                string message = "No Document Exists";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
        }
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeApplicationDoc where AllotteeId='" + LblAllotteeId.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Document5"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType5"].ToString();
                    Response.AddHeader("content-disposition", "inline; filename="
                    + dt.Rows[0]["FileName5"].ToString());
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
            else
            {
                string message = "No Document Exists";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
        }
        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeApplicationDoc where AllotteeId='" + LblAllotteeId.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Document6"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType6"].ToString();
                    Response.AddHeader("content-disposition", "inline; filename="
                    + dt.Rows[0]["FileName6"].ToString());
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
            else
            {
                string message = "No Document Exists";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
        }
        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeApplicationDoc where AllotteeId='" + LblAllotteeId.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Document7"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType7"].ToString();
                    Response.AddHeader("content-disposition", "inline; filename="
                    + dt.Rows[0]["FileName7"].ToString());
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
            else
            {
                string message = "No Document Exists";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
        }





    }




}
