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
public class EmployeeAllLinkedInCourses
{
//Creation Date: 06/07/2021 5:17:57 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_SerialNo; 
private string m_sEmpEmail; 
private string m_sEmpName; 
private int m_iCourseID; 
private string m_sCourseName; 
private string m_sEngagmentType; 
private int m_iEngagmentValue; 
private string m_sAssetType; 
private DateTime m_FirstViewDate; 
private DateTime m_LastEngagedCompletedDate; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int SerialNo
{
get { return  m_SerialNo; }
set {m_SerialNo  = value ; }
}
public string sEmpEmail
{
get { return  m_sEmpEmail; }
set {m_sEmpEmail  = value ; }
}
public string sEmpName
{
get { return  m_sEmpName; }
set {m_sEmpName  = value ; }
}
public int iCourseID
{
get { return  m_iCourseID; }
set {m_iCourseID  = value ; }
}
public string sCourseName
{
get { return  m_sCourseName; }
set {m_sCourseName  = value ; }
}
public string sEngagmentType
{
get { return  m_sEngagmentType; }
set {m_sEngagmentType  = value ; }
}
public int iEngagmentValue
{
get { return  m_iEngagmentValue; }
set {m_iEngagmentValue  = value ; }
}
public string sAssetType
{
get { return  m_sAssetType; }
set {m_sAssetType  = value ; }
}
public DateTime FirstViewDate
{
get { return  m_FirstViewDate; }
set {m_FirstViewDate  = value ; }
}
public DateTime LastEngagedCompletedDate
{
get { return  m_LastEngagedCompletedDate; }
set {m_LastEngagedCompletedDate  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public EmployeeAllLinkedInCourses()
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
public class EmployeeAllLinkedInCoursesDAL : EmployeeAllLinkedInCourses
{
#region "Decleration"
private string m_TableName;
private string m_SerialNoFN ;
private string m_sEmpEmailFN ;
private string m_sEmpNameFN ;
private string m_iCourseIDFN ;
private string m_sCourseNameFN ;
private string m_sEngagmentTypeFN ;
private string m_iEngagmentValueFN ;
private string m_sAssetTypeFN ;
private string m_FirstViewDateFN ;
private string m_LastEngagedCompletedDateFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string SerialNoFN 
{
get { return  m_SerialNoFN; }
set {m_SerialNoFN  = value ; }
}
public string sEmpEmailFN 
{
get { return  m_sEmpEmailFN; }
set {m_sEmpEmailFN  = value ; }
}
public string sEmpNameFN 
{
get { return  m_sEmpNameFN; }
set {m_sEmpNameFN  = value ; }
}
public string iCourseIDFN 
{
get { return  m_iCourseIDFN; }
set {m_iCourseIDFN  = value ; }
}
public string sCourseNameFN 
{
get { return  m_sCourseNameFN; }
set {m_sCourseNameFN  = value ; }
}
public string sEngagmentTypeFN 
{
get { return  m_sEngagmentTypeFN; }
set {m_sEngagmentTypeFN  = value ; }
}
public string iEngagmentValueFN 
{
get { return  m_iEngagmentValueFN; }
set {m_iEngagmentValueFN  = value ; }
}
public string sAssetTypeFN 
{
get { return  m_sAssetTypeFN; }
set {m_sAssetTypeFN  = value ; }
}
public string FirstViewDateFN 
{
get { return  m_FirstViewDateFN; }
set {m_FirstViewDateFN  = value ; }
}
public string LastEngagedCompletedDateFN 
{
get { return  m_LastEngagedCompletedDateFN; }
set {m_LastEngagedCompletedDateFN  = value ; }
}
#endregion
//================End Properties ===================
public EmployeeAllLinkedInCoursesDAL()
{
try
{
this.TableName = "HR_EmployeeAllLinkedInCourses";
this.SerialNoFN = m_TableName + ".SerialNo";
this.sEmpEmailFN = m_TableName + ".sEmpEmail";
this.sEmpNameFN = m_TableName + ".sEmpName";
this.iCourseIDFN = m_TableName + ".iCourseID";
this.sCourseNameFN = m_TableName + ".sCourseName";
this.sEngagmentTypeFN = m_TableName + ".sEngagmentType";
this.iEngagmentValueFN = m_TableName + ".iEngagmentValue";
this.sAssetTypeFN = m_TableName + ".sAssetType";
this.FirstViewDateFN = m_TableName + ".FirstViewDate";
this.LastEngagedCompletedDateFN = m_TableName + ".LastEngagedCompletedDate";
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
sSQL +=SerialNoFN;
sSQL += " , " + sEmpEmailFN;
sSQL += " , " + sEmpNameFN;
sSQL += " , " + iCourseIDFN;
sSQL += " , " + sCourseNameFN;
sSQL += " , " + sEngagmentTypeFN;
sSQL += " , " + iEngagmentValueFN;
sSQL += " , " + sAssetTypeFN;
sSQL += " , " + FirstViewDateFN;
sSQL += " , " + LastEngagedCompletedDateFN;
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
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += SerialNoFN;
            sSQL += " , " + sEmpEmailFN;
            sSQL += " , " + sEmpNameFN;
            sSQL += "  FROM " + m_TableName;
            if (sCondition != "")
            {
                sSQL += " WHERE " + sCondition;
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
sSQL +=SerialNoFN;
sSQL += " , " + sEmpEmailFN;
sSQL += " , " + sEmpNameFN;
sSQL += " , " + iCourseIDFN;
sSQL += " , " + sCourseNameFN;
sSQL += " , " + sEngagmentTypeFN;
sSQL += " , " + iEngagmentValueFN;
sSQL += " , " + sAssetTypeFN;
sSQL += " , " + FirstViewDateFN;
sSQL += " , " + LastEngagedCompletedDateFN;
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
sSQL += LibraryMOD.GetFieldName(sEmpEmailFN) + "=@sEmpEmail";
sSQL += " , " + LibraryMOD.GetFieldName(sEmpNameFN) + "=@sEmpName";
sSQL += " , " + LibraryMOD.GetFieldName(iCourseIDFN) + "=@iCourseID";
sSQL += " , " + LibraryMOD.GetFieldName(sCourseNameFN) + "=@sCourseName";
sSQL += " , " + LibraryMOD.GetFieldName(sEngagmentTypeFN) + "=@sEngagmentType";
sSQL += " , " + LibraryMOD.GetFieldName(iEngagmentValueFN) + "=@iEngagmentValue";
sSQL += " , " + LibraryMOD.GetFieldName(sAssetTypeFN) + "=@sAssetType";
sSQL += " , " + LibraryMOD.GetFieldName(FirstViewDateFN) + "=@FirstViewDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastEngagedCompletedDateFN) + "=@LastEngagedCompletedDate";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(SerialNoFN)+"=@SerialNo";
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
sSQL +=LibraryMOD.GetFieldName(sEmpEmailFN);
sSQL += " , " + LibraryMOD.GetFieldName(sEmpNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(iCourseIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(sCourseNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(sEngagmentTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(iEngagmentValueFN);
sSQL += " , " + LibraryMOD.GetFieldName(sAssetTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(FirstViewDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastEngagedCompletedDateFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @sEmpEmail";
sSQL += " ,@sEmpName";
sSQL += " ,@iCourseID";
sSQL += " ,@sCourseName";
sSQL += " ,@sEngagmentType";
sSQL += " ,@iEngagmentValue";
sSQL += " ,@sAssetType";
sSQL += " ,@FirstViewDate";
sSQL += " ,@LastEngagedCompletedDate";
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
sSQL += LibraryMOD.GetFieldName(SerialNoFN)+"=@SerialNo";
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
public List< EmployeeAllLinkedInCourses> GetEmployeeAllLinkedInCourses(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the EmployeeAllLinkedInCourses
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
List<EmployeeAllLinkedInCourses> results = new List<EmployeeAllLinkedInCourses>();
try
{
//Default Value
EmployeeAllLinkedInCourses myEmployeeAllLinkedInCourses = new EmployeeAllLinkedInCourses();
if (isDeafaultIncluded)
{
//Change the code here
myEmployeeAllLinkedInCourses.SerialNo = 0;
//myEmployeeAllLinkedInCourses. = "Select EmployeeAllLinkedInCourses ...";
results.Add(myEmployeeAllLinkedInCourses);
}
while (reader.Read())
{
myEmployeeAllLinkedInCourses = new EmployeeAllLinkedInCourses();
if (reader[LibraryMOD.GetFieldName(SerialNoFN)].Equals(DBNull.Value))
{
myEmployeeAllLinkedInCourses.SerialNo = 0;
}
else
{
myEmployeeAllLinkedInCourses.SerialNo = int.Parse(reader[LibraryMOD.GetFieldName( SerialNoFN) ].ToString());
}
myEmployeeAllLinkedInCourses.sEmpEmail =reader[LibraryMOD.GetFieldName( sEmpEmailFN) ].ToString();
myEmployeeAllLinkedInCourses.sEmpName =reader[LibraryMOD.GetFieldName( sEmpNameFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(iCourseIDFN)].Equals(DBNull.Value))
{
myEmployeeAllLinkedInCourses.iCourseID = 0;
}
else
{
myEmployeeAllLinkedInCourses.iCourseID = int.Parse(reader[LibraryMOD.GetFieldName( iCourseIDFN) ].ToString());
}
myEmployeeAllLinkedInCourses.sCourseName =reader[LibraryMOD.GetFieldName( sCourseNameFN) ].ToString();
myEmployeeAllLinkedInCourses.sEngagmentType =reader[LibraryMOD.GetFieldName( sEngagmentTypeFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(iEngagmentValueFN)].Equals(DBNull.Value))
{
myEmployeeAllLinkedInCourses.iEngagmentValue = 0;
}
else
{
myEmployeeAllLinkedInCourses.iEngagmentValue = int.Parse(reader[LibraryMOD.GetFieldName( iEngagmentValueFN) ].ToString());
}
myEmployeeAllLinkedInCourses.sAssetType =reader[LibraryMOD.GetFieldName( sAssetTypeFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(FirstViewDateFN)].Equals(DBNull.Value))
{
myEmployeeAllLinkedInCourses.FirstViewDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( FirstViewDateFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastEngagedCompletedDateFN)].Equals(DBNull.Value))
{
myEmployeeAllLinkedInCourses.LastEngagedCompletedDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastEngagedCompletedDateFN) ].ToString());
}
 results.Add(myEmployeeAllLinkedInCourses);
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
public List< EmployeeAllLinkedInCourses > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<EmployeeAllLinkedInCourses> results = new List<EmployeeAllLinkedInCourses>();
try
{
//Default Value
EmployeeAllLinkedInCourses myEmployeeAllLinkedInCourses= new EmployeeAllLinkedInCourses();
if (isDeafaultIncluded)
 {
//Change the code here
 myEmployeeAllLinkedInCourses.SerialNo = -1;
 myEmployeeAllLinkedInCourses.sEmpEmail = "Select EmployeeAllLinkedInCourses" ;
results.Add(myEmployeeAllLinkedInCourses);
 }
while (reader.Read())
{
myEmployeeAllLinkedInCourses = new EmployeeAllLinkedInCourses();
if (reader[LibraryMOD.GetFieldName(SerialNoFN)].Equals(DBNull.Value))
{
myEmployeeAllLinkedInCourses.SerialNo = 0;
}
else
{
myEmployeeAllLinkedInCourses.SerialNo = int.Parse(reader[LibraryMOD.GetFieldName( SerialNoFN) ].ToString());
}
myEmployeeAllLinkedInCourses.sEmpEmail =reader[LibraryMOD.GetFieldName( sEmpEmailFN) ].ToString();
myEmployeeAllLinkedInCourses.sEmpName =reader[LibraryMOD.GetFieldName( sEmpNameFN) ].ToString();
 results.Add(myEmployeeAllLinkedInCourses);
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
public int UpdateEmployeeAllLinkedInCourses(InitializeModule.EnumCampus Campus, int iMode,int SerialNo,string sEmpEmail,string sEmpName,int iCourseID,string sCourseName,string sEngagmentType,int iEngagmentValue,string sAssetType,DateTime FirstViewDate,DateTime LastEngagedCompletedDate)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EmployeeAllLinkedInCourses theEmployeeAllLinkedInCourses = new EmployeeAllLinkedInCourses();
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
Cmd.Parameters.Add(new SqlParameter("@SerialNo",SerialNo));
Cmd.Parameters.Add(new SqlParameter("@sEmpEmail",sEmpEmail));
Cmd.Parameters.Add(new SqlParameter("@sEmpName",sEmpName));
Cmd.Parameters.Add(new SqlParameter("@iCourseID",iCourseID));
Cmd.Parameters.Add(new SqlParameter("@sCourseName",sCourseName));
Cmd.Parameters.Add(new SqlParameter("@sEngagmentType",sEngagmentType));
Cmd.Parameters.Add(new SqlParameter("@iEngagmentValue",iEngagmentValue));
Cmd.Parameters.Add(new SqlParameter("@sAssetType",sAssetType));
Cmd.Parameters.Add(new SqlParameter("@FirstViewDate",FirstViewDate));
Cmd.Parameters.Add(new SqlParameter("@LastEngagedCompletedDate",LastEngagedCompletedDate));
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
public int DeleteEmployeeAllLinkedInCourses(InitializeModule.EnumCampus Campus,string SerialNo)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo ));
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
DataTable dt = new DataTable("EmployeeAllLinkedInCourses");
DataView dv = new DataView();
List<EmployeeAllLinkedInCourses> myEmployeeAllLinkedInCoursess = new List<EmployeeAllLinkedInCourses>();
try
{
myEmployeeAllLinkedInCoursess = GetEmployeeAllLinkedInCourses(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("SerialNo", Type.GetType("int identity"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myEmployeeAllLinkedInCoursess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myEmployeeAllLinkedInCoursess[i].SerialNo;
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
myEmployeeAllLinkedInCoursess.Clear();
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
sSQL += SerialNoFN;
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
public class EmployeeAllLinkedInCoursesCls : EmployeeAllLinkedInCoursesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daEmployeeAllLinkedInCourses;
private DataSet m_dsEmployeeAllLinkedInCourses;
public DataRow EmployeeAllLinkedInCoursesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsEmployeeAllLinkedInCourses
{
get { return m_dsEmployeeAllLinkedInCourses ; }
set { m_dsEmployeeAllLinkedInCourses = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EmployeeAllLinkedInCoursesCls()
{
try
{
dsEmployeeAllLinkedInCourses= new DataSet();

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
public virtual SqlDataAdapter GetEmployeeAllLinkedInCoursesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daEmployeeAllLinkedInCourses = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daEmployeeAllLinkedInCourses);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeAllLinkedInCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeAllLinkedInCourses;
}
public virtual SqlDataAdapter GetEmployeeAllLinkedInCoursesDataAdapter(SqlConnection con)  
{
try
{
daEmployeeAllLinkedInCourses = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeAllLinkedInCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdEmployeeAllLinkedInCourses;
cmdEmployeeAllLinkedInCourses = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@SerialNo", SqlDbType.Int, 4, "SerialNo" );
daEmployeeAllLinkedInCourses.SelectCommand = cmdEmployeeAllLinkedInCourses;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdEmployeeAllLinkedInCourses = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdEmployeeAllLinkedInCourses.Parameters.Add("@SerialNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(SerialNoFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sEmpEmail", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(sEmpEmailFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sEmpName", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(sEmpNameFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@iCourseID", SqlDbType.Int,4, LibraryMOD.GetFieldName(iCourseIDFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sCourseName", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(sCourseNameFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sEngagmentType", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(sEngagmentTypeFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@iEngagmentValue", SqlDbType.Int,4, LibraryMOD.GetFieldName(iEngagmentValueFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sAssetType", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(sAssetTypeFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@FirstViewDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(FirstViewDateFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@LastEngagedCompletedDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastEngagedCompletedDateFN));


Parmeter = cmdEmployeeAllLinkedInCourses.Parameters.Add("@SerialNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SerialNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daEmployeeAllLinkedInCourses.UpdateCommand = cmdEmployeeAllLinkedInCourses;
daEmployeeAllLinkedInCourses.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdEmployeeAllLinkedInCourses = new SqlCommand(GetInsertCommand(), con);
cmdEmployeeAllLinkedInCourses.Parameters.Add("@SerialNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(SerialNoFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sEmpEmail", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(sEmpEmailFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sEmpName", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(sEmpNameFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@iCourseID", SqlDbType.Int,4, LibraryMOD.GetFieldName(iCourseIDFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sCourseName", SqlDbType.NVarChar,500, LibraryMOD.GetFieldName(sCourseNameFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sEngagmentType", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(sEngagmentTypeFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@iEngagmentValue", SqlDbType.Int,4, LibraryMOD.GetFieldName(iEngagmentValueFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@sAssetType", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(sAssetTypeFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@FirstViewDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(FirstViewDateFN));
cmdEmployeeAllLinkedInCourses.Parameters.Add("@LastEngagedCompletedDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastEngagedCompletedDateFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daEmployeeAllLinkedInCourses.InsertCommand =cmdEmployeeAllLinkedInCourses;
daEmployeeAllLinkedInCourses.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdEmployeeAllLinkedInCourses = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdEmployeeAllLinkedInCourses.Parameters.Add("@SerialNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SerialNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daEmployeeAllLinkedInCourses.DeleteCommand =cmdEmployeeAllLinkedInCourses;
daEmployeeAllLinkedInCourses.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daEmployeeAllLinkedInCourses.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeAllLinkedInCourses;
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
dr = dsEmployeeAllLinkedInCourses.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(SerialNoFN)]=SerialNo;
dr[LibraryMOD.GetFieldName(sEmpEmailFN)]=sEmpEmail;
dr[LibraryMOD.GetFieldName(sEmpNameFN)]=sEmpName;
dr[LibraryMOD.GetFieldName(iCourseIDFN)]=iCourseID;
dr[LibraryMOD.GetFieldName(sCourseNameFN)]=sCourseName;
dr[LibraryMOD.GetFieldName(sEngagmentTypeFN)]=sEngagmentType;
dr[LibraryMOD.GetFieldName(iEngagmentValueFN)]=iEngagmentValue;
dr[LibraryMOD.GetFieldName(sAssetTypeFN)]=sAssetType;
dr[LibraryMOD.GetFieldName(FirstViewDateFN)]=FirstViewDate;
dr[LibraryMOD.GetFieldName(LastEngagedCompletedDateFN)]=LastEngagedCompletedDate;
dsEmployeeAllLinkedInCourses.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsEmployeeAllLinkedInCourses.Tables[TableName].Select(LibraryMOD.GetFieldName(SerialNoFN)  + "=" + SerialNo);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(SerialNoFN)]=SerialNo;
drAry[0][LibraryMOD.GetFieldName(sEmpEmailFN)]=sEmpEmail;
drAry[0][LibraryMOD.GetFieldName(sEmpNameFN)]=sEmpName;
drAry[0][LibraryMOD.GetFieldName(iCourseIDFN)]=iCourseID;
drAry[0][LibraryMOD.GetFieldName(sCourseNameFN)]=sCourseName;
drAry[0][LibraryMOD.GetFieldName(sEngagmentTypeFN)]=sEngagmentType;
drAry[0][LibraryMOD.GetFieldName(iEngagmentValueFN)]=iEngagmentValue;
drAry[0][LibraryMOD.GetFieldName(sAssetTypeFN)]=sAssetType;
drAry[0][LibraryMOD.GetFieldName(FirstViewDateFN)]=FirstViewDate;
drAry[0][LibraryMOD.GetFieldName(LastEngagedCompletedDateFN)]=LastEngagedCompletedDate;
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
public int CommitEmployeeAllLinkedInCourses()  
{
//CommitEmployeeAllLinkedInCourses= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daEmployeeAllLinkedInCourses.Update(dsEmployeeAllLinkedInCourses, TableName);
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
FindInMultiPKey(SerialNo);
if (( EmployeeAllLinkedInCoursesDataRow != null)) 
{
EmployeeAllLinkedInCoursesDataRow.Delete();
CommitEmployeeAllLinkedInCourses();
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
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(SerialNoFN)]== System.DBNull.Value)
{
  SerialNo=0;
}
else
{
  SerialNo = (int)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(SerialNoFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sEmpEmailFN)]== System.DBNull.Value)
{
  sEmpEmail="";
}
else
{
  sEmpEmail = (string)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sEmpEmailFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sEmpNameFN)]== System.DBNull.Value)
{
  sEmpName="";
}
else
{
  sEmpName = (string)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sEmpNameFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(iCourseIDFN)]== System.DBNull.Value)
{
  iCourseID=0;
}
else
{
  iCourseID = (int)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(iCourseIDFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sCourseNameFN)]== System.DBNull.Value)
{
  sCourseName="";
}
else
{
  sCourseName = (string)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sCourseNameFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sEngagmentTypeFN)]== System.DBNull.Value)
{
  sEngagmentType="";
}
else
{
  sEngagmentType = (string)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sEngagmentTypeFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(iEngagmentValueFN)]== System.DBNull.Value)
{
  iEngagmentValue=0;
}
else
{
  iEngagmentValue = (int)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(iEngagmentValueFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sAssetTypeFN)]== System.DBNull.Value)
{
  sAssetType="";
}
else
{
  sAssetType = (string)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(sAssetTypeFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(FirstViewDateFN)]== System.DBNull.Value)
{
}
else
{
  FirstViewDate = (DateTime)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(FirstViewDateFN)];
}
if (EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(LastEngagedCompletedDateFN)]== System.DBNull.Value)
{
}
else
{
  LastEngagedCompletedDate = (DateTime)EmployeeAllLinkedInCoursesDataRow[LibraryMOD.GetFieldName(LastEngagedCompletedDateFN)];
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
public int FindInMultiPKey(int PKSerialNo) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKSerialNo;
EmployeeAllLinkedInCoursesDataRow = dsEmployeeAllLinkedInCourses.Tables[TableName].Rows.Find(findTheseVals);
if  ((EmployeeAllLinkedInCoursesDataRow !=null)) 
{
lngCurRow = dsEmployeeAllLinkedInCourses.Tables[TableName].Rows.IndexOf(EmployeeAllLinkedInCoursesDataRow);
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
  lngCurRow = dsEmployeeAllLinkedInCourses.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsEmployeeAllLinkedInCourses.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsEmployeeAllLinkedInCourses.Tables[TableName].Rows.Count > 0) 
{
  EmployeeAllLinkedInCoursesDataRow = dsEmployeeAllLinkedInCourses.Tables[TableName].Rows[lngCurRow];
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
daEmployeeAllLinkedInCourses.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeAllLinkedInCourses.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daEmployeeAllLinkedInCourses.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeAllLinkedInCourses.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
