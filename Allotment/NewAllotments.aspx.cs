using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class NewAllotments : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {

                // BindServiceRequestGridView();
                Bind_Announcement_List_GridView();
                BindGridInprocess();
                //drpdnRaiseReQ();
            }
        }

        private DataTable Getdata2
        {
            get; set;
        }

        private void BindGridInprocess()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";


                ds = objServiceTimelinesBLL.BindGridInprocess(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata4 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }

                //Getdata1 = ds.Tables[1];
                //Getdata3 = ds.Tables[2];
                if (ds.Tables[0].Rows.Count > 0)
                {

                    GridViewInProcess.DataSource = Getdata2;
                    GridViewInProcess.DataBind();

                }
                else
                {
                    GridViewInProcess.DataSource = null;
                    GridViewInProcess.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Getdata4 = ds.Tables[1];
                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        private void BindGridCompleted()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";


                ds = objServiceTimelinesBLL.BindGridInprocess(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }


                //Getdata1 = ds.Tables[1];
                //Getdata3 = ds.Tables[2];
                if (ds.Tables[0].Rows.Count > 0)
                {

                    GridViewcompleted.DataSource = Getdata2;
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
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();
                    grid_Announcement_List.DataSource = ds.Tables[0];
                    grid_Announcement_List.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    grid_Announcement_List.DataSource = null;
                    grid_Announcement_List.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[1];
                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private DataTable Getdata1
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }

        private DataTable Getdata3
        {
            get; set;
        }




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
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserId = _objLoginInfo.userid;
                objServiceTimelinesBEL.IAId = Int32.Parse(drpdnRaiseReQ.SelectedValue.ToString());

                // Create ticket for Verification


                Int32 retVal = objServiceTimelinesBLL.ServicePacketCreationforaAllotment(objServiceTimelinesBEL);
                if (retVal >= 0)
                {
                    string str = string.Empty;
                    if (retVal == 2) { str = "Already One Packet for Industrial Area is in Process! Please Close the existing request first"; }
                    if (retVal == 3) { str = "Application is already in process"; }
                    if (retVal == 4) { str = "Packet Created"; }
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + str + "');", true);
                    Bind_Announcement_List_GridView();
                    BindGridInprocess();

                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "alert('Unable to create packet. Please Contact Administrator');", true);
                    return;
                }


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


        protected void drpdnRaiseReQInprocess_IndexChanged(object sender, EventArgs e)
        {
            DropDownList drpdnRaiseReQInprocess = (DropDownList)sender;
            GridViewRow gridrow = (GridViewRow)drpdnRaiseReQInprocess.NamingContainer;
            int rowIndex = gridrow.RowIndex;

            string PacketId = (gridrow.FindControl("PacketId") as HiddenField).Value;





            try
            {
                if (drpdnRaiseReQInprocess.SelectedValue.ToString() != "Please Select")
                {
                    objServiceTimelinesBEL.packetID = Int32.Parse(PacketId);
                    objServiceTimelinesBEL.operationID = Int32.Parse(drpdnRaiseReQInprocess.SelectedValue.ToString());


                    //GeneralMethod gm = new GeneralMethod();
                    //string Data_string  =  gm.GetDataManagerByPacketAndStage(objServiceTimelinesBEL.packetID, objServiceTimelinesBEL.operationID);


                    try
                    {
                        //if (Data_string.Length > 0)
                        //{
                        string Message_show = objServiceTimelinesBLL.ServiceTicketCreationforaAllotment(objServiceTimelinesBEL);

                        MessageBox1.ShowSuccess(Message_show);
                        Bind_Announcement_List_GridView();
                        BindGridInprocess();
                        //}
                        //else
                        //{
                        //    string Message_show = "Plese Assign Roll  For " + drpdnRaiseReQInprocess.SelectedItem.Text.Trim();
                        //    MessageBox1.ShowSuccess(Message_show);
                        //}
                    }

                    catch (Exception ex)
                    {
                        string Message_show = "Error Occured In Ticket Creation !";
                        MessageBox1.ShowSuccess(Message_show);
                    }
                }
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
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string id1 = GridView2.DataKeys[e.Row.RowIndex].Value.ToString();
                    DataTable dt = Getdata1.Clone();
                    foreach (DataRow dr in Getdata1.Rows)
                    {

                        if (dr[0].ToString() == id1)
                        {
                            DataRow newdr = dt.NewRow();
                            newdr[0] = dr[0];
                            newdr[1] = dr[1];
                            newdr[2] = dr[2];
                            newdr[3] = dr[3];
                            newdr[4] = dr[4];
                            newdr[5] = dr[5];
                            newdr[6] = dr[6];
                            newdr[7] = dr[7];
                            newdr[8] = dr[8];
                            newdr[9] = dr[9];
                            newdr[10] = dr[10];
                            newdr[11] = dr[11];
                            newdr[12] = dr[12];
                            newdr[13] = dr[13];
                            newdr[14] = dr[14];
                            dt.Rows.Add(newdr);
                        }
                    }
                    GridView grdview = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
                    grdview.DataSource = dt;
                    grdview.DataBind();

                    int index = e.Row.RowIndex;

                    DropDownList drpdnRaiseReQ = (e.Row.FindControl("drpdnRaiseReQ") as DropDownList);
                    if (drpdnRaiseReQ != null)
                    {
                        drpdnRaiseReQ.Items.Add(new ListItem("Please Select", "Please Select"));


                        DataTable dt2 = Getdata2.Copy();

                        int ispacketCreated = Int32.Parse(dt2.Rows[index][8].ToString());
                        if (ispacketCreated == 0) { drpdnRaiseReQ.Items.Add(new ListItem("Create Packet", dt2.Rows[index][0].ToString())); }


                    }



                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        protected void GridViewInProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string id1 = GridViewInProcess.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string PacketID = GridViewInProcess.DataKeys[e.Row.RowIndex].Values[1].ToString();
                DataTable dt2 = Getdata3.Copy();
                if (Getdata4 != null)
                {
                    DataRow[] row = Getdata4.Select("PacketID=" + PacketID);


                    if (row.Count() > 0)
                    {
                        DataTable dt = row.CopyToDataTable();
                        //foreach (DataRow dr in dt.Rows)
                        //{

                        //    if (dr[0].ToString() == id1)
                        //    {
                        //        DataRow newdr = dt.NewRow();
                        //        newdr[0] = dr[0];
                        //        newdr[1] = dr[1];
                        //        newdr[2] = dr[2];
                        //        newdr[3] = dr[3];
                        //        newdr[4] = dr[4];
                        //        newdr[5] = dr[5];
                        //        newdr[6] = dr[6];
                        //        newdr[7] = dr[7];
                        //        newdr[8] = dr[8];
                        //        newdr[9] = dr[9];
                        //        newdr[10] = dr[10];
                        //        newdr[11] = dr[11];
                        //        newdr[12] = dr[12];
                        //        newdr[13] = dr[13];
                        //        newdr[14] = dr[14];

                        //        dt.Rows.Add(newdr);
                        //    }

                        //}
                        GridView grdview = e.Row.FindControl("GridViewAllotmentRequestInProcess") as GridView;
                        if (dt.Rows.Count > 0)
                        {
                            grdview.DataSource = dt;
                            grdview.DataBind();
                        }
                    }
                }

                int index = GetColumnIndexByName(e.Row, "PacketID");
                if (index > 0)
                {
                    string packetID = e.Row.Cells[index].Text;




                    DropDownList drpdnRaiseReQ = (e.Row.FindControl("drpdnRaiseReQInprocess") as DropDownList);
                    if (drpdnRaiseReQ != null)
                    {
                        drpdnRaiseReQ.Items.Add(new ListItem("Please Select", "Please Select"));
                        foreach (DataRow row in dt2.Rows)
                        {
                            if (row[0].ToString() == packetID)
                            {
                                //if (row[1].ToString() == "9")
                                //{
                                //    drpdnRaiseReQ.Visible = false;
                                //}
                                //else
                                //{
                                drpdnRaiseReQ.Items.Add(new ListItem(row[2].ToString(), row[1].ToString()));
                                //}
                            }
                        }

                    }
                }
                else
                {
                    DropDownList drpdnRaiseReQ = (e.Row.FindControl("drpdnRaiseReQInprocess") as DropDownList);
                    drpdnRaiseReQ.Items.Add(new ListItem("Close Packet", "9"));
                }




            }
        }


        int GetColumnIndexByName(GridViewRow row, string columnName)
        {
            int columnIndex = 0;
            int foundIndex = -1;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                {
                    if (((BoundField)cell.ContainingField).DataField.Equals(columnName))
                    {
                        foundIndex = columnIndex;
                        break;
                    }
                }
                columnIndex++; // keep adding 1 while we don't have the correct name
            }
            return foundIndex;
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {



        }

        protected void GridViewcompleted_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridViewInprocess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string id1 = GridViewInprocess.DataKeys[e.Row.RowIndex].Value.ToString();
            //    DataTable dt = Getdata1.Clone();
            //    foreach (DataRow dr in Getdata1.Rows)
            //    {

            //        if (dr[2].ToString() == id1)
            //        {
            //            DataRow newdr = dt.NewRow();
            //            newdr[0] = dr[0];
            //            newdr[1] = dr[1];
            //            newdr[2] = dr[2];
            //            newdr[3] = dr[3];
            //            newdr[4] = dr[4];
            //            dt.Rows.Add(newdr);
            //        }
            //    }
            //    GridView grdview = e.Row.FindControl("TicketGridinprocess") as GridView;
            //    grdview.DataSource = dt;
            //    grdview.DataBind();
            //}

        }
    }
}