<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search1.ascx.cs" Inherits="LocalECT.Search1" %>
<table  bgcolor="#EFF3FB" style="width:100%;">
    <tr>
        <td>
                                        <asp:Label ID="lbl1" runat="server" Width="100px"></asp:Label>
                                     </td>
        <td>
                                        <asp:TextBox ID="txt1" runat="server" CssClass="form-control"  
                                            ontextchanged="txt1_TextChanged"></asp:TextBox>
                                     </td>
        <td>
                                        <asp:Label ID="lbl2" runat="server" Width="100px"></asp:Label>
                                     </td>
        <td colspan="2">
                                        <asp:TextBox ID="txt2" runat="server" CssClass="form-control"  
                                            ontextchanged="txt2_TextChanged" TabIndex="1"></asp:TextBox>
                                     </td>
    </tr>
    <tr>
        <td>
                                        <asp:Label ID="lbl3" runat="server" Width="100px"></asp:Label>
                                     </td>
        <td>
                                        <asp:TextBox ID="txt3" runat="server" CssClass="form-control"
                                            ontextchanged="txt3_TextChanged" TabIndex="3"></asp:TextBox>
                                     </td>
        <td>
                                        <asp:Label ID="lbl4" runat="server" Width="100px"></asp:Label>
                                     </td>
        <td>
                                        <asp:TextBox ID="txt4" runat="server" CssClass="form-control"  TabIndex="4"></asp:TextBox>
                                     </td>
        <td align="right">
                                        &nbsp;</td>
    </tr>
    <tr>
        <td>
                                        <asp:Label ID="lbl5" runat="server" Width="100px"></asp:Label>
                                     </td>
        <td colspan="3">
                                        <asp:TextBox ID="txt5" runat="server" CssClass="form-control" 
                                            ontextchanged="txt2_TextChanged" TabIndex="1"></asp:TextBox>
                                     </td>
        <td align="left">
                                       <%-- <asp:ImageButton ID="Search1_btn" runat="server" BorderStyle="Solid" 
                                            BorderWidth="1px" ImageUrl="~/Images/Icons/sSearch.bmp" 
                                            onclick="Search1_btn_Click" TabIndex="2" Width="19px" />--%>

             <asp:LinkButton ID="Search1_btn" runat="server" 
                                            OnClick="Search1_btn_Click" TabIndex="2" CssClass="btn btn-success btn-sm"><i class="fa fa-search"></i> Search</asp:LinkButton>
                                     </td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="Clear_LNK" runat="server" onclick="Clear_LNK_Click" 
                TabIndex="6" ForeColor="Blue" Font-Underline="true"><i class="fa fa-search"></i> New 
            Search</asp:LinkButton>
        </td>
        <td colspan="4">
                                         <asp:ListBox ID="Search_lst" runat="server" AutoPostBack="True" 
                                             
                onselectedindexchanged="Search_lst_SelectedIndexChanged" Visible="False" 
                                             Width="500px" ToolTip="Select Result Please" TabIndex="5"></asp:ListBox>
                                     </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td colspan="4">
                                         <asp:HiddenField ID="hdn_Field1" runat="server" />
                                         <asp:HiddenField ID="hdn_Field2" runat="server" />
                                         <asp:HiddenField ID="hdn_Field3" runat="server" />
                                         <asp:HiddenField ID="hdn_Field4" runat="server" />
                                         <asp:HiddenField ID="hdn_Field5" runat="server" />
                                     </td>
    </tr>
</table>
