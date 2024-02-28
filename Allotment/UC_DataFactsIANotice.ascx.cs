using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
using System.Drawing;
using System.Globalization;
namespace Allotment
{
    public partial class UC_DataFactsIANotice : System.Web.UI.UserControl
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
                #region Newservice

                if (ServiceId == "1013")
                {

                    PlotCancelationNotice.Visible = true;
                    BindAppointmentToDdl();
                    SqlCommand cmd = new SqlCommand("DetailsForNoticeID '" + lblServiceReqNo.Text + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dt0 = ds.Tables[0];
                    if(dt0.Rows.Count > 0)
                    {
                        string spNoticeID = dt0.Rows[0]["NoticeID"].ToString();
                        GetAllotteeDetailForPlotCancelationNotice(spNoticeID);
                    }
                    else
                    {
                        GetAllotteeDetailForPlotCancelationNotice("");
                    }
                    
                }
                #endregion
            }
        }
        #region Plot Cancelation Letter

        protected void UpdateAllotteeLedger_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllotteeLedgerEntry.aspx");
        }
        #region CopyTOClause
        public void temp_Copyannexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_Copyannexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                gvCopyto.DataSource = dt;
                gvCopyto.DataBind();
                gvCopyto.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gvCopyto.DataSource = dt;
                gvCopyto.DataBind();
            }

        }
        protected void CopytoClauseGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_Copyannexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_Copyannexre_details"] = dt;
            dt.AcceptChanges();
            temp_Copyannexre_details_DataBind();
        }
        protected void btnSaveCopyClause_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_Copyannexre_details"];

            string CopyClause = (gvCopyto.FooterRow.FindControl("txtCopy") as TextBox).Text.Replace(",", "");


            if (CopyClause == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Annexures"] = CopyClause;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["temp_Copyannexre_details"] = dt;
                temp_Copyannexre_details_DataBind();
            }
        }
        #endregion

        public void temp_Noticeannexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                gvPlotcancelationNotice.DataSource = dt;
                gvPlotcancelationNotice.DataBind();
                gvPlotcancelationNotice.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gvPlotcancelationNotice.DataSource = dt;
                gvPlotcancelationNotice.DataBind();
            }

        }

        protected void NoticeClauseGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_annexre_details"] = dt;
            dt.AcceptChanges();
            temp_Noticeannexre_details_DataBind();
        }

        protected void btnSaveNoticeClause_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            string Clause = (gvPlotcancelationNotice.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");


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
                temp_Noticeannexre_details_DataBind();
            }
        }
        //protected void btnSend_Click(object sender, EventArgs e)
        //{
        //    string AppointmentType1 = "";
        //    try
        //    {
        //        if (drpAppointmentType.SelectedValue.Trim() == "0")
        //        {
        //            MessageBox1.ShowInfo("Kindly Select Notice Type");
        //            return;
        //        }

        //        foreach (ListItem drpAppointmentType in this.drpAppointmentType.Items)
        //        {
        //            if (drpAppointmentType.Selected == true)
        //            {
        //                AppointmentType1 = AppointmentType1 + drpAppointmentType.Value + ",";
        //            }
        //        }
        //        SqlCommand cmd = new SqlCommand("GetAllotteeDetailsToCreateNotice '" + SerReqNo + "'", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataSet dss = new DataSet();
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        DataTable dt1 = new DataTable();
        //        adp.Fill(dss);
        //        dt = dss.Tables[0];
        //        if (dss.Tables[0].Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["NoticeID"].ToString() == "" || dt.Rows[0]["NoticeID"].ToString() == null)
        //            {
        //                if (Session["FileName"].ToString() == "" || Session["FileName"].ToString() == null)
        //                {
        //                    MessageBox1.ShowError("Please Upload Notice First");
        //                    return;
        //                }
        //                else
        //                {
        //                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
        //                    objServiceTimelinesBEL.AppointmentType = AppointmentType1.TrimEnd(',').Trim();
        //                    objServiceTimelinesBEL.AppointmentDesc = txtComment.Text.Trim();
        //                    objServiceTimelinesBEL.UserID = UserId;
        //                    objServiceTimelinesBEL.Uploadfile = (Session["File"]) as byte[];
        //                    objServiceTimelinesBEL.content = Convert.ToString(Session["FileExt"]);
        //                    objServiceTimelinesBEL.filename = Convert.ToString(Session["FileName"]);
        //                    ds = objServiceTimelinesBLL.CreateNotice(objServiceTimelinesBEL);
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        MessageBox1.ShowInfo(ds.Tables[0].Rows[0][0].ToString());
        //                        drpAppointmentType.SelectedIndex = 0;
        //                        txtComment.Text = "";
        //                        //NoticeSendtoApplicant();
        //                        Session["File"] = "";
        //                        Session["FileExt"] = "";
        //                        Session["FileName"] = "";
        //                        lbluploadingMsg.Visible = false;
        //                        btnSend.Enabled = false;
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        MessageBox1.ShowError("Erron In Creating Notice");
        //                        return;
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                MessageBox1.ShowError("Notice is alredy open ");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (Session["FileName"].ToString() == "" || Session["FileName"].ToString() == null)
        //            {
        //                MessageBox1.ShowError("Please Upload Notice First");
        //                return;
        //            }
        //            else
        //            {
        //                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
        //                objServiceTimelinesBEL.AppointmentType = AppointmentType1.TrimEnd(',').Trim();
        //                objServiceTimelinesBEL.AppointmentDesc = txtComment.Text.Trim();
        //                objServiceTimelinesBEL.UserID = UserId;
        //                objServiceTimelinesBEL.Uploadfile = (Session["File"]) as byte[];
        //                objServiceTimelinesBEL.content = Convert.ToString(Session["FileExt"]);
        //                objServiceTimelinesBEL.filename = Convert.ToString(Session["FileName"]);
        //                ds = objServiceTimelinesBLL.CreateNotice(objServiceTimelinesBEL);
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    MessageBox1.ShowInfo(ds.Tables[0].Rows[0][0].ToString());
        //                    drpAppointmentType.SelectedIndex = 0;
        //                    txtComment.Text = "";
        //                    NoticeSendtoApplicant();
        //                    Session["File"] = "";
        //                    Session["FileExt"] = "";
        //                    Session["FileName"] = "";
        //                    lbluploadingMsg.Visible = false;
        //                    btnSend.Enabled = false;
        //                    return;
        //                }
        //                else
        //                {
        //                    MessageBox1.ShowError("Erron In Creating Notice");
        //                    return;
        //                }
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox1.ShowError(ex.ToString());
        //        return;
        //    }
        //}
        protected void LockNoticeData_Click(object sender, EventArgs e)
        {
            string AppointmentType1 = "";
            string NoticeType = "";
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                DataSet ds = new DataSet();
                if (drpAppointmentType.SelectedValue.Trim() == "0")
                {
                    MessageBox1.ShowInfo("Kindly Select Notice Type");
                    return;
                }
                if (txtLeaseDeedDate.Text == "")
                {
                    MessageBox1.ShowInfo("Kindly give LeaseDeed Date");
                    return;
                }
                if (txtNoticevaildupto.Text == "")
                {
                    MessageBox1.ShowInfo("Kindly Enter Notice Vaild Upto ");
                    return;
                }
                if (txtClause.Text == "")
                {
                    MessageBox1.ShowInfo("Kindly Enter Clause  ");
                    return;
                }
                foreach (ListItem drpAppointmentType in this.drpAppointmentType.Items)
                {
                    if (drpAppointmentType.Selected == true)
                    {
                        NoticeType = NoticeType + drpAppointmentType.Text + ",";
                    }
                }
                foreach (ListItem drpAppointmentType in this.drpAppointmentType.Items)
                {
                    if (drpAppointmentType.Selected == true)
                    {
                        AppointmentType1 = AppointmentType1 + drpAppointmentType.Value + ",";
                    }
                }
                objServiceTimelinesBEL.ServiceRequestNO = lblServiceReqNo.Text;
                string date_to_be = DateTime.ParseExact(txtLeaseDeedDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.LeaseDeedDate = Convert.ToDateTime(date_to_be);
                string Noticevaildupto1 = DateTime.ParseExact(txtNoticevaildupto.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.NoticeVaildUpto = Convert.ToDateTime(Noticevaildupto1);
                objServiceTimelinesBEL.Clause = txtClause.Text;
                objServiceTimelinesBEL.AppointmentType = AppointmentType1.TrimEnd(',').Trim();
                objServiceTimelinesBEL.NoticeTypes = NoticeType.TrimEnd(',').Trim();
                objServiceTimelinesBEL.CreatedBy = UserName;
                //int result = objServiceTimelinesBLL.InsertServiceCustomSetApplicantDataforNotice(objServiceTimelinesBEL);
                ds = objServiceTimelinesBLL.CreateNotice(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    #region CopyTOClause
                    DataTable AnnexuresCopy = (DataTable)ViewState["temp_Copyannexre_details"];
                    command = new SqlCommand(@"sp_ClearAnnexuresCopy '" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                    if (AnnexuresCopy.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in AnnexuresCopy.Rows)
                        {
                            string CopyClause = dr2["Annexures"].ToString();
                            command = new SqlCommand(@"[Sp_AnnexuresCopyInsert]", con, transaction);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                            command.Parameters.AddWithValue("@Clause", CopyClause);
                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                        }

                    }
                    #endregion
                    DataTable Annexures = (DataTable)ViewState["temp_annexre_details"];
                    command = new SqlCommand(@"sp_ClearAnnexures '" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                    if (Annexures.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in Annexures.Rows)
                        {
                            string ADDClause = dr2["Annexures"].ToString();
                            command = new SqlCommand(@"[Sp_AnnexuresInsert]", con, transaction);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                            command.Parameters.AddWithValue("@Clause", ADDClause);
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
                    string NoticeID = ds.Tables[0].Rows[0][0].ToString();
                    GetAllotteeDetailForPlotCancelationNotice(NoticeID);
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
        public void GetAllotteeDetailForPlotCancelationNotice(String NoticeID)
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Notice_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();
            try
            {
                decimal Outstanding = 0;
                SqlCommand cmd = new SqlCommand("DetailsForNoticeLetter '" + lblServiceReqNo.Text + "','" + NoticeID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                if (dt0.Rows.Count > 0)
                {

                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                    string DateofIssueletter = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string Allotmentletterno = dt0.Rows[0]["Allotmentletterno"].ToString();
                    string AllotmentDate = dt0.Rows[0]["AllotmentDate"].ToString();
                    string NoticeType = dt0.Rows[0]["NoticeTypeID"].ToString();
                    string NoticeVaildity = dt0.Rows[0]["NoticeVaildDate"].ToString();
                    string NoticeRefID = dt0.Rows[0]["NoticeID"].ToString();


                    string[] NoticeArr = NoticeType.Split(',');
                    if (NoticeType == "")
                    {
                        drpAppointmentType.ClearSelection();
                    }
                    else
                    {
                        for (int i = 0; i < NoticeArr.Length; i++)
                        {
                            drpAppointmentType.Items.FindByValue(NoticeArr[i]).Selected = true;
                        }
                    }
                    string NoticeDescription = dt0.Rows[0]["NoticeType"].ToString();
                    txtLeaseDeedDate.Text = dt0.Rows[0]["leasedeeddate"].ToString();
                    txtNoticevaildupto.Text = dt0.Rows[0]["NoticeVaildDate"].ToString();
                    txtClause.Text = dt0.Rows[0]["ClauseNumber"].ToString();
                    htmlContent = htmlContent.Replace("{{RefNo}}", lblServiceReqNo.Text);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", DateofIssueletter);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{Allotmentletterno}}", Allotmentletterno);
                    htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{leasedeeddate}}", txtLeaseDeedDate.Text);
                    htmlContent = htmlContent.Replace("{{ClauseNumber}}", txtClause.Text);
                    htmlContent = htmlContent.Replace("{{NoticeDescription}}", NoticeDescription);
                    htmlContent = htmlContent.Replace("{{NoticeVaildDate}}", txtNoticevaildupto.Text);
                    htmlContent = htmlContent.Replace("{{NoticeID}}", NoticeRefID);

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
                if(dt3.Rows.Count > 0)
                {
                     Outstanding = Convert.ToDecimal(dt3.Compute("SUM(Outstanding)", string.Empty));
                    htmlContent = htmlContent.Replace("{{Outstanding}}", Convert.ToDecimal(Outstanding).ToString());
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
                        temp_Noticeannexre_details_DataBind();
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
                if (dt4.Rows.Count >= 0)
                {

                    if (ViewState["temp_Copyannexre_details"] == null || ViewState["temp_Copyannexre_details"].Equals(""))
                    {
                        DataTable temp_Copyannexre_details = new DataTable();
                        temp_Copyannexre_details.TableName = "temp_Copyannexre_details";
                        temp_Copyannexre_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_Copyannexre_details"] = temp_Copyannexre_details;

                        ViewState["temp_Copyannexre_details"] = dt4;
                        temp_Copyannexre_details_DataBind();
                    }

                }
                if (dt4.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Copy To.";
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
<table Class='table table-hover table-bordered ' style='width:100%;'>";
                    int i = 0;
                    foreach (DataRow dr in dt4.Rows)
                    {
                        i++;
                        html += "<tr><td width='5%'> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresCopy}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresCopy}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal1.Text = htmlContent;

        }

        #endregion

        private void BindAppointmentToDdl()
        {
            SqlCommand cmd = new SqlCommand("GetNoticeType", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                drpAppointmentType.DataSource = dt;
                drpAppointmentType.DataBind();
                drpAppointmentType.DataTextField = "StageDescription";
                drpAppointmentType.DataValueField = "ID";
                drpAppointmentType.DataBind();
            }

        }
    }


}