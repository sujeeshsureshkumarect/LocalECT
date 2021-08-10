<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginas.aspx.cs" Inherits="LocalECT.Loginas" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="Loginas">&nbsp;Login As</a>                        
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
                                            <h2><i class="fa fa-user"></i> Login as Another User</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                             <div class="col-sm-3 col-md-3 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Username</label>  
                                        <div class="input-group">  
                                           <asp:DropDownList ID="drp_Users" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>                                          
                                    </div>  
                                </div><br />
                                            <asp:Button ID="btn_Login" runat="server" Text="Login" CssClass="btn btn-success btn-sm" OnClick="btn_Login_Click"/>
            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>