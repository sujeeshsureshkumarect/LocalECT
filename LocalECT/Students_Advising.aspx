<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students_Advising.aspx.cs" Inherits="LocalECT.Students_Advising" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="Includes/jQuery/jquery-1.4.1.min.js" type="text/javascript"></script>
    <!-- Sexy error includes -->
    <script src="Includes/jQuery/sexy-alert-box-1.2.2/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="Includes/jQuery/sexy-alert-box-1.2.2/sexyalertbox.v1.2.jquery.js" type="text/javascript"></script>
    <link href="Includes/jQuery/sexy-alert-box-1.2.2/sexyalertbox.css" rel="stylesheet" media="all" type="text/css" />
    <!-- end of sexy error includes -->
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Student Advising</a>
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
                                    
                                   #ContentPlaceHolder1_tblDetail  th, td {
  padding-bottom: 7px;
  padding-top: 7px;
}
                                  caption {
    padding-top: .75rem;
    padding-bottom: .75rem;
    font-weight:bold;
    text-align: center !important;
    caption-side: top !important;
}
       
            #divConfirmation
            {
        	    background-color: #F2B702;
        	    margin: 3px;
                padding: 3px;
                -moz-border-radius: 5px;  
                -webkit-border-radius: 5px;  
                -khtml-border-radius: 5px;  
            }
            .error
            {
        	    background-color: #fff;
        	    border: 2px solid red;
        	    color: red;
            }
            TABLE TH {
    border-right: white thin solid;
    border-top: white thin solid;
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    border-left: white thin solid;
    color: #ffffff;
    border-bottom: white thin solid;
    font-family: Verdana;
    background-color: #84A5D6;
    text-align: center;
    line-height: 2;
    font-size: small;
}
/*            TABLE {
    border-style: none;
    padding: 0px;
    margin: 0px;
    vertical-align: top;
    direction: ltr;
    line-height: normal;
    letter-spacing: normal;
    text-align: left;
    padding:5px;
}
*/
         .style9
         {
             height: 24px;
         }
         .style10
         {
             height: 26px;
         }
         .style11
         {
             height: 22px;
         }
         .style12
         {
             text-align: center;
         }
         .R_NormalWhite {
    border-right: cornflowerblue thin solid;
    border-top: cornflowerblue thin solid;
    vertical-align: middle;
    border-left: cornflowerblue thin solid;
    color: #003333;
    border-bottom: cornflowerblue thin solid;
    font-family: Verdana;
    background-color: #EFF3FB;
    text-align: left;
}
         .R_NormalGray {
    border-right: cornflowerblue thin solid;
    border-top: cornflowerblue thin solid;
    vertical-align: middle;
    border-left: cornflowerblue thin solid;
    color: #003333;
    border-bottom: cornflowerblue thin solid;
    font-family: Verdana;
    background-color: White;
    text-align: left;
}
         /*table {
    border: 1px solid #dee2e6;
}*/
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-user"></i> Student Advising</h2>
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
                                                <table style="width:100%;" >
                                                    <tr>
                                                        <td align="center">
                                                            <asp:RadioButtonList ID="rbnView" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="rbnView_SelectedIndexChanged"
                                                                RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True">&nbsp;Student Advising&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                                <asp:ListItem>&nbsp;CGPA Demo(Grades)</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <hr />
                                              
                                                <div>
                                                    <table style="width:100%;" >
                                                        <tr>
                                                            <td>
                                                                 <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <th style="vertical-align: middle; text-align: center; height: 20px;">
                                    Student Advising</th>
                            </tr>
                            <tr>
                                <th style="vertical-align: middle; text-align: center; height: 20px" 
                                    class="BoxInfo">
                                    <asp:Label ID="lblSelectedStudent" runat="server" style="font-size: medium"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    
                                    <div ID="divTools" runat="server" align="center">
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="Term_ddl" runat="server" CssClass="form-control" 
                                                OnSelectedIndexChanged="Term_ddl_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                         <div class="col-md-3">
                                             <asp:DropDownList ID="Type_ddl" runat="server" CssClass="form-control"  >
                                            <asp:ListItem Selected="True">For Registration</asp:ListItem>
                                            <asp:ListItem>For Add and Drop</asp:ListItem>
                                            <asp:ListItem>Empty Form</asp:ListItem>
                                        </asp:DropDownList>
                                             </div>
                                        <div class="col-md-3">
                                            <asp:LinkButton ID="Run_btn" runat="server"
                                                OnClick="Run_btn_Click" Style="text-align: left" ToolTip="Run Advising" Text="Run Advising" CssClass="btn btn-success btn-sm">
                                                <i class="fa fa-bolt"></i> Run Advising
                                                </asp:LinkButton>
                                            <asp:LinkButton ID="Print_btn" runat="server" Enabled="False"
                                                OnClick="Print_btn_Click" CssClass="btn btn-success btn-sm"
                                                ToolTip="Print" ><i class="fa fa-print"></i> Print</asp:LinkButton>
                                        </div>
                                        
                                        
                                        
                                       
                                       
                                    </div>   
                                    
                                </td>
                            </tr>
                            <tr>                               
                                <td align="center">
                                   <%-- <hr />--%>
                                    <h2>
                                        <asp:LinkButton ID="lngAdvisorComments" runat="server" Font-Size="Large"
                                            onclick="lngAdvisorComments_Click" ForeColor="Blue" Font-Underline="true"
                                            >Advisor Comments/Suggested Courses</asp:LinkButton>
                                        &nbsp;&nbsp;|&nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkStudenttranscript" runat="server" Font-Size="Large" 
                                            onclick="lnkStudenttranscript_Click" ForeColor="Blue" Font-Underline="true"
                                            >Show Student Transcript</asp:LinkButton>
                                    </h2>
                                    
                                </td>
                            </tr>
                      <%--      <tr>
                                <td align="center">
                                    <h2>
                                        
                                    </h2>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <div ID="divDetail" runat="server" align="center" style="width:100%;">
                                    </div>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <div ID="divCRS" runat="server" align="center" visible="false">
                                        <asp:Label ID="lblCourse" runat="server" Font-Bold="True" ForeColor="Red" 
                                            Height="50px" Width="790px"></asp:Label>
                                        <asp:Label ID="lblCourseName" runat="server" Font-Bold="True" ForeColor="Red" 
                                            Height="50px" Width="790px"></asp:Label>
                                        <br />
                                        <asp:GridView ID="grdCrs" runat="server" AutoGenerateColumns="False" 
                                            Caption="Available Classes" 
                                            DataKeyNames="intStudyYear,byteSemester,strCourse,byteClass,byteShift" 
                                            DataSourceID="TmDS" EmptyDataText="Course not available." 
                                            onselectedindexchanged="grdCrs_SelectedIndexChanged" PageSize="15" Width="100%">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                            CommandArgument='<%# Eval("byteClass") %>' CommandName="Select" Text="Suggest" 
                                                            ToolTip='<%# Bind("CourseDesc") %>' ForeColor="Blue" Font-Underline="true"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="strCourse" HeaderText="Code" 
                                                    SortExpression="strCourse" />
                                                <asp:BoundField DataField="byteClass" HeaderText="Section" 
                                                    SortExpression="byteClass" />
                                                <asp:BoundField DataField="strLecturerDescEn" HeaderText="Lecturer" 
                                                    SortExpression="strLecturerDescEn" />
                                                <asp:BoundField DataField="dateTimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                    HeaderText="From" SortExpression="dateTimeFrom" />
                                                <asp:BoundField DataField="dateTimeTo" DataFormatString="{0:hh:mm tt}" 
                                                    HeaderText="To" SortExpression="dateTimeTo" />
                                                <asp:BoundField DataField="strDays" HeaderText="Days" ReadOnly="True" 
                                                    SortExpression="strDays" />
                                                <asp:BoundField DataField="strHall" HeaderText="Hall" 
                                                    SortExpression="strHall" />
                                                <asp:BoundField DataField="Max" HeaderText="Max" SortExpression="Max" 
                                                    Visible="False" />
                                                <asp:BoundField DataField="Capacity" HeaderText="Capacity" ReadOnly="True" 
                                                    SortExpression="Capacity" Visible="False" />
                                            </Columns>
                                            <EmptyDataRowStyle BackColor="#FF3300" Font-Bold="True" Font-Size="Medium" 
                                                ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="TmDS" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                            
                                            SelectCommand="SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass, byteCreditHours, strLecturerDescEn, dateTimeFrom, dateTimeTo, strDays, strHall, Max, Capacity, CourseDesc FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn, CT.dateTimeFrom, CT.dateTimeTo, dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall, (CASE WHEN H.intMaxSeats &lt; MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity, C.strCourseDescEn AS CourseDesc FROM Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND CT.byteShift = CC.Shift WHERE (CT.intStudyYear = @iYear) AND (CT.byteSemester = @bSem) AND (CT.strCourse IN (@sCourse))) AS TM WHERE (Max &gt; Capacity) AND (byteClass &lt; 100) ORDER BY strCourse, byteShift, byteClass, dateTimeFrom">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="0" Name="iYear" />
                                                <asp:Parameter DefaultValue="0" Name="bSem" />
                                                <asp:Parameter DefaultValue="0" Name="sCourse" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <div ID="divConfirmation" runat="server">
                                        </div>
                                        <br />
                                        <hr />
                                        <br />
                                        <asp:GridView ID="grdSuggested" runat="server" AutoGenerateColumns="False" 
                                            Caption="Suggested" EmptyDataText="Nothing suggested yet!" 
                                            onselectedindexchanged="grdSuggested_SelectedIndexChanged" Width="100%">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                            CommandArgument='<%# Eval("Index") %>' CommandName="Select" Text="Remove" 
                                                            ToolTip='<%# Bind("Course") %>' ForeColor="Blue" Font-Underline="true"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                                                <asp:BoundField DataField="Class" HeaderText="Section" SortExpression="Class" 
                                                    Visible="False" />
                                                <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                    SortExpression="Lecturer" />
                                                <asp:BoundField DataField="From" DataFormatString="{0:hh:mm tt}" 
                                                    HeaderText="From" SortExpression="From" />
                                                <asp:BoundField DataField="To" DataFormatString="{0:hh:mm tt}" HeaderText="To" 
                                                    SortExpression="To" />
                                                <asp:BoundField DataField="Days" HeaderText="Days" ReadOnly="True" 
                                                    SortExpression="Days" />
                                                <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                <asp:BoundField DataField="isReg" HeaderText="Reg ?" SortExpression="isReg" />
                                                <asp:BoundField DataField="Campus" HeaderText="Where" SortExpression="Campus" />
                                            </Columns>
                                            <EmptyDataRowStyle BackColor="#FF3300" Font-Bold="True" Font-Size="Medium" 
                                                ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:GridView>
                                        <br />
                                        <asp:LinkButton ID="lngBack" runat="server" onclick="lngBack_Click" Font-Underline="true" CssClass="btn btn-success btn-sm"><i class="fa fa-reply"></i> Back to the Mirror</asp:LinkButton>
                                        <hr />
                                        <table class="style7">
                                            <tr>
                                                <td class="style12">
                                                    <asp:Label ID="lblStudentGPA" runat="server" CssClass="ECT2" 
                                                        style="text-align: left">Student CGPA</asp:Label>
                                                </td>
                                                <td class="style12">
                                                    <asp:Label ID="txtStudentCGPA" runat="server" BorderColor="LightSteelBlue" 
                                                        BorderStyle="Solid" BorderWidth="1px" Enabled="False" ForeColor="Black" 
                                                        style="text-align: center" Width="100px"></asp:Label>
                                                </td>
                                                <td class="style12">
                                                    <asp:Label ID="lblAdvisorName" runat="server" CssClass="ECT2">Advisor Name</asp:Label>
                                                </td>
                                                <td class="style12">
                                                    <asp:TextBox ID="txtAdvisorName" runat="server" Enabled="False" ReadOnly="True" 
                                                        Width="250px" style="text-align: left"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style12" colspan="4">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label1" runat="server" 
                                            Text="Advisor Comment (Previous Semester Performance)" Font-Bold="true" Font-Underline="true"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtComment" runat="server" Height="100px" TextMode="MultiLine" 
                                            Width="100%"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" Text="Student feedback" Font-Bold="true" Font-Underline="true"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtStudentFeedback" runat="server" Height="58px" 
                                            TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        <br />
                                          <br />
                                        <asp:LinkButton ID="Print_Adv_btn" runat="server" CssClass="btn btn-success btn-sm"
                                            onclick="Print_Adv_btn_Click" 
                                            ToolTip="Print Student Visit Record" ><i class="fa fa-print"></i> Print Student Visit Record</asp:LinkButton>
                                        <asp:LinkButton ID="SaveCMD" runat="server" CssClass="btn btn-success btn-sm"
                                            onclick="SaveCMD_Click" 
                                            
                                            ToolTip="Save" ><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdAdvisorsComments" runat="server" 
                                        AutoGenerateColumns="False" Caption="Advisor Comments" 
                                        DataKeyNames="AcademicAdvisingID" DataSourceID="SqlDataSourceAdvisorsComments" 
                                        EmptyDataText="No comments from advisors" 
                                        onselectedindexchanged="grdAdvisorsComments_SelectedIndexChanged" 
                                        Width="100%">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
                                            <asp:BoundField DataField="AcademicAdvisingID" HeaderText="#" ReadOnly="True" 
                                                SortExpression="AcademicAdvisingID" />
                                            <asp:BoundField DataField="StudentID" HeaderText="StudentID" 
                                                SortExpression="StudentID" Visible="False" />
                                            <asp:BoundField DataField="StudentName" HeaderText="StudentName" 
                                                SortExpression="StudentName" Visible="False" />
                                            <asp:BoundField DataField="sTerm" HeaderText="Term" 
                                                SortExpression="sTerm" />
                                            <asp:BoundField DataField="CreationDate" HeaderText="Advising Date">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdvisorName" HeaderText="Advisor Name" 
                                                SortExpression="AdvisorName" />
                                            <asp:BoundField DataField="AdvisorComments" HeaderText="Advisor Comments" 
                                                SortExpression="AdvisorComments" />
                                            <asp:BoundField DataField="StudentComments" HeaderText="Student feedback" 
                                                SortExpression="StudentComments" />
                                            <asp:BoundField DataField="CurrentCGPA" HeaderText="CGPA" 
                                                SortExpression="CurrentCGPA">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle BackColor="#FF3300" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSourceAdvisorsComments" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                        
                                        
                                        
                                        SelectCommand="SELECT AA.AcademicAdvisingID, AA.StudentID, SD.strLastDescEn AS StudentName, AA.AdvisorID, L.LecturerNameEn AS AdvisorName, AA.AdvisorComments, AA.AcademicYear, AA.Semester, AA.StudentComments, S.sTerm, AA.CreationDate, AA.CurrentCGPA FROM Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN Reg_AcademicAdvising AS AA ON A.lngStudentNumber = AA.StudentID INNER JOIN LOCALECT.ECTDataNew.dbo.Reg_Semester AS S ON AA.AcademicYear = S.AcademicYear AND AA.Semester = S.Semester INNER JOIN LOCALECT.ECTDataNew.dbo.Reg_Lecturers AS L ON AA.AdvisorID = L.LecturerID WHERE (AA.StudentID = @StudentID)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="sSelectedValue" Name="StudentID" 
                                                PropertyName="Value" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:LinkButton ID="PrintAllAdvisorsComments_btn" runat="server"
                                        onclick="PrintAllAdvisorsComments_btn_Click" 
                                        ToolTip="Print all comments" CssClass="btn btn-success btn-sm"><i class="fa fa-print"></i> Print all comments</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <hr />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                         <table width="100%" id="tbl">
                            <tr>
                                <th style="vertical-align: middle; text-align: center; height: 20px" 
                                    colspan="2">
                                CGPA Demo</th>
                            </tr>
                            
                            <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                             <tr>
                                 <td colspan="2">
                                     <div ID="divGrades" runat="server" align="center">
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="2">
                                     <asp:LinkButton ID="btnHideGrades" runat="server" 
                                          onclick="btnHideGrades_Click" 
                                         ToolTip="Hide old grades"  CssClass="btn btn-success btn-sm" Text="Hide old grades"/>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style11" colspan="2">
                                     <div ID="divNewGrades" runat="server">
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="2">
                                     <asp:LinkButton ID="lngNewGrdae" runat="server" onclick="lngNewGrdae_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add new grade</asp:LinkButton>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="2">
                                     <asp:GridView ID="grdCGPADemo" runat="server" AllowPaging="True" 
                                         AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                                         EmptyDataText="No Data to Preview ..." Font-Size="X-Small" ForeColor="#333333" 
                                         GridLines="None"  
                                         Width="779px">
                                         <EmptyDataRowStyle CssClass="NoData" Font-Bold="True" />
                                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                         <RowStyle BackColor="#EFF3FB" />
                                         <EditRowStyle BackColor="#2461BF" ForeColor="White" />
                                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                         <AlternatingRowStyle BackColor="White" />
                                         <PagerSettings FirstPageImageUrl="~/Images/Icons/First.gif" 
                                             FirstPageText="First" LastPageImageUrl="~/Images/Icons/Last.gif" 
                                             LastPageText="Last" Mode="NextPreviousFirstLast" 
                                             NextPageImageUrl="~/Images/Icons/Next_Column.gif" NextPageText="Next" 
                                             PreviousPageImageUrl="~/Images/Icons/Prev_Column.gif" 
                                             PreviousPageText="Previous" />
                                     </asp:GridView>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="2">
                                     <hr />
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="2">
                                     <asp:Label ID="lblInformation" runat="server" Font-Bold="True" Font-Size="Small" 
                                         ForeColor="Red" 
                                         Text="The following calculation based on the current major" 
                                         Width="100%"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" class="style9" colspan="2">
                                     <asp:Label ID="lblrepeatedCourses" runat="server" 
                                         style="color: #006600; font-weight: 700"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" class="style9" colspan="2">
                                     <asp:Label ID="lblOldCGPA" runat="server" BorderColor="LightSteelBlue" 
                                         BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" Text="Old CGPA" 
                                         Width="100px"></asp:Label>
                                     <asp:Label ID="txtOldCGPA" runat="server" BorderColor="LightSteelBlue" 
                                         BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                         style="text-align: center" Text="0" Width="100px"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="2">
                                     <asp:Label ID="lblAcademicYear2" runat="server" BorderColor="LightSteelBlue" 
                                         BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                         style="text-align: center; background-color: #3399FF;" Text="New CGPA" 
                                         Width="100px"></asp:Label>
                                     <asp:Label ID="lblCGPA" runat="server" BorderColor="LightSteelBlue" 
                                         BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                         style="text-align: center; background-color: #CCFFCC;" Text="0" Width="100px"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center">
                                     <asp:LinkButton ID="btnRefresh" runat="server"  
                                          onclick="btnRefresh_Click" 
                                         ToolTip="Clear all changes"  CssClass="btn btn-success btn-sm"><i class="fa fa-refresh"></i> Clear</asp:LinkButton>
                                     <asp:LinkButton ID="btnToExcel" runat="server"  onclick="btnToExcel_Click" 
                                         ToolTip="Export to excel"   CssClass="btn btn-success btn-sm"><i class="fa fa-file-excel-o"></i> Export</asp:LinkButton>
                                     <asp:LinkButton ID="ButSave" runat="server" 
                                          TabIndex="4"  onclick="ButSave_Click"  CssClass="btn btn-success btn-sm"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                     <asp:LinkButton ID="ButPrint" runat="server" 
                                          onclick="ButPrint_Click" 
                                         ToolTip="Click To preview" CssClass="btn btn-success btn-sm"><i class="fa fa-print"></i> Print</asp:LinkButton>
                                 </td>
                                 <td align="center">
                                     &nbsp;</td>
                             </tr>
                         </table>
                    </asp:View>
                </asp:MultiView>
                                                            </td>
                                                        </tr>
                                                         <tr>
            <td style="text-align: center" >
                    
                                    <asp:LinkButton ID="lnkStudenttranscript0" runat="server" 
                                        onclick="lnkStudenttranscript_Click" 
                                        Font-Size="Large" 
                    
                    ForeColor="Blue" Font-Underline="true">Show Student Transcript</asp:LinkButton>
                                </td>
        </tr>
        <tr>
            <td >
                    
                                <asp:SqlDataSource ID="dsGrades" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                    
                                    SelectCommand="SELECT strGrade, (CASE WHEN strGrade = 'Pass' THEN - 1 WHEN strGrade = 'Fail' THEN - 2 ELSE curCreditPoint END) AS curCreditPoint FROM Reg_Grade_System WHERE (bCalc = @bCalc) AND (byteGradeSystem &lt;&gt; @byteGradeSystem) OR (strGrade = N'Pass') OR (strGrade = N'Fail') ORDER BY curCreditPoint DESC">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="true" Name="bCalc" Type="Boolean" />
                                        <asp:Parameter DefaultValue="2" Name="byteGradeSystem" Type="Int16" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td >
                    
                    <asp:HiddenField ID="sSelectedText" runat="server" />
                    
            </td>
        </tr>
        <tr>
            <td>
                    
                    <asp:HiddenField ID="sSelectedValue" runat="server" />
                    
            </td>
        </tr>
        <tr>
            <td>
                    
                    <asp:HiddenField ID="hdnMajor" runat="server" />
                    
            </td>
        </tr>
        <tr>
            <td>
                    
                    <asp:HiddenField ID="hdnDegree" runat="server" />
                    
            </td>
        </tr>
                                                    </table>

                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

    <!-- Modal Popup -->
