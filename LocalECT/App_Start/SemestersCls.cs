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
public class EctDataSemesters
{
//Creation Date: 18/04/2010 07:03:27 م
//Programmer Name : hazem
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private DateTime m_dateStartRegistration; 
private DateTime m_dateEndRegistration; 
private DateTime m_dateStartSemester; 
private DateTime m_dateEndSemester; 
private int m_Period; 
private string m_bApplyRules; 
private int m_byteAttDaysAllowed; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
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
public DateTime dateStartRegistration
{
get { return  m_dateStartRegistration; }
set {m_dateStartRegistration  = value ; }
}
public DateTime dateEndRegistration
{
get { return  m_dateEndRegistration; }
set {m_dateEndRegistration  = value ; }
}
public DateTime dateStartSemester
{
get { return  m_dateStartSemester; }
set {m_dateStartSemester  = value ; }
}
public DateTime dateEndSemester
{
get { return  m_dateEndSemester; }
set {m_dateEndSemester  = value ; }
}
public int Period
{
get { return  m_Period; }
set {m_Period  = value ; }
}
public string bApplyRules
{
get { return  m_bApplyRules; }
set {m_bApplyRules  = value ; }
}
public int byteAttDaysAllowed
{
get { return  m_byteAttDaysAllowed; }
set {m_byteAttDaysAllowed  = value ; }
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
public EctDataSemesters()
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
public class SemestersDAL : EctDataSemesters
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_dateStartRegistrationFN ;
private string m_dateEndRegistrationFN ;
private string m_dateStartSemesterFN ;
private string m_dateEndSemesterFN ;
private string m_PeriodFN ;
private string m_bApplyRulesFN ;
private string m_byteAttDaysAllowedFN ;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
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
public string dateStartRegistrationFN 
{
get { return  m_dateStartRegistrationFN; }
set {m_dateStartRegistrationFN  = value ; }
}
public string dateEndRegistrationFN 
{
get { return  m_dateEndRegistrationFN; }
set {m_dateEndRegistrationFN  = value ; }
}
public string dateStartSemesterFN 
{
get { return  m_dateStartSemesterFN; }
set {m_dateStartSemesterFN  = value ; }
}
public string dateEndSemesterFN 
{
get { return  m_dateEndSemesterFN; }
set {m_dateEndSemesterFN  = value ; }
}
public string PeriodFN 
{
get { return  m_PeriodFN; }
set {m_PeriodFN  = value ; }
}
public string bApplyRulesFN 
{
get { return  m_bApplyRulesFN; }
set {m_bApplyRulesFN  = value ; }
}
public string byteAttDaysAllowedFN 
{
get { return  m_byteAttDaysAllowedFN; }
set {m_byteAttDaysAllowedFN  = value ; }
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
public SemestersDAL()
{
try
{
this.TableName = "Reg_Semesters";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.dateStartRegistrationFN = m_TableName + ".dateStartRegistration";
this.dateEndRegistrationFN = m_TableName + ".dateEndRegistration";
this.dateStartSemesterFN = m_TableName + ".dateStartSemester";
this.dateEndSemesterFN = m_TableName + ".dateEndSemester";
this.PeriodFN = m_TableName + ".Period";
this.bApplyRulesFN = m_TableName + ".bApplyRules";
this.byteAttDaysAllowedFN = m_TableName + ".byteAttDaysAllowed";
this.strUserCreateFN = m_TableName + ".strUserCreate";
this.dateCreateFN = m_TableName + ".dateCreate";
this.strUserSaveFN = m_TableName + ".strUserSave";
this.dateLastSaveFN = m_TableName + ".dateLastSave";
this.strMachineFN = m_TableName + ".strMachine";
this.strNUserFN = m_TableName + ".strNUser";
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
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + dateStartRegistrationFN;
sSQL += " , " + dateEndRegistrationFN;
sSQL += " , " + dateStartSemesterFN;
sSQL += " , " + dateEndSemesterFN;
sSQL += " , " + PeriodFN;
sSQL += " , " + bApplyRulesFN;
sSQL += " , " + byteAttDaysAllowedFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
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
public string GetAcademicYearListSQL(string sWhere)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT DISTINCT ";
        sSQL += intStudyYearFN;
        sSQL += " FROM " + m_TableName;
        sSQL += sWhere;
        sSQL += " ORDER BY " + intStudyYearFN + " DESC";

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
public string GetSemestersListSQL(string sWhere)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT MinorID, DescEn ";
        sSQL += " FROM Cmn_LookupDetails ";
        sSQL += " WHERE MajorID=10 ";
        if(!sWhere.Equals(""))
        sSQL += " AND " + sWhere;
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
sSQL += " , " + dateStartRegistrationFN;
sSQL += " , " + dateEndRegistrationFN;
sSQL += " , " + dateStartSemesterFN;
sSQL += " , " + dateEndSemesterFN;
sSQL += " , " + PeriodFN;
sSQL += " , " + bApplyRulesFN;
sSQL += " , " + byteAttDaysAllowedFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
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
sSQL += LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
sSQL += " , " + LibraryMOD.GetFieldName(dateStartRegistrationFN) + "=@dateStartRegistration";
sSQL += " , " + LibraryMOD.GetFieldName(dateEndRegistrationFN) + "=@dateEndRegistration";
sSQL += " , " + LibraryMOD.GetFieldName(dateStartSemesterFN) + "=@dateStartSemester";
sSQL += " , " + LibraryMOD.GetFieldName(dateEndSemesterFN) + "=@dateEndSemester";
sSQL += " , " + LibraryMOD.GetFieldName(PeriodFN) + "=@Period";
sSQL += " , " + LibraryMOD.GetFieldName(bApplyRulesFN) + "=@bApplyRules";
sSQL += " , " + LibraryMOD.GetFieldName(byteAttDaysAllowedFN) + "=@byteAttDaysAllowed";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
//sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
//sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
//sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
//sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
//sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
//sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intStudyYearFN)+"=@intStudyYear";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteSemesterFN)+"=@byteSemester";
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
sSQL += " , " + LibraryMOD.GetFieldName(dateStartRegistrationFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateEndRegistrationFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateStartSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateEndSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(PeriodFN);
sSQL += " , " + LibraryMOD.GetFieldName(bApplyRulesFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteAttDaysAllowedFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
//sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
//sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intStudyYear";
sSQL += " ,@byteSemester";
sSQL += " ,@dateStartRegistration";
sSQL += " ,@dateEndRegistration";
sSQL += " ,@dateStartSemester";
sSQL += " ,@dateEndSemester";
sSQL += " ,@Period";
sSQL += " ,@bApplyRules";
sSQL += " ,@byteAttDaysAllowed";
sSQL += " ,@strUserCreate";
sSQL += " ,@dateCreate";
sSQL += " ,@strUserSave";
sSQL += " ,@dateLastSave";
sSQL += " ,@strMachine";
sSQL += " ,@strNUser";
//sSQL += " ,@CreationUserID";
//sSQL += " ,@CreationDate";
//sSQL += " ,@LastUpdateUserID";
//sSQL += " ,@LastUpdateDate";
//sSQL += " ,@PCName";
//sSQL += " ,@NetUserName";
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

public List<Semesters> GetAcademicYearsList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{

    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetAcademicYearListSQL(sCondition);

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Semesters> results = new List<Semesters>();
    try
    {
        //Default Value
        Semesters mySemesters = new Semesters();
        if (isDeafaultIncluded)
        {
            //Change the code here
            mySemesters.AcademicYear = 0;
            mySemesters.ShortDesc = "Select Year ...";
            results.Add(mySemesters);
        }
        while (reader.Read())
        {
            mySemesters = new Semesters();

            if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
            {
                mySemesters.AcademicYear = 0;
            }
            else
            {
                mySemesters.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName(intStudyYearFN)].ToString());
            }
            mySemesters.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName(intStudyYearFN)].ToString());

            results.Add(mySemesters);
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

//SELECT MinorID, DescEn FROM Cmn_LookupDetails WHERE MajorID=10
public List<Semesters> GetSemestersList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{

    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetSemestersListSQL(sCondition);

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Semesters> results = new List<Semesters>();
    try
    {
        //Default Value
        Semesters mySemesters = new Semesters();
        if (isDeafaultIncluded)
        {
            //Change the code here
            mySemesters.Semester = 0;
            mySemesters.ShortDesc = "Select Semester ...";
            results.Add(mySemesters);
        }
        while (reader.Read())
        {
            mySemesters = new Semesters();

            if (reader["MinorID"].Equals(DBNull.Value))
            {
                mySemesters.Semester = 0;
            }
            else
            {
                mySemesters.Semester = int.Parse(reader["MinorID"].ToString());
            }
            mySemesters.ShortDesc = reader["DescEn"].ToString();

            results.Add(mySemesters);
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

public List<EctDataSemesters> GetSemesters(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Semesters
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
List<EctDataSemesters> results = new List<EctDataSemesters>();
try
{
//Default Value
    EctDataSemesters mySemesters = new EctDataSemesters();
if (isDeafaultIncluded)
{
//Change the code here
mySemesters.intStudyYear = 0;
mySemesters.byteSemester = 0;
mySemesters.dateStartRegistration = new DateTime(1900, 01, 01);
results.Add(mySemesters);
}
while (reader.Read())
{
    mySemesters = new EctDataSemesters();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
mySemesters.intStudyYear = 0;
}
else
{
mySemesters.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
mySemesters.byteSemester = 0;
}
else
{
mySemesters.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (!reader[dateStartRegistrationFN].Equals(DBNull.Value))
{
mySemesters.dateStartRegistration = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateStartRegistrationFN) ].ToString());
}
if (!reader[dateEndRegistrationFN].Equals(DBNull.Value))
{
mySemesters.dateEndRegistration = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateEndRegistrationFN) ].ToString());
}
if (!reader[dateStartSemesterFN].Equals(DBNull.Value))
{
mySemesters.dateStartSemester = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateStartSemesterFN) ].ToString());
}
if (!reader[dateEndSemesterFN].Equals(DBNull.Value))
{
mySemesters.dateEndSemester = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateEndSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(PeriodFN)].Equals(DBNull.Value))
{
mySemesters.Period = 0;
}
else
{
mySemesters.Period = int.Parse(reader[LibraryMOD.GetFieldName( PeriodFN) ].ToString());
}
mySemesters.bApplyRules =reader[LibraryMOD.GetFieldName( bApplyRulesFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteAttDaysAllowedFN)].Equals(DBNull.Value))
{
mySemesters.byteAttDaysAllowed = 0;
}
else
{
mySemesters.byteAttDaysAllowed = int.Parse(reader[LibraryMOD.GetFieldName( byteAttDaysAllowedFN) ].ToString());
}
mySemesters.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[dateCreateFN].Equals(DBNull.Value))
{
mySemesters.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
mySemesters.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[dateLastSaveFN].Equals(DBNull.Value))
{
mySemesters.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
mySemesters.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
mySemesters.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
mySemesters.CreationUserID = 0;
}
else
{
mySemesters.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
mySemesters.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
mySemesters.LastUpdateUserID = 0;
}
else
{
mySemesters.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
mySemesters.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
mySemesters.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
mySemesters.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(mySemesters);
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
public int UpdateSemesters(InitializeModule.EnumCampus Campus, int iMode,int intStudyYear,int byteSemester,DateTime dateStartRegistration,DateTime dateEndRegistration,DateTime dateStartSemester,DateTime dateEndSemester,int Period,string bApplyRules,int byteAttDaysAllowed,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EctDataSemesters theSemesters = new EctDataSemesters();
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
Cmd.Parameters.Add(new SqlParameter("@dateStartRegistration",dateStartRegistration));
Cmd.Parameters.Add(new SqlParameter("@dateEndRegistration",dateEndRegistration));
Cmd.Parameters.Add(new SqlParameter("@dateStartSemester",dateStartSemester));
Cmd.Parameters.Add(new SqlParameter("@dateEndSemester",dateEndSemester));
Cmd.Parameters.Add(new SqlParameter("@Period",Period));
Cmd.Parameters.Add(new SqlParameter("@bApplyRules",bApplyRules));
Cmd.Parameters.Add(new SqlParameter("@byteAttDaysAllowed",byteAttDaysAllowed));
Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));
//Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
//Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
//Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
//Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
//Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
//Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
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
public int DeleteSemesters(InitializeModule.EnumCampus Campus,string intStudyYear,string byteSemester)
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
DataTable dt = new DataTable("Semesters");
DataView dv = new DataView();
List<EctDataSemesters> mySemesterss = new List<EctDataSemesters>();
try
{
mySemesterss = GetSemesters(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("dateStartRegistration", Type.GetType("datetime"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < mySemesterss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = mySemesterss[i].intStudyYear;
  dr[2] = mySemesterss[i].byteSemester;
  dr[3] = mySemesterss[i].dateStartRegistration;
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
mySemesterss.Clear();
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
public class SemestersCls : SemestersDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daSemesters;
    private DataSet m_dsSemesters;
    public DataRow SemestersDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsSemesters
    {
        get { return m_dsSemesters; }
        set { m_dsSemesters = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public SemestersCls()
    {
        try
        {
            dsSemesters = new DataSet();

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
    public virtual SqlDataAdapter GetSemestersDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daSemesters = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSemesters);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daSemesters.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSemesters;
    }
    public virtual SqlDataAdapter GetSemestersDataAdapter(SqlConnection con)
    {
        try
        {
            daSemesters = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daSemesters.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdSemesters;
            cmdSemesters = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, "intStudyYear" );
            //'cmdRolePermission.Parameters.Add("@byteSemester", SqlDbType.Int, 4, "byteSemester" );
            daSemesters.SelectCommand = cmdSemesters;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdSemesters = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdSemesters.Parameters.Add("@intStudyYear", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intStudyYearFN));
            cmdSemesters.Parameters.Add("@byteSemester", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteSemesterFN));
            cmdSemesters.Parameters.Add("@dateStartRegistration", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateStartRegistrationFN));
            cmdSemesters.Parameters.Add("@dateEndRegistration", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateEndRegistrationFN));
            cmdSemesters.Parameters.Add("@dateStartSemester", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateStartSemesterFN));
            cmdSemesters.Parameters.Add("@dateEndSemester", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateEndSemesterFN));
            cmdSemesters.Parameters.Add("@Period", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PeriodFN));
            cmdSemesters.Parameters.Add("@bApplyRules", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bApplyRulesFN));
            cmdSemesters.Parameters.Add("@byteAttDaysAllowed", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteAttDaysAllowedFN));
            cmdSemesters.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdSemesters.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdSemesters.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdSemesters.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdSemesters.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdSemesters.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            cmdSemesters.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSemesters.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSemesters.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSemesters.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSemesters.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdSemesters.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdSemesters.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
            Parmeter = cmdSemesters.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daSemesters.UpdateCommand = cmdSemesters;
            daSemesters.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdSemesters = new SqlCommand(GetInsertCommand(), con);
            cmdSemesters.Parameters.Add("@intStudyYear", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intStudyYearFN));
            cmdSemesters.Parameters.Add("@byteSemester", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteSemesterFN));
            cmdSemesters.Parameters.Add("@dateStartRegistration", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateStartRegistrationFN));
            cmdSemesters.Parameters.Add("@dateEndRegistration", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateEndRegistrationFN));
            cmdSemesters.Parameters.Add("@dateStartSemester", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateStartSemesterFN));
            cmdSemesters.Parameters.Add("@dateEndSemester", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateEndSemesterFN));
            cmdSemesters.Parameters.Add("@Period", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PeriodFN));
            cmdSemesters.Parameters.Add("@bApplyRules", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bApplyRulesFN));
            cmdSemesters.Parameters.Add("@byteAttDaysAllowed", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteAttDaysAllowedFN));
            cmdSemesters.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdSemesters.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdSemesters.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdSemesters.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdSemesters.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdSemesters.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            cmdSemesters.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSemesters.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSemesters.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSemesters.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSemesters.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdSemesters.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daSemesters.InsertCommand = cmdSemesters;
            daSemesters.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdSemesters = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdSemesters.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
            Parmeter = cmdSemesters.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daSemesters.DeleteCommand = cmdSemesters;
            daSemesters.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daSemesters.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSemesters;
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
                    dr = dsSemesters.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(intStudyYearFN)] = intStudyYear;
                    dr[LibraryMOD.GetFieldName(byteSemesterFN)] = byteSemester;
                    dr[LibraryMOD.GetFieldName(dateStartRegistrationFN)] = dateStartRegistration;
                    dr[LibraryMOD.GetFieldName(dateEndRegistrationFN)] = dateEndRegistration;
                    dr[LibraryMOD.GetFieldName(dateStartSemesterFN)] = dateStartSemester;
                    dr[LibraryMOD.GetFieldName(dateEndSemesterFN)] = dateEndSemester;
                    dr[LibraryMOD.GetFieldName(PeriodFN)] = Period;
                    dr[LibraryMOD.GetFieldName(bApplyRulesFN)] = bApplyRules;
                    dr[LibraryMOD.GetFieldName(byteAttDaysAllowedFN)] = byteAttDaysAllowed;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
                    dsSemesters.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsSemesters.Tables[TableName].Select(LibraryMOD.GetFieldName(intStudyYearFN) + "=" + intStudyYear + " AND " + LibraryMOD.GetFieldName(byteSemesterFN) + "=" + byteSemester);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)] = intStudyYear;
                    drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)] = byteSemester;
                    drAry[0][LibraryMOD.GetFieldName(dateStartRegistrationFN)] = dateStartRegistration;
                    drAry[0][LibraryMOD.GetFieldName(dateEndRegistrationFN)] = dateEndRegistration;
                    drAry[0][LibraryMOD.GetFieldName(dateStartSemesterFN)] = dateStartSemester;
                    drAry[0][LibraryMOD.GetFieldName(dateEndSemesterFN)] = dateEndSemester;
                    drAry[0][LibraryMOD.GetFieldName(PeriodFN)] = Period;
                    drAry[0][LibraryMOD.GetFieldName(bApplyRulesFN)] = bApplyRules;
                    drAry[0][LibraryMOD.GetFieldName(byteAttDaysAllowedFN)] = byteAttDaysAllowed;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
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
    public int CommitSemesters()
    {
        //CommitSemesters= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daSemesters.Update(dsSemesters, TableName);
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
            FindInMultiPKey(intStudyYear, byteSemester);
            if ((SemestersDataRow != null))
            {
                SemestersDataRow.Delete();
                CommitSemesters();
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
            if (SemestersDataRow[LibraryMOD.GetFieldName(intStudyYearFN)] == System.DBNull.Value)
            {
                intStudyYear = 0;
            }
            else
            {
                intStudyYear = (int)SemestersDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(byteSemesterFN)] == System.DBNull.Value)
            {
                byteSemester = 0;
            }
            else
            {
                byteSemester = (int)SemestersDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(dateStartRegistrationFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateStartRegistration = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(dateStartRegistrationFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(dateEndRegistrationFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateEndRegistration = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(dateEndRegistrationFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(dateStartSemesterFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateStartSemester = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(dateStartSemesterFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(dateEndSemesterFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateEndSemester = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(dateEndSemesterFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(PeriodFN)] == System.DBNull.Value)
            {
                Period = 0;
            }
            else
            {
                Period = (int)SemestersDataRow[LibraryMOD.GetFieldName(PeriodFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(bApplyRulesFN)] == System.DBNull.Value)
            {
                bApplyRules = "";
            }
            else
            {
                bApplyRules = (string)SemestersDataRow[LibraryMOD.GetFieldName(bApplyRulesFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(byteAttDaysAllowedFN)] == System.DBNull.Value)
            {
                byteAttDaysAllowed = 0;
            }
            else
            {
                byteAttDaysAllowed = (int)SemestersDataRow[LibraryMOD.GetFieldName(byteAttDaysAllowedFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)SemestersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)SemestersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)SemestersDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)SemestersDataRow[LibraryMOD.GetFieldName(strNUserFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)SemestersDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)SemestersDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)SemestersDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)SemestersDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (SemestersDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)SemestersDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKintStudyYear, int PKbyteSemester)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKintStudyYear;
            findTheseVals[1] = PKbyteSemester;
            SemestersDataRow = dsSemesters.Tables[TableName].Rows.Find(findTheseVals);
            if ((SemestersDataRow != null))
            {
                lngCurRow = dsSemesters.Tables[TableName].Rows.IndexOf(SemestersDataRow);
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
            lngCurRow = dsSemesters.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsSemesters.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsSemesters.Tables[TableName].Rows.Count > 0)
            {
                SemestersDataRow = dsSemesters.Tables[TableName].Rows[lngCurRow];
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
            daSemesters.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSemesters.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daSemesters.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSemesters.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
