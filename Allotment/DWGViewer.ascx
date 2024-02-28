<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DWGViewer.ascx.cs" Inherits="Allotment.DWGViewer" %>
<%@ Register Assembly="CADControl" Namespace="WebCAD" TagPrefix="sg" %>



    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    

    <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/smoothness/jquery-ui.css">
    <link rel="stylesheet" type="text/css" href="./Content/buttons.css">
    <link rel="stylesheet" type="text/css" href="./Content/site.css">

    <script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>
    <%--<script src="http://code.jquery.com/jquery-1.10.2.js"></script>--%>
    <%--<script src="http://code.jquery.com/jquery-2.0.3.js"></script>--%>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#buttonSet0").buttonset();
            $("#buttonSet1").buttonset();
            $("#buttonSet2").buttonset();
            $("#buttonSet3").buttonset();

            var iconSet = [{ icon: "icon_save", text: false }, { icon: "icon_copy", text: false }, { icon: "icon_print", text: false }, { icon: "icon_zoomin", text: false }, { icon: "icon_zoomout", text: false }, { icon: "icon_orbit", text: false }, { icon: "icon_bw", text: false }, { icon: "icon_bwdraw", text: false }, { icon: "icon_extents", text: false }, { icon: "icon_layers", text: false }, { icon: "icon_select", text: false }, { icon: "icon_line", text: false }, { icon: "icon_poly", text: false }, { icon: "icon_area", text: false }];
            $("button.nav").each(function (i) {
                if ((i < iconSet.length)) {
                    $(this).button({
                        text: iconSet[i].text,
                        icons: { primary: iconSet[i].icon }
                    });
                } else {
                    $(this).button();
                }
            });
            $("#dialogLayers").dialog({ autoOpen: false, width: "auto", height: "auto" });
            $("#dialogMeasuring").dialog({ autoOpen: false, close: function (ev, ui) { if (!noClosedMeas) measStart(this, false); } });
            $("#dialogPrint").dialog({ autoOpen: false, width: 600 });
            $("#dialogEntInfo").dialog({ autoOpen: false, width: 450 });
			$("#clipboardPreview").dialog({ autoOpen: false, width: "auto", height: "auto", position: [150, 150] });

            changeDialogVisibility = function (dlg) {
                if ($(dlg).dialog("isOpen")) {
                    $(dlg).dialog("close");
                } else {
                    $(dlg).dialog("open");
                }
            }
        });
    </script>

    <style type="text/css">
        @media screen {
            .nonPrintableArea {
                display: block;
            }

            .printableArea {
                display: none;
            }
        }

        @media print {
            body {
                margin: 0;
                padding: 0;
            }

            .nonPrintableArea {
                display: none;
            }

            .printableArea {
                display: block;
            }
        }
    </style>



    <div class="printableArea">
        <img id="printImage" onload="window.print()" />
    </div>
    <div class="nonPrintableArea">
        <div class="nav left makesmaller">
            <span id="buttonSet0">
                <button class="nav" onclick="saveAsDXF();">Save as DXF</button>
				<button class="nav" onclick="copyToClip(true);">Copy</button>
                <button class="nav" onclick="popupPrint();">Print</button>
            </span>
            <span id="buttonSet1">
                <button class="nav" onclick="CADControl1.cad.face.zoomIn();">Zoom in</button>
                <button class="nav" onclick="CADControl1.cad.face.zoomOut();">Zoom out</button>
                <button class="nav" onclick="CADControl1.cad.orbit.enabled = !CADControl1.cad.orbit.enabled;">3D Orbit</button>
            </span>
            <span id="buttonSet2">
                <button class="nav" onclick="CADControl1.cad.face.changeBackgroundColor(this);">Black background</button>
				<button class="nav" onclick="var mode = (CADControl1.cad.getDrawMode() == 0)? 1: 0; CADControl1.cad.setDrawMode(mode);">B/W Drawing</button>
                <button class="nav" onclick="CADControl1.cad.face.resetView();">Fit to window</button>
                <button class="nav" onclick="CADControl1.cad.face.updateCBL('checkBoxlist'); changeDialogVisibility('#dialogLayers');">Layers</button>
                <button class="nav" onclick="CADControl1.cad.setInfoEnabled();">Info</button>
            </span>
            <span id="buttonSet3">
                <button class="nav" onclick="measStart(this, 1)">Distance</button>
                <button class="nav" onclick="measStart(this, 2)">Polyline</button>
                <button class="nav" onclick="measStart(this, 3)">Area</button>
            </span>
            <select class="nav" id="dropDownlist">
            </select>
            <select class="nav" id="viewsDownlist">
            </select>
            <select class="nav" id="displayDownlist">
            </select>
        </div>
        <form id="Form1" runat="server">
           
            <div style="display:none;">
            <asp:FileUpload ID="FileUpload1" runat="server" Width="230" onchange="Button1.click()"/>
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" style="display: none"/>
            <asp:Button ID="Button2" runat="server" Text="Load from HDD" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Load from Web" OnClick="Button3_Click" />
			<input type="button" value="Merge" name="MergeFile" onclick="if (confirm('Select insert point')) CADControl1.cad.onselectpoint = startMerge;" />
            <asp:Button ID="Button4" runat="server" Text="Download CSV" OnClick="Button4_Click" />
			<input type="text" name="inputText"/>
			<input type="button" value="Find" name="FindButton" onclick="findText(inputText.value)" />
            <br />
            <br /></div>
            <sg:CADControl runat="server" ID="CADControl1" Service="./draw" Height="100%" Width="100%" DefaultSHXFont="simplex.shx" SHXSearchPaths="SHX\" UseSHXFonts="True" SHXDefaultPath="SHX\" OnEntityClickEvent="CADControl1_EntityClickEvent"></sg:CADControl>
        </form>
        <div id="dialogLayers" class="makesmaller" title="Layers">
            <form id="checkBoxlist" style="max-height: 500px">
            </form>
        </div>
        <div id="dialogMeasuring" class="makesmaller" title="Mass">
            <form id="measuringList" style="max-height: 500px">
                <label id="lbDistanse" for="edDistance">Distance</label><input id="edDistance" type="text" />
                <br />
                <label id="lbDeltaX" for="edDeltaX">Delta X</label><input id="edDeltaX" type="text" />
                <br />
                <label id="lbDeltaY" for="edDeltaY">Delta Y</label><input id="edDeltaY" type="text" />
                <br />
                <label id="lbPerimeter" for="edPerimeter">Perimeter</label><input id="edPerimeter" type="text" />
                <br />
                <label id="lbArea" for="edArea">Area</label><input id="edArea" type="text" />
                <br />
                <label id="lbAngle" for="edAngle">Angle</label><input id="edAngle" type="text" />
            </form>
        </div>
        <div id="dialogEntInfo" class="makesmaller" title="Entity info">
        </div>
        <div id="clipboardPreview" class="makesmaller" title="Clipboard preview">
        </div>		
    </div>
    <script type="text/javascript">
	    cad.utils.setElementDefaults("checkBoxlist");

        CADControl1.cad.face.updateCBL("checkBoxlist");
        CADControl1.cad.face.updateDDL("dropDownlist");
        //CADControl1.cad.isShowSnap = true;
        CADControl1.cad.settings.ScaleName = "m";
        CADControl1.cad.settings.CADsInUnit = 1;
		
        var viewsNames = ["Initial View", "-", "Top View", "Bottom View", "Left View", "Right View", "Front View", "Back View", "-", "SW Isometric", "SE Isometric", "NE Isometric", "NW Isometric"];
        CADControl1.cad.face.updateVDL("viewsDownlist", viewsNames);
        var displayModes = ["2D Wireframe", "-", "3D Wireframe", "3D Hidden lines", "3D Smooth shading", "3D Flat shading"];
        CADControl1.cad.face.updateVDL("displayDownlist", displayModes, 100);

        cad.get(CADControl1.cad, "mode?" + cad.makeParams({ id: CADControl1.cad.guid }), undefined, function (msg) {
            if (msg > 0)
                displayDownlist.selectedIndex = msg;
        }, null, true);

        var saveAsDXF = function () {
            location.href = cad.service + "/saveasdxf?id=" + CADControl1.cad.guid;
        }

        var measStart = function (e, t) {
            var m = CADControl1.cad.measuring;
            m.start(m.mode != t ? t : 0);
        }

        CADControl1.cad.onselect = function (msg) {
            dialogEntInfo.innerHTML = "";
            var innerHTML = "<table style=\"width:100%\">";
            var isOpen = false;

            if (msg) {
                //var xml = msg.xml;
                //delete  msg.xml;
                var isOpen = false;

                for (var i = 0; i < msg.length; i++) {
                    innerHTML += "<tr><td><b>" + msg[i].Key + "</b></td><td>" + msg[i].Value + "</td></tr>";
                    isOpen = true;
                }
                dialogEntInfo.innerHTML = innerHTML + "</table>";

                if (isOpen)
                    $(dialogEntInfo).dialog("open");
            }

            if (!isOpen)
                $(dialogEntInfo).dialog("close");
        }

        CADControl1.cad.measuring.onmeasuring = function (e) {
            if (confirm('Are you sure?')) {
                return true;
            }
            return false;
        }

        var makePopupWindowParams = function (w, h) {
            var params = [];
            var x = 0, y = 0;

            if (cad.utils.browser.msie) {
                x = window.screenLeft;
                y = window.screenTop;
            } else {
                x = window.screenX;
                y = window.screenY;
            }

            var top = y + (document.documentElement.clientHeight - h) / 2;
            var left = x + (document.documentElement.clientWidth - w) / 2;

            params.push("top=" + top);
            params.push("left=" + left);
            params.push("height=" + h);
            params.push("width=" + w);
            return params.join(",");
        }

        var setMeasValue = function (edt, val, is_open) {
            if (val) {
                edt.value = val.toFixed(2);
                edt.style.display = "inline";
                is_open.val = true;
                edt.blur();
            } else
                edt.style.display = "none";

            return is_open.val;
        }

        var showMeasuring = function (dist, area, perimeter, angle, deltaX, deltaY, isShow) {
            var dlg = '#dialogMeasuring';
            var isOpen = { val: false };
            noClosedMeas = isShow;

            if (cad.utils.browser.msie) {
                edDistance = document.getElementById("edDistance");
                edArea = document.getElementById("edArea");
                edPerimeter = document.getElementById("edPerimeter");
                edAngle = document.getElementById("edAngle");
                edDeltaX = document.getElementById("edDeltaX");
                edDeltaY = document.getElementById("edDeltaY");
            }

            setMeasValue(edDistance, dist, isOpen);
            setMeasValue(edDeltaX, deltaX, isOpen);
            setMeasValue(edDeltaY, deltaY, isOpen);
            setMeasValue(edArea, area, isOpen);
            setMeasValue(edPerimeter, perimeter, isOpen);
            setMeasValue(edAngle, angle, isOpen);

            if (!isShow)
                isOpen.val = false;
            else if (isShow && CADControl1.cad.measuring.mode == 1)
                isOpen.val = true;

            if (isOpen.val) {
                if (!($(dlg).dialog("isOpen"))) {
                    $(dlg).dialog("open");
                    //$(dlg).dialog('option', 'position', [x,y]);
                }
            } else {
                $(dlg).dialog("close");
            }

            noClosedMeas = false;
        }
		
		CADControl1.cad.measuring.onShowMeasuring = showMeasuring;

        var copyToClip = function (showPreview) {
            if (showPreview) {
                if ($(clipboardPreview).dialog("isOpen"))
                    $(clipboardPreview).dialog("close");
                else {
                    var elem = document.getElementById("clipboardPreview");

                    if (elem.firstChild)
                        elem.removeChild(elem.firstChild);

                    var img = CADControl1.cad.copyToClipboard();

                    img.style.maxWidth = (window.innerWidth * 2 / 3).toString() + "px";
                    elem.appendChild(img);
                    $(clipboardPreview).dialog("open");
                }
            }
            else
                $(clipboardPreview).dialog("close");
        }
		
        var findText = function (str) {
            var msg = CADControl1.cad.findText(str, false);
            var innerHTML = "<table style=\"width:100%\">";
            var isOpen = false;

            dialogEntInfo.innerHTML = "";

            for (var i = 0; i < msg.length; i++) {
                innerHTML += "<tr><td>" + msg[i].Handle.toString() + "</td><td>" + msg[i].BoxCAD.Left.toString() + "," + msg[i].BoxCAD.Top.toString() + "," + msg[i].BoxCAD.Right.toString() + "," + msg[i].BoxCAD.Bottom.toString() + "</td><td>" + msg[i].Text + "</td></tr>";
                isOpen = true;
            }

            if (isOpen)
            {
                dialogEntInfo.innerHTML = innerHTML + "</table>";
                $(dialogEntInfo).dialog("open");
            }
            else
                $(dialogEntInfo).dialog("close");
        }
	
        var runXML = function(str) {
            var res = CADControl1.cad.processXML(str);
            dialogEntInfo.innerHTML = "<textarea style=\"width:100%\" name=\"res\" cols=\"25\" rows=\"10\">" + res + "</textarea>";
            $(dialogEntInfo).dialog("open");
        }
		
        var makePopupWindowParams = function (w, h) {
            var params = [];
            var x = 0, y = 0;

            if (cad.utils.browser.msie) {
                x = window.screenLeft;
                y = window.screenTop;
            } else {
                x = window.screenX;
                y = window.screenY;
            }

            var top = y + (document.documentElement.clientHeight - h) / 2;
            var left = x + (document.documentElement.clientWidth - w) / 2;

            params.push("top=" + top);
            params.push("left=" + left);
            params.push("height=" + h);
            params.push("width=" + w);
            return params.join(",");
        }

        var getCadRefernce = function () {
            return CADControl1.cad;
        }

        var popupPrint = function () {
            if (CADControl1.cad.isPrint()) {
                CADControl1.cad.cancel();
            }
            else {
                var params = makePopupWindowParams(500, 320);
                var win = window.open('<%=CADControl1.GetForm(CADControl.DialogForm.Print, "eng")%>', '_blank', params);

                $(win.document).ready(function () {
                    win.cad = CADControl1.cad;
                });
            }
        }

        var startMerge = function (merge_pt) {
            CADControl1.cad.onselectpoint = null;

            var params = makePopupWindowParams(320, 210);
            var win = window.open('<%=CADControl1.GetForm(CADControl.DialogForm.Merge, "eng")%>', '_blank', params);

            $(win.document).ready(function () {
			    win.ns_cad = cad;
                win.cad = CADControl1.cad;
                win.merge_pt = merge_pt;
                win.scale_pt = { x: 1, y: 1 };
                win.rotation = 0;
                win.x_name = 'name' + Math.random();
            });
        }
		
    </script>

