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
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Requested_Forms
{
//Creation Date: 21/03/2010 11:01:12 AM
//Programmer Name : Ihab Awad
//-----Decleration --------------
#region "Decleration"
private int m_iFormNo; 
private int m_iStudyYear; 
private int m_bSemester;
private string m_Term;
private string m_sStudentNumber;
private string m_sStudentName;
private int m_bRequestType;
private string m_sRequestType;
private string m_sReason; 
private string m_sRequestedCollege; 
private string m_sRequestedDegree; 
private string m_sRequestedMajor;
private string m_sMajor;
private string m_sRequestedCourse;
private string m_Course_Desc;
private int m_iCourseLecturer;
private string m_sLecturer;
private string m_sAddress; 
private string m_sPOBox; 
private string m_sMobile; 
private string m_sPhone;
private string m_sRegMobile;
private string m_sRegPhone;
private string m_sEmail; 
private bool m_isEmployed; 
private string m_sWorkPlace; 
private string m_sJobTitle; 
private string m_sWorkPhone; 
private string m_sSuperVisor; 
private string m_sSuperVisorTitle; 
private DateTime m_dDate; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int iFormNo
{
get { return  m_iFormNo; }
set {m_iFormNo  = value ; }
}
public int iStudyYear
{
get { return  m_iStudyYear; }
set {m_iStudyYear  = value ; }
}
public int bSemester
{
get { return  m_bSemester; }
set {m_bSemester  = value ; }
}

public string  Term
{
    get { return m_Term; }
    set { m_Term = value; }
}

public string sStudentNumber
{
get { return  m_sStudentNumber; }
set {m_sStudentNumber  = value ; }
}

public string SStudentName
{
    get { return m_sStudentName; }
    set { m_sStudentName = value; }
} 
public int bRequestType
{
get { return  m_bRequestType; }
set {m_bRequestType  = value ; }
}

public string SRequestType
{
    get { return m_sRequestType; }
    set { m_sRequestType = value; }
} 
public string sReason
{
get { return  m_sReason; }
set {m_sReason  = value ; }
}
public string sRequestedCollege
{
get { return  m_sRequestedCollege; }
set {m_sRequestedCollege  = value ; }
}
public string sRequestedDegree
{
get { return  m_sRequestedDegree; }
set {m_sRequestedDegree  = value ; }
}
public string sRequestedMajor
{
get { return  m_sRequestedMajor; }
set {m_sRequestedMajor  = value ; }
}

public string SMajor
{
    get { return m_sMajor; }
    set { m_sMajor = value; }
} 
public string sRequestedCourse
{
get { return  m_sRequestedCourse; }
set {m_sRequestedCourse  = value ; }
}

public string Course_Desc
{
    get { return m_Course_Desc; }
    set { m_Course_Desc = value; }
} 
public int iCourseLecturer
{
get { return  m_iCourseLecturer; }
set {m_iCourseLecturer  = value ; }
}

public string SLecturer
{
    get { return m_sLecturer; }
    set { m_sLecturer = value; }
} 
public string sAddress
{
get { return  m_sAddress; }
set {m_sAddress  = value ; }
}
public string sPOBox
{
get { return  m_sPOBox; }
set {m_sPOBox  = value ; }
}
public string sMobile
{
get { return  m_sMobile; }
set {m_sMobile  = value ; }
}
public string sPhone
{
get { return  m_sPhone; }
set {m_sPhone  = value ; }
}

public string SRegMobile
{
    get { return m_sRegMobile; }
    set { m_sRegMobile = value; }
}

public string SRegPhone
{
    get { return m_sRegPhone; }
    set { m_sRegPhone = value; }
} 

public string sEmail
{
get { return  m_sEmail; }
set {m_sEmail  = value ; }
}
public bool isEmployed
{
get { return  m_isEmployed; }
set {m_isEmployed  = value ; }
}
public string sWorkPlace
{
get { return  m_sWorkPlace; }
set {m_sWorkPlace  = value ; }
}
public string sJobTitle
{
get { return  m_sJobTitle; }
set {m_sJobTitle  = value ; }
}
public string sWorkPhone
{
get { return  m_sWorkPhone; }
set {m_sWorkPhone  = value ; }
}
public string sSuperVisor
{
get { return  m_sSuperVisor; }
set {m_sSuperVisor  = value ; }
}
public string sSuperVisorTitle
{
get { return  m_sSuperVisorTitle; }
set {m_sSuperVisorTitle  = value ; }
}
public DateTime dDate
{
get { return  m_dDate; }
set {m_dDate  = value ; }
}
#endregion
//'-----------------------------------------------------
public Requested_Forms()
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
public class Requested_FormsDAL : Requested_Forms
{
#region "Decleration"
private string m_TableName;
private string m_iFormNoFN ;
private string m_iStudyYearFN ;
private string m_bSemesterFN ;
private string m_sStudentNumberFN ;
private string m_bRequestTypeFN ;
private string m_sReasonFN ;
private string m_sRequestedCollegeFN ;
private string m_sRequestedDegreeFN ;
private string m_sRequestedMajorFN ;
private string m_sRequestedCourseFN ;
private string m_iCourseLecturerFN ;
private string m_sAddressFN ;
private string m_sPOBoxFN ;
private string m_sMobileFN ;
private string m_sPhoneFN ;
private string m_sEmailFN ;
private string m_isEmployedFN ;
private string m_sWorkPlaceFN ;
private string m_sJobTitleFN ;
private string m_sWorkPhoneFN ;
private string m_sSuperVisorFN ;
private string m_sSuperVisorTitleFN ;
private string m_dDateFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string iFormNoFN 
{
get { return  m_iFormNoFN; }
set {m_iFormNoFN  = value ; }
}
public string iStudyYearFN 
{
get { return  m_iStudyYearFN; }
set {m_iStudyYearFN  = value ; }
}
public string bSemesterFN 
{
get { return  m_bSemesterFN; }
set {m_bSemesterFN  = value ; }
}
public string sStudentNumberFN 
{
get { return  m_sStudentNumberFN; }
set {m_sStudentNumberFN  = value ; }
}
public string bRequestTypeFN 
{
get { return  m_bRequestTypeFN; }
set {m_bRequestTypeFN  = value ; }
}
public string sReasonFN 
{
get { return  m_sReasonFN; }
set {m_sReasonFN  = value ; }
}
public string sRequestedCollegeFN 
{
get { return  m_sRequestedCollegeFN; }
set {m_sRequestedCollegeFN  = value ; }
}
public string sRequestedDegreeFN 
{
get { return  m_sRequestedDegreeFN; }
set {m_sRequestedDegreeFN  = value ; }
}
public string sRequestedMajorFN 
{
get { return  m_sRequestedMajorFN; }
set {m_sRequestedMajorFN  = value ; }
}
public string sRequestedCourseFN 
{
get { return  m_sRequestedCourseFN; }
set {m_sRequestedCourseFN  = value ; }
}
public string iCourseLecturerFN 
{
get { return  m_iCourseLecturerFN; }
set {m_iCourseLecturerFN  = value ; }
}
public string sAddressFN 
{
get { return  m_sAddressFN; }
set {m_sAddressFN  = value ; }
}
public string sPOBoxFN 
{
get { return  m_sPOBoxFN; }
set {m_sPOBoxFN  = value ; }
}
public string sMobileFN 
{
get { return  m_sMobileFN; }
set {m_sMobileFN  = value ; }
}
public string sPhoneFN 
{
get { return  m_sPhoneFN; }
set {m_sPhoneFN  = value ; }
}
public string sEmailFN 
{
get { return  m_sEmailFN; }
set {m_sEmailFN  = value ; }
}
public string isEmployedFN 
{
get { return  m_isEmployedFN; }
set {m_isEmployedFN  = value ; }
}
public string sWorkPlaceFN 
{
get { return  m_sWorkPlaceFN; }
set {m_sWorkPlaceFN  = value ; }
}
public string sJobTitleFN 
{
get { return  m_sJobTitleFN; }
set {m_sJobTitleFN  = value ; }
}
public string sWorkPhoneFN 
{
get { return  m_sWorkPhoneFN; }
set {m_sWorkPhoneFN  = value ; }
}
public string sSuperVisorFN 
{
get { return  m_sSuperVisorFN; }
set {m_sSuperVisorFN  = value ; }
}
public string sSuperVisorTitleFN 
{
get { return  m_sSuperVisorTitleFN; }
set {m_sSuperVisorTitleFN  = value ; }
}
public string dDateFN 
{
get { return  m_dDateFN; }
set {m_dDateFN  = value ; }
}
#endregion
//================End Properties ===================
public Requested_FormsDAL()
{
try
{
this.TableName = "Reg_Requested_Forms";
this.iFormNoFN = m_TableName + ".iFormNo";
this.iStudyYearFN = m_TableName + ".iStudyYear";
this.bSemesterFN = m_TableName + ".bSemester";
this.sStudentNumberFN = m_TableName + ".sStudentNumber";
this.bRequestTypeFN = m_TableName + ".bRequestType";
this.sReasonFN = m_TableName + ".sReason";
this.sRequestedCollegeFN = m_TableName + ".sRequestedCollege";
this.sRequestedDegreeFN = m_TableName + ".sRequestedDegree";
this.sRequestedMajorFN = m_TableName + ".sRequestedMajor";
this.sRequestedCourseFN = m_TableName + ".sRequestedCourse";
this.iCourseLecturerFN = m_TableName + ".iCourseLecturer";
this.sAddressFN = m_TableName + ".sAddress";
this.sPOBoxFN = m_TableName + ".sPOBox";
this.sMobileFN = m_TableName + ".sMobile";
this.sPhoneFN = m_TableName + ".sPhone";
this.sEmailFN = m_TableName + ".sEmail";
this.isEmployedFN = m_TableName + ".isEmployed";
this.sWorkPlaceFN = m_TableName + ".sWorkPlace";
this.sJobTitleFN = m_TableName + ".sJobTitle";
this.sWorkPhoneFN = m_TableName + ".sWorkPhone";
this.sSuperVisorFN = m_TableName + ".sSuperVisor";
this.sSuperVisorTitleFN = m_TableName + ".sSuperVisorTitle";
this.dDateFN = m_TableName + ".dDate";
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
sSQL +=iFormNoFN;
sSQL += " , " + iStudyYearFN;
sSQL += " , " + bSemesterFN;
sSQL += " , " + sStudentNumberFN;
sSQL += " , " + bRequestTypeFN;
sSQL += " , " + sReasonFN;
sSQL += " , " + sRequestedCollegeFN;
sSQL += " , " + sRequestedDegreeFN;
sSQL += " , " + sRequestedMajorFN;
sSQL += " , " + sRequestedCourseFN;
sSQL += " , " + iCourseLecturerFN;
sSQL += " , " + sAddressFN;
sSQL += " , " + sPOBoxFN;
sSQL += " , " + sMobileFN;
sSQL += " , " + sPhoneFN;
sSQL += " , " + sEmailFN;
sSQL += " , " + isEmployedFN;
sSQL += " , " + sWorkPlaceFN;
sSQL += " , " + sJobTitleFN;
sSQL += " , " + sWorkPhoneFN;
sSQL += " , " + sSuperVisorFN;
sSQL += " , " + sSuperVisorTitleFN;
sSQL += " , " + dDateFN;
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
sSQL +=iFormNoFN;
sSQL += " , " + iStudyYearFN;
sSQL += " , " + bSemesterFN;
sSQL += " , " + sStudentNumberFN;
sSQL += " , " + bRequestTypeFN;
sSQL += " , " + sReasonFN;
sSQL += " , " + sRequestedCollegeFN;
sSQL += " , " + sRequestedDegreeFN;
sSQL += " , " + sRequestedMajorFN;
sSQL += " , " + sRequestedCourseFN;
sSQL += " , " + iCourseLecturerFN;
sSQL += " , " + sAddressFN;
sSQL += " , " + sPOBoxFN;
sSQL += " , " + sMobileFN;
sSQL += " , " + sPhoneFN;
sSQL += " , " + sEmailFN;
sSQL += " , " + isEmployedFN;
sSQL += " , " + sWorkPlaceFN;
sSQL += " , " + sJobTitleFN;
sSQL += " , " + sWorkPhoneFN;
sSQL += " , " + sSuperVisorFN;
sSQL += " , " + sSuperVisorTitleFN;
sSQL += " , " + dDateFN;
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
sSQL += LibraryMOD.GetFieldName(iFormNoFN) + "=@iFormNo";
sSQL += " , " + LibraryMOD.GetFieldName(iStudyYearFN) + "=@iStudyYear";
sSQL += " , " + LibraryMOD.GetFieldName(bSemesterFN) + "=@bSemester";
sSQL += " , " + LibraryMOD.GetFieldName(sStudentNumberFN) + "=@sStudentNumber";
sSQL += " , " + LibraryMOD.GetFieldName(bRequestTypeFN) + "=@bRequestType";
sSQL += " , " + LibraryMOD.GetFieldName(sReasonFN) + "=@sReason";
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedCollegeFN) + "=@sRequestedCollege";
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedDegreeFN) + "=@sRequestedDegree";
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedMajorFN) + "=@sRequestedMajor";
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedCourseFN) + "=@sRequestedCourse";
sSQL += " , " + LibraryMOD.GetFieldName(iCourseLecturerFN) + "=@iCourseLecturer";
sSQL += " , " + LibraryMOD.GetFieldName(sAddressFN) + "=@sAddress";
sSQL += " , " + LibraryMOD.GetFieldName(sPOBoxFN) + "=@sPOBox";
sSQL += " , " + LibraryMOD.GetFieldName(sMobileFN) + "=@sMobile";
sSQL += " , " + LibraryMOD.GetFieldName(sPhoneFN) + "=@sPhone";
sSQL += " , " + LibraryMOD.GetFieldName(sEmailFN) + "=@sEmail";
sSQL += " , " + LibraryMOD.GetFieldName(isEmployedFN) + "=@isEmployed";
sSQL += " , " + LibraryMOD.GetFieldName(sWorkPlaceFN) + "=@sWorkPlace";
sSQL += " , " + LibraryMOD.GetFieldName(sJobTitleFN) + "=@sJobTitle";
sSQL += " , " + LibraryMOD.GetFieldName(sWorkPhoneFN) + "=@sWorkPhone";
sSQL += " , " + LibraryMOD.GetFieldName(sSuperVisorFN) + "=@sSuperVisor";
sSQL += " , " + LibraryMOD.GetFieldName(sSuperVisorTitleFN) + "=@sSuperVisorTitle";
sSQL += " , " + LibraryMOD.GetFieldName(dDateFN) + "=@dDate";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(iFormNoFN)+"=@iFormNo";
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
sSQL +=LibraryMOD.GetFieldName(iFormNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(iStudyYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(bSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(sStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(bRequestTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(sReasonFN);
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedDegreeFN);
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedMajorFN);
sSQL += " , " + LibraryMOD.GetFieldName(sRequestedCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(iCourseLecturerFN);
sSQL += " , " + LibraryMOD.GetFieldName(sAddressFN);
sSQL += " , " + LibraryMOD.GetFieldName(sPOBoxFN);
sSQL += " , " + LibraryMOD.GetFieldName(sMobileFN);
sSQL += " , " + LibraryMOD.GetFieldName(sPhoneFN);
sSQL += " , " + LibraryMOD.GetFieldName(sEmailFN);
sSQL += " , " + LibraryMOD.GetFieldName(isEmployedFN);
sSQL += " , " + LibraryMOD.GetFieldName(sWorkPlaceFN);
sSQL += " , " + LibraryMOD.GetFieldName(sJobTitleFN);
sSQL += " , " + LibraryMOD.GetFieldName(sWorkPhoneFN);
sSQL += " , " + LibraryMOD.GetFieldName(sSuperVisorFN);
sSQL += " , " + LibraryMOD.GetFieldName(sSuperVisorTitleFN);
sSQL += " , " + LibraryMOD.GetFieldName(dDateFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @iFormNo";
sSQL += " ,@iStudyYear";
sSQL += " ,@bSemester";
sSQL += " ,@sStudentNumber";
sSQL += " ,@bRequestType";
sSQL += " ,@sReason";
sSQL += " ,@sRequestedCollege";
sSQL += " ,@sRequestedDegree";
sSQL += " ,@sRequestedMajor";
sSQL += " ,@sRequestedCourse";
sSQL += " ,@iCourseLecturer";
sSQL += " ,@sAddress";
sSQL += " ,@sPOBox";
sSQL += " ,@sMobile";
sSQL += " ,@sPhone";
sSQL += " ,@sEmail";
sSQL += " ,@isEmployed";
sSQL += " ,@sWorkPlace";
sSQL += " ,@sJobTitle";
sSQL += " ,@sWorkPhone";
sSQL += " ,@sSuperVisor";
sSQL += " ,@sSuperVisorTitle";
sSQL += " ,@dDate";
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
sSQL += LibraryMOD.GetFieldName(iFormNoFN)+"=@iFormNo";
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
public List< Requested_Forms> GetRequested_Forms(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Requested_Forms
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
List<Requested_Forms> results = new List<Requested_Forms>();
try
{
//Default Value
Requested_Forms myRequested_Forms = new Requested_Forms();
//if (isDeafaultIncluded)
//{
////Change the code here
//myRequested_Forms.iFormNo = 0;
//myRequested_Forms.iStudyYear = "Select Request Type ...";
//results.Add(myRequested_Forms);
//}
while (reader.Read())
{
myRequested_Forms = new Requested_Forms();
if (reader[LibraryMOD.GetFieldName(iFormNoFN)].Equals(DBNull.Value))
{
myRequested_Forms.iFormNo = 0;
}
else
{
myRequested_Forms.iFormNo = int.Parse(reader[LibraryMOD.GetFieldName( iFormNoFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(iStudyYearFN)].Equals(DBNull.Value))
{
myRequested_Forms.iStudyYear = 0;
}
else
{
myRequested_Forms.iStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( iStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(bSemesterFN)].Equals(DBNull.Value))
{
myRequested_Forms.bSemester = 0;
}
else
{
myRequested_Forms.bSemester = int.Parse(reader[LibraryMOD.GetFieldName( bSemesterFN) ].ToString());
}
myRequested_Forms.sStudentNumber =reader[LibraryMOD.GetFieldName( sStudentNumberFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(bRequestTypeFN)].Equals(DBNull.Value))
{
myRequested_Forms.bRequestType = 0;
}
else
{
myRequested_Forms.bRequestType = int.Parse(reader[LibraryMOD.GetFieldName( bRequestTypeFN) ].ToString());
}
myRequested_Forms.sReason =reader[LibraryMOD.GetFieldName( sReasonFN) ].ToString();
myRequested_Forms.sRequestedCollege =reader[LibraryMOD.GetFieldName( sRequestedCollegeFN) ].ToString();
myRequested_Forms.sRequestedDegree =reader[LibraryMOD.GetFieldName( sRequestedDegreeFN) ].ToString();
myRequested_Forms.sRequestedMajor =reader[LibraryMOD.GetFieldName( sRequestedMajorFN) ].ToString();
myRequested_Forms.sRequestedCourse =reader[LibraryMOD.GetFieldName( sRequestedCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(iCourseLecturerFN)].Equals(DBNull.Value))
{
myRequested_Forms.iCourseLecturer = 0;
}
else
{
myRequested_Forms.iCourseLecturer = int.Parse(reader[LibraryMOD.GetFieldName( iCourseLecturerFN) ].ToString());
}
myRequested_Forms.sAddress =reader[LibraryMOD.GetFieldName( sAddressFN) ].ToString();
myRequested_Forms.sPOBox =reader[LibraryMOD.GetFieldName( sPOBoxFN) ].ToString();
myRequested_Forms.sMobile =reader[LibraryMOD.GetFieldName( sMobileFN) ].ToString();
myRequested_Forms.sPhone =reader[LibraryMOD.GetFieldName( sPhoneFN) ].ToString();
myRequested_Forms.sEmail =reader[LibraryMOD.GetFieldName( sEmailFN) ].ToString();
myRequested_Forms.isEmployed =bool.Parse( reader[LibraryMOD.GetFieldName( isEmployedFN) ].ToString());
myRequested_Forms.sWorkPlace =reader[LibraryMOD.GetFieldName( sWorkPlaceFN) ].ToString();
myRequested_Forms.sJobTitle =reader[LibraryMOD.GetFieldName( sJobTitleFN) ].ToString();
myRequested_Forms.sWorkPhone =reader[LibraryMOD.GetFieldName( sWorkPhoneFN) ].ToString();
myRequested_Forms.sSuperVisor =reader[LibraryMOD.GetFieldName( sSuperVisorFN) ].ToString();
myRequested_Forms.sSuperVisorTitle =reader[LibraryMOD.GetFieldName( sSuperVisorTitleFN) ].ToString();

if (!reader[LibraryMOD.GetFieldName(dDateFN)].Equals(DBNull.Value))
{
    myRequested_Forms.dDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dDateFN) ].ToString());
}
 results.Add(myRequested_Forms);
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

public List<Requested_Forms> GetRequested_Forms(int iCampus, int iTerm, byte bType,int iOperator,string sDate)
{
    //' returns a list of Classes instances based on the
    //' data in the Requested_Forms
    InitializeModule.EnumCampus Campus = (InitializeModule.EnumCampus)iCampus;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = "SELECT F.iFormNo AS [#], (CASE WHEN bSemester > 1 THEN CONVERT(char(5), iStudyYear + 1)";
    sSQL+=" + (CASE bSemester WHEN 2 THEN 'W' WHEN 3 THEN 'S1' WHEN 4 THEN 'S2' END) ELSE CONVERT(char(5), iStudyYear) + 'F' END) AS Term,";
    sSQL+=" F.sStudentNumber AS No, SD.strLastDescEn AS Name, T.strFormDesc AS Type, F.sRequestedCourse AS [Requested Course],";
    sSQL+=" M.strMajor AS [Requested Major], F.dDate AS Date, F.iStudyYear, F.bSemester, F.bRequestType"; 
    sSQL+=" FROM Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN";
    sSQL+=" Reg_Form_Types AS T INNER JOIN Reg_Requested_Forms AS F ON T.byteForm = F.bRequestType ON A.lngStudentNumber = F.sStudentNumber LEFT OUTER JOIN";
    sSQL+=" Reg_Specializations AS M ON F.sRequestedCollege = M.strCollege AND F.sRequestedDegree = M.strDegree AND ";
    sSQL += " F.sRequestedMajor = M.strSpecialization LEFT OUTER JOIN Reg_Lecturers AS L ON F.iCourseLecturer = L.intLecturer";

    sSQL += " Where 1=1";        
    
    if (iTerm > 0)
    {
        int iYear;
        int iSem;
        iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
        sSQL+=" And F.iStudyYear="+iYear;
        sSQL+=" And F.bSemester="+iSem ;
    }
    if(bType>0)
    {
        sSQL+=" And F.bRequestType="+bType;
    }

    if (!string.IsNullOrEmpty(sDate) && sDate!="null")
    {
        sDate = LibraryMOD.GetUniversalDate(sDate);
        sSQL += " And F.dDate " + LibraryMOD.GetOperator((InitializeModule.CeComparisonOperator) iOperator) + " CONVERT(DATETIME,'" + sDate + "',102)";
    }

    sSQL += "Order By F.dDate DESC";

    
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Requested_Forms> results = new List<Requested_Forms>();
    try
    {
       
        Requested_Forms myRequested_Forms = new Requested_Forms();
       
        while (reader.Read())
        {
            myRequested_Forms = new Requested_Forms();
           
            myRequested_Forms.iFormNo = int.Parse(reader["#"].ToString());
            myRequested_Forms.sStudentNumber = reader["No"].ToString();
            myRequested_Forms.SStudentName = reader["Name"].ToString();
            myRequested_Forms.SRequestType = reader["Type"].ToString();
            myRequested_Forms.SMajor = reader["Requested Major"].ToString();
            myRequested_Forms.sRequestedCourse = reader["Requested Course"].ToString();
            myRequested_Forms.Term = reader["Term"].ToString();
            myRequested_Forms.dDate = DateTime.Parse( reader["Date"].ToString());
            
            results.Add(myRequested_Forms);
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

public List<Requested_Forms> Get_Graduated(InitializeModule.EnumCampus Campus, int iForm)
{
    //' returns a list of Classes instances based on the
    //' data in the Requested_Forms
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

    string sSQL = "SELECT F.iFormNo AS iForm, (CASE WHEN bSemester > 1 THEN CONVERT(char(5), iStudyYear + 1) + (CASE bSemester WHEN 2 THEN 'W' WHEN 3 THEN 'S1' WHEN 4 THEN 'S2' END) ELSE CONVERT(char(5), iStudyYear) + 'F' END) AS sTerm,";
    sSQL += " F.sStudentNumber AS sNo, SD.strLastDescEn AS sName, M.strDisplay AS sMajor, F.dDate, F.sMobile, F.sPhone, F.sAddress, F.sPOBox, F.sEmail, ";
    sSQL += " F.sWorkPlace, F.sJobTitle, F.sWorkPhone, F.sSuperVisor, F.sSuperVisorTitle, SD.strPhone1 AS sRegMobile, SD.strPhone2 AS sRegPhone FROM dbo.Reg_Students_Data AS SD INNER JOIN";
    sSQL += " dbo.Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN dbo.Reg_Requested_Forms AS F ON A.lngStudentNumber = F.sStudentNumber INNER JOIN";
    sSQL += " dbo.Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization";

    sSQL += " Where F.iFormNo=" + iForm;


    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Requested_Forms> results = new List<Requested_Forms>();
    try
    {

        Requested_Forms myRequested_Forms = new Requested_Forms();

        while (reader.Read())
        {
            myRequested_Forms = new Requested_Forms();

            myRequested_Forms.iFormNo = int.Parse(reader["iForm"].ToString());
            myRequested_Forms.sStudentNumber = reader["sNo"].ToString();
            myRequested_Forms.SStudentName = reader["sName"].ToString();
            myRequested_Forms.SMajor = reader["sMajor"].ToString();
            myRequested_Forms.Term = reader["sTerm"].ToString();
            myRequested_Forms.dDate = DateTime.Parse(reader["dDate"].ToString());
            myRequested_Forms.sMobile = reader["sMobile"].ToString();
            myRequested_Forms.sPhone = reader["sPhone"].ToString();
            myRequested_Forms.sAddress = reader["sAddress"].ToString();
            myRequested_Forms.sPOBox = reader["sPOBox"].ToString();
            myRequested_Forms.sEmail = reader["sEmail"].ToString();
            myRequested_Forms.sWorkPlace = reader["sWorkPlace"].ToString();
            myRequested_Forms.sJobTitle = reader["sJobTitle"].ToString();
            myRequested_Forms.sWorkPhone = reader["sWorkPhone"].ToString();
            myRequested_Forms.sSuperVisor = reader["sSuperVisor"].ToString();
            myRequested_Forms.sSuperVisorTitle = reader["sSuperVisorTitle"].ToString();
            myRequested_Forms.SRegMobile = reader["sRegMobile"].ToString();
            myRequested_Forms.SRegPhone = reader["sRegPhone"].ToString();
            results.Add(myRequested_Forms);
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
public List<Requested_Forms> Get_ChangeMajor(InitializeModule.EnumCampus Campus, int iForm)
{
    //' returns a list of Classes instances based on the
    //' data in the Requested_Forms
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

    string sSQL = "SELECT F.iFormNo AS iForm, (CASE WHEN bSemester > 1 THEN CONVERT(char(5), iStudyYear + 1) + (CASE bSemester WHEN 2 THEN 'W' WHEN 3 THEN 'S1' WHEN 4 THEN 'S2' END) ELSE CONVERT(char(5), iStudyYear) + 'F' END) AS sTerm, ";
    sSQL += " F.sStudentNumber AS sNo, SD.strLastDescEn AS sName, M.strDisplay AS sMajor, F.dDate, SD.strPhone1, SD.strPhone2, S.strDisplay AS sRequested";
    sSQL += " FROM Reg_Students_Data AS SD INNER JOIN";
    sSQL += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN";
    sSQL += " Reg_Requested_Forms AS F ON A.lngStudentNumber = F.sStudentNumber INNER JOIN";
    sSQL += " Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
    sSQL += " Reg_Specializations AS S ON F.sRequestedCollege = S.strCollege AND F.sRequestedDegree = S.strDegree AND";
    sSQL += " F.sRequestedMajor = S.strSpecialization";
    sSQL += " Where F.iFormNo=" + iForm;

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Requested_Forms> results = new List<Requested_Forms>();
    try
    {

        Requested_Forms myRequested_Forms = new Requested_Forms();

        while (reader.Read())
        {
            myRequested_Forms = new Requested_Forms();

            myRequested_Forms.iFormNo = int.Parse(reader["iForm"].ToString());
            myRequested_Forms.sStudentNumber = reader["sNo"].ToString();
            myRequested_Forms.SStudentName = reader["sName"].ToString();
            myRequested_Forms.SMajor = reader["sMajor"].ToString();
            myRequested_Forms.Term = reader["sTerm"].ToString();
            myRequested_Forms.dDate = DateTime.Parse(reader["dDate"].ToString());
            myRequested_Forms.SRegMobile = reader["strPhone1"].ToString();
            myRequested_Forms.SRegPhone = reader["strPhone2"].ToString();
            myRequested_Forms.sRequestedMajor = reader["sRequested"].ToString();
            results.Add(myRequested_Forms);
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
public List<Requested_Forms> Get_Courses(InitializeModule.EnumCampus Campus, int iForm)
{
    //' returns a list of Classes instances based on the
    //' data in the Requested_Forms
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

    string sSQL = "SELECT F.iFormNo AS iForm, (CASE WHEN bSemester > 1 THEN CONVERT(char(5), iStudyYear + 1) ";
        sSQL += " + (CASE bSemester WHEN 2 THEN 'W' WHEN 3 THEN 'S1' WHEN 4 THEN 'S2' END) ELSE CONVERT(char(5), iStudyYear) + 'F' END) AS sTerm,";
        sSQL += " F.sStudentNumber AS sNo, SD.strLastDescEn AS sName, M.strDisplay AS sMajor, F.dDate, SD.strPhone1, SD.strPhone2, F.sRequestedCourse,";
        sSQL += " l.strLecturers AS sInstructor, Reg_Courses.strCourseDescEn AS sDesc";
        sSQL += " FROM Reg_Students_Data AS SD INNER JOIN";
        sSQL += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN";
        sSQL += " Reg_Requested_Forms AS F ON A.lngStudentNumber = F.sStudentNumber INNER JOIN";
        sSQL += " Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
        sSQL += " Course_Balance_View_Eq AS cb ON F.sStudentNumber = cb.Student AND F.sRequestedCourse = cb.Course INNER JOIN";
        sSQL += " Class_Lecturers AS l ON cb.iYear = l.intStudyYear AND cb.Sem = l.byteSemester AND cb.Shift = l.byteShift AND"; 
        sSQL += " cb.Course COLLATE Arabic_CI_AS = l.strCourse AND cb.Class = l.byteClass INNER JOIN";
        sSQL += " Reg_Courses ON F.sRequestedCourse = Reg_Courses.strCourse";
        sSQL += " WHERE F.iFormNo=" + iForm;

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Requested_Forms> results = new List<Requested_Forms>();
    try
    {

        Requested_Forms myRequested_Forms = new Requested_Forms();

        while (reader.Read())
        {
            myRequested_Forms = new Requested_Forms();

            myRequested_Forms.iFormNo = int.Parse(reader["iForm"].ToString());
            myRequested_Forms.sStudentNumber = reader["sNo"].ToString();
            myRequested_Forms.SStudentName = reader["sName"].ToString();
            myRequested_Forms.SMajor = reader["sMajor"].ToString();
            myRequested_Forms.Term = reader["sTerm"].ToString();
            myRequested_Forms.dDate = DateTime.Parse(reader["dDate"].ToString());
            myRequested_Forms.SRegMobile = reader["strPhone1"].ToString();
            myRequested_Forms.SRegPhone = reader["strPhone2"].ToString();
            myRequested_Forms.sRequestedCourse = reader["sRequestedCourse"].ToString();
            myRequested_Forms.Course_Desc = reader["sDesc"].ToString();
            myRequested_Forms.SLecturer = reader["sInstructor"].ToString();
            results.Add(myRequested_Forms);

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

public int UpdateRequested_Forms(InitializeModule.EnumCampus Campus, int iMode,int iFormNo,int iStudyYear,int bSemester,string sStudentNumber,int bRequestType,string sReason,string sRequestedCollege,string sRequestedDegree,string sRequestedMajor,string sRequestedCourse,int iCourseLecturer,string sAddress,string sPOBox,string sMobile,string sPhone,string sEmail,string isEmployed,string sWorkPlace,string sJobTitle,string sWorkPhone,string sSuperVisor,string sSuperVisorTitle,DateTime dDate)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Requested_Forms theRequested_Forms = new Requested_Forms();
//'Updates the  table
switch(iMode) 
  {
  case  (int)InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@iFormNo",iFormNo));
Cmd.Parameters.Add(new SqlParameter("@iStudyYear",iStudyYear));
Cmd.Parameters.Add(new SqlParameter("@bSemester",bSemester));
Cmd.Parameters.Add(new SqlParameter("@sStudentNumber",sStudentNumber));
Cmd.Parameters.Add(new SqlParameter("@bRequestType",bRequestType));
Cmd.Parameters.Add(new SqlParameter("@sReason",sReason));
Cmd.Parameters.Add(new SqlParameter("@sRequestedCollege",sRequestedCollege));
Cmd.Parameters.Add(new SqlParameter("@sRequestedDegree",sRequestedDegree));
Cmd.Parameters.Add(new SqlParameter("@sRequestedMajor",sRequestedMajor));
Cmd.Parameters.Add(new SqlParameter("@sRequestedCourse",sRequestedCourse));
Cmd.Parameters.Add(new SqlParameter("@iCourseLecturer",iCourseLecturer));
Cmd.Parameters.Add(new SqlParameter("@sAddress",sAddress));
Cmd.Parameters.Add(new SqlParameter("@sPOBox",sPOBox));
Cmd.Parameters.Add(new SqlParameter("@sMobile",sMobile));
Cmd.Parameters.Add(new SqlParameter("@sPhone",sPhone));
Cmd.Parameters.Add(new SqlParameter("@sEmail",sEmail));
Cmd.Parameters.Add(new SqlParameter("@isEmployed",isEmployed));
Cmd.Parameters.Add(new SqlParameter("@sWorkPlace",sWorkPlace));
Cmd.Parameters.Add(new SqlParameter("@sJobTitle",sJobTitle));
Cmd.Parameters.Add(new SqlParameter("@sWorkPhone",sWorkPhone));
Cmd.Parameters.Add(new SqlParameter("@sSuperVisor",sSuperVisor));
Cmd.Parameters.Add(new SqlParameter("@sSuperVisorTitle",sSuperVisorTitle));
Cmd.Parameters.Add(new SqlParameter("@dDate",dDate));
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
public int DeleteRequested_Forms(InitializeModule.EnumCampus Campus,string iFormNo)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@iFormNo", iFormNo ));
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
    public int UpdateRequested_Forms(InitializeModule.EnumCampus Campus, int iMode,Requested_Forms myForm,string sDate)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Requested_Forms theRequested_Forms = new Requested_Forms();
            //'Updates the  table
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    sql = GetUpdateCommand();
                    break;
                case (int)InitializeModule.enumModes.NewMode:
                    sql = GetInsertCommand();
                    break;
            }
            SqlCommand Cmd = new SqlCommand(sql, Conn);
            Cmd.Parameters.Add(new SqlParameter("@iFormNo", myForm.iFormNo));
            Cmd.Parameters.Add(new SqlParameter("@iStudyYear", myForm.iStudyYear));
            Cmd.Parameters.Add(new SqlParameter("@bSemester", myForm.bSemester));
            Cmd.Parameters.Add(new SqlParameter("@sStudentNumber", myForm.sStudentNumber));
            Cmd.Parameters.Add(new SqlParameter("@bRequestType", myForm.bRequestType));
            Cmd.Parameters.Add(new SqlParameter("@sReason", myForm.sReason));
            Cmd.Parameters.Add(new SqlParameter("@sRequestedCollege", myForm.sRequestedCollege));
            Cmd.Parameters.Add(new SqlParameter("@sRequestedDegree", myForm.sRequestedDegree));
            Cmd.Parameters.Add(new SqlParameter("@sRequestedMajor", myForm.sRequestedMajor));
            Cmd.Parameters.Add(new SqlParameter("@sRequestedCourse", myForm.sRequestedCourse));
            Cmd.Parameters.Add(new SqlParameter("@iCourseLecturer", myForm.iCourseLecturer));
            Cmd.Parameters.Add(new SqlParameter("@sAddress", myForm.sAddress));
            Cmd.Parameters.Add(new SqlParameter("@sPOBox", myForm.sPOBox));
            Cmd.Parameters.Add(new SqlParameter("@sMobile", myForm.sMobile));
            Cmd.Parameters.Add(new SqlParameter("@sPhone", myForm.sPhone));
            Cmd.Parameters.Add(new SqlParameter("@sEmail", myForm.sEmail));
            Cmd.Parameters.Add(new SqlParameter("@isEmployed", myForm.isEmployed));
            Cmd.Parameters.Add(new SqlParameter("@sWorkPlace", myForm.sWorkPlace));
            Cmd.Parameters.Add(new SqlParameter("@sJobTitle", myForm.sJobTitle));
            Cmd.Parameters.Add(new SqlParameter("@sWorkPhone", myForm.sWorkPhone));
            Cmd.Parameters.Add(new SqlParameter("@sSuperVisor", myForm.sSuperVisor));
            Cmd.Parameters.Add(new SqlParameter("@sSuperVisorTitle", myForm.sSuperVisorTitle));
            sDate = LibraryMOD.GetUniversalDate(sDate);
            Cmd.Parameters.Add(new SqlParameter("@dDate", sDate));
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
DataTable dt = new DataTable("Requested_Forms");
DataView dv = new DataView();
List<Requested_Forms> myRequested_Formss = new List<Requested_Forms>();
try
{
myRequested_Formss = GetRequested_Forms(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("iFormNo", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("iStudyYear", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("bSemester", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myRequested_Formss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myRequested_Formss[i].iFormNo;
  dr[2] = myRequested_Formss[i].iStudyYear;
  dr[3] = myRequested_Formss[i].bSemester;
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
myRequested_Formss.Clear();
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
sSQL += iFormNoFN;
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
public class Requested_FormsCls : Requested_FormsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daRequested_Forms;
private DataSet m_dsRequested_Forms;
public DataRow Requested_FormsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsRequested_Forms
{
get { return m_dsRequested_Forms ; }
set { m_dsRequested_Forms = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Requested_FormsCls()
{
try
{
dsRequested_Forms= new DataSet();

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
public virtual SqlDataAdapter GetRequested_FormsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daRequested_Forms = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daRequested_Forms);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daRequested_Forms.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daRequested_Forms;
}
public virtual SqlDataAdapter GetRequested_FormsDataAdapter(SqlConnection con)  
{
try
{
daRequested_Forms = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daRequested_Forms.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdRequested_Forms;
cmdRequested_Forms = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@iFormNo", SqlDbType.Int, 4, "iFormNo" );
daRequested_Forms.SelectCommand = cmdRequested_Forms;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdRequested_Forms = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdRequested_Forms.Parameters.Add("@iFormNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(iFormNoFN));
cmdRequested_Forms.Parameters.Add("@iStudyYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(iStudyYearFN));
cmdRequested_Forms.Parameters.Add("@bSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(bSemesterFN));
cmdRequested_Forms.Parameters.Add("@sStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sStudentNumberFN));
cmdRequested_Forms.Parameters.Add("@bRequestType", SqlDbType.Int,2, LibraryMOD.GetFieldName(bRequestTypeFN));
cmdRequested_Forms.Parameters.Add("@sReason", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(sReasonFN));
cmdRequested_Forms.Parameters.Add("@sRequestedCollege", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedCollegeFN));
cmdRequested_Forms.Parameters.Add("@sRequestedDegree", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedDegreeFN));
cmdRequested_Forms.Parameters.Add("@sRequestedMajor", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedMajorFN));
cmdRequested_Forms.Parameters.Add("@sRequestedCourse", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedCourseFN));
cmdRequested_Forms.Parameters.Add("@iCourseLecturer", SqlDbType.Int,4, LibraryMOD.GetFieldName(iCourseLecturerFN));
cmdRequested_Forms.Parameters.Add("@sAddress", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(sAddressFN));
cmdRequested_Forms.Parameters.Add("@sPOBox", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sPOBoxFN));
cmdRequested_Forms.Parameters.Add("@sMobile", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sMobileFN));
cmdRequested_Forms.Parameters.Add("@sPhone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sPhoneFN));
cmdRequested_Forms.Parameters.Add("@sEmail", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sEmailFN));
cmdRequested_Forms.Parameters.Add("@isEmployed", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isEmployedFN));
cmdRequested_Forms.Parameters.Add("@sWorkPlace", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sWorkPlaceFN));
cmdRequested_Forms.Parameters.Add("@sJobTitle", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sJobTitleFN));
cmdRequested_Forms.Parameters.Add("@sWorkPhone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sWorkPhoneFN));
cmdRequested_Forms.Parameters.Add("@sSuperVisor", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sSuperVisorFN));
cmdRequested_Forms.Parameters.Add("@sSuperVisorTitle", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sSuperVisorTitleFN));
cmdRequested_Forms.Parameters.Add("@dDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dDateFN));


Parmeter = cmdRequested_Forms.Parameters.Add("@iFormNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iFormNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daRequested_Forms.UpdateCommand = cmdRequested_Forms;
daRequested_Forms.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdRequested_Forms = new SqlCommand(GetInsertCommand(), con);
cmdRequested_Forms.Parameters.Add("@iFormNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(iFormNoFN));
cmdRequested_Forms.Parameters.Add("@iStudyYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(iStudyYearFN));
cmdRequested_Forms.Parameters.Add("@bSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(bSemesterFN));
cmdRequested_Forms.Parameters.Add("@sStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sStudentNumberFN));
cmdRequested_Forms.Parameters.Add("@bRequestType", SqlDbType.Int,2, LibraryMOD.GetFieldName(bRequestTypeFN));
cmdRequested_Forms.Parameters.Add("@sReason", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(sReasonFN));
cmdRequested_Forms.Parameters.Add("@sRequestedCollege", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedCollegeFN));
cmdRequested_Forms.Parameters.Add("@sRequestedDegree", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedDegreeFN));
cmdRequested_Forms.Parameters.Add("@sRequestedMajor", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedMajorFN));
cmdRequested_Forms.Parameters.Add("@sRequestedCourse", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sRequestedCourseFN));
cmdRequested_Forms.Parameters.Add("@iCourseLecturer", SqlDbType.Int,4, LibraryMOD.GetFieldName(iCourseLecturerFN));
cmdRequested_Forms.Parameters.Add("@sAddress", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(sAddressFN));
cmdRequested_Forms.Parameters.Add("@sPOBox", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sPOBoxFN));
cmdRequested_Forms.Parameters.Add("@sMobile", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sMobileFN));
cmdRequested_Forms.Parameters.Add("@sPhone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sPhoneFN));
cmdRequested_Forms.Parameters.Add("@sEmail", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sEmailFN));
cmdRequested_Forms.Parameters.Add("@isEmployed", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isEmployedFN));
cmdRequested_Forms.Parameters.Add("@sWorkPlace", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sWorkPlaceFN));
cmdRequested_Forms.Parameters.Add("@sJobTitle", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sJobTitleFN));
cmdRequested_Forms.Parameters.Add("@sWorkPhone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sWorkPhoneFN));
cmdRequested_Forms.Parameters.Add("@sSuperVisor", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sSuperVisorFN));
cmdRequested_Forms.Parameters.Add("@sSuperVisorTitle", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sSuperVisorTitleFN));
cmdRequested_Forms.Parameters.Add("@dDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dDateFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daRequested_Forms.InsertCommand =cmdRequested_Forms;
daRequested_Forms.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdRequested_Forms = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdRequested_Forms.Parameters.Add("@iFormNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iFormNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daRequested_Forms.DeleteCommand =cmdRequested_Forms;
daRequested_Forms.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daRequested_Forms.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daRequested_Forms;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsRequested_Forms.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(iFormNoFN)]=iFormNo;
dr[LibraryMOD.GetFieldName(iStudyYearFN)]=iStudyYear;
dr[LibraryMOD.GetFieldName(bSemesterFN)]=bSemester;
dr[LibraryMOD.GetFieldName(sStudentNumberFN)]=sStudentNumber;
dr[LibraryMOD.GetFieldName(bRequestTypeFN)]=bRequestType;
dr[LibraryMOD.GetFieldName(sReasonFN)]=sReason;
dr[LibraryMOD.GetFieldName(sRequestedCollegeFN)]=sRequestedCollege;
dr[LibraryMOD.GetFieldName(sRequestedDegreeFN)]=sRequestedDegree;
dr[LibraryMOD.GetFieldName(sRequestedMajorFN)]=sRequestedMajor;
dr[LibraryMOD.GetFieldName(sRequestedCourseFN)]=sRequestedCourse;
dr[LibraryMOD.GetFieldName(iCourseLecturerFN)]=iCourseLecturer;
dr[LibraryMOD.GetFieldName(sAddressFN)]=sAddress;
dr[LibraryMOD.GetFieldName(sPOBoxFN)]=sPOBox;
dr[LibraryMOD.GetFieldName(sMobileFN)]=sMobile;
dr[LibraryMOD.GetFieldName(sPhoneFN)]=sPhone;
dr[LibraryMOD.GetFieldName(sEmailFN)]=sEmail;
dr[LibraryMOD.GetFieldName(isEmployedFN)]=isEmployed;
dr[LibraryMOD.GetFieldName(sWorkPlaceFN)]=sWorkPlace;
dr[LibraryMOD.GetFieldName(sJobTitleFN)]=sJobTitle;
dr[LibraryMOD.GetFieldName(sWorkPhoneFN)]=sWorkPhone;
dr[LibraryMOD.GetFieldName(sSuperVisorFN)]=sSuperVisor;
dr[LibraryMOD.GetFieldName(sSuperVisorTitleFN)]=sSuperVisorTitle;
dr[LibraryMOD.GetFieldName(dDateFN)]=dDate;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsRequested_Forms.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsRequested_Forms.Tables[TableName].Select(LibraryMOD.GetFieldName(iFormNoFN)  + "=" + iFormNo);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(iFormNoFN)]=iFormNo;
drAry[0][LibraryMOD.GetFieldName(iStudyYearFN)]=iStudyYear;
drAry[0][LibraryMOD.GetFieldName(bSemesterFN)]=bSemester;
drAry[0][LibraryMOD.GetFieldName(sStudentNumberFN)]=sStudentNumber;
drAry[0][LibraryMOD.GetFieldName(bRequestTypeFN)]=bRequestType;
drAry[0][LibraryMOD.GetFieldName(sReasonFN)]=sReason;
drAry[0][LibraryMOD.GetFieldName(sRequestedCollegeFN)]=sRequestedCollege;
drAry[0][LibraryMOD.GetFieldName(sRequestedDegreeFN)]=sRequestedDegree;
drAry[0][LibraryMOD.GetFieldName(sRequestedMajorFN)]=sRequestedMajor;
drAry[0][LibraryMOD.GetFieldName(sRequestedCourseFN)]=sRequestedCourse;
drAry[0][LibraryMOD.GetFieldName(iCourseLecturerFN)]=iCourseLecturer;
drAry[0][LibraryMOD.GetFieldName(sAddressFN)]=sAddress;
drAry[0][LibraryMOD.GetFieldName(sPOBoxFN)]=sPOBox;
drAry[0][LibraryMOD.GetFieldName(sMobileFN)]=sMobile;
drAry[0][LibraryMOD.GetFieldName(sPhoneFN)]=sPhone;
drAry[0][LibraryMOD.GetFieldName(sEmailFN)]=sEmail;
drAry[0][LibraryMOD.GetFieldName(isEmployedFN)]=isEmployed;
drAry[0][LibraryMOD.GetFieldName(sWorkPlaceFN)]=sWorkPlace;
drAry[0][LibraryMOD.GetFieldName(sJobTitleFN)]=sJobTitle;
drAry[0][LibraryMOD.GetFieldName(sWorkPhoneFN)]=sWorkPhone;
drAry[0][LibraryMOD.GetFieldName(sSuperVisorFN)]=sSuperVisor;
drAry[0][LibraryMOD.GetFieldName(sSuperVisorTitleFN)]=sSuperVisorTitle;
drAry[0][LibraryMOD.GetFieldName(dDateFN)]=dDate;
//drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
return InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitRequested_Forms()  
{
//CommitRequested_Forms= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daRequested_Forms.Update(dsRequested_Forms, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow= InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(iFormNo);
if (( Requested_FormsDataRow != null)) 
{
Requested_FormsDataRow.Delete();
CommitRequested_Forms();
if (MoveNext() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(iFormNoFN)]== System.DBNull.Value)
{
  iFormNo=0;
}
else
{
  iFormNo = (int)Requested_FormsDataRow[LibraryMOD.GetFieldName(iFormNoFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(iStudyYearFN)]== System.DBNull.Value)
{
  iStudyYear=0;
}
else
{
  iStudyYear = (int)Requested_FormsDataRow[LibraryMOD.GetFieldName(iStudyYearFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(bSemesterFN)]== System.DBNull.Value)
{
  bSemester=0;
}
else
{
  bSemester = (int)Requested_FormsDataRow[LibraryMOD.GetFieldName(bSemesterFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sStudentNumberFN)]== System.DBNull.Value)
{
  sStudentNumber="";
}
else
{
  sStudentNumber = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sStudentNumberFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(bRequestTypeFN)]== System.DBNull.Value)
{
  bRequestType=0;
}
else
{
  bRequestType = (int)Requested_FormsDataRow[LibraryMOD.GetFieldName(bRequestTypeFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sReasonFN)]== System.DBNull.Value)
{
  sReason="";
}
else
{
  sReason = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sReasonFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedCollegeFN)]== System.DBNull.Value)
{
  sRequestedCollege="";
}
else
{
  sRequestedCollege = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedCollegeFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedDegreeFN)]== System.DBNull.Value)
{
  sRequestedDegree="";
}
else
{
  sRequestedDegree = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedDegreeFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedMajorFN)]== System.DBNull.Value)
{
  sRequestedMajor="";
}
else
{
  sRequestedMajor = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedMajorFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedCourseFN)]== System.DBNull.Value)
{
  sRequestedCourse="";
}
else
{
  sRequestedCourse = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sRequestedCourseFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(iCourseLecturerFN)]== System.DBNull.Value)
{
  iCourseLecturer=0;
}
else
{
  iCourseLecturer = (int)Requested_FormsDataRow[LibraryMOD.GetFieldName(iCourseLecturerFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sAddressFN)]== System.DBNull.Value)
{
  sAddress="";
}
else
{
  sAddress = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sAddressFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sPOBoxFN)]== System.DBNull.Value)
{
  sPOBox="";
}
else
{
  sPOBox = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sPOBoxFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sMobileFN)]== System.DBNull.Value)
{
  sMobile="";
}
else
{
  sMobile = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sMobileFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sPhoneFN)]== System.DBNull.Value)
{
  sPhone="";
}
else
{
  sPhone = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sPhoneFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sEmailFN)]== System.DBNull.Value)
{
  sEmail="";
}
else
{
  sEmail = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sEmailFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(isEmployedFN)]== System.DBNull.Value)
{
  isEmployed=false;
}
else
{
  isEmployed = (bool)Requested_FormsDataRow[LibraryMOD.GetFieldName(isEmployedFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sWorkPlaceFN)]== System.DBNull.Value)
{
  sWorkPlace="";
}
else
{
  sWorkPlace = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sWorkPlaceFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sJobTitleFN)]== System.DBNull.Value)
{
  sJobTitle="";
}
else
{
  sJobTitle = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sJobTitleFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sWorkPhoneFN)]== System.DBNull.Value)
{
  sWorkPhone="";
}
else
{
  sWorkPhone = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sWorkPhoneFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sSuperVisorFN)]== System.DBNull.Value)
{
  sSuperVisor="";
}
else
{
  sSuperVisor = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sSuperVisorFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(sSuperVisorTitleFN)]== System.DBNull.Value)
{
  sSuperVisorTitle="";
}
else
{
  sSuperVisorTitle = (string)Requested_FormsDataRow[LibraryMOD.GetFieldName(sSuperVisorTitleFN)];
}
if (Requested_FormsDataRow[LibraryMOD.GetFieldName(dDateFN)]== System.DBNull.Value)
{
}
else
{
  dDate = (DateTime)Requested_FormsDataRow[LibraryMOD.GetFieldName(dDateFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(int PKiFormNo) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKiFormNo;
Requested_FormsDataRow = dsRequested_Forms.Tables[TableName].Rows.Find(findTheseVals);
if  ((Requested_FormsDataRow !=null)) 
{
lngCurRow = dsRequested_Forms.Tables[TableName].Rows.IndexOf(Requested_FormsDataRow);
SynchronizeDataRowToClass();
return InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst= InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast= InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsRequested_Forms.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsRequested_Forms.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow= InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsRequested_Forms.Tables[TableName].Rows.Count > 0) 
{
  Requested_FormsDataRow = dsRequested_Forms.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
// InitializeModule.FAIL_RET;
try
{
daRequested_Forms.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daRequested_Forms.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daRequested_Forms.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daRequested_Forms.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
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
