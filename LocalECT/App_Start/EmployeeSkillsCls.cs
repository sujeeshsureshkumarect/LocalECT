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
public class EmployeeSkills
{
//Creation Date: 31/10/2010 7:15 PM
//Programmer Name : Bahaa Addin Ghaleb Najem
//-----Decleration --------------
#region "Decleration"
private int m_EmployeeID; 
private int m_SkillID; 
private string m_SkillName; 
private int m_SkillLevelID; 
private int m_YearsOfExperience; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int EmployeeID
{
get { return  m_EmployeeID; }
set {m_EmployeeID  = value ; }
}
public int SkillID
{
get { return  m_SkillID; }
set {m_SkillID  = value ; }
}
public string SkillName
{
get { return  m_SkillName; }
set {m_SkillName  = value ; }
}
public int SkillLevelID
{
get { return  m_SkillLevelID; }
set {m_SkillLevelID  = value ; }
}
public int YearsOfExperience
{
get { return  m_YearsOfExperience; }
set {m_YearsOfExperience  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public EmployeeSkills()
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
public class EmployeeSkillsDAL : EmployeeSkills
{
#region "Decleration"
private string m_TableName;
private string m_EmployeeIDFN ;
private string m_SkillIDFN ;
private string m_SkillNameFN ;
private string m_SkillLevelIDFN ;
private string m_YearsOfExperienceFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string EmployeeIDFN 
{
get { return  m_EmployeeIDFN; }
set {m_EmployeeIDFN  = value ; }
}
public string SkillIDFN 
{
get { return  m_SkillIDFN; }
set {m_SkillIDFN  = value ; }
}
public string SkillNameFN 
{
get { return  m_SkillNameFN; }
set {m_SkillNameFN  = value ; }
}
public string SkillLevelIDFN 
{
get { return  m_SkillLevelIDFN; }
set {m_SkillLevelIDFN  = value ; }
}
public string YearsOfExperienceFN 
{
get { return  m_YearsOfExperienceFN; }
set {m_YearsOfExperienceFN  = value ; }
}
#endregion
//================End Properties ===================
public EmployeeSkillsDAL()
{
try
{
this.TableName = "HR_EmployeeSkills";
this.EmployeeIDFN = m_TableName + ".EmployeeID";
this.SkillIDFN = m_TableName + ".SkillID";
this.SkillNameFN = m_TableName + ".SkillName";
this.SkillLevelIDFN = m_TableName + ".SkillLevelID";
this.YearsOfExperienceFN = m_TableName + ".YearsOfExperience";
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
sSQL +=EmployeeIDFN;
sSQL += " , " + SkillIDFN;
sSQL += " , " + SkillNameFN;
sSQL += " , " + SkillLevelIDFN;
sSQL += " , " + YearsOfExperienceFN;
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
public string GetListSQL(string sWhere) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=EmployeeIDFN;
sSQL += " , " + SkillIDFN;
sSQL += " , " + SkillNameFN;
sSQL += "  FROM " + m_TableName;
sSQL += sWhere;
sSQL += " Order By (" + SkillIDFN + ")";
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
sSQL +=EmployeeIDFN;
sSQL += " , " + SkillIDFN;
sSQL += " , " + SkillNameFN;
sSQL += " , " + SkillLevelIDFN;
sSQL += " , " + YearsOfExperienceFN;
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN) + "=@EmployeeID";
sSQL += " , " + LibraryMOD.GetFieldName(SkillIDFN) + "=@SkillID";
sSQL += " , " + LibraryMOD.GetFieldName(SkillNameFN) + "=@SkillName";
sSQL += " , " + LibraryMOD.GetFieldName(SkillLevelIDFN) + "=@SkillLevelID";
sSQL += " , " + LibraryMOD.GetFieldName(YearsOfExperienceFN) + "=@YearsOfExperience";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " + LibraryMOD.GetFieldName(SkillIDFN)+"=@SkillID";
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
sSQL +=LibraryMOD.GetFieldName(EmployeeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SkillIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SkillNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(SkillLevelIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(YearsOfExperienceFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @EmployeeID";
sSQL += " ,@SkillID";
sSQL += " ,@SkillName";
sSQL += " ,@SkillLevelID";
sSQL += " ,@YearsOfExperience";
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(SkillIDFN)+"=@SkillID";
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
public List< EmployeeSkills> GetEmployeeSkills(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the EmployeeSkills
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
List<EmployeeSkills> results = new List<EmployeeSkills>();
try
{
//Default Value
EmployeeSkills myEmployeeSkills = new EmployeeSkills();
if (isDeafaultIncluded)
{
//Change the code here
myEmployeeSkills.EmployeeID = 0;
myEmployeeSkills.SkillID = 0;
myEmployeeSkills.SkillName = "Select EmployeeSkills ...";
results.Add(myEmployeeSkills);
}
while (reader.Read())
{
myEmployeeSkills = new EmployeeSkills();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeSkills.EmployeeID = 0;
}
else
{
myEmployeeSkills.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SkillIDFN)].Equals(DBNull.Value))
{
myEmployeeSkills.SkillID = 0;
}
else
{
myEmployeeSkills.SkillID = int.Parse(reader[LibraryMOD.GetFieldName( SkillIDFN) ].ToString());
}
myEmployeeSkills.SkillName =reader[LibraryMOD.GetFieldName( SkillNameFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(SkillLevelIDFN)].Equals(DBNull.Value))
{
myEmployeeSkills.SkillLevelID = 0;
}
else
{
myEmployeeSkills.SkillLevelID = int.Parse(reader[LibraryMOD.GetFieldName( SkillLevelIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(YearsOfExperienceFN)].Equals(DBNull.Value))
{
myEmployeeSkills.YearsOfExperience = 0;
}
else
{
myEmployeeSkills.YearsOfExperience = int.Parse(reader[LibraryMOD.GetFieldName( YearsOfExperienceFN) ].ToString());
}
 results.Add(myEmployeeSkills);
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
public List< EmployeeSkills > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<EmployeeSkills> results = new List<EmployeeSkills>();
try
{
//Default Value
EmployeeSkills myEmployeeSkills= new EmployeeSkills();
if (isDeafaultIncluded) 
 {
//Change the code here
 myEmployeeSkills.EmployeeID = -1;
 myEmployeeSkills.SkillID = 0 ;
results.Add(myEmployeeSkills);
 }
while (reader.Read())
{
myEmployeeSkills = new EmployeeSkills();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeSkills.EmployeeID = 0;
}
else
{
myEmployeeSkills.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SkillIDFN)].Equals(DBNull.Value))
{
myEmployeeSkills.SkillID = 0;
}
else
{
myEmployeeSkills.SkillID = int.Parse(reader[LibraryMOD.GetFieldName( SkillIDFN) ].ToString());
}
myEmployeeSkills.SkillName =reader[LibraryMOD.GetFieldName( SkillNameFN) ].ToString();
 results.Add(myEmployeeSkills);
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
public int UpdateEmployeeSkills(InitializeModule.EnumCampus Campus, int iMode,int EmployeeID,int SkillID,string SkillName,int SkillLevelID,int YearsOfExperience)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EmployeeSkills theEmployeeSkills = new EmployeeSkills();
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
Cmd.Parameters.Add(new SqlParameter("@EmployeeID",EmployeeID));
Cmd.Parameters.Add(new SqlParameter("@SkillID",SkillID));
Cmd.Parameters.Add(new SqlParameter("@SkillName",SkillName));
Cmd.Parameters.Add(new SqlParameter("@SkillLevelID",SkillLevelID));
Cmd.Parameters.Add(new SqlParameter("@YearsOfExperience",YearsOfExperience));
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
public int DeleteEmployeeSkills(InitializeModule.EnumCampus Campus,string EmployeeID,string SkillID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID ));
Cmd.Parameters.Add(new SqlParameter("@SkillID", SkillID ));
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
DataTable dt = new DataTable("EmployeeSkills");
DataView dv = new DataView();
List<EmployeeSkills> myEmployeeSkillss = new List<EmployeeSkills>();
try
{
myEmployeeSkillss = GetEmployeeSkills(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("EmployeeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("SkillID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("SkillName", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myEmployeeSkillss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myEmployeeSkillss[i].EmployeeID;
  dr[2] = myEmployeeSkillss[i].SkillID;
  dr[3] = myEmployeeSkillss[i].SkillName;
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
myEmployeeSkillss.Clear();
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
sSQL += EmployeeIDFN;
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
public class EmployeeSkillsCls : EmployeeSkillsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daEmployeeSkills;
private DataSet m_dsEmployeeSkills;
public DataRow EmployeeSkillsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsEmployeeSkills
{
get { return m_dsEmployeeSkills ; }
set { m_dsEmployeeSkills = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EmployeeSkillsCls()
{
try
{
dsEmployeeSkills= new DataSet();

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
public virtual SqlDataAdapter GetEmployeeSkillsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daEmployeeSkills = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daEmployeeSkills);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeSkills.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeSkills;
}
public virtual SqlDataAdapter GetEmployeeSkillsDataAdapter(SqlConnection con)  
{
try
{
daEmployeeSkills = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeSkills.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdEmployeeSkills;
cmdEmployeeSkills = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, "EmployeeID" );
//'cmdRolePermission.Parameters.Add("@SkillID", SqlDbType.Int, 4, "SkillID" );
daEmployeeSkills.SelectCommand = cmdEmployeeSkills;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdEmployeeSkills = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdEmployeeSkills.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeSkills.Parameters.Add("@SkillID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SkillIDFN));
cmdEmployeeSkills.Parameters.Add("@SkillName", SqlDbType.NVarChar,510, LibraryMOD.GetFieldName(SkillNameFN));
cmdEmployeeSkills.Parameters.Add("@SkillLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SkillLevelIDFN));
cmdEmployeeSkills.Parameters.Add("@YearsOfExperience", SqlDbType.Int,4, LibraryMOD.GetFieldName(YearsOfExperienceFN));


Parmeter = cmdEmployeeSkills.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeSkills.Parameters.Add("@SkillID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SkillIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daEmployeeSkills.UpdateCommand = cmdEmployeeSkills;
daEmployeeSkills.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdEmployeeSkills = new SqlCommand(GetInsertCommand(), con);
cmdEmployeeSkills.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeSkills.Parameters.Add("@SkillID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SkillIDFN));
cmdEmployeeSkills.Parameters.Add("@SkillName", SqlDbType.NVarChar,510, LibraryMOD.GetFieldName(SkillNameFN));
cmdEmployeeSkills.Parameters.Add("@SkillLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SkillLevelIDFN));
cmdEmployeeSkills.Parameters.Add("@YearsOfExperience", SqlDbType.Int,4, LibraryMOD.GetFieldName(YearsOfExperienceFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daEmployeeSkills.InsertCommand =cmdEmployeeSkills;
daEmployeeSkills.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdEmployeeSkills = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdEmployeeSkills.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeSkills.Parameters.Add("@SkillID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SkillIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daEmployeeSkills.DeleteCommand =cmdEmployeeSkills;
daEmployeeSkills.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daEmployeeSkills.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeSkills;
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
dr = dsEmployeeSkills.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
dr[LibraryMOD.GetFieldName(SkillIDFN)]=SkillID;
dr[LibraryMOD.GetFieldName(SkillNameFN)]=SkillName;
dr[LibraryMOD.GetFieldName(SkillLevelIDFN)]=SkillLevelID;
dr[LibraryMOD.GetFieldName(YearsOfExperienceFN)]=YearsOfExperience;
dsEmployeeSkills.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsEmployeeSkills.Tables[TableName].Select(LibraryMOD.GetFieldName(EmployeeIDFN)  + "=" + EmployeeID  + " AND " + LibraryMOD.GetFieldName(SkillIDFN) + "=" + SkillID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
drAry[0][LibraryMOD.GetFieldName(SkillIDFN)]=SkillID;
drAry[0][LibraryMOD.GetFieldName(SkillNameFN)]=SkillName;
drAry[0][LibraryMOD.GetFieldName(SkillLevelIDFN)]=SkillLevelID;
drAry[0][LibraryMOD.GetFieldName(YearsOfExperienceFN)]=YearsOfExperience;
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
public int CommitEmployeeSkills()  
{
//CommitEmployeeSkills= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daEmployeeSkills.Update(dsEmployeeSkills, TableName);
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
FindInMultiPKey(EmployeeID,SkillID);
if (( EmployeeSkillsDataRow != null)) 
{
EmployeeSkillsDataRow.Delete();
CommitEmployeeSkills();
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
if (EmployeeSkillsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)]== System.DBNull.Value)
{
  EmployeeID=0;
}
else
{
  EmployeeID = (int)EmployeeSkillsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
}
if (EmployeeSkillsDataRow[LibraryMOD.GetFieldName(SkillIDFN)]== System.DBNull.Value)
{
  SkillID=0;
}
else
{
  SkillID = (int)EmployeeSkillsDataRow[LibraryMOD.GetFieldName(SkillIDFN)];
}
if (EmployeeSkillsDataRow[LibraryMOD.GetFieldName(SkillNameFN)]== System.DBNull.Value)
{
  SkillName="";
}
else
{
  SkillName = (string)EmployeeSkillsDataRow[LibraryMOD.GetFieldName(SkillNameFN)];
}
if (EmployeeSkillsDataRow[LibraryMOD.GetFieldName(SkillLevelIDFN)]== System.DBNull.Value)
{
  SkillLevelID=0;
}
else
{
  SkillLevelID = (int)EmployeeSkillsDataRow[LibraryMOD.GetFieldName(SkillLevelIDFN)];
}
if (EmployeeSkillsDataRow[LibraryMOD.GetFieldName(YearsOfExperienceFN)]== System.DBNull.Value)
{
  YearsOfExperience=0;
}
else
{
  YearsOfExperience = (int)EmployeeSkillsDataRow[LibraryMOD.GetFieldName(YearsOfExperienceFN)];
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
public int FindInMultiPKey(int PKEmployeeID,int PKSkillID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKEmployeeID;
findTheseVals[1] = PKSkillID;
EmployeeSkillsDataRow = dsEmployeeSkills.Tables[TableName].Rows.Find(findTheseVals);
if  ((EmployeeSkillsDataRow !=null)) 
{
lngCurRow = dsEmployeeSkills.Tables[TableName].Rows.IndexOf(EmployeeSkillsDataRow);
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
  lngCurRow = dsEmployeeSkills.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsEmployeeSkills.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsEmployeeSkills.Tables[TableName].Rows.Count > 0) 
{
  EmployeeSkillsDataRow = dsEmployeeSkills.Tables[TableName].Rows[lngCurRow];
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
daEmployeeSkills.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeSkills.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daEmployeeSkills.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeSkills.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
