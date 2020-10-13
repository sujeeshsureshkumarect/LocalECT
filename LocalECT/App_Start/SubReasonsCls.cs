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
public class SubReasons
{
//Creation Date: 06/04/2010 7:20 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_byteMainReason; 
private int m_byteSubReson; 
private string m_strSubReasonEn; 
private string m_strSubReasonAr; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int byteMainReason
{
get { return  m_byteMainReason; }
set {m_byteMainReason  = value ; }
}
public int byteSubReson
{
get { return  m_byteSubReson; }
set {m_byteSubReson  = value ; }
}
public string strSubReasonEn
{
get { return  m_strSubReasonEn; }
set {m_strSubReasonEn  = value ; }
}
public string strSubReasonAr
{
get { return  m_strSubReasonAr; }
set {m_strSubReasonAr  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public SubReasons()
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
public class SubReasonsDAL : SubReasons
{
#region "Decleration"
private string m_TableName;
private string m_byteMainReasonFN ;
private string m_byteSubResonFN ;
private string m_strSubReasonEnFN ;
private string m_strSubReasonArFN ;
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
public string byteSubResonFN 
{
get { return  m_byteSubResonFN; }
set {m_byteSubResonFN  = value ; }
}
public string strSubReasonEnFN 
{
get { return  m_strSubReasonEnFN; }
set {m_strSubReasonEnFN  = value ; }
}
public string strSubReasonArFN 
{
get { return  m_strSubReasonArFN; }
set {m_strSubReasonArFN  = value ; }
}
#endregion
//================End Properties ===================
public SubReasonsDAL()
{
try
{
this.TableName = "Lkp_SubReasons";
this.byteMainReasonFN = m_TableName + ".byteMainReason";
this.byteSubResonFN = m_TableName + ".byteSubReson";
this.strSubReasonEnFN = m_TableName + ".strSubReasonEn";
this.strSubReasonArFN = m_TableName + ".strSubReasonAr";
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
sSQL += " , " + byteSubResonFN;
sSQL += " , " + strSubReasonEnFN;
sSQL += " , " + strSubReasonArFN;
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
sSQL += " , " + byteSubResonFN;
sSQL += " , " + strSubReasonEnFN;
sSQL += " , " + strSubReasonArFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(byteSubResonFN) + "=@byteSubReson";
sSQL += " , " + LibraryMOD.GetFieldName(strSubReasonEnFN) + "=@strSubReasonEn";
sSQL += " , " + LibraryMOD.GetFieldName(strSubReasonArFN) + "=@strSubReasonAr";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(byteMainReasonFN)+"=@byteMainReason";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteSubResonFN)+"=@byteSubReson";
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
sSQL += " , " + LibraryMOD.GetFieldName(byteSubResonFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSubReasonEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSubReasonArFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @byteMainReason";
sSQL += " ,@byteSubReson";
sSQL += " ,@strSubReasonEn";
sSQL += " ,@strSubReasonAr";
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
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteSubResonFN)+"=@byteSubReson";
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
public List< SubReasons> GetSubReasons(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the SubReasons
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
List<SubReasons> results = new List<SubReasons>();
try
{
//Default Value
SubReasons mySubReasons = new SubReasons();
if (isDeafaultIncluded)
{
//Change the code here
mySubReasons.byteMainReason = 0;
mySubReasons.byteSubReson = 0;
mySubReasons.strSubReasonEn = "Select SubReason ...";
results.Add(mySubReasons);
}
while (reader.Read())
{
mySubReasons = new SubReasons();
if (reader[LibraryMOD.GetFieldName(byteMainReasonFN)].Equals(DBNull.Value))
{
mySubReasons.byteMainReason = 0;
}
else
{
mySubReasons.byteMainReason = int.Parse(reader[LibraryMOD.GetFieldName( byteMainReasonFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSubResonFN)].Equals(DBNull.Value))
{
mySubReasons.byteSubReson = 0;
}
else
{
mySubReasons.byteSubReson = int.Parse(reader[LibraryMOD.GetFieldName( byteSubResonFN) ].ToString());
}
mySubReasons.strSubReasonEn =reader[LibraryMOD.GetFieldName( strSubReasonEnFN) ].ToString();
mySubReasons.strSubReasonAr =reader[LibraryMOD.GetFieldName( strSubReasonArFN) ].ToString();
 results.Add(mySubReasons);
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
public int UpdateSubReasons(InitializeModule.EnumCampus Campus, int iMode,int byteMainReason,int byteSubReson,string strSubReasonEn,string strSubReasonAr)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
SubReasons theSubReasons = new SubReasons();
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
Cmd.Parameters.Add(new SqlParameter("@byteSubReson",byteSubReson));
Cmd.Parameters.Add(new SqlParameter("@strSubReasonEn",strSubReasonEn));
Cmd.Parameters.Add(new SqlParameter("@strSubReasonAr",strSubReasonAr));
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
public int DeleteSubReasons(InitializeModule.EnumCampus Campus,string byteMainReason,string byteSubReson)
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
Cmd.Parameters.Add(new SqlParameter("@byteSubReson", byteSubReson ));
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
DataTable dt = new DataTable("SubReasons");
DataView dv = new DataView();
List<SubReasons> mySubReasonss = new List<SubReasons>();
try
{
mySubReasonss = GetSubReasons(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("byteMainReason", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSubReson", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strSubReasonEn", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < mySubReasonss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = mySubReasonss[i].byteMainReason;
  dr[2] = mySubReasonss[i].byteSubReson;
  dr[3] = mySubReasonss[i].strSubReasonEn;
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
mySubReasonss.Clear();
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
public class SubReasonsCls : SubReasonsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daSubReasons;
private DataSet m_dsSubReasons;
public DataRow SubReasonsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsSubReasons
{
get { return m_dsSubReasons ; }
set { m_dsSubReasons = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public SubReasonsCls()
{
try
{
dsSubReasons= new DataSet();

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
public virtual SqlDataAdapter GetSubReasonsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daSubReasons = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSubReasons);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daSubReasons.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSubReasons;
}
public virtual SqlDataAdapter GetSubReasonsDataAdapter(SqlConnection con)  
{
try
{
daSubReasons = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daSubReasons.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdSubReasons;
cmdSubReasons = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@byteMainReason", SqlDbType.Int, 4, "byteMainReason" );
//'cmdRolePermission.Parameters.Add("@byteSubReson", SqlDbType.Int, 4, "byteSubReson" );
daSubReasons.SelectCommand = cmdSubReasons;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdSubReasons = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdSubReasons.Parameters.Add("@byteMainReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMainReasonFN));
//cmdSubReasons.Parameters.Add("@byteSubReson", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSubResonFN));
cmdSubReasons.Parameters.Add("@strSubReasonEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSubReasonEnFN));
cmdSubReasons.Parameters.Add("@strSubReasonAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSubReasonArFN));


Parmeter = cmdSubReasons.Parameters.Add("@byteMainReason", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteMainReasonFN));
Parmeter = cmdSubReasons.Parameters.Add("@byteSubReson", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSubResonFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daSubReasons.UpdateCommand = cmdSubReasons;
daSubReasons.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdSubReasons = new SqlCommand(GetInsertCommand(), con);
cmdSubReasons.Parameters.Add("@byteMainReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMainReasonFN));
cmdSubReasons.Parameters.Add("@byteSubReson", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSubResonFN));
cmdSubReasons.Parameters.Add("@strSubReasonEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSubReasonEnFN));
cmdSubReasons.Parameters.Add("@strSubReasonAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSubReasonArFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daSubReasons.InsertCommand =cmdSubReasons;
daSubReasons.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdSubReasons = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdSubReasons.Parameters.Add("@byteMainReason", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteMainReasonFN));
Parmeter = cmdSubReasons.Parameters.Add("@byteSubReson", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSubResonFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daSubReasons.DeleteCommand =cmdSubReasons;
daSubReasons.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daSubReasons.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSubReasons;
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
dr = dsSubReasons.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(byteMainReasonFN)]=byteMainReason;
dr[LibraryMOD.GetFieldName(byteSubResonFN)]=byteSubReson;
dr[LibraryMOD.GetFieldName(strSubReasonEnFN)]=strSubReasonEn;
dr[LibraryMOD.GetFieldName(strSubReasonArFN)]=strSubReasonAr;
dsSubReasons.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsSubReasons.Tables[TableName].Select(LibraryMOD.GetFieldName(byteMainReasonFN)  + "=" + byteMainReason  + " AND " + LibraryMOD.GetFieldName(byteSubResonFN) + "=" + byteSubReson);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(byteMainReasonFN)]=byteMainReason;
drAry[0][LibraryMOD.GetFieldName(byteSubResonFN)]=byteSubReson;
drAry[0][LibraryMOD.GetFieldName(strSubReasonEnFN)]=strSubReasonEn;
drAry[0][LibraryMOD.GetFieldName(strSubReasonArFN)]=strSubReasonAr;
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
public int CommitSubReasons()  
{
//CommitSubReasons= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daSubReasons.Update(dsSubReasons, TableName);
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
FindInMultiPKey(byteMainReason,byteSubReson);
if (( SubReasonsDataRow != null)) 
{
SubReasonsDataRow.Delete();
CommitSubReasons();
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
if (SubReasonsDataRow[LibraryMOD.GetFieldName(byteMainReasonFN)]== System.DBNull.Value)
{
  byteMainReason=0;
}
else
{
  byteMainReason = (int)SubReasonsDataRow[LibraryMOD.GetFieldName(byteMainReasonFN)];
}
if (SubReasonsDataRow[LibraryMOD.GetFieldName(byteSubResonFN)]== System.DBNull.Value)
{
  byteSubReson=0;
}
else
{
  byteSubReson = (int)SubReasonsDataRow[LibraryMOD.GetFieldName(byteSubResonFN)];
}
if (SubReasonsDataRow[LibraryMOD.GetFieldName(strSubReasonEnFN)]== System.DBNull.Value)
{
  strSubReasonEn="";
}
else
{
  strSubReasonEn = (string)SubReasonsDataRow[LibraryMOD.GetFieldName(strSubReasonEnFN)];
}
if (SubReasonsDataRow[LibraryMOD.GetFieldName(strSubReasonArFN)]== System.DBNull.Value)
{
  strSubReasonAr="";
}
else
{
  strSubReasonAr = (string)SubReasonsDataRow[LibraryMOD.GetFieldName(strSubReasonArFN)];
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
public int FindInMultiPKey(int PKbyteMainReason,int PKbyteSubReson) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKbyteMainReason;
findTheseVals[1] = PKbyteSubReson;
SubReasonsDataRow = dsSubReasons.Tables[TableName].Rows.Find(findTheseVals);
if  ((SubReasonsDataRow !=null)) 
{
lngCurRow = dsSubReasons.Tables[TableName].Rows.IndexOf(SubReasonsDataRow);
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
  lngCurRow = dsSubReasons.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsSubReasons.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsSubReasons.Tables[TableName].Rows.Count > 0) 
{
  SubReasonsDataRow = dsSubReasons.Tables[TableName].Rows[lngCurRow];
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
daSubReasons.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSubReasons.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daSubReasons.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSubReasons.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
