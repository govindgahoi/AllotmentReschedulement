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
    public partial class UC_Doc_ack : System.Web.UI.UserControl
    {
        SqlConnection con;
        public string ServiceRequestNo { get; set; }
        public string AppTypeID { get; set; }
        string UserName = "";
        string ServiceId = "";
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




            if (lblServiceReqNo.Text.Length > 0)
            {


                if (AppTypeID == "1")
                {

                    BuildingDiv.Visible = true;
                    BindCheckList();
                    GetAllotteeDetailForBuilding();
                }


            }



        }

        public void GetAllotteeDetailForBuilding()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/DocAck.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForLeaseAck '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["Date"].ToString();
                    string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string DAName = dt0.Rows[0]["DAName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{DAName}}", DAName);

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

                if (dt7.Rows.Count > 0)
                {
                    GridView1.DataSource = dt7;
                    GridView1.DataBind();

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
                                <tr><th width='10%'> S.NO </th><th> Document description </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["CheckListDesc"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{DocList}}", html);
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    htmlContent = htmlContent.Replace("{{DocList}}", "No Record Found");

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal2.Text = htmlContent;

        }




        public void BindCheckList()
        {

            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();



                objServiceTimelinesBEL.ServiceTimeLines = "1001";
                objServiceTimelinesBEL.FirmType = "1";




                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetDocumentChecklistLeaseDeed(objServiceTimelinesBEL);
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
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }



        }

        protected void LockBPData_Click(object sender, EventArgs e)
        {

            try
            {


                int retVal1 = 0, retVal2 = 0;
                objServiceTimelinesBEL.ServiceRequestNO = lblServiceReqNo.Text.Trim();
                retVal1 = objServiceTimelinesBLL.ClearAckDoc(objServiceTimelinesBEL);
                if (retVal1 >= 0)
                {
                    foreach (GridViewRow row in GridView2.Rows)
                    {
                        if ((row.FindControl("chk") as CheckBox).Checked)
                        {
                            string CheckListID = ((Label)row.Cells[0].FindControl("lblCheckListID")).Text;
                            string CheckHead = row.Cells[2].Text;
                            string CheckDesc = row.Cells[3].Text;

                            objServiceTimelinesBEL.ServiceCheckListsID = Convert.ToInt32(CheckListID);
                            objServiceTimelinesBEL.ServiceChecklistCondition = CheckHead;
                            objServiceTimelinesBEL.ServiceChecklistDesc = CheckDesc;
                            retVal2 = objServiceTimelinesBLL.InsertAckDocLease(objServiceTimelinesBEL);
                        }
                    }
                    if (retVal2 > 0)
                    {
                        MessageBox1.ShowSuccess("Data Saved");
                        GetAllotteeDetailForBuilding();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox1.ShowError(ex.ToString());
            }
        }
    }

}