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
public class Specialization_Courses
{
//Creation Date: 23/04/2012 03:33:04 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private string m_strCollege; 
private string m_strDegree; 
private string m_strSpecialization; 
private int m_byteCourseClass; 
private string m_strCourse; 
private string m_bCurrent; 
private int m_byteOrder; 
private int m_MajorCoursesOrder; 
private int m_intLink; 
private int m_intLevel; 
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
public string strDegree
{
get { return  m_strDegree; }
set {m_strDegree  = value ; }
}
public string strSpecialization
{
get { return  m_strSpecialization; }
set {m_strSpecialization  = value ; }
}
public int byteCourseClass
{
get { return  m_byteCourseClass; }
set {m_byteCourseClass  = value ; }
}
public string strCourse
{
get { return  m_strCourse; }
set {m_strCourse  = value ; }
}
public string bCurrent
{
get { return  m_bCurrent; }
set {m_bCurrent  = value ; }
}
public int byteOrder
{
get { return  m_byteOrder; }
set {m_byteOrder  = value ; }
}
public int MajorCoursesOrder
{
get { return  m_MajorCoursesOrder; }
set {m_MajorCoursesOrder  = value ; }
}
public int intLink
{
get { return  m_intLink; }
set {m_intLink  = value ; }
}
public int intLevel
{
get { return  m_intLevel; }
set {m_intLevel  = value ; }
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
public Specialization_Courses()
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
public class Specialization_CoursesDAL : Specialization_Courses
{
#region "Decleration"
private string m_TableName;
private string m_strCollegeFN ;
private string m_strDegreeFN ;
private string m_strSpecializationFN ;
private string m_byteCourseClassFN ;
private string m_strCourseFN ;
private string m_bCurrentFN ;
private string m_byteOrderFN ;
private string m_MajorCoursesOrderFN ;
private string m_intLinkFN ;
private string m_intLevelFN ;
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
public string strDegreeFN 
{
get { return  m_strDegreeFN; }
set {m_strDegreeFN  = value ; }
}
public string strSpecializationFN 
{
get { return  m_strSpecializationFN; }
set {m_strSpecializationFN  = value ; }
}
public string byteCourseClassFN 
{
get { return  m_byteCourseClassFN; }
set {m_byteCourseClassFN  = value ; }
}
public string strCourseFN 
{
get { return  m_strCourseFN; }
set {m_strCourseFN  = value ; }
}
public string bCurrentFN 
{
get { return  m_bCurrentFN; }
set {m_bCurrentFN  = value ; }
}
public string byteOrderFN 
{
get { return  m_byteOrderFN; }
set {m_byteOrderFN  = value ; }
}
public string MajorCoursesOrderFN 
{
get { return  m_MajorCoursesOrderFN; }
set {m_MajorCoursesOrderFN  = value ; }
}
public string intLinkFN 
{
get { return  m_intLinkFN; }
set {m_intLinkFN  = value ; }
}
public string intLevelFN 
{
get { return  m_intLevelFN; }
set {m_intLevelFN  = value ; }
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
public Specialization_CoursesDAL()
{
try
{
this.TableName = "Reg_Specialization_Courses";
this.strCollegeFN = m_TableName + ".strCollege";
this.strDegreeFN = m_TableName + ".strDegree";
this.strSpecializationFN = m_TableName + ".strSpecialization";
this.byteCourseClassFN = m_TableName + ".byteCourseClass";
this.strCourseFN = m_TableName + ".strCourse";
this.bCurrentFN = m_TableName + ".bCurrent";
this.byteOrderFN = m_TableName + ".byteOrder";
this.MajorCoursesOrderFN = m_TableName + ".MajorCoursesOrder";
this.intLinkFN = m_TableName + ".intLink";
this.intLevelFN = m_TableName + ".intLevel";
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
sSQL += " , " + strDegreeFN;
sSQL += " , " + strSpecializationFN;
sSQL += " , " + byteCourseClassFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + bCurrentFN;
sSQL += " , " + byteOrderFN;
sSQL += " , " + MajorCoursesOrderFN;
sSQL += " , " + intLinkFN;
sSQL += " , " + intLevelFN;
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
public string GetListSQL(string sWhere) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strSpecializationFN;
sSQL += "  FROM " + m_TableName;

sSQL += sWhere;
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
sSQL +=strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strSpecializationFN;
sSQL += " , " + byteCourseClassFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + bCurrentFN;
sSQL += " , " + byteOrderFN;
sSQL += " , " + MajorCoursesOrderFN;
sSQL += " , " + intLinkFN;
sSQL += " , " + intLevelFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
sSQL += " , " + LibraryMOD.GetFieldName(byteCourseClassFN) + "=@byteCourseClass";
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
sSQL += " , " + LibraryMOD.GetFieldName(bCurrentFN) + "=@bCurrent";
sSQL += " , " + LibraryMOD.GetFieldName(byteOrderFN) + "=@byteOrder";
sSQL += " , " + LibraryMOD.GetFieldName(MajorCoursesOrderFN) + "=@MajorCoursesOrder";
sSQL += " , " + LibraryMOD.GetFieldName(intLinkFN) + "=@intLink";
sSQL += " , " + LibraryMOD.GetFieldName(intLevelFN) + "=@intLevel";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(strCollegeFN)+"=@strCollege";
sSQL +=  " And " + LibraryMOD.GetFieldName(strDegreeFN)+"=@strDegree";
sSQL +=  " And " + LibraryMOD.GetFieldName(strSpecializationFN)+"=@strSpecialization";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteCourseClassFN)+"=@byteCourseClass";
sSQL +=  " And " + LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
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
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteCourseClassFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(bCurrentFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteOrderFN);
sSQL += " , " + LibraryMOD.GetFieldName(MajorCoursesOrderFN);
sSQL += " , " + LibraryMOD.GetFieldName(intLinkFN);
sSQL += " , " + LibraryMOD.GetFieldName(intLevelFN);
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
sSQL += " ,@strDegree";
sSQL += " ,@strSpecialization";
sSQL += " ,@byteCourseClass";
sSQL += " ,@strCourse";
sSQL += " ,@bCurrent";
sSQL += " ,@byteOrder";
sSQL += " ,@MajorCoursesOrder";
sSQL += " ,@intLink";
sSQL += " ,@intLevel";
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
sSQL +=  " And " +  LibraryMOD.GetFieldName(strDegreeFN)+"=@strDegree";
sSQL +=  " And " +  LibraryMOD.GetFieldName(strSpecializationFN)+"=@strSpecialization";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteCourseClassFN)+"=@byteCourseClass";
sSQL +=  " And " +  LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
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
public Boolean  IsCourseInMajorPlan(string sDegree,string sMajorID,string sCourse)
{
    String sSQL;
    Boolean  isExist = false;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males );
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += strCourseFN  ;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + strDegreeFN + "='" + sDegree + "'" ;
        sSQL += "  AND " + strSpecializationFN + "='" + sMajorID + "'";
        sSQL += "  AND " + strCourseFN + "='" + sCourse + "'";

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            isExist =true;
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

    return isExist ;
}

public List< Specialization_Courses> GetSpecialization_Courses(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Specialization_Courses
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
List<Specialization_Courses> results = new List<Specialization_Courses>();
try
{
//Default Value
Specialization_Courses mySpecialization_Courses = new Specialization_Courses();
if (isDeafaultIncluded)
{
//Change the code here
mySpecialization_Courses.strCollege = "";
mySpecialization_Courses.strDegree = "";
mySpecialization_Courses.strSpecialization = "";
mySpecialization_Courses.byteCourseClass = 0;
mySpecialization_Courses.strCourse = "";
mySpecialization_Courses.strCourse = "Select Specialization_Courses ...";
results.Add(mySpecialization_Courses);
}
while (reader.Read())
{
mySpecialization_Courses = new Specialization_Courses();
mySpecialization_Courses.strCollege =reader[LibraryMOD.GetFieldName( strCollegeFN) ].ToString();
mySpecialization_Courses.strDegree =reader[LibraryMOD.GetFieldName( strDegreeFN) ].ToString();
mySpecialization_Courses.strSpecialization =reader[LibraryMOD.GetFieldName( strSpecializationFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteCourseClassFN)].Equals(DBNull.Value))
{
mySpecialization_Courses.byteCourseClass = 0;
}
else
{
mySpecialization_Courses.byteCourseClass = int.Parse(reader[LibraryMOD.GetFieldName( byteCourseClassFN) ].ToString());
}
mySpecialization_Courses.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
mySpecialization_Courses.bCurrent =reader[LibraryMOD.GetFieldName( bCurrentFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteOrderFN)].Equals(DBNull.Value))
{
mySpecialization_Courses.byteOrder = 0;
}
else
{
mySpecialization_Courses.byteOrder = int.Parse(reader[LibraryMOD.GetFieldName( byteOrderFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(MajorCoursesOrderFN)].Equals(DBNull.Value))
{
mySpecialization_Courses.MajorCoursesOrder = 0;
}
else
{
mySpecialization_Courses.MajorCoursesOrder = int.Parse(reader[LibraryMOD.GetFieldName( MajorCoursesOrderFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intLinkFN)].Equals(DBNull.Value))
{
mySpecialization_Courses.intLink = 0;
}
else
{
mySpecialization_Courses.intLink = int.Parse(reader[LibraryMOD.GetFieldName( intLinkFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intLevelFN)].Equals(DBNull.Value))
{
mySpecialization_Courses.intLevel = 0;
}
else
{
mySpecialization_Courses.intLevel = int.Parse(reader[LibraryMOD.GetFieldName( intLevelFN) ].ToString());
}
mySpecialization_Courses.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
mySpecialization_Courses.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
mySpecialization_Courses.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
mySpecialization_Courses.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
mySpecialization_Courses.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
mySpecialization_Courses.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(mySpecialization_Courses);
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
public List< Specialization_Courses > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Specialization_Courses> results = new List<Specialization_Courses>();
try
{
//Default Value
Specialization_Courses mySpecialization_Courses= new Specialization_Courses();
if (isDeafaultIncluded)
 {
//Change the code here
 mySpecialization_Courses.strCollege = "";
 mySpecialization_Courses.strDegree = "Select Specialization_Courses" ;
results.Add(mySpecialization_Courses);
 }
while (reader.Read())
{
mySpecialization_Courses = new Specialization_Courses();
mySpecialization_Courses.strCollege =reader[LibraryMOD.GetFieldName( strCollegeFN) ].ToString();
mySpecialization_Courses.strDegree =reader[LibraryMOD.GetFieldName( strDegreeFN) ].ToString();
mySpecialization_Courses.strSpecialization =reader[LibraryMOD.GetFieldName( strSpecializationFN) ].ToString();
 results.Add(mySpecialization_Courses);
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
public int UpdateSpecialization_Courses(InitializeModule.EnumCampus Campus, int iMode,string strCollege,string strDegree,string strSpecialization,int byteCourseClass,string strCourse,string bCurrent,int byteOrder,int MajorCoursesOrder,int intLink,int intLevel,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Specialization_Courses theSpecialization_Courses = new Specialization_Courses();
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
Cmd.Parameters.Add(new SqlParameter("@strCollege",strCollege));
Cmd.Parameters.Add(new SqlParameter("@strDegree",strDegree));
Cmd.Parameters.Add(new SqlParameter("@strSpecialization",strSpecialization));
Cmd.Parameters.Add(new SqlParameter("@byteCourseClass",byteCourseClass));
Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
Cmd.Parameters.Add(new SqlParameter("@bCurrent",bCurrent));
Cmd.Parameters.Add(new SqlParameter("@byteOrder",byteOrder));
Cmd.Parameters.Add(new SqlParameter("@MajorCoursesOrder",MajorCoursesOrder));
Cmd.Parameters.Add(new SqlParameter("@intLink",intLink));
Cmd.Parameters.Add(new SqlParameter("@intLevel",intLevel));
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
public int DeleteSpecialization_Courses(InitializeModule.EnumCampus Campus,string strCollege,string strDegree,string strSpecialization,string byteCourseClass,string strCourse)
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
Cmd.Parameters.Add(new SqlParameter("@strDegree", strDegree ));
Cmd.Parameters.Add(new SqlParameter("@strSpecialization", strSpecialization ));
Cmd.Parameters.Add(new SqlParameter("@byteCourseClass", byteCourseClass ));
Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse ));
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
DataTable dt = new DataTable("Specialization_Courses");
DataView dv = new DataView();
List<Specialization_Courses> mySpecialization_Coursess = new List<Specialization_Courses>();
try
{
mySpecialization_Coursess = GetSpecialization_Courses(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("strCollege", Type.GetType("nvarchar"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("strDegree", Type.GetType("nvarchar"));
dt.Columns.Add(col1 );
DataColumn col2 = new DataColumn("strSpecialization", Type.GetType("nvarchar"));
dt.Columns.Add(col2);
DataColumn col3 = new DataColumn("byteCourseClass", Type.GetType("int"));
dt.Columns.Add(col3);
DataColumn col4 = new DataColumn("strCourse", Type.GetType("nvarchar"));
dt.Columns.Add(col4);
dt.Constraints.Add(new UniqueConstraint(col0));
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));
dt.Constraints.Add(new UniqueConstraint(col4));

DataRow dr;
for (int i = 0; i < mySpecialization_Coursess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = mySpecialization_Coursess[i].strCollege;
  dr[2] = mySpecialization_Coursess[i].strDegree;
  dr[3] = mySpecialization_Coursess[i].strSpecialization;
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
mySpecialization_Coursess.Clear();
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
public class Specialization_CoursesCls : Specialization_CoursesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daSpecialization_Courses;
    private DataSet m_dsSpecialization_Courses;
    public DataRow Specialization_CoursesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsSpecialization_Courses
    {
        get { return m_dsSpecialization_Courses; }
        set { m_dsSpecialization_Courses = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Specialization_CoursesCls()
    {
        try
        {
            dsSpecialization_Courses = new DataSet();

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
    public virtual SqlDataAdapter GetSpecialization_CoursesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daSpecialization_Courses = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSpecialization_Courses);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daSpecialization_Courses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSpecialization_Courses;
    }
    public virtual SqlDataAdapter GetSpecialization_CoursesDataAdapter(SqlConnection con)
    {
        try
        {
            daSpecialization_Courses = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daSpecialization_Courses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdSpecialization_Courses;
            cmdSpecialization_Courses = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@strCollege", SqlDbType.Int, 4, "strCollege" );
            //'cmdRolePermission.Parameters.Add("@strDegree", SqlDbType.Int, 4, "strDegree" );
            //'cmdRolePermission.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, "strSpecialization" );
            //'cmdRolePermission.Parameters.Add("@byteCourseClass", SqlDbType.Int, 4, "byteCourseClass" );
            //'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
            daSpecialization_Courses.SelectCommand = cmdSpecialization_Courses;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdSpecialization_Courses = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdSpecialization_Courses.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdSpecialization_Courses.Parameters.Add("@strDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strDegreeFN));
            cmdSpecialization_Courses.Parameters.Add("@strSpecialization", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strSpecializationFN));
            cmdSpecialization_Courses.Parameters.Add("@byteCourseClass", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteCourseClassFN));
            cmdSpecialization_Courses.Parameters.Add("@strCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strCourseFN));
            cmdSpecialization_Courses.Parameters.Add("@bCurrent", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bCurrentFN));
            cmdSpecialization_Courses.Parameters.Add("@byteOrder", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteOrderFN));
            cmdSpecialization_Courses.Parameters.Add("@MajorCoursesOrder", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MajorCoursesOrderFN));
            cmdSpecialization_Courses.Parameters.Add("@intLink", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intLinkFN));
            cmdSpecialization_Courses.Parameters.Add("@intLevel", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intLevelFN));
            cmdSpecialization_Courses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdSpecialization_Courses.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdSpecialization_Courses.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdSpecialization_Courses.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdSpecialization_Courses.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdSpecialization_Courses.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strSpecializationFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@byteCourseClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteCourseClassFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daSpecialization_Courses.UpdateCommand = cmdSpecialization_Courses;
            daSpecialization_Courses.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdSpecialization_Courses = new SqlCommand(GetInsertCommand(), con);
            cmdSpecialization_Courses.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdSpecialization_Courses.Parameters.Add("@strDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strDegreeFN));
            cmdSpecialization_Courses.Parameters.Add("@strSpecialization", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strSpecializationFN));
            cmdSpecialization_Courses.Parameters.Add("@byteCourseClass", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteCourseClassFN));
            cmdSpecialization_Courses.Parameters.Add("@strCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strCourseFN));
            cmdSpecialization_Courses.Parameters.Add("@bCurrent", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bCurrentFN));
            cmdSpecialization_Courses.Parameters.Add("@byteOrder", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteOrderFN));
            cmdSpecialization_Courses.Parameters.Add("@MajorCoursesOrder", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MajorCoursesOrderFN));
            cmdSpecialization_Courses.Parameters.Add("@intLink", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intLinkFN));
            cmdSpecialization_Courses.Parameters.Add("@intLevel", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intLevelFN));
            cmdSpecialization_Courses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdSpecialization_Courses.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdSpecialization_Courses.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdSpecialization_Courses.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdSpecialization_Courses.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdSpecialization_Courses.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daSpecialization_Courses.InsertCommand = cmdSpecialization_Courses;
            daSpecialization_Courses.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdSpecialization_Courses = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strSpecializationFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@byteCourseClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteCourseClassFN));
            Parmeter = cmdSpecialization_Courses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daSpecialization_Courses.DeleteCommand = cmdSpecialization_Courses;
            daSpecialization_Courses.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daSpecialization_Courses.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSpecialization_Courses;
    }
    //'-------SaveData  -----------------------------
    public int SaveData(int lFormMode)
    {
        //SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            switch (lFormMode)
            {
                case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
                    DataRow dr = default(DataRow);
                    dr = dsSpecialization_Courses.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    dr[LibraryMOD.GetFieldName(strDegreeFN)] = strDegree;
                    dr[LibraryMOD.GetFieldName(strSpecializationFN)] = strSpecialization;
                    dr[LibraryMOD.GetFieldName(byteCourseClassFN)] = byteCourseClass;
                    dr[LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    dr[LibraryMOD.GetFieldName(bCurrentFN)] = bCurrent;
                    dr[LibraryMOD.GetFieldName(byteOrderFN)] = byteOrder;
                    dr[LibraryMOD.GetFieldName(MajorCoursesOrderFN)] = MajorCoursesOrder;
                    dr[LibraryMOD.GetFieldName(intLinkFN)] = intLink;
                    dr[LibraryMOD.GetFieldName(intLevelFN)] = intLevel;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsSpecialization_Courses.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsSpecialization_Courses.Tables[TableName].Select(LibraryMOD.GetFieldName(strCollegeFN) + "=" + strCollege + " AND " + LibraryMOD.GetFieldName(strDegreeFN) + "=" + strDegree + " AND " + LibraryMOD.GetFieldName(strSpecializationFN) + "=" + strSpecialization + " AND " + LibraryMOD.GetFieldName(byteCourseClassFN) + "=" + byteCourseClass + " AND " + LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    drAry[0][LibraryMOD.GetFieldName(strDegreeFN)] = strDegree;
                    drAry[0][LibraryMOD.GetFieldName(strSpecializationFN)] = strSpecialization;
                    drAry[0][LibraryMOD.GetFieldName(byteCourseClassFN)] = byteCourseClass;
                    drAry[0][LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    drAry[0][LibraryMOD.GetFieldName(bCurrentFN)] = bCurrent;
                    drAry[0][LibraryMOD.GetFieldName(byteOrderFN)] = byteOrder;
                    drAry[0][LibraryMOD.GetFieldName(MajorCoursesOrderFN)] = MajorCoursesOrder;
                    drAry[0][LibraryMOD.GetFieldName(intLinkFN)] = intLink;
                    drAry[0][LibraryMOD.GetFieldName(intLevelFN)] = intLevel;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
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
    public int CommitSpecialization_Courses()
    {
        //CommitSpecialization_Courses= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daSpecialization_Courses.Update(dsSpecialization_Courses, TableName);
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
            FindInMultiPKey(strCollege, strDegree, strSpecialization, byteCourseClass, strCourse);
            if ((Specialization_CoursesDataRow != null))
            {
                Specialization_CoursesDataRow.Delete();
                CommitSpecialization_Courses();
                if (MoveNext() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strCollegeFN)] == System.DBNull.Value)
            {
                strCollege = "";
            }
            else
            {
                strCollege = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strDegreeFN)] == System.DBNull.Value)
            {
                strDegree = "";
            }
            else
            {
                strDegree = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strDegreeFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strSpecializationFN)] == System.DBNull.Value)
            {
                strSpecialization = "";
            }
            else
            {
                strSpecialization = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strSpecializationFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(byteCourseClassFN)] == System.DBNull.Value)
            {
                byteCourseClass = 0;
            }
            else
            {
                byteCourseClass = (int)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(byteCourseClassFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)] == System.DBNull.Value)
            {
                strCourse = "";
            }
            else
            {
                strCourse = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(bCurrentFN)] == System.DBNull.Value)
            {
                bCurrent = "";
            }
            else
            {
                bCurrent = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(bCurrentFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(byteOrderFN)] == System.DBNull.Value)
            {
                byteOrder = 0;
            }
            else
            {
                byteOrder = (int)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(byteOrderFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(MajorCoursesOrderFN)] == System.DBNull.Value)
            {
                MajorCoursesOrder = 0;
            }
            else
            {
                MajorCoursesOrder = (int)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(MajorCoursesOrderFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(intLinkFN)] == System.DBNull.Value)
            {
                intLink = 0;
            }
            else
            {
                intLink = (int)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(intLinkFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(intLevelFN)] == System.DBNull.Value)
            {
                intLevel = 0;
            }
            else
            {
                intLevel = (int)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(intLevelFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)Specialization_CoursesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(string PKstrCollege, string PKstrDegree, string PKstrSpecialization, int PKbyteCourseClass, string PKstrCourse)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKstrCollege;
            findTheseVals[1] = PKstrDegree;
            findTheseVals[2] = PKstrSpecialization;
            findTheseVals[3] = PKbyteCourseClass;
            findTheseVals[4] = PKstrCourse;
            Specialization_CoursesDataRow = dsSpecialization_Courses.Tables[TableName].Rows.Find(findTheseVals);
            if ((Specialization_CoursesDataRow != null))
            {
                lngCurRow = dsSpecialization_Courses.Tables[TableName].Rows.IndexOf(Specialization_CoursesDataRow);
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
    public int MoveFirst()
    {
        //MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = 0;
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
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
    public int MovePrevious()
    {
        //MovePrevious= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Max(lngCurRow - 1, 0);
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
    public int MoveLast()
    {
        //MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = dsSpecialization_Courses.Tables[TableName].Rows.Count - 1; //'Zero based index
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
    public int MoveNext()
    {
        //MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Min(lngCurRow + 1, dsSpecialization_Courses.Tables[TableName].Rows.Count - 1);
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
    public int GoToCurrentRow()
    {
        //GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            if (lngCurRow >= 0 & dsSpecialization_Courses.Tables[TableName].Rows.Count > 0)
            {
                Specialization_CoursesDataRow = dsSpecialization_Courses.Tables[TableName].Rows[lngCurRow];
                SynchronizeDataRowToClass();
            }
            else return ECTGlobalDll.InitializeModule.FAIL_RET;
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
            daSpecialization_Courses.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSpecialization_Courses.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daSpecialization_Courses.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSpecialization_Courses.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            if (args.StatementType == StatementType.Delete)
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
    private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs args)
    {
        try
        {
            if (args.Status == UpdateStatus.ErrorsOccurred)
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
