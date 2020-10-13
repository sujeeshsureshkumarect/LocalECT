using System;
using System.Data;
using System.Configuration;
using System.Linq;
//using System.Web;
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
public class EmployeeLanguageSkills
{
//Creation Date: 29/11/2010 2:44 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_EmployeeID; 
private int m_LanguageID; 
private int m_ReadLevelID; 
private int m_WriteLevelID; 
private int m_SpeakLevelID; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int EmployeeID
{
get { return  m_EmployeeID; }
set {m_EmployeeID  = value ; }
}
public int LanguageID
{
get { return  m_LanguageID; }
set {m_LanguageID  = value ; }
}
public int ReadLevelID
{
get { return  m_ReadLevelID; }
set {m_ReadLevelID  = value ; }
}
public int WriteLevelID
{
get { return  m_WriteLevelID; }
set {m_WriteLevelID  = value ; }
}
public int SpeakLevelID
{
get { return  m_SpeakLevelID; }
set {m_SpeakLevelID  = value ; }
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
public EmployeeLanguageSkills()
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
public class EmployeeLanguageSkillsDAL : EmployeeLanguageSkills
{
#region "Decleration"
private string m_TableName;
private string m_EmployeeIDFN ;
private string m_LanguageIDFN ;
private string m_ReadLevelIDFN ;
private string m_WriteLevelIDFN ;
private string m_SpeakLevelIDFN ;
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
public string EmployeeIDFN 
{
get { return  m_EmployeeIDFN; }
set {m_EmployeeIDFN  = value ; }
}
public string LanguageIDFN 
{
get { return  m_LanguageIDFN; }
set {m_LanguageIDFN  = value ; }
}
public string ReadLevelIDFN 
{
get { return  m_ReadLevelIDFN; }
set {m_ReadLevelIDFN  = value ; }
}
public string WriteLevelIDFN 
{
get { return  m_WriteLevelIDFN; }
set {m_WriteLevelIDFN  = value ; }
}
public string SpeakLevelIDFN 
{
get { return  m_SpeakLevelIDFN; }
set {m_SpeakLevelIDFN  = value ; }
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
public EmployeeLanguageSkillsDAL()
{
try
{
this.TableName = "Hr_EmployeeLanguageSkills";
this.EmployeeIDFN = m_TableName + ".EmployeeID";
this.LanguageIDFN = m_TableName + ".LanguageID";
this.ReadLevelIDFN = m_TableName + ".ReadLevelID";
this.WriteLevelIDFN = m_TableName + ".WriteLevelID";
this.SpeakLevelIDFN = m_TableName + ".SpeakLevelID";
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
sSQL +=EmployeeIDFN;
sSQL += " , " + LanguageIDFN;
sSQL += " , " + ReadLevelIDFN;
sSQL += " , " + WriteLevelIDFN;
sSQL += " , " + SpeakLevelIDFN;
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
//-----GetListSQl Function ---------------------------------
public string  GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=EmployeeIDFN;
sSQL += " , " + LanguageIDFN;
sSQL += " , " + ReadLevelIDFN;
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
sSQL +=EmployeeIDFN;
sSQL += " , " + LanguageIDFN;
sSQL += " , " + ReadLevelIDFN;
sSQL += " , " + WriteLevelIDFN;
sSQL += " , " + SpeakLevelIDFN;
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN) + "=@EmployeeID";
sSQL += " , " + LibraryMOD.GetFieldName(LanguageIDFN) + "=@LanguageID";
sSQL += " , " + LibraryMOD.GetFieldName(ReadLevelIDFN) + "=@ReadLevelID";
sSQL += " , " + LibraryMOD.GetFieldName(WriteLevelIDFN) + "=@WriteLevelID";
sSQL += " , " + LibraryMOD.GetFieldName(SpeakLevelIDFN) + "=@SpeakLevelID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " + LibraryMOD.GetFieldName(LanguageIDFN)+"=@LanguageID";
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
sSQL +=LibraryMOD.GetFieldName(EmployeeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LanguageIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ReadLevelIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(WriteLevelIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SpeakLevelIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @EmployeeID";
sSQL += " ,@LanguageID";
sSQL += " ,@ReadLevelID";
sSQL += " ,@WriteLevelID";
sSQL += " ,@SpeakLevelID";
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(LanguageIDFN)+"=@LanguageID";
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
public List< EmployeeLanguageSkills> GetEmployeeLanguageSkills(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the EmployeeLanguageSkills
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
List<EmployeeLanguageSkills> results = new List<EmployeeLanguageSkills>();
try
{
//Default Value
EmployeeLanguageSkills myEmployeeLanguageSkills = new EmployeeLanguageSkills();
if (isDeafaultIncluded)
{
//Change the code here
myEmployeeLanguageSkills.EmployeeID = 0;
myEmployeeLanguageSkills.LanguageID = 0;
myEmployeeLanguageSkills.ReadLevelID = 0;
results.Add(myEmployeeLanguageSkills);
}
while (reader.Read())
{
myEmployeeLanguageSkills = new EmployeeLanguageSkills();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.EmployeeID = 0;
}
else
{
myEmployeeLanguageSkills.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LanguageIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.LanguageID = 0;
}
else
{
myEmployeeLanguageSkills.LanguageID = int.Parse(reader[LibraryMOD.GetFieldName( LanguageIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ReadLevelIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.ReadLevelID = 0;
}
else
{
myEmployeeLanguageSkills.ReadLevelID = int.Parse(reader[LibraryMOD.GetFieldName( ReadLevelIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(WriteLevelIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.WriteLevelID = 0;
}
else
{
myEmployeeLanguageSkills.WriteLevelID = int.Parse(reader[LibraryMOD.GetFieldName( WriteLevelIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SpeakLevelIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.SpeakLevelID = 0;
}
else
{
myEmployeeLanguageSkills.SpeakLevelID = int.Parse(reader[LibraryMOD.GetFieldName( SpeakLevelIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.CreationUserID = 0;
}
else
{
myEmployeeLanguageSkills.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.LastUpdateUserID = 0;
}
else
{
myEmployeeLanguageSkills.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myEmployeeLanguageSkills.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myEmployeeLanguageSkills.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myEmployeeLanguageSkills);
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
public List< EmployeeLanguageSkills > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<EmployeeLanguageSkills> results = new List<EmployeeLanguageSkills>();
try
{
//Default Value
EmployeeLanguageSkills myEmployeeLanguageSkills= new EmployeeLanguageSkills();
if (isDeafaultIncluded) 
 {
//Change the code here
 myEmployeeLanguageSkills.EmployeeID = -1;
 myEmployeeLanguageSkills.LanguageID = 0 ;
results.Add(myEmployeeLanguageSkills);
 }
while (reader.Read())
{
myEmployeeLanguageSkills = new EmployeeLanguageSkills();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.EmployeeID = 0;
}
else
{
myEmployeeLanguageSkills.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LanguageIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.LanguageID = 0;
}
else
{
myEmployeeLanguageSkills.LanguageID = int.Parse(reader[LibraryMOD.GetFieldName( LanguageIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ReadLevelIDFN)].Equals(DBNull.Value))
{
myEmployeeLanguageSkills.ReadLevelID = 0;
}
else
{
myEmployeeLanguageSkills.ReadLevelID = int.Parse(reader[LibraryMOD.GetFieldName( ReadLevelIDFN) ].ToString());
}
 results.Add(myEmployeeLanguageSkills);
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
public int UpdateEmployeeLanguageSkills(InitializeModule.EnumCampus Campus, int iMode,int EmployeeID,int LanguageID,int ReadLevelID,int WriteLevelID,int SpeakLevelID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EmployeeLanguageSkills theEmployeeLanguageSkills = new EmployeeLanguageSkills();
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
Cmd.Parameters.Add(new SqlParameter("@EmployeeID",EmployeeID));
Cmd.Parameters.Add(new SqlParameter("@LanguageID",LanguageID));
Cmd.Parameters.Add(new SqlParameter("@ReadLevelID",ReadLevelID));
Cmd.Parameters.Add(new SqlParameter("@WriteLevelID",WriteLevelID));
Cmd.Parameters.Add(new SqlParameter("@SpeakLevelID",SpeakLevelID));
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
public int DeleteEmployeeLanguageSkills(InitializeModule.EnumCampus Campus,string EmployeeID,string LanguageID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID ));
Cmd.Parameters.Add(new SqlParameter("@LanguageID", LanguageID ));
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
DataTable dt = new DataTable("EmployeeLanguageSkills");
DataView dv = new DataView();
List<EmployeeLanguageSkills> myEmployeeLanguageSkillss = new List<EmployeeLanguageSkills>();
try
{
myEmployeeLanguageSkillss = GetEmployeeLanguageSkills(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("EmployeeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("LanguageID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("ReadLevelID", Type.GetType("int"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myEmployeeLanguageSkillss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myEmployeeLanguageSkillss[i].EmployeeID;
  dr[2] = myEmployeeLanguageSkillss[i].LanguageID;
  dr[3] = myEmployeeLanguageSkillss[i].ReadLevelID;
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
myEmployeeLanguageSkillss.Clear();
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
sSQL += EmployeeIDFN;
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
public class EmployeeLanguageSkillsCls : EmployeeLanguageSkillsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daEmployeeLanguageSkills;
private DataSet m_dsEmployeeLanguageSkills;
public DataRow EmployeeLanguageSkillsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsEmployeeLanguageSkills
{
get { return m_dsEmployeeLanguageSkills ; }
set { m_dsEmployeeLanguageSkills = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EmployeeLanguageSkillsCls()
{
try
{
dsEmployeeLanguageSkills= new DataSet();

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
public virtual SqlDataAdapter GetEmployeeLanguageSkillsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daEmployeeLanguageSkills = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daEmployeeLanguageSkills);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeLanguageSkills.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeLanguageSkills;
}
public virtual SqlDataAdapter GetEmployeeLanguageSkillsDataAdapter(SqlConnection con)  
{
try
{
daEmployeeLanguageSkills = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeLanguageSkills.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdEmployeeLanguageSkills;
cmdEmployeeLanguageSkills = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, "EmployeeID" );
//'cmdRolePermission.Parameters.Add("@LanguageID", SqlDbType.Int, 4, "LanguageID" );
daEmployeeLanguageSkills.SelectCommand = cmdEmployeeLanguageSkills;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdEmployeeLanguageSkills = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdEmployeeLanguageSkills.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@LanguageID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LanguageIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@ReadLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ReadLevelIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@WriteLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(WriteLevelIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@SpeakLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SpeakLevelIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployeeLanguageSkills.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployeeLanguageSkills.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployeeLanguageSkills.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdEmployeeLanguageSkills.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeLanguageSkills.Parameters.Add("@LanguageID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LanguageIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daEmployeeLanguageSkills.UpdateCommand = cmdEmployeeLanguageSkills;
daEmployeeLanguageSkills.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdEmployeeLanguageSkills = new SqlCommand(GetInsertCommand(), con);
cmdEmployeeLanguageSkills.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@LanguageID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LanguageIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@ReadLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ReadLevelIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@WriteLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(WriteLevelIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@SpeakLevelID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SpeakLevelIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployeeLanguageSkills.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployeeLanguageSkills.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployeeLanguageSkills.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployeeLanguageSkills.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daEmployeeLanguageSkills.InsertCommand =cmdEmployeeLanguageSkills;
daEmployeeLanguageSkills.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdEmployeeLanguageSkills = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdEmployeeLanguageSkills.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeLanguageSkills.Parameters.Add("@LanguageID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LanguageIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daEmployeeLanguageSkills.DeleteCommand =cmdEmployeeLanguageSkills;
daEmployeeLanguageSkills.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daEmployeeLanguageSkills.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeLanguageSkills;
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
dr = dsEmployeeLanguageSkills.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
dr[LibraryMOD.GetFieldName(LanguageIDFN)]=LanguageID;
dr[LibraryMOD.GetFieldName(ReadLevelIDFN)]=ReadLevelID;
dr[LibraryMOD.GetFieldName(WriteLevelIDFN)]=WriteLevelID;
dr[LibraryMOD.GetFieldName(SpeakLevelIDFN)]=SpeakLevelID;
dsEmployeeLanguageSkills.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsEmployeeLanguageSkills.Tables[TableName].Select(LibraryMOD.GetFieldName(EmployeeIDFN)  + "=" + EmployeeID  + " AND " + LibraryMOD.GetFieldName(LanguageIDFN) + "=" + LanguageID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
drAry[0][LibraryMOD.GetFieldName(LanguageIDFN)]=LanguageID;
drAry[0][LibraryMOD.GetFieldName(ReadLevelIDFN)]=ReadLevelID;
drAry[0][LibraryMOD.GetFieldName(WriteLevelIDFN)]=WriteLevelID;
drAry[0][LibraryMOD.GetFieldName(SpeakLevelIDFN)]=SpeakLevelID;
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
public int CommitEmployeeLanguageSkills()  
{
//CommitEmployeeLanguageSkills= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daEmployeeLanguageSkills.Update(dsEmployeeLanguageSkills, TableName);
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
FindInMultiPKey(EmployeeID,LanguageID);
if (( EmployeeLanguageSkillsDataRow != null)) 
{
EmployeeLanguageSkillsDataRow.Delete();
CommitEmployeeLanguageSkills();
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
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)]== System.DBNull.Value)
{
  EmployeeID=0;
}
else
{
  EmployeeID = (int)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(LanguageIDFN)]== System.DBNull.Value)
{
  LanguageID=0;
}
else
{
  LanguageID = (int)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(LanguageIDFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(ReadLevelIDFN)]== System.DBNull.Value)
{
  ReadLevelID=0;
}
else
{
  ReadLevelID = (int)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(ReadLevelIDFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(WriteLevelIDFN)]== System.DBNull.Value)
{
  WriteLevelID=0;
}
else
{
  WriteLevelID = (int)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(WriteLevelIDFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(SpeakLevelIDFN)]== System.DBNull.Value)
{
  SpeakLevelID=0;
}
else
{
  SpeakLevelID = (int)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(SpeakLevelIDFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)EmployeeLanguageSkillsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKEmployeeID,int PKLanguageID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKEmployeeID;
findTheseVals[1] = PKLanguageID;
EmployeeLanguageSkillsDataRow = dsEmployeeLanguageSkills.Tables[TableName].Rows.Find(findTheseVals);
if  ((EmployeeLanguageSkillsDataRow !=null)) 
{
lngCurRow = dsEmployeeLanguageSkills.Tables[TableName].Rows.IndexOf(EmployeeLanguageSkillsDataRow);
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
  lngCurRow = dsEmployeeLanguageSkills.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsEmployeeLanguageSkills.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsEmployeeLanguageSkills.Tables[TableName].Rows.Count > 0) 
{
  EmployeeLanguageSkillsDataRow = dsEmployeeLanguageSkills.Tables[TableName].Rows[lngCurRow];
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
daEmployeeLanguageSkills.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeLanguageSkills.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daEmployeeLanguageSkills.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeLanguageSkills.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
