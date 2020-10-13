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
public class Nationality
{
//Creation Date: 13/01/2014 5:35 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_NationalityID; 
private string m_NationalityDescEn; 
private string m_NationalityDescAr; 
private int m_GroupID; 
private int m_NationalityMaleID; 
private int m_NationalityFemaleID; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int NationalityID
{
get { return  m_NationalityID; }
set {m_NationalityID  = value ; }
}
public string NationalityDescEn
{
get { return  m_NationalityDescEn; }
set {m_NationalityDescEn  = value ; }
}
public string NationalityDescAr
{
get { return  m_NationalityDescAr; }
set {m_NationalityDescAr  = value ; }
}
public int GroupID
{
get { return  m_GroupID; }
set {m_GroupID  = value ; }
}
public int NationalityMaleID
{
get { return  m_NationalityMaleID; }
set {m_NationalityMaleID  = value ; }
}
public int NationalityFemaleID
{
get { return  m_NationalityFemaleID; }
set {m_NationalityFemaleID  = value ; }
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
public Nationality()
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
public class NationalityDAL : Nationality
{
#region "Decleration"
private string m_TableName;
private string m_NationalityIDFN ;
private string m_NationalityDescEnFN ;
private string m_NationalityDescArFN ;
private string m_GroupIDFN ;
private string m_NationalityMaleIDFN ;
private string m_NationalityFemaleIDFN ;
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
public string NationalityIDFN 
{
get { return  m_NationalityIDFN; }
set {m_NationalityIDFN  = value ; }
}
public string NationalityDescEnFN 
{
get { return  m_NationalityDescEnFN; }
set {m_NationalityDescEnFN  = value ; }
}
public string NationalityDescArFN 
{
get { return  m_NationalityDescArFN; }
set {m_NationalityDescArFN  = value ; }
}
public string GroupIDFN 
{
get { return  m_GroupIDFN; }
set {m_GroupIDFN  = value ; }
}
public string NationalityMaleIDFN 
{
get { return  m_NationalityMaleIDFN; }
set {m_NationalityMaleIDFN  = value ; }
}
public string NationalityFemaleIDFN 
{
get { return  m_NationalityFemaleIDFN; }
set {m_NationalityFemaleIDFN  = value ; }
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
public NationalityDAL()
{
try
{
this.TableName = "Lkp_Nationality";
this.NationalityIDFN = m_TableName + ".NationalityID";
this.NationalityDescEnFN = m_TableName + ".NationalityDescEn";
this.NationalityDescArFN = m_TableName + ".NationalityDescAr";
this.GroupIDFN = m_TableName + ".GroupID";
this.NationalityMaleIDFN = m_TableName + ".NationalityMaleID";
this.NationalityFemaleIDFN = m_TableName + ".NationalityFemaleID";
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
sSQL +=NationalityIDFN;
sSQL += " , " + NationalityDescEnFN;
sSQL += " , " + NationalityDescArFN;
sSQL += " , " + GroupIDFN;
sSQL += " , " + NationalityMaleIDFN;
sSQL += " , " + NationalityFemaleIDFN;
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
public string  GetListSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=NationalityIDFN;
sSQL += " , " + NationalityDescEnFN;
sSQL += " , " + NationalityDescArFN;
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
public string GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
    sSQL = "SELECT ";
    sSQL +=NationalityIDFN;
    sSQL += " , " + NationalityDescEnFN;
    sSQL += " , " + NationalityDescArFN;
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
sSQL +=NationalityIDFN;
sSQL += " , " + NationalityDescEnFN;
sSQL += " , " + NationalityDescArFN;
sSQL += " , " + GroupIDFN;
sSQL += " , " + NationalityMaleIDFN;
sSQL += " , " + NationalityFemaleIDFN;
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
sSQL += LibraryMOD.GetFieldName(NationalityIDFN) + "=@NationalityID";
sSQL += " , " + LibraryMOD.GetFieldName(NationalityDescEnFN) + "=@NationalityDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(NationalityDescArFN) + "=@NationalityDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(GroupIDFN) + "=@GroupID";
sSQL += " , " + LibraryMOD.GetFieldName(NationalityMaleIDFN) + "=@NationalityMaleID";
sSQL += " , " + LibraryMOD.GetFieldName(NationalityFemaleIDFN) + "=@NationalityFemaleID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(NationalityIDFN)+"=@NationalityID";
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
sSQL +=LibraryMOD.GetFieldName(NationalityIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(NationalityDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(NationalityDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(GroupIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(NationalityMaleIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(NationalityFemaleIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @NationalityID";
sSQL += " ,@NationalityDescEn";
sSQL += " ,@NationalityDescAr";
sSQL += " ,@GroupID";
sSQL += " ,@NationalityMaleID";
sSQL += " ,@NationalityFemaleID";
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
sSQL += LibraryMOD.GetFieldName(NationalityIDFN)+"=@NationalityID";
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
public List< Nationality> GetNationality(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Nationality
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string  sSQL = GetSQL();
if (!string.IsNullOrEmpty(sCondition))
{
sSQL += sCondition;
}
sSQL += " ORDER BY " + NationalityDescEnFN ;
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Nationality> results = new List<Nationality>();
try
{
//Default Value
Nationality myNationality = new Nationality();
if (isDeafaultIncluded)
{
//Change the code here
myNationality.NationalityID = 0;
myNationality.NationalityDescEn  = "Select ...";
results.Add(myNationality);
}
while (reader.Read())
{
myNationality = new Nationality();
if (reader[LibraryMOD.GetFieldName(NationalityIDFN)].Equals(DBNull.Value))
{
myNationality.NationalityID = 0;
}
else
{
myNationality.NationalityID = int.Parse(reader[LibraryMOD.GetFieldName( NationalityIDFN) ].ToString());
}
myNationality.NationalityDescEn =reader[LibraryMOD.GetFieldName( NationalityDescEnFN) ].ToString();
myNationality.NationalityDescAr =reader[LibraryMOD.GetFieldName( NationalityDescArFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(GroupIDFN)].Equals(DBNull.Value))
{
myNationality.GroupID = 0;
}
else
{
myNationality.GroupID = int.Parse(reader[LibraryMOD.GetFieldName( GroupIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(NationalityMaleIDFN)].Equals(DBNull.Value))
{
myNationality.NationalityMaleID = 0;
}
else
{
myNationality.NationalityMaleID = int.Parse(reader[LibraryMOD.GetFieldName( NationalityMaleIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(NationalityFemaleIDFN)].Equals(DBNull.Value))
{
myNationality.NationalityFemaleID = 0;
}
else
{
myNationality.NationalityFemaleID = int.Parse(reader[LibraryMOD.GetFieldName( NationalityFemaleIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myNationality.CreationUserID = 0;
}
else
{
myNationality.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myNationality.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myNationality.LastUpdateUserID = 0;
}
else
{
myNationality.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myNationality.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myNationality.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myNationality.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myNationality);
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
public List< Nationality > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Nationality> results = new List<Nationality>();
try
{
//Default Value
Nationality myNationality= new Nationality();
if (isDeafaultIncluded)
 {
//Change the code here
 myNationality.NationalityID = -1;
 myNationality.NationalityDescEn = "Select Nationality" ;
results.Add(myNationality);
 }
while (reader.Read())
{
myNationality = new Nationality();
if (reader[LibraryMOD.GetFieldName(NationalityIDFN)].Equals(DBNull.Value))
{
myNationality.NationalityID = 0;
}
else
{
myNationality.NationalityID = int.Parse(reader[LibraryMOD.GetFieldName( NationalityIDFN) ].ToString());
}
myNationality.NationalityDescEn =reader[LibraryMOD.GetFieldName( NationalityDescEnFN) ].ToString();
myNationality.NationalityDescAr =reader[LibraryMOD.GetFieldName( NationalityDescArFN) ].ToString();
 results.Add(myNationality);
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
public int UpdateNationality(InitializeModule.EnumCampus Campus, int iMode,int NationalityID,string NationalityDescEn,string NationalityDescAr,int GroupID,int NationalityMaleID,int NationalityFemaleID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Nationality theNationality = new Nationality();
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
Cmd.Parameters.Add(new SqlParameter("@NationalityID",NationalityID));
Cmd.Parameters.Add(new SqlParameter("@NationalityDescEn",NationalityDescEn));
Cmd.Parameters.Add(new SqlParameter("@NationalityDescAr",NationalityDescAr));
Cmd.Parameters.Add(new SqlParameter("@GroupID",GroupID));
Cmd.Parameters.Add(new SqlParameter("@NationalityMaleID",NationalityMaleID));
Cmd.Parameters.Add(new SqlParameter("@NationalityFemaleID",NationalityFemaleID));
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
public int DeleteNationality(InitializeModule.EnumCampus Campus,string NationalityID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@NationalityID", NationalityID ));
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
DataTable dt = new DataTable("Nationality");
DataView dv = new DataView();
List<Nationality> myNationalitys = new List<Nationality>();
try
{
myNationalitys = GetNationality(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("NationalityID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myNationalitys.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myNationalitys[i].NationalityID;
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
myNationalitys.Clear();
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
sSQL += NationalityIDFN;
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
public class NationalityCls : NationalityDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daNationality;
private DataSet m_dsNationality;
public DataRow NationalityDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsNationality
{
get { return m_dsNationality ; }
set { m_dsNationality = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public NationalityCls()
{
try
{
dsNationality= new DataSet();

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
public virtual SqlDataAdapter GetNationalityDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daNationality = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daNationality);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daNationality.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daNationality;
}
public virtual SqlDataAdapter GetNationalityDataAdapter(SqlConnection con)  
{
try
{
daNationality = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daNationality.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdNationality;
cmdNationality = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@NationalityID", SqlDbType.Int, 4, "NationalityID" );
daNationality.SelectCommand = cmdNationality;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdNationality = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdNationality.Parameters.Add("@NationalityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityIDFN));
cmdNationality.Parameters.Add("@NationalityDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NationalityDescEnFN));
cmdNationality.Parameters.Add("@NationalityDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NationalityDescArFN));
cmdNationality.Parameters.Add("@GroupID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GroupIDFN));
cmdNationality.Parameters.Add("@NationalityMaleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityMaleIDFN));
cmdNationality.Parameters.Add("@NationalityFemaleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityFemaleIDFN));
cmdNationality.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdNationality.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdNationality.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdNationality.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdNationality.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdNationality.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdNationality.Parameters.Add("@NationalityID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NationalityIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daNationality.UpdateCommand = cmdNationality;
daNationality.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdNationality = new SqlCommand(GetInsertCommand(), con);
cmdNationality.Parameters.Add("@NationalityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityIDFN));
cmdNationality.Parameters.Add("@NationalityDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NationalityDescEnFN));
cmdNationality.Parameters.Add("@NationalityDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NationalityDescArFN));
cmdNationality.Parameters.Add("@GroupID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GroupIDFN));
cmdNationality.Parameters.Add("@NationalityMaleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityMaleIDFN));
cmdNationality.Parameters.Add("@NationalityFemaleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityFemaleIDFN));
cmdNationality.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdNationality.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdNationality.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdNationality.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdNationality.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdNationality.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daNationality.InsertCommand =cmdNationality;
daNationality.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdNationality = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdNationality.Parameters.Add("@NationalityID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NationalityIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daNationality.DeleteCommand =cmdNationality;
daNationality.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daNationality.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daNationality;
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
dr = dsNationality.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(NationalityIDFN)]=NationalityID;
dr[LibraryMOD.GetFieldName(NationalityDescEnFN)]=NationalityDescEn;
dr[LibraryMOD.GetFieldName(NationalityDescArFN)]=NationalityDescAr;
dr[LibraryMOD.GetFieldName(GroupIDFN)]=GroupID;
dr[LibraryMOD.GetFieldName(NationalityMaleIDFN)]=NationalityMaleID;
dr[LibraryMOD.GetFieldName(NationalityFemaleIDFN)]=NationalityFemaleID;
dsNationality.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsNationality.Tables[TableName].Select(LibraryMOD.GetFieldName(NationalityIDFN)  + "=" + NationalityID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(NationalityIDFN)]=NationalityID;
drAry[0][LibraryMOD.GetFieldName(NationalityDescEnFN)]=NationalityDescEn;
drAry[0][LibraryMOD.GetFieldName(NationalityDescArFN)]=NationalityDescAr;
drAry[0][LibraryMOD.GetFieldName(GroupIDFN)]=GroupID;
drAry[0][LibraryMOD.GetFieldName(NationalityMaleIDFN)]=NationalityMaleID;
drAry[0][LibraryMOD.GetFieldName(NationalityFemaleIDFN)]=NationalityFemaleID;
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
public int CommitNationality()  
{
//CommitNationality= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daNationality.Update(dsNationality, TableName);
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
FindInMultiPKey(NationalityID);
if (( NationalityDataRow != null)) 
{
NationalityDataRow.Delete();
CommitNationality();
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
if (NationalityDataRow[LibraryMOD.GetFieldName(NationalityIDFN)]== System.DBNull.Value)
{
  NationalityID=0;
}
else
{
  NationalityID = (int)NationalityDataRow[LibraryMOD.GetFieldName(NationalityIDFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(NationalityDescEnFN)]== System.DBNull.Value)
{
  NationalityDescEn="";
}
else
{
  NationalityDescEn = (string)NationalityDataRow[LibraryMOD.GetFieldName(NationalityDescEnFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(NationalityDescArFN)]== System.DBNull.Value)
{
  NationalityDescAr="";
}
else
{
  NationalityDescAr = (string)NationalityDataRow[LibraryMOD.GetFieldName(NationalityDescArFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(GroupIDFN)]== System.DBNull.Value)
{
  GroupID=0;
}
else
{
  GroupID = (int)NationalityDataRow[LibraryMOD.GetFieldName(GroupIDFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(NationalityMaleIDFN)]== System.DBNull.Value)
{
  NationalityMaleID=0;
}
else
{
  NationalityMaleID = (int)NationalityDataRow[LibraryMOD.GetFieldName(NationalityMaleIDFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(NationalityFemaleIDFN)]== System.DBNull.Value)
{
  NationalityFemaleID=0;
}
else
{
  NationalityFemaleID = (int)NationalityDataRow[LibraryMOD.GetFieldName(NationalityFemaleIDFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)NationalityDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)NationalityDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)NationalityDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)NationalityDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)NationalityDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (NationalityDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)NationalityDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKNationalityID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKNationalityID;
NationalityDataRow = dsNationality.Tables[TableName].Rows.Find(findTheseVals);
if  ((NationalityDataRow !=null)) 
{
lngCurRow = dsNationality.Tables[TableName].Rows.IndexOf(NationalityDataRow);
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
  lngCurRow = dsNationality.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsNationality.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsNationality.Tables[TableName].Rows.Count > 0) 
{
  NationalityDataRow = dsNationality.Tables[TableName].Rows[lngCurRow];
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
daNationality.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daNationality.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daNationality.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daNationality.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
