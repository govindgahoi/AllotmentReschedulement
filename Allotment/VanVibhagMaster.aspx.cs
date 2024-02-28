using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class Van_VibhagMaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!IsPostBack)
            {
                bindIndustrialAreaDetail();
                BindVanVibhagGridView();
            }
        }
        private void bindIndustrialAreaDetail()
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                    ddlArea.DataSource = ds;
                    ddlArea.DataTextField = "IAName";
                    ddlArea.DataValueField = "Id";
                    ddlArea.DataBind();
                    ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void BindVanVibhagGridView()
        {
            try
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.IndustrialArea = ddlArea.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.SearchRecord = txtSearch.Text;
                if (Session["UserName"].ToString().Trim() == "Admin1")
                {
                    try
                    {

                        objServiceTimelinesBEL.Parameter = "A";
                        ds = objServiceTimelinesBLL.GetBindVanVibhagMasterGridView(objServiceTimelinesBEL);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            PlantationGrid.DataSource = ds;
                            PlantationGrid.DataBind();
                        }
                        else
                        {
                            PlantationGrid.DataSource = null;
                            PlantationGrid.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("GetUserRole_sp '" + Session["UserName"].ToString().Trim() + "'", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        objServiceTimelinesBEL.IndustrialArea = dt.Rows[0]["IndustrialArea"].ToString().Trim();
                        string Level = dt.Rows[0]["Level"].ToString().Trim();
                        if (Level == "RM")
                        {
                            objServiceTimelinesBEL.Parameter = "S";
                            ds = objServiceTimelinesBLL.GetBindVanVibhagMasterGridView(objServiceTimelinesBEL);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                PlantationGrid.DataSource = ds;
                                PlantationGrid.DataBind();
                            }
                            else
                            {
                                PlantationGrid.DataSource = null;
                                PlantationGrid.DataBind();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindVanVibhagGridView();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objServiceTimelinesBEL.IAId = Convert.ToInt32(ddlArea.SelectedItem.Value);
                objServiceTimelinesBEL.IndustrialArea = ddlArea.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.LocationAddress = txtLocationAddress.Text.Trim();
                objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                objServiceTimelinesBEL.plotSize = txtPlotSize.Text.Trim();
                objServiceTimelinesBEL.SpeciesofTrees = txtSpeciesofTrees.Text.Trim();
                objServiceTimelinesBEL.NoOfTrees = txtNoofTrees.Text.Trim();
                objServiceTimelinesBEL.UploadedFileName = Convert.ToString(Session["FileName"]);
                objServiceTimelinesBEL.UploadedFile = Session["File"] as byte[];
                objServiceTimelinesBEL.UploadedFileExt = Convert.ToString(Session["FileExt"]);
                objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);

                try
                {
                    if (btnSubmit.Text == "Save")
                    {
                        if (ddlArea.SelectedIndex == 0)
                        {

                            MessageBox1.ShowWarning("Please Select Industrial Area");
                            return;
                        }
                        int retVal = objServiceTimelinesBLL.SaveVanVibhagDetail(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Record Inserted successfully");
                            BindVanVibhagGridView();
                            reset();
                            //BindServiceCheckListGridView();
                            //BindCategory();
                        }
                        else
                        {
                            MessageBox1.ShowError("Some Error Occured");
                            return;
                        }
                    }
                    if (btnSubmit.Text == "Update")
                    {
                        objServiceTimelinesBEL.ID = Convert.ToInt32(ViewState["ID"]);
                        int retVal = objServiceTimelinesBLL.UpdateVanVibhagDetails(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Record Update Successfully");
                            BindVanVibhagGridView();
                            reset();

                        }
                        else
                        {
                            MessageBox1.ShowError("Some Error Occured");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileupload.HasFile)
                {
                    HttpPostedFile file = fileupload.PostedFile;
                    objServiceTimelinesBEL.UploadedFile = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.UploadedFile, 0, file.ContentLength);
                    objServiceTimelinesBEL.UploadedFileName = Path.GetFileName(fileupload.PostedFile.FileName);

                    objServiceTimelinesBEL.UploadedFileExt = fileupload.PostedFile.ContentType;
                    Session["FileName"] = objServiceTimelinesBEL.UploadedFileName;
                    Session["File"] = objServiceTimelinesBEL.UploadedFile;
                    Session["FileExt"] = objServiceTimelinesBEL.UploadedFileExt;
                    lbluploadingMsg.Text = "File uploaded Successfully";
                    lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsg.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        protected void PlantationGrid_PreRender(object sender, EventArgs e)
        {
            MergeRows(PlantationGrid);

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "gridviewScroll();", true);


        }
        public static void MergeRows(GridView PlantationGrid)
        {
            int K = 0;

            for (int rowIndex = PlantationGrid.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = PlantationGrid.Rows[rowIndex];
                GridViewRow previousRow = PlantationGrid.Rows[rowIndex + 1];

                //   for (int i = 0; i < row.Cells.Count; i++)
                //   {

                if (row.Cells[2].Text == previousRow.Cells[2].Text)
                {


                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;

                    row.Cells[1].RowSpan = row.Cells[2].RowSpan;
                    previousRow.Cells[1].Visible = false;
                }
                if (row.Cells[3].Text == previousRow.Cells[3].Text)
                {
                    row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                    previousRow.Cells[3].Visible = false;
                }

            }

            string prev_hi = "EEE";
            for (int rowIndex = 0; rowIndex < PlantationGrid.Rows.Count; rowIndex++)
            {

                GridViewRow row = PlantationGrid.Rows[rowIndex];
                if (row.Cells[3].Visible == true)
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                        prev_hi = "FFF";
                    }
                    else
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");
                        prev_hi = "EEE";
                    }
                    K++;
                    //  row.Cells[0].Text = K.ToString();
                }
                else
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");

                    }
                    else
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                    }
                }

            }


        }
        protected void PlantationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % PlantationGrid.PageSize;
                string IAId = (PlantationGrid.DataKeys[index].Values[1]).ToString();
                string DocType = (PlantationGrid.DataKeys[index].Values[2]).ToString();
                if (e.CommandName == "Process")
                {

                    int id = Convert.ToInt32(PlantationGrid.DataKeys[index].Values[0]);
                    ddlArea.SelectedItem.Value = IAId;
                    ddlArea.SelectedItem.Text = DocType.Trim();
                    txtLocationAddress.Text = PlantationGrid.Rows[index].Cells[3].Text.Trim().Replace("&nbsp;", "");
                    txtPlotNo.Text = PlantationGrid.Rows[index].Cells[4].Text.Trim().Replace("&nbsp;", "");
                    txtPlotSize.Text = PlantationGrid.Rows[index].Cells[5].Text.Trim().Replace("&nbsp;", "");
                    txtSpeciesofTrees.Text = PlantationGrid.Rows[index].Cells[6].Text.Trim().Replace("&nbsp;", "");
                    txtNoofTrees.Text = PlantationGrid.Rows[index].Cells[7].Text.Trim().Replace("&nbsp;", "");
                    ViewState["ID"] = id;

                    btnSubmit.Text = "Update";
                }
                if (e.CommandName == "DeletePlantation")
                {
                    int id = Convert.ToInt32(PlantationGrid.DataKeys[index].Values[0]);
                    objServiceTimelinesBEL.ID = id;
                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteVanVibhaagDetail(objServiceTimelinesBEL);

                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Delete Record Successfully");
                            BindVanVibhagGridView();
                            reset();
                        }
                        else
                        {
                            MessageBox1.ShowError("Some Error Occured");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                    finally
                    {

                    }

                }
                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.IndustrialArea = DocType;
                        ds = objServiceTimelinesBLL.GetPlatationDocument(objServiceTimelinesBEL);
                        DataTable dtDoc = ds.Tables[0];
                        if (dtDoc != null)
                        {
                            download(dtDoc);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }
        protected void PlantationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string DocType = (DataBinder.Eval(e.Row.DataItem, "Industrial Area").ToString());

                    //int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    //int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());

                    try
                    {
                        DataSet ds1 = new DataSet();
                        objServiceTimelinesBEL.IndustrialArea = DocType;
                        ds1 = objServiceTimelinesBLL.GetPlatationDocument(objServiceTimelinesBEL);
                        DataTable dtDoc = ds1.Tables[0];
                        if (dtDoc.Rows.Count > 0)
                        {
                            e.Row.FindControl("LinkButton1").Visible = true;
                            //e.Row.FindControl("lbDelete").Visible = true;
                        }
                        else
                        {
                            e.Row.FindControl("LinkButton1").Visible = false;
                            //e.Row.FindControl("lbDelete").Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
            catch
            {

            }

        }
        protected void PlantationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PlantationGrid.PageIndex = e.NewPageIndex;
            BindVanVibhagGridView();
        }
        protected void PlantationGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["PlantationGrid"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }

                PlantationGrid.DataSource = dtrslt;
                PlantationGrid.DataBind();
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
                + dt.Rows[0]["ColName"].ToString() + ".pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {

            }

        }
        private void reset()
        {
            ddlArea.SelectedIndex = 0;
            txtLocationAddress.Text = "";
            txtPlotNo.Text = "";
            txtPlotSize.Text = "";
            txtSpeciesofTrees.Text = "";
            txtNoofTrees.Text = "";
            lbluploadingMsg.Text = "";
            Session["FileName"] = "";
            Session["File"] = "";
            Session["FileExt"] = "";
        }
        //private void bindregion(string reg)
        //{
        //    SqlCommand cmd = new SqlCommand("select distinct RegionalOffice from IndustrialArea where RegionalOffice='" + reg.Trim() + "'", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    dlregion.DataSource = dt;
        //    dlregion.DataTextField = "RegionalOffice";
        //    dlregion.DataValueField = "RegionalOffice";
        //    dlregion.DataBind();
        //    dlregion.Items.Insert(0, new ListItem("--Select--", "0"));
        //}
        //private void bindregion1()
        //{
        //    SqlCommand cmd = new SqlCommand("select distinct RegionalOffice from IndustrialArea", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    dlregion.DataSource = dt;
        //    dlregion.DataTextField = "RegionalOffice";
        //    dlregion.DataValueField = "RegionalOffice";
        //    dlregion.DataBind();
        //    dlregion.Items.Insert(0, new ListItem("--Select--", "0"));
        //}
        //private void bindIA(string IA)
        //{
        //    SqlCommand cmd = new SqlCommand("GetIAUserRoleWise_sp '" + IA + "'", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    IaDdl.DataSource = dt;
        //    IaDdl.DataTextField = "IAName";
        //    IaDdl.DataValueField = "Id";
        //    IaDdl.DataBind();
        //    IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
        //}

        //protected void dlregion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Session["UserName"].ToString().Trim() == "Admin1")
        //    {
        //        objServiceTimelinesBEL.RegionalOffice = (dlregion.SelectedValue.Trim());
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
        //            IaDdl.DataSource = ds;
        //            IaDdl.DataTextField = "IAName";
        //            IaDdl.DataValueField = "Id";
        //            IaDdl.DataBind();
        //            IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));

        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured :" + ex.Message.ToString());
        //        }
        //        finally
        //        {
        //            objServiceTimelinesBEL = null;
        //            objServiceTimelinesBLL = null;
        //        }
        //    }
        //    else
        //    {

        //        SqlCommand cmd = new SqlCommand("GetUserRole_sp '" + Session["UserName"].ToString().Trim() + "'", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);

        //        string IA = dt.Rows[0]["IndustrialArea"].ToString().Trim();
        //        string RegOffice = dt.Rows[0]["RegionalOffice"].ToString().Trim();


        //        bindIA(IA);

        //    }
        //}


        //private void check_user_role()
        //{
        //    if (Session["UserName"].ToString().Trim() == "Admin1")
        //    {
        //        bindregion1();
        //        bindRateGrid(null, "A");
        //    }
        //    else
        //    {
        //        SqlCommand cmd = new SqlCommand("GetUserRole_sp '" + Session["UserName"].ToString().Trim() + "'", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string IA = dt.Rows[0]["IndustrialArea"].ToString().Trim();
        //            string RegOffice = dt.Rows[0]["RegionalOffice"].ToString().Trim();
        //            bindregion(RegOffice);
        //            dlregion.SelectedIndex = 1;
        //            bindIA(IA);
        //            bindRateGrid(IA, "S");

        //        }
        //    }

        //}

        //private void bindRateGrid(string IAId, string p)
        //{
        //    SqlCommand cmd = new SqlCommand("GetIARatesDetail_sp '" + IAId + "','" + p + "'", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    IARateGrid.DataSource = dt;
        //    IARateGrid.DataBind();

        //}
        //private void gridFunc()
        //{
        //    if (Session["UserName"].ToString().Trim() == "Admin1")
        //    {

        //        bindRateGrid(null, "A");
        //    }
        //    else
        //    {
        //        SqlCommand cmd = new SqlCommand("GetUserRole_sp '" + Session["UserName"].ToString().Trim() + "'", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);

        //        string IA = dt.Rows[0]["IndustrialArea"].ToString().Trim();
        //        string RegOffice = dt.Rows[0]["RegionalOffice"].ToString().Trim();

        //        bindRateGrid(IA, "S");

        //    }
        //}


        //protected void IARateGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    IARateGrid.PageIndex = e.NewPageIndex;
        //    gridFunc();
        //}
        //protected void IARateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Process")
        //    {
        //        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });

        //        string rowid = commandArgs[0];
        //        string iaID = commandArgs[1];
        //        string regoffice = commandArgs[2];

        //        if (regoffice == "FAIZABAD REGION")
        //        {
        //            dlregion.SelectedIndex = 5;
        //        }
        //        else
        //        {
        //            dlregion.SelectedValue = regoffice.Trim();
        //        }

        //        dlregion_SelectedIndexChanged(null, null);
        //        IaDdl.SelectedValue = iaID.Trim();

        //        IaDdl_SelectedIndexChanged(null, null);




        //    }
        //    if (e.CommandName == "DeleteRate")
        //    {
        //        string rowid = e.CommandArgument.ToString();

        //        string error = "";
        //        con.Open();
        //        SqlCommand command = con.CreateCommand();
        //        SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
        //        command.Connection = con;
        //        command.Transaction = transaction;
        //        bool transactionResult = true;
        //        try
        //        {


        //            command.CommandText = ("delete From Master_IARates where RateID='" + rowid + "'");
        //            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));


        //            if (transactionResult)
        //            {
        //                transaction.Commit();
        //                MessageBox1.ShowSuccess("Rate Deleted successfully");

        //                gridFunc();

        //            }
        //            else
        //            {

        //                transaction.Rollback();
        //                MessageBox1.ShowError("Some Error Occured");
        //                return;


        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            error += "Commit Exception Type: " + ex.GetType();
        //            error += "  Message: " + ex.Message;
        //            Response.Write(error);

        //            try
        //            { transaction.Rollback(); }

        //            catch (Exception ex2)
        //            {
        //                error += "Rollback Exception Type:" + ex2.GetType();
        //                error += " Message: " + ex2.Message;
        //                Response.Write(error);
        //            }

        //        }

        //        finally
        //        {
        //            transaction.Dispose();
        //            con.Close();

        //        }



        //    }
        //}

        //private void reset()
        //{
        //    dlregion.SelectedIndex = 0;
        //    txtRateOfPlot.Text = "";
        //    txtRebate.Text = "";
        //    txtRegistrationMoneyRate.Text = "";
        //    txtNoOfInstallments.Text = "";
        //    txtEMDRates.Text = "";
        //    txtDepreciationRate.Text = "";
        //    txtLocationCharge.Text = "";
        //    txtEffectiveFromDate.Text = "";
        //    txtInterestRate.Text = "";
        //    btnSubmit.Text = "Submit";
        //    RateIdlbl.Text = "0";
        //    IaDdl.Items.Clear();

        //}
        //protected void txtEffectiveFromDate_TextChanged(object sender, EventArgs e)
        //{
        //    txtEffectiveFromDate.Text = Convert.ToDateTime(txtEffectiveFromDate.Text.Trim()).ToString("dd-MMM-yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt");
        //}

        //private void get_prev_rate()
        //{
        //    RateIdlbl.Text = "0";
        //    SqlCommand cmd = new SqlCommand("Select * from Master_IARates where IAId='" + IaDdl.SelectedValue.Trim() + "'   and Active=1", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        MessageBox1.ShowInfo("Previous Rate Exist Against Industrial Area");
        //        RateIdlbl.Text = dt.Rows[0]["RateID"].ToString();
        //        txtRateOfPlot.Text = dt.Rows[0]["RateofPlot"].ToString();
        //        txtInterestRate.Text = dt.Rows[0]["InterestRate"].ToString();
        //        txtRebate.Text = dt.Rows[0]["Rebate"].ToString();
        //        txtNoOfInstallments.Text = dt.Rows[0]["NoofInstallments"].ToString();
        //        txtEMDRates.Text = dt.Rows[0]["EMDRate"].ToString();
        //        txtRegistrationMoneyRate.Text = dt.Rows[0]["RegistrationMoneyRate"].ToString();
        //        txtDepreciationRate.Text = dt.Rows[0]["DepricationRate"].ToString();
        //        txtLocationCharge.Text = dt.Rows[0]["LocationChage"].ToString();
        //        string date = dt.Rows[0]["EffectiveFromDate"].ToString();
        //        if (date != "" || date != null)
        //        {
        //            txtEffectiveFromDate.Text = Convert.ToDateTime(date).ToString("dd-MMM-yyyy hh:mm:ss tt");
        //        }
        //        btnSubmit.Text = "Update";

        //    }
        //    else
        //    {
        //        txtRateOfPlot.Text = "";
        //        txtRebate.Text = "";
        //        txtRegistrationMoneyRate.Text = "";
        //        txtNoOfInstallments.Text = "";
        //        txtEMDRates.Text = "";
        //        txtDepreciationRate.Text = "";
        //        txtLocationCharge.Text = "";
        //        txtEffectiveFromDate.Text = "";
        //        txtInterestRate.Text = "";
        //        btnSubmit.Text = "Submit";
        //        RateIdlbl.Text = "0";
        //    }

        //}

        //protected void IaDdl_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    get_prev_rate();
        //}
        protected void save_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }
        protected void Upload_ServerClick(object sender, EventArgs e)
        {
            btnUpload_Click(null, null);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        protected void reset_ServerClick(object sender, EventArgs e)
        {
            btnReset_Click(null, null);
        }
        protected void Home_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DashboardI.aspx");
        }
    }
}