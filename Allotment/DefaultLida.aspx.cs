using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class DefaultLida : System.Web.UI.Page
    {
       
            int index = 1;



            protected void Page_Load(object sender, EventArgs e)
            {


            }

            protected void Button1_Click(object sender, EventArgs e)
            {

                //int count = 0;
                index += 1;
                TableRow NewRow1 = new TableRow();

                //1st cell
                TableCell NewCell1 = new TableCell();
                NewCell1.Style.Add("border-style", "none");

                // new text box
                TextBox textBox1 = new TextBox();


                // adding textbox into cell
                NewCell1.Controls.Add(textBox1);

                // adding cells to row
                NewRow1.Cells.Add(NewCell1);

                //2ed cell
                TableCell NewCell2 = new TableCell();
                NewCell2.Style.Add("border-style", "none");

                // new text box
                TextBox textBox2 = new TextBox();

                NewCell2.Controls.Add(textBox2);
                NewRow1.Cells.Add(NewCell2);


                //3rd cell
                TableCell NewCell3 = new TableCell();
                NewCell3.Style.Add("border-style", "none");

                // new text box
                DropDownList dropDown1 = new DropDownList();
                dropDown1.Style.Add("width", "150px");
                dropDown1.Style.Add("height", "26px");
                NewCell3.Controls.Add(dropDown1);
                NewRow1.Cells.Add(NewCell3);


                //4rth cell
                TableCell NewCell4 = new TableCell();
                NewCell4.Style.Add("border-style", "none");

                // new text box
                DropDownList dropDown2 = new DropDownList();
                dropDown2.Style.Add("width", "150px");
                dropDown2.Style.Add("height", "26px");
                NewCell4.Controls.Add(dropDown2);
                NewRow1.Cells.Add(NewCell4);

                //adding row into table
                Table1.Rows.Add(NewRow1);


                //5th cell
                TableCell NewCell5 = new TableCell();
                NewCell5.Style.Add("border-style", "none");

                // new text box
                TextBox textBox3 = new TextBox();

                NewCell5.Controls.Add(textBox3);
                NewRow1.Cells.Add(NewCell5);

                //adding row into table
                Table1.Rows.Add(NewRow1);
            
        }

    }
}