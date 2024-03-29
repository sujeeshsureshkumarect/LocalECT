﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Link_Manager_Home.aspx.cs" Inherits="LocalECT.Link_Manager_Home" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                     <h3><i class="fa fa-globe"></i> Link Manager</h3>
                                </div>
                                <style>
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
                                            <h2><i class="fa fa-dashboard"></i> Management Console</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           <div class="box-wrapper">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat blue-madison">
                                <div class="visual"><i class="glyphicon glyphicon-globe icon-white"></i></div>
                                <div class="positionchane"><i class="glyphicon glyphicon-cog icon-white"></i></div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lbl_total" runat="server" Text="0"></asp:Label></div>
                                    <div class="desc">Total </div>
                                </div>
                                <%--<a class="more" style=" background:#4D85B7 !important;color: #FFFFFF;" href="javascript:void(0);"> View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i> </a> --%>
                                <asp:LinkButton ID="LinkButton8" runat="server" class="more" Style="background: #4D85B7 !important; color: #FFFFFF;" OnClick="LinkButton8_Click" Font-Underline="true">View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="box-wrapper">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat purple-plum light_blue-clr">
                                <div class="visual"><i class="glyphicon glyphicon-globe icon-white"></i></div>
                                <div class="positionchane"><i class="glyphicon glyphicon-ok icon-white"></i></div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lbl_Active" runat="server" Text="0"></asp:Label></div>
                                    <div class="desc">Active </div>
                                </div>
                                <%-- <a class="more" style=" background:#7B6A9A !important;color: #FFFFFF;" href="javascript:void(0);"> View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i> </a> --%>
                                <asp:LinkButton ID="LinkButton9" runat="server" class="more" Style="background: #649035 !important; color: #FFFFFF;" OnClick="LinkButton9_Click" Font-Underline="true">View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>  
                            <div class="box-wrapper">
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
                                <%-- <a class="more" href="javascript:void(0);"> View More <i class="glyphicon glyphicon-circle-arrow-right" style="font-size:12px"></i> </a>--%>
                            </div>
                        </div>
                    </div>           
                                            <a href="Link_Manager_Create.aspx" style="float:right;" class="btn btn-success btn-sm"><i class="glyphicon glyphicon-plus"></i> Create New Link</a>
                                            <div class="clearfix"></div>
                                             
                   <hr />

                                                      <link rel="stylesheet" type="text/css" href="SearchBuilder/jquery.dataTables.min.css">
                                        <link rel="stylesheet" type="text/css" href="SearchBuilder/searchBuilder.dataTables.min.css">
                                        <link rel="stylesheet" type="text/css" href="SearchBuilder/dataTables.dateTime.min.css">
                                        <link rel="stylesheet" type="text/css" href="SearchBuilder/buttons.dataTables.min.css">

                                        <script type="text/javascript" src="SearchBuilder/jquery-3.5.1.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/jquery.dataTables.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/dataTables.searchBuilder.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/dataTables.dateTime.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/dataTables.buttons.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/jszip.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/pdfmake.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/vfs_fonts.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/buttons.print.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/buttons.html5.min.js"></script>

                                            <script>
                                                $.noConflict();  //Release the $ variable
                                                jQuery(document).ready(function ($) {
                                                    $('#example').DataTable({
                                                        language: {
                                                            searchBuilder: {
                                                                title: {
                                                                    0: 'Search Builder',
                                                                    _: 'Search Builder (%d)'
                                                                }
                                                            }
                                                        },
                                                        dom: 'QlBfrtip',
                                                        buttons: [
                                                            'csv', 'excel', 'print'
                                                        ]
                                                    });
                                                });
    //$(document).ready(function () {
    //    $('#example').DataTable({
    //        dom: 'Qlfrtip',
    //        searchBuilder: {
    //            logic: 'OR'
    //        }
    //    });
    //});
                                            </script>
                                        <style>
                                            div.dtsb-searchBuilder button.dtsb-button{
                                                font-size:12px !important;
                                            }
                                        </style>

                         <div id="datatable_wrapper" class="table-responsive">
                     
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                <table id="example" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Description</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Short Link</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending">Detail</th>--%>                                            
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="max-width:140px !important;">URL</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Expiry</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Active</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Source</th>  
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Language</th>  
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Medium</th>  
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Action</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added By</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added Date</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                     <td><%#Eval("sDesc")%></td>
                                                    <td><a href="https://dt.ect.ac.ae/l?q=<%#Eval("sCode")%>" target="_blank" style="color:blue"><u>https://dt.ect.ac.ae/l?q=<%#Eval("sCode")%></u></a></td>
                                                    <td style="max-width:140px !important;text-overflow:ellipsis;white-space: nowrap;overflow: hidden;" title=<%#Eval("sURL")%>><a href="<%#Eval("sURL")%>" target="_blank" style="color:blue"><u><%#Eval("sURL")%></u></a></td>
                                                     <td><%#Eval("dExpiry","{0:yyyy-MM-dd}")%></td>
                                                    <td><%#Eval("isActive")%></td>
                                                    <td><%#Eval("sSource")%></td>   
                                                    <td><%#Eval("sTargetLanguage")%></td>
                                                    <td><%#Eval("sMedium")%></td>
                                                     <td>
                                                    <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">
                                                             <a class="dropdown-item copy_text" href="https://dt.ect.ac.ae/l?q=<%#Eval("sCode")%>" data-toggle="tooltip" title="Copy to Clipboard">Copy Link</a>
                                                             <a href="Link_Manager_Update.aspx?id=<%#Eval("iLink")%>" class="dropdown-item">Edit</a>
                                                             <a class="dropdown-item" href="Link_Manager_Analysis.aspx?id=<%#Eval("iLink")%>">Analysis</a>                                                          
                                                         </div>
                                                     </div>
                                                   </td>
                                                    <td><%#Eval("sAddedby")%></td>
                                                    <td><%#Eval("dAdded","{0:yyyy-MM-dd}")%></td>
                                                </tr>
                                        
                                   </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>                          
                            </div>
                        </div>
                             <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
                  <script>
                      $('.copy_text').click(function (e) {
                          e.preventDefault();
                          var copyText = $(this).attr('href');

                          document.addEventListener('copy', function (e) {
                              e.clipboardData.setData('text/plain', copyText);
                              e.preventDefault();
                          }, true);

                          document.execCommand('copy');
                          console.log('copied text : ', copyText);
                          alert('Text Copied to Clipboard \r\nCopied text: ' + copyText);
                      });
                  </script>
                    </div>
                        </div>

                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
       <script>
           var table = document.getElementById("example");
       if (table != null) {
           for (var i = 1; i < table.rows.length; i++) {
               //var link = table.rows[i].cells[3].textContent;
               //var attachment = table.rows[i].cells[4].textContent;
               var status = table.rows[i].cells[5].textContent;


               //if (link == "") {
               //    table.rows[i].cells[3].innerHTML = '';
               //}
               //else {
               //    table.rows[i].cells[3].innerHTML = '<a href=' + link +' target="_blank"><i class="fa fa-globe"></i> <u>View</u></a>';
               //}  
               //if (attachment == "") {
               //    table.rows[i].cells[4].innerHTML = '';
               //}
               //else {
               //    table.rows[i].cells[4].innerHTML = '<a href=' + attachment + ' target="_blank"><i class="fa fa-paperclip"></i> <u>View</u></a>';
               //} 
               if (status == "True") {
                   table.rows[i].cells[5].innerHTML = '<span class="badge badge-success">Active</span>';
               }
               else if (status == "False") {
                   table.rows[i].cells[5].innerHTML = '<span class="badge badge-danger">Inactive</span>';
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