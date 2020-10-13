using System;
using System.Data;
using System.Configuration;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Cities
{
//Creation Date: 22/03/2010 08:50:46 م
//Programmer Name : Hazem
//-----Decleration --------------
#region "Decleration"
private int m_byteCountry; 
private int m_byteCity; 
private string m_strCityDescEn; 
private string m_strCityDescAr; 
private int m_byteArea; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int byteCountry
{
get { return  m_byteCountry; }
set {m_byteCountry  = value ; }
}
public int byteCity
{
get { return  m_byteCity; }
set {m_byteCity  = value ; }
}
public string strCityDescEn
{
get { return  m_strCityDescEn; }
set {m_strCityDescEn  = value ; }
}
public string strCityDescAr
{
get { return  m_strCityDescAr; }
set {m_strCityDescAr  = value ; }
}
public int byteArea
{
get { return  m_byteArea; }
set {m_byteArea  = value ; }
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
public Cities()
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
public class CitiesDAL : Cities
{
#region "Decleration"
private string m_TableName;
private string m_byteCountryFN ;
private string m_byteCityFN ;
private string m_strCityDescEnFN ;
private string m_strCityDescArFN ;
private string m_byteAreaFN ;
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
public string byteCountryFN 
{
get { return  m_byteCountryFN; }
set {m_byteCountryFN  = value ; }
}
public string byteCityFN 
{
get { return  m_byteCityFN; }
set {m_byteCityFN  = value ; }
}
public string strCityDescEnFN 
{
get { return  m_strCityDescEnFN; }
set {m_strCityDescEnFN  = value ; }
}
public string strCityDescArFN 
{
get { return  m_strCityDescArFN; }
set {m_strCityDescArFN  = value ; }
}
public string byteAreaFN 
{
get { return  m_byteAreaFN; }
set {m_byteAreaFN  = value ; }
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
public CitiesDAL()
{
try
{
this.TableName = "Lkp_Cities";
this.byteCountryFN = m_TableName + ".byteCountry";
this.byteCityFN = m_TableName + ".byteCity";
this.strCityDescEnFN = m_TableName + ".strCityDescEn";
this.strCityDescArFN = m_TableName + ".strCityDescAr";
this.byteAreaFN = m_TableName + ".byteArea";
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
sSQL +=byteCountryFN;
sSQL += " , " + byteCityFN;
sSQL += " , " + strCityDescEnFN;
sSQL += " , " + strCityDescArFN;
sSQL += " , " + byteAreaFN;
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
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=byteCountryFN;
sSQL += " , " + byteCityFN;
sSQL += " , " + strCityDescEnFN;
sSQL += " , " + strCityDescArFN;
sSQL += " , " + byteAreaFN;
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
sSQL += LibraryMOD.GetFieldName(byteCountryFN) + "=@byteCountry";
sSQL += " , " + LibraryMOD.GetFieldName(byteCityFN) + "=@byteCity";
sSQL += " , " + LibraryMOD.GetFieldName(strCityDescEnFN) + "=@strCityDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strCityDescArFN) + "=@strCityDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(byteAreaFN) + "=@byteArea";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(byteCountryFN)+"=@byteCountry";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteCityFN)+"=@byteCity";
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
sSQL +=LibraryMOD.GetFieldName(byteCountryFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteCityFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCityDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCityDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteAreaFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @byteCountry";
sSQL += " ,@byteCity";
sSQL += " ,@strCityDescEn";
sSQL += " ,@strCityDescAr";
sSQL += " ,@byteArea";
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
sSQL += LibraryMOD.GetFieldName(byteCountryFN)+"=@byteCountry";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteCityFN)+"=@byteCity";
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
public List< Cities> GetCities(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    {
    //' returns a list of Classes instances based on the
    //' data in the Cities
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
    List<Cities> results = new List<Cities>();
    try
    {
    //Default Value
    Cities myCities = new Cities();
    if (isDeafaultIncluded)
    {
    //Change the code here
    myCities.byteCountry = 0;
    myCities.byteCity = 0;
    myCities.strCityDescEn = "Select City ...";
    results.Add(myCities);
    }
    while (reader.Read())
    {
    myCities = new Cities();
    if (reader[LibraryMOD.GetFieldName(byteCountryFN)].Equals(DBNull.Value))
        {
        myCities.byteCountry = 0;
        }
        else
        {
        myCities.byteCountry = int.Parse(reader[LibraryMOD.GetFieldName( byteCountryFN) ].ToString());
        }
    if (reader[LibraryMOD.GetFieldName(byteCityFN)].Equals(DBNull.Value))
    {
    myCities.byteCity = 0;
    }
    else
    {
    myCities.byteCity = int.Parse(reader[LibraryMOD.GetFieldName( byteCityFN) ].ToString());
    }
    myCities.strCityDescEn =reader[LibraryMOD.GetFieldName( strCityDescEnFN) ].ToString();
    myCities.strCityDescAr =reader[LibraryMOD.GetFieldName( strCityDescArFN) ].ToString();
    if (reader[LibraryMOD.GetFieldName(byteAreaFN)].Equals(DBNull.Value))
    {
    myCities.byteArea = 0;
    }
    else
    {
    myCities.byteArea = int.Parse(reader[LibraryMOD.GetFieldName( byteAreaFN) ].ToString());
    }
    myCities.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
    {
        myCities.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
    }
    myCities.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
    {
        myCities.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
    }
    myCities.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
    myCities.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
    
    results.Add(myCities);
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
public int UpdateCities(InitializeModule.EnumCampus Campus, int iMode,int byteCountry,int byteCity,string strCityDescEn,string strCityDescAr,int byteArea,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Cities theCities = new Cities();
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
Cmd.Parameters.Add(new SqlParameter("@byteCountry",byteCountry));
Cmd.Parameters.Add(new SqlParameter("@byteCity",byteCity));
Cmd.Parameters.Add(new SqlParameter("@strCityDescEn",strCityDescEn));
Cmd.Parameters.Add(new SqlParameter("@strCityDescAr",strCityDescAr));
Cmd.Parameters.Add(new SqlParameter("@byteArea",byteArea));
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
public int DeleteCities(InitializeModule.EnumCampus Campus,string byteCountry,string byteCity)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@byteCountry", byteCountry ));
Cmd.Parameters.Add(new SqlParameter("@byteCity", byteCity ));
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
DataTable dt = new DataTable("Cities");
DataView dv = new DataView();
List<Cities> myCitiess = new List<Cities>();
try
{
myCitiess = GetCities(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("byteCountry", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteCity", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strCityDescEn", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myCitiess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCitiess[i].byteCountry;
  dr[2] = myCitiess[i].byteCity;
  dr[3] = myCitiess[i].strCityDescEn;
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
myCitiess.Clear();
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
sSQL += byteCountryFN;
//sSQL += " , " + ";
sSQL += "  FROM " + m_TableName;
SqlDataAdapter adapter = new SqlDataAdapter(sSQL, con);
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
public class CitiesCls : CitiesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daCities;
private DataSet m_dsCities;
public DataRow CitiesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsCities
{
get { return m_dsCities ; }
set { m_dsCities = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public CitiesCls()
{
try
{
dsCities= new DataSet();

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
public virtual SqlDataAdapter GetCitiesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daCities = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCities);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daCities.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCities;
}
public virtual SqlDataAdapter GetCitiesDataAdapter(SqlConnection con)  
{
try
{
daCities = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daCities.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdCities;
cmdCities = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@byteCountry", SqlDbType.Int, 4, "byteCountry" );
//'cmdRolePermission.Parameters.Add("@byteCity", SqlDbType.Int, 4, "byteCity" );
daCities.SelectCommand = cmdCities;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdCities = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdCities.Parameters.Add("@byteCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCountryFN));
cmdCities.Parameters.Add("@byteCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCityFN));
cmdCities.Parameters.Add("@strCityDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCityDescEnFN));
cmdCities.Parameters.Add("@strCityDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCityDescArFN));
cmdCities.Parameters.Add("@byteArea", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteAreaFN));
cmdCities.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdCities.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdCities.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdCities.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdCities.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdCities.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdCities.Parameters.Add("@byteCountry", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteCountryFN));
Parmeter = cmdCities.Parameters.Add("@byteCity", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteCityFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daCities.UpdateCommand = cmdCities;
daCities.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdCities = new SqlCommand(GetInsertCommand(), con);
cmdCities.Parameters.Add("@byteCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCountryFN));
cmdCities.Parameters.Add("@byteCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCityFN));
cmdCities.Parameters.Add("@strCityDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCityDescEnFN));
cmdCities.Parameters.Add("@strCityDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCityDescArFN));
cmdCities.Parameters.Add("@byteArea", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteAreaFN));
cmdCities.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdCities.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdCities.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdCities.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdCities.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdCities.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daCities.InsertCommand =cmdCities;
daCities.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdCities = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdCities.Parameters.Add("@byteCountry", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteCountryFN));
Parmeter = cmdCities.Parameters.Add("@byteCity", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteCityFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daCities.DeleteCommand =cmdCities;
daCities.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daCities.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCities;
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
dr = dsCities.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(byteCountryFN)]=byteCountry;
dr[LibraryMOD.GetFieldName(byteCityFN)]=byteCity;
dr[LibraryMOD.GetFieldName(strCityDescEnFN)]=strCityDescEn;
dr[LibraryMOD.GetFieldName(strCityDescArFN)]=strCityDescAr;
dr[LibraryMOD.GetFieldName(byteAreaFN)]=byteArea;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= ECTGlobalDll.InitializeModule.gNetUserName;
dsCities.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsCities.Tables[TableName].Select(LibraryMOD.GetFieldName(byteCountryFN)  + "=" + byteCountry  + " AND " + LibraryMOD.GetFieldName(byteCityFN) + "=" + byteCity);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(byteCountryFN)]=byteCountry;
drAry[0][LibraryMOD.GetFieldName(byteCityFN)]=byteCity;
drAry[0][LibraryMOD.GetFieldName(strCityDescEnFN)]=strCityDescEn;
drAry[0][LibraryMOD.GetFieldName(strCityDescArFN)]=strCityDescAr;
drAry[0][LibraryMOD.GetFieldName(byteAreaFN)]=byteArea;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
//drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
//drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
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
public int CommitCities()  
{
//CommitCities= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daCities.Update(dsCities, TableName);
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
FindInMultiPKey(byteCountry,byteCity);
if (( CitiesDataRow != null)) 
{
CitiesDataRow.Delete();
CommitCities();
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
if (CitiesDataRow[LibraryMOD.GetFieldName(byteCountryFN)]== System.DBNull.Value)
{
  byteCountry=0;
}
else
{
  byteCountry = (int)CitiesDataRow[LibraryMOD.GetFieldName(byteCountryFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(byteCityFN)]== System.DBNull.Value)
{
  byteCity=0;
}
else
{
  byteCity = (int)CitiesDataRow[LibraryMOD.GetFieldName(byteCityFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(strCityDescEnFN)]== System.DBNull.Value)
{
  strCityDescEn="";
}
else
{
  strCityDescEn = (string)CitiesDataRow[LibraryMOD.GetFieldName(strCityDescEnFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(strCityDescArFN)]== System.DBNull.Value)
{
  strCityDescAr="";
}
else
{
  strCityDescAr = (string)CitiesDataRow[LibraryMOD.GetFieldName(strCityDescArFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(byteAreaFN)]== System.DBNull.Value)
{
  byteArea=0;
}
else
{
  byteArea = (int)CitiesDataRow[LibraryMOD.GetFieldName(byteAreaFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)CitiesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)CitiesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)CitiesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)CitiesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)CitiesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (CitiesDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)CitiesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKbyteCountry,int PKbyteCity) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKbyteCountry;
findTheseVals[1] = PKbyteCity;
CitiesDataRow = dsCities.Tables[TableName].Rows.Find(findTheseVals);
if  ((CitiesDataRow !=null)) 
{
lngCurRow = dsCities.Tables[TableName].Rows.IndexOf(CitiesDataRow);
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
  lngCurRow = dsCities.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsCities.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsCities.Tables[TableName].Rows.Count > 0) 
{
  CitiesDataRow = dsCities.Tables[TableName].Rows[lngCurRow];
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
daCities.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCities.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daCities.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCities.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
