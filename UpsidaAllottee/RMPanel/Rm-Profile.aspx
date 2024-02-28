<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="Rm-Profile.aspx.cs" Inherits="UpsidaAllottee.RMPanel.Rm_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section profile">
            <div class="row">
                <div class="col-md-3"></div>
            <div class="col-md-6">
                    <div class="card">
                        <div class="card-body profile-overview profile-edit pt-3">
                            <div class="row ">
                                <img src="assets/img/profile-img.jpg" alt="Profile" class="rounded-circle" />
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg-3 col-md-4 label">Full Name</div>
                                <div class="col-lg-9 col-md-8">SHRI VINOD KUMAR</div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-md-4 label">Regional Office</div>
                                <div class="col-lg-9 col-md-8">AGRA</div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-md-4 label">Address</div>
                                <div class="col-lg-9 col-md-8">Administrative Building, EPIP, Shastripuram, Agra.</div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-md-4 label">State</div>
                                <div class="col-lg-9 col-md-8">Uttar Pradesh</div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-md-4 label">Phone No.</div>
                                <div class="col-lg-9 col-md-8">9451427184</div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-md-4 label">Landline No</div>
                                <div class="col-lg-9 col-md-8">0562-2641924</div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-md-4 label">Email</div>
                                <div class="col-lg-9 col-md-8">rmagra@upsida.co.in</div>
                            </div>
                        </div>
                    </div>
                </div>
            <div class="col-md-3"></div>
                </div>
        </section>
    </main>

</asp:Content>
