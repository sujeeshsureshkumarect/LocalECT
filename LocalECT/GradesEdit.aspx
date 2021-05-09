<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradesEdit.aspx.cs" Inherits="LocalECT.GradesEdit" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Grades Edit</a>
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
       .TableSize
        {
            width:800px;
            
        }
        .ComboWidth
        {
        	margin-left: 1px;
            margin-bottom: 0px;
        }
  
   
  
        .style11
        {
            width: 49px;
            height: 44px;
        }
        .style12
        {
            width: 41px;
            height: 44px;
        }
        .style17
        {
            height: 44px;
        }
        .style20
        {
            width: 14px;
        }
          
   
  
        .style27
        {
            height: 52px;
        }
        .style28
        {
            width: 120px;
            height: 52px;
        }
        .style29
        {
            width: 133px;
            height: 52px;
        }
  
   
  
        .style30
        {
            height: 31px;
        }
        .style31
        {
            width: 120px;
            height: 31px;
        }
        .style32
        {
            width: 133px;
            height: 31px;
        }
  
   
  
        .style33
        {
            width: 32px;
            height: 33px;
        }
        .style34
        {
            width: 46px;
            height: 33px;
        }
  
   
  
        .style41
        {
            height: 33px;
        }
        .style42
        {
            width: 120px;
            height: 33px;
        }
  
   
  
        .style43
        {
            width: 690px;
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
            case "EW":
            case "W":
            case "I":
            case "Pass":
            case "Fail":
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
                                            <h2><i class="fa fa-edit"></i> Grades Edit</h2>
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
                                            <div>
                                                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="isValid" style="text-align: center" />
                                            </div>
                                            <div class="x_panel">
                                                <div class="col-md-12 col-sm-12">
                                                    <div class="col-md-4 col-sm-4" id="terms1" runat="server">
                                                        <div class="form-group">
                                                            <label>Term</label>
                                                            <div class="input-group">
                                                                <asp:DropDownList ID="Terms" runat="server"
                                                                    Style="margin-left: 0px" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="Terms_SelectedIndexChanged" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div>
                                                           <asp:GridView ID="grdStudentGrades" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%"
        AllowPaging="True" 
        AllowSorting="True" DataSourceID="SqlDataSourceStudentGrades"  
        CssClass="TableStyle" 
        OnRowUpdating ="grdStudentGrades_RowUpdating" 
        OnRowEditing ="grdStudentGrades_RowEditing" PageSize="7" 
        AutoGenerateColumns="False" 
        
        
        DataKeyNames="byteShift,byteClass,strCourse" 
        EnableModelValidation="True" 
        onselectedindexchanged="grdStudentGrades_SelectedIndexChanged" >
        
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Font-Size="Small" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
            <asp:BoundField DataField="byteShift" HeaderText="byteShift" 
                SortExpression="byteShift" Visible="False" />
            <asp:BoundField DataField="byteClass" HeaderText="byteClass" 
                SortExpression="byteClass" Visible="False" />
            <asp:BoundField DataField="strCourse" HeaderText="Course" 
                SortExpression="strCourse" />
            <asp:BoundField DataField="strDesc" HeaderText="Desc" 
                SortExpression="strDesc" />
            <asp:BoundField DataField="strGrade" HeaderText="Grade" 
                SortExpression="strGrade" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" 
            Height="45px" Wrap="True" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
                                                    </div>

                                                    <div>
                                                        <%--<hr />--%>
                                                              <table style="width:100%;">       
          <tr>
              <td >
                  </td>
              <td >
                Course 
              </td>
              <td >
                  <asp:TextBox ID="txtCourse" runat="server" 
                      ontextchanged="txtCourse_TextChanged" CssClass="form-control" ReadOnly="True"></asp:TextBox>
              </td>
              <td >
                <asp:DropDownList ID="DdlCourses" runat="server" DataSourceID="SDSCourses" DataTextField="strCourse" 
                    DataValueField="strCourse" 
                    CssClass="form-control"
                      onselectedindexchanged="DdlCourses_SelectedIndexChanged"
                      ondatabound="DdlCourses_DataBound" AutoPostBack="True" Enabled="False">
                </asp:DropDownList>
              </td>
              <td >
                <asp:DropDownList ID="DdlCourseName" runat="server" DataSourceID="SDSCourses" DataTextField="strCourseDescEn" 
                    DataValueField="strCourse" CssClass="form-control" AutoPostBack="True" 
                      onselectedindexchanged="DdlCourseName_SelectedIndexChanged"
                      ondatabound="DdlCourseName_DataBound" Enabled="False">
                </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td >
                  </td>
              <td >
                Grade</td>
              <td  colspan="2">
                <asp:DropDownList ID="DdlGrade" runat="server" 
                    CssClass="form-control">
                    <asp:ListItem Selected="True" Value="-1">Select Grade</asp:ListItem>
                    <asp:ListItem>EW</asp:ListItem>
                    <asp:ListItem>W</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>NG</asp:ListItem>
                    <asp:ListItem>Pass</asp:ListItem>
                    <asp:ListItem>Fail</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
              </td>
              <td >
                  &nbsp;</td>
          </tr>
       <%--   <tr>
              <td>
                  </td>
              <td >
     
    
     
              </td>
              <td class="style29" colspan="2">
                  &nbsp;</td>
              <td class="style27">
                  <asp:Button ID="btnGradesRounding" runat="server" Height="32px" 
                      onclick="btnGradesRounding_Click" Text="Update grades rounding" 
                      Enabled="False" Visible="False" CssClass="btn btn-success btn-sm"/>
                  </td>
          </tr>--%>
    </table>
                                                        <br />
       <table>
          <tr>
              <td >
                  <asp:LinkButton ID="SaveCMD" runat="server" 
                      onclick="SaveCMD_Click"                      
                      ToolTip="Save" ValidationGroup="isValid" CssClass="btn btn-success btn-sm"><i class="fa fa-save"></i> Save</asp:LinkButton>
              </td>
              <td >
                  <asp:LinkButton ID="DeleteCMD" runat="server" 
                      onclick="DeleteCMD_Click"                      
                      ToolTip="Delete" Enabled="False" CssClass="btn btn-danger btn-sm"><i class="fa fa-trash"></i> Delete</asp:LinkButton>
              </td>
              <td >
                  <asp:Button ID="btnGradesRounding" runat="server" Height="32px" 
                      onclick="btnGradesRounding_Click" Text="Update grades rounding" 
                      Enabled="False" Visible="False" CssClass="btn btn-success btn-sm"/></td>
          </tr>
    </table>
       
   
  <asp:HiddenField ID="sSelectedText" runat="server" />
  <asp:HiddenField ID="sSelectedValue" runat="server" />
                <asp:HiddenField ID="isDataChanged" runat="server" />
      
       
   
                <asp:HiddenField ID="DataStatus" runat="server" />
    <asp:SqlDataSource ID="SqlDataSourceStudentGrades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
        DeleteCommand="DELETE FROM [Reg_Grade_Header] WHERE [intStudyYear] = @intStudyYear AND [byteSemester] = @byteSemester AND [byteShift] = @byteShift AND [strCourse] = @strCourse AND [byteClass] = @byteClass AND [lngStudentNumber] = @lngStudentNumber" 
        InsertCommand="INSERT INTO [Reg_Grade_Header] ([intStudyYear], [byteSemester], [byteShift], [strCourse], [byteClass], [lngStudentNumber], [strGrade]) VALUES (@intStudyYear, @byteSemester, @byteShift, @strCourse, @byteClass, @lngStudentNumber, @strGrade)" 
        SelectCommand="SELECT CB.Shift AS byteShift, CB.Class AS byteClass, CB.Course AS strCourse, C.strCourseDescEn AS strDesc, GH.strGrade FROM Reg_Courses AS C INNER JOIN Course_Balance_View_Eq AS CB ON C.strCourse = CB.Course LEFT OUTER JOIN Reg_Grade_Header AS GH ON CB.iYear = GH.intStudyYear AND CB.Sem = GH.byteSemester AND CB.Shift = GH.byteShift AND CB.Course = GH.strCourse AND CB.Class = GH.byteClass AND CB.Student = GH.lngStudentNumber WHERE (CB.iYear = @iYear) AND (CB.Sem = @Sem) AND (CB.Student = @Student) AND (GH.strGrade = N'EW' OR GH.strGrade = N'W' OR GH.strGrade = N'I' OR GH.strGrade = N'F' OR GH.strGrade = N'NG' OR GH.strGrade = N'Fail' OR GH.strGrade IS NULL)" 
        
        
        
        UpdateCommand="UPDATE [Reg_Grade_Header] SET [strGrade] = @strGrade WHERE [intStudyYear] = @intStudyYear AND [byteSemester] = @byteSemester AND [byteShift] = @byteShift AND [strCourse] = @strCourse AND [byteClass] = @byteClass AND [lngStudentNumber] = @lngStudentNumber">
        <SelectParameters>
            <asp:ControlParameter ControlID="iYear" Name="iYear" 
                PropertyName="Value" DefaultValue="0" />
            <asp:ControlParameter ControlID="iSemester" Name="Sem" 
                PropertyName="Value" DefaultValue="0" />
            <asp:ControlParameter ControlID="sSelectedValue" Name="Student" 
                PropertyName="Value" DefaultValue="0" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="intStudyYear" Type="Int16" />
            <asp:Parameter Name="byteSemester" Type="Int16" />
            <asp:Parameter Name="byteShift" Type="Int16" />
            <asp:Parameter Name="strCourse" Type="String" />
            <asp:Parameter Name="byteClass" Type="Int16" />
            <asp:Parameter Name="lngStudentNumber" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="strGrade" Type="String" />
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
            <asp:Parameter Name="strGrade" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
      
       
   
                <asp:SqlDataSource ID="SDSCourses" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                    
        
        
        SelectCommand="SELECT [strCourse], [strCourseDescEn] FROM [Reg_Courses] ORDER BY [strCourse]">
                </asp:SqlDataSource>
     
                                                                                                                                              
   
  <asp:HiddenField ID="iSemester" runat="server" />
     
                                                                                                                                              
   
  <asp:HiddenField ID="iYear" runat="server" />
     
                                                    </div>


                                                </div>

                                                </div>
            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>