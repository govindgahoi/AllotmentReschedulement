using System;
using System.Data;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ApplicationTracker : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtServiceReqNo_TextChanged(object sender, EventArgs e)
        {

            GetApplicantDetails(txtServiceReqNo.Text.Trim());
        }

        private void GetApplicantDetails(String ID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {

                objServiceTimelinesBEL.ServiceRequestNO = ID;
                ds = objServiceTimelinesBLL.TrackDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                if (dt.Rows.Count > 0)
                {
                    lblApplicantName.Text = dt.Rows[0]["ApplicantName"].ToString();
                    lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblApplicationDate.Text = dt.Rows[0]["ApplicationDate"].ToString();
                    lblPlotPreference1.Text = dt.Rows[0]["PlotPref1"].ToString();
                    lblPlotPreference2.Text = dt.Rows[0]["PlotPref2"].ToString();
                    lblPlotPreference3.Text = dt.Rows[0]["PlotPref3"].ToString(); ;
                    lblPaymentAmount.Text = dt.Rows[0]["PaymentAmount"].ToString();
                    lblPaymentDate.Text = dt.Rows[0]["PaymentDate"].ToString();
                    lblPaymentStatus.Text = dt.Rows[0]["PaymentStatus"].ToString();
                    lblApplicationStatus.Text = dt.Rows[0]["AppStatus"].ToString();
                    lblIaname.Text = dt.Rows[0]["IAName"].ToString();

                    string Imagetype = dt.Rows[0]["ImageType"].ToString().Trim();
                    string img = dt.Rows[0]["AppImage"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["AppImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrv.Visible = true;
                        ImgPrv.ImageUrl = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }
                    else
                    {
                        ImgPrv.Visible = false;
                        ImgPrv.ImageUrl = "";
                    }


                    string currentstage = "";

                    string Stage1 = dt.Rows[0]["Stage1"].ToString();
                    if (Stage1 == "1")
                    {
                        stage1.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage1.Attributes.Add("class", "red");
                    }
                    string Stage2 = dt.Rows[0]["Stage2"].ToString();
                    if (Stage2 == "True")
                    {
                        stage2.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage2.Attributes.Add("class", "red");
                    }
                    string Stage3 = dt.Rows[0]["Stage3"].ToString();
                    if (Stage3 == "True")
                    {
                        stage3.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage3.Attributes.Add("class", "red");
                    }
                    string Stage4 = dt.Rows[0]["Stage4"].ToString();
                    if (Stage4 == "True")
                    {
                        stage4.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage4.Attributes.Add("class", "red");
                    }
                    string Stage5 = dt.Rows[0]["Stage5"].ToString();
                    if (Stage5 == "True")
                    {
                        stage5.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage5.Attributes.Add("class", "red");
                    }
                    string Stage6 = dt.Rows[0]["Stage6"].ToString();
                    if (Stage6 == "True")
                    {
                        stage6.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage6.Attributes.Add("class", "red");
                    }
                    string Stage7 = dt.Rows[0]["Stage7"].ToString();
                    if (Stage7 == "True")
                    {
                        stage7.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage7.Attributes.Add("class", "red");
                    }
                    string Stage8 = dt.Rows[0]["Stage8"].ToString();
                    if (Stage8 == "True")
                    {
                        stage8.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage8.Attributes.Add("class", "red");
                    }
                    string Stage9 = dt.Rows[0]["Stage9"].ToString();
                    if (Stage9 == "True")
                    {
                        stage9.Attributes.Add("class", "green");
                    }
                    else
                    {
                        stage9.Attributes.Add("class", "red");
                    }

                    if (Stage1 == "0")
                    {
                        currentstage = "1";
                    }
                    else
                    {
                        if (Stage2 == "False")
                        {
                            currentstage = "2";
                        }
                        else
                        {
                            if (Stage3 == "False")
                            {
                                currentstage = "3";
                            }
                            else
                            {
                                if (Stage4 == "False")
                                {
                                    currentstage = "4";
                                }
                                else
                                {
                                    if (Stage5 == "False")
                                    {
                                        currentstage = "5";
                                    }
                                    else
                                    {
                                        if (Stage6 == "False")
                                        {
                                            currentstage = "6";
                                        }
                                        else
                                        {
                                            if (Stage7 == "False")
                                            {
                                                currentstage = "7";
                                            }
                                            else
                                            {
                                                if (Stage8 == "False")
                                                {
                                                    currentstage = "8";
                                                }
                                                else
                                                {
                                                    if (Stage9 == "False")
                                                    {
                                                        currentstage = "9";
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (currentstage == "1")
                    {
                        stage1.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "2")
                    {
                        stage2.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "3")
                    {
                        stage3.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "4")
                    {
                        stage4.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "5")
                    {
                        stage5.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "6")
                    {
                        stage6.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "7")
                    {
                        stage7.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "8")
                    {
                        stage8.Attributes.Add("class", "orange");
                    }
                    if (currentstage == "9")
                    {
                        stage9.Attributes.Add("class", "orange");
                    }

                }
                else
                {

                }
                if (dt1.Rows.Count > 0)
                {
                    Application_Grid.DataSource = dt1;
                    Application_Grid.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


    }


}