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
public class InsuraneCompany
{
//Creation Date: 03/10/2010 7:33 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_CompanyID; 
private string m_CompanyName; 
private string m_ContactPerson; 
private string m_Phone; 
private string m_Fax; 
private string m_POBox; 
private string m_Email; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int CompanyID
{
get { return  m_CompanyID; }
set {m_CompanyID  = value ; }
}
public string CompanyName
{
get { return  m_CompanyName; }
set {m_CompanyName  = value ; }
}
public string ContactPerson
{
get { return  m_ContactPerson; }
set {m_ContactPerson  = value ; }
}
public string Phone
{
get { return  m_Phone; }
set {m_Phone  = value ; }
}
public string Fax
{
get { return  m_Fax; }
set {m_Fax  = value ; }
}
public string POBox
{
get { return  m_POBox; }
set {m_POBox  = value ; }
}
public string Email
{
get { return  m_Email; }
set {m_Email  = value ; }
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
public InsuraneCompany()
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
public class InsuraneCompanyDAL : InsuraneCompany
{
#region "Decleration"
private string m_TableName;
private string m_CompanyIDFN ;
private string m_CompanyNameFN ;
private string m_ContactPersonFN ;
private string m_PhoneFN ;
private string m_FaxFN ;
private string m_POBoxFN ;
private string m_EmailFN ;
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
public string CompanyIDFN 
{
get { return  m_CompanyIDFN; }
set {m_CompanyIDFN  = value ; }
}
public string CompanyNameFN 
{
get { return  m_CompanyNameFN; }
set {m_CompanyNameFN  = value ; }
}
public string ContactPersonFN 
{
get { return  m_ContactPersonFN; }
set {m_ContactPersonFN  = value ; }
}
public string PhoneFN 
{
get { return  m_PhoneFN; }
set {m_PhoneFN  = value ; }
}
public string FaxFN 
{
get { return  m_FaxFN; }
set {m_FaxFN  = value ; }
}
public string POBoxFN 
{
get { return  m_POBoxFN; }
set {m_POBoxFN  = value ; }
}
public string EmailFN 
{
get { return  m_EmailFN; }
set {m_EmailFN  = value ; }
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
public InsuraneCompanyDAL()
{
try
{
this.TableName = "Hr_InsuraneCompany";
this.CompanyIDFN = m_TableName + ".CompanyID";
this.CompanyNameFN = m_TableName + ".CompanyName";
this.ContactPersonFN = m_TableName + ".ContactPerson";
this.PhoneFN = m_TableName + ".Phone";
this.FaxFN = m_TableName + ".Fax";
this.POBoxFN = m_TableName + ".POBox";
this.EmailFN = m_TableName + ".Email";
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
sSQL +=CompanyIDFN;
sSQL += " , " + CompanyNameFN;
sSQL += " , " + ContactPersonFN;
sSQL += " , " + PhoneFN;
sSQL += " , " + FaxFN;
sSQL += " , " + POBoxFN;
sSQL += " , " + EmailFN;
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
sSQL +=CompanyIDFN;
sSQL += " , " + CompanyNameFN;
sSQL += " , " + ContactPersonFN;
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
sSQL +=CompanyIDFN;
sSQL += " , " + CompanyNameFN;
sSQL += " , " + ContactPersonFN;
sSQL += " , " + PhoneFN;
sSQL += " , " + FaxFN;
sSQL += " , " + POBoxFN;
sSQL += " , " + EmailFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(CompanyNameFN) + "=@CompanyName";
sSQL += " , " + LibraryMOD.GetFieldName(ContactPersonFN) + "=@ContactPerson";
sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN) + "=@Phone";
sSQL += " , " + LibraryMOD.GetFieldName(FaxFN) + "=@Fax";
sSQL += " , " + LibraryMOD.GetFieldName(POBoxFN) + "=@POBox";
sSQL += " , " + LibraryMOD.GetFieldName(EmailFN) + "=@Email";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(CompanyIDFN)+"=@CompanyID";
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
sSQL += " , " + LibraryMOD.GetFieldName(CompanyNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(ContactPersonFN);
sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN);
sSQL += " , " + LibraryMOD.GetFieldName(FaxFN);
sSQL += " , " + LibraryMOD.GetFieldName(POBoxFN);
sSQL += " , " + LibraryMOD.GetFieldName(EmailFN);
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
sSQL += " ,@CompanyName";
sSQL += " ,@ContactPerson";
sSQL += " ,@Phone";
sSQL += " ,@Fax";
sSQL += " ,@POBox";
sSQL += " ,@Email";
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
sSQL += LibraryMOD.GetFieldName(CompanyIDFN)+"=@CompanyID";
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
public List< InsuraneCompany> GetInsuraneCompany(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the InsuraneCompany
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
List<InsuraneCompany> results = new List<InsuraneCompany>();
try
{
//Default Value
InsuraneCompany myInsuraneCompany = new InsuraneCompany();
if (isDeafaultIncluded)
{
//Change the code here
myInsuraneCompany.CompanyID = 0;
myInsuraneCompany.CompanyName = "Select InsuraneCompany ...";
results.Add(myInsuraneCompany);
}
while (reader.Read())
{
myInsuraneCompany = new InsuraneCompany();
if (reader[LibraryMOD.GetFieldName(CompanyIDFN)].Equals(DBNull.Value))
{
myInsuraneCompany.CompanyID = 0;
}
else
{
myInsuraneCompany.CompanyID = int.Parse(reader[LibraryMOD.GetFieldName( CompanyIDFN) ].ToString());
}
myInsuraneCompany.CompanyName =reader[LibraryMOD.GetFieldName( CompanyNameFN) ].ToString();
myInsuraneCompany.ContactPerson =reader[LibraryMOD.GetFieldName( ContactPersonFN) ].ToString();
myInsuraneCompany.Phone =reader[LibraryMOD.GetFieldName( PhoneFN) ].ToString();
myInsuraneCompany.Fax =reader[LibraryMOD.GetFieldName( FaxFN) ].ToString();
myInsuraneCompany.POBox =reader[LibraryMOD.GetFieldName( POBoxFN) ].ToString();
myInsuraneCompany.Email =reader[LibraryMOD.GetFieldName( EmailFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myInsuraneCompany.CreationUserID = 0;
}
else
{
myInsuraneCompany.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myInsuraneCompany.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myInsuraneCompany.LastUpdateUserID = 0;
}
else
{
myInsuraneCompany.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myInsuraneCompany.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myInsuraneCompany.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myInsuraneCompany.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myInsuraneCompany);
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
public List< InsuraneCompany > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<InsuraneCompany> results = new List<InsuraneCompany>();
try
{
//Default Value
InsuraneCompany myInsuraneCompany= new InsuraneCompany();
if (isDeafaultIncluded) 
 {
//Change the code here
 myInsuraneCompany.CompanyID = -1;
 myInsuraneCompany.CompanyName = "Select InsuraneCompany" ;
results.Add(myInsuraneCompany);
 }
while (reader.Read())
{
myInsuraneCompany = new InsuraneCompany();
if (reader[LibraryMOD.GetFieldName(CompanyIDFN)].Equals(DBNull.Value))
{
myInsuraneCompany.CompanyID = 0;
}
else
{
myInsuraneCompany.CompanyID = int.Parse(reader[LibraryMOD.GetFieldName( CompanyIDFN) ].ToString());
}
myInsuraneCompany.CompanyName =reader[LibraryMOD.GetFieldName( CompanyNameFN) ].ToString();
myInsuraneCompany.ContactPerson =reader[LibraryMOD.GetFieldName( ContactPersonFN) ].ToString();
 results.Add(myInsuraneCompany);
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
public int UpdateInsuraneCompany(InitializeModule.EnumCampus Campus, int iMode,int CompanyID,string CompanyName,string ContactPerson,string Phone,string Fax,string POBox,string Email,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
InsuraneCompany theInsuraneCompany = new InsuraneCompany();
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
Cmd.Parameters.Add(new SqlParameter("@CompanyID",CompanyID));
Cmd.Parameters.Add(new SqlParameter("@CompanyName",CompanyName));
Cmd.Parameters.Add(new SqlParameter("@ContactPerson",ContactPerson));
Cmd.Parameters.Add(new SqlParameter("@Phone",Phone));
Cmd.Parameters.Add(new SqlParameter("@Fax",Fax));
Cmd.Parameters.Add(new SqlParameter("@POBox",POBox));
Cmd.Parameters.Add(new SqlParameter("@Email",Email));
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
public int DeleteInsuraneCompany(InitializeModule.EnumCampus Campus,string CompanyID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@CompanyID", CompanyID ));
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
DataTable dt = new DataTable("InsuraneCompany");
DataView dv = new DataView();
List<InsuraneCompany> myInsuraneCompanys = new List<InsuraneCompany>();
try
{
myInsuraneCompanys = GetInsuraneCompany(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("CompanyID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("CompanyName", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("ContactPerson", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myInsuraneCompanys.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myInsuraneCompanys[i].CompanyID;
  dr[2] = myInsuraneCompanys[i].CompanyName;
  dr[3] = myInsuraneCompanys[i].ContactPerson;
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
myInsuraneCompanys.Clear();
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
sSQL += CompanyIDFN;
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
public class InsuraneCompanyCls : InsuraneCompanyDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daInsuraneCompany;
private DataSet m_dsInsuraneCompany;
public DataRow InsuraneCompanyDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsInsuraneCompany
{
get { return m_dsInsuraneCompany ; }
set { m_dsInsuraneCompany = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public InsuraneCompanyCls()
{
try
{
dsInsuraneCompany= new DataSet();

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
public virtual SqlDataAdapter GetInsuraneCompanyDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daInsuraneCompany = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daInsuraneCompany);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daInsuraneCompany.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daInsuraneCompany;
}
public virtual SqlDataAdapter GetInsuraneCompanyDataAdapter(SqlConnection con)  
{
try
{
daInsuraneCompany = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daInsuraneCompany.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdInsuraneCompany;
cmdInsuraneCompany = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@CompanyID", SqlDbType.Int, 4, "CompanyID" );
daInsuraneCompany.SelectCommand = cmdInsuraneCompany;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdInsuraneCompany = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdInsuraneCompany.Parameters.Add("@CompanyID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CompanyIDFN));
cmdInsuraneCompany.Parameters.Add("@CompanyName", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(CompanyNameFN));
cmdInsuraneCompany.Parameters.Add("@ContactPerson", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(ContactPersonFN));
cmdInsuraneCompany.Parameters.Add("@Phone", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(PhoneFN));
cmdInsuraneCompany.Parameters.Add("@Fax", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(FaxFN));
cmdInsuraneCompany.Parameters.Add("@POBox", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(POBoxFN));
cmdInsuraneCompany.Parameters.Add("@Email", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(EmailFN));
cmdInsuraneCompany.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdInsuraneCompany.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdInsuraneCompany.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdInsuraneCompany.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdInsuraneCompany.Parameters.Add("@PCName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(PCNameFN));
cmdInsuraneCompany.Parameters.Add("@NetUserName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdInsuraneCompany.Parameters.Add("@CompanyID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CompanyIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daInsuraneCompany.UpdateCommand = cmdInsuraneCompany;
daInsuraneCompany.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdInsuraneCompany = new SqlCommand(GetInsertCommand(), con);
cmdInsuraneCompany.Parameters.Add("@CompanyID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CompanyIDFN));
cmdInsuraneCompany.Parameters.Add("@CompanyName", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(CompanyNameFN));
cmdInsuraneCompany.Parameters.Add("@ContactPerson", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(ContactPersonFN));
cmdInsuraneCompany.Parameters.Add("@Phone", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(PhoneFN));
cmdInsuraneCompany.Parameters.Add("@Fax", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(FaxFN));
cmdInsuraneCompany.Parameters.Add("@POBox", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(POBoxFN));
cmdInsuraneCompany.Parameters.Add("@Email", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(EmailFN));
cmdInsuraneCompany.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdInsuraneCompany.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdInsuraneCompany.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdInsuraneCompany.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdInsuraneCompany.Parameters.Add("@PCName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(PCNameFN));
cmdInsuraneCompany.Parameters.Add("@NetUserName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daInsuraneCompany.InsertCommand =cmdInsuraneCompany;
daInsuraneCompany.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdInsuraneCompany = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdInsuraneCompany.Parameters.Add("@CompanyID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CompanyIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daInsuraneCompany.DeleteCommand =cmdInsuraneCompany;
daInsuraneCompany.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daInsuraneCompany.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daInsuraneCompany;
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
dr = dsInsuraneCompany.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(CompanyIDFN)]=CompanyID;
dr[LibraryMOD.GetFieldName(CompanyNameFN)]=CompanyName;
dr[LibraryMOD.GetFieldName(ContactPersonFN)]=ContactPerson;
dr[LibraryMOD.GetFieldName(PhoneFN)]=Phone;
dr[LibraryMOD.GetFieldName(FaxFN)]=Fax;
dr[LibraryMOD.GetFieldName(POBoxFN)]=POBox;
dr[LibraryMOD.GetFieldName(EmailFN)]=Email;
dsInsuraneCompany.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsInsuraneCompany.Tables[TableName].Select(LibraryMOD.GetFieldName(CompanyIDFN)  + "=" + CompanyID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(CompanyIDFN)]=CompanyID;
drAry[0][LibraryMOD.GetFieldName(CompanyNameFN)]=CompanyName;
drAry[0][LibraryMOD.GetFieldName(ContactPersonFN)]=ContactPerson;
drAry[0][LibraryMOD.GetFieldName(PhoneFN)]=Phone;
drAry[0][LibraryMOD.GetFieldName(FaxFN)]=Fax;
drAry[0][LibraryMOD.GetFieldName(POBoxFN)]=POBox;
drAry[0][LibraryMOD.GetFieldName(EmailFN)]=Email;
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
public int CommitInsuraneCompany()  
{
//CommitInsuraneCompany= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daInsuraneCompany.Update(dsInsuraneCompany, TableName);
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
FindInMultiPKey(CompanyID);
if (( InsuraneCompanyDataRow != null)) 
{
InsuraneCompanyDataRow.Delete();
CommitInsuraneCompany();
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
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CompanyIDFN)]== System.DBNull.Value)
{
  CompanyID=0;
}
else
{
  CompanyID = (int)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CompanyIDFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CompanyNameFN)]== System.DBNull.Value)
{
  CompanyName="";
}
else
{
  CompanyName = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CompanyNameFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(ContactPersonFN)]== System.DBNull.Value)
{
  ContactPerson="";
}
else
{
  ContactPerson = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(ContactPersonFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(PhoneFN)]== System.DBNull.Value)
{
  Phone="";
}
else
{
  Phone = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(PhoneFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(FaxFN)]== System.DBNull.Value)
{
  Fax="";
}
else
{
  Fax = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(FaxFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(POBoxFN)]== System.DBNull.Value)
{
  POBox="";
}
else
{
  POBox = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(POBoxFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(EmailFN)]== System.DBNull.Value)
{
  Email="";
}
else
{
  Email = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(EmailFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (InsuraneCompanyDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)InsuraneCompanyDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKCompanyID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKCompanyID;
InsuraneCompanyDataRow = dsInsuraneCompany.Tables[TableName].Rows.Find(findTheseVals);
if  ((InsuraneCompanyDataRow !=null)) 
{
lngCurRow = dsInsuraneCompany.Tables[TableName].Rows.IndexOf(InsuraneCompanyDataRow);
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
  lngCurRow = dsInsuraneCompany.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsInsuraneCompany.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsInsuraneCompany.Tables[TableName].Rows.Count > 0) 
{
  InsuraneCompanyDataRow = dsInsuraneCompany.Tables[TableName].Rows[lngCurRow];
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
daInsuraneCompany.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daInsuraneCompany.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daInsuraneCompany.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daInsuraneCompany.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
