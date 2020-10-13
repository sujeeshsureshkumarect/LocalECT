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
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Colleges
{
//Creation Date: 22/02/2010 6:54:00 PM
//Programmer Name : ihab
//-----Decleration --------------
#region "Decleration"
private string m_strCollege; 
private string m_strCollegeDescEn; 
private string m_strCollegeDescAr;
private int  m_ChairmanID; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public string strCollege
{
get { return  m_strCollege; }
set {m_strCollege  = value ; }
}
public string strCollegeDescEn
{
get { return  m_strCollegeDescEn; }
set {m_strCollegeDescEn  = value ; }
}
public string strCollegeDescAr
{
get { return  m_strCollegeDescAr; }
set {m_strCollegeDescAr  = value ; }
}
public int ChairmanID
{
    get { return m_ChairmanID; }
    set { m_ChairmanID = value; }
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
#endregion
//'-----------------------------------------------------
public Colleges()
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
public class CollegesDAL : Colleges
{
#region "Decleration"
private string m_TableName;
private string m_strCollegeFN ;
private string m_strCollegeDescEnFN ;
private string m_strCollegeDescArFN ;
private string m_ChairmanIDFN;
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
public string strCollegeFN 
{
get { return  m_strCollegeFN; }
set {m_strCollegeFN  = value ; }
}
public string strCollegeDescEnFN 
{
get { return  m_strCollegeDescEnFN; }
set {m_strCollegeDescEnFN  = value ; }
}
public string strCollegeDescArFN 
{
get { return  m_strCollegeDescArFN; }
set {m_strCollegeDescArFN  = value ; }
}
public string ChairmanIDFN 
{
get { return  m_ChairmanIDFN; }
set {m_ChairmanIDFN  = value ; }
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
public CollegesDAL()
{
try
{
this.TableName = "Reg_Colleges";
this.strCollegeFN = m_TableName + ".strCollege";
this.strCollegeDescEnFN = m_TableName + ".strCollegeDescEn";
this.strCollegeDescArFN = m_TableName + ".strCollegeDescAr";
this.ChairmanIDFN = m_TableName + ".ChairmanID";
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
sSQL +=strCollegeFN;
sSQL += " , " + strCollegeDescEnFN;
sSQL += " , " + strCollegeDescArFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + ChairmanIDFN;
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

public string GetListSQL(string sWhere)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += strCollegeFN;
        sSQL += " , " + strCollegeDescEnFN;
        sSQL += "  FROM " + m_TableName;
        if (!string.IsNullOrEmpty(sWhere))
        {
            sSQL += " WHERE " + sWhere;
        }
        sSQL += " ORDER BY FacultyID," +  strCollegeDescEnFN;
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
public List<Colleges> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
    //' returns a list of Classes instances based on the
    //' data in the Lecturers
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Colleges> results = new List<Colleges>();
    try
    {
        //Default Value
        Colleges myColleges = new Colleges();
        if (isDeafaultIncluded)
        {
            //Change the code here
            myColleges.strCollege="0";
            myColleges.strCollegeDescEn = "Select Unit ...";

            results.Add(myColleges);
        }
        while (reader.Read())
        {
            myColleges = new Colleges();
            myColleges.strCollege = reader[LibraryMOD.GetFieldName(strCollegeFN)].ToString();
            myColleges.strCollegeDescEn = reader[LibraryMOD.GetFieldName(strCollegeDescEnFN)].ToString();
            results.Add(myColleges);
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
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=strCollegeFN;
sSQL += " , " + strCollegeDescEnFN;
sSQL += " , " + strCollegeDescArFN;
sSQL += " , " + ChairmanIDFN;
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
sSQL += LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeDescEnFN) + "=@strCollegeDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeDescArFN) + "=@strCollegeDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(ChairmanIDFN) + "=@ChairmanID";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(strCollegeFN)+"=@strCollege";
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
sSQL +=LibraryMOD.GetFieldName(strCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(ChairmanIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @strCollege";
sSQL += " ,@strCollegeDescEn";
sSQL += " ,@strCollegeDescAr";
sSQL += " ,@ChairmanID";
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
sSQL += LibraryMOD.GetFieldName(strCollegeFN)+"=@strCollege";
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
public List< Colleges> GetColleges(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Colleges
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
List<Colleges> results = new List<Colleges>();
try
{
//Default Value
Colleges myColleges = new Colleges();
if (isDeafaultIncluded)
{
//Change the code here
myColleges.strCollege = "0";
myColleges.strCollegeDescEn = "Select College ...";
results.Add(myColleges);
}
while (reader.Read())
{
myColleges = new Colleges();
myColleges.strCollege =reader[LibraryMOD.GetFieldName( strCollegeFN) ].ToString();
myColleges.strCollegeDescEn =reader[LibraryMOD.GetFieldName( strCollegeDescEnFN) ].ToString();
myColleges.strCollegeDescAr =reader[LibraryMOD.GetFieldName( strCollegeDescArFN) ].ToString();
myColleges.ChairmanID = int.Parse(reader[LibraryMOD.GetFieldName(ChairmanIDFN)].ToString());
myColleges.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myColleges.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myColleges.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myColleges.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myColleges.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myColleges.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myColleges);
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
public int UpdateColleges(InitializeModule.EnumCampus Campus, int iMode,string strCollege,string strCollegeDescEn,string strCollegeDescAr,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Colleges theColleges = new Colleges();
//'Updates the  table
switch(iMode) 
  {
  case  (int)InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@strCollege",strCollege));
Cmd.Parameters.Add(new SqlParameter("@strCollegeDescEn",strCollegeDescEn));
Cmd.Parameters.Add(new SqlParameter("@strCollegeDescAr",strCollegeDescAr));
Cmd.Parameters.Add(new SqlParameter("@ChairmanID", ChairmanID));
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
public int DeleteColleges(InitializeModule.EnumCampus Campus,string strCollege)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege ));
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
DataTable dt = new DataTable("Colleges");
DataView dv = new DataView();
List<Colleges> myCollegess = new List<Colleges>();
try
{
myCollegess = GetColleges(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("strCollege", Type.GetType("nvarchar"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strCollegeDescEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strCollegeDescAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
DataColumn col4 = new DataColumn("ChairmanID", Type.GetType("int"));
dt.Columns.Add(col4);

dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myCollegess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCollegess[i].strCollege;
  dr[2] = myCollegess[i].strCollegeDescEn;
  dr[3] = myCollegess[i].strCollegeDescAr;
  dr[4] = myCollegess[i].ChairmanID;
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
myCollegess.Clear();
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
sSQL += strCollegeFN;
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
public class CollegesCls : CollegesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daColleges;
private DataSet m_dsColleges;
public DataRow CollegesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsColleges
{
get { return m_dsColleges ; }
set { m_dsColleges = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public CollegesCls()
{
try
{
dsColleges= new DataSet();

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
public virtual SqlDataAdapter GetCollegesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daColleges = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daColleges);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daColleges.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daColleges;
}
public virtual SqlDataAdapter GetCollegesDataAdapter(SqlConnection con)  
{
try
{
daColleges = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daColleges.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdColleges;
cmdColleges = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@strCollege", SqlDbType.Int, 4, "strCollege" );
daColleges.SelectCommand = cmdColleges;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdColleges = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdColleges.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
cmdColleges.Parameters.Add("@strCollegeDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCollegeDescEnFN));
cmdColleges.Parameters.Add("@strCollegeDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCollegeDescArFN));
cmdColleges.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdColleges.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdColleges.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdColleges.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdColleges.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdColleges.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdColleges.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daColleges.UpdateCommand = cmdColleges;
daColleges.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdColleges = new SqlCommand(GetInsertCommand(), con);
cmdColleges.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
cmdColleges.Parameters.Add("@strCollegeDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCollegeDescEnFN));
cmdColleges.Parameters.Add("@strCollegeDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCollegeDescArFN));
cmdColleges.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdColleges.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdColleges.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdColleges.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdColleges.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdColleges.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daColleges.InsertCommand =cmdColleges;
daColleges.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdColleges = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdColleges.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daColleges.DeleteCommand =cmdColleges;
daColleges.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daColleges.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daColleges;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsColleges.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
dr[LibraryMOD.GetFieldName(strCollegeDescEnFN)]=strCollegeDescEn;
dr[LibraryMOD.GetFieldName(strCollegeDescArFN)]=strCollegeDescAr;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsColleges.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsColleges.Tables[TableName].Select(LibraryMOD.GetFieldName(strCollegeFN)  + "=" + strCollege);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
drAry[0][LibraryMOD.GetFieldName(strCollegeDescEnFN)]=strCollegeDescEn;
drAry[0][LibraryMOD.GetFieldName(strCollegeDescArFN)]=strCollegeDescAr;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
return InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitColleges()  
{
//CommitColleges= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daColleges.Update(dsColleges, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow= InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(strCollege);
if (( CollegesDataRow != null)) 
{
CollegesDataRow.Delete();
CommitColleges();
if (MoveNext() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (CollegesDataRow[LibraryMOD.GetFieldName(strCollegeFN)]== System.DBNull.Value)
{
  strCollege="";
}
else
{
  strCollege = (string)CollegesDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(strCollegeDescEnFN)]== System.DBNull.Value)
{
  strCollegeDescEn="";
}
else
{
  strCollegeDescEn = (string)CollegesDataRow[LibraryMOD.GetFieldName(strCollegeDescEnFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(strCollegeDescArFN)]== System.DBNull.Value)
{
  strCollegeDescAr="";
}
else
{
  strCollegeDescAr = (string)CollegesDataRow[LibraryMOD.GetFieldName(strCollegeDescArFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)CollegesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)CollegesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)CollegesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)CollegesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)CollegesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (CollegesDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)CollegesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(string PKstrCollege) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKstrCollege;
CollegesDataRow = dsColleges.Tables[TableName].Rows.Find(findTheseVals);
if  ((CollegesDataRow !=null)) 
{
lngCurRow = dsColleges.Tables[TableName].Rows.IndexOf(CollegesDataRow);
SynchronizeDataRowToClass();
return InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst= InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast= InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsColleges.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsColleges.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow= InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsColleges.Tables[TableName].Rows.Count > 0) 
{
  CollegesDataRow = dsColleges.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
// InitializeModule.FAIL_RET;
try
{
daColleges.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daColleges.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daColleges.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daColleges.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
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
