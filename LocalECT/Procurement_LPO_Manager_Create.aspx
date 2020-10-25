<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Procurement_LPO_Manager_Create.aspx.cs" Inherits="LocalECT.Procurement_LPO_Manager_Create" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Procurement /</a>
                        <a href="Procurement_LPO_Manager">&nbsp;LPO Manager /</a>
                        <a href="Procurement_LPO_Manager_Create">&nbsp;Create New LPO</a>
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
                                     .details {
                        /* font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
                        border-collapse: collapse;
                        width: 100%;
                    }

                    td {
                        width: 25%;
                    }

                    .details td, .details th {
                        border: 1px solid #ddd;
                        padding: 5px;
                    }
                    table th{
                        background-color: #2a3f54;
                        font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    color: #ffffff;
   /* border-bottom: white thin solid;*/
    font-family: Arial, Helvetica, sans-serif;
    background-color: #3f658c;
    text-align: center;
    line-height: 2;
    font-size: 13px;
                    }
                    /*#details tr:nth-child(even){background-color: #f2f2f2;}

#details tr:hover {background-color: #ddd;}*/

                    .details th {
                        padding-top: 12px;
                        padding-bottom: 12px;
                        text-align: left;
                        background-color: #4CAF50;
                        color: white;
                    }
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-plus"></i> Create New LPO</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
             <div id="form" align="center">

            <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">
                                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="div_Alert">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <asp:Label ID="lbl_Msg" runat="server" Text="" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                                </div>
                                            </div>

                                <table style="width: 100%">
                                    <tr>
                                        <th style="text-align: left; padding-left: 10px">Issue: 18/08/2011</th>
                                        <th style="text-align: right;">Revision Date: 10/06/2015 </th>
                                        <th style="text-align: right; padding-right: 10px">Form No.: ECT/PRC/F06.01</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Local Purchase Order
                                            </p>
                                        </td>
                                    </tr>
                                </table>

                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Reference # :</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Ref" runat="server" Text="ECT/MR/2020000"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Date : </b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Date" runat="server" Style="text-transform: capitalize;" />                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>BRF : </b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_brf" runat="server" Text="Manual Entry"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>LPO # :</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_lponum" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Department : </b>
                                        </td>
                                        <td align="center">
                                           <asp:DropDownList ID="drp_dept" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_dept" InitialValue="0" ErrorMessage="*Please select a department to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                            
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>To :</b>
                                        </td>
                                        <td align="center">
                                           <asp:DropDownList ID="drp_Supplier" runat="server" CssClass="form-control" OnSelectedIndexChanged="drp_Supplier_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_Supplier" InitialValue="0" ErrorMessage="*Please select a supplier to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>P.O Box : </b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Pobox" runat="server" Style="text-transform: capitalize;" />                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Tel : </b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Tel" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Fax :</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Fax" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr />    

                 <div class="GridviewDiv">
<asp:GridView runat="server" ID="gvDetails" ShowFooter="true" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnRowDeleting="gvDetails_RowDeleting">
<HeaderStyle CssClass="headerstyle" />
<Columns>
<asp:BoundField DataField="rowid" HeaderText="SR No." ReadOnly="true" />
<asp:TemplateField HeaderText="Description">
<ItemTemplate>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control"/>
</ItemTemplate>
    <FooterTemplate>
<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
</FooterTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Qty">
<ItemTemplate>
<asp:TextBox ID="txtQty" runat="server" CssClass="form-control" TextMode="Number" OnTextChanged="txtQty_TextChanged" AutoPostBack="true" Text="0"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText = "Unit Price">
<ItemTemplate>
<asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" OnTextChanged="txtPrice_TextChanged" AutoPostBack="true" Text="0"/>
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Total">
<ItemTemplate>
<asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ReadOnly="true"/>
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="true">

</asp:CommandField>


</Columns>
</asp:GridView>
</div>
       
                 <hr />
                                <asp:LinkButton ID="lnk_Generate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="lnk_Generate_Click"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                  <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success btn-sm"  OnClick="LinkButton1_Click"><i class="fa fa-close"></i> Cancel</asp:LinkButton>
                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
   <style>
       #ContentPlaceHolder1_gvDetails td{
           width:10%;
       }
   </style>
    </asp:Content>