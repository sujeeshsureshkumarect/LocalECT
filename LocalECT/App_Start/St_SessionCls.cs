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
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlTypes;
public class St_Session
{
//Creation Date: 14/12/2009 6:53:56 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_SessionID; 
private string m_SessionEn; 
private string m_SessionAr; 
private DateTime m_dateTimeFrom; 
private DateTime m_dateTimeTo; 
private string m_Shortcut; 
private int m_IsActive; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int SessionID
{
get { return  m_SessionID; }
set {m_SessionID  = value ; }
}
public string SessionEn
{
get { return  m_SessionEn; }
set {m_SessionEn  = value ; }
}
public string SessionAr
{
get { return  m_SessionAr; }
set {m_SessionAr  = value ; }
}
public DateTime dateTimeFrom
{
get { return  m_dateTimeFrom; }
set {m_dateTimeFrom  = value ; }
}
public DateTime dateTimeTo
{
get { return  m_dateTimeTo; }
set {m_dateTimeTo  = value ; }
}
public string Shortcut
{
get { return  m_Shortcut; }
set {m_Shortcut  = value ; }
}
public int IsActive
{
get { return  m_IsActive; }
set {m_IsActive  = value ; }
}
#endregion
//'-----------------------------------------------------
public St_Session()
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
public class St_SessionDAL : St_Session
{
#region "Decleration"
private string m_TableName;
private string m_SessionIDFN ;
private string m_SessionEnFN ;
private string m_SessionArFN ;
private string m_dateTimeFromFN ;
private string m_dateTimeToFN ;
private string m_ShortcutFN ;
private string m_IsActiveFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string SessionIDFN 
{
get { return  m_SessionIDFN; }
set {m_SessionIDFN  = value ; }
}
public string SessionEnFN 
{
get { return  m_SessionEnFN; }
set {m_SessionEnFN  = value ; }
}
public string SessionArFN 
{
get { return  m_SessionArFN; }
set {m_SessionArFN  = value ; }
}
public string dateTimeFromFN 
{
get { return  m_dateTimeFromFN; }
set {m_dateTimeFromFN  = value ; }
}
public string dateTimeToFN 
{
get { return  m_dateTimeToFN; }
set {m_dateTimeToFN  = value ; }
}
public string ShortcutFN 
{
get { return  m_ShortcutFN; }
set {m_ShortcutFN  = value ; }
}
public string IsActiveFN 
{
get { return  m_IsActiveFN; }
set {m_IsActiveFN  = value ; }
}
#endregion
//================End Properties ===================
public St_SessionDAL()
{
try
{
this.TableName = "Lkp_St_Session";
this.SessionIDFN = m_TableName + ".SessionID";
this.SessionEnFN = m_TableName + ".SessionEn";
this.SessionArFN = m_TableName + ".SessionAr";
this.dateTimeFromFN = m_TableName + ".dateTimeFrom";
this.dateTimeToFN = m_TableName + ".dateTimeTo";
this.ShortcutFN = m_TableName + ".Shortcut";
this.IsActiveFN = m_TableName + ".IsActive";
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
sSQL +=SessionIDFN;
sSQL += " , " + SessionEnFN;
sSQL += " , " + SessionArFN;
sSQL += " , " + dateTimeFromFN;
sSQL += " , " + dateTimeToFN;
sSQL += " , " + ShortcutFN;
sSQL += " , " + IsActiveFN;
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

public string GetListSQL(string sWhere)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += SessionIDFN;
        sSQL += " , " + SessionEnFN;
        sSQL += " , " + ShortcutFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += sWhere;
        sSQL += " Order By " + ShortcutFN ;

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
sSQL +=SessionIDFN;
sSQL += " , " + SessionEnFN;
sSQL += " , " + SessionArFN;
sSQL += " , " + dateTimeFromFN;
sSQL += " , " + dateTimeToFN;
sSQL += " , " + ShortcutFN;
sSQL += " , " + IsActiveFN;
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
sSQL += LibraryMOD.GetFieldName(SessionIDFN) + "=@SessionID";
sSQL += " , " + LibraryMOD.GetFieldName(SessionEnFN) + "=@SessionEn";
sSQL += " , " + LibraryMOD.GetFieldName(SessionArFN) + "=@SessionAr";
sSQL += " , " + LibraryMOD.GetFieldName(dateTimeFromFN) + "=@dateTimeFrom";
sSQL += " , " + LibraryMOD.GetFieldName(dateTimeToFN) + "=@dateTimeTo";
sSQL += " , " + LibraryMOD.GetFieldName(ShortcutFN) + "=@Shortcut";
sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(SessionIDFN)+"=@SessionID";
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
sSQL +=LibraryMOD.GetFieldName(SessionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SessionEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(SessionArFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateTimeFromFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateTimeToFN);
sSQL += " , " + LibraryMOD.GetFieldName(ShortcutFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @SessionID";
sSQL += " ,@SessionEn";
sSQL += " ,@SessionAr";
sSQL += " ,@dateTimeFrom";
sSQL += " ,@dateTimeTo";
sSQL += " ,@Shortcut";
sSQL += " ,@IsActive";
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
sSQL += LibraryMOD.GetFieldName(SessionIDFN)+"=@SessionID";
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
public List< St_Session> GetSt_Session(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the St_Session
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
List<St_Session> results = new List<St_Session>();
try
{
//Default Value
St_Session mySt_Session = new St_Session();
if (isDeafaultIncluded)
{
//Change the code here
mySt_Session.SessionID = 0;
mySt_Session.SessionEn = "Select Session ...";
results.Add(mySt_Session);
}
while (reader.Read())
{
mySt_Session = new St_Session();
if (reader[LibraryMOD.GetFieldName(SessionIDFN)].Equals(DBNull.Value))
{
mySt_Session.SessionID = 0;
}
else
{
mySt_Session.SessionID = int.Parse(reader[LibraryMOD.GetFieldName( SessionIDFN) ].ToString());
}
mySt_Session.SessionEn =reader[LibraryMOD.GetFieldName( SessionEnFN) ].ToString();
mySt_Session.SessionAr =reader[LibraryMOD.GetFieldName( SessionArFN) ].ToString();
if (!reader[dateTimeFromFN].Equals(DBNull.Value))
{
mySt_Session.dateTimeFrom = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateTimeFromFN) ].ToString());
}
if (!reader[dateTimeToFN].Equals(DBNull.Value))
{
mySt_Session.dateTimeTo = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateTimeToFN) ].ToString());
}
mySt_Session.Shortcut =reader[LibraryMOD.GetFieldName( ShortcutFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(IsActiveFN)].Equals(DBNull.Value))
{
mySt_Session.IsActive = 0;
}
else
{
mySt_Session.IsActive = int.Parse(reader[LibraryMOD.GetFieldName( IsActiveFN) ].ToString());
}
 results.Add(mySt_Session);
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

public List<St_Session> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{

    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<St_Session> results = new List<St_Session>();
    try
    {
        //Default Value
        St_Session mySt_Session = new St_Session();
        if (isDeafaultIncluded)
        {
            //Change the code here
            mySt_Session.SessionID = 0;
            mySt_Session.Shortcut = "Select Session ...";
            mySt_Session.SessionEn = "Select Session ...";
            results.Add(mySt_Session);
        }
        while (reader.Read())
        {
            mySt_Session = new St_Session();

            if (reader[LibraryMOD.GetFieldName(SessionIDFN)].Equals(DBNull.Value))
            {
                mySt_Session.SessionID = 0;
            }
            else
            {
                mySt_Session.SessionID = int.Parse(reader[LibraryMOD.GetFieldName(SessionIDFN)].ToString());
            }
            mySt_Session.Shortcut = reader[LibraryMOD.GetFieldName(ShortcutFN)].ToString();
            mySt_Session.SessionEn = reader[LibraryMOD.GetFieldName(SessionEnFN)].ToString();

            results.Add(mySt_Session);
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

public int UpdateSt_Session(InitializeModule.EnumCampus Campus, int iMode,int SessionID,string SessionEn,string SessionAr,DateTime dateTimeFrom,DateTime dateTimeTo,string Shortcut,int IsActive)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
St_Session theSt_Session = new St_Session();
//'Updates the  table
switch(iMode) 
  {
  case  (int)InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@SessionID",SessionID));
Cmd.Parameters.Add(new SqlParameter("@SessionEn",SessionEn));
Cmd.Parameters.Add(new SqlParameter("@SessionAr",SessionAr));
Cmd.Parameters.Add(new SqlParameter("@dateTimeFrom",dateTimeFrom));
Cmd.Parameters.Add(new SqlParameter("@dateTimeTo",dateTimeTo));
Cmd.Parameters.Add(new SqlParameter("@Shortcut",Shortcut));
Cmd.Parameters.Add(new SqlParameter("@IsActive",IsActive));
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
public int DeleteSt_Session(InitializeModule.EnumCampus Campus,string SessionID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@SessionID", SessionID ));
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
DataTable dt = new DataTable("St_Session");
DataView dv = new DataView();
List<St_Session> mySt_Sessions = new List<St_Session>();
try
{
mySt_Sessions = GetSt_Session(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("SessionID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("SessionEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("SessionAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < mySt_Sessions.Count; i++)
{
dr = dt.NewRow();
  dr[1] = mySt_Sessions[i].SessionID;
  dr[2] = mySt_Sessions[i].SessionEn;
  dr[3] = mySt_Sessions[i].SessionAr;
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
mySt_Sessions.Clear();
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
sSQL += SessionIDFN;
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
public class St_SessionCls : St_SessionDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daSt_Session;
private DataSet m_dsSt_Session;
public DataRow St_SessionDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsSt_Session
{
get { return m_dsSt_Session ; }
set { m_dsSt_Session = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public St_SessionCls()
{
try
{
dsSt_Session= new DataSet();

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
public virtual SqlDataAdapter GetSt_SessionDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daSt_Session = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSt_Session);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daSt_Session.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSt_Session;
}
public virtual SqlDataAdapter GetSt_SessionDataAdapter(SqlConnection con)  
{
try
{
daSt_Session = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daSt_Session.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdSt_Session;
cmdSt_Session = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@SessionID", SqlDbType.Int, 4, "SessionID" );
daSt_Session.SelectCommand = cmdSt_Session;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdSt_Session = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdSt_Session.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdSt_Session.Parameters.Add("@SessionEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(SessionEnFN));
cmdSt_Session.Parameters.Add("@SessionAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(SessionArFN));
cmdSt_Session.Parameters.Add("@dateTimeFrom", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateTimeFromFN));
cmdSt_Session.Parameters.Add("@dateTimeTo", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateTimeToFN));
cmdSt_Session.Parameters.Add("@Shortcut", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(ShortcutFN));
cmdSt_Session.Parameters.Add("@IsActive", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsActiveFN));


Parmeter = cmdSt_Session.Parameters.Add("@SessionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SessionIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daSt_Session.UpdateCommand = cmdSt_Session;
daSt_Session.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdSt_Session = new SqlCommand(GetInsertCommand(), con);
cmdSt_Session.Parameters.Add("@SessionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionIDFN));
cmdSt_Session.Parameters.Add("@SessionEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(SessionEnFN));
cmdSt_Session.Parameters.Add("@SessionAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(SessionArFN));
cmdSt_Session.Parameters.Add("@dateTimeFrom", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateTimeFromFN));
cmdSt_Session.Parameters.Add("@dateTimeTo", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateTimeToFN));
cmdSt_Session.Parameters.Add("@Shortcut", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(ShortcutFN));
cmdSt_Session.Parameters.Add("@IsActive", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsActiveFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daSt_Session.InsertCommand =cmdSt_Session;
daSt_Session.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdSt_Session = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdSt_Session.Parameters.Add("@SessionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SessionIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daSt_Session.DeleteCommand =cmdSt_Session;
daSt_Session.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daSt_Session.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSt_Session;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsSt_Session.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
dr[LibraryMOD.GetFieldName(SessionEnFN)]=SessionEn;
dr[LibraryMOD.GetFieldName(SessionArFN)]=SessionAr;
dr[LibraryMOD.GetFieldName(dateTimeFromFN)]=dateTimeFrom;
dr[LibraryMOD.GetFieldName(dateTimeToFN)]=dateTimeTo;
dr[LibraryMOD.GetFieldName(ShortcutFN)]=Shortcut;
dr[LibraryMOD.GetFieldName(IsActiveFN)]=IsActive;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsSt_Session.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsSt_Session.Tables[TableName].Select(LibraryMOD.GetFieldName(SessionIDFN)  + "=" + SessionID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(SessionIDFN)]=SessionID;
drAry[0][LibraryMOD.GetFieldName(SessionEnFN)]=SessionEn;
drAry[0][LibraryMOD.GetFieldName(SessionArFN)]=SessionAr;
drAry[0][LibraryMOD.GetFieldName(dateTimeFromFN)]=dateTimeFrom;
drAry[0][LibraryMOD.GetFieldName(dateTimeToFN)]=dateTimeTo;
drAry[0][LibraryMOD.GetFieldName(ShortcutFN)]=Shortcut;
drAry[0][LibraryMOD.GetFieldName(IsActiveFN)]=IsActive;
//drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
return InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitSt_Session()  
{
//CommitSt_Session= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daSt_Session.Update(dsSt_Session, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow= InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(SessionID);
if (( St_SessionDataRow != null)) 
{
St_SessionDataRow.Delete();
CommitSt_Session();
if (MoveNext() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (St_SessionDataRow[LibraryMOD.GetFieldName(SessionIDFN)]== System.DBNull.Value)
{
  SessionID=0;
}
else
{
  SessionID = (int)St_SessionDataRow[LibraryMOD.GetFieldName(SessionIDFN)];
}
if (St_SessionDataRow[LibraryMOD.GetFieldName(SessionEnFN)]== System.DBNull.Value)
{
  SessionEn="";
}
else
{
  SessionEn = (string)St_SessionDataRow[LibraryMOD.GetFieldName(SessionEnFN)];
}
if (St_SessionDataRow[LibraryMOD.GetFieldName(SessionArFN)]== System.DBNull.Value)
{
  SessionAr="";
}
else
{
  SessionAr = (string)St_SessionDataRow[LibraryMOD.GetFieldName(SessionArFN)];
}
if (St_SessionDataRow[LibraryMOD.GetFieldName(dateTimeFromFN)]== System.DBNull.Value)
{
}
else
{
  dateTimeFrom = (DateTime)St_SessionDataRow[LibraryMOD.GetFieldName(dateTimeFromFN)];
}
if (St_SessionDataRow[LibraryMOD.GetFieldName(dateTimeToFN)]== System.DBNull.Value)
{
}
else
{
  dateTimeTo = (DateTime)St_SessionDataRow[LibraryMOD.GetFieldName(dateTimeToFN)];
}
if (St_SessionDataRow[LibraryMOD.GetFieldName(ShortcutFN)]== System.DBNull.Value)
{
  Shortcut="";
}
else
{
  Shortcut = (string)St_SessionDataRow[LibraryMOD.GetFieldName(ShortcutFN)];
}
if (St_SessionDataRow[LibraryMOD.GetFieldName(IsActiveFN)]== System.DBNull.Value)
{
  IsActive=0;
}
else
{
  IsActive = (int)St_SessionDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(int PKSessionID) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKSessionID;
St_SessionDataRow = dsSt_Session.Tables[TableName].Rows.Find(findTheseVals);
if  ((St_SessionDataRow !=null)) 
{
lngCurRow = dsSt_Session.Tables[TableName].Rows.IndexOf(St_SessionDataRow);
SynchronizeDataRowToClass();
return InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst= InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast= InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsSt_Session.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsSt_Session.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow= InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsSt_Session.Tables[TableName].Rows.Count > 0) 
{
  St_SessionDataRow = dsSt_Session.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
// InitializeModule.FAIL_RET;
try
{
daSt_Session.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSt_Session.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daSt_Session.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSt_Session.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
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
