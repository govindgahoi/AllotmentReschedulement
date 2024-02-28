using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class PMView : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
            }
            catch
            {
                UserName = "Admin1";
            }


            if (!IsPostBack)
            {
                checkuser();

            }
            checkuser();
            //  GetReviewMeeting();
        }



        public void GetReviewMeeting()
        {
            string value = Session["GroupName"] as string;

            if (!(String.IsNullOrEmpty(value)))
            {
                if (Session["GroupName"].ToString().Length > 0)
                {

                    objServiceTimelinesBEL.UserName = UserName;
                    SqlCommand cmd2 = new SqlCommand("Get_ReviewMeeting  '" + objServiceTimelinesBEL.UserName.Trim() + "' ", con);
                    SqlDataAdapter adp1 = new SqlDataAdapter(cmd2); DataTable dt = new DataTable(); adp1.Fill(dt);
                    // Allottee_master_grid.DataSource = dt; Allottee_master_grid.DataBind();

                    int i = 0;
                    int comment1 = 6, comment2 = 6;
                    string comment_str1 = "", comment_str2 = "";
                    string comment_strDate1 = "", comment_strDate2 = "";
                    string htmldata = "";

                    ph.Controls.Clear();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)

                        {

                            comment_str1 = ""; comment_str2 = ""; comment_strDate1 = ""; comment_strDate2 = "";

                            for (int k = 6; k < dt.Columns.Count; k++)
                            {
                                if ((dr[k].ToString()).Trim().Length > 0)
                                {
                                    if (comment_str1 == "") { comment_str1 = (dr[k].ToString()).Trim(); comment_strDate1 = "<code>Date</code>: " + dt.Columns[k].ColumnName.Replace(" 12:00AM", ""); }
                                    else if (comment_str2 == "")
                                    {
                                        comment_str2 = @"<hr/><div class=""row""><div class=""col-md-8 col-sm-12"">" + (dr[k].ToString()).Trim() + @"</div>";
                                        comment_strDate2 = @"<div class=""col-md-4 col-sm-12 text-right font-bold""><code>Date</code>: " + dt.Columns[k].ColumnName.Replace(" 12:00AM", "") + @"</div></div>";
                                    }
                                }
                            }
                            comment_str1 = HttpContext.Current.Server.HtmlDecode(comment_str1);
                            comment_str2 = HttpContext.Current.Server.HtmlDecode(comment_str2);


                            i++;
                            htmldata = @" <div class=""activity-full-height"" style=""height: 100vh; "">
                   <div class=""panel panel-default my-activity-area"" id='section" + i + @"' style=""border: 1px solid #ccc;padding: 12px;    background: #f7f7f7;margin-bottom: 30px;"">
                <div class=""div-actionarea"" style=""background: #f7f7f7;"">
                                <div class=""activity-heading"" style="""">
                                    Actionable Area " + i + @" : <b>" + dr["Actionable Area"].ToString() + @"</b>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label class=""col-md-2 col-sm-12"">
                                            &nbsp;&nbsp;Activity :
                                        </label>
                                        <div class=""col-md-6 col-sm-12"">
                                          " + dr["Activity"].ToString() + @"
                                        </div>
                                        <label class=""col-md-3 col-sm-6 text-right font-bold"">
                                            &nbsp;&nbsp;Target Date :
                                        </label>
                                        <div class=""col-md-1 col-sm-6 font-bold"">
                                           " + dr["Target Date"].ToString() + @"
                                        </div>
                                    </div>
                                </div>
                                <div class=""clearfix""></div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label class=""col-md-2 col-sm-12"">
                                            &nbsp;&nbsp;Responsibility :
                                        </label>
                                        <div class=""col-md-8 col-sm-12"">
                                           " + dr["Responsibilty"].ToString() + @"
                                        </div>
                                        
                                    </div>
                                </div>
                                <div class=""clearfix""></div>
                                <!--<hr class=""myhrline"" style=""margin:10px 0;border-top:3px solid #dadada;""/>-->
                                
                
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label class=""col-md-2 col-sm-12"">
                                            &nbsp;&nbsp;Action to be taken :
                                        </label>
                                        <div class=""col-md-10 col-sm-12"">
                                           " + dr["Action To be Taken"].ToString() + @"
                                        </div>
                                    </div>
                                </div>
                                <div class=""clearfix""></div>
                </div>


            <hr class=""myhrline"" style=""margin:10px 0;border-top:3px solid #dadada;""/>
                <div class=""div-response-sec"" style=""background: #f7f7f7;"">
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <div class=""col-md-8 col-sm-12"">
                                         " + comment_str1 + @"
                                        </div>
                                         <div class=""col-md-4 col-sm-12 text-right font-bold"">
                                            " + comment_strDate1 + @"
                                        </div>
                                    </div>
                                </div>
                                <div class=""clearfix""></div>
                                <div class=""form-group"">
                               " + comment_str2 + comment_strDate2 + @"
                                </div>
                                <div class=""clearfix""></div>
                                
                </div>

         <hr class=""myhrline"" style=""margin:10px 0;border-top:3px solid #dadada;""/>
                <div class=""form-group"">
                    <div class=""row"">                        
                        <div class=""col-md-12"">";


                            //<asp:Textbox ID = ""Label1"" runat=""server"" Text="""" CssClass=""margin-left-z""  TextMode=""MultiLine"" Width=""100%"" Height=""100px""></asp:Textbox>


                            string htmldata1 = @"</div>
                    </div>
                </div>
                <div class=""clearfix""></div>
                <div class=""form-group"">   
                    <div class=""row"">
                        <div class=""col-md-12"">";


                            //<asp:Button ID = ""Button3"" runat=""server"" CssClass=""btn btn-sm btn-primary btn-popup pull-right"" style=""margin-right: 3px;margin-top:10px;"" Text=""Comment""/>

                            string htmldata2 = @"</div>
                    </div>
                </div>
                <div class=""clearfix""></div>
                <a href = '#section" + (i + 1) + @"' class=""scroll-screen""><span></span><i class=""fa fa-angle-double-down"" aria-hidden=""true""></i></a>
            </div>
        </div>";

                            Literal loLit = new Literal();
                            loLit.Text = (htmldata);
                            ph.Controls.Add(loLit);

                            TextBox loTxt = new TextBox();
                            loTxt.CssClass = "margin-left-z";
                            loTxt.TextMode = TextBoxMode.MultiLine;
                            loTxt.Height = 100;
                            loTxt.Attributes.Add("style", "width:100%");
                            loTxt.ID = "txtComment" + dr["Id"].ToString().Trim();

                            ph.Controls.Add(loTxt);

                            Literal loLit1 = new Literal();
                            loLit1.Text = (htmldata1);
                            ph.Controls.Add(loLit1);


                            Button lobtn = new Button();
                            lobtn.Attributes.Add("class", "btn btn-sm btn-primary btn-popup pull-right");
                            lobtn.Attributes.Add("style", "margin-right: 3px;margin-top:10px;");
                            lobtn.Text = "Comment";
                            lobtn.ID = "btnComment" + dr["Id"].ToString().Trim();
                            lobtn.Click += new EventHandler(this.btnComment_Click);

                            ph.Controls.Add(lobtn);

                            Literal loLit2 = new Literal();
                            loLit2.Text = (htmldata2);
                            ph.Controls.Add(loLit2);


                        }
                    }
                    else
                    {
                        Literal loLit4 = new Literal();
                        loLit4.Text = ("No Action Required");
                        ph.Controls.Add(loLit4);
                    }
                }
                else
                {
                    Literal loLit4 = new Literal();
                    loLit4.Text = ("No Action Required !");
                    ph.Controls.Add(loLit4);
                    //Allottee_master_grid.DataBind();
                }
            }
            else
            {
                // Allottee_master_grid.DataBind();
            }

        }



        private void btnComment_Click(object sender, EventArgs e)
        {
            Button button_id = sender as Button;
            string id = button_id.ID.ToString().Replace("btnComment", "");
            TextBox txt = (TextBox)(ph.FindControl("txtComment" + id));

            // MessageBox1.ShowWarning(txt.Text);

            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                if (txt.Text == "" || txt.Text == null)
                {
                    MessageBox1.ShowError("Please Provide Comments");
                    return;
                }
                else
                {
                    string desc = txt.Text.Trim();
                    command.CommandText = ("InsertCommentReviewMeeting_sp " + id + ",'" + desc + "','" + Group_lbl.Text.Trim() + "'");
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                }

                if (transactionResult)
                {
                    transaction.Commit();
                    MessageBox1.ShowSuccess("Comment Inserted successfully");
                    txt.Text = "";// row.Value = "";
                    GetReviewMeeting();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "gridviewScroll();", true);
                }
                else
                {
                    transaction.Rollback();
                    MessageBox1.ShowError("Some Error Occured");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "gridviewScroll();", true);
                    return;
                }

            }

            catch (Exception ex)
            {
                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }
            }
            finally
            {
                transaction.Dispose();
                con.Close();
            }



        }




        public void checkuser()
        {
            objServiceTimelinesBEL.UserName = UserName;

            // lblUserId.Text = objServiceTimelinesBEL.UserName;
            //   lblPass.Text = txtLoginPass.Text;

            SqlCommand cmd = new SqlCommand("select * from GroupMaster where UserID='" + objServiceTimelinesBEL.UserName.Trim() + "' ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //MessageBox1.ShowSuccess("Welcome " + dt.Rows[0]["GroupName"].ToString());
                Group_lbl.Text = dt.Rows[0]["GroupName"].ToString();
                //   lblUserId.Text = dt.Rows[0]["UserID"].ToString();


                Session["GroupName"] = dt.Rows[0]["GroupName"].ToString();
                // login_check();
                GetReviewMeeting();
                // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "gridviewScroll();", true);
                //  txtLoginUserid.Text = "";
                //  txtLoginPass.Text = "";
            }
        }




    }
}