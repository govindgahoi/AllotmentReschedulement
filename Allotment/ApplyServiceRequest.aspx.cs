using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;





namespace Allotment
{
    public partial class ApplyServiceRequest : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "", AllottementLetterNo = "", service_id = "";


        UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail = new UC_Service_Allotteee_Detail();
        UC_Service_Building_Plan UC_Service_Building_Plan = new UC_Service_Building_Plan();
        UC_Service_WaterConnection UC_Service_WaterConnection;
        UC_Service_Plot_Transfer UC_Service_Plot_Transfer;

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



            AllottementLetterNo = (string)ViewState["AllottementLetterNo"];

            string SerReqID_in = Request.QueryString["serviceId"];
            string SerID_in = Request.QueryString["id"];
            string SerReqID = HttpUtility.HtmlDecode(SerReqID_in);

            if (!IsPostBack)
            {
                UserSpecificBinding();
            }

            service_id = SerID_in;





            if (string.IsNullOrEmpty(SerReqID))
            {
                lblserRequest.Text = SerID_in;

                // UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                // Placeholder1.Controls.Add(UC_Service_Building_Plan);
                // UC_Service_Building_Plan.SerReqID = SerReqID;
                // UC_Service_Building_Plan.SerID_in = SerID_in;
                // UC_Service_Building_Plan.UserBy = UserName;
                // UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;

            }
            else
            {
                lblserRequest.Text = SerReqID;
                string[] SerIdarray = lblserRequest.Text.Split('/');

                string alloteeid = SerIdarray[2];



                service_id = SerIdarray[1];

                lbl_service_no.Text = lblserRequest.Text;




                //switch (service_id.ToString())
                //{
                //    case "1" :
                //        {
                //            UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                //            Placeholder1.Controls.Add(UC_Service_Building_Plan);
                //            UC_Service_Building_Plan.SerReqID = SerReqID;
                //            UC_Service_Building_Plan.SerID_in = SerID_in;
                //            UC_Service_Building_Plan.UserBy = UserName;
                //            UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;
                //            break;
                //        }


                //    case "2":
                //        {
                //            UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                //            Placeholder1.Controls.Add(UC_Service_Building_Plan);
                //            UC_Service_Building_Plan.SerReqID = SerReqID;
                //            UC_Service_Building_Plan.SerID_in = SerID_in;
                //            UC_Service_Building_Plan.UserBy = UserName;
                //            UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;
                //            break;
                //        }

                //    case "3":
                //        {
                //            UC_Service_WaterConnection = LoadControl("~/UC_Service_WaterConnection.ascx") as UC_Service_WaterConnection;
                //            Placeholder1.Controls.Add(UC_Service_WaterConnection);
                //            UC_Service_WaterConnection.SerReqID = SerReqID;
                //            UC_Service_WaterConnection.SerID_in = SerID_in;
                //            UC_Service_WaterConnection.UserBy = UserName;
                //            UC_Service_WaterConnection.AllottementLetterNo = AllottementLetterNo;
                //            break;

                //        }

                //    case "4":
                //        {
                //            UC_Service_Plot_Transfer = LoadControl("~/UC_Service_Plot_Transfer.ascx") as UC_Service_Plot_Transfer;
                //            Placeholder1.Controls.Add(UC_Service_Plot_Transfer);
                //            UC_Service_Plot_Transfer.SerReqID = SerReqID;
                //            UC_Service_Plot_Transfer.SerID_in = SerID_in;
                //            UC_Service_Plot_Transfer.UserBy = UserName;
                //            UC_Service_Plot_Transfer.AllottementLetterNo = AllottementLetterNo;
                //            break;
                //        }        
                //}




                SqlCommand cmd = new SqlCommand("SELECT Allotmentletterno , case when rtrim(ltrim(isnull([AllotteeName],''))) > '' then [AllotteeName] else  [CompanyName] end  'allotee_name'    FROM AllotteeMaster   WHERE AllotteeID  ='" + alloteeid + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                adp.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    AllottementLetterNo = dt1.Rows[0]["Allotmentletterno"].ToString();
                    lbl_allottee.Text = dt1.Rows[0]["allotee_name"].ToString();
                }

            }


