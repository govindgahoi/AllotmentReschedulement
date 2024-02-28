<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetailApi.aspx.cs" Inherits="UpsidaAllottee.UserDetailApi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <%--<link href="/css/theme.css" rel="stylesheet" />--%>
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">--%>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>--%>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
     <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
    <script>
          //const params = new URLSearchParams(window.location.search);
            
         //   var serNo = params.get('ServiceReqNo');
	    //var type= params.get('Type');
        $(document).ready(function () {

        });
          var _DynamicArr=[];
          $('#fileaxup').change(function(e) {
              debugger
              var fd = new FormData();
              var _files="";
              var _fileName="";
              var fileext="";
              //$.each()
              //var id=$(this).attr('id');

              _files = $('#fileaxup')[0].files[0];
              fd.append('file', _files);
              _fileName=_files.name;
              fileext=_fileName.split('.').pop();
              getFileBuffer(_files).then(function(buffer){            
                  _DynamicArr.push({buffer:buffer,FileName:_fileName});
              });
          });
              $('#UploadButton').click(function () {
                  debugger
                  fileUpload();
              });

              function fileUpload(){
                  debugger
                  $.each(_DynamicArr,function(key,value){
                      UploadAttachment("SER20210402/1029/28356/15151","APA",value.buffer, "document", fileext)
                  });
              }
              function getFileBuffer (file) { 
                  var deferred = $.Deferred();  
                  var reader = new FileReader();

                  reader.onload = function (e) {  
                      deferred.resolve(e.target.result);  
                  }  
                  reader.onerror = function (e) {  
                      deferred.reject(e.target.error);  
                  }  
                  reader.readAsArrayBuffer(file);  
                  return deferred.promise();  
              }
              function UploadAttachment(srNo, type, buffer, _fileName, FileName) {
                  debugger
                  $.ajax({
                      // url: 'UserDetailApi.aspx/uploadSignedCopy',
                      type: "POST",
                      dataType: "json",
                      contentType: "application/json; charset=utf-8",
                      url: 'UserDetailApi.aspx/uploadSignedCopy',
                      data: JSON.stringify({ serReqNo: srNo, type: type, fUpload: buffer, fName: _fileName, FileExtention: fileext }),
                      
                      success: function (data) {
                          alert(FileName + ' has been Uploaded');
                      },
                      error: function (error) {
                          console.log(JSON.stringify(error));
                          dfdP.reject(error);
                      }
                  });
              }
              
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    <asp:fileupload id="fileaxup" runat="server"></asp:fileupload>
        <asp:Button id="UploadButton" 
            Text="Upload file"
            
            runat="server">
        </asp:Button>
    </div>
    </form>

      <script>
          //const params = new URLSearchParams(window.location.search);
            
         //   var serNo = params.get('ServiceReqNo');
	    //var type= params.get('Type');
        $(document).ready(function () {

        });
        var _DynamicArr = [];
        var Buffer;
        var fileext = "";
        var _files = "";
        var _fileName = "";
          $('#fileaxup').change(function(e) {
              debugger
              var fd = new FormData();
              
              //$.each()
              //var id=$(this).attr('id');

              _files = $('#fileaxup')[0].files[0];
              fd.append('file', _files);
              _fileName=_files.name;
              fileext=_fileName.split('.').pop();
              getFileBuffer(_files).then(function(buffer){            
                  //_DynamicArr.push({buffer:buffer,FileName:_fileName});
                  Buffer = buffer;
              });
          });
              $('#UploadButton').click(function () {
                  debugger
                  fileUpload();
              });

              function fileUpload(){
                  debugger
                  
                      UploadAttachment("SER20210402/1029/28356/15151", "APA", Buffer, "document", fileext)
                 
              }
              function getFileBuffer (file) { 
                  var deferred = $.Deferred();  
                  var reader = new FileReader();

                  reader.onload = function (e) {  
                      deferred.resolve(e.target.result);  
                  }  
                  reader.onerror = function (e) {  
                      deferred.reject(e.target.error);  
                  }  
                  reader.readAsArrayBuffer(file);  
                  return deferred.promise();  
              }
              function UploadAttachment(srNo, Tp, buffer, _fileName, FileName) {
                  debugger
                  $.ajax({
                      // url: 'UserDetailApi.aspx/uploadSignedCopy',
                      type: "POST",
                      dataType: "json",
                      contentType: "application/json; charset=utf-8",
                      url: 'UserDetailApi.aspx/uploadSignedCopy',
                      data: JSON.stringify({ serReqNo: srNo, Tp: Tp, fUpload: buffer, fName: _fileName, FileExtention: fileext }),
                      
                      success: function (data) {
                          alert(FileName + ' has been Uploaded');
                      },
                      error: function (error) {
                          console.log(JSON.stringify(error));
                          dfdP.reject(error);
                      }
                  });
              }
              
    </script>

</body>
</html>
