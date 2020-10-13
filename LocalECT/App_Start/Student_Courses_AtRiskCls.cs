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
public class Student_Courses_AtRisk
{
//Creation Date: 09/03/2017 3:28:07 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_ID; 
private string m_StudentID; 
private int m_AcademicYear; 
private int m_Semester; 
private string m_CourseID; 
private int m_SessionID; 
private int m_ClassID; 
private string m_IsAllowedToGetExtraActivity; 
private double m_CGPA; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int ID
{
get { return  m_ID; }
set {m_ID  = value ; }
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
public string IsAllowedToGetExtraActivity
{
get { return  m_IsAllowedToGetExtraActivity; }
set {m_IsAllowedToGetExtraActivity  = value ; }
}
public double CGPA
{
get { return  m_CGPA; }
set {m_CGPA  = value ; }
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
public Student_Courses_AtRisk()
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
public class Student_Courses_AtRiskDAL : Student_Courses_AtRisk
{
#region "Decleration"
private string m_TableName;
private string m_IDFN ;
private string m_StudentIDFN ;
private string m_AcademicYearFN ;
private string m_SemesterFN ;
private string m_CourseIDFN ;
private string m_SessionIDFN ;
private string m_ClassIDFN ;
private string m_IsAllowedToGetExtraActivityFN ;
private string m_CGPAFN ;
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
public string IDFN 
{
get { return  m_IDFN; }
set {m_IDFN  = value ; }
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
public string IsAllowedToGetExtraActivityFN 
{
get { return  m_IsAllowedToGetExtraActivityFN; }
set {m_IsAllowedToGetExtraActivityFN  = value ; }
}
public string CGPAFN 
{
get { return  m_CGPAFN; }
set {m_CGPAFN  = value ; }
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
public Student_Courses_AtRiskDAL()
{
try
{
this.TableName = "Reg_Student_Courses_AtRisk";
this.IDFN = m_TableName + ".ID";
this.StudentIDFN = m_TableName + ".StudentID";
this.AcademicYearFN = m_TableName + ".AcademicYear";
this.SemesterFN = m_TableName + ".Semester";
this.CourseIDFN = m_TableName + ".CourseID";
this.SessionIDFN = m_TableName + ".SessionID";
this.ClassIDFN = m_TableName + ".ClassID";
this.IsAllowedToGetExtraActivityFN = m_TableName + ".IsAllowedToGetExtraActivity";
this.CGPAFN = m_TableName + ".CGPA";
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
sSQL +=IDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + SessionIDFN;
sSQL += " , " + ClassIDFN;
sSQL += " , " + IsAllowedToGetExtraActivityFN;
sSQL += " , " + CGPAFN;
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
sSQL +=IDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
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
sSQL +=IDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + SessionIDFN;
sSQL += " , " + ClassIDFN;
sSQL += " , " + IsAllowedToGetExtraActivityFN;
sSQL += " , " + CGPAFN;
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
sSQL += LibraryMOD.GetFieldName(IDFN) + "=@ID";
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN) + "=@StudentID";
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN) + "=@CourseID";
sSQL += " , " + LibraryMOD.GetFieldName(SessionIDFN) + "=@SessionID";
sSQL += " , " + LibraryMOD.GetFieldName(ClassIDFN) + "=@ClassID";
sSQL += " , " + LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN) + "=@IsAllowedToGetExtraActivity";
sSQL += " , " + LibraryMOD.GetFieldName(CGPAFN) + "=@CGPA";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(IDFN)+"=@ID";
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
sSQL +=LibraryMOD.GetFieldName(IDFN);
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SessionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ClassIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN);
sSQL += " , " + LibraryMOD.GetFieldName(CGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @ID";
sSQL += " ,@StudentID";
sSQL += " ,@AcademicYear";
sSQL += " ,@Semester";
sSQL += " ,@CourseID";
sSQL += " ,@SessionID";
sSQL += " ,@ClassID";
sSQL += " ,@IsAllowedToGetExtraActivity";
sSQL += " ,@CGPA";
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
sSQL += LibraryMOD.GetFieldName(IDFN)+"=@ID";
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
public List< Student_Courses_AtRisk> GetStudent_Courses_AtRisk(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Student_Courses_AtRisk
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
List<Student_Courses_AtRisk> results = new List<Student_Courses_AtRisk>();
try
{
//Default Value
Student_Courses_AtRisk myStudent_Courses_AtRisk = new Student_Courses_AtRisk();
if (isDeafaultIncluded)
{
//Change the code here
myStudent_Courses_AtRisk.ID = 0;
//myStudent_Courses_AtRisk.ID = "Select Student_Courses_AtRisk ...";
results.Add(myStudent_Courses_AtRisk);
}
while (reader.Read())
{
myStudent_Courses_AtRisk = new Student_Courses_AtRisk();
if (reader[LibraryMOD.GetFieldName(IDFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.ID = 0;
}
else
{
myStudent_Courses_AtRisk.ID = int.Parse(reader[LibraryMOD.GetFieldName( IDFN) ].ToString());
}
myStudent_Courses_AtRisk.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.AcademicYear = 0;
}
else
{
myStudent_Courses_AtRisk.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.Semester = 0;
}
else
{
myStudent_Courses_AtRisk.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
}
myStudent_Courses_AtRisk.CourseID =reader[LibraryMOD.GetFieldName( CourseIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(SessionIDFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.SessionID = 0;
}
else
{
myStudent_Courses_AtRisk.SessionID = int.Parse(reader[LibraryMOD.GetFieldName( SessionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ClassIDFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.ClassID = 0;
}
else
{
myStudent_Courses_AtRisk.ClassID = int.Parse(reader[LibraryMOD.GetFieldName( ClassIDFN) ].ToString());
}
myStudent_Courses_AtRisk.IsAllowedToGetExtraActivity =reader[LibraryMOD.GetFieldName( IsAllowedToGetExtraActivityFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.CreationUserID = 0;
}
else
{
myStudent_Courses_AtRisk.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.LastUpdateUserID = 0;
}
else
{
myStudent_Courses_AtRisk.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myStudent_Courses_AtRisk.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myStudent_Courses_AtRisk.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myStudent_Courses_AtRisk);
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
public List< Student_Courses_AtRisk > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Student_Courses_AtRisk> results = new List<Student_Courses_AtRisk>();
try
{
//Default Value
Student_Courses_AtRisk myStudent_Courses_AtRisk= new Student_Courses_AtRisk();
if (isDeafaultIncluded)
 {
//Change the code here
 myStudent_Courses_AtRisk.ID = -1;
 myStudent_Courses_AtRisk.StudentID = "Select Student_Courses_AtRisk" ;
results.Add(myStudent_Courses_AtRisk);
 }
while (reader.Read())
{
myStudent_Courses_AtRisk = new Student_Courses_AtRisk();
if (reader[LibraryMOD.GetFieldName(IDFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.ID = 0;
}
else
{
myStudent_Courses_AtRisk.ID = int.Parse(reader[LibraryMOD.GetFieldName( IDFN) ].ToString());
}
myStudent_Courses_AtRisk.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myStudent_Courses_AtRisk.AcademicYear = 0;
}
else
{
myStudent_Courses_AtRisk.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
 results.Add(myStudent_Courses_AtRisk);
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
public int UpdateStudent_Courses_AtRisk(InitializeModule.EnumCampus Campus, int iMode,int ID,string StudentID,int AcademicYear,int Semester,string CourseID,int SessionID,int ClassID,int IsAllowedToGetExtraActivity,decimal CGPA,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Student_Courses_AtRisk theStudent_Courses_AtRisk = new Student_Courses_AtRisk();
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
Cmd.Parameters.Add(new SqlParameter("@ID",ID));
Cmd.Parameters.Add(new SqlParameter("@StudentID",StudentID));
Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
Cmd.Parameters.Add(new SqlParameter("@CourseID",CourseID));
Cmd.Parameters.Add(new SqlParameter("@SessionID",SessionID));
Cmd.Parameters.Add(new SqlParameter("@ClassID",ClassID));
Cmd.Parameters.Add(new SqlParameter("@IsAllowedToGetExtraActivity",IsAllowedToGetExtraActivity));
Cmd.Parameters.Add(new SqlParameter("@CGPA",CGPA));
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
public int DeleteStudent_Courses_AtRisk(InitializeModule.EnumCampus Campus,string ID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@ID", ID ));
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
DataTable dt = new DataTable("Student_Courses_AtRisk");
DataView dv = new DataView();
List<Student_Courses_AtRisk> myStudent_Courses_AtRisks = new List<Student_Courses_AtRisk>();
try
{
myStudent_Courses_AtRisks = GetStudent_Courses_AtRisk(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("ID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myStudent_Courses_AtRisks.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myStudent_Courses_AtRisks[i].ID;
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
myStudent_Courses_AtRisks.Clear();
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
sSQL += IDFN;
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
public class Student_Courses_AtRiskCls : Student_Courses_AtRiskDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daStudent_Courses_AtRisk;
private DataSet m_dsStudent_Courses_AtRisk;
public DataRow Student_Courses_AtRiskDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsStudent_Courses_AtRisk
{
get { return m_dsStudent_Courses_AtRisk ; }
set { m_dsStudent_Courses_AtRisk = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Student_Courses_AtRiskCls()
{
try
{
dsStudent_Courses_AtRisk= new DataSet();

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
public virtual SqlDataAdapter GetStudent_Courses_AtRiskDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daStudent_Courses_AtRisk = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudent_Courses_AtRisk);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_Courses_AtRisk.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_Courses_AtRisk;
}
public virtual SqlDataAdapter GetStudent_Courses_AtRiskDataAdapter(SqlConnection con)  
{
try
{
daStudent_Courses_AtRisk = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_Courses_AtRisk.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdStudent_Courses_AtRisk;
cmdStudent_Courses_AtRisk = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@ID", SqlDbType.Int, 4, "ID" );
daStudent_Courses_AtRisk.SelectCommand = cmdStudent_Courses_AtRisk;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdStudent_Courses_AtRisk = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdStudent_Courses_AtRisk.Parameters.Add("@ID", SqlDbType.Int,4, LibraryMOD.GetFieldName(IDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@ClassID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ClassIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@IsAllowedToGetExtraActivity", SqlDbType.Bit,1, LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CGPA", SqlDbType.Decimal,7, LibraryMOD.GetFieldName(CGPAFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdStudent_Courses_AtRisk.Parameters.Add("@ID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daStudent_Courses_AtRisk.UpdateCommand = cmdStudent_Courses_AtRisk;
daStudent_Courses_AtRisk.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdStudent_Courses_AtRisk = new SqlCommand(GetInsertCommand(), con);
cmdStudent_Courses_AtRisk.Parameters.Add("@ID", SqlDbType.Int,4, LibraryMOD.GetFieldName(IDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@ClassID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ClassIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@IsAllowedToGetExtraActivity", SqlDbType.Bit,1, LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CGPA", SqlDbType.Decimal,7, LibraryMOD.GetFieldName(CGPAFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdStudent_Courses_AtRisk.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daStudent_Courses_AtRisk.InsertCommand =cmdStudent_Courses_AtRisk;
daStudent_Courses_AtRisk.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdStudent_Courses_AtRisk = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdStudent_Courses_AtRisk.Parameters.Add("@ID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daStudent_Courses_AtRisk.DeleteCommand =cmdStudent_Courses_AtRisk;
daStudent_Courses_AtRisk.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daStudent_Courses_AtRisk.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_Courses_AtRisk;
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
dr = dsStudent_Courses_AtRisk.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(IDFN)]=ID;
dr[LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
dr[LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
dr[LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
dr[LibraryMOD.GetFieldName(ClassIDFN)]=ClassID;
dr[LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN)]=IsAllowedToGetExtraActivity;
dr[LibraryMOD.GetFieldName(CGPAFN)]=CGPA;
dsStudent_Courses_AtRisk.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsStudent_Courses_AtRisk.Tables[TableName].Select(LibraryMOD.GetFieldName(IDFN)  + "=" + ID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(IDFN)]=ID;
drAry[0][LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
drAry[0][LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
drAry[0][LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
drAry[0][LibraryMOD.GetFieldName(ClassIDFN)]=ClassID;
drAry[0][LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN)]=IsAllowedToGetExtraActivity;
drAry[0][LibraryMOD.GetFieldName(CGPAFN)]=CGPA;
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
public int CommitStudent_Courses_AtRisk()  
{
//CommitStudent_Courses_AtRisk= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daStudent_Courses_AtRisk.Update(dsStudent_Courses_AtRisk, TableName);
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
FindInMultiPKey(ID);
if (( Student_Courses_AtRiskDataRow != null)) 
{
Student_Courses_AtRiskDataRow.Delete();
CommitStudent_Courses_AtRisk();
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
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(IDFN)]== System.DBNull.Value)
{
  ID=0;
}
else
{
  ID = (int)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(IDFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(StudentIDFN)]== System.DBNull.Value)
{
  StudentID="";
}
else
{
  StudentID = (string)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(StudentIDFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
{
  AcademicYear=0;
}
else
{
  AcademicYear = (int)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
{
  Semester=0;
}
else
{
  Semester = (int)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(SemesterFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(CourseIDFN)]== System.DBNull.Value)
{
  CourseID="";
}
else
{
  CourseID = (string)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(CourseIDFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(SessionIDFN)]== System.DBNull.Value)
{
  SessionID=0;
}
else
{
  SessionID = (int)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(SessionIDFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(ClassIDFN)]== System.DBNull.Value)
{
  ClassID=0;
}
else
{
  ClassID = (int)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(ClassIDFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN)]== System.DBNull.Value)
{
  IsAllowedToGetExtraActivity="";
}
else
{
  IsAllowedToGetExtraActivity = (string)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(IsAllowedToGetExtraActivityFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(CGPAFN)]== System.DBNull.Value)
{
}
else
{
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)Student_Courses_AtRiskDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKID;
Student_Courses_AtRiskDataRow = dsStudent_Courses_AtRisk.Tables[TableName].Rows.Find(findTheseVals);
if  ((Student_Courses_AtRiskDataRow !=null)) 
{
lngCurRow = dsStudent_Courses_AtRisk.Tables[TableName].Rows.IndexOf(Student_Courses_AtRiskDataRow);
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
  lngCurRow = dsStudent_Courses_AtRisk.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsStudent_Courses_AtRisk.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsStudent_Courses_AtRisk.Tables[TableName].Rows.Count > 0) 
{
  Student_Courses_AtRiskDataRow = dsStudent_Courses_AtRisk.Tables[TableName].Rows[lngCurRow];
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
daStudent_Courses_AtRisk.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_Courses_AtRisk.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daStudent_Courses_AtRisk.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_Courses_AtRisk.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
