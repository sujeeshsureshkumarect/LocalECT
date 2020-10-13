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

public class Student_Qualifications
{
//Creation Date: 11/04/2010 12:21 PM
//Programmer Name : Bahaa Addin Ghaleb Najem
//-----Decleration --------------
#region "Decleration"
private int m_lngSerial; 
private int m_byteQualification; 
private int m_intCertificate; 
private int m_intMajor; 
private int m_intMinor; 
private int m_intGraduationYear; 
private int m_byteYears; 
private int m_byteInstituteCountry; 
private int m_byteStudyLanguage; 
private int m_byteStudyType; 
private double m_sngGrade; 
private int m_byteGrade; 
private string m_strCertificateSource; 
private int m_byteLevel; 
private int m_intLecturer;
private DateTime m_dateENG;

private int m_VerifiedByAdmission;
private string m_AdmissionComments;
private int m_AdmissionUserID;
private DateTime m_AdmissionUpdateDate;
private int m_VerifiedByregistrar;
private string m_RegistrarComments;
private int m_RegistrarUserID;
private DateTime m_RegistrarUpdateDate;

private int m_VerifiedByDirector;
private string m_DirectorComments;
private int m_DirectorUserID;
private DateTime m_DirectorUpdateDate;

private int m_HS_InstitutionType;
private int m_HS_InstitutionCity;
private int m_G12_Stream;
private int m_ScoreOfMath;
private int m_ScoreOfChemistry;
private int m_ScoreOfBiology;
private int m_ScoreOfPhysics;

private string m_IESOL_Grade;
private int m_ExamCenterID;

private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int lngSerial
{
get { return  m_lngSerial; }
set {m_lngSerial  = value ; }
}
public int byteQualification
{
get { return  m_byteQualification; }
set {m_byteQualification  = value ; }
}
public int intCertificate
{
get { return  m_intCertificate; }
set {m_intCertificate  = value ; }
}
public int intMajor
{
get { return  m_intMajor; }
set {m_intMajor  = value ; }
}
public int intMinor
{
get { return  m_intMinor; }
set {m_intMinor  = value ; }
}
public int intGraduationYear
{
get { return  m_intGraduationYear; }
set {m_intGraduationYear  = value ; }
}
public int byteYears
{
get { return  m_byteYears; }
set {m_byteYears  = value ; }
}
public int byteInstituteCountry
{
get { return  m_byteInstituteCountry; }
set {m_byteInstituteCountry  = value ; }
}
public int byteStudyLanguage
{
get { return  m_byteStudyLanguage; }
set {m_byteStudyLanguage  = value ; }
}
public int byteStudyType
{
get { return  m_byteStudyType; }
set {m_byteStudyType  = value ; }
}
public double sngGrade
{
get { return  m_sngGrade; }
set {m_sngGrade  = value ; }
}
public int byteGrade
{
get { return  m_byteGrade; }
set {m_byteGrade  = value ; }
}
public string strCertificateSource
{
get { return  m_strCertificateSource; }
set {m_strCertificateSource  = value ; }
}
public int byteLevel
{
get { return  m_byteLevel; }
set {m_byteLevel  = value ; }
}
public int intLecturer
{
get { return  m_intLecturer; }
set {m_intLecturer  = value ; }
}

public DateTime dateENG
{
    get { return m_dateENG; }
    set { m_dateENG = value; }
}
public int VerifiedByAdmission
{
    get { return m_VerifiedByAdmission; }
    set { m_VerifiedByAdmission = value; }
}
public string AdmissionComments
{
    get { return m_AdmissionComments; }
    set { m_AdmissionComments = value; }
}
public int AdmissionUserID
{
    get { return m_AdmissionUserID; }
    set { m_AdmissionUserID = value; }
}
public DateTime AdmissionUpdateDate
{
    get { return m_AdmissionUpdateDate; }
    set { m_AdmissionUpdateDate = value; }
}

public int HS_InstitutionType
{
    get { return m_HS_InstitutionType; }
    set { m_HS_InstitutionType = value; }
}
public int HS_InstitutionCity
{
    get { return m_HS_InstitutionCity; }
    set { m_HS_InstitutionCity = value; }
}

public int G12_Stream
{
    get { return m_G12_Stream; }
    set { m_G12_Stream = value; }
}
public int ScoreOfMath
{
    get { return m_ScoreOfMath; }
    set { m_ScoreOfMath = value; }
}

public int ScoreOfChemistry
{
    get { return m_ScoreOfChemistry; }
    set { m_ScoreOfChemistry = value; }
}
public int ScoreOfBiology
{
    get { return m_ScoreOfBiology; }
    set { m_ScoreOfBiology = value; }
}
public int ScoreOfPhysics
{
    get { return m_ScoreOfPhysics; }
    set { m_ScoreOfPhysics = value; }
}
public int ExamCenterID
{
    get { return m_ExamCenterID; }
    set { m_ExamCenterID = value; }
}

public string IESOL_Grade
{
    get { return m_IESOL_Grade; }
    set { m_IESOL_Grade = value; }
}

public int VerifiedByregistrar
{
    get { return m_VerifiedByregistrar; }
    set { m_VerifiedByregistrar = value; }
}
public string RegistrarComments
{
    get { return m_RegistrarComments; }
    set { m_RegistrarComments = value; }
}
public int RegistrarUserID
{
    get { return m_RegistrarUserID; }
    set { m_RegistrarUserID = value; }
}
public DateTime RegistrarUpdateDate
{
    get { return m_RegistrarUpdateDate; }
    set { m_RegistrarUpdateDate = value; }
}
public int VerifiedByDirector
{
    get { return m_VerifiedByDirector; }
    set { m_VerifiedByDirector = value; }
}

public string DirectorComments
{
    get { return m_DirectorComments; }
    set { m_DirectorComments = value; }
}

public int DirectorUserID
{
    get { return m_DirectorUserID; }
    set { m_DirectorUserID = value; }
}

public DateTime DirectorUpdateDate
{
    get { return m_DirectorUpdateDate; }
    set { m_DirectorUpdateDate = value; }
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
public Student_Qualifications()
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
public class Student_QualificationsDAL : Student_Qualifications
{
#region "Decleration"
private string m_TableName;
private string m_lngSerialFN ;
private string m_byteQualificationFN ;
private string m_intCertificateFN ;
private string m_intMajorFN ;
private string m_intMinorFN ;
private string m_intGraduationYearFN ;
private string m_byteYearsFN ;
private string m_byteInstituteCountryFN ;
private string m_byteStudyLanguageFN ;
private string m_byteStudyTypeFN ;
private string m_sngGradeFN ;
private string m_byteGradeFN ;
private string m_strCertificateSourceFN ;
private string m_byteLevelFN ;
private string m_intLecturerFN ;
private string m_dateENGFN;

private string m_HS_InstitutionTypeFN;
private string m_HS_InstitutionCityFN;
private string m_G12_StreamFN;
private string m_ScoreOfMathFN;
private string m_ScoreOfChemistryFN;
private string m_ScoreOfBiologyFN;
private string m_ScoreOfPhysicsFN;

private string m_IESOL_GradeFN;
private string m_ExamCenterIDFN;

private string m_VerifiedByAdmissionFN;
private string m_AdmissionCommentsFN;
private string m_AdmissionUserIDFN;
private string m_AdmissionUpdateDateFN;
private string m_VerifiedByregistrarFN;
private string m_RegistrarCommentsFN;
private string m_RegistrarUserIDFN;
private string m_RegistrarUpdateDateFN;
private string m_VerifiedByDirectorFN;
private string m_DirectorCommentsFN;
private string m_DirectorUserIDFN;
private string m_DirectorUpdateDateFN;

private string m_strUserCreateFN;
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
public string lngSerialFN 
{
get { return  m_lngSerialFN; }
set {m_lngSerialFN  = value ; }
}
public string byteQualificationFN 
{
get { return  m_byteQualificationFN; }
set {m_byteQualificationFN  = value ; }
}
public string intCertificateFN 
{
get { return  m_intCertificateFN; }
set {m_intCertificateFN  = value ; }
}
public string intMajorFN 
{
get { return  m_intMajorFN; }
set {m_intMajorFN  = value ; }
}
public string intMinorFN 
{
get { return  m_intMinorFN; }
set {m_intMinorFN  = value ; }
}
public string intGraduationYearFN 
{
get { return  m_intGraduationYearFN; }
set {m_intGraduationYearFN  = value ; }
}
public string byteYearsFN 
{
get { return  m_byteYearsFN; }
set {m_byteYearsFN  = value ; }
}
public string byteInstituteCountryFN 
{
get { return  m_byteInstituteCountryFN; }
set {m_byteInstituteCountryFN  = value ; }
}
public string byteStudyLanguageFN 
{
get { return  m_byteStudyLanguageFN; }
set {m_byteStudyLanguageFN  = value ; }
}
public string byteStudyTypeFN 
{
get { return  m_byteStudyTypeFN; }
set {m_byteStudyTypeFN  = value ; }
}
public string sngGradeFN 
{
get { return  m_sngGradeFN; }
set {m_sngGradeFN  = value ; }
}
public string byteGradeFN 
{
get { return  m_byteGradeFN; }
set {m_byteGradeFN  = value ; }
}
public string strCertificateSourceFN 
{
get { return  m_strCertificateSourceFN; }
set {m_strCertificateSourceFN  = value ; }
}
public string byteLevelFN 
{
get { return  m_byteLevelFN; }
set {m_byteLevelFN  = value ; }
}
public string intLecturerFN 
{
get { return  m_intLecturerFN; }
set {m_intLecturerFN  = value ; }
}
public string dateENGFN 
{
    get { return m_dateENGFN; }
    set { m_dateENGFN = value; }
}   

public string VerifiedByAdmissionFN
{
    get { return m_VerifiedByAdmissionFN; }
    set { m_VerifiedByAdmissionFN = value; }
}
public string AdmissionCommentsFN
{
    get { return m_AdmissionCommentsFN; }
    set { m_AdmissionCommentsFN = value; }
}
public string AdmissionUserIDFN
{
    get { return m_AdmissionUserIDFN; }
    set { m_AdmissionUserIDFN = value; }
}

public string AdmissionUpdateDateFN
{
    get { return m_AdmissionUpdateDateFN; }
    set { m_AdmissionUpdateDateFN = value; }
}

public string HS_InstitutionTypeFN
{
    get { return m_HS_InstitutionTypeFN; }
    set { m_HS_InstitutionTypeFN = value; }
}
public string HS_InstitutionCityFN
{
    get { return m_HS_InstitutionCityFN; }
    set { m_HS_InstitutionCityFN = value; }
}
public string G12_StreamFN
{
    get { return m_G12_StreamFN; }
    set { m_G12_StreamFN = value; }
}
public string ScoreOfMathFN
{
    get { return m_ScoreOfMathFN; }
    set { m_ScoreOfMathFN = value; }
}

public string ScoreOfChemistryFN
{
    get { return m_ScoreOfChemistryFN; }
    set { m_ScoreOfChemistryFN = value; }
}
public string ScoreOfBiologyFN
{
    get { return m_ScoreOfBiologyFN; }
    set { m_ScoreOfBiologyFN = value; }
}
public string ScoreOfPhysicsFN
{
    get { return m_ScoreOfPhysicsFN; }
    set { m_ScoreOfPhysicsFN = value; }
}
public string IESOL_GradeFN
{
    get { return m_IESOL_GradeFN; }
    set { m_IESOL_GradeFN = value; }
}
public string ExamCenterIDFN
{
    get { return m_ExamCenterIDFN; }
    set { m_ExamCenterIDFN = value; }
}

public string VerifiedByregistrarFN
{
    get { return m_VerifiedByregistrarFN; }
    set { m_VerifiedByregistrarFN = value; }
}
public string RegistrarCommentsFN
{
    get { return m_RegistrarCommentsFN; }
    set { m_RegistrarCommentsFN = value; }
}
public string RegistrarUserIDFN
{
    get { return m_RegistrarUserIDFN; }
    set { m_RegistrarUserIDFN = value; }
}
public string RegistrarUpdateDateFN
{
    get { return m_RegistrarUpdateDateFN; }
    set { m_RegistrarUpdateDateFN = value; }
}
public string VerifiedByDirectorFN
{
    get { return m_VerifiedByDirectorFN; }
    set { m_VerifiedByDirectorFN = value; }
}
public string DirectorCommentsFN
{
    get { return m_DirectorCommentsFN; }
    set { m_DirectorCommentsFN = value; }
}
public string DirectorUserIDFN
{
    get { return m_DirectorUserIDFN; }
    set { m_DirectorUserIDFN = value; }
}
public string DirectorUpdateDateFN
{
    get { return m_DirectorUpdateDateFN; }
    set { m_DirectorUpdateDateFN = value; }
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
public Student_QualificationsDAL()
{
try
{
    this.TableName = "Reg_Student_Qualifications";
this.lngSerialFN = m_TableName + ".lngSerial";
this.byteQualificationFN = m_TableName + ".byteQualification";
this.intCertificateFN = m_TableName + ".intCertificate";
this.intMajorFN = m_TableName + ".intMajor";
this.intMinorFN = m_TableName + ".intMinor";
this.intGraduationYearFN = m_TableName + ".intGraduationYear";
this.byteYearsFN = m_TableName + ".byteYears";
this.byteInstituteCountryFN = m_TableName + ".byteInstituteCountry";
this.byteStudyLanguageFN = m_TableName + ".byteStudyLanguage";
this.byteStudyTypeFN = m_TableName + ".byteStudyType";
this.sngGradeFN = m_TableName + ".sngGrade";
this.byteGradeFN = m_TableName + ".byteGrade";
this.strCertificateSourceFN = m_TableName + ".strCertificateSource";
this.byteLevelFN = m_TableName + ".byteLevel";
this.intLecturerFN = m_TableName + ".intLecturer";
this.dateENGFN = m_TableName + ".dateENG";

this.VerifiedByAdmissionFN = m_TableName + ".VerifiedByAdmission";
this.AdmissionCommentsFN = m_TableName + ".AdmissionComments";
this.AdmissionUserIDFN = m_TableName + ".AdmissionUserID";
this.AdmissionUpdateDateFN = m_TableName + ".AdmissionUpdateDate";

this.VerifiedByregistrarFN = m_TableName + ".VerifiedByregistrar";
this.RegistrarCommentsFN = m_TableName + ".RegistrarComments";
this.RegistrarUserIDFN = m_TableName + ".RegistrarUserID";
this.RegistrarUpdateDateFN = m_TableName + ".RegistrarUpdateDate";

this.VerifiedByDirectorFN = m_TableName + ".VerifiedByDirector";
this.DirectorCommentsFN = m_TableName + ".DirectorComments";
this.DirectorUserIDFN = m_TableName + ".DirectorUserID";
this.DirectorUpdateDateFN = m_TableName + ".DirectorUpdateDate";

this.HS_InstitutionTypeFN = m_TableName + ".HS_InstitutionType";
this.HS_InstitutionCityFN = m_TableName + ".HS_InstitutionCity";
this.G12_StreamFN = m_TableName + ".G12_Stream";
this.ScoreOfMathFN = m_TableName + ".ScoreOfMath";
this.ScoreOfChemistryFN = m_TableName + ".ScoreOfChemistry";
this.ScoreOfBiologyFN = m_TableName + ".ScoreOfBiology";
this.ScoreOfPhysicsFN = m_TableName + ".ScoreOfPhysics";

this.IESOL_GradeFN = m_TableName + ".IESOL_Grade";
this.ExamCenterIDFN = m_TableName + ".ExamCenterID";

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
sSQL +=lngSerialFN;
sSQL += " , " + byteQualificationFN;
sSQL += " , " + intCertificateFN;
sSQL += " , " + intMajorFN;
sSQL += " , " + intMinorFN;
sSQL += " , " + intGraduationYearFN;
sSQL += " , " + byteYearsFN;
sSQL += " , " + byteInstituteCountryFN;
sSQL += " , " + byteStudyLanguageFN;
sSQL += " , " + byteStudyTypeFN;
sSQL += " , " + sngGradeFN;
sSQL += " , " + byteGradeFN;
sSQL += " , " + strCertificateSourceFN;
sSQL += " , " + byteLevelFN;
sSQL += " , " + intLecturerFN;
sSQL += " , " + dateENGFN;
sSQL += " , " + VerifiedByAdmissionFN;
sSQL += " , " + AdmissionCommentsFN;
sSQL += " , " + AdmissionUserIDFN;
sSQL += " , " + AdmissionUpdateDateFN;
sSQL += " , " + VerifiedByregistrarFN;
sSQL += " , " + RegistrarCommentsFN;
sSQL += " , " + RegistrarUserIDFN;
sSQL += " , " + RegistrarUpdateDateFN;

sSQL += " , " + VerifiedByDirectorFN;
sSQL += " , " + DirectorCommentsFN;
sSQL += " , " + DirectorUserIDFN;
sSQL += " , " + DirectorUpdateDateFN;

sSQL += " , " + HS_InstitutionTypeFN;
sSQL += " , " + HS_InstitutionCityFN;
sSQL += " , " + G12_StreamFN;
sSQL += " , " + ScoreOfMathFN;
sSQL += " , " + ScoreOfChemistryFN ;
sSQL += " , " + ScoreOfBiologyFN ;
sSQL += " , " + ScoreOfPhysicsFN ;
sSQL += " , " + IESOL_GradeFN;
sSQL += " , " + ExamCenterIDFN ;

sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE 1=1 " ;
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
sSQL +=lngSerialFN;
sSQL += " , " + byteQualificationFN;
sSQL += " , " + intCertificateFN;
sSQL += " , " + intMajorFN;
sSQL += " , " + intMinorFN;
sSQL += " , " + intGraduationYearFN;
sSQL += " , " + byteYearsFN;
sSQL += " , " + byteInstituteCountryFN;
sSQL += " , " + byteStudyLanguageFN;
sSQL += " , " + byteStudyTypeFN;
sSQL += " , " + sngGradeFN;
sSQL += " , " + byteGradeFN;
sSQL += " , " + strCertificateSourceFN;
sSQL += " , " + byteLevelFN;
sSQL += " , " + intLecturerFN;
sSQL += " , " + dateENGFN;
sSQL += " , " + VerifiedByAdmissionFN;
sSQL += " , " + AdmissionCommentsFN;
sSQL += " , " + AdmissionUserIDFN;
sSQL += " , " + AdmissionUpdateDateFN;
sSQL += " , " + VerifiedByregistrarFN;
sSQL += " , " + RegistrarCommentsFN;
sSQL += " , " + RegistrarUserIDFN;
sSQL += " , " + RegistrarUpdateDateFN;

sSQL += " , " + VerifiedByDirectorFN;
sSQL += " , " + DirectorCommentsFN;
sSQL += " , " + DirectorUserIDFN;
sSQL += " , " + DirectorUpdateDateFN;

sSQL += " , " + HS_InstitutionTypeFN;
sSQL += " , " + HS_InstitutionCityFN;
sSQL += " , " + G12_StreamFN;
sSQL += " , " + ScoreOfMathFN;
sSQL += " , " + ScoreOfChemistryFN;
sSQL += " , " + ScoreOfBiologyFN;
sSQL += " , " + ScoreOfPhysicsFN;
sSQL += " , " + IESOL_GradeFN;
sSQL += " , " + ExamCenterIDFN;

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
sSQL += LibraryMOD.GetFieldName(lngSerialFN) + "=@lngSerial";
sSQL += " , " + LibraryMOD.GetFieldName(byteQualificationFN) + "=@byteQualification";
sSQL += " , " + LibraryMOD.GetFieldName(intCertificateFN) + "=@intCertificate";
sSQL += " , " + LibraryMOD.GetFieldName(intMajorFN) + "=@intMajor";
sSQL += " , " + LibraryMOD.GetFieldName(intMinorFN) + "=@intMinor";
sSQL += " , " + LibraryMOD.GetFieldName(intGraduationYearFN) + "=@intGraduationYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteYearsFN) + "=@byteYears";
sSQL += " , " + LibraryMOD.GetFieldName(byteInstituteCountryFN) + "=@byteInstituteCountry";
sSQL += " , " + LibraryMOD.GetFieldName(byteStudyLanguageFN) + "=@byteStudyLanguage";
sSQL += " , " + LibraryMOD.GetFieldName(byteStudyTypeFN) + "=@byteStudyType";
sSQL += " , " + LibraryMOD.GetFieldName(sngGradeFN) + "=@sngGrade";
sSQL += " , " + LibraryMOD.GetFieldName(byteGradeFN) + "=@byteGrade";
sSQL += " , " + LibraryMOD.GetFieldName(strCertificateSourceFN) + "=@strCertificateSource";
sSQL += " , " + LibraryMOD.GetFieldName(byteLevelFN) + "=@byteLevel";
sSQL += " , " + LibraryMOD.GetFieldName(intLecturerFN) + "=@intLecturer";
sSQL += " , " + LibraryMOD.GetFieldName(dateENGFN) + "=@dateENG";

sSQL += " , " + LibraryMOD.GetFieldName(VerifiedByAdmissionFN) + "=@VerifiedByAdmission";
sSQL += " , " + LibraryMOD.GetFieldName(AdmissionCommentsFN) + "=@AdmissionComments";
sSQL += " , " + LibraryMOD.GetFieldName(AdmissionUserIDFN) + "=@AdmissionUserID";
sSQL += " , " + LibraryMOD.GetFieldName(AdmissionUpdateDateFN) + "=@AdmissionUpdateDate";

sSQL += " , " + LibraryMOD.GetFieldName(VerifiedByregistrarFN) + "=@VerifiedByregistrar";
sSQL += " , " + LibraryMOD.GetFieldName(RegistrarCommentsFN) + "=@RegistrarComments";
sSQL += " , " + LibraryMOD.GetFieldName(RegistrarUserIDFN) + "=@RegistrarUserID";
sSQL += " , " + LibraryMOD.GetFieldName(RegistrarUpdateDateFN) + "=@RegistrarUpdateDate";

sSQL += " , " + LibraryMOD.GetFieldName(VerifiedByDirectorFN) + "=@VerifiedByDirector";
sSQL += " , " + LibraryMOD.GetFieldName(DirectorCommentsFN) + "=@DirectorComments";
sSQL += " , " + LibraryMOD.GetFieldName(DirectorUserIDFN) + "=@DirectorUserID";
sSQL += " , " + LibraryMOD.GetFieldName(DirectorUpdateDateFN) + "=@DirectorUpdateDate";

sSQL += " , " + LibraryMOD.GetFieldName(HS_InstitutionTypeFN) + "=@HS_InstitutionType";
sSQL += " , " + LibraryMOD.GetFieldName(HS_InstitutionCityFN) + "=@HS_InstitutionCity";
sSQL += " , " + LibraryMOD.GetFieldName(G12_StreamFN) + "=@G12_Stream";
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfMathFN) + "=@ScoreOfMath";
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfChemistryFN) + "=@ScoreOfChemistry";
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfBiologyFN) + "=@ScoreOfBiology";
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfPhysicsFN) + "=@ScoreOfPhysics";
sSQL += " , " + LibraryMOD.GetFieldName(IESOL_GradeFN) + "=@IESOL_Grade";
sSQL += " , " + LibraryMOD.GetFieldName(ExamCenterIDFN) + "=@ExamCenterID";

sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(lngSerialFN)+"=@lngSerial";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteQualificationFN)+"=@byteQualification";
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
sSQL +=LibraryMOD.GetFieldName(lngSerialFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteQualificationFN);
sSQL += " , " + LibraryMOD.GetFieldName(intCertificateFN);
sSQL += " , " + LibraryMOD.GetFieldName(intMajorFN);
sSQL += " , " + LibraryMOD.GetFieldName(intMinorFN);
sSQL += " , " + LibraryMOD.GetFieldName(intGraduationYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteYearsFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteInstituteCountryFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteStudyLanguageFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteStudyTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(sngGradeFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteGradeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCertificateSourceFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteLevelFN);
sSQL += " , " + LibraryMOD.GetFieldName(intLecturerFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateENGFN);
sSQL += " , " + LibraryMOD.GetFieldName(VerifiedByAdmissionFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(AdmissionCommentsFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(AdmissionUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(AdmissionUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(VerifiedByregistrarFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(RegistrarCommentsFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(RegistrarUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegistrarUpdateDateFN);

sSQL += " , " + LibraryMOD.GetFieldName(VerifiedByDirectorFN);
sSQL += " , " + LibraryMOD.GetFieldName(DirectorCommentsFN);
sSQL += " , " + LibraryMOD.GetFieldName(DirectorUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(DirectorUpdateDateFN);

sSQL += " , " + LibraryMOD.GetFieldName(HS_InstitutionTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(HS_InstitutionCityFN);
sSQL += " , " + LibraryMOD.GetFieldName(G12_StreamFN);
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfMathFN);
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfChemistryFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfBiologyFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(ScoreOfPhysicsFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(IESOL_GradeFN );
sSQL += " , " + LibraryMOD.GetFieldName(ExamCenterIDFN );

sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @lngSerial";
sSQL += " ,@byteQualification";
sSQL += " ,@intCertificate";
sSQL += " ,@intMajor";
sSQL += " ,@intMinor";
sSQL += " ,@intGraduationYear";
sSQL += " ,@byteYears";
sSQL += " ,@byteInstituteCountry";
sSQL += " ,@byteStudyLanguage";
sSQL += " ,@byteStudyType";
sSQL += " ,@sngGrade";
sSQL += " ,@byteGrade";
sSQL += " ,@strCertificateSource";
sSQL += " ,@byteLevel";
sSQL += " ,@intLecturer";
sSQL += " ,@dateENG";
sSQL += " ,@VerifiedByAdmission";
sSQL += " ,@AdmissionComments";
sSQL += " ,@AdmissionUserID";
sSQL += " ,@AdmissionUpdateDate";
sSQL += " ,@VerifiedByregistrar";
sSQL += " ,@RegistrarComments";
sSQL += " ,@RegistrarUserID";
sSQL += " ,@RegistrarUpdateDate";

sSQL += " ,@DirectorByregistrar";
sSQL += " ,@DirectorComments";
sSQL += " ,@DirectorUserID";
sSQL += " ,@DirectorUpdateDate";

sSQL += " ,@HS_InstitutionType";
sSQL += " ,@HS_InstitutionCity";
sSQL += " ,@G12_Stream";
sSQL += " ,@ScoreOfMath";
sSQL += " ,@ScoreOfChemistry";
sSQL += " ,@ScoreOfBiology";
sSQL += " ,@ScoreOfPhysics";
sSQL += " ,@IESOL_Grade";
sSQL += " ,@ExamCenterID";

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
sSQL += LibraryMOD.GetFieldName(lngSerialFN)+"=@lngSerial";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteQualificationFN)+"=@byteQualification";
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
public List< Student_Qualifications> GetStudent_Qualifications(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Student_Qualifications
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
List<Student_Qualifications> results = new List<Student_Qualifications>();
try
{
//Default Value
Student_Qualifications myStudent_Qualifications = new Student_Qualifications();
if (isDeafaultIncluded)
{
//Change the code here
myStudent_Qualifications.lngSerial = 0;
myStudent_Qualifications.byteQualification = 0;
myStudent_Qualifications.intCertificate = 0;
myStudent_Qualifications.intCertificate = 0;

results.Add(myStudent_Qualifications);
}
while (reader.Read())
{
myStudent_Qualifications = new Student_Qualifications();
if (reader[LibraryMOD.GetFieldName(lngSerialFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.lngSerial = 0;
}
else
{
myStudent_Qualifications.lngSerial = int.Parse(reader[LibraryMOD.GetFieldName( lngSerialFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteQualificationFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.byteQualification = 0;
}
else
{
myStudent_Qualifications.byteQualification = int.Parse(reader[LibraryMOD.GetFieldName( byteQualificationFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intCertificateFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.intCertificate = 0;
}
else
{
myStudent_Qualifications.intCertificate = int.Parse(reader[LibraryMOD.GetFieldName( intCertificateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intMajorFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.intMajor = 0;
}
else
{
myStudent_Qualifications.intMajor = int.Parse(reader[LibraryMOD.GetFieldName( intMajorFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intMinorFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.intMinor = 0;
}
else
{
myStudent_Qualifications.intMinor = int.Parse(reader[LibraryMOD.GetFieldName( intMinorFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intGraduationYearFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.intGraduationYear = 0;
}
else
{
myStudent_Qualifications.intGraduationYear = int.Parse(reader[LibraryMOD.GetFieldName( intGraduationYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteYearsFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.byteYears = 0;
}
else
{
myStudent_Qualifications.byteYears = int.Parse(reader[LibraryMOD.GetFieldName( byteYearsFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteInstituteCountryFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.byteInstituteCountry = 0;
}
else
{
myStudent_Qualifications.byteInstituteCountry = int.Parse(reader[LibraryMOD.GetFieldName( byteInstituteCountryFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteStudyLanguageFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.byteStudyLanguage = 0;
}
else
{
myStudent_Qualifications.byteStudyLanguage = int.Parse(reader[LibraryMOD.GetFieldName( byteStudyLanguageFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteStudyTypeFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.byteStudyType = 0;
}
else
{
myStudent_Qualifications.byteStudyType = int.Parse(reader[LibraryMOD.GetFieldName( byteStudyTypeFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(sngGradeFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.sngGrade = 0;
}
else
{
    myStudent_Qualifications.sngGrade = Convert.ToDouble(reader[LibraryMOD.GetFieldName(sngGradeFN)].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteGradeFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.byteGrade = 0;
}
else
{
myStudent_Qualifications.byteGrade = int.Parse(reader[LibraryMOD.GetFieldName( byteGradeFN) ].ToString());
}
myStudent_Qualifications.strCertificateSource =reader[LibraryMOD.GetFieldName( strCertificateSourceFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteLevelFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.byteLevel = 0;
}
else
{
myStudent_Qualifications.byteLevel = int.Parse(reader[LibraryMOD.GetFieldName( byteLevelFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intLecturerFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.intLecturer = 0;
}
else
{
myStudent_Qualifications.intLecturer = int.Parse(reader[LibraryMOD.GetFieldName( intLecturerFN) ].ToString());
}

if (!reader[LibraryMOD.GetFieldName(dateENGFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.dateENG = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateENGFN)].ToString());
}


if (reader[LibraryMOD.GetFieldName(VerifiedByAdmissionFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.VerifiedByAdmission = 0;
}
else
{
    myStudent_Qualifications.VerifiedByAdmission = Convert.ToInt32 ((Boolean )reader[LibraryMOD.GetFieldName(VerifiedByAdmissionFN)]);
}
if (reader[LibraryMOD.GetFieldName(AdmissionUserIDFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.AdmissionUserID = 0;
}
else
{
    myStudent_Qualifications.AdmissionUserID = Convert.ToInt32(reader[LibraryMOD.GetFieldName(AdmissionUserIDFN)]);
}
if (!reader[LibraryMOD.GetFieldName(AdmissionUpdateDateFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.AdmissionUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(AdmissionUpdateDateFN)].ToString());
}
myStudent_Qualifications.AdmissionComments = reader[LibraryMOD.GetFieldName(AdmissionCommentsFN)].ToString();

if (reader[LibraryMOD.GetFieldName(VerifiedByregistrarFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.VerifiedByregistrar = 0;
}
else
{
    myStudent_Qualifications.VerifiedByregistrar = Convert.ToInt32((Boolean) reader[LibraryMOD.GetFieldName(VerifiedByregistrarFN)]);
}
myStudent_Qualifications.RegistrarComments = reader[LibraryMOD.GetFieldName(RegistrarCommentsFN)].ToString();
if (reader[LibraryMOD.GetFieldName(RegistrarUserIDFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.RegistrarUserID = 0;
}
else
{
    myStudent_Qualifications.RegistrarUserID = Convert.ToInt32(reader[LibraryMOD.GetFieldName(RegistrarUserIDFN)]);
}
if (!reader[LibraryMOD.GetFieldName(RegistrarUpdateDateFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.RegistrarUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(RegistrarUpdateDateFN)].ToString());
}
if (reader[LibraryMOD.GetFieldName(VerifiedByDirectorFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.VerifiedByDirector = 0;
}
else
{
    myStudent_Qualifications.VerifiedByDirector = Convert.ToInt32((Boolean)reader[LibraryMOD.GetFieldName(VerifiedByDirectorFN)]);
}
myStudent_Qualifications.DirectorComments = reader[LibraryMOD.GetFieldName(DirectorCommentsFN)].ToString();
if (reader[LibraryMOD.GetFieldName(DirectorUserIDFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.DirectorUserID = 0;
}
else
{
    myStudent_Qualifications.DirectorUserID = Convert.ToInt32(reader[LibraryMOD.GetFieldName(DirectorUserIDFN)]);
}
if (!reader[LibraryMOD.GetFieldName(DirectorUpdateDateFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.DirectorUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(DirectorUpdateDateFN)].ToString());
}

if (reader[LibraryMOD.GetFieldName(HS_InstitutionTypeFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.HS_InstitutionType = 0;
}
else
{
    myStudent_Qualifications.HS_InstitutionType = Convert.ToInt32(reader[LibraryMOD.GetFieldName(HS_InstitutionTypeFN)]);
}
if (reader[LibraryMOD.GetFieldName(HS_InstitutionCityFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.HS_InstitutionCity = 0;
}
else
{
    myStudent_Qualifications.HS_InstitutionCity = Convert.ToInt32(reader[LibraryMOD.GetFieldName(HS_InstitutionCityFN)]);
}
if (reader[LibraryMOD.GetFieldName(G12_StreamFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.G12_Stream = 0;
}
else
{
    myStudent_Qualifications.G12_Stream = Convert.ToInt32(reader[LibraryMOD.GetFieldName(G12_StreamFN)]);
}
if (reader[LibraryMOD.GetFieldName(ScoreOfMathFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.ScoreOfMath = 0;
}
else
{
    myStudent_Qualifications.ScoreOfMath = Convert.ToInt32 (reader[LibraryMOD.GetFieldName(ScoreOfMathFN)]);
}

if (reader[LibraryMOD.GetFieldName(ScoreOfChemistryFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.ScoreOfChemistry = 0;
}
else
{
    myStudent_Qualifications.ScoreOfChemistry = Convert.ToInt32(reader[LibraryMOD.GetFieldName(ScoreOfChemistryFN)]);
}
if (reader[LibraryMOD.GetFieldName(ScoreOfBiologyFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.ScoreOfBiology = 0;
}
else
{
    myStudent_Qualifications.ScoreOfBiology = Convert.ToInt32(reader[LibraryMOD.GetFieldName(ScoreOfBiologyFN)]);
}
if (reader[LibraryMOD.GetFieldName(ScoreOfPhysicsFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.ScoreOfPhysics = 0;
}
else
{
    myStudent_Qualifications.ScoreOfPhysics = Convert.ToInt32(reader[LibraryMOD.GetFieldName(ScoreOfPhysicsFN)]);
}
if (reader[LibraryMOD.GetFieldName(ExamCenterIDFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.ExamCenterID = 0;
}
else
{
    myStudent_Qualifications.ExamCenterID = Convert.ToInt32(reader[LibraryMOD.GetFieldName(ExamCenterIDFN)]);
}

if (reader[LibraryMOD.GetFieldName(IESOL_GradeFN)].Equals(DBNull.Value))
{
    myStudent_Qualifications.IESOL_Grade = "-";
}
else
{
    myStudent_Qualifications.IESOL_Grade = reader[LibraryMOD.GetFieldName(IESOL_GradeFN)].ToString();
}

myStudent_Qualifications.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myStudent_Qualifications.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myStudent_Qualifications.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myStudent_Qualifications.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myStudent_Qualifications.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myStudent_Qualifications);
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
public int UpdateStudent_Qualifications(InitializeModule.EnumCampus Campus, int iMode,
    int lngSerial,int byteQualification,int intCertificate,int intMajor,
    int intMinor,int intGraduationYear,int byteYears,int byteInstituteCountry,
    int byteStudyLanguage,int byteStudyType,double sngGrade,int byteGrade,
    string strCertificateSource, int byteLevel, int intLecturer, DateTime dateENG,
    int iAdmissionVerification,string sAdmissionComments ,int iAdmissionUserID ,DateTime AdmissionUpdateDate,
    int iRegistrarVerification, string sRegistrarComments,int iRegistrarUserID ,DateTime RegistrarUpdateDate,
    int iDirectorVerification, string sDirectorComments, int iDirectorUserID, DateTime DirectorUpdateDate,
    int iHS_InstitutionType,int iHS_InstitutionCity,int iG12_Stream,int iScoreOfMath,
    int iScoreOfChemistry,int iScoreOfBiology,int iScoreOfPhysics,string sIESOL_Grade,int iExamCenterID,
    string strUserCreate,DateTime dateCreate,string strUserSave,
    DateTime dateLastSave,string strMachine,string strNUser)
   
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Student_Qualifications theStudent_Qualifications = new Student_Qualifications();
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
Cmd.Parameters.Add(new SqlParameter("@lngSerial",lngSerial));
Cmd.Parameters.Add(new SqlParameter("@byteQualification",byteQualification));
Cmd.Parameters.Add(new SqlParameter("@intCertificate",intCertificate));
Cmd.Parameters.Add(new SqlParameter("@intMajor",intMajor));
Cmd.Parameters.Add(new SqlParameter("@intMinor",intMinor));
Cmd.Parameters.Add(new SqlParameter("@intGraduationYear",intGraduationYear));
Cmd.Parameters.Add(new SqlParameter("@byteYears",byteYears));
Cmd.Parameters.Add(new SqlParameter("@byteInstituteCountry",byteInstituteCountry));
Cmd.Parameters.Add(new SqlParameter("@byteStudyLanguage",byteStudyLanguage));
Cmd.Parameters.Add(new SqlParameter("@byteStudyType",byteStudyType));
Cmd.Parameters.Add(new SqlParameter("@sngGrade",sngGrade));
Cmd.Parameters.Add(new SqlParameter("@byteGrade",byteGrade));
Cmd.Parameters.Add(new SqlParameter("@strCertificateSource",strCertificateSource));
Cmd.Parameters.Add(new SqlParameter("@byteLevel",byteLevel));
Cmd.Parameters.Add(new SqlParameter("@intLecturer",intLecturer));
Cmd.Parameters.Add(new SqlParameter("@dateENG", dateENG));

Cmd.Parameters.Add(new SqlParameter("@VerifiedByAdmission", iAdmissionVerification));
Cmd.Parameters.Add(new SqlParameter("@AdmissionComments",sAdmissionComments));
Cmd.Parameters.Add(new SqlParameter("@AdmissionUserID", iAdmissionUserID));
Cmd.Parameters.Add(new SqlParameter("@AdmissionUpdateDate", AdmissionUpdateDate));

Cmd.Parameters.Add(new SqlParameter("@VerifiedByRegistrar", iRegistrarVerification));
Cmd.Parameters.Add(new SqlParameter("@RegistrarComments", sRegistrarComments));
Cmd.Parameters.Add(new SqlParameter("@RegistrarUserID", iRegistrarUserID));
Cmd.Parameters.Add(new SqlParameter("@RegistrarUpdateDate", RegistrarUpdateDate));

Cmd.Parameters.Add(new SqlParameter("@VerifiedByDirector", iDirectorVerification));
Cmd.Parameters.Add(new SqlParameter("@DirectorComments", sDirectorComments));
Cmd.Parameters.Add(new SqlParameter("@DirectorUserID", iDirectorUserID));
Cmd.Parameters.Add(new SqlParameter("@DirectorUpdateDate", DirectorUpdateDate));

Cmd.Parameters.Add(new SqlParameter("@HS_InstitutionType", iHS_InstitutionType));
Cmd.Parameters.Add(new SqlParameter("@HS_InstitutionCity", iHS_InstitutionCity));
Cmd.Parameters.Add(new SqlParameter("@G12_Stream", iG12_Stream));
Cmd.Parameters.Add(new SqlParameter("@ScoreOfMath", iScoreOfMath));

Cmd.Parameters.Add(new SqlParameter("@ScoreOfChemistry", iScoreOfChemistry));
Cmd.Parameters.Add(new SqlParameter("@ScoreOfBiology", iScoreOfBiology));
Cmd.Parameters.Add(new SqlParameter("@ScoreOfPhysics", iScoreOfPhysics));

Cmd.Parameters.Add(new SqlParameter("@IESOL_Grade", sIESOL_Grade));
Cmd.Parameters.Add(new SqlParameter("@ExamCenterID", iExamCenterID));

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
public int DeleteStudent_Qualifications(InitializeModule.EnumCampus Campus,string lngSerial,string byteQualification)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@lngSerial", lngSerial ));
Cmd.Parameters.Add(new SqlParameter("@byteQualification", byteQualification ));
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
DataTable dt = new DataTable("Student_Qualifications");
DataView dv = new DataView();
List<Student_Qualifications> myStudent_Qualificationss = new List<Student_Qualifications>();
try
{
myStudent_Qualificationss = GetStudent_Qualifications(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("lngSerial", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteQualification", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("intCertificate", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myStudent_Qualificationss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myStudent_Qualificationss[i].lngSerial;
  dr[2] = myStudent_Qualificationss[i].byteQualification;
  dr[3] = myStudent_Qualificationss[i].intCertificate;
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
myStudent_Qualificationss.Clear();
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
sSQL += lngSerialFN;
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
public class Student_QualificationsCls : Student_QualificationsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daStudent_Qualifications;
private DataSet m_dsStudent_Qualifications;
public DataRow Student_QualificationsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsStudent_Qualifications
{
get { return m_dsStudent_Qualifications ; }
set { m_dsStudent_Qualifications = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Student_QualificationsCls()
{
try
{
dsStudent_Qualifications= new DataSet();

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
public virtual SqlDataAdapter GetStudent_QualificationsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daStudent_Qualifications = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudent_Qualifications);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_Qualifications.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_Qualifications;
}
public virtual SqlDataAdapter GetStudent_QualificationsDataAdapter(SqlConnection con)  
{
try
{
daStudent_Qualifications = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_Qualifications.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdStudent_Qualifications;
cmdStudent_Qualifications = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@lngSerial", SqlDbType.Int, 4, "lngSerial" );
//'cmdRolePermission.Parameters.Add("@byteQualification", SqlDbType.Int, 4, "byteQualification" );
daStudent_Qualifications.SelectCommand = cmdStudent_Qualifications;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdStudent_Qualifications = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdStudent_Qualifications.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
//cmdStudent_Qualifications.Parameters.Add("@byteQualification", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteQualificationFN));
cmdStudent_Qualifications.Parameters.Add("@intCertificate", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCertificateFN));
cmdStudent_Qualifications.Parameters.Add("@intMajor", SqlDbType.Int,2, LibraryMOD.GetFieldName(intMajorFN));
cmdStudent_Qualifications.Parameters.Add("@intMinor", SqlDbType.Int,2, LibraryMOD.GetFieldName(intMinorFN));
cmdStudent_Qualifications.Parameters.Add("@intGraduationYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intGraduationYearFN));
cmdStudent_Qualifications.Parameters.Add("@byteYears", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteYearsFN));
cmdStudent_Qualifications.Parameters.Add("@byteInstituteCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteInstituteCountryFN));
cmdStudent_Qualifications.Parameters.Add("@byteStudyLanguage", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudyLanguageFN));
cmdStudent_Qualifications.Parameters.Add("@byteStudyType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudyTypeFN));
cmdStudent_Qualifications.Parameters.Add("@sngGrade", SqlDbType.Decimal,8, LibraryMOD.GetFieldName(sngGradeFN));
cmdStudent_Qualifications.Parameters.Add("@byteGrade", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGradeFN));
cmdStudent_Qualifications.Parameters.Add("@strCertificateSource", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strCertificateSourceFN));
cmdStudent_Qualifications.Parameters.Add("@byteLevel", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteLevelFN));
cmdStudent_Qualifications.Parameters.Add("@intLecturer", SqlDbType.Int,2, LibraryMOD.GetFieldName(intLecturerFN));
cmdStudent_Qualifications.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdStudent_Qualifications.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdStudent_Qualifications.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdStudent_Qualifications.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdStudent_Qualifications.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdStudent_Qualifications.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdStudent_Qualifications.Parameters.Add("@lngSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngSerialFN));
Parmeter = cmdStudent_Qualifications.Parameters.Add("@byteQualification", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteQualificationFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daStudent_Qualifications.UpdateCommand = cmdStudent_Qualifications;
daStudent_Qualifications.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdStudent_Qualifications = new SqlCommand(GetInsertCommand(), con);
cmdStudent_Qualifications.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
cmdStudent_Qualifications.Parameters.Add("@byteQualification", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteQualificationFN));
cmdStudent_Qualifications.Parameters.Add("@intCertificate", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCertificateFN));
cmdStudent_Qualifications.Parameters.Add("@intMajor", SqlDbType.Int,2, LibraryMOD.GetFieldName(intMajorFN));
cmdStudent_Qualifications.Parameters.Add("@intMinor", SqlDbType.Int,2, LibraryMOD.GetFieldName(intMinorFN));
cmdStudent_Qualifications.Parameters.Add("@intGraduationYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intGraduationYearFN));
cmdStudent_Qualifications.Parameters.Add("@byteYears", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteYearsFN));
cmdStudent_Qualifications.Parameters.Add("@byteInstituteCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteInstituteCountryFN));
cmdStudent_Qualifications.Parameters.Add("@byteStudyLanguage", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudyLanguageFN));
cmdStudent_Qualifications.Parameters.Add("@byteStudyType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudyTypeFN));
cmdStudent_Qualifications.Parameters.Add("@sngGrade", SqlDbType.Decimal,8, LibraryMOD.GetFieldName(sngGradeFN));
cmdStudent_Qualifications.Parameters.Add("@byteGrade", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGradeFN));
cmdStudent_Qualifications.Parameters.Add("@strCertificateSource", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strCertificateSourceFN));
cmdStudent_Qualifications.Parameters.Add("@byteLevel", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteLevelFN));
cmdStudent_Qualifications.Parameters.Add("@intLecturer", SqlDbType.Int,2, LibraryMOD.GetFieldName(intLecturerFN));
cmdStudent_Qualifications.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdStudent_Qualifications.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdStudent_Qualifications.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdStudent_Qualifications.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdStudent_Qualifications.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdStudent_Qualifications.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daStudent_Qualifications.InsertCommand =cmdStudent_Qualifications;
daStudent_Qualifications.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdStudent_Qualifications = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdStudent_Qualifications.Parameters.Add("@lngSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngSerialFN));
Parmeter = cmdStudent_Qualifications.Parameters.Add("@byteQualification", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteQualificationFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daStudent_Qualifications.DeleteCommand =cmdStudent_Qualifications;
daStudent_Qualifications.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daStudent_Qualifications.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_Qualifications;
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
dr = dsStudent_Qualifications.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
dr[LibraryMOD.GetFieldName(byteQualificationFN)]=byteQualification;
dr[LibraryMOD.GetFieldName(intCertificateFN)]=intCertificate;
dr[LibraryMOD.GetFieldName(intMajorFN)]=intMajor;
dr[LibraryMOD.GetFieldName(intMinorFN)]=intMinor;
dr[LibraryMOD.GetFieldName(intGraduationYearFN)]=intGraduationYear;
dr[LibraryMOD.GetFieldName(byteYearsFN)]=byteYears;
dr[LibraryMOD.GetFieldName(byteInstituteCountryFN)]=byteInstituteCountry;
dr[LibraryMOD.GetFieldName(byteStudyLanguageFN)]=byteStudyLanguage;
dr[LibraryMOD.GetFieldName(byteStudyTypeFN)]=byteStudyType;
dr[LibraryMOD.GetFieldName(sngGradeFN)]=sngGrade;
dr[LibraryMOD.GetFieldName(byteGradeFN)]=byteGrade;
dr[LibraryMOD.GetFieldName(strCertificateSourceFN)]=strCertificateSource;
dr[LibraryMOD.GetFieldName(byteLevelFN)]=byteLevel;
dr[LibraryMOD.GetFieldName(intLecturerFN)]=intLecturer;

dr[LibraryMOD.GetFieldName(intLecturerFN)] = HS_InstitutionType;
dr[LibraryMOD.GetFieldName(HS_InstitutionCityFN)] = HS_InstitutionCity;
dr[LibraryMOD.GetFieldName(G12_StreamFN)] = G12_Stream;
dr[LibraryMOD.GetFieldName(ScoreOfMathFN)] = ScoreOfMath;

dr[LibraryMOD.GetFieldName(ScoreOfChemistryFN)] = ScoreOfChemistry;
dr[LibraryMOD.GetFieldName(ScoreOfBiologyFN)] = ScoreOfBiology;
dr[LibraryMOD.GetFieldName(ScoreOfPhysicsFN)] = ScoreOfPhysics;

dr[LibraryMOD.GetFieldName(IESOL_GradeFN)] = IESOL_Grade;
dr[LibraryMOD.GetFieldName(ExamCenterIDFN)] = ExamCenterID;
       
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = DateTime.Now;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;

dsStudent_Qualifications.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsStudent_Qualifications.Tables[TableName].Select(LibraryMOD.GetFieldName(lngSerialFN)  + "=" + lngSerial  + " AND " + LibraryMOD.GetFieldName(byteQualificationFN) + "=" + byteQualification);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
drAry[0][LibraryMOD.GetFieldName(byteQualificationFN)]=byteQualification;
drAry[0][LibraryMOD.GetFieldName(intCertificateFN)]=intCertificate;
drAry[0][LibraryMOD.GetFieldName(intMajorFN)]=intMajor;
drAry[0][LibraryMOD.GetFieldName(intMinorFN)]=intMinor;
drAry[0][LibraryMOD.GetFieldName(intGraduationYearFN)]=intGraduationYear;
drAry[0][LibraryMOD.GetFieldName(byteYearsFN)]=byteYears;
drAry[0][LibraryMOD.GetFieldName(byteInstituteCountryFN)]=byteInstituteCountry;
drAry[0][LibraryMOD.GetFieldName(byteStudyLanguageFN)]=byteStudyLanguage;
drAry[0][LibraryMOD.GetFieldName(byteStudyTypeFN)]=byteStudyType;
drAry[0][LibraryMOD.GetFieldName(sngGradeFN)]=sngGrade;
drAry[0][LibraryMOD.GetFieldName(byteGradeFN)]=byteGrade;
drAry[0][LibraryMOD.GetFieldName(strCertificateSourceFN)]=strCertificateSource;
drAry[0][LibraryMOD.GetFieldName(byteLevelFN)]=byteLevel;
drAry[0][LibraryMOD.GetFieldName(intLecturerFN)]=intLecturer;

drAry[0][LibraryMOD.GetFieldName(HS_InstitutionTypeFN)] = HS_InstitutionType;
drAry[0][LibraryMOD.GetFieldName(HS_InstitutionCityFN)] = HS_InstitutionCity;
drAry[0][LibraryMOD.GetFieldName(G12_StreamFN)] = G12_Stream;
drAry[0][LibraryMOD.GetFieldName(ScoreOfMathFN)] = ScoreOfMath;

drAry[0][LibraryMOD.GetFieldName(ScoreOfChemistryFN)] = ScoreOfChemistry;
drAry[0][LibraryMOD.GetFieldName(ScoreOfBiologyFN)] = ScoreOfBiology;
drAry[0][LibraryMOD.GetFieldName(ScoreOfPhysicsFN)] = ScoreOfPhysics;

drAry[0][LibraryMOD.GetFieldName(IESOL_GradeFN)] = IESOL_Grade;
drAry[0][LibraryMOD.GetFieldName(ExamCenterIDFN)] = ExamCenterID;

drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = DateTime.Now;
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
public int CommitStudent_Qualifications()  
{
//CommitStudent_Qualifications= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daStudent_Qualifications.Update(dsStudent_Qualifications, TableName);
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
FindInMultiPKey(lngSerial,byteQualification);
if (( Student_QualificationsDataRow != null)) 
{
Student_QualificationsDataRow.Delete();
CommitStudent_Qualifications();
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
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(lngSerialFN)]== System.DBNull.Value)
{
  lngSerial=0;
}
else
{
  lngSerial = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(lngSerialFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteQualificationFN)]== System.DBNull.Value)
{
  byteQualification=0;
}
else
{
  byteQualification = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteQualificationFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(intCertificateFN)]== System.DBNull.Value)
{
  intCertificate=0;
}
else
{
  intCertificate = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(intCertificateFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(intMajorFN)]== System.DBNull.Value)
{
  intMajor=0;
}
else
{
  intMajor = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(intMajorFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(intMinorFN)]== System.DBNull.Value)
{
  intMinor=0;
}
else
{
  intMinor = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(intMinorFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(intGraduationYearFN)]== System.DBNull.Value)
{
  intGraduationYear=0;
}
else
{
  intGraduationYear = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(intGraduationYearFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteYearsFN)]== System.DBNull.Value)
{
  byteYears=0;
}
else
{
  byteYears = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteYearsFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteInstituteCountryFN)]== System.DBNull.Value)
{
  byteInstituteCountry=0;
}
else
{
  byteInstituteCountry = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteInstituteCountryFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteStudyLanguageFN)]== System.DBNull.Value)
{
  byteStudyLanguage=0;
}
else
{
  byteStudyLanguage = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteStudyLanguageFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteStudyTypeFN)]== System.DBNull.Value)
{
  byteStudyType=0;
}
else
{
  byteStudyType = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteStudyTypeFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(sngGradeFN)]== System.DBNull.Value)
{
}
else
{
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteGradeFN)]== System.DBNull.Value)
{
  byteGrade=0;
}
else
{
  byteGrade = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteGradeFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(strCertificateSourceFN)]== System.DBNull.Value)
{
  strCertificateSource="";
}
else
{
  strCertificateSource = (string)Student_QualificationsDataRow[LibraryMOD.GetFieldName(strCertificateSourceFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteLevelFN)]== System.DBNull.Value)
{
  byteLevel=0;
}
else
{
  byteLevel = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(byteLevelFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(intLecturerFN)]== System.DBNull.Value)
{
  intLecturer=0;
}
else
{
  intLecturer = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(intLecturerFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(HS_InstitutionTypeFN)] == System.DBNull.Value)
{
    HS_InstitutionType = 0;
}
else
{
    HS_InstitutionType = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(HS_InstitutionTypeFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(HS_InstitutionCityFN)] == System.DBNull.Value)
{
    HS_InstitutionCity = 0;
}
else
{
    HS_InstitutionCity = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(HS_InstitutionCityFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(G12_StreamFN)] == System.DBNull.Value)
{
    G12_Stream = 0;
}
else
{
    G12_Stream = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(G12_StreamFN)];
}

if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfMathFN)] == System.DBNull.Value)
{
    ScoreOfMath = 0;
}
else
{
    ScoreOfMath = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfMathFN)];
}

if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfChemistryFN)] == System.DBNull.Value)
{
    ScoreOfChemistry = 0;
}
else
{
    ScoreOfChemistry = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfChemistryFN)];
}
    
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfBiologyFN)] == System.DBNull.Value)
{
    ScoreOfBiology = 0;
}
else
{
    ScoreOfBiology = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfBiologyFN)];
}
        
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfPhysicsFN)] == System.DBNull.Value)
{
    ScoreOfPhysics = 0;
}
else
{
    ScoreOfPhysics = (int)Student_QualificationsDataRow[LibraryMOD.GetFieldName(ScoreOfPhysicsFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Student_QualificationsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Student_QualificationsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Student_QualificationsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Student_QualificationsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Student_QualificationsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Student_QualificationsDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Student_QualificationsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKlngSerial,int PKbyteQualification) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKlngSerial;
findTheseVals[1] = PKbyteQualification;
Student_QualificationsDataRow = dsStudent_Qualifications.Tables[TableName].Rows.Find(findTheseVals);
if  ((Student_QualificationsDataRow !=null)) 
{
lngCurRow = dsStudent_Qualifications.Tables[TableName].Rows.IndexOf(Student_QualificationsDataRow);
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
  lngCurRow = dsStudent_Qualifications.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsStudent_Qualifications.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsStudent_Qualifications.Tables[TableName].Rows.Count > 0) 
{
  Student_QualificationsDataRow = dsStudent_Qualifications.Tables[TableName].Rows[lngCurRow];
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
daStudent_Qualifications.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_Qualifications.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daStudent_Qualifications.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_Qualifications.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
