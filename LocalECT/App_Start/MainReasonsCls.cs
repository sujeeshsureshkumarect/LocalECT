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
public class MainReasons
{
//Creation Date: 06/04/2010 7:20 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_byteMainReason; 
private string m_strMainReasonEn; 
private string m_strMainReasonAr; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int byteMainReason
{
get { return  m_byteMainReason; }
set {m_byteMainReason  = value ; }
}
public string strMainReasonEn
{
get { return  m_strMainReasonEn; }
set {m_strMainReasonEn  = value ; }
}
public string strMainReasonAr
{
get { return  m_strMainReasonAr; }
set {m_strMainReasonAr  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public MainReasons()
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
public class MainReasonsDAL : MainReasons
{
#region "Decleration"
private string m_TableName;
private string m_byteMainReasonFN ;
private string m_strMainReasonEnFN ;
private string m_strMainReasonArFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string byteMainReasonFN 
{
get { return  m_byteMainReasonFN; }
set {m_byteMainReasonFN  = value ; }
}
public string strMainReasonEnFN 
{
get { return  m_strMainReasonEnFN; }
set {m_strMainReasonEnFN  = value ; }
}
public string strMainReasonArFN 
{
get { return  m_strMainReasonArFN; }
set {m_strMainReasonArFN  = value ; }
}
#endregion
//================End Properties ===================
public MainReasonsDAL()
{
try
{
this.TableName = "Lkp_MainReasons";
this.byteMainReasonFN = m_TableName + ".byteMainReason";
this.strMainReasonEnFN = m_TableName + ".strMainReasonEn";
this.strMainReasonArFN = m_TableName + ".strMainReasonAr";
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
sSQL +=byteMainReasonFN;
sSQL += " , " + strMainReasonEnFN;
sSQL += " , " + strMainReasonArFN;
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
sSQL +=byteMainReasonFN;
sSQL += " , " + strMainReasonEnFN;
sSQL += " , " + strMainReasonArFN;
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
sSQL += LibraryMOD.GetFieldName(byteMainReasonFN) + "=@byteMainReason";
sSQL += " , " + LibraryMOD.GetFieldName(strMainReasonEnFN) + "=@strMainReasonEn";
sSQL += " , " + LibraryMOD.GetFieldName(strMainReasonArFN) + "=@strMainReasonAr";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(byteMainReasonFN)+"=@byteMainReason";
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
sSQL +=LibraryMOD.GetFieldName(byteMainReasonFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMainReasonEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMainReasonArFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @byteMainReason";
sSQL += " ,@strMainReasonEn";
sSQL += " ,@strMainReasonAr";
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
sSQL += LibraryMOD.GetFieldName(byteMainReasonFN)+"=@byteMainReason";
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
public List< MainReasons> GetMainReasons(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the MainReasons
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
List<MainReasons> results = new List<MainReasons>();
try
{
//Default Value
MainReasons myMainReasons = new MainReasons();
if (isDeafaultIncluded)
{
//Change the code here
myMainReasons.byteMainReason = 0;
myMainReasons.strMainReasonEn = "Select Main Reason ...";
results.Add(myMainReasons);
}
while (reader.Read())
{
myMainReasons = new MainReasons();
if (reader[LibraryMOD.GetFieldName(byteMainReasonFN)].Equals(DBNull.Value))
{
myMainReasons.byteMainReason = 0;
}
else
{
myMainReasons.byteMainReason = int.Parse(reader[LibraryMOD.GetFieldName( byteMainReasonFN) ].ToString());
}
myMainReasons.strMainReasonEn =reader[LibraryMOD.GetFieldName( strMainReasonEnFN) ].ToString();
myMainReasons.strMainReasonAr =reader[LibraryMOD.GetFieldName( strMainReasonArFN) ].ToString();
 results.Add(myMainReasons);
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
public int UpdateMainReasons(InitializeModule.EnumCampus Campus, int iMode,int byteMainReason,string strMainReasonEn,string strMainReasonAr)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
MainReasons theMainReasons = new MainReasons();
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
Cmd.Parameters.Add(new SqlParameter("@byteMainReason",byteMainReason));
Cmd.Parameters.Add(new SqlParameter("@strMainReasonEn",strMainReasonEn));
Cmd.Parameters.Add(new SqlParameter("@strMainReasonAr",strMainReasonAr));
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
public int DeleteMainReasons(InitializeModule.EnumCampus Campus,string byteMainReason)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@byteMainReason", byteMainReason ));
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
DataTable dt = new DataTable("MainReasons");
DataView dv = new DataView();
List<MainReasons> myMainReasonss = new List<MainReasons>();
try
{
myMainReasonss = GetMainReasons(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("byteMainReason", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strMainReasonEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strMainReasonAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myMainReasonss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myMainReasonss[i].byteMainReason;
  dr[2] = myMainReasonss[i].strMainReasonEn;
  dr[3] = myMainReasonss[i].strMainReasonAr;
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
myMainReasonss.Clear();
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
sSQL += byteMainReasonFN;
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
public class MainReasonsCls : MainReasonsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daMainReasons;
private DataSet m_dsMainReasons;
public DataRow MainReasonsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsMainReasons
{
get { return m_dsMainReasons ; }
set { m_dsMainReasons = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public MainReasonsCls()
{
try
{
dsMainReasons= new DataSet();

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
public virtual SqlDataAdapter GetMainReasonsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daMainReasons = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daMainReasons);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daMainReasons.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daMainReasons;
}
public virtual SqlDataAdapter GetMainReasonsDataAdapter(SqlConnection con)  
{
try
{
daMainReasons = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daMainReasons.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdMainReasons;
cmdMainReasons = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@byteMainReason", SqlDbType.Int, 4, "byteMainReason" );
daMainReasons.SelectCommand = cmdMainReasons;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdMainReasons = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdMainReasons.Parameters.Add("@byteMainReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMainReasonFN));
cmdMainReasons.Parameters.Add("@strMainReasonEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMainReasonEnFN));
cmdMainReasons.Parameters.Add("@strMainReasonAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMainReasonArFN));


Parmeter = cmdMainReasons.Parameters.Add("@byteMainReason", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteMainReasonFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daMainReasons.UpdateCommand = cmdMainReasons;
daMainReasons.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdMainReasons = new SqlCommand(GetInsertCommand(), con);
cmdMainReasons.Parameters.Add("@byteMainReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMainReasonFN));
cmdMainReasons.Parameters.Add("@strMainReasonEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMainReasonEnFN));
cmdMainReasons.Parameters.Add("@strMainReasonAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMainReasonArFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daMainReasons.InsertCommand =cmdMainReasons;
daMainReasons.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdMainReasons = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdMainReasons.Parameters.Add("@byteMainReason", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteMainReasonFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daMainReasons.DeleteCommand =cmdMainReasons;
daMainReasons.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daMainReasons.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daMainReasons;
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
dr = dsMainReasons.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(byteMainReasonFN)]=byteMainReason;
dr[LibraryMOD.GetFieldName(strMainReasonEnFN)]=strMainReasonEn;
dr[LibraryMOD.GetFieldName(strMainReasonArFN)]=strMainReasonAr;
dsMainReasons.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsMainReasons.Tables[TableName].Select(LibraryMOD.GetFieldName(byteMainReasonFN)  + "=" + byteMainReason);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(byteMainReasonFN)]=byteMainReason;
drAry[0][LibraryMOD.GetFieldName(strMainReasonEnFN)]=strMainReasonEn;
drAry[0][LibraryMOD.GetFieldName(strMainReasonArFN)]=strMainReasonAr;
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
public int CommitMainReasons()  
{
//CommitMainReasons= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daMainReasons.Update(dsMainReasons, TableName);
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
FindInMultiPKey(byteMainReason);
if (( MainReasonsDataRow != null)) 
{
MainReasonsDataRow.Delete();
CommitMainReasons();
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
if (MainReasonsDataRow[LibraryMOD.GetFieldName(byteMainReasonFN)]== System.DBNull.Value)
{
  byteMainReason=0;
}
else
{
  byteMainReason = (int)MainReasonsDataRow[LibraryMOD.GetFieldName(byteMainReasonFN)];
}
if (MainReasonsDataRow[LibraryMOD.GetFieldName(strMainReasonEnFN)]== System.DBNull.Value)
{
  strMainReasonEn="";
}
else
{
  strMainReasonEn = (string)MainReasonsDataRow[LibraryMOD.GetFieldName(strMainReasonEnFN)];
}
if (MainReasonsDataRow[LibraryMOD.GetFieldName(strMainReasonArFN)]== System.DBNull.Value)
{
  strMainReasonAr="";
}
else
{
  strMainReasonAr = (string)MainReasonsDataRow[LibraryMOD.GetFieldName(strMainReasonArFN)];
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
public int FindInMultiPKey(int PKbyteMainReason) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKbyteMainReason;
MainReasonsDataRow = dsMainReasons.Tables[TableName].Rows.Find(findTheseVals);
if  ((MainReasonsDataRow !=null)) 
{
lngCurRow = dsMainReasons.Tables[TableName].Rows.IndexOf(MainReasonsDataRow);
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
  lngCurRow = dsMainReasons.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsMainReasons.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsMainReasons.Tables[TableName].Rows.Count > 0) 
{
  MainReasonsDataRow = dsMainReasons.Tables[TableName].Rows[lngCurRow];
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
daMainReasons.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daMainReasons.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daMainReasons.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daMainReasons.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
