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
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Committee
{
//Creation Date: 27/01/2010 8:12:08 PM
//Programmer Name : Bahaa Najem
//-----Decleration --------------
#region "Decleration"
private int m_CommitteeID; 
private int m_DepartmentID; 
private string m_DescEn; 
private string m_DescAr; 
private int m_ChairmanID; 
private int m_AcademicYear; 
private int m_Semester; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int CommitteeID
{
get { return  m_CommitteeID; }
set {m_CommitteeID  = value ; }
}
public int DepartmentID
{
get { return  m_DepartmentID; }
set {m_DepartmentID  = value ; }
}
public string DescEn
{
get { return  m_DescEn; }
set {m_DescEn  = value ; }
}
public string DescAr
{
get { return  m_DescAr; }
set {m_DescAr  = value ; }
}
public int ChairmanID
{
get { return  m_ChairmanID; }
set {m_ChairmanID  = value ; }
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
public Committee()
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
public class CommitteeDAL : Committee
{
#region "Decleration"
private string m_TableName;
private string m_CommitteeIDFN ;
private string m_DepartmentIDFN ;
private string m_DescEnFN ;
private string m_DescArFN ;
private string m_ChairmanIDFN ;
private string m_AcademicYearFN ;
private string m_SemesterFN ;
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
public string CommitteeIDFN 
{
get { return  m_CommitteeIDFN; }
set {m_CommitteeIDFN  = value ; }
}
public string DepartmentIDFN 
{
get { return  m_DepartmentIDFN; }
set {m_DepartmentIDFN  = value ; }
}
public string DescEnFN 
{
get { return  m_DescEnFN; }
set {m_DescEnFN  = value ; }
}
public string DescArFN 
{
get { return  m_DescArFN; }
set {m_DescArFN  = value ; }
}
public string ChairmanIDFN 
{
get { return  m_ChairmanIDFN; }
set {m_ChairmanIDFN  = value ; }
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
public CommitteeDAL()
{
try
{
    this.TableName = "Lkp_Committee";
this.CommitteeIDFN = m_TableName + ".CommitteeID";
this.DepartmentIDFN = m_TableName + ".DepartmentID";
this.DescEnFN = m_TableName + ".DescEn";
this.DescArFN = m_TableName + ".DescAr";
this.ChairmanIDFN = m_TableName + ".ChairmanID";
this.AcademicYearFN = m_TableName + ".AcademicYear";
this.SemesterFN = m_TableName + ".Semester";
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
sSQL +=CommitteeIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + DescEnFN;
sSQL += " , " + DescArFN;
sSQL += " , " + ChairmanIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
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
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=CommitteeIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + DescEnFN;
sSQL += " , " + DescArFN;
sSQL += " , " + ChairmanIDFN;
sSQL += " , " + AcademicYearFN;
sSQL += " , " + SemesterFN;
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
sSQL += LibraryMOD.GetFieldName(CommitteeIDFN) + "=@CommitteeID";
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN) + "=@DepartmentID";
sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN) + "=@DescEn";
sSQL += " , " + LibraryMOD.GetFieldName(DescArFN) + "=@DescAr";
sSQL += " , " + LibraryMOD.GetFieldName(ChairmanIDFN) + "=@ChairmanID";
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(CommitteeIDFN)+"=@CommitteeID";
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
sSQL +=LibraryMOD.GetFieldName(CommitteeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(DescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(ChairmanIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @CommitteeID";
sSQL += " ,@DepartmentID";
sSQL += " ,@DescEn";
sSQL += " ,@DescAr";
sSQL += " ,@ChairmanID";
sSQL += " ,@AcademicYear";
sSQL += " ,@Semester";
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
sSQL += LibraryMOD.GetFieldName(CommitteeIDFN)+"=@CommitteeID";
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
public List< Committee> GetCommittee(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Committee
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
List<Committee> results = new List<Committee>();
try
{
//Default Value
Committee myCommittee = new Committee();
if (isDeafaultIncluded)
{
//Change the code here
myCommittee.CommitteeID = 0;
//myCommittee.DepartmentID = "Select Committee ...";
results.Add(myCommittee);
}
while (reader.Read())
{
myCommittee = new Committee();
if (reader[LibraryMOD.GetFieldName(CommitteeIDFN)].Equals(DBNull.Value))
{
myCommittee.CommitteeID = 0;
}
else
{
myCommittee.CommitteeID = int.Parse(reader[LibraryMOD.GetFieldName( CommitteeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
{
myCommittee.DepartmentID = 0;
}
else
{
myCommittee.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentIDFN) ].ToString());
}
myCommittee.DescEn =reader[LibraryMOD.GetFieldName( DescEnFN) ].ToString();
myCommittee.DescAr =reader[LibraryMOD.GetFieldName( DescArFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(ChairmanIDFN)].Equals(DBNull.Value))
{
myCommittee.ChairmanID = 0;
}
else
{
myCommittee.ChairmanID = int.Parse(reader[LibraryMOD.GetFieldName( ChairmanIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myCommittee.AcademicYear = 0;
}
else
{
myCommittee.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
{
myCommittee.Semester = 0;
}
else
{
myCommittee.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myCommittee.CreationUserID = 0;
}
else
{
myCommittee.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[CreationDateFN].Equals(DBNull.Value))
{
myCommittee.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myCommittee.LastUpdateUserID = 0;
}
else
{
myCommittee.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LastUpdateDateFN].Equals(DBNull.Value))
{
myCommittee.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myCommittee.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myCommittee.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myCommittee);
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
public int UpdateCommittee(InitializeModule.EnumCampus Campus, int iMode,int CommitteeID,int DepartmentID,string DescEn,string DescAr,int ChairmanID,int AcademicYear,int Semester,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Committee theCommittee = new Committee();
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
Cmd.Parameters.Add(new SqlParameter("@CommitteeID",CommitteeID));
Cmd.Parameters.Add(new SqlParameter("@DepartmentID",DepartmentID));
Cmd.Parameters.Add(new SqlParameter("@DescEn",DescEn));
Cmd.Parameters.Add(new SqlParameter("@DescAr",DescAr));
Cmd.Parameters.Add(new SqlParameter("@ChairmanID",ChairmanID));
Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
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
public int DeleteCommittee(InitializeModule.EnumCampus Campus,string CommitteeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@CommitteeID", CommitteeID ));
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
DataTable dt = new DataTable("Committee");
DataView dv = new DataView();
List<Committee> myCommittees = new List<Committee>();
try
{
myCommittees = GetCommittee(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("CommitteeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("DepartmentID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("DescEn", Type.GetType("varchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myCommittees.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCommittees[i].CommitteeID;
  dr[2] = myCommittees[i].DepartmentID;
  dr[3] = myCommittees[i].DescEn;
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
myCommittees.Clear();
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
sSQL += CommitteeIDFN;
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
public class CommitteeCls : CommitteeDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daCommittee;
private DataSet m_dsCommittee;
public DataRow CommitteeDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsCommittee
{
get { return m_dsCommittee ; }
set { m_dsCommittee = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public CommitteeCls()
{
try
{
dsCommittee= new DataSet();

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
public virtual SqlDataAdapter GetCommitteeDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daCommittee = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCommittee);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daCommittee.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCommittee;
}
public virtual SqlDataAdapter GetCommitteeDataAdapter(SqlConnection con)  
{
try
{
daCommittee = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daCommittee.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdCommittee;
cmdCommittee = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@CommitteeID", SqlDbType.Int, 4, "CommitteeID" );
daCommittee.SelectCommand = cmdCommittee;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdCommittee = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdCommittee.Parameters.Add("@CommitteeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CommitteeIDFN));
cmdCommittee.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdCommittee.Parameters.Add("@DescEn", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(DescEnFN));
cmdCommittee.Parameters.Add("@DescAr", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(DescArFN));
cmdCommittee.Parameters.Add("@ChairmanID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ChairmanIDFN));
cmdCommittee.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdCommittee.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdCommittee.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdCommittee.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdCommittee.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdCommittee.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdCommittee.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdCommittee.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdCommittee.Parameters.Add("@CommitteeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CommitteeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daCommittee.UpdateCommand = cmdCommittee;
daCommittee.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdCommittee = new SqlCommand(GetInsertCommand(), con);
cmdCommittee.Parameters.Add("@CommitteeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CommitteeIDFN));
cmdCommittee.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdCommittee.Parameters.Add("@DescEn", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(DescEnFN));
cmdCommittee.Parameters.Add("@DescAr", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(DescArFN));
cmdCommittee.Parameters.Add("@ChairmanID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ChairmanIDFN));
cmdCommittee.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdCommittee.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdCommittee.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdCommittee.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdCommittee.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdCommittee.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdCommittee.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdCommittee.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daCommittee.InsertCommand =cmdCommittee;
daCommittee.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdCommittee = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdCommittee.Parameters.Add("@CommitteeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CommitteeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daCommittee.DeleteCommand =cmdCommittee;
daCommittee.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daCommittee.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCommittee;
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
dr = dsCommittee.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(CommitteeIDFN)]=CommitteeID;
dr[LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
dr[LibraryMOD.GetFieldName(DescEnFN)]=DescEn;
dr[LibraryMOD.GetFieldName(DescArFN)]=DescAr;
dr[LibraryMOD.GetFieldName(ChairmanIDFN)]=ChairmanID;
dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsCommittee.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsCommittee.Tables[TableName].Select(LibraryMOD.GetFieldName(CommitteeIDFN)  + "=" + CommitteeID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(CommitteeIDFN)]=CommitteeID;
drAry[0][LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
drAry[0][LibraryMOD.GetFieldName(DescEnFN)]=DescEn;
drAry[0][LibraryMOD.GetFieldName(DescArFN)]=DescAr;
drAry[0][LibraryMOD.GetFieldName(ChairmanIDFN)]=ChairmanID;
drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
public int CommitCommittee()  
{
//CommitCommittee= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daCommittee.Update(dsCommittee, TableName);
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
FindInMultiPKey(CommitteeID);
if (( CommitteeDataRow != null)) 
{
CommitteeDataRow.Delete();
CommitCommittee();
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
if (CommitteeDataRow[LibraryMOD.GetFieldName(CommitteeIDFN)]== System.DBNull.Value)
{
  CommitteeID=0;
}
else
{
  CommitteeID = (int)CommitteeDataRow[LibraryMOD.GetFieldName(CommitteeIDFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)]== System.DBNull.Value)
{
  DepartmentID=0;
}
else
{
  DepartmentID = (int)CommitteeDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(DescEnFN)]== System.DBNull.Value)
{
  DescEn="";
}
else
{
  DescEn = (string)CommitteeDataRow[LibraryMOD.GetFieldName(DescEnFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(DescArFN)]== System.DBNull.Value)
{
  DescAr="";
}
else
{
  DescAr = (string)CommitteeDataRow[LibraryMOD.GetFieldName(DescArFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(ChairmanIDFN)]== System.DBNull.Value)
{
  ChairmanID=0;
}
else
{
  ChairmanID = (int)CommitteeDataRow[LibraryMOD.GetFieldName(ChairmanIDFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
{
  AcademicYear=0;
}
else
{
  AcademicYear = (int)CommitteeDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
{
  Semester=0;
}
else
{
  Semester = (int)CommitteeDataRow[LibraryMOD.GetFieldName(SemesterFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)CommitteeDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)CommitteeDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)CommitteeDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)CommitteeDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)CommitteeDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (CommitteeDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)CommitteeDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKCommitteeID) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKCommitteeID;
CommitteeDataRow = dsCommittee.Tables[TableName].Rows.Find(findTheseVals);
if  ((CommitteeDataRow !=null)) 
{
lngCurRow = dsCommittee.Tables[TableName].Rows.IndexOf(CommitteeDataRow);
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
  lngCurRow = dsCommittee.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsCommittee.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsCommittee.Tables[TableName].Rows.Count > 0) 
{
  CommitteeDataRow = dsCommittee.Tables[TableName].Rows[lngCurRow];
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
daCommittee.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCommittee.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daCommittee.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCommittee.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
