<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Track_Students.aspx.cs" Inherits="LocalECT.Track_Students" MasterPageFile="~/LocalECT.Master"%>

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
                                     .style8
        {
            height: 22px;
        }
        .style9
        {
        }
        .style11
        {
            height: 22px;
            width: 76px;
        }
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Students Discipline</h2>
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
        <tr>
            <th class="PageTitle" colspan="4">Students Discipline</th>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:FormView ID="FormView1" runat="server" 
                    DataKeyNames="strCourse,byteClass,intStudyYear,byteSemester,byteShift" 
                    DataSourceID="Class_DS" Width="100%">
                    <EditItemTemplate>
                        strShortcut:
                        <asp:TextBox ID="strShortcutTextBox" runat="server" 
                            Text='<%# Bind("strShortcut") %>' />
                        <br />
                        strCourse:
                        <asp:Label ID="strCourseLabel1" runat="server" 
                            Text='<%# Eval("strCourse") %>' />
                        <br />
                        strCourseDescEn:
                        <asp:TextBox ID="strCourseDescEnTextBox" runat="server" 
                            Text='<%# Bind("strCourseDescEn") %>' />
                        <br />
                        byteClass:
                        <asp:Label ID="byteClassLabel1" runat="server" 
                            Text='<%# Eval("byteClass") %>' />
                        <br />
                        intStudyYear:
                        <asp:Label ID="intStudyYearLabel1" runat="server" 
                            Text='<%# Eval("intStudyYear") %>' />
                        <br />
                        byteSemester:
                        <asp:Label ID="byteSemesterLabel1" runat="server" 
                            Text='<%# Eval("byteSemester") %>' />
                        <br />
                        byteShift:
                        <asp:Label ID="byteShiftLabel1" runat="server" 
                            Text='<%# Eval("byteShift") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        strShortcut:
                        <asp:TextBox ID="strShortcutTextBox" runat="server" 
                            Text='<%# Bind("strShortcut") %>' />
                        <br />
                        strCourse:
                        <asp:TextBox ID="strCourseTextBox" runat="server" 
                            Text='<%# Bind("strCourse") %>' />
                        <br />
                        strCourseDescEn:
                        <asp:TextBox ID="strCourseDescEnTextBox" runat="server" 
                            Text='<%# Bind("strCourseDescEn") %>' />
                        <br />
                        byteClass:
                        <asp:TextBox ID="byteClassTextBox" runat="server" 
                            Text='<%# Bind("byteClass") %>' />
                        <br />
                        intStudyYear:
                        <asp:TextBox ID="intStudyYearTextBox" runat="server" 
                            Text='<%# Bind("intStudyYear") %>' />
                        <br />
                        byteSemester:
                        <asp:TextBox ID="byteSemesterTextBox" runat="server" 
                            Text='<%# Bind("byteSemester") %>' />
                        <br />
                        byteShift:
                        <asp:TextBox ID="byteShiftTextBox" runat="server" 
                            Text='<%# Bind("byteShift") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table class="style7">
                            <tr>
                                <th>
                                    <asp:Label ID="Label6" runat="server" Text="Session"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="Label7" runat="server" Text="Code"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="Label8" runat="server" Text="Course"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="Label9" runat="server" Text="Section"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="strShortcutLabel" runat="server" 
                                        Text='<%# Bind("strShortcut") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="strCourseLabel" runat="server" Text='<%# Eval("strCourse") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="strCourseDescEnLabel" runat="server" 
                                        Text='<%# Bind("strCourseDescEn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="byteClassLabel" runat="server" Text='<%# Eval("byteClass") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" DataSourceID="Timing_ds" Font-Size="Smaller" 
                                        ForeColor="#333333" GridLines="None" Width="100%">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                SortExpression="Lecturer" />
                                            <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                            <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                HeaderText="From" SortExpression="TimeFrom" />
                                            <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}" 
                                                HeaderText="To" SortExpression="TimeTo" />
                                            <asp:TemplateField HeaderText="Sat" SortExpression="Sat">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" Height="20px" 
                                                        ImageUrl="~/Images/Icons/Correct.gif" 
                                                        Visible='<%# Convert.ToBoolean(Eval("isSat")) %>' Width="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("isSat") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image2" runat="server" Height="20px" 
                                                        ImageUrl="~/Images/Icons/Correct.gif" 
                                                        Visible='<%# Convert.ToBoolean(Eval("isSun")) %>' Width="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("isSun") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image3" runat="server" Height="20px" 
                                                        ImageUrl="~/Images/Icons/Correct.gif" 
                                                        Visible='<%# Convert.ToBoolean(Eval("isMon")) %>' Width="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("isMon") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image4" runat="server" Height="20px" 
                                                        ImageUrl="~/Images/Icons/Correct.gif" 
                                                        Visible='<%# Convert.ToBoolean(Eval("isTus")) %>' Width="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("isTus") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image5" runat="server" Height="20px" 
                                                        ImageUrl="~/Images/Icons/Correct.gif" 
                                                        Visible='<%# Convert.ToBoolean(Eval("isWed")) %>' Width="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("isWed") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image6" runat="server" Height="20px" 
                                                        ImageUrl="~/Images/Icons/Correct.gif" 
                                                        Visible='<%# Convert.ToBoolean(Eval("isThu")) %>' Width="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("isThu") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image7" runat="server" Height="20px" 
                                                        ImageUrl="~/Images/Icons/Correct.gif" 
                                                        Visible='<%# Convert.ToBoolean(Eval("isFri")) %>' Width="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("isFri") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="Class_DS" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                    SelectCommand="SELECT P.strShortcut, AV.strCourse, C.strCourseDescEn, AV.byteClass, AV.intStudyYear, AV.byteSemester, AV.byteShift FROM Reg_Available_Courses AS AV INNER JOIN Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN Reg_Shifts AS P ON AV.byteShift = P.byteShift WHERE (AV.strCourse = @sCourse) AND (AV.byteClass = @bClass) AND (AV.intStudyYear = @iStudyYear) AND (AV.byteSemester = @bSemester) AND (AV.byteShift = @bShift)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="iStudyYear" QueryStringField="iStudyYear" 
                            DefaultValue="0" />
                        <asp:QueryStringParameter Name="bSemester" QueryStringField="bSemester" 
                            DefaultValue="0" />
                        <asp:QueryStringParameter Name="bShift" QueryStringField="bShift" 
                            DefaultValue="0" />
                        <asp:QueryStringParameter Name="sCourse" QueryStringField="sCourse" 
                            DefaultValue="" />
                        <asp:QueryStringParameter Name="bClass" QueryStringField="bClass" 
                            DefaultValue="0" />
                    </SelectParameters>
                </asp:SqlDataSource>
                                                        <asp:SqlDataSource ID="Timing_ds" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                            
                                                            
                    
                    SelectCommand="SELECT Lecturer, Hall, TimeFrom, TimeTo, isSat, isSun, isMon, isTus, isWed, isThu, isFri FROM TM_ALL_Times WHERE (intStudyYear = @StudyYear) AND (byteSemester = @Semester) AND (byteShift = @Shift) AND (strCourse = @Course) AND (byteClass = @Class) ORDER BY byteDay, TimeFrom">
                                                            <SelectParameters>
                                                                <asp:QueryStringParameter DefaultValue="0" Name="StudyYear" 
                                                                    QueryStringField="iStudyYear" />
                                                                <asp:QueryStringParameter DefaultValue="0" Name="Semester" 
                                                                    QueryStringField="bSemester" />
                                                                <asp:QueryStringParameter DefaultValue="0" Name="Shift" 
                                                                    QueryStringField="bShift" />
                                                                <asp:QueryStringParameter DefaultValue="" Name="Course" 
                                                                    QueryStringField="sCourse" />
                                                                <asp:QueryStringParameter DefaultValue="0" Name="Class" 
                                                                    QueryStringField="bClass" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:SqlDataSource ID="StudentsDS" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                    SelectCommand="SELECT Reg_Applications.lngStudentNumber, Reg_Students_Data.strLastDescEn FROM Reg_Applications INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial INNER JOIN Course_Balance_View ON Reg_Applications.lngStudentNumber = Course_Balance_View.Student WHERE (Course_Balance_View.iYear = @iYear) AND (Course_Balance_View.Sem = @bSem) AND (Course_Balance_View.Shift = @bShift) AND (Course_Balance_View.Course = @sCourse) AND (Course_Balance_View.Class = @bClass) ORDER BY Reg_Students_Data.strLastDescEn">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="iYear" 
                            QueryStringField="iStudyYear" />
                        <asp:QueryStringParameter DefaultValue="0" Name="bSem" 
                            QueryStringField="bSemester" />
                        <asp:QueryStringParameter DefaultValue="0" Name="bShift" 
                            QueryStringField="bShift" />
                        <asp:QueryStringParameter DefaultValue="" Name="sCourse" 
                            QueryStringField="sCourse" />
                        <asp:QueryStringParameter DefaultValue="0" Name="bClass" 
                            QueryStringField="bClass" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" 
                    EnableTheming="True">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="StudentsGRD" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="lngStudentNumber" DataSourceID="StudentsDS" 
                            onselectedindexchanged="StudentsGRD_SelectedIndexChanged" Width="100%">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderText="*" />
                                <asp:BoundField DataField="lngStudentNumber" HeaderText="Student ID" 
                                    SortExpression="lngStudentNumber" />
                                <asp:BoundField DataField="strLastDescEn" HeaderText="Name" 
                                    SortExpression="strLastDescEn" />
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    
                    <asp:View ID="View2" runat="server">
                        <table class="style7">
                            <tr>
                                <td colspan="3">
                                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                                        CellPadding="4" DataSourceID="Student_DS2" ForeColor="#333333" GridLines="None" 
                                        Height="50px" Width="100%">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <Fields>
                                            <asp:BoundField DataField="lngStudentNumber" HeaderText="Student ID" 
                                                SortExpression="lngStudentNumber" />
                                            <asp:BoundField DataField="strLastDescEn" HeaderText="Name" 
                                                SortExpression="strLastDescEn" />
                                        </Fields>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:DetailsView>
                                    <asp:SqlDataSource ID="Student_DS2" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                        SelectCommand="SELECT Reg_Applications.lngStudentNumber, Reg_Students_Data.strLastDescEn FROM Reg_Applications INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial INNER JOIN Course_Balance_View ON Reg_Applications.lngStudentNumber = Course_Balance_View.Student WHERE (Course_Balance_View.iYear = @iYear) AND (Course_Balance_View.Sem = @bSem) AND (Course_Balance_View.Shift = @bShift) AND (Course_Balance_View.Course = @sCourse) AND (Course_Balance_View.Class = @bClass)AND(Reg_Applications.lngStudentNumber=@sNo) ORDER BY Reg_Students_Data.strLastDescEn">
                                        <SelectParameters>
                                            <asp:QueryStringParameter DefaultValue="0" Name="iYear" 
                                                QueryStringField="iStudyYear" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bSem" 
                                                QueryStringField="bSemester" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bShift" 
                                                QueryStringField="bShift" />
                                            <asp:QueryStringParameter DefaultValue="" Name="sCourse" 
                                                QueryStringField="sCourse" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bClass" 
                                                QueryStringField="bClass" />
                                            <asp:ControlParameter ControlID="StudentsGRD" DefaultValue="0" Name="sNo" 
                                                PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="Track_GRD" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="Track_DS" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="*">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Edit_LNK" runat="server" 
                                                        CommandArgument='<%# Eval("byteGradeType") + ";" + Eval("byteTrackDegree")+ ";" + Eval("byteTrackType") + ";" + Eval("strNote") %>' 
                                                        oncommand="Edit_LNK_Command">Edit</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="strGradeDesc" HeaderText="Topic" 
                                                SortExpression="strGradeDesc">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="strTrackDegree" HeaderText="Degree" 
                                                SortExpression="strTrackDegree" />
                                            <asp:BoundField DataField="strTrackType" HeaderText="Type" 
                                                SortExpression="strTrackType" />
                                            <asp:BoundField DataField="dateCreate" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="Date" SortExpression="dateCreate">
                                                <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="strNote" HeaderText="Remark" 
                                                SortExpression="strNote">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="Track_DS" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                        
                                        SelectCommand="SELECT GT.strGradeDesc, D.strTrackDegree, TP.strTrackType, T.dateCreate, T.strNote, T.byteGradeType, T.byteTrackDegree, T.byteTrackType FROM Lkp_Track_Degree AS D INNER JOIN Reg_Discipline_Track AS T ON D.byteTrackDegree = T.byteTrackDegree INNER JOIN Lkp_Track_Type AS TP ON T.byteTrackType = TP.byteTrackType INNER JOIN Reg_Grade_Types AS GT ON T.byteGradeType = GT.byteGradeType WHERE (T.intStudyYear = @iYear) AND (T.byteSemester = @bSem) AND (T.byteShift = @bShift) AND (T.strCourse = @sCourse) AND (T.byteClass = @bClass) AND (T.lngStudentNumber = @sSno) ORDER BY D.byteTrackDegree, TP.byteTrackType">
                                        <SelectParameters>
                                            <asp:QueryStringParameter DefaultValue="0" Name="iYear" 
                                                QueryStringField="iStudyYear" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bSem" 
                                                QueryStringField="bSemester" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bShift" 
                                                QueryStringField="bShift" />
                                            <asp:QueryStringParameter DefaultValue="" Name="sCourse" 
                                                QueryStringField="sCourse" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bClass" 
                                                QueryStringField="bClass" />
                                            <asp:ControlParameter ControlID="StudentsGRD" DefaultValue="0" Name="sSno" 
                                                PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr class="Command">
                                <td align="left" colspan="3" >
                                    <asp:LinkButton ID="Back_LNK" runat="server" onclick="Back_LNK_Click">&lt;&lt;Back</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="Add_LNK" runat="server" onclick="Add_LNK_Click">Add&gt;&gt;</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table >
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label1" runat="server" Text="Student"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Student_TXT" runat="server" Width="300px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label2" runat="server" Text="Topic"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="Topic_LST" runat="server" DataSourceID="Topic_DS" 
                                        DataTextField="strGradeDesc" DataValueField="byteGradeType" Width="150px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="Topic_DS" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                        SelectCommand="SELECT GTC.byteGradeType, GT.strGradeDesc FROM Reg_Grades_Taype_Courses AS GTC INNER JOIN Reg_Grades_Distributions AS GD ON GTC.intDistribution = GD.intDistribution INNER JOIN Reg_Grade_Types AS GT ON GTC.byteGradeType = GT.byteGradeType WHERE (GD.intStudyYear = @iYear) AND (GD.byteSemester = @bSem) AND (GTC.strCourse = @sCourse) ORDER BY GTC.byteOrder">
                                        <SelectParameters>
                                            <asp:QueryStringParameter DefaultValue="0" Name="iYear" 
                                                QueryStringField="iStudyYear" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bSem" 
                                                QueryStringField="bSemester" />
                                            <asp:QueryStringParameter DefaultValue="" Name="sCourse" 
                                                QueryStringField="sCourse" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style11">
                                    <asp:Label ID="Label3" runat="server" Text="Degree"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:DropDownList ID="Degree_LST" runat="server" DataSourceID="Degree_DS" 
                                        DataTextField="strTrackDegree" DataValueField="byteTrackDegree" Width="150px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="Degree_DS" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                        SelectCommand="SELECT [byteTrackDegree], [strTrackDegree] FROM [Lkp_Track_Degree] ORDER BY [byteTrackDegree]">
                                    </asp:SqlDataSource>
                                </td>
                                <td align="left" valign="middle">
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToValidate="Degree_LST" ErrorMessage="Select Degree Please" 
                                        Operator="GreaterThan" Type="Integer" ValueToCompare="0" 
                                        ValidationGroup="isValid"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label4" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="Type_LST" runat="server" DataSourceID="Type_DS" 
                                        DataTextField="strTrackType" DataValueField="byteTrackType" Width="150px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="Type_DS" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                        SelectCommand="SELECT [byteTrackType], [strTrackType] FROM [Lkp_Track_Type] ORDER BY [byteTrackType]">
                                    </asp:SqlDataSource>
                                </td>
                                <td align="left" valign="middle">
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                        ControlToValidate="Type_LST" ErrorMessage="Select Type Please" 
                                        Operator="GreaterThan" Type="Integer" ValueToCompare="0" 
                                        ValidationGroup="isValid"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label5" runat="server" Text="Remark"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Remark_TXT" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                                <td align="left" valign="middle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="Remark_TXT" Display="Dynamic" 
                                        ErrorMessage="Remark is Required" SetFocusOnError="True" 
                                        ValidationGroup="isValid"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    &nbsp;</td>
                                <td>
                                    <asp:HiddenField ID="Date_FLD" runat="server" />
                                    <asp:SqlDataSource ID="Insert_DS" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                        InsertCommand="INSERT INTO Reg_Discipline_Track(intStudyYear, byteSemester, byteShift, strCourse, byteClass, byteGradeType, byteTrackDegree, byteTrackType, lngStudentNumber, strNote, dateCreate, strUserCreate,intLecturer) VALUES (@iYear, @bSem, @bShift, @sCourse, @bClass, @bGrade, @bDegree, @bType, @sSno, @sNote, @sDate, @sUser,@iLec)">
                                        <InsertParameters>
                                            <asp:QueryStringParameter DefaultValue="0" Name="iYear" 
                                                QueryStringField="iStudyYear" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bSem" 
                                                QueryStringField="bSemester" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bShift" 
                                                QueryStringField="bShift" />
                                            <asp:QueryStringParameter DefaultValue="" Name="sCourse" 
                                                QueryStringField="sCourse" />
                                            <asp:QueryStringParameter DefaultValue="0" Name="bClass" 
                                                QueryStringField="bClass" />
                                            <asp:ControlParameter ControlID="Topic_LST" DefaultValue="0" Name="bGrade" 
                                                PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="Degree_LST" DefaultValue="0" Name="bDegree" 
                                                PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="Type_LST" DefaultValue="0" Name="bType" 
                                                PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="StudentsGRD" DefaultValue="0" Name="sSno" 
                                                PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="Remark_TXT" DefaultValue="" Name="sNote" 
                                                PropertyName="Text" />
                                            <asp:ControlParameter ControlID="Date_FLD" Name="sDate" PropertyName="Value" />
                                            <asp:Parameter DefaultValue="LocalECT" Name="sUser" />
                                            <asp:ControlParameter ControlID="Lecturer" DefaultValue="0" Name="iLec" 
                                                PropertyName="Value" />
                                        </InsertParameters>
                                    </asp:SqlDataSource>
                                    
                                    <asp:HiddenField ID="Lecturer" runat="server" />
                                    
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;</td>
                            </tr>
                            <tr class="Serial">
                                <td align="left" class="Command" colspan="3">
                                    <asp:LinkButton ID="Update_LNK0" runat="server" onclick="SaveCMD_Click" 
                                        ValidationGroup="isValid">Add</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="Back2_LNK" runat="server" onclick="Back_LNK_Click" 
                                        ValidationGroup="NoGroup">Undo</asp:LinkButton>
