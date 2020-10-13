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
public class LibPublishers
{
//Creation Date: 25/01/2011 16:42:51
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_PublisherID; 
private string m_strPublisherAr; 
private string m_strPublisherEn; 
private int m_CountryID; 
private string m_strAddress; 
private int m_PoBox; 
private string m_Fax; 
private string m_Phone; 
private string m_Email; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int PublisherID
{
get { return  m_PublisherID; }
set {m_PublisherID  = value ; }
}
public string strPublisherAr
{
get { return  m_strPublisherAr; }
set {m_strPublisherAr  = value ; }
}
public string strPublisherEn
{
get { return  m_strPublisherEn; }
set {m_strPublisherEn  = value ; }
}
public int CountryID
{
get { return  m_CountryID; }
set {m_CountryID  = value ; }
}
public string strAddress
{
get { return  m_strAddress; }
set {m_strAddress  = value ; }
}
public int PoBox
{
get { return  m_PoBox; }
set {m_PoBox  = value ; }
}
public string Fax
{
get { return  m_Fax; }
set {m_Fax  = value ; }
}
public string Phone
{
get { return  m_Phone; }
set {m_Phone  = value ; }
}
public string Email
{
get { return  m_Email; }
set {m_Email  = value ; }
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
public LibPublishers()
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
public class LibPublishersDAL : LibPublishers
{
#region "Decleration"
private string m_TableName;
private string m_PublisherIDFN ;
private string m_strPublisherArFN ;
private string m_strPublisherEnFN ;
private string m_CountryIDFN ;
private string m_strAddressFN ;
private string m_PoBoxFN ;
private string m_FaxFN ;
private string m_PhoneFN ;
private string m_EmailFN ;
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
public string PublisherIDFN 
{
get { return  m_PublisherIDFN; }
set {m_PublisherIDFN  = value ; }
}
public string strPublisherArFN 
{
get { return  m_strPublisherArFN; }
set {m_strPublisherArFN  = value ; }
}
public string strPublisherEnFN 
{
get { return  m_strPublisherEnFN; }
set {m_strPublisherEnFN  = value ; }
}
public string CountryIDFN 
{
get { return  m_CountryIDFN; }
set {m_CountryIDFN  = value ; }
}
public string strAddressFN 
{
get { return  m_strAddressFN; }
set {m_strAddressFN  = value ; }
}
public string PoBoxFN 
{
get { return  m_PoBoxFN; }
set {m_PoBoxFN  = value ; }
}
public string FaxFN 
{
get { return  m_FaxFN; }
set {m_FaxFN  = value ; }
}
public string PhoneFN 
{
get { return  m_PhoneFN; }
set {m_PhoneFN  = value ; }
}
public string EmailFN 
{
get { return  m_EmailFN; }
set {m_EmailFN  = value ; }
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
public LibPublishersDAL()
{
try
{
this.TableName = "LibPublishers";
this.PublisherIDFN = m_TableName + ".PublisherID";
this.strPublisherArFN = m_TableName + ".strPublisherAr";
this.strPublisherEnFN = m_TableName + ".strPublisherEn";
this.CountryIDFN = m_TableName + ".CountryID";
this.strAddressFN = m_TableName + ".strAddress";
this.PoBoxFN = m_TableName + ".PoBox";
this.FaxFN = m_TableName + ".Fax";
this.PhoneFN = m_TableName + ".Phone";
this.EmailFN = m_TableName + ".Email";
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
sSQL +=PublisherIDFN;
sSQL += " , " + strPublisherArFN;
sSQL += " , " + strPublisherEnFN;
sSQL += " , " + CountryIDFN;
sSQL += " , " + strAddressFN;
sSQL += " , " + PoBoxFN;
sSQL += " , " + FaxFN;
sSQL += " , " + PhoneFN;
sSQL += " , " + EmailFN;
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
    sSQL += PublisherIDFN;
    sSQL += " , " + strPublisherArFN;
    sSQL += " , " + strPublisherEnFN;
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
sSQL +=PublisherIDFN;
sSQL += " , " + strPublisherArFN;
sSQL += " , " + strPublisherEnFN;
sSQL += " , " + CountryIDFN;
sSQL += " , " + strAddressFN;
sSQL += " , " + PoBoxFN;
sSQL += " , " + FaxFN;
sSQL += " , " + PhoneFN;
sSQL += " , " + EmailFN;
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
sSQL += LibraryMOD.GetFieldName(PublisherIDFN) + "=@PublisherID";
sSQL += " , " + LibraryMOD.GetFieldName(strPublisherArFN) + "=@strPublisherAr";
sSQL += " , " + LibraryMOD.GetFieldName(strPublisherEnFN) + "=@strPublisherEn";
sSQL += " , " + LibraryMOD.GetFieldName(CountryIDFN) + "=@CountryID";
sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN) + "=@strAddress";
sSQL += " , " + LibraryMOD.GetFieldName(PoBoxFN) + "=@PoBox";
sSQL += " , " + LibraryMOD.GetFieldName(FaxFN) + "=@Fax";
sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN) + "=@Phone";
sSQL += " , " + LibraryMOD.GetFieldName(EmailFN) + "=@Email";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(PublisherIDFN)+"=@PublisherID";
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
sSQL +=LibraryMOD.GetFieldName(PublisherIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(strPublisherArFN);
sSQL += " , " + LibraryMOD.GetFieldName(strPublisherEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(CountryIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN);
sSQL += " , " + LibraryMOD.GetFieldName(PoBoxFN);
sSQL += " , " + LibraryMOD.GetFieldName(FaxFN);
sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN);
sSQL += " , " + LibraryMOD.GetFieldName(EmailFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @PublisherID";
sSQL += " ,@strPublisherAr";
sSQL += " ,@strPublisherEn";
sSQL += " ,@CountryID";
sSQL += " ,@strAddress";
sSQL += " ,@PoBox";
sSQL += " ,@Fax";
sSQL += " ,@Phone";
sSQL += " ,@Email";
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
sSQL += LibraryMOD.GetFieldName(PublisherIDFN)+"=@PublisherID";
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
public List< LibPublishers> GetLibPublishers(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the LibPublishers
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
List<LibPublishers> results = new List<LibPublishers>();
try
{
//Default Value
LibPublishers myLibPublishers = new LibPublishers();
if (isDeafaultIncluded)
{
//Change the code here
myLibPublishers.PublisherID = 0;
results.Add(myLibPublishers);
}
while (reader.Read())
{
myLibPublishers = new LibPublishers();
if (reader[LibraryMOD.GetFieldName(PublisherIDFN)].Equals(DBNull.Value))
{
myLibPublishers.PublisherID = 0;
}
else
{
myLibPublishers.PublisherID = int.Parse(reader[LibraryMOD.GetFieldName( PublisherIDFN) ].ToString());
}
myLibPublishers.strPublisherAr =reader[LibraryMOD.GetFieldName( strPublisherArFN) ].ToString();
myLibPublishers.strPublisherEn =reader[LibraryMOD.GetFieldName( strPublisherEnFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CountryIDFN)].Equals(DBNull.Value))
{
myLibPublishers.CountryID = 0;
}
else
{
myLibPublishers.CountryID = int.Parse(reader[LibraryMOD.GetFieldName( CountryIDFN) ].ToString());
}
myLibPublishers.strAddress =reader[LibraryMOD.GetFieldName( strAddressFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(PoBoxFN)].Equals(DBNull.Value))
{
myLibPublishers.PoBox = 0;
}
else
{
myLibPublishers.PoBox = int.Parse(reader[LibraryMOD.GetFieldName( PoBoxFN) ].ToString());
}
myLibPublishers.Fax =reader[LibraryMOD.GetFieldName( FaxFN) ].ToString();
myLibPublishers.Phone =reader[LibraryMOD.GetFieldName( PhoneFN) ].ToString();
myLibPublishers.Email =reader[LibraryMOD.GetFieldName( EmailFN) ].ToString();
myLibPublishers.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myLibPublishers.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myLibPublishers.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myLibPublishers.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myLibPublishers.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myLibPublishers.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myLibPublishers);
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
public List< LibPublishers > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<LibPublishers> results = new List<LibPublishers>();
try
{
//Default Value
LibPublishers myLibPublishers= new LibPublishers();
if (isDeafaultIncluded)
 {
//Change the code here
 myLibPublishers.PublisherID = -1;
 myLibPublishers.strPublisherAr = "Select LibPublishers" ;
results.Add(myLibPublishers);
 }
while (reader.Read())
{
myLibPublishers = new LibPublishers();
if (reader[LibraryMOD.GetFieldName(PublisherIDFN)].Equals(DBNull.Value))
{
myLibPublishers.PublisherID = 0;
}
else
{
myLibPublishers.PublisherID = int.Parse(reader[LibraryMOD.GetFieldName( PublisherIDFN) ].ToString());
}
myLibPublishers.strPublisherAr =reader[LibraryMOD.GetFieldName( strPublisherArFN) ].ToString();
myLibPublishers.strPublisherEn =reader[LibraryMOD.GetFieldName( strPublisherEnFN) ].ToString();
 results.Add(myLibPublishers);
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
public int UpdateLibPublishers(InitializeModule.EnumCampus Campus, int iMode,int PublisherID,string strPublisherAr,string strPublisherEn,int CountryID,string strAddress,int PoBox,string Fax,string Phone,string Email,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
LibPublishers theLibPublishers = new LibPublishers();
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
Cmd.Parameters.Add(new SqlParameter("@PublisherID",PublisherID));
Cmd.Parameters.Add(new SqlParameter("@strPublisherAr",strPublisherAr));
Cmd.Parameters.Add(new SqlParameter("@strPublisherEn",strPublisherEn));
Cmd.Parameters.Add(new SqlParameter("@CountryID",CountryID));
Cmd.Parameters.Add(new SqlParameter("@strAddress",strAddress));
Cmd.Parameters.Add(new SqlParameter("@PoBox",PoBox));
Cmd.Parameters.Add(new SqlParameter("@Fax",Fax));
Cmd.Parameters.Add(new SqlParameter("@Phone",Phone));
Cmd.Parameters.Add(new SqlParameter("@Email",Email));
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
public int DeleteLibPublishers(InitializeModule.EnumCampus Campus,string PublisherID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@PublisherID", PublisherID ));
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
DataTable dt = new DataTable("LibPublishers");
DataView dv = new DataView();
List<LibPublishers> myLibPublisherss = new List<LibPublishers>();
try
{
myLibPublisherss = GetLibPublishers(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("PublisherID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myLibPublisherss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myLibPublisherss[i].PublisherID;
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
myLibPublisherss.Clear();
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
sSQL += PublisherIDFN;
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
public class LibPublishersCls : LibPublishersDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daLibPublishers;
private DataSet m_dsLibPublishers;
public DataRow LibPublishersDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsLibPublishers
{
get { return m_dsLibPublishers ; }
set { m_dsLibPublishers = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public LibPublishersCls()
{
try
{
dsLibPublishers= new DataSet();

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
public virtual SqlDataAdapter GetLibPublishersDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daLibPublishers = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibPublishers);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daLibPublishers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibPublishers;
}
public virtual SqlDataAdapter GetLibPublishersDataAdapter(SqlConnection con)  
{
try
{
daLibPublishers = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daLibPublishers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdLibPublishers;
cmdLibPublishers = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@PublisherID", SqlDbType.Int, 4, "PublisherID" );
daLibPublishers.SelectCommand = cmdLibPublishers;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdLibPublishers = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdLibPublishers.Parameters.Add("@PublisherID", SqlDbType.Int,4, LibraryMOD.GetFieldName(PublisherIDFN));
cmdLibPublishers.Parameters.Add("@strPublisherAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strPublisherArFN));
cmdLibPublishers.Parameters.Add("@strPublisherEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strPublisherEnFN));
cmdLibPublishers.Parameters.Add("@CountryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CountryIDFN));
cmdLibPublishers.Parameters.Add("@strAddress", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strAddressFN));
cmdLibPublishers.Parameters.Add("@PoBox", SqlDbType.Int,4, LibraryMOD.GetFieldName(PoBoxFN));
cmdLibPublishers.Parameters.Add("@Fax", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(FaxFN));
cmdLibPublishers.Parameters.Add("@Phone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PhoneFN));
cmdLibPublishers.Parameters.Add("@Email", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(EmailFN));
cmdLibPublishers.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdLibPublishers.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdLibPublishers.Parameters.Add("@strUserSave", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserSaveFN));
cmdLibPublishers.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdLibPublishers.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdLibPublishers.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdLibPublishers.Parameters.Add("@PublisherID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublisherIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daLibPublishers.UpdateCommand = cmdLibPublishers;
daLibPublishers.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdLibPublishers = new SqlCommand(GetInsertCommand(), con);
cmdLibPublishers.Parameters.Add("@PublisherID", SqlDbType.Int,4, LibraryMOD.GetFieldName(PublisherIDFN));
cmdLibPublishers.Parameters.Add("@strPublisherAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strPublisherArFN));
cmdLibPublishers.Parameters.Add("@strPublisherEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strPublisherEnFN));
cmdLibPublishers.Parameters.Add("@CountryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CountryIDFN));
cmdLibPublishers.Parameters.Add("@strAddress", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strAddressFN));
cmdLibPublishers.Parameters.Add("@PoBox", SqlDbType.Int,4, LibraryMOD.GetFieldName(PoBoxFN));
cmdLibPublishers.Parameters.Add("@Fax", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(FaxFN));
cmdLibPublishers.Parameters.Add("@Phone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PhoneFN));
cmdLibPublishers.Parameters.Add("@Email", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(EmailFN));
cmdLibPublishers.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdLibPublishers.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdLibPublishers.Parameters.Add("@strUserSave", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserSaveFN));
cmdLibPublishers.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdLibPublishers.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdLibPublishers.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daLibPublishers.InsertCommand =cmdLibPublishers;
daLibPublishers.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdLibPublishers = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdLibPublishers.Parameters.Add("@PublisherID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublisherIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daLibPublishers.DeleteCommand =cmdLibPublishers;
daLibPublishers.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daLibPublishers.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibPublishers;
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
dr = dsLibPublishers.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(PublisherIDFN)]=PublisherID;
dr[LibraryMOD.GetFieldName(strPublisherArFN)]=strPublisherAr;
dr[LibraryMOD.GetFieldName(strPublisherEnFN)]=strPublisherEn;
dr[LibraryMOD.GetFieldName(CountryIDFN)]=CountryID;
dr[LibraryMOD.GetFieldName(strAddressFN)]=strAddress;
dr[LibraryMOD.GetFieldName(PoBoxFN)]=PoBox;
dr[LibraryMOD.GetFieldName(FaxFN)]=Fax;
dr[LibraryMOD.GetFieldName(PhoneFN)]=Phone;
dr[LibraryMOD.GetFieldName(EmailFN)]=Email;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsLibPublishers.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsLibPublishers.Tables[TableName].Select(LibraryMOD.GetFieldName(PublisherIDFN)  + "=" + PublisherID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(PublisherIDFN)]=PublisherID;
drAry[0][LibraryMOD.GetFieldName(strPublisherArFN)]=strPublisherAr;
drAry[0][LibraryMOD.GetFieldName(strPublisherEnFN)]=strPublisherEn;
drAry[0][LibraryMOD.GetFieldName(CountryIDFN)]=CountryID;
drAry[0][LibraryMOD.GetFieldName(strAddressFN)]=strAddress;
drAry[0][LibraryMOD.GetFieldName(PoBoxFN)]=PoBox;
drAry[0][LibraryMOD.GetFieldName(FaxFN)]=Fax;
drAry[0][LibraryMOD.GetFieldName(PhoneFN)]=Phone;
drAry[0][LibraryMOD.GetFieldName(EmailFN)]=Email;
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
public int CommitLibPublishers()  
{
//CommitLibPublishers= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daLibPublishers.Update(dsLibPublishers, TableName);
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
FindInMultiPKey(PublisherID);
if (( LibPublishersDataRow != null)) 
{
LibPublishersDataRow.Delete();
CommitLibPublishers();
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
if (LibPublishersDataRow[LibraryMOD.GetFieldName(PublisherIDFN)]== System.DBNull.Value)
{
  PublisherID=0;
}
else
{
  PublisherID = (int)LibPublishersDataRow[LibraryMOD.GetFieldName(PublisherIDFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(strPublisherArFN)]== System.DBNull.Value)
{
  strPublisherAr="";
}
else
{
  strPublisherAr = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(strPublisherArFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(strPublisherEnFN)]== System.DBNull.Value)
{
  strPublisherEn="";
}
else
{
  strPublisherEn = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(strPublisherEnFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(CountryIDFN)]== System.DBNull.Value)
{
  CountryID=0;
}
else
{
  CountryID = (int)LibPublishersDataRow[LibraryMOD.GetFieldName(CountryIDFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(strAddressFN)]== System.DBNull.Value)
{
  strAddress="";
}
else
{
  strAddress = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(strAddressFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(PoBoxFN)]== System.DBNull.Value)
{
  PoBox=0;
}
else
{
  PoBox = (int)LibPublishersDataRow[LibraryMOD.GetFieldName(PoBoxFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(FaxFN)]== System.DBNull.Value)
{
  Fax="";
}
else
{
  Fax = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(FaxFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(PhoneFN)]== System.DBNull.Value)
{
  Phone="";
}
else
{
  Phone = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(PhoneFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(EmailFN)]== System.DBNull.Value)
{
  Email="";
}
else
{
  Email = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(EmailFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)LibPublishersDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)LibPublishersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (LibPublishersDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)LibPublishersDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKPublisherID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKPublisherID;
LibPublishersDataRow = dsLibPublishers.Tables[TableName].Rows.Find(findTheseVals);
if  ((LibPublishersDataRow !=null)) 
{
lngCurRow = dsLibPublishers.Tables[TableName].Rows.IndexOf(LibPublishersDataRow);
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
  lngCurRow = dsLibPublishers.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsLibPublishers.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsLibPublishers.Tables[TableName].Rows.Count > 0) 
{
  LibPublishersDataRow = dsLibPublishers.Tables[TableName].Rows[lngCurRow];
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
daLibPublishers.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibPublishers.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daLibPublishers.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibPublishers.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
