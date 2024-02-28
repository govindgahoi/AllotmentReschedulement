using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_CommentsPIP : System.Web.UI.UserControl
    {
        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        public string ServiceReqNo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            CommitteeLettersUploaded();

            Get_Notesheet_of_service(ServiceReqNo);

        }
        private DataTable Getdata1
        {
            get; set;
        }

        private void CommitteeLettersUploaded()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetServiceChecklists_PIP_Comm '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = Getdata1;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }

    

    public void Get_Notesheet_of_service(string ServiceReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            string CommentDate = "";
            DataSet dsR = new DataSet();
            try
            {
                DivNotesheet.Text = "";
                dsR = objServiceTimelinesBLL.Get_Notesheet_of_application_PIP(ServiceReqNo);
                if (dsR.Tables.Count > 1)
                {
                    if (dsR.Tables[1].Rows.Count > 0)
                    {

                        IEnumerable<DataRow> orderedRows = dsR.Tables[1].AsEnumerable().OrderBy(r => r.Field<DateTime>("Entry_Time"));
                        DataTable dt = dsR.Tables[0];


                        if (dt.Rows.Count > 0)
                        {

                            int i = 0;



                            DivNotesheet.Text += @"<div style=''>
                                                <div class='panel-group' id='accordion'>";

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow drP in dt.Rows)
                                {

                                    string From = drP["FromUser"].ToString();
                                    string To = drP["ToUser"].ToString();
                                    string comment = drP["Remark"].ToString();
                                    string datetime = drP["Entry_Time"].ToString();
                                    string fromDes = drP["Transfer_From"].ToString();
                                    string toDes = drP["Transfer_To"].ToString();
                                    string Status = drP["Status"].ToString();
                                    string Designationfrom = drP["FromDesignation"].ToString();
                                    string DesignationTo = drP["ToDesignation"].ToString();
                                    string Comments = drP["Comments"].ToString();
                                    string OutStatus = drP["OutStatus"].ToString();
                                    string filePath = drP["DocPath"].ToString();
                                    string filePath1 = drP["UserDocPath"].ToString();
                                    string IDs = drP["id"].ToString();
                                    string Reminder1 = drP["Reminder1"].ToString();
                                    string Reminder2 = drP["Reminder2"].ToString();
                                    string Reminder3 = drP["Reminder3"].ToString();
                                    string Reminder4 = drP["Reminder4"].ToString();
                                    string Reminder5 = drP["Reminder5"].ToString();

                                    if (drP["CommentDate"].ToString().Length > 0)
                                    {

                                        CommentDate = Convert.ToDateTime(drP["CommentDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
                                    }
                                    else
                                    {
                                        CommentDate = "Not Available";
                                    }




                                    DivNotesheet.Text += @"<div style='border: 1px solid #ccc;padding:6px;margin:6px 0;background: #ccc;'>
                                                          <div style='border: 1px solid #ccc;' class='panel panel-default'>";

                                    DivNotesheet.Text += @"<div class='form-group'>
                                        <div class='col-md-9 col-sm-9 col-xs-9' style='padding: 10px 13px;font-size:12px;'><b></b> " + comment + @"</div>                                       
    <div class='col-md-3 col-sm-3 col-xs-3'>
    <div class='col-md-12 col-sm-12 col-xs-12' style='background: #f7f7f7; padding: 10px 13px;font-size:12px;margin: 5px 0;'><b></b>" + Status + @"</div>
    <div class='col-md-12 col-sm-12 col-xs-12' style='padding: 10px 13px;'></div>
    <div class='col-md-12 col-sm-12 col-xs-12' style='font-size: 12px;background: #f7f7f7;padding: 0 10px;'>" + From + @"</div>
    <div class='col-md-12 col-sm-12 col-xs-12' style='font-size: 12px;background: #f7f7f7;padding: 0 10px;'>" + Designationfrom + @"</div>
    <div class='col-md-12 col-sm-12 col-xs-12'style='background: #f7f7f7; padding: 0 10px;font-size:12px;'><b></b>" + Convert.ToDateTime(datetime).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"</div>
    </div> 
    <div class='clearfix'></div>";

                                    if (filePath1.Length > 0)
                                    {
                                        DivNotesheet.Text += "</div><div class='col-md-10 col-sm-10 col-xs-10'style='background: #f7f7f7;border:1px solid #ccc; padding: 10px 13px;font-size:12px;'><b></b>" + To + "(" + DesignationTo + ')' + @"</div>";
                                        //DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""http://localhost:50610" + filePath1.Trim().Remove(0, 1) + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";
                                        DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""" + filePath1.Trim().Remove(0, 1) + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";

                                    }
                                    else
                                    {
                                        DivNotesheet.Text += "</div><div class='col-md-12 col-sm-12 col-xs-12'style='background: #f7f7f7;border:1px solid #ccc; padding: 10px 13px;font-size:12px;'><b></b>" + To + "(" + DesignationTo + ')' + @"</div>";

                                    }
                                    DivNotesheet.Text += "</div><div class='clearfix'></div></div>";

                                    /*

                                    DivNotesheet.Text += @"<div style=''>
                                                <div class='panel-group' id='accordion'>";

                                    DivNotesheet.Text += @"<div style='border: 1px solid #ccc;padding:6px;margin:6px 0;background: #ccc;'>
                                                          <div style='border: 1px solid #ccc;' class='panel panel-default'>";

                                    DivNotesheet.Text += @"<div class='form-group'>
                                        <div class='col-md-9 col-sm-9 col-xs-9' style='padding: 10px 13px;font-size:12px;'><b></b> " + Comments + @"</div>                                       
    <div class='col-md-3 col-sm-3 col-xs-3'>
    <div class='col-md-12 col-sm-12 col-xs-12' style='background: #f7f7f7; padding: 10px 13px;font-size:12px;margin: 5px 0;'><b></b>" + OutStatus + @"</div>
    <div class='col-md-12 col-sm-12 col-xs-12' style='padding: 10px 13px;'></div>
    <div class='col-md-12 col-sm-12 col-xs-12' style='font-size: 12px;background: #f7f7f7;padding: 0 10px;'>" + To + @"</div>
    <div class='col-md-12 col-sm-12 col-xs-12' style='font-size: 12px;background: #f7f7f7;padding: 0 10px;'>" + DesignationTo + @"</div>
    <div class='col-md-12 col-sm-12 col-xs-12'style='background: #f7f7f7; padding: 0 10px;font-size:12px;'><b></b>" + CommentDate.Trim() + @"</div>
    </div> 
    <div class='clearfix'></div>";
                                    if (filePath.Length > 0)
                                    {
                                        DivNotesheet.Text += @"</div><div class='col-md-10 col-sm-10 col-xs-10' style='background: #f7f7f7;border:1px solid #ccc; padding: 10px 13px;font-size:12px;'><b></b>" + From + "(" + Designationfrom + ')' + @"</div>";
                                        // DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""http://localhost:50610" + filePath.Trim().Remove(0, 1) + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";
                                        DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""" + filePath.Trim().Remove(0, 1) + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";

                                    }
                                    else
                                    {
                                        DivNotesheet.Text += @"</div><div class='col-md-12 col-sm-12 col-xs-12' style='background: #f7f7f7;border:1px solid #ccc; padding: 10px 13px;font-size:12px;'><b></b>" + From + "(" + Designationfrom + ')' + @"</div>";

                                    }
                                    if (Reminder1 != "")
                                    {
                                        DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a>Reminder</a></div>";

                                        DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""/PIP/Reminder/" + Reminder1.Trim() + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";

                                        if (Reminder2 != "")
                                        {
                                            DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""/PIP/Reminder/" + Reminder2.Trim() + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";
                                        }
                                        if (Reminder3 != "")
                                        {
                                            DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""/PIP/Reminder/" + Reminder3.Trim() + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";
                                        }
                                        if (Reminder4 != "")
                                        {
                                            DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""/PIP/Reminder/" + Reminder4.Trim() + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";
                                        }
                                        if (Reminder5 != "")
                                        {
                                            DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""/PIP/Reminder/" + Reminder5.Trim() + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";
                                        }
                                    }
                                    DivNotesheet.Text += @"</div><div class='clearfix'></div></div>";
*/
                                }
                            }
                            
                            DivNotesheet.Text += "</div></div><br/><br/></div>";



                        }


                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

        }


    }
}