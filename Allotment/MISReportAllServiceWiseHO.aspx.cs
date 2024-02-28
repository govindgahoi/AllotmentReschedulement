using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;

namespace Allotment
{
    public partial class MISReportAllServiceWiseHO : System.Web.UI.Page
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
                    Bind_Announcement_List_GridView();
                }

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

        }

        public void RenderHeaderGrid1(HtmlTextWriter writer, Control ctl)
        {
            DynamicHeaders dynHead = new DynamicHeaders("SNo,Add,Regional Office,Applications Received,Applications Under Objection,Approved,Rejected,Total Pending,Pending At|DA,Pending At|RM,Pending At|JE,Pending At|Accountant,Pending At|MO,Pending At|AM,Pending At|DM,Pending At|CMIA,Pending At|JMD,Pending At|MD");
            ArrayList Headers = dynHead.ParseHeader();

            Color[] bkColors = { Color.Yellow, Color.Yellow };
            int[] fntSizes = { 10, 10 };

            for (int j = 0; j < Headers.Count; j++)
            {
                List<DynamicHeaderCell> HeaderRow = (List<DynamicHeaderCell>)Headers[j];
                for (int i = 0; i < HeaderRow.Count; i++)
                {
                    TableCell item = new TableCell();
                    item.Text = HeaderRow[i].Header;
                    item.ColumnSpan = HeaderRow[i].ColSpan;
                    item.RowSpan = HeaderRow[i].RowSpan;
                    item.HorizontalAlign = HorizontalAlign.Center;
                    item.VerticalAlign = VerticalAlign.Middle;
                    item.Font.Bold = true;
                    item.Font.Name = "arial, helvetica,sans-serif";
                    item.Font.Size = fntSizes[j];
                    item.BackColor = bkColors[j];
                    item.RenderControl(writer);

                }

                writer.WriteEndTag("TR");
                if (j < Headers.Count - 1)
                    writer.RenderBeginTag("TR");
            }

        }
        public void RenderHeaderGridService(HtmlTextWriter writer, Control ctl)
        {
            DynamicHeaders dynHead = new DynamicHeaders("SNo,Service Name,Applications Received,Applications Under Objection,Approved,Rejected,Total Pending,Pending At|DA,Pending At|RM,Pending At|JE,Pending At|Accountant,Pending At|MO,Pending At|AM,Pending At|DM,Pending At|CMIA,Pending At|JMD,Pending At|MD");
            ArrayList Headers = dynHead.ParseHeader();

            Color[] bkColors = { Color.Yellow, Color.Yellow };
            int[] fntSizes = { 10, 10 };

            for (int j = 0; j < Headers.Count; j++)
            {
                List<DynamicHeaderCell> HeaderRow = (List<DynamicHeaderCell>)Headers[j];
                for (int i = 0; i < HeaderRow.Count; i++)
                {
                    TableCell item = new TableCell();
                    item.Text = HeaderRow[i].Header;
                    item.ColumnSpan = HeaderRow[i].ColSpan;
                    item.RowSpan = HeaderRow[i].RowSpan;
                    item.HorizontalAlign = HorizontalAlign.Center;
                    item.VerticalAlign = VerticalAlign.Middle;
                    item.Font.Bold = true;
                    item.Font.Name = "arial, helvetica,sans-serif";
                    item.Font.Size = fntSizes[j];
                    item.BackColor = bkColors[j];
                    item.RenderControl(writer);
                }
                writer.WriteEndTag("TR");
                if (j < Headers.Count - 1)
                    writer.RenderBeginTag("TR");
            }

        }
        protected void GridViewWithDynamicHeader_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                //Render the header
                e.Row.SetRenderMethodDelegate(new RenderMethod(RenderHeaderGrid1));
        }
        protected void GridViewWithServiceHeader_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                //Render the header
                e.Row.SetRenderMethodDelegate(new RenderMethod(RenderHeaderGridService));
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

       
        protected void Regional_Changed(object sender, EventArgs e)
        {
            try
            {

                Bind_Announcement_List_GridView();

            }
            catch (Exception ex)
            {

            }

        }

        #region "IA Service Report"
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private DataTable Getdata2
        {
            get; set;
        }
        private void Bind_Announcement_List_GridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
                objServiceTimelinesBEL.IAName = "ALL";
                //objServiceTimelinesBEL.FromDate = txtTransactionFromDate.Text;
                //objServiceTimelinesBEL.ToDate = txtTransactionToDate.Text;

                ds = objServiceTimelinesBLL.Get_IAService_ROList(objServiceTimelinesBEL);
                //ds = objServiceTimelinesBLL.Get_IAService_ListNew(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
                //if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }
                //if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    DateTime dateTime = DateTime.UtcNow.Date;
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();
                    lblDate.Text = (dateTime.ToString("dd/MM/yyyy"));

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();

                }
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    Getdata1 = ds.Tables[1];
                //}




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private DataTable Getdata1
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }
        private DataTable dtReginaloffice
        {
            get; set;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataSet dsReginaloffice = new DataSet();
                    try
                    {
                        belBookDetails objServiceTimelinesBEL = new belBookDetails();
                        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                       
                        objServiceTimelinesBEL.RegionalOffice = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();
                        string ReginalOffice = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        objServiceTimelinesBEL.ServiceTimeLines = ddlService.SelectedValue.Trim();
                        //objServiceTimelinesBEL.FromDate = txtTransactionFromDate.Text;
                        //objServiceTimelinesBEL.ToDate = txtTransactionToDate.Text;
                        dsReginaloffice = objServiceTimelinesBLL.Get_IAServiceList(objServiceTimelinesBEL);
                        if (dsReginaloffice.Tables[0].Rows.Count > 0) { dtReginaloffice = dsReginaloffice.Tables[0]; }
                        if (dsReginaloffice.Tables[0].Rows.Count > 0)
                        {
                            GridView grdview = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
                            grdview.DataSource = dtReginaloffice;
                            grdview.DataBind();
                            Label ReginalOfficeName = e.Row.FindControl("ReginalOfficeName") as Label;
                            ReginalOfficeName.Text = ReginalOffice;
                            Label Date = e.Row.FindControl("lblDate") as Label;
                            Date.Text = (dateTime.ToString("dd/MM/yyyy"));
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        #endregion



        protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_Announcement_List_GridView();
        }
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            Bind_Announcement_List_GridView();
        }

        protected void ddlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Bind_Announcement_List_GridView();

            }
            catch (Exception ex)
            {

            }
        }
    }
}