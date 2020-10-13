using System;
using System.Data;
using System.Configuration;
using System.Linq;
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
public class LibTransTypes
{
//Creation Date: 09/12/2010 10:34:08 AM
//Programmer Name : Hazem
//-----Decleration --------------
#region "Decleration"
private int m_TransTypeID; 
private string m_strTransTypeAr; 
private string m_strTransTypeEn; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int TransTypeID
{
get { return  m_TransTypeID; }
set {m_TransTypeID  = value ; }
}
public string strTransTypeAr
{
get { return  m_strTransTypeAr; }
set {m_strTransTypeAr  = value ; }
}
public string strTransTypeEn
{
get { return  m_strTransTypeEn; }
set {m_strTransTypeEn  = value ; }
}
public string strUserCreate
{
get { return  m_strUserCreate; }
set {m_strUserCreate  = value ; }
}
public DateTime dateCreate
{
get { return  m_dateCreate; }
set {m_dateCreate  = value ; }
}
public string strUserSave
{
get { return  m_strUserSave; }
set {m_strUserSave  = value ; }
}
public DateTime dateLastSave
{
get { return  m_dateLastSave; }
set {m_dateLastSave  = value ; }
}
public string strMachine
{
get { return  m_strMachine; }
set {m_strMachine  = value ; }
}
public string strNUser
{
get { return  m_strNUser; }
set {m_strNUser  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public LibTransTypes()
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
public class LibTransTypesDAL : LibTransTypes
{
#region "Decleration"
private string m_TableName;
private string m_TransTypeIDFN ;
private string m_strTransTypeArFN ;
private string m_strTransTypeEnFN ;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string TransTypeIDFN 
{
get { return  m_TransTypeIDFN; }
set {m_TransTypeIDFN  = value ; }
}
public string strTransTypeArFN 
{
get { return  m_strTransTypeArFN; }
set {m_strTransTypeArFN  = value ; }
}
public string strTransTypeEnFN 
{
get { return  m_strTransTypeEnFN; }
set {m_strTransTypeEnFN  = value ; }
}
public string strUserCreateFN 
{
get { return  m_strUserCreateFN; }
set {m_strUserCreateFN  = value ; }
}
public string dateCreateFN 
{
get { return  m_dateCreateFN; }
set {m_dateCreateFN  = value ; }
}
public string strUserSaveFN 
{
get { return  m_strUserSaveFN; }
set {m_strUserSaveFN  = value ; }
}
public string dateLastSaveFN 
{
get { return  m_dateLastSaveFN; }
set {m_dateLastSaveFN  = value ; }
}
public string strMachineFN 
{
get { return  m_strMachineFN; }
set {m_strMachineFN  = value ; }
}
public string strNUserFN 
{
get { return  m_strNUserFN; }
set {m_strNUserFN  = value ; }
}
#endregion
//================End Properties ===================
public LibTransTypesDAL()
{
try
{
this.TableName = "LibTransTypes";
this.TransTypeIDFN = m_TableName + ".TransTypeID";
this.strTransTypeArFN = m_TableName + ".strTransTypeAr";
this.strTransTypeEnFN = m_TableName + ".strTransTypeEn";
this.strUserCreateFN = m_TableName + ".strUserCreate";
this.dateCreateFN = m_TableName + ".dateCreate";
this.strUserSaveFN = m_TableName + ".strUserSave";
this.dateLastSaveFN = m_TableName + ".dateLastSave";
this.strMachineFN = m_TableName + ".strMachine";
this.strNUserFN = m_TableName + ".strNUser";
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
sSQL +=TransTypeIDFN;
sSQL += " , " + strTransTypeArFN;
sSQL += " , " + strTransTypeEnFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
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
sSQL +=TransTypeIDFN;
sSQL += " , " + strTransTypeArFN;
sSQL += " , " + strTransTypeEnFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
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
sSQL += LibraryMOD.GetFieldName(TransTypeIDFN) + "=@TransTypeID";
sSQL += " , " + LibraryMOD.GetFieldName(strTransTypeArFN) + "=@strTransTypeAr";
sSQL += " , " + LibraryMOD.GetFieldName(strTransTypeEnFN) + "=@strTransTypeEn";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(TransTypeIDFN)+"=@TransTypeID";
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
sSQL +=LibraryMOD.GetFieldName(TransTypeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(strTransTypeArFN);
sSQL += " , " + LibraryMOD.GetFieldName(strTransTypeEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @TransTypeID";
sSQL += " ,@strTransTypeAr";
sSQL += " ,@strTransTypeEn";
sSQL += " ,@strUserCreate";
sSQL += " ,@dateCreate";
sSQL += " ,@strUserSave";
sSQL += " ,@dateLastSave";
sSQL += " ,@strMachine";
sSQL += " ,@strNUser";
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
sSQL += LibraryMOD.GetFieldName(TransTypeIDFN)+"=@TransTypeID";
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
public List< LibTransTypes> GetLibTransTypes(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the LibTransTypes
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
List<LibTransTypes> results = new List<LibTransTypes>();
try
{
//Default Value
LibTransTypes myLibTransTypes = new LibTransTypes();
if (isDeafaultIncluded)
{
//Change the code here
myLibTransTypes.TransTypeID = 0;
myLibTransTypes.strTransTypeAr = "Select LibTransTypes ...";
results.Add(myLibTransTypes);
}
while (reader.Read())
{
myLibTransTypes = new LibTransTypes();
if (reader[LibraryMOD.GetFieldName(TransTypeIDFN)].Equals(DBNull.Value))
{
myLibTransTypes.TransTypeID = 0;
}
else
{
myLibTransTypes.TransTypeID = int.Parse(reader[LibraryMOD.GetFieldName( TransTypeIDFN) ].ToString());
}
myLibTransTypes.strTransTypeAr =reader[LibraryMOD.GetFieldName( strTransTypeArFN) ].ToString();
myLibTransTypes.strTransTypeEn =reader[LibraryMOD.GetFieldName( strTransTypeEnFN) ].ToString();
myLibTransTypes.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[dateCreateFN].Equals(DBNull.Value))
{
myLibTransTypes.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myLibTransTypes.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[dateLastSaveFN].Equals(DBNull.Value))
{
myLibTransTypes.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myLibTransTypes.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myLibTransTypes.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myLibTransTypes);
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
public int UpdateLibTransTypes(InitializeModule.EnumCampus Campus, int iMode,int TransTypeID,string strTransTypeAr,string strTransTypeEn,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
LibTransTypes theLibTransTypes = new LibTransTypes();
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
Cmd.Parameters.Add(new SqlParameter("@TransTypeID",TransTypeID));
Cmd.Parameters.Add(new SqlParameter("@strTransTypeAr",strTransTypeAr));
Cmd.Parameters.Add(new SqlParameter("@strTransTypeEn",strTransTypeEn));
Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));
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
public int DeleteLibTransTypes(InitializeModule.EnumCampus Campus,string TransTypeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@TransTypeID", TransTypeID ));
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
DataTable dt = new DataTable("LibTransTypes");
DataView dv = new DataView();
List<LibTransTypes> myLibTransTypess = new List<LibTransTypes>();
try
{
myLibTransTypess = GetLibTransTypes(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("TransTypeID", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strTransTypeAr", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strTransTypeEn", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myLibTransTypess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myLibTransTypess[i].TransTypeID;
  dr[2] = myLibTransTypess[i].strTransTypeAr;
  dr[3] = myLibTransTypess[i].strTransTypeEn;
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
myLibTransTypess.Clear();
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
sSQL += TransTypeIDFN;
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
public class LibTransTypesCls : LibTransTypesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daLibTransTypes;
private DataSet m_dsLibTransTypes;
public DataRow LibTransTypesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsLibTransTypes
{
get { return m_dsLibTransTypes ; }
set { m_dsLibTransTypes = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public LibTransTypesCls()
{
try
{
dsLibTransTypes= new DataSet();

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
public virtual SqlDataAdapter GetLibTransTypesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daLibTransTypes = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibTransTypes);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daLibTransTypes.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibTransTypes;
}
public virtual SqlDataAdapter GetLibTransTypesDataAdapter(SqlConnection con)  
{
try
{
daLibTransTypes = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daLibTransTypes.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdLibTransTypes;
cmdLibTransTypes = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@TransTypeID", SqlDbType.Int, 4, "TransTypeID" );
daLibTransTypes.SelectCommand = cmdLibTransTypes;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdLibTransTypes = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdLibTransTypes.Parameters.Add("@TransTypeID", SqlDbType.Int,2, LibraryMOD.GetFieldName(TransTypeIDFN));
cmdLibTransTypes.Parameters.Add("@strTransTypeAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strTransTypeArFN));
cmdLibTransTypes.Parameters.Add("@strTransTypeEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strTransTypeEnFN));
cmdLibTransTypes.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdLibTransTypes.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdLibTransTypes.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdLibTransTypes.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdLibTransTypes.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdLibTransTypes.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdLibTransTypes.Parameters.Add("@TransTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransTypeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daLibTransTypes.UpdateCommand = cmdLibTransTypes;
daLibTransTypes.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdLibTransTypes = new SqlCommand(GetInsertCommand(), con);
cmdLibTransTypes.Parameters.Add("@TransTypeID", SqlDbType.Int,2, LibraryMOD.GetFieldName(TransTypeIDFN));
cmdLibTransTypes.Parameters.Add("@strTransTypeAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strTransTypeArFN));
cmdLibTransTypes.Parameters.Add("@strTransTypeEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strTransTypeEnFN));
cmdLibTransTypes.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdLibTransTypes.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdLibTransTypes.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdLibTransTypes.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdLibTransTypes.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdLibTransTypes.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daLibTransTypes.InsertCommand =cmdLibTransTypes;
daLibTransTypes.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdLibTransTypes = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdLibTransTypes.Parameters.Add("@TransTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransTypeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daLibTransTypes.DeleteCommand =cmdLibTransTypes;
daLibTransTypes.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daLibTransTypes.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibTransTypes;
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
dr = dsLibTransTypes.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(TransTypeIDFN)]=TransTypeID;
dr[LibraryMOD.GetFieldName(strTransTypeArFN)]=strTransTypeAr;
dr[LibraryMOD.GetFieldName(strTransTypeEnFN)]=strTransTypeEn;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsLibTransTypes.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsLibTransTypes.Tables[TableName].Select(LibraryMOD.GetFieldName(TransTypeIDFN)  + "=" + TransTypeID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(TransTypeIDFN)]=TransTypeID;
drAry[0][LibraryMOD.GetFieldName(strTransTypeArFN)]=strTransTypeAr;
drAry[0][LibraryMOD.GetFieldName(strTransTypeEnFN)]=strTransTypeEn;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
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
public int CommitLibTransTypes()  
{
//CommitLibTransTypes= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daLibTransTypes.Update(dsLibTransTypes, TableName);
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
FindInMultiPKey(TransTypeID);
if (( LibTransTypesDataRow != null)) 
{
LibTransTypesDataRow.Delete();
CommitLibTransTypes();
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
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(TransTypeIDFN)]== System.DBNull.Value)
{
  TransTypeID=0;
}
else
{
  TransTypeID = (int)LibTransTypesDataRow[LibraryMOD.GetFieldName(TransTypeIDFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(strTransTypeArFN)]== System.DBNull.Value)
{
  strTransTypeAr="";
}
else
{
  strTransTypeAr = (string)LibTransTypesDataRow[LibraryMOD.GetFieldName(strTransTypeArFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(strTransTypeEnFN)]== System.DBNull.Value)
{
  strTransTypeEn="";
}
else
{
  strTransTypeEn = (string)LibTransTypesDataRow[LibraryMOD.GetFieldName(strTransTypeEnFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)LibTransTypesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)LibTransTypesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)LibTransTypesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)LibTransTypesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)LibTransTypesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (LibTransTypesDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)LibTransTypesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKTransTypeID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKTransTypeID;
LibTransTypesDataRow = dsLibTransTypes.Tables[TableName].Rows.Find(findTheseVals);
if  ((LibTransTypesDataRow !=null)) 
{
lngCurRow = dsLibTransTypes.Tables[TableName].Rows.IndexOf(LibTransTypesDataRow);
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
  lngCurRow = dsLibTransTypes.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsLibTransTypes.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsLibTransTypes.Tables[TableName].Rows.Count > 0) 
{
  LibTransTypesDataRow = dsLibTransTypes.Tables[TableName].Rows[lngCurRow];
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
daLibTransTypes.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibTransTypes.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daLibTransTypes.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibTransTypes.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
