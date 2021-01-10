<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassAttendance.aspx.cs" Inherits="LocalECT.ClassAttendance" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Classes /</a>
                        <a href="ClassAttendance">&nbsp;Classes Attendance</a>

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
                                            <h2><i class="fa fa-dashboard"></i> Classes Attendance</h2>
                                            <ul class="nav navbar-right panel_toolbox">
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

                                            <div class="x_panel">
                                                <div class="col-md-12 col-sm-12">
                                                     
                                                          <div class="col-md-6 col-sm-6" id="terms1" runat="server">
                                            <div class="form-group">
                                                <label>Term</label>
                                                <div class="input-group">
                                                   <asp:DropDownList ID="Terms" runat="server"
                    style="margin-left: 0px" AutoPostBack="True" 
                    onselectedindexchanged="Terms_SelectedIndexChanged" CssClass="form-control" 
                                >
            </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                                          <div class="col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label>Lecturer</label>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="LecturersCBO" runat="server" AutoPostBack="True" 
                    CssClass="form-control">
                </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                                          <div class="col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label>Campus</label>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="CampusCBO" runat="server" AutoPostBack="True" 
                    CssClass="form-control" 
                    onselectedindexchanged="CampusCBO_SelectedIndexChanged">
                </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                                        
                                                </div>
                                            </div>

                                             <div class="x_panel">

                                                 <asp:GridView ID="ClassesGRD" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="ClassesDS" Width="100%" 
                    onselectedindexchanged="ClassesGRD_SelectedIndexChanged">
                    <Columns>
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
                        <asp:TemplateField HeaderText="Action" SortExpression="Lecturer">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Lecturer") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="SelectBTN" runat="server" 
                                    CommandArgument='<%# Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass") %>' 
                                    oncommand="SelectBTN_Command" ForeColor="Blue" Font-Underline="true">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Summary">
                            <ItemTemplate>
                                <asp:LinkButton ID="ShowBTN" runat="server" 
                                    CommandArgument='<%# Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass") %>' 
                                    oncommand="ShowBTN_Command" ForeColor="Blue" Font-Underline="true">Show</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="List">
                            <ItemTemplate>
                                <asp:LinkButton ID="ListBTN" runat="server" 
                                    CommandArgument='<%# Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass") %>' 
                                    oncommand="ListBTN_Command" ForeColor="Blue" Font-Underline="true">List</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="QR Code">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgQrCode" runat="server" BorderColor="#0066FF" 
                                    BorderStyle="Solid" BorderWidth="1px" 
                                    CommandArgument='<%# Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass") %>' 
                                    Height="35px" ImageUrl="~/Images/Icons/QRIcon.png" 
                                    oncommand="imgQrCode_Command" Width="35px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                                                  <asp:ObjectDataSource ID="ClassesDS" runat="server" SelectMethod="GetClasses" 
        TypeName="ClassesDAL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CampusCBO" DefaultValue="1" Name="Campus" 
                PropertyName="SelectedValue" Type="Object" />
            <asp:ControlParameter ControlID="LecturersCBO" DefaultValue="0" 
                Name="Condition" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="iYear" DefaultValue="" Name="iYear" 
                PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="iSemester" Name="bSemester" 
                PropertyName="Value" Type="Byte" />
        </SelectParameters>
    </asp:ObjectDataSource>


                                                 </div>

                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
         <br />
    <br />
    <br />
    <div style="text-align: center; vertical-align: middle" >
        <asp:PlaceHolder ID="phQr" runat="server"></asp:PlaceHolder>
    </div>
                    </div>
     <asp:HiddenField ID="iSemester" runat="server" />                                                                                                                                                      
  <asp:HiddenField ID="iYear" runat="server" />
    </asp:Content>