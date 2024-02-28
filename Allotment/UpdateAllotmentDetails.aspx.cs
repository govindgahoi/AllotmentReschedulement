using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class UpdateAllotmentDetails : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        string IndustrialArea = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;

                
                if (!IsPostBack)
                {

                    GetIAAssociatedWithRM(UserName, Session["Type"].ToString().Trim());
                    //GridView_Load();

                }



            }
            catch
            {
                //Response.Redirect("/Default.aspx");
            }

        }

        private void GetIAAssociatedWithRM(string userName, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = userName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIAAssociatedWithRM(objServiceTimelinesBEL);
                DlIA.DataSource = ds;
                DlIA.DataTextField = "IAName";
                DlIA.DataValueField = "IAName";
                DlIA.DataBind();
                ListItem liIArea = new ListItem("--Select All--", "-1");
                DlIA.Items.Insert(0, liIArea);
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

     
        protected void DlIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //panel.Visible = false;
            if (DlIA.SelectedIndex == 0)
            {
                DropDownList3.SelectedIndex = 0;
                txtSearch.Text = "";
                DropDownList3.Enabled = false;
                txtSearch.Enabled = false;
            }
            else
            {
                DropDownList3.SelectedIndex = 0;
                DropDownList3.Enabled = true;
                //Label2.Visible = false;
            }
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (DlIA.SelectedIndex == 0)
            {
                txtSearch.Text = "";
                txtSearch.Enabled = false;
            }
            else
            {
                txtSearch.Enabled = true;
                //Label2.Visible = false;
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public  List<string> GetAutoCompleteData(string txtSearch)
        {
            List<string> result = new List<string>();
           string IndustrialArea = DlIA.SelectedValue;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_getAllotteeName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@IAName", IndustrialArea);
            cmd.Parameters.AddWithValue("@AllotteeName", txtSearch);
            SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["AllotteeName"].ToString());
                    }
                    return result;
        }

        protected void GridView_Load(object sender, EventArgs e)
        {
            string IA = "G.C. Jainpur";
            string PltNo = "E-93";
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_getAllotteeName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IAName", IA);
            cmd.Parameters.AddWithValue("@PlotNo", PltNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gridView.DataSource = dt;
                gridView.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gridView.DataSource = dt;
                gridView.DataBind();
                //int columncount = gridView.Rows[0].Cells.Count;
                lblmsg.Text = " No data found !!!";
            }
        }
        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            //GridView_Load();
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string stor_id = gridView.DataKeys[e.RowIndex].Values["stor_id"].ToString();
            TextBox stor_name = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtname");
            TextBox stor_address = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtaddress");
            TextBox city = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtcity");
            TextBox state = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtstate");
            TextBox zip = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtzip");
            con.Open();
            SqlCommand cmd = new SqlCommand("update stores set stor_name='" + stor_name.Text + "', stor_address='" + stor_address.Text + "', city='" + city.Text + "', state='" + state.Text + "', zip='" + zip.Text + "' where stor_id=" + stor_id, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.BackColor = Color.Blue;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = stor_id + "        Updated successfully........    ";
            gridView.EditIndex = -1;
            //GridView_Load();
        }
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            //GridView_Load();
        }
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string stor_id = gridView.DataKeys[e.RowIndex].Values["stor_id"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from stores where stor_id=" + stor_id, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                //GridView_Load();
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = stor_id + "      Deleted successfully.......    ";
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string stor_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "stor_id"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + stor_id + "')");
                }
            }
        }
        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox instorid = (TextBox)gridView.FooterRow.FindControl("instorid");
                TextBox inname = (TextBox)gridView.FooterRow.FindControl("inname");
                TextBox inaddress = (TextBox)gridView.FooterRow.FindControl("inaddress");
                TextBox incity = (TextBox)gridView.FooterRow.FindControl("incity");
                TextBox instate = (TextBox)gridView.FooterRow.FindControl("instate");
                TextBox inzip = (TextBox)gridView.FooterRow.FindControl("inzip");
                con.Open();
                SqlCommand cmd =
                    new SqlCommand(
                        "insert into stores(stor_id,stor_name,stor_address,city,state,zip) values('" + instorid.Text + "','" +
                        inname.Text + "','" + inaddress.Text + "','" + incity.Text + "','" + instate.Text + "','" + inzip.Text + "')", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result == 1)
                {
                    //GridView_Load();
                    lblmsg.BackColor = Color.Green;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = instorid.Text + "      Added successfully......    ";
                }
                else
                {
                    lblmsg.BackColor = Color.Red;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = instorid.Text + " Error while adding row.....";
                }
            }
        }
    }
}