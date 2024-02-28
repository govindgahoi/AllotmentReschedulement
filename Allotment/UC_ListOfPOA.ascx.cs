using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_ListOfPOA : System.Web.UI.UserControl
    {
        SqlConnection con;
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
        public string IAID = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        public string IAIDs { get; set; }
        string UserName = "";
        string AllotteeID = "";
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.RegisterPostBackControl();
                string[] SerIdarray = ServiceReqNo.Split('/');

                AllotteeID = SerIdarray[2].Trim();

                Page.Form.Enctype = "multipart/form-data";


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }

                BindAppointmentToDdl();

            }
            catch (Exception ex) { }

        }




        private void BindAppointmentToDdl()
        {
            SqlCommand cmd = new SqlCommand("GetListOfPOA '" + IAIDs + "','" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = ds.Tables[0];
            dt1 = ds.Tables[1];

            if (dt.Rows.Count > 0)
            {
                gvImages.DataSource = dt;
                gvImages.DataBind();
            }
            if (dt1.Rows.Count > 0)
            {
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["POAPhoto"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
                string imageUrl1 = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["POASign"]);
                (e.Row.FindControl("Image2") as Image).ImageUrl = imageUrl1;
            }
        }




        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);


        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)

        {



            CheckBox chk = (CheckBox)sender;

            GridViewRow gv = (GridViewRow)chk.NamingContainer;

            int rownumber = gv.RowIndex;



            if (chk.Checked)

            {

                int i;

                for (i = 0; i <= gvImages.Rows.Count - 1; i++)

                {

                    if (i != rownumber)

                    {

                        CheckBox chkcheckbox = ((CheckBox)(gvImages.Rows[i].FindControl("chkRow")));

                        chkcheckbox.Checked = false;

                    }

                }

            }

        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {

                int count = 0;
                int retVal1 = 0;

                foreach (GridViewRow row in gvImages.Rows)
                {
                    if ((row.FindControl("chkRow") as CheckBox).Checked)
                    {
                        count = count + 1;
                        string ID = ((Label)row.Cells[0].FindControl("POAID")).Text;
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                        objServiceTimelinesBEL.POAID = ID;
                        retVal1 = objServiceTimelinesBLL.AssignPOA(objServiceTimelinesBEL);
                    }

                }
                if (count <= 0)
                {
                    MessageBox1.ShowWarning("Please Select Any POA To Assign");
                }
                if (retVal1 > 0)
                {
                    MessageBox1.ShowSuccess("POA Assigned Successfully");
                    BindAppointmentToDdl();

                }

            }
            catch (Exception ex)
            {

                MessageBox1.ShowError(ex.ToString());
            }
        }
    }
}