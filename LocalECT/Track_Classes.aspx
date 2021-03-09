<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Track_Classes.aspx.cs" Inherits="LocalECT.Track_Classes" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <%--<h3>Welcome To Emirates College Of Technology (ECT)</h3>--%>
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
                                            <h2><i class="fa fa-dashboard"></i> Classes Discipline</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                             <table style="width:100%;">
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4">
                <div id="divMsg" runat="server" class="NoData"></div>
            </td>
        </tr>
        <%--<tr>
            <th class="PageTitle" colspan="4">Classes Discipline</th>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Term :"></asp:Label>
            </td>
            <td>
                                         <asp:DropDownList ID="Term_ddl" runat="server" 
                   CssClass="form-control" AutoPostBack="True" Enabled="False" 
                                             onselectedindexchanged="Term_ddl_SelectedIndexChanged">
                                         </asp:DropDownList>
                        </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Campus :"></asp:Label>
                        </td>
            <td>
                <asp:DropDownList ID="CampusCBO" runat="server" AutoPostBack="True" 
                    CssClass="form-control" >
                </asp:DropDownList>
                        </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Lecturer :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="LecturersCBO" runat="server" AutoPostBack="True" 
                    CssClass="form-control">
                </asp:DropDownList>
                        </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="ClassesGRD" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="ClassesDS" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="*" SortExpression="Lecturer">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Lecturer") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="SelectBTN" runat="server" 
                                    CommandArgument='<%# Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass") %>' 
                                    oncommand="SelectBTN_Command" Font-Underline="true" ForeColor="Blue">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Shortcut" HeaderText="Period" 
                            SortExpression="Shortcut" />
                        <asp:BoundField DataField="Course" HeaderText="Course" 
                            SortExpression="Course" />
                        <asp:BoundField DataField="AttClass" HeaderText="Section No" 
                            SortExpression="AttClass" />
                        <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                        <asp:BoundField DataField="TimeFrom" HeaderText="From" 
                            SortExpression="TimeFrom" />
                        <asp:BoundField DataField="TimeTo" HeaderText="To" SortExpression="TimeTo" />
                        <asp:BoundField DataField="Days" HeaderText="Days" SortExpression="Days" />
                    </Columns>
                </asp:GridView>
                
            </td>
        </tr>
        <tr>
            <td colspan="4">
    <asp:ObjectDataSource ID="ClassesDS" runat="server" SelectMethod="GetClasses" 
        TypeName="ClassesDAL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CampusCBO" DefaultValue="1" Name="Campus" 
                PropertyName="SelectedValue" Type="Object" />
            <asp:ControlParameter ControlID="LecturersCBO" DefaultValue="" 
                Name="iLecturer" PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="iYear" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="bSemester" Type="Byte" />
        </SelectParameters>
    </asp:ObjectDataSource>
            </td>
            
        </tr>
        
    </table>
            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>