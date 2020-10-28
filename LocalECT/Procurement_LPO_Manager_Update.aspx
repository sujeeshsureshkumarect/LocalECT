<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Procurement_LPO_Manager_Update.aspx.cs" Inherits="LocalECT.Procurement_LPO_Manager_Update" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Procurement /</a>
                        <a href="Procurement_LPO_Manager">&nbsp;LPO Manager /</a>
                        <a href="#">&nbsp;Update LPO</a>
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
                                            <h2><i class="fa fa-edit"></i> Update LPO</h2>
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
                 <style>
                     #tbl_Pricing td{
                         width:10% !important;
                         border:1px solid #ededed;
                     }
                     #tbl_Pricing th{                         
                         border:1px solid #ededed;
                     }
                 </style>
                 <div class="col-md-9 col-sm-9">
                 <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                          <table style="width: 100%;border:1px solid #ededed;text-align:center;" id="tbl_Pricing">
                               <thead>
                                    <tr>
                                        <th style="width:5% !important"><font color="#fff">SR No.</font></th>
                                        <th style="width:30% !important"><font color="#fff">Description</font></th>
                                        <th><font color="#fff">Qty</font></th>
                                        <th><font color="#fff">Unit Price</font></th>
                                        <th><font color="#fff">Total</font></th> 
                                        <th><font color="#fff">Action</font></th>
                                        <th style="width:9% !important"><font color="#fff"></font></th>    
                                    </tr>
                                   </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                    <tr class="row<%# Container.ItemIndex+1 %> <%#Eval("add")%>">   
                                        <td style="width:5% !important"><asp:Label ID="lbl_srno" runat="server" Text="<%# Container.ItemIndex+1 %>" ClientIDMode="Static"></asp:Label> </td>                                           
                                        <td style="width:30% !important"><asp:TextBox ID="txt_desc" runat="server" CssClass="form-control" ClientIDMode="Static" EnableViewState="false" Text=<%#Eval("sDescription")%>></asp:TextBox></td>                                      
                                        <td><asp:TextBox ID="txt_qty" class="product" runat="server" CssClass="form-control" TextMode="Number" ClientIDMode="Static" Text='<%#string.Format("{0:0.00}",Eval("cQTY")) %>'  style="text-align:center;" ></asp:TextBox></td>
                                        <td><asp:TextBox ID="txt_up" class="product" runat="server" CssClass="form-control" TextMode="Number" ClientIDMode="Static" Text='<%#string.Format("{0:0.00}",Eval("cUnitPrice")) %>' style="text-align:center;" EnableViewState="false"></asp:TextBox></td>
                                        <td><asp:TextBox ID="txt_total" runat="server" CssClass="form-control" ClientIDMode="Static" Text='<%#string.Format("{0:0.00}",Eval("Total")) %>' TextMode="Number" ReadOnly="true" style="text-align:center;" EnableViewState="false"></asp:TextBox></td>                                     
                                        <td style="width:5% !important"> <asp:LinkButton ID="lnk_Delete" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%#Eval("iSerial")%>' CommandName='<%#Eval("iLPO")%>' oncommand="DeleteBTN_Command" OnClientClick="return confirm('Are you sure you want to delete?'); "><i class="fa fa-trash"></i> Delete</asp:LinkButton></td>
                                         <td style="width:9% !important">
                                            <%--<p class="<%#Eval("add1")%>" onclick="toggleRow(this);"><u>+ Add</u></p>--%>
                                              <p class="<%#Eval("add1")%> btn btn-success btn-sm" onclick="toggleRow(this);"><i class="fa fa-plus"></i> Add</p>
                                        </td>
                                    </tr>
                                             </ItemTemplate>
                                         <FooterTemplate>
                                  <tr class="footer">
                                        <td bgcolor="#f2f2f2"><font color="#444444"><b>Total</b></font></td>                                        
                                        <td bgcolor="#f2f2f2"></td>
                                        <td bgcolor="#f2f2f2"> </td>
                                        <td bgcolor="#f2f2f2"></td>
                                        <td bgcolor="#f2f2f2"><asp:Label ID="total1" ClientIDMode="Static" runat="server" Font-Bold="true" ForeColor="#444444"></asp:Label></td>                                       
                                        <td bgcolor="#f2f2f2"></td>
                                      <td bgcolor="#f2f2f2" style="width:9% !important"></td>
                                    </tr>
                              </table>  
                                         </FooterTemplate>
                                     </asp:Repeater>
                     </div>
                 <div class="col-md-3 col-sm-3">
                      <div class="x_panel">
                     <h2><u>Terms & Conditions :</u></h2>
                     <div class="form-group row">
                         <label>Invoice</label>
                         <asp:TextBox ID="txt_Invoice" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="form-group row">
                         <label>Payment</label>
                         <asp:TextBox ID="txt_Payment" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="form-group row">
                         <label>Other Terms</label>
                         <asp:TextBox ID="txt_other" runat="server" CssClass="form-control" TextMode="MultiLine" Height="70px"></asp:TextBox>
                     </div>


                     <asp:LinkButton ID="lnk_Generate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="lnk_Generate_Click"><i class="fa fa-floppy-o"></i> Update</asp:LinkButton>
                     <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success btn-sm" OnClick="LinkButton1_Click"><i class="fa fa-close"></i> Cancel</asp:LinkButton>
                 </div>
                      </div>
             </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
   <style>
       .hide{
           display:none;
       }  
       .btn {    
    border: 1px solid #dddddd;
}
       .button {
  transition-duration: 0.4s;
}

