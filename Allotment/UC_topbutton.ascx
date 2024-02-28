<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_topbutton.ascx.cs" Inherits="Allotment.UC_topbutton" %>
<script type="text/javascript">
    function mytopbtnFunction() {
        var curr = document.getElementById("topbtncollapse");
        if (curr.style.display == 'block') {
            curr.style.display = 'none';
        }
        else {
            curr.style.display = 'block';
        }
    }
</script> 
 <div class="row topbtncollapse" id="topbtncollapse">
            <div class="col-md-12 col-sm-12 col-xs-12 top-menu-fulldiv12" style="background: #dbdbdb;padding:0;">
                <div>
                <div style="" class="text-center top-menu-fulldiv">
                    Dashboard<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="">
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_dashboard"><i class="fa fa-tachometer" aria-hidden="true"></i><br />Dashboard</asp:HyperLink>
                        </li>
                    </ul>
                </div>
                <div style="border-left:1px solid #000;" class="text-center top-menu-fulldiv">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                           <asp:HyperLink Enabled="false" runat="server" ID="menu_new"><i class="fa fa-plus" aria-hidden="true"></i><br />New</asp:HyperLink>                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Edit</asp:HyperLink>                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_delete"><i class="fa fa-trash-o" aria-hidden="true"></i><br />Delete</asp:HyperLink>                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_save"><i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save</asp:HyperLink>                            
                        </li> 
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_refresh"><i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh</asp:HyperLink>                           
                        </li>
                    </ul>
                </div>
                <div style="border-left:1px solid #000;border-right:1px solid #000;" class="text-center top-menu-fulldiv">
                    Services<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_draft"><i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted</asp:HyperLink>                                                        
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_submitted"><i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted</asp:HyperLink>                            
                        </li> 
                           
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_track"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Track</asp:HyperLink>
                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_export"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Export</asp:HyperLink>                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_import"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Export</asp:HyperLink>                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="print"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Print</asp:HyperLink>                            
                        </li>
                      </ul>
                </div>
                 <div style="" class="text-center top-menu-fulldiv">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_last"><i class="fa fa-step-backward" aria-hidden="true"></i><br />Last</asp:HyperLink>
                                                      
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_previous"><i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous</asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_next"><i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next</asp:HyperLink>
                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_final"><i class="fa fa-step-forward" aria-hidden="true"></i><br />Final</asp:HyperLink>
                            
                        </li>
                    </ul>
                    </div>
                     <div style="border-left:1px solid #000;" class="text-center top-menu-fulldiv">
                        Reports<br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                            <li >
                                <asp:HyperLink Enabled="false" runat="server" ID="menu_reports"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Reports</asp:HyperLink>
                                
                            </li>
                         </ul>
                    </div>
                     <div style="border-left:1px solid #000;" class="text-center top-menu-fulldiv">
                        Repository<br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr master-nav-iconsbr-last" style="border-top:1px solid #ccc;">
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_repository"><i class="fa fa-database" aria-hidden="true"></i><br />Repository</asp:HyperLink>
                            
                        </li>
                      </ul>
                 </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>