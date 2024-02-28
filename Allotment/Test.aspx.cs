using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class Test : System.Web.UI.Page
    {
        Classes.Class1 cs = new Classes.Class1();
        DataTable dt = new DataTable(); DataTable dt1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            cs.str = "SELECT ServiceNo from ApplicantTransaction where ServiceNo like '%/1000/%' and Paid=1 and TransactionDate >= '2021-04-01 00:00:00.000' and TransactionDate<= '2022-04-01 00:00:00.000' ";
            dt = cs.GetDataTable(cs.str);
            if (dt.Rows.Count > 0)
            {
                string sumss = "0";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cs.str = "EXEC ServiceApplicableFeesNewAssetTest '" + dt.Rows[i][0].ToString() + "' ";
                    dt1 = cs.GetDataTable(cs.str);
                    if (dt1.Rows[0][4].ToString() != "")
                    {
                        string sk = dt1.Rows[0][4].ToString();
                        if (sumss == "0")
                        {
                            sumss = sk;
                        }
                        else
                        {
                            sumss = (Convert.ToDecimal(sumss) + Convert.ToDecimal(sk)).ToString();

                        }
                    }
                }
                lblmsg.Text = sumss;
            }
        }
    }
}