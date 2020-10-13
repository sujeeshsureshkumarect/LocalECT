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
public class Available_Courses_Hours
{
//Creation Date: 05/04/2010 9:55:00 AM
//Programmer Name : Ihab Awad
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private int m_byteShift; 
private string m_strCourse; 
private int m_byteClass; 
private double m_curDay1; 
private double m_curDay2; 
private double m_curDay3; 
private double m_curDay4; 
private double m_curDay5; 
private double m_curDay6; 
private double m_curDay7; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intStudyYear
{
get { return  m_intStudyYear; }
set {m_intStudyYear  = value ; }
}
public int byteSemester
{
get { return  m_byteSemester; }
set {m_byteSemester  = value ; }
}
public int byteShift
{
get { return  m_byteShift; }
set {m_byteShift  = value ; }
}
public string strCourse
{
get { return  m_strCourse; }
set {m_strCourse  = value ; }
}
public int byteClass
{
get { return  m_byteClass; }
set {m_byteClass  = value ; }
}
public double curDay1
{
get { return  m_curDay1; }
set {m_curDay1  = value ; }
}
public double curDay2
{
get { return  m_curDay2; }
set {m_curDay2  = value ; }
}
public double curDay3
{
get { return  m_curDay3; }
set {m_curDay3  = value ; }
}
public double curDay4
{
get { return  m_curDay4; }
set {m_curDay4  = value ; }
}
public double curDay5
{
get { return  m_curDay5; }
set {m_curDay5  = value ; }
}
public double curDay6
{
get { return  m_curDay6; }
set {m_curDay6  = value ; }
}
public double curDay7
{
get { return  m_curDay7; }
set {m_curDay7  = value ; }
}
#endregion
//'-----------------------------------------------------
public Available_Courses_Hours()
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
public class Available_Courses_HoursDAL : Available_Courses_Hours
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_byteShiftFN ;
private string m_strCourseFN ;
private string m_byteClassFN ;
private string m_curDay1FN ;
private string m_curDay2FN ;
private string m_curDay3FN ;
private string m_curDay4FN ;
private string m_curDay5FN ;
private string m_curDay6FN ;
private string m_curDay7FN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string intStudyYearFN 
{
get { return  m_intStudyYearFN; }
set {m_intStudyYearFN  = value ; }
}
public string byteSemesterFN 
{
get { return  m_byteSemesterFN; }
set {m_byteSemesterFN  = value ; }
}
public string byteShiftFN 
{
get { return  m_byteShiftFN; }
set {m_byteShiftFN  = value ; }
}
public string strCourseFN 
{
get { return  m_strCourseFN; }
set {m_strCourseFN  = value ; }
}
public string byteClassFN 
{
get { return  m_byteClassFN; }
set {m_byteClassFN  = value ; }
}
public string curDay1FN 
{
get { return  m_curDay1FN; }
set {m_curDay1FN  = value ; }
}
public string curDay2FN 
{
get { return  m_curDay2FN; }
set {m_curDay2FN  = value ; }
}
public string curDay3FN 
{
get { return  m_curDay3FN; }
set {m_curDay3FN  = value ; }
}
public string curDay4FN 
{
get { return  m_curDay4FN; }
set {m_curDay4FN  = value ; }
}
public string curDay5FN 
{
get { return  m_curDay5FN; }
set {m_curDay5FN  = value ; }
}
public string curDay6FN 
{
get { return  m_curDay6FN; }
set {m_curDay6FN  = value ; }
}
public string curDay7FN 
{
get { return  m_curDay7FN; }
set {m_curDay7FN  = value ; }
}
#endregion
//================End Properties ===================
public Available_Courses_HoursDAL()
{
try
{
this.TableName = "Reg_Available_Courses_Hours";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.byteShiftFN = m_TableName + ".byteShift";
this.strCourseFN = m_TableName + ".strCourse";
this.byteClassFN = m_TableName + ".byteClass";
this.curDay1FN = m_TableName + ".curDay1";
this.curDay2FN = m_TableName + ".curDay2";
this.curDay3FN = m_TableName + ".curDay3";
this.curDay4FN = m_TableName + ".curDay4";
this.curDay5FN = m_TableName + ".curDay5";
this.curDay6FN = m_TableName + ".curDay6";
this.curDay7FN = m_TableName + ".curDay7";
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
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + curDay1FN;
sSQL += " , " + curDay2FN;
sSQL += " , " + curDay3FN;
sSQL += " , " + curDay4FN;
sSQL += " , " + curDay5FN;
sSQL += " , " + curDay6FN;
sSQL += " , " + curDay7FN;
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
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + curDay1FN;
sSQL += " , " + curDay2FN;
sSQL += " , " + curDay3FN;
sSQL += " , " + curDay4FN;
sSQL += " , " + curDay5FN;
sSQL += " , " + curDay6FN;
sSQL += " , " + curDay7FN;
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
sSQL += LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN) + "=@byteClass";
sSQL += " , " + LibraryMOD.GetFieldName(curDay1FN) + "=@curDay1";
sSQL += " , " + LibraryMOD.GetFieldName(curDay2FN) + "=@curDay2";
sSQL += " , " + LibraryMOD.GetFieldName(curDay3FN) + "=@curDay3";
sSQL += " , " + LibraryMOD.GetFieldName(curDay4FN) + "=@curDay4";
sSQL += " , " + LibraryMOD.GetFieldName(curDay5FN) + "=@curDay5";
sSQL += " , " + LibraryMOD.GetFieldName(curDay6FN) + "=@curDay6";
sSQL += " , " + LibraryMOD.GetFieldName(curDay7FN) + "=@curDay7";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " + LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
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
sSQL +=LibraryMOD.GetFieldName(intStudyYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN);
sSQL += " , " + LibraryMOD.GetFieldName(curDay1FN);
sSQL += " , " + LibraryMOD.GetFieldName(curDay2FN);
sSQL += " , " + LibraryMOD.GetFieldName(curDay3FN);
sSQL += " , " + LibraryMOD.GetFieldName(curDay4FN);
sSQL += " , " + LibraryMOD.GetFieldName(curDay5FN);
sSQL += " , " + LibraryMOD.GetFieldName(curDay6FN);
sSQL += " , " + LibraryMOD.GetFieldName(curDay7FN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intStudyYear";
sSQL += " ,@byteSemester";
sSQL += " ,@byteShift";
sSQL += " ,@strCourse";
sSQL += " ,@byteClass";
sSQL += " ,@curDay1";
sSQL += " ,@curDay2";
sSQL += " ,@curDay3";
sSQL += " ,@curDay4";
sSQL += " ,@curDay5";
sSQL += " ,@curDay6";
sSQL += " ,@curDay7";
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
sSQL += LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " +  LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
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
public List< Available_Courses_Hours> GetAvailable_Courses_Hours(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Available_Courses_Hours
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
List<Available_Courses_Hours> results = new List<Available_Courses_Hours>();
try
{
//Default Value
Available_Courses_Hours myAvailable_Courses_Hours = new Available_Courses_Hours();
if (isDeafaultIncluded)
{
//Change the code here
myAvailable_Courses_Hours.byteShift = 0;
myAvailable_Courses_Hours.byteClass = 0;
myAvailable_Courses_Hours.strCourse = "Select Available_Courses_Hours ...";
results.Add(myAvailable_Courses_Hours);
}
while (reader.Read())
{
myAvailable_Courses_Hours = new Available_Courses_Hours();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myAvailable_Courses_Hours.intStudyYear = 0;
}
else
{
myAvailable_Courses_Hours.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myAvailable_Courses_Hours.byteSemester = 0;
}
else
{
myAvailable_Courses_Hours.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myAvailable_Courses_Hours.byteShift = 0;
}
else
{
myAvailable_Courses_Hours.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
myAvailable_Courses_Hours.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteClassFN)].Equals(DBNull.Value))
{
myAvailable_Courses_Hours.byteClass = 0;
}
else
{
myAvailable_Courses_Hours.byteClass = int.Parse(reader[LibraryMOD.GetFieldName( byteClassFN) ].ToString());
}
 results.Add(myAvailable_Courses_Hours);
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
public int UpdateAvailable_Courses_Hours(InitializeModule.EnumCampus Campus, int iMode,int intStudyYear,int byteSemester,int byteShift,string strCourse,int byteClass,double curDay1,double curDay2,double curDay3,double curDay4,double curDay5,double curDay6,double curDay7)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Available_Courses_Hours theAvailable_Courses_Hours = new Available_Courses_Hours();
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
Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@byteShift",byteShift));
Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
Cmd.Parameters.Add(new SqlParameter("@byteClass",byteClass));
Cmd.Parameters.Add(new SqlParameter("@curDay1",curDay1));
Cmd.Parameters.Add(new SqlParameter("@curDay2",curDay2));
Cmd.Parameters.Add(new SqlParameter("@curDay3",curDay3));
Cmd.Parameters.Add(new SqlParameter("@curDay4",curDay4));
Cmd.Parameters.Add(new SqlParameter("@curDay5",curDay5));
Cmd.Parameters.Add(new SqlParameter("@curDay6",curDay6));
Cmd.Parameters.Add(new SqlParameter("@curDay7",curDay7));
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
public int DeleteAvailable_Courses_Hours(InitializeModule.EnumCampus Campus,string byteShift,string strCourse,string byteClass)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@byteShift", byteShift ));
Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse ));
Cmd.Parameters.Add(new SqlParameter("@byteClass", byteClass ));
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
DataTable dt = new DataTable("Available_Courses_Hours");
DataView dv = new DataView();
List<Available_Courses_Hours> myAvailable_Courses_Hourss = new List<Available_Courses_Hours>();
try
{
myAvailable_Courses_Hourss = GetAvailable_Courses_Hours(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("byteShift", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));

DataRow dr;
for (int i = 0; i < myAvailable_Courses_Hourss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myAvailable_Courses_Hourss[i].intStudyYear;
  dr[2] = myAvailable_Courses_Hourss[i].byteSemester;
  dr[3] = myAvailable_Courses_Hourss[i].byteShift;
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
myAvailable_Courses_Hourss.Clear();
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
sSQL += byteShiftFN;
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
public class Available_Courses_HoursCls : Available_Courses_HoursDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daAvailable_Courses_Hours;
private DataSet m_dsAvailable_Courses_Hours;
public DataRow Available_Courses_HoursDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsAvailable_Courses_Hours
{
get { return m_dsAvailable_Courses_Hours ; }
set { m_dsAvailable_Courses_Hours = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Available_Courses_HoursCls()
{
try
{
dsAvailable_Courses_Hours= new DataSet();

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
public virtual SqlDataAdapter GetAvailable_Courses_HoursDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daAvailable_Courses_Hours = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daAvailable_Courses_Hours);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daAvailable_Courses_Hours.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAvailable_Courses_Hours;
}
public virtual SqlDataAdapter GetAvailable_Courses_HoursDataAdapter(SqlConnection con)  
{
try
{
daAvailable_Courses_Hours = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daAvailable_Courses_Hours.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdAvailable_Courses_Hours;
cmdAvailable_Courses_Hours = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@byteShift", SqlDbType.Int, 4, "byteShift" );
//'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
//'cmdRolePermission.Parameters.Add("@byteClass", SqlDbType.Int, 4, "byteClass" );
daAvailable_Courses_Hours.SelectCommand = cmdAvailable_Courses_Hours;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdAvailable_Courses_Hours = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdAvailable_Courses_Hours.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdAvailable_Courses_Hours.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdAvailable_Courses_Hours.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdAvailable_Courses_Hours.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdAvailable_Courses_Hours.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay1", SqlDbType.Decimal,21, LibraryMOD.GetFieldName(curDay1FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay2", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay2FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay3", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay3FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay4", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay4FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay5", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay5FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay6", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay6FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay7", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay7FN));


Parmeter = cmdAvailable_Courses_Hours.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdAvailable_Courses_Hours.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdAvailable_Courses_Hours.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daAvailable_Courses_Hours.UpdateCommand = cmdAvailable_Courses_Hours;
daAvailable_Courses_Hours.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdAvailable_Courses_Hours = new SqlCommand(GetInsertCommand(), con);
cmdAvailable_Courses_Hours.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdAvailable_Courses_Hours.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdAvailable_Courses_Hours.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdAvailable_Courses_Hours.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdAvailable_Courses_Hours.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay1", SqlDbType.Decimal,21, LibraryMOD.GetFieldName(curDay1FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay2", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay2FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay3", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay3FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay4", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay4FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay5", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay5FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay6", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay6FN));
cmdAvailable_Courses_Hours.Parameters.Add("@curDay7", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curDay7FN));
Parmeter.SourceVersion = DataRowVersion.Current;
daAvailable_Courses_Hours.InsertCommand =cmdAvailable_Courses_Hours;
daAvailable_Courses_Hours.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdAvailable_Courses_Hours = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdAvailable_Courses_Hours.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdAvailable_Courses_Hours.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdAvailable_Courses_Hours.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daAvailable_Courses_Hours.DeleteCommand =cmdAvailable_Courses_Hours;
daAvailable_Courses_Hours.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daAvailable_Courses_Hours.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAvailable_Courses_Hours;
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
dr = dsAvailable_Courses_Hours.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
dr[LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
dr[LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
dr[LibraryMOD.GetFieldName(curDay1FN)]=curDay1;
dr[LibraryMOD.GetFieldName(curDay2FN)]=curDay2;
dr[LibraryMOD.GetFieldName(curDay3FN)]=curDay3;
dr[LibraryMOD.GetFieldName(curDay4FN)]=curDay4;
dr[LibraryMOD.GetFieldName(curDay5FN)]=curDay5;
dr[LibraryMOD.GetFieldName(curDay6FN)]=curDay6;
dr[LibraryMOD.GetFieldName(curDay7FN)]=curDay7;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsAvailable_Courses_Hours.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsAvailable_Courses_Hours.Tables[TableName].Select(LibraryMOD.GetFieldName(byteShiftFN)  + "=" + byteShift  + " AND " + LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse  + " AND " + LibraryMOD.GetFieldName(byteClassFN) + "=" + byteClass);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
drAry[0][LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
drAry[0][LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
drAry[0][LibraryMOD.GetFieldName(curDay1FN)]=curDay1;
drAry[0][LibraryMOD.GetFieldName(curDay2FN)]=curDay2;
drAry[0][LibraryMOD.GetFieldName(curDay3FN)]=curDay3;
drAry[0][LibraryMOD.GetFieldName(curDay4FN)]=curDay4;
drAry[0][LibraryMOD.GetFieldName(curDay5FN)]=curDay5;
drAry[0][LibraryMOD.GetFieldName(curDay6FN)]=curDay6;
drAry[0][LibraryMOD.GetFieldName(curDay7FN)]=curDay7;
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
public int CommitAvailable_Courses_Hours()  
{
//CommitAvailable_Courses_Hours= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daAvailable_Courses_Hours.Update(dsAvailable_Courses_Hours, TableName);
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
FindInMultiPKey(byteShift,strCourse,byteClass);
if (( Available_Courses_HoursDataRow != null)) 
{
Available_Courses_HoursDataRow.Delete();
CommitAvailable_Courses_Hours();
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
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(byteShiftFN)]== System.DBNull.Value)
{
  byteShift=0;
}
else
{
  byteShift = (int)Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(byteShiftFN)];
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(strCourseFN)]== System.DBNull.Value)
{
  strCourse="";
}
else
{
  strCourse = (string)Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(strCourseFN)];
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(byteClassFN)]== System.DBNull.Value)
{
  byteClass=0;
}
else
{
  byteClass = (int)Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(byteClassFN)];
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(curDay1FN)]== System.DBNull.Value)
{
}
else
{
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(curDay2FN)]== System.DBNull.Value)
{
}
else
{
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(curDay3FN)]== System.DBNull.Value)
{
}
else
{
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(curDay4FN)]== System.DBNull.Value)
{
}
else
{
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(curDay5FN)]== System.DBNull.Value)
{
}
else
{
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(curDay6FN)]== System.DBNull.Value)
{
}
else
{
}
if (Available_Courses_HoursDataRow[LibraryMOD.GetFieldName(curDay7FN)]== System.DBNull.Value)
{
}
else
{
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
public int FindInMultiPKey(int PKbyteShift,string  PKstrCourse,int PKbyteClass) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKbyteShift;
findTheseVals[1] = PKstrCourse;
findTheseVals[2] = PKbyteClass;
Available_Courses_HoursDataRow = dsAvailable_Courses_Hours.Tables[TableName].Rows.Find(findTheseVals);
if  ((Available_Courses_HoursDataRow !=null)) 
{
lngCurRow = dsAvailable_Courses_Hours.Tables[TableName].Rows.IndexOf(Available_Courses_HoursDataRow);
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
  lngCurRow = dsAvailable_Courses_Hours.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsAvailable_Courses_Hours.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsAvailable_Courses_Hours.Tables[TableName].Rows.Count > 0) 
{
  Available_Courses_HoursDataRow = dsAvailable_Courses_Hours.Tables[TableName].Rows[lngCurRow];
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
daAvailable_Courses_Hours.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAvailable_Courses_Hours.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daAvailable_Courses_Hours.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAvailable_Courses_Hours.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
