<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradesEdit_Alt.aspx.cs" Inherits="LocalECT.GradesEdit_Alt" MasterPageFile="~/LocalECT.Master"%>
<%--<%@ Register src="~/Search1.ascx" tagname="Search1" tagprefix="uc1" %>--%>
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
                                <style type="text/css">
        .TableStyle
        {
        }
       .TableSize
        {
            width:800px;
            
        }
        .ComboWidth
        {
        	margin-left: 0px;
            margin-bottom: 0px;
        }
  
   
  
        .style20
        {
            width: 14px;
        }
          
   
  
        .style38
        {
            width: 103px;
        }
        .style39
        {
            width: 446px;
        }
        .style40
        {
            width: 329px;
        }
          
   
  
        .style41
        {
            width: 14px;
            height: 317px;
        }
        .style42
        {
            height: 317px;
        }
          
   
  
        </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Grades Edit</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
            <table class="TableSize" style="width:100%;">
     <%--   <tr>
            <th class="PageTitle" rowspan="1">Grades Edit
            </th>
            
        </tr>--%>
        
        <tr>
           <td>
              <div id="divMsg" runat="server" 
                 align="center" class="NoData">
              </div>
           </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="isValid" style="text-align: center" />
            </td>
        </tr>
        <tr>
            <td class="TABLETH">
             
            </td>
        </tr>
        
     
         <tr>
            <td>
             
   
      <table class="TableSize" style="width:100%;">
     <tr>
     <td class="style20" >
        
         &nbsp;</td>
     <td class="style38" >
        
                Term&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
     <td colspan="2" >
        
                <asp:DropDownList ID="Terms" runat="server" CssClass="form-control"
                    onselectedindexchanged="Terms_SelectedIndexChanged" 
                    style="margin-bottom: 0px" AutoPostBack="true">
            </asp:DropDownList>
            
     </td>
     </tr>
     <tr>
     <td class="style20" >
        
         &nbsp;</td>
     <td class="style38" >
        
                Campus</td>
     <td colspan="2" >
        
                <asp:DropDownList ID="CampusCBO" runat="server" 
                   CssClass="form-control"
                    onselectedindexchanged="CampusCBO_SelectedIndexChanged">
                    <asp:ListItem Value="1">Males</asp:ListItem>
                    <asp:ListItem Value="2">Females</asp:ListItem>
                </asp:DropDownList>
        
     </td>
     </tr>

     </table>
     
                                                                                                                                              
   
             </td>
        </tr>
        
     
    </table>
                                                                                                                                              
   
     
                                                                                                                                              
   
  <asp:HiddenField ID="sSelectedText" runat="server" />
     
        <hr />                                                                                                                                      
   
    <asp:GridView ID="grdStudentGrades" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%"
        AllowPaging="True" 
        AllowSorting="True" DataSourceID="SqlDataSourceStudentGrades"  
        CssClass="TableStyle" 
        PageSize="25" 
        AutoGenerateColumns="False" 
        
        
        
        DataKeyNames="intStudyYear,byteSemester,byteShift,strCourse,byteClass,lngStudentNumber" onrowupdating="grdStudentGrades_RowUpdating" 
        onselectedindexchanged="grdStudentGrades_SelectedIndexChanged" 
        onrowupdated="grdStudentGrades_RowUpdated" >
       
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Font-Size="Small" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
            <asp:BoundField DataField="lngStudentNumber" HeaderText="Student ID" 
                ReadOnly="True" SortExpression="lngStudentNumber" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="strLastDescEn" HeaderText="Name" ReadOnly="True" 
                SortExpression="strLastDescEn">
            <ItemStyle Width="220px" />
            </asp:BoundField>
            <asp:BoundField DataField="intStudyYear" HeaderText="intStudyYear" 
                ReadOnly="True" SortExpression="intStudyYear" Visible="False" />
            <asp:BoundField DataField="byteSemester" HeaderText="byteSemester" 
                ReadOnly="True" SortExpression="byteSemester" Visible="False" />
            <asp:BoundField DataField="byteShift" HeaderText="byteShift" ReadOnly="True" 
                SortExpression="byteShift" Visible="False" />
            <asp:BoundField DataField="strCourse" HeaderText="Course" ReadOnly="True" 
                SortExpression="strCourse" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="strCourseDescEn" HeaderText="Course Name" 
                ReadOnly="True" />
            <asp:BoundField DataField="byteClass" HeaderText="byteClass" ReadOnly="True" 
                SortExpression="byteClass" Visible="False" />
            <asp:BoundField DataField="strGrade" HeaderText="Grade" 
                SortExpression="strGrade" ReadOnly="True" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="sAlt" HeaderText="Alternative Course" 
                SortExpression="sAlt" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" 
            Height="45px" Wrap="True" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
      
       
   
  <asp:HiddenField ID="iYear" runat="server" />
     
                                                                                                                                              
   
  <asp:HiddenField ID="iSemester" runat="server" />
     
                                                                                                                                              
   
  <asp:HiddenField ID="sSelectedValue" runat="server" />
                <asp:HiddenField ID="isDataChanged" runat="server" />
      
       
   
                <asp:HiddenField ID="DataStatus" runat="server" />
      
       
   
    <asp:SqlDataSource ID="SqlDataSourceStudentGrades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
        DeleteCommand="DELETE FROM [Reg_Grade_Header] WHERE [intStudyYear] = @intStudyYear AND [byteSemester] = @byteSemester AND [byteShift] = @byteShift AND [strCourse] = @strCourse AND [byteClass] = @byteClass AND [lngStudentNumber] = @lngStudentNumber" 
        InsertCommand="INSERT INTO [Reg_Grade_Header] ([intStudyYear], [byteSemester], [byteShift], [strCourse], [byteClass], [lngStudentNumber], [sAlt]) VALUES (@intStudyYear, @byteSemester, @byteShift, @strCourse, @byteClass, @lngStudentNumber, @sAlt)" 
        SelectCommand="SELECT Reg_Grade_Header.intStudyYear, Reg_Grade_Header.byteSemester, Reg_Grade_Header.byteShift, Reg_Grade_Header.strCourse, Reg_Grade_Header.byteClass, Reg_Grade_Header.lngStudentNumber, Reg_Students_Data.strLastDescEn, Reg_Grade_Header.strGrade, Reg_Grade_Header.sAlt, Reg_Courses.strCourseDescEn FROM Reg_Students_Data INNER JOIN Reg_Applications ON Reg_Students_Data.lngSerial = Reg_Applications.lngSerial INNER JOIN Reg_Grade_Header ON Reg_Applications.lngStudentNumber = Reg_Grade_Header.lngStudentNumber INNER JOIN Reg_Courses ON Reg_Grade_Header.strCourse = Reg_Courses.strCourse LEFT OUTER JOIN Reg_Specilization_Courses_And_Elective ON Reg_Grade_Header.strMajor = Reg_Specilization_Courses_And_Elective.strSpecialization AND Reg_Grade_Header.strDegree = Reg_Specilization_Courses_And_Elective.strDegree AND Reg_Grade_Header.strCourse = Reg_Specilization_Courses_And_Elective.strCourse WHERE (Reg_Specilization_Courses_And_Elective.strCourse IS NULL) AND (Reg_Grade_Header.strMajor = N'-1')" 
        
        
        
        
        
        
        
        UpdateCommand="UPDATE Reg_Grade_Header SET sAlt = @sAlt WHERE (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester) AND (byteShift = @byteShift) AND (strCourse = @strCourse) AND (byteClass = @byteClass) AND (lngStudentNumber = @lngStudentNumber)">
        <DeleteParameters>
            <asp:Parameter Name="intStudyYear" Type="Int16" />
            <asp:Parameter Name="byteSemester" Type="Int16" />
            <asp:Parameter Name="byteShift" Type="Int16" />
            <asp:Parameter Name="strCourse" Type="String" />
            <asp:Parameter Name="byteClass" Type="Int16" />
            <asp:Parameter Name="lngStudentNumber" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="sAlt" />
            <asp:Parameter Name="intStudyYear" Type="Int16" />
            <asp:Parameter Name="byteSemester" Type="Int16" />
            <asp:Parameter Name="byteShift" Type="Int16" />
            <asp:Parameter Name="strCourse" Type="String" />
            <asp:Parameter Name="byteClass" Type="Int16" />
            <asp:Parameter Name="lngStudentNumber" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="intStudyYear" Type="Int16" />
            <asp:Parameter Name="byteSemester" Type="Int16" />
            <asp:Parameter Name="byteShift" Type="Int16" />
            <asp:Parameter Name="strCourse" Type="String" />
            <asp:Parameter Name="byteClass" Type="Int16" />
            <asp:Parameter Name="lngStudentNumber" Type="String" />
            <asp:Parameter Name="sAlt" />
        </InsertParameters>
    </asp:SqlDataSource>
      
       
   
                <asp:SqlDataSource ID="SDSCourses" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                    
        SelectCommand="SELECT [strCourse], [strCourseDescEn] FROM [Reg_Courses] WHERE ([IsActive] = @IsActive) ORDER BY [strCourse]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="IsActive" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
      

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>