.btn-default:hover {
  border: 1px solid #000000;
  background-color: #f91414; /* Crimson Red */
  color: white;
}
   </style>
     <script type="text/javascript">
         function toggleRow(e) {
             var subRow = e.parentNode.parentNode.nextElementSibling;
             //subRow.style.display = subRow.style.display === 'none' ? 'table-row' : 'none';
             subRow.style.display = 'table-row';
         }
     </script>
  <%--      <script type="text/javascript">

     function GetTotalAmount(obj){
         var txtbox1id = obj.id.replace('txt_up','txt_qty');
         var txtbox2id = obj.id.replace('txt_qty','txt_up');
         var txtbox3id = obj.id.replace('txt_qty', 'txt_total').replace('txt_up','txt_total');
            var total =parseFloat($('#'+ txtbox1id).val()) * parseFloat($('#'+txtbox2id).val());
            $('#' + txtbox3id).val(total);
           }


      $(document).ready(function() {
          $("input[id*=txt_qty]").each(function() {
            $(this).change(function() {
              GetTotalAmount(this);
            });
          });

          $("input[id*=txt_up]").each(function() {
            $(this).change(function() {
              GetTotalAmount(this);
            });
          });

    });

        </script>--%>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    $("[id*=txt_qty]").val("0");
        //    $("[id*=txt_up]").val("0");
        //});
        $("body").on("change keyup", "[id*=txt_qty]", function () {
            //Check whether Quantity value is valid Float number.            
            var quantity = $.trim($(this).val());
            if (isNaN(quantity)) {
                quantity = 0;
            }
            //Update the Quantity TextBox.
            $(this).val(quantity);

            //Calculate and update Row Total.
            var row = $(this).closest("tr"); 

            //var up = parseFloat($("[id*=txt_up]", row).val());
            //if (isNaN(up)) {
            //    up = 0;
            //}
            //alert(up);
            $("[id*=txt_total]", row).val(parseFloat($("[id*=txt_up]", row).val()) * parseFloat($(this).val()));

            //Calculate and update Grand Total.
            var grandTotal = 0;
            $("[id*=txt_total]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).val());
            });
            $("[id*=total1]").html(grandTotal.toString());
        });
        $("body").on("change keyup", "[id*=txt_up]", function () {
            //Check whether Quantity value is valid Float number.            
            var up = $.trim($(this).val());
            if (isNaN(up)) {
                up = 0;
            }
            //Update the Quantity TextBox.
            $(this).val(up);

            //Calculate and update Row Total.
            var row = $(this).closest("tr");

            //var up = parseFloat($("[id*=txt_up]", row).val());
            //if (isNaN(up)) {
            //    up = 0;
            //}
            //alert(up);
            $("[id*=txt_total]", row).val(parseFloat($("[id*=txt_qty]", row).val()) * parseFloat($(this).val()));

            //Calculate and update Grand Total.
            var grandTotal = 0;
            $("[id*=txt_total]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).val());
            });
            $("[id*=total1]").html(grandTotal.toString());
        });
    </script>
    </asp:Content>