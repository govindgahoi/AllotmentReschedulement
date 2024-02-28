using System;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class Index : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objBookDetailsBEL = new belBookDetails();
        BooksDetails_BLL objBookDetailsBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ClearAll();
                BindCategory();


                //if (Request.RequestType == "POST")
                //{
                //    string name = Request.Form["txtName"];
                //    if (name.Length > 0)
                //    {
                //        if (System.Text.RegularExpressions.Regex.IsMatch(name,
                //                                           "^[a-zA-Z'.]{1,40}$"))
                //            Response.Write("Valid name");
                //        else
                //            Response.Write("Invalid name");
                //    }
                //}

            }
        }
        public void ClearAll()
        {
            lblMessage.Text = string.Empty;
            txtUserName.Text = string.Empty;
            drpCat.Items.Clear();
        }

        public void BindCategory()
        {
            drpCat.Items.Clear();
            drpCat.Items.Add("---Select Category---");
            drpCat.Items.Add("Industrial");
            drpCat.Items.Add("Institutional");
            drpCat.Items.Add("Commercial");
            drpCat.Items.Add("Residential");
            drpCat.Items.Add("Group Housing");
            drpCat.Items.Add("Builders");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // check if Allotment No is entered
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text,
                                                       "^[a-zA-Z0-9-'._]{1,40}$"))
                lblMessage.Text = "Valid name";
            else
                lblMessage.Text = "Invalid Allotment Number";
            // check if Plot Category is not selected 
            if ((drpCat.SelectedIndex == -1) || (drpCat.SelectedIndex == 0))
            {
                lblMessage.Text += "\r\n Select Category";
            }

        }





    }
}