<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="LocalECT.Registration" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Registration</a>
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

                    .table {
                        color: #444444;
                    }
                </style>
                <script>
                    setTimeout(explode, 200);
                    function explode() {
                        var test = document.getElementById('datatable_info').textContent;
                        document.getElementById('lbl_Count').textContent = "(" + test + ")";
                    }
                    $(document).on('keyup', '.dataTables_filter input', function () {
                        var test = document.getElementById('datatable_info').textContent;
                        document.getElementById('lbl_Count').textContent = "(" + test + ")";
                    })
                </script>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-dashboard"></i> Registration</h2>
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
                            <div class="x_panel">
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="sSelectedValue" runat="server" />
    <asp:HiddenField ID="sSelectedText" runat="server" />    
</asp:Content>
