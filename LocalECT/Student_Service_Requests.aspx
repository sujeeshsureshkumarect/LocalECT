<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Service_Requests.aspx.cs" Inherits="LocalECT.Student_Service_Requests" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Student Service Requests</a>
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
                                     .badge {
            font-size: 100%;
        }
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Student Service Requests <asp:LinkButton ID="lnk_refresh" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_refresh_Click" ToolTip="Refresh"><i class="fa fa-refresh"></i></asp:LinkButton></h2>
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

                                            <div class="clearfix"></div>                                           
                         <div id="datatable_wrapper" class="table-responsive">
                    <style>                      
                        #datatable tbody td div{
width:490px;
max-height:100px !important;
overflow:scroll;
white-space: nowrap;
}

                    </style>
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                <table id="datatable" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Service Name</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending">Detail</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Created on</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Link</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td><%#Eval("ServiceID")%></td>                                                                                                         
                                                    <td><%#Eval("Status")%></td>                                                                                                        
                                                    <td><span style="display: none;"><%#Eval("Created","{0:yyyyMMdd}")%></span><%#Eval("Created","{0:dd/MM/yyyy hh:mm tt}")%></td>
                                                    <td><a class="btn btn-success btn-sm" href="https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices/Lists/Students_Requests/EditForm.aspx?ID=<%#Eval("ID")%>" target="_blank">Link to Item</a></td>
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
                                         <script>
       var table = document.getElementById("datatable");
       if (table != null) {
           for (var i = 1; i < table.rows.length; i++) {              
               var status = table.rows[i].cells[2].textContent;               
               if (status == "Completed") {
                   table.rows[i].cells[2].innerHTML = '<span class="badge badge-success">Completed</span>';
               }                 
           }
       }
                                         </script>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>