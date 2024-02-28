using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class OfflinePayment : System.Web.UI.Page
    {
        SqlConnection con;
        String RequestID = "";
        String ControlID = "";
        String UnitID = "";
        decimal downpayment = 0;
        decimal instalment1 = 0;
        decimal instalment2 = 0;
        decimal instalment3 = 0;
        string level = "";
        string UserName = "";
        string PaymentType;
        int schemeType;
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            ddlInst.Visible = false;
            drpPay.Visible = false;
            btnSubmit.Enabled = true;
            //txtRelDate.Text = null;
            txtRelDate.Enabled = false;
            
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                //lblname.Text = Convert.ToString(Session["UserName"]);
                level = Convert.ToString(Session["Level"]);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                if (level == "Admin1" || level == "MD" || level == "JMD")
                {
                    //dlRO.Enabled = true;
                }
                else
                {
                    //dlRO.Enabled = false;
                }
            }
            catch
            {
                Response.Redirect("/loginpage.aspx");
            }
        }
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
        protected void Click_OK(object sender, EventArgs e)
        {

            UnitID = txtUnitID.Text.Trim();
            DataSet dt = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_PaymentDetailByRequestID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UnitID", UnitID);
                cmd.Parameters.AddWithValue("@RequestID", txtReqID.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Tables.Count < 2)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        Session["downpayment"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Fee_Amount"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Fee_Amount"]);
                        Session["instalment1"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Inst_Fee_Amount1"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Inst_Fee_Amount1"]);
                        Session["instalment2"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Inst_Fee_Amount2"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Inst_Fee_Amount2"]);
                        Session["instalment3"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Inst_Fee_Amount3"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Inst_Fee_Amount3"]);
                        Panel1.Visible = true;
                        Panel3.Visible = true;
                        Panel4.Visible = false;
                        Panel5.Visible = true;
                        btnRel.Visible = false;
                        btnSubmit.Visible = true;
                        Session["schemeType"] = Convert.ToInt32(dt.Tables[0].Rows[0]["SchemeType"]);
                        string Offline_Flag = dt.Tables[0].Rows[0]["Offline_Flag"].ToString();
                        if (Offline_Flag == "True")
                        {
                            if (Convert.ToInt32(Session["schemeType"]) == 0)
                            {
                                ddlInst.Visible = false;
                                drpPay.Visible = true;
                                lblPaymentType.Text = "One Time";
                            }
                            if (Convert.ToInt32(Session["schemeType"]) == 1)
                            {
                                ddlInst.Visible = true;
                                drpPay.Visible = false;
                                lblPaymentType.Text = "Instalment";
                            }
                        }
                        else
                        {
                            Panel1.Visible = false;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Offline facility is not available for this UnitID');", true);
                        }
                    }
                    else
                    {
                        Panel1.Visible = false;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter correct data.');", true);
                    }
                }
                else
                {
                    Panel1.Visible = true;
                    Panel3.Visible = false;
                    Panel4.Visible = true;
                    Panel5.Visible = true;
                    btnRel.Visible = true;
                    btnSubmit.Visible = false;
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        Session["downpayment"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Fee_Amount"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Fee_Amount"]);
                        Session["instalment1"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Inst_Fee_Amount1"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Inst_Fee_Amount1"]);
                        Session["instalment2"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Inst_Fee_Amount2"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Inst_Fee_Amount2"]);
                        Session["instalment3"] = (String.IsNullOrEmpty(dt.Tables[0].Rows[0]["Inst_Fee_Amount3"].ToString())) ? 0 : Convert.ToDecimal(dt.Tables[0].Rows[0]["Inst_Fee_Amount3"]);

                        Session["schemeType"] = Convert.ToInt32(dt.Tables[0].Rows[0]["SchemeType"]);
                        string Offline_Flag = dt.Tables[0].Rows[0]["Offline_Flag"].ToString();
                        if (Offline_Flag == "True")
                        {
                            if (Convert.ToInt32(Session["schemeType"]) == 0)
                            {
                                ddlInst.Visible = false;
                                drpPay.Visible = true;
                                lblPaymentType.Text = "One Time";
                                //drpPay.Items.Add(new ListItem("--Select--", ""));
                                //drpPay.Items.Add(new ListItem("Down Payment", "1"));
                                //drpPay.Items.Add(new ListItem("Balance Amount", "2"));
                            }
                            if (Convert.ToInt32(Session["schemeType"]) == 1)
                            {
                                ddlInst.Visible = true;
                                drpPay.Visible = false;
                                lblPaymentType.Text = "Instalment";
                                //drpPay.Items.Add(new ListItem("--Select--", ""));
                                //drpPay.Items.Add(new ListItem("Down Payment", "1"));
                                //drpPay.Items.Add(new ListItem("Instalment-1", "2"));
                                //drpPay.Items.Add(new ListItem("Instalment-2", "3"));
                                //drpPay.Items.Add(new ListItem("Instalment-3", "4"));
                            }
                        }
                        else
                        {
                            Panel1.Visible = false;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Offline facility is not available for this UnitID');", true);
                        }
                    }


                }
            }
            catch (Exception ex) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Internal server error.');", true); }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["schemeType"]) == 0)
            {
                if (drpPay.SelectedIndex == 2 && Convert.ToDecimal(Session["downpayment"]) < 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please pay downpayment amount first');", true);
                    drpPay.SelectedIndex = -1;
                }
                else
                {
                    ddlInst.Visible = false;
                    drpPay.Visible = true;
                    Panel1.Visible = true;
                }
            }
            else if (Convert.ToInt32(Session["schemeType"]) == 1)
            {
                if (drpPay.SelectedIndex == 2 && Convert.ToDecimal(Session["downpayment"]) < 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please pay downpayment amount first');", true);
                    drpPay.SelectedIndex = -1;
                }
                else if (drpPay.SelectedIndex == 3 && Convert.ToDecimal(Session["instalment1"]) < 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please pay Instalment-1 amount first');", true);
                    drpPay.SelectedIndex = -1;
                }
                else if (drpPay.SelectedIndex == 4 && Convert.ToDecimal(Session["instalment2"]) < 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please pay Instalment-2 amount first');", true);
                    drpPay.SelectedIndex = -1;
                }
                else
                {
                    ddlInst.Visible = true;
                    drpPay.Visible = false;
                    Panel1.Visible = true;
                }
            }
        }
        protected DataTable isAlreadySubmitted(string unitID, string requestID)
        {
            DataTable ds = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Offline_PaymentDetailByRM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unitID", unitID);
                cmd.Parameters.AddWithValue("@requestID", requestID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //    throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        protected void btn_Click(Object sender, EventArgs e)
        {
            bool flag = false;
            btnSubmit.Enabled = false;
            RequestID = txtReqID.Text.Trim();
            UnitID = txtUnitID.Text.Trim();
            PaymentType = "Demand Draft";
            DataTable dts = new DataTable();
            dts = isAlreadySubmitted(txtUnitID.Text.Trim(), txtReqID.Text.Trim());
            if (dts.Rows.Count > 0) { }
            else { 
            if (Convert.ToInt32(Session["schemeType"]) == 0)
            {
                if (drpPay.SelectedValue == "-1")
                {
                    string message1 = "Please Select Payment";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    RecallController();
                }
            }
            else if (Convert.ToInt32(Session["schemeType"]) == 1)
            {
                if (ddlInst.SelectedValue == "-1")
                {
                    string message1 = "Please Select Payment";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                        RecallController();
                }
            }
            if (CheckBox1.Checked && (drpPay.SelectedValue != "-1" || ddlInst.SelectedValue != "-1"))
            {
                try
                {
                    if (FileUpload2.HasFile && FileUpload1.HasFile && CheckBox1.Checked)
                    {
                        string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        string filename1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        string contentType = FileUpload2.PostedFile.ContentType;
                        string contentType1 = FileUpload1.PostedFile.ContentType;
                        Stream fs1 = FileUpload1.PostedFile.InputStream;
                        BinaryReader br1 = new BinaryReader(fs1);
                        byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);
                        using (Stream fs = FileUpload2.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                                using (SqlConnection con = new SqlConnection(constr))
                                {
                                    using (SqlCommand cmd = new SqlCommand("usp_setOfflinePayment", con))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@UnitID", UnitID);
                                        cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                                        cmd.Parameters.AddWithValue("@RequestID", RequestID);
                                        cmd.Parameters.AddWithValue("@SchemeType", Convert.ToInt32(Session["schemeType"]));
                                        cmd.Parameters.AddWithValue("@Payment1", drpPay.SelectedValue);
                                        cmd.Parameters.AddWithValue("@Payment2", ddlInst.SelectedValue);
                                        cmd.Parameters.AddWithValue("@PaymentAmount", txtAmountPaid.Text.Trim());
                                        cmd.Parameters.AddWithValue("@DateOfReceipt", txtRecDate.Text.Trim());
                                        cmd.Parameters.AddWithValue("@ReceiptNo", txtChallanNo.Text.Trim());
                                        cmd.Parameters.AddWithValue("@ReceiptCopy", bytes1);
                                        cmd.Parameters.AddWithValue("@NoteSheetCopy", bytes);
                                        cmd.Parameters.AddWithValue("@Doctype1", contentType1);
                                        cmd.Parameters.AddWithValue("@Doctype", contentType);
                                        cmd.Parameters.AddWithValue("@checked", 1);
                                        cmd.Parameters.AddWithValue("@isRealised", false);
                                        cmd.Parameters.AddWithValue("@BankName", txtBankName.Text.Trim());
                                        cmd.Parameters.AddWithValue("@DDDate", txtDDate.Text.Trim());
                                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                        DataTable dt = new DataTable();
                                        adp.Fill(dt);
                                        if (dt.Rows.Count > 0)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "alert('Payment Updated successfully.');", true);
                                            //GetApplicantDetails(dt, bytes);
                                            //Response.Redirect("~/OTSGrievancesMIS.aspx");
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "alert('Please fill all fields');", true);
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "call_show", "alert('Please upload pdf file.');", true);
                        //Mention Alert msg for File not uploaded
                        //Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select all mandatory fields.');", true);
            }
        }
        }
        protected void CheckedChanged(Object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                btnSubmit.Enabled = true;


            }
            else
            {
                btnSubmit.Enabled = false;
            }
            Panel1.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = true;
            if (lblPaymentType.Text == "One Time")
            {
                drpPay.Visible = true;
            }
            else if (lblPaymentType.Text == "Instalment")
            {
                ddlInst.Visible = true;
            }
        }
        protected void Click_Radio(Object sender, EventArgs e)
        {
            if (RadioYes.Checked)
            {
                Panel1.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = true;
                Panel5.Visible = true;
                btnSubmit.Enabled = true;
                txtRelDate.Text = null;
                txtRelDate.Enabled = true;

            }
            else
            {
                Panel1.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = true;
                Panel5.Visible = true;
                btnSubmit.Enabled = false;
                txtRelDate.Text = null;
                txtRelDate.Enabled = false;
            }
            if (lblPaymentType.Text == "One Time")
            {
                drpPay.Visible = true;
            }
            else if (lblPaymentType.Text == "Instalment")
            {
                ddlInst.Visible = true;
            }
        }
        protected void btn_RealisedClick(Object sender, EventArgs e)
        {
            RequestID = txtReqID.Text.Trim();
            UnitID = txtUnitID.Text.Trim();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_Update_Offlinedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@isrealised", 1);
            cmd.Parameters.AddWithValue("@RealisedDate", txtRelDate.Text.Trim());
            cmd.Parameters.AddWithValue("@RequestID", RequestID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["Flag"]) == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "call_show", "alert('Realisation Date saved successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "call_show", "alert('Either RequestID is not Correct or already realised against given RequestID.');", true);
                }
            }
        }
        protected void RecallController()
        {
            Panel1.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = true;
            btnRel.Visible = false;
            btnSubmit.Visible = true;
            if (Convert.ToInt32(Session["schemeType"]) == 0)
            {
                ddlInst.Visible = false;
                drpPay.Visible = true;
                lblPaymentType.Text = "One Time";
            }
            if (Convert.ToInt32(Session["schemeType"]) == 1)
            {
                ddlInst.Visible = true;
                drpPay.Visible = false;
                lblPaymentType.Text = "Instalment";
            }
        }
        //protected void setUploadButtonState(Object sender, EventArgs e)
        //{

        //}
    }
}