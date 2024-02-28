using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
namespace Allotment
{
    public partial class UC_DataFactsIAService : System.Web.UI.UserControl
    {
        SqlConnection con;
        public string ServiceRequestNo { get; set; }
        string UserName = "";
        string ServiceId = "";
        string AppDate = "";
        string IAName = "";
        string PlotArea = "";
        string PlotNumber = "";
        string AllotteeID = "";
        string TEFTimeperiod = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        #endregion

        public string strSender { get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
            strSender = "NewSystem";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            lblServiceReqNo.Text = ServiceRequestNo;
            string[] Arr = ServiceRequestNo.Split('/');
            ServiceId = Arr[1];
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


            if (!IsPostBack)
            {

            }

            if (lblServiceReqNo.Text.Length > 0)
            {

                if (ServiceId == "1003")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForChangeOfProject();
                }

                if (ServiceId == "1004")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForAdditionOfProduct();
                }

                if (ServiceId == "1009")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForCompletionCertificate();
                }
                if (ServiceId == "1010")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForOccupancyCertificate();
                }
                else if (ServiceId == "1005")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForIAService_NocMortgage();
                }
                else if (ServiceId == "1006")
                {
                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForIAService_JointMortgage();
                }
                else if (ServiceId == "1007")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForIAService_SecondCharge();
                }
                else if (ServiceId == "1011")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForIAService_Transferofleasedeed();
                }
                else if (ServiceId == "1002")
                {

                    TEFDiv.Visible = true;
                    GetAllotteeDetailForIAService_TEF();
                }
                else if (ServiceId == "1023")
                {
                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForNoDues();
                }
                else if (ServiceId == "1027")
                {
                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForOutstandingDues();
                }
                #region DemoService

                if (ServiceId == "1014")
                {
                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForIAService_startofproduction();
                }
                if (ServiceId == "1013")
                {
                    BuildingDiv.Visible = true;
                    GetPlotCancelDetails();
                }
                if (ServiceId == "1017")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForhandoverofleasedeedtolease();
                }
                if (ServiceId == "1022")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForWaterConnection();
                }
                if (ServiceId == "1008")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForreconstitutionforallotte();
                }
                if (ServiceId == "1021")
                {
                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForRecognitionoftheLegalHeir();
                }

                #region  ManishShuklaNewService
                if (ServiceId == "1012")
                {
                    RestorationDiv.Visible = true;
                    GetAllotteeDetailForRestorationofplot();
                }
                if (ServiceId == "1024")
                {
                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForSurrenderofPlot();
                }
                if (ServiceId == "1025")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForEstablishmentofAdditionalUnit();
                }
                if (ServiceId == "1026")
                {

                    SublettingDiv.Visible = true;
                    GetAllotteeDetailForSublettingofPlot();
                }
                if (ServiceId == "1029")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForAmalgamationPostAllotment();
                }
                if (ServiceId == "1030")
                {

                    BuildingDiv.Visible = true;
                    GetAllotteeDetailForSubDivisionPostAllotment();
                }
                #endregion
                #endregion
            }



        }

        public void GetAllotteeDetailForSubDivisionPostAllotment()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/SubDivision_Post_Allotment_NOC.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForSubDivisionPostAllotmentLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt8 = ds.Tables[3];




                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotNo = dt0.Rows[0]["PlotNo"].ToString();
                    string AmalgamatedPlots = dt0.Rows[0]["AmalgamatedPlots"].ToString();
                    string AmalgamatedPlotsArea = dt0.Rows[0]["AmalgamatedPlotsArea"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string AppNo = lblServiceReqNo.Text;

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{AppNo}}", AppNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{AmalgamatedPlotsArea}}", AmalgamatedPlotsArea);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotNo);
                    htmlContent = htmlContent.Replace("{{AmalgamatedPlots}}", AmalgamatedPlots);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
                if (dt8.Rows.Count > 0)
                {


                    string html11 = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Plot No </th><th> Plot Area </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt8.Rows)
                    {
                        i++;
                        html11 += "<tr><td> " + i.ToString() + " </td><td> " + dr["PlotNumber"].ToString() + " </ td><td> " + dr["PlotArea"].ToString() + " </ td></tr> ";

                    }
                    html11 += "<tr><th colspan='2'></th><th>" + dt8.Compute("Sum(PlotArea)", string.Empty).ToString() + "</th></tr></table>";

                    htmlContent = htmlContent.Replace("{{PlotDetails}}", html11);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{PlotDetails}}", "");

                }




            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetailForCompletionCertificate()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/CompletionCertificate.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForCompletionSCertificate '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count >= 0)
                    {

                        if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_annexre_details";
                            temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                            ViewState["temp_annexre_details"] = temp_clause_details;

                            ViewState["temp_annexre_details"] = dt7;
                            temp_bpannexre_details_DataBind();
                        }

                    }

                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }




                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetailForAmalgamationPostAllotment()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Amalgamation_Post_Allotment_NOC.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForAmalgamationPostAllotmentLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt8 = ds.Tables[3];




                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotNo = dt0.Rows[0]["PlotNo"].ToString();
                    string AmalgamatedPlots = dt0.Rows[0]["AmalgamatedPlots"].ToString();
                    string AmalgamatedPlotsArea = dt0.Rows[0]["AmalgamatedPlotsArea"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string AppNo = lblServiceReqNo.Text;

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{AppNo}}", AppNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{AmalgamatedPlotsArea}}", AmalgamatedPlotsArea);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotNo);
                    htmlContent = htmlContent.Replace("{{AmalgamatedPlots}}", AmalgamatedPlots);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
                if (dt8.Rows.Count > 0)
                {


                    string html11 = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Plot No </th><th> Plot Area </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt8.Rows)
                    {
                        i++;
                        html11 += "<tr><td> " + i.ToString() + " </td><td> " + dr["PlotNumber"].ToString() + " </ td><td> " + dr["PlotArea"].ToString() + " </ td></tr> ";

                    }
                    html11 += "<tr><th colspan='2'></th><th>" + dt8.Compute("Sum(PlotArea)", string.Empty).ToString() + "</th></tr></table>";

                    htmlContent = htmlContent.Replace("{{PlotDetails}}", html11);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{PlotDetails}}", "");

                }




            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }

        public void GetAllotteeDetailForOccupancyCertificate()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/OccupancyCertificate.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForCompletionSCertificate '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count >= 0)
                    {

                        if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_annexre_details";
                            temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                            ViewState["temp_annexre_details"] = temp_clause_details;

                            ViewState["temp_annexre_details"] = dt7;
                            temp_bpannexre_details_DataBind();
                        }

                    }

                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }




                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }

        public void GetAllotteeDetailForChangeOfProject()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Change_Of_Project_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForChangeOfProjectLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt8 = ds.Tables[3];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }
                if (dt8.Rows.Count > 0)
                {
                    string lblIndustrytype = dt8.Rows[0]["IndustryType"].ToString();
                    string lblPlotRequiredExpansion = dt8.Rows[0]["ExpansionOfLand"].ToString();
                    string lblExportOrientedIndustry = dt8.Rows[0]["ExportOriented"].ToString();
                    string lblRelevantExperience = dt8.Rows[0]["WorkExperience"].ToString();
                    string lblTimelimitSetup = dt8.Rows[0]["ProjectStartMonths"].ToString();
                    string lblLandCost = dt8.Rows[0]["LandDetails"].ToString();
                    string lblBuildingCost = dt8.Rows[0]["BuildingDetails"].ToString();
                    string lblPlantMachineryCost = dt8.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    string lblTotalProjectCost = dt8.Rows[0]["EstimatedCostOfProject"].ToString();
                    string lblCoveredarea = dt8.Rows[0]["CoveredArea"].ToString();
                    string lblOpenArea = dt8.Rows[0]["OpenAreaRequired"].ToString();
                    string lblSolidQuantity = dt8.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    string lblSolidComposition = dt8.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    string lblLiquidQuantity = dt8.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    string lblLiquidComposition = dt8.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    string lblGasQuantity = dt8.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    string lblGasComposition = dt8.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    string lblEstimatedEmployment = dt8.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    string lblInvestmentOtherAssets = dt8.Rows[0]["OtherFixedAssets"].ToString();
                    string lblInvestmentOtherExpenses = dt8.Rows[0]["OtherExpenses"].ToString();
                    string lblProposedEffluents1 = dt8.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    string lblProposedEffluents2 = dt8.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    string lblProposedEffluents3 = dt8.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    string lblPowerrequirement = dt8.Rows[0]["PowerReqInKW"].ToString();
                    string lblNetWorthTurnover = dt8.Rows[0]["NetWorth"].ToString();
                    string lblpriorityCategory = dt8.Rows[0]["ApplicantPrioritySpecification"].ToString();
                    string lblTypeOfIndustryy = dt8.Rows[0]["IAClasification"].ToString();
                    string lblIndustrialCategory = dt8.Rows[0]["PollutionCategory"].ToString();
                    string lblEtp = dt8.Rows[0]["EtpRequired"].ToString();
                    string IACategory = dt8.Rows[0]["IACategory"].ToString();
                    string lblTurnOver = dt8.Rows[0]["NetTurnover"].ToString().Trim();


                    htmlContent = htmlContent.Replace("{{lblIndustrytype}}", lblIndustrytype);
                    htmlContent = htmlContent.Replace("{{lblPlotRequiredExpansion}}", lblPlotRequiredExpansion);
                    htmlContent = htmlContent.Replace("{{lblExportOrientedIndustry}}", lblExportOrientedIndustry);
                    htmlContent = htmlContent.Replace("{{lblRelevantExperience}}", lblRelevantExperience);
                    htmlContent = htmlContent.Replace("{{lblTimelimitSetup}}", lblTimelimitSetup);
                    htmlContent = htmlContent.Replace("{{lblLandCost}}", lblLandCost);
                    htmlContent = htmlContent.Replace("{{lblBuildingCost}}", lblBuildingCost);
                    htmlContent = htmlContent.Replace("{{lblPlantMachineryCost}}", lblPlantMachineryCost);
                    htmlContent = htmlContent.Replace("{{lblTotalProjectCost}}", lblTotalProjectCost);
                    htmlContent = htmlContent.Replace("{{lblCoveredarea}}", lblCoveredarea);
                    htmlContent = htmlContent.Replace("{{lblOpenArea}}", lblOpenArea);
                    htmlContent = htmlContent.Replace("{{lblTypeOfIndustryy}}", lblTypeOfIndustryy);
                    htmlContent = htmlContent.Replace("{{lblEstimatedEmployment}}", lblEstimatedEmployment);
                    htmlContent = htmlContent.Replace("{{lblInvestmentOtherAssets}}", lblInvestmentOtherAssets);
                    htmlContent = htmlContent.Replace("{{lblInvestmentOtherExpenses}}", lblInvestmentOtherExpenses);

                }


                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }






            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }

        public void GetAllotteeDetailForAdditionOfProduct()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Addition_Of_Product_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForAdditionOfProductLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt8 = ds.Tables[3];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }
                if (dt8.Rows.Count > 0)
                {
                    string ProductName = dt8.Rows[0]["AdditionalProduct"].ToString();
                    string ProductDescription = dt8.Rows[0]["ProductDescription"].ToString();
                    htmlContent = htmlContent.Replace("{{ProductName}}", ProductName);
                    htmlContent = htmlContent.Replace("{{ProductDescription}}", ProductDescription);

                }


                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }






            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }

        public void temp_bpannexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                BPClauseGrid.DataSource = dt;
                BPClauseGrid.DataBind();
                BPClauseGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                BPClauseGrid.DataSource = dt;
                BPClauseGrid.DataBind();
            }

        }

        protected void BPClauseGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_annexre_details"] = dt;
            dt.AcceptChanges();
            temp_bpannexre_details_DataBind();
        }

        protected void btnSaveBpClause_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            string Clause = (BPClauseGrid.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");


            if (Clause == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Annexures"] = Clause;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["temp_annexre_details"] = dt;
                temp_bpannexre_details_DataBind();
            }
        }

        protected void LockBPData_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {


                DataTable Annexures = (DataTable)ViewState["temp_annexre_details"];
                command = new SqlCommand(@"sp_ClearAnnexures '" + lblServiceReqNo.Text + "'", con, transaction);
                transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                if (Annexures.Rows.Count > 0)
                {

                    foreach (DataRow dr2 in Annexures.Rows)
                    {
                        string Clause = dr2["Annexures"].ToString();
                        command = new SqlCommand(@"[Sp_AnnexuresInsert]", con, transaction);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                        command.Parameters.AddWithValue("@Clause", Clause);

                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                    }

                }



                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Data Facts Locked Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    if (ServiceId == "1003")
                    {
                        GetAllotteeDetailForChangeOfProject();
                    }
                    if (ServiceId == "1023")
                    {
                        GetAllotteeDetailForNoDues();
                    }
                    if (ServiceId == "1027")
                    {
                        GetAllotteeDetailForOutstandingDues();
                    }
                    if (ServiceId == "1004")
                    {
                        GetAllotteeDetailForAdditionOfProduct();
                    }
                    if (ServiceId == "1005")
                    {
                        GetAllotteeDetailForIAService_NocMortgage();
                    }
                    if (ServiceId == "1006")
                    {
                        GetAllotteeDetailForIAService_JointMortgage();
                    }
                    if (ServiceId == "1007")
                    {
                        GetAllotteeDetailForIAService_SecondCharge();
                    }
                    if (ServiceId == "1011")
                    {
                        GetAllotteeDetailForIAService_Transferofleasedeed();
                    }
                    if (ServiceId == "1014")
                    {
                        GetAllotteeDetailForIAService_startofproduction();
                    }
                    if (ServiceId == "1025")
                    {
                        GetAllotteeDetailForEstablishmentofAdditionalUnit();
                    }
                    if (ServiceId == "1024")
                    {
                        GetAllotteeDetailForSurrenderofPlot();
                    }
                    if (ServiceId == "1014")
                    {
                        GetAllotteeDetailForIAService_startofproduction();
                    }
                    if (ServiceId == "1017")
                    {
                        GetAllotteeDetailForhandoverofleasedeedtolease();
                    }
                    if (ServiceId == "1008")
                    {
                        GetAllotteeDetailForreconstitutionforallotte();
                    }
                    if (ServiceId == "1021")
                    {
                        GetAllotteeDetailForRecognitionoftheLegalHeir();
                    }
                    if (ServiceId == "1029")
                    {
                        GetAllotteeDetailForAmalgamationPostAllotment();
                    }
                    if (ServiceId == "1030")
                    {
                        GetAllotteeDetailForSubDivisionPostAllotment();
                    }
                }
                else
                {
                    transaction.Rollback();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                {
                    transaction.Rollback();
                }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }

        }

        public void GetAllotteeDetailForNoDues()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/NoDuesCertificate_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForNoDuesCertificate] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];




                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:NoDuesCertificate";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }


                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }






            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }


        public void GetAllotteeDetailForOutstandingDues()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/OutstandingDuesCertificate_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForOutstandingDuesCertificate] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];




                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:NoDuesCertificate";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }


                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }


                if(dt3.Rows.Count > 0)
                {

                    string html = @"<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Payment Head </th><th> Demanded </th><th> Paid </th><th> Oustanding </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt3.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["PaymentName"].ToString() + " </ td><td> " + dr["Demanded"].ToString() + " </ td><td> " + dr["Paid"].ToString() + " </ td><td> " + dr["Outstanding"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";
                    htmlContent = htmlContent.Replace("{{Ledger}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{Ledger}}", "");
                }





            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }


        #region codemymanish
        #region Secondcharge GridDetails

        public void GetAllotteeDetailForIAService_SecondCharge()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/SecondCharges_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();

            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForSecondchargeLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    string SanctionletternoSecond = dt0.Rows[0]["SanctionletternoSecond"].ToString();
                    string SanctionletterDate = dt0.Rows[0]["SanctionletterDate"].ToString();
                    string PremimAmountSecond = dt0.Rows[0]["PremimAmountSecond"].ToString();

                    string firstNameofbank = dt0.Rows[0]["firstNameofbank"].ToString();
                    string firstBranch = dt0.Rows[0]["firstBranch"].ToString();
                    string secondNameofbank = dt0.Rows[0]["secondNameofbank"].ToString();
                    string secondBranch = dt0.Rows[0]["secondBranch"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", lblServiceReqNo.Text);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                    htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                    htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);

                    htmlContent = htmlContent.Replace("{{secondNameofbank}}", secondNameofbank);
                    htmlContent = htmlContent.Replace("{{secondBranch}}", secondBranch);
                    htmlContent = htmlContent.Replace("{{firstNameofbank}}", firstNameofbank);
                    htmlContent = htmlContent.Replace("{{firstBranch}}", firstBranch);
                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Literal2.Text = htmlContent;
        }
        public void GetAllotteeDetailForIAService_NocMortgage()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/NocMortgage_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();

            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForNocMortgageLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];



                if (dt0.Rows.Count > 0)
                {

                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    string SanctionletternoSecond = dt0.Rows[0]["letterNo"].ToString();
                    string SanctionletterDate = dt0.Rows[0]["letterDate"].ToString();
                    string PremimAmountSecond = dt0.Rows[0]["PremimAmount"].ToString();
                    string NOCBankName = dt0.Rows[0]["BankName"].ToString();
                    string NOCBranchName = dt0.Rows[0]["BranchName"].ToString();
                    string NOCDiginationName = dt0.Rows[0]["LetterFrom"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", lblServiceReqNo.Text);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                    htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                    htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);

                    htmlContent = htmlContent.Replace("{{BankName}}", NOCBankName);
                    htmlContent = htmlContent.Replace("{{BranchName}}", NOCBranchName);
                    htmlContent = htmlContent.Replace("{{LetterFrom}}", NOCDiginationName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetailForIAService_JointMortgage()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/JointMortgage_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();

            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForJointMortgageLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt8 = ds.Tables[3];

                if (dt0.Rows.Count > 0)
                {

                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    string SanctionletternoSecond = dt0.Rows[0]["letterNo"].ToString();
                    string SanctionletterDate = dt0.Rows[0]["letterDate"].ToString();
                    string PremimAmountSecond = dt0.Rows[0]["PremimAmount"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", lblServiceReqNo.Text);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                    htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                    htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone    = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId  = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    if (dt8.Rows.Count > 0)
                    {
                        //string MobileNumber = dt8.Rows[0]["MobileNumber"].ToString();
                        string BankName = dt8.Rows[0]["BankName"].ToString();
                        string BranchName = dt8.Rows[0]["BranchName"].ToString();
                        
                        htmlContent = htmlContent.Replace("{{BankName}}", BankName);
                        htmlContent = htmlContent.Replace("{{BranchName}}", BranchName);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetailForIAService_Transferofleasedeed()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Transferofleasedeed_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();

            try
            {

                SqlCommand cmd = new SqlCommand("DetailsFortransferofleasedeedLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];



                if (dt0.Rows.Count > 0)
                {

                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string SanctionletternoSecond = dt0.Rows[0]["letterNo"].ToString();
                    string SanctionletterDate = dt0.Rows[0]["letterDate"].ToString();
                    string PremimAmountSecond = dt0.Rows[0]["PremimAmount"].ToString();

                    string letterfrom = dt0.Rows[0]["letterfrom"].ToString();
                    string BankName = dt0.Rows[0]["BankName"].ToString();
                    string BankAddress = dt0.Rows[0]["BankAddress"].ToString();



                    htmlContent = htmlContent.Replace("{{RefNo}}", lblServiceReqNo.Text);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{letterno}}", SanctionletternoSecond);
                    htmlContent = htmlContent.Replace("{{letterDate}}", SanctionletterDate);
                    htmlContent = htmlContent.Replace("{{PremimAmount}}", PremimAmountSecond);

                    htmlContent = htmlContent.Replace("{{letterfrom}}", letterfrom);
                    htmlContent = htmlContent.Replace("{{BankName}}", BankName);
                    htmlContent = htmlContent.Replace("{{BankAddress}}", BankAddress);


                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        #endregion

        #region tef GridDetails
        public void temp_tefannexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_tefannexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                AnnexreGridtef.DataSource = dt;
                AnnexreGridtef.DataBind();
                AnnexreGridtef.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                AnnexreGridtef.DataSource = dt;
                AnnexreGridtef.DataBind();
            }

        }

        protected void insert_tefannexre_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_tefannexre_details"];

            string Clause = (AnnexreGridtef.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");


            if (Clause == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Annexures"] = Clause;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["temp_tefannexre_details"] = dt;
                temp_tefannexre_details_DataBind();
            }

        }

        protected void AnnexretefDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_tefannexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_tefannexre_details"] = dt;
            dt.AcceptChanges();
            temp_tefannexre_details_DataBind();
        }

        protected void LockTimeextensionfeeData_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = lblServiceReqNo.Text;
                string date_to_be = DateTime.ParseExact(txttefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.TEFApprovalDate = Convert.ToDateTime(date_to_be);
                objServiceTimelinesBEL.CreatedBy = UserName;

                int result = objServiceTimelinesBLL.InsertServiceCustomSetApplicantDataforTEF(objServiceTimelinesBEL);
                if (result > 0)
                {
                    DataTable Annexures = (DataTable)ViewState["temp_tefannexre_details"];
                    command = new SqlCommand(@"sp_ClearAnnexures '" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                    if (Annexures.Rows.Count > 0)
                    {

                        foreach (DataRow dr2 in Annexures.Rows)
                        {
                            string Clause = dr2["Annexures"].ToString();
                            command = new SqlCommand(@"[Sp_AnnexuresInsert]", con, transaction);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                            command.Parameters.AddWithValue("@Clause", Clause);

                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                        }

                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }
                if (transactionResult)
                {
                    transaction.Commit();
                    GetAllotteeDetailForIAService_TEF();
                    string message = "Data Facts Locked Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);



                }
                else
                {
                    transaction.Rollback();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                {
                    transaction.Rollback();
                }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }

        public void GetAllotteeDetailForIAService_TEF()
        {
            string htmlContent = "";
            decimal Outstanding = 0;
            StreamReader reader = new StreamReader(Server.MapPath("/html/TEF_Letter_View.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();
            try
            {
                SqlCommand cmd = new SqlCommand("DetailsForTEFLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];

                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    AppDate = dt0.Rows[0]["DateOfTEFRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    PlotNumber = dt0.Rows[0]["PlotNo"].ToString();
                    PlotArea = dt0.Rows[0]["TotalAllottedplotArea"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    AllotteeID = dt0.Rows[0]["AllotteeID"].ToString();
                    TEFTimeperiod = dt0.Rows[0]["TEFTimeperiod"].ToString();
                    txttefDate.Text = dt0.Rows[0]["tefDate"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotNumber);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{tefDate}}", txttefDate.Text);
                    htmlContent = htmlContent.Replace("{{TEFTimeperiod}}", TEFTimeperiod);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }

                if (dt3.Rows.Count > 0)
                {
                    Outstanding = Convert.ToDecimal(dt3.Compute("SUM(Outstanding)", string.Empty));
                    htmlContent = htmlContent.Replace("{{Outstanding}}", Convert.ToDecimal(Outstanding).ToString());
                }
                if (dt3.Rows.Count > 0)
                {

                    string html = @"<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Payment Head </th><th> Demanded </th><th> Paid </th><th> Oustanding </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt3.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["PaymentName"].ToString() + " </ td><td> " + dr["Demanded"].ToString() + " </ td><td> " + dr["Paid"].ToString() + " </ td><td> " + dr["Outstanding"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";
                    htmlContent = htmlContent.Replace("{{Ledger}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{Ledger}}", "");
                }

                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_tefannexre_details"] == null || ViewState["temp_tefannexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_tefannexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_tefannexre_details"] = temp_clause_details;

                        ViewState["temp_tefannexre_details"] = dt7;
                        temp_tefannexre_details_DataBind();
                    }

                }
                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexres}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexres}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literaltimeextension.Text = htmlContent;

        }
        #endregion


        #endregion

        #region Newservice

        public void GetAllotteeDetailForIAService_startofproduction()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Startofproduction_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();

            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForstartofproduction '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];



                if (dt0.Rows.Count > 0)
                {

                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string IssueDate = dt0.Rows[0]["IssueDate"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string StartofproductionDate = dt0.Rows[0]["StartofproductionDate"].ToString();
                    htmlContent = htmlContent.Replace("{{RefNo}}", lblServiceReqNo.Text);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{StartofproductionDate}}", StartofproductionDate);
                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        #region Plot Cancelation

        public void temp_clause_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_clause_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                ClauseGrid.DataSource = dt;
                ClauseGrid.DataBind();
                ClauseGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                ClauseGrid.DataSource = dt;
                ClauseGrid.DataBind();
            }

        }

        protected void insert_clause_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_clause_details"];

            string Clause = (ClauseGrid.FooterRow.FindControl("txtClause_insert1") as TextBox).Text.Replace(",", ""); ;


            if (Clause != "")
            {

                DataRow dr = dt.NewRow();
                dr["Annexures"] = Clause;


                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_clause_details"] = dt;
                temp_clause_details_DataBind();

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }

        }

        protected void ClauseDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_clause_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_clause_details"] = dt;

            dt.AcceptChanges();


            temp_clause_details_DataBind();


        }


        protected void btnLockPlotCancel_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                int retVal1 = 0;
                int retVal2 = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo.Trim();
                DataTable temp1 = (DataTable)ViewState["temp_clause_details"];
                retVal1 = objServiceTimelinesBLL.ClearPlotCancelNotices(objServiceTimelinesBEL);
                if (retVal1 >= 0)
                {

                    if (temp1.Rows.Count > 0)
                    {


                        foreach (DataRow dr2 in temp1.Rows)
                        {
                            string Clause = dr2["Annexures"].ToString();


                            objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo.Trim();
                            objServiceTimelinesBEL.Clause = Clause.Trim();


                            retVal2 = objServiceTimelinesBLL.SaveClauseNoticesDetails(objServiceTimelinesBEL);

                        }


                        if (retVal2 > 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Facts Saved Successfully');", true);
                            return;
                        }


                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Clauses Entered');", true);
                        return;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void GetPlotCancelDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Plot_Cancelation.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();
            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForPlotCancellation '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];



                if (dt0.Rows.Count > 0)
                {

                    string RefNo = dt0.Rows[0]["ServiceRequestNO"].ToString();
                    string IssueDate = dt0.Rows[0]["IssueDate"].ToString();
                    string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string AllotmentLetterNo = dt0.Rows[0]["AllotmentLetterNo"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{AllotmentLetterNo}}", AllotmentLetterNo);
                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt2.Rows.Count >= 0)
                {

                    gridNotices.DataSource = dt2;
                    gridNotices.DataBind();
                }
                if (dt3.Rows.Count >= 0)
                {

                    if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_clause_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_clause_details"] = temp_clause_details;

                        ViewState["temp_clause_details"] = dt3;
                        temp_clause_details_DataBind();
                    }

                }

                if (dt3.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt3.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        #endregion

        #endregion

        #region ManishShuklaNewService




        //Surrender of Plot
        public void GetAllotteeDetailForSurrenderofPlot()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/SurrenderofPlot_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForSurrenderofPlotLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];




                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }






            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }

        //Additional Unit


        #region  Subletting

        protected void LockSubletingData_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = lblServiceReqNo.Text;
                objServiceTimelinesBEL.SublettingYear = Convert.ToInt32(ddlSublettingYear.SelectedValue.TrimEnd());
                objServiceTimelinesBEL.totalSublettingCharge = Convert.ToDecimal(txtSublettingcharge.Text);
                //objServiceTimelinesBEL.presentrates = Convert.ToDecimal(txtpresentrates.Text);
                //objServiceTimelinesBEL.SubLettingCharges = Convert.ToDecimal(txtSubLettingCharges.Text);
                string date_to_be = DateTime.ParseExact(txtleasedeeddate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.leasedeeddate = Convert.ToDateTime(date_to_be);
                //objServiceTimelinesBEL.outstandingDues = Convert.ToDecimal(txtoutstandingDues.Text);
                objServiceTimelinesBEL.CreatedBy = UserName;

                int result = objServiceTimelinesBLL.InsertServiceCustomSetApplicantDataforSubletting(objServiceTimelinesBEL);
                if (result > 0)
                {
                    DataTable Annexures = (DataTable)ViewState["temp_annexre_details"];
                    command = new SqlCommand(@"sp_ClearAnnexures '" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                    if (Annexures.Rows.Count > 0)
                    {

                        foreach (DataRow dr2 in Annexures.Rows)
                        {
                            string Clause = dr2["Annexures"].ToString();
                            command = new SqlCommand(@"[Sp_AnnexuresInsert]", con, transaction);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                            command.Parameters.AddWithValue("@Clause", Clause);

                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                        }

                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }
                if (transactionResult)
                {
                    transaction.Commit();
                    GetAllotteeDetailForSublettingofPlot();
                    string message = "Data Facts Locked Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);



                }
                else
                {
                    transaction.Rollback();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                {
                    transaction.Rollback();
                }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }


        public void GetAllotteeDetailForSublettingofPlot()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Sublettingofplot_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForSublettingtLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt8 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_sublettingannexre_details_DataBind();
                    }

                }
                if (dt4.Rows.Count > 0)
                {

                    ddlSublettingYear.SelectedValue = dt4.Rows[0]["sublettingyear"].ToString();
                    txtSublettingcharge.Text = dt4.Rows[0]["sublettingcharge"].ToString();
                    txtleasedeeddate.Text = dt4.Rows[0]["leasedeedDate"].ToString();

                    htmlContent = htmlContent.Replace("{{sublettingyear}}", ddlSublettingYear.SelectedValue);
                    htmlContent = htmlContent.Replace("{{sublettingcharge}}", txtSublettingcharge.Text);
                    htmlContent = htmlContent.Replace("{{leasedeedDate}}", txtleasedeeddate.Text);
                }
                if (dt8.Rows.Count > 0)
                {
                    string lblIndustrytype = dt8.Rows[0]["ProjectName"].ToString();
                    string SublettingAllotteeAddress = dt8.Rows[0]["SublettingAllotteeAddress"].ToString();
                    string SublettingAllotteeName = dt8.Rows[0]["SublettingAllotteeName"].ToString();
                    string SublettingPlotArea = dt8.Rows[0]["SublettingPlotArea"].ToString();
                    string AreaRate = dt8.Rows[0]["RateofPlot"].ToString();
                    string SublettingCharge = dt8.Rows[0]["SublettingCharge"].ToString();
                    string SublettingChargeGST = dt8.Rows[0]["SublettingChargeGST"].ToString();

                    htmlContent = htmlContent.Replace("{{ProjectName}}", lblIndustrytype);
                    htmlContent = htmlContent.Replace("{{SublettingAllotteeAddress}}", SublettingAllotteeAddress);
                    htmlContent = htmlContent.Replace("{{SublettingAllotteeName}}", SublettingAllotteeName);
                    htmlContent = htmlContent.Replace("{{SublettingPlotArea}}", SublettingPlotArea);

                    htmlContent = htmlContent.Replace("{{RateofPlot}}", AreaRate);
                    htmlContent = htmlContent.Replace("{{SublettingCharge}}", SublettingCharge);
                    htmlContent = htmlContent.Replace("{{SublettingChargeGST}}", SublettingChargeGST);

                }


                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }






            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            ltsubleting.Text = htmlContent;

        }


        public void temp_sublettingannexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                SubletingClauseGrid.DataSource = dt;
                SubletingClauseGrid.DataBind();
                SubletingClauseGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                SubletingClauseGrid.DataSource = dt;
                SubletingClauseGrid.DataBind();
            }

        }

        protected void sublettingClauseGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_annexre_details"] = dt;
            dt.AcceptChanges();
            temp_sublettingannexre_details_DataBind();
        }

        protected void btnSavesublettingClause_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            string Clause = (SubletingClauseGrid.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");


            if (Clause == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Annexures"] = Clause;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["temp_annexre_details"] = dt;
                temp_sublettingannexre_details_DataBind();
            }
        }

        #endregion

        #region Restoration of Plot
        protected void LockRestorationData_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = lblServiceReqNo.Text;
                objServiceTimelinesBEL.Restorationlevypercentage = Convert.ToDecimal(txtRestorationlevypercentage.Text);
                string buildingPlanDate = DateTime.ParseExact(txtbuildingDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.buildingDate = Convert.ToDateTime(buildingPlanDate);
                string ProductionStartDate = DateTime.ParseExact(txtProductionDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.ProductionDate = Convert.ToDateTime(ProductionStartDate);
                objServiceTimelinesBEL.CreatedBy = UserName;

                int result = objServiceTimelinesBLL.InsertServiceCustomSetApplicantDataforRestoration(objServiceTimelinesBEL);
                if (result > 0)
                {
                    DataTable Annexures = (DataTable)ViewState["temp_annexre_details"];
                    command = new SqlCommand(@"sp_ClearAnnexures '" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                    if (Annexures.Rows.Count > 0)
                    {

                        foreach (DataRow dr2 in Annexures.Rows)
                        {
                            string Clause = dr2["Annexures"].ToString();
                            command = new SqlCommand(@"[Sp_AnnexuresInsert]", con, transaction);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                            command.Parameters.AddWithValue("@Clause", Clause);

                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                        }

                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }
                if (transactionResult)
                {
                    transaction.Commit();
                    GetAllotteeDetailForRestorationofplot();
                    string message = "Data Facts Locked Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);



                }
                else
                {
                    transaction.Rollback();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                {
                    transaction.Rollback();
                }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }

        public void GetAllotteeDetailForRestorationofplot()
        {
            string htmlContent = "";
            decimal SumTotal = 0;

            StreamReader reader = new StreamReader(Server.MapPath("/html/Restorationofplot_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForRestorationofplotLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt2 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];

                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string TotalPlotArea = dt0.Rows[0]["PlotArea"].ToString();
                    string RateofPlot = dt0.Rows[0]["RateofPlot"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{PlotArea}}", TotalPlotArea);
                    htmlContent = htmlContent.Replace("{{RateofPlot}}", RateofPlot);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_Restorationannexre_details_DataBind();
                    }

                }
                if (dt4.Rows.Count > 0)
                {

                    txtRestorationlevypercentage.Text = dt4.Rows[0]["Restorationlevypercentage"].ToString();
                    txtbuildingDate.Text = dt4.Rows[0]["buildingPlanDate"].ToString();
                    txtProductionDate.Text = dt4.Rows[0]["ProductionStartDate"].ToString();
                    string Totalrestorationlevyamount = dt4.Rows[0]["Totalrestorationlevyamount"].ToString();
                    //lblTotalrestorationlevyamount.Text = Totalrestorationlevyamount;

                    htmlContent = htmlContent.Replace("{{Restorationlevypercentage}}", txtRestorationlevypercentage.Text);
                    htmlContent = htmlContent.Replace("{{buildingPlanDate}}", txtbuildingDate.Text);
                    htmlContent = htmlContent.Replace("{{ProductionStartDate}}", txtProductionDate.Text);
                    htmlContent = htmlContent.Replace("{{lblTotalrestorationlevyamount}}", Totalrestorationlevyamount);
                }
                if (dt2.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>The detail of outstanding dues are as under";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of outstanding dues </th><th> Rs </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt2.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["PaymentName"].ToString() + " </ td><td> " + dr["Outstanding"].ToString() + " </ td></tr> ";
                        SumTotal = SumTotal + Convert.ToDecimal(dr["Outstanding"].ToString());
                    }

                    html += @"<tr style='background:#f7f7f7;' >
                                          <th></th>
                                          <th ><span >Total </span></th>
                                          <th >" + SumTotal + @"</th>
                                          </tr>";

                    html += " </table>";

                    htmlContent = htmlContent.Replace("{{Listofoutstandingdues}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{Listofoutstandingdues}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            ltRestoration.Text = htmlContent;

        }



        public void temp_Restorationannexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                RestorationClauseGrid.DataSource = dt;
                RestorationClauseGrid.DataBind();
                RestorationClauseGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                RestorationClauseGrid.DataSource = dt;
                RestorationClauseGrid.DataBind();
            }

        }

        protected void RestorationClauseGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_annexre_details"] = dt;
            dt.AcceptChanges();
            temp_Restorationannexre_details_DataBind();
        }

        protected void btnSaveRestorationClause_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            string Clause = (RestorationClauseGrid.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");


            if (Clause == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Annexures"] = Clause;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["temp_annexre_details"] = dt;
                temp_Restorationannexre_details_DataBind();
            }
        }


        #endregion
        #region  Additional Unit
        public void GetAllotteeDetailForEstablishmentofAdditionalUnit()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/AdditionalUnit_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForAdditionalUnitLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];

                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                }
                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }

                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }






            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        #endregion

        #endregion

        #region DemoCode
        public void GetAllotteeDetailForWaterConnection()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/WaterConnection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForWaterConnection '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt8 = ds.Tables[3];

                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        //string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        //htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:waterconnection";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt8.Rows.Count > 0)
                    {

                        string TypeofConnection = dt8.Rows[0]["TypeofConnection"].ToString();
                        string WaterMeterSize = dt8.Rows[0]["WaterMeterSize"].ToString();
                        string Waterrequirement = dt8.Rows[0]["Waterrequirement"].ToString();

                        htmlContent = htmlContent.Replace("{{TypeofConnection}}", TypeofConnection);
                        htmlContent = htmlContent.Replace("{{WaterMeterSize}}", WaterMeterSize);
                        htmlContent = htmlContent.Replace("{{Waterrequirement}}", Waterrequirement);


                    }
                    if (dt7.Rows.Count >= 0)
                    {

                        if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_annexre_details";
                            temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                            ViewState["temp_annexre_details"] = temp_clause_details;

                            ViewState["temp_annexre_details"] = dt7;
                            temp_bpannexre_details_DataBind();
                        }

                    }

                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }




                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetailForhandoverofleasedeedtolease()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Requestforhandoverofleasedeedtolease.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForhandoverofleasedeedtolease '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        //string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        //htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:HandOverleasedeed";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count >= 0)
                    {

                        if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_annexre_details";
                            temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                            ViewState["temp_annexre_details"] = temp_clause_details;

                            ViewState["temp_annexre_details"] = dt7;
                            temp_bpannexre_details_DataBind();
                        }

                    }

                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }




                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetailForreconstitutionforallotte()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/ReconstitutionOfAllottee.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForreconstitutionforallotte '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string AllottmentDate = dt0.Rows[0]["AllotmentDate"].ToString();

                         
                        htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllottmentDate);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:ReconstitutionOfCompany";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count >= 0)
                    {

                        if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_annexre_details";
                            temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                            ViewState["temp_annexre_details"] = temp_clause_details;

                            ViewState["temp_annexre_details"] = dt7;
                            temp_bpannexre_details_DataBind();
                        }

                    }

                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }




                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetailForRecognitionoftheLegalHeir()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/RecognitionoftheLegalHeir.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForreconstitutionforallotte '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string ProjectName = dt0.Rows[0]["ProjectName"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string NewAllotteeName = dt0.Rows[0]["NewAllotteeName"].ToString();
                        string AllotmentNo = dt0.Rows[0]["AllotmentNo"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string AllottmentDate = dt0.Rows[0]["AllotmentDate"].ToString();

                        htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllottmentDate);
                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", ProjectName);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{NewAllotteeName}}", NewAllotteeName);
                        htmlContent = htmlContent.Replace("{{AllotmentNo}}", AllotmentNo);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:ReconstitutionOfCompany";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                            }

                        }

                    }
                    if (dt7.Rows.Count >= 0)
                    {

                        if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_annexre_details";
                            temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                            ViewState["temp_annexre_details"] = temp_clause_details;

                            ViewState["temp_annexre_details"] = dt7;
                            temp_bpannexre_details_DataBind();
                        }

                    }

                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }




                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }


        #endregion


    }


}