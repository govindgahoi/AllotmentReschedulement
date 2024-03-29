﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class MISReportInvestmentDataHO : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                if (!IsPostBack)
                {

                    UserSpecificBinding();

                }

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

        }
        protected void UserSpecificBinding()
        {

            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                ddloffice.Items.Insert(0, new ListItem("--ALL--", "All"));
                Regional_Changed(null, null);
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIAregionalOfficeWise(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--All--", "ALL"));
                //     BindServiceRequestGrid();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }
        protected void Regional_Changed(object sender, EventArgs e)
        {
            try
            {

                bindDDLRegion(ddloffice.SelectedItem.Value, null);

            }
            catch (Exception ex)
            {

            }

        }

        private void BindServiceRequestGrid()
        {
            DataSet ds = new DataSet();
            try
            {

                objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
                objServiceTimelinesBEL.IndustrialArea = (drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.PaymentMode    = (ddlReportType.SelectedValue.Trim());
                objServiceTimelinesBEL.serviceID      = (ddlService.SelectedValue.Trim());
                if (txtTransactionFromDate.Text == "") 
                {
                    objServiceTimelinesBEL.FromDatetime = null;
                }
                else
                {
                    string FromDate = DateTime.ParseExact(txtTransactionFromDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.FromDatetime = Convert.ToDateTime(FromDate);

                }
                if (txtTransactionToDate.Text == "")
                {
                    objServiceTimelinesBEL.ToDatetime = null;
                }
                else
                {
                    string ToDate = DateTime.ParseExact(txtTransactionToDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.ToDatetime = Convert.ToDateTime(ToDate);
                }
                ds = objServiceTimelinesBLL.GetListOfInvestmentIAWise(objServiceTimelinesBEL);


                DataTable dt  = new DataTable();
                DataTable dt1 = new DataTable();

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        AllGrid.DataSource = dt;
                        AllGrid.DataBind();
                    }
                    else
                    {
                        AllGrid.DataSource = null;
                        AllGrid.DataBind();
                    }
                }
                else
                {
                    AllGrid.DataSource = null;
                    AllGrid.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }
    }
}