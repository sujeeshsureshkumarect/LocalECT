using System;
using System.Data;
using System.Configuration;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Degrees
{
//Creation Date: 06/04/2010 7:48 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private string m_strCollege; 
private string m_strDegree; 
private string m_strDegreeDescEn; 
private string m_strDegreeDescAr; 
private int m_bytePassMark; 
private int m_byteStudyDuration; 
private int m_byteSemesterDuration; 
private int m_intCreditHours; 
private int m_intPracticalHours; 
private int m_byteMaxCreditHours; 
private int m_byteMinCreditHours; 
private int m_bytePreStartDuration; 
private int m_byteAddSubDuration; 
private int m_byteSubDuration; 
private int m_byteMinPassMark; 
private int m_byteZeroMark; 
private int m_byteMinGPA; 
private int m_byteMaxRepeatMark; 
private string m_bAvgCancel; 
private int m_byteFailTimes; 
private int m_byteMaxFailMark; 
private int m_byteRepeatTrial; 
private int m_byteRepeatCourse; 
private int m_bytePostponeSemesters; 
private int m_bytePostponePreDuration; 
private int m_byteMaxPostpone; 
private int m_byteMaxCreditBalance; 
private int m_byteRepeatMinGPA; 
private int m_byteMarkAllowed; 
private string m_strReportEn; 
private string m_strReportAr; 
private string m_bCourse; 
private string m_strAccount; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public string strCollege
{
get { return  m_strCollege; }
set {m_strCollege  = value ; }
}
public string strDegree
{
get { return  m_strDegree; }
set {m_strDegree  = value ; }
}
public string strDegreeDescEn
{
get { return  m_strDegreeDescEn; }
set {m_strDegreeDescEn  = value ; }
}
public string strDegreeDescAr
{
get { return  m_strDegreeDescAr; }
set {m_strDegreeDescAr  = value ; }
}
public int bytePassMark
{
get { return  m_bytePassMark; }
set {m_bytePassMark  = value ; }
}
public int byteStudyDuration
{
get { return  m_byteStudyDuration; }
set {m_byteStudyDuration  = value ; }
}
public int byteSemesterDuration
{
get { return  m_byteSemesterDuration; }
set {m_byteSemesterDuration  = value ; }
}
public int intCreditHours
{
get { return  m_intCreditHours; }
set {m_intCreditHours  = value ; }
}
public int intPracticalHours
{
get { return  m_intPracticalHours; }
set {m_intPracticalHours  = value ; }
}
public int byteMaxCreditHours
{
get { return  m_byteMaxCreditHours; }
set {m_byteMaxCreditHours  = value ; }
}
public int byteMinCreditHours
{
get { return  m_byteMinCreditHours; }
set {m_byteMinCreditHours  = value ; }
}
public int bytePreStartDuration
{
get { return  m_bytePreStartDuration; }
set {m_bytePreStartDuration  = value ; }
}
public int byteAddSubDuration
{
get { return  m_byteAddSubDuration; }
set {m_byteAddSubDuration  = value ; }
}
public int byteSubDuration
{
get { return  m_byteSubDuration; }
set {m_byteSubDuration  = value ; }
}
public int byteMinPassMark
{
get { return  m_byteMinPassMark; }
set {m_byteMinPassMark  = value ; }
}
public int byteZeroMark
{
get { return  m_byteZeroMark; }
set {m_byteZeroMark  = value ; }
}
public int byteMinGPA
{
get { return  m_byteMinGPA; }
set {m_byteMinGPA  = value ; }
}
public int byteMaxRepeatMark
{
get { return  m_byteMaxRepeatMark; }
set {m_byteMaxRepeatMark  = value ; }
}
public string bAvgCancel
{
get { return  m_bAvgCancel; }
set {m_bAvgCancel  = value ; }
}
public int byteFailTimes
{
get { return  m_byteFailTimes; }
set {m_byteFailTimes  = value ; }
}
public int byteMaxFailMark
{
get { return  m_byteMaxFailMark; }
set {m_byteMaxFailMark  = value ; }
}
public int byteRepeatTrial
{
get { return  m_byteRepeatTrial; }
set {m_byteRepeatTrial  = value ; }
}
public int byteRepeatCourse
{
get { return  m_byteRepeatCourse; }
set {m_byteRepeatCourse  = value ; }
}
public int bytePostponeSemesters
{
get { return  m_bytePostponeSemesters; }
set {m_bytePostponeSemesters  = value ; }
}
public int bytePostponePreDuration
{
get { return  m_bytePostponePreDuration; }
set {m_bytePostponePreDuration  = value ; }
}
public int byteMaxPostpone
{
get { return  m_byteMaxPostpone; }
set {m_byteMaxPostpone  = value ; }
}
public int byteMaxCreditBalance
{
get { return  m_byteMaxCreditBalance; }
set {m_byteMaxCreditBalance  = value ; }
}
public int byteRepeatMinGPA
{
get { return  m_byteRepeatMinGPA; }
set {m_byteRepeatMinGPA  = value ; }
}
public int byteMarkAllowed
{
get { return  m_byteMarkAllowed; }
set {m_byteMarkAllowed  = value ; }
}
public string strReportEn
{
get { return  m_strReportEn; }
set {m_strReportEn  = value ; }
}
public string strReportAr
{
get { return  m_strReportAr; }
set {m_strReportAr  = value ; }
}
public string bCourse
{
get { return  m_bCourse; }
set {m_bCourse  = value ; }
}
public string strAccount
{
get { return  m_strAccount; }
set {m_strAccount  = value ; }
}
public string strUserCreate
{
get { return  m_strUserCreate; }
set {m_strUserCreate  = value ; }
}
public DateTime dateCreate
{
get { return  m_dateCreate; }
set {m_dateCreate  = value ; }
}
public string strUserSave
{
get { return  m_strUserSave; }
set {m_strUserSave  = value ; }
}
public DateTime dateLastSave
{
get { return  m_dateLastSave; }
set {m_dateLastSave  = value ; }
}
public string strMachine
{
get { return  m_strMachine; }
set {m_strMachine  = value ; }
}
public string strNUser
{
get { return  m_strNUser; }
set {m_strNUser  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Degrees()
{
try
{
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
//end first class
}
public class DegreesDAL : Degrees
{
#region "Decleration"
private string m_TableName;
private string m_strCollegeFN ;
private string m_strDegreeFN ;
private string m_strDegreeDescEnFN ;
private string m_strDegreeDescArFN ;
private string m_bytePassMarkFN ;
private string m_byteStudyDurationFN ;
private string m_byteSemesterDurationFN ;
private string m_intCreditHoursFN ;
private string m_intPracticalHoursFN ;
private string m_byteMaxCreditHoursFN ;
private string m_byteMinCreditHoursFN ;
private string m_bytePreStartDurationFN ;
private string m_byteAddSubDurationFN ;
private string m_byteSubDurationFN ;
private string m_byteMinPassMarkFN ;
private string m_byteZeroMarkFN ;
private string m_byteMinGPAFN ;
private string m_byteMaxRepeatMarkFN ;
private string m_bAvgCancelFN ;
private string m_byteFailTimesFN ;
private string m_byteMaxFailMarkFN ;
private string m_byteRepeatTrialFN ;
private string m_byteRepeatCourseFN ;
private string m_bytePostponeSemestersFN ;
private string m_bytePostponePreDurationFN ;
private string m_byteMaxPostponeFN ;
private string m_byteMaxCreditBalanceFN ;
private string m_byteRepeatMinGPAFN ;
private string m_byteMarkAllowedFN ;
private string m_strReportEnFN ;
private string m_strReportArFN ;
private string m_bCourseFN ;
private string m_strAccountFN ;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string strCollegeFN 
{
get { return  m_strCollegeFN; }
set {m_strCollegeFN  = value ; }
}
public string strDegreeFN 
{
get { return  m_strDegreeFN; }
set {m_strDegreeFN  = value ; }
}
public string strDegreeDescEnFN 
{
get { return  m_strDegreeDescEnFN; }
set {m_strDegreeDescEnFN  = value ; }
}
public string strDegreeDescArFN 
{
get { return  m_strDegreeDescArFN; }
set {m_strDegreeDescArFN  = value ; }
}
public string bytePassMarkFN 
{
get { return  m_bytePassMarkFN; }
set {m_bytePassMarkFN  = value ; }
}
public string byteStudyDurationFN 
{
get { return  m_byteStudyDurationFN; }
set {m_byteStudyDurationFN  = value ; }
}
public string byteSemesterDurationFN 
{
get { return  m_byteSemesterDurationFN; }
set {m_byteSemesterDurationFN  = value ; }
}
public string intCreditHoursFN 
{
get { return  m_intCreditHoursFN; }
set {m_intCreditHoursFN  = value ; }
}
public string intPracticalHoursFN 
{
get { return  m_intPracticalHoursFN; }
set {m_intPracticalHoursFN  = value ; }
}
public string byteMaxCreditHoursFN 
{
get { return  m_byteMaxCreditHoursFN; }
set {m_byteMaxCreditHoursFN  = value ; }
}
public string byteMinCreditHoursFN 
{
get { return  m_byteMinCreditHoursFN; }
set {m_byteMinCreditHoursFN  = value ; }
}
public string bytePreStartDurationFN 
{
get { return  m_bytePreStartDurationFN; }
set {m_bytePreStartDurationFN  = value ; }
}
public string byteAddSubDurationFN 
{
get { return  m_byteAddSubDurationFN; }
set {m_byteAddSubDurationFN  = value ; }
}
public string byteSubDurationFN 
{
get { return  m_byteSubDurationFN; }
set {m_byteSubDurationFN  = value ; }
}
public string byteMinPassMarkFN 
{
get { return  m_byteMinPassMarkFN; }
set {m_byteMinPassMarkFN  = value ; }
}
public string byteZeroMarkFN 
{
get { return  m_byteZeroMarkFN; }
set {m_byteZeroMarkFN  = value ; }
}
public string byteMinGPAFN 
{
get { return  m_byteMinGPAFN; }
set {m_byteMinGPAFN  = value ; }
}
public string byteMaxRepeatMarkFN 
{
get { return  m_byteMaxRepeatMarkFN; }
set {m_byteMaxRepeatMarkFN  = value ; }
}
public string bAvgCancelFN 
{
get { return  m_bAvgCancelFN; }
set {m_bAvgCancelFN  = value ; }
}
public string byteFailTimesFN 
{
get { return  m_byteFailTimesFN; }
set {m_byteFailTimesFN  = value ; }
}
public string byteMaxFailMarkFN 
{
get { return  m_byteMaxFailMarkFN; }
set {m_byteMaxFailMarkFN  = value ; }
}
public string byteRepeatTrialFN 
{
get { return  m_byteRepeatTrialFN; }
set {m_byteRepeatTrialFN  = value ; }
}
public string byteRepeatCourseFN 
{
get { return  m_byteRepeatCourseFN; }
set {m_byteRepeatCourseFN  = value ; }
}
public string bytePostponeSemestersFN 
{
get { return  m_bytePostponeSemestersFN; }
set {m_bytePostponeSemestersFN  = value ; }
}
public string bytePostponePreDurationFN 
{
get { return  m_bytePostponePreDurationFN; }
set {m_bytePostponePreDurationFN  = value ; }
}
public string byteMaxPostponeFN 
{
get { return  m_byteMaxPostponeFN; }
set {m_byteMaxPostponeFN  = value ; }
}
public string byteMaxCreditBalanceFN 
{
get { return  m_byteMaxCreditBalanceFN; }
set {m_byteMaxCreditBalanceFN  = value ; }
}
public string byteRepeatMinGPAFN 
{
get { return  m_byteRepeatMinGPAFN; }
set {m_byteRepeatMinGPAFN  = value ; }
}
public string byteMarkAllowedFN 
{
get { return  m_byteMarkAllowedFN; }
set {m_byteMarkAllowedFN  = value ; }
}
public string strReportEnFN 
{
get { return  m_strReportEnFN; }
set {m_strReportEnFN  = value ; }
}
public string strReportArFN 
{
get { return  m_strReportArFN; }
set {m_strReportArFN  = value ; }
}
public string bCourseFN 
{
get { return  m_bCourseFN; }
set {m_bCourseFN  = value ; }
}
public string strAccountFN 
{
get { return  m_strAccountFN; }
set {m_strAccountFN  = value ; }
}
public string strUserCreateFN 
{
get { return  m_strUserCreateFN; }
set {m_strUserCreateFN  = value ; }
}
public string dateCreateFN 
{
get { return  m_dateCreateFN; }
set {m_dateCreateFN  = value ; }
}
public string strUserSaveFN 
{
get { return  m_strUserSaveFN; }
set {m_strUserSaveFN  = value ; }
}
public string dateLastSaveFN 
{
get { return  m_dateLastSaveFN; }
set {m_dateLastSaveFN  = value ; }
}
public string strMachineFN 
{
get { return  m_strMachineFN; }
set {m_strMachineFN  = value ; }
}
public string strNUserFN 
{
get { return  m_strNUserFN; }
set {m_strNUserFN  = value ; }
}
#endregion
//================End Properties ===================
public DegreesDAL()
{
try
{
this.TableName = "Reg_Degrees";
this.strCollegeFN = m_TableName + ".strCollege";
this.strDegreeFN = m_TableName + ".strDegree";
this.strDegreeDescEnFN = m_TableName + ".strDegreeDescEn";
this.strDegreeDescArFN = m_TableName + ".strDegreeDescAr";
this.bytePassMarkFN = m_TableName + ".bytePassMark";
this.byteStudyDurationFN = m_TableName + ".byteStudyDuration";
this.byteSemesterDurationFN = m_TableName + ".byteSemesterDuration";
this.intCreditHoursFN = m_TableName + ".intCreditHours";
this.intPracticalHoursFN = m_TableName + ".intPracticalHours";
this.byteMaxCreditHoursFN = m_TableName + ".byteMaxCreditHours";
this.byteMinCreditHoursFN = m_TableName + ".byteMinCreditHours";
this.bytePreStartDurationFN = m_TableName + ".bytePreStartDuration";
this.byteAddSubDurationFN = m_TableName + ".byteAddSubDuration";
this.byteSubDurationFN = m_TableName + ".byteSubDuration";
this.byteMinPassMarkFN = m_TableName + ".byteMinPassMark";
this.byteZeroMarkFN = m_TableName + ".byteZeroMark";
this.byteMinGPAFN = m_TableName + ".byteMinGPA";
this.byteMaxRepeatMarkFN = m_TableName + ".byteMaxRepeatMark";
this.bAvgCancelFN = m_TableName + ".bAvgCancel";
this.byteFailTimesFN = m_TableName + ".byteFailTimes";
this.byteMaxFailMarkFN = m_TableName + ".byteMaxFailMark";
this.byteRepeatTrialFN = m_TableName + ".byteRepeatTrial";
this.byteRepeatCourseFN = m_TableName + ".byteRepeatCourse";
this.bytePostponeSemestersFN = m_TableName + ".bytePostponeSemesters";
this.bytePostponePreDurationFN = m_TableName + ".bytePostponePreDuration";
this.byteMaxPostponeFN = m_TableName + ".byteMaxPostpone";
this.byteMaxCreditBalanceFN = m_TableName + ".byteMaxCreditBalance";
this.byteRepeatMinGPAFN = m_TableName + ".byteRepeatMinGPA";
this.byteMarkAllowedFN = m_TableName + ".byteMarkAllowed";
this.strReportEnFN = m_TableName + ".strReportEn";
this.strReportArFN = m_TableName + ".strReportAr";
this.bCourseFN = m_TableName + ".bCourse";
this.strAccountFN = m_TableName + ".strAccount";
this.strUserCreateFN = m_TableName + ".strUserCreate";
this.dateCreateFN = m_TableName + ".dateCreate";
this.strUserSaveFN = m_TableName + ".strUserSave";
this.dateLastSaveFN = m_TableName + ".dateLastSave";
this.strMachineFN = m_TableName + ".strMachine";
this.strNUserFN = m_TableName + ".strNUser";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
#region "Data Access Layer"
//-----Get SQl Function ---------------------------------
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strDegreeDescEnFN;
sSQL += " , " + strDegreeDescArFN;
sSQL += " , " + bytePassMarkFN;
sSQL += " , " + byteStudyDurationFN;
sSQL += " , " + byteSemesterDurationFN;
sSQL += " , " + intCreditHoursFN;
sSQL += " , " + intPracticalHoursFN;
sSQL += " , " + byteMaxCreditHoursFN;
sSQL += " , " + byteMinCreditHoursFN;
sSQL += " , " + bytePreStartDurationFN;
sSQL += " , " + byteAddSubDurationFN;
sSQL += " , " + byteSubDurationFN;
sSQL += " , " + byteMinPassMarkFN;
sSQL += " , " + byteZeroMarkFN;
sSQL += " , " + byteMinGPAFN;
sSQL += " , " + byteMaxRepeatMarkFN;
sSQL += " , " + bAvgCancelFN;
sSQL += " , " + byteFailTimesFN;
sSQL += " , " + byteMaxFailMarkFN;
sSQL += " , " + byteRepeatTrialFN;
sSQL += " , " + byteRepeatCourseFN;
sSQL += " , " + bytePostponeSemestersFN;
sSQL += " , " + bytePostponePreDurationFN;
sSQL += " , " + byteMaxPostponeFN;
sSQL += " , " + byteMaxCreditBalanceFN;
sSQL += " , " + byteRepeatMinGPAFN;
sSQL += " , " + byteMarkAllowedFN;
sSQL += " , " + strReportEnFN;
sSQL += " , " + strReportArFN;
sSQL += " , " + bCourseFN;
sSQL += " , " + strAccountFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += "  FROM " + m_TableName;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strDegreeDescEnFN;
sSQL += " , " + strDegreeDescArFN;
sSQL += " , " + bytePassMarkFN;
sSQL += " , " + byteStudyDurationFN;
sSQL += " , " + byteSemesterDurationFN;
sSQL += " , " + intCreditHoursFN;
sSQL += " , " + intPracticalHoursFN;
sSQL += " , " + byteMaxCreditHoursFN;
sSQL += " , " + byteMinCreditHoursFN;
sSQL += " , " + bytePreStartDurationFN;
sSQL += " , " + byteAddSubDurationFN;
sSQL += " , " + byteSubDurationFN;
sSQL += " , " + byteMinPassMarkFN;
sSQL += " , " + byteZeroMarkFN;
sSQL += " , " + byteMinGPAFN;
sSQL += " , " + byteMaxRepeatMarkFN;
sSQL += " , " + bAvgCancelFN;
sSQL += " , " + byteFailTimesFN;
sSQL += " , " + byteMaxFailMarkFN;
sSQL += " , " + byteRepeatTrialFN;
sSQL += " , " + byteRepeatCourseFN;
sSQL += " , " + bytePostponeSemestersFN;
sSQL += " , " + bytePostponePreDurationFN;
sSQL += " , " + byteMaxPostponeFN;
sSQL += " , " + byteMaxCreditBalanceFN;
sSQL += " , " + byteRepeatMinGPAFN;
sSQL += " , " + byteMarkAllowedFN;
sSQL += " , " + strReportEnFN;
sSQL += " , " + strReportArFN;
sSQL += " , " + bCourseFN;
sSQL += " , " + strAccountFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += "  FROM " + m_TableName;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
//-----Get GetUpdateCommand Function -----------------------
public string GetUpdateCommand()  
{
string sSQL  = "";
try
{
sSQL = "UPDATE " + TableName;
sSQL += " SET ";
sSQL += LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeDescEnFN) + "=@strDegreeDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeDescArFN) + "=@strDegreeDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(bytePassMarkFN) + "=@bytePassMark";
sSQL += " , " + LibraryMOD.GetFieldName(byteStudyDurationFN) + "=@byteStudyDuration";
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterDurationFN) + "=@byteSemesterDuration";
sSQL += " , " + LibraryMOD.GetFieldName(intCreditHoursFN) + "=@intCreditHours";
sSQL += " , " + LibraryMOD.GetFieldName(intPracticalHoursFN) + "=@intPracticalHours";
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxCreditHoursFN) + "=@byteMaxCreditHours";
sSQL += " , " + LibraryMOD.GetFieldName(byteMinCreditHoursFN) + "=@byteMinCreditHours";
sSQL += " , " + LibraryMOD.GetFieldName(bytePreStartDurationFN) + "=@bytePreStartDuration";
sSQL += " , " + LibraryMOD.GetFieldName(byteAddSubDurationFN) + "=@byteAddSubDuration";
sSQL += " , " + LibraryMOD.GetFieldName(byteSubDurationFN) + "=@byteSubDuration";
sSQL += " , " + LibraryMOD.GetFieldName(byteMinPassMarkFN) + "=@byteMinPassMark";
sSQL += " , " + LibraryMOD.GetFieldName(byteZeroMarkFN) + "=@byteZeroMark";
sSQL += " , " + LibraryMOD.GetFieldName(byteMinGPAFN) + "=@byteMinGPA";
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxRepeatMarkFN) + "=@byteMaxRepeatMark";
sSQL += " , " + LibraryMOD.GetFieldName(bAvgCancelFN) + "=@bAvgCancel";
sSQL += " , " + LibraryMOD.GetFieldName(byteFailTimesFN) + "=@byteFailTimes";
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxFailMarkFN) + "=@byteMaxFailMark";
sSQL += " , " + LibraryMOD.GetFieldName(byteRepeatTrialFN) + "=@byteRepeatTrial";
sSQL += " , " + LibraryMOD.GetFieldName(byteRepeatCourseFN) + "=@byteRepeatCourse";
sSQL += " , " + LibraryMOD.GetFieldName(bytePostponeSemestersFN) + "=@bytePostponeSemesters";
sSQL += " , " + LibraryMOD.GetFieldName(bytePostponePreDurationFN) + "=@bytePostponePreDuration";
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxPostponeFN) + "=@byteMaxPostpone";
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxCreditBalanceFN) + "=@byteMaxCreditBalance";
sSQL += " , " + LibraryMOD.GetFieldName(byteRepeatMinGPAFN) + "=@byteRepeatMinGPA";
sSQL += " , " + LibraryMOD.GetFieldName(byteMarkAllowedFN) + "=@byteMarkAllowed";
sSQL += " , " + LibraryMOD.GetFieldName(strReportEnFN) + "=@strReportEn";
sSQL += " , " + LibraryMOD.GetFieldName(strReportArFN) + "=@strReportAr";
sSQL += " , " + LibraryMOD.GetFieldName(bCourseFN) + "=@bCourse";
sSQL += " , " + LibraryMOD.GetFieldName(strAccountFN) + "=@strAccount";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(strCollegeFN)+"=@strCollege";
sSQL +=  " And " + LibraryMOD.GetFieldName(strDegreeFN)+"=@strDegree";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
//-----Get GetInsertCommand Function -----------------------
public string GetInsertCommand()  
{
string sSQL= "";
try
{
sSQL = "INSERT intO "  + TableName;
sSQL += "( ";
sSQL +=LibraryMOD.GetFieldName(strCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(bytePassMarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteStudyDurationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterDurationFN);
sSQL += " , " + LibraryMOD.GetFieldName(intCreditHoursFN);
sSQL += " , " + LibraryMOD.GetFieldName(intPracticalHoursFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxCreditHoursFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMinCreditHoursFN);
sSQL += " , " + LibraryMOD.GetFieldName(bytePreStartDurationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteAddSubDurationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSubDurationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMinPassMarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteZeroMarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMinGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxRepeatMarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(bAvgCancelFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteFailTimesFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxFailMarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteRepeatTrialFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteRepeatCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(bytePostponeSemestersFN);
sSQL += " , " + LibraryMOD.GetFieldName(bytePostponePreDurationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxPostponeFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMaxCreditBalanceFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteRepeatMinGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMarkAllowedFN);
sSQL += " , " + LibraryMOD.GetFieldName(strReportEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strReportArFN);
sSQL += " , " + LibraryMOD.GetFieldName(bCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(strAccountFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @strCollege";
sSQL += " ,@strDegree";
sSQL += " ,@strDegreeDescEn";
sSQL += " ,@strDegreeDescAr";
sSQL += " ,@bytePassMark";
sSQL += " ,@byteStudyDuration";
sSQL += " ,@byteSemesterDuration";
sSQL += " ,@intCreditHours";
sSQL += " ,@intPracticalHours";
sSQL += " ,@byteMaxCreditHours";
sSQL += " ,@byteMinCreditHours";
sSQL += " ,@bytePreStartDuration";
sSQL += " ,@byteAddSubDuration";
sSQL += " ,@byteSubDuration";
sSQL += " ,@byteMinPassMark";
sSQL += " ,@byteZeroMark";
sSQL += " ,@byteMinGPA";
sSQL += " ,@byteMaxRepeatMark";
sSQL += " ,@bAvgCancel";
sSQL += " ,@byteFailTimes";
sSQL += " ,@byteMaxFailMark";
sSQL += " ,@byteRepeatTrial";
sSQL += " ,@byteRepeatCourse";
sSQL += " ,@bytePostponeSemesters";
sSQL += " ,@bytePostponePreDuration";
sSQL += " ,@byteMaxPostpone";
sSQL += " ,@byteMaxCreditBalance";
sSQL += " ,@byteRepeatMinGPA";
sSQL += " ,@byteMarkAllowed";
sSQL += " ,@strReportEn";
sSQL += " ,@strReportAr";
sSQL += " ,@bCourse";
sSQL += " ,@strAccount";
sSQL += " ,@strUserCreate";
sSQL += " ,@dateCreate";
sSQL += " ,@strUserSave";
sSQL += " ,@dateLastSave";
sSQL += " ,@strMachine";
sSQL += " ,@strNUser";
sSQL += ") ";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
//-----Get GetDeleteCommand Function -----------------------
public string  GetDeleteCommand()
{
string sSQL= "";
try
{
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(strCollegeFN)+"=@strCollege";
sSQL +=  " And " +  LibraryMOD.GetFieldName(strDegreeFN)+"=@strDegree";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
#endregion
public List< Degrees> GetDegrees(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Degrees
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string  sSQL = GetSQL();
if (!string.IsNullOrEmpty(sCondition))
{
sSQL += sCondition;
}
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Degrees> results = new List<Degrees>();
try
{
//Default Value
Degrees myDegrees = new Degrees();
if (isDeafaultIncluded)
{
//Change the code here
myDegrees.strCollege = "0";
myDegrees.strDegree = "0";
myDegrees.strDegreeDescEn = "Select Degree ...";
results.Add(myDegrees);
}
while (reader.Read())
    {
    myDegrees = new Degrees();
    myDegrees.strCollege =reader[LibraryMOD.GetFieldName( strCollegeFN) ].ToString();
    myDegrees.strDegree =reader[LibraryMOD.GetFieldName( strDegreeFN) ].ToString();
    myDegrees.strDegreeDescEn =reader[LibraryMOD.GetFieldName( strDegreeDescEnFN) ].ToString();
    myDegrees.strDegreeDescAr =reader[LibraryMOD.GetFieldName( strDegreeDescArFN) ].ToString();
    //if (reader[LibraryMOD.GetFieldName(bytePassMarkFN)].Equals(DBNull.Value))
    //{
    //myDegrees.bytePassMark = 0;
    //}
    //else
    //{
    //myDegrees.bytePassMark = int.Parse(reader[LibraryMOD.GetFieldName( bytePassMarkFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteStudyDurationFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteStudyDuration = 0;
    //}
    //else
    //{
    //myDegrees.byteStudyDuration = int.Parse(reader[LibraryMOD.GetFieldName( byteStudyDurationFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteSemesterDurationFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteSemesterDuration = 0;
    //}
    //else
    //{
    //myDegrees.byteSemesterDuration = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterDurationFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(intCreditHoursFN)].Equals(DBNull.Value))
    //{
    //myDegrees.intCreditHours = 0;
    //}
    //else
    //{
    //myDegrees.intCreditHours = int.Parse(reader[LibraryMOD.GetFieldName( intCreditHoursFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(intPracticalHoursFN)].Equals(DBNull.Value))
    //{
    //myDegrees.intPracticalHours = 0;
    //}
    //else
    //{
    //myDegrees.intPracticalHours = int.Parse(reader[LibraryMOD.GetFieldName( intPracticalHoursFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMaxCreditHoursFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMaxCreditHours = 0;
    //}
    //else
    //{
    //myDegrees.byteMaxCreditHours = int.Parse(reader[LibraryMOD.GetFieldName( byteMaxCreditHoursFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMinCreditHoursFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMinCreditHours = 0;
    //}
    //else
    //{
    //myDegrees.byteMinCreditHours = int.Parse(reader[LibraryMOD.GetFieldName( byteMinCreditHoursFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(bytePreStartDurationFN)].Equals(DBNull.Value))
    //{
    //myDegrees.bytePreStartDuration = 0;
    //}
    //else
    //{
    //myDegrees.bytePreStartDuration = int.Parse(reader[LibraryMOD.GetFieldName( bytePreStartDurationFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteAddSubDurationFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteAddSubDuration = 0;
    //}
    //else
    //{
    //myDegrees.byteAddSubDuration = int.Parse(reader[LibraryMOD.GetFieldName( byteAddSubDurationFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteSubDurationFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteSubDuration = 0;
    //}
    //else
    //{
    //myDegrees.byteSubDuration = int.Parse(reader[LibraryMOD.GetFieldName( byteSubDurationFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMinPassMarkFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMinPassMark = 0;
    //}
    //else
    //{
    //myDegrees.byteMinPassMark = int.Parse(reader[LibraryMOD.GetFieldName( byteMinPassMarkFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteZeroMarkFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteZeroMark = 0;
    //}
    //else
    //{
    //myDegrees.byteZeroMark = int.Parse(reader[LibraryMOD.GetFieldName( byteZeroMarkFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMinGPAFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMinGPA = 0;
    //}
    //else
    //{
    //myDegrees.byteMinGPA = int.Parse(reader[LibraryMOD.GetFieldName( byteMinGPAFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMaxRepeatMarkFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMaxRepeatMark = 0;
    //}
    //else
    //{
    //myDegrees.byteMaxRepeatMark = int.Parse(reader[LibraryMOD.GetFieldName( byteMaxRepeatMarkFN) ].ToString());
    //}
    //myDegrees.bAvgCancel =reader[LibraryMOD.GetFieldName( bAvgCancelFN) ].ToString();
    //if (reader[LibraryMOD.GetFieldName(byteFailTimesFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteFailTimes = 0;
    //}
    //else
    //{
    //myDegrees.byteFailTimes = int.Parse(reader[LibraryMOD.GetFieldName( byteFailTimesFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMaxFailMarkFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMaxFailMark = 0;
    //}
    //else
    //{
    //myDegrees.byteMaxFailMark = int.Parse(reader[LibraryMOD.GetFieldName( byteMaxFailMarkFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteRepeatTrialFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteRepeatTrial = 0;
    //}
    //else
    //{
    //myDegrees.byteRepeatTrial = int.Parse(reader[LibraryMOD.GetFieldName( byteRepeatTrialFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteRepeatCourseFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteRepeatCourse = 0;
    //}
    //else
    //{
    //myDegrees.byteRepeatCourse = int.Parse(reader[LibraryMOD.GetFieldName( byteRepeatCourseFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(bytePostponeSemestersFN)].Equals(DBNull.Value))
    //{
    //myDegrees.bytePostponeSemesters = 0;
    //}
    //else
    //{
    //myDegrees.bytePostponeSemesters = int.Parse(reader[LibraryMOD.GetFieldName( bytePostponeSemestersFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(bytePostponePreDurationFN)].Equals(DBNull.Value))
    //{
    //myDegrees.bytePostponePreDuration = 0;
    //}
    //else
    //{
    //myDegrees.bytePostponePreDuration = int.Parse(reader[LibraryMOD.GetFieldName( bytePostponePreDurationFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMaxPostponeFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMaxPostpone = 0;
    //}
    //else
    //{
    //myDegrees.byteMaxPostpone = int.Parse(reader[LibraryMOD.GetFieldName( byteMaxPostponeFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMaxCreditBalanceFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMaxCreditBalance = 0;
    //}
    //else
    //{
    //myDegrees.byteMaxCreditBalance = int.Parse(reader[LibraryMOD.GetFieldName( byteMaxCreditBalanceFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteRepeatMinGPAFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteRepeatMinGPA = 0;
    //}
    //else
    //{
    //myDegrees.byteRepeatMinGPA = int.Parse(reader[LibraryMOD.GetFieldName( byteRepeatMinGPAFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(byteMarkAllowedFN)].Equals(DBNull.Value))
    //{
    //myDegrees.byteMarkAllowed = 0;
    //}
    //else
    //{
    //myDegrees.byteMarkAllowed = int.Parse(reader[LibraryMOD.GetFieldName( byteMarkAllowedFN) ].ToString());
    //}
    //myDegrees.strReportEn =reader[LibraryMOD.GetFieldName( strReportEnFN) ].ToString();
    //myDegrees.strReportAr =reader[LibraryMOD.GetFieldName( strReportArFN) ].ToString();
    //myDegrees.bCourse =reader[LibraryMOD.GetFieldName( bCourseFN) ].ToString();
    //myDegrees.strAccount =reader[LibraryMOD.GetFieldName( strAccountFN) ].ToString();

   

    myDegrees.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
    {
        myDegrees.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
    }
    myDegrees.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
    {
        myDegrees.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
    }
    myDegrees.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
    myDegrees.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
    
    results.Add(myDegrees);
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
reader.Close();
reader.Dispose();
Conn.Close();
Conn.Dispose();
}
return results;
}
public int UpdateDegrees(InitializeModule.EnumCampus Campus, int iMode,string strCollege,string strDegree,string strDegreeDescEn,string strDegreeDescAr,int bytePassMark,int byteStudyDuration,int byteSemesterDuration,int intCreditHours,int intPracticalHours,int byteMaxCreditHours,int byteMinCreditHours,int bytePreStartDuration,int byteAddSubDuration,int byteSubDuration,int byteMinPassMark,int byteZeroMark,int byteMinGPA,int byteMaxRepeatMark,string bAvgCancel,int byteFailTimes,int byteMaxFailMark,int byteRepeatTrial,int byteRepeatCourse,int bytePostponeSemesters,int bytePostponePreDuration,int byteMaxPostpone,int byteMaxCreditBalance,int byteRepeatMinGPA,int byteMarkAllowed,string strReportEn,string strReportAr,string bCourse,string strAccount,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Degrees theDegrees = new Degrees();
//'Updates the  table
switch(iMode) 
  {
  case  (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@strCollege",strCollege));
Cmd.Parameters.Add(new SqlParameter("@strDegree",strDegree));
Cmd.Parameters.Add(new SqlParameter("@strDegreeDescEn",strDegreeDescEn));
Cmd.Parameters.Add(new SqlParameter("@strDegreeDescAr",strDegreeDescAr));
Cmd.Parameters.Add(new SqlParameter("@bytePassMark",bytePassMark));
Cmd.Parameters.Add(new SqlParameter("@byteStudyDuration",byteStudyDuration));
Cmd.Parameters.Add(new SqlParameter("@byteSemesterDuration",byteSemesterDuration));
Cmd.Parameters.Add(new SqlParameter("@intCreditHours",intCreditHours));
Cmd.Parameters.Add(new SqlParameter("@intPracticalHours",intPracticalHours));
Cmd.Parameters.Add(new SqlParameter("@byteMaxCreditHours",byteMaxCreditHours));
Cmd.Parameters.Add(new SqlParameter("@byteMinCreditHours",byteMinCreditHours));
Cmd.Parameters.Add(new SqlParameter("@bytePreStartDuration",bytePreStartDuration));
Cmd.Parameters.Add(new SqlParameter("@byteAddSubDuration",byteAddSubDuration));
Cmd.Parameters.Add(new SqlParameter("@byteSubDuration",byteSubDuration));
Cmd.Parameters.Add(new SqlParameter("@byteMinPassMark",byteMinPassMark));
Cmd.Parameters.Add(new SqlParameter("@byteZeroMark",byteZeroMark));
Cmd.Parameters.Add(new SqlParameter("@byteMinGPA",byteMinGPA));
Cmd.Parameters.Add(new SqlParameter("@byteMaxRepeatMark",byteMaxRepeatMark));
Cmd.Parameters.Add(new SqlParameter("@bAvgCancel",bAvgCancel));
Cmd.Parameters.Add(new SqlParameter("@byteFailTimes",byteFailTimes));
Cmd.Parameters.Add(new SqlParameter("@byteMaxFailMark",byteMaxFailMark));
Cmd.Parameters.Add(new SqlParameter("@byteRepeatTrial",byteRepeatTrial));
Cmd.Parameters.Add(new SqlParameter("@byteRepeatCourse",byteRepeatCourse));
Cmd.Parameters.Add(new SqlParameter("@bytePostponeSemesters",bytePostponeSemesters));
Cmd.Parameters.Add(new SqlParameter("@bytePostponePreDuration",bytePostponePreDuration));
Cmd.Parameters.Add(new SqlParameter("@byteMaxPostpone",byteMaxPostpone));
Cmd.Parameters.Add(new SqlParameter("@byteMaxCreditBalance",byteMaxCreditBalance));
Cmd.Parameters.Add(new SqlParameter("@byteRepeatMinGPA",byteRepeatMinGPA));
Cmd.Parameters.Add(new SqlParameter("@byteMarkAllowed",byteMarkAllowed));
Cmd.Parameters.Add(new SqlParameter("@strReportEn",strReportEn));
Cmd.Parameters.Add(new SqlParameter("@strReportAr",strReportAr));
Cmd.Parameters.Add(new SqlParameter("@bCourse",bCourse));
Cmd.Parameters.Add(new SqlParameter("@strAccount",strAccount));
Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));
iEffected = Cmd.ExecuteNonQuery();
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
Conn.Close();
Conn.Dispose();
}
return iEffected;
}
public int DeleteDegrees(InitializeModule.EnumCampus Campus,string strCollege,string strDegree)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege ));
Cmd.Parameters.Add(new SqlParameter("@strDegree", strDegree ));
Conn.Open();
iEffected = Cmd.ExecuteNonQuery();
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
Conn.Close();
Conn.Dispose();
}
return iEffected;
}
public DataView GetDataView(bool isFromRole,int PK,string sCondition)
{
DataTable dt = new DataTable("Degrees");
DataView dv = new DataView();
List<Degrees> myDegreess = new List<Degrees>();
try
{
myDegreess = GetDegrees(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("strCollege", Type.GetType("nvarchar"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strDegree", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strDegreeDescEn", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myDegreess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myDegreess[i].strCollege;
  dr[2] = myDegreess[i].strDegree;
  dr[3] = myDegreess[i].strDegreeDescEn;
  dt.Rows.Add(dr);
}
dt.AcceptChanges();
dv.Table = dt;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
myDegreess.Clear();
}
 return dv;
}
//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += strCollegeFN;
//sSQL += " , " + ";
sSQL += "  FROM " + m_TableName;
SqlDataAdapter adapter = new SqlDataAdapter(sSQL, con);
//'table.Locale = System.Globalization.CultureInfo.InvariantCulture
adapter.Fill(table);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return table;
}
//end class tow
}
public class DegreesCls : DegreesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daDegrees;
private DataSet m_dsDegrees;
public DataRow DegreesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsDegrees
{
get { return m_dsDegrees ; }
set { m_dsDegrees = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public DegreesCls()
{
try
{
dsDegrees= new DataSet();

}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
//-------Get DataAdapter  -----------------------------
#region "DataAdapter"
public virtual SqlDataAdapter GetDegreesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daDegrees = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daDegrees);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daDegrees.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDegrees;
}
public virtual SqlDataAdapter GetDegreesDataAdapter(SqlConnection con)  
{
try
{
daDegrees = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daDegrees.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdDegrees;
cmdDegrees = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@strCollege", SqlDbType.Int, 4, "strCollege" );
//'cmdRolePermission.Parameters.Add("@strDegree", SqlDbType.Int, 4, "strDegree" );
daDegrees.SelectCommand = cmdDegrees;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdDegrees = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdDegrees.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
//cmdDegrees.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdDegrees.Parameters.Add("@strDegreeDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDegreeDescEnFN));
cmdDegrees.Parameters.Add("@strDegreeDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDegreeDescArFN));
cmdDegrees.Parameters.Add("@bytePassMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePassMarkFN));
cmdDegrees.Parameters.Add("@byteStudyDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudyDurationFN));
cmdDegrees.Parameters.Add("@byteSemesterDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterDurationFN));
cmdDegrees.Parameters.Add("@intCreditHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCreditHoursFN));
cmdDegrees.Parameters.Add("@intPracticalHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(intPracticalHoursFN));
cmdDegrees.Parameters.Add("@byteMaxCreditHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxCreditHoursFN));
cmdDegrees.Parameters.Add("@byteMinCreditHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinCreditHoursFN));
cmdDegrees.Parameters.Add("@bytePreStartDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePreStartDurationFN));
cmdDegrees.Parameters.Add("@byteAddSubDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteAddSubDurationFN));
cmdDegrees.Parameters.Add("@byteSubDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSubDurationFN));
cmdDegrees.Parameters.Add("@byteMinPassMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinPassMarkFN));
cmdDegrees.Parameters.Add("@byteZeroMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteZeroMarkFN));
cmdDegrees.Parameters.Add("@byteMinGPA", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinGPAFN));
cmdDegrees.Parameters.Add("@byteMaxRepeatMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxRepeatMarkFN));
cmdDegrees.Parameters.Add("@bAvgCancel", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bAvgCancelFN));
cmdDegrees.Parameters.Add("@byteFailTimes", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFailTimesFN));
cmdDegrees.Parameters.Add("@byteMaxFailMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxFailMarkFN));
cmdDegrees.Parameters.Add("@byteRepeatTrial", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRepeatTrialFN));
cmdDegrees.Parameters.Add("@byteRepeatCourse", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRepeatCourseFN));
cmdDegrees.Parameters.Add("@bytePostponeSemesters", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePostponeSemestersFN));
cmdDegrees.Parameters.Add("@bytePostponePreDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePostponePreDurationFN));
cmdDegrees.Parameters.Add("@byteMaxPostpone", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxPostponeFN));
cmdDegrees.Parameters.Add("@byteMaxCreditBalance", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxCreditBalanceFN));
cmdDegrees.Parameters.Add("@byteRepeatMinGPA", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRepeatMinGPAFN));
cmdDegrees.Parameters.Add("@byteMarkAllowed", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMarkAllowedFN));
cmdDegrees.Parameters.Add("@strReportEn", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strReportEnFN));
cmdDegrees.Parameters.Add("@strReportAr", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strReportArFN));
cmdDegrees.Parameters.Add("@bCourse", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bCourseFN));
cmdDegrees.Parameters.Add("@strAccount", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strAccountFN));
cmdDegrees.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdDegrees.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdDegrees.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdDegrees.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdDegrees.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdDegrees.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdDegrees.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
Parmeter = cmdDegrees.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daDegrees.UpdateCommand = cmdDegrees;
daDegrees.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdDegrees = new SqlCommand(GetInsertCommand(), con);
cmdDegrees.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
cmdDegrees.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdDegrees.Parameters.Add("@strDegreeDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDegreeDescEnFN));
cmdDegrees.Parameters.Add("@strDegreeDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDegreeDescArFN));
cmdDegrees.Parameters.Add("@bytePassMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePassMarkFN));
cmdDegrees.Parameters.Add("@byteStudyDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudyDurationFN));
cmdDegrees.Parameters.Add("@byteSemesterDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterDurationFN));
cmdDegrees.Parameters.Add("@intCreditHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCreditHoursFN));
cmdDegrees.Parameters.Add("@intPracticalHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(intPracticalHoursFN));
cmdDegrees.Parameters.Add("@byteMaxCreditHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxCreditHoursFN));
cmdDegrees.Parameters.Add("@byteMinCreditHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinCreditHoursFN));
cmdDegrees.Parameters.Add("@bytePreStartDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePreStartDurationFN));
cmdDegrees.Parameters.Add("@byteAddSubDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteAddSubDurationFN));
cmdDegrees.Parameters.Add("@byteSubDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSubDurationFN));
cmdDegrees.Parameters.Add("@byteMinPassMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinPassMarkFN));
cmdDegrees.Parameters.Add("@byteZeroMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteZeroMarkFN));
cmdDegrees.Parameters.Add("@byteMinGPA", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinGPAFN));
cmdDegrees.Parameters.Add("@byteMaxRepeatMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxRepeatMarkFN));
cmdDegrees.Parameters.Add("@bAvgCancel", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bAvgCancelFN));
cmdDegrees.Parameters.Add("@byteFailTimes", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFailTimesFN));
cmdDegrees.Parameters.Add("@byteMaxFailMark", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxFailMarkFN));
cmdDegrees.Parameters.Add("@byteRepeatTrial", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRepeatTrialFN));
cmdDegrees.Parameters.Add("@byteRepeatCourse", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRepeatCourseFN));
cmdDegrees.Parameters.Add("@bytePostponeSemesters", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePostponeSemestersFN));
cmdDegrees.Parameters.Add("@bytePostponePreDuration", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytePostponePreDurationFN));
cmdDegrees.Parameters.Add("@byteMaxPostpone", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxPostponeFN));
cmdDegrees.Parameters.Add("@byteMaxCreditBalance", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMaxCreditBalanceFN));
cmdDegrees.Parameters.Add("@byteRepeatMinGPA", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRepeatMinGPAFN));
cmdDegrees.Parameters.Add("@byteMarkAllowed", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMarkAllowedFN));
cmdDegrees.Parameters.Add("@strReportEn", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strReportEnFN));
cmdDegrees.Parameters.Add("@strReportAr", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strReportArFN));
cmdDegrees.Parameters.Add("@bCourse", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bCourseFN));
cmdDegrees.Parameters.Add("@strAccount", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strAccountFN));
cmdDegrees.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdDegrees.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdDegrees.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdDegrees.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdDegrees.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdDegrees.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daDegrees.InsertCommand =cmdDegrees;
daDegrees.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdDegrees = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdDegrees.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
Parmeter = cmdDegrees.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daDegrees.DeleteCommand =cmdDegrees;
daDegrees.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daDegrees.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDegrees;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsDegrees.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
dr[LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
dr[LibraryMOD.GetFieldName(strDegreeDescEnFN)]=strDegreeDescEn;
dr[LibraryMOD.GetFieldName(strDegreeDescArFN)]=strDegreeDescAr;
dr[LibraryMOD.GetFieldName(bytePassMarkFN)]=bytePassMark;
dr[LibraryMOD.GetFieldName(byteStudyDurationFN)]=byteStudyDuration;
dr[LibraryMOD.GetFieldName(byteSemesterDurationFN)]=byteSemesterDuration;
dr[LibraryMOD.GetFieldName(intCreditHoursFN)]=intCreditHours;
dr[LibraryMOD.GetFieldName(intPracticalHoursFN)]=intPracticalHours;
dr[LibraryMOD.GetFieldName(byteMaxCreditHoursFN)]=byteMaxCreditHours;
dr[LibraryMOD.GetFieldName(byteMinCreditHoursFN)]=byteMinCreditHours;
dr[LibraryMOD.GetFieldName(bytePreStartDurationFN)]=bytePreStartDuration;
dr[LibraryMOD.GetFieldName(byteAddSubDurationFN)]=byteAddSubDuration;
dr[LibraryMOD.GetFieldName(byteSubDurationFN)]=byteSubDuration;
dr[LibraryMOD.GetFieldName(byteMinPassMarkFN)]=byteMinPassMark;
dr[LibraryMOD.GetFieldName(byteZeroMarkFN)]=byteZeroMark;
dr[LibraryMOD.GetFieldName(byteMinGPAFN)]=byteMinGPA;
dr[LibraryMOD.GetFieldName(byteMaxRepeatMarkFN)]=byteMaxRepeatMark;
dr[LibraryMOD.GetFieldName(bAvgCancelFN)]=bAvgCancel;
dr[LibraryMOD.GetFieldName(byteFailTimesFN)]=byteFailTimes;
dr[LibraryMOD.GetFieldName(byteMaxFailMarkFN)]=byteMaxFailMark;
dr[LibraryMOD.GetFieldName(byteRepeatTrialFN)]=byteRepeatTrial;
dr[LibraryMOD.GetFieldName(byteRepeatCourseFN)]=byteRepeatCourse;
dr[LibraryMOD.GetFieldName(bytePostponeSemestersFN)]=bytePostponeSemesters;
dr[LibraryMOD.GetFieldName(bytePostponePreDurationFN)]=bytePostponePreDuration;
dr[LibraryMOD.GetFieldName(byteMaxPostponeFN)]=byteMaxPostpone;
dr[LibraryMOD.GetFieldName(byteMaxCreditBalanceFN)]=byteMaxCreditBalance;
dr[LibraryMOD.GetFieldName(byteRepeatMinGPAFN)]=byteRepeatMinGPA;
dr[LibraryMOD.GetFieldName(byteMarkAllowedFN)]=byteMarkAllowed;
dr[LibraryMOD.GetFieldName(strReportEnFN)]=strReportEn;
dr[LibraryMOD.GetFieldName(strReportArFN)]=strReportAr;
dr[LibraryMOD.GetFieldName(bCourseFN)]=bCourse;
dr[LibraryMOD.GetFieldName(strAccountFN)]=strAccount;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsDegrees.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsDegrees.Tables[TableName].Select(LibraryMOD.GetFieldName(strCollegeFN)  + "=" + strCollege  + " AND " + LibraryMOD.GetFieldName(strDegreeFN) + "=" + strDegree);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
drAry[0][LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
drAry[0][LibraryMOD.GetFieldName(strDegreeDescEnFN)]=strDegreeDescEn;
drAry[0][LibraryMOD.GetFieldName(strDegreeDescArFN)]=strDegreeDescAr;
drAry[0][LibraryMOD.GetFieldName(bytePassMarkFN)]=bytePassMark;
drAry[0][LibraryMOD.GetFieldName(byteStudyDurationFN)]=byteStudyDuration;
drAry[0][LibraryMOD.GetFieldName(byteSemesterDurationFN)]=byteSemesterDuration;
drAry[0][LibraryMOD.GetFieldName(intCreditHoursFN)]=intCreditHours;
drAry[0][LibraryMOD.GetFieldName(intPracticalHoursFN)]=intPracticalHours;
drAry[0][LibraryMOD.GetFieldName(byteMaxCreditHoursFN)]=byteMaxCreditHours;
drAry[0][LibraryMOD.GetFieldName(byteMinCreditHoursFN)]=byteMinCreditHours;
drAry[0][LibraryMOD.GetFieldName(bytePreStartDurationFN)]=bytePreStartDuration;
drAry[0][LibraryMOD.GetFieldName(byteAddSubDurationFN)]=byteAddSubDuration;
drAry[0][LibraryMOD.GetFieldName(byteSubDurationFN)]=byteSubDuration;
drAry[0][LibraryMOD.GetFieldName(byteMinPassMarkFN)]=byteMinPassMark;
drAry[0][LibraryMOD.GetFieldName(byteZeroMarkFN)]=byteZeroMark;
drAry[0][LibraryMOD.GetFieldName(byteMinGPAFN)]=byteMinGPA;
drAry[0][LibraryMOD.GetFieldName(byteMaxRepeatMarkFN)]=byteMaxRepeatMark;
drAry[0][LibraryMOD.GetFieldName(bAvgCancelFN)]=bAvgCancel;
drAry[0][LibraryMOD.GetFieldName(byteFailTimesFN)]=byteFailTimes;
drAry[0][LibraryMOD.GetFieldName(byteMaxFailMarkFN)]=byteMaxFailMark;
drAry[0][LibraryMOD.GetFieldName(byteRepeatTrialFN)]=byteRepeatTrial;
drAry[0][LibraryMOD.GetFieldName(byteRepeatCourseFN)]=byteRepeatCourse;
drAry[0][LibraryMOD.GetFieldName(bytePostponeSemestersFN)]=bytePostponeSemesters;
drAry[0][LibraryMOD.GetFieldName(bytePostponePreDurationFN)]=bytePostponePreDuration;
drAry[0][LibraryMOD.GetFieldName(byteMaxPostponeFN)]=byteMaxPostpone;
drAry[0][LibraryMOD.GetFieldName(byteMaxCreditBalanceFN)]=byteMaxCreditBalance;
drAry[0][LibraryMOD.GetFieldName(byteRepeatMinGPAFN)]=byteRepeatMinGPA;
drAry[0][LibraryMOD.GetFieldName(byteMarkAllowedFN)]=byteMarkAllowed;
drAry[0][LibraryMOD.GetFieldName(strReportEnFN)]=strReportEn;
drAry[0][LibraryMOD.GetFieldName(strReportArFN)]=strReportAr;
drAry[0][LibraryMOD.GetFieldName(bCourseFN)]=bCourse;
drAry[0][LibraryMOD.GetFieldName(strAccountFN)]=strAccount;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = DateTime.Now;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
break;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitDegrees()  
{
//CommitDegrees= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daDegrees.Update(dsDegrees, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(strCollege,strDegree);
if (( DegreesDataRow != null)) 
{
DegreesDataRow.Delete();
CommitDegrees();
if (MoveNext() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (DegreesDataRow[LibraryMOD.GetFieldName(strCollegeFN)]== System.DBNull.Value)
{
  strCollege="";
}
else
{
  strCollege = (string)DegreesDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strDegreeFN)]== System.DBNull.Value)
{
  strDegree="";
}
else
{
  strDegree = (string)DegreesDataRow[LibraryMOD.GetFieldName(strDegreeFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strDegreeDescEnFN)]== System.DBNull.Value)
{
  strDegreeDescEn="";
}
else
{
  strDegreeDescEn = (string)DegreesDataRow[LibraryMOD.GetFieldName(strDegreeDescEnFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strDegreeDescArFN)]== System.DBNull.Value)
{
  strDegreeDescAr="";
}
else
{
  strDegreeDescAr = (string)DegreesDataRow[LibraryMOD.GetFieldName(strDegreeDescArFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(bytePassMarkFN)]== System.DBNull.Value)
{
  bytePassMark=0;
}
else
{
  bytePassMark = (int)DegreesDataRow[LibraryMOD.GetFieldName(bytePassMarkFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteStudyDurationFN)]== System.DBNull.Value)
{
  byteStudyDuration=0;
}
else
{
  byteStudyDuration = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteStudyDurationFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteSemesterDurationFN)]== System.DBNull.Value)
{
  byteSemesterDuration=0;
}
else
{
  byteSemesterDuration = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteSemesterDurationFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(intCreditHoursFN)]== System.DBNull.Value)
{
  intCreditHours=0;
}
else
{
  intCreditHours = (int)DegreesDataRow[LibraryMOD.GetFieldName(intCreditHoursFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(intPracticalHoursFN)]== System.DBNull.Value)
{
  intPracticalHours=0;
}
else
{
  intPracticalHours = (int)DegreesDataRow[LibraryMOD.GetFieldName(intPracticalHoursFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMaxCreditHoursFN)]== System.DBNull.Value)
{
  byteMaxCreditHours=0;
}
else
{
  byteMaxCreditHours = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMaxCreditHoursFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMinCreditHoursFN)]== System.DBNull.Value)
{
  byteMinCreditHours=0;
}
else
{
  byteMinCreditHours = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMinCreditHoursFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(bytePreStartDurationFN)]== System.DBNull.Value)
{
  bytePreStartDuration=0;
}
else
{
  bytePreStartDuration = (int)DegreesDataRow[LibraryMOD.GetFieldName(bytePreStartDurationFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteAddSubDurationFN)]== System.DBNull.Value)
{
  byteAddSubDuration=0;
}
else
{
  byteAddSubDuration = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteAddSubDurationFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteSubDurationFN)]== System.DBNull.Value)
{
  byteSubDuration=0;
}
else
{
  byteSubDuration = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteSubDurationFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMinPassMarkFN)]== System.DBNull.Value)
{
  byteMinPassMark=0;
}
else
{
  byteMinPassMark = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMinPassMarkFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteZeroMarkFN)]== System.DBNull.Value)
{
  byteZeroMark=0;
}
else
{
  byteZeroMark = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteZeroMarkFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMinGPAFN)]== System.DBNull.Value)
{
  byteMinGPA=0;
}
else
{
  byteMinGPA = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMinGPAFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMaxRepeatMarkFN)]== System.DBNull.Value)
{
  byteMaxRepeatMark=0;
}
else
{
  byteMaxRepeatMark = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMaxRepeatMarkFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(bAvgCancelFN)]== System.DBNull.Value)
{
  bAvgCancel="";
}
else
{
  bAvgCancel = (string)DegreesDataRow[LibraryMOD.GetFieldName(bAvgCancelFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteFailTimesFN)]== System.DBNull.Value)
{
  byteFailTimes=0;
}
else
{
  byteFailTimes = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteFailTimesFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMaxFailMarkFN)]== System.DBNull.Value)
{
  byteMaxFailMark=0;
}
else
{
  byteMaxFailMark = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMaxFailMarkFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteRepeatTrialFN)]== System.DBNull.Value)
{
  byteRepeatTrial=0;
}
else
{
  byteRepeatTrial = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteRepeatTrialFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteRepeatCourseFN)]== System.DBNull.Value)
{
  byteRepeatCourse=0;
}
else
{
  byteRepeatCourse = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteRepeatCourseFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(bytePostponeSemestersFN)]== System.DBNull.Value)
{
  bytePostponeSemesters=0;
}
else
{
  bytePostponeSemesters = (int)DegreesDataRow[LibraryMOD.GetFieldName(bytePostponeSemestersFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(bytePostponePreDurationFN)]== System.DBNull.Value)
{
  bytePostponePreDuration=0;
}
else
{
  bytePostponePreDuration = (int)DegreesDataRow[LibraryMOD.GetFieldName(bytePostponePreDurationFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMaxPostponeFN)]== System.DBNull.Value)
{
  byteMaxPostpone=0;
}
else
{
  byteMaxPostpone = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMaxPostponeFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMaxCreditBalanceFN)]== System.DBNull.Value)
{
  byteMaxCreditBalance=0;
}
else
{
  byteMaxCreditBalance = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMaxCreditBalanceFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteRepeatMinGPAFN)]== System.DBNull.Value)
{
  byteRepeatMinGPA=0;
}
else
{
  byteRepeatMinGPA = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteRepeatMinGPAFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(byteMarkAllowedFN)]== System.DBNull.Value)
{
  byteMarkAllowed=0;
}
else
{
  byteMarkAllowed = (int)DegreesDataRow[LibraryMOD.GetFieldName(byteMarkAllowedFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strReportEnFN)]== System.DBNull.Value)
{
  strReportEn="";
}
else
{
  strReportEn = (string)DegreesDataRow[LibraryMOD.GetFieldName(strReportEnFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strReportArFN)]== System.DBNull.Value)
{
  strReportAr="";
}
else
{
  strReportAr = (string)DegreesDataRow[LibraryMOD.GetFieldName(strReportArFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(bCourseFN)]== System.DBNull.Value)
{
  bCourse="";
}
else
{
  bCourse = (string)DegreesDataRow[LibraryMOD.GetFieldName(bCourseFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strAccountFN)]== System.DBNull.Value)
{
  strAccount="";
}
else
{
  strAccount = (string)DegreesDataRow[LibraryMOD.GetFieldName(strAccountFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)DegreesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)DegreesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)DegreesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)DegreesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)DegreesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (DegreesDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)DegreesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(string PKstrCollege,string PKstrDegree) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKstrCollege;
findTheseVals[1] = PKstrDegree;
DegreesDataRow = dsDegrees.Tables[TableName].Rows.Find(findTheseVals);
if  ((DegreesDataRow !=null)) 
{
lngCurRow = dsDegrees.Tables[TableName].Rows.IndexOf(DegreesDataRow);
SynchronizeDataRowToClass();
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsDegrees.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsDegrees.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsDegrees.Tables[TableName].Rows.Count > 0) 
{
  DegreesDataRow = dsDegrees.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
// ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
daDegrees.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDegrees.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daDegrees.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDegrees.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------OnRowUpdating  -----------------------------
private static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs args)
{
try
{
if (args.StatementType == StatementType.Delete )
{
System.IO.TextWriter tw = System.IO.File.AppendText("Delete.log");
tw.Close();
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
//'-------OnRowUpdated  -----------------------------
private static void  OnRowUpdated( object sender, SqlRowUpdatedEventArgs args)
{
try
{
if (args.Status == UpdateStatus.ErrorsOccurred )
{
args.Row.RowError = args.Errors.Message;
System.IO.File.AppendText("Delete.log");
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
#endregion
//end third class
}
