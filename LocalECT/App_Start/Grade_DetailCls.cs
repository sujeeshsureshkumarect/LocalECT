using System;
using System.Data;
using System.Configuration;
////using System.Linq;
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
public class Grade_Detail
{
//Creation Date: 27/06/2010 8:14 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private int m_byteShift; 
private string m_strCourse; 
private int m_byteClass; 
private string m_lngStudentNumber; 
private int m_byteGradeType; 
private double m_curGrade; 
private string m_strGrade; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
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
public string lngStudentNumber
{
get { return  m_lngStudentNumber; }
set {m_lngStudentNumber  = value ; }
}
public int byteGradeType
{
get { return  m_byteGradeType; }
set {m_byteGradeType  = value ; }
}
public double curGrade
{
get { return  m_curGrade; }
set {m_curGrade  = value ; }
}
public string strGrade
{
get { return  m_strGrade; }
set {m_strGrade  = value ; }
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
public Grade_Detail()
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
public class Grade_DetailDAL : Grade_Detail
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_byteShiftFN ;
private string m_strCourseFN ;
private string m_byteClassFN ;
private string m_lngStudentNumberFN ;
private string m_byteGradeTypeFN ;
private string m_curGradeFN ;
private string m_strGradeFN ;
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
public string lngStudentNumberFN 
{
get { return  m_lngStudentNumberFN; }
set {m_lngStudentNumberFN  = value ; }
}
public string byteGradeTypeFN 
{
get { return  m_byteGradeTypeFN; }
set {m_byteGradeTypeFN  = value ; }
}
public string curGradeFN 
{
get { return  m_curGradeFN; }
set {m_curGradeFN  = value ; }
}
public string strGradeFN 
{
get { return  m_strGradeFN; }
set {m_strGradeFN  = value ; }
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
public Grade_DetailDAL()
{
try
{
this.TableName = "Reg_Grade_Detail";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.byteShiftFN = m_TableName + ".byteShift";
this.strCourseFN = m_TableName + ".strCourse";
this.byteClassFN = m_TableName + ".byteClass";
this.lngStudentNumberFN = m_TableName + ".lngStudentNumber";
this.byteGradeTypeFN = m_TableName + ".byteGradeType";
this.curGradeFN = m_TableName + ".curGrade";
this.strGradeFN = m_TableName + ".strGrade";
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
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + byteGradeTypeFN;
sSQL += " , " + curGradeFN;
sSQL += " , " + strGradeFN;
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
public string  GetListSQL() 
    {
        string sSQL  = "";
        try
        {
        sSQL = "SELECT ";
        sSQL +=intStudyYearFN;
        sSQL += " , " + byteSemesterFN;
        sSQL += " , " + byteShiftFN;
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
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += intStudyYearFN;
        sSQL += " , " + byteSemesterFN;
        sSQL += " , " + byteShiftFN;
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
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + byteGradeTypeFN;
sSQL += " , " + curGradeFN;
sSQL += " , " + strGradeFN;
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
//sSQL += LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
//sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
//sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
//sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
//sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN) + "=@byteClass";
//sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
//sSQL +=  LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";
sSQL +=  LibraryMOD.GetFieldName(curGradeFN) + "=@curGrade";
sSQL += " , " + LibraryMOD.GetFieldName(strGradeFN) + "=@strGrade";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intStudyYearFN)+"=@intStudyYear";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteSemesterFN)+"=@byteSemester";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " + LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " + LibraryMOD.GetFieldName(lngStudentNumberFN)+"=@lngStudentNumber";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";

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
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteGradeTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(curGradeFN);
//sSQL += " , " + LibraryMOD.GetFieldName(strGradeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intStudyYear";
sSQL += " ,@byteSemester";
sSQL += " ,@byteShift";
sSQL += " ,@strCourse";
sSQL += " ,@byteClass";
sSQL += " ,@lngStudentNumber";
sSQL += " ,@byteGradeType";
sSQL += " ,@curGrade";
//sSQL += " ,@strGrade";
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
sSQL += LibraryMOD.GetFieldName(intStudyYearFN)+"=@intStudyYear";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteSemesterFN)+"=@byteSemester";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " +  LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " +  LibraryMOD.GetFieldName(lngStudentNumberFN)+"=@lngStudentNumber";
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
public List< Grade_Detail> GetGrade_Detail(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Grade_Detail
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
List<Grade_Detail> results = new List<Grade_Detail>();
try
{
//Default Value
Grade_Detail myGrade_Detail = new Grade_Detail();
if (isDeafaultIncluded)
{
//Change the code here
myGrade_Detail.intStudyYear = 0;
myGrade_Detail.byteSemester = 0;

results.Add(myGrade_Detail);
}
while (reader.Read())
{
myGrade_Detail = new Grade_Detail();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myGrade_Detail.intStudyYear = 0;
}
else
{
myGrade_Detail.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myGrade_Detail.byteSemester = 0;
}
else
{
myGrade_Detail.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myGrade_Detail.byteShift = 0;
}
else
{
myGrade_Detail.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
myGrade_Detail.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteClassFN)].Equals(DBNull.Value))
{
myGrade_Detail.byteClass = 0;
}
else
{
myGrade_Detail.byteClass = int.Parse(reader[LibraryMOD.GetFieldName( byteClassFN) ].ToString());
}
myGrade_Detail.lngStudentNumber =reader[LibraryMOD.GetFieldName( lngStudentNumberFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteGradeTypeFN)].Equals(DBNull.Value))
{
myGrade_Detail.byteGradeType = 0;
}
else
{
myGrade_Detail.byteGradeType = int.Parse(reader[LibraryMOD.GetFieldName( byteGradeTypeFN) ].ToString());
}
myGrade_Detail.strGrade =reader[LibraryMOD.GetFieldName( strGradeFN) ].ToString();
myGrade_Detail.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myGrade_Detail.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myGrade_Detail.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myGrade_Detail.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myGrade_Detail.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myGrade_Detail.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myGrade_Detail);
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
public List< Grade_Detail > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Grade_Detail> results = new List<Grade_Detail>();
try
{
//Default Value
Grade_Detail myGrade_Detail= new Grade_Detail();
if (isDeafaultIncluded) 
 {
//Change the code here
 myGrade_Detail.intStudyYear = -1;
 myGrade_Detail.byteSemester = -1;
 results.Add(myGrade_Detail);
 }
while (reader.Read())
{
myGrade_Detail = new Grade_Detail();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myGrade_Detail.intStudyYear = 0;
}
else
{
myGrade_Detail.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myGrade_Detail.byteSemester = 0;
}
else
{
myGrade_Detail.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myGrade_Detail.byteShift = 0;
}
else
{
myGrade_Detail.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
 results.Add(myGrade_Detail);
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

public int UpdateGrade_Detail(InitializeModule.EnumCampus Campus, int iMode,int intStudyYear,int byteSemester,int byteShift,string strCourse,int byteClass,string lngStudentNumber,int byteGradeType,double curGrade,string strGrade,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Grade_Detail theGrade_Detail = new Grade_Detail();
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
Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@byteShift",byteShift));
Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
Cmd.Parameters.Add(new SqlParameter("@byteClass",byteClass));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));
Cmd.Parameters.Add(new SqlParameter("@byteGradeType",byteGradeType));

Cmd.Parameters.Add(new SqlParameter("@curGrade",curGrade));
Cmd.Parameters.Add(new SqlParameter("@strGrade",strGrade));
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
public int DeleteGrade_Detail(InitializeModule.EnumCampus Campus,string intStudyYear,string byteSemester,string byteShift,string strCourse,string byteClass,string lngStudentNumber)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intStudyYear", intStudyYear ));
Cmd.Parameters.Add(new SqlParameter("@byteSemester", byteSemester ));
Cmd.Parameters.Add(new SqlParameter("@byteShift", byteShift ));
Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse ));
Cmd.Parameters.Add(new SqlParameter("@byteClass", byteClass ));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber", lngStudentNumber ));
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
DataTable dt = new DataTable("Grade_Detail");
DataView dv = new DataView();
List<Grade_Detail> myGrade_Details = new List<Grade_Detail>();
try
{
myGrade_Details = GetGrade_Detail(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("byteShift", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));
//dt.Constraints.Add(new UniqueConstraint(col4));
//dt.Constraints.Add(new UniqueConstraint(col5));
//dt.Constraints.Add(new UniqueConstraint(col6));

DataRow dr;
for (int i = 0; i < myGrade_Details.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myGrade_Details[i].intStudyYear;
  dr[2] = myGrade_Details[i].byteSemester;
  dr[3] = myGrade_Details[i].byteShift;
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
myGrade_Details.Clear();
}
 return dv;
}
public int IsGradeTypeExist(int iCampus, string sStudentID, int iyear, int isem, string sCourse, int iSession, int iClass,int iGradeType)
{
    String sSQL;
    int isExist = -1;

    Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += curGradeFN ;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + lngStudentNumberFN + "='" + sStudentID + "'";
        sSQL += "  AND " + strCourseFN + "='" + sCourse + "'";
        sSQL += "  AND " + intStudyYearFN + "=" + iyear;
        sSQL += "  AND " + byteSemesterFN + "=" + isem;
        sSQL += "  AND " + byteShiftFN + "=" + iSession;
        sSQL += "  AND " + byteClassFN + "=" + iClass;
        sSQL += "  AND " + byteGradeTypeFN + "=" + iGradeType;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            isExist = Convert.ToByte( Convert.ToDouble ("0" + datReader[0].ToString() ));
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
sSQL += intStudyYearFN;
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
public class Grade_DetailCls : Grade_DetailDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daGrade_Detail;
private DataSet m_dsGrade_Detail;
public DataRow Grade_DetailDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsGrade_Detail
{
get { return m_dsGrade_Detail ; }
set { m_dsGrade_Detail = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Grade_DetailCls()
{
try
{
dsGrade_Detail= new DataSet();

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
public virtual SqlDataAdapter GetGrade_DetailDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daGrade_Detail = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daGrade_Detail);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daGrade_Detail.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daGrade_Detail;
}
public virtual SqlDataAdapter GetGrade_DetailDataAdapter(SqlConnection con)  
{
try
{
daGrade_Detail = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daGrade_Detail.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdGrade_Detail;
cmdGrade_Detail = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, "intStudyYear" );
//'cmdRolePermission.Parameters.Add("@byteSemester", SqlDbType.Int, 4, "byteSemester" );
//'cmdRolePermission.Parameters.Add("@byteShift", SqlDbType.Int, 4, "byteShift" );
//'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
//'cmdRolePermission.Parameters.Add("@byteClass", SqlDbType.Int, 4, "byteClass" );
//'cmdRolePermission.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, "lngStudentNumber" );
daGrade_Detail.SelectCommand = cmdGrade_Detail;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdGrade_Detail = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below

    cmdGrade_Detail.Parameters.Add("@byteGradeType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGradeTypeFN));
cmdGrade_Detail.Parameters.Add("@curGrade", SqlDbType.Money,21, LibraryMOD.GetFieldName(curGradeFN));
cmdGrade_Detail.Parameters.Add("@strGrade", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strGradeFN));
cmdGrade_Detail.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdGrade_Detail.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdGrade_Detail.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdGrade_Detail.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdGrade_Detail.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdGrade_Detail.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdGrade_Detail.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngStudentNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daGrade_Detail.UpdateCommand = cmdGrade_Detail;
daGrade_Detail.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdGrade_Detail = new SqlCommand(GetInsertCommand(), con);
cmdGrade_Detail.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdGrade_Detail.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdGrade_Detail.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdGrade_Detail.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdGrade_Detail.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdGrade_Detail.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdGrade_Detail.Parameters.Add("@byteGradeType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGradeTypeFN));
cmdGrade_Detail.Parameters.Add("@curGrade", SqlDbType.Money,21, LibraryMOD.GetFieldName(curGradeFN));
cmdGrade_Detail.Parameters.Add("@strGrade", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strGradeFN));
cmdGrade_Detail.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdGrade_Detail.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdGrade_Detail.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdGrade_Detail.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdGrade_Detail.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdGrade_Detail.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daGrade_Detail.InsertCommand =cmdGrade_Detail;
daGrade_Detail.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdGrade_Detail = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdGrade_Detail.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdGrade_Detail.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngStudentNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daGrade_Detail.DeleteCommand =cmdGrade_Detail;
daGrade_Detail.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daGrade_Detail.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daGrade_Detail;
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
dr = dsGrade_Detail.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
dr[LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
dr[LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
dr[LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
dr[LibraryMOD.GetFieldName(byteGradeTypeFN)]=byteGradeType;
dr[LibraryMOD.GetFieldName(curGradeFN)]=curGrade;
dr[LibraryMOD.GetFieldName(strGradeFN)]=strGrade;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsGrade_Detail.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsGrade_Detail.Tables[TableName].Select(LibraryMOD.GetFieldName(intStudyYearFN)  + "=" + intStudyYear  + " AND " + LibraryMOD.GetFieldName(byteSemesterFN) + "=" + byteSemester  + " AND " + LibraryMOD.GetFieldName(byteShiftFN) + "=" + byteShift  + " AND " + LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse  + " AND " + LibraryMOD.GetFieldName(byteClassFN) + "=" + byteClass  + " AND " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=" + lngStudentNumber);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
drAry[0][LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
drAry[0][LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
drAry[0][LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
drAry[0][LibraryMOD.GetFieldName(byteGradeTypeFN)]=byteGradeType;
drAry[0][LibraryMOD.GetFieldName(curGradeFN)]=curGrade;
drAry[0][LibraryMOD.GetFieldName(strGradeFN)]=strGrade;
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
public int CommitGrade_Detail()  
{
//CommitGrade_Detail= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daGrade_Detail.Update(dsGrade_Detail, TableName);
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
FindInMultiPKey(intStudyYear,byteSemester,byteShift,strCourse,byteClass,lngStudentNumber);
if (( Grade_DetailDataRow != null)) 
{
Grade_DetailDataRow.Delete();
CommitGrade_Detail();
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
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)Grade_DetailDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)Grade_DetailDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(byteShiftFN)]== System.DBNull.Value)
{
  byteShift=0;
}
else
{
  byteShift = (int)Grade_DetailDataRow[LibraryMOD.GetFieldName(byteShiftFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(strCourseFN)]== System.DBNull.Value)
{
  strCourse="";
}
else
{
  strCourse = (string)Grade_DetailDataRow[LibraryMOD.GetFieldName(strCourseFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(byteClassFN)]== System.DBNull.Value)
{
  byteClass=0;
}
else
{
  byteClass = (int)Grade_DetailDataRow[LibraryMOD.GetFieldName(byteClassFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)]== System.DBNull.Value)
{
  lngStudentNumber="";
}
else
{
  lngStudentNumber = (string)Grade_DetailDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(byteGradeTypeFN)]== System.DBNull.Value)
{
  byteGradeType=0;
}
else
{
  byteGradeType = (int)Grade_DetailDataRow[LibraryMOD.GetFieldName(byteGradeTypeFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(curGradeFN)]== System.DBNull.Value)
{
}
else
{
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(strGradeFN)]== System.DBNull.Value)
{
  strGrade="";
}
else
{
  strGrade = (string)Grade_DetailDataRow[LibraryMOD.GetFieldName(strGradeFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Grade_DetailDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Grade_DetailDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Grade_DetailDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Grade_DetailDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Grade_DetailDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Grade_DetailDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Grade_DetailDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKintStudyYear,int PKbyteSemester,int PKbyteShift,string PKstrCourse,int PKbyteClass,string PKlngStudentNumber) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintStudyYear;
findTheseVals[1] = PKbyteSemester;
findTheseVals[2] = PKbyteShift;
findTheseVals[3] = PKstrCourse;
findTheseVals[4] = PKbyteClass;
findTheseVals[5] = PKlngStudentNumber;
Grade_DetailDataRow = dsGrade_Detail.Tables[TableName].Rows.Find(findTheseVals);
if  ((Grade_DetailDataRow !=null)) 
{
lngCurRow = dsGrade_Detail.Tables[TableName].Rows.IndexOf(Grade_DetailDataRow);
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
  lngCurRow = dsGrade_Detail.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsGrade_Detail.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsGrade_Detail.Tables[TableName].Rows.Count > 0) 
{
  Grade_DetailDataRow = dsGrade_Detail.Tables[TableName].Rows[lngCurRow];
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
daGrade_Detail.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daGrade_Detail.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daGrade_Detail.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daGrade_Detail.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
