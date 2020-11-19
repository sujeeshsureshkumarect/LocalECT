<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="LocalECT.Registration" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="Includes/jQuery/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#divConfirmation").hide();
        });
        function DropConfirm() {
            var b = confirm('Are you sure ?');
            return b;
        }

    </script> 
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                    table{
                        border: 1px solid #dee2e6
                    }
                    caption {
    padding-top: .75rem !important;
    padding-bottom: .75rem !important;
    /*color: #6c757d !important;*/
     text-align: center !important; 
     caption-side: top !important;
     font-weight:bold;
     background:#3f658c;
     color:white;
}
                  #ContentPlaceHolder1_tblDetail  th, td {
  padding-bottom: 7px;
  padding-top: 7px;
}
                </style>
                 <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
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
                            <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">
                                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="div_Alert">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <asp:Label ID="lbl_Msg" runat="server" Text="" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                                </div>
                                            </div>
                            <div class="x_panel">
                                
                                
                                 <div class="form-group row">
                                     <label class="col-form-label col-md-1 col-sm-1 ">Term</label>
                                    <div class="col-md-2 col-sm-2 ">
                                        <asp:DropDownList ID="Terms" runat="server" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="Terms_SelectedIndexChanged" CssClass="form-control" 
                               >
            </asp:DropDownList>
                                        </div>
                                    <div class="col-md-6 col-sm-6 ">
                                         <asp:Button ID="btnCopy" runat="server"   
                        onclick="btnCopy_Click" 
                        Text="Register Student in Males" CssClass="btn btn-success btn-sm" />
                                    </div>
                                </div>
                                <hr />
                                <div id="Loading" runat="server"
                                    style="vertical-align: middle; text-align: center">

                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>

                                            <asp:Image ID="LoadingIMG" runat="server" ImageAlign="Middle"
                                                ImageUrl="~/Images/ajax-loader.gif" Width="150px" />

                                        </ProgressTemplate>
                                    </asp:UpdateProgress>

                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>
                                        <div id="divTabs" runat="server">

                                            <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick"
                                                Orientation="Horizontal" BackColor="#ededed" DynamicHorizontalOffset="2"
                                                            Font-Bold="True" ForeColor="#284E98"
                                                            StaticSubMenuIndent="10px" Width="100%" >
                                                            <StaticSelectedStyle BackColor="#3f658c" ForeColor="White" />
                                                            <StaticMenuItemStyle HorizontalPadding="7px" VerticalPadding="7px" />
                                                            <DynamicHoverStyle BackColor="#3f658c" ForeColor="White" />
                                                            <DynamicMenuStyle BackColor="#B5C7DE" />
                                                            <DynamicSelectedStyle BackColor="#3f658c" ForeColor="White" />
                                                            <DynamicMenuItemStyle HorizontalPadding="7px" VerticalPadding="7px" />
                                                            <StaticHoverStyle BackColor="#3f658c" ForeColor="White" />
                                                <Items>
                                                    <asp:MenuItem Text="Acedemic Information" Value="0"></asp:MenuItem>
                                                    <asp:MenuItem Text=" | Advising" Value="1"></asp:MenuItem>
                                                    <asp:MenuItem Text=" | Time Table" Value="2"></asp:MenuItem>
                                                </Items>
                                            </asp:Menu>


                                        </div>

                                        <asp:MultiView ID="MultiTabs" runat="server">
                                            <asp:View ID="View1" runat="server">
                                                <hr />
                                                <div id="divPlan" runat="server">
                                                </div>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <hr />
                                               <%-- <table width="100%">
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>--%>
                                                            <div id="divRec" runat="server">
                                                        <%--</td>
                                                    </tr>
                                                </table>--%>
                                                </div>
                                            </asp:View>
                                            <asp:View ID="View3" runat="server">
                                                <hr />
                                                   <div class="form-group row">
                                     <label class="col-form-label col-md-1 col-sm-1 ">Course</label>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:TextBox ID="txtCourse" runat="server" AutoPostBack="True" CssClass="form-control" Width="250px"></asp:TextBox>
                                        </div>
                                    <div class="col-md-6 col-sm-6 ">
                                          <asp:LinkButton ID="crsSearch" runat="server" CssClass="btn btn-success btn-sm"
                                                    OnClick="crsSearch_Click"><i class="fa fa-search"></i> Search</asp:LinkButton>
                                    </div>
                                </div>


                                               
                                               
                                            </asp:View>

                                        </asp:MultiView>

                                        <asp:MultiView ID="MultiAdd" runat="server">
                                            <asp:View ID="View4" runat="server">
                                                <table width=100% align="center">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdCourses" runat="server" AutoGenerateColumns="False"
                                                                Caption="Available Courses" CaptionAlign="Top" CellPadding="4"
                                                                DataSourceID="CTMDS" ForeColor="#333333" GridLines="None"
                                                                Width="100%">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle BackColor="#ededed"/>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="?">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="Addbtn" runat="server"
                                                                                CommandArgument='<%# Eval("byteShift") + ";" + Eval("Course")+ ";" + Eval("Class") %>'
                                                                                OnCommand="Addbtn_Command" CssClass="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Session" HeaderText="Session"
                                                                        SortExpression="Session" />
                                                                    <asp:BoundField DataField="Course" HeaderText="Course"
                                                                        SortExpression="Course" />
                                                                    <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
                                                                    <asp:BoundField DataField="Lecturer" HeaderText="Lecturer"
                                                                        SortExpression="Lecturer" />
                                                                    <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}"
                                                                        HeaderText="TimeFrom" SortExpression="TimeFrom" />
                                                                    <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}"
                                                                        HeaderText="TimeTo" SortExpression="TimeTo" />
                                                                    <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image2" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Sun")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Sun") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image3" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Mon")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Mon") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image4" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Tus")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Tus") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image5" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Wed")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Wed") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image6" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Thu")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Thu") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image7" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Fri")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Fri") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sat" SortExpression="Sat">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image8" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Sat")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Sat") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                    <asp:BoundField DataField="RegCapacity" HeaderText="C" />
                                                                    <asp:BoundField DataField="MaxSeats" HeaderText="M" />
                                                                </Columns>
                                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle BorderStyle="None" Font-Bold="True" ForeColor="White"
                                                                    HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                                <EditRowStyle BackColor="#2461BF" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="divConfirmation" runat="server" class="Confirm" style="width: 100%"></div>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdTimeTable" runat="server" AutoGenerateColumns="False"
                                                                CellPadding="4" DataSourceID="TMDS" ForeColor="#333333" GridLines="None"
                                                                Width="100%" Caption="Registered Courses" CaptionAlign="Top">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle BackColor="#ededed"/>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="?">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="Dropbtn" runat="server"
                                                                                CommandArgument='<%# Eval("iSession") + ";" + Eval("Course")+ ";" + Eval("Class") %>'
                                                                                OnCommand="Dropbtn_Command" OnClientClick="return DropConfirm();" CssClass="btn btn-danger btn-sm"><i class="fa fa-trash"></i> Drop</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("iYear") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Session" HeaderText="Session"
                                                                        SortExpression="Session" />
                                                                    <asp:BoundField DataField="Course" HeaderText="Course"
                                                                        SortExpression="Course" />
                                                                    <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
                                                                    <asp:BoundField DataField="Lecturer" HeaderText="Lecturer"
                                                                        SortExpression="Lecturer" />
                                                                    <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}"
                                                                        HeaderText="TimeFrom" SortExpression="TimeFrom" />
                                                                    <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}"
                                                                        HeaderText="TimeTo" SortExpression="TimeTo" />
                                                                    <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image1" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Sun")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Sun") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image2" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Mon")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Mon") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image3" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Tus")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Tus") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image4" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Wed")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Wed") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image5" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Thu")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Thu") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image6" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Fri")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Fri") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sat" SortExpression="Sat">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image7" runat="server" Height="20px"
                                                                                ImageUrl="~/Images/Icons/Correct.gif"
                                                                                Visible='<%# Convert.ToBoolean(Eval("Sat")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Sat") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                    <asp:BoundField DataField="sAL" HeaderText="AL" />
                                                                </Columns>
                                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                                    VerticalAlign="Middle" Wrap="True" />
                                                                <EditRowStyle BackColor="#2461BF" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                            </asp:GridView>


                                                        </td>
                                                    </tr>
                                                </table>

                                            </asp:View>
                                            <asp:View ID="View5" runat="server">
                                                <div id="divAddContainer" runat="server" style="border: thin solid #ededed; background-color: #f7f7f7; vertical-align: middle; text-align: center;">
                                                    <table style="width:100%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <div id="divAdd" runat="server"
                                                                    style="background-color: #3f658c; vertical-align: middle; text-align: center; width: 100%;color:#ffffff;font-weight:bold;">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Button ID="Proceedbtn" runat="server" OnClick="Proceedbtn_Click"
                                                                    Text="Proceed" CssClass="btn btn-success btn-sm" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:Button ID="Cancelbtn" runat="server" OnClick="Cancelbtn_Click"
                                                                    Text="Cancel" CssClass="btn btn-danger btn-sm"/>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Label ID="Label3" runat="server" Text="As : "></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:DropDownList ID="ddlAlt" runat="server" Width="150px"
                                                                    ToolTip="Use it to set an alternative to" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </asp:View>
                                        </asp:MultiView>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <hr />
                                <div align="middle">
                                      <asp:LinkButton ID="Print_CMD" runat="server"
                                     OnClick="PrintCMD_Click"
                                    CssClass="btn btn-success btn-sm"
                                    ToolTip="Print as PDF" ><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>
                                </div>
                              





                                <asp:SqlDataSource ID="CTMDS" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>"
                                    SelectCommand="SELECT TT.byteShift, P.strShiftEn AS Session, TT.strCourse AS Course, TT.byteClass AS Class, TT.Lecturer, TT.TimeFrom, TT.TimeTo, TT.Sun, TT.Mon, TT.Tus, TT.Wed, TT.Thu, TT.Fri, TT.Sat, TT.Hall, ISNULL(CC.RegCapacity, 0) AS RegCapacity, CONVERT (int, FLOOR(TT.intMaxSeats * TT.cSharedFactor)) AS MaxSeats FROM Reg_Shifts AS P INNER JOIN Time_Table_Times AS TT ON P.byteShift = TT.byteShift INNER JOIN Reg_Courses AS C ON TT.strCourse = C.strCourse LEFT OUTER JOIN ClassCapacity AS CC ON TT.intStudyYear = CC.iYear AND TT.byteSemester = CC.Sem AND TT.byteShift = CC.Shift AND TT.strCourse = CC.Course AND TT.byteClass = CC.Class WHERE (TT.strCourse LIKE N'%' + @Course + N'%') AND (TT.intStudyYear = @iYear) AND (TT.byteSemester = @iSem) AND (TT.byteShift &lt;&gt; 11) AND (TT.byteClass &lt; 100) ORDER BY Course, TT.byteShift, Class, TT.TimeFrom">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtCourse" DefaultValue="-" Name="Course"
                                            PropertyName="Text" />
                                        <asp:SessionParameter DefaultValue="2013" Name="iYear" SessionField="RegYear" />
                                        <asp:SessionParameter DefaultValue="2" Name="iSem" SessionField="RegSemester" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

                                <asp:SqlDataSource ID="TMDS" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>"
                                    SelectCommand="SELECT P.strShiftEn AS Session, TT.strCourse AS Course, TT.byteClass AS Class, TT.Lecturer, TT.TimeFrom, TT.TimeTo, TT.Sun, TT.Mon, TT.Tus, TT.Wed, TT.Thu, TT.Fri, TT.Sat, TT.Hall, CB.Shift AS iSession, AL.strAlternativeTo AS sAL FROM Course_Balance_View AS CB INNER JOIN Time_Table_Times AS TT ON CB.Shift = TT.byteShift AND CB.Course = TT.strCourse AND CB.Class = TT.byteClass AND CB.iYear = TT.intStudyYear AND CB.Sem = TT.byteSemester INNER JOIN Reg_Shifts AS P ON TT.byteShift = P.byteShift LEFT OUTER JOIN Reg_Course_Alternative AS AL ON CB.iYear = AL.intStudyYear AND CB.Sem = AL.byteSemester AND CB.Student = AL.lngStudentNumber AND CB.Course = AL.strAlternative WHERE (CB.Student = @Student) AND (CB.iYear = @iYear) AND (CB.Sem = @iSem) ORDER BY Course, TT.TimeFrom">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="sSelectedValue" DefaultValue="-"
                                            Name="Student" PropertyName="Value" />
                                        <asp:SessionParameter DefaultValue="2013" Name="iYear" SessionField="RegYear" />
                                        <asp:SessionParameter DefaultValue="2" Name="iSem" SessionField="RegSemester" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="sSelectedValue" runat="server" />
    <asp:HiddenField ID="sSelectedText" runat="server" />
    <asp:HiddenField ID="hdnStudentMajor" runat="server" />
    <asp:HiddenField ID="hdnSerial" runat="server" />
    <asp:HiddenField ID="hdnStudentEmail" runat="server" />
    <asp:HiddenField ID="hdnMsg" runat="server" />
    <asp:SqlDataSource ID="CopyDS" runat="server"
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
        InsertCommand="CopyToMales" InsertCommandType="StoredProcedure"
        ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>">
        <InsertParameters>
            <asp:Parameter DefaultValue="0" Direction="ReturnValue" Name="RETURN_VALUE"
                Type="Int32" />
            <asp:ControlParameter ControlID="sSelectedValue" DefaultValue="0" Name="sNo"
                PropertyName="Value" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
