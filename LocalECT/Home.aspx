﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LocalECT.Home" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3>Welcome To Emirates College of Technology (ECT)</h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                    /* A[href=""], A[href="#"] {
  display: none;
}*/
                                </style>
                                <%--  <div class="title_right">
                <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                      <button class="btn btn-default" type="button">Go!</button>
                    </span>
                  </div>
                </div>
              </div>--%>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Dashboard</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div class="col-md-4 col-sm-12">
                                                <a class="weatherwidget-io" href="https://forecast7.com/en/24d4554d38/abu-dhabi/" data-label_1="ABU DHABI" data-label_2="WEATHER" data-theme="original" data-basecolor="#3f658c" data-textcolor="#fff">ABU DHABI WEATHER</a>
                                                <script>
                                                    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = 'https://weatherwidget.io/js/widget.min.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'weatherwidget-io-js');
                                                </script>                                                
                                            </div> 
             <%--                                <div class="col-md-8" style="width:100%;overflow-y:scroll;max-height:550px;">
                <div class="x_panel">
                  <div class="x_title">
                    <h2><i class="fa fa-volume-up"></i> ECT Announcements</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                     
                      <li><a class="close-link"><i class="fa fa-close"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                   <div>

                        <h4>Latest News</h4>

                        <!-- end of user messages -->
                        <ul class="messages">
                            <asp:Repeater ID="RepeaterNews" runat="server">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <img src="https://lms.ectmoodle.ae/theme/image.php/ect/theme/1595326309/favicon" class="avatar" alt="Avatar">
                                        <div class="message_date">
                                            <h3 class="date text-info"><%# Eval("dDate", "{0:dd}") %></h3>
                                            <p class="month"><%# Eval("dDate", "{0:MMM}") %></p>
                                            <p class="month"><%# Eval("dDate", "{0:yyyy}") %></p>
                                        </div>
                                        <div class="message_wrapper">
                                            <h4 class="heading"><a href="<%#Eval("sLink") %>?header=link" target="_blank"><%#Eval("sHeader") %></a></h4>
                                            <blockquote class="message" style="text-align: justify;text-justify: inter-word;"><%#Eval("sDetail") %></blockquote>
                                            <br>
                                            <p class="url">
                                                <span class="fs1 text-info" aria-hidden="true" data-icon=""></span>
                                                <a href="<%#Eval("sAttachment") %>" target="_blank" style="color: blue;"><u><i class="fa fa-paperclip"></i> <%#Eval("sAttachment") %></u></a>
                                            </p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate></FooterTemplate>
                            </asp:Repeater>
                        </ul>
                        <!-- end of user messages -->


                      </div>
                  </div>
                </div>
              </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>