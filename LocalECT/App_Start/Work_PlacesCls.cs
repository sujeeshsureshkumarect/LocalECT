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
public class Work_Places
{
//Creation Date: 05/04/2010 10:28 AM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_intWorkPlace; 
private string m_strWorkPlaceEn; 
private string m_strWorkPlaceAr; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intWorkPlace
{
get { return  m_intWorkPlace; }
set {m_intWorkPlace  = value ; }
}
public string strWorkPlaceEn
{
get { return  m_strWorkPlaceEn; }
set {m_strWorkPlaceEn  = value ; }
}
public string strWorkPlaceAr
{
get { return  m_strWorkPlaceAr; }
set {m_strWorkPlaceAr  = value ; }
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
public Work_Places()
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
public class Work_PlacesDAL : Work_Places
{
#region "Decleration"
private string m_TableName;
private string m_intWorkPlaceFN ;
private string m_strWorkPlaceEnFN ;
private string m_strWorkPlaceArFN ;
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
public string intWorkPlaceFN 
{
get { return  m_intWorkPlaceFN; }
set {m_intWorkPlaceFN  = value ; }
}
public string strWorkPlaceEnFN 
{
get { return  m_strWorkPlaceEnFN; }
set {m_strWorkPlaceEnFN  = value ; }
}
public string strWorkPlaceArFN 
{
get { return  m_strWorkPlaceArFN; }
set {m_strWorkPlaceArFN  = value ; }
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
public Work_PlacesDAL()
{
try
{
this.TableName = "Lkp_Work_Places";
this.intWorkPlaceFN = m_TableName + ".intWorkPlace";
this.strWorkPlaceEnFN = m_TableName + ".strWorkPlaceEn";
this.strWorkPlaceArFN = m_TableName + ".strWorkPlaceAr";
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
sSQL +=intWorkPlaceFN;
sSQL += " , " + strWorkPlaceEnFN;
sSQL += " , " + strWorkPlaceArFN;
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
sSQL +=intWorkPlaceFN;
sSQL += " , " + strWorkPlaceEnFN;
sSQL += " , " + strWorkPlaceArFN;
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
sSQL += LibraryMOD.GetFieldName(intWorkPlaceFN) + "=@intWorkPlace";
sSQL += " , " + LibraryMOD.GetFieldName(strWorkPlaceEnFN) + "=@strWorkPlaceEn";
sSQL += " , " + LibraryMOD.GetFieldName(strWorkPlaceArFN) + "=@strWorkPlaceAr";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intWorkPlaceFN)+"=@intWorkPlace";
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
sSQL +=LibraryMOD.GetFieldName(intWorkPlaceFN);
sSQL += " , " + LibraryMOD.GetFieldName(strWorkPlaceEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strWorkPlaceArFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intWorkPlace";
sSQL += " ,@strWorkPlaceEn";
sSQL += " ,@strWorkPlaceAr";
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
sSQL += LibraryMOD.GetFieldName(intWorkPlaceFN)+"=@intWorkPlace";
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
public List< Work_Places> GetWork_Places(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Work_Places
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
List<Work_Places> results = new List<Work_Places>();
try
{
//Default Value
Work_Places myWork_Places = new Work_Places();
if (isDeafaultIncluded)
{
//Change the code here
myWork_Places.intWorkPlace = 0;
myWork_Places.strWorkPlaceEn = "Select Work_Place ...";
results.Add(myWork_Places);
}
while (reader.Read())
{
myWork_Places = new Work_Places();
if (reader[LibraryMOD.GetFieldName(intWorkPlaceFN)].Equals(DBNull.Value))
{
myWork_Places.intWorkPlace = 0;
}
else
{
myWork_Places.intWorkPlace = int.Parse(reader[LibraryMOD.GetFieldName( intWorkPlaceFN) ].ToString());
}
myWork_Places.strWorkPlaceEn =reader[LibraryMOD.GetFieldName( strWorkPlaceEnFN) ].ToString();
myWork_Places.strWorkPlaceAr =reader[LibraryMOD.GetFieldName( strWorkPlaceArFN) ].ToString();
myWork_Places.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
    myWork_Places.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
}
myWork_Places.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
    myWork_Places.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
}
myWork_Places.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
myWork_Places.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
results.Add(myWork_Places);
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
public int UpdateWork_Places(InitializeModule.EnumCampus Campus, int iMode,int intWorkPlace,string strWorkPlaceEn,string strWorkPlaceAr,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Work_Places theWork_Places = new Work_Places();
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
Cmd.Parameters.Add(new SqlParameter("@intWorkPlace",intWorkPlace));
Cmd.Parameters.Add(new SqlParameter("@strWorkPlaceEn",strWorkPlaceEn));
Cmd.Parameters.Add(new SqlParameter("@strWorkPlaceAr",strWorkPlaceAr));
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
public int DeleteWork_Places(InitializeModule.EnumCampus Campus,string intWorkPlace)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intWorkPlace", intWorkPlace ));
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
DataTable dt = new DataTable("Work_Places");
DataView dv = new DataView();
List<Work_Places> myWork_Placess = new List<Work_Places>();
try
{
myWork_Placess = GetWork_Places(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intWorkPlace", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strWorkPlaceEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strWorkPlaceAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myWork_Placess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myWork_Placess[i].intWorkPlace;
  dr[2] = myWork_Placess[i].strWorkPlaceEn;
  dr[3] = myWork_Placess[i].strWorkPlaceAr;
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
myWork_Placess.Clear();
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
sSQL += intWorkPlaceFN;
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
public class Work_PlacesCls : Work_PlacesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daWork_Places;
private DataSet m_dsWork_Places;
public DataRow Work_PlacesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsWork_Places
{
get { return m_dsWork_Places ; }
set { m_dsWork_Places = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Work_PlacesCls()
{
try
{
dsWork_Places= new DataSet();

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
public virtual SqlDataAdapter GetWork_PlacesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daWork_Places = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daWork_Places);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daWork_Places.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daWork_Places;
}
public virtual SqlDataAdapter GetWork_PlacesDataAdapter(SqlConnection con)  
{
try
{
daWork_Places = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daWork_Places.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdWork_Places;
cmdWork_Places = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intWorkPlace", SqlDbType.Int, 4, "intWorkPlace" );
daWork_Places.SelectCommand = cmdWork_Places;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdWork_Places = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdWork_Places.Parameters.Add("@intWorkPlace", SqlDbType.Int,4, LibraryMOD.GetFieldName(intWorkPlaceFN));
cmdWork_Places.Parameters.Add("@strWorkPlaceEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strWorkPlaceEnFN));
cmdWork_Places.Parameters.Add("@strWorkPlaceAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strWorkPlaceArFN));
cmdWork_Places.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdWork_Places.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdWork_Places.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdWork_Places.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdWork_Places.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdWork_Places.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdWork_Places.Parameters.Add("@intWorkPlace", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intWorkPlaceFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daWork_Places.UpdateCommand = cmdWork_Places;
daWork_Places.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdWork_Places = new SqlCommand(GetInsertCommand(), con);
cmdWork_Places.Parameters.Add("@intWorkPlace", SqlDbType.Int,4, LibraryMOD.GetFieldName(intWorkPlaceFN));
cmdWork_Places.Parameters.Add("@strWorkPlaceEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strWorkPlaceEnFN));
cmdWork_Places.Parameters.Add("@strWorkPlaceAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strWorkPlaceArFN));
cmdWork_Places.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdWork_Places.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdWork_Places.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdWork_Places.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdWork_Places.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdWork_Places.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daWork_Places.InsertCommand =cmdWork_Places;
daWork_Places.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdWork_Places = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdWork_Places.Parameters.Add("@intWorkPlace", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intWorkPlaceFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daWork_Places.DeleteCommand =cmdWork_Places;
daWork_Places.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daWork_Places.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daWork_Places;
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
dr = dsWork_Places.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intWorkPlaceFN)]=intWorkPlace;
dr[LibraryMOD.GetFieldName(strWorkPlaceEnFN)]=strWorkPlaceEn;
dr[LibraryMOD.GetFieldName(strWorkPlaceArFN)]=strWorkPlaceAr;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strMachineFN)] = ECTGlobalDll.InitializeModule.gPCName;
dr[LibraryMOD.GetFieldName(strNUserFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
dsWork_Places.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsWork_Places.Tables[TableName].Select(LibraryMOD.GetFieldName(intWorkPlaceFN)  + "=" + intWorkPlace);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intWorkPlaceFN)]=intWorkPlace;
drAry[0][LibraryMOD.GetFieldName(strWorkPlaceEnFN)]=strWorkPlaceEn;
drAry[0][LibraryMOD.GetFieldName(strWorkPlaceArFN)]=strWorkPlaceAr;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = DateTime.Now;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
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
public int CommitWork_Places()  
{
//CommitWork_Places= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daWork_Places.Update(dsWork_Places, TableName);
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
FindInMultiPKey(intWorkPlace);
if (( Work_PlacesDataRow != null)) 
{
Work_PlacesDataRow.Delete();
CommitWork_Places();
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
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(intWorkPlaceFN)]== System.DBNull.Value)
{
  intWorkPlace=0;
}
else
{
  intWorkPlace = (int)Work_PlacesDataRow[LibraryMOD.GetFieldName(intWorkPlaceFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(strWorkPlaceEnFN)]== System.DBNull.Value)
{
  strWorkPlaceEn="";
}
else
{
  strWorkPlaceEn = (string)Work_PlacesDataRow[LibraryMOD.GetFieldName(strWorkPlaceEnFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(strWorkPlaceArFN)]== System.DBNull.Value)
{
  strWorkPlaceAr="";
}
else
{
  strWorkPlaceAr = (string)Work_PlacesDataRow[LibraryMOD.GetFieldName(strWorkPlaceArFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Work_PlacesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Work_PlacesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Work_PlacesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Work_PlacesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Work_PlacesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Work_PlacesDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Work_PlacesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKintWorkPlace) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintWorkPlace;
Work_PlacesDataRow = dsWork_Places.Tables[TableName].Rows.Find(findTheseVals);
if  ((Work_PlacesDataRow !=null)) 
{
lngCurRow = dsWork_Places.Tables[TableName].Rows.IndexOf(Work_PlacesDataRow);
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
  lngCurRow = dsWork_Places.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsWork_Places.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsWork_Places.Tables[TableName].Rows.Count > 0) 
{
  Work_PlacesDataRow = dsWork_Places.Tables[TableName].Rows[lngCurRow];
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
daWork_Places.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daWork_Places.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daWork_Places.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daWork_Places.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
