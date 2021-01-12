<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradesEntry.aspx.cs" Inherits="LocalECT.GradesEntry" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Classes /</a>
                        <a href="GradesEntry">&nbsp;Classes Grades</a>

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
                                            <h2><i class="fa fa-dashboard"></i> Classes Grades</h2>
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
                                                <label>Instructor</label>
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
                    DataSourceID="ClassesDS" Width="100%">
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
                        <asp:TemplateField HeaderText="?" SortExpression="Lecturer">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Lecturer") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="SelectBTN" runat="server" 
                                    CommandArgument='<%# Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass") %>' 
                                    oncommand="SelectBTN_Command" ForeColor="Blue" Font-Underline="true">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
<br />
                                                 <br />
                                                  <div id="divDetail" runat="server">
                </div>

                                                 <asp:ObjectDataSource ID="ClassesDS" runat="server" SelectMethod="GetClasses" 
        TypeName="ClassesDAL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CampusCBO" DefaultValue="1" Name="Campus" 
                PropertyName="SelectedValue" Type="Object" />
            <asp:ControlParameter ControlID="LecturersCBO" DefaultValue="" 
                Name="iLecturer" PropertyName="SelectedValue" Type="Int32" />
            <asp:SessionParameter Name="iYear" SessionField="CurrentYear" Type="Int32" />
            <asp:SessionParameter Name="bSemester" SessionField="CurrentSemester" 
                Type="Byte" />
        </SelectParameters>
    </asp:ObjectDataSource>



                                                 </div>

            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>