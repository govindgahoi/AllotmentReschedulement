using System;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ArchitectDetails : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        public string SerReqID { get; set; }
        #endregion
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetServiceRequestBPDetail(SerReqID);
        }
        public void GetServiceRequestBPDetail(string servicereqid)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            objServiceTimelinesBEL.ServiceRequest = servicereqid;
            DataSet ds = new DataSet();
            try
            {

                ds = objServiceTimelinesBLL.GetServiceRequestBPDetail(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtNameTechnical.Text = ds.Tables[0].Rows[0]["NameofArchitect"].ToString();
                    txtLicensedPerson.Text = ds.Tables[0].Rows[0]["ArchitectLicenseNo"].ToString();
                    txtRegistration.Text = ds.Tables[0].Rows[0]["ArchitectRegistrationNo"].ToString();
                    txtAddressPerson.Text = ds.Tables[0].Rows[0]["ArchitectAddress"].ToString();


                    txtStructuralEngineer.Text = ds.Tables[0].Rows[0]["NameofStructuralEngineer"].ToString();
                    txtStructuralEngineerLicensedNo.Text = ds.Tables[0].Rows[0]["StructuralEngineerLicensedNo"].ToString();
                    txtStructuralEngineerRegistratinNo.Text = ds.Tables[0].Rows[0]["StructuralEngineerRegistratinNo"].ToString();
                    txtStructuralEngineerAddress.Text = ds.Tables[0].Rows[0]["StructuralEngineerAddress"].ToString();



                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }


    }
}