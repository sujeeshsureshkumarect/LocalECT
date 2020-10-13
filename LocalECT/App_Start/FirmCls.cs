using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public class Firm
{
//Creation Date: 25/05/2011 11:49 AM
//Programmer Name : Bahaa Addin
//-----Decleration --------------
#region "Decleration"
private int m_byteFirm; 
private string m_strFirmDesc; 
private string m_strPhone1; 
private string m_strPhone2; 
private string m_strTelex; 
private string m_strFax; 
private string m_strEmail; 
private string m_strUrl; 
private string m_strPobox; 
private string m_strZipCode; 
private string m_strAddress; 
private string m_strRegistration; 
private DateTime m_dateRegistration; 
private int m_byteStartMonth; 
private DateTime m_dateLastPeriod; 
private string m_oleLogo; 
private int m_byteGraduation; 
private int m_byteCancel; 
private int m_byteGrades; 
private int m_intStudyYear; 
private int m_byteSemester; 
private int m_intRegYear; 
private int m_byteRegSemester; 
private int m_intNewYear; 
private int m_byteNewSemester; 
private int m_intCurrentYear; 
private int m_byteCurrentSemester; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int byteFirm
{
get { return  m_byteFirm; }
set {m_byteFirm  = value ; }
}
public string strFirmDesc
{
get { return  m_strFirmDesc; }
set {m_strFirmDesc  = value ; }
}
public string strPhone1
{
get { return  m_strPhone1; }
set {m_strPhone1  = value ; }
}
public string strPhone2
{
get { return  m_strPhone2; }
set {m_strPhone2  = value ; }
}
public string strTelex
{
get { return  m_strTelex; }
set {m_strTelex  = value ; }
}
public string strFax
{
get { return  m_strFax; }
set {m_strFax  = value ; }
}
public string strEmail
{
get { return  m_strEmail; }
set {m_strEmail  = value ; }
}
public string strUrl
{
get { return  m_strUrl; }
set {m_strUrl  = value ; }
}
public string strPobox
{
get { return  m_strPobox; }
set {m_strPobox  = value ; }
}
public string strZipCode
{
get { return  m_strZipCode; }
set {m_strZipCode  = value ; }
}
public string strAddress
{
get { return  m_strAddress; }
set {m_strAddress  = value ; }
}
public string strRegistration
{
get { return  m_strRegistration; }
set {m_strRegistration  = value ; }
}
public DateTime dateRegistration
{
get { return  m_dateRegistration; }
set {m_dateRegistration  = value ; }
}
public int byteStartMonth
{
get { return  m_byteStartMonth; }
set {m_byteStartMonth  = value ; }
}
public DateTime dateLastPeriod
{
get { return  m_dateLastPeriod; }
set {m_dateLastPeriod  = value ; }
}
public string oleLogo
{
get { return  m_oleLogo; }
set {m_oleLogo  = value ; }
}
public int byteGraduation
{
get { return  m_byteGraduation; }
set {m_byteGraduation  = value ; }
}
public int byteCancel
{
get { return  m_byteCancel; }
set {m_byteCancel  = value ; }
}
public int byteGrades
{
get { return  m_byteGrades; }
set {m_byteGrades  = value ; }
}
public int intStudyYear
{
get { return  m_intStudyYear; }
set {m_intStudyYear  = value ; }
}
public int byteSemester
{
get { return  m_byteSemester; }
set {m_byteSemester  = value ; }
}
public int intRegYear
{
get { return  m_intRegYear; }
set {m_intRegYear  = value ; }
}
public int byteRegSemester
{
get { return  m_byteRegSemester; }
set {m_byteRegSemester  = value ; }
}
public int intNewYear
{
get { return  m_intNewYear; }
set {m_intNewYear  = value ; }
}
public int byteNewSemester
{
get { return  m_byteNewSemester; }
set {m_byteNewSemester  = value ; }
}
public int intCurrentYear
{
get { return  m_intCurrentYear; }
set {m_intCurrentYear  = value ; }
}
public int byteCurrentSemester
{
get { return  m_byteCurrentSemester; }
set {m_byteCurrentSemester  = value ; }
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
public Firm()
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
public class FirmDAL : Firm
{
#region "Decleration"
private string m_TableName;
private string m_byteFirmFN ;
private string m_strFirmDescFN ;
private string m_strPhone1FN ;
private string m_strPhone2FN ;
private string m_strTelexFN ;
private string m_strFaxFN ;
private string m_strEmailFN ;
private string m_strUrlFN ;
private string m_strPoboxFN ;
private string m_strZipCodeFN ;
private string m_strAddressFN ;
private string m_strRegistrationFN ;
private string m_dateRegistrationFN ;
private string m_byteStartMonthFN ;
private string m_dateLastPeriodFN ;
private string m_oleLogoFN ;
private string m_byteGraduationFN ;
private string m_byteCancelFN ;
private string m_byteGradesFN ;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_intRegYearFN ;
private string m_byteRegSemesterFN ;
private string m_intNewYearFN ;
private string m_byteNewSemesterFN ;
private string m_intCurrentYearFN ;
private string m_byteCurrentSemesterFN ;
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
public string byteFirmFN 
{
get { return  m_byteFirmFN; }
set {m_byteFirmFN  = value ; }
}
public string strFirmDescFN 
{
get { return  m_strFirmDescFN; }
set {m_strFirmDescFN  = value ; }
}
public string strPhone1FN 
{
get { return  m_strPhone1FN; }
set {m_strPhone1FN  = value ; }
}
public string strPhone2FN 
{
get { return  m_strPhone2FN; }
set {m_strPhone2FN  = value ; }
}
public string strTelexFN 
{
get { return  m_strTelexFN; }
set {m_strTelexFN  = value ; }
}
public string strFaxFN 
{
get { return  m_strFaxFN; }
set {m_strFaxFN  = value ; }
}
public string strEmailFN 
{
get { return  m_strEmailFN; }
set {m_strEmailFN  = value ; }
}
public string strUrlFN 
{
get { return  m_strUrlFN; }
set {m_strUrlFN  = value ; }
}
public string strPoboxFN 
{
get { return  m_strPoboxFN; }
set {m_strPoboxFN  = value ; }
}
public string strZipCodeFN 
{
get { return  m_strZipCodeFN; }
set {m_strZipCodeFN  = value ; }
}
public string strAddressFN 
{
get { return  m_strAddressFN; }
set {m_strAddressFN  = value ; }
}
public string strRegistrationFN 
{
get { return  m_strRegistrationFN; }
set {m_strRegistrationFN  = value ; }
}
public string dateRegistrationFN 
{
get { return  m_dateRegistrationFN; }
set {m_dateRegistrationFN  = value ; }
}
public string byteStartMonthFN 
{
get { return  m_byteStartMonthFN; }
set {m_byteStartMonthFN  = value ; }
}
public string dateLastPeriodFN 
{
get { return  m_dateLastPeriodFN; }
set {m_dateLastPeriodFN  = value ; }
}
public string oleLogoFN 
{
get { return  m_oleLogoFN; }
set {m_oleLogoFN  = value ; }
}
public string byteGraduationFN 
{
get { return  m_byteGraduationFN; }
set {m_byteGraduationFN  = value ; }
}
public string byteCancelFN 
{
get { return  m_byteCancelFN; }
set {m_byteCancelFN  = value ; }
}
public string byteGradesFN 
{
get { return  m_byteGradesFN; }
set {m_byteGradesFN  = value ; }
}
public string intStudyYearFN 
{
get { return  m_intStudyYearFN; }
set {m_intStudyYearFN  = value ; }
}
public string byteSemesterFN 
{
get { return  m_byteSemesterFN; }
set {m_byteSemesterFN  = value ; }
}
public string intRegYearFN 
{
get { return  m_intRegYearFN; }
set {m_intRegYearFN  = value ; }
}
public string byteRegSemesterFN 
{
get { return  m_byteRegSemesterFN; }
set {m_byteRegSemesterFN  = value ; }
}
public string intNewYearFN 
{
get { return  m_intNewYearFN; }
set {m_intNewYearFN  = value ; }
}
public string byteNewSemesterFN 
{
get { return  m_byteNewSemesterFN; }
set {m_byteNewSemesterFN  = value ; }
}
public string intCurrentYearFN 
{
get { return  m_intCurrentYearFN; }
set {m_intCurrentYearFN  = value ; }
}
public string byteCurrentSemesterFN 
{
get { return  m_byteCurrentSemesterFN; }
set {m_byteCurrentSemesterFN  = value ; }
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
public FirmDAL()
{
try
{
this.TableName = "Cmn_Firm";
this.byteFirmFN = m_TableName + ".byteFirm";
this.strFirmDescFN = m_TableName + ".strFirmDesc";
this.strPhone1FN = m_TableName + ".strPhone1";
this.strPhone2FN = m_TableName + ".strPhone2";
this.strTelexFN = m_TableName + ".strTelex";
this.strFaxFN = m_TableName + ".strFax";
this.strEmailFN = m_TableName + ".strEmail";
this.strUrlFN = m_TableName + ".strUrl";
this.strPoboxFN = m_TableName + ".strPobox";
this.strZipCodeFN = m_TableName + ".strZipCode";
this.strAddressFN = m_TableName + ".strAddress";
this.strRegistrationFN = m_TableName + ".strRegistration";
this.dateRegistrationFN = m_TableName + ".dateRegistration";
this.byteStartMonthFN = m_TableName + ".byteStartMonth";
this.dateLastPeriodFN = m_TableName + ".dateLastPeriod";
this.oleLogoFN = m_TableName + ".oleLogo";
this.byteGraduationFN = m_TableName + ".byteGraduation";
this.byteCancelFN = m_TableName + ".byteCancel";
this.byteGradesFN = m_TableName + ".byteGrades";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.intRegYearFN = m_TableName + ".intRegYear";
this.byteRegSemesterFN = m_TableName + ".byteRegSemester";
this.intNewYearFN = m_TableName + ".intNewYear";
this.byteNewSemesterFN = m_TableName + ".byteNewSemester";
this.intCurrentYearFN = m_TableName + ".intCurrentYear";
this.byteCurrentSemesterFN = m_TableName + ".byteCurrentSemester";
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
sSQL +=byteFirmFN;
sSQL += " , " + strFirmDescFN;
sSQL += " , " + strPhone1FN;
sSQL += " , " + strPhone2FN;
sSQL += " , " + strTelexFN;
sSQL += " , " + strFaxFN;
sSQL += " , " + strEmailFN;
sSQL += " , " + strUrlFN;
sSQL += " , " + strPoboxFN;
sSQL += " , " + strZipCodeFN;
sSQL += " , " + strAddressFN;
sSQL += " , " + strRegistrationFN;
sSQL += " , " + dateRegistrationFN;
sSQL += " , " + byteStartMonthFN;
sSQL += " , " + dateLastPeriodFN;
sSQL += " , " + oleLogoFN;
sSQL += " , " + byteGraduationFN;
sSQL += " , " + byteCancelFN;
sSQL += " , " + byteGradesFN;
sSQL += " , " + intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + intRegYearFN;
sSQL += " , " + byteRegSemesterFN;
sSQL += " , " + intNewYearFN;
sSQL += " , " + byteNewSemesterFN;
sSQL += " , " + intCurrentYearFN;
sSQL += " , " + byteCurrentSemesterFN;
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
//-----GetListSQl Function ---------------------------------
public string  GetListSQL(string  sCondition ) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=byteFirmFN;
sSQL += " , " + strFirmDescFN;
sSQL += " , " + strPhone1FN;
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
sSQL +=byteFirmFN;
sSQL += " , " + strFirmDescFN;
sSQL += " , " + strPhone1FN;
sSQL += " , " + strPhone2FN;
sSQL += " , " + strTelexFN;
sSQL += " , " + strFaxFN;
sSQL += " , " + strEmailFN;
sSQL += " , " + strUrlFN;
sSQL += " , " + strPoboxFN;
sSQL += " , " + strZipCodeFN;
sSQL += " , " + strAddressFN;
sSQL += " , " + strRegistrationFN;
sSQL += " , " + dateRegistrationFN;
sSQL += " , " + byteStartMonthFN;
sSQL += " , " + dateLastPeriodFN;
sSQL += " , " + oleLogoFN;
sSQL += " , " + byteGraduationFN;
sSQL += " , " + byteCancelFN;
sSQL += " , " + byteGradesFN;
sSQL += " , " + intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + intRegYearFN;
sSQL += " , " + byteRegSemesterFN;
sSQL += " , " + intNewYearFN;
sSQL += " , " + byteNewSemesterFN;
sSQL += " , " + intCurrentYearFN;
sSQL += " , " + byteCurrentSemesterFN;
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
sSQL += LibraryMOD.GetFieldName(byteFirmFN) + "=@byteFirm";
sSQL += " , " + LibraryMOD.GetFieldName(strFirmDescFN) + "=@strFirmDesc";
sSQL += " , " + LibraryMOD.GetFieldName(strPhone1FN) + "=@strPhone1";
sSQL += " , " + LibraryMOD.GetFieldName(strPhone2FN) + "=@strPhone2";
sSQL += " , " + LibraryMOD.GetFieldName(strTelexFN) + "=@strTelex";
sSQL += " , " + LibraryMOD.GetFieldName(strFaxFN) + "=@strFax";
sSQL += " , " + LibraryMOD.GetFieldName(strEmailFN) + "=@strEmail";
sSQL += " , " + LibraryMOD.GetFieldName(strUrlFN) + "=@strUrl";
sSQL += " , " + LibraryMOD.GetFieldName(strPoboxFN) + "=@strPobox";
sSQL += " , " + LibraryMOD.GetFieldName(strZipCodeFN) + "=@strZipCode";
sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN) + "=@strAddress";
sSQL += " , " + LibraryMOD.GetFieldName(strRegistrationFN) + "=@strRegistration";
sSQL += " , " + LibraryMOD.GetFieldName(dateRegistrationFN) + "=@dateRegistration";
sSQL += " , " + LibraryMOD.GetFieldName(byteStartMonthFN) + "=@byteStartMonth";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastPeriodFN) + "=@dateLastPeriod";
sSQL += " , " + LibraryMOD.GetFieldName(oleLogoFN) + "=@oleLogo";
sSQL += " , " + LibraryMOD.GetFieldName(byteGraduationFN) + "=@byteGraduation";
sSQL += " , " + LibraryMOD.GetFieldName(byteCancelFN) + "=@byteCancel";
sSQL += " , " + LibraryMOD.GetFieldName(byteGradesFN) + "=@byteGrades";
sSQL += " , " + LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
sSQL += " , " + LibraryMOD.GetFieldName(intRegYearFN) + "=@intRegYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteRegSemesterFN) + "=@byteRegSemester";
sSQL += " , " + LibraryMOD.GetFieldName(intNewYearFN) + "=@intNewYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteNewSemesterFN) + "=@byteNewSemester";
sSQL += " , " + LibraryMOD.GetFieldName(intCurrentYearFN) + "=@intCurrentYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteCurrentSemesterFN) + "=@byteCurrentSemester";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(byteFirmFN)+"=@byteFirm";
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
sSQL +=LibraryMOD.GetFieldName(byteFirmFN);
sSQL += " , " + LibraryMOD.GetFieldName(strFirmDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(strPhone1FN);
sSQL += " , " + LibraryMOD.GetFieldName(strPhone2FN);
sSQL += " , " + LibraryMOD.GetFieldName(strTelexFN);
sSQL += " , " + LibraryMOD.GetFieldName(strFaxFN);
sSQL += " , " + LibraryMOD.GetFieldName(strEmailFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUrlFN);
sSQL += " , " + LibraryMOD.GetFieldName(strPoboxFN);
sSQL += " , " + LibraryMOD.GetFieldName(strZipCodeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN);
sSQL += " , " + LibraryMOD.GetFieldName(strRegistrationFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateRegistrationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteStartMonthFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastPeriodFN);
sSQL += " , " + LibraryMOD.GetFieldName(oleLogoFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteGraduationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteCancelFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteGradesFN);
sSQL += " , " + LibraryMOD.GetFieldName(intStudyYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(intRegYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteRegSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(intNewYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteNewSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(intCurrentYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteCurrentSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @byteFirm";
sSQL += " ,@strFirmDesc";
sSQL += " ,@strPhone1";
sSQL += " ,@strPhone2";
sSQL += " ,@strTelex";
sSQL += " ,@strFax";
sSQL += " ,@strEmail";
sSQL += " ,@strUrl";
sSQL += " ,@strPobox";
sSQL += " ,@strZipCode";
sSQL += " ,@strAddress";
sSQL += " ,@strRegistration";
sSQL += " ,@dateRegistration";
sSQL += " ,@byteStartMonth";
sSQL += " ,@dateLastPeriod";
sSQL += " ,@oleLogo";
sSQL += " ,@byteGraduation";
sSQL += " ,@byteCancel";
sSQL += " ,@byteGrades";
sSQL += " ,@intStudyYear";
sSQL += " ,@byteSemester";
sSQL += " ,@intRegYear";
sSQL += " ,@byteRegSemester";
sSQL += " ,@intNewYear";
sSQL += " ,@byteNewSemester";
sSQL += " ,@intCurrentYear";
sSQL += " ,@byteCurrentSemester";
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
sSQL += LibraryMOD.GetFieldName(byteFirmFN)+"=@byteFirm";
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
public List< Firm> GetFirm(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Firm
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
List<Firm> results = new List<Firm>();
try
{
//Default Value
Firm myFirm = new Firm();
if (isDeafaultIncluded)
{
//Change the code here
myFirm.byteFirm = 0;
myFirm.strFirmDesc  = "Select Firm ...";
results.Add(myFirm);
}
while (reader.Read())
{
myFirm = new Firm();
if (reader[LibraryMOD.GetFieldName(byteFirmFN)].Equals(DBNull.Value))
{
myFirm.byteFirm = 0;
}
else
{
myFirm.byteFirm = int.Parse(reader[LibraryMOD.GetFieldName( byteFirmFN) ].ToString());
}
myFirm.strFirmDesc =reader[LibraryMOD.GetFieldName( strFirmDescFN) ].ToString();
myFirm.strPhone1 =reader[LibraryMOD.GetFieldName( strPhone1FN) ].ToString();
myFirm.strPhone2 =reader[LibraryMOD.GetFieldName( strPhone2FN) ].ToString();
myFirm.strTelex =reader[LibraryMOD.GetFieldName( strTelexFN) ].ToString();
myFirm.strFax =reader[LibraryMOD.GetFieldName( strFaxFN) ].ToString();
myFirm.strEmail =reader[LibraryMOD.GetFieldName( strEmailFN) ].ToString();
myFirm.strUrl =reader[LibraryMOD.GetFieldName( strUrlFN) ].ToString();
myFirm.strPobox =reader[LibraryMOD.GetFieldName( strPoboxFN) ].ToString();
myFirm.strZipCode =reader[LibraryMOD.GetFieldName( strZipCodeFN) ].ToString();
myFirm.strAddress =reader[LibraryMOD.GetFieldName( strAddressFN) ].ToString();
myFirm.strRegistration =reader[LibraryMOD.GetFieldName( strRegistrationFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateRegistrationFN)].Equals(DBNull.Value))
{
myFirm.dateRegistration = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateRegistrationFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteStartMonthFN)].Equals(DBNull.Value))
{
myFirm.byteStartMonth = 0;
}
else
{
myFirm.byteStartMonth = int.Parse(reader[LibraryMOD.GetFieldName( byteStartMonthFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(dateLastPeriodFN)].Equals(DBNull.Value))
{
myFirm.dateLastPeriod = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastPeriodFN) ].ToString());
}
myFirm.oleLogo =reader[LibraryMOD.GetFieldName( oleLogoFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteGraduationFN)].Equals(DBNull.Value))
{
myFirm.byteGraduation = 0;
}
else
{
myFirm.byteGraduation = int.Parse(reader[LibraryMOD.GetFieldName( byteGraduationFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteCancelFN)].Equals(DBNull.Value))
{
myFirm.byteCancel = 0;
}
else
{
myFirm.byteCancel = int.Parse(reader[LibraryMOD.GetFieldName( byteCancelFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteGradesFN)].Equals(DBNull.Value))
{
myFirm.byteGrades = 0;
}
else
{
myFirm.byteGrades = int.Parse(reader[LibraryMOD.GetFieldName( byteGradesFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myFirm.intStudyYear = 0;
}
else
{
myFirm.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myFirm.byteSemester = 0;
}
else
{
myFirm.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intRegYearFN)].Equals(DBNull.Value))
{
myFirm.intRegYear = 0;
}
else
{
myFirm.intRegYear = int.Parse(reader[LibraryMOD.GetFieldName( intRegYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteRegSemesterFN)].Equals(DBNull.Value))
{
myFirm.byteRegSemester = 0;
}
else
{
myFirm.byteRegSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteRegSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intNewYearFN)].Equals(DBNull.Value))
{
myFirm.intNewYear = 0;
}
else
{
myFirm.intNewYear = int.Parse(reader[LibraryMOD.GetFieldName( intNewYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteNewSemesterFN)].Equals(DBNull.Value))
{
myFirm.byteNewSemester = 0;
}
else
{
myFirm.byteNewSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteNewSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intCurrentYearFN)].Equals(DBNull.Value))
{
myFirm.intCurrentYear = 0;
}
else
{
myFirm.intCurrentYear = int.Parse(reader[LibraryMOD.GetFieldName( intCurrentYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteCurrentSemesterFN)].Equals(DBNull.Value))
{
myFirm.byteCurrentSemester = 0;
}
else
{
myFirm.byteCurrentSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteCurrentSemesterFN) ].ToString());
}
myFirm.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myFirm.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myFirm.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myFirm.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myFirm.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myFirm.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myFirm);
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
public List< Firm > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Firm> results = new List<Firm>();
try
{
//Default Value
Firm myFirm= new Firm();
if (isDeafaultIncluded)
 {
//Change the code here
 myFirm.byteFirm = -1;
 myFirm.strFirmDesc = "Select Firm" ;
results.Add(myFirm);
 }
while (reader.Read())
{
myFirm = new Firm();
if (reader[LibraryMOD.GetFieldName(byteFirmFN)].Equals(DBNull.Value))
{
myFirm.byteFirm = 0;
}
else
{
myFirm.byteFirm = int.Parse(reader[LibraryMOD.GetFieldName( byteFirmFN) ].ToString());
}
myFirm.strFirmDesc =reader[LibraryMOD.GetFieldName( strFirmDescFN) ].ToString();
myFirm.strPhone1 =reader[LibraryMOD.GetFieldName( strPhone1FN) ].ToString();
 results.Add(myFirm);
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
public int UpdateFirm(InitializeModule.EnumCampus Campus, int iMode,int byteFirm,string strFirmDesc,string strPhone1,string strPhone2,string strTelex,string strFax,string strEmail,string strUrl,string strPobox,string strZipCode,string strAddress,string strRegistration,DateTime dateRegistration,int byteStartMonth,DateTime dateLastPeriod,string oleLogo,int byteGraduation,int byteCancel,int byteGrades,int intStudyYear,int byteSemester,int intRegYear,int byteRegSemester,int intNewYear,int byteNewSemester,int intCurrentYear,int byteCurrentSemester,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Firm theFirm = new Firm();
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
Cmd.Parameters.Add(new SqlParameter("@byteFirm",byteFirm));
Cmd.Parameters.Add(new SqlParameter("@strFirmDesc",strFirmDesc));
Cmd.Parameters.Add(new SqlParameter("@strPhone1",strPhone1));
Cmd.Parameters.Add(new SqlParameter("@strPhone2",strPhone2));
Cmd.Parameters.Add(new SqlParameter("@strTelex",strTelex));
Cmd.Parameters.Add(new SqlParameter("@strFax",strFax));
Cmd.Parameters.Add(new SqlParameter("@strEmail",strEmail));
Cmd.Parameters.Add(new SqlParameter("@strUrl",strUrl));
Cmd.Parameters.Add(new SqlParameter("@strPobox",strPobox));
Cmd.Parameters.Add(new SqlParameter("@strZipCode",strZipCode));
Cmd.Parameters.Add(new SqlParameter("@strAddress",strAddress));
Cmd.Parameters.Add(new SqlParameter("@strRegistration",strRegistration));
Cmd.Parameters.Add(new SqlParameter("@dateRegistration",dateRegistration));
Cmd.Parameters.Add(new SqlParameter("@byteStartMonth",byteStartMonth));
Cmd.Parameters.Add(new SqlParameter("@dateLastPeriod",dateLastPeriod));
Cmd.Parameters.Add(new SqlParameter("@oleLogo",oleLogo));
Cmd.Parameters.Add(new SqlParameter("@byteGraduation",byteGraduation));
Cmd.Parameters.Add(new SqlParameter("@byteCancel",byteCancel));
Cmd.Parameters.Add(new SqlParameter("@byteGrades",byteGrades));
Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@intRegYear",intRegYear));
Cmd.Parameters.Add(new SqlParameter("@byteRegSemester",byteRegSemester));
Cmd.Parameters.Add(new SqlParameter("@intNewYear",intNewYear));
Cmd.Parameters.Add(new SqlParameter("@byteNewSemester",byteNewSemester));
Cmd.Parameters.Add(new SqlParameter("@intCurrentYear",intCurrentYear));
Cmd.Parameters.Add(new SqlParameter("@byteCurrentSemester",byteCurrentSemester));
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
public int DeleteFirm(InitializeModule.EnumCampus Campus,string byteFirm)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@byteFirm", byteFirm ));
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
DataTable dt = new DataTable("Firm");
DataView dv = new DataView();
List<Firm> myFirms = new List<Firm>();
try
{
myFirms = GetFirm(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("byteFirm", Type.GetType("smallint"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myFirms.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myFirms[i].byteFirm;
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
myFirms.Clear();
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
sSQL += byteFirmFN;
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
public class FirmCls : FirmDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daFirm;
private DataSet m_dsFirm;
public DataRow FirmDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsFirm
{
get { return m_dsFirm ; }
set { m_dsFirm = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public FirmCls()
{
try
{
dsFirm= new DataSet();

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
public virtual SqlDataAdapter GetFirmDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daFirm = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daFirm);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daFirm.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFirm;
}
public virtual SqlDataAdapter GetFirmDataAdapter(SqlConnection con)  
{
try
{
daFirm = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daFirm.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdFirm;
cmdFirm = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@byteFirm", SqlDbType.Int, 4, "byteFirm" );
daFirm.SelectCommand = cmdFirm;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdFirm = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdFirm.Parameters.Add("@byteFirm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFirmFN));
cmdFirm.Parameters.Add("@strFirmDesc", SqlDbType.NVarChar,120, LibraryMOD.GetFieldName(strFirmDescFN));
cmdFirm.Parameters.Add("@strPhone1", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strPhone1FN));
cmdFirm.Parameters.Add("@strPhone2", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strPhone2FN));
cmdFirm.Parameters.Add("@strTelex", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strTelexFN));
cmdFirm.Parameters.Add("@strFax", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strFaxFN));
cmdFirm.Parameters.Add("@strEmail", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strEmailFN));
cmdFirm.Parameters.Add("@strUrl", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUrlFN));
cmdFirm.Parameters.Add("@strPobox", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strPoboxFN));
cmdFirm.Parameters.Add("@strZipCode", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(strZipCodeFN));
cmdFirm.Parameters.Add("@strAddress", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strAddressFN));
cmdFirm.Parameters.Add("@strRegistration", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strRegistrationFN));
cmdFirm.Parameters.Add("@dateRegistration", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateRegistrationFN));
cmdFirm.Parameters.Add("@byteStartMonth", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStartMonthFN));
cmdFirm.Parameters.Add("@dateLastPeriod", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastPeriodFN));
cmdFirm.Parameters.Add("@oleLogo", SqlDbType.Image,2147483647, LibraryMOD.GetFieldName(oleLogoFN));
cmdFirm.Parameters.Add("@byteGraduation", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGraduationFN));
cmdFirm.Parameters.Add("@byteCancel", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCancelFN));
cmdFirm.Parameters.Add("@byteGrades", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGradesFN));
cmdFirm.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdFirm.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdFirm.Parameters.Add("@intRegYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intRegYearFN));
cmdFirm.Parameters.Add("@byteRegSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRegSemesterFN));
cmdFirm.Parameters.Add("@intNewYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intNewYearFN));
cmdFirm.Parameters.Add("@byteNewSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteNewSemesterFN));
cmdFirm.Parameters.Add("@intCurrentYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCurrentYearFN));
cmdFirm.Parameters.Add("@byteCurrentSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCurrentSemesterFN));
cmdFirm.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFirm.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFirm.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFirm.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFirm.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFirm.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdFirm.Parameters.Add("@byteFirm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFirmFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daFirm.UpdateCommand = cmdFirm;
daFirm.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdFirm = new SqlCommand(GetInsertCommand(), con);
cmdFirm.Parameters.Add("@byteFirm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFirmFN));
cmdFirm.Parameters.Add("@strFirmDesc", SqlDbType.NVarChar,120, LibraryMOD.GetFieldName(strFirmDescFN));
cmdFirm.Parameters.Add("@strPhone1", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strPhone1FN));
cmdFirm.Parameters.Add("@strPhone2", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strPhone2FN));
cmdFirm.Parameters.Add("@strTelex", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strTelexFN));
cmdFirm.Parameters.Add("@strFax", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strFaxFN));
cmdFirm.Parameters.Add("@strEmail", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strEmailFN));
cmdFirm.Parameters.Add("@strUrl", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUrlFN));
cmdFirm.Parameters.Add("@strPobox", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strPoboxFN));
cmdFirm.Parameters.Add("@strZipCode", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(strZipCodeFN));
cmdFirm.Parameters.Add("@strAddress", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strAddressFN));
cmdFirm.Parameters.Add("@strRegistration", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(strRegistrationFN));
cmdFirm.Parameters.Add("@dateRegistration", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateRegistrationFN));
cmdFirm.Parameters.Add("@byteStartMonth", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStartMonthFN));
cmdFirm.Parameters.Add("@dateLastPeriod", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastPeriodFN));
cmdFirm.Parameters.Add("@oleLogo", SqlDbType.Image,2147483647, LibraryMOD.GetFieldName(oleLogoFN));
cmdFirm.Parameters.Add("@byteGraduation", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGraduationFN));
cmdFirm.Parameters.Add("@byteCancel", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCancelFN));
cmdFirm.Parameters.Add("@byteGrades", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGradesFN));
cmdFirm.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdFirm.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdFirm.Parameters.Add("@intRegYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intRegYearFN));
cmdFirm.Parameters.Add("@byteRegSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRegSemesterFN));
cmdFirm.Parameters.Add("@intNewYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intNewYearFN));
cmdFirm.Parameters.Add("@byteNewSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteNewSemesterFN));
cmdFirm.Parameters.Add("@intCurrentYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCurrentYearFN));
cmdFirm.Parameters.Add("@byteCurrentSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCurrentSemesterFN));
cmdFirm.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFirm.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFirm.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFirm.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFirm.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFirm.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daFirm.InsertCommand =cmdFirm;
daFirm.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdFirm = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdFirm.Parameters.Add("@byteFirm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFirmFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daFirm.DeleteCommand =cmdFirm;
daFirm.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daFirm.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFirm;
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
dr = dsFirm.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(byteFirmFN)]=byteFirm;
dr[LibraryMOD.GetFieldName(strFirmDescFN)]=strFirmDesc;
dr[LibraryMOD.GetFieldName(strPhone1FN)]=strPhone1;
dr[LibraryMOD.GetFieldName(strPhone2FN)]=strPhone2;
dr[LibraryMOD.GetFieldName(strTelexFN)]=strTelex;
dr[LibraryMOD.GetFieldName(strFaxFN)]=strFax;
dr[LibraryMOD.GetFieldName(strEmailFN)]=strEmail;
dr[LibraryMOD.GetFieldName(strUrlFN)]=strUrl;
dr[LibraryMOD.GetFieldName(strPoboxFN)]=strPobox;
dr[LibraryMOD.GetFieldName(strZipCodeFN)]=strZipCode;
dr[LibraryMOD.GetFieldName(strAddressFN)]=strAddress;
dr[LibraryMOD.GetFieldName(strRegistrationFN)]=strRegistration;
dr[LibraryMOD.GetFieldName(dateRegistrationFN)]=dateRegistration;
dr[LibraryMOD.GetFieldName(byteStartMonthFN)]=byteStartMonth;
dr[LibraryMOD.GetFieldName(dateLastPeriodFN)]=dateLastPeriod;
dr[LibraryMOD.GetFieldName(oleLogoFN)]=oleLogo;
dr[LibraryMOD.GetFieldName(byteGraduationFN)]=byteGraduation;
dr[LibraryMOD.GetFieldName(byteCancelFN)]=byteCancel;
dr[LibraryMOD.GetFieldName(byteGradesFN)]=byteGrades;
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(intRegYearFN)]=intRegYear;
dr[LibraryMOD.GetFieldName(byteRegSemesterFN)]=byteRegSemester;
dr[LibraryMOD.GetFieldName(intNewYearFN)]=intNewYear;
dr[LibraryMOD.GetFieldName(byteNewSemesterFN)]=byteNewSemester;
dr[LibraryMOD.GetFieldName(intCurrentYearFN)]=intCurrentYear;
dr[LibraryMOD.GetFieldName(byteCurrentSemesterFN)]=byteCurrentSemester;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsFirm.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsFirm.Tables[TableName].Select(LibraryMOD.GetFieldName(byteFirmFN)  + "=" + byteFirm);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(byteFirmFN)]=byteFirm;
drAry[0][LibraryMOD.GetFieldName(strFirmDescFN)]=strFirmDesc;
drAry[0][LibraryMOD.GetFieldName(strPhone1FN)]=strPhone1;
drAry[0][LibraryMOD.GetFieldName(strPhone2FN)]=strPhone2;
drAry[0][LibraryMOD.GetFieldName(strTelexFN)]=strTelex;
drAry[0][LibraryMOD.GetFieldName(strFaxFN)]=strFax;
drAry[0][LibraryMOD.GetFieldName(strEmailFN)]=strEmail;
drAry[0][LibraryMOD.GetFieldName(strUrlFN)]=strUrl;
drAry[0][LibraryMOD.GetFieldName(strPoboxFN)]=strPobox;
drAry[0][LibraryMOD.GetFieldName(strZipCodeFN)]=strZipCode;
drAry[0][LibraryMOD.GetFieldName(strAddressFN)]=strAddress;
drAry[0][LibraryMOD.GetFieldName(strRegistrationFN)]=strRegistration;
drAry[0][LibraryMOD.GetFieldName(dateRegistrationFN)]=dateRegistration;
drAry[0][LibraryMOD.GetFieldName(byteStartMonthFN)]=byteStartMonth;
drAry[0][LibraryMOD.GetFieldName(dateLastPeriodFN)]=dateLastPeriod;
drAry[0][LibraryMOD.GetFieldName(oleLogoFN)]=oleLogo;
drAry[0][LibraryMOD.GetFieldName(byteGraduationFN)]=byteGraduation;
drAry[0][LibraryMOD.GetFieldName(byteCancelFN)]=byteCancel;
drAry[0][LibraryMOD.GetFieldName(byteGradesFN)]=byteGrades;
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(intRegYearFN)]=intRegYear;
drAry[0][LibraryMOD.GetFieldName(byteRegSemesterFN)]=byteRegSemester;
drAry[0][LibraryMOD.GetFieldName(intNewYearFN)]=intNewYear;
drAry[0][LibraryMOD.GetFieldName(byteNewSemesterFN)]=byteNewSemester;
drAry[0][LibraryMOD.GetFieldName(intCurrentYearFN)]=intCurrentYear;
drAry[0][LibraryMOD.GetFieldName(byteCurrentSemesterFN)]=byteCurrentSemester;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
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
public int CommitFirm()  
{
//CommitFirm= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daFirm.Update(dsFirm, TableName);
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
FindInMultiPKey(byteFirm);
if (( FirmDataRow != null)) 
{
FirmDataRow.Delete();
CommitFirm();
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

    public string  GetEmployeeCurrentSemester()
    {
    string sSQL ="";
    string sSem = "";
    try
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS();
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        
        sSQL = "SELECT ";
        sSQL += byteCurrentSemesterFN  ;
        sSQL += " FROM " + TableName ;
     

        System.Data.SqlClient.SqlCommand CommandSQL =new  System.Data.SqlClient.SqlCommand(sSQL, Conn );
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader();

        

        if (datReader.Read() ) 
        {
            sSem = datReader.GetString(0);
        }
        datReader.Close();
        
        }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        
    }
    return sSem;
    }
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (FirmDataRow[LibraryMOD.GetFieldName(byteFirmFN)]== System.DBNull.Value)
{
  byteFirm=0;
}
else
{
  byteFirm = (int)FirmDataRow[LibraryMOD.GetFieldName(byteFirmFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strFirmDescFN)]== System.DBNull.Value)
{
  strFirmDesc="";
}
else
{
  strFirmDesc = (string)FirmDataRow[LibraryMOD.GetFieldName(strFirmDescFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strPhone1FN)]== System.DBNull.Value)
{
  strPhone1="";
}
else
{
  strPhone1 = (string)FirmDataRow[LibraryMOD.GetFieldName(strPhone1FN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strPhone2FN)]== System.DBNull.Value)
{
  strPhone2="";
}
else
{
  strPhone2 = (string)FirmDataRow[LibraryMOD.GetFieldName(strPhone2FN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strTelexFN)]== System.DBNull.Value)
{
  strTelex="";
}
else
{
  strTelex = (string)FirmDataRow[LibraryMOD.GetFieldName(strTelexFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strFaxFN)]== System.DBNull.Value)
{
  strFax="";
}
else
{
  strFax = (string)FirmDataRow[LibraryMOD.GetFieldName(strFaxFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strEmailFN)]== System.DBNull.Value)
{
  strEmail="";
}
else
{
  strEmail = (string)FirmDataRow[LibraryMOD.GetFieldName(strEmailFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strUrlFN)]== System.DBNull.Value)
{
  strUrl="";
}
else
{
  strUrl = (string)FirmDataRow[LibraryMOD.GetFieldName(strUrlFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strPoboxFN)]== System.DBNull.Value)
{
  strPobox="";
}
else
{
  strPobox = (string)FirmDataRow[LibraryMOD.GetFieldName(strPoboxFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strZipCodeFN)]== System.DBNull.Value)
{
  strZipCode="";
}
else
{
  strZipCode = (string)FirmDataRow[LibraryMOD.GetFieldName(strZipCodeFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strAddressFN)]== System.DBNull.Value)
{
  strAddress="";
}
else
{
  strAddress = (string)FirmDataRow[LibraryMOD.GetFieldName(strAddressFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strRegistrationFN)]== System.DBNull.Value)
{
  strRegistration="";
}
else
{
  strRegistration = (string)FirmDataRow[LibraryMOD.GetFieldName(strRegistrationFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(dateRegistrationFN)]== System.DBNull.Value)
{
}
else
{
  dateRegistration = (DateTime)FirmDataRow[LibraryMOD.GetFieldName(dateRegistrationFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteStartMonthFN)]== System.DBNull.Value)
{
  byteStartMonth=0;
}
else
{
  byteStartMonth = (int)FirmDataRow[LibraryMOD.GetFieldName(byteStartMonthFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(dateLastPeriodFN)]== System.DBNull.Value)
{
}
else
{
  dateLastPeriod = (DateTime)FirmDataRow[LibraryMOD.GetFieldName(dateLastPeriodFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(oleLogoFN)]== System.DBNull.Value)
{
  oleLogo="";
}
else
{
  oleLogo = (string)FirmDataRow[LibraryMOD.GetFieldName(oleLogoFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteGraduationFN)]== System.DBNull.Value)
{
  byteGraduation=0;
}
else
{
  byteGraduation = (int)FirmDataRow[LibraryMOD.GetFieldName(byteGraduationFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteCancelFN)]== System.DBNull.Value)
{
  byteCancel=0;
}
else
{
  byteCancel = (int)FirmDataRow[LibraryMOD.GetFieldName(byteCancelFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteGradesFN)]== System.DBNull.Value)
{
  byteGrades=0;
}
else
{
  byteGrades = (int)FirmDataRow[LibraryMOD.GetFieldName(byteGradesFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)FirmDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)FirmDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(intRegYearFN)]== System.DBNull.Value)
{
  intRegYear=0;
}
else
{
  intRegYear = (int)FirmDataRow[LibraryMOD.GetFieldName(intRegYearFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteRegSemesterFN)]== System.DBNull.Value)
{
  byteRegSemester=0;
}
else
{
  byteRegSemester = (int)FirmDataRow[LibraryMOD.GetFieldName(byteRegSemesterFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(intNewYearFN)]== System.DBNull.Value)
{
  intNewYear=0;
}
else
{
  intNewYear = (int)FirmDataRow[LibraryMOD.GetFieldName(intNewYearFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteNewSemesterFN)]== System.DBNull.Value)
{
  byteNewSemester=0;
}
else
{
  byteNewSemester = (int)FirmDataRow[LibraryMOD.GetFieldName(byteNewSemesterFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(intCurrentYearFN)]== System.DBNull.Value)
{
  intCurrentYear=0;
}
else
{
  intCurrentYear = (int)FirmDataRow[LibraryMOD.GetFieldName(intCurrentYearFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(byteCurrentSemesterFN)]== System.DBNull.Value)
{
  byteCurrentSemester=0;
}
else
{
  byteCurrentSemester = (int)FirmDataRow[LibraryMOD.GetFieldName(byteCurrentSemesterFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)FirmDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)FirmDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)FirmDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)FirmDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)FirmDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (FirmDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)FirmDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKbyteFirm) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKbyteFirm;
FirmDataRow = dsFirm.Tables[TableName].Rows.Find(findTheseVals);
if  ((FirmDataRow !=null)) 
{
lngCurRow = dsFirm.Tables[TableName].Rows.IndexOf(FirmDataRow);
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
  lngCurRow = dsFirm.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsFirm.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsFirm.Tables[TableName].Rows.Count > 0) 
{
  FirmDataRow = dsFirm.Tables[TableName].Rows[lngCurRow];
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
daFirm.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFirm.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daFirm.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFirm.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
