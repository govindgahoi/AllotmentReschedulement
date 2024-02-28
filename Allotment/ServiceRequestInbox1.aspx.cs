using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceRequestInbox1 : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                BindServiceRequestGridView();
                Bind_Announcement_List_GridView();
            }
        }


        private void Bind_Announcement_List_GridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";

                ds = objServiceTimelinesBLL.Get_Announcement_List(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid_Announcement_List.DataSource = ds;
                    grid_Announcement_List.DataBind();
                }
                else
                {
                    grid_Announcement_List.DataSource = null;
                    grid_Announcement_List.DataBind();
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

        private DataTable Getdata1
        {
            get; set;
        }


        #region "Bind ServiceRequest  in GridView"
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserID = _objLoginInfo.userid;
                // objServiceTimelinesBEL.RequestReportType = "INBOX";

                ds = objServiceTimelinesBLL.GetServiceRequestRecords(objServiceTimelinesBEL);
                try
                {


                    Getdata1 = ds.Tables[3];
                }
                catch
                {


                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GridViewInprocess.DataSource = ds.Tables[1];
                    GridViewInprocess.DataBind();
                }
                else
                {
                    GridViewInprocess.DataSource = null;
                    GridViewInprocess.DataBind();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridViewcompleted.DataSource = ds.Tables[0];
                    GridViewcompleted.DataBind();
                }
                else
                {
                    GridViewcompleted.DataSource = null;
                    GridViewcompleted.DataBind();
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
        #endregion


        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            //this.BindServiceCheckListGridView();

        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void drpdnRaiseReQ_IndexChanged(object sender, EventArgs e)
        {
            DropDownList drpdnRaiseReQ = (DropDownList)sender;
            GridViewRow gridrow = (GridViewRow)drpdnRaiseReQ.NamingContainer;
            int rowIndex = gridrow.RowIndex;

            try
            {
                // Raise a ticket for Data Verifier to verify the service Request

                //string serviceID = ServiceID;
                //int industrialAreaID = Int32.Parse(IAID);
                //int RespondentID = Int32.Parse(drpVerifier.SelectedValue);
                //int ticketOwnerID = objServiceTimelinesBEL.UserID;
                //string[] SerArray = serviceID.Split('/');
                //int caseType = int.Parse(SerArray[1]);

                //objServiceTimelinesBEL.industrialAreaID = Int32.Parse(IAID);
                //objServiceTimelinesBEL.serviceID = ServiceID;
                //objServiceTimelinesBEL.RespondentID = RespondentID;
                //objServiceTimelinesBEL.ticketOwnerID = ticketOwnerID;
                //objServiceTimelinesBEL.caseType = caseType;



                //// Create ticket for Verification


                //int retVal = objServiceTimelinesBLL.ServiceTicketCreate(objServiceTimelinesBEL);
                //if (retVal > 0)
                //{
                //    string str = "Ticket raised for verifier to verify";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "alert('Ticket raised for verifier to verify');", true);

                //}
                //else
                //{
                //    return;
                //}


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());


            }






            foreach (GridViewRow row in GridView2.Rows)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "return confirm('Changing the language will clear the text in the textboxes. Click OK to proceed.');", true);



                if (row.RowIndex == rowIndex + 1)
                {
                    //now you are in next row. You can acces controls and make changes in the next line here
                }
            }



        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //IsAccountClear
                //IsDataVerified
                //IsDataReviewed

                DropDownList drpdnRaiseReQ = (e.Row.FindControl("drpdnRaiseReQ") as DropDownList);

                string IsAccountClear = (e.Row.FindControl("IsAccountClear") as HiddenField).Value;
                string IsDataVerified = (e.Row.FindControl("IsDataVerified") as HiddenField).Value;
                string IsDataReviewed = (e.Row.FindControl("IsDataReviewed") as HiddenField).Value;











                if (IsAccountClear == "false")
                {
                    drpdnRaiseReQ.Items.Add(new ListItem("Accounts clearence", "Accounts clearence"));
                }

                if (IsDataVerified == "false")
                {
                    drpdnRaiseReQ.Items.Add(new ListItem("Data verification", "Data verification"));
                }
                else
                {

                    if (IsDataReviewed == "false")
                    {
                        drpdnRaiseReQ.Items.Add(new ListItem("Data Review", "Data Review"));
                    }
                }



                //DropDownList drpdnRaiseReQ = (e.Row.FindControl("drpdnRaiseReQ") as DropDownList);
                ////'Add Default Item in the DropDownList
                //drpdnRaiseReQ.Items.Insert(0, new ListItem("Raise ReQ."));
                //drpdnRaiseReQ.Items.Insert(1, new ListItem("Accounts clearence"));
                //drpdnRaiseReQ.Items.Insert(2, new ListItem("Data verification"));

            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            //if (e.CommandName == "EditRow")
            //{

            //    //  pnlChecklist.Enabled = true;
            //    GridViewRow row = GridView2.SelectedRow;
            //    //  int index = e.Row.RowIndex;

            //    int index = Convert.ToInt32(e.CommandArgument);
            //    var a = GridView2.Rows[index].Cells[0].Text;
            //    var b = GridView2.Rows[index].Cells[1].Text;
            //    drplanduse.SelectedIndex = drplanduse.Items.IndexOf(drplanduse.Items.FindByText(b));
            //    txtActivity.Text = GridView2.Rows[index].Cells[2].Text;
            //    txtTimelines.Text = GridView2.Rows[index].Cells[3].Text;
            //    txtApprover.Text = GridView2.Rows[index].Cells[4].Text;
            //    lblServiceID.Text = a;
            //    pnlCheckList.Enabled = true;
            //    lnkChecklist.Visible = true;
            //    btnSubmit.Text = "Update";
            //}
            //if (e.CommandName == "DeleteRow")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    int Service_Id = Convert.ToInt32(GridView2.Rows[index].Cells[0].Text);
            //    objServiceTimelinesBEL.ServiceTimeLinesID = Service_Id;
            //    string confirmValue = Request.Form["confirm_value"];
            //    if (confirmValue == "Yes")
            //    {
            //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            //    }
            //    else
            //    {
            //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            //    }

            //    try
            //    {
            //        int retVal = objServiceTimelinesBLL.DeleteServiceRecord(objServiceTimelinesBEL);

            //        if (retVal > 0)
            //        {
            //            lblStatus.Text = "ServiceTimelines deleted successfully";
            //            lblStatus.ForeColor = System.Drawing.Color.Green;
            //            ClearAll();
            //            BindServiceTimelinesGridView();
            //            BindCategory();
            //        }
            //        else
            //        {
            //            lblStatus.Text = "ServiceTimelines couldn't be deleted";
            //            lblStatus.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write("Oops! error occured :" + ex.Message.ToString());
            //    }
            //    finally
            //    {
            //        objServiceTimelinesBEL = null;
            //        objServiceTimelinesBLL = null;
            //    }

            //}

        }

        protected void GridViewcompleted_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string id1 = GridViewcompleted.DataKeys[e.Row.RowIndex].Value.ToString();
                DataTable dt = Getdata1.Clone();
                foreach (DataRow dr in Getdata1.Rows)
                {
                    if (dr[2].ToString() == id1)
                    {
                        DataRow newdr = dt.NewRow();
                        newdr[0] = dr[0];
                        newdr[1] = dr[1];
                        newdr[2] = dr[2];
                        newdr[3] = dr[3];
                        newdr[4] = dr[4];
                        dt.Rows.Add(newdr);
                    }
                }
                GridView grdview = e.Row.FindControl("TicketGrid") as GridView;
                grdview.DataSource = dt;
                grdview.DataBind();
            }
        }

        protected void GridViewInprocess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string id1 = GridViewInprocess.DataKeys[e.Row.RowIndex].Value.ToString();
                DataTable dt = Getdata1.Clone();
                foreach (DataRow dr in Getdata1.Rows)
                {

                    if (dr[2].ToString() == id1)
                    {
                        DataRow newdr = dt.NewRow();
                        newdr[0] = dr[0];
                        newdr[1] = dr[1];
                        newdr[2] = dr[2];
                        newdr[3] = dr[3];
                        newdr[4] = dr[4];
                        dt.Rows.Add(newdr);
                    }
                }
                GridView grdview = e.Row.FindControl("TicketGridinprocess") as GridView;
                grdview.DataSource = dt;
                grdview.DataBind();
            }

        }
    }
}