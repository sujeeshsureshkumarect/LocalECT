<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Procurement_LPO_Manager.aspx.cs" Inherits="LocalECT.Procurement_LPO_Manager" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                  <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Procurement /</a>
                        <a href="Procurement_LPO_Manager">&nbsp;LPO Manager</a>

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
                        color:#444444;
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
                                            <h2><i class="fa fa-file-text-o"></i> LPO Manager</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                    <a href="Procurement_LPO_Manager_Create.aspx" class="btn btn-success btn-sm"><i class="glyphicon glyphicon-plus"></i> Create New LPO</a>
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
             <%--                                                           <div class="box-wrapper">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat blue-madison">
                                <div class="visual"><i class="glyphicon glyphicon-globe icon-white"></i></div>
                                <div class="positionchane"><i class="glyphicon glyphicon-cog icon-white"></i></div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lbl_total" runat="server" Text="0"></asp:Label></div>
                                    <div class="desc">Total </div>
                                </div>                               
                                <asp:LinkButton ID="LinkButton8" runat="server" class="more" Style="background: #4D85B7 !important; color: #FFFFFF;" OnClick="LinkButton8_Click" Font-Underline="true">View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>--%>
             <%--       <div class="box-wrapper">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat purple-plum light_blue-clr">
                                <div class="visual"><i class="glyphicon glyphicon-globe icon-white"></i></div>
                                <div class="positionchane"><i class="glyphicon glyphicon-ok icon-white"></i></div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lbl_Active" runat="server" Text="0"></asp:Label></div>
                                    <div class="desc">Active </div>
                                </div>                                
                                <asp:LinkButton ID="LinkButton9" runat="server" class="more" Style="background: #649035 !important; color: #FFFFFF;" OnClick="LinkButton9_Click" Font-Underline="true">View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>--%>  
                     <%--       <div class="box-wrapper">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat red-intense">
                                <div class="visual"><i class="glyphicon glyphicon-globe icon-white"></i></div>
                                <div class="positionchane"><i class="glyphicon glyphicon-remove icon-white"></i></div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lbl_Inactive" runat="server" Text="0"></asp:Label></div>
                                    <div class="desc">Inactive </div>
                                </div>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="more" OnClick="LinkButton3_Click" Font-Underline="true">View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i></asp:LinkButton>                                
                            </div>
                        </div>
                    </div>--%>      
                                            <div class="x_content bs-example-popovers">
                                                         <div class="alert alert-info alert-dismissible " role="alert">
                                                             <strong>
                                                                 <asp:Label runat="server" ID="lbl_Count" ClientIDMode="Static"></asp:Label>
                                                             </strong>
                                                         </div>
                                                     </div>
                                            <hr />
                                        
                                            <div class="clearfix"></div>                                                                
                      <div id="divResult" runat="server" class="table-responsive">
                                     <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                                             <table id='datatable' class='table table-striped table-bordered' style='width: 100%'>
                                                 <thead>
                                                     <tr class='headings'>
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">LPO #</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Ref #</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Requester</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Company</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Perpared By</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Date</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>
                                                 <td><%#Eval("iLPO")%></td>
                                                 <td><%#Eval("sRef")%></td>
                                                 <td><%#Eval("sRequester")%></td>
                                                 <td><%#Eval("Company")%></td>
                                                 <td><%#Eval("sPreparedBy")%></td>
                                                 <td><span style="display: none;"><%#Eval("dDate","{0:yyyyMMdd}")%></span><%#Eval("dDate","{0:dd/MM/yyyy}")%></td>
                                                 <td><a href="Procurement_LPO_Manager_Update.aspx?seqid=<%#Eval("iLPO")%>" class="btn btn-success btn-sm">View / Edit</a>                                                   
                                                 </td>
                                             </tr>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             </table>  
                                         </FooterTemplate>
                                     </asp:Repeater>
                                 </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
     <script>
         var table = document.getElementById("datatable");
         if (table != null) {
             for (var i = 1; i < table.rows.length; i++) {
                 var status = table.rows[i].cells[2].textContent;


                 if (status == "1") {
                     table.rows[i].cells[2].innerHTML = '<span class="badge badge-success">Active</span>';
                 }
                 else if (status == "0") {
                     table.rows[i].cells[2].innerHTML = '<span class="badge badge-danger">Inactive</span>';
                 }                 
             }
         }
     </script>
       <style>
                         .badge {
            font-size: 100%;
        }
                   .alert-info1 {
    color: #fff;
    background-color: #2b9ad6;
    border-color: #268ec5;
}
.dashboard-stat.red-intense {
    background-color: #e35b5a;
}
.dashboard-stat {
    display: block;
    margin-bottom: 25px;
    overflow: hidden;
    -webkit-border-radius: 8px;
    -moz-border-radius: 8px;
    -ms-border-radius: 8px;
    -o-border-radius: 8px;
    border-radius: 8px;
}

.dashboard-stat .visual {
    width: 80px;
    height: 80px;
    display: block;
    float: left;
    padding-top: 10px;
    padding-left: 15px;
    margin-bottom: 15px;
    font-size: 35px;
    line-height: 35px;
}
.dashboard-stat .positionchane {
    width: 80px;
    height: 80px;
    display: block;
    float: left;
    padding-top: 10px;
    padding-left: 15px;
    margin-bottom: 15px;
    font-size: 35px;
    line-height: 35px;
}
.dashboard-stat .details {
    position: absolute;
    right: 15px;
    padding-right: 15px;
    color: #FFFFFF;
}
.dashboard-stat .details .number {
    padding-top: 13px;
    text-align: right;
    line-height: 36px;
    letter-spacing: -1px;
    margin-bottom: 0px;
    font-weight: 300;
    font-size: 26px;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.dashboard-stat .details .desc {
    text-align: right;
    font-size: 16px;
    letter-spacing: 0px;
    font-weight: 300;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.fa1 {
    display: inline-block;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
    font-style: normal;
    font-weight: normal;
    line-height: 1;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}
.dashboard-stat .visual > i {
    margin-left: -35px;
    font-size: 110px;
    line-height: 110px;
}
.dashboard-stat .positionchane > i {
    margin-left: -50px;
    font-size: 40px;
    line-height: 40px;
}
.dashboard-stat.red-intense .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.purple-plum .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.blue-madison .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.red-intense .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.orange_clr {
    background: #EA9852 !important;
}
.dashboard-stat.blue-madison {
    background-color: #578ebe;
}
.dashboard-stat.purple-plum {
    background-color: #73A839;
}
.dashboard-stat.blue-madison .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.purple-plum .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.red-intense .more {
    color: #FFFFFF;
    background-color: #e04a49;
}
.dashboard-stat .more {
    clear: both;
    display: block;
    padding: 6px 10px 6px 10px;
    position: relative;
    text-transform: uppercase;
    font-weight: 300;
    font-size: 11px;
    opacity: 0.7;
    filter: alpha(opacity=70);
}
    </style>
    </asp:Content>