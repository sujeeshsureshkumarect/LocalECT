<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseCalc.aspx.cs" Inherits="LocalECT.CourseCalc" MasterPageFile="~/LocalECT.Master"%>
<%@ Register src="~/Search1.ascx" tagname="Search1" tagprefix="uc1" %>

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
                                    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .TableStyle
        {
            width: 100%;
            height :100%;
        }
      /* .TableSize
        {
            width:800px;
            
        }*/
        .ComboWidth
        {
        	margin-left: 0px;
        }
  
   
  
        .style8
        {
            text-align: center;
            color: #0000FF;
            font-weight: 700;
            font-family: Arial, Helvetica, sans-serif;
        }
          
   
  
        .style13
        {
            width: 4px;
        }
        .style14
        {
            width: 103px;
        }
  
   
  
        .style15
        {
            height: 26px;
        }
  
   
  
        .style18
        {
            height: 29px;
        }
        .style19
        {
            width: 82px;
        }
        .style20
        {
            width: 87px;
        }
  
   
  
        </style>
                                <script runat="server">
    void ServerValidation(object source, ServerValidateEventArgs arguments)
    {

        string sGrade = "";
        sGrade = Convert.ToString(arguments.Value);

        bool bValue = false;
        switch (sGrade)
        {
            case "EX":
            case "EQ":
            case "TC":
                bValue = true;
                break;
            default:
                bValue = false;
                break;
        }

        arguments.IsValid = bValue;

    }
   

  
