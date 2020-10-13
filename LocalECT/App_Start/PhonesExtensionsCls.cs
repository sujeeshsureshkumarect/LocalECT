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
public class PhonesExtensions
{
//Creation Date: 10/12/2017 6:21:33 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_ExtensionSerialNo; 
private string m_ExtensionDesc; 
private int m_CampusID; 
private int m_EmployeeID; 
private string m_NormalPhoneExtension; 
private string m_IPPhoneExtension; 
private string m_Other; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int ExtensionSerialNo
{
get { return  m_ExtensionSerialNo; }
set {m_ExtensionSerialNo  = value ; }
}
public string ExtensionDesc
{
get { return  m_ExtensionDesc; }
set {m_ExtensionDesc  = value ; }
}
public int CampusID
{
get { return  m_CampusID; }
set {m_CampusID  = value ; }
}
public int EmployeeID
{
get { return  m_EmployeeID; }
set {m_EmployeeID  = value ; }
}
public string NormalPhoneExtension
{
get { return  m_NormalPhoneExtension; }
set {m_NormalPhoneExtension  = value ; }
}
public string IPPhoneExtension
{
get { return  m_IPPhoneExtension; }
set {m_IPPhoneExtension  = value ; }
}
public string Other
{
get { return  m_Other; }
set {m_Other  = value ; }
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
public PhonesExtensions()
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
public class PhonesExtensionsDAL : PhonesExtensions
{
#region "Decleration"
private string m_TableName;
private string m_ExtensionSerialNoFN ;
private string m_ExtensionDescFN ;
private string m_CampusIDFN ;
private string m_EmployeeIDFN ;
private string m_NormalPhoneExtensionFN ;
private string m_IPPhoneExtensionFN ;
private string m_OtherFN ;
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
public string ExtensionSerialNoFN 
{
get { return  m_ExtensionSerialNoFN; }
set {m_ExtensionSerialNoFN  = value ; }
}
public string ExtensionDescFN 
{
get { return  m_ExtensionDescFN; }
set {m_ExtensionDescFN  = value ; }
}
public string CampusIDFN 
{
get { return  m_CampusIDFN; }
set {m_CampusIDFN  = value ; }
}
public string EmployeeIDFN 
{
get { return  m_EmployeeIDFN; }
set {m_EmployeeIDFN  = value ; }
}
public string NormalPhoneExtensionFN 
{
get { return  m_NormalPhoneExtensionFN; }
set {m_NormalPhoneExtensionFN  = value ; }
}
public string IPPhoneExtensionFN 
{
get { return  m_IPPhoneExtensionFN; }
set {m_IPPhoneExtensionFN  = value ; }
}
public string OtherFN 
{
get { return  m_OtherFN; }
set {m_OtherFN  = value ; }
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
public PhonesExtensionsDAL()
{
try
{
this.TableName = "HR_PhonesExtensions";
this.ExtensionSerialNoFN = m_TableName + ".ExtensionSerialNo";
this.ExtensionDescFN = m_TableName + ".ExtensionDesc";
this.CampusIDFN = m_TableName + ".CampusID";
this.EmployeeIDFN = m_TableName + ".EmployeeID";
this.NormalPhoneExtensionFN = m_TableName + ".NormalPhoneExtension";
this.IPPhoneExtensionFN = m_TableName + ".IPPhoneExtension";
this.OtherFN = m_TableName + ".Other";
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
sSQL +=ExtensionSerialNoFN;
sSQL += " , " + ExtensionDescFN;
sSQL += " , " + CampusIDFN;
sSQL += " , " + EmployeeIDFN;
sSQL += " , " + NormalPhoneExtensionFN;
sSQL += " , " + IPPhoneExtensionFN;
sSQL += " , " + OtherFN;
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
sSQL +=ExtensionSerialNoFN;
sSQL += " , " + ExtensionDescFN;
sSQL += " , " + CampusIDFN;
sSQL += "  FROM " + m_TableName;
sSQL += " "  + sCondition;
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
sSQL +=ExtensionSerialNoFN;
sSQL += " , " + ExtensionDescFN;
sSQL += " , " + CampusIDFN;
sSQL += " , " + EmployeeIDFN;
sSQL += " , " + NormalPhoneExtensionFN;
sSQL += " , " + IPPhoneExtensionFN;
sSQL += " , " + OtherFN;
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
sSQL += LibraryMOD.GetFieldName(ExtensionSerialNoFN) + "=@ExtensionSerialNo";
sSQL += " , " + LibraryMOD.GetFieldName(ExtensionDescFN) + "=@ExtensionDesc";
sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN) + "=@CampusID";
sSQL += " , " + LibraryMOD.GetFieldName(EmployeeIDFN) + "=@EmployeeID";
sSQL += " , " + LibraryMOD.GetFieldName(NormalPhoneExtensionFN) + "=@NormalPhoneExtension";
sSQL += " , " + LibraryMOD.GetFieldName(IPPhoneExtensionFN) + "=@IPPhoneExtension";
sSQL += " , " + LibraryMOD.GetFieldName(OtherFN) + "=@Other";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(ExtensionSerialNoFN)+"=@ExtensionSerialNo";
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
sSQL +=LibraryMOD.GetFieldName(ExtensionSerialNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(ExtensionDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(EmployeeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(NormalPhoneExtensionFN);
sSQL += " , " + LibraryMOD.GetFieldName(IPPhoneExtensionFN);
sSQL += " , " + LibraryMOD.GetFieldName(OtherFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @ExtensionSerialNo";
sSQL += " ,@ExtensionDesc";
sSQL += " ,@CampusID";
sSQL += " ,@EmployeeID";
sSQL += " ,@NormalPhoneExtension";
sSQL += " ,@IPPhoneExtension";
sSQL += " ,@Other";
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
sSQL += LibraryMOD.GetFieldName(ExtensionSerialNoFN)+"=@ExtensionSerialNo";
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
public List< PhonesExtensions> GetPhonesExtensions(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the PhonesExtensions
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
List<PhonesExtensions> results = new List<PhonesExtensions>();
try
{
//Default Value
PhonesExtensions myPhonesExtensions = new PhonesExtensions();
if (isDeafaultIncluded)
{
//Change the code here
myPhonesExtensions.ExtensionSerialNo = 0;

results.Add(myPhonesExtensions);
}
while (reader.Read())
{
myPhonesExtensions = new PhonesExtensions();
if (reader[LibraryMOD.GetFieldName(ExtensionSerialNoFN)].Equals(DBNull.Value))
{
myPhonesExtensions.ExtensionSerialNo = 0;
}
else
{
myPhonesExtensions.ExtensionSerialNo = int.Parse(reader[LibraryMOD.GetFieldName( ExtensionSerialNoFN) ].ToString());
}
myPhonesExtensions.ExtensionDesc =reader[LibraryMOD.GetFieldName( ExtensionDescFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CampusIDFN)].Equals(DBNull.Value))
{
myPhonesExtensions.CampusID = 0;
}
else
{
myPhonesExtensions.CampusID = int.Parse(reader[LibraryMOD.GetFieldName( CampusIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myPhonesExtensions.EmployeeID = 0;
}
else
{
myPhonesExtensions.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
myPhonesExtensions.NormalPhoneExtension =reader[LibraryMOD.GetFieldName( NormalPhoneExtensionFN) ].ToString();
myPhonesExtensions.IPPhoneExtension =reader[LibraryMOD.GetFieldName( IPPhoneExtensionFN) ].ToString();
myPhonesExtensions.Other =reader[LibraryMOD.GetFieldName( OtherFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myPhonesExtensions.CreationUserID = 0;
}
else
{
myPhonesExtensions.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myPhonesExtensions.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myPhonesExtensions.LastUpdateUserID = 0;
}
else
{
myPhonesExtensions.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myPhonesExtensions.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myPhonesExtensions.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myPhonesExtensions.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myPhonesExtensions);
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
public List< PhonesExtensions > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<PhonesExtensions> results = new List<PhonesExtensions>();
try
{
//Default Value
PhonesExtensions myPhonesExtensions= new PhonesExtensions();
if (isDeafaultIncluded)
 {
//Change the code here
 myPhonesExtensions.ExtensionSerialNo = -1;
 myPhonesExtensions.ExtensionDesc = "Select PhonesExtensions" ;
results.Add(myPhonesExtensions);
 }
while (reader.Read())
{
myPhonesExtensions = new PhonesExtensions();
if (reader[LibraryMOD.GetFieldName(ExtensionSerialNoFN)].Equals(DBNull.Value))
{
myPhonesExtensions.ExtensionSerialNo = 0;
}
else
{
myPhonesExtensions.ExtensionSerialNo = int.Parse(reader[LibraryMOD.GetFieldName( ExtensionSerialNoFN) ].ToString());
}
myPhonesExtensions.ExtensionDesc =reader[LibraryMOD.GetFieldName( ExtensionDescFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CampusIDFN)].Equals(DBNull.Value))
{
myPhonesExtensions.CampusID = 0;
}
else
{
myPhonesExtensions.CampusID = int.Parse(reader[LibraryMOD.GetFieldName( CampusIDFN) ].ToString());
}
 results.Add(myPhonesExtensions);
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
public int UpdatePhonesExtensions(InitializeModule.EnumCampus Campus, int iMode,int ExtensionSerialNo,string ExtensionDesc,int CampusID,int EmployeeID,string NormalPhoneExtension,string IPPhoneExtension,string Other,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
PhonesExtensions thePhonesExtensions = new PhonesExtensions();
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
Cmd.Parameters.Add(new SqlParameter("@ExtensionSerialNo",ExtensionSerialNo));
Cmd.Parameters.Add(new SqlParameter("@ExtensionDesc",ExtensionDesc));
Cmd.Parameters.Add(new SqlParameter("@CampusID",CampusID));
Cmd.Parameters.Add(new SqlParameter("@EmployeeID",EmployeeID));
Cmd.Parameters.Add(new SqlParameter("@NormalPhoneExtension",NormalPhoneExtension));
Cmd.Parameters.Add(new SqlParameter("@IPPhoneExtension",IPPhoneExtension));
Cmd.Parameters.Add(new SqlParameter("@Other",Other));
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
public int DeletePhonesExtensions(InitializeModule.EnumCampus Campus,string ExtensionSerialNo)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@ExtensionSerialNo", ExtensionSerialNo ));
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
DataTable dt = new DataTable("PhonesExtensions");
DataView dv = new DataView();
List<PhonesExtensions> myPhonesExtensionss = new List<PhonesExtensions>();
try
{
myPhonesExtensionss = GetPhonesExtensions(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("ExtensionSerialNo", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myPhonesExtensionss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myPhonesExtensionss[i].ExtensionSerialNo;
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
myPhonesExtensionss.Clear();
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
sSQL += ExtensionSerialNoFN;
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
public class PhonesExtensionsCls : PhonesExtensionsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daPhonesExtensions;
private DataSet m_dsPhonesExtensions;
public DataRow PhonesExtensionsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsPhonesExtensions
{
get { return m_dsPhonesExtensions ; }
set { m_dsPhonesExtensions = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public PhonesExtensionsCls()
{
try
{
dsPhonesExtensions= new DataSet();

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
public virtual SqlDataAdapter GetPhonesExtensionsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daPhonesExtensions = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daPhonesExtensions);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daPhonesExtensions.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPhonesExtensions;
}
public virtual SqlDataAdapter GetPhonesExtensionsDataAdapter(SqlConnection con)  
{
try
{
daPhonesExtensions = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daPhonesExtensions.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdPhonesExtensions;
cmdPhonesExtensions = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@ExtensionSerialNo", SqlDbType.Int, 4, "ExtensionSerialNo" );
daPhonesExtensions.SelectCommand = cmdPhonesExtensions;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdPhonesExtensions = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdPhonesExtensions.Parameters.Add("@ExtensionSerialNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExtensionSerialNoFN));
cmdPhonesExtensions.Parameters.Add("@ExtensionDesc", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(ExtensionDescFN));
cmdPhonesExtensions.Parameters.Add("@CampusID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CampusIDFN));
cmdPhonesExtensions.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdPhonesExtensions.Parameters.Add("@NormalPhoneExtension", SqlDbType.NChar,24, LibraryMOD.GetFieldName(NormalPhoneExtensionFN));
cmdPhonesExtensions.Parameters.Add("@IPPhoneExtension", SqlDbType.NChar,24, LibraryMOD.GetFieldName(IPPhoneExtensionFN));
cmdPhonesExtensions.Parameters.Add("@Other", SqlDbType.NChar,24, LibraryMOD.GetFieldName(OtherFN));
cmdPhonesExtensions.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdPhonesExtensions.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdPhonesExtensions.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdPhonesExtensions.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdPhonesExtensions.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdPhonesExtensions.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdPhonesExtensions.Parameters.Add("@ExtensionSerialNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtensionSerialNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daPhonesExtensions.UpdateCommand = cmdPhonesExtensions;
daPhonesExtensions.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdPhonesExtensions = new SqlCommand(GetInsertCommand(), con);
cmdPhonesExtensions.Parameters.Add("@ExtensionSerialNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExtensionSerialNoFN));
cmdPhonesExtensions.Parameters.Add("@ExtensionDesc", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(ExtensionDescFN));
cmdPhonesExtensions.Parameters.Add("@CampusID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CampusIDFN));
cmdPhonesExtensions.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdPhonesExtensions.Parameters.Add("@NormalPhoneExtension", SqlDbType.NChar,24, LibraryMOD.GetFieldName(NormalPhoneExtensionFN));
cmdPhonesExtensions.Parameters.Add("@IPPhoneExtension", SqlDbType.NChar,24, LibraryMOD.GetFieldName(IPPhoneExtensionFN));
cmdPhonesExtensions.Parameters.Add("@Other", SqlDbType.NChar,24, LibraryMOD.GetFieldName(OtherFN));
cmdPhonesExtensions.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdPhonesExtensions.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdPhonesExtensions.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdPhonesExtensions.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdPhonesExtensions.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdPhonesExtensions.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daPhonesExtensions.InsertCommand =cmdPhonesExtensions;
daPhonesExtensions.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdPhonesExtensions = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdPhonesExtensions.Parameters.Add("@ExtensionSerialNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtensionSerialNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daPhonesExtensions.DeleteCommand =cmdPhonesExtensions;
daPhonesExtensions.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daPhonesExtensions.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPhonesExtensions;
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
dr = dsPhonesExtensions.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(ExtensionSerialNoFN)]=ExtensionSerialNo;
dr[LibraryMOD.GetFieldName(ExtensionDescFN)]=ExtensionDesc;
dr[LibraryMOD.GetFieldName(CampusIDFN)]=CampusID;
dr[LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
dr[LibraryMOD.GetFieldName(NormalPhoneExtensionFN)]=NormalPhoneExtension;
dr[LibraryMOD.GetFieldName(IPPhoneExtensionFN)]=IPPhoneExtension;
dr[LibraryMOD.GetFieldName(OtherFN)]=Other;
dsPhonesExtensions.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsPhonesExtensions.Tables[TableName].Select(LibraryMOD.GetFieldName(ExtensionSerialNoFN)  + "=" + ExtensionSerialNo);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(ExtensionSerialNoFN)]=ExtensionSerialNo;
drAry[0][LibraryMOD.GetFieldName(ExtensionDescFN)]=ExtensionDesc;
drAry[0][LibraryMOD.GetFieldName(CampusIDFN)]=CampusID;
drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
drAry[0][LibraryMOD.GetFieldName(NormalPhoneExtensionFN)]=NormalPhoneExtension;
drAry[0][LibraryMOD.GetFieldName(IPPhoneExtensionFN)]=IPPhoneExtension;
drAry[0][LibraryMOD.GetFieldName(OtherFN)]=Other;
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
public int CommitPhonesExtensions()  
{
//CommitPhonesExtensions= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daPhonesExtensions.Update(dsPhonesExtensions, TableName);
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
FindInMultiPKey(ExtensionSerialNo);
if (( PhonesExtensionsDataRow != null)) 
{
PhonesExtensionsDataRow.Delete();
CommitPhonesExtensions();
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
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(ExtensionSerialNoFN)]== System.DBNull.Value)
{
  ExtensionSerialNo=0;
}
else
{
  ExtensionSerialNo = (int)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(ExtensionSerialNoFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(ExtensionDescFN)]== System.DBNull.Value)
{
  ExtensionDesc="";
}
else
{
  ExtensionDesc = (string)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(ExtensionDescFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(CampusIDFN)]== System.DBNull.Value)
{
  CampusID=0;
}
else
{
  CampusID = (int)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(CampusIDFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)]== System.DBNull.Value)
{
  EmployeeID=0;
}
else
{
  EmployeeID = (int)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(NormalPhoneExtensionFN)]== System.DBNull.Value)
{
  NormalPhoneExtension="";
}
else
{
  NormalPhoneExtension = (string)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(NormalPhoneExtensionFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(IPPhoneExtensionFN)]== System.DBNull.Value)
{
  IPPhoneExtension="";
}
else
{
  IPPhoneExtension = (string)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(IPPhoneExtensionFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(OtherFN)]== System.DBNull.Value)
{
  Other="";
}
else
{
  Other = (string)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(OtherFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (PhonesExtensionsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)PhonesExtensionsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKExtensionSerialNo) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKExtensionSerialNo;
PhonesExtensionsDataRow = dsPhonesExtensions.Tables[TableName].Rows.Find(findTheseVals);
if  ((PhonesExtensionsDataRow !=null)) 
{
lngCurRow = dsPhonesExtensions.Tables[TableName].Rows.IndexOf(PhonesExtensionsDataRow);
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
  lngCurRow = dsPhonesExtensions.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsPhonesExtensions.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsPhonesExtensions.Tables[TableName].Rows.Count > 0) 
{
  PhonesExtensionsDataRow = dsPhonesExtensions.Tables[TableName].Rows[lngCurRow];
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
daPhonesExtensions.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPhonesExtensions.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daPhonesExtensions.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPhonesExtensions.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