&nbsp; </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <table class="style7">
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label20" runat="server" Text="Remark :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Note_TXT" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="Note_TXT" ErrorMessage="Remark is Required" 
                                        SetFocusOnError="True" ValidationGroup="isValid2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="Serial">
                                <td align="left" class="Command" colspan="3">
                                    <asp:LinkButton ID="Update_LNK" runat="server" onclick="Update_LNK_Click" 
                                        ValidationGroup="isValid2">Update</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="Undo_LNK" runat="server" onclick="Undo_LNK_Click">Undo</asp:LinkButton>
&nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:SqlDataSource ID="TrackEditDS" runat="server" UpdateCommand="UPDATE [ECTData].[dbo].[Reg_Discipline_Track]
                           SET [strNote] = @Note
                         WHERE [intStudyYear] = @StudyYear
                           AND [byteSemester] = @Semester
                           AND [byteShift] = @Shift
                           AND [strCourse] = @Course
                           AND [byteClass] = @Class
                           AND [byteGradeType] = @GradeType
                           AND [byteTrackDegree] = @TrackDegree
                           AND [byteTrackType] = @TrackType
                           AND [lngStudentNumber]=@StudentNumber">
                            <UpdateParameters>
                                <asp:ControlParameter ControlID="Note_TXT" Name="Note" PropertyName="Text" />
                                <asp:QueryStringParameter DefaultValue="0" Name="StudyYear" 
                                    QueryStringField="iStudyYear" />
                                <asp:QueryStringParameter DefaultValue="0" Name="Semester" 
                                    QueryStringField="bSemester" />
                                <asp:QueryStringParameter DefaultValue="0" Name="Shift" 
                                    QueryStringField="bShift" />
                                <asp:QueryStringParameter DefaultValue="" Name="Course" 
                                    QueryStringField="sCourse" />
                                <asp:QueryStringParameter DefaultValue="0" Name="Class" 
                                    QueryStringField="bClass" />
                                <asp:ControlParameter ControlID="TrackDegree" DefaultValue="0" 
                                    Name="TrackDegree" PropertyName="Value" />
                                <asp:ControlParameter ControlID="TrackType" DefaultValue="0" Name="TrackType" 
                                    PropertyName="Value" />
                                <asp:ControlParameter ControlID="StudentsGRD" DefaultValue="" 
                                    Name="StudentNumber" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="GradeType" DefaultValue="0" Name="GradeType" 
                                    PropertyName="Value" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <br />
                        <asp:HiddenField ID="GradeType" runat="server" />
                        <asp:HiddenField ID="TrackDegree" runat="server" />
                        <asp:HiddenField ID="TrackType" runat="server" />
                    </asp:View>
                </asp:MultiView>
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