<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance_Management_Update.aspx.cs" Inherits="LocalECT.Attendance_Management_Update" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <%--<a href="#">&nbsp;Registration /</a>--%>
                        <a href="Attendance_Management">&nbsp;Attendance Management</a>

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
                 /*   .alert{
                        padding:5px;
                    }*/
                    .table {
                        color:#444444;
                    }
                    .dropdown-item {
    width: 100%;
    padding: 5px !important;
}
                </style>
               
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-calendar"></i> Attendance Management-Update</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <%--<a href="Student_Profile.aspx" class="btn btn-success btn-sm" id="lnk_add" runat="server"><i class="glyphicon glyphicon-plus"></i> Create New Student</a>--%>
                               <%-- <asp:LinkButton ID="lnk_add" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_add_Click"><i class="glyphicon glyphicon-plus"></i> Create New Student</asp:LinkButton>--%>
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                              <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">
                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="div_Alert">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <asp:Label ID="lbl_Msg" runat="server" Text="" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12">
                                <div class="form-group row">
                                    <label class="col-form-label col-md-1 col-sm-1 ">Campus</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:DropDownList ID="drp_Campus" runat="server" CssClass="form-control" Enabled="false">
                                            <asp:ListItem Text="Males" Value="1" />
                                            <asp:ListItem Text="Females" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                    <label class="col-form-label col-md-1 col-sm-1 ">Term</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:DropDownList ID="ddlTerm" runat="server" CssClass="form-control" Enabled="false">                                            
                                        </asp:DropDownList>
                                    </div>
                                    <label class="col-form-label col-md-1 col-sm-1 ">Course</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:TextBox ID="txt_Course" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>                                    
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-1 col-sm-1 ">Student ID</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:TextBox ID="txt_StudentID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <label class="col-form-label col-md-1 col-sm-1 ">Date</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:TextBox ID="txt_Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div> 
                                    <label class="col-form-label col-md-1 col-sm-1 ">Status</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:DropDownList ID="drp_Status" runat="server" CssClass="form-control">                                            
                                        </asp:DropDownList>
                                    </div>                                     
                                </div> 
                                <div class="form-group row">
                                    <label class="col-form-label col-md-1 col-sm-1 ">Note</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:TextBox ID="txt_Note" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:LinkButton ID="lnk_Search" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Search_Click" ValidationGroup="no"><i class="fa fa-save"></i> Update</asp:LinkButton>
                                    </div>
                                    </div>
                            </div>
                           
                            
                           
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>            
</asp:Content>
