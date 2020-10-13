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
public class Faculty_Type
{
//Creation Date: 16/05/2019 4:38:08 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_iSerial; 
private string m_sFacultyType; 
private string m_sDesc; 
private string m_sCHDESCode; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int iSerial
{
get { return  m_iSerial; }
set {m_iSerial  = value ; }
}
public string sFacultyType
{
get { return  m_sFacultyType; }
set {m_sFacultyType  = value ; }
}
public string sDesc
{
get { return  m_sDesc; }
set {m_sDesc  = value ; }
}
public string sCHDESCode
{
get { return  m_sCHDESCode; }
set {m_sCHDESCode  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Faculty_Type()
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
public class Faculty_TypeDAL : Faculty_Type
{
#region "Decleration"
private string m_TableName;
private string m_iSerialFN ;
private string m_sFacultyTypeFN ;
private string m_sDescFN ;
private string m_sCHDESCodeFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string iSerialFN 
{
get { return  m_iSerialFN; }
set {m_iSerialFN  = value ; }
}
public string sFacultyTypeFN 
{
get { return  m_sFacultyTypeFN; }
set {m_sFacultyTypeFN  = value ; }
}
public string sDescFN 
{
get { return  m_sDescFN; }
set {m_sDescFN  = value ; }
}
public string sCHDESCodeFN 
{
get { return  m_sCHDESCodeFN; }
set {m_sCHDESCodeFN  = value ; }
}
#endregion
//================End Properties ===================
public Faculty_TypeDAL()
{
try
{
this.TableName = "Lkp_Faculty_Type";
this.iSerialFN = m_TableName + ".iSerial";
this.sFacultyTypeFN = m_TableName + ".sFacultyType";
this.sDescFN = m_TableName + ".sDesc";
this.sCHDESCodeFN = m_TableName + ".sCHDESCode";
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
sSQL +=iSerialFN;
sSQL += " , " + sFacultyTypeFN;
sSQL += " , " + sDescFN;
sSQL += " , " + sCHDESCodeFN;
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
sSQL +=iSerialFN;
sSQL += " , " + sFacultyTypeFN;
sSQL += " , " + sDescFN;
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
sSQL +=iSerialFN;
sSQL += " , " + sFacultyTypeFN;
sSQL += " , " + sDescFN;
sSQL += " , " + sCHDESCodeFN;
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
sSQL += LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
sSQL += " , " + LibraryMOD.GetFieldName(sFacultyTypeFN) + "=@sFacultyType";
sSQL += " , " + LibraryMOD.GetFieldName(sDescFN) + "=@sDesc";
sSQL += " , " + LibraryMOD.GetFieldName(sCHDESCodeFN) + "=@sCHDESCode";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(iSerialFN)+"=@iSerial";
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
sSQL +=LibraryMOD.GetFieldName(iSerialFN);
sSQL += " , " + LibraryMOD.GetFieldName(sFacultyTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(sDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(sCHDESCodeFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @iSerial";
sSQL += " ,@sFacultyType";
sSQL += " ,@sDesc";
sSQL += " ,@sCHDESCode";
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
sSQL += LibraryMOD.GetFieldName(iSerialFN)+"=@iSerial";
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
public List< Faculty_Type> GetFaculty_Type(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Faculty_Type
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
List<Faculty_Type> results = new List<Faculty_Type>();
try
{
//Default Value
Faculty_Type myFaculty_Type = new Faculty_Type();
if (isDeafaultIncluded)
{
//Change the code here
myFaculty_Type.iSerial = 0;
myFaculty_Type.sFacultyType  = "Select Faculty Type ...";
results.Add(myFaculty_Type);
}
while (reader.Read())
{
myFaculty_Type = new Faculty_Type();
if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
{
myFaculty_Type.iSerial = 0;
}
else
{
myFaculty_Type.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
}
myFaculty_Type.sFacultyType =reader[LibraryMOD.GetFieldName( sFacultyTypeFN) ].ToString();
myFaculty_Type.sDesc =reader[LibraryMOD.GetFieldName( sDescFN) ].ToString();
myFaculty_Type.sCHDESCode =reader[LibraryMOD.GetFieldName( sCHDESCodeFN) ].ToString();
 results.Add(myFaculty_Type);
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
public List< Faculty_Type > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Faculty_Type> results = new List<Faculty_Type>();
try
{
//Default Value
Faculty_Type myFaculty_Type= new Faculty_Type();
if (isDeafaultIncluded)
 {
//Change the code here
 myFaculty_Type.iSerial = -1;
 myFaculty_Type.sFacultyType = "Select Faculty_Type" ;
results.Add(myFaculty_Type);
 }
while (reader.Read())
{
myFaculty_Type = new Faculty_Type();
if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
{
myFaculty_Type.iSerial = 0;
}
else
{
myFaculty_Type.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
}
myFaculty_Type.sFacultyType =reader[LibraryMOD.GetFieldName( sFacultyTypeFN) ].ToString();
myFaculty_Type.sDesc =reader[LibraryMOD.GetFieldName( sDescFN) ].ToString();
 results.Add(myFaculty_Type);
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
public int UpdateFaculty_Type(InitializeModule.EnumCampus Campus, int iMode,int iSerial,string sFacultyType,string sDesc,string sCHDESCode)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Faculty_Type theFaculty_Type = new Faculty_Type();
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
Cmd.Parameters.Add(new SqlParameter("@iSerial",iSerial));
Cmd.Parameters.Add(new SqlParameter("@sFacultyType",sFacultyType));
Cmd.Parameters.Add(new SqlParameter("@sDesc",sDesc));
Cmd.Parameters.Add(new SqlParameter("@sCHDESCode",sCHDESCode));
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
public int DeleteFaculty_Type(InitializeModule.EnumCampus Campus,string iSerial)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@iSerial", iSerial ));
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
DataTable dt = new DataTable("Faculty_Type");
DataView dv = new DataView();
List<Faculty_Type> myFaculty_Types = new List<Faculty_Type>();
try
{
myFaculty_Types = GetFaculty_Type(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("iSerial", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myFaculty_Types.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myFaculty_Types[i].iSerial;
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
myFaculty_Types.Clear();
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
sSQL += iSerialFN;
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
public class Faculty_TypeCls : Faculty_TypeDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daFaculty_Type;
private DataSet m_dsFaculty_Type;
public DataRow Faculty_TypeDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsFaculty_Type
{
get { return m_dsFaculty_Type ; }
set { m_dsFaculty_Type = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Faculty_TypeCls()
{
try
{
dsFaculty_Type= new DataSet();

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
public virtual SqlDataAdapter GetFaculty_TypeDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daFaculty_Type = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daFaculty_Type);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daFaculty_Type.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFaculty_Type;
}
public virtual SqlDataAdapter GetFaculty_TypeDataAdapter(SqlConnection con)  
{
try
{
daFaculty_Type = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daFaculty_Type.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdFaculty_Type;
cmdFaculty_Type = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@iSerial", SqlDbType.Int, 4, "iSerial" );
daFaculty_Type.SelectCommand = cmdFaculty_Type;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdFaculty_Type = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdFaculty_Type.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
cmdFaculty_Type.Parameters.Add("@sFacultyType", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(sFacultyTypeFN));
cmdFaculty_Type.Parameters.Add("@sDesc", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(sDescFN));
cmdFaculty_Type.Parameters.Add("@sCHDESCode", SqlDbType.VarChar,1, LibraryMOD.GetFieldName(sCHDESCodeFN));


Parmeter = cmdFaculty_Type.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daFaculty_Type.UpdateCommand = cmdFaculty_Type;
daFaculty_Type.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdFaculty_Type = new SqlCommand(GetInsertCommand(), con);
cmdFaculty_Type.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
cmdFaculty_Type.Parameters.Add("@sFacultyType", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(sFacultyTypeFN));
cmdFaculty_Type.Parameters.Add("@sDesc", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(sDescFN));
cmdFaculty_Type.Parameters.Add("@sCHDESCode", SqlDbType.VarChar,1, LibraryMOD.GetFieldName(sCHDESCodeFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daFaculty_Type.InsertCommand =cmdFaculty_Type;
daFaculty_Type.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdFaculty_Type = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdFaculty_Type.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daFaculty_Type.DeleteCommand =cmdFaculty_Type;
daFaculty_Type.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daFaculty_Type.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFaculty_Type;
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
dr = dsFaculty_Type.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
dr[LibraryMOD.GetFieldName(sFacultyTypeFN)]=sFacultyType;
dr[LibraryMOD.GetFieldName(sDescFN)]=sDesc;
dr[LibraryMOD.GetFieldName(sCHDESCodeFN)]=sCHDESCode;
dsFaculty_Type.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsFaculty_Type.Tables[TableName].Select(LibraryMOD.GetFieldName(iSerialFN)  + "=" + iSerial);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
drAry[0][LibraryMOD.GetFieldName(sFacultyTypeFN)]=sFacultyType;
drAry[0][LibraryMOD.GetFieldName(sDescFN)]=sDesc;
drAry[0][LibraryMOD.GetFieldName(sCHDESCodeFN)]=sCHDESCode;
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
public int CommitFaculty_Type()  
{
//CommitFaculty_Type= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daFaculty_Type.Update(dsFaculty_Type, TableName);
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
FindInMultiPKey(iSerial);
if (( Faculty_TypeDataRow != null)) 
{
Faculty_TypeDataRow.Delete();
CommitFaculty_Type();
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
if (Faculty_TypeDataRow[LibraryMOD.GetFieldName(iSerialFN)]== System.DBNull.Value)
{
  iSerial=0;
}
else
{
  iSerial = (int)Faculty_TypeDataRow[LibraryMOD.GetFieldName(iSerialFN)];
}
if (Faculty_TypeDataRow[LibraryMOD.GetFieldName(sFacultyTypeFN)]== System.DBNull.Value)
{
  sFacultyType="";
}
else
{
  sFacultyType = (string)Faculty_TypeDataRow[LibraryMOD.GetFieldName(sFacultyTypeFN)];
}
if (Faculty_TypeDataRow[LibraryMOD.GetFieldName(sDescFN)]== System.DBNull.Value)
{
  sDesc="";
}
else
{
  sDesc = (string)Faculty_TypeDataRow[LibraryMOD.GetFieldName(sDescFN)];
}
if (Faculty_TypeDataRow[LibraryMOD.GetFieldName(sCHDESCodeFN)]== System.DBNull.Value)
{
  sCHDESCode="";
}
else
{
  sCHDESCode = (string)Faculty_TypeDataRow[LibraryMOD.GetFieldName(sCHDESCodeFN)];
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
public int FindInMultiPKey(int PKiSerial) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKiSerial;
Faculty_TypeDataRow = dsFaculty_Type.Tables[TableName].Rows.Find(findTheseVals);
if  ((Faculty_TypeDataRow !=null)) 
{
lngCurRow = dsFaculty_Type.Tables[TableName].Rows.IndexOf(Faculty_TypeDataRow);
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
  lngCurRow = dsFaculty_Type.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsFaculty_Type.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsFaculty_Type.Tables[TableName].Rows.Count > 0) 
{
  Faculty_TypeDataRow = dsFaculty_Type.Tables[TableName].Rows[lngCurRow];
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
daFaculty_Type.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFaculty_Type.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daFaculty_Type.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFaculty_Type.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
