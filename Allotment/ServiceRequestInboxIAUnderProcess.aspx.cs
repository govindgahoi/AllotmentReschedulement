using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceRequestInboxIAUnderProcess : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Change Of Project" });
                sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Addition Of Product" });
                sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Completion Certificate" });
                sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Occupancy Certificate" });
                sub_menu.Items.Add(new MenuItem { Value = "4", Text = "Second Charge" });
                sub_menu.Items.Add(new MenuItem { Value = "5", Text = "Joint Mortgage" });
                sub_menu.Items.Add(new MenuItem { Value = "6", Text = "Noc Mortgage" });
                sub_menu.Items.Add(new MenuItem { Value = "7", Text = "Transfer of Lease deed" });
                sub_menu.Items.Add(new MenuItem { Value = "8", Text = "Time Extension Fee" });
                sub_menu.Items.Add(new MenuItem { Value = "19", Text = "No Dues" });
                sub_menu.Items.Add(new MenuItem { Value = "20", Text = "Oustanding Dues" });
                #region Newservice
                sub_menu.Items.Add(new MenuItem { Value = "9", Text = "Start of Production" });
                sub_menu.Items.Add(new MenuItem { Value = "10", Text = "Cancelation of Plot" });

                #endregion

                #region Newservice Manish Rastogi
                sub_menu.Items.Add(new MenuItem { Value = "11", Text = "Reconstitution of allotte firm / company" });
                sub_menu.Items.Add(new MenuItem { Value = "12", Text = "Hand over of lease deed to lease" });
                sub_menu.Items.Add(new MenuItem { Value = "13", Text = "Recognition legal heir" });
                sub_menu.Items.Add(new MenuItem { Value = "14", Text = "Water Connection" });
                #endregion

                #region Manish Shukla
                sub_menu.Items.Add(new MenuItem { Value = "15", Text = "Restoration of plot" });
                sub_menu.Items.Add(new MenuItem { Value = "16", Text = "Surrender of Plot" });
                sub_menu.Items.Add(new MenuItem { Value = "17", Text = "Establishment of Additional Unit" });
                sub_menu.Items.Add(new MenuItem { Value = "18", Text = "Subletting of Plot" });

                #endregion

                sub_menu.DataBind();
                BindServiceRequestGridView();
                BindTotalCount();
                if (ApplicationView.ActiveViewIndex <= 0)
                {
                    ApplicationView.ActiveViewIndex = 0;

                }
            }
        }


        protected void grid_Announcement_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_Announcement_List.PageIndex = e.NewPageIndex;
            this.BindTotalCount();
        }

        #region "Bind ServiceRequest in GridView"
        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfChangeOfProjectUnderProcess(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ChangeOfProject_Grid.DataSource = ds.Tables[0];
                    ChangeOfProject_Grid.DataBind();
                }
                else
                {
                    ChangeOfProject_Grid.DataSource = null;
                    ChangeOfProject_Grid.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    AdditionOfProduct_Grid.DataSource = ds.Tables[1];
                    AdditionOfProduct_Grid.DataBind();
                }
                else
                {
                    AdditionOfProduct_Grid.DataSource = null;
                    AdditionOfProduct_Grid.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    CompletionCertificate_Grid.DataSource = ds.Tables[2];
                    CompletionCertificate_Grid.DataBind();
                }
                else
                {
                    CompletionCertificate_Grid.DataSource = null;
                    CompletionCertificate_Grid.DataBind();
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    OccupancyCertificate_Grid.DataSource = ds.Tables[3];
                    OccupancyCertificate_Grid.DataBind();
                }
                else
                {
                    OccupancyCertificate_Grid.DataSource = null;
                    OccupancyCertificate_Grid.DataBind();
                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    SecondCharge_Grid.DataSource = ds.Tables[4];
                    SecondCharge_Grid.DataBind();
                }
                else
                {
                    SecondCharge_Grid.DataSource = null;
                    SecondCharge_Grid.DataBind();
                }
                if (ds.Tables[6].Rows.Count > 0)
                {
                    JointMortgage_Grid.DataSource = ds.Tables[6];
                    JointMortgage_Grid.DataBind();
                }
                else
                {
                    JointMortgage_Grid.DataSource = null;
                    JointMortgage_Grid.DataBind();
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    NocMortgage_Grid.DataSource = ds.Tables[5];
                    NocMortgage_Grid.DataBind();
                }
                else
                {
                    NocMortgage_Grid.DataSource = null;
                    NocMortgage_Grid.DataBind();
                }

                if (ds.Tables[7].Rows.Count > 0)
                {
                    transferofleasedeed.DataSource = ds.Tables[7];
                    transferofleasedeed.DataBind();
                }
                else
                {
                    transferofleasedeed.DataSource = null;
                    transferofleasedeed.DataBind();
                }
                if (ds.Tables[8].Rows.Count > 0)
                {
                    GridViewTEF.DataSource = ds.Tables[8];
                    GridViewTEF.DataBind();
                }
                else
                {
                    GridViewTEF.DataSource = null;
                    GridViewTEF.DataBind();
                }
                #region  Newservice
                if (ds.Tables[9].Rows.Count > 0)
                {
                    gvStartofproduction.DataSource = ds.Tables[9];
                    gvStartofproduction.DataBind();
                }
                else
                {
                    gvStartofproduction.DataSource = null;
                    gvStartofproduction.DataBind();
                }

                if (ds.Tables[10].Rows.Count > 0)
                {
                    gvPlotCancelation.DataSource = ds.Tables[10];
                    gvPlotCancelation.DataBind();
                }
                else
                {
                    gvPlotCancelation.DataSource = null;
                    gvPlotCancelation.DataBind();
                }
                #endregion

                #region Services By Manish Rastogi
                if (ds.Tables[11].Rows.Count > 0)
                {
                    GridViewreconstitution.DataSource = ds.Tables[11];
                    GridViewreconstitution.DataBind();
                }
                else
                {
                    GridViewreconstitution.DataSource = null;
                    GridViewreconstitution.DataBind();
                }
                if (ds.Tables[12].Rows.Count > 0)
                {
                    Gridhandoverofleasedeedtolease.DataSource = ds.Tables[12];
                    Gridhandoverofleasedeedtolease.DataBind();
                }
                else
                {
                    Gridhandoverofleasedeedtolease.DataSource = null;
                    Gridhandoverofleasedeedtolease.DataBind();
                }
                if (ds.Tables[13].Rows.Count > 0)
                {
                    Reconstitutionlegalheir_GridView.DataSource = ds.Tables[13];
                    Reconstitutionlegalheir_GridView.DataBind();
                }
                else
                {
                    Reconstitutionlegalheir_GridView.DataSource = null;
                    Reconstitutionlegalheir_GridView.DataBind();
                }

                if (ds.Tables[14].Rows.Count > 0)
                {
                    WaterConnection_GridView.DataSource = ds.Tables[14];
                    WaterConnection_GridView.DataBind();
                }
                else
                {
                    WaterConnection_GridView.DataSource = null;
                    WaterConnection_GridView.DataBind();
                }
                #endregion

                #region NewServiceManishShukla
                if (ds.Tables[15].Rows.Count > 0)
                {
                    gvRestoration.DataSource = ds.Tables[15];
                    gvRestoration.DataBind();
                }
                else
                {
                    gvRestoration.DataSource = null;
                    gvRestoration.DataBind();
                }
                if (ds.Tables[16].Rows.Count > 0)
                {
                    gvSurrender.DataSource = ds.Tables[16];
                    gvSurrender.DataBind();
                }
                else
                {
                    gvSurrender.DataSource = null;
                    gvSurrender.DataBind();
                }
                if (ds.Tables[17].Rows.Count > 0)
                {
                    gvAdditional.DataSource = ds.Tables[17];
                    gvAdditional.DataBind();
                }
                else
                {
                    gvAdditional.DataSource = null;
                    gvAdditional.DataBind();
                }
                if (ds.Tables[18].Rows.Count > 0)
                {
                    gvSubletting.DataSource = ds.Tables[18];
                    gvSubletting.DataBind();
                }
                else
                {
                    gvSubletting.DataSource = null;
                    gvSubletting.DataBind();
                }

                if (ds.Tables[19].Rows.Count > 0)
                {
                    NoDues_Grid.DataSource = ds.Tables[19];
                    NoDues_Grid.DataBind();
                }
                else
                {
                    NoDues_Grid.DataSource = null;
                    NoDues_Grid.DataBind();
                }

                if (ds.Tables[20].Rows.Count > 0)
                {
                    Grid_OutStandingDues.DataSource = ds.Tables[20];
                    Grid_OutStandingDues.DataBind();
                }
                else
                {
                    Grid_OutStandingDues.DataSource = null;
                    Grid_OutStandingDues.DataBind();
                }

                #endregion
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

        private void BindTotalCount()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.BindTotalCountUnderProcess(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {

                    grid_Announcement_List.DataSource = ds.Tables[0];
                    grid_Announcement_List.DataBind();

                    TotalPending.Text = ds.Tables[1].Rows[0][0].ToString();


                }
                else
                {
                    grid_Announcement_List.DataSource = null;
                    grid_Announcement_List.DataBind();

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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
                if (CategoryID == 2)

                    e.Row.BackColor = System.Drawing.Color.White;
            }
        }
        #endregion




    }
}