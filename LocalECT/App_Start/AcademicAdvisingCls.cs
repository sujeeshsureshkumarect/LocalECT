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
public class AcademicAdvising
{
//Creation Date: 21/03/2019 5:07:55 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_AcademicAdvisingID; 
private string m_StudentID; 
private int m_AcademicYear; 
private int m_Semester; 
private double m_CurrentCGPA; 
private int m_AdvisorID; 
private string m_AdvisorComments; 
private string m_StudentComments; 
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
public double CurrentCGPA
{
get { return  m_CurrentCGPA; }
set {m_CurrentCGPA  = value ; }
}
public int AdvisorID
{
get { return  m_AdvisorID; }
set {m_AdvisorID  = value ; }
}
public string AdvisorComments
{
get { return  m_AdvisorComments; }
set {m_AdvisorComments  = value ; }
}
public string StudentComments
{
get { return  m_StudentComments; }
set {m_StudentComments  = value ; }
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
public AcademicAdvising()
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
public class AcademicAdvisingDAL : AcademicAdvising
{
#region "Decleration"
private string m_TableName;
private string m_AcademicAdvisingIDFN ;
private string m_StudentIDFN ;
private string m_AcademicYearFN ;
private string m_SemesterFN ;
private string m_CurrentCGPAFN ;
private string m_AdvisorIDFN ;
private string m_AdvisorCommentsFN ;
private string m_StudentCommentsFN ;
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
public string CurrentCGPAFN 
{
get { return  m_CurrentCGPAFN; }
set {m_CurrentCGPAFN  = value ; }
}
public string AdvisorIDFN 
{
get { return  m_AdvisorIDFN; }
set {m_AdvisorIDFN  = value ; }
}
public string AdvisorCommentsFN 
{
get { return  m_AdvisorCommentsFN; }
set {m_AdvisorCommentsFN  = value ; }
}
public string StudentCommentsFN 
{
get { return  m_StudentCommentsFN; }
set {m_StudentCommentsFN  = value ; }
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
public AcademicAdvisingDAL()
{
try
{
this.TableName = "Reg_AcademicAdvising";
this.AcademicAdvisingIDFN = m_TableName + ".AcademicAdvisingID";
this.StudentIDFN = m_TableName + ".StudentID";
this.AcademicYearFN = m_TableName + ".AcademicYear";
this.SemesterFN = m_TableName + ".Semester";
this.CurrentCGPAFN = m_TableName + ".CurrentCGPA";
this.AdvisorIDFN = m_TableName + ".AdvisorID";
this.AdvisorCommentsFN = m_TableName + ".AdvisorComments";
this.StudentCommentsFN = m_TableName + ".StudentComments";
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
sSQL +=AcademicAdvisingIDFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + CurrentCGPAFN;
sSQL += " , " + AdvisorIDFN;
sSQL += " , " + AdvisorCommentsFN;
sSQL += " , " + StudentCommentsFN;
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
sSQL += " , " + CurrentCGPAFN;
sSQL += " , " + AdvisorIDFN;
sSQL += " , " + AdvisorCommentsFN;
sSQL += " , " + StudentCommentsFN;
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
sSQL += LibraryMOD.GetFieldName(AcademicAdvisingIDFN) + "=@AcademicAdvisingID";
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN) + "=@StudentID";
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
sSQL += " , " + LibraryMOD.GetFieldName(CurrentCGPAFN) + "=@CurrentCGPA";
sSQL += " , " + LibraryMOD.GetFieldName(AdvisorIDFN) + "=@AdvisorID";
sSQL += " , " + LibraryMOD.GetFieldName(AdvisorCommentsFN) + "=@AdvisorComments";
sSQL += " , " + LibraryMOD.GetFieldName(StudentCommentsFN) + "=@StudentComments";
sSQL += " , " + LibraryMOD.GetFieldName(sRecommendationFN) + "=@sRecommendation";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(AcademicAdvisingIDFN)+"=@AcademicAdvisingID";
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
sSQL += " , " + LibraryMOD.GetFieldName(CurrentCGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(AdvisorIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(AdvisorCommentsFN);
sSQL += " , " + LibraryMOD.GetFieldName(StudentCommentsFN);
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
sSQL += " @AcademicAdvisingID";
sSQL += " ,@StudentID";
sSQL += " ,@AcademicYear";
sSQL += " ,@Semester";
sSQL += " ,@CurrentCGPA";
sSQL += " ,@AdvisorID";
sSQL += " ,@AdvisorComments";
sSQL += " ,@StudentComments";
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
sSQL += LibraryMOD.GetFieldName(AcademicAdvisingIDFN)+"=@AcademicAdvisingID";
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
public List< AcademicAdvising> GetAcademicAdvising(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the AcademicAdvising
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
List<AcademicAdvising> results = new List<AcademicAdvising>();
try
{
//Default Value
AcademicAdvising myAcademicAdvising = new AcademicAdvising();
if (isDeafaultIncluded)
{
//Change the code here
myAcademicAdvising.AcademicAdvisingID = 0;
myAcademicAdvising.AdvisorComments  = "...";
results.Add(myAcademicAdvising);
}
while (reader.Read())
{
myAcademicAdvising = new AcademicAdvising();
if (reader[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising.AcademicAdvisingID = 0;
}
else
{
myAcademicAdvising.AcademicAdvisingID = int.Parse(reader[LibraryMOD.GetFieldName( AcademicAdvisingIDFN) ].ToString());
}
myAcademicAdvising.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myAcademicAdvising.AcademicYear = 0;
}
else
{
myAcademicAdvising.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
{
myAcademicAdvising.Semester = 0;
}
else
{
myAcademicAdvising.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(AdvisorIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising.AdvisorID = 0;
}
else
{
myAcademicAdvising.AdvisorID = int.Parse(reader[LibraryMOD.GetFieldName( AdvisorIDFN) ].ToString());
}
myAcademicAdvising.AdvisorComments =reader[LibraryMOD.GetFieldName( AdvisorCommentsFN) ].ToString();
myAcademicAdvising.StudentComments =reader[LibraryMOD.GetFieldName( StudentCommentsFN) ].ToString();
myAcademicAdvising.sRecommendation =reader[LibraryMOD.GetFieldName( sRecommendationFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising.CreationUserID = 0;
}
else
{
myAcademicAdvising.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myAcademicAdvising.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising.LastUpdateUserID = 0;
}
else
{
myAcademicAdvising.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myAcademicAdvising.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myAcademicAdvising.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myAcademicAdvising.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myAcademicAdvising);
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
public List< AcademicAdvising > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<AcademicAdvising> results = new List<AcademicAdvising>();
try
{
//Default Value
AcademicAdvising myAcademicAdvising= new AcademicAdvising();
if (isDeafaultIncluded)
 {
//Change the code here
 myAcademicAdvising.AcademicAdvisingID = -1;
 myAcademicAdvising.StudentID = "Select AcademicAdvising" ;
results.Add(myAcademicAdvising);
 }
while (reader.Read())
{
myAcademicAdvising = new AcademicAdvising();
if (reader[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)].Equals(DBNull.Value))
{
myAcademicAdvising.AcademicAdvisingID = 0;
}
else
{
myAcademicAdvising.AcademicAdvisingID = int.Parse(reader[LibraryMOD.GetFieldName( AcademicAdvisingIDFN) ].ToString());
}
myAcademicAdvising.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myAcademicAdvising.AcademicYear = 0;
}
else
{
myAcademicAdvising.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
 results.Add(myAcademicAdvising);
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
public int UpdateAcademicAdvising(InitializeModule.EnumCampus Campus, int iMode,int AcademicAdvisingID,string StudentID,int AcademicYear,int Semester,decimal CurrentCGPA,int AdvisorID,string AdvisorComments,string StudentComments,string sRecommendation,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
AcademicAdvising theAcademicAdvising = new AcademicAdvising();
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
Cmd.Parameters.Add(new SqlParameter("@CurrentCGPA",CurrentCGPA));
Cmd.Parameters.Add(new SqlParameter("@AdvisorID",AdvisorID));
Cmd.Parameters.Add(new SqlParameter("@AdvisorComments",AdvisorComments));
Cmd.Parameters.Add(new SqlParameter("@StudentComments",StudentComments));
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
public int DeleteAcademicAdvising(InitializeModule.EnumCampus Campus,string AcademicAdvisingID)
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
DataTable dt = new DataTable("AcademicAdvising");
DataView dv = new DataView();
List<AcademicAdvising> myAcademicAdvisings = new List<AcademicAdvising>();
try
{
myAcademicAdvisings = GetAcademicAdvising(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("AcademicAdvisingID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myAcademicAdvisings.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myAcademicAdvisings[i].AcademicAdvisingID;
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
myAcademicAdvisings.Clear();
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
public class AcademicAdvisingCls : AcademicAdvisingDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daAcademicAdvising;
private DataSet m_dsAcademicAdvising;
public DataRow AcademicAdvisingDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsAcademicAdvising
{
get { return m_dsAcademicAdvising ; }
set { m_dsAcademicAdvising = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public AcademicAdvisingCls()
{
try
{
dsAcademicAdvising= new DataSet();

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
public virtual SqlDataAdapter GetAcademicAdvisingDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daAcademicAdvising = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daAcademicAdvising);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daAcademicAdvising.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAcademicAdvising;
}
public virtual SqlDataAdapter GetAcademicAdvisingDataAdapter(SqlConnection con)  
{
try
{
daAcademicAdvising = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daAcademicAdvising.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdAcademicAdvising;
cmdAcademicAdvising = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int, 4, "AcademicAdvisingID" );
daAcademicAdvising.SelectCommand = cmdAcademicAdvising;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdAcademicAdvising = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdAcademicAdvising.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
cmdAcademicAdvising.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdAcademicAdvising.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdAcademicAdvising.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdAcademicAdvising.Parameters.Add("@CurrentCGPA", SqlDbType.Decimal,7, LibraryMOD.GetFieldName(CurrentCGPAFN));
cmdAcademicAdvising.Parameters.Add("@AdvisorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AdvisorIDFN));
cmdAcademicAdvising.Parameters.Add("@AdvisorComments", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(AdvisorCommentsFN));
cmdAcademicAdvising.Parameters.Add("@StudentComments", SqlDbType.NChar,20, LibraryMOD.GetFieldName(StudentCommentsFN));
cmdAcademicAdvising.Parameters.Add("@sRecommendation", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(sRecommendationFN));
cmdAcademicAdvising.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdAcademicAdvising.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdAcademicAdvising.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdAcademicAdvising.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdAcademicAdvising.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdAcademicAdvising.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdAcademicAdvising.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daAcademicAdvising.UpdateCommand = cmdAcademicAdvising;
daAcademicAdvising.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdAcademicAdvising = new SqlCommand(GetInsertCommand(), con);
cmdAcademicAdvising.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
cmdAcademicAdvising.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdAcademicAdvising.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdAcademicAdvising.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdAcademicAdvising.Parameters.Add("@CurrentCGPA", SqlDbType.Decimal,7, LibraryMOD.GetFieldName(CurrentCGPAFN));
cmdAcademicAdvising.Parameters.Add("@AdvisorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AdvisorIDFN));
cmdAcademicAdvising.Parameters.Add("@AdvisorComments", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(AdvisorCommentsFN));
cmdAcademicAdvising.Parameters.Add("@StudentComments", SqlDbType.NChar,20, LibraryMOD.GetFieldName(StudentCommentsFN));
cmdAcademicAdvising.Parameters.Add("@sRecommendation", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(sRecommendationFN));
cmdAcademicAdvising.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdAcademicAdvising.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdAcademicAdvising.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdAcademicAdvising.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdAcademicAdvising.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdAcademicAdvising.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daAcademicAdvising.InsertCommand =cmdAcademicAdvising;
daAcademicAdvising.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdAcademicAdvising = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdAcademicAdvising.Parameters.Add("@AcademicAdvisingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicAdvisingIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daAcademicAdvising.DeleteCommand =cmdAcademicAdvising;
daAcademicAdvising.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daAcademicAdvising.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAcademicAdvising;
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
dr = dsAcademicAdvising.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)]=AcademicAdvisingID;
dr[LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
dr[LibraryMOD.GetFieldName(CurrentCGPAFN)]=CurrentCGPA;
dr[LibraryMOD.GetFieldName(AdvisorIDFN)]=AdvisorID;
dr[LibraryMOD.GetFieldName(AdvisorCommentsFN)]=AdvisorComments;
dr[LibraryMOD.GetFieldName(StudentCommentsFN)]=StudentComments;
dr[LibraryMOD.GetFieldName(sRecommendationFN)]=sRecommendation;
dsAcademicAdvising.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsAcademicAdvising.Tables[TableName].Select(LibraryMOD.GetFieldName(AcademicAdvisingIDFN)  + "=" + AcademicAdvisingID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(AcademicAdvisingIDFN)]=AcademicAdvisingID;
drAry[0][LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
drAry[0][LibraryMOD.GetFieldName(CurrentCGPAFN)]=CurrentCGPA;
drAry[0][LibraryMOD.GetFieldName(AdvisorIDFN)]=AdvisorID;
drAry[0][LibraryMOD.GetFieldName(AdvisorCommentsFN)]=AdvisorComments;
drAry[0][LibraryMOD.GetFieldName(StudentCommentsFN)]=StudentComments;
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
public int CommitAcademicAdvising()  
{
//CommitAcademicAdvising= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daAcademicAdvising.Update(dsAcademicAdvising, TableName);
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
FindInMultiPKey(AcademicAdvisingID);
if (( AcademicAdvisingDataRow != null)) 
{
AcademicAdvisingDataRow.Delete();
CommitAcademicAdvising();
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
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)]== System.DBNull.Value)
{
  AcademicAdvisingID=0;
}
else
{
  AcademicAdvisingID = (int)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AcademicAdvisingIDFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(StudentIDFN)]== System.DBNull.Value)
{
  StudentID="";
}
else
{
  StudentID = (string)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(StudentIDFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
{
  AcademicYear=0;
}
else
{
  AcademicYear = (int)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
{
  Semester=0;
}
else
{
  Semester = (int)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(SemesterFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(CurrentCGPAFN)]== System.DBNull.Value)
{
}
else
{
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AdvisorIDFN)]== System.DBNull.Value)
{
  AdvisorID=0;
}
else
{
  AdvisorID = (int)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AdvisorIDFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AdvisorCommentsFN)]== System.DBNull.Value)
{
  AdvisorComments="";
}
else
{
  AdvisorComments = (string)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(AdvisorCommentsFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(StudentCommentsFN)]== System.DBNull.Value)
{
  StudentComments="";
}
else
{
  StudentComments = (string)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(StudentCommentsFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(sRecommendationFN)]== System.DBNull.Value)
{
  sRecommendation="";
}
else
{
  sRecommendation = (string)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(sRecommendationFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (AcademicAdvisingDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)AcademicAdvisingDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKAcademicAdvisingID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKAcademicAdvisingID;
AcademicAdvisingDataRow = dsAcademicAdvising.Tables[TableName].Rows.Find(findTheseVals);
if  ((AcademicAdvisingDataRow !=null)) 
{
lngCurRow = dsAcademicAdvising.Tables[TableName].Rows.IndexOf(AcademicAdvisingDataRow);
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
  lngCurRow = dsAcademicAdvising.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsAcademicAdvising.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsAcademicAdvising.Tables[TableName].Rows.Count > 0) 
{
  AcademicAdvisingDataRow = dsAcademicAdvising.Tables[TableName].Rows[lngCurRow];
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
daAcademicAdvising.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAcademicAdvising.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daAcademicAdvising.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAcademicAdvising.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