            switch (service_id.ToString())
            {

                case "1":
                    {
                        UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                        Placeholder1.Controls.Add(UC_Service_Building_Plan);
                        UC_Service_Building_Plan.SerReqID = SerReqID;
                        UC_Service_Building_Plan.SerID_in = SerID_in;
                        UC_Service_Building_Plan.UserBy = UserName;
                        UC_Service_Building_Plan.page_type = "ENTRY";
                        UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;
                        break;
                    }

                case "2":
                    {
                        UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                        Placeholder1.Controls.Add(UC_Service_Building_Plan);
                        UC_Service_Building_Plan.SerReqID = SerReqID;
                        UC_Service_Building_Plan.SerID_in = SerID_in;
                        UC_Service_Building_Plan.UserBy = UserName;
                        UC_Service_Building_Plan.page_type = "ENTRY";
                        UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;
                        break;
                    }

                case "3":
                    {
                        UC_Service_WaterConnection = LoadControl("~/UC_Service_WaterConnection.ascx") as UC_Service_WaterConnection;
                        Placeholder1.Controls.Add(UC_Service_WaterConnection);
                        UC_Service_WaterConnection.SerReqID = SerReqID;
                        UC_Service_WaterConnection.SerID_in = SerID_in;
                        UC_Service_WaterConnection.UserBy = UserName;
                        UC_Service_Building_Plan.page_type = "ENTRY";
                        UC_Service_WaterConnection.AllottementLetterNo = AllottementLetterNo;
                        break;
                    }

                case "4":
                    {
                        UC_Service_Plot_Transfer = LoadControl("~/UC_Service_Plot_Transfer.ascx") as UC_Service_Plot_Transfer;
                        Placeholder1.Controls.Add(UC_Service_Plot_Transfer);
                        UC_Service_Plot_Transfer.SerReqID = SerReqID;
                        UC_Service_Plot_Transfer.SerID_in = SerID_in;
                        UC_Service_Plot_Transfer.UserBy = UserName;
                        UC_Service_Plot_Transfer.page_type = "ENTRY";
                        UC_Service_Plot_Transfer.AllottementLetterNo = AllottementLetterNo;
                        break;
                    }
            }



            switch (service_id.ToString())
            {
                case "1":
                    {
                        lbl_service_name.Text = "Building Plan Approval -Construction Permits";
                        break;
                    }


                case "2":
                    {
                        lbl_service_name.Text = "Building Plan Approval-Occupancy/ Completion Certificate";
                        break;
                    }

                case "3":
                    {
                        lbl_service_name.Text = "Water Connection";
                        break;
                    }

                case "4":
                    {
                        lbl_service_name.Text = "Plot Transfer";
                        break;
                    }
            }




        }





        #region office_ia_plot_binding

        protected void UserSpecificBinding()
        {

            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                Regional_Changed(null, null);
                if (dsR.Tables[1].Rows[0][0].ToString() == "View")
                {
                    //         Allottee_master_grid.Columns[9].Visible = true;
                }
                else
                {
                    //       Allottee_master_grid.Columns[9].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }

            //   Refesh(true);
            //   ResetControl();

        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();



                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }

                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }
                //      GetNewAllotteeDetails();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }



        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand cmd1 = new SqlCommand("SELECT AllotteeID, Allotmentletterno ,  case when rtrim(ltrim(isnull(Sector,''))) >'' then   (rtrim(ltrim(PlotNo)) + ' ('+rtrim(ltrim(isnull(Sector,'')))+')')  else (rtrim(ltrim(PlotNo))) end as PlotText  ,   (rtrim(ltrim(PlotNo)) + '('+rtrim(ltrim(isnull(Sector,'')))+')')  as PlotNo FROM [dbo].[AllotteeMaster]  where [IndustrialArea] ='" + drpdwnIA.SelectedItem.Text.Trim() + "'  order by Sector,PlotNo ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd1);
            DataTable prc1 = new DataTable();
            adp.Fill(prc1);

            ddlPlotNo.DataSource = prc1;
            ddlPlotNo.DataTextField = "PlotText";
            ddlPlotNo.DataValueField = "PlotNo";
            ddlPlotNo.DataBind();
            ViewState["Filter"] = drpdwnIA.SelectedItem.Text;
            try { dddlPlotNo_SelectedIndexChanged(null, null); } catch { }
        }


        protected void dddlPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT AllotteeID, Allotmentletterno , PlotNo  FROM [dbo].[AllotteeMaster]  where [IndustrialArea] ='" + drpdwnIA.SelectedItem.Text.Trim() + "' and   (rtrim(ltrim(PlotNo)) + '('+rtrim(ltrim(isnull(Sector,'')))+')') =  '" + ddlPlotNo.SelectedValue + "' and isnull(iscompleted,0)=1 ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                DataTable prc1 = new DataTable();
                adp.Fill(prc1);

                if (prc1.Rows.Count > 0)
                {
                    ViewState["AllottementLetterNo"] = prc1.Rows[0]["Allotmentletterno"].ToString();
                    fill_data(prc1.Rows[0]["Allotmentletterno"].ToString());
                }
                else
                {
                    ViewState["AllottementLetterNo"] = "";
                    fill_data("");
                }
            }
            catch
            {
                ViewState["AllottementLetterNo"] = "";
                fill_data("");
            }
        }

        private void fill_data(string Allotmentletterno)
        {
            switch (service_id.ToString())
            {
                case "1":
                    {
                        UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;
                        UC_Service_Building_Plan.Page_Load(null, null);
                        break;
                    }

                case "2":
                    {
                        UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;
                        UC_Service_Building_Plan.Page_Load(null, null);
                        break;
                    }

                case "3":
                    {
                        UC_Service_WaterConnection.AllottementLetterNo = AllottementLetterNo;
                        UC_Service_WaterConnection.Page_Load(null, null);
                        break;
                    }

                case "4":
                    {
                        UC_Service_Plot_Transfer.AllottementLetterNo = AllottementLetterNo;
                        UC_Service_Plot_Transfer.Page_Load(null, null);
                        break;
                    }
            }

        }

        #endregion

    }
}