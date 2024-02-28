using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
namespace Allotment
{
    public partial class UC_RejectionLetterDataFacts : System.Web.UI.UserControl
    {
        SqlConnection con;
        public string ServiceRequestNo { get; set; }
        string UserName = "";
        string ServiceId = "";
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
        #endregion

        public string strSender { get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
            strSender = "NewSystem";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            lblServiceReqNo.Text = ServiceRequestNo;
            string[] Arr = ServiceRequestNo.Split('/');
            ServiceId = Arr[1];

            DataTable NMSWP = gm.GetNMSWPIDNews(ServiceRequestNo);
            SWCControlID    = NMSWP.Rows[0][0].ToString();
            SWCUnitID       = NMSWP.Rows[0][1].ToString();
            SWCServiceID    = NMSWP.Rows[0][2].ToString();
            SWCRequest_ID   = NMSWP.Rows[0][3].ToString();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;

                if (lblServiceReqNo.Text.Length > 0)
                {
                    CancelDiv.Visible = true;

                    if (ServiceId == "1" || ServiceId == "2" || ServiceId == "3")
                    {

                        GetBuildingPlanRejectionDetails();
                    }
                    else if (ServiceId == "1000")
                    {
                        GetPlotCancelDetails();
                    }
                    else if (ServiceId == "4")
                    {
                        GetTransferRejectionDetails();
                    }
                    else if (ServiceId == "1003")
                    {
                        GetChangeOfProjectDetails();
                    }
                    else if (ServiceId == "1004")
                    {
                        GetAdditionOfProductDetails();
                    }
                    else if (ServiceId == "1009")
                    {
                        GetAdditionOfProductDetails();
                    }
                    else if (ServiceId == "1010")
                    {
                        GetAdditionOfProductDetails();
                    }
                    else if (ServiceId == "1002")
                    {
                        GetTEFRejectionDetails();
                    }
                    else if (ServiceId == "1005")
                    {

                        GetNocMortgageRejectionDetails();
                    }
                    else if (ServiceId == "1006")
                    {

                        GetJointMortgageRejectionDetails();
                    }
                    else if (ServiceId == "1007")
                    {
                        GetSecondChargeRejectionDetails();
                    }
                    else if (ServiceId == "1011")
                    {
                        GetTransferofleasedeedRejectionDetails();
                    }
                    else if (ServiceId == "1023")
                    {
                        GetNoDuesRejection();
                    }
                    else if (ServiceId == "1027")
                    {
                        GetOutstandingDuesRejection();
                    }

                    else if (ServiceId == "1008")
                    {
                        GetReconstitutionOfAllotteeDetails();
                    }
                    else if (ServiceId == "1017")
                    {
                        GetRequestforhandoverofleasedeedtoleaseDetails();
                    }
                    else if (ServiceId == "1021")
                    {
                        GetRecognitionoftheLegalHeirRejection();
                    }
                    else if (ServiceId == "1022")
                    {
                        GetWaterConnectionRejectionDetails();
                    }

                    #region  ManishShukla
                    else if (ServiceId == "1013")
                    {
                        GetPlotCancelationRejectionDetails();
                    }
                    else if (ServiceId == "1014")
                    {
                        GetStartofProductionRejectionDetails();
                    }
                    else if (ServiceId == "1029")
                    {
                        /*GetChangeOfProjectDetails()*/
                        GetAmalgamationPostAllotmentDetails();
                    }
                    else if (ServiceId == "1030")
                    {
                        /*GetChangeOfProjectDetails()*/
                        GetSubDivisionPostAllotmentDetails();
                    }

                    #region  ManishShuklaNewService
                    if (ServiceId == "1012")
                    {
                        GetAllotteeDetailForRestorationofplot();
                    }
                    if (ServiceId == "1024")
                    {
                        GetAllotteeDetailForSurrenderofPlot();
                    }
                    if (ServiceId == "1025")
                    {

                        GetAllotteeDetailForEstablishmentofAdditionalUnit();
                    }
                    if (ServiceId == "1026")
                    {
                        GetAllotteeDetailForSublettingofPlot();
                    }
                    if (ServiceId == "1001")
                    {
                        GetLeaseDeedDetails();
                    }

                    #endregion
                    BindNMObjectionType();
                    checkRejection();
                }

            }
            catch(Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('"+ex.ToString()+"');", true);
                return;
            }

        }

        private void BindNMObjectionType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[sp_GetNMobjectionType] '" + SWCServiceID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    drp_NMObjectionType.DataSource = dt;
                    drp_NMObjectionType.DataTextField = "Reason_Details";
                    drp_NMObjectionType.DataValueField = "Reson_ID";
                    drp_NMObjectionType.DataBind();
                    drp_NMObjectionType.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
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

            string Clause = (ClauseGrid.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");

            if (Clause.Length <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Clause');", true);
                return;
            }

            else
            {
                if (Clause.Length < 100)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Minimum reason of 100 Characters are required as per Nivesh Mitra');", true);
                    return;
                }
            }

            DataRow dr = dt.NewRow();
                dr["Clause"] = Clause;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["temp_clause_details"] = dt;
                temp_clause_details_DataBind();
            

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

                if (drp_NMObjectionType.SelectedValue.Trim() == "0")
                {
                     System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose nivesh mitra objection type');", true);
                    return;
                }

