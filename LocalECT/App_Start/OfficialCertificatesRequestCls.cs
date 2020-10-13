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
public class OfficialCertificatesRequest
{
//Creation Date: 06/04/2017 2:32:18 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_RequestID; 
private int m_EmployeeID; 
private int m_CertificateType; 
private int m_Language; 
private string m_DirectedTo; 
private int m_RequestStatus; 
private int m_IsActive; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int RequestID
{
get { return  m_RequestID; }
set {m_RequestID  = value ; }
}
public int EmployeeID
{
get { return  m_EmployeeID; }
set {m_EmployeeID  = value ; }
}
public int CertificateType
{
get { return  m_CertificateType; }
set {m_CertificateType  = value ; }
}
public int Language
{
get { return  m_Language; }
set {m_Language  = value ; }
}
public string DirectedTo
{
get { return  m_DirectedTo; }
set {m_DirectedTo  = value ; }
}
public int RequestStatus
{
get { return  m_RequestStatus; }
set {m_RequestStatus  = value ; }
}
public int IsActive
{
get { return  m_IsActive; }
set {m_IsActive  = value ; }
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
public OfficialCertificatesRequest()
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
public class OfficialCertificatesRequestDAL : OfficialCertificatesRequest
{
#region "Decleration"
private string m_TableName;
private string m_RequestIDFN ;
private string m_EmployeeIDFN ;
private string m_CertificateTypeFN ;
private string m_LanguageFN ;
private string m_DirectedToFN ;
private string m_RequestStatusFN ;
private string m_IsActiveFN ;
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
public string RequestIDFN 
{
get { return  m_RequestIDFN; }
set {m_RequestIDFN  = value ; }
}
public string EmployeeIDFN 
{
get { return  m_EmployeeIDFN; }
set {m_EmployeeIDFN  = value ; }
}
public string CertificateTypeFN 
{
get { return  m_CertificateTypeFN; }
set {m_CertificateTypeFN  = value ; }
}
public string LanguageFN 
{
get { return  m_LanguageFN; }
set {m_LanguageFN  = value ; }
}
public string DirectedToFN 
{
get { return  m_DirectedToFN; }
set {m_DirectedToFN  = value ; }
}
public string RequestStatusFN 
{
get { return  m_RequestStatusFN; }
set {m_RequestStatusFN  = value ; }
}
public string IsActiveFN 
{
get { return  m_IsActiveFN; }
set {m_IsActiveFN  = value ; }
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
public OfficialCertificatesRequestDAL()
{
try
{
this.TableName = "HR_OfficialCertificatesRequest";
this.RequestIDFN = m_TableName + ".RequestID";
this.EmployeeIDFN = m_TableName + ".EmployeeID";
this.CertificateTypeFN = m_TableName + ".CertificateType";
this.LanguageFN = m_TableName + ".Language";
this.DirectedToFN = m_TableName + ".DirectedTo";
this.RequestStatusFN = m_TableName + ".RequestStatus";
this.IsActiveFN = m_TableName + ".IsActive";
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
sSQL +=RequestIDFN;
sSQL += " , " + EmployeeIDFN;
sSQL += " , " + CertificateTypeFN;
sSQL += " , " + LanguageFN;
sSQL += " , " + DirectedToFN;
sSQL += " , " + RequestStatusFN;
sSQL += " , " + IsActiveFN;
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
    sSQL +=RequestIDFN;
    sSQL += " , " + EmployeeIDFN;
    sSQL += " , " + CertificateTypeFN;
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
sSQL +=RequestIDFN;
sSQL += " , " + EmployeeIDFN;
sSQL += " , " + CertificateTypeFN;
sSQL += " , " + LanguageFN;
sSQL += " , " + DirectedToFN;
sSQL += " , " + RequestStatusFN;
sSQL += " , " + IsActiveFN;
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
sSQL += LibraryMOD.GetFieldName(RequestIDFN) + "=@RequestID";
sSQL += " , " + LibraryMOD.GetFieldName(EmployeeIDFN) + "=@EmployeeID";
sSQL += " , " + LibraryMOD.GetFieldName(CertificateTypeFN) + "=@CertificateType";
sSQL += " , " + LibraryMOD.GetFieldName(LanguageFN) + "=@Language";
sSQL += " , " + LibraryMOD.GetFieldName(DirectedToFN) + "=@DirectedTo";
sSQL += " , " + LibraryMOD.GetFieldName(RequestStatusFN) + "=@RequestStatus";
sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(RequestIDFN)+"=@RequestID";
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
sSQL +=LibraryMOD.GetFieldName(RequestIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(EmployeeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CertificateTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(LanguageFN);
sSQL += " , " + LibraryMOD.GetFieldName(DirectedToFN);
sSQL += " , " + LibraryMOD.GetFieldName(RequestStatusFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @RequestID";
sSQL += " ,@EmployeeID";
sSQL += " ,@CertificateType";
sSQL += " ,@Language";
sSQL += " ,@DirectedTo";
sSQL += " ,@RequestStatus";
sSQL += " ,@IsActive";
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
sSQL += LibraryMOD.GetFieldName(RequestIDFN)+"=@RequestID";
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
public List< OfficialCertificatesRequest> GetOfficialCertificatesRequest(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the OfficialCertificatesRequest
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
List<OfficialCertificatesRequest> results = new List<OfficialCertificatesRequest>();
try
{
//Default Value
OfficialCertificatesRequest myOfficialCertificatesRequest = new OfficialCertificatesRequest();
if (isDeafaultIncluded)
{
//Change the code here
myOfficialCertificatesRequest.RequestID = 0;
//myOfficialCertificatesRequest.RequestID = "Select OfficialCertificatesRequest ...";
results.Add(myOfficialCertificatesRequest);
}
while (reader.Read())
{
myOfficialCertificatesRequest = new OfficialCertificatesRequest();
if (reader[LibraryMOD.GetFieldName(RequestIDFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.RequestID = 0;
}
else
{
myOfficialCertificatesRequest.RequestID = int.Parse(reader[LibraryMOD.GetFieldName( RequestIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.EmployeeID = 0;
}
else
{
myOfficialCertificatesRequest.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CertificateTypeFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.CertificateType = 0;
}
else
{
myOfficialCertificatesRequest.CertificateType = int.Parse(reader[LibraryMOD.GetFieldName( CertificateTypeFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LanguageFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.Language = 0;
}
else
{
myOfficialCertificatesRequest.Language = int.Parse(reader[LibraryMOD.GetFieldName( LanguageFN) ].ToString());
}
myOfficialCertificatesRequest.DirectedTo =reader[LibraryMOD.GetFieldName( DirectedToFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(RequestStatusFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.RequestStatus = 0;
}
else
{
myOfficialCertificatesRequest.RequestStatus = int.Parse(reader[LibraryMOD.GetFieldName( RequestStatusFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(IsActiveFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.IsActive = 0;
}
else
{
myOfficialCertificatesRequest.IsActive = int.Parse(reader[LibraryMOD.GetFieldName( IsActiveFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.CreationUserID = 0;
}
else
{
myOfficialCertificatesRequest.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.LastUpdateUserID = 0;
}
else
{
myOfficialCertificatesRequest.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myOfficialCertificatesRequest.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myOfficialCertificatesRequest.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myOfficialCertificatesRequest);
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
public List< OfficialCertificatesRequest > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<OfficialCertificatesRequest> results = new List<OfficialCertificatesRequest>();
try
{
//Default Value
OfficialCertificatesRequest myOfficialCertificatesRequest= new OfficialCertificatesRequest();
if (isDeafaultIncluded)
 {
//Change the code here
 myOfficialCertificatesRequest.RequestID = -1;
 myOfficialCertificatesRequest.EmployeeID = 0 ;
results.Add(myOfficialCertificatesRequest);
 }
while (reader.Read())
{
myOfficialCertificatesRequest = new OfficialCertificatesRequest();
if (reader[LibraryMOD.GetFieldName(RequestIDFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.RequestID = 0;
}
else
{
myOfficialCertificatesRequest.RequestID = int.Parse(reader[LibraryMOD.GetFieldName( RequestIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.EmployeeID = 0;
}
else
{
myOfficialCertificatesRequest.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CertificateTypeFN)].Equals(DBNull.Value))
{
myOfficialCertificatesRequest.CertificateType = 0;
}
else
{
myOfficialCertificatesRequest.CertificateType = int.Parse(reader[LibraryMOD.GetFieldName( CertificateTypeFN) ].ToString());
}
 results.Add(myOfficialCertificatesRequest);
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
public int UpdateOfficialCertificatesRequest(InitializeModule.EnumCampus Campus, int iMode,int RequestID,int EmployeeID,int CertificateType,int Language,string DirectedTo,int RequestStatus,int IsActive,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
OfficialCertificatesRequest theOfficialCertificatesRequest = new OfficialCertificatesRequest();
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
    Cmd.Parameters.Add(new SqlParameter("@RequestID",RequestID));
    Cmd.Parameters.Add(new SqlParameter("@EmployeeID",EmployeeID));
    Cmd.Parameters.Add(new SqlParameter("@CertificateType",CertificateType));
    Cmd.Parameters.Add(new SqlParameter("@Language",Language));
    Cmd.Parameters.Add(new SqlParameter("@DirectedTo",DirectedTo));
    Cmd.Parameters.Add(new SqlParameter("@RequestStatus",RequestStatus));
    Cmd.Parameters.Add(new SqlParameter("@IsActive",IsActive));
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
public int DeleteOfficialCertificatesRequest(InitializeModule.EnumCampus Campus,int iRequestID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@RequestID", iRequestID));
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
DataTable dt = new DataTable("OfficialCertificatesRequest");
DataView dv = new DataView();
List<OfficialCertificatesRequest> myOfficialCertificatesRequests = new List<OfficialCertificatesRequest>();
try
{
myOfficialCertificatesRequests = GetOfficialCertificatesRequest(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("RequestID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myOfficialCertificatesRequests.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myOfficialCertificatesRequests[i].RequestID;
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
myOfficialCertificatesRequests.Clear();
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
sSQL += RequestIDFN;
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
public class OfficialCertificatesRequestCls : OfficialCertificatesRequestDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daOfficialCertificatesRequest;
private DataSet m_dsOfficialCertificatesRequest;
public DataRow OfficialCertificatesRequestDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsOfficialCertificatesRequest
{
get { return m_dsOfficialCertificatesRequest ; }
set { m_dsOfficialCertificatesRequest = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public OfficialCertificatesRequestCls()
{
try
{
dsOfficialCertificatesRequest= new DataSet();

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
public virtual SqlDataAdapter GetOfficialCertificatesRequestDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daOfficialCertificatesRequest = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daOfficialCertificatesRequest);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daOfficialCertificatesRequest.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daOfficialCertificatesRequest;
}
public virtual SqlDataAdapter GetOfficialCertificatesRequestDataAdapter(SqlConnection con)  
{
try
{
daOfficialCertificatesRequest = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daOfficialCertificatesRequest.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdOfficialCertificatesRequest;
cmdOfficialCertificatesRequest = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@RequestID", SqlDbType.Int, 4, "RequestID" );
daOfficialCertificatesRequest.SelectCommand = cmdOfficialCertificatesRequest;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdOfficialCertificatesRequest = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdOfficialCertificatesRequest.Parameters.Add("@RequestID", SqlDbType.Int,4, LibraryMOD.GetFieldName(RequestIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@CertificateType", SqlDbType.Int,4, LibraryMOD.GetFieldName(CertificateTypeFN));
cmdOfficialCertificatesRequest.Parameters.Add("@Language", SqlDbType.Int,4, LibraryMOD.GetFieldName(LanguageFN));
cmdOfficialCertificatesRequest.Parameters.Add("@DirectedTo", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(DirectedToFN));
cmdOfficialCertificatesRequest.Parameters.Add("@RequestStatus", SqlDbType.Int,4, LibraryMOD.GetFieldName(RequestStatusFN));
cmdOfficialCertificatesRequest.Parameters.Add("@IsActive", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsActiveFN));
cmdOfficialCertificatesRequest.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdOfficialCertificatesRequest.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdOfficialCertificatesRequest.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdOfficialCertificatesRequest.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdOfficialCertificatesRequest.Parameters.Add("@RequestID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RequestIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daOfficialCertificatesRequest.UpdateCommand = cmdOfficialCertificatesRequest;
daOfficialCertificatesRequest.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdOfficialCertificatesRequest = new SqlCommand(GetInsertCommand(), con);
cmdOfficialCertificatesRequest.Parameters.Add("@RequestID", SqlDbType.Int,4, LibraryMOD.GetFieldName(RequestIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@CertificateType", SqlDbType.Int,4, LibraryMOD.GetFieldName(CertificateTypeFN));
cmdOfficialCertificatesRequest.Parameters.Add("@Language", SqlDbType.Int,4, LibraryMOD.GetFieldName(LanguageFN));
cmdOfficialCertificatesRequest.Parameters.Add("@DirectedTo", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(DirectedToFN));
cmdOfficialCertificatesRequest.Parameters.Add("@RequestStatus", SqlDbType.Int,4, LibraryMOD.GetFieldName(RequestStatusFN));
cmdOfficialCertificatesRequest.Parameters.Add("@IsActive", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsActiveFN));
cmdOfficialCertificatesRequest.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdOfficialCertificatesRequest.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdOfficialCertificatesRequest.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdOfficialCertificatesRequest.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdOfficialCertificatesRequest.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daOfficialCertificatesRequest.InsertCommand =cmdOfficialCertificatesRequest;
daOfficialCertificatesRequest.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdOfficialCertificatesRequest = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdOfficialCertificatesRequest.Parameters.Add("@RequestID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RequestIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daOfficialCertificatesRequest.DeleteCommand =cmdOfficialCertificatesRequest;
daOfficialCertificatesRequest.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daOfficialCertificatesRequest.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daOfficialCertificatesRequest;
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
dr = dsOfficialCertificatesRequest.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(RequestIDFN)]=RequestID;
dr[LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
dr[LibraryMOD.GetFieldName(CertificateTypeFN)]=CertificateType;
dr[LibraryMOD.GetFieldName(LanguageFN)]=Language;
dr[LibraryMOD.GetFieldName(DirectedToFN)]=DirectedTo;
dr[LibraryMOD.GetFieldName(RequestStatusFN)]=RequestStatus;
dr[LibraryMOD.GetFieldName(IsActiveFN)]=IsActive;
dsOfficialCertificatesRequest.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsOfficialCertificatesRequest.Tables[TableName].Select(LibraryMOD.GetFieldName(RequestIDFN)  + "=" + RequestID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(RequestIDFN)]=RequestID;
drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
drAry[0][LibraryMOD.GetFieldName(CertificateTypeFN)]=CertificateType;
drAry[0][LibraryMOD.GetFieldName(LanguageFN)]=Language;
drAry[0][LibraryMOD.GetFieldName(DirectedToFN)]=DirectedTo;
drAry[0][LibraryMOD.GetFieldName(RequestStatusFN)]=RequestStatus;
drAry[0][LibraryMOD.GetFieldName(IsActiveFN)]=IsActive;
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
public int CommitOfficialCertificatesRequest()  
{
//CommitOfficialCertificatesRequest= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daOfficialCertificatesRequest.Update(dsOfficialCertificatesRequest, TableName);
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
FindInMultiPKey(RequestID);
if (( OfficialCertificatesRequestDataRow != null)) 
{
OfficialCertificatesRequestDataRow.Delete();
CommitOfficialCertificatesRequest();
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
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(RequestIDFN)]== System.DBNull.Value)
{
  RequestID=0;
}
else
{
  RequestID = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(RequestIDFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)]== System.DBNull.Value)
{
  EmployeeID=0;
}
else
{
  EmployeeID = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(CertificateTypeFN)]== System.DBNull.Value)
{
  CertificateType=0;
}
else
{
  CertificateType = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(CertificateTypeFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(LanguageFN)]== System.DBNull.Value)
{
  Language=0;
}
else
{
  Language = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(LanguageFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(DirectedToFN)]== System.DBNull.Value)
{
  DirectedTo="";
}
else
{
  DirectedTo = (string)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(DirectedToFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(RequestStatusFN)]== System.DBNull.Value)
{
  RequestStatus=0;
}
else
{
  RequestStatus = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(RequestStatusFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(IsActiveFN)]== System.DBNull.Value)
{
  IsActive=0;
}
else
{
  IsActive = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)OfficialCertificatesRequestDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKRequestID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKRequestID;
OfficialCertificatesRequestDataRow = dsOfficialCertificatesRequest.Tables[TableName].Rows.Find(findTheseVals);
if  ((OfficialCertificatesRequestDataRow !=null)) 
{
lngCurRow = dsOfficialCertificatesRequest.Tables[TableName].Rows.IndexOf(OfficialCertificatesRequestDataRow);
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
  lngCurRow = dsOfficialCertificatesRequest.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsOfficialCertificatesRequest.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsOfficialCertificatesRequest.Tables[TableName].Rows.Count > 0) 
{
  OfficialCertificatesRequestDataRow = dsOfficialCertificatesRequest.Tables[TableName].Rows[lngCurRow];
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
daOfficialCertificatesRequest.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daOfficialCertificatesRequest.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daOfficialCertificatesRequest.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daOfficialCertificatesRequest.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
