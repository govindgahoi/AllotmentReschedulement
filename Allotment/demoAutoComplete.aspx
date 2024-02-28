<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoAutoComplete.aspx.cs" Inherits="Allotment.demoAutoComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link href="css/jquery-ui.css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js.js"></script>
    <script src="js/jquery-ui.js"></script>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />

  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.0/jquery-ui.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <label class="col-md-2 col-sm-6 text-right">
                                            Industrial Area:
                                        </label>
                                        <div class="col-md-2 col-sm-6">
                                            <asp:Label runat="server" ID="drpIndusrialArea" CssClass="chosen input-sm similar-select1 margin-left-z form-control" Text="Chinhat"></asp:Label>
                                        </div>
                                        
                                        <label class="col-md-1 col-sm-6 text-right">
                                            Plot No:
                                        </label>
                                        <div class="col-md-2 col-sm-6">
                                            <asp:TextBox runat="server" ID="txtsearch" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control" ></asp:TextBox>
                                        </div>

    </div>
    </form>
       <script type="text/javascript" lang="javascript">
           $(document).ready(function () {
               debugger
               $('#<%=txtsearch.ClientID%>').autocomplete(
                   {
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: '<%=ResolveUrl("~/searchService.asmx/GetAutoCompleteData") %>',
                        data: "{" +
                        "'txtSearch':'" + request.term + "'," +
                        "'IAName':'" + $('#<%= drpIndusrialArea.ClientID %>').val() + "'" +
                      
                        "}",
                        dataType: "json",
                        //async:false,
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                            alert(textStatus);
                        }
                    });
                },
                //    select: function (e, i) {
                //    $("[id$=hfCustomerId]").val(i.item.val);
                //},
                minLength: 1
            });
        });
        $("input[type=text]").keyup(function () {
            $("#gridView").hide();
            $("#warningmsg").hide();
        });
    </script>
    
</body>
</html>