                int retVal1 = 0;
                int retVal2 = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo.Trim();
                objServiceTimelinesBEL.NMObjectionRejectionType = drp_NMObjectionType.SelectedValue.Trim();
                DataTable temp1 = (DataTable)ViewState["temp_clause_details"];
                retVal1 = objServiceTimelinesBLL.ClearRejectionReasons(objServiceTimelinesBEL);
                if (retVal1 >= 0)
                {
                    if (temp1.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in temp1.Rows)
                        {
                            string Clause = dr2["Clause"].ToString();
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo.Trim();
                            objServiceTimelinesBEL.Clause = Clause.Trim();
                            retVal2 = objServiceTimelinesBLL.SaveAllotmentRejectionDetails(objServiceTimelinesBEL);
                        }
                        if (retVal2 > 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Details Saved Successfully');", true);
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

            StreamReader reader = new StreamReader(Server.MapPath("/html/AllotmentRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForAllotmentRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        private void GetNoDuesRejection()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/NoDuesCertificateRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        private void GetOutstandingDuesRejection()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/OutstandingDuesCertificateRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        private void GetBuildingPlanRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/BuildingPlanRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }


        #region NewService
        private void GetChangeOfProjectDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/ChangeOfProjectRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




                if (dt0.Rows.Count > 0)
                {
                    string RefNo             = dt0.Rows[0]["ServiceRequestNO"].ToString();
                    string IssueDate         = dt0.Rows[0]["IssueDate"].ToString();
                    string AppDate           = dt0.Rows[0]["ApplicationDate"].ToString();
                    string IAName            = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea          = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName      = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address           = dt0.Rows[0]["Address"].ToString();
                    string RMName            = dt0.Rows[0]["RMName"].ToString();
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                        //else
                        //{
                        //    DataTable temp_clause_details = new DataTable();
                        //    temp_clause_details.TableName = "temp_clause_details";
                        //    temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                        //    ViewState["temp_clause_details"] = temp_clause_details;

                        //    ViewState["temp_clause_details"] = dt2;
                        //    temp_clause_details_DataBind();
                        //}


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        #endregion
        #region SubDivision

        private void GetSubDivisionPostAllotmentDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/SubDivisionPostAllotmentRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForSubDivisionPostAllotmentRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        #endregion

        #region Amalgamation
        private void GetAmalgamationPostAllotmentDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/AmalgamationPostAllotmentRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForAmalgamationPostAllotmentRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        #endregion

        private void GetAdditionOfProductDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/AdditionOfProductRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        private void GetLeaseDeedDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/LeaseDeedRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:LeaseDeedRejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        private void GetCompletionCertificateRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/CompletionCertificateRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        private void GetOccupancyCertificateRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/OccupancyCertificateRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        #region SecondCharge
        private void GetSecondChargeRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/SecondchargeRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        #endregion
        #region NocMortgage
        private void GetNocMortgageRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/NocMortgage_Rejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




                if (dt0.Rows.Count > 0)
                {
                    string RefNo             = dt0.Rows[0]["ServiceRequestNO"].ToString();
                    string IssueDate         = dt0.Rows[0]["IssueDate"].ToString();
                    string AppDate           = dt0.Rows[0]["ApplicationDate"].ToString();
                    string IAName            = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea          = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName      = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address           = dt0.Rows[0]["Address"].ToString();
                    string RMName            = dt0.Rows[0]["RMName"].ToString();
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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
                        string OfficePhone    = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId  = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width  = 150;
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;
                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;
                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        #endregion
        #region JointMortgage
        private void GetJointMortgageRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/JointMortgage_Rejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        #endregion
        #region Transfer of leasedeed
        private void GetTransferofleasedeedRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Transferofleasedeed_Rejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        #endregion
        #region Time extension fee
        private void GetTEFRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/TEFRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        #endregion


        

        private void GetStartofProductionRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/StartofproductionRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForStartofProductionRejection'" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        private void GetPlotCancelationRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/PlotCancelationRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForStartofProductionRejection'" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
    
        private void GetReconstitutionOfAllotteeDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/ReconstitutionOfAllotteeRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForWaterConnectionRejection '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        private void GetRecognitionoftheLegalHeirRejection()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/RecognitionoftheLegalHeirRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForWaterConnectionRejection '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        private void GetWaterConnectionRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/WaterConnectionRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForWaterConnectionRejection'" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }
        private void GetRequestforhandoverofleasedeedtoleaseDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/RequestforhandoverofleasedeedtoleaseRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForWaterConnectionRejection '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }


        private void GetAllotteeDetailForRestorationofplot()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/RestorationofplotRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        private void GetAllotteeDetailForSurrenderofPlot()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/SurrenderofPlotRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }


        private void GetAllotteeDetailForEstablishmentofAdditionalUnit()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/AdditionalUnitRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        private void GetAllotteeDetailForSublettingofPlot()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/SublettingofPlotRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        #endregion

         

        private void GetTransferRejectionDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/TransferRejection.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("[DetailsForBuildingPlanRejection] '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];




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
                    string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

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

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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



                    if (dt2.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }


                    }
                    else
                    {
                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt2;
                            temp_clause_details_DataBind();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        private void checkRejection()
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("Select *  From ServiceRequests where ServiceRequestNO='" + ServiceRequestNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string IsCompleted = dt.Rows[0]["IsRejected"].ToString();
                   string Type= dt.Rows[0]["NMRejectionType"].ToString();
                    if (IsCompleted == "True")
                    {
                        btnLockPlotCancel.Text = "Already Rejected";
                        btnLockPlotCancel.Enabled = false;
                    }
                    if (Type.Length > 0)
                    {
                        drp_NMObjectionType.SelectedValue = Type.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }


}