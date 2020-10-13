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
public class SectionofDept
{
//Creation Date: 05/05/2019 4:45:34 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_SectionID; 
private int m_DepartmentID; 
private string m_SectionAbbreviation; 
private string m_DescEN; 
private string m_DescAr; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
private int m_ManagerID; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int SectionID
{
get { return  m_SectionID; }
set {m_SectionID  = value ; }
}
public int DepartmentID
{
get { return  m_DepartmentID; }
set {m_DepartmentID  = value ; }
}
public string SectionAbbreviation
{
get { return  m_SectionAbbreviation; }
set {m_SectionAbbreviation  = value ; }
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
public int ManagerID
{
get { return  m_ManagerID; }
set {m_ManagerID  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public SectionofDept()
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
public class SectionDAL : SectionofDept
{
#region "Decleration"
private string m_TableName;
private string m_SectionIDFN ;
private string m_DepartmentIDFN ;
private string m_SectionAbbreviationFN ;
private string m_DescENFN ;
private string m_DescArFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
private string m_ManagerIDFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string SectionIDFN 
{
get { return  m_SectionIDFN; }
set {m_SectionIDFN  = value ; }
}
public string DepartmentIDFN 
{
get { return  m_DepartmentIDFN; }
set {m_DepartmentIDFN  = value ; }
}
public string SectionAbbreviationFN 
{
get { return  m_SectionAbbreviationFN; }
set {m_SectionAbbreviationFN  = value ; }
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
public string ManagerIDFN 
{
get { return  m_ManagerIDFN; }
set {m_ManagerIDFN  = value ; }
}
#endregion
//================End Properties ===================
public SectionDAL()
{
try
{
this.TableName = "Lkp_Section";
this.SectionIDFN = m_TableName + ".SectionID";
this.DepartmentIDFN = m_TableName + ".DepartmentID";
this.SectionAbbreviationFN = m_TableName + ".SectionAbbreviation";
this.DescENFN = m_TableName + ".DescEN";
this.DescArFN = m_TableName + ".DescAr";
this.CreationUserIDFN = m_TableName + ".CreationUserID";
this.CreationDateFN = m_TableName + ".CreationDate";
this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
this.PCNameFN = m_TableName + ".PCName";
this.NetUserNameFN = m_TableName + ".NetUserName";
this.ManagerIDFN = m_TableName + ".ManagerID";
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
sSQL +=SectionIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + SectionAbbreviationFN;
sSQL += " , " + DescENFN;
sSQL += " , " + DescArFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += " , " + ManagerIDFN;
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
sSQL +=SectionIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + SectionAbbreviationFN;
sSQL += "  FROM " + m_TableName;
sSQL += " WHERE 1=1";
if (sCondition != "")
{
    sSQL += sCondition;
}

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
sSQL +=SectionIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + SectionAbbreviationFN;
sSQL += " , " + DescENFN;
sSQL += " , " + DescArFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += " , " + ManagerIDFN;
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
sSQL += LibraryMOD.GetFieldName(SectionIDFN) + "=@SectionID";
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN) + "=@DepartmentID";
sSQL += " , " + LibraryMOD.GetFieldName(SectionAbbreviationFN) + "=@SectionAbbreviation";
sSQL += " , " + LibraryMOD.GetFieldName(DescENFN) + "=@DescEN";
sSQL += " , " + LibraryMOD.GetFieldName(DescArFN) + "=@DescAr";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " , " + LibraryMOD.GetFieldName(ManagerIDFN) + "=@ManagerID";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(SectionIDFN)+"=@SectionID";
sSQL +=  " And " + LibraryMOD.GetFieldName(DepartmentIDFN)+"=@DepartmentID";
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
sSQL +=LibraryMOD.GetFieldName(SectionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SectionAbbreviationFN);
sSQL += " , " + LibraryMOD.GetFieldName(DescENFN);
sSQL += " , " + LibraryMOD.GetFieldName(DescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(ManagerIDFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @SectionID";
sSQL += " ,@DepartmentID";
sSQL += " ,@SectionAbbreviation";
sSQL += " ,@DescEN";
sSQL += " ,@DescAr";
sSQL += " ,@CreationUserID";
sSQL += " ,@CreationDate";
sSQL += " ,@LastUpdateUserID";
sSQL += " ,@LastUpdateDate";
sSQL += " ,@PCName";
sSQL += " ,@NetUserName";
sSQL += " ,@ManagerID";
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
sSQL += LibraryMOD.GetFieldName(SectionIDFN)+"=@SectionID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(DepartmentIDFN)+"=@DepartmentID";
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
public List<SectionofDept> GetSection(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Section
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
List<SectionofDept> results = new List<SectionofDept>();
try
{
//Default Value
    SectionofDept mySection = new SectionofDept();
if (isDeafaultIncluded)
{
//Change the code here
mySection.SectionID = 0;
mySection.DepartmentID = 0;
mySection.DescEN  = "Select Section ...";
results.Add(mySection);
}
while (reader.Read())
{
    mySection = new SectionofDept();
if (reader[LibraryMOD.GetFieldName(SectionIDFN)].Equals(DBNull.Value))
{
mySection.SectionID = 0;
}
else
{
mySection.SectionID = int.Parse(reader[LibraryMOD.GetFieldName( SectionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
{
mySection.DepartmentID = 0;
}
else
{
mySection.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentIDFN) ].ToString());
}
mySection.SectionAbbreviation =reader[LibraryMOD.GetFieldName( SectionAbbreviationFN) ].ToString();
mySection.DescEN =reader[LibraryMOD.GetFieldName( DescENFN) ].ToString();
mySection.DescAr =reader[LibraryMOD.GetFieldName( DescArFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
mySection.CreationUserID = 0;
}
else
{
mySection.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
mySection.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
mySection.LastUpdateUserID = 0;
}
else
{
mySection.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
mySection.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
mySection.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
mySection.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(ManagerIDFN)].Equals(DBNull.Value))
{
mySection.ManagerID = 0;
}
else
{
mySection.ManagerID = int.Parse(reader[LibraryMOD.GetFieldName( ManagerIDFN) ].ToString());
}
 results.Add(mySection);
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
public List<SectionofDept> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<SectionofDept> results = new List<SectionofDept>();
try
{
//Default Value
    SectionofDept mySection = new SectionofDept();
if (isDeafaultIncluded)
 {
//Change the code here
 mySection.SectionID = -1;
 mySection.DescEN  = "Select Section" ;
results.Add(mySection);
 }
while (reader.Read())
{
    mySection = new SectionofDept();
if (reader[LibraryMOD.GetFieldName(SectionIDFN)].Equals(DBNull.Value))
{
mySection.SectionID = 0;
}
else
{
mySection.SectionID = int.Parse(reader[LibraryMOD.GetFieldName( SectionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
{
mySection.DepartmentID = 0;
}
else
{
mySection.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentIDFN) ].ToString());
}
mySection.SectionAbbreviation =reader[LibraryMOD.GetFieldName( SectionAbbreviationFN) ].ToString();
 results.Add(mySection);
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
public int UpdateSection(InitializeModule.EnumCampus Campus, int iMode,int SectionID,int DepartmentID,string SectionAbbreviation,string DescEN,string DescAr,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName,int ManagerID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
SectionofDept theSection = new SectionofDept();
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
Cmd.Parameters.Add(new SqlParameter("@SectionID",SectionID));
Cmd.Parameters.Add(new SqlParameter("@DepartmentID",DepartmentID));
Cmd.Parameters.Add(new SqlParameter("@SectionAbbreviation",SectionAbbreviation));
Cmd.Parameters.Add(new SqlParameter("@DescEN",DescEN));
Cmd.Parameters.Add(new SqlParameter("@DescAr",DescAr));
Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
Cmd.Parameters.Add(new SqlParameter("@ManagerID",ManagerID));
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
public int DeleteSection(InitializeModule.EnumCampus Campus,string SectionID,string DepartmentID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@SectionID", SectionID ));
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
DataTable dt = new DataTable("Section");
DataView dv = new DataView();
List<SectionofDept> mySections = new List<SectionofDept>();
try
{
mySections = GetSection(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("SectionID", Type.GetType("int"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("DepartmentID", Type.GetType("int"));
dt.Columns.Add(col1 );
dt.Constraints.Add(new UniqueConstraint(col0));
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < mySections.Count; i++)
{
dr = dt.NewRow();
  dr[1] = mySections[i].SectionID;
  dr[2] = mySections[i].DepartmentID;
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
mySections.Clear();
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
sSQL += SectionIDFN;
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
public class SectionCls : SectionDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daSection;
private DataSet m_dsSection;
public DataRow SectionDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsSection
{
get { return m_dsSection ; }
set { m_dsSection = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public SectionCls()
{
try
{
dsSection= new DataSet();

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
public virtual SqlDataAdapter GetSectionDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daSection = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSection);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daSection.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSection;
}
public virtual SqlDataAdapter GetSectionDataAdapter(SqlConnection con)  
{
try
{
daSection = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daSection.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdSection;
cmdSection = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@SectionID", SqlDbType.Int, 4, "SectionID" );
//'cmdRolePermission.Parameters.Add("@DepartmentID", SqlDbType.Int, 4, "DepartmentID" );
daSection.SelectCommand = cmdSection;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdSection = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdSection.Parameters.Add("@SectionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SectionIDFN));
cmdSection.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdSection.Parameters.Add("@SectionAbbreviation", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(SectionAbbreviationFN));
cmdSection.Parameters.Add("@DescEN", SqlDbType.VarChar,150, LibraryMOD.GetFieldName(DescENFN));
cmdSection.Parameters.Add("@DescAr", SqlDbType.NVarChar,300, LibraryMOD.GetFieldName(DescArFN));
cmdSection.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdSection.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdSection.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdSection.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdSection.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdSection.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
cmdSection.Parameters.Add("@ManagerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ManagerIDFN));


Parmeter = cmdSection.Parameters.Add("@SectionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SectionIDFN));
Parmeter = cmdSection.Parameters.Add("@DepartmentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DepartmentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daSection.UpdateCommand = cmdSection;
daSection.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdSection = new SqlCommand(GetInsertCommand(), con);
cmdSection.Parameters.Add("@SectionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SectionIDFN));
cmdSection.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdSection.Parameters.Add("@SectionAbbreviation", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(SectionAbbreviationFN));
cmdSection.Parameters.Add("@DescEN", SqlDbType.VarChar,150, LibraryMOD.GetFieldName(DescENFN));
cmdSection.Parameters.Add("@DescAr", SqlDbType.NVarChar,300, LibraryMOD.GetFieldName(DescArFN));
cmdSection.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdSection.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdSection.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdSection.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdSection.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdSection.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
cmdSection.Parameters.Add("@ManagerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ManagerIDFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daSection.InsertCommand =cmdSection;
daSection.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdSection = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdSection.Parameters.Add("@SectionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SectionIDFN));
Parmeter = cmdSection.Parameters.Add("@DepartmentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DepartmentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daSection.DeleteCommand =cmdSection;
daSection.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daSection.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSection;
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
dr = dsSection.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(SectionIDFN)]=SectionID;
dr[LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
dr[LibraryMOD.GetFieldName(SectionAbbreviationFN)]=SectionAbbreviation;
dr[LibraryMOD.GetFieldName(DescENFN)]=DescEN;
dr[LibraryMOD.GetFieldName(DescArFN)]=DescAr;
dr[LibraryMOD.GetFieldName(ManagerIDFN)]=ManagerID;
dsSection.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsSection.Tables[TableName].Select(LibraryMOD.GetFieldName(SectionIDFN)  + "=" + SectionID  + " AND " + LibraryMOD.GetFieldName(DepartmentIDFN) + "=" + DepartmentID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(SectionIDFN)]=SectionID;
drAry[0][LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
drAry[0][LibraryMOD.GetFieldName(SectionAbbreviationFN)]=SectionAbbreviation;
drAry[0][LibraryMOD.GetFieldName(DescENFN)]=DescEN;
drAry[0][LibraryMOD.GetFieldName(DescArFN)]=DescAr;
drAry[0][LibraryMOD.GetFieldName(ManagerIDFN)]=ManagerID;
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
public int CommitSection()  
{
//CommitSection= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daSection.Update(dsSection, TableName);
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
FindInMultiPKey(SectionID,DepartmentID);
if (( SectionDataRow != null)) 
{
SectionDataRow.Delete();
CommitSection();
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
if (SectionDataRow[LibraryMOD.GetFieldName(SectionIDFN)]== System.DBNull.Value)
{
  SectionID=0;
}
else
{
  SectionID = (int)SectionDataRow[LibraryMOD.GetFieldName(SectionIDFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)]== System.DBNull.Value)
{
  DepartmentID=0;
}
else
{
  DepartmentID = (int)SectionDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(SectionAbbreviationFN)]== System.DBNull.Value)
{
  SectionAbbreviation="";
}
else
{
  SectionAbbreviation = (string)SectionDataRow[LibraryMOD.GetFieldName(SectionAbbreviationFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(DescENFN)]== System.DBNull.Value)
{
  DescEN="";
}
else
{
  DescEN = (string)SectionDataRow[LibraryMOD.GetFieldName(DescENFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(DescArFN)]== System.DBNull.Value)
{
  DescAr="";
}
else
{
  DescAr = (string)SectionDataRow[LibraryMOD.GetFieldName(DescArFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)SectionDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)SectionDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)SectionDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)SectionDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)SectionDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)SectionDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
}
if (SectionDataRow[LibraryMOD.GetFieldName(ManagerIDFN)]== System.DBNull.Value)
{
  ManagerID=0;
}
else
{
  ManagerID = (int)SectionDataRow[LibraryMOD.GetFieldName(ManagerIDFN)];
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
public int FindInMultiPKey(int PKSectionID,int PKDepartmentID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKSectionID;
findTheseVals[1] = PKDepartmentID;
SectionDataRow = dsSection.Tables[TableName].Rows.Find(findTheseVals);
if  ((SectionDataRow !=null)) 
{
lngCurRow = dsSection.Tables[TableName].Rows.IndexOf(SectionDataRow);
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
  lngCurRow = dsSection.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsSection.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsSection.Tables[TableName].Rows.Count > 0) 
{
  SectionDataRow = dsSection.Tables[TableName].Rows[lngCurRow];
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
daSection.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSection.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daSection.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSection.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
