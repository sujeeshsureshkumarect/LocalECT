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
public class EngCertificate_ExamCenter
{
//Creation Date: 19/12/2018 3:43:57 PM
//Programmer Name : Bahaa Addin
//-----Decleration --------------
#region "Decleration"
private int m_ExamCenterID; 
private string m_ExamcenterName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int ExamCenterID
{
get { return  m_ExamCenterID; }
set {m_ExamCenterID  = value ; }
}
public string ExamcenterName
{
get { return  m_ExamcenterName; }
set {m_ExamcenterName  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public EngCertificate_ExamCenter()
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
public class EngCertificate_ExamCenterDAL : EngCertificate_ExamCenter
{
#region "Decleration"
private string m_TableName;
private string m_ExamCenterIDFN ;
private string m_ExamcenterNameFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string ExamCenterIDFN 
{
get { return  m_ExamCenterIDFN; }
set {m_ExamCenterIDFN  = value ; }
}
public string ExamcenterNameFN 
{
get { return  m_ExamcenterNameFN; }
set {m_ExamcenterNameFN  = value ; }
}
#endregion
//================End Properties ===================
public EngCertificate_ExamCenterDAL()
{
try
{
this.TableName = "Lkp_EngCertificate_ExamCenter";
this.ExamCenterIDFN = m_TableName + ".ExamCenterID";
this.ExamcenterNameFN = m_TableName + ".ExamcenterName";
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
sSQL +=ExamCenterIDFN;
sSQL += " , " + ExamcenterNameFN;
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
sSQL += ExamCenterIDFN;
sSQL += " , " + ExamcenterNameFN;
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
sSQL +=ExamCenterIDFN;
sSQL += " , " + ExamcenterNameFN;
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
sSQL += LibraryMOD.GetFieldName(ExamCenterIDFN) + "=@ExamCenterID";
sSQL += " , " + LibraryMOD.GetFieldName(ExamcenterNameFN) + "=@ExamcenterName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(ExamCenterIDFN)+"=@ExamCenterID";
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
sSQL +=LibraryMOD.GetFieldName(ExamCenterIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ExamcenterNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @ExamCenterID";
sSQL += " ,@ExamcenterName";
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
sSQL += LibraryMOD.GetFieldName(ExamCenterIDFN)+"=@ExamCenterID";
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
public List< EngCertificate_ExamCenter> GetEngCertificate_ExamCenter(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the EngCertificate_ExamCenter
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
List<EngCertificate_ExamCenter> results = new List<EngCertificate_ExamCenter>();
try
{
//Default Value
EngCertificate_ExamCenter myEngCertificate_ExamCenter = new EngCertificate_ExamCenter();
if (isDeafaultIncluded)
{
//Change the code here
myEngCertificate_ExamCenter.ExamCenterID = 0;
myEngCertificate_ExamCenter.ExamcenterName = "Select EngCertificate_ExamCenter ...";
results.Add(myEngCertificate_ExamCenter);
}
while (reader.Read())
{
myEngCertificate_ExamCenter = new EngCertificate_ExamCenter();
if (reader[LibraryMOD.GetFieldName(ExamCenterIDFN)].Equals(DBNull.Value))
{
myEngCertificate_ExamCenter.ExamCenterID = 0;
}
else
{
myEngCertificate_ExamCenter.ExamCenterID = int.Parse(reader[LibraryMOD.GetFieldName( ExamCenterIDFN) ].ToString());
}
myEngCertificate_ExamCenter.ExamcenterName =reader[LibraryMOD.GetFieldName( ExamcenterNameFN) ].ToString();
 results.Add(myEngCertificate_ExamCenter);
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
public List< EngCertificate_ExamCenter > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<EngCertificate_ExamCenter> results = new List<EngCertificate_ExamCenter>();
try
{
//Default Value
EngCertificate_ExamCenter myEngCertificate_ExamCenter= new EngCertificate_ExamCenter();
if (isDeafaultIncluded)
 {
//Change the code here
 myEngCertificate_ExamCenter.ExamCenterID = -1;
 myEngCertificate_ExamCenter.ExamcenterName = "Select EngCertificate_ExamCenter" ;
results.Add(myEngCertificate_ExamCenter);
 }
while (reader.Read())
{
myEngCertificate_ExamCenter = new EngCertificate_ExamCenter();
if (reader[LibraryMOD.GetFieldName(ExamCenterIDFN)].Equals(DBNull.Value))
{
myEngCertificate_ExamCenter.ExamCenterID = 0;
}
else
{
myEngCertificate_ExamCenter.ExamCenterID = int.Parse(reader[LibraryMOD.GetFieldName( ExamCenterIDFN) ].ToString());
}
myEngCertificate_ExamCenter.ExamcenterName =reader[LibraryMOD.GetFieldName( ExamcenterNameFN) ].ToString();
 results.Add(myEngCertificate_ExamCenter);
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
public int UpdateEngCertificate_ExamCenter(InitializeModule.EnumCampus Campus, int iMode,int ExamCenterID,string ExamcenterName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EngCertificate_ExamCenter theEngCertificate_ExamCenter = new EngCertificate_ExamCenter();
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
Cmd.Parameters.Add(new SqlParameter("@ExamCenterID",ExamCenterID));
Cmd.Parameters.Add(new SqlParameter("@ExamcenterName",ExamcenterName));
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
public int DeleteEngCertificate_ExamCenter(InitializeModule.EnumCampus Campus,string ExamCenterID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@ExamCenterID", ExamCenterID ));
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
DataTable dt = new DataTable("EngCertificate_ExamCenter");
DataView dv = new DataView();
List<EngCertificate_ExamCenter> myEngCertificate_ExamCenters = new List<EngCertificate_ExamCenter>();
try
{
myEngCertificate_ExamCenters = GetEngCertificate_ExamCenter(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("ExamCenterID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myEngCertificate_ExamCenters.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myEngCertificate_ExamCenters[i].ExamCenterID;
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
myEngCertificate_ExamCenters.Clear();
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
sSQL += ExamCenterIDFN;
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
public class EngCertificate_ExamCenterCls : EngCertificate_ExamCenterDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daEngCertificate_ExamCenter;
private DataSet m_dsEngCertificate_ExamCenter;
public DataRow EngCertificate_ExamCenterDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsEngCertificate_ExamCenter
{
get { return m_dsEngCertificate_ExamCenter ; }
set { m_dsEngCertificate_ExamCenter = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EngCertificate_ExamCenterCls()
{
try
{
dsEngCertificate_ExamCenter= new DataSet();

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
public virtual SqlDataAdapter GetEngCertificate_ExamCenterDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daEngCertificate_ExamCenter = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daEngCertificate_ExamCenter);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daEngCertificate_ExamCenter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEngCertificate_ExamCenter;
}
public virtual SqlDataAdapter GetEngCertificate_ExamCenterDataAdapter(SqlConnection con)  
{
try
{
daEngCertificate_ExamCenter = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daEngCertificate_ExamCenter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdEngCertificate_ExamCenter;
cmdEngCertificate_ExamCenter = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@ExamCenterID", SqlDbType.Int, 4, "ExamCenterID" );
daEngCertificate_ExamCenter.SelectCommand = cmdEngCertificate_ExamCenter;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdEngCertificate_ExamCenter = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdEngCertificate_ExamCenter.Parameters.Add("@ExamCenterID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExamCenterIDFN));
cmdEngCertificate_ExamCenter.Parameters.Add("@ExamcenterName", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(ExamcenterNameFN));


Parmeter = cmdEngCertificate_ExamCenter.Parameters.Add("@ExamCenterID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExamCenterIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daEngCertificate_ExamCenter.UpdateCommand = cmdEngCertificate_ExamCenter;
daEngCertificate_ExamCenter.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdEngCertificate_ExamCenter = new SqlCommand(GetInsertCommand(), con);
cmdEngCertificate_ExamCenter.Parameters.Add("@ExamCenterID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExamCenterIDFN));
cmdEngCertificate_ExamCenter.Parameters.Add("@ExamcenterName", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(ExamcenterNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daEngCertificate_ExamCenter.InsertCommand =cmdEngCertificate_ExamCenter;
daEngCertificate_ExamCenter.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdEngCertificate_ExamCenter = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdEngCertificate_ExamCenter.Parameters.Add("@ExamCenterID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExamCenterIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daEngCertificate_ExamCenter.DeleteCommand =cmdEngCertificate_ExamCenter;
daEngCertificate_ExamCenter.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daEngCertificate_ExamCenter.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEngCertificate_ExamCenter;
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
dr = dsEngCertificate_ExamCenter.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(ExamCenterIDFN)]=ExamCenterID;
dr[LibraryMOD.GetFieldName(ExamcenterNameFN)]=ExamcenterName;
dsEngCertificate_ExamCenter.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsEngCertificate_ExamCenter.Tables[TableName].Select(LibraryMOD.GetFieldName(ExamCenterIDFN)  + "=" + ExamCenterID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(ExamCenterIDFN)]=ExamCenterID;
drAry[0][LibraryMOD.GetFieldName(ExamcenterNameFN)]=ExamcenterName;
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
public int CommitEngCertificate_ExamCenter()  
{
//CommitEngCertificate_ExamCenter= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daEngCertificate_ExamCenter.Update(dsEngCertificate_ExamCenter, TableName);
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
FindInMultiPKey(ExamCenterID);
if (( EngCertificate_ExamCenterDataRow != null)) 
{
EngCertificate_ExamCenterDataRow.Delete();
CommitEngCertificate_ExamCenter();
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
if (EngCertificate_ExamCenterDataRow[LibraryMOD.GetFieldName(ExamCenterIDFN)]== System.DBNull.Value)
{
  ExamCenterID=0;
}
else
{
  ExamCenterID = (int)EngCertificate_ExamCenterDataRow[LibraryMOD.GetFieldName(ExamCenterIDFN)];
}
if (EngCertificate_ExamCenterDataRow[LibraryMOD.GetFieldName(ExamcenterNameFN)]== System.DBNull.Value)
{
  ExamcenterName="";
}
else
{
  ExamcenterName = (string)EngCertificate_ExamCenterDataRow[LibraryMOD.GetFieldName(ExamcenterNameFN)];
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
public int FindInMultiPKey(int PKExamCenterID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKExamCenterID;
EngCertificate_ExamCenterDataRow = dsEngCertificate_ExamCenter.Tables[TableName].Rows.Find(findTheseVals);
if  ((EngCertificate_ExamCenterDataRow !=null)) 
{
lngCurRow = dsEngCertificate_ExamCenter.Tables[TableName].Rows.IndexOf(EngCertificate_ExamCenterDataRow);
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
  lngCurRow = dsEngCertificate_ExamCenter.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsEngCertificate_ExamCenter.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsEngCertificate_ExamCenter.Tables[TableName].Rows.Count > 0) 
{
  EngCertificate_ExamCenterDataRow = dsEngCertificate_ExamCenter.Tables[TableName].Rows[lngCurRow];
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
daEngCertificate_ExamCenter.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEngCertificate_ExamCenter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daEngCertificate_ExamCenter.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEngCertificate_ExamCenter.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
