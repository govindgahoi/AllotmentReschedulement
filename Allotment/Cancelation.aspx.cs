
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class Cancelation : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = string.Empty;
        ArrayList ar1 = new ArrayList();
        ArrayList ar2 = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            if (!IsPostBack)
            {
                UserSpecificBinding();
                BindlstPlotsListbox();

                // BindGrid();
            }



        }

        public void BindlstPlotsListbox()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";


                //ds = objServiceTimelinesBLL.BindlstPlotsListbox(objServiceTimelinesBEL);
                ds = objServiceTimelinesBLL.BindCancelledPlotsListbox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    GridView2.DataSource = Getdata1;
                    GridView2.DataBind();

                    // color based on values
                    //DataRow[] rows = Getdata1.Select("ForColor='" + 1 + "'");

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }

            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }

        }

        protected void UserSpecificBinding()
        {



            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                Regional_Changed(null, null);
                if (dsR.Tables[1].Rows[0][0].ToString() == "View")
                {
                    //         Allottee_master_grid.Columns[9].Visible = true;
                }
                else
                {
                    //       Allottee_master_grid.Columns[9].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }

            //   Refesh(true);
            //   ResetControl();

        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();



                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }

                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }
                //      GetNewAllotteeDetails();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindParentListBox();
            BinddropdownGround();
            BindlstPlotsListbox();

        }

        private DataTable Getdata1
        {
            get; set;
        }

        public void BinddropdownGround()
        {
            DataSet ds = new DataSet();
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.RegulationID = 4;
            try
            {
                ds = objServiceTimelinesBLL.GroundForCancelation(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpCancelationGround.DataSource = ds;
                    drpCancelationGround.DataTextField = "RegulationsName";
                    drpCancelationGround.DataValueField = "RegulationsGroundsid";
                    drpCancelationGround.DataBind();
                    drpCancelationGround.Items.Insert(0, new ListItem("Select Ground for Cancelation", "0"));

                }
            }
            catch (Exception Ex)
            {

                Response.Write("Oops! error occured :" + Ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        public void BindParentListBox()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";

                ds = objServiceTimelinesBLL.PlotsForCancelation(objServiceTimelinesBEL);
                // ds = objServiceTimelinesBLL.PlotBankAvailableForAllotment(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    ListParent.DataSource = Getdata1;
                    ListParent.DataTextField = "plots";
                    ListParent.DataValueField = "PlotMasterId";
                    ListParent.DataBind();
                }
                else
                {
                    ListParent.DataSource = null;
                    ListParent.DataBind();
                }
            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }

        }

        protected void btnSingleForward_Click(object sender, EventArgs e)
        {

            if (ListParent.SelectedIndex >= 0)
            {
                for (int i = 0; i < ListParent.Items.Count; i++)
                {
                    if (ListParent.Items[i].Selected)
                    {
                        if (!ar1.Contains(ListParent.Items[i]))
                        {
                            ar1.Add(ListParent.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ar1.Count; i++)
                {
                    if (!ListSelected.Items.Contains(((ListItem)ar1[i])))
                    {
                        ListSelected.Items.Add(((ListItem)ar1[i]));
                    }
                    ListParent.Items.Remove(((ListItem)ar1[i]));
                }
                ListSelected.SelectedIndex = -1;
            }
            else
            {
                lblmsg.Text = "You Must have atleast one plot selected for Cancelation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnDoubleForward_Click(object sender, EventArgs e)
        {

            while (ListParent.Items.Count != 0)
            {
                for (int i = 0; i < ListParent.Items.Count; i++)
                {
                    ListSelected.Items.Add(ListParent.Items[i]);
                    ListParent.Items.Remove(ListParent.Items[i]);
                }
            }
            lblmsg.Text = "All Records selected for cancellation ";
            lblmsg.ForeColor = System.Drawing.Color.ForestGreen;



        }

        protected void btnDoubleBack_Click(object sender, EventArgs e)
        {

            while (ListSelected.Items.Count != 0)
            {
                for (int i = 0; i < ListSelected.Items.Count; i++)
                {
                    ListParent.Items.Add(ListSelected.Items[i]);
                    ListSelected.Items.Remove(ListSelected.Items[i]);
                }
            }
            lblmsg.Text = "All data removed from Cancellation List.";
            lblmsg.ForeColor = System.Drawing.Color.ForestGreen;
        }

        protected void btnSingleBack_Click(object sender, EventArgs e)
        {

            if (ListSelected.SelectedIndex >= 0)
            {
                for (int i = 0; i < ListSelected.Items.Count; i++)
                {
                    if (ListSelected.Items[i].Selected)
                    {
                        if (!ar2.Contains(ListSelected.Items[i]))
                        {
                            ar2.Add(ListSelected.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ar2.Count; i++)
                {
                    if (!ListParent.Items.Contains(((ListItem)ar2[i])))
                    {
                        ListParent.Items.Add(((ListItem)ar2[i]));
                    }
                    ListSelected.Items.Remove(((ListItem)ar2[i]));
                }
                ListParent.SelectedIndex = -1;
            }
            else
            {
                lblmsg.Text = "Data removed from Cancellation List";
                lblmsg.ForeColor = System.Drawing.Color.ForestGreen;

            }

        }

        protected void btnpublish_Click(object sender, EventArgs e)
        {

            if (ListSelected.Items.Count <= 0)
            {
                lblmsg.Text = "Please Select atleast one Plot for Cancellation";
                lblmsg.ForeColor = System.Drawing.Color.ForestGreen;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select atleast one Plot for Cancellation');", true); return;
            }

            else
            {
                PushforCancelation();
            }


        }

        private void PushforCancelation()
        {


            if (drpCancelationGround.SelectedIndex <= 0)
            {
                string message = "Please Select Ground of Cancellation";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }
            if (!FuplodApplicantImage.HasFile)
            {
                string message = "Please Attach the Office Order to Cancelling the Allotment";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }



            try
            {
                string str = string.Empty;

                str += "Plot Number:";

                for (int i = 0; i < ListSelected.Items.Count; i++)
                {
                    if (ListSelected.Items[i].Selected)
                    {
                        objServiceTimelinesBEL.PlotID = Int32.Parse(ListSelected.SelectedItem.Value);

                        if (objServiceTimelinesBEL.PlotID >= 0)
                        {
                            // int retVal = objServiceTimelinesBLL.InsertUpdateAllotteeDetails(objServiceTimelinesBEL);
                            if (FuplodApplicantImage.HasFile)
                            {
                                string filePath = FuplodApplicantImage.PostedFile.FileName;
                                string fleUpload = Path.GetExtension(FuplodApplicantImage.FileName.ToString());
                                string filename = Path.GetFileName(filePath);
                                string contenttype = String.Empty;
                                switch (fleUpload)
                                {
                                    case ".jpg":
                                        contenttype = "image/jpg";
                                        break;
                                    case ".png":
                                        contenttype = "image/png";
                                        break;
                                    case ".gif":
                                        contenttype = "image/gif";
                                        break;
                                    case ".pdf":
                                        contenttype = "application/pdf";
                                        break;
                                }
                                if (contenttype != String.Empty)
                                {
                                    Stream fs = FuplodApplicantImage.PostedFile.InputStream;
                                    BinaryReader br = new BinaryReader(fs);
                                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                                    DataSet ds = new DataSet();
                                    objServiceTimelinesBEL.Uploadfile = bytes;
                                    objServiceTimelinesBEL.filename = filename;
                                    objServiceTimelinesBEL.content = contenttype;
                                    objServiceTimelinesBEL.CancellationGround = Int32.Parse(drpCancelationGround.SelectedValue);
                                }
                                else
                                {
                                    string message = "Please Attach the Office Order to Cancelling the Allotment";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                                }


                            }
                            else
                            {
                                string message = "Please Attach the Office Order to Cancelling the Allotment";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                            }
                            int retVal = objServiceTimelinesBLL.CancelPlots(objServiceTimelinesBEL);
                            if (retVal > 0)
                            {
                                str += ListSelected.SelectedItem.Text.ToString();
                                ListSelected.Items.RemoveAt(i);

                            }
                        }



                    }
                }
                if (str.Length > 12)
                {
                    lblmsg.Text = str;
                    lblmsg.ForeColor = System.Drawing.Color.ForestGreen;
                    BindlstPlotsListbox();
                }
                else { lblmsg.Text = "No record Selected  for Cancellation"; }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        protected void drpCancelationGround_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnupload_ServerClick(object sender, EventArgs e)
        {

            //if (FuplodApplicantImage.HasFile)
            //{
            //    string filePath = FuplodApplicantImage.PostedFile.FileName;
            //    string fleUpload = Path.GetExtension(FuplodApplicantImage.FileName.ToString());
            //    string filename = Path.GetFileName(filePath);
            //    string contenttype = String.Empty;
            //    switch (fleUpload)
            //    {
            //        case ".jpg":
            //            contenttype = "image/jpg";
            //            break;
            //        case ".png":
            //            contenttype = "image/png";
            //            break;
            //        case ".gif":
            //            contenttype = "image/gif";
            //            break;
            //        case ".pdf":
            //            contenttype = "application/pdf";
            //            break;
            //    }
            //    if (contenttype != String.Empty)
            //    {
            //        Stream fs = FuplodApplicantImage.PostedFile.InputStream;
            //        BinaryReader br = new BinaryReader(fs);
            //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            //        DataSet ds = new DataSet();
            //        objServiceTimelinesBEL.ApplicantImageByte = bytes;
            //        //objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            //        objServiceTimelinesBEL.ApplicantImageName = filename;
            //        objServiceTimelinesBEL.ImageContent = contenttype;





            //        int result = objServiceTimelinesBLL.SaveApplicantImage(objServiceTimelinesBEL);
            //        if (result > 0)
            //        {

            //            string message = "Image Uploaded Successfully";
            //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
            //            //GetApplicantDetails(ServiceReqNo);

            //        }
            //    }
            //    else
            //    {
            //        string message = "Please Choose Image";
            //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            //    }


            //}
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}