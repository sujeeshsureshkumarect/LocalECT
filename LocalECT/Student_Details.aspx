<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Details.aspx.cs" Inherits="LocalECT.Student_Details" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Student Details</a>
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
                     caption {
    padding-top: .75rem;
    padding-bottom: .75rem;
    font-weight:bold;
    text-align: center !important;
    caption-side: top !important;
    /*color:#444444 !important;*/
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    /* border-left: white thin solid; */
    color: #ECF0F1 !important;
    /* border-bottom: white thin solid; */
    font-family: Arial, Helvetica, sans-serif;
    background-color: #3f658c;
    text-align: center;
    line-height: 2;
    font-size: 13px;
}
                    .page-title .title_left {
                        width: 100%;
                        float: left;
                        display: block;
                    }
                </style>
                <style>
table {
 /* font-family: arial, sans-serif;*/
  border-collapse: collapse;
 /* width: 100%;*/
}
#ContentPlaceHolder1_grdFees td,th{
    border:1px solid #dddddd;
}
#ContentPlaceHolder1_grdCheques td,th{
     border:1px solid #dddddd;
}
#ContentPlaceHolder1_grdTimeTable td,th{
     border:1px solid #dddddd;
}
#ContentPlaceHolder1_grdPayment td,th{
    border:1px solid #dddddd;
}
#studentbalance td,th{
    border:1px solid #dddddd;
}
#gpa td,th{
    border:1px solid #dddddd;
}
td, th {
 /* border: 1px solid #dddddd;*/
 /* text-align: left;*/
 /* padding: 5px;*/
}

