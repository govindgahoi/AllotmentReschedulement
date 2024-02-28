<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ArchitectDetails.ascx.cs" Inherits="Allotment.UC_ArchitectDetails" %>
 <div class="panel-body">

                <div runat="server" id="hideDiv">
                    <div class="panel-heading font-bold">Architect Detail</div>
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name of Architect
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtNameTechnical" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Architect Licensed No :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtLicensedPerson" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Architect Registration No
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtRegistration" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Address of Architect:
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtAddressPerson" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />

                    <div class="panel-heading font-bold">Structural Engineer Detail</div>
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name of Structural Engineer
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineer" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Structural Engineer Licensed No :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineerLicensedNo" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Structural Engineer Licensed No :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineerRegistratinNo" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Address of Structural Engineer:
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineerAddress" CssClass="input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                 
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                   
                </div>
            </div>