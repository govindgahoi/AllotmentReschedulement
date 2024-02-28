using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public delegate void SendMessageToThePageHandler(string messageToThePage);
    public partial class uc_data_lock : System.Web.UI.UserControl
    {

        private string strCallee;
        public event SendMessageToThePageHandler sendMessageToThePage;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion



        public string caseID { get; set; }
        public string userID { get; set; }
        public string IAID { get; set; }
        public string ServiceID { get; set; }
        public int RespondentID { get; set; }
        public int ticketOwnerID { get; set; }


        public void DefaultSettings()
        {
            btnAssesment.Enabled = false;
            btnOperaSave.Enabled = false;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                objServiceTimelinesBEL.UserID = _objLoginInfo.userid;
                DefaultSettings();
                string casetype = caseID;
                string userID = objServiceTimelinesBEL.UserName;
                int RespondentID = objServiceTimelinesBEL.UserID;
                int iaID = int.Parse(IAID);
                if (!IsPostBack)
                {
                    GetApprovalOptionsandcommittee(casetype, userID, iaID);
                    GetDataStatus(casetype, ServiceID, iaID);

                }

            }
            catch (Exception ex)

            {
                Response.Redirect("Default.aspx", false);
            }

        }


        #region Binddataforlocking and committee
        public void GetApprovalOptionsandcommittee(string Case, string userID, int IAID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            //conenction path for database
            //int Parameter = Int32.Parse();
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetApprovalOptionsandcommittee(Case, userID, IAID);
                DataTable dtROoperators = new DataTable();
                // DataTable dtCommittee = new DataTable();
                DataTable dtdrdOperations = new DataTable();

                dtROoperators = dsR.Tables[0];
                dtdrdOperations = dsR.Tables[1];
                //  dtCommittee = dsR.Tables[2];

                drpApprover.DataBind();
                drpReviewer.DataBind();
                drpVerifier.DataBind();
                drpOperations.DataBind();
                if (dtROoperators.Rows.Count > 0)
                {

                    DataRow[] drowApprover = dtROoperators.Select("DataManager = 'Data Approver'");
                    if (drowApprover.Length > 0)
                    {
                        drpApprover.DataSource = drowApprover.CopyToDataTable();

                        drpApprover.DataTextField = "EMPLOYEENAME";
                        drpApprover.DataValueField = "userId";
                        drpApprover.DataBind();
                    }

                    DataRow[] drow_Reviewer = dtROoperators.Select("DataManager = 'Data Reviewer'");
                    if (drow_Reviewer.Length > 0)
                    {
                        drpReviewer.DataSource = drow_Reviewer.CopyToDataTable();

                        drpReviewer.DataTextField = "EMPLOYEENAME";
                        drpReviewer.DataValueField = "userId";

                        drpReviewer.DataBind();
                    }


                    DataRow[] drow_Verifier = dtROoperators.Select("DataManager = 'Data Verifier'");
                    if (drow_Verifier.Length > 0)
                    {
                        drpVerifier.DataSource = drow_Verifier.CopyToDataTable();
                        drpVerifier.DataTextField = "EMPLOYEENAME";
                        drpVerifier.DataValueField = "userId";
                        drpVerifier.DataBind();
                    }


                }

                if (dtdrdOperations.Rows.Count > 0)
                {
                    drpOperations.DataSource = dtdrdOperations;
                    drpOperations.DataTextField = "Application_Option";
                    drpOperations.DataValueField = "Application_Option";
                    drpOperations.DataBind();
                    drpOperations.Items.Insert(0, new ListItem("--Select Operation--", "--Select Operation--"));

                }




                //DataTable dt = dsR.Tables[0];
                //GridViewApplicants.DataSource = dt;
                //GridViewApplicants.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        public void GetDataStatus(string Case, string ServiceID, int IAID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            //conenction path for database
            //int Parameter = Int32.Parse();
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetDataStatus(Case, ServiceID, IAID);
                DataTable dt = dsR.Tables[0];
                //GridViewApplicants.DataSource = dt;
                //GridViewApplicants.DataBind();
                lblDataStatus1.Text = dsR.Tables[0].Rows[0][0].ToString();
                lblDataStatus.Text = dsR.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        #endregion




        public String CurrentDate()
        {
            return DateTime.Now.ToString("d");
        }

        protected void drpOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Handling the Change event of operations

            try
            {
                validateDataStatus();
            }
            catch (Exception ex)
            {

                txtValidate.Text = ex.Message;
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }




        }
        public void validateDataStatus()
        {
            if ((drpOperations.SelectedValue.Trim() == "Forward to data verifier") && (lblDataStatus1.Text == "PROVISIONAL"))
            {
                btnOperaSave.Enabled = true;
                btnAssesment.Enabled = true;

            }
            else
            {

                btnOperaSave.Enabled = false;
                btnAssesment.Enabled = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "alert('Data is not yet Verified!  Unable to perform this action at provisional state! Raise a Ticket to Data verifier to verify the data entered by Applicant!');", true);


            }





        }

        protected void btnAssesment_Click(object sender, EventArgs e)
        {

        }

        protected void btnpok_Click(object sender, EventArgs e)
        {



        }

        protected void btnOperaSave_Click(object sender, EventArgs e)
        {
            //lblPopMessage.Text = "This will raise a request for Data Verifier to verify all the relevant Information provided by the Applicant.Please Confirm!";




            try
            {
                // Raise a ticket for Data Verifier to verify the service Request

                string serviceID = ServiceID;
                int industrialAreaID = Int32.Parse(IAID);
                int RespondentID = Int32.Parse(drpVerifier.SelectedValue);
                int ticketOwnerID = objServiceTimelinesBEL.UserID;
                string[] SerArray = serviceID.Split('/');
                int caseType = int.Parse(SerArray[1]);

                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(IAID);
                objServiceTimelinesBEL.serviceID = ServiceID;
                objServiceTimelinesBEL.RespondentID = RespondentID;
                objServiceTimelinesBEL.ticketOwnerID = ticketOwnerID;
                objServiceTimelinesBEL.caseType = caseType;
                objServiceTimelinesBEL.ReQFor = drpOperations.SelectedItem.Text;



                // Create ticket for Verification


                int retVal = objServiceTimelinesBLL.ServiceTicketCreate(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    string str = "Ticket raised for verifier to verify";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "alert('Ticket raised for verifier to verify');", true);

                }
                else
                {
                    return;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());


            }


        }
    }
}