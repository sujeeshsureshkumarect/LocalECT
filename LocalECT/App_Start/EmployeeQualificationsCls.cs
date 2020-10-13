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
public class EmployeeQualifications
{
//Creation Date: 31/10/2010 7:16 PM
//Programmer Name : Bahaa Addin Ghaleb Najem
//-----Decleration --------------
#region "Decleration"
private int m_EmployeeID; 
private int m_QualificationID; 
private int m_QualificationType; 
private int m_CertificateID;
private string  m_ResearchTitle; 
private int m_MainMajorID; 
private int m_SubMajorID; 
private int m_GraduationYear; 
private string m_Startdate; 
private string m_GraduationDate; 
private int m_StudyYears; 
private int m_InstituteCountry; 
private string m_InstituteName; 
private int m_StudyLanguageID; 
private int m_StudyTypeID; 
private string m_Average; 
private int m_GradeID; 
private string m_CoursesTaken; 
private int m_IsAuthenticated; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int EmployeeID
{
get { return  m_EmployeeID; }
set {m_EmployeeID  = value ; }
}
public int QualificationID
{
get { return  m_QualificationID; }
set {m_QualificationID  = value ; }
}
public int QualificationType
{
get { return  m_QualificationType; }
set {m_QualificationType  = value ; }
}
public int CertificateID
{
get { return  m_CertificateID; }
set {m_CertificateID  = value ; }
}

public string ResearchTitle
{
    get { return  m_ResearchTitle; }
    set { m_ResearchTitle = value; }
}
public int MainMajorID
{
get { return  m_MainMajorID; }
set {m_MainMajorID  = value ; }
}
public int SubMajorID
{
get { return  m_SubMajorID; }
set {m_SubMajorID  = value ; }
}
public int GraduationYear
{
get { return  m_GraduationYear; }
set {m_GraduationYear  = value ; }
}
public string Startdate
{
get { return  m_Startdate; }
set {m_Startdate  = value ; }
}
public string GraduationDate
{
get { return  m_GraduationDate; }
set {m_GraduationDate  = value ; }
}
public int StudyYears
{
get { return  m_StudyYears; }
set {m_StudyYears  = value ; }
}
public int InstituteCountry
{
get { return  m_InstituteCountry; }
set {m_InstituteCountry  = value ; }
}
public string InstituteName
{
get { return  m_InstituteName; }
set {m_InstituteName  = value ; }
}
public int StudyLanguageID
{
get { return  m_StudyLanguageID; }
set {m_StudyLanguageID  = value ; }
}
public int StudyTypeID
{
get { return  m_StudyTypeID; }
set {m_StudyTypeID  = value ; }
}
public string Average
{
get { return  m_Average; }
set {m_Average  = value ; }
}
public int GradeID
{
get { return  m_GradeID; }
set {m_GradeID  = value ; }
}
public string CoursesTaken
{
get { return  m_CoursesTaken; }
set {m_CoursesTaken  = value ; }
}
public int IsAuthenticated
{
get { return  m_IsAuthenticated; }
set {m_IsAuthenticated  = value ; }
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
public EmployeeQualifications()
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
public class EmployeeQualificationsDAL : EmployeeQualifications
{
#region "Decleration"
private string m_TableName;
private string m_EmployeeIDFN ;
private string m_QualificationIDFN ;
private string m_QualificationTypeFN ;
private string m_CertificateIDFN ;
private string m_ResearchTitleFN;
private string m_MainMajorIDFN ;
private string m_SubMajorIDFN ;
private string m_GraduationYearFN ;
private string m_StartdateFN ;
private string m_GraduationDateFN ;
private string m_StudyYearsFN ;
private string m_InstituteCountryFN ;
private string m_InstituteNameFN ;
private string m_StudyLanguageIDFN ;
private string m_StudyTypeIDFN ;
private string m_AverageFN ;
private string m_GradeIDFN ;
private string m_CoursesTakenFN ;
private string m_IsAuthenticatedFN ;
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
public string EmployeeIDFN 
{
get { return  m_EmployeeIDFN; }
set {m_EmployeeIDFN  = value ; }
}
public string QualificationIDFN 
{
get { return  m_QualificationIDFN; }
set {m_QualificationIDFN  = value ; }
}
public string QualificationTypeFN 
{
get { return  m_QualificationTypeFN; }
set {m_QualificationTypeFN  = value ; }
}
public string CertificateIDFN 
{
get { return  m_CertificateIDFN; }
set {m_CertificateIDFN  = value ; }
}
public string ResearchTitleFN 
{
    get { return m_ResearchTitleFN; }
    set { m_ResearchTitleFN = value; }
}
public string MainMajorIDFN 
{
get { return  m_MainMajorIDFN; }
set {m_MainMajorIDFN  = value ; }
}
public string SubMajorIDFN 
{
get { return  m_SubMajorIDFN; }
set {m_SubMajorIDFN  = value ; }
}
public string GraduationYearFN 
{
get { return  m_GraduationYearFN; }
set {m_GraduationYearFN  = value ; }
}
public string StartdateFN 
{
get { return  m_StartdateFN; }
set {m_StartdateFN  = value ; }
}
public string GraduationDateFN 
{
get { return  m_GraduationDateFN; }
set {m_GraduationDateFN  = value ; }
}
public string StudyYearsFN 
{
get { return  m_StudyYearsFN; }
set {m_StudyYearsFN  = value ; }
}
public string InstituteCountryFN 
{
get { return  m_InstituteCountryFN; }
set {m_InstituteCountryFN  = value ; }
}
public string InstituteNameFN 
{
get { return  m_InstituteNameFN; }
set {m_InstituteNameFN  = value ; }
}
public string StudyLanguageIDFN 
{
get { return  m_StudyLanguageIDFN; }
set {m_StudyLanguageIDFN  = value ; }
}
public string StudyTypeIDFN 
{
get { return  m_StudyTypeIDFN; }
set {m_StudyTypeIDFN  = value ; }
}
public string AverageFN 
{
get { return  m_AverageFN; }
set {m_AverageFN  = value ; }
}
public string GradeIDFN 
{
get { return  m_GradeIDFN; }
set {m_GradeIDFN  = value ; }
}
public string CoursesTakenFN 
{
get { return  m_CoursesTakenFN; }
set {m_CoursesTakenFN  = value ; }
}
public string IsAuthenticatedFN 
{
get { return  m_IsAuthenticatedFN; }
set {m_IsAuthenticatedFN  = value ; }
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
public EmployeeQualificationsDAL()
{
try
{
this.TableName = "Hr_EmployeeQualifications";
this.EmployeeIDFN = m_TableName + ".EmployeeID";
this.QualificationIDFN = m_TableName + ".QualificationID";
this.QualificationTypeFN = m_TableName + ".QualificationType";
this.CertificateIDFN = m_TableName + ".CertificateID";
this.ResearchTitleFN = m_TableName + ".ResearchTitle";
this.MainMajorIDFN = m_TableName + ".MainMajorID";
this.SubMajorIDFN = m_TableName + ".SubMajorID";
this.GraduationYearFN = m_TableName + ".GraduationYear";
this.StartdateFN = m_TableName + ".Startdate";
this.GraduationDateFN = m_TableName + ".GraduationDate";
this.StudyYearsFN = m_TableName + ".StudyYears";
this.InstituteCountryFN = m_TableName + ".InstituteCountry";
this.InstituteNameFN = m_TableName + ".InstituteName";
this.StudyLanguageIDFN = m_TableName + ".StudyLanguageID";
this.StudyTypeIDFN = m_TableName + ".StudyTypeID";
this.AverageFN = m_TableName + ".Average";
this.GradeIDFN = m_TableName + ".GradeID";
this.CoursesTakenFN = m_TableName + ".CoursesTaken";
this.IsAuthenticatedFN = m_TableName + ".IsAuthenticated";
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
sSQL +=EmployeeIDFN;
sSQL += " , " + QualificationIDFN;
sSQL += " , " + QualificationTypeFN;
sSQL += " , " + CertificateIDFN;
sSQL += " , " + ResearchTitleFN;
sSQL += " , " + MainMajorIDFN;
sSQL += " , " + SubMajorIDFN;
sSQL += " , " + GraduationYearFN;
sSQL += " , " + StartdateFN;
sSQL += " , " + GraduationDateFN;
sSQL += " , " + StudyYearsFN;
sSQL += " , " + InstituteCountryFN;
sSQL += " , " + InstituteNameFN;
sSQL += " , " + StudyLanguageIDFN;
sSQL += " , " + StudyTypeIDFN;
sSQL += " , " + AverageFN;
sSQL += " , " + GradeIDFN;
sSQL += " , " + CoursesTakenFN;
sSQL += " , " + IsAuthenticatedFN;
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
public string  GetListSQL(string sWhere) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=EmployeeIDFN;
sSQL += " , " + QualificationIDFN;
sSQL += " , " + QualificationTypeFN;
sSQL += "  FROM " + m_TableName;
sSQL += sWhere;
sSQL += " Order By (" + QualificationTypeFN + ")";
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
sSQL +=EmployeeIDFN;
sSQL += " , " + QualificationIDFN;
sSQL += " , " + QualificationTypeFN;
sSQL += " , " + CertificateIDFN;
sSQL += " , " + ResearchTitleFN;
sSQL += " , " + MainMajorIDFN;
sSQL += " , " + SubMajorIDFN;
sSQL += " , " + GraduationYearFN;
sSQL += " , " + StartdateFN;
sSQL += " , " + GraduationDateFN;
sSQL += " , " + StudyYearsFN;
sSQL += " , " + InstituteCountryFN;
sSQL += " , " + InstituteNameFN;
sSQL += " , " + StudyLanguageIDFN;
sSQL += " , " + StudyTypeIDFN;
sSQL += " , " + AverageFN;
sSQL += " , " + GradeIDFN;
sSQL += " , " + CoursesTakenFN;
sSQL += " , " + IsAuthenticatedFN;
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN) + "=@EmployeeID";
sSQL += " , " + LibraryMOD.GetFieldName(QualificationIDFN) + "=@QualificationID";
sSQL += " , " + LibraryMOD.GetFieldName(QualificationTypeFN) + "=@QualificationType";
sSQL += " , " + LibraryMOD.GetFieldName(CertificateIDFN) + "=@CertificateID";
sSQL += " , " + LibraryMOD.GetFieldName(ResearchTitleFN) + "=@ResearchTitle";
sSQL += " , " + LibraryMOD.GetFieldName(MainMajorIDFN) + "=@MainMajorID";
sSQL += " , " + LibraryMOD.GetFieldName(SubMajorIDFN) + "=@SubMajorID";
sSQL += " , " + LibraryMOD.GetFieldName(GraduationYearFN) + "=@GraduationYear";
sSQL += " , " + LibraryMOD.GetFieldName(StartdateFN) + "=@Startdate";
sSQL += " , " + LibraryMOD.GetFieldName(GraduationDateFN) + "=@GraduationDate";
sSQL += " , " + LibraryMOD.GetFieldName(StudyYearsFN) + "=@StudyYears";
sSQL += " , " + LibraryMOD.GetFieldName(InstituteCountryFN) + "=@InstituteCountry";
sSQL += " , " + LibraryMOD.GetFieldName(InstituteNameFN) + "=@InstituteName";
sSQL += " , " + LibraryMOD.GetFieldName(StudyLanguageIDFN) + "=@StudyLanguageID";
sSQL += " , " + LibraryMOD.GetFieldName(StudyTypeIDFN) + "=@StudyTypeID";
sSQL += " , " + LibraryMOD.GetFieldName(AverageFN) + "=@Average";
sSQL += " , " + LibraryMOD.GetFieldName(GradeIDFN) + "=@GradeID";
sSQL += " , " + LibraryMOD.GetFieldName(CoursesTakenFN) + "=@CoursesTaken";
sSQL += " , " + LibraryMOD.GetFieldName(IsAuthenticatedFN) + "=@IsAuthenticated";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " + LibraryMOD.GetFieldName(QualificationIDFN)+"=@QualificationID";
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
sSQL +=LibraryMOD.GetFieldName(EmployeeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(QualificationIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(QualificationTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(CertificateIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ResearchTitleFN);
sSQL += " , " + LibraryMOD.GetFieldName(MainMajorIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SubMajorIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(GraduationYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(StartdateFN);
sSQL += " , " + LibraryMOD.GetFieldName(GraduationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(StudyYearsFN);
sSQL += " , " + LibraryMOD.GetFieldName(InstituteCountryFN);
sSQL += " , " + LibraryMOD.GetFieldName(InstituteNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(StudyLanguageIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(StudyTypeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(AverageFN);
sSQL += " , " + LibraryMOD.GetFieldName(GradeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CoursesTakenFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsAuthenticatedFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @EmployeeID";
sSQL += " ,@QualificationID";
sSQL += " ,@QualificationType";
sSQL += " ,@CertificateID";
sSQL += " ,@ResearchTitle";
sSQL += " ,@MainMajorID";
sSQL += " ,@SubMajorID";
sSQL += " ,@GraduationYear";
sSQL += " ,@Startdate";
sSQL += " ,@GraduationDate";
sSQL += " ,@StudyYears";
sSQL += " ,@InstituteCountry";
sSQL += " ,@InstituteName";
sSQL += " ,@StudyLanguageID";
sSQL += " ,@StudyTypeID";
sSQL += " ,@Average";
sSQL += " ,@GradeID";
sSQL += " ,@CoursesTaken";
sSQL += " ,@IsAuthenticated";
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(QualificationIDFN)+"=@QualificationID";
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
public List< EmployeeQualifications> GetEmployeeQualifications(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the EmployeeQualifications
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
List<EmployeeQualifications> results = new List<EmployeeQualifications>();
try
{
//Default Value
EmployeeQualifications myEmployeeQualifications = new EmployeeQualifications();
if (isDeafaultIncluded)
{
//Change the code here
myEmployeeQualifications.EmployeeID = 0;
myEmployeeQualifications.QualificationID = 0;
myEmployeeQualifications.QualificationType = 0;
results.Add(myEmployeeQualifications);
}
while (reader.Read())
{
myEmployeeQualifications = new EmployeeQualifications();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.EmployeeID = 0;
}
else
{
myEmployeeQualifications.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(QualificationIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.QualificationID = 0;
}
else
{
myEmployeeQualifications.QualificationID = int.Parse(reader[LibraryMOD.GetFieldName( QualificationIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(QualificationTypeFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.QualificationType = 0;
}
else
{
myEmployeeQualifications.QualificationType = int.Parse(reader[LibraryMOD.GetFieldName( QualificationTypeFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CertificateIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.CertificateID = 0;
}
else
{
myEmployeeQualifications.CertificateID = int.Parse(reader[LibraryMOD.GetFieldName( CertificateIDFN) ].ToString());
}

if (reader[LibraryMOD.GetFieldName(ResearchTitleFN)].Equals(DBNull.Value))
{
    myEmployeeQualifications.ResearchTitle = "";
}
else
{
    myEmployeeQualifications.ResearchTitle = reader[LibraryMOD.GetFieldName(ResearchTitleFN)].ToString();
}
if (reader[LibraryMOD.GetFieldName(MainMajorIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.MainMajorID = 0;
}
else
{
myEmployeeQualifications.MainMajorID = int.Parse(reader[LibraryMOD.GetFieldName( MainMajorIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SubMajorIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.SubMajorID = 0;
}
else
{
myEmployeeQualifications.SubMajorID = int.Parse(reader[LibraryMOD.GetFieldName( SubMajorIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(GraduationYearFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.GraduationYear = 0;
}
else
{
myEmployeeQualifications.GraduationYear = int.Parse(reader[LibraryMOD.GetFieldName( GraduationYearFN) ].ToString());
}
myEmployeeQualifications.Startdate =reader[LibraryMOD.GetFieldName( StartdateFN) ].ToString();
myEmployeeQualifications.GraduationDate =reader[LibraryMOD.GetFieldName( GraduationDateFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(StudyYearsFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.StudyYears = 0;
}
else
{
myEmployeeQualifications.StudyYears = int.Parse(reader[LibraryMOD.GetFieldName( StudyYearsFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(InstituteCountryFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.InstituteCountry = 0;
}
else
{
myEmployeeQualifications.InstituteCountry = int.Parse(reader[LibraryMOD.GetFieldName( InstituteCountryFN) ].ToString());
}
myEmployeeQualifications.InstituteName =reader[LibraryMOD.GetFieldName( InstituteNameFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(StudyLanguageIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.StudyLanguageID = 0;
}
else
{
myEmployeeQualifications.StudyLanguageID = int.Parse(reader[LibraryMOD.GetFieldName( StudyLanguageIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(StudyTypeIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.StudyTypeID = 0;
}
else
{
myEmployeeQualifications.StudyTypeID = int.Parse(reader[LibraryMOD.GetFieldName( StudyTypeIDFN) ].ToString());
}
myEmployeeQualifications.Average =reader[LibraryMOD.GetFieldName( AverageFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(GradeIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.GradeID = 0;
}
else
{
myEmployeeQualifications.GradeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeIDFN) ].ToString());
}
myEmployeeQualifications.CoursesTaken =reader[LibraryMOD.GetFieldName( CoursesTakenFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(IsAuthenticatedFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.IsAuthenticated = 0;
}
else
{
myEmployeeQualifications.IsAuthenticated = int.Parse(reader[LibraryMOD.GetFieldName( IsAuthenticatedFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.CreationUserID = 0;
}
else
{
myEmployeeQualifications.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.LastUpdateUserID = 0;
}
else
{
myEmployeeQualifications.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myEmployeeQualifications.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myEmployeeQualifications.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myEmployeeQualifications);
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
public List< EmployeeQualifications > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<EmployeeQualifications> results = new List<EmployeeQualifications>();
try
{
//Default Value
EmployeeQualifications myEmployeeQualifications= new EmployeeQualifications();
if (isDeafaultIncluded) 
 {
//Change the code here
 myEmployeeQualifications.EmployeeID = -1;
 myEmployeeQualifications.QualificationID = -1 ;
results.Add(myEmployeeQualifications);
 }
while (reader.Read())
{
myEmployeeQualifications = new EmployeeQualifications();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.EmployeeID = 0;
}
else
{
myEmployeeQualifications.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(QualificationIDFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.QualificationID = 0;
}
else
{
myEmployeeQualifications.QualificationID = int.Parse(reader[LibraryMOD.GetFieldName( QualificationIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(QualificationTypeFN)].Equals(DBNull.Value))
{
myEmployeeQualifications.QualificationType = 0;
}
else
{
myEmployeeQualifications.QualificationType = int.Parse(reader[LibraryMOD.GetFieldName( QualificationTypeFN) ].ToString());
}
 results.Add(myEmployeeQualifications);
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
public int UpdateEmployeeQualifications(InitializeModule.EnumCampus Campus, int iMode, int EmployeeID, int QualificationID, int QualificationType, int CertificateID, string ResearchTitle, int MainMajorID, int SubMajorID, int GraduationYear, string Startdate, string GraduationDate, int StudyYears, int InstituteCountry, string InstituteName, int StudyLanguageID, int StudyTypeID, double   Average, int GradeID, string CoursesTaken, int IsAuthenticated, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EmployeeQualifications theEmployeeQualifications = new EmployeeQualifications();
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
Cmd.Parameters.Add(new SqlParameter("@EmployeeID",EmployeeID));
Cmd.Parameters.Add(new SqlParameter("@QualificationID",QualificationID));
Cmd.Parameters.Add(new SqlParameter("@QualificationType",QualificationType));
Cmd.Parameters.Add(new SqlParameter("@CertificateID",CertificateID));
Cmd.Parameters.Add(new SqlParameter("@ResearchTitle", ResearchTitle));
Cmd.Parameters.Add(new SqlParameter("@MainMajorID",MainMajorID));
Cmd.Parameters.Add(new SqlParameter("@SubMajorID",SubMajorID));
Cmd.Parameters.Add(new SqlParameter("@GraduationYear",GraduationYear));
Cmd.Parameters.Add(new SqlParameter("@Startdate",Startdate));
Cmd.Parameters.Add(new SqlParameter("@GraduationDate",GraduationDate));
Cmd.Parameters.Add(new SqlParameter("@StudyYears",StudyYears));
Cmd.Parameters.Add(new SqlParameter("@InstituteCountry",InstituteCountry));
Cmd.Parameters.Add(new SqlParameter("@InstituteName",InstituteName));
Cmd.Parameters.Add(new SqlParameter("@StudyLanguageID",StudyLanguageID));
Cmd.Parameters.Add(new SqlParameter("@StudyTypeID",StudyTypeID));
Cmd.Parameters.Add(new SqlParameter("@Average",Average));
Cmd.Parameters.Add(new SqlParameter("@GradeID",GradeID));
Cmd.Parameters.Add(new SqlParameter("@CoursesTaken",CoursesTaken));
Cmd.Parameters.Add(new SqlParameter("@IsAuthenticated",IsAuthenticated));
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
public int DeleteEmployeeQualifications(InitializeModule.EnumCampus Campus,string EmployeeID,string QualificationID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID ));
Cmd.Parameters.Add(new SqlParameter("@QualificationID", QualificationID ));
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
DataTable dt = new DataTable("EmployeeQualifications");
DataView dv = new DataView();
List<EmployeeQualifications> myEmployeeQualificationss = new List<EmployeeQualifications>();
try
{
myEmployeeQualificationss = GetEmployeeQualifications(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("EmployeeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("QualificationID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("QualificationType", Type.GetType("int"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myEmployeeQualificationss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myEmployeeQualificationss[i].EmployeeID;
  dr[2] = myEmployeeQualificationss[i].QualificationID;
  dr[3] = myEmployeeQualificationss[i].QualificationType;
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
myEmployeeQualificationss.Clear();
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
sSQL += EmployeeIDFN;
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
public class EmployeeQualificationsCls : EmployeeQualificationsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daEmployeeQualifications;
private DataSet m_dsEmployeeQualifications;
public DataRow EmployeeQualificationsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsEmployeeQualifications
{
get { return m_dsEmployeeQualifications ; }
set { m_dsEmployeeQualifications = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EmployeeQualificationsCls()
{
try
{
dsEmployeeQualifications= new DataSet();

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
public virtual SqlDataAdapter GetEmployeeQualificationsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daEmployeeQualifications = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daEmployeeQualifications);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeQualifications.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeQualifications;
}
public virtual SqlDataAdapter GetEmployeeQualificationsDataAdapter(SqlConnection con)  
{
try
{
daEmployeeQualifications = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeQualifications.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdEmployeeQualifications;
cmdEmployeeQualifications = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, "EmployeeID" );
//'cmdRolePermission.Parameters.Add("@QualificationID", SqlDbType.Int, 4, "QualificationID" );
daEmployeeQualifications.SelectCommand = cmdEmployeeQualifications;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdEmployeeQualifications = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdEmployeeQualifications.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeQualifications.Parameters.Add("@QualificationID", SqlDbType.Int,4, LibraryMOD.GetFieldName(QualificationIDFN));
cmdEmployeeQualifications.Parameters.Add("@QualificationType", SqlDbType.Int,4, LibraryMOD.GetFieldName(QualificationTypeFN));
cmdEmployeeQualifications.Parameters.Add("@CertificateID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CertificateIDFN));
cmdEmployeeQualifications.Parameters.Add("@MainMajorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MainMajorIDFN));
cmdEmployeeQualifications.Parameters.Add("@SubMajorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SubMajorIDFN));
cmdEmployeeQualifications.Parameters.Add("@GraduationYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(GraduationYearFN));
cmdEmployeeQualifications.Parameters.Add("@Startdate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(StartdateFN));
cmdEmployeeQualifications.Parameters.Add("@GraduationDate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(GraduationDateFN));
cmdEmployeeQualifications.Parameters.Add("@StudyYears", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudyYearsFN));
cmdEmployeeQualifications.Parameters.Add("@InstituteCountry", SqlDbType.Int,4, LibraryMOD.GetFieldName(InstituteCountryFN));
cmdEmployeeQualifications.Parameters.Add("@InstituteName", SqlDbType.NVarChar,160, LibraryMOD.GetFieldName(InstituteNameFN));
cmdEmployeeQualifications.Parameters.Add("@StudyLanguageID", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudyLanguageIDFN));
cmdEmployeeQualifications.Parameters.Add("@StudyTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudyTypeIDFN));
cmdEmployeeQualifications.Parameters.Add("@Average", SqlDbType.Decimal, 10, LibraryMOD.GetFieldName(AverageFN));
cmdEmployeeQualifications.Parameters.Add("@GradeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeIDFN));
cmdEmployeeQualifications.Parameters.Add("@CoursesTaken", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(CoursesTakenFN));
cmdEmployeeQualifications.Parameters.Add("@IsAuthenticated", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsAuthenticatedFN));
cmdEmployeeQualifications.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployeeQualifications.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployeeQualifications.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployeeQualifications.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployeeQualifications.Parameters.Add("@PCName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployeeQualifications.Parameters.Add("@NetUserName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdEmployeeQualifications.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeQualifications.Parameters.Add("@QualificationID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(QualificationIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daEmployeeQualifications.UpdateCommand = cmdEmployeeQualifications;
daEmployeeQualifications.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdEmployeeQualifications = new SqlCommand(GetInsertCommand(), con);
cmdEmployeeQualifications.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeQualifications.Parameters.Add("@QualificationID", SqlDbType.Int,4, LibraryMOD.GetFieldName(QualificationIDFN));
cmdEmployeeQualifications.Parameters.Add("@QualificationType", SqlDbType.Int,4, LibraryMOD.GetFieldName(QualificationTypeFN));
cmdEmployeeQualifications.Parameters.Add("@CertificateID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CertificateIDFN));
cmdEmployeeQualifications.Parameters.Add("@MainMajorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MainMajorIDFN));
cmdEmployeeQualifications.Parameters.Add("@SubMajorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SubMajorIDFN));
cmdEmployeeQualifications.Parameters.Add("@GraduationYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(GraduationYearFN));
cmdEmployeeQualifications.Parameters.Add("@Startdate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(StartdateFN));
cmdEmployeeQualifications.Parameters.Add("@GraduationDate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(GraduationDateFN));
cmdEmployeeQualifications.Parameters.Add("@StudyYears", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudyYearsFN));
cmdEmployeeQualifications.Parameters.Add("@InstituteCountry", SqlDbType.Int,4, LibraryMOD.GetFieldName(InstituteCountryFN));
cmdEmployeeQualifications.Parameters.Add("@InstituteName", SqlDbType.NVarChar,160, LibraryMOD.GetFieldName(InstituteNameFN));
cmdEmployeeQualifications.Parameters.Add("@StudyLanguageID", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudyLanguageIDFN));
cmdEmployeeQualifications.Parameters.Add("@StudyTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudyTypeIDFN));
cmdEmployeeQualifications.Parameters.Add("@Average", SqlDbType.Decimal, 10, LibraryMOD.GetFieldName(AverageFN));
cmdEmployeeQualifications.Parameters.Add("@GradeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeIDFN));
cmdEmployeeQualifications.Parameters.Add("@CoursesTaken", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(CoursesTakenFN));
cmdEmployeeQualifications.Parameters.Add("@IsAuthenticated", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsAuthenticatedFN));
cmdEmployeeQualifications.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployeeQualifications.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployeeQualifications.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployeeQualifications.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployeeQualifications.Parameters.Add("@PCName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployeeQualifications.Parameters.Add("@NetUserName", SqlDbType.VarChar,16, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daEmployeeQualifications.InsertCommand =cmdEmployeeQualifications;
daEmployeeQualifications.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdEmployeeQualifications = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdEmployeeQualifications.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeQualifications.Parameters.Add("@QualificationID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(QualificationIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daEmployeeQualifications.DeleteCommand =cmdEmployeeQualifications;
daEmployeeQualifications.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daEmployeeQualifications.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeQualifications;
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
dr = dsEmployeeQualifications.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
dr[LibraryMOD.GetFieldName(QualificationIDFN)]=QualificationID;
dr[LibraryMOD.GetFieldName(QualificationTypeFN)]=QualificationType;
dr[LibraryMOD.GetFieldName(CertificateIDFN)]=CertificateID;
dr[LibraryMOD.GetFieldName(MainMajorIDFN)]=MainMajorID;
dr[LibraryMOD.GetFieldName(SubMajorIDFN)]=SubMajorID;
dr[LibraryMOD.GetFieldName(GraduationYearFN)]=GraduationYear;
dr[LibraryMOD.GetFieldName(StartdateFN)]=Startdate;
dr[LibraryMOD.GetFieldName(GraduationDateFN)]=GraduationDate;
dr[LibraryMOD.GetFieldName(StudyYearsFN)]=StudyYears;
dr[LibraryMOD.GetFieldName(InstituteCountryFN)]=InstituteCountry;
dr[LibraryMOD.GetFieldName(InstituteNameFN)]=InstituteName;
dr[LibraryMOD.GetFieldName(StudyLanguageIDFN)]=StudyLanguageID;
dr[LibraryMOD.GetFieldName(StudyTypeIDFN)]=StudyTypeID;
dr[LibraryMOD.GetFieldName(AverageFN)]=Average;
dr[LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
dr[LibraryMOD.GetFieldName(CoursesTakenFN)]=CoursesTaken;
dr[LibraryMOD.GetFieldName(IsAuthenticatedFN)]=IsAuthenticated;
dsEmployeeQualifications.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsEmployeeQualifications.Tables[TableName].Select(LibraryMOD.GetFieldName(EmployeeIDFN)  + "=" + EmployeeID  + " AND " + LibraryMOD.GetFieldName(QualificationIDFN) + "=" + QualificationID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
drAry[0][LibraryMOD.GetFieldName(QualificationIDFN)]=QualificationID;
drAry[0][LibraryMOD.GetFieldName(QualificationTypeFN)]=QualificationType;
drAry[0][LibraryMOD.GetFieldName(CertificateIDFN)]=CertificateID;
drAry[0][LibraryMOD.GetFieldName(MainMajorIDFN)]=MainMajorID;
drAry[0][LibraryMOD.GetFieldName(SubMajorIDFN)]=SubMajorID;
drAry[0][LibraryMOD.GetFieldName(GraduationYearFN)]=GraduationYear;
drAry[0][LibraryMOD.GetFieldName(StartdateFN)]=Startdate;
drAry[0][LibraryMOD.GetFieldName(GraduationDateFN)]=GraduationDate;
drAry[0][LibraryMOD.GetFieldName(StudyYearsFN)]=StudyYears;
drAry[0][LibraryMOD.GetFieldName(InstituteCountryFN)]=InstituteCountry;
drAry[0][LibraryMOD.GetFieldName(InstituteNameFN)]=InstituteName;
drAry[0][LibraryMOD.GetFieldName(StudyLanguageIDFN)]=StudyLanguageID;
drAry[0][LibraryMOD.GetFieldName(StudyTypeIDFN)]=StudyTypeID;
drAry[0][LibraryMOD.GetFieldName(AverageFN)]=Average;
drAry[0][LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
drAry[0][LibraryMOD.GetFieldName(CoursesTakenFN)]=CoursesTaken;
drAry[0][LibraryMOD.GetFieldName(IsAuthenticatedFN)]=IsAuthenticated;
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
public int CommitEmployeeQualifications()  
{
//CommitEmployeeQualifications= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daEmployeeQualifications.Update(dsEmployeeQualifications, TableName);
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
FindInMultiPKey(EmployeeID,QualificationID);
if (( EmployeeQualificationsDataRow != null)) 
{
EmployeeQualificationsDataRow.Delete();
CommitEmployeeQualifications();
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
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)]== System.DBNull.Value)
{
  EmployeeID=0;
}
else
{
  EmployeeID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(QualificationIDFN)]== System.DBNull.Value)
{
  QualificationID=0;
}
else
{
  QualificationID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(QualificationIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(QualificationTypeFN)]== System.DBNull.Value)
{
  QualificationType=0;
}
else
{
  QualificationType = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(QualificationTypeFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CertificateIDFN)]== System.DBNull.Value)
{
  CertificateID=0;
}
else
{
  CertificateID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CertificateIDFN)];
}

if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(ResearchTitleFN)] == System.DBNull.Value)
{
    ResearchTitle = "";
}
else
{
    ResearchTitle = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(ResearchTitleFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(MainMajorIDFN)]== System.DBNull.Value)
{
  MainMajorID=0;
}
else
{
  MainMajorID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(MainMajorIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(SubMajorIDFN)]== System.DBNull.Value)
{
  SubMajorID=0;
}
else
{
  SubMajorID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(SubMajorIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(GraduationYearFN)]== System.DBNull.Value)
{
  GraduationYear=0;
}
else
{
  GraduationYear = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(GraduationYearFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StartdateFN)]== System.DBNull.Value)
{
  Startdate="";
}
else
{
  Startdate = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StartdateFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(GraduationDateFN)]== System.DBNull.Value)
{
  GraduationDate="";
}
else
{
  GraduationDate = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(GraduationDateFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StudyYearsFN)]== System.DBNull.Value)
{
  StudyYears=0;
}
else
{
  StudyYears = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StudyYearsFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(InstituteCountryFN)]== System.DBNull.Value)
{
  InstituteCountry=0;
}
else
{
  InstituteCountry = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(InstituteCountryFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(InstituteNameFN)]== System.DBNull.Value)
{
  InstituteName="";
}
else
{
  InstituteName = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(InstituteNameFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StudyLanguageIDFN)]== System.DBNull.Value)
{
  StudyLanguageID=0;
}
else
{
  StudyLanguageID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StudyLanguageIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StudyTypeIDFN)]== System.DBNull.Value)
{
  StudyTypeID=0;
}
else
{
  StudyTypeID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(StudyTypeIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(AverageFN)]== System.DBNull.Value)
{
  Average="";
}
else
{
  Average = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(AverageFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(GradeIDFN)]== System.DBNull.Value)
{
  GradeID=0;
}
else
{
  GradeID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(GradeIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CoursesTakenFN)]== System.DBNull.Value)
{
  CoursesTaken="";
}
else
{
  CoursesTaken = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CoursesTakenFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(IsAuthenticatedFN)]== System.DBNull.Value)
{
  IsAuthenticated=0;
}
else
{
  IsAuthenticated = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(IsAuthenticatedFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)EmployeeQualificationsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKEmployeeID,int PKQualificationID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKEmployeeID;
findTheseVals[1] = PKQualificationID;
EmployeeQualificationsDataRow = dsEmployeeQualifications.Tables[TableName].Rows.Find(findTheseVals);
if  ((EmployeeQualificationsDataRow !=null)) 
{
lngCurRow = dsEmployeeQualifications.Tables[TableName].Rows.IndexOf(EmployeeQualificationsDataRow);
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
  lngCurRow = dsEmployeeQualifications.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsEmployeeQualifications.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsEmployeeQualifications.Tables[TableName].Rows.Count > 0) 
{
  EmployeeQualificationsDataRow = dsEmployeeQualifications.Tables[TableName].Rows[lngCurRow];
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
daEmployeeQualifications.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeQualifications.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daEmployeeQualifications.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeQualifications.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
