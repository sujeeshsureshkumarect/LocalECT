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
public class Majors_Proiorities
{
//Creation Date: 03/05/2010 12:04 PM
//Programmer Name : Bahaa Addin Ghaleb Najem
//-----Decleration --------------
#region "Decleration"
private int m_lngSerial; 
private string m_strMajor; 
private int m_byteOrder; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int lngSerial
{
get { return  m_lngSerial; }
set {m_lngSerial  = value ; }
}
public string strMajor
{
get { return  m_strMajor; }
set {m_strMajor  = value ; }
}
public int byteOrder
{
get { return  m_byteOrder; }
set {m_byteOrder  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Majors_Proiorities()
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
public class Majors_ProioritiesDAL : Majors_Proiorities
{
#region "Decleration"
private string m_TableName;
private string m_lngSerialFN ;
private string m_strMajorFN ;
private string m_byteOrderFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string lngSerialFN 
{
get { return  m_lngSerialFN; }
set {m_lngSerialFN  = value ; }
}
public string strMajorFN 
{
get { return  m_strMajorFN; }
set {m_strMajorFN  = value ; }
}
public string byteOrderFN 
{
get { return  m_byteOrderFN; }
set {m_byteOrderFN  = value ; }
}
#endregion
//================End Properties ===================
public Majors_ProioritiesDAL()
{
try
{
this.TableName = "Reg_Majors_Proiorities";
this.lngSerialFN = m_TableName + ".lngSerial";
this.strMajorFN = m_TableName + ".strMajor";
this.byteOrderFN = m_TableName + ".byteOrder";
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
sSQL +=lngSerialFN;
sSQL += " , " + strMajorFN;
sSQL += " , " + byteOrderFN;
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
sSQL +=lngSerialFN;
sSQL += " , " + strMajorFN;
sSQL += " , " + byteOrderFN;
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
sSQL += LibraryMOD.GetFieldName(lngSerialFN) + "=@lngSerial";
sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN) + "=@strMajor";
sSQL += " , " + LibraryMOD.GetFieldName(byteOrderFN) + "=@byteOrder";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(lngSerialFN)+"=@lngSerial";
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
sSQL +=LibraryMOD.GetFieldName(lngSerialFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteOrderFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @lngSerial";
sSQL += " ,@strMajor";
sSQL += " ,@byteOrder";
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
sSQL += LibraryMOD.GetFieldName(lngSerialFN)+"=@lngSerial";
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
public List< Majors_Proiorities> GetMajors_Proiorities(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Majors_Proiorities
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
List<Majors_Proiorities> results = new List<Majors_Proiorities>();
try
{
//Default Value
Majors_Proiorities myMajors_Proiorities = new Majors_Proiorities();
if (isDeafaultIncluded)
{
//Change the code here
myMajors_Proiorities.lngSerial = 0;
myMajors_Proiorities.strMajor = "Select Majors_Proiorities ...";
results.Add(myMajors_Proiorities);
}
while (reader.Read())
{
myMajors_Proiorities = new Majors_Proiorities();
if (reader[LibraryMOD.GetFieldName(lngSerialFN)].Equals(DBNull.Value))
{
myMajors_Proiorities.lngSerial = 0;
}
else
{
myMajors_Proiorities.lngSerial = int.Parse(reader[LibraryMOD.GetFieldName( lngSerialFN) ].ToString());
}
myMajors_Proiorities.strMajor =reader[LibraryMOD.GetFieldName( strMajorFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteOrderFN)].Equals(DBNull.Value))
{
myMajors_Proiorities.byteOrder = 0;
}
else
{
myMajors_Proiorities.byteOrder = int.Parse(reader[LibraryMOD.GetFieldName( byteOrderFN) ].ToString());
}
 results.Add(myMajors_Proiorities);
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
public int UpdateMajors_Proiorities(InitializeModule.EnumCampus Campus, int iMode,int lngSerial,string strMajor,int byteOrder)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Majors_Proiorities theMajors_Proiorities = new Majors_Proiorities();
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
Cmd.Parameters.Add(new SqlParameter("@lngSerial",lngSerial));
Cmd.Parameters.Add(new SqlParameter("@strMajor",strMajor));
Cmd.Parameters.Add(new SqlParameter("@byteOrder",byteOrder));
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
public int DeleteMajors_Proiorities(InitializeModule.EnumCampus Campus,int lngSerial)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@lngSerial", lngSerial ));
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
DataTable dt = new DataTable("Majors_Proiorities");
DataView dv = new DataView();
List<Majors_Proiorities> myMajors_Proioritiess = new List<Majors_Proiorities>();
try
{
myMajors_Proioritiess = GetMajors_Proiorities(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("lngSerial", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strMajor", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("byteOrder", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myMajors_Proioritiess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myMajors_Proioritiess[i].lngSerial;
  dr[2] = myMajors_Proioritiess[i].strMajor;
  dr[3] = myMajors_Proioritiess[i].byteOrder;
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
myMajors_Proioritiess.Clear();
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
sSQL += lngSerialFN;
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
public class Majors_ProioritiesCls : Majors_ProioritiesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daMajors_Proiorities;
private DataSet m_dsMajors_Proiorities;
public DataRow Majors_ProioritiesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsMajors_Proiorities
{
get { return m_dsMajors_Proiorities ; }
set { m_dsMajors_Proiorities = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Majors_ProioritiesCls()
{
try
{
dsMajors_Proiorities= new DataSet();

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
public virtual SqlDataAdapter GetMajors_ProioritiesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daMajors_Proiorities = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daMajors_Proiorities);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daMajors_Proiorities.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daMajors_Proiorities;
}
public virtual SqlDataAdapter GetMajors_ProioritiesDataAdapter(SqlConnection con)  
{
try
{
daMajors_Proiorities = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daMajors_Proiorities.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdMajors_Proiorities;
cmdMajors_Proiorities = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@lngSerial", SqlDbType.Int, 4, "lngSerial" );
daMajors_Proiorities.SelectCommand = cmdMajors_Proiorities;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdMajors_Proiorities = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdMajors_Proiorities.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
cmdMajors_Proiorities.Parameters.Add("@strMajor", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strMajorFN));
cmdMajors_Proiorities.Parameters.Add("@byteOrder", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteOrderFN));


Parmeter = cmdMajors_Proiorities.Parameters.Add("@lngSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngSerialFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daMajors_Proiorities.UpdateCommand = cmdMajors_Proiorities;
daMajors_Proiorities.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdMajors_Proiorities = new SqlCommand(GetInsertCommand(), con);
cmdMajors_Proiorities.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
cmdMajors_Proiorities.Parameters.Add("@strMajor", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strMajorFN));
cmdMajors_Proiorities.Parameters.Add("@byteOrder", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteOrderFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daMajors_Proiorities.InsertCommand =cmdMajors_Proiorities;
daMajors_Proiorities.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdMajors_Proiorities = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdMajors_Proiorities.Parameters.Add("@lngSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngSerialFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daMajors_Proiorities.DeleteCommand =cmdMajors_Proiorities;
daMajors_Proiorities.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daMajors_Proiorities.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daMajors_Proiorities;
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
dr = dsMajors_Proiorities.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
dr[LibraryMOD.GetFieldName(strMajorFN)]=strMajor;
dr[LibraryMOD.GetFieldName(byteOrderFN)]=byteOrder;
dsMajors_Proiorities.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsMajors_Proiorities.Tables[TableName].Select(LibraryMOD.GetFieldName(lngSerialFN)  + "=" + lngSerial);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
drAry[0][LibraryMOD.GetFieldName(strMajorFN)]=strMajor;
drAry[0][LibraryMOD.GetFieldName(byteOrderFN)]=byteOrder;
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
public int CommitMajors_Proiorities()  
{
//CommitMajors_Proiorities= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daMajors_Proiorities.Update(dsMajors_Proiorities, TableName);
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
FindInMultiPKey(lngSerial);
if (( Majors_ProioritiesDataRow != null)) 
{
Majors_ProioritiesDataRow.Delete();
CommitMajors_Proiorities();
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
if (Majors_ProioritiesDataRow[LibraryMOD.GetFieldName(lngSerialFN)]== System.DBNull.Value)
{
  lngSerial=0;
}
else
{
  lngSerial = (int)Majors_ProioritiesDataRow[LibraryMOD.GetFieldName(lngSerialFN)];
}
if (Majors_ProioritiesDataRow[LibraryMOD.GetFieldName(strMajorFN)]== System.DBNull.Value)
{
  strMajor="";
}
else
{
  strMajor = (string)Majors_ProioritiesDataRow[LibraryMOD.GetFieldName(strMajorFN)];
}
if (Majors_ProioritiesDataRow[LibraryMOD.GetFieldName(byteOrderFN)]== System.DBNull.Value)
{
  byteOrder=0;
}
else
{
  byteOrder = (int)Majors_ProioritiesDataRow[LibraryMOD.GetFieldName(byteOrderFN)];
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
public int FindInMultiPKey(int PKlngSerial) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKlngSerial;
Majors_ProioritiesDataRow = dsMajors_Proiorities.Tables[TableName].Rows.Find(findTheseVals);
if  ((Majors_ProioritiesDataRow !=null)) 
{
lngCurRow = dsMajors_Proiorities.Tables[TableName].Rows.IndexOf(Majors_ProioritiesDataRow);
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
  lngCurRow = dsMajors_Proiorities.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsMajors_Proiorities.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsMajors_Proiorities.Tables[TableName].Rows.Count > 0) 
{
  Majors_ProioritiesDataRow = dsMajors_Proiorities.Tables[TableName].Rows[lngCurRow];
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
daMajors_Proiorities.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daMajors_Proiorities.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daMajors_Proiorities.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daMajors_Proiorities.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
