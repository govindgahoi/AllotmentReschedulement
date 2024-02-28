using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class LandAcquisitionRegistration : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        SqlConnection con = new SqlConnection();
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string UserName = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            string value = Session["LandID"] as string;
            if (!(String.IsNullOrEmpty(value)))
            {
                if (Session["LandID"].ToString().Length > 0)
                {
                    btn_first_save.Text = "Saved";
                    LandID.Text = Session["LandID"].ToString();
                    btnNextNotification.Enabled = true;
                }
                else { LandID.Text = ""; Session["LandID"] = ""; }
            }
            else { LandID.Text = ""; Session["LandID"] = ""; btnNextNotification.Enabled = false; }
            if (MultiView1.ActiveViewIndex == -1)
            {
                GetNewAllotteeDetails();
                Session["LandID"] = "";
            }
            if (!IsPostBack)

            {
                bindDDLDistict();
                bindDDLCourtType();
                bindDDLCaseType();
            }
        }

        public void GetNewAllotteeDetails()
        {
            MultiView1.ActiveViewIndex = 0;
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            if (drpDistict.SelectedValue.Length > 0)
            {
                objServiceTimelinesBEL.District = Convert.ToInt32(drpDistict.SelectedValue);
            }
            else
            {
                objServiceTimelinesBEL.District = drpDistict.SelectedIndex;
            }
            if (ddlSubDistict.SelectedValue.Length > 0)
            {
                objServiceTimelinesBEL.SubDistrict = Convert.ToInt32(ddlSubDistict.SelectedValue);
            }
            else
            {
                objServiceTimelinesBEL.SubDistrict = ddlSubDistict.SelectedIndex;
            }
            if (drpdwnIA.SelectedValue.Length > 0)
            {
                objServiceTimelinesBEL.IAID = drpdwnIA.SelectedValue;
            }
            else
            {
                objServiceTimelinesBEL.IAID = (drpdwnIA.SelectedIndex).ToString();
            }

            DataSet dsAllottee = new DataSet();
            try
            {
                dsAllottee = objServiceTimelinesBLL.GetLandADetailwithParameter(objServiceTimelinesBEL);
                DataTable dt = dsAllottee.Tables[0];
                GridView1_pending_process.DataSource = dt;
                GridView1_pending_process.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        private void bindDDLDistict()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetDistrictRecords();
                drpDistict.DataSource = ds;
                drpDistict.DataTextField = "District";
                drpDistict.DataValueField = "DistrictCode";
                drpDistict.DataBind();
                drpDistict.Items.Insert(0, new ListItem("--ALL--", "0"));

                ddlDistrictName.DataSource = ds;
                ddlDistrictName.DataTextField = "District";
                ddlDistrictName.DataValueField = "DistrictCode";
                ddlDistrictName.DataBind();
                ddlDistrictName.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }


        }
        protected void drpDistict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { bindDDLSubDistict(drpDistict.SelectedValue); } catch { }
            int DistrictID = Convert.ToInt32(drpDistict.SelectedValue);
            objServiceTimelinesBEL.District = (DistrictID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIANameNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--Select --", "0"));

                GetNewAllotteeDetails();
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

        protected void ddlDistrictName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { bindDDLSubDistictName(ddlDistrictName.SelectedItem.Value); } catch { }
            try { bindDDLIAName(ddlDistrictName.SelectedItem.Value); } catch { }

        }

        protected void ddlSubDistict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { bindDDLVillage(ddlTehsilName.SelectedValue); } catch { }

        }

        private void bindDDLCaseType()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCaseType();
                ddlCaseType.DataSource = ds;
                ddlCaseType.DataTextField = "CaseName";
                ddlCaseType.DataValueField = "ID";

                ddlCaseType.DataBind();
                ddlCaseType.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void bindDDLCourtType()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCourtType();
                ddlCourttype.DataSource = ds;
                ddlCourttype.DataTextField = "CourtName";
                ddlCourttype.DataValueField = "ID";

                ddlCourttype.DataBind();
                ddlCourttype.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindDDLSubDistict(string pdistict)
        {
            objServiceTimelinesBEL.Distict = Convert.ToInt32(pdistict);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetSubDistict(objServiceTimelinesBEL);
                ddlSubDistict.DataSource = ds;
                ddlSubDistict.DataTextField = "SubDistrict";
                ddlSubDistict.DataValueField = "SubDistrictCode";
                ddlSubDistict.DataBind();
                ddlSubDistict.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void bindDDLSubDistictName(string pdistict)
        {
            objServiceTimelinesBEL.Distict = Convert.ToInt32(pdistict);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetSubDistict(objServiceTimelinesBEL);
                ddlTehsilName.DataSource = ds;
                ddlTehsilName.DataTextField = "SubDistrict";
                ddlTehsilName.DataValueField = "SubDistrictCode";
                ddlTehsilName.DataBind();
                ddlTehsilName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void bindDDLVillage(string pVillage)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.SubDistict = Convert.ToInt32(pVillage);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetVillage(objServiceTimelinesBEL);
                ddlVillage.DataSource = ds;
                ddlVillage.DataTextField = "VillageName";
                ddlVillage.DataValueField = "Census_Village_code";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, new ListItem("--Select--", "0"));


                ddlVilageList.DataSource = ds;
                ddlVilageList.DataTextField = "VillageName";
                ddlVilageList.DataValueField = "Census_Village_code";
                ddlVilageList.DataBind();
                ddlVilageList.Items.Insert(0, new ListItem("--Select--", "0"));

                ddlPossessionVillage.DataSource = ds;
                ddlPossessionVillage.DataTextField = "VillageName";
                ddlPossessionVillage.DataValueField = "Census_Village_code";
                ddlPossessionVillage.DataBind();
                ddlPossessionVillage.Items.Insert(0, new ListItem("--Select--", "0"));

                ddlFinalAwardsVillage.DataSource = ds;
                ddlFinalAwardsVillage.DataTextField = "VillageName";
                ddlFinalAwardsVillage.DataValueField = "Census_Village_code";
                ddlFinalAwardsVillage.DataBind();
                ddlFinalAwardsVillage.Items.Insert(0, new ListItem("--Select--", "0"));


                ddlConveyenceDeedVillageName.DataSource = ds;
                ddlConveyenceDeedVillageName.DataTextField = "VillageName";
                ddlConveyenceDeedVillageName.DataValueField = "Census_Village_code";
                ddlConveyenceDeedVillageName.DataBind();
                ddlConveyenceDeedVillageName.Items.Insert(0, new ListItem("--Select--", "0"));


                VillageList.DataSource = ds;
                VillageList.DataTextField = "VillageName";
                VillageList.DataValueField = "Census_Village_code";
                VillageList.DataBind();
                VillageList.Items.Insert(0, new ListItem("--Select--", "0"));


                ddlVillageCompansation.DataSource = ds;
                ddlVillageCompansation.DataTextField = "VillageName";
                ddlVillageCompansation.DataValueField = "Census_Village_code";
                ddlVillageCompansation.DataBind();
                ddlVillageCompansation.Items.Insert(0, new ListItem("--Select--", "0"));




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        private void bindDDLIAName(string pOffice)
        {
            int DistrictID = Convert.ToInt32(pOffice);
            objServiceTimelinesBEL.District = (DistrictID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIANameNameRecords(objServiceTimelinesBEL);
                ddlIAName.DataSource = ds;
                ddlIAName.DataTextField = "IAName";
                ddlIAName.DataValueField = "Id";
                ddlIAName.DataBind();
                ddlIAName.Items.Insert(0, new ListItem("--Select--", "0"));
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


        private void ResetControl1()
        {
            btn_first_save.Text = "Save";
            ddlDistrictName.SelectedIndex = 0;
            ddlTehsilName.SelectedIndex = -1;
            ddlIAName.SelectedIndex = -1;
            txtPrivateLand.Text = "";
            txtGSLand.Text = "";
            txtCeilingLand.Text = "";
            txtForestLand.Text = "";
            txtOtherArea.Text = "";
            txtNoofTubewells.Text = "";
            txtNoofPuccaBuildings.Text = "";
            txtNoofPuccaDrains.Text = "";
            txtAreaofgroveslands.Text = "";
            txtNosofWorshipPlaces.Text = "";
            txtNosofTrees.Text = "";
            txtOther.Text = "";

        }
        private void ResetControlNotification()
        {
            btnNotificationDetails.Text = "Submit";
            ddlVilageList.SelectedIndex = 0;
            txtDateofProposals.Text = "";
            ddlTypeofland.SelectedIndex = 0;
            txtArea.Text = "";
            txtNoofProposals.Text = "";
            txtus.Text = "";
            txtNotificationNo.Text = "";
            txtNotificationDate.Text = "";
            txtNotificationArea.Text = "";
        }

        private void ResetControlPossession()
        {
            btnPossessionDetails.Text = "Submit";
            ddlPossessionVillage.SelectedIndex = 0;
            txtPossessionDate.Text = "";
            txtPossessionArea.Text = "";
        }

        private void ResetControlAwardDetail()
        {
            btnAward.Text = "Submit";
            ddlFinalAwardsVillage.SelectedIndex = 0;
            txtAwardsDate.Text = "";
            txtAwardedArea.Text = "";
            txtAmount.Text = "";
            txtRemarks.Text = "";
        }

        private void ResetControlConveyenceDeed()
        {
            btnConveyenceDeed.Text = "Submit";
            ddlConveyenceDeedVillageName.SelectedIndex = 0;
            txtConveyenceArea.Text = "";
            txtExecution.Text = "";
            txtRegistration.Text = "";
            txtMutation.Text = "";
            txtInitial.Text = "";
            txtConRemarks.Text = "";
        }
        private void ResetControlPayment()
        {
            btnPaymentDetails.Text = "Submit";
            txtDraftDate.Text = "";
            txtDetails.Text = "";
            txtDraftNo.Text = "";
            txtPaymentAmount.Text = "";
        }

        private void ResetControlCompansation()
        {
            ddlVillageCompansation.SelectedIndex = 0;
            btnCompansation.Text = "Submit";
            txtCompansationAmount.Text = "";
        }

        private void ResetControlLitigation()
        {
            ddlCaseType.SelectedIndex = 0;
            ddlCourttype.SelectedIndex = 0;

            btnLitigation.Text = "Submit";
            txtCaseName.Text = "";
            txtLawyer.Text = "";
            txtPartyName.Text = "";
        }



        protected void Home_ServerClick(object sender, EventArgs e)
        {
            GetNewAllotteeDetails();
            ResetControl1();
            MultiView1.ActiveViewIndex = 0;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void NewAllottee_ServerClick(object sender, EventArgs e)
        {


            New_Allottee_Registration_btn_click(null, null);
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
            lblNewButton.Text = "1";

        }

        #region BindDetails
        public void GetAllLandAcuisitionDetailsFilledById(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandIDs = LandID; 
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetLandAcuisitionDetailsFilledById(objServiceTimelinesBEL);
                DataTable dt1 = ds.Tables[0];

                if (dt1.Rows.Count > 0)
                {
                    ddlDistrictName.SelectedValue = dt1.Rows[0]["DistirctID"].ToString().Trim();
                    ddlDistrictName_SelectedIndexChanged(ddlDistrictName.SelectedValue, null);
                    lblDistrictName.Text= dt1.Rows[0]["DistrictName"].ToString().Trim();

                    ddlTehsilName.SelectedValue = dt1.Rows[0]["TehsilID"].ToString().Trim();
                    ddlSubDistict_SelectedIndexChanged(ddlTehsilName.SelectedValue, null);


                    ddlIAName.SelectedValue = dt1.Rows[0]["IAName"].ToString().Trim();
                    string village = dt1.Rows[0]["Pargana"].ToString().Trim();
                    string[] ArrVillage = village.Split(',');
                    if (village == "")
                    {
                        ddlVillage.ClearSelection();
                    }
                    else
                    {
                        for (int i = 0; i < ArrVillage.Length; i++)
                        {
                            ddlVillage.Items.FindByValue(ArrVillage[i]).Selected = true;
                        }
                    }
                    txtPrivateLand.Text = dt1.Rows[0]["PrivateLandArea"].ToString().Trim();
                    lblPrivateLand.Text= dt1.Rows[0]["PrivateLandArea"].ToString().Trim();

                    txtGSLand.Text = dt1.Rows[0]["GSLandArea"].ToString().Trim();
                    txtCeilingLand.Text = dt1.Rows[0]["CeilingLandArea"].ToString().Trim();
                    txtForestLand.Text = dt1.Rows[0]["ForestLand"].ToString().Trim();
                    txtOtherArea.Text = dt1.Rows[0]["OtherArea"].ToString().Trim();
                    txtNoofTubewells.Text = dt1.Rows[0]["NoofTubewells"].ToString().Trim();
                    txtNoofPuccaBuildings.Text = dt1.Rows[0]["NoofPuccaBuildings"].ToString().Trim();
                    txtNoofPuccaDrains.Text = dt1.Rows[0]["NoofPuccaDrains"].ToString().Trim();
                    txtAreaofgroveslands.Text = dt1.Rows[0]["Areaofgrovaslands"].ToString().Trim();
                    txtNosofWorshipPlaces.Text = dt1.Rows[0]["NoofWorshipplaces"].ToString().Trim();
                    txtNosofTrees.Text = dt1.Rows[0]["NoofTrees"].ToString().Trim();
                    txtOther.Text = dt1.Rows[0]["Others"].ToString().Trim();


                    lblTehsilName.Text = dt1.Rows[0]["TehsilName"].ToString().Trim();
                    lblIndustrialArea.Text = dt1.Rows[0]["IndustrialName"].ToString().Trim();

                    lblGSLand.Text = dt1.Rows[0]["GSLandArea"].ToString().Trim();
                    lblCeilingLand.Text = dt1.Rows[0]["CeilingLandArea"].ToString().Trim();
                    lblForestLand.Text = dt1.Rows[0]["ForestLand"].ToString().Trim();
                    lblOther.Text = dt1.Rows[0]["OtherArea"].ToString().Trim();
                    lblTubewells.Text = dt1.Rows[0]["NoofTubewells"].ToString().Trim();
                    lblPucca.Text = dt1.Rows[0]["NoofPuccaBuildings"].ToString().Trim();
                    lblDrain.Text = dt1.Rows[0]["NoofPuccaDrains"].ToString().Trim();
                    lblgravesland.Text = dt1.Rows[0]["Areaofgrovaslands"].ToString().Trim();
                    lblWorship.Text = dt1.Rows[0]["NoofWorshipplaces"].ToString().Trim();
                    lblTrees.Text = dt1.Rows[0]["NoofTrees"].ToString().Trim();
                    lblotherDetails.Text = dt1.Rows[0]["Others"].ToString().Trim();
                    lblVillageName.Text = dt1.Rows[0]["Census_VillageName"].ToString().Trim();
                    lblTotal.Text = dt1.Rows[0]["TotalLand"].ToString().Trim();



                    lblRemarks.Text = dt1.Rows[0]["Remarks"].ToString().Trim();
                    lblPublicUtilityLandArea.Text = dt1.Rows[0]["PublicUtilityLandArea"].ToString().Trim();
                    lblGeneralLandArea.Text = dt1.Rows[0]["GeneralLandArea"].ToString().Trim();

                    txtRemark.Text = dt1.Rows[0]["Remarks"].ToString().Trim();
                    txtPublicUtility.Text = dt1.Rows[0]["PublicUtilityLandArea"].ToString().Trim();
                    txtGeneralLand.Text = dt1.Rows[0]["GeneralLandArea"].ToString().Trim();


                    GridNotificationDetails(LandID);
                    GridPossessionDetails(LandID);
                    GridAwardDetails(LandID);
                    GridConveyenceDetails(LandID);
                    GridPaymentDetails(LandID);
                    GridCompansationDetails(LandID);
                    GridLitigationDetails(LandID);

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        private void get_NotificationDetails(int id)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.ResumptionOrderID = id;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetNotificationDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ResumptionOrderIDlbl.Text = dt.Rows[0]["ResumptionOrderID"].ToString();
                    ddlVilageList.SelectedValue = dt.Rows[0]["NameofVillage"].ToString().Trim();
                    ddlTypeofland.SelectedValue = dt.Rows[0]["TypeofLand"].ToString().Trim();
                    txtArea.Text = dt.Rows[0]["TotalArea"].ToString();
                    txtNoofProposals.Text = dt.Rows[0]["NoofProposals"].ToString();
                    string DateofProposals = dt.Rows[0]["DateofProposals"].ToString();
                    txtDateofProposals.Text = DateofProposals;

                    txtus.Text = dt.Rows[0]["US"].ToString();
                    txtNotificationNo.Text = dt.Rows[0]["ResumptionNumber"].ToString();
                    string NotificationDate = dt.Rows[0]["ResumptionDate"].ToString();
                    txtNotificationDate.Text = NotificationDate;
                    txtNotificationArea.Text = dt.Rows[0]["ResumptionArea"].ToString();
                    btnNotificationDetails.Text = "Update";
                }
                else
                {
                    btnNotificationDetails.Text = "Submit";
                    ResumptionOrderIDlbl.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }

        private void GridNotificationDetails(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetNotificationGridDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                gvNotification.DataSource = dt;
                gvNotification.DataBind();

                gvFinalViewNotification.DataSource = dt;
                gvFinalViewNotification.DataBind();

                if (dt.Rows.Count > 0)
                {
                    decimal totalArea = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalArea"));
                    decimal totalResumptionArea = dt.AsEnumerable().Sum(row => row.Field<decimal>("ResumptionArea"));

                    gvNotification.FooterRow.Cells[0].Text = "Total";
                    gvNotification.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvNotification.FooterRow.Cells[3].Text = totalArea.ToString("N2");
                    gvNotification.FooterRow.Cells[9].Text = totalResumptionArea.ToString("N2");

                    gvFinalViewNotification.FooterRow.Cells[0].Text = "Total";
                    gvFinalViewNotification.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvFinalViewNotification.FooterRow.Cells[3].Text = totalArea.ToString("N2");
                    gvFinalViewNotification.FooterRow.Cells[9].Text = totalResumptionArea.ToString("N2");
                }




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        private void get_PossessionDetails(int id)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.PossessionID = id;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPossessionDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Possassionlbl.Text = dt.Rows[0]["PossessionID"].ToString();
                    ddlPossessionVillage.SelectedValue = dt.Rows[0]["VillageName"].ToString().Trim();
                    string PossassionDate = dt.Rows[0]["PossessionDate"].ToString();
                    txtPossessionDate.Text = PossassionDate;
                    txtPossessionArea.Text = dt.Rows[0]["PossessionArea"].ToString(); ;
                    btnPossessionDetails.Text = "Update";
                }
                else
                {
                    btnPossessionDetails.Text = "Submit";
                    Possassionlbl.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
       
       

        private void GridPossessionDetails(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPossessionGridDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                gvPossessionDetails.DataSource = dt;
                gvPossessionDetails.DataBind();

                gvFinalviewPossession.DataSource = dt;
                gvFinalviewPossession.DataBind();

                if (dt.Rows.Count > 0)
                {
                    decimal totalArea = dt.AsEnumerable().Sum(row => row.Field<decimal>("PossessionArea"));

                    gvPossessionDetails.FooterRow.Cells[0].Text = "Total";
                    gvPossessionDetails.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvPossessionDetails.FooterRow.Cells[2].Text = totalArea.ToString("N2");
                   

                    gvFinalviewPossession.FooterRow.Cells[0].Text = "Total";
                    gvFinalviewPossession.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvFinalviewPossession.FooterRow.Cells[2].Text = totalArea.ToString("N2");
                   
                }




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        private void get_AwardsDetails(int id)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.AwardID = id;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAwardDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblAwards.Text = dt.Rows[0]["AwardsID"].ToString();
                    ddlFinalAwardsVillage.SelectedValue = dt.Rows[0]["VillageName"].ToString().Trim();
                    string strAwardsDate = dt.Rows[0]["AwardsDate"].ToString();
                    txtAwardsDate.Text = strAwardsDate;

                    txtAwardedArea.Text = dt.Rows[0]["AwardsArea"].ToString();
                    txtAmount.Text = dt.Rows[0]["AwardedAmount"].ToString();
                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();

                    btnAward.Text = "Update";
                }
                else
                {
                    btnAward.Text = "Submit";
                    lblAwards.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
        private void GridAwardDetails(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAwardGridDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                gvAward.DataSource = dt;
                gvAward.DataBind();
                gvFinalViewAward.DataSource = dt;
                gvFinalViewAward.DataBind();
                if(dt.Rows.Count > 0)
                {
                    decimal totalArea = dt.AsEnumerable().Sum(row => row.Field<decimal>("AwardsArea"));
                    decimal totalAmount = dt.AsEnumerable().Sum(row => row.Field<decimal>("AwardedAmount"));

                    gvAward.FooterRow.Cells[0].Text = "Total";
                    gvAward.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvAward.FooterRow.Cells[3].Text = totalArea.ToString("N2");
                    gvAward.FooterRow.Cells[4].Text = totalAmount.ToString("N2");

                    gvFinalViewAward.FooterRow.Cells[0].Text = "Total";
                    gvFinalViewAward.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvFinalViewAward.FooterRow.Cells[3].Text = totalArea.ToString("N2");
                    gvFinalViewAward.FooterRow.Cells[4].Text = totalAmount.ToString("N2");
                }
               

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        private void get_ConveyenceDetails(int id)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.ConveyenceID = id;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetConveyenceDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblConveyence.Text = dt.Rows[0]["ConveyenceID"].ToString();

                    ddlConveyenceDeedVillageName.SelectedValue = dt.Rows[0]["VillageName"].ToString().Trim();
                    txtConveyenceArea.Text = dt.Rows[0]["Area"].ToString();
                    txtExecution.Text = dt.Rows[0]["Execution"].ToString();
                    txtRegistration.Text = dt.Rows[0]["Registration"].ToString();
                    txtMutation.Text = dt.Rows[0]["Mutation"].ToString();
                    txtInitial.Text = dt.Rows[0]["Initial"].ToString();
                    txtConRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                    btnConveyenceDeed.Text = "Update";
                }
                else
                {
                    btnConveyenceDeed.Text = "Submit";
                    lblConveyence.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
        private void GridConveyenceDetails(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetConveyenceGridDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                gvConveyence.DataSource = dt;
                gvConveyence.DataBind();

                gvFinalViewConveyenceDeed.DataSource = dt;
                gvFinalViewConveyenceDeed.DataBind();
                if (dt.Rows.Count > 0)
                {
                    decimal totalArea = dt.AsEnumerable().Sum(row => row.Field<decimal>("Area"));

                    gvConveyence.FooterRow.Cells[0].Text = "Total";
                    gvConveyence.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvConveyence.FooterRow.Cells[2].Text = totalArea.ToString("N2");
                    gvFinalViewConveyenceDeed.FooterRow.Cells[0].Text = "Total";
                    gvFinalViewConveyenceDeed.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvFinalViewConveyenceDeed.FooterRow.Cells[2].Text = totalArea.ToString("N2");
                    
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        private void get_PaymentDetails(int id)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.PaymentsID = id;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPaymentDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblPaymentID.Text = dt.Rows[0]["LAPaymentID"].ToString();
                    string village = dt.Rows[0]["VillageName"].ToString().Trim();
                    string[] ArrVillage = village.Split(',');
                    if (village == "")
                    {
                        VillageList.ClearSelection();
                    }
                    else
                    {
                        for (int i = 0; i < ArrVillage.Length; i++)
                        {
                            VillageList.Items.FindByValue(ArrVillage[i]).Selected = true;
                        }
                    }

                    txtDetails.Text = dt.Rows[0]["Details"].ToString();

                    txtDraftNo.Text = dt.Rows[0]["DraftNo"].ToString();

                    txtDraftDate.Text = dt.Rows[0]["DraftDate"].ToString();

                    txtPaymentAmount.Text = dt.Rows[0]["DraftAmount"].ToString();
                    btnPaymentDetails.Text = "Update";
                }
                else
                {
                    btnPaymentDetails.Text = "Submit";
                    lblPaymentID.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
        private void GridPaymentDetails(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPaymentGridDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                gvPaymentDetails.DataSource = dt;
                gvPaymentDetails.DataBind();

                gvFinalViewPayment.DataSource = dt;
                gvFinalViewPayment.DataBind();

                if (dt.Rows.Count > 0)
                {
                    decimal totalArea = dt.AsEnumerable().Sum(row => row.Field<decimal>("DraftAmount"));

                    gvPaymentDetails.FooterRow.Cells[0].Text = "Total";
                    gvPaymentDetails.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvPaymentDetails.FooterRow.Cells[5].Text = totalArea.ToString("N2");


                    gvFinalViewPayment.FooterRow.Cells[0].Text = "Total";
                    gvFinalViewPayment.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvFinalViewPayment.FooterRow.Cells[5].Text = totalArea.ToString("N2");

                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }


        private void get_CompansationDetails(int id)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.CompansationID = id;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCompansationDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblCompansationID.Text = dt.Rows[0]["DistbursementID"].ToString();
                    string village = dt.Rows[0]["VillageName"].ToString().Trim();
                    ddlVillageCompansation.SelectedValue = dt.Rows[0]["VillageName"].ToString().Trim();
                    txtCompansationAmount.Text = dt.Rows[0]["DistbursementAmount"].ToString();
                    btnCompansation.Text = "Update";
                }
                else
                {
                    btnCompansation.Text = "Submit";
                    lblCompansationID.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }


        private void GridCompansationDetails(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCompansationGridDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                gvCompansation.DataSource = dt;
                gvCompansation.DataBind();

                gvFinalViewCompansation.DataSource = dt;
                gvFinalViewCompansation.DataBind();

                if (dt.Rows.Count > 0)
                {
                    decimal totalArea = dt.AsEnumerable().Sum(row => row.Field<decimal>("DistbursementAmount"));

                    gvCompansation.FooterRow.Cells[0].Text = "Total";
                    gvCompansation.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvCompansation.FooterRow.Cells[2].Text = totalArea.ToString("N2");


                    gvFinalViewCompansation.FooterRow.Cells[0].Text = "Total";
                    gvFinalViewCompansation.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvFinalViewCompansation.FooterRow.Cells[2].Text = totalArea.ToString("N2");

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        private void get_LitigationDetails(int id)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LitigationID = id;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetLitigationDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblLitigationID.Text = dt.Rows[0]["LitigationID"].ToString();
                    ddlCaseType.SelectedValue = dt.Rows[0]["CaseType"].ToString().Trim();
                    ddlCourttype.SelectedValue = dt.Rows[0]["CourtType"].ToString().Trim();
                    txtCaseName.Text = dt.Rows[0]["CaseName"].ToString();
                    txtLawyer.Text = dt.Rows[0]["Lawyer"].ToString();
                    txtPartyName.Text = dt.Rows[0]["PartyName"].ToString();
                    btnLitigation.Text = "Update";
                }
                else
                {
                    btnLitigation.Text = "Submit";
                    lblLitigationID.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
        private void GridLitigationDetails(int LandID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetLitigationGridDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                gvLitigation.DataSource = dt;
                gvLitigation.DataBind();

                gvFinalViewLitigation.DataSource = dt;
                gvFinalViewLitigation.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }


        #endregion


        #region InsertandUpdateRecords
        protected void btn_first_Click(object sender, EventArgs e)
        {
            int retval = 0, retVal2 = 0;
            string msg = "";
            string listVillage = "";
            try
            {

                if (ddlDistrictName.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select  Distict Name");
                    return;
                }
                if (ddlTehsilName.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select  Sub Distict Name");
                    return;
                }
                if (ddlIAName.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Provide Industrial Area Details");
                    return;
                }
                
                DataSet ds = new DataSet();
                if(lblNewButton.Text.Trim().Length > 0 )
                {
                    objServiceTimelinesBEL.Newstatus = Convert.ToInt32(lblNewButton.Text.Trim());
                }
                else
                {
                    objServiceTimelinesBEL.Newstatus = 0;
                }
               
                if (LandID.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
                }
                else
                {
                    objServiceTimelinesBEL.LandID = 0;
                }
                objServiceTimelinesBEL.Distict = Convert.ToInt32((ddlDistrictName.SelectedValue.Trim()));
                objServiceTimelinesBEL.SubDistict = Convert.ToInt32(ddlTehsilName.SelectedValue.Trim());
                objServiceTimelinesBEL.IAId = Convert.ToInt32(ddlIAName.SelectedValue.Trim());

                objServiceTimelinesBEL.PrivateLand = Convert.ToDecimal(string.IsNullOrEmpty(txtPrivateLand.Text.Trim()) ? "0" : txtPrivateLand.Text.Trim());
                objServiceTimelinesBEL.PublicUtility = Convert.ToDecimal(string.IsNullOrEmpty(txtPublicUtility.Text.Trim()) ? "0" : txtPublicUtility.Text.Trim());
                objServiceTimelinesBEL.GeneralLand = Convert.ToDecimal(string.IsNullOrEmpty(txtGeneralLand.Text.Trim()) ? "0" : txtGeneralLand.Text.Trim());

                objServiceTimelinesBEL.GSLand = Convert.ToDecimal(string.IsNullOrEmpty(txtGSLand.Text.Trim()) ? "0" : txtGSLand.Text.Trim());
                objServiceTimelinesBEL.CeilingLand = Convert.ToDecimal(string.IsNullOrEmpty(txtCeilingLand.Text.Trim()) ? "0" : txtCeilingLand.Text.Trim());
                objServiceTimelinesBEL.ForestLand = Convert.ToDecimal(string.IsNullOrEmpty(txtForestLand.Text.Trim()) ? "0" : txtForestLand.Text.Trim());
                objServiceTimelinesBEL.OtherArea = Convert.ToDecimal(string.IsNullOrEmpty(txtOtherArea.Text.Trim()) ? "0" : txtOtherArea.Text.Trim());
                objServiceTimelinesBEL.NoofTubewells = Convert.ToInt32(string.IsNullOrEmpty(txtNoofTubewells.Text.Trim()) ? "0" : txtNoofTubewells.Text.Trim());
                objServiceTimelinesBEL.NoofPuccaBuildings = Convert.ToInt32(string.IsNullOrEmpty(txtNoofPuccaBuildings.Text.Trim()) ? "0" : txtNoofPuccaBuildings.Text.Trim());
                objServiceTimelinesBEL.NoofPuccaDrains = Convert.ToInt32(string.IsNullOrEmpty(txtNoofPuccaDrains.Text.Trim()) ? "0" : txtNoofPuccaDrains.Text.Trim());
                objServiceTimelinesBEL.Areaofgroveslands = Convert.ToDecimal(string.IsNullOrEmpty(txtAreaofgroveslands.Text.Trim()) ? "0" : txtAreaofgroveslands.Text.Trim());
                objServiceTimelinesBEL.NosofWorshipPlaces = Convert.ToInt32(string.IsNullOrEmpty(txtNosofWorshipPlaces.Text.Trim()) ? "0" : txtNosofWorshipPlaces.Text.Trim());
                objServiceTimelinesBEL.NosofTrees = Convert.ToInt32(string.IsNullOrEmpty(txtNosofTrees.Text.Trim()) ? "0" : txtNosofTrees.Text.Trim());
                objServiceTimelinesBEL.Other = txtOther.Text.Trim();
                objServiceTimelinesBEL.Newstatus = Convert.ToInt32(lblNewButton.Text.Trim());
                objServiceTimelinesBEL.CreatedBy = UserName;
                objServiceTimelinesBEL.Remarks = txtRemark.Text.Trim();

                foreach (ListItem ddlVillage in this.ddlVillage.Items)
                {
                    if (ddlVillage.Selected == true)
                    {
                        listVillage = listVillage + ddlVillage.Value + ",";
                    }
                }
                objServiceTimelinesBEL.Village = listVillage.TrimEnd(',').Trim();
                if (btn_first_save.Text == "Submit")
                {
                    LandID.Text = "0";
                }
                else if (btn_first_save.Text == "Update")
                {
                    objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
                }
                ds = objServiceTimelinesBLL.NewRegistrationLandAcquispitionDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                        LandID.Text = Session["LandID"].ToString();
                        if (Session["LandID"].ToString().Length > 0)
                        {
                            btn_first_save.Text = "Saved";
                            lblNewButton.Text = "0";
                        }
                        GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                        MultiView1.ActiveViewIndex = 2;
                    }
                }
                else
                {
                    Session["LandID"] = "";
                    btn_first_save.Text = "Save";
                    string message = "Record could'nt be Save ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void btnNotificationDetails_Click(object sender, EventArgs e)
        {
            if (ddlVilageList.SelectedIndex == 0)
            {
                MessageBox1.ShowWarning("Please Select  Village Name");
                return;
            }
            if (LandID.Text.Trim().Length > 0)
            {
                objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
            }
            else
            {
                objServiceTimelinesBEL.LandID = 0;
            }
            if (txtDateofProposals.Text != "")
            {
                if (ValidateDate(txtDateofProposals.Text))
                {

                }
                else
                {
                    txtDateofProposals.Focus();
                    MessageBox1.ShowError("Date of Proposals");
                    return;
                }
            }



            objServiceTimelinesBEL.VillageID = Convert.ToInt32((ddlVilageList.SelectedValue.Trim()));
            objServiceTimelinesBEL.TypeofLand = ddlTypeofland.SelectedValue.Trim();

            objServiceTimelinesBEL.Area = Convert.ToDecimal(string.IsNullOrEmpty(txtArea.Text.Trim()) ? "0" : txtArea.Text.Trim());
            objServiceTimelinesBEL.NoofProposals = txtNoofProposals.Text.Trim();
            if (txtDateofProposals.Text.Trim().Length > 0)
            {
                string strDateofProposals = DateTime.ParseExact(txtDateofProposals.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.DateofProposals = Convert.ToDateTime(strDateofProposals);
            }
            objServiceTimelinesBEL.us = UserName;
            objServiceTimelinesBEL.NotificationNo = txtNotificationNo.Text.Trim();
            if (txtNotificationDate.Text.Trim().Length > 0)
            {
                string strNotificationDate = DateTime.ParseExact(txtNotificationDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.NotificationDate = Convert.ToDateTime(strNotificationDate);
            }
            objServiceTimelinesBEL.NotificationArea = Convert.ToDecimal(string.IsNullOrEmpty(txtNotificationArea.Text.Trim()) ? "0" : txtArea.Text.Trim());
            objServiceTimelinesBEL.CreatedBy = UserName;
            DataSet ds = new DataSet();
            if (btnNotificationDetails.Text == "Submit")
            {
                ResumptionOrderIDlbl.Text = "0";
            }
            else if (btnNotificationDetails.Text == "Update")
            {
                objServiceTimelinesBEL.ResumptionOrderID = Convert.ToInt32(ResumptionOrderIDlbl.Text.Trim());
            }
            ds = objServiceTimelinesBLL.LANotificationDetails(objServiceTimelinesBEL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                    LandID.Text = Session["LandID"].ToString();
                    if (Session["LandID"].ToString().Length > 0)
                    {
                        btnNotificationDetails.Text = "Submit";
                    }
                    GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                    ResetControlNotification();
                }
            }
            else
            {
                btnNotificationDetails.Text = "Submit";
                string message = "Record could'nt be Save ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }

        }
        protected void btnPossessionDetails_Click(object sender, EventArgs e)
        {
            if (ddlPossessionVillage.SelectedIndex == 0)
            {
                MessageBox1.ShowWarning("Please Select  Village Name");
                return;
            }
            if (txtPossessionDate.Text != "")
            {

            }
            else
            {
                txtPossessionDate.Focus();
                MessageBox1.ShowError("Please Enter Date of Possession");
                return;
            }
            if (LandID.Text.Trim().Length > 0)
            {
                objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
            }
            else
            {
                objServiceTimelinesBEL.LandID = 0;
            }

            objServiceTimelinesBEL.PossessionVillage = Convert.ToInt32((ddlPossessionVillage.SelectedValue.Trim()));
            if (txtPossessionDate.Text.Trim().Length > 0)
            {
                string strPossessionDate = DateTime.ParseExact(txtPossessionDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.PossessionDate = Convert.ToDateTime(strPossessionDate);
            }
            objServiceTimelinesBEL.PossessionArea = Convert.ToDecimal(string.IsNullOrEmpty(txtPossessionArea.Text.Trim()) ? "0" : txtPossessionArea.Text.Trim());
            objServiceTimelinesBEL.CreatedBy = UserName;

            DataSet ds = new DataSet();
            if (btnPossessionDetails.Text == "Submit")
            {
                Possassionlbl.Text = "0";
            }
            else if (btnPossessionDetails.Text == "Update")
            {
                objServiceTimelinesBEL.ResumptionOrderID = Convert.ToInt32(Possassionlbl.Text.Trim());
            }
            ds = objServiceTimelinesBLL.LAPossessionDetails(objServiceTimelinesBEL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                    LandID.Text = Session["LandID"].ToString();
                    if (Session["LandID"].ToString().Length > 0)
                    {
                        btnPossessionDetails.Text = "Submit";
                    }
                    GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                    ResetControlPossession();
                }
            }
            else
            {
                btnPossessionDetails.Text = "Submit";
                string message = "Record could'nt be Save ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }

        }

        protected void btnAwardDetails_Click(object sender, EventArgs e)
        {
            if (ddlFinalAwardsVillage.SelectedIndex == 0)
            {
                MessageBox1.ShowWarning("Please Select  Village Name");
                return;
            }
            if (LandID.Text.Trim().Length > 0)
            {
                objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
            }
            else
            {
                objServiceTimelinesBEL.LandID = 0;
            }
            if (txtAwardsDate.Text != "")
            {

            }
            else
            {
                txtAwardsDate.Focus();
                MessageBox1.ShowError("Please Enter Date of Award");
                return;
            }
            objServiceTimelinesBEL.AwardsVillageID = Convert.ToInt32((ddlFinalAwardsVillage.SelectedValue.Trim()));
            objServiceTimelinesBEL.AwardedArea = Convert.ToDecimal(string.IsNullOrEmpty(txtAwardedArea.Text.Trim()) ? "0" : txtAwardedArea.Text.Trim());

            objServiceTimelinesBEL.AwardedAmount = Convert.ToDecimal(string.IsNullOrEmpty(txtAmount.Text.Trim()) ? "0" : txtAmount.Text.Trim());
            if (txtAwardsDate.Text.Trim().Length > 0)
            {
                string strAwardsDate = DateTime.ParseExact(txtAwardsDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.DateofAwards = Convert.ToDateTime(strAwardsDate);

            }
            objServiceTimelinesBEL.Remarks = txtRemarks.Text.Trim();
            objServiceTimelinesBEL.CreatedBy = UserName;

            DataSet ds = new DataSet();
            if (btnAward.Text == "Submit")
            {
                ResumptionOrderIDlbl.Text = "0";
            }
            else if (btnAward.Text == "Update")
            {
                objServiceTimelinesBEL.AwardID = Convert.ToInt32(lblAwards.Text.Trim());
            }
            ds = objServiceTimelinesBLL.LAAwardsDetails(objServiceTimelinesBEL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                    LandID.Text = Session["LandID"].ToString();
                    if (Session["LandID"].ToString().Length > 0)
                    {
                        btnAward.Text = "Submit";
                    }
                    GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                    ResetControlAwardDetail();
                }
            }
            else
            {
                Session["LandID"] = "";
                btnAward.Text = "Submit";
                string message = "Record could'nt be Save ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }

        }

        protected void btnConveyenceDeed_Click(object sender, EventArgs e)
        {
            if (ddlConveyenceDeedVillageName.SelectedIndex == 0)
            {
                MessageBox1.ShowWarning("Please Select  Village Name");
                return;
            }
            if (LandID.Text.Trim().Length > 0)
            {
                objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
            }
            else
            {
                objServiceTimelinesBEL.LandID = 0;
            }
            objServiceTimelinesBEL.ConveyenceDeedVillageID = Convert.ToInt32((ddlConveyenceDeedVillageName.SelectedValue.Trim()));
            objServiceTimelinesBEL.ConveyenceArea = Convert.ToDecimal(string.IsNullOrEmpty(txtConveyenceArea.Text.Trim()) ? "0" : txtConveyenceArea.Text.Trim());
            objServiceTimelinesBEL.Execution = txtExecution.Text.Trim();
            objServiceTimelinesBEL.Registration = txtRegistration.Text.Trim();
            objServiceTimelinesBEL.Mutation = txtMutation.Text.Trim();
            objServiceTimelinesBEL.Initial = txtInitial.Text.Trim();
            objServiceTimelinesBEL.ConRemarks = txtConRemarks.Text.Trim();
            objServiceTimelinesBEL.CreatedBy = UserName;

            DataSet ds = new DataSet();
            if (btnConveyenceDeed.Text == "Submit")
            {
                lblConveyence.Text = "0";
            }
            else if (btnConveyenceDeed.Text == "Update")
            {
                objServiceTimelinesBEL.ConveyenceID = Convert.ToInt32(lblConveyence.Text.Trim());
            }
            ds = objServiceTimelinesBLL.LAConveyenceDetails(objServiceTimelinesBEL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                    LandID.Text = Session["LandID"].ToString();
                    if (Session["LandID"].ToString().Length > 0)
                    {
                        btnConveyenceDeed.Text = "Submit";
                    }
                    GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                    ResetControlConveyenceDeed();
                }
            }
            else
            {
                btnConveyenceDeed.Text = "Submit";
                string message = "Record could'nt be Save ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }
        }

        protected void btnPaymentDetails_Click(object sender, EventArgs e)
        {
            string listPaymentVillage = "";

            if (LandID.Text.Trim().Length > 0)
            {
                objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
            }
            else
            {
                objServiceTimelinesBEL.LandID = 0;
            }
            if (txtDraftDate.Text != "")
            {

            }
            else
            {
                txtDraftDate.Focus();
                MessageBox1.ShowError("Please Enter Draf Date");
                return;
            }
            foreach (ListItem VillageList in this.VillageList.Items)
            {
                if (VillageList.Selected == true)
                {
                    listPaymentVillage = listPaymentVillage + VillageList.Value + ",";
                }
            }
            objServiceTimelinesBEL.Village = listPaymentVillage.TrimEnd(',').Trim();
            objServiceTimelinesBEL.Details = txtDetails.Text.Trim();
            objServiceTimelinesBEL.DraftNo = txtDraftNo.Text.Trim();
            if (txtDraftDate.Text.Trim().Length > 0)
            {
                string strDraftDate = DateTime.ParseExact(txtDraftDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.DraftDate = Convert.ToDateTime(strDraftDate);
            }
            objServiceTimelinesBEL.PaymentTotalAmount = Convert.ToDecimal(string.IsNullOrEmpty(txtPaymentAmount.Text.Trim()) ? "0" : txtPaymentAmount.Text.Trim());
            objServiceTimelinesBEL.CreatedBy = UserName;
            DataSet ds = new DataSet();
            if (btnPaymentDetails.Text == "Submit")
            {
                lblPaymentID.Text = "0";
            }
            else if (btnPaymentDetails.Text == "Update")
            {
                objServiceTimelinesBEL.PaymentsID = Convert.ToInt32(lblPaymentID.Text.Trim());
            }
            ds = objServiceTimelinesBLL.LAPaymentDetails(objServiceTimelinesBEL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                    LandID.Text = Session["LandID"].ToString();
                    if (Session["LandID"].ToString().Length > 0)
                    {
                        btnPaymentDetails.Text = "Submit";
                    }
                    GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                    ResetControlPayment();
                }
            }
            else
            {
                btnPaymentDetails.Text = "Submit";
                string message = "Record could'nt be Save ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }
        }


        protected void btnCompansation_Click(object sender, EventArgs e)
        {
            if (ddlVillageCompansation.SelectedIndex == 0)
            {
                MessageBox1.ShowWarning("Please Select  Village Name");
                return;
            }
            if (LandID.Text.Trim().Length > 0)
            {
                objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
            }
            else
            {
                objServiceTimelinesBEL.LandID = 0;
            }
            objServiceTimelinesBEL.CompansationVillageID = Convert.ToInt32((ddlVillageCompansation.SelectedValue.Trim()));
            objServiceTimelinesBEL.CompansationAmount = Convert.ToDecimal(string.IsNullOrEmpty(txtCompansationAmount.Text.Trim()) ? "0" : txtCompansationAmount.Text.Trim());
            objServiceTimelinesBEL.CreatedBy = UserName;
            DataSet ds = new DataSet();
            if (btnCompansation.Text == "Submit")
            {
                lblCompansationID.Text = "0";
            }
            else if (btnCompansation.Text == "Update")
            {
                objServiceTimelinesBEL.CompansationID = Convert.ToInt32(lblCompansationID.Text.Trim());
            }
            ds = objServiceTimelinesBLL.LACompansationDetails(objServiceTimelinesBEL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                    LandID.Text = Session["LandID"].ToString();
                    if (Session["LandID"].ToString().Length > 0)
                    {
                        btnCompansation.Text = "Submit";
                    }
                    GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                    ResetControlCompansation();
                }
            }
            else
            {
                btnCompansation.Text = "Submit";
                string message = "Record could'nt be Save ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }
        }

        protected void btnLitigation_Click(object sender, EventArgs e)
        {
            if (ddlCaseType.SelectedIndex == 0)
            {
                MessageBox1.ShowWarning("Please Select  Case Type");
                return;
            }
            if (ddlCourttype.SelectedIndex == 0)
            {
                MessageBox1.ShowWarning("Please Select  Court Type");
                return;
            }
            if (LandID.Text.Trim().Length > 0)
            {
                objServiceTimelinesBEL.LandID = Convert.ToInt32(LandID.Text.Trim());
            }
            else
            {
                objServiceTimelinesBEL.LandID = 0;
            }
            objServiceTimelinesBEL.CaseName = txtCaseName.Text.Trim();
            objServiceTimelinesBEL.caseType = Convert.ToInt32(ddlCaseType.SelectedValue);
            objServiceTimelinesBEL.CourtType = Convert.ToInt32(ddlCourttype.SelectedValue);
            objServiceTimelinesBEL.Lawyer = txtLawyer.Text.Trim();
            objServiceTimelinesBEL.PartyName = txtPartyName.Text.Trim();
            objServiceTimelinesBEL.CreatedBy = UserName;
            DataSet ds = new DataSet();
            if (btnLitigation.Text == "Submit")
            {
                lblLitigationID.Text = "0";
            }
            else if (btnLitigation.Text == "Update")
            {
                objServiceTimelinesBEL.LitigationID = Convert.ToInt32(lblLitigationID.Text.Trim());
            }
            ds = objServiceTimelinesBLL.LALitigationDetails(objServiceTimelinesBEL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LandID"] = ds.Tables[0].Rows[0][0].ToString();
                    LandID.Text = Session["LandID"].ToString();
                    if (Session["LandID"].ToString().Length > 0)
                    {
                        btnLitigation.Text = "Submit";
                    }
                    GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(LandID.Text));
                    ResetControlLitigation();
                }
            }
            else
            {
                btnLitigation.Text = "Submit";
                string message = "Record could'nt be Save ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }
        }
        #endregion
        protected void New_Allottee_Registration_btn_click(object sender, EventArgs e)
        {
            Session["LandID"] = "";
            LandID.Text = Session["LandID"].ToString();
            ResetControl1();
            MultiView1.ActiveViewIndex = 1;
        }
        protected void Reset_ServerClick(object sender, EventArgs e)
        {
            ResetControl1();
        }

        #region GridOptionration
        protected void GridView1_pending_process_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewRow")
            {
                MultiView1.ActiveViewIndex = 9;
                hrefPrint.Visible = true;
                hrefPrint1.Visible = false;
                GetAllLandAcuisitionDetailsFilledById(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "Select_allotee_for_process")
            {

                string GridView1_pending_process_allotee_id = "";

                int index = Convert.ToInt32(e.CommandArgument);
                try
                {

                    GridView1_pending_process_allotee_id = (Convert.ToInt32(e.CommandArgument)).ToString();
                    lblNewButton.Text = "0";
                }
                catch
                {

                }
                Session["LandID"] = GridView1_pending_process_allotee_id;
                LandID.Text = Session["LandID"].ToString();
                GetAllLandAcuisitionDetailsFilledById(int.Parse(GridView1_pending_process_allotee_id));
                btn_first_save.Text = "Update";
                //Chooseplot.Visible = false;

                MultiView1.ActiveViewIndex = 1;
            }

            if (e.CommandName == "DeleteAllotteeRecords")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                int LandID = index;
                objServiceTimelinesBEL.dbId = LandID;

                DataSet ds = new DataSet();
                ds = objServiceTimelinesBLL.GetPreServiceDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    MessageBox1.ShowInfo("Applicant Apply for Another Service so Records will not Deactivate ");
                    return;
                }
                else
                {

                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteAllotteeRecords(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {

                            MessageBox1.ShowSuccess("Allottee Record Deactivated");
                            ViewState["Filter"] = drpdwnIA.SelectedValue;
                            GetNewAllotteeDetails();
                        }
                        else
                        {

                            MessageBox1.ShowError("Allottee Request Cannot Be Deleted!!!");
                            ViewState["Filter"] = drpdwnIA.SelectedValue;
                            GetNewAllotteeDetails();
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
        //protected void GridView1_pending_process_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1_pending_process.PageIndex = e.NewPageIndex;
        //    this.GetNewAllotteeDetails();
        //}
        protected void gvNotification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                string ResumptionOrderID = commandArgs[0];
                string LandID = commandArgs[1];
                string VillageName = commandArgs[2];
                ddlPossessionVillage.SelectedValue = VillageName;
                get_NotificationDetails(Convert.ToInt32(ResumptionOrderID));
            }
            if (e.CommandName == "DeleteNotification")
            {

                DataSet ds = new DataSet();
                string rowid = e.CommandArgument.ToString();
                objServiceTimelinesBEL.ResumptionOrderID = Convert.ToInt32(rowid);
                ds = objServiceTimelinesBLL.LANotificationDeleteDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    MessageBox1.ShowSuccess("Details of Notification/Resumption Orders Deactive successfully");
                    GridNotificationDetails(Convert.ToInt32(LandID.Text));
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;

                }
            }
        }

        protected void gvNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPossessionDetails.PageIndex = e.NewPageIndex;
            GridPossessionDetails(Convert.ToInt32(LandID.Text));
        }
        protected void gvPossessionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                string PossassionID = commandArgs[0];
                string LandID = commandArgs[1];
                string VillageName = commandArgs[2];
                ddlPossessionVillage.SelectedValue = VillageName;
                get_PossessionDetails(Convert.ToInt32(PossassionID));
            }
            if (e.CommandName == "DeletePossession")
            {
                DataSet ds = new DataSet();
                string rowid = e.CommandArgument.ToString();
                objServiceTimelinesBEL.PossessionID = Convert.ToInt32(rowid);
                ds = objServiceTimelinesBLL.LAPossessionDeleteDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    MessageBox1.ShowSuccess("Possession Details DeActive successfully");
                    GridPossessionDetails(Convert.ToInt32((LandID.Text)));
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;

                }
            }
        }

        protected void gvPossessionDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPossessionDetails.PageIndex = e.NewPageIndex;
            GridPossessionDetails(Convert.ToInt32(LandID.Text));
        }


        protected void gvAward_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                string AwardID = commandArgs[0];
                string LandID = commandArgs[1];
                string VillageName = commandArgs[2];
                ddlFinalAwardsVillage.SelectedValue = VillageName;
                get_PossessionDetails(Convert.ToInt32(AwardID));
            }
            if (e.CommandName == "DeleteAward")
            {
                DataSet ds = new DataSet();
                string rowid = e.CommandArgument.ToString();
                objServiceTimelinesBEL.AwardID = Convert.ToInt32(rowid);
                ds = objServiceTimelinesBLL.LAAwardDeleteDetails_sp(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    MessageBox1.ShowSuccess("Award Details DeActive successfully");
                    GridAwardDetails(Convert.ToInt32((LandID.Text)));
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;

                }
            }
        }

        protected void gvAward_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAward.PageIndex = e.NewPageIndex;
            GridAwardDetails(Convert.ToInt32(LandID.Text));
        }

        protected void gvConveyence_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                string ConveyenceID = commandArgs[0];
                string LandID = commandArgs[1];
                string VillageName = commandArgs[2];
                ddlConveyenceDeedVillageName.SelectedValue = VillageName;
                get_ConveyenceDetails(Convert.ToInt32(ConveyenceID));
            }
            if (e.CommandName == "DeleteConveyence")
            {
                DataSet ds = new DataSet();
                string rowid = e.CommandArgument.ToString();
                objServiceTimelinesBEL.ConveyenceID = Convert.ToInt32(rowid);
                ds = objServiceTimelinesBLL.LAConveyenceDeedsDeleteDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    MessageBox1.ShowSuccess("ConveyenceDeed Details DeActive successfully");
                    GridConveyenceDetails(Convert.ToInt32((LandID.Text)));
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;

                }
            }
        }

        protected void gvConveyence_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvConveyence.PageIndex = e.NewPageIndex;
            GridConveyenceDetails(Convert.ToInt32(LandID.Text));
        }

        protected void gvPaymentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                string PaymentID = commandArgs[0];
                string LandID = commandArgs[1];
                string VillageName = commandArgs[2];
                string[] ArrVillage = VillageName.Split(',');
                if (VillageName == "")
                {
                    VillageList.ClearSelection();
                }
                else
                {
                    for (int i = 0; i < ArrVillage.Length; i++)
                    {
                        VillageList.Items.FindByValue(ArrVillage[i]).Selected = true;
                    }
                }
                get_PaymentDetails(Convert.ToInt32(PaymentID));
            }
            if (e.CommandName == "DeletePayment")
            {
                DataSet ds = new DataSet();
                string rowid = e.CommandArgument.ToString();
                objServiceTimelinesBEL.LAPaymentID = Convert.ToInt32(rowid);
                ds = objServiceTimelinesBLL.LAPaymentDeleteDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    MessageBox1.ShowSuccess("Payment Details DeActive successfully");
                    GridPaymentDetails(Convert.ToInt32((LandID.Text)));
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;

                }
            }
        }

        protected void gvPaymentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentDetails.PageIndex = e.NewPageIndex;
            GridPaymentDetails(Convert.ToInt32(LandID.Text));
        }


        protected void gvCompansation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                string DistbursementID = commandArgs[0];
                string LandID = commandArgs[1];
                string VillageName = commandArgs[2];
                ddlVillageCompansation.SelectedValue = VillageName;
                get_CompansationDetails(Convert.ToInt32(DistbursementID));
            }
            if (e.CommandName == "DeleteCompansation")
            {
                DataSet ds = new DataSet();
                string rowid = e.CommandArgument.ToString();
                objServiceTimelinesBEL.DistbursementID = Convert.ToInt32(rowid);
                ds = objServiceTimelinesBLL.LACompansationDeleteDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    MessageBox1.ShowSuccess("Compansation Details DeActive successfully");
                    GridCompansationDetails(Convert.ToInt32((LandID.Text)));
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;

                }
            }
        }

        protected void gvCompansation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompansation.PageIndex = e.NewPageIndex;
            GridCompansationDetails(Convert.ToInt32(LandID.Text));
        }
        protected void gvLitigation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                string LitigationID = commandArgs[0];
                string LandID = commandArgs[1];
                get_LitigationDetails(Convert.ToInt32(LitigationID));
            }
            if (e.CommandName == "DeleteLitigation")
            {

                DataSet ds = new DataSet();
                string rowid = e.CommandArgument.ToString();
                objServiceTimelinesBEL.LitigationID = Convert.ToInt32(rowid);
                ds = objServiceTimelinesBLL.LALitigationDeleteDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    MessageBox1.ShowSuccess("Litigation Details Deactive successfully");
                    GridLitigationDetails(Convert.ToInt32((LandID.Text)));
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;

                }
            }
        }

        protected void gvLitigation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLitigation.PageIndex = e.NewPageIndex;
            GridLitigationDetails(Convert.ToInt32(LandID.Text));
        }
        #endregion
        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else if (MultiView1.ActiveViewIndex == 1)
            {
                btn_first_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                btnNotificationDetails_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 3)
            {
                btnPossessionDetails_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 4)
            {
                btnAwardDetails_Click(null, null);
            }

            else if (MultiView1.ActiveViewIndex == 5)
            {
                btnConveyenceDeed_Click(null, null);
            }

        }



        protected void next_server_click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                if (btnNextNotification.Enabled == true)
                {
                    btnNextNotification_Click(null, null);
                }
            }
            else if (MultiView1.ActiveViewIndex == 1)
            {
                btnNextResumption_Click(null, null);

            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                btnNextPossession_Click(null, null);
            }

            else if (MultiView1.ActiveViewIndex == 3)
            {
                btnNextPayment_Click(null, null);
            }

            else if (MultiView1.ActiveViewIndex == 4)
            {
                btnNextPayment_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 5)
            {
                btnNextPayment_Click1(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 6)
            {
                btnNextDistoursement_Click(null, null);
            }

            else if (MultiView1.ActiveViewIndex == 7)
            {
                btnNextLitigation_Click(null, null);
            }

            else if (MultiView1.ActiveViewIndex == 8)
            {
                btnNextFinalView_Click(null, null);
            }


        }

        #region NextButton
        protected void btnNextNotification_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void btnNextResumption_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void btnNextPossession_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void btnNextPayment_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void btnNextPayment_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void btnNextDistoursement_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 7;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        protected void btnNextLitigation_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 8;
        }

        protected void btnNextFinalView_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 9;
            hrefPrint.Visible = true;
            hrefPrint1.Visible = true;
        }
        #endregion

        #region PreviousButton
        protected void Previous_home_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void Previous_Basic_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void Previous_Notificatin_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        protected void Previous_Possession_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }
        protected void btnPrePossessionDetail_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }
        protected void Previous_Awards_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void btnPrePossessionDetail_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
        }
        protected void btnpreConveyence_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
        }

        protected void btnPrePaymentDetails_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 7;
        }

        protected void btnPreDistoursementofCompansation_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 8;
        }

        protected void btnPrevLitigation_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 9;
        }
        #endregion
        protected void prev_server_click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                Previous_home_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 1)
            {
                Previous_Basic_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                Previous_Notificatin_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 3)
            {
                Previous_Possession_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 4)
            {
                btnPrePossessionDetail_Click(null, null);
            }

            else if (MultiView1.ActiveViewIndex == 5)
            {
                Previous_Awards_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 6)
            {
                btnPrePossessionDetail_Click1(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 7)
            {
                btnpreConveyence_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 8)
            {
                btnPrePaymentDetails_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 9)
            {
                btnPreDistoursementofCompansation_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 10)
            {
                btnPrevLitigation_Click(null, null);
            }
        }

        public bool ValidateDate(string dateInput)
        {
            try
            {
                DateTime dt3;
                if (DateTime.TryParseExact(dateInput,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}



