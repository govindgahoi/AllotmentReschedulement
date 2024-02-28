using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;


namespace Allotment
{
    public partial class ServiceTracker : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string Service;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!IsPostBack)
            {
                btnView.Visible = false;
                Btnview1.Visible = false;
            }
          

        }

        protected void Go_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetgridServiceTracker(txtServiceReqNo.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {


                    if (ds.Tables[0].Rows[0]["Status"].ToString() == "NOC Issued")
                    {
                        string[] SerArray1 = txtServiceReqNo.Text.Split('/');
                        Service = SerArray1[1].ToString();
                        if(Service=="200")
                        {
                            gridServiceTracker.DataSource = ds;
                            gridServiceTracker.DataBind();
                            btnView.Visible = false;
                            Btnview1.Visible = false;
                            btn_ViewApp.Visible = true;
                        }
                        else
                        {
                            gridServiceTracker.DataSource = ds;
                            gridServiceTracker.DataBind();
                            btnView.Visible = true;
                            Btnview1.Visible = false;
                            btn_ViewApp.Visible = true;
                        }
                       
                       
                    }
                    else if (ds.Tables[0].Rows[0]["Status"].ToString() == "Application Rejected")
                    {
                        gridServiceTracker.DataSource = ds;
                        gridServiceTracker.DataBind();
                        btnView.Visible = false;
                        Btnview1.Visible = true;
                        btn_ViewApp.Visible = true;
                      
                    }
                    else
                    {
                        gridServiceTracker.DataSource = ds;
                        gridServiceTracker.DataBind();
                        btnView.Visible = false;
                        Btnview1.Visible = false;
                        btn_ViewApp.Visible = true;
                       
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[1];
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();

                    }


                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record Not Found');", true);
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    gridServiceTracker.DataSource = null;
                    gridServiceTracker.DataBind();
                    btnView.Visible = false;
                    Btnview1.Visible = false;
                    btn_ViewApp.Visible = false;
                    return;
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

        protected void btnView_Click(object sender, EventArgs e)
        {
            string[] SerIdarray = txtServiceReqNo.Text.Split('/');
            string ServiceID = SerIdarray[1].ToString();
            string DocType = "";

            switch (ServiceID)
            {
                case "1000":
                    DocType = "Allotment";
                    break;
                case "1":
                    DocType = "BuildingPlan";
                    break;
                case "2":
                    DocType = "BuildingPlan";
                    break;
                case "1005":
                    DocType = "nocmortgage";
                    break;
                case "1006":
                    DocType = "Jointmortgage";
                    break;
                case "1002":
                    DocType = "Timeextensionfee";
                    break;
                case "1003":
                    DocType = "ChangeOfProject";
                    break;
                case "1004":
                    DocType = "AdditionOfProduct";
                    break;
                case "1014":
                    DocType = "startofproduction";
                    break;
                case "1026":
                    DocType = "Subleting";
                    break;
                case "1007":
                    DocType = "secondcharge";
                    break;
                case "1008":
                    DocType = "ReconstitutionOfCompany";
                    break;
                case "1011":
                    DocType = "transferofleasedeed";
                    break;
                case "1021":
                    DocType = "Reconstitutionforlegalheir";
                    break;
                case "1001":
                    DocType = "Registered Lease";
                    break;
                case "1027":
                    DocType = "OutstandingDues";
                    break;
                case "1025":
                    DocType = "Additional";
                    break;
                case "1023":
                    DocType = "NoDues";
                    break;
                case "1024":
                    DocType = "surrender";
                    break;
                case "1017":
                    DocType = "HandOverleasedeed";
                    break;
                case "1012":
                    DocType = "Restoration";
                    break;
                case "4":
                    DocType = "Transfer";
                    break;
                case "1029":
                    DocType = "AmalgamationPostAllotment";
                    break;

            }


            String js = "window.open('SignedLetterView.aspx?ServiceRequestNo=" + txtServiceReqNo.Text.Trim() + "&DocType="+ DocType + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SignedLetterView.aspx", js, true);
        }

        protected void Btnview1_Click(object sender, EventArgs e)
        {
            String js = "window.open('SignedLetterView.aspx?ServiceRequestNo=" + txtServiceReqNo.Text.Trim() + "&DocType=Rejection', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SignedLetterView.aspx", js, true);
        }

        protected void tbn_ViewApp_Click(object sender, EventArgs e)
        {
            string[] SerArray1 = txtServiceReqNo.Text.Split('/');
            Service = SerArray1[1].ToString();

            if (Service == "1001")
            {
                String js = "window.open('LeaseDeedApplication.aspx?ViewID=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LeaseDeedApplication.aspx", js, true);
            }
            else if (Service == "1002" || Service == "1005" || Service == "1006" || Service == "1007" || Service == "1011" || Service == "1013" || Service == "1014")
            {
                String js = "window.open('IAServicesApplication_Module.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "IAServicesApplication_Module.aspx", js, true);
            }
            else if (Service == "1012" || Service == "1024" || Service == "1025" || Service == "1026")
            {
                String js = "window.open('IAServicesApplication_Module1.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "IAServicesApplication_Module1.aspx", js, true);
            }
            else if (Service == "1017" || Service == "1021" || Service == "1008")
            {
                String js = "window.open('IAReconstitutionApplication.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "IAReconstitutionApplication.aspx", js, true);
            }
            else if (Service == "1" || Service == "2")
            {
                GeneralMethod gm = new GeneralMethod();
                SqlCommand cmd = new SqlCommand("select B.ServiceRequestNO,B.Status,IsNull(A.BPFeePaid,'False') 'BPFeePaid',BuildingTraID,isNull(B.IsClarificationReq,0) 'BuildingPlanObjection',isnull(B.IsRejected,0) 'IsRejected' from AllotteeMaster A, ServiceRequests B where A.AllotteeID = B.AllotteeID  and B.ServiceRequestNO='" + txtServiceReqNo.Text.Trim() + "' and isnull(B.IsActive,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                adp.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    string Rej       = dt1.Rows[0]["IsRejected"].ToString();
                    string Req       = dt1.Rows[0]["ServiceRequestNO"].ToString();
                    string Red       = dt1.Rows[0]["Status"].ToString();
                    string FeePAid   = dt1.Rows[0]["BPFeePaid"].ToString();
                    string TraID     = dt1.Rows[0]["BuildingTraID"].ToString();
                    string Objection = dt1.Rows[0]["BuildingPlanObjection"].ToString();

                    if (Rej == "True")
                    {

                        String js = "window.open('AllotteeApplication.aspx?ServiceID=" + txtServiceReqNo.Text.Trim() + "&TraID=" + TraID + "&App=View', '_blank');";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AllotteeApplication.aspx", js, true);
                    }

                    else if (Objection == "True")
                    {
                        String js = "window.open('AllotteeApplication.aspx?ServiceID=" + txtServiceReqNo.Text.Trim() + "&TraID=" + TraID + "&App=View', '_blank');";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AllotteeApplication.aspx", js, true);
                    }
                    else if (Convert.ToDateTime(gm.GetServiceDate(txtServiceReqNo.Text)) < DateTime.ParseExact("25/08/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    {
                        if (FeePAid == "False")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Kindly Pay Nivesh Mitra Processing Fee for Final Submission of Your Application');", true);
                            return;
                        }
                        else
                        {
                            String js = "window.open('AllotteeApplication.aspx?ServiceID=" + txtServiceReqNo.Text.Trim() + "&TraID=" + TraID + "&App=View', '_blank');";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AllotteeApplication.aspx", js, true);
                        }
                    }
                    else
                    {
                        String js = "window.open('AllotteeApplication.aspx?ServiceID=" + txtServiceReqNo.Text.Trim() + "&TraID=" + TraID + "&App=View', '_blank');";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AllotteeApplication.aspx", js, true);
                    }
                }

            }

            else if(Service=="1000")
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = txtServiceReqNo.Text;
                    ds = objServiceTimelinesBLL.GetLAApplicantDetails(objServiceTimelinesBEL);


                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        string TraID         = dt.Rows[0]["ApplicationTraID"].ToString();
                        string Paid          = dt.Rows[0]["Paid"].ToString();
                        string PayType       = dt.Rows[0]["ResponseCode"].ToString();
                        string Clarification = dt.Rows[0]["IsClarificationReq"].ToString();
                        string ServiceReqNo  = dt.Rows[0]["ServiceReqNo"].ToString();
                        string status = "";

                        if (Clarification.Trim() == "True" || Clarification.Trim() == "1")
                        {
                            String js = "window.open('LandAllotmentApplication.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LandAllotmentApplication.aspx", js, true);
                        }
                        if (Paid == "True")
                        {
                            status = "F";
                        }
                        else
                        {
                            status = "C";
                        }

                        if (TraID == "" || TraID == null)
                        {
                            String js = "window.open('LandAllotmentApplication.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LandAllotmentApplication.aspx", js, true);
                        }
                        else
                        {

                            if (status == "F")
                            {
                                String js = "window.open('LandAllotmentApplication.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&Status=F&TranID=" + TraID + "', '_blank');";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LandAllotmentApplication.aspx", js, true);
                            }
                            if (status == "C")
                            {
                                String js = "window.open('LandAllotmentApplication.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&Status=C&TranID=" + TraID + "', '_blank');";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LandAllotmentApplication.aspx", js, true);
                            }
                            
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Service Request No');", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
            else if(Service == "4")
            {
                String js = "window.open('IATransferOfPlotApplication.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "IAServicesApplication_Module.aspx", js, true);
            }
            else if (Service == "200")
            {
                string SWCControlID;
                GeneralMethod gm = new GeneralMethod();
                DataTable NMSWP = gm.GetNMSWPIDNews(txtServiceReqNo.Text.Trim());
                SWCControlID = NMSWP.Rows[0][0].ToString();
                if(SWCControlID.Length>0)
                {
                    String js = "window.open('AllotteeReservationMoneyPayNMSWP.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AllotteeReservationMoneyPayNMSWP.aspx", js, true);
                }
                else
                {
                    String js = "window.open('AllotteeReservationMoneyPayOld.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AllotteeReservationMoneyPayOld.aspx", js, true);
                }
              
            }
            else if (Service == "1028")
            {
                String js = "window.open('IACurrentDues.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "IAServicesApplication_Module.aspx", js, true);
            }
            else
            {
                String js = "window.open('IAServicesApplication.aspx?ServiceReqNo=" + txtServiceReqNo.Text.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "IAServicesApplication_Module.aspx", js, true);
            }

        }
    }
}