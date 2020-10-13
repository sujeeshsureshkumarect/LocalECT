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
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Programs
{
//Creation Date: 06/04/2010 8:17 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private string m_strProgram; 
private string m_strDesc; 
private string m_strTag; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public string strProgram
{
get { return  m_strProgram; }
set {m_strProgram  = value ; }
}
public string strDesc
{
get { return  m_strDesc; }
set {m_strDesc  = value ; }
}
public string strTag
{
get { return  m_strTag; }
set {m_strTag  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Programs()
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
public class ProgramsDAL : Programs
{
#region "Decleration"
private string m_TableName;
private string m_strProgramFN ;
private string m_strDescFN ;
private string m_strTagFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string strProgramFN 
{
get { return  m_strProgramFN; }
set {m_strProgramFN  = value ; }
}
public string strDescFN 
{
get { return  m_strDescFN; }
set {m_strDescFN  = value ; }
}
public string strTagFN 
{
get { return  m_strTagFN; }
set {m_strTagFN  = value ; }
}
#endregion
//================End Properties ===================
public ProgramsDAL()
{
try
{
this.TableName = "Lkp_Programs";
this.strProgramFN = m_TableName + ".strProgram";
this.strDescFN = m_TableName + ".strDesc";
this.strTagFN = m_TableName + ".strTag";
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
sSQL +=strProgramFN;
sSQL += " , " + strDescFN;
sSQL += " , " + strTagFN;
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
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=strProgramFN;
sSQL += " , " + strDescFN;
sSQL += " , " + strTagFN;
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
sSQL += LibraryMOD.GetFieldName(strProgramFN) + "=@strProgram";
sSQL += " , " + LibraryMOD.GetFieldName(strDescFN) + "=@strDesc";
sSQL += " , " + LibraryMOD.GetFieldName(strTagFN) + "=@strTag";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(strProgramFN)+"=@strProgram";
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
sSQL +=LibraryMOD.GetFieldName(strProgramFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(strTagFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @strProgram";
sSQL += " ,@strDesc";
sSQL += " ,@strTag";
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
sSQL += LibraryMOD.GetFieldName(strProgramFN)+"=@strProgram";
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
public List< Programs> GetPrograms(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Programs
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
List<Programs> results = new List<Programs>();
try
{
//Default Value
Programs myPrograms = new Programs();
if (isDeafaultIncluded)
{
//Change the code here
myPrograms.strProgram = "0";
myPrograms.strDesc = "Select Program ...";
results.Add(myPrograms);
}
while (reader.Read())
{
myPrograms = new Programs();
myPrograms.strProgram =reader[LibraryMOD.GetFieldName( strProgramFN) ].ToString();
myPrograms.strDesc =reader[LibraryMOD.GetFieldName( strDescFN) ].ToString();
myPrograms.strTag =reader[LibraryMOD.GetFieldName( strTagFN) ].ToString();
 results.Add(myPrograms);
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
public int UpdatePrograms(InitializeModule.EnumCampus Campus, int iMode,string strProgram,string strDesc,string strTag)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Programs thePrograms = new Programs();
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
Cmd.Parameters.Add(new SqlParameter("@strProgram",strProgram));
Cmd.Parameters.Add(new SqlParameter("@strDesc",strDesc));
Cmd.Parameters.Add(new SqlParameter("@strTag",strTag));
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
public int DeletePrograms(InitializeModule.EnumCampus Campus,string strProgram)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@strProgram", strProgram ));
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
DataTable dt = new DataTable("Programs");
DataView dv = new DataView();
List<Programs> myProgramss = new List<Programs>();
try
{
myProgramss = GetPrograms(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("strProgram", Type.GetType("nvarchar"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strDesc", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strTag", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myProgramss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myProgramss[i].strProgram;
  dr[2] = myProgramss[i].strDesc;
  dr[3] = myProgramss[i].strTag;
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
myProgramss.Clear();
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
sSQL += strProgramFN;
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
public class ProgramsCls : ProgramsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daPrograms;
private DataSet m_dsPrograms;
public DataRow ProgramsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsPrograms
{
get { return m_dsPrograms ; }
set { m_dsPrograms = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public ProgramsCls()
{
try
{
dsPrograms= new DataSet();

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
public virtual SqlDataAdapter GetProgramsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daPrograms = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daPrograms);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daPrograms.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrograms;
}
public virtual SqlDataAdapter GetProgramsDataAdapter(SqlConnection con)  
{
try
{
daPrograms = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daPrograms.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdPrograms;
cmdPrograms = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@strProgram", SqlDbType.Int, 4, "strProgram" );
daPrograms.SelectCommand = cmdPrograms;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdPrograms = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdPrograms.Parameters.Add("@strProgram", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strProgramFN));
cmdPrograms.Parameters.Add("@strDesc", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strDescFN));
cmdPrograms.Parameters.Add("@strTag", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strTagFN));


Parmeter = cmdPrograms.Parameters.Add("@strProgram", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strProgramFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daPrograms.UpdateCommand = cmdPrograms;
daPrograms.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdPrograms = new SqlCommand(GetInsertCommand(), con);
cmdPrograms.Parameters.Add("@strProgram", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strProgramFN));
cmdPrograms.Parameters.Add("@strDesc", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strDescFN));
cmdPrograms.Parameters.Add("@strTag", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strTagFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daPrograms.InsertCommand =cmdPrograms;
daPrograms.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdPrograms = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdPrograms.Parameters.Add("@strProgram", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strProgramFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daPrograms.DeleteCommand =cmdPrograms;
daPrograms.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daPrograms.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrograms;
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
dr = dsPrograms.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(strProgramFN)]=strProgram;
dr[LibraryMOD.GetFieldName(strDescFN)]=strDesc;
dr[LibraryMOD.GetFieldName(strTagFN)]=strTag;

dsPrograms.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsPrograms.Tables[TableName].Select(LibraryMOD.GetFieldName(strProgramFN)  + "=" + strProgram);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(strProgramFN)]=strProgram;
drAry[0][LibraryMOD.GetFieldName(strDescFN)]=strDesc;
drAry[0][LibraryMOD.GetFieldName(strTagFN)]=strTag;
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
public int CommitPrograms()  
{
//CommitPrograms= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daPrograms.Update(dsPrograms, TableName);
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
FindInMultiPKey(strProgram);
if (( ProgramsDataRow != null)) 
{
ProgramsDataRow.Delete();
CommitPrograms();
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
if (ProgramsDataRow[LibraryMOD.GetFieldName(strProgramFN)]== System.DBNull.Value)
{
  strProgram="";
}
else
{
  strProgram = (string)ProgramsDataRow[LibraryMOD.GetFieldName(strProgramFN)];
}
if (ProgramsDataRow[LibraryMOD.GetFieldName(strDescFN)]== System.DBNull.Value)
{
  strDesc="";
}
else
{
  strDesc = (string)ProgramsDataRow[LibraryMOD.GetFieldName(strDescFN)];
}
if (ProgramsDataRow[LibraryMOD.GetFieldName(strTagFN)]== System.DBNull.Value)
{
  strTag="";
}
else
{
  strTag = (string)ProgramsDataRow[LibraryMOD.GetFieldName(strTagFN)];
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
public int FindInMultiPKey(string PKstrProgram) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKstrProgram;
ProgramsDataRow = dsPrograms.Tables[TableName].Rows.Find(findTheseVals);
if  ((ProgramsDataRow !=null)) 
{
lngCurRow = dsPrograms.Tables[TableName].Rows.IndexOf(ProgramsDataRow);
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
  lngCurRow = dsPrograms.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsPrograms.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsPrograms.Tables[TableName].Rows.Count > 0) 
{
  ProgramsDataRow = dsPrograms.Tables[TableName].Rows[lngCurRow];
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
daPrograms.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrograms.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daPrograms.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrograms.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
