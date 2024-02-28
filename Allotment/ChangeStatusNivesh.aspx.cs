using System;
using System.Configuration;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;
using System.Data;

namespace Allotment
{
    public partial class ChangeStatusNivesh : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
       
        GeneralMethod gm = new GeneralMethod();
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";
        string RequestID = "";
        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        string Request_ID = "";
        string Pendancy_level = "";
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string Is_Certificate_Valid_Life_Time = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";
        string SerReqNo;
        string Type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        }


        protected void btnSample_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            SerReqNo = txtSerReqNo.Text;

            if (radioRejection.SelectedItem.Text.Trim() == "Approval")
            {

                if (radioservice.SelectedItem.Text.Trim() == "LandAllotment")
                {
                    Status_Code = "15";
                    Remarks = "Land Allotment Process Completed";
                    NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Allotment";
                }
                else
                {
                    Status_Code = "15";
                    Remarks = "Building Plan Approval Process Completed";
                    NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=BuildingPlan";
                }

            }
            else
            {
                if (radioservice.SelectedItem.Text.Trim() == "LandAllotment")
                {
                    Status_Code = "07";
                    Remarks = "Land Allotment Application Is Rejected";
                    NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Rejection";
                }
                else
                {
                    Status_Code = "07";
                    Remarks = "Building Plan Application Is Rejected";
                    NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Rejection";
                }
            }

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            "Applicant",
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            txtSerReqNo.Text,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            txtRequestID.Text, 
            "480", 
            "Yes", 
            Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
        }

        protected void BtnFeePaid_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            Status_Code = "11";
            Request_ID = txtSerReqNo.Text;
          //Transaction_ID = txtRequestID.Text;
            Fee_Amount = txtRemarks.Text;

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            Pendancy_level,
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            NOC_Certificate_Number,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
Request_ID, 
Objection_Rejection_Code, 
Is_Certificate_Valid_Life_Time, 
Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7

            );
        }

        protected void btnFormSubmitted_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;

            if (radioservice.SelectedItem.Text == "BuildingPlan")
            {
                Status_Code = "13";
                Remarks = "Form Submitted | DA Agro Park";
            }
            else
            {
                Status_Code = "13";
                Remarks = "EMD Payment Paid.Form Submitted | DA Etah- IIDC";
            }
            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            "DA Etah- IIDC",
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            NOC_Certificate_Number,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
txtRequestID.Text
, Objection_Rejection_Code, Is_Certificate_Valid_Life_Time, Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
        }

        protected void btnDraft_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            Request_ID = txtSerReqNo.Text;

            if (radioservice.SelectedItem.Text == "BuildingPlan")
            {
                Status_Code = "10";
                Remarks = "Building Plan Approval Fee Pending | Applicant";
            }
            else
            {
                Status_Code = "10";
                Remarks = "EMD Payment Pending.";
            }
            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            Pendancy_level,
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            NOC_Certificate_Number,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,

Request_ID, Objection_Rejection_Code, Is_Certificate_Valid_Life_Time, Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
        }

        protected void btnFeeDraft_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            

            if (radioservice.SelectedItem.Text == "BuildingPlan")
            {
                Status_Code = "10";
                Remarks = "Nivesh Mitra Fee Paid.Kindly Proceed to fill rest of the form.";
            }
            else
            {
                Status_Code = "10";
                Remarks = "Nivesh Mitra Fee Paid.Kindly Proceed to fill rest of the form.";
            }
            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            Pendancy_level,
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            NOC_Certificate_Number,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,

