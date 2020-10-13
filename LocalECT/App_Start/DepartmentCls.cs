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
public class Department
{
//Creation Date: 03/10/2010 7:37 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_DepartmentID; 
private string m_DescEN; 
private string m_DescAr; 
private int m_ManagerID; 
private int m_DepartmentRefID; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int DepartmentID
{
get { return  m_DepartmentID; }
set {m_DepartmentID  = value ; }
}
public string DescEN
{
get { return  m_DescEN; }
set {m_DescEN  = value ; }
}
public string DescAr
{
get { return  m_DescAr; }
set {m_DescAr  = value ; }
}
public int ManagerID
{
get { return  m_ManagerID; }
set {m_ManagerID  = value ; }
}
public int DepartmentRefID
{
get { return  m_DepartmentRefID; }
set {m_DepartmentRefID  = value ; }
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
public Department()
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
public class DepartmentDAL : Department
{
#region "Decleration"
private string m_TableName;
private string m_DepartmentIDFN ;
private string m_DescENFN ;
private string m_DescArFN ;
private string m_ManagerIDFN ;
private string m_DepartmentRefIDFN ;
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
public string DepartmentIDFN 
{
get { return  m_DepartmentIDFN; }
set {m_DepartmentIDFN  = value ; }
}
public string DescENFN 
{
get { return  m_DescENFN; }
set {m_DescENFN  = value ; }
}
public string DescArFN 
{
get { return  m_DescArFN; }
set {m_DescArFN  = value ; }
}
public string ManagerIDFN 
{
get { return  m_ManagerIDFN; }
set {m_ManagerIDFN  = value ; }
}
public string DepartmentRefIDFN 
{
get { return  m_DepartmentRefIDFN; }
set {m_DepartmentRefIDFN  = value ; }
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
public DepartmentDAL()
{
try
{
this.TableName = "Lkp_Department";
this.DepartmentIDFN = m_TableName + ".DepartmentID";
this.DescENFN = m_TableName + ".DescEN";
this.DescArFN = m_TableName + ".DescAr";
this.ManagerIDFN = m_TableName + ".ManagerID";
this.DepartmentRefIDFN = m_TableName + ".DepartmentRefID";
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
sSQL +=DepartmentIDFN;
sSQL += " , " + DescENFN;
sSQL += " , " + DescArFN;
sSQL += " , " + ManagerIDFN;
sSQL += " , " + DepartmentRefIDFN;
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
public string GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=DepartmentIDFN;
sSQL += " , " + DescENFN;
sSQL += " , " + DescArFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION;
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
sSQL +=DepartmentIDFN;
sSQL += " , " + DescENFN;
sSQL += " , " + DescArFN;
sSQL += " , " + ManagerIDFN;
sSQL += " , " + DepartmentRefIDFN;
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
sSQL += LibraryMOD.GetFieldName(DepartmentIDFN) + "=@DepartmentID";
sSQL += " , " + LibraryMOD.GetFieldName(DescENFN) + "=@DescEN";
sSQL += " , " + LibraryMOD.GetFieldName(DescArFN) + "=@DescAr";
sSQL += " , " + LibraryMOD.GetFieldName(ManagerIDFN) + "=@ManagerID";
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentRefIDFN) + "=@DepartmentRefID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(DepartmentIDFN)+"=@DepartmentID";
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
sSQL +=LibraryMOD.GetFieldName(DepartmentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(DescENFN);
sSQL += " , " + LibraryMOD.GetFieldName(DescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(ManagerIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentRefIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @DepartmentID";
sSQL += " ,@DescEN";
sSQL += " ,@DescAr";
sSQL += " ,@ManagerID";
sSQL += " ,@DepartmentRefID";
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
sSQL += LibraryMOD.GetFieldName(DepartmentIDFN)+"=@DepartmentID";
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
public List< Department> GetDepartment(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Department
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
List<Department> results = new List<Department>();
try
{
//Default Value
Department myDepartment = new Department();
if (isDeafaultIncluded)
{
//Change the code here
myDepartment.DepartmentID = 0;
myDepartment.DescEN = "Select Department ...";
results.Add(myDepartment);
}
while (reader.Read())
{
myDepartment = new Department();
if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
{
myDepartment.DepartmentID = 0;
}
else
{
myDepartment.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentIDFN) ].ToString());
}
myDepartment.DescEN =reader[LibraryMOD.GetFieldName( DescENFN) ].ToString();
myDepartment.DescAr =reader[LibraryMOD.GetFieldName( DescArFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(ManagerIDFN)].Equals(DBNull.Value))
{
myDepartment.ManagerID = 0;
}
else
{
myDepartment.ManagerID = int.Parse(reader[LibraryMOD.GetFieldName( ManagerIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(DepartmentRefIDFN)].Equals(DBNull.Value))
{
myDepartment.DepartmentRefID = 0;
}
else
{
myDepartment.DepartmentRefID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentRefIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myDepartment.CreationUserID = 0;
}
else
{
myDepartment.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myDepartment.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myDepartment.LastUpdateUserID = 0;
}
else
{
myDepartment.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myDepartment.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myDepartment.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myDepartment.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myDepartment);
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
public List< Department > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Department> results = new List<Department>();
try
{
//Default Value
Department myDepartment= new Department();
if (isDeafaultIncluded) 
 {
//Change the code here
 myDepartment.DepartmentID = -1;
 myDepartment.DescEN = "Select Department" ;
results.Add(myDepartment);
 }
while (reader.Read())
{
myDepartment = new Department();
if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
{
myDepartment.DepartmentID = 0;
}
else
{
myDepartment.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentIDFN) ].ToString());
}
myDepartment.DescEN =reader[LibraryMOD.GetFieldName( DescENFN) ].ToString();
myDepartment.DescAr =reader[LibraryMOD.GetFieldName( DescArFN) ].ToString();
 results.Add(myDepartment);
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
public int UpdateDepartment(InitializeModule.EnumCampus Campus, int iMode,int DepartmentID,string DescEN,string DescAr,int ManagerID,int DepartmentRefID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Department theDepartment = new Department();
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
Cmd.Parameters.Add(new SqlParameter("@DepartmentID",DepartmentID));
Cmd.Parameters.Add(new SqlParameter("@DescEN",DescEN));
Cmd.Parameters.Add(new SqlParameter("@DescAr",DescAr));
Cmd.Parameters.Add(new SqlParameter("@ManagerID",ManagerID));
Cmd.Parameters.Add(new SqlParameter("@DepartmentRefID",DepartmentRefID));
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
public int DeleteDepartment(InitializeModule.EnumCampus Campus,string DepartmentID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@DepartmentID", DepartmentID ));
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
DataTable dt = new DataTable("Department");
DataView dv = new DataView();
List<Department> myDepartments = new List<Department>();
try
{
myDepartments = GetDepartment(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("DepartmentID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("DescEN", Type.GetType("varchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("DescAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myDepartments.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myDepartments[i].DepartmentID;
  dr[2] = myDepartments[i].DescEN;
  dr[3] = myDepartments[i].DescAr;
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
myDepartments.Clear();
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
sSQL += DepartmentIDFN;
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
public class DepartmentCls : DepartmentDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daDepartment;
private DataSet m_dsDepartment;
public DataRow DepartmentDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsDepartment
{
get { return m_dsDepartment ; }
set { m_dsDepartment = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public DepartmentCls()
{
try
{
dsDepartment= new DataSet();

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
public virtual SqlDataAdapter GetDepartmentDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daDepartment = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daDepartment);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daDepartment.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDepartment;
}
public virtual SqlDataAdapter GetDepartmentDataAdapter(SqlConnection con)  
{
try
{
daDepartment = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daDepartment.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdDepartment;
cmdDepartment = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@DepartmentID", SqlDbType.Int, 4, "DepartmentID" );
daDepartment.SelectCommand = cmdDepartment;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdDepartment = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdDepartment.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdDepartment.Parameters.Add("@DescEN", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(DescENFN));
cmdDepartment.Parameters.Add("@DescAr", SqlDbType.NVarChar,300, LibraryMOD.GetFieldName(DescArFN));
cmdDepartment.Parameters.Add("@ManagerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ManagerIDFN));
cmdDepartment.Parameters.Add("@DepartmentRefID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentRefIDFN));
cmdDepartment.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdDepartment.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdDepartment.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdDepartment.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdDepartment.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdDepartment.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdDepartment.Parameters.Add("@DepartmentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DepartmentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daDepartment.UpdateCommand = cmdDepartment;
daDepartment.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdDepartment = new SqlCommand(GetInsertCommand(), con);
cmdDepartment.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdDepartment.Parameters.Add("@DescEN", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(DescENFN));
cmdDepartment.Parameters.Add("@DescAr", SqlDbType.NVarChar,300, LibraryMOD.GetFieldName(DescArFN));
cmdDepartment.Parameters.Add("@ManagerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ManagerIDFN));
cmdDepartment.Parameters.Add("@DepartmentRefID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentRefIDFN));
cmdDepartment.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdDepartment.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdDepartment.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdDepartment.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdDepartment.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdDepartment.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daDepartment.InsertCommand =cmdDepartment;
daDepartment.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdDepartment = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdDepartment.Parameters.Add("@DepartmentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DepartmentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daDepartment.DeleteCommand =cmdDepartment;
daDepartment.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daDepartment.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDepartment;
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
dr = dsDepartment.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
dr[LibraryMOD.GetFieldName(DescENFN)]=DescEN;
dr[LibraryMOD.GetFieldName(DescArFN)]=DescAr;
dr[LibraryMOD.GetFieldName(ManagerIDFN)]=ManagerID;
dr[LibraryMOD.GetFieldName(DepartmentRefIDFN)]=DepartmentRefID;
dsDepartment.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsDepartment.Tables[TableName].Select(LibraryMOD.GetFieldName(DepartmentIDFN)  + "=" + DepartmentID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
drAry[0][LibraryMOD.GetFieldName(DescENFN)]=DescEN;
drAry[0][LibraryMOD.GetFieldName(DescArFN)]=DescAr;
drAry[0][LibraryMOD.GetFieldName(ManagerIDFN)]=ManagerID;
drAry[0][LibraryMOD.GetFieldName(DepartmentRefIDFN)]=DepartmentRefID;
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
public int CommitDepartment()  
{
//CommitDepartment= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daDepartment.Update(dsDepartment, TableName);
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
FindInMultiPKey(DepartmentID);
if (( DepartmentDataRow != null)) 
{
DepartmentDataRow.Delete();
CommitDepartment();
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
if (DepartmentDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)]== System.DBNull.Value)
{
  DepartmentID=0;
}
else
{
  DepartmentID = (int)DepartmentDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(DescENFN)]== System.DBNull.Value)
{
  DescEN="";
}
else
{
  DescEN = (string)DepartmentDataRow[LibraryMOD.GetFieldName(DescENFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(DescArFN)]== System.DBNull.Value)
{
  DescAr="";
}
else
{
  DescAr = (string)DepartmentDataRow[LibraryMOD.GetFieldName(DescArFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(ManagerIDFN)]== System.DBNull.Value)
{
  ManagerID=0;
}
else
{
  ManagerID = (int)DepartmentDataRow[LibraryMOD.GetFieldName(ManagerIDFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(DepartmentRefIDFN)]== System.DBNull.Value)
{
  DepartmentRefID=0;
}
else
{
  DepartmentRefID = (int)DepartmentDataRow[LibraryMOD.GetFieldName(DepartmentRefIDFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)DepartmentDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)DepartmentDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)DepartmentDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)DepartmentDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)DepartmentDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (DepartmentDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)DepartmentDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKDepartmentID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKDepartmentID;
DepartmentDataRow = dsDepartment.Tables[TableName].Rows.Find(findTheseVals);
if  ((DepartmentDataRow !=null)) 
{
lngCurRow = dsDepartment.Tables[TableName].Rows.IndexOf(DepartmentDataRow);
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
  lngCurRow = dsDepartment.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsDepartment.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsDepartment.Tables[TableName].Rows.Count > 0) 
{
  DepartmentDataRow = dsDepartment.Tables[TableName].Rows[lngCurRow];
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
daDepartment.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDepartment.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daDepartment.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDepartment.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