#gpa tr:nth-child(even) {
  background-color: #eff3fb;
}
 .table {
                        color: #444444;
                    }
                    #ContentPlaceHolder1_tblDetail{
                        border: 1px solid #dee2e6
                    }
                      #ContentPlaceHolder1_tblDetail  th, td {
  padding-bottom: 7px;
  padding-top: 7px;
}
</style>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-table"></i> Student Details</h2>
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
                             <div id="divMsg" runat="server" class="NoData"></div>
                            <div class="x_panel" id="student_Details">
                                                  <div id="divPlan" runat="server">
                                                </div>

                                <div id="setopportunity" style="display: flex;justify-content: center;">
                                    <br /><br />
                                   <div class="col-sm-6 col-md-6 col-xs-12 x_panel">  
                                       <p style="color:red;text-align:center"><b>Note:</b> The default (Admission Payment Value) of AED 3500 is requested from the student if you set (Pending Payment) option.<br />Contact the Accoutant if you need to change the (Admission Payment Value) please.</p>
                                       <div class="form-group row">
                                                    <label class="col-form-label col-md-4 col-sm-4"><b>Current Opportunity</b></label>
                                                    <div class="col-md-5 col-sm-5">
                                                         <asp:DropDownList ID="drp_setstatus" runat="server" CssClass="form-control">
                                               <asp:ListItem Text="Pending Payment" Value="0"></asp:ListItem>
                                               <asp:ListItem Text="Payment Succeeded" Value="1"></asp:ListItem>
                                           </asp:DropDownList>
                                                    </div>
                                           <div class="col-md-3 col-sm-3 ">
                                               <asp:LinkButton ID="lnk_setOpportunity" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_setOpportunity_Click" OnClientClick="return confirm('Are you sure to you want to update the CX Opportunity Status?')"><i class="fa fa-save"></i> Set</asp:LinkButton>
                                               </div>
                                                </div>                                  
                                </div> 
                                </div>
                                <asp:HiddenField ID="hdn_Acc" runat="server" Value="0"/>
                                <asp:HiddenField ID="hdn_iOpportunityID" runat="server" value="0"/>
                                <asp:HiddenField ID="hdn_Phone1" runat="server" value="0"/>

                                                </div>
                           
                                <table style="width:100%;">
       <%-- <tr>
            <td colspan="2">
            <div id="divMsg" runat="server" class="NoData"></div>
            </td>
        </tr>
        <tr style="display:none;">
            <th colspan="2">
                        Account Search</th>
        </tr>--%>
        <tr style="display:none;">
            <td >
                                         <asp:Label ID="Label18" runat="server" Text="Campus :" 
                            Width="100px" style="margin-bottom: 0px"></asp:Label>
            </td>
            <td >
                                         <asp:DropDownList ID="Campus_ddl" runat="server" Width="120px" 
                                             AutoPostBack="True" 
                                             onselectedindexchanged="Campus_ddl_SelectedIndexChanged">
                                             <asp:ListItem Value="1">Males</asp:ListItem>
                                             <asp:ListItem Selected="True" Value="2">Females</asp:ListItem>
                                         </asp:DropDownList>
            </td>
        </tr>
        
        <%--<tr>
            <td width="20%" >
                                         <asp:Label ID="Label19" runat="server" 
                    Text="Student :"></asp:Label>
            </td>
            <td align="left" width="80%" >
                                        <ihab:Search ID="Search1" runat="server" Campus="Females" IsSelected="False" 
                                            SCaption1="ID" SCaption2="Name" SCaption3="Account" SCaption4="Phone"
                                            SField1="sNo" SField2="sName" SField3="sAccount" SField4="sPhone" 
                                            SSQL="SELECT sNo, sName, sAccount, sPhone  FROM Web_Acc_Search"  />
            </td>
        </tr>--%>
        
        <tr>
            <td colspan="2" align="center">
                <div id="divAccNotification" runat="server" class="Notification">
                </div>
            </td>
        </tr>
        
        <tr style="display:none;">
            <td colspan="2" align="center">
                <table>
                    <tr align="center">
                        <td>
                            <asp:LinkButton ID="Balance_lnk" runat="server" oncommand="lnk_Command">Balance</asp:LinkButton>
                        </td>
                        <td align="center">
                            |</td>
                        <td class="style11">
                            <asp:LinkButton ID="Account_lnk" runat="server" oncommand="lnk_Command">Account</asp:LinkButton>
                        </td>
                        <td align="center">
                            |</td>
                        <td>
                            <asp:LinkButton ID="Testimony_Lnk" runat="server" oncommand="lnk_Command">Quotation</asp:LinkButton>
                        </td>
                        <td>
                            |</td>
                        <td>
                            <asp:LinkButton ID="New_lnk" runat="server" oncommand="lnk_Command">Create New</asp:LinkButton>
                        </td>
                        
                    </tr>
                </table>
            </td>
        </tr>
        
      <%--  <tr>
            <td colspan="2" align="center">
                <hr/></td>
        </tr>--%>
        
        <tr>
            <td colspan="2" align="center">
                <table style="width:100%;" id="gpa">
                  <%--  <tr>
                        <td align="right" width="50%">
                                        &nbsp;</td>
                        <td>
                                        &nbsp;</td>
                    </tr>--%>
                    <tr style="display:none;">
                        <td align="right" width="50%">
                                        <asp:Label ID="Label33" runat="server" Text="Current Online Status"></asp:Label>
                        </td>
                        <td>
                                        <asp:DropDownList ID="ddlOnlineStatus" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlOnlineStatus_SelectedIndexChanged" Width="150px">
                                            <asp:ListItem Selected="True" Value="0">Inactive</asp:ListItem>
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                            <asp:ListItem Value="2">Fully Activated</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%">
                                        <asp:Label ID="Label53" runat="server" Text="Finance Category" 
                                BackColor="#99CCFF"></asp:Label>
                        </td>
                        <td>
                                        <asp:DropDownList ID="ddlFinanceCat" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlFinanceCat_SelectedIndexChanged" 
                                Width="150px" DataSourceID="FinCatDs" DataTextField="sFinDesc" 
                                            DataValueField="iFinCategory">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="FinCatDs" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ECTDataNew %>" 
                                            SelectCommand="SELECT [iFinCategory], [sFinDesc] FROM [Acc_Finance_Category] ORDER BY [iFinCategory]">
                                        </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%">
                                        <asp:Label ID="Label44" runat="server" Text="Has $ ? (Not In Use)" 
                                BackColor="#99CCFF" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                                        <asp:DropDownList ID="ddlFinance" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlFinance_SelectedIndexChanged" 
                                Width="150px">
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%">
                                        <asp:Label ID="Label45" runat="server" Text="Is ACC Wanted ?" 
                                BackColor="#FF3300"></asp:Label>
                        </td>
                        <td>
                                        <asp:DropDownList ID="ddlACCWanted" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlACCWanted_SelectedIndexChanged" 
                                Width="150px">
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%">
                                        <asp:Label ID="Label51" runat="server" Text="Reg Term" 
                                BackColor="#FFFF66"></asp:Label>
                        </td>
                        <td>
                                                           <asp:DropDownList ID="ddlRegTerm1" runat="server" CssClass="ComboHeight" 
                                                               Height="25px" 
                                                               style="margin-left: 0px" Width="150px" 
                                            AutoPostBack="True" onselectedindexchanged="ddlRegTerm1_SelectedIndexChanged">
                                                           </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%">
                            <asp:Label ID="lblMajorCaption" runat="server" Text="Current Major : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMajor" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%" class="style10">
                            <asp:Label ID="lblCGPACaption" runat="server" Text="Current CGPA : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:Label ID="lblCGPA" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="style10">
                            <asp:Label ID="lblFTRCaption" runat="server" Text="FTR : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:Label ID="lblFTR" runat="server" ForeColor="Black" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="style10">
                            <asp:Label ID="lblLTRCaption" runat="server" Text="LTR Both Side (F+M) : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:Label ID="lblLTRBS" runat="server" ForeColor="Black" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="style10">
                                                                       <asp:Label ID="lblOBalanceVATCaption" 
                                runat="server" Text="Student Balance (Current Side):" Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                                                                       <asp:Label ID="lblOBalanceCVAT" 
                                runat="server" ForeColor="Red" Visible="False">0</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="style10">
                                                                       <asp:Label ID="lblOBalanceVATCaptionBTS" 
                                runat="server" Text="Student Balance (Both Side(F+M)):" Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                                                                       <asp:Label ID="lblOBalanceVATBTS" 
                                runat="server" ForeColor="Red" Visible="False">0</asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;"> 
                        <td align="right" width="50%" class="style10">
                            <asp:Label ID="lblArNameCaption" runat="server" Text="Arabic Name : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:Label ID="lblArName" runat="server" ForeColor="Black" BorderStyle="Inset" 
                                BorderWidth="1px" Visible="False" Width="350px"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%" class="style10">
                            <asp:Label ID="lblLastDisCaption" runat="server" Text="Last Discount : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:ListBox ID="lstDis" runat="server" Height="40px" Visible="False" 
                                Width="350px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%" class="style10">
                            <asp:Label ID="lblRefCaption" runat="server" Text="Reference : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:Label ID="lblRef" runat="server" ForeColor="Black" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%" class="style10">
                            <asp:Label ID="lblLastRefDisCaption" runat="server" Text="Last Ref Discount : " 
                                Visible="False" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:ListBox ID="lstRefDis" runat="server" Height="40px" Visible="False" 
                                Width="350px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" width="50%">
                            &nbsp;</td>
                        <td class="style10">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" width="50%">
                    <asp:HiddenField ID="sSelectedText" runat="server" />
                        </td>
                        <td>
                    <asp:HiddenField ID="sSelectedValue" runat="server" />
                    
                        </td>
                    </tr>
                   
                </table>
            </td>
        </tr>
        
        
        
        <tr>
            <td  colspan="2">
                                       <hr /></td>
        </tr>
        
        
        
        <tr>
            <td  colspan="2">
                                       <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                           <asp:View ID="View1" runat="server">
                                               
                                                   <table style="width:100%;" id="TimeTable">
                                                       <tr>
                                                           <th colspan="4">
                                                               <asp:Label ID="Label20" runat="server" Text="Time Table"></asp:Label>
                                                           </th>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblTerm" runat="server" Text="Term :" Font-Bold="true"></asp:Label>
                                                           </td>
                                                           <td colspan="3" align="left" width="60%">
                                                               <asp:DropDownList ID="Terms" runat="server" AutoPostBack="True" 
                                                                   CssClass="ComboHeight" Height="25px" 
                                                                   onselectedindexchanged="Terms_SelectedIndexChanged" style="margin-left: 0px" 
                                                                   Width="150px">
                                                               </asp:DropDownList>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td width="30%" >
                                                           </td>
                                                           <th>
                                                               Male</th>
                                                           <th>
                                                               Female</th>
                                                           <td>
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblCGPACaption2" runat="server" Text="Registered (CRS) : " Font-Bold="true"></asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblRegM" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblRegF" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               &nbsp;</th>
                                                           <th align="center">
                                                               General</th>
                                                           <th align="center">
                                                               Core</th>
                                                           <th align="center">
                                                               Total</th>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblMajorCaption0" runat="server" 
                                                                   Text="Previously Registered (HRS) : " Font-Bold="true"></asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblPRegGen" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblPRegCore" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblPReg" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblMajorCaption1" runat="server" 
                                                                   Text="Currently Registered (HRS) : " Font-Bold="true"></asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblCRegGen" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblCRegCore" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblCReg" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblMajorCaption2" runat="server" 
                                                                   Text="Completed Successfully (HRS) : " Font-Bold="true"></asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblCompletedGen" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblCompletedCore" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblCompleted" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblMajorCaption3" runat="server" Text="Total (HRS) : " Font-Bold="true"></asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblTotalGen" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblTotalCore" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblTotal" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblMajorCaption14" runat="server" Text="Remaining (HRS) : " Font-Bold="true"></asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblRemainingGen" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblRemainingCore" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               <asp:Label ID="lblRemaining" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                       </tr>
                                                       <tr style="display:none;">
                                                           <td align="right" width="30%">
                                                               <asp:Label ID="lblMajorCaption4" runat="server" Text="Old Rate (CR/AED) : "></asp:Label>
                                                           </td>
                                                           <td align="center">
                                                               &nbsp;</td>
                                                           <td align="center">
                                                               &nbsp;</td>
                                                           <td align="center">
                                                               <asp:Label ID="lblRate" runat="server" ForeColor="Red">0</asp:Label>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right" colspan="4">
                                                               <hr />
                                                           </td>                                                           
                                                       </tr>
                                                       <tr>
                                                           <td align="right" colspan="4">
                                                            
                                                               <asp:GridView ID="grdTimeTable" runat="server" AutoGenerateColumns="False" 
                                                                   Caption="Registered Courses" CaptionAlign="Top" CellPadding="4" 
                                                                   DataSourceID="TMDS" 
                                                                   EmptyDataText="Select a student or the selected student is not registered ..." 
                                                                   ForeColor="#333333" GridLines="None" Width="100%">
                                                                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                   <RowStyle BackColor="#EFF3FB" />
                                                                   <EmptyDataRowStyle BackColor="#f7f7f7" ForeColor="Red" HorizontalAlign="Center" 
                                                                       VerticalAlign="Middle" />
                                                                   <Columns>
                                                                       <asp:BoundField DataField="Session" HeaderText="Session" 
                                                                           SortExpression="Session" />
                                                                       <asp:BoundField DataField="Course" HeaderText="Course" 
                                                                           SortExpression="Course" />
                                                                       <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
                                                                       <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                                           SortExpression="Lecturer" />
                                                                       <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                                           HeaderText="From" SortExpression="TimeFrom" />
                                                                       <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}" 
                                                                           HeaderText="To" SortExpression="TimeTo" />
                                                                       <asp:BoundField DataField="Days" HeaderText="Days" />
                                                                       <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                       <asp:BoundField DataField="strGrade" HeaderText="EW/W" />
                                                                   </Columns>
                                                                   <PagerStyle BackColor="#ededed" ForeColor="#333333" HorizontalAlign="Center" />
                                                                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                   <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                                                                       VerticalAlign="Middle" Wrap="True" />
                                                                   <EditRowStyle BackColor="#2461BF" />
                                                                   <AlternatingRowStyle BackColor="White" />
                                                               </asp:GridView>
                                                            
                                                           </td>                                                           
                                                       </tr>
                                                       <tr>
                                                           <td align="right" colspan="4" style="display:none;">
                                                               <hr />
                                                           </td>                                                           
                                                       </tr>
                                                       <tr style="display:none;">
                                                           <td align="right" colspan="4">
                                                            
                                                               <asp:GridView ID="grdFees" runat="server" AutoGenerateColumns="False" 
                                                                   Caption="Term Fees" CaptionAlign="Top" CellPadding="4" 
                                                                   DataKeyNames="byteFeesNo" DataSourceID="FeesDS" EmptyDataText="No Fees" 
                                                                   ForeColor="#333333" GridLines="None" 
                                                                   onselectedindexchanged="grdFees_SelectedIndexChanged" Width="100%">
                                                                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                   <RowStyle BackColor="#EFF3FB"  />
                                                                   <EmptyDataRowStyle BackColor="#f7f7f7" ForeColor="Red" HorizontalAlign="Center" 
                                                                       VerticalAlign="Middle" />
                                                                   <Columns>
                                                                       <asp:CommandField SelectText="Edit" ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
                                                                       <asp:BoundField DataField="byteFeesNo" HeaderText="#" 
                                                                           SortExpression="byteFeesNo" />
                                                                       <asp:BoundField DataField="strFeesTypeEn" HeaderText="Fees" 
                                                                           SortExpression="strFeesTypeEn" />
                                                                       <asp:BoundField DataField="curDebit" DataFormatString="{0:f}" 
                                                                           HeaderText="Debit" SortExpression="curDebit" />
                                                                       <asp:BoundField DataField="curCredit" DataFormatString="{0:f}" 
                                                                           HeaderText="Credit" SortExpression="curCredit" />
                                                                       <asp:BoundField DataField="curVAT" DataFormatString="{0:f}" HeaderText="VAT" 
                                                                           SortExpression="curVAT" />
                                                                       <asp:BoundField DataField="strRemark" HeaderText="Remark" 
                                                                           SortExpression="strRemark" />
                                                                   </Columns>
                                                                   <PagerStyle BackColor="#ededed" ForeColor="#333333" HorizontalAlign="Center" />
                                                                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                   <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                                                                       VerticalAlign="Middle" Wrap="True" />
                                                                   <EditRowStyle BackColor="#2461BF" />
                                                                   <AlternatingRowStyle BackColor="White" />
                                                               </asp:GridView>
                                                            
                                                           </td>                                                           
                                                       </tr>
                                                       <tr>
                                                           <td align="right" colspan="4" style="display:none;">
                                                               <hr />
                                                           </td>                                                           
                                                       </tr>
                                                       <tr style="display:none;">
                                                           <td align="right" colspan="4">
                                                            
                                                               <asp:MultiView ID="MVCheque" runat="server" ActiveViewIndex="0">
                                                                   <asp:View ID="View7" runat="server">
                                                                       <asp:SqlDataSource ID="ChequesDS" runat="server" 
                                                                           ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                                           SelectCommand="SELECT VD.intFy * 10 + VD.byteFSemester AS Term, VD.strVoucherNo AS VNo, VD.lngEntryNo AS Serial, VD.datePayment AS EDate, C.strChequeNo AS CNo, B.strBankEn AS Bank, VD.curCredit AS Amount, VD.dateDue AS DueDate, CS.strChequeStatusEn AS Status FROM Reg_Student_Accounts AS AC INNER JOIN Acc_Cheques AS C INNER JOIN Acc_Voucher_Detail AS VD ON C.lngCheque = VD.lngCheque INNER JOIN Acc_Banks AS B ON VD.intBank = B.intBank INNER JOIN Acc_Cheques_Statuses AS CS ON VD.byteStatus = CS.byteChequeStatus ON AC.strAccountNo = VD.strAccountNo WHERE (AC.strAccountNo = @ACC) ORDER BY EDate DESC">
                                                                           <SelectParameters>
                                                                               <asp:ControlParameter ControlID="sSelectedText" DefaultValue="0" Name="ACC" 
                                                                                   PropertyName="Value" />
                                                                           </SelectParameters>
                                                                       </asp:SqlDataSource>
                                                                       <asp:GridView ID="grdCheques" runat="server" AllowPaging="True" 
                                                                           AutoGenerateColumns="False" Caption="All Cheques" CaptionAlign="Top" 
                                                                           CellPadding="4" DataKeyNames="Term,VNo,Serial" DataSourceID="ChequesDS" 
                                                                           EmptyDataText="No Cheques" ForeColor="#333333" GridLines="None" 
                                                                           onselectedindexchanged="grdCheques_SelectedIndexChanged" PageSize="5" 
                                                                           Width="100%">
                                                                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                           <RowStyle BackColor="#EFF3FB"  />
                                                                           <EmptyDataRowStyle BackColor="#f7f7f7" ForeColor="Red" HorizontalAlign="Center" 
                                                                               VerticalAlign="Middle" />
                                                                           <PagerStyle BackColor="#ededed" ForeColor="#333333" HorizontalAlign="Center" Font-Underline="true"/>
                                                                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                           <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                                                                               VerticalAlign="Middle" Wrap="True" />
                                                                           <Columns>
                                                                               <asp:CommandField ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
                                                                               <asp:BoundField DataField="Term" HeaderText="Term" ReadOnly="True" 
                                                                                   SortExpression="Term" />
                                                                               <asp:BoundField DataField="VNo" HeaderText="VNo" SortExpression="VNo" />
                                                                               <asp:BoundField DataField="Serial" HeaderText="Serial" 
                                                                                   SortExpression="Serial" />
                                                                               <asp:BoundField DataField="EDate" DataFormatString="{0:dd/MM/yyyy}" 
                                                                                   HeaderText="EDate" SortExpression="EDate" />
                                                                               <asp:BoundField DataField="CNo" HeaderText="CNo" SortExpression="CNo" />
                                                                               <asp:BoundField DataField="Bank" HeaderText="Bank" SortExpression="Bank" />
                                                                               <asp:BoundField DataField="Amount" DataFormatString="{0:f}" HeaderText="Amount" 
                                                                                   SortExpression="Amount" />
                                                                               <asp:BoundField DataField="DueDate" DataFormatString="{0:dd/MM/yyyy}" 
                                                                                   HeaderText="DueDate" SortExpression="DueDate" />
                                                                               <asp:BoundField DataField="Status" HeaderText="Status" 
                                                                                   SortExpression="Status" />
                                                                           </Columns>
                                                                           <EditRowStyle BackColor="#2461BF" />
                                                                           <AlternatingRowStyle BackColor="White" />
                                                                       </asp:GridView>
                                                                   </asp:View>
                                                                   <asp:View ID="View8" runat="server">
                                                                   <table style="width:100%;">
                                                                        <tr>
                                                                            <th colspan="5">
                                                                                <asp:Label ID="Label52" runat="server" Text="Update Cheque Status"></asp:Label>
                                                                            </th>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>Cheque No</th><th>Bank</th><th>Credit</th><th>Due Date</th><th>Status</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblCheque" runat="server"></asp:Label>
                                                                            </td><td>
                                                                                <asp:Label ID="lblBank" runat="server"></asp:Label>
                                                                            </td><td>
                                                                                <asp:Label ID="lblChCredit" runat="server"></asp:Label>
                                                                            </td><td>
                                                                                <asp:Label ID="lblDueDate" runat="server"></asp:Label>
                                                                            </td><td>
                                                                                <asp:DropDownList ID="ddlChStatus" runat="server" DataSourceID="ChStatusDS" 
                                                                                    DataTextField="strChequeStatusEn" DataValueField="byteChequeStatus" 
                                                                                    Width="150px">
                                                                                </asp:DropDownList>
                                                                            </td>
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
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="5">
                                                                                <asp:Label ID="lblChMsg" runat="server" Font-Bold="True" Font-Size="Small" 
                                                                                    ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="btnSaveStatus" runat="server" 
                                                                                    ImageUrl="~/Images/Icons/Save.gif" onclick="btnSaveStatus_Click" 
                                                                                    ToolTip="Save Payment" />
                                                                                <asp:ImageButton ID="btnUndoStatus" runat="server" CausesValidation="False" 
                                                                                    ImageUrl="~/Images/Icons/GoBack.jpg" onclick="btnUndoStatus_Click" 
                                                                                    ToolTip="Go Back" ValidationGroup="None" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:SqlDataSource ID="ChStatusDS" runat="server" 
                                                                                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                                                    SelectCommand="SELECT [byteChequeStatus], [strChequeStatusEn] FROM [Acc_Cheques_Statuses]">
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnStatus" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                   </table>
                                                                       </td>
                                                                       </tr>
                                                                       <tr>
                                                                           <td align="center">
                                                                           </td>
                                                                       </tr>
                                                                       <tr>
                                                                           <td align="center">
                                                                           </td>
                                                                       </tr>
                                                                       <tr>
                                                                           <td align="center">
                                                                           </td>
                                                                       </tr>
                                                                       </table>
                                                                   </asp:View>
                                                               </asp:MultiView>
                                                            
                                                           </td>                                                           
                                                       </tr>
                                                       <tr style="display:none;">
                                                           <td align="right" colspan="4">
                                                               <hr />
                                                           </td>                                                           
                                                       </tr>
                                                       <tr style="display:none;">
                                                           <td align="right" colspan="4">
                                                            
                                                               <asp:MultiView ID="MVPayemnt" runat="server" ActiveViewIndex="0">
                                                                   <asp:View ID="View5" runat="server">
                                                                       <asp:GridView ID="grdPayment" runat="server" AutoGenerateColumns="False" 
                                                                           Caption="Term Payments" CaptionAlign="Top" CellPadding="4" 
                                                                           DataKeyNames="strVoucherNo,lngEntryNo" DataSourceID="PaymentDS" 
                                                                           EmptyDataText="No Payments" ForeColor="#333333" GridLines="None" 
                                                                           onselectedindexchanged="grdPayment_SelectedIndexChanged" Width="100%">
                                                                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                           <RowStyle BackColor="#EFF3FB"  />
                                                                           <EmptyDataRowStyle BackColor="#f7f7f7" ForeColor="Red" HorizontalAlign="Center" 
                                                                               VerticalAlign="Middle" />
                                                                           <Columns>
                                                                               <asp:CommandField SelectText="Edit" ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
                                                                               <asp:BoundField DataField="strVoucherNo" HeaderText="VNo" 
                                                                                   SortExpression="strVoucherNo" />
                                                                               <asp:BoundField DataField="lngEntryNo" HeaderText="#" 
                                                                                   SortExpression="lngEntryNo" />
                                                                               <asp:BoundField DataField="datePayment" DataFormatString="{0:dd/MM/yyyy}" 
                                                                                   HeaderText="Date" SortExpression="datePayment" />
                                                                               <asp:BoundField DataField="curCredit" DataFormatString="{0:f}" 
                                                                                   HeaderText="Credit" SortExpression="curCredit" />
                                                                               <asp:BoundField DataField="strPaymentTypeEn" HeaderText="Way" 
                                                                                   SortExpression="strPaymentTypeEn" />
                                                                               <asp:BoundField DataField="strRemark" HeaderText="Remark" 
                                                                                   SortExpression="strRemark" />
                                                                           </Columns>
                                                                           <PagerStyle BackColor="#ededed" ForeColor="#333333" HorizontalAlign="Center" />
                                                                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                           <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                                                                               VerticalAlign="Middle" Wrap="True" />
                                                                           <EditRowStyle BackColor="#2461BF" />
                                                                           <AlternatingRowStyle BackColor="White" />
                                                                       </asp:GridView>
                                                                       <div align="center" style="display:none;">
                                                                           <table width="790">
                                                                               <tr>
                                                                                   <td align="right" width="30%">
                                                                                       &nbsp;</td>
                                                                                   <td>
                                                                                       &nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td align="right" width="30%">
                                                                                       <asp:LinkButton ID="lnkSetCash" runat="server" onclick="lnkSetCash_Click">Set Cash</asp:LinkButton>
                                                                                   </td>
                                                                                   <td>
                                                                                       <asp:RadioButtonList ID="rbnCash" runat="server" Enabled="False" 
                                                                                           RepeatDirection="Horizontal">
                                                                                           <asp:ListItem Selected="True" Value="1">Males</asp:ListItem>
                                                                                           <asp:ListItem Value="2">Females</asp:ListItem>
                                                                                           <asp:ListItem Value="3">Media</asp:ListItem>
                                                                                           <asp:ListItem Value="4">Western Area</asp:ListItem>
                                                                                       </asp:RadioButtonList>
                                                                                   </td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td align="right" width="30%">
                                                                                       <asp:LinkButton ID="lnkSetPrinter" runat="server" onclick="lnkSetPrinter_Click">Set Printer</asp:LinkButton>
                                                                                   </td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="txtPrinter" runat="server" Width="150px">\\Aliacc\EpsonAli</asp:TextBox>
                                                                                   </td>
                                                                               </tr>
                                                                           </table>
                                                                       </div>
                                                                       <div align="center" style="display:none;">
                                                                           <asp:ImageButton ID="New_Voucher_btn" runat="server" CausesValidation="False" 
                                                                               ImageUrl="~/Images/Icons/New_File.gif" onclick="New_Voucher_btn_Click" 
                                                                               ToolTip="New Voucher" />
                                                                       </div>
                                                                   </asp:View>
                                                                   <asp:View ID="View6" runat="server">
                                                                       <table style="width:100%;">
                                                                           <tr>
                                                                               <td align="center" colspan="3">
                                                                                   <asp:GridView ID="grdVH" runat="server" AutoGenerateColumns="False" 
                                                                                       Caption="Voucher" CaptionAlign="Top" CellPadding="4" DataSourceID="VHDS" 
                                                                                       EmptyDataText="No Payments" ForeColor="#333333" GridLines="None" Width="100%">
                                                                                       <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                       <RowStyle BackColor="#EFF3FB" />
                                                                                       <EmptyDataRowStyle BackColor="#f7f7f7" ForeColor="Red" HorizontalAlign="Center" 
                                                                                           VerticalAlign="Middle" />
                                                                                       <Columns>
                                                                                           <asp:BoundField DataField="strVoucherNo" HeaderText="#" 
                                                                                               SortExpression="strVoucherNo" />
                                                                                           <asp:BoundField DataField="dateVoucher" DataFormatString="{0:dd/MM/yyyy}" 
                                                                                               HeaderText="Date" SortExpression="dateVoucher" />
                                                                                           <asp:BoundField DataField="strAccountNo" HeaderText="ACC" 
                                                                                               SortExpression="strAccountNo" />
                                                                                           <asp:BoundField DataField="strStudentName" HeaderText="Name" 
                                                                                               SortExpression="strStudentName" />
                                                                                           <asp:BoundField DataField="lngStudentNumber" HeaderText="SID" 
                                                                                               SortExpression="lngStudentNumber" />
                                                                                       </Columns>
                                                                                       <PagerStyle BackColor="#ededed" ForeColor="#333333" HorizontalAlign="Center" />
                                                                                       <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                       <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                                                                                           VerticalAlign="Middle" Wrap="True" />
                                                                                       <EditRowStyle BackColor="#2461BF" />
                                                                                       <AlternatingRowStyle BackColor="White" />
                                                                                   </asp:GridView>
                                                                                   <asp:SqlDataSource ID="VHDS" runat="server" 
                                                                                       ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                                                       SelectCommand="SELECT Acc_Voucher_Header.strVoucherNo, Acc_Voucher_Header.dateVoucher, Acc_Voucher_Header.strAccountNo, Reg_Student_Accounts.strStudentName, Reg_Student_Accounts.lngStudentNumber FROM Acc_Voucher_Header INNER JOIN Reg_Student_Accounts ON Acc_Voucher_Header.strAccountNo = Reg_Student_Accounts.strAccountNo WHERE (Acc_Voucher_Header.strVoucherNo = @strVoucherNo) AND (Acc_Voucher_Header.intFy = @intFy) AND (Acc_Voucher_Header.byteFSemester = @byteFSemester)">
                                                                                       <SelectParameters>
                                                                                           <asp:Parameter Name="strVoucherNo" />
                                                                                           <asp:Parameter Name="intFy" />
                                                                                           <asp:Parameter Name="byteFSemester" />
                                                                                       </SelectParameters>
                                                                                   </asp:SqlDataSource>
                                                                               </td>
                                                                           </tr>
                                                                           <tr style="display:none;">
                                                                               <td align="center" colspan="3">
                                                                                   <hr />
                                                                               </td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="center" colspan="3">
                                                                                   <asp:GridView ID="grdVD" runat="server" AutoGenerateColumns="False" 
                                                                                       Caption="Payments" CaptionAlign="Top" CellPadding="4" DataKeyNames="lngEntryNo" 
                                                                                       DataSourceID="VDDS" EmptyDataText="No Payments" ForeColor="#333333" 
                                                                                       GridLines="None" onselectedindexchanged="grdVD_SelectedIndexChanged" 
                                                                                       Width="100%">
                                                                                       <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                       <RowStyle BackColor="#EFF3FB" />
                                                                                       <EmptyDataRowStyle BackColor="#f7f7f7" ForeColor="Red" HorizontalAlign="Center" 
                                                                                           VerticalAlign="Middle" />
                                                                                       <Columns>
                                                                                           <asp:CommandField SelectText="Edit" ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
                                                                                           <asp:BoundField DataField="lngEntryNo" HeaderText="#" ReadOnly="True" 
                                                                                               SortExpression="lngEntryNo" />
                                                                                           <asp:BoundField DataField="datePayment" DataFormatString="{0:dd/MM/yyyy}" 
                                                                                               HeaderText="Date" SortExpression="datePayment" />
                                                                                           <asp:BoundField DataField="curCredit" DataFormatString="{0:f}" 
                                                                                               HeaderText="Amount" SortExpression="curCredit" />
                                                                                           <asp:BoundField DataField="strPaymentTypeEn" HeaderText="Way" 
                                                                                               SortExpression="strPaymentTypeEn" />
                                                                                           <asp:BoundField DataField="strChequeStatusEn" HeaderText="Status" 
                                                                                               SortExpression="strChequeStatusEn" />
                                                                                           <asp:BoundField DataField="strChequeNo" HeaderText="Cheque #" 
                                                                                               SortExpression="strChequeNo" />
                                                                                           <asp:BoundField DataField="dateDue" DataFormatString="{0:dd/MM/yyyy}" 
                                                                                               HeaderText="Due" SortExpression="dateDue" />
                                                                                           <asp:BoundField DataField="strBankEn" HeaderText="Bank" 
                                                                                               SortExpression="strBankEn" />
                                                                                       </Columns>
                                                                                       <PagerStyle BackColor="#ededed" ForeColor="#333333" HorizontalAlign="Center" />
                                                                                       <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                       <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                                                                                           VerticalAlign="Middle" Wrap="True" />
                                                                                       <EditRowStyle BackColor="#2461BF" />
                                                                                       <AlternatingRowStyle BackColor="White" />
                                                                                   </asp:GridView>
                                                                               </td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="center" colspan="3">
                                                                                   <hr />
                                                                               </td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="center" colspan="3">
                                                                                   <asp:SqlDataSource ID="VDDS" runat="server" 
                                                                                       ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                                                       SelectCommand="SELECT Acc_Voucher_Detail.lngEntryNo, Acc_Voucher_Detail.datePayment, Acc_Voucher_Detail.curCredit, Acc_PaymentsTypes.strPaymentTypeEn, Acc_Cheques_Statuses.strChequeStatusEn, Acc_Cheques.strChequeNo, Acc_Cheques.dateDue, Acc_Banks.strBankEn FROM Acc_Cheques_Statuses INNER JOIN Acc_Voucher_Detail INNER JOIN Acc_PaymentsTypes ON Acc_Voucher_Detail.bytePaymentWay = Acc_PaymentsTypes.bytePaymentType ON Acc_Cheques_Statuses.byteChequeStatus = Acc_Voucher_Detail.byteStatus LEFT OUTER JOIN Acc_Banks RIGHT OUTER JOIN Acc_Cheques ON Acc_Banks.intBank = Acc_Cheques.intBank ON Acc_Voucher_Detail.lngCheque = Acc_Cheques.lngCheque WHERE (Acc_Voucher_Detail.intFy = @intFy) AND (Acc_Voucher_Detail.byteFSemester = @byteFSemester) AND (Acc_Voucher_Detail.strVoucherNo = @strVoucherNo)">
                                                                                       <SelectParameters>
                                                                                           <asp:Parameter Name="intFy" />
                                                                                           <asp:Parameter Name="byteFSemester" />
                                                                                           <asp:Parameter DefaultValue="" Name="strVoucherNo" />
                                                                                       </SelectParameters>
                                                                                   </asp:SqlDataSource>
                                                                               </td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label43" runat="server" Text="Voucher :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:Label ID="lblVoucher" runat="server"></asp:Label>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label34" runat="server" Text="# :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:Label ID="lblEntryNo" runat="server"></asp:Label>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label35" runat="server" Text="Date :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:TextBox ID="txtDatePayment" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label36" runat="server" Text="Amount :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:TextBox ID="txtPayment" runat="server" Enabled="False"></asp:TextBox>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label37" runat="server" Text="Payment Way :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:DropDownList ID="ddlPaymentWay" runat="server" CssClass="ComboHeight" 
                                                                                       Enabled="False" Height="25px" 
                                                                                       onselectedindexchanged="Terms_SelectedIndexChanged" style="margin-left: 0px" 
                                                                                       Width="150px">
                                                                                       <asp:ListItem Selected="True" Value="1">Cash</asp:ListItem>
                                                                                       <asp:ListItem Value="2">Credit Card</asp:ListItem>
                                                                                       <asp:ListItem Value="3">Cheque</asp:ListItem>
                                                                                   </asp:DropDownList>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label42" runat="server" Text="Status :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:DropDownList ID="ddlStatus" runat="server" CssClass="ComboHeight" 
                                                                                       Height="25px" onselectedindexchanged="Terms_SelectedIndexChanged" 
                                                                                       style="margin-left: 0px" Width="150px">
                                                                                       <asp:ListItem Selected="True" Value="0">Entry</asp:ListItem>
                                                                                       <asp:ListItem Value="1">Paid</asp:ListItem>
                                                                                       <asp:ListItem Value="2">Returned</asp:ListItem>
                                                                                       <asp:ListItem Value="3">Insurance</asp:ListItem>
                                                                                       <asp:ListItem Value="4">Canceled</asp:ListItem>
                                                                                   </asp:DropDownList>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label38" runat="server" Text="Cheque # :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:TextBox ID="txtCheque" runat="server" Enabled="False"></asp:TextBox>
                                                                                   <asp:HiddenField ID="hdnCheque" runat="server" />
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label39" runat="server" Text="Due Date :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:TextBox ID="txtDueDate" runat="server" Enabled="False"></asp:TextBox>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label40" runat="server" Text="Bank :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:DropDownList ID="ddlBank" runat="server" CssClass="ComboHeight" 
                                                                                       DataSourceID="BankDS" DataTextField="strBankEn" DataValueField="intBank" 
                                                                                       Enabled="False" Height="25px" 
                                                                                       onselectedindexchanged="Terms_SelectedIndexChanged" style="margin-left: 0px" 
                                                                                       Width="150px">
                                                                                   </asp:DropDownList>
                                                                                   <asp:SqlDataSource ID="BankDS" runat="server" 
                                                                                       ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                                                       SelectCommand="SELECT [intBank], [strBankEn] FROM [Acc_Banks] ORDER BY [strBankEn]">
                                                                                   </asp:SqlDataSource>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   <asp:Label ID="Label41" runat="server" Text="Remark :"></asp:Label>
                                                                               </td>
                                                                               <td width="50%">
                                                                                   <asp:TextBox ID="txtPRemark" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="right" width="40%">
                                                                                   &nbsp;</td>
                                                                               <td width="50%">
                                                                                   <asp:HiddenField ID="hdnPaymentStatus" runat="server" Value="0" />
                                                                               </td>
                                                                               <td>
                                                                                   &nbsp;</td>
                                                                           </tr>
                                                                           <tr>
                                                                               <td align="center" colspan="3" width="40%">
                                                                                   <table>
                                                                                       <tr>
                                                                                           <td>
                                                                                               <asp:ImageButton ID="New_Payment_btn" runat="server" CausesValidation="False" 
                                                                                                   ImageUrl="~/Images/Icons/New_File.gif" onclick="New_Payment_btn_Click" 
                                                                                                   ToolTip="New Payment" />
                                                                                           </td>
                                                                                           <td>
                                                                                               <asp:ImageButton ID="Save_Payment_btn" runat="server" 
                                                                                                   ImageUrl="~/Images/Icons/Save.gif" onclick="Save_Payment_btn_Click" 
                                                                                                   ToolTip="Save Payment" />
                                                                                           </td>
                                                                                           <td>
                                                                                               <asp:ImageButton ID="Delete_Payment_btn" runat="server" 
                                                                                                   ImageUrl="~/Images/Icons/Delete.gif" onclick="Delete_Payment_btn_Click" 
                                                                                                   onclientclick="return DeleteConfirm();" 
                                                                                                   Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                                                                                                   ToolTip="Delete Payment" />
                                                                                           </td>
                                                                                           <td>
                                                                                               <asp:ImageButton ID="Go_Payment_btn" runat="server" CausesValidation="False" 
                                                                                                   ImageUrl="~/Images/Icons/GoBack.jpg" onclick="Go_Payment_btn_Click" 
                                                                                                   ToolTip="Go Back" ValidationGroup="None" />
                                                                                           </td>
                                                                                           <td>
                                                                                               <asp:ImageButton ID="Print_Payment_btn" runat="server" 
                                                                                                   ImageUrl="~/Images/Icons/Print.gif" onclick="Print_Payment_btn_Click" 
                                                                                                   Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                                                                                                   ToolTip="Print Voucher" />
                                                                                           </td>
                                                                                           <td>
                                                                                               &nbsp;</td>
                                                                                       </tr>
                                                                                   </table>
                                                                               </td>
                                                                           </tr>
                                                                       </table>
                                                                   </asp:View>
                                                               </asp:MultiView>
                                                            
                                                           </td>                                                           
                                                       </tr>
                                                       <tr>
                                                           <td align="right" colspan="4">
                                                               <hr />
                                                           </td>                                                           
                                                       </tr>
                                                       <tr style="display:none;">
                                                           <th align="left" colspan="4">
                                                            
                                                               <asp:Label ID="lblMajorCaption5" runat="server" Text="Student Balance"></asp:Label>
                                                            
                                                           </th>                                                           
                                                       </tr>
                                                       <tr style="display:none;">
                                                           <td align="right" colspan="4">
                                                            
                                                               <table style="width:100%;" id="studentbalance">
                                                                   <tr>
                                                                       <th align="center">
                                                                           &nbsp;</th>
                                                                       <th align="center">
                                                                           <asp:Label ID="lblMajorCaption6" runat="server" Text="Insurance"></asp:Label>
                                                                       </th>
                                                                       <th align="center">
                                                                           <asp:Label ID="lblMajorCaption7" runat="server" Text="Debit"></asp:Label>
                                                                       </th>
                                                                       <th align="center">
                                                                           <asp:Label ID="lblMajorCaption8" runat="server" Text="Credit"></asp:Label>
                                                                       </th>
                                                                       <th align="center">
                                                                           <asp:Label ID="lblMajorCaption12" runat="server" Text="VAT"></asp:Label>
                                                                       </th>
                                                                       <th align="center">
                                                                           <asp:Label ID="lblMajorCaption9" runat="server" Text="Balance"></asp:Label>
                                                                       </th>
                                                                       <th align="center">
                                                                           <asp:Label ID="lblMajorCaption13" runat="server" Text="Balance+VAT"></asp:Label>
                                                                       </th>
                                                                   </tr>
                                                                   <tr>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblMajorCaption10" runat="server" Text="Term" Font-Bold="true"></asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblTIns" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblTDebit" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblTCredit" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblTVat" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblTBalance" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblTBalanceVAT" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblMajorCaption11" runat="server" Text="Overall" Font-Bold="true"></asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblOIns" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblODebit" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblOCredit" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblOvat" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblOBalance" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                       <td align="center">
                                                                           <asp:Label ID="lblOBalanceVAT" runat="server" ForeColor="Red">0</asp:Label>
                                                                       </td>
                                                                   </tr>
                                                               </table>
                                                            
                                                           </td>                                                           
                                                       </tr>
                                                       <tr>
                                                           <td align="left" colspan="4">
                                                            
                                                            
                                                            
                                                               <asp:SqlDataSource ID="FeesDS" runat="server" 
                                                                   ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                                   SelectCommand="SELECT P.byteFeesNo, F.strFeesTypeEn, P.curDebit, P.curCredit, P.strRemark, P.curVAT FROM Acc_Voucher_Payments AS P INNER JOIN Reg_Fees_Type AS F ON P.byteFeesType = F.byteFeesType WHERE (P.intFy * 10 + P.byteFSemester = @iTerm) AND (P.strAccount = @sAcc) ORDER BY P.byteFeesNo">
                                                                   <SelectParameters>
                                                                       <asp:ControlParameter ControlID="Terms" DefaultValue="0" Name="iTerm" 
                                                                           PropertyName="SelectedValue" />
                                                                       <asp:ControlParameter ControlID="sSelectedText" DefaultValue="0" Name="sAcc" 
                                                                           PropertyName="Value" />
                                                                   </SelectParameters>
                                                               </asp:SqlDataSource>
                                                               <asp:SqlDataSource ID="PaymentDS" runat="server" 
                                                                   ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                                   SelectCommand="SELECT Acc_Voucher_Detail.strVoucherNo, Acc_Voucher_Detail.lngEntryNo, Acc_Voucher_Detail.datePayment, Acc_Voucher_Detail.curCredit, Acc_PaymentsTypes.strPaymentTypeEn, Acc_Voucher_Detail.strRemark FROM Acc_Voucher_Detail INNER JOIN Acc_PaymentsTypes ON Acc_Voucher_Detail.bytePaymentWay = Acc_PaymentsTypes.bytePaymentType LEFT OUTER JOIN Acc_Cheques ON Acc_Voucher_Detail.lngCheque = Acc_Cheques.lngCheque WHERE (Acc_Voucher_Detail.intFy * 10 + Acc_Voucher_Detail.byteFSemester = @iTerm) AND (Acc_Voucher_Detail.strAccountNo = @sAcc) ORDER BY Acc_Voucher_Detail.lngEntryNo">
                                                                   <SelectParameters>
                                                                       <asp:ControlParameter ControlID="Terms" DefaultValue="0" Name="iTerm" 
                                                                           PropertyName="SelectedValue" />
                                                                       <asp:ControlParameter ControlID="sSelectedText" DefaultValue="0" Name="sAcc" 
                                                                           PropertyName="Value" />
                                                                   </SelectParameters>
                                                               </asp:SqlDataSource>
                                                            
                                                            
                                                            
                                                           </td>                                                           
                                                       </tr>
                                                       <tr>
                                                           <td align="left" colspan="4">
                                                              
                                                           </td>
                                                       </tr>
                                                   </table>
                                                   
                                                   
                                                   
                                           </asp:View>
                                           <asp:View ID="View2" runat="server">
                                               <table width="790">
                                                   <tr>
                                                       <th colspan="3" class="style9">
                                                           <asp:Label ID="Label1" runat="server" Text="Account"></asp:Label>
                                                       </th>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label2" runat="server" Text="ACC :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:Label ID="lblACC" runat="server"></asp:Label>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label26" runat="server" Text="ACC Type:"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:DropDownList ID="ddlACCType" runat="server" CssClass="ComboHeight" 
                                                               Height="25px" onselectedindexchanged="Terms_SelectedIndexChanged" 
                                                               style="margin-left: 0px" Width="150px">
                                                               <asp:ListItem Selected="True" Value="0">Student Account</asp:ListItem>
                                                               <asp:ListItem Value="1">TOEFL Account</asp:ListItem>
                                                               <asp:ListItem Value="2">IELTS Account</asp:ListItem>
                                                           </asp:DropDownList>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label21" runat="server" Text="Name :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                                                       </td>
                                                       <td width="10%">
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                               ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Name is Required" 
                                                               SetFocusOnError="True" ValidationGroup="acc">*</asp:RequiredFieldValidator>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label22" runat="server" Text="ID :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:DropDownList ID="ddlIDs" runat="server" CssClass="ComboHeight" 
                                                               Height="25px" onselectedindexchanged="Terms_SelectedIndexChanged" 
                                                               style="margin-left: 0px" Width="150px">
                                                           </asp:DropDownList>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label23" runat="server" Text="Phone :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label24" runat="server" Text="Note :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           &nbsp;</td>
                                                       <td align="left" width="50%">
                                                           &nbsp;</td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label25" runat="server" Text="Sponsored By :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:DropDownList ID="ddlSponsor" runat="server" AutoPostBack="True" 
                                                               CssClass="ComboHeight" Height="25px" 
                                                               onselectedindexchanged="Terms_SelectedIndexChanged" style="margin-left: 0px" 
                                                               Width="300px">
                                                           </asp:DropDownList>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label27" runat="server" Text="Amount :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:TextBox ID="txtAmount" runat="server" Width="150px"></asp:TextBox>
                                                           <asp:Label ID="Label28" runat="server" Text="%"></asp:Label>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label29" runat="server" Text="Remarks :"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           &nbsp;</td>
                                                       <td align="right" width="50%">
                                                           &nbsp;</td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label32" runat="server" Text="Financial Problem ($)"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:RadioButtonList ID="rbnStatus" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1">Yes</asp:ListItem>
                                                               <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                           </asp:RadioButtonList>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           <asp:Label ID="Label31" runat="server" Text="Reg Term"></asp:Label>
                                                       </td>
                                                       <td align="left" width="50%">
                                                           <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="ComboHeight" 
                                                               Height="25px" 
                                                               style="margin-left: 0px" Width="150px">
                                                           </asp:DropDownList>
                                                       </td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" width="40%">
                                                           &nbsp;</td>
                                                       <td align="right" width="50%">
                                                           &nbsp;</td>
                                                       <td width="10%">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="3" align="center">
                                                            <table>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                <asp:ImageButton ID="Save_btn" runat="server" 
                                    ImageUrl="~/Images/Icons/Save.gif" onclick="Save_btn_Click" 
                                ValidationGroup="acc" ToolTip="Save Account" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="3" align="center">
                                                           <hr />
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="3">
                                                           <asp:GridView ID="grdDiscounts" runat="server" AutoGenerateColumns="False" 
                                                               Caption="Discounts" CaptionAlign="Top" CellPadding="4" 
                                                               DataKeyNames="intStudyYear,byteSemester,byteDiscountType" 
                                                               DataSourceID="DiscountDS" EmptyDataText="No Discounts" ForeColor="#333333" 
                                                               GridLines="None" onselectedindexchanged="grdDiscounts_SelectedIndexChanged" 
                                                               Width="100%">
                                                               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                               <RowStyle BackColor="#EFF3FB"  />
                                                               <EmptyDataRowStyle BackColor="#f7f7f7" ForeColor="Red" HorizontalAlign="Center" 
                                                                   VerticalAlign="Middle" />
                                                               <Columns>
                                                                   <asp:CommandField SelectText="Edit" ShowSelectButton="True" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>
                                                                   <asp:BoundField DataField="iYear" HeaderText="Year" SortExpression="iYear" />
                                                                   <asp:BoundField DataField="sSem" HeaderText="Sem" SortExpression="sSem" />
                                                                   <asp:BoundField DataField="Discount" HeaderText="Discount" 
                                                                       SortExpression="Discount" />
                                                                   <asp:BoundField DataField="Value" DataFormatString="{0:f}%" HeaderText="Value" 
                                                                       SortExpression="Value" />
                                                                   <asp:BoundField DataField="Remark" HeaderText="Remark" 
                                                                       SortExpression="Remark" />
                                                                   <asp:BoundField DataField="Active" HeaderText="Active" ReadOnly="True" 
                                                                       SortExpression="Active" />
                                                               </Columns>
                                                               <PagerStyle BackColor="#ededed" ForeColor="#333333" HorizontalAlign="Center" />
                                                               <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                               <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                                                                   VerticalAlign="Middle" Wrap="True" />
                                                               <EditRowStyle BackColor="#2461BF" />
                                                               <AlternatingRowStyle BackColor="White" />
                                                           </asp:GridView>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="3">
                                                           <asp:SqlDataSource ID="DiscountDS" runat="server" 
                                                               ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                               SelectCommand="SELECT Reg_Semesters.iYear, Lkp_Semesters.sSem, Reg_Student_Discounts.byteDiscountType, Reg_Discounts.strDiscountDesc AS Discount, Reg_Student_Discounts.curDiscount AS Value, Reg_Student_Discounts.strRemark AS Remark, (CASE WHEN bActive = 1 THEN 'Yes' ELSE 'No' END) AS Active, Reg_Student_Discounts.intStudyYear, Reg_Student_Discounts.byteSemester FROM Reg_Student_Discounts INNER JOIN Reg_Discounts ON Reg_Student_Discounts.byteDiscountType = Reg_Discounts.byteDiscountType INNER JOIN Reg_Semesters ON Reg_Student_Discounts.intStudyYear = Reg_Semesters.intStudyYear AND Reg_Student_Discounts.byteSemester = Reg_Semesters.byteSemester INNER JOIN Lkp_Semesters ON Reg_Semesters.byteSemester = Lkp_Semesters.byteSemester WHERE (Reg_Student_Discounts.lngStudentNumber = @sID) ORDER BY Reg_Student_Discounts.intStudyYear DESC, Reg_Student_Discounts.byteSemester DESC, Discount">
                                                               <SelectParameters>
                                                                   <asp:ControlParameter ControlID="sSelectedValue" DefaultValue="0" Name="sID" 
                                                                       PropertyName="Value" />
                                                               </SelectParameters>
                                                           </asp:SqlDataSource>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </asp:View>
                                           <asp:View ID="View3" runat="server">
                                               <table width="790">
                                                   <tr>
                                                       <td align="right">
                                                           <asp:Label ID="Label50" runat="server" Text="Term : "></asp:Label>
                                                       </td>
                                                       <td colspan="4">
                                                           <asp:DropDownList ID="TestimonyTerm" runat="server" 
                                                               CssClass="ComboHeight" Height="25px" 
                                                               onselectedindexchanged="Terms_SelectedIndexChanged" style="margin-left: 0px" 
                                                               Width="150px">
                                                           </asp:DropDownList>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right">
                                                           <asp:Label ID="Label46" runat="server" Text="Type : "></asp:Label>
                                                       </td>
                                                       <td colspan="4">
                                                           <asp:RadioButtonList ID="optType" runat="server">
                                                               <asp:ListItem Value="1" Selected="True">Current Semester</asp:ListItem>
                                                               <asp:ListItem Value="2">Paid and Remaining till Graduation</asp:ListItem>
                                                               <asp:ListItem Value="3">Paid Only</asp:ListItem>
                                                               <asp:ListItem Value="4">Current Remaining</asp:ListItem>
                                                               <asp:ListItem Value="5">Remaining till Graduation</asp:ListItem>
                                                           </asp:RadioButtonList>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right">
                                                           <asp:Label ID="Label47" runat="server" Text="Paid : "></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtPaid" runat="server" Width="150px" ValidationGroup="Create" 
                                                               style="text-align: center">0</asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                               ControlToValidate="txtPaid" Display="Dynamic" ErrorMessage="Paid is required" 
                                                               SetFocusOnError="True" ValidationGroup="Create">*</asp:RequiredFieldValidator>
                                                           <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                               ControlToValidate="txtPaid" Display="Dynamic" ErrorMessage="Number Only" 
                                                               Type="Double" ValidationGroup="Create">Number Only</asp:RangeValidator>
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right" class="style12">
                                                           <asp:Label ID="Label48" runat="server" Text="Remaining : "></asp:Label>
                                                       </td>
                                                       <td class="style12">
                                                           <asp:TextBox ID="txtRemind" runat="server" Width="150px" 
                                                               ValidationGroup="Create" style="text-align: center">0</asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                               ControlToValidate="txtRemind" Display="Dynamic" 
                                                               ErrorMessage="Remind is required" SetFocusOnError="True" 
                                                               ValidationGroup="Create">*</asp:RequiredFieldValidator>
                                                           <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                                               ControlToValidate="txtRemind" Display="Dynamic" ErrorMessage="Number Only" 
                                                               Type="Double" ValidationGroup="Create">Number Only</asp:RangeValidator>
                                                       </td>
                                                       <td class="style12">
                                                       </td>
                                                       <td class="style12">
                                                       </td>
                                                       <td class="style12">
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right">
                                                           &nbsp;</td>
                                                       <td>
                                                           <asp:Button ID="Create_btn" runat="server" Text="Create Text" 
                                                               ValidationGroup="Create" onclick="Create_btn_Click" />
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right">
                                                           <asp:Label ID="Label49" runat="server" Text="Text : "></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtText" runat="server" Height="150px" Width="600px" 
                                                               TextMode="MultiLine" style="text-align: right; font-size: medium" 
                                                               ValidationGroup="Print" Font-Size="Large"></asp:TextBox>
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right">
                                                           &nbsp;</td>
                                                       <td>
                                                           <asp:ImageButton ID="Print_Text" runat="server" 
                                                               ImageUrl="~/Images/Icons/Print.gif" 
                                                               Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                                                               ToolTip="Text" ValidationGroup="Print" onclick="Print_Text_Click" />
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                               ControlToValidate="txtText" Display="Dynamic" ErrorMessage="Text is required" 
                                                               SetFocusOnError="True" ValidationGroup="Print">Text is required</asp:RequiredFieldValidator>
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td align="right">
                                                           &nbsp;</td>
                                                       <td colspan="4">
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>
                                           </asp:View>
                                           <asp:View ID="View4" runat="server">
                                           </asp:View>
                                       </asp:MultiView>
            </td>
        </tr>
        
        <tr>
            <td  colspan="2">
               
                                      </td>
        </tr>
        
        <tr>
            <td  colspan="2">
               
                <asp:SqlDataSource ID="TMDS" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                    
                    
                        
                    
                    SelectCommand="SELECT C.strShortcut AS Session, C.strCourse AS Course, C.byteClass AS Class, L.strLecturerDescEn AS Lecturer, C.dateTimeFrom AS TimeFrom, C.dateTimeTo AS TimeTo, C.days, C.strHall AS Hall, CB.Shift AS iSession, W_EW.strGrade FROM Course_Balance_View AS CB INNER JOIN Classes_All AS C ON CB.iYear = C.intStudyYear AND CB.Sem = C.byteSemester AND CB.Shift = C.byteShift AND CB.Course = C.strCourse AND CB.Class = C.byteClass INNER JOIN Reg_Lecturers AS L ON C.intLecturer = L.intLecturer LEFT OUTER JOIN W_EW ON CB.iYear = W_EW.intStudyYear AND CB.Sem = W_EW.byteSemester AND CB.Course = W_EW.strCourse AND CB.Student = W_EW.lngStudentNumber WHERE (CB.Student = @Student) AND (CB.iYear * 10 + CB.Sem = @Term) ORDER BY Course">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="sSelectedValue" DefaultValue="-" 
                            Name="Student" PropertyName="Value" />
                        <asp:ControlParameter ControlID="Terms" DefaultValue="0" Name="Term" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
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
