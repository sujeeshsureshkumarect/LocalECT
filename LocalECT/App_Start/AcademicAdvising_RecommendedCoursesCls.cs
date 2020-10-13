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
public class AcademicAdvising_RecommendedCourses
{
//Creation Date: 21/03/2019 5:08:05 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_AcademicAdvisingID; 
private string m_StudentID; 
private int m_AcademicYear; 
private int m_Semester; 
private string m_CourseID; 
private int m_SessionID; 
private int m_ClassID; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int AcademicAdvisingID
{
get { return  m_AcademicAdvisingID; }
set {m_AcademicAdvisingID  = value ; }
}
public string StudentID
{
get { return  m_StudentID; }
set {m_StudentID  = value ; }
}
public int AcademicYear
{
get { return  m_AcademicYear; }
set {m_AcademicYear  = value ; }
}
public int Semester
{
get { return  m_Semester; }
set {m_Semester  = value ; }
}
public string CourseID
{
get { return  m_CourseID; }
set {m_CourseID  = value ; }
}
public int SessionID
{
get { return  m_SessionID; }
set {m_SessionID  = value ; }
}
public int ClassID
{
get { return  m_ClassID; }
set {m_ClassID  = value ; }
}
public int CreationUserID
{
get { return  m_CreationUserID; }
set {m_CreationUserID  = value ; }
}
public DateTime CreationDate
{
get { return  m_CreationDate; }
set {m_CreationDate  = value ; }
}
public int LastUpdateUserID
{
get { return  m_LastUpdateUserID; }
set {m_LastUpdateUserID  = value ; }
}
public DateTime LastUpdateDate
{
get { return  m_LastUpdateDate; }
set {m_LastUpdateDate  = value ; }
}
public string PCName
{
get { return  m_PCName; }
set {m_PCName  = value ; }
}
public string NetUserName
{
get { return  m_NetUserName; }
set {m_NetUserName  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public AcademicAdvising_RecommendedCourses()
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
public class AcademicAdvising_RecommendedCoursesDAL : AcademicAdvising_RecommendedCourses
{
#region "Decleration"
private string m_TableName;
private string m_AcademicAdvisingIDFN ;
private string m_StudentIDFN ;
private string m_AcademicYearFN ;
private string m_SemesterFN ;
private string m_CourseIDFN ;
private string m_SessionIDFN ;
private string m_ClassIDFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string AcademicAdvisingIDFN 
{
get { return  m_AcademicAdvisingIDFN; }
set {m_AcademicAdvisingIDFN  = value ; }
}
public string StudentIDFN 
{
get { return  m_StudentIDFN; }
set {m_StudentIDFN  = value ; }
}
public string AcademicYearFN 
{
get { return  m_AcademicYearFN; }
set {m_AcademicYearFN  = value ; }
}
public string SemesterFN 
{
get { return  m_SemesterFN; }
set {m_SemesterFN  = value ; }
}
public string CourseIDFN 
{
get { return  m_CourseIDFN; }
set {m_CourseIDFN  = value ; }
}
public string SessionIDFN 
{
get { return  m_SessionIDFN; }
set {m_SessionIDFN  = value ; }
}
public string ClassIDFN 
{
get { return  m_ClassIDFN; }
set {m_ClassIDFN  = value ; }
}
public string CreationUserIDFN 
{
get { return  m_CreationUserIDFN; }
set {m_CreationUserIDFN  = value ; }
}
public string CreationDateFN 
{
get { return  m_CreationDateFN; }
set {m_CreationDateFN  = value ; }
}
public string LastUpdateUserIDFN 
{
get { return  m_LastUpdateUserIDFN; }
set {m_LastUpdateUserIDFN  = value ; }
}
public string LastUpdateDateFN 
{
get { return  m_LastUpdateDateFN; }
set {m_LastUpdateDateFN  = value ; }
}
public string PCNameFN 
{
get { return  m_PCNameFN; }
set {m_PCNameFN  = value ; }
}
public string NetUserNameFN 
{
get { return  m_NetUserNameFN; }
set {m_NetUserNameFN  = value ; }
}
#endregion
//================End Properties ===================
public AcademicAdvising_RecommendedCoursesDAL()
{
try
{
this.TableName = "Reg_AcademicAdvising_RecommendedCourses";
this.AcademicAdvisingIDFN = m_TableName + ".AcademicAdvisingID";
this.StudentIDFN = m_TableName + ".StudentID";
this.AcademicYearFN = m_TableName + ".AcademicYear";
this.SemesterFN = m_TableName + ".Semester";
this.CourseIDFN = m_TableName + ".CourseID";
this.SessionIDFN = m_TableName + ".SessionID";
this.ClassIDFN = m_TableName + ".ClassID";
this.CreationUserIDFN = m_TableName + ".CreationUserID";
this.CreationDateFN = m_TableName + ".CreationDate";
this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
this.PCNameFN = m_TableName + ".PCName";
this.NetUserNameFN = m_TableName + ".NetUserName";
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
sSQL +=AcademicAdvisingIDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + SessionIDFN;
sSQL += " , " + ClassIDFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
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
sSQL +=AcademicAdvisingIDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += "  FROM " + m_TableName;
sSQL += " WHERE 1=1";
if (sCondition != "")
{
    sSQL += sCondition;
}
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
sSQL +=AcademicAdvisingIDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + SessionIDFN;
sSQL += " , " + ClassIDFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
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
sSQL += LibraryMOD.GetFieldName(AcademicAdvisingIDFN) + "=@AcademicAdvisingID";
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN) + "=@StudentID";
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN) + "=@CourseID";
sSQL += " , " + LibraryMOD.GetFieldName(SessionIDFN) + "=@SessionID";
sSQL += " , " + LibraryMOD.GetFieldName(ClassIDFN) + "=@ClassID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(AcademicAdvisingIDFN)+"=@AcademicAdvisingID";
sSQL +=  " And " + LibraryMOD.GetFieldName(StudentIDFN)+"=@StudentID";
sSQL +=  " And " + LibraryMOD.GetFieldName(AcademicYearFN)+"=@AcademicYear";
sSQL +=  " And " + LibraryMOD.GetFieldName(SemesterFN)+"=@Semester";
sSQL +=  " And " + LibraryMOD.GetFieldName(CourseIDFN)+"=@CourseID";
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
sSQL +=LibraryMOD.GetFieldName(AcademicAdvisingIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SessionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ClassIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @AcademicAdvisingID";
sSQL += " ,@StudentID";
sSQL += " ,@AcademicYear";
sSQL += " ,@Semester";
sSQL += " ,@CourseID";
sSQL += " ,@SessionID";
sSQL += " ,@ClassID";
sSQL += " ,@CreationUserID";
sSQL += " ,@CreationDate";
sSQL += " ,@LastUpdateUserID";
sSQL += " ,@LastUpdateDate";
sSQL += " ,@PCName";
sSQL += " ,@NetUserName";
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
sSQL += LibraryMOD.GetFieldName(AcademicAdvisingIDFN)+"=@AcademicAdvisingID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(StudentIDFN)+"=@StudentID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(AcademicYearFN)+"=@AcademicYear";
sSQL +=  " And " +  LibraryMOD.GetFieldName(SemesterFN)+"=@Semester";
sSQL +=  " And " +  LibraryMOD.GetFieldName(CourseIDFN)+"=@CourseID";
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
public List< AcademicAdvising_RecommendedCourses> GetAcademicAdvising_RecommendedCourses(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the AcademicAdvising_RecommendedCourses
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
List<AcademicAdvising_RecommendedCourses> results = new List<AcademicAdvising_RecommendedCourses>();
try
{
//Default Value
AcademicAdvising_RecommendedCourses myAcademicAdvising_RecommendedCourses = new AcademicAdvising_RecommendedCourses();
if (isDeafaultIncluded)
{
//Change the code here
myAcademicAdvising_RecommendedCourses.AcademicAdvisingID = 0;
myAcademicAdvising_RecommendedCourses.CourseID = "";
results.Add(myAcademicAdvising_RecommendedCourses);
}
while (reader.Read())
{
myAcademicAdvising_RecommendedCourses = new AcademicAdvising_RecommendedCourses();
if (reader[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.AcademicAdvisingID = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.AcademicAdvisingID = int.Parse(reader[LibraryMOD.GetFieldName( AcademicAdvisingIDFN) ].ToString());
}
myAcademicAdvising_RecommendedCourses.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.AcademicYear = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.Semester = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
}
myAcademicAdvising_RecommendedCourses.CourseID =reader[LibraryMOD.GetFieldName( CourseIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(SessionIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.SessionID = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.SessionID = int.Parse(reader[LibraryMOD.GetFieldName( SessionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ClassIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.ClassID = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.ClassID = int.Parse(reader[LibraryMOD.GetFieldName( ClassIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.CreationUserID = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.LastUpdateUserID = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myAcademicAdvising_RecommendedCourses.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myAcademicAdvising_RecommendedCourses.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myAcademicAdvising_RecommendedCourses);
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
public List< AcademicAdvising_RecommendedCourses > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<AcademicAdvising_RecommendedCourses> results = new List<AcademicAdvising_RecommendedCourses>();
try
{
//Default Value
AcademicAdvising_RecommendedCourses myAcademicAdvising_RecommendedCourses= new AcademicAdvising_RecommendedCourses();
if (isDeafaultIncluded)
 {
//Change the code here
 myAcademicAdvising_RecommendedCourses.AcademicAdvisingID = -1;
 myAcademicAdvising_RecommendedCourses.StudentID = "Select AcademicAdvising_RecommendedCourses" ;
results.Add(myAcademicAdvising_RecommendedCourses);
 }
while (reader.Read())
{
myAcademicAdvising_RecommendedCourses = new AcademicAdvising_RecommendedCourses();
if (reader[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.AcademicAdvisingID = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.AcademicAdvisingID = int.Parse(reader[LibraryMOD.GetFieldName( AcademicAdvisingIDFN) ].ToString());
}
myAcademicAdvising_RecommendedCourses.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myAcademicAdvising_RecommendedCourses.AcademicYear = 0;
}
else
{
myAcademicAdvising_RecommendedCourses.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
 results.Add(myAcademicAdvising_RecommendedCourses);
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
public int UpdateAcademicAdvising_RecommendedCourses(InitializeModule.EnumCampus Campus, int iMode,int AcademicAdvisingID,string StudentID,int AcademicYear,int Semester,string CourseID,int SessionID,int ClassID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
AcademicAdvising_RecommendedCourses theAcademicAdvising_RecommendedCourses = new AcademicAdvising_RecommendedCourses();
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
Cmd.Parameters.Add(new SqlParameter("@AcademicAdvisingID",AcademicAdvisingID));
Cmd.Parameters.Add(new SqlParameter("@StudentID",StudentID));
Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
Cmd.Parameters.Add(new SqlParameter("@CourseID",CourseID));
Cmd.Parameters.Add(new SqlParameter("@SessionID",SessionID));
Cmd.Parameters.Add(new SqlParameter("@ClassID",ClassID));
Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
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
public int DeleteAcademicAdvising_RecommendedCourses(InitializeModule.EnumCampus Campus,string AcademicAdvisingID,string StudentID,string AcademicYear,string Semester,string CourseID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@AcademicAdvisingID", AcademicAdvisingID ));
Cmd.Parameters.Add(new SqlParameter("@StudentID", StudentID ));
Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear ));
Cmd.Parameters.Add(new SqlParameter("@Semester", Semester ));
Cmd.Parameters.Add(new SqlParameter("@CourseID", CourseID ));
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
DataTable dt = new DataTable("AcademicAdvising_RecommendedCourses");
DataView dv = new DataView();
List<AcademicAdvising_RecommendedCourses> myAcademicAdvising_RecommendedCoursess = new List<AcademicAdvising_RecommendedCourses>();
try
{
myAcademicAdvising_RecommendedCoursess = GetAcademicAdvising_RecommendedCourses(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("AcademicAdvisingID", Type.GetType("int"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("StudentID", Type.GetType("nvarchar"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("AcademicYear", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3 = new DataColumn("CourseID", Type.GetType("nvarchar"));
dt.Columns.Add(col3);

dt.Constraints.Add(new UniqueConstraint(col0));
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));


DataRow dr;
for (int i = 0; i < myAcademicAdvising_RecommendedCoursess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myAcademicAdvising_RecommendedCoursess[i].AcademicAdvisingID;
  dr[2] = myAcademicAdvising_RecommendedCoursess[i].StudentID;
  dr[3] = myAcademicAdvising_RecommendedCoursess[i].AcademicYear;
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
myAcademicAdvising_RecommendedCoursess.Clear();
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
sSQL += AcademicAdvisingIDFN;
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
public class AcademicAdvising_RecommendedCoursesCls : AcademicAdvising_RecommendedCoursesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daAcademicAdvising_RecommendedCourses;
private DataSet m_dsAcademicAdvising_RecommendedCourses;
public DataRow AcademicAdvising_RecommendedCoursesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsAcademicAdvising_RecommendedCourses
{
get { return m_dsAcademicAdvising_RecommendedCourses ; }
set { m_dsAcademicAdvising_RecommendedCourses = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public AcademicAdvising_RecommendedCoursesCls()
{
try
{
dsAcademicAdvising_RecommendedCourses= new DataSet();

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
public virtual SqlDataAdapter GetAcademicAdvising_RecommendedCoursesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daAcademicAdvising_RecommendedCourses = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daAcademicAdvising_RecommendedCourses);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daAcademicAdvising_RecommendedCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAcademicAdvising_RecommendedCourses;
}
public virtual SqlDataAdapter GetAcademicAdvising_RecommendedCoursesDataAdapter(SqlConnection con)  
{
try
{
daAcademicAdvising_RecommendedCourses = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daAcademicAdvising_RecommendedCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdAcademicAdvising_RecommendedCourses;
cmdAcademicAdvising_RecommendedCourses = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int, 4, "AcademicAdvisingID" );
//'cmdRolePermission.Parameters.Add("@StudentID", SqlDbType.Int, 4, "StudentID" );
//'cmdRolePermission.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, "AcademicYear" );
//'cmdRolePermission.Parameters.Add("@Semester", SqlDbType.Int, 4, "Semester" );
//'cmdRolePermission.Parameters.Add("@CourseID", SqlDbType.Int, 4, "CourseID" );
daAcademicAdvising_RecommendedCourses.SelectCommand = cmdAcademicAdvising_RecommendedCourses;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdAcademicAdvising_RecommendedCourses = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@ClassID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ClassIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@StudentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StudentIDFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CourseID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CourseIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daAcademicAdvising_RecommendedCourses.UpdateCommand = cmdAcademicAdvising_RecommendedCourses;
daAcademicAdvising_RecommendedCourses.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdAcademicAdvising_RecommendedCourses = new SqlCommand(GetInsertCommand(), con);
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@ClassID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ClassIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daAcademicAdvising_RecommendedCourses.InsertCommand =cmdAcademicAdvising_RecommendedCourses;
daAcademicAdvising_RecommendedCourses.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdAcademicAdvising_RecommendedCourses = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@StudentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StudentIDFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
Parmeter = cmdAcademicAdvising_RecommendedCourses.Parameters.Add("@CourseID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CourseIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daAcademicAdvising_RecommendedCourses.DeleteCommand =cmdAcademicAdvising_RecommendedCourses;
daAcademicAdvising_RecommendedCourses.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daAcademicAdvising_RecommendedCourses.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAcademicAdvising_RecommendedCourses;
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
dr = dsAcademicAdvising_RecommendedCourses.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)]=AcademicAdvisingID;
dr[LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
dr[LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
dr[LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
dr[LibraryMOD.GetFieldName(ClassIDFN)]=ClassID;
dsAcademicAdvising_RecommendedCourses.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsAcademicAdvising_RecommendedCourses.Tables[TableName].Select(LibraryMOD.GetFieldName(AcademicAdvisingIDFN)  + "=" + AcademicAdvisingID  + " AND " + LibraryMOD.GetFieldName(StudentIDFN) + "=" + StudentID  + " AND " + LibraryMOD.GetFieldName(AcademicYearFN) + "=" + AcademicYear  + " AND " + LibraryMOD.GetFieldName(SemesterFN) + "=" + Semester  + " AND " + LibraryMOD.GetFieldName(CourseIDFN) + "=" + CourseID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(AcademicAdvisingIDFN)]=AcademicAdvisingID;
drAry[0][LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
drAry[0][LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
drAry[0][LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
drAry[0][LibraryMOD.GetFieldName(ClassIDFN)]=ClassID;
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
public int CommitAcademicAdvising_RecommendedCourses()  
{
//CommitAcademicAdvising_RecommendedCourses= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daAcademicAdvising_RecommendedCourses.Update(dsAcademicAdvising_RecommendedCourses, TableName);
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
FindInMultiPKey(AcademicAdvisingID,StudentID,AcademicYear,Semester,CourseID);
if (( AcademicAdvising_RecommendedCoursesDataRow != null)) 
{
AcademicAdvising_RecommendedCoursesDataRow.Delete();
CommitAcademicAdvising_RecommendedCourses();
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
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)]== System.DBNull.Value)
{
  AcademicAdvisingID=0;
}
else
{
  AcademicAdvisingID = (int)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(StudentIDFN)]== System.DBNull.Value)
{
  StudentID="";
}
else
{
  StudentID = (string)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(StudentIDFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
{
  AcademicYear=0;
}
else
{
  AcademicYear = (int)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
{
  Semester=0;
}
else
{
  Semester = (int)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(SemesterFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(CourseIDFN)]== System.DBNull.Value)
{
  CourseID="";
}
else
{
  CourseID = (string)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(CourseIDFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(SessionIDFN)]== System.DBNull.Value)
{
  SessionID=0;
}
else
{
  SessionID = (int)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(SessionIDFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(ClassIDFN)]== System.DBNull.Value)
{
  ClassID=0;
}
else
{
  ClassID = (int)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(ClassIDFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)AcademicAdvising_RecommendedCoursesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKAcademicAdvisingID,string PKStudentID,int PKAcademicYear,int PKSemester,string PKCourseID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKAcademicAdvisingID;
findTheseVals[1] = PKStudentID;
findTheseVals[2] = PKAcademicYear;
findTheseVals[3] = PKSemester;
findTheseVals[4] = PKCourseID;
AcademicAdvising_RecommendedCoursesDataRow = dsAcademicAdvising_RecommendedCourses.Tables[TableName].Rows.Find(findTheseVals);
if  ((AcademicAdvising_RecommendedCoursesDataRow !=null)) 
{
lngCurRow = dsAcademicAdvising_RecommendedCourses.Tables[TableName].Rows.IndexOf(AcademicAdvising_RecommendedCoursesDataRow);
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
  lngCurRow = dsAcademicAdvising_RecommendedCourses.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsAcademicAdvising_RecommendedCourses.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsAcademicAdvising_RecommendedCourses.Tables[TableName].Rows.Count > 0) 
{
  AcademicAdvising_RecommendedCoursesDataRow = dsAcademicAdvising_RecommendedCourses.Tables[TableName].Rows[lngCurRow];
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
daAcademicAdvising_RecommendedCourses.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAcademicAdvising_RecommendedCourses.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daAcademicAdvising_RecommendedCourses.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAcademicAdvising_RecommendedCourses.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
