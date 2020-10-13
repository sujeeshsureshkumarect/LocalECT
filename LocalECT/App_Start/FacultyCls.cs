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
public class Faculty
    {
    //Creation Date: 04/10/2018 5:04:41 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
    #region "Decleration"
private int m_FacultyID; 
private string m_FacultyName; 
private string m_FacultyShortcut; 
private int m_IsShowAsFaculty;
private int m_DeanofFacultyID; 
   
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
    #region "Puplic Properties"
//'-----------------------------------------------------
public int FacultyID
{
get { return  m_FacultyID; }
set {m_FacultyID  = value ; }
}
public string FacultyName
{
get { return  m_FacultyName; }
set {m_FacultyName  = value ; }
}
public string FacultyShortcut
{
get { return  m_FacultyShortcut; }
set {m_FacultyShortcut  = value ; }
}
public int IsShowAsFaculty
{
    get { return m_IsShowAsFaculty; }
    set { m_IsShowAsFaculty = value; }
}
public int DeanofFacultyID
{
    get { return m_DeanofFacultyID; }
    set { m_DeanofFacultyID = value; }
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
    public Faculty()
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
public class FacultyDAL : Faculty
{
    #region "Decleration"
private string m_TableName;
private string m_FacultyIDFN ;
private string m_FacultyNameFN ;
private string m_FacultyShortcutFN ;
private string m_IsShowAsFacultyFN;
private string m_DeanofFacultyIDFN; 
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
public string FacultyIDFN 
{
get { return  m_FacultyIDFN; }
set {m_FacultyIDFN  = value ; }
}
public string FacultyNameFN 
{
get { return  m_FacultyNameFN; }
set {m_FacultyNameFN  = value ; }
}
public string FacultyShortcutFN 
{
get { return  m_FacultyShortcutFN; }
set {m_FacultyShortcutFN  = value ; }
}
    
public string IsShowAsFacultyFN 
{
get { return  m_IsShowAsFacultyFN; }
set {m_IsShowAsFacultyFN  = value ; }
}
public string DeanofFacultyIDFN 
{
get { return  m_DeanofFacultyIDFN; }
set {m_DeanofFacultyIDFN  = value ; }
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
    public FacultyDAL()
{
try
{
this.TableName = "Reg_Faculty";
this.FacultyIDFN = m_TableName + ".FacultyID";
this.FacultyNameFN = m_TableName + ".FacultyName";
this.FacultyShortcutFN = m_TableName + ".FacultyShortcut";
this.IsShowAsFacultyFN = m_TableName + ".IsShowAsFaculty";
this.DeanofFacultyIDFN = m_TableName + ".DeanofFacultyID";

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
sSQL +=FacultyIDFN;
sSQL += " , " + FacultyNameFN;
sSQL += " , " + FacultyShortcutFN;
sSQL += " , " + IsShowAsFacultyFN ;
sSQL += " , " + DeanofFacultyIDFN ;
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
public string GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=FacultyIDFN;
sSQL += " , " + FacultyNameFN;
sSQL += " , " + FacultyShortcutFN;
sSQL += " , " + IsShowAsFacultyFN;
sSQL += " , " + DeanofFacultyIDFN;
sSQL += "  FROM " + m_TableName;
if (!string.IsNullOrEmpty(sCondition))
{
    sSQL += " Where " + sCondition;
}
sSQL += " ORDER BY " + FacultyNameFN;
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
sSQL +=FacultyIDFN;
sSQL += " , " + FacultyNameFN;
sSQL += " , " + FacultyShortcutFN;
sSQL += " , " + IsShowAsFacultyFN;
sSQL += " , " + DeanofFacultyIDFN;
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
sSQL += LibraryMOD.GetFieldName(FacultyIDFN) + "=@FacultyID";
sSQL += " , " + LibraryMOD.GetFieldName(FacultyNameFN) + "=@FacultyName";
sSQL += " , " + LibraryMOD.GetFieldName(FacultyShortcutFN) + "=@FacultyShortcut";
sSQL += " , " + LibraryMOD.GetFieldName(IsShowAsFacultyFN) + "=@IsShowAsFaculty";
sSQL += " , " + LibraryMOD.GetFieldName(DeanofFacultyIDFN) + "=@DeanofFacultyID";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(FacultyIDFN)+"=@FacultyID";
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
sSQL +=LibraryMOD.GetFieldName(FacultyIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(FacultyNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(FacultyShortcutFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsShowAsFacultyFN );
sSQL += " , " + LibraryMOD.GetFieldName(DeanofFacultyIDFN );
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @FacultyID";
sSQL += " ,@FacultyName";
sSQL += " ,@FacultyShortcut";
sSQL += " ,@IsShowAsFaculty";
sSQL += " ,@DeanofFacultyID";
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
sSQL += LibraryMOD.GetFieldName(FacultyIDFN)+"=@FacultyID";
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
public List< Faculty> GetFaculty(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Faculty
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
List<Faculty> results = new List<Faculty>();
try
{
//Default Value
Faculty myFaculty = new Faculty();
if (isDeafaultIncluded)
{
//Change the code here
myFaculty.FacultyID = 0;
myFaculty.FacultyName = "Select Faculty ...";
results.Add(myFaculty);
}
while (reader.Read())
{
myFaculty = new Faculty();
if (reader[LibraryMOD.GetFieldName(FacultyIDFN)].Equals(DBNull.Value))
{
myFaculty.FacultyID = 0;
}
else
{
myFaculty.FacultyID = int.Parse(reader[LibraryMOD.GetFieldName( FacultyIDFN) ].ToString());
}
myFaculty.FacultyName =reader[LibraryMOD.GetFieldName( FacultyNameFN) ].ToString();
myFaculty.FacultyShortcut =reader[LibraryMOD.GetFieldName( FacultyShortcutFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(IsShowAsFacultyFN)].Equals(DBNull.Value))
{
    myFaculty.IsShowAsFaculty = 0;
}
else
{
    myFaculty.IsShowAsFaculty = int.Parse(reader[LibraryMOD.GetFieldName(IsShowAsFacultyFN)].ToString());
}
if (reader[LibraryMOD.GetFieldName(DeanofFacultyIDFN )].Equals(DBNull.Value))
{
    myFaculty.DeanofFacultyID = 0;
}
else
{
    myFaculty.DeanofFacultyID = int.Parse(reader[LibraryMOD.GetFieldName(DeanofFacultyIDFN)].ToString());
}
myFaculty.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myFaculty.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myFaculty.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myFaculty.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myFaculty.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myFaculty.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myFaculty);
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
public List< Faculty > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Faculty> results = new List<Faculty>();
try
{
//Default Value
Faculty myFaculty= new Faculty();
if (isDeafaultIncluded)
 {
//Change the code here
 myFaculty.FacultyID = -1;
 myFaculty.FacultyName = "Select Faculty" ;
results.Add(myFaculty);
 }
while (reader.Read())
{
myFaculty = new Faculty();
if (reader[LibraryMOD.GetFieldName(FacultyIDFN)].Equals(DBNull.Value))
{
myFaculty.FacultyID = 0;
}
else
{
myFaculty.FacultyID = int.Parse(reader[LibraryMOD.GetFieldName( FacultyIDFN) ].ToString());
}
myFaculty.FacultyName =reader[LibraryMOD.GetFieldName( FacultyNameFN) ].ToString();
myFaculty.FacultyShortcut =reader[LibraryMOD.GetFieldName( FacultyShortcutFN) ].ToString();

    if (reader[LibraryMOD.GetFieldName(IsShowAsFacultyFN )].Equals(DBNull.Value))
{
    myFaculty.IsShowAsFaculty = 0;
}
else
{
    myFaculty.IsShowAsFaculty = int.Parse(reader[LibraryMOD.GetFieldName(IsShowAsFacultyFN)].ToString());
}
if (reader[LibraryMOD.GetFieldName(DeanofFacultyIDFN)].Equals(DBNull.Value))
{
    myFaculty.DeanofFacultyID = 0;
}
else
{
    myFaculty.DeanofFacultyID = int.Parse(reader[LibraryMOD.GetFieldName(DeanofFacultyIDFN)].ToString());
}
 results.Add(myFaculty);
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
public int UpdateFaculty(InitializeModule.EnumCampus Campus, int iMode,int FacultyID,string FacultyName,string FacultyShortcut, int isShowAsFaculty,int DeanofFacultyID,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Faculty theFaculty = new Faculty();
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
Cmd.Parameters.Add(new SqlParameter("@FacultyID",FacultyID));
Cmd.Parameters.Add(new SqlParameter("@FacultyName",FacultyName));
Cmd.Parameters.Add(new SqlParameter("@FacultyShortcut",FacultyShortcut));

Cmd.Parameters.Add(new SqlParameter("@IsShowAsFaculty", isShowAsFaculty));
Cmd.Parameters.Add(new SqlParameter("@DeanofFacultyID", DeanofFacultyID));
    
         

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
public int DeleteFaculty(InitializeModule.EnumCampus Campus,int FacultyID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@FacultyID", FacultyID ));
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
DataTable dt = new DataTable("Faculty");
DataView dv = new DataView();
List<Faculty> myFacultys = new List<Faculty>();
try
{
myFacultys = GetFaculty(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("FacultyID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myFacultys.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myFacultys[i].FacultyID;
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
myFacultys.Clear();
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
sSQL += FacultyIDFN;
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
public class FacultyCls : FacultyDAL
{
    #region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daFaculty;
private DataSet m_dsFaculty;
public DataRow FacultyDataRow ;
#endregion
    #region "Puplic Properties"
public DataSet dsFaculty
{
get { return m_dsFaculty ; }
set { m_dsFaculty = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
    public FacultyCls()
{
try
{
dsFaculty= new DataSet();

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
public virtual SqlDataAdapter GetFacultyDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daFaculty = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daFaculty);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daFaculty.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFaculty;
}
public virtual SqlDataAdapter GetFacultyDataAdapter(SqlConnection con)  
{
try
{
daFaculty = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daFaculty.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdFaculty;
cmdFaculty = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@FacultyID", SqlDbType.Int, 4, "FacultyID" );
daFaculty.SelectCommand = cmdFaculty;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdFaculty = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below

cmdFaculty.Parameters.Add("@FacultyName", SqlDbType.NVarChar,300, LibraryMOD.GetFieldName(FacultyNameFN));
cmdFaculty.Parameters.Add("@FacultyShortcut", SqlDbType.NChar,20, LibraryMOD.GetFieldName(FacultyShortcutFN));
cmdFaculty.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFaculty.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFaculty.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFaculty.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFaculty.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFaculty.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdFaculty.Parameters.Add("@FacultyID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FacultyIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daFaculty.UpdateCommand = cmdFaculty;
daFaculty.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdFaculty = new SqlCommand(GetInsertCommand(), con);
cmdFaculty.Parameters.Add("@FacultyID", SqlDbType.Int,4, LibraryMOD.GetFieldName(FacultyIDFN));
cmdFaculty.Parameters.Add("@FacultyName", SqlDbType.NVarChar,300, LibraryMOD.GetFieldName(FacultyNameFN));
cmdFaculty.Parameters.Add("@FacultyShortcut", SqlDbType.NChar,20, LibraryMOD.GetFieldName(FacultyShortcutFN));
cmdFaculty.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFaculty.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFaculty.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFaculty.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFaculty.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFaculty.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daFaculty.InsertCommand =cmdFaculty;
daFaculty.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdFaculty = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdFaculty.Parameters.Add("@FacultyID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FacultyIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daFaculty.DeleteCommand =cmdFaculty;
daFaculty.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daFaculty.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFaculty;
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
dr = dsFaculty.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(FacultyIDFN)]=FacultyID;
dr[LibraryMOD.GetFieldName(FacultyNameFN)]=FacultyName;
dr[LibraryMOD.GetFieldName(FacultyShortcutFN)]=FacultyShortcut;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsFaculty.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsFaculty.Tables[TableName].Select(LibraryMOD.GetFieldName(FacultyIDFN)  + "=" + FacultyID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(FacultyIDFN)]=FacultyID;
drAry[0][LibraryMOD.GetFieldName(FacultyNameFN)]=FacultyName;
drAry[0][LibraryMOD.GetFieldName(FacultyShortcutFN)]=FacultyShortcut;
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
public int CommitFaculty()  
{
//CommitFaculty= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daFaculty.Update(dsFaculty, TableName);
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
FindInMultiPKey(FacultyID);
if (( FacultyDataRow != null)) 
{
FacultyDataRow.Delete();
CommitFaculty();
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
if (FacultyDataRow[LibraryMOD.GetFieldName(FacultyIDFN)]== System.DBNull.Value)
{
  FacultyID=0;
}
else
{
  FacultyID = (int)FacultyDataRow[LibraryMOD.GetFieldName(FacultyIDFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(FacultyNameFN)]== System.DBNull.Value)
{
  FacultyName="";
}
else
{
  FacultyName = (string)FacultyDataRow[LibraryMOD.GetFieldName(FacultyNameFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(FacultyShortcutFN)]== System.DBNull.Value)
{
  FacultyShortcut="";
}
else
{
  FacultyShortcut = (string)FacultyDataRow[LibraryMOD.GetFieldName(FacultyShortcutFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)FacultyDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)FacultyDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)FacultyDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)FacultyDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)FacultyDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (FacultyDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)FacultyDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKFacultyID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKFacultyID;
FacultyDataRow = dsFaculty.Tables[TableName].Rows.Find(findTheseVals);
if  ((FacultyDataRow !=null)) 
{
lngCurRow = dsFaculty.Tables[TableName].Rows.IndexOf(FacultyDataRow);
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
  lngCurRow = dsFaculty.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsFaculty.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsFaculty.Tables[TableName].Rows.Count > 0) 
{
  FacultyDataRow = dsFaculty.Tables[TableName].Rows[lngCurRow];
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
daFaculty.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFaculty.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daFaculty.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFaculty.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
