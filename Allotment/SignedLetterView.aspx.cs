using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class SignedLetterView : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        string id;
        string Doctype;
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SD = "";
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            id = Request.QueryString["ServiceRequestNo"];
            Doctype = Request.QueryString["DocType"];

             SD = id.Substring(0, 1);
            DataTable NMSWP = gm.GetNMSWPIDNews(id);
            if (NMSWP.Rows.Count > 0)
            {
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID    = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
            }
            if (!IsPostBack)
            {
                GetDetails();
            }

        }


        private void GetDetails()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetSignedLetters '" + Doctype + "','" + id + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {

                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DocumentViewer(string ServiceRequestNo, string DocType, string type)
        {
            Placeholder.Controls.Clear();

            SqlCommand cmd = new SqlCommand();
            if (type == "Letter")
            {
                if (SD == "U")
                {
                    cmd = new SqlCommand(@"select Id , SignedDocumentContent , SignedDocument from 
                                              [dbo].[Repositoryforoldapplicant] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);
                }
                else
                {
                    cmd = new SqlCommand(@"select Id , SignedDocumentContent , SignedDocument from 
                                              [dbo].[Repository] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);
                }
            }
            if (type == "Map")
            {
                if (SD == "U")
                {
                    cmd = new SqlCommand(@"select Id ,SignedMapContent 'SignedDocumentContent' , SignedMap 'SignedDocument' from 
                                              [dbo].[Repositoryforoldapplicant] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);

                }
                else
                {
                    cmd = new SqlCommand(@"select Id ,SignedMapContent 'SignedDocumentContent' , SignedMap 'SignedDocument' from 
                                              [dbo].[Repository] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);
                }
            }

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SignedDocument"].ToString().Length > 0)
                    {

                        byte[] Document = (byte[])dt.Rows[0]["SignedDocument"];
                        String base64EncodedPdf = System.Convert.ToBase64String(Document);
                        string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                        Literal ltEmbed = new Literal();
                        ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
                        Placeholder.Controls.Add(ltEmbed);
                    }
                }
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index           = index % GridView2.PageSize;
                string SerReqNo = GridView2.DataKeys[index].Values[0].ToString();
                string Service  = GridView2.DataKeys[index].Values[1].ToString();
                string DoccType = GridView2.DataKeys[index].Values[2].ToString();
                if (e.CommandName == "selectDocument")
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        if (Service == "Letter")
                        {
                            if (SD == "U")
                            {
                                cmd = new SqlCommand("select AllotmentLetterNo,SignedDocument 'Letter', SignedDocumentContent 'ContentType',DocType from Repositoryforoldapplicant where ServiceRequestNo='" + id + "' ", con);

                            }
                            else
                            {
                                cmd = new SqlCommand("select AllotmentLetterNo,SignedDocument 'Letter', SignedDocumentContent 'ContentType',DocType from Repository where ServiceRequestNo='" + id + "' and DocType='"+DoccType+"' ", con);
                            }
                        }
                        if (Service == "Map")
                        {
                            if (SD == "U")
                            {
                                cmd = new SqlCommand("select AllotmentLetterNo,SignedMap 'Letter',SignedMapContent 'ContentType',DocType from Repositoryforoldapplicant where ServiceRequestNo='" + id + "' ", con);

                            }
                            else
                            {
                                cmd = new SqlCommand("select AllotmentLetterNo,SignedMap 'Letter',SignedMapContent 'ContentType','SignedMap' DocType from Repository where ServiceRequestNo='" + id + "' ", con);
                            }
                        }

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {
                    DocumentViewer(id, Doctype, Service);

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
                string doctype = dt.Rows[0]["DocType"].ToString();
                if (dt.Rows[0]["Letter"].ToString().Length > 0)
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType"].ToString();
                    Response.AddHeader("content-disposition", "attachment;filename=" + doctype + ".pdf");
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            try
            {


                string ControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCControlID);
                string UnitID    = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCUnitID);
                string ServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCServiceID);
                string DeptID    = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
                string PassSalt  = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
                NameValueCollection collections = new NameValueCollection();
                collections.Add("Dept_Code", DeptID.Trim());
                collections.Add("ControlID", ControlID.Trim());
                collections.Add("UnitID"   , UnitID.Trim());
                collections.Add("ServiceID", ServiceID.Trim());
                collections.Add("PassSalt" , PassSalt.Trim());

                string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Bck_page.aspx";

                string html = "<html><head>";
                html += "</head><body onload='document.forms[0].submit()'>";
                html += string.Format("<form name='PostForm' style='display:none;' method='POST' action='{0}'>", remoteUrl);
                foreach (string key in collections.Keys)
                {
                    html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
                }
                html += "</form></body></html>";
                Response.Clear();
                Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.HeaderEncoding  = Encoding.GetEncoding("ISO-8859-1");
                Response.Charset = "ISO-8859-1";
                Response.Write(html);
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }




}
