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
public class Delegations
{
//Creation Date: 05/04/2010 10:41 AM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_intDelegation; 
private string m_strDelegationDescEn; 
private string m_strDelegationDescAr; 
private string m_strAccount; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intDelegation
{
get { return  m_intDelegation; }
set {m_intDelegation  = value ; }
}
public string strDelegationDescEn
{
get { return  m_strDelegationDescEn; }
set {m_strDelegationDescEn  = value ; }
}
public string strDelegationDescAr
{
get { return  m_strDelegationDescAr; }
set {m_strDelegationDescAr  = value ; }
}
public string strAccount
{
get { return  m_strAccount; }
set {m_strAccount  = value ; }
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
public Delegations()
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
public class DelegationsDAL : Delegations
{
#region "Decleration"
private string m_TableName;
private string m_intDelegationFN ;
private string m_strDelegationDescEnFN ;
private string m_strDelegationDescArFN ;
private string m_strAccountFN ;
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
public string intDelegationFN 
{
get { return  m_intDelegationFN; }
set {m_intDelegationFN  = value ; }
}
public string strDelegationDescEnFN 
{
get { return  m_strDelegationDescEnFN; }
set {m_strDelegationDescEnFN  = value ; }
}
public string strDelegationDescArFN 
{
get { return  m_strDelegationDescArFN; }
set {m_strDelegationDescArFN  = value ; }
}
public string strAccountFN 
{
get { return  m_strAccountFN; }
set {m_strAccountFN  = value ; }
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
public DelegationsDAL()
{
try
{
this.TableName = "Lkp_Delegations";
this.intDelegationFN = m_TableName + ".intDelegation";
this.strDelegationDescEnFN = m_TableName + ".strDelegationDescEn";
this.strDelegationDescArFN = m_TableName + ".strDelegationDescAr";
this.strAccountFN = m_TableName + ".strAccount";
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
sSQL +=intDelegationFN;
sSQL += " , " + strDelegationDescEnFN;
sSQL += " , " + strDelegationDescArFN;
sSQL += " , " + strAccountFN;
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
sSQL +=intDelegationFN;
sSQL += " , " + strDelegationDescEnFN;
sSQL += " , " + strDelegationDescArFN;
sSQL += " , " + strAccountFN;
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
sSQL += LibraryMOD.GetFieldName(intDelegationFN) + "=@intDelegation";
sSQL += " , " + LibraryMOD.GetFieldName(strDelegationDescEnFN) + "=@strDelegationDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strDelegationDescArFN) + "=@strDelegationDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(strAccountFN) + "=@strAccount";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intDelegationFN)+"=@intDelegation";
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
sSQL +=LibraryMOD.GetFieldName(intDelegationFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDelegationDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDelegationDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(strAccountFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intDelegation";
sSQL += " ,@strDelegationDescEn";
sSQL += " ,@strDelegationDescAr";
sSQL += " ,@strAccount";
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
sSQL += LibraryMOD.GetFieldName(intDelegationFN)+"=@intDelegation";
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
public List< Delegations> GetDelegations(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Delegations
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
List<Delegations> results = new List<Delegations>();
try
{
//Default Value
Delegations myDelegations = new Delegations();
if (isDeafaultIncluded)
{
//Change the code here
myDelegations.intDelegation = 0;
myDelegations.strDelegationDescEn = "Select Delegation ...";
results.Add(myDelegations);
}
while (reader.Read())
{
myDelegations = new Delegations();
if (reader[LibraryMOD.GetFieldName(intDelegationFN)].Equals(DBNull.Value))
{
myDelegations.intDelegation = 0;
}
else
{
myDelegations.intDelegation = int.Parse(reader[LibraryMOD.GetFieldName( intDelegationFN) ].ToString());
}
myDelegations.strDelegationDescEn =reader[LibraryMOD.GetFieldName( strDelegationDescEnFN) ].ToString();
myDelegations.strDelegationDescAr =reader[LibraryMOD.GetFieldName( strDelegationDescArFN) ].ToString();
myDelegations.strAccount =reader[LibraryMOD.GetFieldName( strAccountFN) ].ToString();
myDelegations.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
    myDelegations.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
}
myDelegations.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
    myDelegations.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
}
myDelegations.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
myDelegations.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
results.Add(myDelegations);
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
public int UpdateDelegations(InitializeModule.EnumCampus Campus, int iMode,int intDelegation,string strDelegationDescEn,string strDelegationDescAr,string strAccount,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Delegations theDelegations = new Delegations();
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
Cmd.Parameters.Add(new SqlParameter("@intDelegation",intDelegation));
Cmd.Parameters.Add(new SqlParameter("@strDelegationDescEn",strDelegationDescEn));
Cmd.Parameters.Add(new SqlParameter("@strDelegationDescAr",strDelegationDescAr));
Cmd.Parameters.Add(new SqlParameter("@strAccount",strAccount));
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
public int DeleteDelegations(InitializeModule.EnumCampus Campus,string intDelegation)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intDelegation", intDelegation ));
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
DataTable dt = new DataTable("Delegations");
DataView dv = new DataView();
List<Delegations> myDelegationss = new List<Delegations>();
try
{
myDelegationss = GetDelegations(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intDelegation", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strDelegationDescEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strDelegationDescAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myDelegationss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myDelegationss[i].intDelegation;
  dr[2] = myDelegationss[i].strDelegationDescEn;
  dr[3] = myDelegationss[i].strDelegationDescAr;
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
myDelegationss.Clear();
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
sSQL += intDelegationFN;
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
public class DelegationsCls : DelegationsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daDelegations;
private DataSet m_dsDelegations;
public DataRow DelegationsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsDelegations
{
get { return m_dsDelegations ; }
set { m_dsDelegations = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public DelegationsCls()
{
try
{
dsDelegations= new DataSet();

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
public virtual SqlDataAdapter GetDelegationsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daDelegations = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daDelegations);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daDelegations.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDelegations;
}
public virtual SqlDataAdapter GetDelegationsDataAdapter(SqlConnection con)  
{
try
{
daDelegations = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daDelegations.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdDelegations;
cmdDelegations = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intDelegation", SqlDbType.Int, 4, "intDelegation" );
daDelegations.SelectCommand = cmdDelegations;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdDelegations = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdDelegations.Parameters.Add("@intDelegation", SqlDbType.Int,2, LibraryMOD.GetFieldName(intDelegationFN));
cmdDelegations.Parameters.Add("@strDelegationDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDelegationDescEnFN));
cmdDelegations.Parameters.Add("@strDelegationDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDelegationDescArFN));
cmdDelegations.Parameters.Add("@strAccount", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(strAccountFN));
cmdDelegations.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdDelegations.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdDelegations.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdDelegations.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdDelegations.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdDelegations.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdDelegations.Parameters.Add("@intDelegation", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intDelegationFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daDelegations.UpdateCommand = cmdDelegations;
daDelegations.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdDelegations = new SqlCommand(GetInsertCommand(), con);
cmdDelegations.Parameters.Add("@intDelegation", SqlDbType.Int,2, LibraryMOD.GetFieldName(intDelegationFN));
cmdDelegations.Parameters.Add("@strDelegationDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDelegationDescEnFN));
cmdDelegations.Parameters.Add("@strDelegationDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strDelegationDescArFN));
cmdDelegations.Parameters.Add("@strAccount", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(strAccountFN));
cmdDelegations.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdDelegations.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdDelegations.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdDelegations.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdDelegations.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdDelegations.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daDelegations.InsertCommand =cmdDelegations;
daDelegations.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdDelegations = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdDelegations.Parameters.Add("@intDelegation", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intDelegationFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daDelegations.DeleteCommand =cmdDelegations;
daDelegations.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daDelegations.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDelegations;
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
dr = dsDelegations.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intDelegationFN)]=intDelegation;
dr[LibraryMOD.GetFieldName(strDelegationDescEnFN)]=strDelegationDescEn;
dr[LibraryMOD.GetFieldName(strDelegationDescArFN)]=strDelegationDescAr;
dr[LibraryMOD.GetFieldName(strAccountFN)]=strAccount;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strMachineFN)] = ECTGlobalDll.InitializeModule.gPCName;
dr[LibraryMOD.GetFieldName(strNUserFN)] = ECTGlobalDll.InitializeModule.gNetUserName;

dsDelegations.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsDelegations.Tables[TableName].Select(LibraryMOD.GetFieldName(intDelegationFN)  + "=" + intDelegation);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intDelegationFN)]=intDelegation;
drAry[0][LibraryMOD.GetFieldName(strDelegationDescEnFN)]=strDelegationDescEn;
drAry[0][LibraryMOD.GetFieldName(strDelegationDescArFN)]=strDelegationDescAr;
drAry[0][LibraryMOD.GetFieldName(strAccountFN)]=strAccount;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = DateTime.Now;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = DateTime.Now;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = ECTGlobalDll.InitializeModule.gPCName;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
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
public int CommitDelegations()  
{
//CommitDelegations= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daDelegations.Update(dsDelegations, TableName);
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
FindInMultiPKey(intDelegation);
if (( DelegationsDataRow != null)) 
{
DelegationsDataRow.Delete();
CommitDelegations();
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
if (DelegationsDataRow[LibraryMOD.GetFieldName(intDelegationFN)]== System.DBNull.Value)
{
  intDelegation=0;
}
else
{
  intDelegation = (int)DelegationsDataRow[LibraryMOD.GetFieldName(intDelegationFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(strDelegationDescEnFN)]== System.DBNull.Value)
{
  strDelegationDescEn="";
}
else
{
  strDelegationDescEn = (string)DelegationsDataRow[LibraryMOD.GetFieldName(strDelegationDescEnFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(strDelegationDescArFN)]== System.DBNull.Value)
{
  strDelegationDescAr="";
}
else
{
  strDelegationDescAr = (string)DelegationsDataRow[LibraryMOD.GetFieldName(strDelegationDescArFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(strAccountFN)]== System.DBNull.Value)
{
  strAccount="";
}
else
{
  strAccount = (string)DelegationsDataRow[LibraryMOD.GetFieldName(strAccountFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)DelegationsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)DelegationsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)DelegationsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)DelegationsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)DelegationsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (DelegationsDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)DelegationsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKintDelegation) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintDelegation;
DelegationsDataRow = dsDelegations.Tables[TableName].Rows.Find(findTheseVals);
if  ((DelegationsDataRow !=null)) 
{
lngCurRow = dsDelegations.Tables[TableName].Rows.IndexOf(DelegationsDataRow);
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
  lngCurRow = dsDelegations.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsDelegations.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsDelegations.Tables[TableName].Rows.Count > 0) 
{
  DelegationsDataRow = dsDelegations.Tables[TableName].Rows[lngCurRow];
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
daDelegations.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDelegations.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daDelegations.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDelegations.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
