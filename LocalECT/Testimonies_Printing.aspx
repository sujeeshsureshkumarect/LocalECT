<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testimonies_Printing.aspx.cs" Inherits="LocalECT.Testimonies_Printing" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Testimonies</a>
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
                            <h2><i class="fa fa-print"></i> Testimonies Printing</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                 <a href="StudentSearch.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Student Search</a>
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
                            <div class="col-md-6 col-sm-6">
                                <div class="x_panel">
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Student ID</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:TextBox ID="lblID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Student Name</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:TextBox ID="lblName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Term</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:DropDownList ID="Terms" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="Terms_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Testimony</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:RadioButtonList ID="rbnTestimony" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="rbnTestimony_SelectedIndexChanged" CssClass="form-control" Height="200px">
                                                <asp:ListItem Selected="True">Registered</asp:ListItem>
                                                <asp:ListItem>Final Exams</asp:ListItem>
                                                <asp:ListItem>Attend Final Exams</asp:ListItem>
                                                <asp:ListItem>Training</asp:ListItem>
                                                <asp:ListItem>Admission</asp:ListItem>
                                                <asp:ListItem>Graduation</asp:ListItem>
                                                <asp:ListItem>Graduate Verification Form</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Language</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:RadioButtonList ID="rbnLanguage" runat="server"
                                                RepeatDirection="Horizontal"
                                                OnSelectedIndexChanged="rbnLanguage_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Selected="True">Arabic</asp:ListItem>
                                                <asp:ListItem>English</asp:ListItem>
                                            </asp:RadioButtonList>

                                            <asp:CheckBox ID="chkTable" runat="server" Text="Include Courses Time Table"
                                                AutoPostBack="True" OnCheckedChanged="chkTable_CheckedChanged" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <div class="x_panel">
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Course(s)</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:CheckBoxList ID="chkIncluded" runat="server" RepeatDirection="Horizontal" CssClass="form-control">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">From</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" ReadOnly="true" placeholder="yyyy-mm-dd" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">To</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" ReadOnly="true" placeholder="yyyy-mm-dd" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                                                                                                                    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
                $j("#txtDateFrom").datepicker({ dateFormat: 'yy-mm-dd' });
                $j("#txtDateTo").datepicker({ dateFormat: 'yy-mm-dd' });
            });
        </script>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Destination</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:TextBox ID="txtDestination" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-3 col-sm-3">Signed By</label>
                                        <div class="col-md-9 col-sm-9 ">
                                            <asp:DropDownList ID="ddlSignedBy" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="1">Manager - Student Registration</asp:ListItem>
                                                <asp:ListItem Value="2">Director - Student Affairs and Registration</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:CheckBox ID="chkPrintHeaderFooter" runat="server"
                                                
                                                Text="Print Header &amp; Footer" Checked="True" ForeColor="#0066FF" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <asp:LinkButton ID="Print_btn" runat="server" CssClass="btn btn-success btn-sm" OnClick="Print_btn_Click"><i class="fa fa-file-pdf-o"></i> Print PDF</asp:LinkButton>
                                    <asp:LinkButton ID="Word_btn" runat="server" CssClass="btn btn-success btn-sm" OnClick="Word_btn_Click"><i class="fa fa-file-word-o"></i> Print Word</asp:LinkButton>
                                    <asp:HiddenField ID="hfText1" runat="server" />
                                                    <asp:HiddenField ID="hfText2" runat="server" />
                                    <asp:HiddenField ID="hfText4" runat="server" />
                <asp:HiddenField ID="hfText3" runat="server" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
