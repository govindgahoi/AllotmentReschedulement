<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="Grievance.aspx.cs" Inherits="UpsidaAllottee.RMPanel.Grievance" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        window.onload = function () {

            var chart = new CanvasJS.Chart("chartContainer", {
                exportEnabled: true,
                animationEnabled: true,
                title: {
                    text: ""
                },
                legend: {
                    cursor: "pointer",
                    itemclick: explodePie
                },
                data: [{
                    type: "pie",
                    showInLegend: true,
                    toolTipContent: "{name}: <strong>{y}</strong>",
                    indexLabel: "{name} - {y}",
                    dataPoints: [
                        <%--{ y: <%Response.Write(lblGriResolved.Text);%>, name: "Grievance Resolve" },
                        { y: <%Response.Write(lblTotalGriRequest.Text);%>, name: "Grievance Request" },
                        { y: <%Response.Write(lblTotalGriProgress.Text);%>, name: "Grievance Progress" },--%>

                    ]
                }]
            });
            chart.render();
        }

        function explodePie(e) {
            if (typeof (e.dataSeries.dataPoints[e.dataPointIndex].exploded) === "undefined" || !e.dataSeries.dataPoints[e.dataPointIndex].exploded) {
                e.dataSeries.dataPoints[e.dataPointIndex].exploded = true;
            } else {
                e.dataSeries.dataPoints[e.dataPointIndex].exploded = false;
            }
            e.chart.render();

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>Grievance Redressal System </h1>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-10 col-md-10">
                            <div class="offices">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6">
                                        <p class="float-end col-form-label">Regional Office</p>
                                    </div>
                                    <div class="col-lg-6 col-md-6">
                                         <asp:DropDownList ID="ddlRegOffice" class="form-control" runat="server">
                                            </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                         
                     <div class="col-lg-2 col-md-2"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4 col-md-4">
                            <div class="offices">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6">
                                        <p class="float-end col-form-label">
                                            View Grievance Status</p>
                                     </div>
                                    <div class="col-lg-6 col-md-6">
                                        <asp:DropDownList ID="ddlGreStatus" class="form-control" runat="server">
                                                <asp:ListItem Value="01">--Select Status--</asp:ListItem>
                                                <asp:ListItem Value="02">Request Raised</asp:ListItem>
                                                <asp:ListItem Value="03">Resolved</asp:ListItem>
                                                <asp:ListItem Value="04">In Progress</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 ">
                            <div class="offices">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3">
                                     <p class="float-end col-form-label">Grievance Id</p>
                                    </div>
                                    <div class="col-lg-9 col-md-9">
                                            <asp:TextBox ID="txtGrievanceId" runat="server" class="form-control" placeholder="Grievance Id"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <div class="offices float-end">
                                   
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6">
                            <div class="offices float-start">
                                <input id="Button1" type="button" class="btn btn-info text-white" value="Download Report" />
                            </div>
                        </div>


                        <div class="col-lg-6 col-md-6">
                            <div class="offices float-end">
                                    <input id="Button1" type="button" class="btn btn-info text-white" value="Print PDF" />
                               
                            </div>
                        </div>
                    </div>
                        <div class="table-responsive" style="overflow-y: auto; max-height: 590px;">
                                    
                                <asp:GridView ID="grdGreStatus" DataKeyNames="Grievance_Ref_ID" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="table table-bordered table-hover" OnPageIndexChanging="grdGreStatus_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                <asp:BoundField DataField="Company_Name" HeaderText="Company Name" />
                                                <asp:BoundField DataField="Mobile_No" HeaderText="Mobile No" />
                                                <asp:BoundField DataField="Email_ID" HeaderText="Email-Id" />

                                                <asp:BoundField DataField="Grievance_Type" HeaderText="Grievance Type" />
                                                <asp:BoundField DataField="Regional_Office" HeaderText="Regional Office" />
                                                <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" />
                                               <%-- <asp:TemplateField HeaderText="Current Status">
                                                    <ItemTemplate>
                                                       
                                                        <asp:Button ID="btnProgress" runat="server" PostBackUrl='<%# string.Format("~/Admin-Dashboard/ApplicantDetails.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("Grievance_Ref_ID").ToString())) %>' Text="In Progress" class="status-bg bg-secondary"></asp:Button>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Grievance-Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="hlnkView"  NavigateUrl='<%# string.Format("~/Admin-Dashboard/ApplicantDetails.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("Grievance_Ref_ID").ToString())) %>' Text='<%# Eval("Grievance_Ref_ID").ToString()%>'> </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="View" ></asp:TemplateField>
                                                 <asp:HyperLinkField Text="View" DataNavigateUrlFields="Grievance_Ref_ID" DataNavigateUrlFormatString="ApplicantDetails.aspx?Grievance_Ref_ID={0}">
                                                    
                                                </asp:HyperLinkField>
                                                --%>

                                                <%-- <asp:TemplateField HeaderText="View" >
                                                    <ItemTemplate >
                                                        
                                                       <a href="ApplicantDetails.aspx" class="btn btn-warning btn-xs"><i class="fa fa-eye" aria-hidden="true"></i></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                        </div>
                </div>

            </div>
        </section>
    </main>
</asp:Content>
