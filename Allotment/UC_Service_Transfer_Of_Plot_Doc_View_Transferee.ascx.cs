using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;
using System.Configuration;




namespace Allotment
{
    public partial class UC_Service_Transfer_Of_Plot_Doc_View_Transferee : System.Web.UI.UserControl
    {
       

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        #endregion


        SqlConnection con;
       
        public string SerReqID { get; set; }

        public string checklistid { get; set; }

        // "ENTRY", "VIEW"
        public string page_type { get; set; }


        public void Page_Load(object sender, EventArgs e)
        {      
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            BindServiceCheckListGridView();
            this.RegisterPostBackControl();
        }

        private void RegisterPostBackControl()
        {

            foreach (GridViewRow row in GridView2.Rows)
            {
                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);

           

            }
        }   
        public void BindServiceCheckListGridView()
        {

            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = SerReqID.Split('/');
                objServiceTimelinesBEL.ServiceTimeLines = "1000";
                objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetTransfreeDocuments(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    { 

                        GridView2.DataSource = ds;
                        GridView2.DataBind();

                    }
                    else
                    {

                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }  
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            int CheckId = 0;
            string AllottementLetterNo = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);


                string[] SerIdarray = SerReqID.Split('/');
                if (checklistid == "" || checklistid == null)
                {
                    AllottementLetterNo = SerIdarray[2];
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Select AllotteeID from AllotteeApplicationRegister where ApplicationId='" + SerReqID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        AllottementLetterNo = dt.Rows[0]["AllotteeID"].ToString();
                    }

                }


                objServiceTimelinesBEL.UserName = AllottementLetterNo;
                Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

                string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();
                CheckId = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());


                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
                        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                        objServiceTimelinesBEL.ServiceTimeLinesID = 1000;
                        objServiceTimelinesBEL.DocumentID = DocumentID;
                        ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download(dtDoc1);
                        }
                        else
                        {
                            ltEmbed.Text = "";
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {


                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = 1000;
                    objServiceTimelinesBEL.DocumentID = DocumentID;

                    ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);

                    DataTable dtDoc = ds.Tables[0];

                    if (dtDoc.Rows.Count > 0)
                    {

                        string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();


                        if (contype == "dwg")
                        {
                            Response.Write("<script>window.open ('Default1.aspx?ServiceReqNo=" + SerReqID.Trim() + "&ServiceId=" + Service_Id + "','_blank');</script>");
                        }
                        else
                        {

                            string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                        If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                        or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                        </object><br/>";

                            ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer.ashx?ServiceRequestNO=" + SerReqID.Trim() + "&ServiceCheckListsID=" + Service_Id + "&ServiceTimeLinesID=1000&DocId=" + DocumentID + ""));
                        }
                    }
                    else
                    {
                        ltEmbed.Text = "";
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        private void download(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["ColName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}






