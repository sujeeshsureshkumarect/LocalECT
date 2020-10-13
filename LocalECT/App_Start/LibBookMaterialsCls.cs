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
public class LibBookMaterials
{
//Creation Date: 10/01/2011 3:34:42 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_BookID; 
private int m_MaterialTypeID; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int BookID
{
get { return  m_BookID; }
set {m_BookID  = value ; }
}
public int MaterialTypeID
{
get { return  m_MaterialTypeID; }
set {m_MaterialTypeID  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public LibBookMaterials()
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
public class LibBookMaterialsDAL : LibBookMaterials
{
#region "Decleration"
private string m_TableName;
private string m_BookIDFN ;
private string m_MaterialTypeIDFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string BookIDFN 
{
get { return  m_BookIDFN; }
set {m_BookIDFN  = value ; }
}
public string MaterialTypeIDFN 
{
get { return  m_MaterialTypeIDFN; }
set {m_MaterialTypeIDFN  = value ; }
}
#endregion
//================End Properties ===================
public LibBookMaterialsDAL()
{
try
{
this.TableName = "LibBookMaterials";
this.BookIDFN = m_TableName + ".BookID";
this.MaterialTypeIDFN = m_TableName + ".MaterialTypeID";
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
sSQL +=BookIDFN;
sSQL += " , " + MaterialTypeIDFN;
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
sSQL +=BookIDFN;
sSQL += " , " + MaterialTypeIDFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION;
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
sSQL +=BookIDFN;
sSQL += " , " + MaterialTypeIDFN;
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
sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
sSQL += " , " + LibraryMOD.GetFieldName(MaterialTypeIDFN) + "=@MaterialTypeID";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(BookIDFN)+"=@BookID";
sSQL +=  " And " + LibraryMOD.GetFieldName(MaterialTypeIDFN)+"=@MaterialTypeID";
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
sSQL +=LibraryMOD.GetFieldName(BookIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(MaterialTypeIDFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @BookID";
sSQL += " ,@MaterialTypeID";
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
sSQL += LibraryMOD.GetFieldName(BookIDFN)+"=@BookID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(MaterialTypeIDFN)+"=@MaterialTypeID";
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
public List< LibBookMaterials> GetLibBookMaterials(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the LibBookMaterials
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
List<LibBookMaterials> results = new List<LibBookMaterials>();
try
{
//Default Value
LibBookMaterials myLibBookMaterials = new LibBookMaterials();
if (isDeafaultIncluded)
{
//Change the code here
myLibBookMaterials.BookID = 0;
myLibBookMaterials.MaterialTypeID = 0;
results.Add(myLibBookMaterials);
}
while (reader.Read())
{
myLibBookMaterials = new LibBookMaterials();
if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
{
myLibBookMaterials.BookID = 0;
}
else
{
myLibBookMaterials.BookID = int.Parse(reader[LibraryMOD.GetFieldName( BookIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(MaterialTypeIDFN)].Equals(DBNull.Value))
{
myLibBookMaterials.MaterialTypeID = 0;
}
else
{
myLibBookMaterials.MaterialTypeID = int.Parse(reader[LibraryMOD.GetFieldName( MaterialTypeIDFN) ].ToString());
}
 results.Add(myLibBookMaterials);
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
public List< LibBookMaterials > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<LibBookMaterials> results = new List<LibBookMaterials>();
try
{
//Default Value
LibBookMaterials myLibBookMaterials= new LibBookMaterials();
if (isDeafaultIncluded)
 {
//Change the code here
 myLibBookMaterials.BookID = -1;
 myLibBookMaterials.MaterialTypeID = -1;
results.Add(myLibBookMaterials);
 }
while (reader.Read())
{
myLibBookMaterials = new LibBookMaterials();
if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
{
myLibBookMaterials.BookID = 0;
}
else
{
myLibBookMaterials.BookID = int.Parse(reader[LibraryMOD.GetFieldName( BookIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(MaterialTypeIDFN)].Equals(DBNull.Value))
{
myLibBookMaterials.MaterialTypeID = 0;
}
else
{
myLibBookMaterials.MaterialTypeID = int.Parse(reader[LibraryMOD.GetFieldName( MaterialTypeIDFN) ].ToString());
}
 results.Add(myLibBookMaterials);
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
public int UpdateLibBookMaterials(InitializeModule.EnumCampus Campus, int iMode,int BookID,int MaterialTypeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
LibBookMaterials theLibBookMaterials = new LibBookMaterials();
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
Cmd.Parameters.Add(new SqlParameter("@BookID",BookID));
Cmd.Parameters.Add(new SqlParameter("@MaterialTypeID",MaterialTypeID));
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
public int DeleteLibBookMaterials(InitializeModule.EnumCampus Campus,string BookID,string MaterialTypeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@BookID", BookID ));
Cmd.Parameters.Add(new SqlParameter("@MaterialTypeID", MaterialTypeID ));
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
DataTable dt = new DataTable("LibBookMaterials");
DataView dv = new DataView();
List<LibBookMaterials> myLibBookMaterialss = new List<LibBookMaterials>();
try
{
myLibBookMaterialss = GetLibBookMaterials(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("BookID", Type.GetType("int"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("MaterialTypeID", Type.GetType("int"));
dt.Columns.Add(col1 );
dt.Constraints.Add(new UniqueConstraint(col0));
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myLibBookMaterialss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myLibBookMaterialss[i].BookID;
  dr[2] = myLibBookMaterialss[i].MaterialTypeID;
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
myLibBookMaterialss.Clear();
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
sSQL += BookIDFN;
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
public class LibBookMaterialsCls : LibBookMaterialsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daLibBookMaterials;
private DataSet m_dsLibBookMaterials;
public DataRow LibBookMaterialsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsLibBookMaterials
{
get { return m_dsLibBookMaterials ; }
set { m_dsLibBookMaterials = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public LibBookMaterialsCls()
{
try
{
dsLibBookMaterials= new DataSet();

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
public virtual SqlDataAdapter GetLibBookMaterialsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daLibBookMaterials = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibBookMaterials);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daLibBookMaterials.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibBookMaterials;
}
public virtual SqlDataAdapter GetLibBookMaterialsDataAdapter(SqlConnection con)  
{
try
{
daLibBookMaterials = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daLibBookMaterials.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdLibBookMaterials;
cmdLibBookMaterials = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@BookID", SqlDbType.Int, 4, "BookID" );
//'cmdRolePermission.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, "MaterialTypeID" );
daLibBookMaterials.SelectCommand = cmdLibBookMaterials;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdLibBookMaterials = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdLibBookMaterials.Parameters.Add("@BookID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BookIDFN));
cmdLibBookMaterials.Parameters.Add("@MaterialTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MaterialTypeIDFN));


Parmeter = cmdLibBookMaterials.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
Parmeter = cmdLibBookMaterials.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaterialTypeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daLibBookMaterials.UpdateCommand = cmdLibBookMaterials;
daLibBookMaterials.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdLibBookMaterials = new SqlCommand(GetInsertCommand(), con);
cmdLibBookMaterials.Parameters.Add("@BookID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BookIDFN));
cmdLibBookMaterials.Parameters.Add("@MaterialTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MaterialTypeIDFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daLibBookMaterials.InsertCommand =cmdLibBookMaterials;
daLibBookMaterials.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdLibBookMaterials = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdLibBookMaterials.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
Parmeter = cmdLibBookMaterials.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaterialTypeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daLibBookMaterials.DeleteCommand =cmdLibBookMaterials;
daLibBookMaterials.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daLibBookMaterials.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibBookMaterials;
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
dr = dsLibBookMaterials.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(BookIDFN)]=BookID;
dr[LibraryMOD.GetFieldName(MaterialTypeIDFN)]=MaterialTypeID;
dsLibBookMaterials.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsLibBookMaterials.Tables[TableName].Select(LibraryMOD.GetFieldName(BookIDFN)  + "=" + BookID  + " AND " + LibraryMOD.GetFieldName(MaterialTypeIDFN) + "=" + MaterialTypeID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(BookIDFN)]=BookID;
drAry[0][LibraryMOD.GetFieldName(MaterialTypeIDFN)]=MaterialTypeID;
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
public int CommitLibBookMaterials()  
{
//CommitLibBookMaterials= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daLibBookMaterials.Update(dsLibBookMaterials, TableName);
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
FindInMultiPKey(BookID,MaterialTypeID);
if (( LibBookMaterialsDataRow != null)) 
{
LibBookMaterialsDataRow.Delete();
CommitLibBookMaterials();
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
if (LibBookMaterialsDataRow[LibraryMOD.GetFieldName(BookIDFN)]== System.DBNull.Value)
{
  BookID=0;
}
else
{
  BookID = (int)LibBookMaterialsDataRow[LibraryMOD.GetFieldName(BookIDFN)];
}
if (LibBookMaterialsDataRow[LibraryMOD.GetFieldName(MaterialTypeIDFN)]== System.DBNull.Value)
{
  MaterialTypeID=0;
}
else
{
  MaterialTypeID = (int)LibBookMaterialsDataRow[LibraryMOD.GetFieldName(MaterialTypeIDFN)];
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
public int FindInMultiPKey(int PKBookID,int PKMaterialTypeID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKBookID;
findTheseVals[1] = PKMaterialTypeID;
LibBookMaterialsDataRow = dsLibBookMaterials.Tables[TableName].Rows.Find(findTheseVals);
if  ((LibBookMaterialsDataRow !=null)) 
{
lngCurRow = dsLibBookMaterials.Tables[TableName].Rows.IndexOf(LibBookMaterialsDataRow);
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
  lngCurRow = dsLibBookMaterials.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsLibBookMaterials.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsLibBookMaterials.Tables[TableName].Rows.Count > 0) 
{
  LibBookMaterialsDataRow = dsLibBookMaterials.Tables[TableName].Rows[lngCurRow];
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
daLibBookMaterials.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibBookMaterials.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daLibBookMaterials.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibBookMaterials.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
