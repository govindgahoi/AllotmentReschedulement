using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_Assesment_Entry_Inspection : System.Web.UI.UserControl
    {

        SqlConnection con;

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        public int PacketId { get; set; }
        public string ServiceReqNo { get; set; }
        public string TicketId { get; set; }


        int UserId = 0; string UserName = "";



        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

            }
            catch { Response.Redirect("Default.aspx", false); }

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd;

            if (!IsPostBack)
            {
            }

        }


        protected void submit_Click(object sender, EventArgs e)
        {
            if (TicketId.Length > 0)
                try { con.Open(); } catch { }

            SqlCommand com = con.CreateCommand();
            com.Connection = con;

            string filePath = FileUpload4.PostedFile.FileName;          // getting the file path of uploaded file
            string filename1 = Path.GetFileName(filePath);              // getting the file name of uploaded file
            string ext = Path.GetExtension(filename1);                  // getting the file extension of uploaded file
            string type = String.Empty;

            if (!FileUpload4.HasFile)
            {
                MessageBox1.ShowWarning("Please Select File !");        // if file uploader has no file 
                return;
            }
            else
            if (FileUpload4.HasFile)
            {
                try
                {
                    switch (ext)                                         // this switch code validate the files which allow to upload only PDF  file 
                    {
                        case ".pdf":
                            type = "application/pdf";
                            break;
                    }

                    if (type != String.Empty)
                    {
                        Stream fs = FileUpload4.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        try
                        {
                            SqlCommand cmd = new SqlCommand("SET_ServiceRequest_Inspection", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Service_Request_No", ServiceReqNo);
                            cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                            cmd.Parameters.AddWithValue("@DocumentInByte", bytes);
                            cmd.Parameters.AddWithValue("@UserId", UserId);
                            cmd.Parameters.AddWithValue("@Remark", Remark.Text);
                            cmd.Parameters.AddWithValue("@TicketId", TicketId);

                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                Remark.Text = "";
                                submit.CssClass = "disabled btn btn-sm";
                                submit.Text = "Submited";
                                submit.Enabled = false;
                                MessageBox1.ShowSuccess("Inspection Report Submitted");
                                return;
                            }
                            else
                            {
                                MessageBox1.ShowWarning("Failed !");
                                return;
                            }

                        }
                        catch
                        {
                            MessageBox1.ShowWarning("Failed !");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox1.ShowWarning("Select Only PDF Files  ");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning("Error: " + ex.Message.ToString());
                    return;
                }
                finally
                {
                    con.Close();
                }
            }
        }





    }
}