<div id="MyPopup" class="modal fade" role="dialog" style="width:100%">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">
                </h4>
                <button type="button" class="close" data-dismiss="modal">
                    &times;</button>
                
            </div>
            <div class="modal-body">
                <div ID="div1" runat="server">
                                        </div>
                <br />
                  <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" 
                                             ></asp:Label>&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" 
                                            ></asp:Label>
                                        <br />
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            
                                            DataKeyNames="intStudyYear,byteSemester,strCourse,byteClass,byteShift" 
                                            DataSourceID="SqlDataSource1" EmptyDataText="Course not available." 
                                            onselectedindexchanged="grdCrs_SelectedIndexChanged1" PageSize="15" Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="true" HeaderText="Suggest">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                            CommandArgument='<%# Eval("byteClass") %>' CommandName="Select" Text="Suggest" 
                                                            ToolTip='<%# Bind("CourseDesc") %>' ForeColor="Blue" Font-Underline="true"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="strCourse" HeaderText="Code" 
                                                    SortExpression="strCourse" />
                                                <asp:BoundField DataField="byteClass" HeaderText="Section" 
                                                    SortExpression="byteClass" />
                                                <asp:BoundField DataField="strLecturerDescEn" HeaderText="Lecturer" 
                                                    SortExpression="strLecturerDescEn" />
                                                <asp:BoundField DataField="dateTimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                    HeaderText="From" SortExpression="dateTimeFrom" />
                                                <asp:BoundField DataField="dateTimeTo" DataFormatString="{0:hh:mm tt}" 
                                                    HeaderText="To" SortExpression="dateTimeTo" />
                                                <asp:BoundField DataField="strDays" HeaderText="Days" ReadOnly="True" 
                                                    SortExpression="strDays" />
                                                <asp:BoundField DataField="strHall" HeaderText="Hall" 
                                                    SortExpression="strHall" />
                                                <asp:BoundField DataField="Max" HeaderText="Max" SortExpression="Max" 
                                                    Visible="False" />
                                                <asp:BoundField DataField="Capacity" HeaderText="Capacity" ReadOnly="True" 
                                                    SortExpression="Capacity" Visible="False" />
                                                 <asp:BoundField DataField="Available" HeaderText="Available" ReadOnly="True" 
                                                    SortExpression="Available" Visible="True" />
                                            </Columns>
                                            <EmptyDataRowStyle BackColor="#FF3300" Font-Bold="True" Font-Size="Medium" 
                                                ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                            
                                            SelectCommand="SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass, byteCreditHours, strLecturerDescEn, dateTimeFrom, dateTimeTo, strDays, strHall, Max, Capacity,(Max-Capacity) as Available , CourseDesc FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn, CT.dateTimeFrom, CT.dateTimeTo, dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall, (CASE WHEN H.intMaxSeats &lt; MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity, C.strCourseDescEn AS CourseDesc FROM Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND CT.byteShift = CC.Shift WHERE (CT.intStudyYear = @iYear) AND (CT.byteSemester = @bSem) AND (CT.strCourse IN (@sCourse))) AS TM WHERE (Max &gt; Capacity) AND (byteClass &lt; 100) ORDER BY strCourse, byteShift, byteClass, dateTimeFrom">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="0" Name="iYear" />
                                                <asp:Parameter DefaultValue="0" Name="bSem" />
                                                <asp:Parameter DefaultValue="0" Name="sCourse" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success btn-sm" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>
</div>
    <script type="text/javascript">
    function ShowPopup(title, body) {
        $("#MyPopup .modal-title").html("Available Classes");
        //$("#MyPopup .modal-body").html(body);
        $("#MyPopup").modal("show");
    }
    </script>
    </asp:Content>