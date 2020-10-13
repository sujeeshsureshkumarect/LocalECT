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
public class FinalExam_StudentSchedule_D
{
//Creation Date: 20/05/2014 6:58 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_iSerial; 
private string m_StudentID; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int iSerial
{
get { return  m_iSerial; }
set {m_iSerial  = value ; }
}
public string StudentID
{
get { return  m_StudentID; }
set {m_StudentID  = value ; }
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
public FinalExam_StudentSchedule_D()
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
public class FinalExam_StudentSchedule_DDAL : FinalExam_StudentSchedule_D
{
#region "Decleration"
private string m_TableName;
private string m_iSerialFN ;
private string m_StudentIDFN ;
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
public string iSerialFN 
{
get { return  m_iSerialFN; }
set {m_iSerialFN  = value ; }
}
public string StudentIDFN 
{
get { return  m_StudentIDFN; }
set {m_StudentIDFN  = value ; }
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
public FinalExam_StudentSchedule_DDAL()
{
try
{
this.TableName = "Reg_FinalExam_StudentSchedule_D";
this.iSerialFN = m_TableName + ".iSerial";
this.StudentIDFN = m_TableName + ".StudentID";
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
sSQL +=iSerialFN;
sSQL += " , " + StudentIDFN;
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
//-----GetListSQl Function ---------------------------------
public string  GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=iSerialFN;
sSQL += " , " + StudentIDFN;
sSQL += " , " + strUserCreateFN;
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
sSQL += " , " + StudentIDFN;
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
sSQL += LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN) + "=@StudentID";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(iSerialFN)+"=@iSerial";
sSQL +=  " And " + LibraryMOD.GetFieldName(StudentIDFN)+"=@StudentID";
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
sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @iSerial";
sSQL += " ,@StudentID";
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
sSQL += LibraryMOD.GetFieldName(iSerialFN)+"=@iSerial";
sSQL +=  " And " +  LibraryMOD.GetFieldName(StudentIDFN)+"=@StudentID";
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
public List< FinalExam_StudentSchedule_D> GetFinalExam_StudentSchedule_D(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the FinalExam_StudentSchedule_D
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
List<FinalExam_StudentSchedule_D> results = new List<FinalExam_StudentSchedule_D>();
try
{
//Default Value
FinalExam_StudentSchedule_D myFinalExam_StudentSchedule_D = new FinalExam_StudentSchedule_D();
if (isDeafaultIncluded)
{
//Change the code here
myFinalExam_StudentSchedule_D.iSerial = 0;
myFinalExam_StudentSchedule_D.StudentID = "";
myFinalExam_StudentSchedule_D.StudentID = "Select FinalExam_StudentSchedule_D ...";
results.Add(myFinalExam_StudentSchedule_D);
}
while (reader.Read())
{
myFinalExam_StudentSchedule_D = new FinalExam_StudentSchedule_D();
if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
{
myFinalExam_StudentSchedule_D.iSerial = 0;
}
else
{
myFinalExam_StudentSchedule_D.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
}
myFinalExam_StudentSchedule_D.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
myFinalExam_StudentSchedule_D.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myFinalExam_StudentSchedule_D.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myFinalExam_StudentSchedule_D.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myFinalExam_StudentSchedule_D.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myFinalExam_StudentSchedule_D.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myFinalExam_StudentSchedule_D.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myFinalExam_StudentSchedule_D);
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
public List< FinalExam_StudentSchedule_D > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<FinalExam_StudentSchedule_D> results = new List<FinalExam_StudentSchedule_D>();
try
{
//Default Value
FinalExam_StudentSchedule_D myFinalExam_StudentSchedule_D= new FinalExam_StudentSchedule_D();
if (isDeafaultIncluded)
 {
//Change the code here
 myFinalExam_StudentSchedule_D.iSerial = -1;
 myFinalExam_StudentSchedule_D.StudentID = "Select FinalExam_StudentSchedule_D" ;
results.Add(myFinalExam_StudentSchedule_D);
 }
while (reader.Read())
{
myFinalExam_StudentSchedule_D = new FinalExam_StudentSchedule_D();
if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
{
myFinalExam_StudentSchedule_D.iSerial = 0;
}
else
{
myFinalExam_StudentSchedule_D.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
}
myFinalExam_StudentSchedule_D.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
myFinalExam_StudentSchedule_D.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
 results.Add(myFinalExam_StudentSchedule_D);
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
public int UpdateFinalExam_StudentSchedule_D(InitializeModule.EnumCampus Campus, int iMode,int iSerial,string StudentID,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
FinalExam_StudentSchedule_D theFinalExam_StudentSchedule_D = new FinalExam_StudentSchedule_D();
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
Cmd.Parameters.Add(new SqlParameter("@StudentID",StudentID));
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
public int DeleteFinalExam_StudentSchedule_D(InitializeModule.EnumCampus Campus,string iSerial,string StudentID)
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
Cmd.Parameters.Add(new SqlParameter("@StudentID", StudentID ));
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
DataTable dt = new DataTable("FinalExam_StudentSchedule_D");
DataView dv = new DataView();
List<FinalExam_StudentSchedule_D> myFinalExam_StudentSchedule_Ds = new List<FinalExam_StudentSchedule_D>();
try
{
myFinalExam_StudentSchedule_Ds = GetFinalExam_StudentSchedule_D(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("iSerial", Type.GetType("int"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("StudentID", Type.GetType("nvarchar"));
dt.Columns.Add(col1 );

//dt.Constraints.Add(new UniqueConstraint(col0));
//dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myFinalExam_StudentSchedule_Ds.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myFinalExam_StudentSchedule_Ds[i].iSerial;
  dr[2] = myFinalExam_StudentSchedule_Ds[i].StudentID;
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
myFinalExam_StudentSchedule_Ds.Clear();
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
public class FinalExam_StudentSchedule_DCls : FinalExam_StudentSchedule_DDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daFinalExam_StudentSchedule_D;
private DataSet m_dsFinalExam_StudentSchedule_D;
public DataRow FinalExam_StudentSchedule_DDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsFinalExam_StudentSchedule_D
{
get { return m_dsFinalExam_StudentSchedule_D ; }
set { m_dsFinalExam_StudentSchedule_D = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public FinalExam_StudentSchedule_DCls()
{
try
{
dsFinalExam_StudentSchedule_D= new DataSet();

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
public virtual SqlDataAdapter GetFinalExam_StudentSchedule_DDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daFinalExam_StudentSchedule_D = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daFinalExam_StudentSchedule_D);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daFinalExam_StudentSchedule_D.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFinalExam_StudentSchedule_D;
}
public virtual SqlDataAdapter GetFinalExam_StudentSchedule_DDataAdapter(SqlConnection con)  
{
try
{
daFinalExam_StudentSchedule_D = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daFinalExam_StudentSchedule_D.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdFinalExam_StudentSchedule_D;
cmdFinalExam_StudentSchedule_D = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@iSerial", SqlDbType.Int, 4, "iSerial" );
//'cmdRolePermission.Parameters.Add("@StudentID", SqlDbType.Int, 4, "StudentID" );
daFinalExam_StudentSchedule_D.SelectCommand = cmdFinalExam_StudentSchedule_D;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdFinalExam_StudentSchedule_D = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdFinalExam_StudentSchedule_D.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
//cmdFinalExam_StudentSchedule_D.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdFinalExam_StudentSchedule_D.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
Parmeter = cmdFinalExam_StudentSchedule_D.Parameters.Add("@StudentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StudentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daFinalExam_StudentSchedule_D.UpdateCommand = cmdFinalExam_StudentSchedule_D;
daFinalExam_StudentSchedule_D.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdFinalExam_StudentSchedule_D = new SqlCommand(GetInsertCommand(), con);
cmdFinalExam_StudentSchedule_D.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@StudentID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(StudentIDFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFinalExam_StudentSchedule_D.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daFinalExam_StudentSchedule_D.InsertCommand =cmdFinalExam_StudentSchedule_D;
daFinalExam_StudentSchedule_D.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdFinalExam_StudentSchedule_D = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdFinalExam_StudentSchedule_D.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
Parmeter = cmdFinalExam_StudentSchedule_D.Parameters.Add("@StudentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StudentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daFinalExam_StudentSchedule_D.DeleteCommand =cmdFinalExam_StudentSchedule_D;
daFinalExam_StudentSchedule_D.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daFinalExam_StudentSchedule_D.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFinalExam_StudentSchedule_D;
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
dr = dsFinalExam_StudentSchedule_D.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
dr[LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsFinalExam_StudentSchedule_D.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsFinalExam_StudentSchedule_D.Tables[TableName].Select(LibraryMOD.GetFieldName(iSerialFN)  + "=" + iSerial  + " AND " + LibraryMOD.GetFieldName(StudentIDFN) + "=" + StudentID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
drAry[0][LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
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
public int CommitFinalExam_StudentSchedule_D()  
{
//CommitFinalExam_StudentSchedule_D= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daFinalExam_StudentSchedule_D.Update(dsFinalExam_StudentSchedule_D, TableName);
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
FindInMultiPKey(iSerial,StudentID);
if (( FinalExam_StudentSchedule_DDataRow != null)) 
{
FinalExam_StudentSchedule_DDataRow.Delete();
CommitFinalExam_StudentSchedule_D();
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
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(iSerialFN)]== System.DBNull.Value)
{
  iSerial=0;
}
else
{
  iSerial = (int)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(iSerialFN)];
}
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(StudentIDFN)]== System.DBNull.Value)
{
  StudentID="";
}
else
{
  StudentID = (string)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(StudentIDFN)];
}
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)FinalExam_StudentSchedule_DDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKiSerial,string PKStudentID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKiSerial;
findTheseVals[1] = PKStudentID;
FinalExam_StudentSchedule_DDataRow = dsFinalExam_StudentSchedule_D.Tables[TableName].Rows.Find(findTheseVals);
if  ((FinalExam_StudentSchedule_DDataRow !=null)) 
{
lngCurRow = dsFinalExam_StudentSchedule_D.Tables[TableName].Rows.IndexOf(FinalExam_StudentSchedule_DDataRow);
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
  lngCurRow = dsFinalExam_StudentSchedule_D.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsFinalExam_StudentSchedule_D.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsFinalExam_StudentSchedule_D.Tables[TableName].Rows.Count > 0) 
{
  FinalExam_StudentSchedule_DDataRow = dsFinalExam_StudentSchedule_D.Tables[TableName].Rows[lngCurRow];
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
daFinalExam_StudentSchedule_D.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFinalExam_StudentSchedule_D.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daFinalExam_StudentSchedule_D.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFinalExam_StudentSchedule_D.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
