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
public class Final_Group
{
//Creation Date: 17/12/2013 4:50 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_Year; 
private int m_Semester; 
private int m_iGroupID; 
private int m_iDay;     
private DateTime m_dTime; 
private string m_sDesc; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int Year
{
get { return  m_Year; }
set {m_Year  = value ; }
}
public int Semester
{
get { return  m_Semester; }
set {m_Semester  = value ; }
}
public int iGroupID
{
get { return  m_iGroupID; }
set {m_iGroupID  = value ; }
}
public int iDay
{
    get { return m_iDay; }
    set { m_iDay = value; }
}
    
public DateTime dTime
{
get { return  m_dTime; }
set {m_dTime  = value ; }
}
public string sDesc
{
get { return  m_sDesc; }
set {m_sDesc  = value ; }
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
public Final_Group()
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
public class Final_GroupDAL : Final_Group
{
#region "Decleration"
private string m_TableName;
private string m_YearFN ;
private string m_SemesterFN ;
private string m_iDayFN;
private string m_iGroupIDFN ;
private string m_dTimeFN ;
private string m_sDescFN ;
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
public string YearFN 
{
get { return  m_YearFN; }
set {m_YearFN  = value ; }
}
public string SemesterFN 
{
get { return  m_SemesterFN; }
set {m_SemesterFN  = value ; }
}
public string iGroupIDFN 
{
get { return  m_iGroupIDFN; }
set {m_iGroupIDFN  = value ; }
}
public string iDayFN 
{
    get { return m_iDayFN; }
    set { m_iDayFN = value; }
}   

public string dTimeFN 
{
get { return  m_dTimeFN; }
set {m_dTimeFN  = value ; }
}
public string sDescFN 
{
get { return  m_sDescFN; }
set {m_sDescFN  = value ; }
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
public Final_GroupDAL()
{
try
{
this.TableName = "Reg_Final_Group";
this.YearFN = m_TableName + ".Year";
this.SemesterFN = m_TableName + ".Semester";
this.iGroupIDFN = m_TableName + ".iGroupID";
this.iDayFN = m_TableName + ".iDay";
this.dTimeFN = m_TableName + ".dTime";
this.sDescFN = m_TableName + ".sDesc";
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
sSQL +=YearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + iGroupIDFN;
sSQL += " , " + iDayFN;
sSQL += " , " + dTimeFN;
sSQL += " , " + sDescFN;
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
sSQL +=YearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + iGroupIDFN;
sSQL += " , " + iDayFN;
sSQL += "  FROM " + m_TableName;
if (sCondition != "")
{
    sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION;
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
sSQL +=YearFN;
sSQL += " , " + SemesterFN;
sSQL += " , " + iGroupIDFN;
sSQL += " , " + iDayFN;
sSQL += " , " + dTimeFN;
sSQL += " , " + sDescFN;
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
sSQL += LibraryMOD.GetFieldName(YearFN) + "=@Year";
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
sSQL += " , " + LibraryMOD.GetFieldName(iGroupIDFN) + "=@iGroupID";
sSQL += " , " + LibraryMOD.GetFieldName(iDayFN) + "=@iDay";
sSQL += " , " + LibraryMOD.GetFieldName(dTimeFN) + "=@dTime";
sSQL += " , " + LibraryMOD.GetFieldName(sDescFN) + "=@sDesc";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(YearFN)+"=@Year";
sSQL +=  " And " + LibraryMOD.GetFieldName(SemesterFN)+"=@Semester";
sSQL +=  " And " + LibraryMOD.GetFieldName(iGroupIDFN)+"=@iGroupID";
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
sSQL +=LibraryMOD.GetFieldName(YearFN);
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(iGroupIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(iDayFN);
sSQL += " , " + LibraryMOD.GetFieldName(dTimeFN);
sSQL += " , " + LibraryMOD.GetFieldName(sDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @Year";
sSQL += " ,@Semester";
sSQL += " ,@iGroupID";
sSQL += " ,@iDay";
sSQL += " ,@dTime";
sSQL += " ,@sDesc";
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
sSQL += LibraryMOD.GetFieldName(YearFN)+"=@Year";
sSQL +=  " And " +  LibraryMOD.GetFieldName(SemesterFN)+"=@Semester";
sSQL +=  " And " +  LibraryMOD.GetFieldName(iGroupIDFN)+"=@iGroupID";
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
public List< Final_Group> GetFinal_Group(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Final_Group
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
List<Final_Group> results = new List<Final_Group>();
try
{
//Default Value
Final_Group myFinal_Group = new Final_Group();
if (isDeafaultIncluded)
{
//Change the code here
myFinal_Group.Year = 0;
myFinal_Group.Semester = 0;
myFinal_Group.iGroupID = 0;
//myFinal_Group.iGroupID = "Select Final_Group ...";

results.Add(myFinal_Group);
}
while (reader.Read())
{
myFinal_Group = new Final_Group();
if (reader[LibraryMOD.GetFieldName(YearFN)].Equals(DBNull.Value))
{
myFinal_Group.Year = 0;
}
else
{
myFinal_Group.Year = int.Parse(reader[LibraryMOD.GetFieldName( YearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
{
myFinal_Group.Semester = 0;
}
else
{
myFinal_Group.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(iGroupIDFN)].Equals(DBNull.Value))
{
myFinal_Group.iGroupID = 0;
}
else
{
myFinal_Group.iGroupID = int.Parse(reader[LibraryMOD.GetFieldName( iGroupIDFN) ].ToString());
}

if (reader[LibraryMOD.GetFieldName(iDayFN)].Equals(DBNull.Value))
{
    myFinal_Group.iDay = 0;
}
else
{
    myFinal_Group.iDay = int.Parse(reader[LibraryMOD.GetFieldName(iDayFN)].ToString());
}

if (!reader[LibraryMOD.GetFieldName(dTimeFN)].Equals(DBNull.Value))
{
myFinal_Group.dTime = DateTime.Parse(reader[LibraryMOD.GetFieldName( dTimeFN) ].ToString());
}
myFinal_Group.sDesc =reader[LibraryMOD.GetFieldName( sDescFN) ].ToString();
myFinal_Group.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myFinal_Group.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myFinal_Group.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myFinal_Group.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myFinal_Group.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myFinal_Group.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myFinal_Group);
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
public List< Final_Group > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Final_Group> results = new List<Final_Group>();
try
{
//Default Value
Final_Group myFinal_Group= new Final_Group();
if (isDeafaultIncluded)
 {
//Change the code here
 myFinal_Group.Year = -1;
 myFinal_Group.Semester = -1 ;
 myFinal_Group.iGroupID  = -1;

results.Add(myFinal_Group);
 }
while (reader.Read())
{
myFinal_Group = new Final_Group();
if (reader[LibraryMOD.GetFieldName(YearFN)].Equals(DBNull.Value))
{
myFinal_Group.Year = 0;
}
else
{
myFinal_Group.Year = int.Parse(reader[LibraryMOD.GetFieldName( YearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
{
myFinal_Group.Semester = 0;
}
else
{
myFinal_Group.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(iGroupIDFN)].Equals(DBNull.Value))
{
myFinal_Group.iGroupID = 0;
}
else
{
myFinal_Group.iGroupID = int.Parse(reader[LibraryMOD.GetFieldName( iGroupIDFN) ].ToString());
}

if (reader[LibraryMOD.GetFieldName(iDayFN)].Equals(DBNull.Value))
{
myFinal_Group.iDay = 0;
}
else
{
myFinal_Group.iDay = int.Parse(reader[LibraryMOD.GetFieldName( iDayFN) ].ToString());
}
 results.Add(myFinal_Group);
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
public int UpdateFinal_Group(InitializeModule.EnumCampus Campus, int iMode,int Year,int Semester,int iGroupID,DateTime dTime,string sDesc,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Final_Group theFinal_Group = new Final_Group();
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
Cmd.Parameters.Add(new SqlParameter("@Year",Year));
Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
Cmd.Parameters.Add(new SqlParameter("@iGroupID",iGroupID));
Cmd.Parameters.Add(new SqlParameter("@iDay", iDay));
Cmd.Parameters.Add(new SqlParameter("@dTime",dTime));
Cmd.Parameters.Add(new SqlParameter("@sDesc",sDesc));
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
public int DeleteFinal_Group(InitializeModule.EnumCampus Campus,string Year,string Semester,string iGroupID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@Year", Year ));
Cmd.Parameters.Add(new SqlParameter("@Semester", Semester ));
Cmd.Parameters.Add(new SqlParameter("@iGroupID", iGroupID ));
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

public int GetDay(int iGroupID, int iYear, int iSem)
{
    String sSQL;
    int iDayID = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += iDayFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + iGroupIDFN  + "=" + iGroupID;
        sSQL += "  AND " + YearFN + "=" + iYear;
        sSQL += "  AND " + SemesterFN + "=" + iSem;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            iGroupID = datReader.GetInt32(0);
        }
        datReader.Close();

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

    return iDayID;
}

public DataView GetDataView(bool isFromRole,int PK,string sCondition)
{
DataTable dt = new DataTable("Final_Group");
DataView dv = new DataView();
List<Final_Group> myFinal_Groups = new List<Final_Group>();
try
{
myFinal_Groups = GetFinal_Group(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("Year", Type.GetType("int"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("Semester", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("iGroupID", Type.GetType("int"));
dt.Columns.Add(col2 );

dt.Constraints.Add(new UniqueConstraint(col0));
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myFinal_Groups.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myFinal_Groups[i].Year;
  dr[2] = myFinal_Groups[i].Semester;
  dr[3] = myFinal_Groups[i].iGroupID;
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
myFinal_Groups.Clear();
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
sSQL += YearFN;
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
public class Final_GroupCls : Final_GroupDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daFinal_Group;
private DataSet m_dsFinal_Group;
public DataRow Final_GroupDataRow ;
//'---- Used In Details classes -----------------------
public DataTable dtFinal_Group;
public DataRow[] Final_GroupDataRowAry ;
//'-----------------------------------------------------
#endregion
#region "Puplic Properties"
public DataSet dsFinal_Group
{
get { return m_dsFinal_Group ; }
set { m_dsFinal_Group = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Final_GroupCls()
{
try
{
dsFinal_Group= new DataSet();

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
public virtual SqlDataAdapter GetFinal_GroupDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daFinal_Group = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daFinal_Group);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daFinal_Group.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFinal_Group;
}
public virtual SqlDataAdapter GetFinal_GroupDataAdapter(SqlConnection con)  
{
try
{
daFinal_Group = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daFinal_Group.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdFinal_Group;
cmdFinal_Group = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@Year", SqlDbType.Int, 4, "Year" );
//'cmdRolePermission.Parameters.Add("@Semester", SqlDbType.Int, 4, "Semester" );
//'cmdRolePermission.Parameters.Add("@iGroupID", SqlDbType.Int, 4, "iGroupID" );
daFinal_Group.SelectCommand = cmdFinal_Group;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdFinal_Group = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdFinal_Group.Parameters.Add("@Year", SqlDbType.Int,4, LibraryMOD.GetFieldName(YearFN));
//cmdFinal_Group.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
//cmdFinal_Group.Parameters.Add("@iGroupID", SqlDbType.Int,4, LibraryMOD.GetFieldName(iGroupIDFN));
cmdFinal_Group.Parameters.Add("@iDay", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iDayFN));
cmdFinal_Group.Parameters.Add("@dTime", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dTimeFN));
cmdFinal_Group.Parameters.Add("@sDesc", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(sDescFN));
cmdFinal_Group.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFinal_Group.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFinal_Group.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFinal_Group.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFinal_Group.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFinal_Group.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdFinal_Group.Parameters.Add("@Year", SqlDbType.Int, 4, LibraryMOD.GetFieldName(YearFN));
Parmeter = cmdFinal_Group.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
Parmeter = cmdFinal_Group.Parameters.Add("@iGroupID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iGroupIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daFinal_Group.UpdateCommand = cmdFinal_Group;
daFinal_Group.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdFinal_Group = new SqlCommand(GetInsertCommand(), con);
cmdFinal_Group.Parameters.Add("@Year", SqlDbType.Int,4, LibraryMOD.GetFieldName(YearFN));
cmdFinal_Group.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
cmdFinal_Group.Parameters.Add("@iGroupID", SqlDbType.Int,4, LibraryMOD.GetFieldName(iGroupIDFN));
cmdFinal_Group.Parameters.Add("@iDay", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iDayFN));
cmdFinal_Group.Parameters.Add("@dTime", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dTimeFN));
cmdFinal_Group.Parameters.Add("@sDesc", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(sDescFN));
cmdFinal_Group.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdFinal_Group.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdFinal_Group.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdFinal_Group.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdFinal_Group.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdFinal_Group.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daFinal_Group.InsertCommand =cmdFinal_Group;
daFinal_Group.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdFinal_Group = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdFinal_Group.Parameters.Add("@Year", SqlDbType.Int, 4, LibraryMOD.GetFieldName(YearFN));
Parmeter = cmdFinal_Group.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
Parmeter = cmdFinal_Group.Parameters.Add("@iGroupID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iGroupIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daFinal_Group.DeleteCommand =cmdFinal_Group;
daFinal_Group.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daFinal_Group.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daFinal_Group;
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
dr = dtFinal_Group.NewRow();
dr[LibraryMOD.GetFieldName(YearFN)]=Year;
dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
dr[LibraryMOD.GetFieldName(iGroupIDFN)]=iGroupID;
dr[LibraryMOD.GetFieldName(iDayFN)] = iDay;
dr[LibraryMOD.GetFieldName(dTimeFN)]=dTime;
dr[LibraryMOD.GetFieldName(sDescFN)]=sDesc;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dtFinal_Group.Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dtFinal_Group.Select(LibraryMOD.GetFieldName(YearFN)  + "=" + Year  + " AND " + LibraryMOD.GetFieldName(SemesterFN) + "=" + Semester  + " AND " + LibraryMOD.GetFieldName(iGroupIDFN) + "=" + iGroupID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(YearFN)]=Year;
drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
drAry[0][LibraryMOD.GetFieldName(iGroupIDFN)]=iGroupID;
drAry[0][LibraryMOD.GetFieldName(iDayFN)] = iDay;
drAry[0][LibraryMOD.GetFieldName(dTimeFN)]=dTime;
drAry[0][LibraryMOD.GetFieldName(sDescFN)]=sDesc;
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
public int CommitFinal_Group()  
{
//CommitFinal_Group= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daFinal_Group.Update(dsFinal_Group, TableName);
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
FindInMultiPKey(Year,Semester,iGroupID);
if (( Final_GroupDataRow != null)) 
{
Final_GroupDataRow.Delete();
CommitFinal_Group();
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
//'-------DeleteAllRows  -----------------------------
public int DeleteAllRows(SqlConnection con) 
{
//DeleteAllRows= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
string sSQL  ="";
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE " + YearFN + "=" + Year;
SqlCommand CommandSQL = new SqlCommand(sSQL, con);
CommandSQL.ExecuteNonQuery();
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
//'-------DeleteAllRows  -------Trans As SqlClient.SqlTransaction -----------------
public int DeleteAllRows(SqlTransaction Trans,SqlConnection con )
{
//DeleteAllRows= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
string sSQL ="";
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE " + YearFN + "=" + Year;
SqlCommand CommandSQL = new SqlCommand(sSQL, con, Trans);
CommandSQL.ExecuteNonQuery();
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
if (Final_GroupDataRow[LibraryMOD.GetFieldName(YearFN)]== System.DBNull.Value)
{
  Year=0;
}
else
{
  Year = (int)Final_GroupDataRow[LibraryMOD.GetFieldName(YearFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
{
  Semester=0;
}
else
{
  Semester = (int)Final_GroupDataRow[LibraryMOD.GetFieldName(SemesterFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(iGroupIDFN)]== System.DBNull.Value)
{
  iGroupID=0;
}
else
{
  iGroupID = (int)Final_GroupDataRow[LibraryMOD.GetFieldName(iGroupIDFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(iDayFN)] == System.DBNull.Value)
{
    iDay = 0;
}
else
{
    iDay = (int)Final_GroupDataRow[LibraryMOD.GetFieldName(iDayFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(dTimeFN)]== System.DBNull.Value)
{
}
else
{
  dTime = (DateTime)Final_GroupDataRow[LibraryMOD.GetFieldName(dTimeFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(sDescFN)]== System.DBNull.Value)
{
  sDesc="";
}
else
{
  sDesc = (string)Final_GroupDataRow[LibraryMOD.GetFieldName(sDescFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Final_GroupDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Final_GroupDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Final_GroupDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Final_GroupDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Final_GroupDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Final_GroupDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Final_GroupDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKYear,int PKSemester,int PKiGroupID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[3] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKYear;
findTheseVals[1] = PKSemester;
findTheseVals[2] = PKiGroupID;
Final_GroupDataRow = dtFinal_Group.Rows.Find(findTheseVals);
if  ((Final_GroupDataRow !=null)) 
{
lngCurRow = dtFinal_Group.Rows.IndexOf(Final_GroupDataRow);
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
  lngCurRow = dsFinal_Group.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsFinal_Group.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsFinal_Group.Tables[TableName].Rows.Count > 0) 
{
  Final_GroupDataRow = dsFinal_Group.Tables[TableName].Rows[lngCurRow];
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
daFinal_Group.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFinal_Group.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daFinal_Group.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daFinal_Group.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
