using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PlotAvailability : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        #endregion
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                // bindgrid();
                bindregion();
                tblplotdetails.Visible = false;
            }
        }

        private void bindregion()
        {


            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[spDistrictRecordsforfindaplot]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlDistrict.DataSource = dt;
                ddlDistrict.DataTextField = "District";
                ddlDistrict.DataValueField = "DistrictID";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

            int districtId = Convert.ToInt32(ddlDistrict.SelectedValue.Trim());

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetDistrictNameRecords(districtId);
                ddlIA.DataSource = ds;
                ddlIA.DataTextField = "IAName";
                ddlIA.DataValueField = "Id";
                ddlIA.DataBind();
                ddlIA.Items.Insert(0, new ListItem("--Select--", "0"));
                tblplotdetails.Visible = false;

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
        public void bindgrid()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            tblplotdetails.Visible = true;

            int IA = Convert.ToInt32(ddlIA.SelectedValue);
            ViewState["ID"] = IA;
            try
            {
                ds = objServiceTimelinesBLL.Getgridplotavailability(IA);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gridplotavailability.DataSource = ds;
                    gridplotavailability.DataBind();
                }
                else
                {
                    gridplotavailability.DataSource = null;
                    gridplotavailability.DataBind();
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
        protected void ddlIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IA = Convert.ToInt32(ddlIA.SelectedValue);
            ViewState["ID"] = IA;
            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[spGetAREARANGE]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlArea.DataSource = dt;
                ddlArea.DataTextField = "AREARANGE";
                ddlArea.DataValueField = "ID";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
                bindgrid();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }


        public void gridFunc()
        {
            try
            {
                bindgrid();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void gridplotavailability_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridplotavailability.PageIndex = e.NewPageIndex;
                gridFunc();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            tblplotdetails.Visible = true;
            int IAID = Convert.ToInt32(ViewState["ID"]);
            int AreaID = Convert.ToInt32(ddlArea.SelectedValue);
            try
            {
                ds = objServiceTimelinesBLL.Getgridplotareawise(IAID, AreaID);
                if (ds != null)
                {
                    gridplotavailability.DataSource = ds;
                    gridplotavailability.DataBind();
                }
                else
                {
                    gridplotavailability.DataSource = null;
                    gridplotavailability.DataBind();
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