</script>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Course Calculation</h2>
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
      <%--  <tr>
            <th class="PageTitle" rowspan="1">Course Calculation</th>
            
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
             
                &nbsp;&nbsp;</td>
        </tr>
        
     
    </table>
                                                                                                                                              
   
    <table class="">
        <tr>
            <td class="style14" >
                &nbsp;</td>
            <td class="style14" >
                Campus&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:DropDownList ID="CampusCBO" runat="server" AutoPostBack="True" 
                    CssClass="form-control" 
                    onselectedindexchanged="CampusCBO_SelectedIndexChanged">
                    <asp:ListItem Value="1">Males</asp:ListItem>
                    <asp:ListItem Value="2">Females</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
        
                &nbsp;</td>
            <td >
        
                &nbsp;</td>
            <td colspan="2" >
        
         <uc1:Search1 ID="Search1" runat="server" SCaption1="Student ID" SCaption2="Name" 
             SField1="sNo" SField2="sName" 
             SSQL="SELECT sNo, sName,iSerial FROM Web_Students_Search" 
             OnChangedEvent  ="Search1_ChangedEvent" Campus="Males" SField3="iSerial"  style="width:100%;"/>
        
            </td>
        </tr>
        <tr>
            <td class="style14" >
        
                                        &nbsp;</td>
            <td class="style14" align="right" >
        
                                   <%--     <asp:ImageButton ID="RunCMD" runat="server" ImageUrl="~/Images/Icons/Run.gif"
                                        Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                                        ToolTip="Run" onclick="RunCMD_Click" />--%>

                 <asp:LinkButton ID="RunCMD" runat="server" 
                                        ToolTip="Run" OnClick="RunCMD_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-bolt"></i> Run</asp:LinkButton>
        
                                                                                                                                              
            </td>
            <td class="style8">
                <h3>
                    <asp:Label ID="lblrecordsCounts" runat="server" style="text-align: center"></asp:Label>
                </h3>
            </td>
        </tr>
        </table>
     
                                                                                                                                              
      <table class="style7" style="width:100%;">
          <tr>
              <td class="style18" colspan="5" bgcolor="#FFCC66">
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style18">
                  </td>
              <td class="style18" align="right">
                Course 
              </td>
              <td class="style20">
                  <asp:TextBox ID="txtCourse" runat="server" 
                      ontextchanged="txtCourse_TextChanged"  CssClass="form-control" ></asp:TextBox>
              </td>
              <td class="style19">
                <asp:DropDownList ID="DdlCourses" runat="server" DataSourceID="SDSCourses" DataTextField="strCourse" 
                    DataValueField="strCourse" 
                     CssClass="form-control"  AutoPostBack="True" 
                      onselectedindexchanged="DdlCourses_SelectedIndexChanged"
                      ondatabound="DdlCourses_DataBound">
                </asp:DropDownList>
              </td>
              <td>
                <asp:DropDownList ID="DdlCourseName" runat="server" DataSourceID="SDSCourses" DataTextField="strCourseDescEn" 
                    DataValueField="strCourse"  CssClass="form-control"  AutoPostBack="True" 
                      onselectedindexchanged="DdlCourseName_SelectedIndexChanged"
                      ondatabound="DdlCourseName_DataBound">
                </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="style15">
                </td>
              <td class="style15" align="right">
                Institute</td>
              <td colspan="3">
                <asp:DropDownList ID="DdlInstitute" runat="server" 
                    DataSourceID="SqlDataSourceInstitute" DataTextField="strCollegeDescEn" 
                    DataValueField="byteCollege" 
                     CssClass="form-control" 
                    ondatabound="DdlInstitute_DataBound">
                </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td align="right">
                Grade</td>
              <td class="style13" colspan="2">
                <asp:DropDownList ID="DdlGrade" runat="server" 
                     CssClass="form-control" >
                    <asp:ListItem>EX</asp:ListItem>
                    <asp:ListItem>TC</asp:ListItem>
                    <asp:ListItem>EQ</asp:ListItem>
                    <asp:ListItem Selected="True" Value="-1">Select Grade</asp:ListItem>
                </asp:DropDownList>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td colspan="5">
                  <hr /></td>
          </tr>
          </table>

        <div align="center">
          <table class="">
              <tr>
                  <td class="">
                      &nbsp;</td>
                  <td>
                      <asp:ImageButton ID="SaveCMD" runat="server" ImageUrl="~/Images/Icons/Save.gif" 
                          onclick="SaveCMD_Click" 
                          Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                          ToolTip="Save" ValidationGroup="isValid" />
                  </td>
                  <td>
                      <asp:ImageButton ID="DeleteCMD" runat="server" 
                          ImageUrl="~/Images/Icons/Delete.gif" onclick="DeleteCMD_Click" 
                          Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                          ToolTip="Delete" Enabled="False" />
                  </td>
                  <td>
                      <asp:ImageButton ID="printCMD" runat="server" 
                          ImageUrl="~/Images/Icons/Print.gif" onclick="printCMD_Click" 
                          Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                          ToolTip="Print" />
                  </td>
              </tr>
            </table>
        </div>        
     
        <div align="center">                                                                                                                                                  
            <asp:GridView ID="grdStudentGrades" runat="server" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" 
            BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="771px" 
            Height="254px" DataSourceID="SqlDataSourceStudentGrades"  
            CssClass="TableStyle" 
            OnRowUpdating ="grdStudentGrades_RowUpdating" 
            OnRowEditing ="grdStudentGrades_RowEditing" PageSize="50" 
            AutoGenerateColumns="False" 
        
        
            DataKeyNames="intStudyYear,byteSemester,byteShift,strCourse,byteClass,lngStudentNumber,byteRefCollege" 
            onselectedindexchanged="grdStudentGrades_SelectedIndexChanged" 
            onrowdatabound="grdStudentGrades_RowDataBound" >
        
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Font-Size="Small" />
            <Columns>
          
     
                <asp:BoundField DataField="#" HeaderText="#" ReadOnly="True" 
                    SortExpression="#" />
          
     
                <asp:CommandField ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
          
     
                <asp:BoundField DataField="intStudyYear" HeaderText="StudyYear" ReadOnly="True" 
                    SortExpression="intStudyYear" Visible="False" />
            
                <asp:BoundField DataField="byteSemester" HeaderText="byteSemester" ReadOnly="True" 
                    SortExpression="byteSemester" Visible="False" />
                <asp:BoundField DataField="byteShift" HeaderText="byteShift" ReadOnly="True" 
                    SortExpression="byteShift" Visible="False" />
                <asp:BoundField DataField="strCourse" HeaderText="Course" 
                    ReadOnly="True" SortExpression="strCourse" />
                <asp:BoundField DataField="byteClass" HeaderText="byteClass" ReadOnly="True" 
                    SortExpression="byteClass" Visible="False" />
                <asp:BoundField DataField="lngStudentNumber" HeaderText="lngStudentNumber" 
                    ReadOnly="True" SortExpression="lngStudentNumber" Visible="False" />
                <asp:BoundField DataField="strGrade" HeaderText="Grade" 
                    SortExpression="strGrade" />
          
                <asp:BoundField DataField="byteRefCollege" HeaderText="InstituteID" 
                    SortExpression="byteRefCollege" Visible="true"/>
                <asp:BoundField DataField="strDegree" HeaderText="Degree" 
                    SortExpression="strDegree" Visible="False" />
                <asp:BoundField DataField="strMajor" HeaderText="Major" 
                    SortExpression="strMajor" Visible="False" />
           
                <asp:BoundField DataField="strUserCreate" HeaderText="User" 
                    SortExpression="strUserCreate" />
                <asp:BoundField DataField="dateCreate" DataFormatString="{0:dd/MM/yyy}" 
                    HeaderText="Created" SortExpression="dateCreate" />
           
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" 
                Height="45px" Wrap="True" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        </div>
      
       
        <div align="center">
         <asp:Button ID="btnESLExemption" runat="server" onclick="Button1_Click" 
             Text="ESL Exemption" Width="139px" Height="30px" 
                    ToolTip="Click to Calc ESL Courses" Visible="False" />
        </div>
        
       
   
    <br />
      
       
   
                <asp:SqlDataSource ID="SDSCourses" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                    
        
        SelectCommand="SELECT [strCourse], [strCourseDescEn] FROM [Reg_Courses] WHERE ([IsActive] = @IsActive) or [strCourse]='bit301' ORDER BY [strCourse]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="IsActive" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                  <asp:SqlDataSource ID="SqlDataSourceInstitute" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
        SelectCommand="SELECT [byteCollege], [strCollegeDescEn] FROM [Lkp_Foreign_Colleges] ORDER BY [strCollegeDescEn]">
    </asp:SqlDataSource>
                <asp:HiddenField ID="DataStatus" runat="server" />
                <asp:HiddenField ID="isDataChanged" runat="server" />
      
       
   
  <asp:HiddenField ID="sSelectedText" runat="server" />
   
  <asp:HiddenField ID="sSelectedValue" runat="server" />
  <asp:SqlDataSource 
        ID="SqlDataSourceStudentGrades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
        
        
        
        
        SelectCommand="SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber, strGrade, byteRefCollege, strDegree, strMajor, strUserCreate, dateCreate,ROW_NUMBER() OVER (ORDER BY dateCreate DESC) AS # FROM Reg_Grade_Header WHERE (lngStudentNumber = @lngStudentNumber) AND (strGrade = N'TC' OR strGrade = N'EX' OR strGrade = N'EQ' OR strGrade = N'NC') ORDER BY dateCreate DESC">
       
       
        <%-- DeleteCommand="DELETE FROM [Reg_Grade_Header] WHERE [intStudyYear] = @intStudyYear AND [byteSemester] = @byteSemester AND [byteShift] = @byteShift AND [strCourse] = @strCourse AND [byteClass] = @byteClass AND [lngStudentNumber] = @lngStudentNumber" --%>

        <SelectParameters>
           <asp:ControlParameter ControlID="sSelectedValue" Name="lngStudentNumber" 
               PropertyName="Value" Type="String" />
       </SelectParameters>
       
     <%--<DeleteParameters>
            <asp:Parameter Name="intStudyYear" Type="Int16" />
            <asp:Parameter Name="byteSemester" Type="Int16" />
            <asp:Parameter Name="byteShift" Type="Int16" />
            <asp:Parameter Name="strCourse" Type="String" />
            <asp:Parameter Name="byteClass" Type="Int16" />
            <asp:Parameter Name="lngStudentNumber" Type="String" />
        </DeleteParameters>--%>
       
               
    </asp:SqlDataSource>
    
            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>