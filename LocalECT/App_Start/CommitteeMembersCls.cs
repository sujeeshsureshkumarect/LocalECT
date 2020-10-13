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
public class CommitteeMembers
{
//Creation Date: 02/17/2010 8:55:13 AM
//Programmer Name : Mohammad Hussein
//-----Decleration --------------
#region "Decleration"
private int m_CommitteeID; 
private int m_MemberID; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int CommitteeID
{
get { return  m_CommitteeID; }
set {m_CommitteeID  = value ; }
}
public int MemberID
{
get { return  m_MemberID; }
set {m_MemberID  = value ; }
}
public int CreationUserID
{
get { return  m_CreationUserID; }
set {m_CreationUserID  = value ; }
}
public DateTime CreationDate
{
get { return  m_CreationDate; }
set {m_CreationDate  = value ; }
}
public int LastUpdateUserID
{
get { return  m_LastUpdateUserID; }
set {m_LastUpdateUserID  = value ; }
}
public DateTime LastUpdateDate
{
get { return  m_LastUpdateDate; }
set {m_LastUpdateDate  = value ; }
}
public string PCName
{
get { return  m_PCName; }
set {m_PCName  = value ; }
}
public string NetUserName
{
get { return  m_NetUserName; }
set {m_NetUserName  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public CommitteeMembers()
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
public class CommitteeMembersDAL : CommitteeMembers
{
#region "Decleration"
private string m_TableName;
private string m_CommitteeIDFN ;
private string m_MemberIDFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string CommitteeIDFN 
{
get { return  m_CommitteeIDFN; }
set {m_CommitteeIDFN  = value ; }
}
public string MemberIDFN 
{
get { return  m_MemberIDFN; }
set {m_MemberIDFN  = value ; }
}
public string CreationUserIDFN 
{
get { return  m_CreationUserIDFN; }
set {m_CreationUserIDFN  = value ; }
}
public string CreationDateFN 
{
get { return  m_CreationDateFN; }
set {m_CreationDateFN  = value ; }
}
public string LastUpdateUserIDFN 
{
get { return  m_LastUpdateUserIDFN; }
set {m_LastUpdateUserIDFN  = value ; }
}
public string LastUpdateDateFN 
{
get { return  m_LastUpdateDateFN; }
set {m_LastUpdateDateFN  = value ; }
}
public string PCNameFN 
{
get { return  m_PCNameFN; }
set {m_PCNameFN  = value ; }
}
public string NetUserNameFN 
{
get { return  m_NetUserNameFN; }
set {m_NetUserNameFN  = value ; }
}
#endregion
//================End Properties ===================
public CommitteeMembersDAL()
{
try
{
this.TableName = "Lkp_CommitteeMembers";
this.CommitteeIDFN = m_TableName + ".CommitteeID";
this.MemberIDFN = m_TableName + ".MemberID";
this.CreationUserIDFN = m_TableName + ".CreationUserID";
this.CreationDateFN = m_TableName + ".CreationDate";
this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
this.PCNameFN = m_TableName + ".PCName";
this.NetUserNameFN = m_TableName + ".NetUserName";
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
sSQL +=CommitteeIDFN;
sSQL += " , " + MemberIDFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION  ;

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
sSQL +=CommitteeIDFN;
sSQL += " , " + MemberIDFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
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
sSQL += LibraryMOD.GetFieldName(CommitteeIDFN) + "=@CommitteeID";
sSQL += " , " + LibraryMOD.GetFieldName(MemberIDFN) + "=@MemberID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(CommitteeIDFN)+"=@CommitteeID";
sSQL +=  " And " + LibraryMOD.GetFieldName(MemberIDFN)+"=@MemberID";
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
sSQL +=LibraryMOD.GetFieldName(CommitteeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(MemberIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @CommitteeID";
sSQL += " ,@MemberID";
sSQL += " ,@CreationUserID";
sSQL += " ,@CreationDate";
sSQL += " ,@LastUpdateUserID";
sSQL += " ,@LastUpdateDate";
sSQL += " ,@PCName";
sSQL += " ,@NetUserName";
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
sSQL += LibraryMOD.GetFieldName(CommitteeIDFN)+"=@CommitteeID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(MemberIDFN)+"=@MemberID";
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
public List< CommitteeMembers> GetCommitteeMembers(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the CommitteeMembers
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
List<CommitteeMembers> results = new List<CommitteeMembers>();
try
{
//Default Value
CommitteeMembers myCommitteeMembers = new CommitteeMembers();
if (isDeafaultIncluded)
{
//Change the code here
myCommitteeMembers.CommitteeID = 0;
myCommitteeMembers.MemberID = 0;
myCommitteeMembers.CreationUserID = 0;
results.Add(myCommitteeMembers);
}
while (reader.Read())
{
myCommitteeMembers = new CommitteeMembers();
if (reader[LibraryMOD.GetFieldName(CommitteeIDFN)].Equals(DBNull.Value))
{
myCommitteeMembers.CommitteeID = 0;
}
else
{
myCommitteeMembers.CommitteeID = int.Parse(reader[LibraryMOD.GetFieldName( CommitteeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(MemberIDFN)].Equals(DBNull.Value))
{
myCommitteeMembers.MemberID = 0;
}
else
{
myCommitteeMembers.MemberID = int.Parse(reader[LibraryMOD.GetFieldName( MemberIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myCommitteeMembers.CreationUserID = 0;
}
else
{
myCommitteeMembers.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[CreationDateFN].Equals(DBNull.Value))
{
myCommitteeMembers.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myCommitteeMembers.LastUpdateUserID = 0;
}
else
{
myCommitteeMembers.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LastUpdateDateFN].Equals(DBNull.Value))
{
myCommitteeMembers.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myCommitteeMembers.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myCommitteeMembers.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myCommitteeMembers);
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
public int UpdateCommitteeMembers(InitializeModule.EnumCampus Campus, int iMode,int CommitteeID,int MemberID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
CommitteeMembers theCommitteeMembers = new CommitteeMembers();
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
Cmd.Parameters.Add(new SqlParameter("@CommitteeID",CommitteeID));
Cmd.Parameters.Add(new SqlParameter("@MemberID",MemberID));
Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
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
public int DeleteCommitteeMembers(InitializeModule.EnumCampus Campus,string CommitteeID,string MemberID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@CommitteeID", CommitteeID ));
Cmd.Parameters.Add(new SqlParameter("@MemberID", MemberID ));
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
DataTable dt = new DataTable("CommitteeMembers");
DataView dv = new DataView();
List<CommitteeMembers> myCommitteeMemberss = new List<CommitteeMembers>();
try
{
myCommitteeMemberss = GetCommitteeMembers(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("CommitteeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("MemberID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("CreationUserID", Type.GetType("int"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myCommitteeMemberss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCommitteeMemberss[i].CommitteeID;
  dr[2] = myCommitteeMemberss[i].MemberID;
  dr[3] = myCommitteeMemberss[i].CreationUserID;
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
myCommitteeMemberss.Clear();
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
sSQL += CommitteeIDFN;
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
public class CommitteeMembersCls : CommitteeMembersDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daCommitteeMembers;
private DataSet m_dsCommitteeMembers;
public DataRow CommitteeMembersDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsCommitteeMembers
{
get { return m_dsCommitteeMembers ; }
set { m_dsCommitteeMembers = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public CommitteeMembersCls()
{
try
{
dsCommitteeMembers= new DataSet();

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
public virtual SqlDataAdapter GetCommitteeMembersDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daCommitteeMembers = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCommitteeMembers);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daCommitteeMembers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCommitteeMembers;
}
public virtual SqlDataAdapter GetCommitteeMembersDataAdapter(SqlConnection con)  
{
try
{
daCommitteeMembers = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daCommitteeMembers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdCommitteeMembers;
cmdCommitteeMembers = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@CommitteeID", SqlDbType.Int, 4, "CommitteeID" );
//'cmdRolePermission.Parameters.Add("@MemberID", SqlDbType.Int, 4, "MemberID" );
daCommitteeMembers.SelectCommand = cmdCommitteeMembers;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdCommitteeMembers = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdCommitteeMembers.Parameters.Add("@CommitteeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CommitteeIDFN));
cmdCommitteeMembers.Parameters.Add("@MemberID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MemberIDFN));
cmdCommitteeMembers.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdCommitteeMembers.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdCommitteeMembers.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdCommitteeMembers.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdCommitteeMembers.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdCommitteeMembers.Parameters.Add("@NetUserName", SqlDbType.NVarChar,64, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdCommitteeMembers.Parameters.Add("@CommitteeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CommitteeIDFN));
Parmeter = cmdCommitteeMembers.Parameters.Add("@MemberID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MemberIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daCommitteeMembers.UpdateCommand = cmdCommitteeMembers;
daCommitteeMembers.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdCommitteeMembers = new SqlCommand(GetInsertCommand(), con);
cmdCommitteeMembers.Parameters.Add("@CommitteeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CommitteeIDFN));
cmdCommitteeMembers.Parameters.Add("@MemberID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MemberIDFN));
cmdCommitteeMembers.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdCommitteeMembers.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdCommitteeMembers.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdCommitteeMembers.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdCommitteeMembers.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdCommitteeMembers.Parameters.Add("@NetUserName", SqlDbType.NVarChar,64, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daCommitteeMembers.InsertCommand =cmdCommitteeMembers;
daCommitteeMembers.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdCommitteeMembers = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdCommitteeMembers.Parameters.Add("@CommitteeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CommitteeIDFN));
Parmeter = cmdCommitteeMembers.Parameters.Add("@MemberID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MemberIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daCommitteeMembers.DeleteCommand =cmdCommitteeMembers;
daCommitteeMembers.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daCommitteeMembers.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCommitteeMembers;
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
dr = dsCommitteeMembers.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(CommitteeIDFN)]=CommitteeID;
dr[LibraryMOD.GetFieldName(MemberIDFN)]=MemberID;
dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsCommitteeMembers.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsCommitteeMembers.Tables[TableName].Select(LibraryMOD.GetFieldName(CommitteeIDFN)  + "=" + CommitteeID  + " AND " + LibraryMOD.GetFieldName(MemberIDFN) + "=" + MemberID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(CommitteeIDFN)]=CommitteeID;
drAry[0][LibraryMOD.GetFieldName(MemberIDFN)]=MemberID;
drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
public int CommitCommitteeMembers()  
{
//CommitCommitteeMembers= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daCommitteeMembers.Update(dsCommitteeMembers, TableName);
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
//-------DeleteAllRows  -----------------------------
public int DeleteAllRows(SqlConnection conn)
{
    //DeleteAllRows = InitializeModule.FAIL_RET;
    try
    {
        string sSQL = "";
        sSQL = "DELETE FROM " + TableName;
        sSQL += " WHERE " + CommitteeIDFN + "=" + CommitteeID;

        SqlCommand CommandSQL = new SqlCommand(sSQL, conn);

        CommandSQL.ExecuteNonQuery();
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

public int DeleteMemebr(SqlConnection conn)
{
    //DeleteAllRows = InitializeModule.FAIL_RET;
    try
    {
        string sSQL = "";
        sSQL = "DELETE FROM " + TableName;
        sSQL += " WHERE " + CommitteeIDFN + "=" + CommitteeID;
        sSQL += " AND " + MemberIDFN + "=" + MemberID;

        SqlCommand CommandSQL = new SqlCommand(sSQL, conn);

        CommandSQL.ExecuteNonQuery();
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
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(CommitteeIDFN)]== System.DBNull.Value)
{
  CommitteeID=0;
}
else
{
  CommitteeID = (int)CommitteeMembersDataRow[LibraryMOD.GetFieldName(CommitteeIDFN)];
}
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(MemberIDFN)]== System.DBNull.Value)
{
  MemberID=0;
}
else
{
  MemberID = (int)CommitteeMembersDataRow[LibraryMOD.GetFieldName(MemberIDFN)];
}
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)CommitteeMembersDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)CommitteeMembersDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)CommitteeMembersDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)CommitteeMembersDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)CommitteeMembersDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (CommitteeMembersDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)CommitteeMembersDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKCommitteeID,int PKMemberID) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKCommitteeID;
findTheseVals[1] = PKMemberID;
CommitteeMembersDataRow = dsCommitteeMembers.Tables[TableName].Rows.Find(findTheseVals);
if  ((CommitteeMembersDataRow !=null)) 
{
lngCurRow = dsCommitteeMembers.Tables[TableName].Rows.IndexOf(CommitteeMembersDataRow);
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
public int FindInMultiPKey(int PKCommitteeID)
{
    //FindInMultiPKey= InitializeModule.FAIL_RET;
    try
    {
        //' Create an array for the key values to find.
        object[] findTheseVals = new object[1];
        //' Set the values of the keys to find.
        findTheseVals[0] = PKCommitteeID;
        CommitteeMembersDataRow = dsCommitteeMembers.Tables[TableName].Rows.Find(findTheseVals);
        if ((CommitteeMembersDataRow != null))
        {
            lngCurRow = dsCommitteeMembers.Tables[TableName].Rows.IndexOf(CommitteeMembersDataRow);
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
  lngCurRow = dsCommitteeMembers.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsCommitteeMembers.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsCommitteeMembers.Tables[TableName].Rows.Count > 0) 
{
  CommitteeMembersDataRow = dsCommitteeMembers.Tables[TableName].Rows[lngCurRow];
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
daCommitteeMembers.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCommitteeMembers.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daCommitteeMembers.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCommitteeMembers.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
