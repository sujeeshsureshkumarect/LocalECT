﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Services.aspx.cs" Inherits="LocalECT.HR_Services" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;HRM /</a>
                        <a href="HR_Services">&nbsp;HR Services</a>

                    </h3>
                                </div>
                                <style>
                                      .breadcrumb {
                        padding: 8px 15px;
                        margin-bottom: 20px;
                        list-style: none;
                        background-color: #ededed;
                        border-radius: 4px;
                        font-size: 13px;
                    }
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }                                  
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-users"></i> HR Services</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                                          <div id="divStudentServices">
                                               <asp:Repeater ID="RepterDetails" runat="server">  
    <HeaderTemplate>  
        </HeaderTemplate>
                                                   <ItemTemplate>  
                                               <div class="col-md-4 col-sm-4" style="min-height:210px;">
                                                   
                                                       <div class="card text-center">
                                                           <h5 class="card-header" style = "text-transform:capitalize;"><%#Eval("ServiceEn") %><br />
                                                               <%#Eval("ServiceAr") %></h5>
                                                           <div class="card-body">
                                                               <h2 class="card-title hztitle"><%#Eval("HostDesc") %></h2>
                                                               <%--<h2 class="card-text hztitle"><%#Eval("ServiceDescEn") %></h2>   --%>
                                                               <%--<h4 class="card-text h4text1">(Inclusive of VAT)</h4>--%>
                                                               <div class="accordion" id="accordion<%# Container.ItemIndex %>" role="tablist" aria-multiselectable="true">
                                                                   <div class="panel">
                                                                       <a class="panel-heading collapsed" role="tab" id="headingOne<%# Container.ItemIndex %>" data-toggle="collapse" data-parent="#accordion<%# Container.ItemIndex %>" href="#collapseOne<%# Container.ItemIndex %>" aria-expanded="false" aria-controls="collapseOne<%# Container.ItemIndex %>">
                                                                           <p class="panel-title"><i class="fa fa-chevron-down"></i> Click to View More</p>
                                                                       </a>
                                                                       <div id="collapseOne<%# Container.ItemIndex %>" class="panel-collapse in collapse" role="tabpanel" aria-labelledby="headingOne<%# Container.ItemIndex %>" style="">
                                                                           <div class="panel-body">
                                                                               <h4 class="card-text h4text"><b><u>Descritpion</u></b></h4>
                                                                               <h4 class="card-text h4text"><%#Eval("ServiceDescEn") %></h4>
                                                                               <h4 class="card-text h4text"><%#Eval("ServiceDescAr") %></h4>
                                                                               <%--<hr />                                                                                       
                                                                               <h4 class="card-text h4text"><b><u>Example:</u></b></h4>
                                                                               <a href="<%#Eval("ExampleLink") %>" target="_blank" title="Click to Open">
                                                                                   <img src="<%#Eval("ExampleLink") %>" style="height: auto; width: 50%" onerror="this.src='images/noimage.jpg'"/></a>--%>
                                                                           </div>
                                                                       </div>
                                                                   </div>
                                                               </div>
                                                               <a href="<%#Eval("RequestLink") %>?ServiceID=<%#Eval("ServiceID") %>" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Create Request</a>
                                                           </div>
                                                       </div>
                                                  
                                               </div>
</ItemTemplate>
                                                   <FooterTemplate>     
    </FooterTemplate>  
    </asp:Repeater> 
                                            
                                                
                                             
                                               
                                           </div>
               <style>
        .accordion .panel-heading {
    background: #F2F5F7;
    padding:1px;
    width: 100%;
    display: block;
}
        .servh2{
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    /* border-left: white thin solid; */
    color: #ECF0F1;
    /* border-bottom: white thin solid; */
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2a3f54;
/*    text-align: center;*/
    line-height: 2;
    font-size: 13px;
        }
    .card-header {
    padding: .75rem 1.25rem;
    margin-bottom: 0;
    background-color: #3f658c;
    border-bottom: 1px solid rgba(0,0,0,.125);
    color: #f8fafb !important;
}
    .hztitle {
    font-size: 14px;
    /*font-weight: bold;*/
}
    .h5, h5 {
    font-size: 14px;
}
    .h4text {
    font-size: 13px !important;
    font-weight: 500;
}
      .h4text1 {
    font-size: 11px !important;
    font-weight: 500;
}
    .card-body {   
    padding: 0rem !important;
}
    </style>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>