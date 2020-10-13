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
public class Student_AtRisk_H
{
//Creation Date: 27/03/2016 5:42:02 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_AtRiskTransactionID; 
private string m_StudentID; 
private int m_AcademicYear; 
private int m_Semester; 
private string m_CourseID; 
private int m_SessionID; 
private int m_ClassID; 
private double m_CGPA; 
private string m_sRemarks; 
private string m_sRecommendation; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int AtRiskTransactionID
{
get { return  m_AtRiskTransactionID; }
set {m_AtRiskTransactionID  = value ; }
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
public double CGPA
{
get { return  m_CGPA; }
set {m_CGPA  = value ; }
}
public string sRemarks
{
get { return  m_sRemarks; }
set {m_sRemarks  = value ; }
}
public string sRecommendation
{
get { return  m_sRecommendation; }
set {m_sRecommendation  = value ; }
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
public Student_AtRisk_H()
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
public class Student_AtRisk_HDAL : Student_AtRisk_H
{
#region "Decleration"
private string m_TableName;
private string m_AtRiskTransactionIDFN ;
private string m_StudentIDFN ;
private string m_AcademicYearFN ;
private string m_SemesterFN ;
private string m_CourseIDFN ;
private string m_SessionIDFN ;
private string m_ClassIDFN ;
private string m_CGPAFN ;
private string m_sRemarksFN ;
private string m_sRecommendationFN ;
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
public string AtRiskTransactionIDFN 
{
get { return  m_AtRiskTransactionIDFN; }
set {m_AtRiskTransactionIDFN  = value ; }
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
public string CGPAFN 
{
get { return  m_CGPAFN; }
set {m_CGPAFN  = value ; }
}
public string sRemarksFN 
{
get { return  m_sRemarksFN; }
set {m_sRemarksFN  = value ; }
}
public string sRecommendationFN 
{
get { return  m_sRecommendationFN; }
set {m_sRecommendationFN  = value ; }
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
public Student_AtRisk_HDAL()
{
try
{
this.TableName = "Reg_Student_AtRisk_H";
this.AtRiskTransactionIDFN = m_TableName + ".AtRiskTransactionID";
this.StudentIDFN = m_TableName + ".StudentID";
this.AcademicYearFN = m_TableName + ".AcademicYear";
this.SemesterFN = m_TableName + ".Semester";
this.CourseIDFN = m_TableName + ".CourseID";
this.SessionIDFN = m_TableName + ".SessionID";
this.ClassIDFN = m_TableName + ".ClassID";
this.CGPAFN = m_TableName + ".CGPA";
this.sRemarksFN = m_TableName + ".sRemarks";
this.sRecommendationFN = m_TableName + ".sRecommendation";
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
sSQL +=AtRiskTransactionIDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + SessionIDFN;
sSQL += " , " + ClassIDFN;
sSQL += " , " + CGPAFN;
sSQL += " , " + sRemarksFN;
sSQL += " , " + sRecommendationFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE 1=1";
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
public string  GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
    sSQL = "SELECT ";
    sSQL +=AtRiskTransactionIDFN;
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
sSQL +=AtRiskTransactionIDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + SessionIDFN;
sSQL += " , " + ClassIDFN;
sSQL += " , " + CGPAFN;
sSQL += " , " + sRemarksFN;
sSQL += " , " + sRecommendationFN;
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
sSQL += LibraryMOD.GetFieldName(AtRiskTransactionIDFN) + "=@AtRiskTransactionID";
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN) + "=@StudentID";
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN) + "=@CourseID";
sSQL += " , " + LibraryMOD.GetFieldName(SessionIDFN) + "=@SessionID";
sSQL += " , " + LibraryMOD.GetFieldName(ClassIDFN) + "=@ClassID";
sSQL += " , " + LibraryMOD.GetFieldName(CGPAFN) + "=@CGPA";
sSQL += " , " + LibraryMOD.GetFieldName(sRemarksFN) + "=@sRemarks";
sSQL += " , " + LibraryMOD.GetFieldName(sRecommendationFN) + "=@sRecommendation";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(AtRiskTransactionIDFN)+"=@AtRiskTransactionID";
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
sSQL +=LibraryMOD.GetFieldName(AtRiskTransactionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SessionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ClassIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(sRemarksFN);
sSQL += " , " + LibraryMOD.GetFieldName(sRecommendationFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @AtRiskTransactionID";
sSQL += " ,@StudentID";
sSQL += " ,@AcademicYear";
sSQL += " ,@Semester";
sSQL += " ,@CourseID";
sSQL += " ,@SessionID";
sSQL += " ,@ClassID";
sSQL += " ,@CGPA";
sSQL += " ,@sRemarks";
sSQL += " ,@sRecommendation";
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
sSQL += LibraryMOD.GetFieldName(AtRiskTransactionIDFN)+"=@AtRiskTransactionID";
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
public List< Student_AtRisk_H> GetStudent_AtRisk_H(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Student_AtRisk_H
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
List<Student_AtRisk_H> results = new List<Student_AtRisk_H>();
try
{
//Default Value
Student_AtRisk_H myStudent_AtRisk_H = new Student_AtRisk_H();
if (isDeafaultIncluded)
{
//Change the code here
myStudent_AtRisk_H.AtRiskTransactionID = 0;
//myStudent_AtRisk_H.AtRiskTransactionID = "Select Student_AtRisk_H ...";
results.Add(myStudent_AtRisk_H);
}
while (reader.Read())
{
myStudent_AtRisk_H = new Student_AtRisk_H();
if (reader[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.AtRiskTransactionID = 0;
}
else
{
myStudent_AtRisk_H.AtRiskTransactionID = int.Parse(reader[LibraryMOD.GetFieldName( AtRiskTransactionIDFN) ].ToString());
}
myStudent_AtRisk_H.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.AcademicYear = 0;
}
else
{
myStudent_AtRisk_H.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.Semester = 0;
}
else
{
myStudent_AtRisk_H.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
}
myStudent_AtRisk_H.CourseID =reader[LibraryMOD.GetFieldName( CourseIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(SessionIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.SessionID = 0;
}
else
{
myStudent_AtRisk_H.SessionID = int.Parse(reader[LibraryMOD.GetFieldName( SessionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ClassIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.ClassID = 0;
}
else
{
myStudent_AtRisk_H.ClassID = int.Parse(reader[LibraryMOD.GetFieldName( ClassIDFN) ].ToString());
}
myStudent_AtRisk_H.sRemarks =reader[LibraryMOD.GetFieldName( sRemarksFN) ].ToString();
myStudent_AtRisk_H.sRecommendation =reader[LibraryMOD.GetFieldName( sRecommendationFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.CreationUserID = 0;
}
else
{
myStudent_AtRisk_H.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.LastUpdateUserID = 0;
}
else
{
myStudent_AtRisk_H.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myStudent_AtRisk_H.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myStudent_AtRisk_H.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myStudent_AtRisk_H);
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
public List< Student_AtRisk_H > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Student_AtRisk_H> results = new List<Student_AtRisk_H>();
try
{
//Default Value
Student_AtRisk_H myStudent_AtRisk_H= new Student_AtRisk_H();
if (isDeafaultIncluded)
 {
//Change the code here
 myStudent_AtRisk_H.AtRiskTransactionID = -1;
 myStudent_AtRisk_H.StudentID = "Select Student_AtRisk_H" ;
results.Add(myStudent_AtRisk_H);
 }
while (reader.Read())
{
myStudent_AtRisk_H = new Student_AtRisk_H();
if (reader[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.AtRiskTransactionID = 0;
}
else
{
myStudent_AtRisk_H.AtRiskTransactionID = int.Parse(reader[LibraryMOD.GetFieldName( AtRiskTransactionIDFN) ].ToString());
}
myStudent_AtRisk_H.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_H.AcademicYear = 0;
}
else
{
myStudent_AtRisk_H.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
 results.Add(myStudent_AtRisk_H);
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
public int UpdateStudent_AtRisk_H(InitializeModule.EnumCampus Campus, int iMode,int AtRiskTransactionID,string StudentID,int AcademicYear,int Semester,string CourseID,int SessionID,int ClassID,double CGPA,string sRemarks,string sRecommendation,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Student_AtRisk_H theStudent_AtRisk_H = new Student_AtRisk_H();
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
Cmd.Parameters.Add(new SqlParameter("@AtRiskTransactionID",AtRiskTransactionID));
Cmd.Parameters.Add(new SqlParameter("@StudentID",StudentID));
Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
Cmd.Parameters.Add(new SqlParameter("@CourseID",CourseID));
Cmd.Parameters.Add(new SqlParameter("@SessionID",SessionID));
Cmd.Parameters.Add(new SqlParameter("@ClassID",ClassID));
Cmd.Parameters.Add(new SqlParameter("@CGPA",CGPA));
Cmd.Parameters.Add(new SqlParameter("@sRemarks",sRemarks));
Cmd.Parameters.Add(new SqlParameter("@sRecommendation",sRecommendation));
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
public int DeleteStudent_AtRisk_H(InitializeModule.EnumCampus Campus,string AtRiskTransactionID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@AtRiskTransactionID", AtRiskTransactionID ));
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
DataTable dt = new DataTable("Student_AtRisk_H");
DataView dv = new DataView();
List<Student_AtRisk_H> myStudent_AtRisk_Hs = new List<Student_AtRisk_H>();
try
{
myStudent_AtRisk_Hs = GetStudent_AtRisk_H(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("AtRiskTransactionID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myStudent_AtRisk_Hs.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myStudent_AtRisk_Hs[i].AtRiskTransactionID;
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
myStudent_AtRisk_Hs.Clear();
}
 return dv;
}
public int IsStudentAtRiskExist(int iCampus ,string sStudentID, int iyear, int isem,string sCourse,int iSession,int iClass)
{
    String sSQL;
    int isExist = 0;

    Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus );
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += AtRiskTransactionIDFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + StudentIDFN + "='" + sStudentID + "'";
        sSQL += "  AND " + CourseIDFN + "='" + sCourse + "'";
        sSQL += "  AND " + AcademicYearFN + "=" + iyear;
        sSQL += "  AND " + SemesterFN + "=" + isem;
        sSQL += "  AND " + SessionIDFN + "=" + iSession ;
        sSQL += "  AND " + ClassIDFN + "=" + iClass;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            isExist = Convert.ToInt32 ("0" +  datReader[0].ToString ());
        }
        datReader.Close();

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

    return isExist;
}
//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += AtRiskTransactionIDFN;
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
public class Student_AtRisk_HCls : Student_AtRisk_HDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daStudent_AtRisk_H;
private DataSet m_dsStudent_AtRisk_H;
public DataRow Student_AtRisk_HDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsStudent_AtRisk_H
{
get { return m_dsStudent_AtRisk_H ; }
set { m_dsStudent_AtRisk_H = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Student_AtRisk_HCls()
{
try
{
dsStudent_AtRisk_H= new DataSet();

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
public virtual SqlDataAdapter GetStudent_AtRisk_HDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daStudent_AtRisk_H = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudent_AtRisk_H);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_AtRisk_H.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_AtRisk_H;
}
public virtual SqlDataAdapter GetStudent_AtRisk_HDataAdapter(SqlConnection con)  
{
try
{
daStudent_AtRisk_H = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_AtRisk_H.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdStudent_AtRisk_H;
cmdStudent_AtRisk_H = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int, 4, "AtRiskTransactionID" );
daStudent_AtRisk_H.SelectCommand = cmdStudent_AtRisk_H;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdStudent_AtRisk_H = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdStudent_AtRisk_H.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdStudent_AtRisk_H.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdStudent_AtRisk_H.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@ClassID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ClassIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@CGPA", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(CGPAFN));
cmdStudent_AtRisk_H.Parameters.Add("@sRemarks", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(sRemarksFN));
cmdStudent_AtRisk_H.Parameters.Add("@sRecommendation", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(sRecommendationFN));
cmdStudent_AtRisk_H.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudent_AtRisk_H.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudent_AtRisk_H.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdStudent_AtRisk_H.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdStudent_AtRisk_H.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daStudent_AtRisk_H.UpdateCommand = cmdStudent_AtRisk_H;
daStudent_AtRisk_H.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdStudent_AtRisk_H = new SqlCommand(GetInsertCommand(), con);
cmdStudent_AtRisk_H.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdStudent_AtRisk_H.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdStudent_AtRisk_H.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@ClassID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ClassIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@CGPA", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(CGPAFN));
cmdStudent_AtRisk_H.Parameters.Add("@sRemarks", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(sRemarksFN));
cmdStudent_AtRisk_H.Parameters.Add("@sRecommendation", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(sRecommendationFN));
cmdStudent_AtRisk_H.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudent_AtRisk_H.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudent_AtRisk_H.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudent_AtRisk_H.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdStudent_AtRisk_H.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daStudent_AtRisk_H.InsertCommand =cmdStudent_AtRisk_H;
daStudent_AtRisk_H.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdStudent_AtRisk_H = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdStudent_AtRisk_H.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daStudent_AtRisk_H.DeleteCommand =cmdStudent_AtRisk_H;
daStudent_AtRisk_H.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daStudent_AtRisk_H.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_AtRisk_H;
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
dr = dsStudent_AtRisk_H.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)]=AtRiskTransactionID;
dr[LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
dr[LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
dr[LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
dr[LibraryMOD.GetFieldName(ClassIDFN)]=ClassID;
dr[LibraryMOD.GetFieldName(CGPAFN)]=CGPA;
dr[LibraryMOD.GetFieldName(sRemarksFN)]=sRemarks;
dr[LibraryMOD.GetFieldName(sRecommendationFN)]=sRecommendation;
dsStudent_AtRisk_H.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsStudent_AtRisk_H.Tables[TableName].Select(LibraryMOD.GetFieldName(AtRiskTransactionIDFN)  + "=" + AtRiskTransactionID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(AtRiskTransactionIDFN)]=AtRiskTransactionID;
drAry[0][LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
drAry[0][LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
drAry[0][LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
drAry[0][LibraryMOD.GetFieldName(ClassIDFN)]=ClassID;
drAry[0][LibraryMOD.GetFieldName(CGPAFN)]=CGPA;
drAry[0][LibraryMOD.GetFieldName(sRemarksFN)]=sRemarks;
drAry[0][LibraryMOD.GetFieldName(sRecommendationFN)]=sRecommendation;
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
public int CommitStudent_AtRisk_H()  
{
//CommitStudent_AtRisk_H= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daStudent_AtRisk_H.Update(dsStudent_AtRisk_H, TableName);
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
FindInMultiPKey(AtRiskTransactionID);
if (( Student_AtRisk_HDataRow != null)) 
{
Student_AtRisk_HDataRow.Delete();
CommitStudent_AtRisk_H();
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
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)]== System.DBNull.Value)
{
  AtRiskTransactionID=0;
}
else
{
  AtRiskTransactionID = (int)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(StudentIDFN)]== System.DBNull.Value)
{
  StudentID="";
}
else
{
  StudentID = (string)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(StudentIDFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
{
  AcademicYear=0;
}
else
{
  AcademicYear = (int)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
{
  Semester=0;
}
else
{
  Semester = (int)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(SemesterFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(CourseIDFN)]== System.DBNull.Value)
{
  CourseID="";
}
else
{
  CourseID = (string)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(CourseIDFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(SessionIDFN)]== System.DBNull.Value)
{
  SessionID=0;
}
else
{
  SessionID = (int)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(SessionIDFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(ClassIDFN)]== System.DBNull.Value)
{
  ClassID=0;
}
else
{
  ClassID = (int)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(ClassIDFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(CGPAFN)]== System.DBNull.Value)
{
}
else
{
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(sRemarksFN)]== System.DBNull.Value)
{
  sRemarks="";
}
else
{
  sRemarks = (string)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(sRemarksFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(sRecommendationFN)]== System.DBNull.Value)
{
  sRecommendation="";
}
else
{
  sRecommendation = (string)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(sRecommendationFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)Student_AtRisk_HDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKAtRiskTransactionID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKAtRiskTransactionID;
Student_AtRisk_HDataRow = dsStudent_AtRisk_H.Tables[TableName].Rows.Find(findTheseVals);
if  ((Student_AtRisk_HDataRow !=null)) 
{
lngCurRow = dsStudent_AtRisk_H.Tables[TableName].Rows.IndexOf(Student_AtRisk_HDataRow);
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
  lngCurRow = dsStudent_AtRisk_H.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsStudent_AtRisk_H.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsStudent_AtRisk_H.Tables[TableName].Rows.Count > 0) 
{
  Student_AtRisk_HDataRow = dsStudent_AtRisk_H.Tables[TableName].Rows[lngCurRow];
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
daStudent_AtRisk_H.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_AtRisk_H.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daStudent_AtRisk_H.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_AtRisk_H.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
