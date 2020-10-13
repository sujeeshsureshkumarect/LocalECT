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
public class Advising_CGPA_Tracking
{
//Creation Date: 08/06/2017 3:51:17 PM
//Programmer Name : Bahaa Addin
//-----Decleration --------------
#region "Decleration"
private int m_intTrackingID; 
private int m_intStudyYear; 
private int m_byteSemester; 
private string m_lngStudentNumber; 
private string m_strCourse; 
private string m_strExpectedGrade; 
private double m_dblOldCGPA; 
private double m_dblNewCGPA; 
private int m_intAdvisorID; 
private string m_sAdvisorComments; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
private string m_field1; 
private string m_field2; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intTrackingID
{
get { return  m_intTrackingID; }
set {m_intTrackingID  = value ; }
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
public string lngStudentNumber
{
get { return  m_lngStudentNumber; }
set {m_lngStudentNumber  = value ; }
}
public string strCourse
{
get { return  m_strCourse; }
set {m_strCourse  = value ; }
}
public string strExpectedGrade
{
get { return  m_strExpectedGrade; }
set {m_strExpectedGrade  = value ; }
}
public double dblOldCGPA
{
get { return  m_dblOldCGPA; }
set {m_dblOldCGPA  = value ; }
}
public double dblNewCGPA
{
get { return  m_dblNewCGPA; }
set {m_dblNewCGPA  = value ; }
}
public int intAdvisorID
{
get { return  m_intAdvisorID; }
set {m_intAdvisorID  = value ; }
}
public string sAdvisorComments
{
get { return  m_sAdvisorComments; }
set {m_sAdvisorComments  = value ; }
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
public string field1
{
get { return  m_field1; }
set {m_field1  = value ; }
}
public string field2
{
get { return  m_field2; }
set {m_field2  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Advising_CGPA_Tracking()
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
public class Advising_CGPA_TrackingDAL : Advising_CGPA_Tracking
{
#region "Decleration"
private string m_TableName;
private string m_intTrackingIDFN ;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_lngStudentNumberFN ;
private string m_strCourseFN ;
private string m_strExpectedGradeFN ;
private string m_dblOldCGPAFN ;
private string m_dblNewCGPAFN ;
private string m_intAdvisorIDFN ;
private string m_sAdvisorCommentsFN ;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
private string m_field1FN ;
private string m_field2FN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string intTrackingIDFN 
{
get { return  m_intTrackingIDFN; }
set {m_intTrackingIDFN  = value ; }
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
public string lngStudentNumberFN 
{
get { return  m_lngStudentNumberFN; }
set {m_lngStudentNumberFN  = value ; }
}
public string strCourseFN 
{
get { return  m_strCourseFN; }
set {m_strCourseFN  = value ; }
}
public string strExpectedGradeFN 
{
get { return  m_strExpectedGradeFN; }
set {m_strExpectedGradeFN  = value ; }
}
public string dblOldCGPAFN 
{
get { return  m_dblOldCGPAFN; }
set {m_dblOldCGPAFN  = value ; }
}
public string dblNewCGPAFN 
{
get { return  m_dblNewCGPAFN; }
set {m_dblNewCGPAFN  = value ; }
}
public string intAdvisorIDFN 
{
get { return  m_intAdvisorIDFN; }
set {m_intAdvisorIDFN  = value ; }
}
public string sAdvisorCommentsFN 
{
get { return  m_sAdvisorCommentsFN; }
set {m_sAdvisorCommentsFN  = value ; }
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
public string field1FN 
{
get { return  m_field1FN; }
set {m_field1FN  = value ; }
}
public string field2FN 
{
get { return  m_field2FN; }
set {m_field2FN  = value ; }
}
#endregion
//================End Properties ===================
public Advising_CGPA_TrackingDAL()
{
try
{
this.TableName = "Reg_Advising_CGPA_Tracking";
this.intTrackingIDFN = m_TableName + ".intTrackingID";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.lngStudentNumberFN = m_TableName + ".lngStudentNumber";
this.strCourseFN = m_TableName + ".strCourse";
this.strExpectedGradeFN = m_TableName + ".strExpectedGrade";
this.dblOldCGPAFN = m_TableName + ".dblOldCGPA";
this.dblNewCGPAFN = m_TableName + ".dblNewCGPA";
this.intAdvisorIDFN = m_TableName + ".intAdvisorID";
this.sAdvisorCommentsFN = m_TableName + ".sAdvisorComments";
this.strUserCreateFN = m_TableName + ".strUserCreate";
this.dateCreateFN = m_TableName + ".dateCreate";
this.strUserSaveFN = m_TableName + ".strUserSave";
this.dateLastSaveFN = m_TableName + ".dateLastSave";
this.strMachineFN = m_TableName + ".strMachine";
this.strNUserFN = m_TableName + ".strNUser";
this.field1FN = m_TableName + ".field1";
this.field2FN = m_TableName + ".field2";
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
sSQL +=intTrackingIDFN;
sSQL += " , " + intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + strExpectedGradeFN;
sSQL += " , " + dblOldCGPAFN;
sSQL += " , " + dblNewCGPAFN;
sSQL += " , " + intAdvisorIDFN;
sSQL += " , " + sAdvisorCommentsFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += " , " + field1FN;
sSQL += " , " + field2FN;
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
public string GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=intTrackingIDFN;
sSQL += " , " + intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += "  FROM " + m_TableName;
sSQL += sCondition;

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
sSQL +=intTrackingIDFN;
sSQL += " , " + intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + strExpectedGradeFN;
sSQL += " , " + dblOldCGPAFN;
sSQL += " , " + dblNewCGPAFN;
sSQL += " , " + intAdvisorIDFN;
sSQL += " , " + sAdvisorCommentsFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += " , " + field1FN;
sSQL += " , " + field2FN;
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
sSQL += LibraryMOD.GetFieldName(intTrackingIDFN) + "=@intTrackingID";
sSQL += " , " + LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
sSQL += " , " + LibraryMOD.GetFieldName(strExpectedGradeFN) + "=@strExpectedGrade";
sSQL += " , " + LibraryMOD.GetFieldName(dblOldCGPAFN) + "=@dblOldCGPA";
sSQL += " , " + LibraryMOD.GetFieldName(dblNewCGPAFN) + "=@dblNewCGPA";
sSQL += " , " + LibraryMOD.GetFieldName(intAdvisorIDFN) + "=@intAdvisorID";
sSQL += " , " + LibraryMOD.GetFieldName(sAdvisorCommentsFN) + "=@sAdvisorComments";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " , " + LibraryMOD.GetFieldName(field1FN) + "=@field1";
sSQL += " , " + LibraryMOD.GetFieldName(field2FN) + "=@field2";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intTrackingIDFN)+"=@intTrackingID";
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
sSQL +=LibraryMOD.GetFieldName(intTrackingIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(intStudyYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(strExpectedGradeFN);
sSQL += " , " + LibraryMOD.GetFieldName(dblOldCGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(dblNewCGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(intAdvisorIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(sAdvisorCommentsFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += " , " + LibraryMOD.GetFieldName(field1FN);
sSQL += " , " + LibraryMOD.GetFieldName(field2FN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intTrackingID";
sSQL += " ,@intStudyYear";
sSQL += " ,@byteSemester";
sSQL += " ,@lngStudentNumber";
sSQL += " ,@strCourse";
sSQL += " ,@strExpectedGrade";
sSQL += " ,@dblOldCGPA";
sSQL += " ,@dblNewCGPA";
sSQL += " ,@intAdvisorID";
sSQL += " ,@sAdvisorComments";
sSQL += " ,@strUserCreate";
sSQL += " ,@dateCreate";
sSQL += " ,@strUserSave";
sSQL += " ,@dateLastSave";
sSQL += " ,@strMachine";
sSQL += " ,@strNUser";
sSQL += " ,@field1";
sSQL += " ,@field2";
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
sSQL += LibraryMOD.GetFieldName(intTrackingIDFN)+"=@intTrackingID";
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
public List< Advising_CGPA_Tracking> GetAdvising_CGPA_Tracking(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Advising_CGPA_Tracking
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
List<Advising_CGPA_Tracking> results = new List<Advising_CGPA_Tracking>();
try
{
//Default Value
Advising_CGPA_Tracking myAdvising_CGPA_Tracking = new Advising_CGPA_Tracking();
if (isDeafaultIncluded)
{
//Change the code here
myAdvising_CGPA_Tracking.intTrackingID = 0;
//myAdvising_CGPA_Tracking.intTrackingID = "Select Advising_CGPA_Tracking ...";
results.Add(myAdvising_CGPA_Tracking);
}
while (reader.Read())
{
myAdvising_CGPA_Tracking = new Advising_CGPA_Tracking();
if (reader[LibraryMOD.GetFieldName(intTrackingIDFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.intTrackingID = 0;
}
else
{
myAdvising_CGPA_Tracking.intTrackingID = int.Parse(reader[LibraryMOD.GetFieldName( intTrackingIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.intStudyYear = 0;
}
else
{
myAdvising_CGPA_Tracking.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.byteSemester = 0;
}
else
{
myAdvising_CGPA_Tracking.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
myAdvising_CGPA_Tracking.lngStudentNumber =reader[LibraryMOD.GetFieldName( lngStudentNumberFN) ].ToString();
myAdvising_CGPA_Tracking.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
myAdvising_CGPA_Tracking.strExpectedGrade =reader[LibraryMOD.GetFieldName( strExpectedGradeFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(intAdvisorIDFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.intAdvisorID = 0;
}
else
{
myAdvising_CGPA_Tracking.intAdvisorID = int.Parse(reader[LibraryMOD.GetFieldName( intAdvisorIDFN) ].ToString());
}
myAdvising_CGPA_Tracking.sAdvisorComments =reader[LibraryMOD.GetFieldName( sAdvisorCommentsFN) ].ToString();
myAdvising_CGPA_Tracking.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myAdvising_CGPA_Tracking.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myAdvising_CGPA_Tracking.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myAdvising_CGPA_Tracking.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
myAdvising_CGPA_Tracking.field1 =reader[LibraryMOD.GetFieldName( field1FN) ].ToString();
myAdvising_CGPA_Tracking.field2 =reader[LibraryMOD.GetFieldName( field2FN) ].ToString();
 results.Add(myAdvising_CGPA_Tracking);
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
public List< Advising_CGPA_Tracking > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Advising_CGPA_Tracking> results = new List<Advising_CGPA_Tracking>();
try
{
//Default Value
Advising_CGPA_Tracking myAdvising_CGPA_Tracking= new Advising_CGPA_Tracking();
if (isDeafaultIncluded)
 {
//Change the code here
 myAdvising_CGPA_Tracking.intTrackingID = -1;
 //myAdvising_CGPA_Tracking.intStudyYear = "Select Advising_CGPA_Tracking" ;
results.Add(myAdvising_CGPA_Tracking);
 }
while (reader.Read())
{
myAdvising_CGPA_Tracking = new Advising_CGPA_Tracking();
if (reader[LibraryMOD.GetFieldName(intTrackingIDFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.intTrackingID = 0;
}
else
{
myAdvising_CGPA_Tracking.intTrackingID = int.Parse(reader[LibraryMOD.GetFieldName( intTrackingIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.intStudyYear = 0;
}
else
{
myAdvising_CGPA_Tracking.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myAdvising_CGPA_Tracking.byteSemester = 0;
}
else
{
myAdvising_CGPA_Tracking.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
 results.Add(myAdvising_CGPA_Tracking);
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
public int UpdateAdvising_CGPA_Tracking(InitializeModule.EnumCampus Campus, int iMode,int intTrackingID,int intStudyYear,int byteSemester,string lngStudentNumber,string strCourse,string strExpectedGrade,decimal  dblOldCGPA,decimal dblNewCGPA,int intAdvisorID,string sAdvisorComments,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser,string field1,string field2)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Advising_CGPA_Tracking theAdvising_CGPA_Tracking = new Advising_CGPA_Tracking();
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
Cmd.Parameters.Add(new SqlParameter("@intTrackingID",intTrackingID));
Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));
Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
Cmd.Parameters.Add(new SqlParameter("@strExpectedGrade",strExpectedGrade));
Cmd.Parameters.Add(new SqlParameter("@dblOldCGPA",dblOldCGPA));
Cmd.Parameters.Add(new SqlParameter("@dblNewCGPA",dblNewCGPA));
Cmd.Parameters.Add(new SqlParameter("@intAdvisorID",intAdvisorID));
Cmd.Parameters.Add(new SqlParameter("@sAdvisorComments",sAdvisorComments));
Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));
Cmd.Parameters.Add(new SqlParameter("@field1",field1));
Cmd.Parameters.Add(new SqlParameter("@field2",field2));
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
public int DeleteAdvising_CGPA_Tracking(InitializeModule.EnumCampus Campus,string intTrackingID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intTrackingID", intTrackingID ));
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
DataTable dt = new DataTable("Advising_CGPA_Tracking");
DataView dv = new DataView();
List<Advising_CGPA_Tracking> myAdvising_CGPA_Trackings = new List<Advising_CGPA_Tracking>();
try
{
myAdvising_CGPA_Trackings = GetAdvising_CGPA_Tracking(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("intTrackingID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myAdvising_CGPA_Trackings.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myAdvising_CGPA_Trackings[i].intTrackingID;
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
myAdvising_CGPA_Trackings.Clear();
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
sSQL += intTrackingIDFN;
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
public class Advising_CGPA_TrackingCls : Advising_CGPA_TrackingDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daAdvising_CGPA_Tracking;
private DataSet m_dsAdvising_CGPA_Tracking;
public DataRow Advising_CGPA_TrackingDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsAdvising_CGPA_Tracking
{
get { return m_dsAdvising_CGPA_Tracking ; }
set { m_dsAdvising_CGPA_Tracking = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Advising_CGPA_TrackingCls()
{
try
{
dsAdvising_CGPA_Tracking= new DataSet();

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
public virtual SqlDataAdapter GetAdvising_CGPA_TrackingDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daAdvising_CGPA_Tracking = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daAdvising_CGPA_Tracking);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daAdvising_CGPA_Tracking.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAdvising_CGPA_Tracking;
}
public virtual SqlDataAdapter GetAdvising_CGPA_TrackingDataAdapter(SqlConnection con)  
{
try
{
daAdvising_CGPA_Tracking = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daAdvising_CGPA_Tracking.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdAdvising_CGPA_Tracking;
cmdAdvising_CGPA_Tracking = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intTrackingID", SqlDbType.Int, 4, "intTrackingID" );
daAdvising_CGPA_Tracking.SelectCommand = cmdAdvising_CGPA_Tracking;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdAdvising_CGPA_Tracking = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdAdvising_CGPA_Tracking.Parameters.Add("@intTrackingID", SqlDbType.Int,4, LibraryMOD.GetFieldName(intTrackingIDFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strExpectedGrade", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strExpectedGradeFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dblOldCGPA", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(dblOldCGPAFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dblNewCGPA", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(dblNewCGPAFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@intAdvisorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(intAdvisorIDFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@sAdvisorComments", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(sAdvisorCommentsFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strUserSave", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserSaveFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@field1", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(field1FN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@field2", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(field2FN));


Parmeter = cmdAdvising_CGPA_Tracking.Parameters.Add("@intTrackingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intTrackingIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daAdvising_CGPA_Tracking.UpdateCommand = cmdAdvising_CGPA_Tracking;
daAdvising_CGPA_Tracking.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdAdvising_CGPA_Tracking = new SqlCommand(GetInsertCommand(), con);
cmdAdvising_CGPA_Tracking.Parameters.Add("@intTrackingID", SqlDbType.Int,4, LibraryMOD.GetFieldName(intTrackingIDFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strExpectedGrade", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strExpectedGradeFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dblOldCGPA", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(dblOldCGPAFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dblNewCGPA", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(dblNewCGPAFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@intAdvisorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(intAdvisorIDFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@sAdvisorComments", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(sAdvisorCommentsFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strUserSave", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserSaveFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@field1", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(field1FN));
cmdAdvising_CGPA_Tracking.Parameters.Add("@field2", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(field2FN));
Parmeter.SourceVersion = DataRowVersion.Current;
daAdvising_CGPA_Tracking.InsertCommand =cmdAdvising_CGPA_Tracking;
daAdvising_CGPA_Tracking.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdAdvising_CGPA_Tracking = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdAdvising_CGPA_Tracking.Parameters.Add("@intTrackingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intTrackingIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daAdvising_CGPA_Tracking.DeleteCommand =cmdAdvising_CGPA_Tracking;
daAdvising_CGPA_Tracking.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daAdvising_CGPA_Tracking.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAdvising_CGPA_Tracking;
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
dr = dsAdvising_CGPA_Tracking.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intTrackingIDFN)]=intTrackingID;
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
dr[LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
dr[LibraryMOD.GetFieldName(strExpectedGradeFN)]=strExpectedGrade;
dr[LibraryMOD.GetFieldName(dblOldCGPAFN)]=dblOldCGPA;
dr[LibraryMOD.GetFieldName(dblNewCGPAFN)]=dblNewCGPA;
dr[LibraryMOD.GetFieldName(intAdvisorIDFN)]=intAdvisorID;
dr[LibraryMOD.GetFieldName(sAdvisorCommentsFN)]=sAdvisorComments;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dr[LibraryMOD.GetFieldName(field1FN)]=field1;
dr[LibraryMOD.GetFieldName(field2FN)]=field2;
dsAdvising_CGPA_Tracking.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsAdvising_CGPA_Tracking.Tables[TableName].Select(LibraryMOD.GetFieldName(intTrackingIDFN)  + "=" + intTrackingID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intTrackingIDFN)]=intTrackingID;
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
drAry[0][LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
drAry[0][LibraryMOD.GetFieldName(strExpectedGradeFN)]=strExpectedGrade;
drAry[0][LibraryMOD.GetFieldName(dblOldCGPAFN)]=dblOldCGPA;
drAry[0][LibraryMOD.GetFieldName(dblNewCGPAFN)]=dblNewCGPA;
drAry[0][LibraryMOD.GetFieldName(intAdvisorIDFN)]=intAdvisorID;
drAry[0][LibraryMOD.GetFieldName(sAdvisorCommentsFN)]=sAdvisorComments;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
drAry[0][LibraryMOD.GetFieldName(field1FN)]=field1;
drAry[0][LibraryMOD.GetFieldName(field2FN)]=field2;
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
public int CommitAdvising_CGPA_Tracking()  
{
//CommitAdvising_CGPA_Tracking= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daAdvising_CGPA_Tracking.Update(dsAdvising_CGPA_Tracking, TableName);
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
FindInMultiPKey(intTrackingID);
if (( Advising_CGPA_TrackingDataRow != null)) 
{
Advising_CGPA_TrackingDataRow.Delete();
CommitAdvising_CGPA_Tracking();
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
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(intTrackingIDFN)]== System.DBNull.Value)
{
  intTrackingID=0;
}
else
{
  intTrackingID = (int)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(intTrackingIDFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)]== System.DBNull.Value)
{
  lngStudentNumber="";
}
else
{
  lngStudentNumber = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strCourseFN)]== System.DBNull.Value)
{
  strCourse="";
}
else
{
  strCourse = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strCourseFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strExpectedGradeFN)]== System.DBNull.Value)
{
  strExpectedGrade="";
}
else
{
  strExpectedGrade = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strExpectedGradeFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(dblOldCGPAFN)]== System.DBNull.Value)
{
}
else
{
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(dblNewCGPAFN)]== System.DBNull.Value)
{
}
else
{
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(intAdvisorIDFN)]== System.DBNull.Value)
{
  intAdvisorID=0;
}
else
{
  intAdvisorID = (int)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(intAdvisorIDFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(sAdvisorCommentsFN)]== System.DBNull.Value)
{
  sAdvisorComments="";
}
else
{
  sAdvisorComments = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(sAdvisorCommentsFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(strNUserFN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(field1FN)]== System.DBNull.Value)
{
  field1="";
}
else
{
  field1 = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(field1FN)];
}
if (Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(field2FN)]== System.DBNull.Value)
{
  field2="";
}
else
{
  field2 = (string)Advising_CGPA_TrackingDataRow[LibraryMOD.GetFieldName(field2FN)];
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
public int FindInMultiPKey(int PKintTrackingID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintTrackingID;
Advising_CGPA_TrackingDataRow = dsAdvising_CGPA_Tracking.Tables[TableName].Rows.Find(findTheseVals);
if  ((Advising_CGPA_TrackingDataRow !=null)) 
{
lngCurRow = dsAdvising_CGPA_Tracking.Tables[TableName].Rows.IndexOf(Advising_CGPA_TrackingDataRow);
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
  lngCurRow = dsAdvising_CGPA_Tracking.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsAdvising_CGPA_Tracking.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsAdvising_CGPA_Tracking.Tables[TableName].Rows.Count > 0) 
{
  Advising_CGPA_TrackingDataRow = dsAdvising_CGPA_Tracking.Tables[TableName].Rows[lngCurRow];
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
daAdvising_CGPA_Tracking.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAdvising_CGPA_Tracking.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daAdvising_CGPA_Tracking.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAdvising_CGPA_Tracking.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
