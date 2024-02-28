using System;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_BuildingDetails : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        public string SerReqID { get; set; }
        public string HiddenClassNameEx { get; private set; }
        public string HiddenClassNamePr { get; private set; }
        #endregion
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetServiceRequestBPDetail(SerReqID);
            string[] SerIdarray = SerReqID.Split('/');
            if (SerIdarray[1] == "1")
            {
                HiddenClassNameEx = "display:none;";
            }
            else
            {
                HiddenClassNamePr = "display:none;";
            }
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


                    lblPlotSize.Text = ds.Tables[0].Rows[0]["totalPlotArea"].ToString();

                    txtFar.Text = ds.Tables[0].Rows[0]["far"].ToString().Trim();
                    txtGroundcover.Text = ds.Tables[0].Rows[0]["GroundCoverage"].ToString().Trim();
                    txtSetBackFront.Text = ds.Tables[0].Rows[0]["front"].ToString().Trim();
                    txtSetBackRear.Text = ds.Tables[0].Rows[0]["rear"].ToString().Trim();
                    txtSetBackSide1.Text = ds.Tables[0].Rows[0]["side1"].ToString().Trim();
                    txtSetBackSide2.Text = ds.Tables[0].Rows[0]["side2"].ToString().Trim();
                    txtHeight.Text = ds.Tables[0].Rows[0]["Height"].ToString().Trim();
                    txtOccupancy.Text = ds.Tables[0].Rows[0]["Occupancy"].ToString().Trim();
                    txtCoveredArea.Text = ds.Tables[0].Rows[0]["CoveredArea"].ToString().Trim();
                    txtStealth.Text = ds.Tables[0].Rows[0]["StiltFloor"].ToString().Trim();
                    txtMumti.Text = ds.Tables[0].Rows[0]["Mumti"].ToString().Trim();
                    ///////////////  Updated by Mr. Manish
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
                    string TemporaryStructExist = ds.Tables[0].Rows[0]["TemporaryStructExists"].ToString().Trim();
                    if (TemporaryStructExist.Trim() == "True")
                    {
                        drpTemoraryStructure.SelectedValue = "1";
                        TemporaryStructureUse.Visible = true;
                    }
                    else
                    {
                        drpTemoraryStructure.SelectedValue = "0";
                        TemporaryStructureUse.Visible = false;
                    }
                    txtHutment.Text = ds.Tables[0].Rows[0]["LabourHutmentArea"].ToString().Trim();
                    txtOtherCharges.Text = ds.Tables[0].Rows[0]["AreaOtherUse"].ToString().Trim();


                    try
                    {
                        ddlNature.SelectedValue = ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim();
                    }
                    catch { }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        string Type = ds.Tables[2].Rows[0]["BPType"].ToString();
                        if (Type == "3")
                        {
                            RevisionDetailsTbl.Visible = true;
                            MalbaPaid_lbl.Text = ds.Tables[0].Rows[0]["MalbachargesPaid"].ToString().Trim();
                            InfraPaid_lbl.Text = ds.Tables[0].Rows[0]["InfraChargesPaid"].ToString().Trim();
                            prevAppBPArea_lbl.Text = ds.Tables[0].Rows[0]["PrevAppBuiltUpArea"].ToString().Trim();
                        }
                    }

                }
                if (ds.Tables[1].Rows.Count > 0)
                {

                    lblFarByelaws.Text = ds.Tables[1].Rows[0]["far"].ToString().Trim();
                    lblGroundBylo.Text = ds.Tables[1].Rows[0]["ground_coverage_percentage"].ToString().Trim();
                    lblSetBackFront.Text = ds.Tables[1].Rows[0]["front"].ToString().Trim();
                    lblSetBackRear.Text = ds.Tables[1].Rows[0]["rear"].ToString().Trim();
                    lblSetBackSide1.Text = ds.Tables[1].Rows[0]["side1"].ToString().Trim();
                    lblSetBackSide2.Text = ds.Tables[1].Rows[0]["side2"].ToString().Trim();

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


    }
}