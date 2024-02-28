<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CommentsBT.ascx.cs" Inherits="Allotment.UC_CommentsBT" %>


<script type='text/javascript'>
      

        function PrintElem() {

            Popup($('#DivP').html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Application</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }

    </script>
<div class="panel-heading font-bold" style="padding:7px 3px !important;">Comments And Recommendations</div>
						                        
                    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">
                           <asp:Label ID="DivNotesheet" runat="server" />
                    </div>
               



				<div class="clearfix"></div>