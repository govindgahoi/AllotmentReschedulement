using System;
using System.Configuration;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;
using System.Web.UI.WebControls;
using System.IO;

namespace UpsidaAllottee
{
    public partial class UpdateStatusNiv : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;

        string strControlID = "";
        string strUnitID = "";
        string strServiceID = "";
        string base64 = "";
        string MimeType = "";

        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";

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

            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            Status_Code = "15";
            Request_ID = txtSerReqNo.Text;
            Fee_Amount = txtRemarks.Text;
            Remarks = "25% Upfront Paid Successfully";
            NOC_URL = "http://services.stagingupsida.com/images/NOC20000168799210330001.pdf";
            NOC_Certificate_Number = "NOCNMUPSWP20000168799";
            Is_Certificate_Valid_Life_Time = "NO";
            Certificate_EXP_Date_DDMMYYYY = "17/01/2022";
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
    "20000168799210330001",
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

            Console.WriteLine(Update_Result);
        }

        protected void btnFormSubmitted_Click(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;

            if (radioservice.SelectedItem.Text == "BuildingPlan")
            {
                Status_Code = "13";
                //Remarks = "Form Submitted | DA Orai-I";
                Remarks = "Form Submitted";
            }
            else
            {
                Status_Code = "13";
                Remarks = "EMD Payment Paid.Form Submitted | DA Etah- IIDC";
            }
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
            ControlID,
            UnitID,
            ServiceID,
            ProcessIndustryID,
            ApplicationID,
            Status_Code,
            Remarks,
            "DA Orai-I",
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

            if (radioservice.SelectedItem.Text == "BuildingPlan")
            {
                Status_Code = "10";
                Remarks = "Building Plan Approval Fee Pending.";
            }
            else
            {
                Status_Code = "10";
                Remarks = "EMD Payment Pending.";
            }
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            Status_Code = "08";
            Remarks     = txtRemarks.Text + " | DA "+txtSerReqNo.Text+" raises query and objection to Applicant";

            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            //Remarks = "NOC Certificate Issued";
            Remarks = "NMSWP Fee Pending | Applicant";
            Pendancy_level = txtSerReqNo.Text;

            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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

            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            UnitID    = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            SerReqNo  = txtSerReqNo.Text;

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
        protected void btnLandPurchase_Click(object sender, EventArgs e)
        {
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();

            string Update2 = webService.WReturn_CUSID_ISLandPurchased(txtControlID.Text, txtUnitID.Text, txtServiceID.Text, "Yes", passsalt);


            NMSWP_DistrictUpdate.Dist_updation_after_land_allotmt_By_DptSoapClient webService1 = new NMSWP_DistrictUpdate.Dist_updation_after_land_allotmt_By_DptSoapClient();

            string Update_Result = webService1.Unit_Industry_District_Location_Updation("21", txtUnitID.Text, txtRemarks.Text, "", "", "p5632aa8a5c915ba4b896325bc5baz8k");


        }

        static string base64String = null;
        public string ImageToBase64()
        {
            string path = "C:\\Users\\John\\Documents\\tNc.jpg";
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public System.Drawing.Image Base64ToImage()
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        protected void ImageToBase_Click(object sender, EventArgs e)
        {
            //TextBox1.Text = ImageToBase64();
        }
        protected void BaseToImage_Click(object sender, EventArgs e)
        {
            Base64ToImage().Save(Server.MapPath("~/Images/Hello.jpg"));
            //Image1.ImageUrl = "~/Images/Hello.jpg";
        }
        protected void btnNMPaidCertificate_Click(object sender, EventArgs e)
        {
            strControlID = NMControl.Text;
            strUnitID = NMUnit.Text;
            strServiceID = NMService.Text;
            Request_ID = NMRequestID.Text;
            ProcessIndustryID = NMIndustryID.Text;
            NOC_Certificate_Number= NMNoc.Text;
            base64= NMBase64.Text;
            MimeType= TextBox8.Text;
            passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";

            //SerReqNo = txtSerReqNo.Text;

           // string NOC_URL = "https://eservices.onlineupsidc.com/OutstandingDuesPaymentAck.aspx?ServiceReqNo=" + SerReqNo.Trim() + "&TraId=" + txtRemarks.Text + "";
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_Entrepreneur_NOC_IN_BINARYFORMAT(
            strControlID,
            strUnitID,
            strServiceID,
            ProcessIndustryID,
            Request_ID,
            NOC_Certificate_Number,
            base64,
            MimeType,
            passsalt
           
            );
        }


        protected void BtnFeePaid_Click25(object sender, EventArgs e)
        {
            ControlID = txtControlID.Text;
            UnitID = txtUnitID.Text;
            ServiceID = txtServiceID.Text;
            Status_Code = "15";
            Request_ID = txtSerReqNo.Text;
            Fee_Amount = txtRemarks.Text;
            Remarks = "25% Upfront Paid Successfully";
            NOC_URL = "http://services.stagingupsida.com/images/NOC20000168799210330001.pdf";
            NOC_Certificate_Number = "NOCNMUPSWP20000168799";
            Is_Certificate_Valid_Life_Time = "NO";
            Certificate_EXP_Date_DDMMYYYY = "17/01/2022";
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
"20000168799210330001",
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

            Console.WriteLine(Update_Result);
        }

        
        //protected string imageTostring(I)
        //{
        //  byte[] imageArray = System.IO.File.ReadAllBytes(@"image file path");
        //string base64ImageRepresentation = Convert.ToBase64String(imageArray);
        //return base64ImageRepresentation;
        //using (Image image = Image.FromFile(Path))
        //{
        //    using (MemoryStream m = new MemoryStream())
        //    {
        //        image.Save(m, image.RawFormat);
        //        byte[] imageBytes = m.ToArray();

        //        // Convert byte[] to Base64 String
        //        string base64String = Convert.ToBase64String(imageBytes);
        //        return base64String;
        //    }
        //}
        //}



    }
}