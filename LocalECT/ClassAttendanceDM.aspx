<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassAttendanceDM.aspx.cs" Inherits="LocalECT.ClassAttendanceDM" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                     <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Classes /</a>
                        <a href="#">&nbsp;Classes Attendance</a>

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
                                     #divDetail
        {
            text-align: center;
        }
        .style8
        {
            height: 50px;
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
 <div>
        <table width="100%">
            <tr>
                <td colspan="5"><div id="divMsg" runat="server" class="NoData"></div></td>
            </tr>
            <tr>
                <th colspan="5" class="PageTitle">Classes Attendance</th>
            </tr>
            <tr>
                <td align="right" colspan="4" style="text-align: center">
                        <table>
                            <tr>
                                <td>
                    <asp:ImageButton ID="BackCMD" runat="server" ImageUrl="~/Images/Icons/Prev_Column.gif"
                    Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                    ToolTip="Back to Classes" onclick="BackCMD_Click" Height="41px" Width="43px" />
                                </td>
                                <td>
                    <asp:ImageButton ID="SaveCMD" runat="server" ImageUrl="~/Images/Icons/Save.gif"
                    Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                    ToolTip="Save" onclick="SaveCMD_Click"  />
                                </td>
                                <td>
                    <asp:TextBox ID="txt_date" runat="server" Enabled="False" Width="107px"></asp:TextBox>
                                </td>
                                <td>
                    <asp:ImageButton ID="CalendarBTN" runat="server" 
                        ImageUrl="~/Images/Icons/Calender.gif" onclick="CalendarBTN_Click" 
                        ToolTip="Show Calendar" />
                                </td>
                            </tr>
                        </table>
                </td>
                <td rowspan="3">
                    <asp:Calendar ID="dCalender" runat="server" Font-Size="X-Small" Height="50px" 
                        onselectionchanged="dCalender_SelectionChanged" Visible="False" Width="100px">
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="style8">
                    <h4>
                        <asp:Label ID="Label3" runat="server" Text="Set all to" Font-Size="Small" 
                            style="text-align: center"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlChangeAllStatuses" runat="server" 
                            Width="140px" Height="34px">
                            <asp:ListItem Value="-1">Select Status</asp:ListItem>
                            <asp:ListItem Value="5">Absent</asp:ListItem>
                            <asp:ListItem Value="1">Attended</asp:ListItem>
                        </asp:DropDownList>
&nbsp;<asp:Button ID="btnChangeStatus" runat="server"  onclick="btnChangeStatus_Click" 
                            Text="Set" CssClass="btn btn-success btn-sm"/>
                    </h4>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                        <asp:Label ID="lblSaveNotification" runat="server" 
                            style="color: #0000FF" 
                            Text="Please click Save button to save changes"></asp:Label>
                    </td>
                <td>&nbsp;</td>
            </tr>
            <style>
                #ContentPlaceHolder1_MyTable{
                    width:100%;
                }
            </style>
            </table>
    </div>
    <div id="divDetail" runat="server" style="text-align:center; width: 100%;"></div>
    <table width="100%" bgcolor="#f7f7f7">
        <tr>
                <td colspan="5"><hr /></td>
            </tr>
            <tr>
                <td colspan="5" class="style8">&nbsp;<asp:Image ID="Image2" runat="server" 
                        ImageUrl="~/Images/Icons/info.jpg" Width="35px" Height="35px" 
                        ToolTip="Contact the Administration" />
&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" 
                        Text="Please contact the administration " 
                        Font-Size="Small" Font-Bold="True"></asp:Label>
                    <asp:Image ID="Image3" runat="server" 
                        ImageUrl="~/Images/Icons/Question.png" Width="35px" Height="35px" 
                        ToolTip="Stritcly Contact the Administration" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/star.gif" 
                        Visible="False" />
&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red" 
                        
                        Text="Star Symbol means that the Student Expected to graduate by the End of Current Semester." 
                        Font-Size="Small" Font-Bold="True" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5"><hr /></td>
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
    </asp:Content>