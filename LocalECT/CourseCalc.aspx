<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseCalc.aspx.cs" Inherits="LocalECT.CourseCalc" MasterPageFile="~/LocalECT.Master"%>
<%--<%@ Register src="~/Search1.ascx" tagname="Search1" tagprefix="uc1" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                               <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Course Calc</a>
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
                                            <h2><i class="fa fa-calculator"></i> Course(s) Calculation</h2>
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

                                                <table class="TableSize" style="width:100%;">       
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="isValid" style="text-align: center" />
            </td>
        </tr>               
    </table>
                                                                                                                                              
   

     
                                                                                                                                              
      <table class="style7" style="width:100%;">
          <tr>
              <td class="style18">
                  </td>
              <td class="style18" align="right">
                Course 
              </td>
              <td class="">
                  <asp:TextBox ID="txtCourse" runat="server" 
                      ontextchanged="txtCourse_TextChanged"  CssClass="form-control" ></asp:TextBox>
              </td>
              <td class="">
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
                      <asp:LinkButton ID="SaveCMD" runat="server" 
                          onclick="SaveCMD_Click"                           
                          ToolTip="Save" ValidationGroup="isValid" CssClass="btn btn-success btn-sm"><i class="fa fa-save"></i> Save</asp:LinkButton>
                  </td>
                  <td>
                      <asp:LinkButton ID="DeleteCMD" runat="server" 
                           onclick="DeleteCMD_Click"                           
                          ToolTip="Delete" Enabled="False" CssClass="btn btn-danger btn-sm"><i class="fa fa-trash"></i> Delete</asp:LinkButton>
                  </td>
                  <td>
                      <asp:LinkButton ID="printCMD" runat="server" 
                           onclick="printCMD_Click"                           
                          ToolTip="Print" CssClass="btn btn-success btn-sm"><i class="fa fa-print"></i> Print</asp:LinkButton>
                  </td>
              </tr>
            </table>
        </div>        
     
        <div align="center">                                                                                                                                                  
            <asp:GridView ID="grdStudentGrades" runat="server" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" 
            BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%" 
             DataSourceID="SqlDataSourceStudentGrades"  
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
             Text="ESL Exemption" ToolTip="Click to Calc ESL Courses" Visible="False" CssClass="btn btn-success btn-sm"/>
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