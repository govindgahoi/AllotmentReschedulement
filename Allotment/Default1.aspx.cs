using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using CADImport;
using WebCAD;

namespace Allotment
{
    public partial class Default1 : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                string ServiceReqNo = Request.QueryString["ServiceReqNo"];
                string ChecklistID = Request.QueryString["ServiceId"];
                GetView(ServiceReqNo, ChecklistID);
            }
            catch (Exception ex)
            {
            }
        }


        private void GetView(string p, string d)
        {
            SqlCommand cmd = new SqlCommand("select * from CheckListDocument where ServiceTimeLinesID=1 and ServiceReqID='" + p + "' and ServiceChecklistsID=" + d + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                byte[] byt = System.Text.Encoding.UTF8.GetBytes(dt.Rows[0]["Documents"].ToString());
                string file = HttpUtility.UrlEncode(Convert.ToBase64String(byt));
                // CADControl1.File = Server.MapPath("/") + "Rooma (final) APROVED(print).dwg";
                string ext = "";
                //  string tempFile = Path.Combine("C:/TempPdf/DWG/",
                //Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                ext = ".dwg";
                // File.WriteAllBytes(tempFile + ext, (byte[])dt.Rows[0]["Documents"]);


                BinaryWriter Writer = null;
                string Name = Server.MapPath("TempPdf/" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ext);
                Writer = new BinaryWriter(File.OpenWrite(Name));

                // Writer raw data                
                Writer.Write((byte[])dt.Rows[0]["Documents"]);
                Writer.Flush();
                Writer.Close();
                CADControl1.File = Name;
                Response.Write(Name);


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string file = Path.GetTempPath() + Guid.NewGuid().ToString() + "_" + FileUpload1.FileName;
            FileUpload1.SaveAs(file);
            CADControl1.File = file;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CADControl1.File = Server.MapPath("/") + "Gasket.dwg";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string file = Path.GetTempPath() + Guid.NewGuid().ToString() + "_floorplan.dwg";
            string url = "http://www.cadsofttools.com/dwgviewer/floorplan.dwg";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, file);
                CADControl1.File = file;
            }
        }

        public struct AttributesExport
        {
            public string BlockName;
            public Dictionary<string, string> Tags;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DrawingState ds = DrawingManager.Get(CADControl1.DrawingID);
            if (ds != null)
            {
                List<AttributesExport> toExcel = new List<AttributesExport>();

                if (DrawingManager.Engine == DrawingEngine.CADNET)
                {
                    CADImage cadImage = ds.Drawing.GetInstance() as CADImage;
                    foreach (CADEntity ent in cadImage.Converter.Entities)
                        if ((ent is CADInsert) && ((ent as CADInsert).Attribs.Count == 3))
                        {
                            AttributesExport atrExp = new AttributesExport();
                            atrExp.Tags = new Dictionary<string, string>();
                            foreach (CADAttrib attr in (ent as CADInsert).Attribs)
                                atrExp.Tags.Add(attr.Tag, attr.Value);
                            atrExp.BlockName = (ent as CADInsert).Block.Name;
                            toExcel.Add(atrExp);
                        }
                }
                else
                {
                    string xml = ds.Drawing.ProcessXML("<?xml version=\"1.0\" encoding=\"UTF-8\"?><cadsofttools version=\"2\"><get mode=\"5\" /></cadsofttools>");

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml);
                    XmlNodeList nodes = doc.SelectNodes("//cstInsert");

                    foreach (XmlNode node in nodes)
                    //if (node.ChildNodes.Count == 3)
                    {
                        AttributesExport attrExp = new AttributesExport();
                        attrExp.Tags = new Dictionary<string, string>();
                        XmlAttribute attr = node.Attributes["BlockName"];
                        if (attr != null)
                            attrExp.BlockName = attr.Value;
                        foreach (XmlNode cNode in node.ChildNodes)
                        {
                            XmlAttribute atrTag = cNode.Attributes["Tag"];
                            XmlAttribute atrValue = cNode.Attributes["Value"];
                            if ((atrTag != null) && (atrValue != null))
                                attrExp.Tags.Add(atrTag.Value, atrValue.Value);
                        }
                        toExcel.Add(attrExp);
                    }
                }
                string resp = "";
                foreach (AttributesExport attr in toExcel)
                {
                    resp += attr.BlockName + "; ";
                    foreach (var tag in attr.Tags)
                        resp += tag.Key + "; " + tag.Value + "; ";
                    resp += "\r\n";
                }
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", "attachment;filename=attribs.csv");
                Response.Write(resp);
                Response.End();
            }
        }

        protected void CADControl1_EntityClickEvent(object sender, EntityClickArgs e)
        {
            if (e.EntityInfo.Count == 0)
                e.EntityInfo.Add(new KeyValuePair<string, object>("No entity selected", "No data"));
        }
    }
}