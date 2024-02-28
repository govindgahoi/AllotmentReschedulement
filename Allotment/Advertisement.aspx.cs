using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Allotment
{
    public partial class Advertisement : System.Web.UI.Page
    {

        SqlConnection con;


        protected void Page_Load(object sender, EventArgs e)
        {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


            if (!IsPostBack)
            {
                string com = @"SELECT  
                            a.[IAId], b.IAName
                            FROM [Advertised_Plot] a, IndustrialArea b
                            where a.[IAId]= b.Id  and a.[IsActive] = 1 and  a.Status = 1 and isnull(b.PlotPublishing,0)=1  
                            group by  a.[IAId], b.IAName
                            order by b.IAName";

                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataSet myDataSet = new DataSet();
                adpt.Fill(myDataSet, "UserDetail");
                if (myDataSet.Tables.Count > 0)
                {
                    DataTable myDataTable = myDataSet.Tables[0];

                    if (myDataTable.Rows.Count > 0)
                    {
                        listArea.DataSource = myDataTable;
                        listArea.DataTextField = "IAName";
                        listArea.DataValueField = "IAId";

                        listArea.DataBind();

                        listArea.SelectedIndex = 0;

                        GetAllReleventData(listArea.SelectedValue);
                        lblIAName.Text = listArea.SelectedItem.ToString();
                    }
                }
            }

        }




        protected void GetAllReleventData(string IAID)
        {
            string com = "";


            com = @"GetAdvertised_Plot  " + IAID;

            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataSet myDataSet = new DataSet();
            adpt.Fill(myDataSet, "UserDetail");
            if (IAID.Length > 0)
            {
                DataTable DT_IAArea = myDataSet.Tables[0];
                DataTable DT_IAPlots = myDataSet.Tables[1];
                DataTable DT_IADetails = myDataSet.Tables[2];

                if (DT_IAArea.Rows.Count > 0)
                {
                    lblTotalArea.Text = DT_IAArea.Rows[0]["AreaInAcre"].ToString() + " acres";
                }


                if (DT_IAPlots.Rows.Count > 0)
                {
                    Plot_List_Grid.DataSource = DT_IAPlots;
                    Plot_List_Grid.DataBind();
                }
                else
                {
                    Plot_List_Grid.DataSource = null;
                    Plot_List_Grid.DataBind();
                }
                if (DT_IADetails.Rows.Count > 0)
                {
                    if (DT_IADetails.Rows[0]["CurrentRate"].ToString().Length > 0)
                    {
                        lblReservePrice.Text = "Rs " + DT_IADetails.Rows[0]["CurrentRate"].ToString() + " per sqmt";
                    }
                    else
                    {
                        lblReservePrice.Text = "";
                    }

                    lblLocation.Text = DT_IADetails.Rows[0]["Address"].ToString();
                    lblContactInfo.Text = DT_IADetails.Rows[0]["OfficePhoneNo"].ToString();
                }
            }
        }

        protected void listArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIAName.Text = listArea.SelectedItem.ToString();
            GetAllReleventData(listArea.SelectedValue);
        }


    }
}