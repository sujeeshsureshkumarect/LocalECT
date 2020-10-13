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
public class Exam_Checker
{
//Creation Date: 10/04/2013 5:53 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private string m_Course; 
private int m_GroupID; 
private int m_Year;
private int m_Semester;
private string m_strUserCreate;
private DateTime m_dateCreate;
private string m_strUserSave;
private DateTime m_dateLastSave;
private string m_strMachine;
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public string Course
{
get { return  m_Course; }
set {m_Course  = value ; }
}
public int GroupID
{
get { return  m_GroupID; }
set {m_GroupID  = value ; }
}
public int Year
{
get { return  m_Year; }
set {m_Year  = value ; }
}
public int Semester
{
    get { return m_Semester; }
    set { m_Semester = value; }
}
public string strUserCreate
{
    get { return m_strUserCreate; }
    set { m_strUserCreate = value; }
}
public DateTime dateCreate
{
    get { return m_dateCreate; }
    set { m_dateCreate = value; }
}
public string strUserSave
{
    get { return m_strUserSave; }
    set { m_strUserSave = value; }
}
public DateTime dateLastSave
{
    get { return m_dateLastSave; }
    set { m_dateLastSave = value; }
}
public string strMachine
{
    get { return m_strMachine; }
    set { m_strMachine = value; }
}
public string strNUser
{
    get { return m_strNUser; }
    set { m_strNUser = value; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Exam_Checker()
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
public class Exam_CheckerDAL : Exam_Checker
{
#region "Decleration"
private string m_TableName;
private string m_CourseFN ;
private string m_GroupIDFN ;
private string m_YearFN ;
private string m_SemesterFN;
private string m_strUserCreateFN;
private string m_dateCreateFN;
private string m_strUserSaveFN;
private string m_dateLastSaveFN;
private string m_strMachineFN;
private string m_strNUserFN;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string CourseFN 
{
get { return  m_CourseFN; }
set {m_CourseFN  = value ; }
}
public string GroupIDFN 
{
get { return  m_GroupIDFN; }
set {m_GroupIDFN  = value ; }
}
public string YearFN 
{
get { return  m_YearFN; }
set {m_YearFN  = value ; }
}
public string SemesterFN 
{
    get { return m_SemesterFN; }
    set { m_SemesterFN = value; }
}
public string strUserCreateFN
{
    get { return m_strUserCreateFN; }
    set { m_strUserCreateFN = value; }
}
public string dateCreateFN
{
    get { return m_dateCreateFN; }
    set { m_dateCreateFN = value; }
}
public string strUserSaveFN
{
    get { return m_strUserSaveFN; }
    set { m_strUserSaveFN = value; }
}
public string dateLastSaveFN
{
    get { return m_dateLastSaveFN; }
    set { m_dateLastSaveFN = value; }
}
public string strMachineFN
{
    get { return m_strMachineFN; }
    set { m_strMachineFN = value; }
}
public string strNUserFN
{
    get { return m_strNUserFN; }
    set { m_strNUserFN = value; }
}
#endregion
//================End Properties ===================
public Exam_CheckerDAL()
{
try
{
this.TableName = "Reg_Final_Exam_Checker";
this.CourseFN = m_TableName + ".Course";
this.GroupIDFN = m_TableName + ".GroupID";
this.YearFN = m_TableName + ".Year";
this.SemesterFN = m_TableName + ".Semester";
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
sSQL +=CourseFN;
sSQL += " , " + GroupIDFN;
sSQL += " , " + YearFN;
sSQL += " , " + SemesterFN;
    
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
public string  GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
    sSQL = "SELECT ";
    sSQL +=CourseFN;
    sSQL += " , " + GroupIDFN;
    sSQL += " , " + YearFN;
    sSQL += " , " + SemesterFN;
    sSQL += " , " + strUserCreateFN;
    sSQL += " , " + dateCreateFN;
    sSQL += " , " + strUserSaveFN;
    sSQL += " , " + dateLastSaveFN;
    sSQL += " , " + strMachineFN;
    sSQL += " , " + strNUserFN;
    sSQL += "  FROM " + m_TableName;
    
    if (sCondition != "" )
    {
        sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION  ;
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
sSQL +=CourseFN;
sSQL += " , " + GroupIDFN;
sSQL += " , " + YearFN;
sSQL += " , " + SemesterFN;
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
sSQL +=  LibraryMOD.GetFieldName(GroupIDFN) + "=@GroupID";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL +=LibraryMOD.GetFieldName(YearFN) + "=@Year";
sSQL += " AND " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
sSQL += " AND " + LibraryMOD.GetFieldName(CourseFN) + "=@Course";
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
sSQL +=LibraryMOD.GetFieldName(CourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(GroupIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(YearFN);
sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @Course";
sSQL += " ,@GroupID";
sSQL += " ,@Year";
sSQL += " ,@Semester";
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
    sSQL +=" AND " + LibraryMOD.GetFieldName(SemesterFN )+"=@Semester";
    sSQL += " AND " + LibraryMOD.GetFieldName(CourseFN)+"=@Course";
    
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


public int GetGroupID(string sCourse ,int iYear,int iSem) 
{
        String sSQL ;
        int  iGroupID=0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males );
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {

            sSQL = "SELECT ";
            sSQL += GroupIDFN  ;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + CourseFN + "='" + sCourse + "'";
            sSQL += "  AND " + YearFN + "=" + iYear ;
            sSQL += "  AND " + SemesterFN + "=" + iSem ;

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader ;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection );

            
            if ( datReader.Read() )
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

        return iGroupID;
 }
    

#endregion
public List< Exam_Checker> GetExam_Checker(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Exam_Checker
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
List<Exam_Checker> results = new List<Exam_Checker>();
try
{
//Default Value
Exam_Checker myExam_Checker = new Exam_Checker();
if (isDeafaultIncluded)
{
//Change the code here
myExam_Checker.Course = "";

results.Add(myExam_Checker);
}
while (reader.Read())
{
myExam_Checker = new Exam_Checker();
myExam_Checker.Course =reader[LibraryMOD.GetFieldName( CourseFN) ].ToString();
myExam_Checker.GroupID =Convert.ToInt32 ("0" +  reader[LibraryMOD.GetFieldName( GroupIDFN) ].ToString());
myExam_Checker.Year =Convert.ToInt32 ("0" + reader[LibraryMOD.GetFieldName( YearFN) ].ToString());
myExam_Checker.Semester = Convert.ToInt32("0" + reader[LibraryMOD.GetFieldName(SemesterFN)].ToString());
 results.Add(myExam_Checker);
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
public List< Exam_Checker > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Exam_Checker> results = new List<Exam_Checker>();
try
{
//Default Value
Exam_Checker myExam_Checker= new Exam_Checker();
if (isDeafaultIncluded)
 {
//Change the code here
 myExam_Checker.Course = "";
 myExam_Checker.GroupID = 0 ;
results.Add(myExam_Checker);
 }
while (reader.Read())
{
myExam_Checker = new Exam_Checker();
myExam_Checker.Course =reader[LibraryMOD.GetFieldName( CourseFN) ].ToString();
myExam_Checker.GroupID =Convert.ToInt32 ("0" +  reader[LibraryMOD.GetFieldName( GroupIDFN) ].ToString ());
myExam_Checker.Year =Convert.ToInt32 ("0" + reader[LibraryMOD.GetFieldName( YearFN) ].ToString());
myExam_Checker.Semester = Convert.ToInt32("0" + reader[LibraryMOD.GetFieldName(SemesterFN)].ToString());    
 results.Add(myExam_Checker);
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
public int UpdateExam_Checker(InitializeModule.EnumCampus Campus, int iMode, string Course, int GroupID, int Year, int Semester, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Exam_Checker theExam_Checker = new Exam_Checker();
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
Cmd.Parameters.Add(new SqlParameter("@Course",Course));
Cmd.Parameters.Add(new SqlParameter("@GroupID",GroupID));
Cmd.Parameters.Add(new SqlParameter("@Year",Year));
Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
Cmd.Parameters.Add(new SqlParameter("@strUserCreate", strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate", dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave", strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave", dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine", strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser", strNUser));
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
public int DeleteExam_Checker(InitializeModule.EnumCampus Campus, int Year, int Semester, string Course)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Cmd.Parameters.Add(new SqlParameter("@Year", Year  ));
    Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
    Cmd.Parameters.Add(new SqlParameter("@Course", Course ));
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
//-------DeleteAllRows  -----------------------------
public int DeleteAllRows(SqlConnection conn, int Year, int Semester)
{
    //DeleteAllRows = InitializeModule.FAIL_RET;
    try
    {
        string sSQL = "";
        sSQL = " DELETE FROM " + TableName;
        sSQL += " WHERE " + YearFN + "=" + Year   ;
        sSQL += " AND " + SemesterFN + "=" + Semester;

        SqlCommand CommandSQL = new SqlCommand(sSQL, conn);

        CommandSQL.ExecuteNonQuery();
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
public DataView GetDataView(bool isFromRole,int PK,string sCondition)
{
DataTable dt = new DataTable("Exam_Checker");
DataView dv = new DataView();
List<Exam_Checker> myExam_Checkers = new List<Exam_Checker>();
try
{
myExam_Checkers = GetExam_Checker(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("Course", Type.GetType("nvarchar"));
dt.Columns.Add(col0 );

dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myExam_Checkers.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myExam_Checkers[i].Course;
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
myExam_Checkers.Clear();
}
 return dv;
}
public Boolean IsCourseExist(string sCourse,int iyear,int isem)
{
    String sSQL;
    Boolean isExist = false;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += CourseFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + CourseFN + "='" + sCourse + "'";
        sSQL += "  AND " + YearFN + "=" + iyear ;
        sSQL += "  AND " + SemesterFN + "=" + isem  ;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            isExist = true;
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

    return isExist;
}

//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += CourseFN;
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
public class Exam_CheckerCls : Exam_CheckerDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daExam_Checker;
private DataSet m_dsExam_Checker;
public DataRow Exam_CheckerDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsExam_Checker
{
get { return m_dsExam_Checker ; }
set { m_dsExam_Checker = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Exam_CheckerCls()
{
try
{
dsExam_Checker= new DataSet();

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
public virtual SqlDataAdapter GetExam_CheckerDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daExam_Checker = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daExam_Checker);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daExam_Checker.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daExam_Checker;
}
public virtual SqlDataAdapter GetExam_CheckerDataAdapter(SqlConnection con)  
{
try
{
daExam_Checker = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daExam_Checker.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdExam_Checker;
cmdExam_Checker = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@Course", SqlDbType.Int, 4, "Course" );
daExam_Checker.SelectCommand = cmdExam_Checker;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdExam_Checker = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdExam_Checker.Parameters.Add("@Course", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseFN));
cmdExam_Checker.Parameters.Add("@GroupID", SqlDbType.NChar,20, LibraryMOD.GetFieldName(GroupIDFN));
//cmdExam_Checker.Parameters.Add("@Year", SqlDbType.NChar, 20, LibraryMOD.GetFieldName(YearFN));
cmdExam_Checker.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdExam_Checker.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
cmdExam_Checker.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdExam_Checker.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdExam_Checker.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
cmdExam_Checker.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));

Parmeter = cmdExam_Checker.Parameters.Add("@Year", SqlDbType.Int, 4, LibraryMOD.GetFieldName(YearFN));
Parmeter = cmdExam_Checker.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN ));
Parmeter = cmdExam_Checker.Parameters.Add("@Course", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CourseFN));


Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daExam_Checker.UpdateCommand = cmdExam_Checker;
daExam_Checker.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdExam_Checker = new SqlCommand(GetInsertCommand(), con);
cmdExam_Checker.Parameters.Add("@Course", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseFN));
cmdExam_Checker.Parameters.Add("@GroupID", SqlDbType.NChar,20, LibraryMOD.GetFieldName(GroupIDFN));
cmdExam_Checker.Parameters.Add("@Year", SqlDbType.NChar,20, LibraryMOD.GetFieldName(YearFN));
cmdExam_Checker.Parameters.Add("@Semester", SqlDbType.NChar, 20, LibraryMOD.GetFieldName(SemesterFN));
cmdExam_Checker.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdExam_Checker.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
cmdExam_Checker.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdExam_Checker.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdExam_Checker.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
cmdExam_Checker.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN)); 

    Parmeter.SourceVersion = DataRowVersion.Current;
daExam_Checker.InsertCommand =cmdExam_Checker;
daExam_Checker.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdExam_Checker = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdExam_Checker.Parameters.Add("@Course", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CourseFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daExam_Checker.DeleteCommand =cmdExam_Checker;
daExam_Checker.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daExam_Checker.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daExam_Checker;
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
dr = dsExam_Checker.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(CourseFN)]=Course;
dr[LibraryMOD.GetFieldName(GroupIDFN)]=GroupID;
dr[LibraryMOD.GetFieldName(YearFN)]=Year;
dr[LibraryMOD.GetFieldName(SemesterFN)] = Semester;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsExam_Checker.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsExam_Checker.Tables[TableName].Select(LibraryMOD.GetFieldName(CourseFN)  + "=" + Course);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(CourseFN)]=Course;
drAry[0][LibraryMOD.GetFieldName(GroupIDFN)]=GroupID;
drAry[0][LibraryMOD.GetFieldName(YearFN)]=Year;
drAry[0][LibraryMOD.GetFieldName(SemesterFN)] = Semester;
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
public int CommitExam_Checker()  
{
//CommitExam_Checker= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daExam_Checker.Update(dsExam_Checker, TableName);
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
FindInMultiPKey(Course);
if (( Exam_CheckerDataRow != null)) 
{
Exam_CheckerDataRow.Delete();
CommitExam_Checker();
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
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(CourseFN)]== System.DBNull.Value)
{
  Course="";
}
else
{
  Course = (string)Exam_CheckerDataRow[LibraryMOD.GetFieldName(CourseFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(GroupIDFN)]== System.DBNull.Value)
{
  GroupID=0;
}
else
{
  GroupID = (int)Exam_CheckerDataRow[LibraryMOD.GetFieldName(GroupIDFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(YearFN)]== System.DBNull.Value)
{
  Year=0;
}
else
{
    Year = (int)Exam_CheckerDataRow[LibraryMOD.GetFieldName(YearFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(SemesterFN)] == System.DBNull.Value)
{
    Semester = 0;
}
else
{
    Semester = (int)Exam_CheckerDataRow[LibraryMOD.GetFieldName(SemesterFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
{
    strUserCreate = "";
}
else
{
    strUserCreate = (string)Exam_CheckerDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
{
}
else
{
    dateCreate = (DateTime)Exam_CheckerDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
{
    strUserSave = "";
}
else
{
    strUserSave = (string)Exam_CheckerDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
{
}
else
{
    dateLastSave = (DateTime)Exam_CheckerDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
{
    strMachine = "";
}
else
{
    strMachine = (string)Exam_CheckerDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Exam_CheckerDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
{
    strNUser = "";
}
else
{
    strNUser = (string)Exam_CheckerDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(string PKCourse) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKCourse;
Exam_CheckerDataRow = dsExam_Checker.Tables[TableName].Rows.Find(findTheseVals);
if  ((Exam_CheckerDataRow !=null)) 
{
lngCurRow = dsExam_Checker.Tables[TableName].Rows.IndexOf(Exam_CheckerDataRow);
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
  lngCurRow = dsExam_Checker.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsExam_Checker.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsExam_Checker.Tables[TableName].Rows.Count > 0) 
{
  Exam_CheckerDataRow = dsExam_Checker.Tables[TableName].Rows[lngCurRow];
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
daExam_Checker.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daExam_Checker.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daExam_Checker.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daExam_Checker.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
