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
    public partial class UC_Comments : System.Web.UI.UserControl
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
            Get_Notesheet_of_service(ServiceReqNo);


        }


        public void Get_Notesheet_of_service(string ServiceReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                DivNotesheet.Text = "";
                dsR = objServiceTimelinesBLL.Get_Notesheet_of_application(ServiceReqNo);
                if (dsR.Tables.Count > 1)
                {
                    if (dsR.Tables[1].Rows.Count > 0)
                    {

                        IEnumerable<DataRow> orderedRows = dsR.Tables[1].AsEnumerable().OrderBy(r => r.Field<DateTime>("Entry_Time"));
                        DataTable dt = dsR.Tables[0];

                        DataTable dt_DistinctCommittee = orderedRows.CopyToDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            string ApplicantName = dt.Rows[0][0].ToString();
                            string PlotNo = dt.Rows[0][1].ToString();
                            string ApplicationDate = dt.Rows[0][2].ToString();
                            string WeakStart = dt.Rows[0][3].ToString();
                            string WeakEnd = dt.Rows[0][4].ToString();

                            int i = 0;
                            DivNotesheet.Text += @"<div style=''>
                                                <div class='panel-group' id='accordion'>";


                            DivNotesheet.Text += @"
                                               <div style='' class='panel panel-default'>
                                                        <div  class='panel-heading' style='font-size:15px !important;font-weight:700;background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #d8d8d8), color-stop(1, #fafafa));'>Applicant :  " + ApplicantName + @"
                                                            <span  class='pull-right'>Service No :<span class='span'>" + ServiceReqNo + @"</span></span>
                                                        </div>
<div  class='panel-heading' style='font-size:15px !important;font-weight:700;background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #d8d8d8), color-stop(1, #fafafa));'>Plot No :  " + PlotNo + @"
                                                            <span  class='pull-right'>Application Date :<span class='span'>" + ApplicationDate + @"</span></span>
                                                        </div>
<div  class='panel-heading' style='font-size:15px !important;font-weight:700;background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #d8d8d8), color-stop(1, #fafafa));'>Weak Start :  " + WeakStart + @"
                                                            <span  class='pull-right'>Weak End :<span class='span'>" + WeakEnd + @"</span></span>
                                                        </div>
                                                        <div>
                                                        ";

                            if (dt_DistinctCommittee.Rows.Count > 0)
                            {
                                foreach (DataRow drP in dt_DistinctCommittee.Rows)
                                {

                                    string From     = drP["FromUser"].ToString();
                                    string To       = drP["ToUser"].ToString();
                                    string comment  = drP["Remark"].ToString();
                                    string datetime = drP["Entry_Time"].ToString();
                                    string fromDes  = drP["Transfer_From"].ToString();
                                    string toDes    = drP["Transfer_To"].ToString();
                                    string Status   = drP["Status"].ToString();
                                    string Designationfrom = drP["FromDesignation"].ToString();
                                    string DesignationTo = drP["ToDesignation"].ToString();
                                    string filePath      = drP["DocPath"].ToString();


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
                                    if (filePath.Length > 0)
                                    {
                                        DivNotesheet.Text += @"</div><div class='col-md-10 col-sm-10 col-xs-10' style='background: #f7f7f7;border:1px solid #ccc; padding: 10px 13px;font-size:12px;'><b></b>" + To + "(" + DesignationTo + ')' + @"</div>";
                                        DivNotesheet.Text += @"<div class='col-md-2 col-sm-2 col-xs-2' style='background: #f7f7f7;border:1px solid #ccc; padding: 7px 13px;font-size:12px;'><b></b><a href=""https://eservices.onlineupsidc.com/" + filePath.Trim().Remove(0, 1) + @""" Target='_blank'><img src='images/file-pdf-icon.png' height='22px' /></a></div>";
                                    }
                                    else
                                    {
                                        DivNotesheet.Text += "</div><div class='col-md-12 col-sm-12 col-xs-12' style='background: #f7f7f7;border:1px solid #ccc; padding: 10px 13px;font-size:12px;'><b></b>" + To + "(" + DesignationTo + ')' + @"</div>";

                                    }
                                    DivNotesheet.Text += "</div><div class='clearfix'></div></div>";




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