<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_Task_Update.aspx.cs" Inherits="LocalECT.Strategy_Strategic_Task_Update" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3><i class="fa fa-globe"></i> Corporate Strategy</h3>
                                </div>
                                <style>
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
                                            <h2><i class="fa fa-plus"></i> <asp:Label ID="lbl_Header" runat="server" ForeColor="#444444"></asp:Label></h2>
                                            <ul class="nav navbar-right panel_toolbox">                                                
                                                <asp:LinkButton ID="lnk_Back" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" title="Back" OnClick="lnk_Back_Click"><i class="fa fa-arrow-circle-left"></i> Tasks</asp:LinkButton>
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                                  <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">

                                    <div class="alert alert-success alert-dismissible " role="alert" runat="server" id="div_Alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Task Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">

                                                    <div class="form-group ">
                                                        <label>Task ID *</label>
                                                        <asp:TextBox ID="txt_TaskID" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Task ID Required" ControlToValidate="txt_TaskID" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Task Description *</label>
                                                        <asp:TextBox ID="txt_TaskDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Task Description Required" ControlToValidate="txt_TaskDesc" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Period *</label>
                                                        <asp:DropDownList ID="drp_Period" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Start Date *</label>
                                                        <asp:TextBox ID="txt_dStart" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Start Date Required" ControlToValidate="txt_dStart" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>End Date *</label>
                                                        <asp:TextBox ID="txt_dEnd" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*End Date Required" ControlToValidate="txt_dEnd" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                     <div class="form-group ">
                                                        <label>Department *</label>
                                                        <asp:DropDownList ID="drp_Department" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_Department_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Section *</label>
                                                        <asp:DropDownList ID="drp_Section" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                     <div class="form-group ">
                                                        <label>MOE Re-licensure Stipulation *</label>
                                                        <asp:DropDownList ID="drp_Stipulation" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_Stipulation_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>MOE Re-licensure Sub Stipulation *</label>
                                                        <asp:DropDownList ID="drp_SubStipulation" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_SubStipulation_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                     <div class="form-group ">
                                                        <label>MOE Re-licensure Stipulation Guidelines *</label>
                                                        <asp:DropDownList ID="drp_Guideline" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Inspection Compliance Standard *</label>                                                        
                                                        <asp:TextBox ID="txt_InspectionComplianceStandard" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Inspection Compliance Standard Required" ControlToValidate="txt_InspectionComplianceStandard" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="hdn_InspectionComplianceStandard" runat="server" />
                                                    </div>    
                                                    <div class="form-group ">
                                                        <label>Inspection Compliance Domain *</label>                                                        
                                                        <asp:TextBox ID="txt_InspectionComplianceDomain" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Inspection Compliance Domain Required" ControlToValidate="txt_InspectionComplianceDomain" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="hdn_InspectionComplianceDomain" runat="server" />
                                                    </div>  
                                                     <div class="form-group ">
                                                        <label>Inspection Compliance Indicator *</label>                                                        
                                                         <asp:TextBox ID="txt_InspectionComplianceIndicator" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Inspection Compliance Indicator Required" ControlToValidate="txt_InspectionComplianceIndicator" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                         <asp:HiddenField ID="hdn_InspectionComplianceIndicator" runat="server" />
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Inspection Compliance Guidelines *</label>
                                                        <asp:DropDownList ID="drp_InspectionComplianceGuidelines" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_InspectionComplianceGuidelines_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Risk Management *</label>
                                                        <asp:DropDownList ID="drp_RiskManagement" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                 <%--    <div class="form-group ">
                                                        <label>Survey Form Reference *</label>
                                                        <asp:DropDownList ID="drp_SurveyFormReference" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>IRQA Recommendation *</label>
                                                        <asp:DropDownList ID="drp_IRQARecommendation" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>--%>
                                                    <div class="form-group ">
                                                        <label>Evidence *</label>
                                                        <asp:DropDownList ID="drp_Evidence" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Initiative *</label>
                                                        <asp:DropDownList ID="drp_Initiative" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                    </div>

                                                    <div class="form-group ">
                                                        <label>Strategy Version *</label>
                                                        <asp:DropDownList ID="drp_StrategyVersion" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                    </div>
                                                        <div class="form-group ">
                                                        <label>Order *</label>
                                                        <asp:TextBox ID="txt_Order" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Order Required" ControlToValidate="txt_Order" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>                                                    
                                                <div class="form-group ">
                                                <asp:Button id="btn_Create" runat="server" Text="Create" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="btn_Create_Click"/>
                                                <asp:Button id="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-sm" OnClick="btn_Cancel_Click"/>
                                                    </div>
                                                    </div> 
                                                    </div>    
         <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
         <link rel="stylesheet" href="/resources/demos/style.css">
         <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
         <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
         <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
                $j("#txt_dStart").datepicker({ dateFormat: 'dd/mm/yy' });
                $j("#txt_dEnd").datepicker({ dateFormat: 'dd/mm/yy' });
            });
         </script>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>