Request_ID, Objection_Rejection_Code, Is_Certificate_Valid_Life_Time, Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
        }
        protected void btnObjection_Click(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            ControlID   = txtControlID.Text;
            UnitID      = txtUnitID.Text;
            ServiceID   = txtServiceID.Text;
            Request_ID = txtRequestID.Text;

            Status_Code = "08";
            Remarks     = txtRemarks.Text + " | DA "+txtSerReqNo.Text+" raises query and objection to Applicant";

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            Pendancy_level,
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            NOC_Certificate_Number,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            Request_ID,
            Objection_Rejection_Code, 
            Is_Certificate_Valid_Life_Time, 
            Certificate_EXP_Date_DDMMYYYY,
            D1,
            D2,
            D3,
            D4,
            D5,
            D6,
D7
            );
        }
        protected void FeeStatusNM_Click(object sender, EventArgs e)
        {

            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            Status_Code = "12";
            Fee_Amount = txtRemarks.Text;
            Fee_Status = "UB";
            Remarks = "NMSWP Fee Pending | Applicant";

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            Pendancy_level,
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            NOC_Certificate_Number,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            txtRequestID.Text, 
            Objection_Rejection_Code, 
            Is_Certificate_Valid_Life_Time, 
            Certificate_EXP_Date_DDMMYYYY,
            D1,
            D2,
            D3,
            D4,
            D5,
            D6,
            D7
            );

        }



        protected void btnPending_Click(object sender, EventArgs e)
        {

            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            Status_Code = "01";
            
            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            Pendancy_level,
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            NOC_Certificate_Number,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            txtRequestID.Text,
            Objection_Rejection_Code,
            Is_Certificate_Valid_Life_Time,
            Certificate_EXP_Date_DDMMYYYY,
            D1,
            D2,
            D3,
            D4,
            D5,
            D6,
            D7
            );

        }

        protected void btnReservationNOC_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID    = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            SerReqNo  = txtSerReqNo.Text;
            NOC_URL   = "https://eservices.onlineupsidc.com/ReservationMoneyPaymentAck.aspx?ServiceReqNo=" + SerReqNo + "&TraId=" + txtRemarks.Text + "";
             
            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            "15",
            "Reservation Money Payment Receipt Generated | Applicant",
            "Applicant",
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            txtRemarks.Text,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            txtRequestID.Text,
            Objection_Rejection_Code,
            "Yes",
            Certificate_EXP_Date_DDMMYYYY,
            D1,
            D2,
            D3,
            D4,
            D5,
            D6,
            D7
            );
        }

        protected void btnDuesPaymentNOC_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            SerReqNo = txtSerReqNo.Text;

            string NOC_URL = "https://eservices.onlineupsidc.com/OutstandingDuesPaymentAck.aspx?ServiceReqNo=" + SerReqNo.Trim() + "&TraId=" + txtRemarks.Text + "";
            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            "15",
            "Outstanding Dues Payment Receipt Generated | Applicant",
            "Applicant",
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            txtSerReqNo.Text,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            txtRequestID.Text,
            Objection_Rejection_Code,
            "Yes",
            Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
        }

        protected void BtnFinalNoc_Click(object sender, EventArgs e)
        {

            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            SerReqNo = txtSerReqNo.Text;

            if (radioRejection.SelectedItem.Text.Trim() == "Approval")
            {
                Status_Code = "15";
                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=" + txtRemarks.Text;
            }
            else
            {
                Objection_Rejection_Code = "486";
                Status_Code = "07";
                Remarks = "Application Rejected | Applicant";
                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=" + txtRemarks.Text;

            }

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            "Applicant",
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            txtSerReqNo.Text,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            txtRequestID.Text,
            Objection_Rejection_Code,
            "Yes",
            Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
        }

        protected void BtnFinalNoc_Clicknar(object sender, EventArgs e) //NARENDRA TIWARI 20/10/2023
        {
            try
            {
                using (con)
                {
                    using (SqlCommand cmd9 = new SqlCommand("SELECT * FROM ServiceRequests WHERE IsCompleted= 1 AND  CompletedOn >= DATEADD(MONTH, -1, GETDATE()) AND CompletedOn <= GETDATE()"))
                    {
                        cmd9.CommandType = CommandType.Text;
                        cmd9.Connection = con;
                        con.Open();
                        SqlDataReader sdr = cmd9.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                string ControlID = sdr["NMControlID"].ToString();
                                string UnitID = sdr["NMUnitID"].ToString();
                                string ServiceID = sdr["NMServiceID"].ToString();
                                string Request_ID = sdr["NMRequestID"].ToString();
                                string ServiceReqNo = sdr["ServiceRequestNO"].ToString();

                                DataTable dt = gm.GetNMSWP_Details(ControlID, UnitID, ServiceID, Request_ID);
                                string StatusCode = dt.Rows[0]["Status_Code"].ToString();  
                                if(StatusCode != "15")
                                {
                                    Status_Code = "15";
                                    if (ServiceID== "SC21038")
                                    {
                                       
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";                                    
                                        NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wNS8yNS9TLzYxNjc=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                        else if(ServiceID == "SC21002")
                                           {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER201812131359/1/24118/7380&DocType=BuildingPlan" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                           }
                                       else if (ServiceID == "SC21001")
                                           {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20190805/1000/20478/1779&DocType=Allotment" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                           }
                                    else if (ServiceID == "SC21027")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/OutstandingDuesPaymentAck.aspx?ServiceReqNo=SER20220829/1028/17379/57646&TraId=95586333" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21022")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/ReservationMoneyPaymentAck.aspx?ServiceReqNo=SER20201109/200/28747/9063&TraId=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21033")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=SER20220217/2000/5313/41529" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21003")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200529/1/25191/5078&DocType=BuildingPlan" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21043")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wOS8xMy9TLzI4NTE=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21012")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210304/1004/23909/14034&DocType=AdditionOfProduct" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21041")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_amalgation_certificate.php?cid=MjAyMy8wNy8yNy9BTS81MjIz" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21031")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221018/1026/17396/60632&DocType=Subleting" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21013")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200706/1003/5812/6069&DocType=ChangeOfProject" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21030")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20201130/1025/24924/9769&DocType=AdditionOfProduct" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21032")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210212/1017/30249/13179&DocType=HandOverleasedeed" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21020")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20201122/1014/22090/9504&DocType=startofproduction" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21016")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210909/1005/11330/20905&DocType=nocmortgage" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21014")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210124/1001/30371/12305&DocType=SignedLease" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21039")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wOC8xOS9TLzQwMjc=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21029")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200709/1023/25191/6135&DocType=NoDues" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21028")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20230522/1027/19082/72834&DocType=OutstandingDues" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21017")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20231007/1007/7478/84508&DocType=secondcharge" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21018")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20211029/1006/10495/26980&DocType=Jointmortgage" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21023")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20211023/1021/9326/26688&DocType=Reconstitutionforlegalheir" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21024")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200822/1008/18430/6926&DocType=ReconstitutionOfCompany" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21021")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20230516/1012/46269/72636&DocType=NOC%20Issued" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21026")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20220304/1024/21420/44674&DocType=surrender" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21015")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210122/1002/22090/12179&DocType=Timeextensionfee" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21019")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20230216/1011/12383/68392&DocType=transferofleasedeed" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21025")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200620/4/11915/5476&DocType=Transfer" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21040")
                                    {
                                        Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                        NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wNi8yNy9TLzU0OTY=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }

                                }
                                else { }
                                       

                                

                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                string Update_Result = webService.WReturn_CUSID_STATUS(
                                ControlID,
                                UnitID,
                                ServiceID,
                                ProcessIndustryID,
                                ApplicationID,
                                Status_Code,
                                Remarks,
                                "Applicant",
                                Fee_Amount,
                                Fee_Status,
                                Transaction_ID,
                                Transaction_Date,
                                Transaction_Date_Time,
                                txtSerReqNo.Text,
                                NOC_URL,
                                ISNOC_URL_ActiveYesNO,
                                passsalt,
                                txtRequestID.Text,
                                Objection_Rejection_Code,
                                "Yes",
                                Certificate_EXP_Date_DDMMYYYY,
                    D1,
                    D2,
                    D3,
                    D4,
                    D5,
                    D6,
                    D7
                                );

                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            
        }

        protected void BtnFinalReject_Clicknar(object sender, EventArgs e) //NARENDRA TIWARI 20/10/2023
        {
            try
            {
                using (con)
                {
                    using (SqlCommand cmd9 = new SqlCommand("SELECT  * FROM ServiceRequests WHERE IsRejected= 1 AND  RejectedOn >= DATEADD(MONTH, -2, GETDATE()) AND CompletedOn <= GETDATE()"))
                    {
                        cmd9.CommandType = CommandType.Text;
                        cmd9.Connection = con;
                        con.Open();
                        SqlDataReader sdr = cmd9.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                string ControlID = sdr["NMControlID"].ToString();
                                string UnitID = sdr["NMUnitID"].ToString();
                                string ServiceID = sdr["NMServiceID"].ToString();
                                string Request_ID = sdr["NMRequestID"].ToString();
                                string ServiceReqNo = sdr["ServiceRequestNO"].ToString();

                                DataTable dt = gm.GetNMSWP_Details(ControlID, UnitID, ServiceID, Request_ID);
                                string StatusCode = dt.Rows[0]["Status_Code"].ToString();
                                if (StatusCode != "07")
                                {
                                    //Objection_Rejection_Code = "486";
                                    //Status_Code = "07";
                                    //Remarks = "Application Rejected | Applicant";
                                    //NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    Status_Code = "07";
                                    if (ServiceID == "SC21036")
                                    {

                                        Objection_Rejection_Code = "486";                                       
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://services.stagingupsida.com/LAWCorrespondenceLetters/LOA/sparkle%20.pdf" + SerReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21002")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER201812131359/1/24118/7380&DocType=BuildingPlan" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21001")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20220719/1000/1357/55109&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21003")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200305/1/25626/4499&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21012")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200305/1/25626/4499&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21031")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20211029/1026/32793/26957&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21013")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210630/1003/14555/17465&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21030")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21032")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21020")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21016")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21016")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21029")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21028")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21017")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21018")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21023")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21024")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21021")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21026")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21015")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21019")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21025")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                    else if (ServiceID == "SC21040")
                                    {
                                        Objection_Rejection_Code = "486";
                                        Remarks = "Application Rejected | Applicant";
                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221206/1025/7982/63054&DocType=Rejection" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                                    }
                                }
                             
                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                string Update_Result = webService.WReturn_CUSID_STATUS(
                                ControlID,
                                UnitID,
                                ServiceID,
                                ProcessIndustryID,
                                ApplicationID,
                                Status_Code,
                                Remarks,
                                "Applicant",
                                Fee_Amount,
                                Fee_Status,
                                Transaction_ID,
                                Transaction_Date,
                                Transaction_Date_Time,
                                txtSerReqNo.Text,
                                NOC_URL,
                                ISNOC_URL_ActiveYesNO,
                                passsalt,
                                txtRequestID.Text,
                                Objection_Rejection_Code,
                                "Yes",
                                Certificate_EXP_Date_DDMMYYYY,
                    D1,
                    D2,
                    D3,
                    D4,
                    D5,
                    D6,
                    D7
                                );

                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }


        protected void BtnFinalFwd_Click(object sender, EventArgs e)
        {

            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            SerReqNo = txtSerReqNo.Text;
            Pendancy_level = "Pending At Nodal Officer WareHousing";
            Objection_Rejection_Code = "";

            Status_Code = "05";
            Remarks = "Application Forwarded to Nodal Officer WareHousing";

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            "Applicant",
            Fee_Amount,
            Fee_Status,
            Transaction_ID,
            Transaction_Date,
            Transaction_Date_Time,
            txtSerReqNo.Text,
            NOC_URL,
            ISNOC_URL_ActiveYesNO,
            passsalt,
            txtRequestID.Text,
            Objection_Rejection_Code,
            "Yes",
            Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
        }



        protected void btnLandPurchase_Click(object sender, EventArgs e)
        {
            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();

            string Update2 = webService.WReturn_CUSID_ISLandPurchased(txtControlID.Text, txtUnitID.Text, txtServiceID.Text, "Yes", passsalt);


            NMSWP_DistrictUpdate.Dist_updation_after_land_allotmt_By_DptSoapClient webService1 = new NMSWP_DistrictUpdate.Dist_updation_after_land_allotmt_By_DptSoapClient();

            string Update_Result = webService1.Unit_Industry_District_Location_Updation("21", txtUnitID.Text, txtRemarks.Text, "", "", "p5632aa8a5c915ba4b896325bc5baz8k");


        }
    }
}