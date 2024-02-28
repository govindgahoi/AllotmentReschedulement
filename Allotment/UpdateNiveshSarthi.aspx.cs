using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Web.Services.Description;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Text;
using static System.Collections.Specialized.BitVector32;
using System.Web.Configuration;



namespace Allotment
{
    public partial class UpdateNiveshSarthi : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string json;
            try
            {
                using (con)
                {
                    using (SqlCommand cmd9 = new SqlCommand("SELECT top 2  '19' 'DepartmentName', '29' 'IndustrySector', p.UNIQUEPLOTID  AS PlotIdentificationNumber, p.PlotArea AS PlotSize, (SELECT RegionalOffice FROM IndustrialArea WHERE id=p.IAId) AS District, (SELECT IAName FROM IndustrialArea WHERE id=p.IAId) AS IndustrialArea, (SELECT TOP 1 RateofPlot FROM Master_IARates where IAId = p.IAId order by RateID desc) as PlotRate, (SELECT  distinct [PlotStatusDesc]+'  ('+plotstatusName+')'   FROM PlotSubStatusDetail WHERE PlotStatusID=p.Status AND PlotSubStatusID=p.SUBSTATUS) AS LandAllotmentStatus, (SELECT TOP 1 m.Address FROM AllotteeMaster m WHERE plotno=p.PlotNumber AND m.IndustrialArea=(SELECT IAName FROM IndustrialArea WHERE id=p.IAId) ORDER BY M.AllotteeID desc) AS AddressLocation, (SELECT TOP 1 m.DateofAllotmentNo FROM AllotteeMaster m WHERE plotno=p.PlotNumber AND m.IndustrialArea=(SELECT IAName FROM IndustrialArea WHERE id=p.IAId) ORDER BY M.AllotteeID desc) AS AuctionIssueDate_or_AllotmentDate, (SELECT TOP 1 m.AllotteeName FROM AllotteeMaster m WHERE plotno=p.PlotNumber AND m.IndustrialArea=(SELECT IAName FROM IndustrialArea WHERE id=p.IAId) ORDER BY M.AllotteeID desc) AS NameofAllotte, (SELECT TOP 1 CASE WHEN DateofAllotmentNo < '2019-01-01' THEN 'Other' WHEN DateofAllotmentNo >= '2019-01-01' and (select count(*) from ServiceRequests where AllotteeID = m.AllotteeID) > 0 THEN 'Nivesh Mitra' ELSE 'Auction' END FROM AllotteeMaster m WHERE plotno=p.PlotNumber AND m.IndustrialArea= ( SELECT IAName FROM IndustrialArea WHERE id=p.IAId )  ORDER BY M.AllotteeID desc )  AS LandAllotmentType, (select PC.PollutionCategory  from AllotteeProjectDetails APD,  Pollution_Category PC where APD.pollutionCategory = PC.ID and ApplicantId = ( SELECT TOP 1 m.Allotmentletterno FROM AllotteeMaster m WHERE plotno=p.PlotNumber AND m.IndustrialArea= ( SELECT IAName FROM IndustrialArea WHERE id=p.IAId) ORDER BY M.AllotteeID desc )) as PollutionIndex, (select TOP 1 EstimatedCostOfProject from AllotteeProjectDetails where ApplicantId = ( SELECT TOP 1 m.Allotmentletterno FROM AllotteeMaster m WHERE plotno=p.PlotNumber AND m.IndustrialArea= ( SELECT IAName FROM IndustrialArea WHERE id=p.IAId) ORDER BY M.AllotteeID desc )) as Investment, (select TOP 1 EstimatedEmploymentGeneration from AllotteeProjectDetails where ApplicantId = ( SELECT TOP 1 m.Allotmentletterno FROM AllotteeMaster m WHERE plotno=p.PlotNumber AND m.IndustrialArea= ( SELECT IAName FROM IndustrialArea WHERE id=p.IAId) ORDER BY M.AllotteeID desc )) as Employment, Convert(date, getdate()) as SubmittedOn FROM PlotMaster p WHERE   P.IsActive=1  and isnull(P.landuseCode,'')>'' and isnull(P.NorthID,'')>''  AND p.RegionCode>''"))
                    {
                        cmd9.CommandType = CommandType.Text;
                        cmd9.Connection = con;
                        con.Open();
                        SqlDataReader sdr = cmd9.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            json = "[";
                                //{\"DepartmentName\":\"19\",\"District\":567,\"IndustrialArea\":\"Bargarh-II -Industrial\",\"IndustrySector\":29,\"AddressLocation\":\"-\",\"AuctionIssueDate_or_AllotmentDate\":null,\"PlotIdentificationNumber\":\"1223227EH-41\",\"PollutionIndex\":\"Mix\",\"PlotSize\":57.00,\"PlotRate\":950.0,\"LandAllotmentType\":\"Auction\",\"LandAllotmentStatus\":\"Sold\",\"NameofAllotte\":\"ABC\",\"Investment\":null,\"Employment\":10,\"SubmittedOn\":\"27-09-23 00:00:00\"}]";

                            while (sdr.Read())
                            {
                                //json = json + "{\"DepartmentName\":\"'"+sdr["DepartmentName"].ToString()+ "'\"',\"District\":\"'" + sdr["District"].ToString() + "'\"',\"IndustrialArea\":\"'" + sdr["IndustrialArea"].ToString() + "'\"',\"IndustrySector\":\"'" + sdr["IndustrySector"].ToString() + "'\"',\"AddressLocation\":\"'" + sdr["AddressLocation"].ToString() + "'\"',\"AuctionIssueDate_or_AllotmentDate\":\"'" + sdr["AuctionIssueDate_or_AllotmentDate"].ToString() + "'\"',\"PlotIdentificationNumber\":\"'" + sdr["PlotIdentificationNumber"].ToString() + "'\"',\"PollutionIndex\":\"'" + sdr["PollutionIndex"].ToString() + "'\"',\"PlotSize\":\"'" + sdr["PlotSize"].ToString() + "'\"',\"PlotRate\":\"'" + sdr["PlotRate"].ToString() + "'\"',\"LandAllotmentType\":\"'" + sdr["LandAllotmentType"].ToString() + "'\"',\"LandAllotmentStatus\":\"'" + sdr["LandAllotmentStatus"].ToString() + "'\"',\"NameofAllotte\":\"'" + sdr["NameofAllotte"].ToString() + "'\"',\"Investment\":\"'" + sdr["Investment"].ToString() + "'\"',\"Employment\":\"'" + sdr["Employment"].ToString() + "'\"',\"SubmittedOn\":\"'" + sdr["SubmittedOn"].ToString() + "'\"},";
                                json = json + "{\"DepartmentName\":\" + sdr[DepartmentName].ToString() + \",\"District\":\"'" + sdr["District"].ToString() + "'\"',\"IndustrialArea\":\"'" + sdr["IndustrialArea"].ToString() + "'\"',\"IndustrySector\":\"'" + sdr["IndustrySector"].ToString() + "'\"',\"AddressLocation\":\"'" + sdr["AddressLocation"].ToString() + "'\"',\"AuctionIssueDate_or_AllotmentDate\":\"'" + sdr["AuctionIssueDate_or_AllotmentDate"].ToString() + "'\"',\"PlotIdentificationNumber\":\"'" + sdr["PlotIdentificationNumber"].ToString() + "'\"',\"PollutionIndex\":\"'" + sdr["PollutionIndex"].ToString() + "'\"',\"PlotSize\":\"'" + sdr["PlotSize"].ToString() + "'\"',\"PlotRate\":\"'" + sdr["PlotRate"].ToString() + "'\"',\"LandAllotmentType\":\"'" + sdr["LandAllotmentType"].ToString() + "'\"',\"LandAllotmentStatus\":\"'" + sdr["LandAllotmentStatus"].ToString() + "'\"',\"NameofAllotte\":\"'" + sdr["NameofAllotte"].ToString() + "'\"',\"Investment\":\"'" + sdr["Investment"].ToString() + "'\"',\"Employment\":\"'" + sdr["Employment"].ToString() + "'\"',\"SubmittedOn\":\"'" + sdr["SubmittedOn"].ToString() + "'\"},";
                            }

                            json = json + "]";

                            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://demo.investup.org.in/niveshsarathi/api/pushCollection");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                //string json1 = "[{\"DepartmentName\":\"19\",\"District\":567,\"IndustrialArea\":\"Bargarh-II -Industrial\",\"IndustrySector\":29,\"AddressLocation\":\"-\",\"AuctionIssueDate_or_AllotmentDate\":null,\"PlotIdentificationNumber\":\"1223227EH-41\",\"PollutionIndex\":\"Mix\",\"PlotSize\":57.00,\"PlotRate\":950.0,\"LandAllotmentType\":\"Auction\",\"LandAllotmentStatus\":\"Sold\",\"NameofAllotte\":\"ABC\",\"Investment\":null,\"Employment\":10,\"SubmittedOn\":\"27-09-23 00:00:00\"}]";

                                string json2 = "[{\"DepartmentName\":\"'19'\"',\"District\":\"'AGRA'\"',\"IndustrialArea\":\"'Mathura B'\"',\"IndustrySector\":\"'29'\"',\"AddressLocation\":\"'R/o C-23, Sector-B-2, Tronica City, Loni, Ghaziabad'\"',\"AuctionIssueDate_or_AllotmentDate\":\"'13/03/2021 12:00:00 AM'\"',\"PlotIdentificationNumber\":\"'1313141J-402'\"',\"PollutionIndex\":\"''\"',\"PlotSize\":\"'1198.00'\"',\"PlotRate\":\"'2800'\"',\"LandAllotmentType\":\"'Nivesh Mitra'\"',\"LandAllotmentStatus\":\"'Allotted  (Vacant)'\"',\"NameofAllotte\":\"'M/s. Brijwasi Food Industries (Partner- Sh. Dinesh'\"',\"Investment\":\"''\"',\"Employment\":\"''\"',\"SubmittedOn\":\"'29/09/2023 12:00:00 AM'\"},{\"DepartmentName\":\"'19'\"',\"District\":\"'AGRA'\"',\"IndustrialArea\":\"'Mathura B'\"',\"IndustrySector\":\"'29'\"',\"AddressLocation\":\"'R/o 5505/15, Basti Harphool Singh, Sadar Thana Road, Delhi-110006'\"',\"AuctionIssueDate_or_AllotmentDate\":\"'11/09/2021 12:00:00 AM'\"',\"PlotIdentificationNumber\":\"'1313141J-1293'\"',\"PollutionIndex\":\"''\"',\"PlotSize\":\"'1864.00'\"',\"PlotRate\":\"'2800'\"',\"LandAllotmentType\":\"'Auction'\"',\"LandAllotmentStatus\":\"'Allotted  (Vacant)'\"',\"NameofAllotte\":\"'Mr. Yash Garg (Prop of Yash Metals)'\"',\"Investment\":\"''\"',\"Employment\":\"''\"',\"SubmittedOn\":\"'29/09/2023 12:00:00 AM'\"}]";
                                streamWriter.Write(json2);
                            }

                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var result = streamReader.ReadToEnd();
                            }

                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            

        }
    }
}