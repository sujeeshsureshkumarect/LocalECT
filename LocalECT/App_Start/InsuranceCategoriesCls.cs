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
public class InsuranceCategories
{
//Creation Date: 03/10/2010 7:33 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_CategoryNo; 
private int m_CompanyID; 
private string m_CategoryName; 
private string m_Notes; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int CategoryNo
{
get { return  m_CategoryNo; }
set {m_CategoryNo  = value ; }
}
public int CompanyID
{
get { return  m_CompanyID; }
set {m_CompanyID  = value ; }
}
public string CategoryName
{
get { return  m_CategoryName; }
set {m_CategoryName  = value ; }
}
public string Notes
{
get { return  m_Notes; }
set {m_Notes  = value ; }
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
public InsuranceCategories()
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
public class InsuranceCategoriesDAL : InsuranceCategories
{
#region "Decleration"
private string m_TableName;
private string m_CategoryNoFN ;
private string m_CompanyIDFN ;
private string m_CategoryNameFN ;
private string m_NotesFN ;
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
public string CategoryNoFN 
{
get { return  m_CategoryNoFN; }
set {m_CategoryNoFN  = value ; }
}
public string CompanyIDFN 
{
get { return  m_CompanyIDFN; }
set {m_CompanyIDFN  = value ; }
}
public string CategoryNameFN 
{
get { return  m_CategoryNameFN; }
set {m_CategoryNameFN  = value ; }
}
public string NotesFN 
{
get { return  m_NotesFN; }
set {m_NotesFN  = value ; }
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
public InsuranceCategoriesDAL()
{
try
{
this.TableName = "Hr_InsuranceCategories";
this.CategoryNoFN = m_TableName + ".CategoryNo";
this.CompanyIDFN = m_TableName + ".CompanyID";
this.CategoryNameFN = m_TableName + ".CategoryName";
this.NotesFN = m_TableName + ".Notes";
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
sSQL +=CategoryNoFN;
sSQL += " , " + CompanyIDFN;
sSQL += " , " + CategoryNameFN;
sSQL += " , " + NotesFN;
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
sSQL +=CategoryNoFN;
sSQL += " , " + CompanyIDFN;
sSQL += " , " + CategoryNameFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION ;
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
sSQL +=CategoryNoFN;
sSQL += " , " + CompanyIDFN;
sSQL += " , " + CategoryNameFN;
sSQL += " , " + NotesFN;
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
sSQL += LibraryMOD.GetFieldName(CompanyIDFN) + "=@CompanyID";
sSQL += " , " + LibraryMOD.GetFieldName(CategoryNameFN) + "=@CategoryName";
sSQL += " , " + LibraryMOD.GetFieldName(NotesFN) + "=@Notes";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(CategoryNoFN)+"=@CategoryNo";
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
sSQL +=LibraryMOD.GetFieldName(CompanyIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CategoryNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NotesFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @CompanyID";
sSQL += " ,@CategoryName";
sSQL += " ,@Notes";
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
sSQL += LibraryMOD.GetFieldName(CategoryNoFN)+"=@CategoryNo";
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
public List< InsuranceCategories> GetInsuranceCategories(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the InsuranceCategories
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
List<InsuranceCategories> results = new List<InsuranceCategories>();
try
{
//Default Value
InsuranceCategories myInsuranceCategories = new InsuranceCategories();
if (isDeafaultIncluded)
{
//Change the code here
myInsuranceCategories.CategoryNo = 0;

myInsuranceCategories.CategoryName  = "Select InsuranceCategories ...";
results.Add(myInsuranceCategories);
}
while (reader.Read())
{
myInsuranceCategories = new InsuranceCategories();
if (reader[LibraryMOD.GetFieldName(CategoryNoFN)].Equals(DBNull.Value))
{
myInsuranceCategories.CategoryNo = 0;
}
else
{
myInsuranceCategories.CategoryNo = int.Parse(reader[LibraryMOD.GetFieldName( CategoryNoFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CompanyIDFN)].Equals(DBNull.Value))
{
myInsuranceCategories.CompanyID = 0;
}
else
{
myInsuranceCategories.CompanyID = int.Parse(reader[LibraryMOD.GetFieldName( CompanyIDFN) ].ToString());
}
myInsuranceCategories.CategoryName =reader[LibraryMOD.GetFieldName( CategoryNameFN) ].ToString();
myInsuranceCategories.Notes =reader[LibraryMOD.GetFieldName( NotesFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myInsuranceCategories.CreationUserID = 0;
}
else
{
myInsuranceCategories.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myInsuranceCategories.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myInsuranceCategories.LastUpdateUserID = 0;
}
else
{
myInsuranceCategories.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myInsuranceCategories.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myInsuranceCategories.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myInsuranceCategories.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myInsuranceCategories);
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
public List< InsuranceCategories > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<InsuranceCategories> results = new List<InsuranceCategories>();
try
{
//Default Value
InsuranceCategories myInsuranceCategories= new InsuranceCategories();
if (isDeafaultIncluded) 
 {
//Change the code here
 myInsuranceCategories.CategoryNo = -1;
 myInsuranceCategories.CategoryName  = "Select InsuranceCategories" ;
results.Add(myInsuranceCategories);
 }
while (reader.Read())
{
myInsuranceCategories = new InsuranceCategories();
if (reader[LibraryMOD.GetFieldName(CategoryNoFN)].Equals(DBNull.Value))
{
myInsuranceCategories.CategoryNo = 0;
}
else
{
myInsuranceCategories.CategoryNo = int.Parse(reader[LibraryMOD.GetFieldName( CategoryNoFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CompanyIDFN)].Equals(DBNull.Value))
{
myInsuranceCategories.CompanyID = 0;
}
else
{
myInsuranceCategories.CompanyID = int.Parse(reader[LibraryMOD.GetFieldName( CompanyIDFN) ].ToString());
}
myInsuranceCategories.CategoryName =reader[LibraryMOD.GetFieldName( CategoryNameFN) ].ToString();
 results.Add(myInsuranceCategories);
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
public int UpdateInsuranceCategories(InitializeModule.EnumCampus Campus, int iMode,int CategoryNo,int CompanyID,string CategoryName,string Notes,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
InsuranceCategories theInsuranceCategories = new InsuranceCategories();
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
Cmd.Parameters.Add(new SqlParameter("@CategoryNo",CategoryNo));
Cmd.Parameters.Add(new SqlParameter("@CompanyID",CompanyID));
Cmd.Parameters.Add(new SqlParameter("@CategoryName",CategoryName));
Cmd.Parameters.Add(new SqlParameter("@Notes",Notes));
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
public int DeleteInsuranceCategories(InitializeModule.EnumCampus Campus,string CategoryNo)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@CategoryNo", CategoryNo ));
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
DataTable dt = new DataTable("InsuranceCategories");
DataView dv = new DataView();
List<InsuranceCategories> myInsuranceCategoriess = new List<InsuranceCategories>();
try
{
myInsuranceCategoriess = GetInsuranceCategories(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("CategoryNo", Type.GetType("int identity"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("CompanyID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("CategoryName", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myInsuranceCategoriess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myInsuranceCategoriess[i].CategoryNo;
  dr[2] = myInsuranceCategoriess[i].CompanyID;
  dr[3] = myInsuranceCategoriess[i].CategoryName;
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
myInsuranceCategoriess.Clear();
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
sSQL += CategoryNoFN;
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
public class InsuranceCategoriesCls : InsuranceCategoriesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daInsuranceCategories;
private DataSet m_dsInsuranceCategories;
public DataRow InsuranceCategoriesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsInsuranceCategories
{
get { return m_dsInsuranceCategories ; }
set { m_dsInsuranceCategories = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public InsuranceCategoriesCls()
{
try
{
dsInsuranceCategories= new DataSet();

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
public virtual SqlDataAdapter GetInsuranceCategoriesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daInsuranceCategories = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daInsuranceCategories);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daInsuranceCategories.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daInsuranceCategories;
}
public virtual SqlDataAdapter GetInsuranceCategoriesDataAdapter(SqlConnection con)  
{
try
{
daInsuranceCategories = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daInsuranceCategories.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdInsuranceCategories;
cmdInsuranceCategories = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@CategoryNo", SqlDbType.Int, 4, "CategoryNo" );
daInsuranceCategories.SelectCommand = cmdInsuranceCategories;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdInsuranceCategories = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdInsuranceCategories.Parameters.Add("@CategoryNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(CategoryNoFN));
cmdInsuranceCategories.Parameters.Add("@CompanyID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CompanyIDFN));
cmdInsuranceCategories.Parameters.Add("@CategoryName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(CategoryNameFN));
cmdInsuranceCategories.Parameters.Add("@Notes", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(NotesFN));
cmdInsuranceCategories.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdInsuranceCategories.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdInsuranceCategories.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdInsuranceCategories.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdInsuranceCategories.Parameters.Add("@PCName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(PCNameFN));
cmdInsuranceCategories.Parameters.Add("@NetUserName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdInsuranceCategories.Parameters.Add("@CategoryNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CategoryNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daInsuranceCategories.UpdateCommand = cmdInsuranceCategories;
daInsuranceCategories.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdInsuranceCategories = new SqlCommand(GetInsertCommand(), con);
cmdInsuranceCategories.Parameters.Add("@CategoryNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(CategoryNoFN));
cmdInsuranceCategories.Parameters.Add("@CompanyID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CompanyIDFN));
cmdInsuranceCategories.Parameters.Add("@CategoryName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(CategoryNameFN));
cmdInsuranceCategories.Parameters.Add("@Notes", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(NotesFN));
cmdInsuranceCategories.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdInsuranceCategories.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdInsuranceCategories.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdInsuranceCategories.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdInsuranceCategories.Parameters.Add("@PCName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(PCNameFN));
cmdInsuranceCategories.Parameters.Add("@NetUserName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daInsuranceCategories.InsertCommand =cmdInsuranceCategories;
daInsuranceCategories.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdInsuranceCategories = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdInsuranceCategories.Parameters.Add("@CategoryNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CategoryNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daInsuranceCategories.DeleteCommand =cmdInsuranceCategories;
daInsuranceCategories.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daInsuranceCategories.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daInsuranceCategories;
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
dr = dsInsuranceCategories.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(CategoryNoFN)]=CategoryNo;
dr[LibraryMOD.GetFieldName(CompanyIDFN)]=CompanyID;
dr[LibraryMOD.GetFieldName(CategoryNameFN)]=CategoryName;
dr[LibraryMOD.GetFieldName(NotesFN)]=Notes;
dsInsuranceCategories.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsInsuranceCategories.Tables[TableName].Select(LibraryMOD.GetFieldName(CategoryNoFN)  + "=" + CategoryNo);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(CategoryNoFN)]=CategoryNo;
drAry[0][LibraryMOD.GetFieldName(CompanyIDFN)]=CompanyID;
drAry[0][LibraryMOD.GetFieldName(CategoryNameFN)]=CategoryName;
drAry[0][LibraryMOD.GetFieldName(NotesFN)]=Notes;
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
public int CommitInsuranceCategories()  
{
//CommitInsuranceCategories= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daInsuranceCategories.Update(dsInsuranceCategories, TableName);
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
FindInMultiPKey(CategoryNo);
if (( InsuranceCategoriesDataRow != null)) 
{
InsuranceCategoriesDataRow.Delete();
CommitInsuranceCategories();
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
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CategoryNoFN)]== System.DBNull.Value)
{
  CategoryNo=0;
}
else
{
  CategoryNo = (int)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CategoryNoFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CompanyIDFN)]== System.DBNull.Value)
{
  CompanyID=0;
}
else
{
  CompanyID = (int)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CompanyIDFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CategoryNameFN)]== System.DBNull.Value)
{
  CategoryName="";
}
else
{
  CategoryName = (string)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CategoryNameFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(NotesFN)]== System.DBNull.Value)
{
  Notes="";
}
else
{
  Notes = (string)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(NotesFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)InsuranceCategoriesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKCategoryNo) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKCategoryNo;
InsuranceCategoriesDataRow = dsInsuranceCategories.Tables[TableName].Rows.Find(findTheseVals);
if  ((InsuranceCategoriesDataRow !=null)) 
{
lngCurRow = dsInsuranceCategories.Tables[TableName].Rows.IndexOf(InsuranceCategoriesDataRow);
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
  lngCurRow = dsInsuranceCategories.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsInsuranceCategories.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsInsuranceCategories.Tables[TableName].Rows.Count > 0) 
{
  InsuranceCategoriesDataRow = dsInsuranceCategories.Tables[TableName].Rows[lngCurRow];
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
daInsuranceCategories.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daInsuranceCategories.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daInsuranceCategories.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daInsuranceCategories.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
