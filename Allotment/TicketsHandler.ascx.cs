using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class TicketsHandler : System.Web.UI.UserControl
    {


        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            BindServiceRequestGridView();

            //universityGrid.DataSource = oGetData();
            //universityGrid.DataBind();
        }

        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserID = _objLoginInfo.userid;
                objServiceTimelinesBEL.RequestReportType = "INBOX";

                ds = objServiceTimelinesBLL.GetServiceRequestRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    universityGrid.DataSource = ds;
                    universityGrid.DataBind();
                }
                else
                {
                    universityGrid.DataSource = null;
                    universityGrid.DataBind();
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

        protected void universityGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string id1 = universityGrid.DataKeys[e.Row.RowIndex].Value.ToString();

                DataSet ds = new DataSet();
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserID = _objLoginInfo.userid;
                objServiceTimelinesBEL.RequestReportType = "INBOX";

                ds = objServiceTimelinesBLL.GetServiceRequestRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    DataTable dt = ds.Tables[0].Clone();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr[2].ToString() == id1)
                        {
                            DataRow newdr = dt.NewRow();
                            newdr[0] = dr[0];
                            newdr[1] = dr[1];
                            newdr[2] = dr[2];
                            dt.Rows.Add(newdr);
                        }
                    }
                    GridView grdview = e.Row.FindControl("clgGrid") as GridView;
                    grdview.DataSource = dt;
                    grdview.DataBind();






                }
                else
                {
                    //universityGrid.DataSource = null;
                    //universityGrid.DataBind();
                }



            }

        }

        protected void clgGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView grid = (GridView)sender;
                    string id1 = grid.DataKeys[e.Row.RowIndex].Value.ToString();


                    DataSet ds = new DataSet();
                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    objServiceTimelinesBEL.UserID = _objLoginInfo.userid;
                    objServiceTimelinesBEL.RequestReportType = "INBOX";

                    ds = objServiceTimelinesBLL.GetServiceRequestRecords(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt = ds.Tables[0].Clone();
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr[2].ToString() == id1)
                            {
                                DataRow newdr = dt.NewRow();
                                newdr[0] = dr[0];
                                newdr[1] = dr[1];
                                newdr[2] = dr[2];
                                dt.Rows.Add(newdr);
                            }
                        }
                        GridView grdview = e.Row.FindControl("branchGrid") as GridView;
                        grdview.DataSource = dt;
                        grdview.DataBind();

                    }






                    //DataTable dt = Getdata2.Clone();
                    //foreach (DataRow dr in Getdata2.Rows)
                    //{
                    //    if (dr[0].ToString() == id1)
                    //    {
                    //        DataRow newdr = dt.NewRow();
                    //        newdr[0] = dr[0];
                    //        newdr[1] = dr[1];
                    //        newdr[2] = dr[2];

                    //        dt.Rows.Add(newdr);
                    //    }
                    //}
                    //GridView grdview = e.Row.FindControl("branchGrid") as GridView;
                    //grdview.DataSource = dt;
                    //grdview.DataBind();
                }
            }
            catch { }
        }

        protected void branchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        GridView grid = (GridView)sender;
            //        string id1 = grid.DataKeys[e.Row.RowIndex].Value.ToString();
            //        DataTable dt = Getdata3.Clone();
            //        foreach (DataRow dr in Getdata3.Rows)
            //        {
            //            if (dr[0].ToString() == id1)
            //            {
            //                DataRow newdr = dt.NewRow();
            //                newdr[0] = dr[0];
            //                newdr[1] = dr[1];
            //                newdr[2] = dr[2];
            //                newdr[3] = dr[3];
            //                dt.Rows.Add(newdr);
            //            }
            //        }
            //        GridView grdview = e.Row.FindControl("studentGrid") as GridView;
            //        grdview.DataSource = dt;
            //        grdview.DataBind();
            //    }
            //}
            //catch { }

        }
    }

    //public static DataTable Getdata()
    //{
    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("UnivercityCode");
    //    dt.Columns.Add("UniversityName");
    //    dt.Rows.Add("UNS111", "Nagarjuna University");
    //    dt.Rows.Add("UNS222", "Andhra University");
    //    dt.Rows.Add("UNS333", "JNTUniversity");
    //    return dt;
    //}
    //private DataTable Getdata1
    //{
    //    get
    //    {
    //        DataTable dt = new DataTable();
    //        dt.Columns.Add("CollegeCode");
    //        dt.Columns.Add("CollegeName");
    //        dt.Columns.Add("UnivercityCode");
    //        dt.Rows.Add("CLG111", "A.B.M. Degree College", "UNS111");
    //        dt.Rows.Add("CLG222", "Raghu Institute of Technology", "UNS222");
    //        dt.Rows.Add("CLG333", "Annie Besant College of Education", "UNS111");
    //        dt.Rows.Add("CLG444", "NOVA'S INSTITUTE OF TECHNOLOGY FOR WOMEN", "UNS333");
    //        dt.Rows.Add("CLG555", "Sankethika Vidya Parishad Engineering College", "UNS222");
    //        dt.Rows.Add("CLG666", "ADARSA COLLEGE OF PHARMACY", "UNS333");
    //        dt.Rows.Add("CLG777", "BA&KR College", "UNS111");
    //        dt.Rows.Add("CLG888", "Anil Neerukonda Institute Of Technology & Science", "UNS222");
    //        dt.Rows.Add("CLG999", "Bharathi Degree College", "UNS111");
    //        dt.Rows.Add("CLG11", "AVANTHI INSTITUTE OF ENGG. & TECHNOLOGY", "UNS333");
    //        dt.Rows.Add("CLG22", "V.S.M. College of Engineering", "UNS222");
    //        dt.Rows.Add("CLG33", "AL-AMAN COLLEGE OF ENGINEERING", "UNS333");
    //        return dt;
    //    }
    //}
    //private DataTable Getdata2
    //{
    //    get
    //    {
    //        DataTable dt = new DataTable();
    //        dt.Columns.Add("CollegeCode");
    //        dt.Columns.Add("BranchCode");
    //        dt.Columns.Add("BranchName");
    //        dt.Rows.Add("CLG111", "BNC111", "ECE");
    //        dt.Rows.Add("CLG222", "BNC222", "CSC");
    //        dt.Rows.Add("CLG333", "BNC333", "EEE");
    //        dt.Rows.Add("CLG444", "BNC444", "CSC");
    //        dt.Rows.Add("CLG555", "BNC555", "EEE");
    //        dt.Rows.Add("CLG666", "BNC666", "ECE");
    //        dt.Rows.Add("CLG777", "BNC777", "EEE");
    //        dt.Rows.Add("CLG888", "BNC888", "CSC");
    //        dt.Rows.Add("CLG999", "BNC999", "ECE");
    //        dt.Rows.Add("CLG11", "BNC11", "CSC");
    //        dt.Rows.Add("CLG22", "BNC22", "EEE");
    //        dt.Rows.Add("CLG33", "BNC33", "ECE");
    //        return dt;
    //    }
    //}
    //private DataTable Getdata3
    //{
    //    get
    //    {

    //        DataTable dt = new DataTable();
    //        dt.Columns.Add("BranchCode");
    //        dt.Columns.Add("StudentID");
    //        dt.Columns.Add("StudentName");
    //        dt.Columns.Add("BranchName");
    //        dt.Rows.Add("BNC333", "SID11", "Chandrakirthi", "EEE");
    //        dt.Rows.Add("BNC111", "SID12", "Fadee", "ECE");
    //        dt.Rows.Add("BNC222", "SID13", "Paawan", "CSC");
    //        dt.Rows.Add("BNC333", "SID14", "Kaamla", "EEE");
    //        dt.Rows.Add("BNC111", "SID15", "Chandrasen", "ECE");
    //        dt.Rows.Add("BNC222", "SID16", "Kabira", "CSC");
    //        dt.Rows.Add("BNC333", "SID21", "Gaerwn", "EEE");
    //        dt.Rows.Add("BNC111", "SID22", "Gagana", "ECE");
    //        dt.Rows.Add("BNC111", "SID23", "Paddy", "ECE");
    //        dt.Rows.Add("BNC333", "SID24", "Gaganasindhu", "EEE");
    //        dt.Rows.Add("BNC222", "SID25", "Earlene", "CSC");
    //        dt.Rows.Add("BNC111", "SID26", "Edalene", "ECE");
    //        dt.Rows.Add("BNC444", "SID31", "Chandrakirthi", "CSC");
    //        dt.Rows.Add("BNC666", "SID32", "Fadee", "ECE");
    //        dt.Rows.Add("BNC555", "SID33", "Paawan", "EEE");
    //        dt.Rows.Add("BNC999", "SID34", "Kaamla", "ECE");
    //        dt.Rows.Add("BNC888", "SID35", "Chandrasen", "CSC");
    //        dt.Rows.Add("BNC777", "SID36", "Kabira", "EEE");
    //        dt.Rows.Add("BNC333", "SID41", "Gaerwn", "EEE");
    //        dt.Rows.Add("BNC555", "SID42", "Gagana", "EEE");
    //        dt.Rows.Add("BNC11", "SID43", "Paddy", "CSC");
    //        dt.Rows.Add("BNC33", "SID44", "Gaganasindhu", "ECE");
    //        dt.Rows.Add("BNC22", "SID45", "Earlene", "EEE");
    //        dt.Rows.Add("BNC444", "SID46", "Edalene", "CSC");
    //        return dt;
    //    }
    //}


}