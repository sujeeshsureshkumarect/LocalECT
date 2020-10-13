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
public class Currency
{
//Creation Date: 19/11/2014 4:52 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_CurrencyID; 
private string m_CurrencyDesc; 
private string m_MinCurrencyFrac; 
private string m_CurrencyAbb; 
private int m_CurrencyRound; 
private string m_StartRate; 
private string m_LastRate; 
private int m_LastRateDate; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int CurrencyID
{
get { return  m_CurrencyID; }
set {m_CurrencyID  = value ; }
}
public string CurrencyDesc
{
get { return  m_CurrencyDesc; }
set {m_CurrencyDesc  = value ; }
}
public string MinCurrencyFrac
{
get { return  m_MinCurrencyFrac; }
set {m_MinCurrencyFrac  = value ; }
}
public string CurrencyAbb
{
get { return  m_CurrencyAbb; }
set {m_CurrencyAbb  = value ; }
}
public int CurrencyRound
{
get { return  m_CurrencyRound; }
set {m_CurrencyRound  = value ; }
}
public string StartRate
{
get { return  m_StartRate; }
set {m_StartRate  = value ; }
}
public string LastRate
{
get { return  m_LastRate; }
set {m_LastRate  = value ; }
}
public int LastRateDate
{
get { return  m_LastRateDate; }
set {m_LastRateDate  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Currency()
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
public class CurrencyDAL : Currency
{
#region "Decleration"
private string m_TableName;
private string m_CurrencyIDFN ;
private string m_CurrencyDescFN ;
private string m_MinCurrencyFracFN ;
private string m_CurrencyAbbFN ;
private string m_CurrencyRoundFN ;
private string m_StartRateFN ;
private string m_LastRateFN ;
private string m_LastRateDateFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string CurrencyIDFN 
{
get { return  m_CurrencyIDFN; }
set {m_CurrencyIDFN  = value ; }
}
public string CurrencyDescFN 
{
get { return  m_CurrencyDescFN; }
set {m_CurrencyDescFN  = value ; }
}
public string MinCurrencyFracFN 
{
get { return  m_MinCurrencyFracFN; }
set {m_MinCurrencyFracFN  = value ; }
}
public string CurrencyAbbFN 
{
get { return  m_CurrencyAbbFN; }
set {m_CurrencyAbbFN  = value ; }
}
public string CurrencyRoundFN 
{
get { return  m_CurrencyRoundFN; }
set {m_CurrencyRoundFN  = value ; }
}
public string StartRateFN 
{
get { return  m_StartRateFN; }
set {m_StartRateFN  = value ; }
}
public string LastRateFN 
{
get { return  m_LastRateFN; }
set {m_LastRateFN  = value ; }
}
public string LastRateDateFN 
{
get { return  m_LastRateDateFN; }
set {m_LastRateDateFN  = value ; }
}
#endregion
//================End Properties ===================
public CurrencyDAL()
{
try
{
this.TableName = "Cmn_Currency";
this.CurrencyIDFN = m_TableName + ".CurrencyID";
this.CurrencyDescFN = m_TableName + ".CurrencyDesc";
this.MinCurrencyFracFN = m_TableName + ".MinCurrencyFrac";
this.CurrencyAbbFN = m_TableName + ".CurrencyAbb";
this.CurrencyRoundFN = m_TableName + ".CurrencyRound";
this.StartRateFN = m_TableName + ".StartRate";
this.LastRateFN = m_TableName + ".LastRate";
this.LastRateDateFN = m_TableName + ".LastRateDate";
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
sSQL +=CurrencyIDFN;
sSQL += " , " + CurrencyDescFN;
sSQL += " , " + MinCurrencyFracFN;
sSQL += " , " + CurrencyAbbFN;
sSQL += " , " + CurrencyRoundFN;
sSQL += " , " + StartRateFN;
sSQL += " , " + LastRateFN;
sSQL += " , " + LastRateDateFN;
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
    sSQL +=CurrencyIDFN;
    sSQL += " , " + CurrencyDescFN;
    sSQL += " , " + MinCurrencyFracFN;
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
sSQL +=CurrencyIDFN;
sSQL += " , " + CurrencyDescFN;
sSQL += " , " + MinCurrencyFracFN;
sSQL += " , " + CurrencyAbbFN;
sSQL += " , " + CurrencyRoundFN;
sSQL += " , " + StartRateFN;
sSQL += " , " + LastRateFN;
sSQL += " , " + LastRateDateFN;
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
sSQL += LibraryMOD.GetFieldName(CurrencyIDFN) + "=@CurrencyID";
sSQL += " , " + LibraryMOD.GetFieldName(CurrencyDescFN) + "=@CurrencyDesc";
sSQL += " , " + LibraryMOD.GetFieldName(MinCurrencyFracFN) + "=@MinCurrencyFrac";
sSQL += " , " + LibraryMOD.GetFieldName(CurrencyAbbFN) + "=@CurrencyAbb";
sSQL += " , " + LibraryMOD.GetFieldName(CurrencyRoundFN) + "=@CurrencyRound";
sSQL += " , " + LibraryMOD.GetFieldName(StartRateFN) + "=@StartRate";
sSQL += " , " + LibraryMOD.GetFieldName(LastRateFN) + "=@LastRate";
sSQL += " , " + LibraryMOD.GetFieldName(LastRateDateFN) + "=@LastRateDate";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(CurrencyIDFN)+"=@CurrencyID";
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
sSQL +=LibraryMOD.GetFieldName(CurrencyIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CurrencyDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(MinCurrencyFracFN);
sSQL += " , " + LibraryMOD.GetFieldName(CurrencyAbbFN);
sSQL += " , " + LibraryMOD.GetFieldName(CurrencyRoundFN);
sSQL += " , " + LibraryMOD.GetFieldName(StartRateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastRateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastRateDateFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @CurrencyID";
sSQL += " ,@CurrencyDesc";
sSQL += " ,@MinCurrencyFrac";
sSQL += " ,@CurrencyAbb";
sSQL += " ,@CurrencyRound";
sSQL += " ,@StartRate";
sSQL += " ,@LastRate";
sSQL += " ,@LastRateDate";
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
sSQL += LibraryMOD.GetFieldName(CurrencyIDFN)+"=@CurrencyID";
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
public List< Currency> GetCurrency(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Currency
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
List<Currency> results = new List<Currency>();
try
{
//Default Value
Currency myCurrency = new Currency();
if (isDeafaultIncluded)
{
//Change the code here
myCurrency.CurrencyID = 0;
myCurrency.CurrencyDesc  = "Select Currency ...";
results.Add(myCurrency);
}
while (reader.Read())
{
myCurrency = new Currency();
if (reader[LibraryMOD.GetFieldName(CurrencyIDFN)].Equals(DBNull.Value))
{
myCurrency.CurrencyID = 0;
}
else
{
myCurrency.CurrencyID = int.Parse(reader[LibraryMOD.GetFieldName( CurrencyIDFN) ].ToString());
}
myCurrency.CurrencyDesc =reader[LibraryMOD.GetFieldName( CurrencyDescFN) ].ToString();
myCurrency.MinCurrencyFrac =reader[LibraryMOD.GetFieldName( MinCurrencyFracFN) ].ToString();
myCurrency.CurrencyAbb =reader[LibraryMOD.GetFieldName( CurrencyAbbFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CurrencyRoundFN)].Equals(DBNull.Value))
{
myCurrency.CurrencyRound = 0;
}
else
{
myCurrency.CurrencyRound = int.Parse(reader[LibraryMOD.GetFieldName( CurrencyRoundFN) ].ToString());
}
myCurrency.StartRate =reader[LibraryMOD.GetFieldName( StartRateFN) ].ToString();
myCurrency.LastRate =reader[LibraryMOD.GetFieldName( LastRateFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(LastRateDateFN)].Equals(DBNull.Value))
{
myCurrency.LastRateDate = 0;
}
else
{
myCurrency.LastRateDate = int.Parse(reader[LibraryMOD.GetFieldName( LastRateDateFN) ].ToString());
}
 results.Add(myCurrency);
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
public List< Currency > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Currency> results = new List<Currency>();
try
{
//Default Value
Currency myCurrency= new Currency();
if (isDeafaultIncluded)
 {
//Change the code here
 myCurrency.CurrencyID = -1;
 myCurrency.CurrencyDesc = "Select Currency" ;
results.Add(myCurrency);
 }
while (reader.Read())
{
myCurrency = new Currency();
if (reader[LibraryMOD.GetFieldName(CurrencyIDFN)].Equals(DBNull.Value))
{
myCurrency.CurrencyID = 0;
}
else
{
myCurrency.CurrencyID = int.Parse(reader[LibraryMOD.GetFieldName( CurrencyIDFN) ].ToString());
}
myCurrency.CurrencyDesc =reader[LibraryMOD.GetFieldName( CurrencyDescFN) ].ToString();
myCurrency.MinCurrencyFrac =reader[LibraryMOD.GetFieldName( MinCurrencyFracFN) ].ToString();
 results.Add(myCurrency);
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
public int UpdateCurrency(InitializeModule.EnumCampus Campus, int iMode,int CurrencyID,string CurrencyDesc,string MinCurrencyFrac,string CurrencyAbb,int CurrencyRound,string StartRate,string LastRate,int LastRateDate)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Currency theCurrency = new Currency();
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
Cmd.Parameters.Add(new SqlParameter("@CurrencyID",CurrencyID));
Cmd.Parameters.Add(new SqlParameter("@CurrencyDesc",CurrencyDesc));
Cmd.Parameters.Add(new SqlParameter("@MinCurrencyFrac",MinCurrencyFrac));
Cmd.Parameters.Add(new SqlParameter("@CurrencyAbb",CurrencyAbb));
Cmd.Parameters.Add(new SqlParameter("@CurrencyRound",CurrencyRound));
Cmd.Parameters.Add(new SqlParameter("@StartRate",StartRate));
Cmd.Parameters.Add(new SqlParameter("@LastRate",LastRate));
Cmd.Parameters.Add(new SqlParameter("@LastRateDate",LastRateDate));
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
public int DeleteCurrency(InitializeModule.EnumCampus Campus,string CurrencyID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@CurrencyID", CurrencyID ));
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
DataTable dt = new DataTable("Currency");
DataView dv = new DataView();
List<Currency> myCurrencys = new List<Currency>();
try
{
myCurrencys = GetCurrency(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("CurrencyID", Type.GetType("int"));
dt.Columns.Add(col0 );

dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myCurrencys.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCurrencys[i].CurrencyID;
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
myCurrencys.Clear();
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
sSQL += CurrencyIDFN;
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
public class CurrencyCls : CurrencyDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daCurrency;
private DataSet m_dsCurrency;
public DataRow CurrencyDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsCurrency
{
get { return m_dsCurrency ; }
set { m_dsCurrency = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public CurrencyCls()
{
try
{
dsCurrency= new DataSet();

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
public virtual SqlDataAdapter GetCurrencyDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daCurrency = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCurrency);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daCurrency.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCurrency;
}
public virtual SqlDataAdapter GetCurrencyDataAdapter(SqlConnection con)  
{
try
{
daCurrency = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daCurrency.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdCurrency;
cmdCurrency = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@CurrencyID", SqlDbType.Int, 4, "CurrencyID" );
daCurrency.SelectCommand = cmdCurrency;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdCurrency = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdCurrency.Parameters.Add("@CurrencyID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CurrencyIDFN));
cmdCurrency.Parameters.Add("@CurrencyDesc", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(CurrencyDescFN));
cmdCurrency.Parameters.Add("@MinCurrencyFrac", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(MinCurrencyFracFN));
cmdCurrency.Parameters.Add("@CurrencyAbb", SqlDbType.NVarChar,6, LibraryMOD.GetFieldName(CurrencyAbbFN));
cmdCurrency.Parameters.Add("@CurrencyRound", SqlDbType.Int,4, LibraryMOD.GetFieldName(CurrencyRoundFN));
cmdCurrency.Parameters.Add("@StartRate", SqlDbType.Decimal,8, LibraryMOD.GetFieldName(StartRateFN));
cmdCurrency.Parameters.Add("@LastRate", SqlDbType.Decimal,8, LibraryMOD.GetFieldName(LastRateFN));
cmdCurrency.Parameters.Add("@LastRateDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastRateDateFN));


Parmeter = cmdCurrency.Parameters.Add("@CurrencyID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CurrencyIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daCurrency.UpdateCommand = cmdCurrency;
daCurrency.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdCurrency = new SqlCommand(GetInsertCommand(), con);
cmdCurrency.Parameters.Add("@CurrencyID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CurrencyIDFN));
cmdCurrency.Parameters.Add("@CurrencyDesc", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(CurrencyDescFN));
cmdCurrency.Parameters.Add("@MinCurrencyFrac", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(MinCurrencyFracFN));
cmdCurrency.Parameters.Add("@CurrencyAbb", SqlDbType.NVarChar,6, LibraryMOD.GetFieldName(CurrencyAbbFN));
cmdCurrency.Parameters.Add("@CurrencyRound", SqlDbType.Int,4, LibraryMOD.GetFieldName(CurrencyRoundFN));
cmdCurrency.Parameters.Add("@StartRate", SqlDbType.Decimal,8, LibraryMOD.GetFieldName(StartRateFN));
cmdCurrency.Parameters.Add("@LastRate", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(LastRateFN));
cmdCurrency.Parameters.Add("@LastRateDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastRateDateFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daCurrency.InsertCommand =cmdCurrency;
daCurrency.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdCurrency = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdCurrency.Parameters.Add("@CurrencyID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CurrencyIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daCurrency.DeleteCommand =cmdCurrency;
daCurrency.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daCurrency.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCurrency;
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
dr = dsCurrency.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(CurrencyIDFN)]=CurrencyID;
dr[LibraryMOD.GetFieldName(CurrencyDescFN)]=CurrencyDesc;
dr[LibraryMOD.GetFieldName(MinCurrencyFracFN)]=MinCurrencyFrac;
dr[LibraryMOD.GetFieldName(CurrencyAbbFN)]=CurrencyAbb;
dr[LibraryMOD.GetFieldName(CurrencyRoundFN)]=CurrencyRound;
dr[LibraryMOD.GetFieldName(StartRateFN)]=StartRate;
dr[LibraryMOD.GetFieldName(LastRateFN)]=LastRate;
dr[LibraryMOD.GetFieldName(LastRateDateFN)]=LastRateDate;
dsCurrency.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsCurrency.Tables[TableName].Select(LibraryMOD.GetFieldName(CurrencyIDFN)  + "=" + CurrencyID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(CurrencyIDFN)]=CurrencyID;
drAry[0][LibraryMOD.GetFieldName(CurrencyDescFN)]=CurrencyDesc;
drAry[0][LibraryMOD.GetFieldName(MinCurrencyFracFN)]=MinCurrencyFrac;
drAry[0][LibraryMOD.GetFieldName(CurrencyAbbFN)]=CurrencyAbb;
drAry[0][LibraryMOD.GetFieldName(CurrencyRoundFN)]=CurrencyRound;
drAry[0][LibraryMOD.GetFieldName(StartRateFN)]=StartRate;
drAry[0][LibraryMOD.GetFieldName(LastRateFN)]=LastRate;
drAry[0][LibraryMOD.GetFieldName(LastRateDateFN)]=LastRateDate;
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
public int CommitCurrency()  
{
//CommitCurrency= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daCurrency.Update(dsCurrency, TableName);
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
FindInMultiPKey(CurrencyID);
if (( CurrencyDataRow != null)) 
{
CurrencyDataRow.Delete();
CommitCurrency();
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
if (CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyIDFN)]== System.DBNull.Value)
{
  CurrencyID=0;
}
else
{
  CurrencyID = (int)CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyIDFN)];
}
if (CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyDescFN)]== System.DBNull.Value)
{
  CurrencyDesc="";
}
else
{
  CurrencyDesc = (string)CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyDescFN)];
}
if (CurrencyDataRow[LibraryMOD.GetFieldName(MinCurrencyFracFN)]== System.DBNull.Value)
{
  MinCurrencyFrac="";
}
else
{
  MinCurrencyFrac = (string)CurrencyDataRow[LibraryMOD.GetFieldName(MinCurrencyFracFN)];
}
if (CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyAbbFN)]== System.DBNull.Value)
{
  CurrencyAbb="";
}
else
{
  CurrencyAbb = (string)CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyAbbFN)];
}
if (CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyRoundFN)]== System.DBNull.Value)
{
  CurrencyRound=0;
}
else
{
  CurrencyRound = (int)CurrencyDataRow[LibraryMOD.GetFieldName(CurrencyRoundFN)];
}
if (CurrencyDataRow[LibraryMOD.GetFieldName(StartRateFN)]== System.DBNull.Value)
{
  StartRate="";
}
else
{
  StartRate = (string)CurrencyDataRow[LibraryMOD.GetFieldName(StartRateFN)];
}
if (CurrencyDataRow[LibraryMOD.GetFieldName(LastRateFN)]== System.DBNull.Value)
{
  LastRate="";
}
else
{
  LastRate = (string)CurrencyDataRow[LibraryMOD.GetFieldName(LastRateFN)];
}
if (CurrencyDataRow[LibraryMOD.GetFieldName(LastRateDateFN)]== System.DBNull.Value)
{
  LastRateDate=0;
}
else
{
  LastRateDate = (int)CurrencyDataRow[LibraryMOD.GetFieldName(LastRateDateFN)];
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
public int FindInMultiPKey(int PKCurrencyID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKCurrencyID;
CurrencyDataRow = dsCurrency.Tables[TableName].Rows.Find(findTheseVals);
if  ((CurrencyDataRow !=null)) 
{
lngCurRow = dsCurrency.Tables[TableName].Rows.IndexOf(CurrencyDataRow);
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
  lngCurRow = dsCurrency.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsCurrency.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsCurrency.Tables[TableName].Rows.Count > 0) 
{
  CurrencyDataRow = dsCurrency.Tables[TableName].Rows[lngCurRow];
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
daCurrency.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCurrency.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daCurrency.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCurrency.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
