using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_Assesment_Entry_BP : System.Web.UI.UserControl
    {


        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        public int PacketId { get; set; }
        public string ServiceReqNo { get; set; }
        int UserId = 0; string UserName = "";


        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

            }
            catch { Response.Redirect("Default.aspx", false); }



            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd;
            Get_EvaluationCheckListData_ForPacketApplicant();

            if (!IsPostBack)
            {
                GetBPBylawsByArea();
                get_drp_permisesUse();
                BindHazardDdl();
                GetInspectorGrid();
            }

            GetServiceRequestBPDetail(ServiceReqNo);
            RiskAssesment();
            BindInsepectorRequestGridView();


        }


        #region Inspector

        public void GetInspectorGrid()
        {
            GeneralMethod gm = new GeneralMethod();
            DataTable dt = new DataTable();
            dt = gm.bind_Inspector(ServiceReqNo);

            drpInspector.DataSource = dt;
            drpInspector.DataTextField = "EmployeeName";
            drpInspector.DataValueField = "userId";
            drpInspector.DataBind();
            drpInspector.Items.Insert(0, new ListItem("--Select Inspector--", "0"));
        }


        protected void InspectorSelecor_Click(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            string TicketCreationResult = gm.ServiceTicketCreationForSpecificService(PacketId, ServiceReqNo, int.Parse(drpInspector.SelectedValue), 10);
            MessageBox1.ShowInfo(TicketCreationResult);
        }

        private void BindInsepectorRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.RequestReportType = "View";
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                ds = objServiceTimelinesBLL.GetInspectorRequestRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
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

        #endregion




        public void get_drp_permisesUse()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("select id, UseSubZoneCode, PermisesUse from  [DevelopmentCodesLandUsePermissibilityUsePremises]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                drp_permisesUse.DataSource = dt;
                drp_permisesUse.DataTextField = "PermisesUse";
                drp_permisesUse.DataValueField = "id";
                drp_permisesUse.DataBind();

                drp_permisesUse.Items.Insert(0, new ListItem("----", "0"));
            }
            catch { }
        }

        public void GetServiceRequestBPDetail(string servicereqid)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            objServiceTimelinesBEL.ServiceRequest = servicereqid;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceRequestBPDetail(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    //txtNameTechnical.Text = ds.Tables[0].Rows[0]["NameofArchitect"].ToString();
                    //txtLicensedPerson.Text = ds.Tables[0].Rows[0]["ArchitectLicenseNo"].ToString();
                    //txtRegistration.Text = ds.Tables[0].Rows[0]["ArchitectRegistrationNo"].ToString();
                    //txtAddressPerson.Text = ds.Tables[0].Rows[0]["ArchitectAddress"].ToString();

                    //txtStructuralEngineer.Text = ds.Tables[0].Rows[0]["NameofStructuralEngineer"].ToString();
                    //txtStructuralEngineerLicensedNo.Text = ds.Tables[0].Rows[0]["StructuralEngineerLicensedNo"].ToString();
                    //txtStructuralEngineerRegistratinNo.Text = ds.Tables[0].Rows[0]["StructuralEngineerRegistratinNo"].ToString();
                    //txtStructuralEngineerAddress.Text = ds.Tables[0].Rows[0]["StructuralEngineerAddress"].ToString();


                    lblPlotSize.Text = ds.Tables[0].Rows[0]["totalPlotArea"].ToString();


                    txtFar_lbl.Text = ds.Tables[0].Rows[0]["far"].ToString().Trim();
                    txtGroundcover_lbl.Text = ds.Tables[0].Rows[0]["GroundCoverage"].ToString().Trim();
                    txtSetBackFront_lbl.Text = ds.Tables[0].Rows[0]["front"].ToString().Trim();
                    txtSetBackRear_lbl.Text = ds.Tables[0].Rows[0]["rear"].ToString().Trim();
                    txtSetBackSide1_lbl.Text = ds.Tables[0].Rows[0]["side1"].ToString().Trim();
                    txtSetBackSide2_lbl.Text = ds.Tables[0].Rows[0]["side2"].ToString().Trim();
                    txtHeight_lbl.Text = ds.Tables[0].Rows[0]["Height"].ToString().Trim();
                    txtOccupancy_lbl.Text = ds.Tables[0].Rows[0]["Occupancy"].ToString().Trim();


                    ///////////////  Updated by Mr Manish
                    txtBaseMent1.Text = ds.Tables[0].Rows[0]["ExistingBasement"].ToString().Trim();
                    txtBaseMent2.Text = ds.Tables[0].Rows[0]["ProposedBasement"].ToString().Trim();
                    txtGround1.Text = ds.Tables[0].Rows[0]["ExistingGroundFloor"].ToString().Trim();
                    txtGround2.Text = ds.Tables[0].Rows[0]["ProposedGroundFloor"].ToString().Trim();
                    txtFirstfloor1.Text = ds.Tables[0].Rows[0]["ExistingFirstFloor"].ToString().Trim();
                    txtFirstfloor2.Text = ds.Tables[0].Rows[0]["ProposedFirstFloor"].ToString().Trim();
                    txtSecondFloor1.Text = ds.Tables[0].Rows[0]["ExistingSecondFloor"].ToString().Trim();
                    txtSecondFloor2.Text = ds.Tables[0].Rows[0]["ProposedSecondFloor"].ToString().Trim();

                    txtMezzanine1.Text = ds.Tables[0].Rows[0]["ExistingMezzanineFloor"].ToString().Trim();
                    txtMezzanine2.Text = ds.Tables[0].Rows[0]["ProposedMezzanineFloor"].ToString().Trim();
                    txtFoundation.Text = ds.Tables[0].Rows[0]["Foundation"].ToString().Trim();
                    txtWalls.Text = ds.Tables[0].Rows[0]["Walls"].ToString().Trim();
                    txtFloors.Text = ds.Tables[0].Rows[0]["Floors"].ToString().Trim();
                    txtRoofs.Text = ds.Tables[0].Rows[0]["Roofs"].ToString().Trim();

                    txtStories.Text = ds.Tables[0].Rows[0]["NoofStories"].ToString().Trim();
                    txtLatrines.Text = ds.Tables[0].Rows[0]["NoofLatrines"].ToString().Trim();

                    txtbuildingPurpose.Text = ds.Tables[0].Rows[0]["PurposeofBuildingUse"].ToString().Trim();
                    txtPreviousConstruction.Text = ds.Tables[0].Rows[0]["PreviousConstruction"].ToString().Trim();
                    txtWaterSource.Text = ds.Tables[0].Rows[0]["SourceofWater"].ToString().Trim();
                    ///////////////////////////////



                    try
                    {
                        ddlNature.SelectedValue = ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim();
                        ddlNature_lbl.Text = ddlNature.SelectedItem.Text;
                    }
                    catch { }

                    try
                    {
                        drp_permisesUse.SelectedValue = ds.Tables[0].Rows[0]["PermisesUse"].ToString().Trim();
                        drp_permisesUse_lbl.Text = drp_permisesUse.SelectedItem.Text;
                    }
                    catch { }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        public void GetBPBylawsByArea()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            objServiceTimelinesBEL.UsepermisesCode = drp_permissibility.SelectedValue;

            float plotsize = 0;
            try
            {
                plotsize = float.Parse(lblPlotSize.Text);

            }
            catch { }
            objServiceTimelinesBEL.totalPlotArea = plotsize;




            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetBPBylawsByArea(objServiceTimelinesBEL);


                if (ds.Tables[0].Rows.Count > 0)
                {

                    lblFarByelaws.Text = ds.Tables[0].Rows[0]["far"].ToString().Trim();
                    lblGroundBylo.Text = ds.Tables[0].Rows[0]["ground_coverage_percentage"].ToString().Trim();
                    lblSetBackFront.Text = ds.Tables[0].Rows[0]["front"].ToString().Trim();
                    lblSetBackRear.Text = ds.Tables[0].Rows[0]["rear"].ToString().Trim();
                    lblSetBackSide1.Text = ds.Tables[0].Rows[0]["side1"].ToString().Trim();
                    lblSetBackSide2.Text = ds.Tables[0].Rows[0]["side2"].ToString().Trim();

                }

            }
            catch { }

        }

        protected void Get_EvaluationCheckListData_ForPacketApplicant()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("Get_ServiceTicketChecklistBP '" + PacketId + "' , '" + ServiceReqNo + "'  ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    txtFar.Text = dt.Rows[0]["far"].ToString().Trim();
                    txtGroundcover.Text = dt.Rows[0]["ground_coverage_percentage"].ToString().Trim();
                    txtSetBackFront.Text = dt.Rows[0]["front"].ToString().Trim();
                    txtSetBackRear.Text = dt.Rows[0]["rear"].ToString().Trim();
                    txtSetBackSide1.Text = dt.Rows[0]["side1"].ToString().Trim();
                    txtSetBackSide2.Text = dt.Rows[0]["side2"].ToString().Trim();
                    try { drp_permissibility.SelectedValue = dt.Rows[0]["Permissibility"].ToString().Trim(); } catch { }

                }

            }
            catch { }

        }


        protected void Set_EvaluationCheckListData_ForPacketApplicant(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            objServiceTimelinesBEL.UserId = UserId;
            objServiceTimelinesBEL.packetID = PacketId;
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

            try { objServiceTimelinesBEL.Far = float.Parse(txtFar.Text); } catch { }
            try { objServiceTimelinesBEL.Groundcover = float.Parse(txtGroundcover.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackFront = float.Parse(txtSetBackFront.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackRear = float.Parse(txtSetBackRear.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackSide1 = float.Parse(txtSetBackSide1.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackSide2 = float.Parse(txtSetBackSide2.Text); } catch { }


            //try { objServiceTimelinesBEL.Height = float.Parse(txtHeight.Text); } catch { }
            //try { objServiceTimelinesBEL.Occupancy = float.Parse(txtOccupancy.Text); } catch { }            
            //objServiceTimelinesBEL.NatureofOccupancy = ddlNature.SelectedValue.Trim();



            objServiceTimelinesBEL.Permissibility = (drp_permissibility.SelectedValue.Trim());
            objServiceTimelinesBEL.ModifiedBy = UserId.ToString();
            objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;


            /////////////////  Update By Mr Manish
            objServiceTimelinesBEL.ExistingBasement = (txtBaseMent1.Text);
            objServiceTimelinesBEL.ExistingGroundFloor = (txtGround1.Text.Trim());
            objServiceTimelinesBEL.ExistingFirstFloor = (txtFirstfloor1.Text.Trim());
            objServiceTimelinesBEL.ExistingSecondFloor = (txtSecondFloor1.Text.Trim());
            objServiceTimelinesBEL.ExistingMezzanineFloor = (txtMezzanine1.Text.Trim());
            objServiceTimelinesBEL.ProposedBasement = (txtBaseMent2.Text.Trim());
            objServiceTimelinesBEL.ProposedGroundFloor = (txtGround2.Text.Trim());
            objServiceTimelinesBEL.ProposedFirstFloor = (txtFirstfloor2.Text.Trim());
            objServiceTimelinesBEL.ProposedSecondFloor = (txtSecondFloor2.Text.Trim());
            objServiceTimelinesBEL.ProposedMezzanineFloor = (txtMezzanine2.Text.Trim());
            objServiceTimelinesBEL.Foundation = (txtFoundation.Text.Trim());
            objServiceTimelinesBEL.Floors = (txtFloors.Text.Trim());
            objServiceTimelinesBEL.Walls = (txtWalls.Text.Trim());
            objServiceTimelinesBEL.Roofs = (txtRoofs.Text.Trim());
            objServiceTimelinesBEL.NoofLatrines = (txtLatrines.Text.Trim());
            objServiceTimelinesBEL.NoofStories = (txtStories.Text.Trim());
            objServiceTimelinesBEL.PurposeofBuildingUse = (txtbuildingPurpose.Text.Trim());
            objServiceTimelinesBEL.PreviousConstruction = (txtPreviousConstruction.Text.Trim());
            objServiceTimelinesBEL.SourceofWater = (txtWaterSource.Text.Trim());

            ////////////////////////////////////////////////////////////////////


            try
            {
                int retVal = objServiceTimelinesBLL.Set_ServiceTicketChecklistBP(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "alert('Updated')", true);
                }
                else
                {
                    string message = "Record couldnt be  Save ";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }


        }

        protected void drp_permissibility_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBPBylawsByArea();
            Assessment aks = new Assessment();
        }

        protected void BindHazardDdl()
        {
            SqlCommand cmd = new SqlCommand("spGetBuildingTypeDetail", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            ddlNature.DataSource = dt;
            ddlNature.DataTextField = "Classification";
            ddlNature.DataValueField = "ID";
            ddlNature.DataBind();
        }


        #region RiskAssesment
        public void RiskAssesment()
        {
            int risk0 = 0; int risk1 = 0; int risk2 = 0; int risk = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("select ID , Classification ,HazardStatus from   Master_IndustryBasedHazard  where ID = '" + ddlNature.SelectedValue + "'  ", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                string HazardStatus = "";
                if (dt.Rows.Count > 0) { HazardStatus = dt.Rows[0]["HazardStatus"].ToString(); }

                if (HazardStatus == "Low") { risk2 = 0; riskDetail.Text = riskDetail.Text + "Degree Of Hazards: Low Risk<br/>"; }
                else if (HazardStatus == "Moderate") { risk2 = 1; riskDetail.Text = riskDetail.Text + "Degree Of Hazards: Moderate Risk<br/>"; }
                else if (HazardStatus == "High") { risk2 = 2; riskDetail.Text = riskDetail.Text + "Degree Of Hazards: High Risk<br/>"; }

            }
            catch { }

            try
            {
                if (Convert.ToDecimal(txtHeight_lbl.Text) <= 10)
                {
                    risk0 = 0;
                }
                else if (Convert.ToDecimal(txtHeight_lbl.Text) <= 15)
                {
                    risk0 = 1;
                }
                else if (Convert.ToDecimal(txtHeight_lbl.Text) > 15)
                {
                    risk0 = 2;
                }

            }
            catch { }

            try
            {
                if (Convert.ToDecimal(txtOccupancy_lbl.Text) <= 50)
                {
                    risk1 = 0;
                }
                else if (Convert.ToDecimal(txtHeight_lbl.Text) <= 100)
                {
                    risk1 = 1;
                }
                else if (Convert.ToDecimal(txtHeight_lbl.Text) > 100)
                {
                    risk1 = 2;
                }

            }
            catch { }



            switch (risk0)
            {
                case 0: Height_Risklbl.Text = "Low"; Height_Risklbl.Attributes.Add("style", "display:block;background-color:green;height:27px;"); break;
                case 1: Height_Risklbl.Text = "Moderate"; Height_Risklbl.Attributes.Add("style", "display:block; background-color:yellow;height:27px;"); break;
                case 2: Height_Risklbl.Text = "High"; Height_Risklbl.Attributes.Add("style", "display:block; background-color:red;height:27px;"); break;
            }

            switch (risk1)
            {
                case 0: Occupancy_Risklbl.Text = "Low"; Occupancy_Risklbl.Attributes.Add("style", "display:block;background-color:green;height:27px;"); break;
                case 1: Occupancy_Risklbl.Text = "Moderate"; Occupancy_Risklbl.Attributes.Add("style", "display:block;background-color:yellow;height:27px;"); break;
                case 2: Occupancy_Risklbl.Text = "High"; Occupancy_Risklbl.Attributes.Add("style", "display:block;background-color:red;height:27px;"); break;
            }


            switch (risk2)
            {
                case 0: ddlNature_Risklbl.Text = "Low"; ddlNature_Risklbl.Attributes.Add("style", "display:block; background-color:green;height:27px;"); break;
                case 1: ddlNature_Risklbl.Text = "Moderate"; ddlNature_Risklbl.Attributes.Add("style", "display:block;background-color:yellow;height:27px;"); break;
                case 2: ddlNature_Risklbl.Text = "High"; ddlNature_Risklbl.Attributes.Add("style", "display:block;background-color:red;height:27px;"); break;
            }


            risk = Math.Max(risk0, risk1);
            risk = Math.Max(risk, risk2);


            if (risk == 0) { lblRisk.Text = "Low"; lblRisk.Attributes.Add("style", "display:block;background-color:green;height:27px;"); }
            if (risk == 1) { lblRisk.Text = "Medium"; lblRisk.Attributes.Add("style", "display:block;background-color:yellow;height:27px;"); }
            if (risk == 2) { lblRisk.Text = "High"; lblRisk.Attributes.Add("style", "display:block;background-color:red;height:27px;"); }

        }

        protected void lblRisk_Click(object sender, EventArgs e)
        {
            MessageBox1.ShowInfo(riskDetail.Text);
        }

        #endregion

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                    int total_len = 0;
                    try
                    {
                        total_len = Convert.ToInt32(((Label)e.Row.FindControl("file_name")).Text.ToString().Length);
                    }
                    catch { }

                    if (total_len > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;
                    }
                }
            }
            catch
            {
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[Convert.ToInt32(e.CommandArgument)];

            if (e.CommandName == "selectDocument")
            {
                DataSet ds = new DataSet();
                try
                {
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                    objServiceTimelinesBEL.RequestReportType = "View";
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                    ds = objServiceTimelinesBLL.GetInspectorRequestRecords(objServiceTimelinesBEL);

                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
        }

        private void download(DataTable dt)
        {
            try
            {

                Response.Clear();
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString().Trim();
                Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ColName"].ToString().Trim());
                string filename = dt.Rows[0]["ColName"].ToString().Trim();


                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}