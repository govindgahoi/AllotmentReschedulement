using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment.AllotteePanel
{
    public partial class Allottee_Master : System.Web.UI.MasterPage
    {

        Classes.Class1 cs = new Classes.Class1();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {


            //if (lblname.Text == "")
            //{
            //    Response.Redirect("/AllotteLogin.aspx");
            //}
            //else
            //{

            //    lblname.Text = Convert.ToString(Session["UserId"]);
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        cs.str = " SELECT AID,AllotteeName,EmailID, MobNo  FROM AlloteeRegistration  WHERE Userid='" + Session["UserId"] + "'";
                        dt = cs.GetDataTable(cs.str);
                        if (dt.Rows.Count > 0)
                        {
                            lblname.Text = dt.Rows[0]["AllotteeName"].ToString();
                            Session["AllotteeName"] = lblname.Text;
                            Session["Email"] = dt.Rows[0]["EmailID"].ToString();
                            Session["MobNo"] = dt.Rows[0]["MobNo"].ToString();
                            Session["AID"] = dt.Rows[0]["AID"].ToString();
                            lbluserid.Text = Convert.ToString(Session["UserId"]);
                        }
                    }
                    catch
                    {
                        //Response.Redirect("/AllotteLogin.aspx");
                    }


                }
            }
            else
            {
                Response.Redirect("AllotteeLogin.aspx");
            }
        }
    }
}