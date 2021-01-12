<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradesDM.aspx.cs" Inherits="LocalECT.GradesDM" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Classes /</a>
                        <a href="#">&nbsp;Classes Grades Entry</a>

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
                                     .style1
        {
            height: 44px;
        }
                                </style>
                                  <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
                                  <script language="javascript" type="text/javascript">

        function test(e) {
            
            alert("Here i am "+e);
            
        }

        function handleBackButton(){
            var x="1";
            var isBack;
            isBack = (x != document.getElementById("_isBack").value);
        
            document.getElementById("_isBack").value=2;
            document.getElementById("_isBack").defaultValue=2;
            if (isBack==true)
            {
                alert("Sorry ... You Cannot Use Back or Forward Button to Browse this Page");    
                document.location.href="ClassesAttendance.aspx";
            }
        }

        function txtCleaner(e)
        {
        var keynum;
        var keychar;
        var numcheck;
        var isValid=true; 
        var sMsg;


        if(window.event) // IE
          {
	        keynum = e.keyCode;
          }
        else if(e.which) // Netscape/Firefox/Opera
          {
	        keynum = e.which;
          }

       

        if ((keynum==46)||(keynum==8))  // dot(.)(Back Space)
          {
	        return isValid;	
          }
         

        keychar = String.fromCharCode(keynum);

        numcheck = /\d/ //&& /\w/;      // d =Numbers ,w=Alpha

        isValid=numcheck.test(keychar);

          if (!isValid)
          {
	        alert( keychar + ' Is not Valid Numeric or (.)dot');
          }	
        return isValid;

        }

        function txtChanged(id,max,row,counts)
        {
            var counter=0;
            var per=0.0;
            var current=0.0;
            var sum=0.0;
            var sId,sCurrent;
            var bEmpty=false;
            var str = "ihab";
            var term = 0;

          
            //Alert(id);
            term = document.getElementById('hdnTerm').value;
            //Alert(term);
            per=document.getElementById(id).value;
            if (per>max)
            {
                alert('Detail Mark Over Limit ('+ max +')');
                document.getElementById(id).value=0;
                return;
            }
            
            for (counter=0;counter<counts;counter++)
            {
                sId='TextR' + row + 'C' + counter;
                sCurrent = document.getElementById(sId).value;
//                document.getElementById('TextR' + row).enabled = false;
                if (sCurrent!='')
                {
                    current=sCurrent*1;
        
                    sum+=current;
                }
                else
                {   
        
                    bEmpty=true;
                }
            }


            sum = Math.round(sum);                
            document.getElementById('TextM' + row).value = sum;
            
            document.getElementById('isDataGhanged'+row ).value=1;   
//            str=document.getElementById('Course').value;
            
            
            iGradeSystem=document.getElementById('GradesSystem').value;
//            alert(iGradeSystem);                
            if (bEmpty==false)
            {
                if(iGradeSystem==0)//Normal
                {
                    if (term < 20121) {
                        if (sum < 50) {
                            document.getElementById('TextG' + row).value = 'F';
                        }
                        else if (sum >= 50 && sum < 60) {
                            document.getElementById('TextG' + row).value = 'D';
                        }
                        else if (sum >= 60 && sum < 70) {
                            document.getElementById('TextG' + row).value = 'C';
                        }
                        else if (sum >= 70 && sum < 75) {
                            document.getElementById('TextG' + row).value = 'C+';
                        }
                        else if (sum >= 75 && sum < 80) {
                            document.getElementById('TextG' + row).value = 'B-';
                        }
                        else if (sum >= 80 && sum < 85) {
                            document.getElementById('TextG' + row).value = 'B';
                        }
                        else if (sum >= 85 && sum < 90) {
                            document.getElementById('TextG' + row).value = 'B+';
                        }
                        else if (sum >= 90 && sum < 93) {
                            document.getElementById('TextG' + row).value = 'A-';
                        }
                        else if (sum >= 93) {
                            document.getElementById('TextG' + row).value = 'A';
                        }
                    }
                    else {
                        if (sum < 60) {
                            document.getElementById('TextG' + row).value = 'F';
                        }
                        else if (sum >= 60 && sum < 64) {
                            document.getElementById('TextG' + row).value = 'D';
                        } 
                        else if (sum >= 64 && sum < 67) {
                            document.getElementById('TextG' + row).value = 'D+';
                        }
                        else if (sum >= 67 && sum < 70) {
                            document.getElementById('TextG' + row).value = 'C-';
                        }                        
                        else if (sum >= 70 && sum < 74) {
                            document.getElementById('TextG' + row).value = 'C';
                        }
                        else if (sum >= 74 && sum < 77) {
                            document.getElementById('TextG' + row).value = 'C+';
                        }
                        else if (sum >= 77 && sum < 80) {
                            document.getElementById('TextG' + row).value = 'B-';
                        }
                        else if (sum >= 80 && sum < 84) {
                            document.getElementById('TextG' + row).value = 'B';
                        }
                        else if (sum >= 84 && sum < 87) {
                            document.getElementById('TextG' + row).value = 'B+';
                        }
                        else if (sum >= 87 && sum < 90) {
                            document.getElementById('TextG' + row).value = 'A-';
                        }
                        else if (sum >= 90) {
                            document.getElementById('TextG' + row).value = 'A';
                        }
                        
                    }                      
                
                }
                else if (iGradeSystem==1)//ESL
                {
                    if (sum>=50)
                    {
                        document.getElementById('TextG'+row ).value='NC';   
                    }
                    else
                    {
                        document.getElementById('TextG'+row ).value='F'; 
                    }
                    
                }
                else if (iGradeSystem==2)//Pass Fail
                {
                    if (sum>=60)
                    {
                        document.getElementById('TextG'+row ).value='Pass';   
                    }
                    else
                    {
                        document.getElementById('TextG'+row ).value='Fail'; 
                    }
                    
                }
            
            }
            else
            {
                document.getElementById('TextG'+row ).value='NG';        
            }
          
        }
        
        function SetPost()
        {
            var HCount=0;
            var DCount=0;
            var Hcounter=0;
            var Dcounter = 0;
            var sUpdates = "Start";

            HCount = document.getElementById("Count").value;
//            sUpdates = "Start-GetDCount";
            DCount = document.getElementById("DetailCount").value;
          
            var x="";
            var sID="";
            var isChanged=0;
          
            var iChanged=0;
            for (Hcounter=0;Hcounter<HCount;Hcounter++)
            {
                //**
//                alert("#"+Hcounter);
                isChanged=document.getElementById("isDataGhanged"+Hcounter ).value;
                //**
//                alert("isChanged="+isChanged );
                if (isChanged==1)
                {
                    
                    iChanged+=1;
                    //**
//                    alert("stno="+document.getElementById("StNo"+Hcounter ).value);
                    
                    sUpdates+=";"+document.getElementById("StNo"+Hcounter ).value;
                    
                    for(Dcounter=0;Dcounter<DCount;Dcounter++)
                    {                    
                        sID="TextR"+Hcounter +"C"+Dcounter;
                        //**
//                        alert("txt="+sID);
                        //Get Type                            
                        sUpdates+=";"+document.getElementById(sID+"T").value;
                        //Get Detail Grade
                        sUpdates+=";"+document.getElementById(sID).value;                            
                        //**
//                        alert("sUpdates="+sUpdates);
                    }
                    //**
//                    alert("Mark="+document.getElementById("TextM"+Hcounter).value);
//                    alert("Grade="+document.getElementById("TextG"+Hcounter).value);
//                    alert("Status="+document.getElementById("DataStatus"+Hcounter).value);
                    
                    sUpdates+=";"+document.getElementById("TextM"+Hcounter).value;
                    sUpdates+=";"+document.getElementById("TextG"+Hcounter).value;
                    sUpdates+=";"+document.getElementById("DataStatus"+Hcounter).value;
//                    alert("sUpdates="+sUpdates);
                }
                  
            }
            //**
//          alert("I am setting the texts");
            sUpdates=iChanged+";"+sUpdates; 
            document.getElementById("txtUpdates").value=sUpdates;
        }
               
       
                                  </script>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Classes Grades Entry</h2>
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

                                                      <div id='divCommands' runat="server" style="text-align:center " align="center" >
        <table align="center">
            <tr>
                <td class="style1">
                    
                    
                    <asp:ImageButton ID="SaveCMD" runat="server" ImageUrl="~/Images/Icons/Save.gif"
                    Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                    ToolTip="Save" onclientclick="javascript: SetPost();" onclick="SaveCMD_Click"  />
                    
                    
                </td>
                            
                
                <td class="style1">
                    <asp:ImageButton ID="BackCMD" runat="server" ImageUrl="~/Images/Icons/Prev_Column.gif"
                    Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                    ToolTip="Back to Classes Grades" onclick="BackCMD_Click" />
                </td>
                <td class="style1">
                    <asp:ImageButton ID="ReportCMD" runat="server" ImageUrl="~/Images/Icons/Print.gif"
                    Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                    ToolTip="View Report" onclick="ReportCMD_Click" />
                </td>
                <td class="style1">
                    <asp:ImageButton ID="ToExcelCMD" runat="server" ImageUrl="~/Images/Icons/toExcel.gif"
                    Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                    ToolTip="Transfer to Excel" onclick="ToExcelCMD_Click"  />
                </td>
                <td class="style1">
                    <asp:ImageButton ID="ToWordCMD" runat="server" ImageUrl="~/Images/Icons/toWord.gif"
                    Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                    ToolTip="Transfer to Excel" onclick="ToWordCMD_Click"  />
                </td>
                <td class="style1">
                    <asp:DropDownList ID="rptTypeCBO" runat="server">
                        <asp:ListItem Selected="True" Value="0">Detail</asp:ListItem>
                        <asp:ListItem Value="1" Enabled="False">Without Names</asp:ListItem>
                        <asp:ListItem Value="2" Enabled="False">Grades</asp:ListItem>
                        <asp:ListItem Value="3">Statistics</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:CheckBox ID="AllPassedCHK" runat="server" Text="All Passed" 
                        Visible="False" />
                    </td>
                <td class="style1">
                    </td>
            </tr>
            
            <tr>
                <td colspan="6">
                    
                    
                    <asp:LinkButton ID="lnkbtnExportAllSectionsMarks" runat="server" 
                        onclick="lnkbtnExportAllSectionsMarks_Click" Visible="False" 
                        Enabled="False">Export all marks from all Sections to LMS</asp:LinkButton>
                    
                    
                </td>
                            
                
                <td>
                    &nbsp;</td>
            </tr>
            
        </table>
        </div>

                                                    <br />
                                                     <div id='divDetail' runat="server" style="text-align:center ">
            
        </div>
        <p>
        
            <asp:HiddenField ID="txtUpdates" runat="server" 
                onvaluechanged="txtUpdates_ValueChanged" />
            <asp:HiddenField ID="hdnTerm" runat="server" />
            
        </p>
        <asp:Label ID="lblEffectedRecords" runat="server" Visible="False"></asp:Label>
        <br />
        <table width="100%" bgcolor="silver" >
        <tr>
                <td><hr /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="AvgLBL" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/star.gif" />
&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red" 
                        
                        Text="Star Symbol means that the Student Expected to graduate by the End of Current Semester." 
                        Font-Size="Small" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td><hr /></td>
            </tr>
    </table>
        <br />
        <div runat="server" id="divRpt" align="left">
           
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