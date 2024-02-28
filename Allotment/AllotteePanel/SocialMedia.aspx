<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="SocialMedia.aspx.cs" Inherits="Allotment.AllotteePanel.SocialMedia" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Social   |  Media</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper allottee-leadger">
        <section class="content">
            <div class="card-solid">
                <div class="card-body pb-0">
                    <div class="box">
                        <%-- Social Media  Start--%>
                        <div class="heading-main-top">
                            <h1 class="subtitle fancy"><span>Social Media</span></h1>
                        </div>
                    </div>
                    <%-- Social Media Start--%>
                    <div class="card">
                        <div class="card-body">
                            <div class="main-social0">
                                <div class="row">
                                    
                                    <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
                                        <%--  instagram start--%>
                                        <div class="social_media1">
                                            <a href="https://www.instagram.com/upsida_official/" target="_blank"> <h1 style="background-color:#c61515; text-align: center;"><span>Instagram</span><i class="fas fa-instagram"><span style="font-size: 14px;">click here</span> </i></h1></a>
                                            
                                        </div>
                                        <%--  instagram End--%>
                                    </div>

                                     <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
                                        <%--  linkedin start--%>
                                        <div class="social_media1">
                                         <a href="https://www.linkedin.com/company/upsida-official/" target="_blank">   <h1 style="background-color:#0a66c2; text-align: center;"><span>Linkedin</span><i class="fas fa-linkedin"><span style="font-size: 14px;">Click here</span> </i></h1> </a>
                                        </div>
                                        <%--  linkedin End--%>
                                    </div>

                                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                        <%--  facebook start--%>
                                        <div class="social_media1">
                                            <h1><i class="fa fa-facebook"></i><span>Facebook</span></h1>
                                            <div class="social_link">
                                            <iframe src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2FUPSIDAOfficial&tabs=timeline&small_header=true&adapt_container_width=true&hide_cover=false&show_facepile=true&appId" class="social_media_ifrem"></iframe></div>
                                        </div>
                                        <%--  facebook End--%>
                                    </div>
                                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                        <%--  Twitter start--%>
                                        <div class="social_media1 tweetwe">
                                            <h1><i class="fa fa-twitter"></i><span>Twitter</span></h1>
                                            <div class="social_link1">
                                                <a class="twitter-timeline" href="https://twitter.com/UPSIDA?ref_src=twsrc%5Etfw"></a>
                                                <script src="https://platform.twitter.com/widgets.js"></script>
                                            </div>
                                        </div>
                                        <%--  Twitter End--%>
                                    </div>
                                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                        <%--  Youtube start--%>
                                        <div class="social_media1 youtunesw">
                                            <h1><i class="fa fa-youtube"></i><span>Youtube</span></h1>
                                            <div class="social_link1">
                                                <div class="youtubes">
                                                    <iframe src="https://www.youtube.com/embed/OVmy1Od2cLk" title="YouTube video player" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"></iframe>
                                                </div>
                                                <div class="youtubes">
                                                    <iframe src="https://www.youtube.com/embed/hveLmKHbtTc" title="YouTube video player" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"></iframe>
                                                </div>
                                                <div class="youtubes">
                                                    <iframe src="https://www.youtube.com/embed/jn-wx94uOAE" title="YouTube video player" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"></iframe>
                                                </div>
                                            </div>
                                        </div>
                                        <%--  Youtube End--%>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <%--  Social Media End--%>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

