using System;
using System.Data;
using System.Configuration;
////////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//////using System.Xml.Linq;
using System.Collections.Generic;
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Employee
{
//Creation Date: 31/10/2010 7:13 PM
//Programmer Name : Bahaa Addin Ghaleb Najem
//-----Decleration --------------
#region "Decleration"
private int m_EmployeeID; 
private string m_EmpFileNo; 
private string m_EmpCardID; 
private string m_FirstNameEn; 
private string m_SecondNameEn; 
private string m_ThirdNameEn; 
private string m_FamilyNameEn; 
private string m_FirstNameAr; 
private string m_SecondNameAr; 
private string m_ThirdNameAr; 
private string m_FamilyNameAr; 
private string m_SurnameEn; 
private string m_SurnameAr; 
private Image m_EmpPicture; 
private int m_HomeCountryID; 
private int m_HomeCityID; 
private string m_POBox; 
private string m_Phone; 
private string m_Mobile; 
private string m_Fax; 
private string m_Email; 
private string m_InternalEmail; 
private string m_ZipCode; 
private string m_Address; 
private string m_HomeCountryAddress; 
private string m_IdentityCard; 
private int m_Sex; 
private int m_MaritalStaus; 
private int m_ReligionID; 
private int m_NationalityID; 
//private string m_BloodType; 
private string m_PassportNo; 
private string m_IssuePlace; 
private int m_PassportIssueDate; 
private int m_PassportExpireDate; 
private int m_BirthDate; 
private int m_BirthCountryID; 
private int m_BirthCityID; 
private int m_IsFullTime; 
private int m_ContractType; 
private int m_ContractIssueDate; 
private int m_ContractExpireDate; 
private int m_HireDate; 
private int m_EndWorkDate; 
private int m_EndReasonID; 
private int m_IsSuspended; 
private int m_SuspendedFromDate; 
private int m_SuspendedToDate; 
private int m_SuspendedReasonID; 
private int m_EmployeeGroup; 
private int m_ManagerID; 
private int m_DepartmentID; 
private int m_JobTitleID; 
private int m_EmployeeGrade; 
private int m_GradeCircleNo; 
private int m_ShiftID; 
private int m_InsuranceCategoryID; 
private string m_Notes; 
private int m_IsActive;
private string m_Name;
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
private string m_TitleOfCourtesy; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int EmployeeID
{
get { return  m_EmployeeID; }
set {m_EmployeeID  = value ; }
}
public string EmpFileNo
{
get { return  m_EmpFileNo; }
set {m_EmpFileNo  = value ; }
}
public string EmpCardID
{
get { return  m_EmpCardID; }
set {m_EmpCardID  = value ; }
}
public string FirstNameEn
{
get { return  m_FirstNameEn; }
set {m_FirstNameEn  = value ; }
}
public string SecondNameEn
{
get { return  m_SecondNameEn; }
set {m_SecondNameEn  = value ; }
}
public string ThirdNameEn
{
get { return  m_ThirdNameEn; }
set {m_ThirdNameEn  = value ; }
}
public string FamilyNameEn
{
get { return  m_FamilyNameEn; }
set {m_FamilyNameEn  = value ; }
}
public string FirstNameAr
{
get { return  m_FirstNameAr; }
set {m_FirstNameAr  = value ; }
}
public string SecondNameAr
{
get { return  m_SecondNameAr; }
set {m_SecondNameAr  = value ; }
}
public string ThirdNameAr
{
get { return  m_ThirdNameAr; }
set {m_ThirdNameAr  = value ; }
}
public string FamilyNameAr
{
get { return  m_FamilyNameAr; }
set {m_FamilyNameAr  = value ; }
}
public string SurnameEn
{
get { return  m_SurnameEn; }
set {m_SurnameEn  = value ; }
}
public string SurnameAr
{
get { return  m_SurnameAr; }
set {m_SurnameAr  = value ; }
}
public Image  EmpPicture
{
get { return  m_EmpPicture; }
set {m_EmpPicture  = value ; }
}

public int HomeCountryID
{
get { return  m_HomeCountryID; }
set {m_HomeCountryID  = value ; }
}
public int HomeCityID
{
get { return  m_HomeCityID; }
set {m_HomeCityID  = value ; }
}
public string POBox
{
get { return  m_POBox; }
set {m_POBox  = value ; }
}
public string Phone
{
get { return  m_Phone; }
set {m_Phone  = value ; }
}
public string Mobile
{
get { return  m_Mobile; }
set {m_Mobile  = value ; }
}
public string Fax
{
get { return  m_Fax; }
set {m_Fax  = value ; }
}
public string Email
{
get { return  m_Email; }
set {m_Email  = value ; }
}
public string InternalEmail
{
get { return  m_InternalEmail; }
set {m_InternalEmail  = value ; }
}
public string ZipCode
{
get { return  m_ZipCode; }
set {m_ZipCode  = value ; }
}
public string Address
{
get { return  m_Address; }
set {m_Address  = value ; }
}
public string HomeCountryAddress
{
get { return  m_HomeCountryAddress; }
set {m_HomeCountryAddress  = value ; }
}
public string IdentityCard
{
get { return  m_IdentityCard; }
set {m_IdentityCard  = value ; }
}
public int Sex
{
get { return  m_Sex; }
set {m_Sex  = value ; }
}
public int MaritalStaus
{
get { return  m_MaritalStaus; }
set {m_MaritalStaus  = value ; }
}
public int ReligionID
{
get { return  m_ReligionID; }
set {m_ReligionID  = value ; }
}
public int NationalityID
{
get { return  m_NationalityID; }
set {m_NationalityID  = value ; }
}
//public string BloodType
//{
//get { return  m_BloodType; }
//set {m_BloodType  = value ; }
//}
public string PassportNo
{
get { return  m_PassportNo; }
set {m_PassportNo  = value ; }
}
public string IssuePlace
{
get { return  m_IssuePlace; }
set {m_IssuePlace  = value ; }
}
public int PassportIssueDate
{
get { return  m_PassportIssueDate; }
set {m_PassportIssueDate  = value ; }
}
public int PassportExpireDate
{
get { return  m_PassportExpireDate; }
set {m_PassportExpireDate  = value ; }
}
public int BirthDate
{
get { return  m_BirthDate; }
set {m_BirthDate  = value ; }
}
public int BirthCountryID
{
get { return  m_BirthCountryID; }
set {m_BirthCountryID  = value ; }
}
public int BirthCityID
{
get { return  m_BirthCityID; }
set {m_BirthCityID  = value ; }
}
public int IsFullTime
{
get { return  m_IsFullTime; }
set {m_IsFullTime  = value ; }
}
public int ContractType
{
get { return  m_ContractType; }
set {m_ContractType  = value ; }
}
public int ContractIssueDate
{
get { return  m_ContractIssueDate; }
set {m_ContractIssueDate  = value ; }
}
public int ContractExpireDate
{
get { return  m_ContractExpireDate; }
set {m_ContractExpireDate  = value ; }
}
public int HireDate
{
get { return  m_HireDate; }
set {m_HireDate  = value ; }
}
public int EndWorkDate
{
get { return  m_EndWorkDate; }
set {m_EndWorkDate  = value ; }
}
public int EndReasonID
{
get { return  m_EndReasonID; }
set {m_EndReasonID  = value ; }
}
public int IsSuspended
{
get { return  m_IsSuspended; }
set {m_IsSuspended  = value ; }
}
public int SuspendedFromDate
{
get { return  m_SuspendedFromDate; }
set {m_SuspendedFromDate  = value ; }
}
public int SuspendedToDate
{
get { return  m_SuspendedToDate; }
set {m_SuspendedToDate  = value ; }
}
public int SuspendedReasonID
{
get { return  m_SuspendedReasonID; }
set {m_SuspendedReasonID  = value ; }
}
public int EmployeeGroup
{
get { return  m_EmployeeGroup; }
set {m_EmployeeGroup  = value ; }
}
public int ManagerID
{
get { return  m_ManagerID; }
set {m_ManagerID  = value ; }
}
public int DepartmentID
{
get { return  m_DepartmentID; }
set {m_DepartmentID  = value ; }
}
public int JobTitleID
{
get { return  m_JobTitleID; }
set {m_JobTitleID  = value ; }
}
public int EmployeeGrade
{
get { return  m_EmployeeGrade; }
set {m_EmployeeGrade  = value ; }
}
public int GradeCircleNo
{
get { return  m_GradeCircleNo; }
set {m_GradeCircleNo  = value ; }
}
public int ShiftID
{
get { return  m_ShiftID; }
set {m_ShiftID  = value ; }
}
public int InsuranceCategoryID
{
get { return  m_InsuranceCategoryID; }
set {m_InsuranceCategoryID  = value ; }
}
public string Notes
{
get { return  m_Notes; }
set {m_Notes  = value ; }
}
public int IsActive
{
get { return  m_IsActive; }
set {m_IsActive  = value ; }
}
public string Name
{
    get { return m_Name; }
    set { m_Name = value; }
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
public string TitleOfCourtesy
{
get { return  m_TitleOfCourtesy; }
set {m_TitleOfCourtesy  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Employee()
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
public class EmployeeDAL : Employee
{
#region "Decleration"
private string m_TableName;
private string m_EmployeeIDFN ;
private string m_EmpFileNoFN ;
private string m_EmpCardIDFN ;
private string m_FirstNameEnFN ;
private string m_SecondNameEnFN ;
private string m_ThirdNameEnFN ;
private string m_FamilyNameEnFN ;
private string m_FirstNameArFN ;
private string m_SecondNameArFN ;
private string m_ThirdNameArFN ;
private string m_FamilyNameArFN ;
private string m_SurnameEnFN ;
private string m_SurnameArFN ;
private string m_EmpPictureFN ;
private string m_HomeCountryIDFN ;
private string m_HomeCityIDFN ;
private string m_POBoxFN ;
private string m_PhoneFN ;
private string m_MobileFN ;
private string m_FaxFN ;
private string m_EmailFN ;
private string m_InternalEmailFN ;
private string m_ZipCodeFN ;
private string m_AddressFN ;
private string m_HomeCountryAddressFN ;
private string m_IdentityCardFN ;
private string m_SexFN ;
private string m_MaritalStausFN ;
private string m_ReligionIDFN ;
private string m_NationalityIDFN ;
//private string m_BloodTypeFN ;
private string m_PassportNoFN ;
private string m_IssuePlaceFN ;
private string m_PassportIssueDateFN ;
private string m_PassportExpireDateFN ;
private string m_BirthDateFN ;
private string m_BirthCountryIDFN ;
private string m_BirthCityIDFN ;
private string m_IsFullTimeFN ;
private string m_ContractTypeFN ;
private string m_ContractIssueDateFN ;
private string m_ContractExpireDateFN ;
private string m_HireDateFN ;
private string m_EndWorkDateFN ;
private string m_EndReasonIDFN ;
private string m_IsSuspendedFN ;
private string m_SuspendedFromDateFN ;
private string m_SuspendedToDateFN ;
private string m_SuspendedReasonIDFN ;
private string m_EmployeeGroupFN ;
private string m_ManagerIDFN ;
private string m_DepartmentIDFN ;
private string m_JobTitleIDFN ;
private string m_EmployeeGradeFN ;
private string m_GradeCircleNoFN ;
private string m_ShiftIDFN ;
private string m_InsuranceCategoryIDFN ;
private string m_NotesFN ;
private string m_IsActiveFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
private string m_TitleOfCourtesyFN ;
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
public string EmpFileNoFN 
{
get { return  m_EmpFileNoFN; }
set {m_EmpFileNoFN  = value ; }
}
public string EmpCardIDFN 
{
get { return  m_EmpCardIDFN; }
set {m_EmpCardIDFN  = value ; }
}
public string FirstNameEnFN 
{
get { return  m_FirstNameEnFN; }
set {m_FirstNameEnFN  = value ; }
}
public string SecondNameEnFN 
{
get { return  m_SecondNameEnFN; }
set {m_SecondNameEnFN  = value ; }
}
public string ThirdNameEnFN 
{
get { return  m_ThirdNameEnFN; }
set {m_ThirdNameEnFN  = value ; }
}
public string FamilyNameEnFN 
{
get { return  m_FamilyNameEnFN; }
set {m_FamilyNameEnFN  = value ; }
}
public string FirstNameArFN 
{
get { return  m_FirstNameArFN; }
set {m_FirstNameArFN  = value ; }
}
public string SecondNameArFN 
{
get { return  m_SecondNameArFN; }
set {m_SecondNameArFN  = value ; }
}
public string ThirdNameArFN 
{
get { return  m_ThirdNameArFN; }
set {m_ThirdNameArFN  = value ; }
}
public string FamilyNameArFN 
{
get { return  m_FamilyNameArFN; }
set {m_FamilyNameArFN  = value ; }
}
public string SurnameEnFN 
{
get { return  m_SurnameEnFN; }
set {m_SurnameEnFN  = value ; }
}
public string SurnameArFN 
{
get { return  m_SurnameArFN; }
set {m_SurnameArFN  = value ; }
}
public string EmpPictureFN 
{
get { return  m_EmpPictureFN; }
set {m_EmpPictureFN  = value ; }
}
public string HomeCountryIDFN 
{
get { return  m_HomeCountryIDFN; }
set {m_HomeCountryIDFN  = value ; }
}
public string HomeCityIDFN 
{
get { return  m_HomeCityIDFN; }
set {m_HomeCityIDFN  = value ; }
}
public string POBoxFN 
{
get { return  m_POBoxFN; }
set {m_POBoxFN  = value ; }
}
public string PhoneFN 
{
get { return  m_PhoneFN; }
set {m_PhoneFN  = value ; }
}
public string MobileFN 
{
get { return  m_MobileFN; }
set {m_MobileFN  = value ; }
}
public string FaxFN 
{
get { return  m_FaxFN; }
set {m_FaxFN  = value ; }
}
public string EmailFN 
{
get { return  m_EmailFN; }
set {m_EmailFN  = value ; }
}
public string InternalEmailFN 
{
get { return  m_InternalEmailFN; }
set {m_InternalEmailFN  = value ; }
}
public string ZipCodeFN 
{
get { return  m_ZipCodeFN; }
set {m_ZipCodeFN  = value ; }
}
public string AddressFN 
{
get { return  m_AddressFN; }
set {m_AddressFN  = value ; }
}
public string HomeCountryAddressFN 
{
get { return  m_HomeCountryAddressFN; }
set {m_HomeCountryAddressFN  = value ; }
}
public string IdentityCardFN 
{
get { return  m_IdentityCardFN; }
set {m_IdentityCardFN  = value ; }
}
public string SexFN 
{
get { return  m_SexFN; }
set {m_SexFN  = value ; }
}
public string MaritalStausFN 
{
get { return  m_MaritalStausFN; }
set {m_MaritalStausFN  = value ; }
}
public string ReligionIDFN 
{
get { return  m_ReligionIDFN; }
set {m_ReligionIDFN  = value ; }
}
public string NationalityIDFN 
{
get { return  m_NationalityIDFN; }
set {m_NationalityIDFN  = value ; }
}
//public string BloodTypeFN 
//{
//get { return  m_BloodTypeFN; }
//set {m_BloodTypeFN  = value ; }
//}
public string PassportNoFN 
{
get { return  m_PassportNoFN; }
set {m_PassportNoFN  = value ; }
}
public string IssuePlaceFN 
{
get { return  m_IssuePlaceFN; }
set {m_IssuePlaceFN  = value ; }
}
public string PassportIssueDateFN 
{
get { return  m_PassportIssueDateFN; }
set {m_PassportIssueDateFN  = value ; }
}
public string PassportExpireDateFN 
{
get { return  m_PassportExpireDateFN; }
set {m_PassportExpireDateFN  = value ; }
}
public string BirthDateFN 
{
get { return  m_BirthDateFN; }
set {m_BirthDateFN  = value ; }
}
public string BirthCountryIDFN 
{
get { return  m_BirthCountryIDFN; }
set {m_BirthCountryIDFN  = value ; }
}
public string BirthCityIDFN 
{
get { return  m_BirthCityIDFN; }
set {m_BirthCityIDFN  = value ; }
}
public string IsFullTimeFN 
{
get { return  m_IsFullTimeFN; }
set {m_IsFullTimeFN  = value ; }
}
public string ContractTypeFN 
{
get { return  m_ContractTypeFN; }
set {m_ContractTypeFN  = value ; }
}
public string ContractIssueDateFN 
{
get { return  m_ContractIssueDateFN; }
set {m_ContractIssueDateFN  = value ; }
}
public string ContractExpireDateFN 
{
get { return  m_ContractExpireDateFN; }
set {m_ContractExpireDateFN  = value ; }
}
public string HireDateFN 
{
get { return  m_HireDateFN; }
set {m_HireDateFN  = value ; }
}
public string EndWorkDateFN 
{
get { return  m_EndWorkDateFN; }
set {m_EndWorkDateFN  = value ; }
}
public string EndReasonIDFN 
{
get { return  m_EndReasonIDFN; }
set {m_EndReasonIDFN  = value ; }
}
public string IsSuspendedFN 
{
get { return  m_IsSuspendedFN; }
set {m_IsSuspendedFN  = value ; }
}
public string SuspendedFromDateFN 
{
get { return  m_SuspendedFromDateFN; }
set {m_SuspendedFromDateFN  = value ; }
}
public string SuspendedToDateFN 
{
get { return  m_SuspendedToDateFN; }
set {m_SuspendedToDateFN  = value ; }
}
public string SuspendedReasonIDFN 
{
get { return  m_SuspendedReasonIDFN; }
set {m_SuspendedReasonIDFN  = value ; }
}
public string EmployeeGroupFN 
{
get { return  m_EmployeeGroupFN; }
set {m_EmployeeGroupFN  = value ; }
}
public string ManagerIDFN 
{
get { return  m_ManagerIDFN; }
set {m_ManagerIDFN  = value ; }
}
public string DepartmentIDFN 
{
get { return  m_DepartmentIDFN; }
set {m_DepartmentIDFN  = value ; }
}
public string JobTitleIDFN 
{
get { return  m_JobTitleIDFN; }
set {m_JobTitleIDFN  = value ; }
}
public string EmployeeGradeFN 
{
get { return  m_EmployeeGradeFN; }
set {m_EmployeeGradeFN  = value ; }
}
public string GradeCircleNoFN 
{
get { return  m_GradeCircleNoFN; }
set {m_GradeCircleNoFN  = value ; }
}
public string ShiftIDFN 
{
get { return  m_ShiftIDFN; }
set {m_ShiftIDFN  = value ; }
}
public string InsuranceCategoryIDFN 
{
get { return  m_InsuranceCategoryIDFN; }
set {m_InsuranceCategoryIDFN  = value ; }
}
public string NotesFN 
{
get { return  m_NotesFN; }
set {m_NotesFN  = value ; }
}
public string IsActiveFN 
{
get { return  m_IsActiveFN; }
set {m_IsActiveFN  = value ; }
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
public string TitleOfCourtesyFN 
{
get { return  m_TitleOfCourtesyFN; }
set {m_TitleOfCourtesyFN  = value ; }
}
#endregion
//================End Properties ===================
public EmployeeDAL()
{
try
{
this.TableName = "Hr_Employee";
this.EmployeeIDFN = m_TableName + ".EmployeeID";
this.EmpFileNoFN = m_TableName + ".EmpFileNo";
this.EmpCardIDFN = m_TableName + ".EmpCardID";
this.FirstNameEnFN = m_TableName + ".FirstNameEn";
this.SecondNameEnFN = m_TableName + ".SecondNameEn";
this.ThirdNameEnFN = m_TableName + ".ThirdNameEn";
this.FamilyNameEnFN = m_TableName + ".FamilyNameEn";
this.FirstNameArFN = m_TableName + ".FirstNameAr";
this.SecondNameArFN = m_TableName + ".SecondNameAr";
this.ThirdNameArFN = m_TableName + ".ThirdNameAr";
this.FamilyNameArFN = m_TableName + ".FamilyNameAr";
this.SurnameEnFN = m_TableName + ".SurnameEn";
this.SurnameArFN = m_TableName + ".SurnameAr";
this.EmpPictureFN = m_TableName + ".EmpPicture";
this.HomeCountryIDFN = m_TableName + ".HomeCountryID";
this.HomeCityIDFN = m_TableName + ".HomeCityID";
this.POBoxFN = m_TableName + ".POBox";
this.PhoneFN = m_TableName + ".Phone";
this.MobileFN = m_TableName + ".Mobile";
this.FaxFN = m_TableName + ".Fax";
this.EmailFN = m_TableName + ".Email";
this.InternalEmailFN = m_TableName + ".InternalEmail";
this.ZipCodeFN = m_TableName + ".ZipCode";
this.AddressFN = m_TableName + ".Address";
this.HomeCountryAddressFN = m_TableName + ".HomeCountryAddress";
this.IdentityCardFN = m_TableName + ".IdentityCard";
this.SexFN = m_TableName + ".Sex";
this.MaritalStausFN = m_TableName + ".MaritalStaus";
this.ReligionIDFN = m_TableName + ".ReligionID";
this.NationalityIDFN = m_TableName + ".NationalityID";
//this.BloodTypeFN = m_TableName + ".BloodType";
this.PassportNoFN = m_TableName + ".PassportNo";
this.IssuePlaceFN = m_TableName + ".IssuePlace";
this.PassportIssueDateFN = m_TableName + ".PassportIssueDate";
this.PassportExpireDateFN = m_TableName + ".PassportExpireDate";
this.BirthDateFN = m_TableName + ".BirthDate";
this.BirthCountryIDFN = m_TableName + ".BirthCountryID";
this.BirthCityIDFN = m_TableName + ".BirthCityID";
this.IsFullTimeFN = m_TableName + ".IsFullTime";
this.ContractTypeFN = m_TableName + ".ContractType";
this.ContractIssueDateFN = m_TableName + ".ContractIssueDate";
this.ContractExpireDateFN = m_TableName + ".ContractExpireDate";
this.HireDateFN = m_TableName + ".HireDate";
this.EndWorkDateFN = m_TableName + ".EndWorkDate";
this.EndReasonIDFN = m_TableName + ".EndReasonID";
this.IsSuspendedFN = m_TableName + ".IsSuspended";
this.SuspendedFromDateFN = m_TableName + ".SuspendedFromDate";
this.SuspendedToDateFN = m_TableName + ".SuspendedToDate";
this.SuspendedReasonIDFN = m_TableName + ".SuspendedReasonID";
this.EmployeeGroupFN = m_TableName + ".EmployeeGroup";
this.ManagerIDFN = m_TableName + ".ManagerID";
this.DepartmentIDFN = m_TableName + ".DepartmentID";
this.JobTitleIDFN = m_TableName + ".JobTitleID";
this.EmployeeGradeFN = m_TableName + ".EmployeeGrade";
this.GradeCircleNoFN = m_TableName + ".GradeCircleNo";
this.ShiftIDFN = m_TableName + ".ShiftID";
this.InsuranceCategoryIDFN = m_TableName + ".InsuranceCategoryID";
this.NotesFN = m_TableName + ".Notes";
this.IsActiveFN = m_TableName + ".IsActive";
this.CreationUserIDFN = m_TableName + ".CreationUserID";
this.CreationDateFN = m_TableName + ".CreationDate";
this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
this.PCNameFN = m_TableName + ".PCName";
this.NetUserNameFN = m_TableName + ".NetUserName";
this.TitleOfCourtesyFN = m_TableName + ".TitleOfCourtesy";
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
sSQL += " , " + EmpFileNoFN;
sSQL += " , " + EmpCardIDFN;
sSQL += " , " + FirstNameEnFN;
sSQL += " , " + SecondNameEnFN;
sSQL += " , " + ThirdNameEnFN;
sSQL += " , " + FamilyNameEnFN;
sSQL += " , " + FirstNameArFN;
sSQL += " , " + SecondNameArFN;
sSQL += " , " + ThirdNameArFN;
sSQL += " , " + FamilyNameArFN;
sSQL += " , " + SurnameEnFN;
sSQL += " , " + SurnameArFN;
sSQL += " , " + EmpPictureFN;
sSQL += " , " + HomeCountryIDFN;
sSQL += " , " + HomeCityIDFN;
sSQL += " , " + POBoxFN;
sSQL += " , " + PhoneFN;
sSQL += " , " + MobileFN;
sSQL += " , " + FaxFN;
sSQL += " , " + EmailFN;
sSQL += " , " + InternalEmailFN;
sSQL += " , " + ZipCodeFN;
sSQL += " , " + AddressFN;
sSQL += " , " + HomeCountryAddressFN;
sSQL += " , " + IdentityCardFN;
sSQL += " , " + SexFN;
sSQL += " , " + MaritalStausFN;
sSQL += " , " + ReligionIDFN;
sSQL += " , " + NationalityIDFN;
//sSQL += " , " + BloodTypeFN;
sSQL += " , " + PassportNoFN;
sSQL += " , " + IssuePlaceFN;
sSQL += " , " + PassportIssueDateFN;
sSQL += " , " + PassportExpireDateFN;
sSQL += " , " + BirthDateFN;
sSQL += " , " + BirthCountryIDFN;
sSQL += " , " + BirthCityIDFN;
sSQL += " , " + IsFullTimeFN;
sSQL += " , " + ContractTypeFN;
sSQL += " , " + ContractIssueDateFN;
sSQL += " , " + ContractExpireDateFN;
sSQL += " , " + HireDateFN;
sSQL += " , " + EndWorkDateFN;
sSQL += " , " + EndReasonIDFN;
sSQL += " , " + IsSuspendedFN;
sSQL += " , " + SuspendedFromDateFN;
sSQL += " , " + SuspendedToDateFN;
sSQL += " , " + SuspendedReasonIDFN;
sSQL += " , " + EmployeeGroupFN;
sSQL += " , " + ManagerIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + JobTitleIDFN;
sSQL += " , " + EmployeeGradeFN;
sSQL += " , " + GradeCircleNoFN;
sSQL += " , " + ShiftIDFN;
sSQL += " , " + InsuranceCategoryIDFN;
sSQL += " , " + NotesFN;
sSQL += " , " + IsActiveFN;
sSQL += " , (" + FirstNameEnFN + "+' '+" + FamilyNameEnFN + ") AS Name";

sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += " , " + TitleOfCourtesyFN;
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
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += EmployeeIDFN;
        sSQL += " , (" + FirstNameEnFN + "+' '+" + SecondNameEnFN + "+' '+" + ThirdNameEnFN  +"+' '+" + FamilyNameEnFN + ") AS Name";
        sSQL += "  FROM " + m_TableName;
        sSQL += sWhere;
        sSQL += " Order By (" + FirstNameEnFN + "+' '+" + SecondNameEnFN  + "+' '+" + ThirdNameEnFN + "+' '+" + FamilyNameEnFN + ")";
        
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
sSQL += " , " + EmpFileNoFN;
sSQL += " , " + EmpCardIDFN;
sSQL += " , " + FirstNameEnFN;
sSQL += " , " + SecondNameEnFN;
sSQL += " , " + ThirdNameEnFN;
sSQL += " , " + FamilyNameEnFN;
sSQL += " , " + FirstNameArFN;
sSQL += " , " + SecondNameArFN;
sSQL += " , " + ThirdNameArFN;
sSQL += " , " + FamilyNameArFN;
sSQL += " , " + SurnameEnFN;
sSQL += " , " + SurnameArFN;
sSQL += " , " + EmpPictureFN;
sSQL += " , " + HomeCountryIDFN;
sSQL += " , " + HomeCityIDFN;
sSQL += " , " + POBoxFN;
sSQL += " , " + PhoneFN;
sSQL += " , " + MobileFN;
sSQL += " , " + FaxFN;
sSQL += " , " + EmailFN;
sSQL += " , " + InternalEmailFN;
sSQL += " , " + ZipCodeFN;
sSQL += " , " + AddressFN;
sSQL += " , " + HomeCountryAddressFN;
sSQL += " , " + IdentityCardFN;
sSQL += " , " + SexFN;
sSQL += " , " + MaritalStausFN;
sSQL += " , " + ReligionIDFN;
sSQL += " , " + NationalityIDFN;
//sSQL += " , " + BloodTypeFN;
sSQL += " , " + PassportNoFN;
sSQL += " , " + IssuePlaceFN;
sSQL += " , " + PassportIssueDateFN;
sSQL += " , " + PassportExpireDateFN;
sSQL += " , " + BirthDateFN;
sSQL += " , " + BirthCountryIDFN;
sSQL += " , " + BirthCityIDFN;
sSQL += " , " + IsFullTimeFN;
sSQL += " , " + ContractTypeFN;
sSQL += " , " + ContractIssueDateFN;
sSQL += " , " + ContractExpireDateFN;
sSQL += " , " + HireDateFN;
sSQL += " , " + EndWorkDateFN;
sSQL += " , " + EndReasonIDFN;
sSQL += " , " + IsSuspendedFN;
sSQL += " , " + SuspendedFromDateFN;
sSQL += " , " + SuspendedToDateFN;
sSQL += " , " + SuspendedReasonIDFN;
sSQL += " , " + EmployeeGroupFN;
sSQL += " , " + ManagerIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + JobTitleIDFN;
sSQL += " , " + EmployeeGradeFN;
sSQL += " , " + GradeCircleNoFN;
sSQL += " , " + ShiftIDFN;
sSQL += " , " + InsuranceCategoryIDFN;
sSQL += " , " + NotesFN;
sSQL += " , " + IsActiveFN;
sSQL += " , (" + FirstNameEnFN + "+' '+" + FamilyNameEnFN + ") AS Name";

sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += " , " + TitleOfCourtesyFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(EmpFileNoFN) + "=@EmpFileNo";
sSQL += " , " + LibraryMOD.GetFieldName(EmpCardIDFN) + "=@EmpCardID";
sSQL += " , " + LibraryMOD.GetFieldName(FirstNameEnFN) + "=@FirstNameEn";
sSQL += " , " + LibraryMOD.GetFieldName(SecondNameEnFN) + "=@SecondNameEn";
sSQL += " , " + LibraryMOD.GetFieldName(ThirdNameEnFN) + "=@ThirdNameEn";
sSQL += " , " + LibraryMOD.GetFieldName(FamilyNameEnFN) + "=@FamilyNameEn";
sSQL += " , " + LibraryMOD.GetFieldName(FirstNameArFN) + "=@FirstNameAr";
sSQL += " , " + LibraryMOD.GetFieldName(SecondNameArFN) + "=@SecondNameAr";
sSQL += " , " + LibraryMOD.GetFieldName(ThirdNameArFN) + "=@ThirdNameAr";
sSQL += " , " + LibraryMOD.GetFieldName(FamilyNameArFN) + "=@FamilyNameAr";
//sSQL += " , " + LibraryMOD.GetFieldName(SurnameEnFN) + "=@SurnameEn";
//sSQL += " , " + LibraryMOD.GetFieldName(SurnameArFN) + "=@SurnameAr";
//sSQL += " , " + LibraryMOD.GetFieldName(EmpPictureFN) + "=@EmpPicture";
//sSQL += " , " + LibraryMOD.GetFieldName(HomeCountryIDFN) + "=@HomeCountryID";
//sSQL += " , " + LibraryMOD.GetFieldName(HomeCityIDFN) + "=@HomeCityID";
//sSQL += " , " + LibraryMOD.GetFieldName(POBoxFN) + "=@POBox";
sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN) + "=@Phone";
sSQL += " , " + LibraryMOD.GetFieldName(MobileFN) + "=@Mobile";
sSQL += " , " + LibraryMOD.GetFieldName(FaxFN) + "=@Fax";
sSQL += " , " + LibraryMOD.GetFieldName(EmailFN) + "=@Email";
sSQL += " , " + LibraryMOD.GetFieldName(InternalEmailFN) + "=@InternalEmail";
//sSQL += " , " + LibraryMOD.GetFieldName(ZipCodeFN) + "=@ZipCode";
sSQL += " , " + LibraryMOD.GetFieldName(AddressFN) + "=@Address";
sSQL += " , " + LibraryMOD.GetFieldName(HomeCountryAddressFN) + "=@HomeCountryAddress";
sSQL += " , " + LibraryMOD.GetFieldName(IdentityCardFN) + "=@IdentityCard";
sSQL += " , " + LibraryMOD.GetFieldName(SexFN) + "=@Sex";
sSQL += " , " + LibraryMOD.GetFieldName(MaritalStausFN) + "=@MaritalStaus";
//sSQL += " , " + LibraryMOD.GetFieldName(ReligionIDFN) + "=@ReligionID";
sSQL += " , " + LibraryMOD.GetFieldName(NationalityIDFN) + "=@NationalityID";
//sSQL += " , " + LibraryMOD.GetFieldName(BloodTypeFN) + "=@BloodType";
sSQL += " , " + LibraryMOD.GetFieldName(PassportNoFN) + "=@PassportNo";
sSQL += " , " + LibraryMOD.GetFieldName(IssuePlaceFN) + "=@IssuePlace";
sSQL += " , " + LibraryMOD.GetFieldName(PassportIssueDateFN) + "=@PassportIssueDate";
sSQL += " , " + LibraryMOD.GetFieldName(PassportExpireDateFN) + "=@PassportExpireDate";
sSQL += " , " + LibraryMOD.GetFieldName(BirthDateFN) + "=@BirthDate";
sSQL += " , " + LibraryMOD.GetFieldName(BirthCountryIDFN) + "=@BirthCountryID";
sSQL += " , " + LibraryMOD.GetFieldName(BirthCityIDFN) + "=@BirthCityID";
//sSQL += " , " + LibraryMOD.GetFieldName(IsFullTimeFN) + "=@IsFullTime";
//sSQL += " , " + LibraryMOD.GetFieldName(ContractTypeFN) + "=@ContractType";
//sSQL += " , " + LibraryMOD.GetFieldName(ContractIssueDateFN) + "=@ContractIssueDate";
//sSQL += " , " + LibraryMOD.GetFieldName(ContractExpireDateFN) + "=@ContractExpireDate";
//sSQL += " , " + LibraryMOD.GetFieldName(HireDateFN) + "=@HireDate";
//sSQL += " , " + LibraryMOD.GetFieldName(EndWorkDateFN) + "=@EndWorkDate";
//sSQL += " , " + LibraryMOD.GetFieldName(EndReasonIDFN) + "=@EndReasonID";
//sSQL += " , " + LibraryMOD.GetFieldName(IsSuspendedFN) + "=@IsSuspended";
//sSQL += " , " + LibraryMOD.GetFieldName(SuspendedFromDateFN) + "=@SuspendedFromDate";
//sSQL += " , " + LibraryMOD.GetFieldName(SuspendedToDateFN) + "=@SuspendedToDate";
//sSQL += " , " + LibraryMOD.GetFieldName(SuspendedReasonIDFN) + "=@SuspendedReasonID";
//sSQL += " , " + LibraryMOD.GetFieldName(EmployeeGroupFN) + "=@EmployeeGroup";
//sSQL += " , " + LibraryMOD.GetFieldName(ManagerIDFN) + "=@ManagerID";
//sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN) + "=@DepartmentID";
//sSQL += " , " + LibraryMOD.GetFieldName(JobTitleIDFN) + "=@JobTitleID";
//sSQL += " , " + LibraryMOD.GetFieldName(EmployeeGradeFN) + "=@EmployeeGrade";
//sSQL += " , " + LibraryMOD.GetFieldName(GradeCircleNoFN) + "=@GradeCircleNo";
//sSQL += " , " + LibraryMOD.GetFieldName(ShiftIDFN) + "=@ShiftID";
//sSQL += " , " + LibraryMOD.GetFieldName(InsuranceCategoryIDFN) + "=@InsuranceCategoryID";
//sSQL += " , " + LibraryMOD.GetFieldName(NotesFN) + "=@Notes";
//sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " , " + LibraryMOD.GetFieldName(TitleOfCourtesyFN) + "=@TitleOfCourtesy";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
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
sSQL += " , " + LibraryMOD.GetFieldName(EmpFileNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(EmpCardIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(FirstNameEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(SecondNameEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(ThirdNameEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(FamilyNameEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(FirstNameArFN);
sSQL += " , " + LibraryMOD.GetFieldName(SecondNameArFN);
sSQL += " , " + LibraryMOD.GetFieldName(ThirdNameArFN);
sSQL += " , " + LibraryMOD.GetFieldName(FamilyNameArFN);
//sSQL += " , " + LibraryMOD.GetFieldName(SurnameEnFN);
//sSQL += " , " + LibraryMOD.GetFieldName(SurnameArFN);
//sSQL += " , " + LibraryMOD.GetFieldName(EmpPictureFN);
//sSQL += " , " + LibraryMOD.GetFieldName(HomeCountryIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(HomeCityIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(POBoxFN);
sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN);
sSQL += " , " + LibraryMOD.GetFieldName(MobileFN);
sSQL += " , " + LibraryMOD.GetFieldName(FaxFN);
sSQL += " , " + LibraryMOD.GetFieldName(EmailFN);
sSQL += " , " + LibraryMOD.GetFieldName(InternalEmailFN);
//sSQL += " , " + LibraryMOD.GetFieldName(ZipCodeFN);
sSQL += " , " + LibraryMOD.GetFieldName(AddressFN);
sSQL += " , " + LibraryMOD.GetFieldName(HomeCountryAddressFN);
sSQL += " , " + LibraryMOD.GetFieldName(IdentityCardFN);
sSQL += " , " + LibraryMOD.GetFieldName(SexFN);
sSQL += " , " + LibraryMOD.GetFieldName(MaritalStausFN);
//sSQL += " , " + LibraryMOD.GetFieldName(ReligionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(NationalityIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(BloodTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(PassportNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(IssuePlaceFN);
sSQL += " , " + LibraryMOD.GetFieldName(PassportIssueDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PassportExpireDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(BirthDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(BirthCountryIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(BirthCityIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(IsFullTimeFN);
//sSQL += " , " + LibraryMOD.GetFieldName(ContractTypeFN);
//sSQL += " , " + LibraryMOD.GetFieldName(ContractIssueDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(ContractExpireDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(HireDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(EndWorkDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(EndReasonIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(IsSuspendedFN);
//sSQL += " , " + LibraryMOD.GetFieldName(SuspendedFromDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(SuspendedToDateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(SuspendedReasonIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(EmployeeGroupFN);
//sSQL += " , " + LibraryMOD.GetFieldName(ManagerIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(JobTitleIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(EmployeeGradeFN);
//sSQL += " , " + LibraryMOD.GetFieldName(GradeCircleNoFN);
//sSQL += " , " + LibraryMOD.GetFieldName(ShiftIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(InsuranceCategoryIDFN);
//sSQL += " , " + LibraryMOD.GetFieldName(NotesFN);
//sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(TitleOfCourtesyFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @EmployeeID";
sSQL += " ,@EmpFileNo";
sSQL += " ,@EmpCardID";
sSQL += " ,@FirstNameEn";
sSQL += " ,@SecondNameEn";
sSQL += " ,@ThirdNameEn";
sSQL += " ,@FamilyNameEn";
sSQL += " ,@FirstNameAr";
sSQL += " ,@SecondNameAr";
sSQL += " ,@ThirdNameAr";
sSQL += " ,@FamilyNameAr";
//sSQL += " ,@SurnameEn";
//sSQL += " ,@SurnameAr";
//sSQL += " ,@EmpPicture";
//sSQL += " ,@HomeCountryID";
//sSQL += " ,@HomeCityID";
//sSQL += " ,@POBox";
sSQL += " ,@Phone";
sSQL += " ,@Mobile";
sSQL += " ,@Fax";
sSQL += " ,@Email";
sSQL += " ,@InternalEmail";
//sSQL += " ,@ZipCode";
sSQL += " ,@Address";
sSQL += " ,@HomeCountryAddress";
sSQL += " ,@IdentityCard";
sSQL += " ,@Sex";
sSQL += " ,@MaritalStaus";
//sSQL += " ,@ReligionID";
sSQL += " ,@NationalityID";
//sSQL += " ,@BloodType";
sSQL += " ,@PassportNo";
sSQL += " ,@IssuePlace";
sSQL += " ,@PassportIssueDate";
sSQL += " ,@PassportExpireDate";
sSQL += " ,@BirthDate";
sSQL += " ,@BirthCountryID";
sSQL += " ,@BirthCityID";
//sSQL += " ,@IsFullTime";
//sSQL += " ,@ContractType";
//sSQL += " ,@ContractIssueDate";
//sSQL += " ,@ContractExpireDate";
//sSQL += " ,@HireDate";
//sSQL += " ,@EndWorkDate";
//sSQL += " ,@EndReasonID";
//sSQL += " ,@IsSuspended";
//sSQL += " ,@SuspendedFromDate";
//sSQL += " ,@SuspendedToDate";
//sSQL += " ,@SuspendedReasonID";
//sSQL += " ,@EmployeeGroup";
//sSQL += " ,@ManagerID";
//sSQL += " ,@DepartmentID";
//sSQL += " ,@JobTitleID";
//sSQL += " ,@EmployeeGrade";
//sSQL += " ,@GradeCircleNo";
//sSQL += " ,@ShiftID";
//sSQL += " ,@InsuranceCategoryID";
//sSQL += " ,@Notes";
//sSQL += " ,@IsActive";
sSQL += " ,@CreationUserID";
sSQL += " ,@CreationDate";
sSQL += " ,@LastUpdateUserID";
sSQL += " ,@LastUpdateDate";
sSQL += " ,@PCName";
sSQL += " ,@NetUserName";
sSQL += " ,@TitleOfCourtesy";
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
public List<Employee> GetEmployee(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
    //' returns a list of Classes instances based on the
    //' data in the Employee

    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetSQL();
    if (!string.IsNullOrEmpty(sCondition))
    {
        sSQL += sCondition;
    }

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Employee> results = new List<Employee>();
    try
    {
        //Default Value
        Employee myEmployee = new Employee();
        if (isDeafaultIncluded)
        {
            //Change the code here
            myEmployee.EmployeeID = 0;
            myEmployee.Name = "Select Employee ...";
            results.Add(myEmployee);
        }
        while (reader.Read())
        {
            myEmployee = new Employee();
            if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
            {
                myEmployee.EmployeeID = 0;
            }
            else
            {
                myEmployee.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName(EmployeeIDFN)].ToString());
            }
            myEmployee.Name = reader["Name"].ToString();
            myEmployee.EmpFileNo = reader[LibraryMOD.GetFieldName(EmpFileNoFN)].ToString();
            myEmployee.EmpCardID = reader[LibraryMOD.GetFieldName(EmpCardIDFN)].ToString();
            myEmployee.FirstNameEn = reader[LibraryMOD.GetFieldName(FirstNameEnFN)].ToString();
            myEmployee.SecondNameEn = reader[LibraryMOD.GetFieldName(SecondNameEnFN)].ToString();
            myEmployee.ThirdNameEn = reader[LibraryMOD.GetFieldName(ThirdNameEnFN)].ToString();
            myEmployee.FamilyNameEn = reader[LibraryMOD.GetFieldName(FamilyNameEnFN)].ToString();
            myEmployee.FirstNameAr = reader[LibraryMOD.GetFieldName(FirstNameArFN)].ToString();
            myEmployee.SecondNameAr = reader[LibraryMOD.GetFieldName(SecondNameArFN)].ToString();
            myEmployee.ThirdNameAr = reader[LibraryMOD.GetFieldName(ThirdNameArFN)].ToString();
            myEmployee.FamilyNameAr = reader[LibraryMOD.GetFieldName(FamilyNameArFN)].ToString();

            if (reader[LibraryMOD.GetFieldName(EmpPictureFN)].Equals(DBNull.Value))
            {

            }
            else
            { 
            
            myEmployee.EmpPicture = (Image )reader[LibraryMOD.GetFieldName(EmpPictureFN)];
            }
            
            
        //        if  (myEmployee.EmpPicture.ImageUrl =="") 
        //        {
                    
        //        }
        //        else 
        //        {
        //            //Dim bits As Byte() = CType(myEmployee.EmpPicture, Byte())
        //            //If bits.Length > 100 Then

        //            //    Dim memorybits As New IO.MemoryStream(bits)
        //            //    Dim bitmap As New Bitmap(memorybits)
        //            //    PicEmployee.Image = bitmap
        //            //Else
        //            //    PicEmployee.Image = Nothing
        //            //End If
        //            //' PicEmployee.Image = .EmpPicture
        //}


            myEmployee.HomeCountryAddress  = reader[LibraryMOD.GetFieldName(HomeCountryAddressFN)].ToString();
            myEmployee.IdentityCard = reader[LibraryMOD.GetFieldName(IdentityCardFN)].ToString();

            if (reader[LibraryMOD.GetFieldName(HomeCountryIDFN)].Equals(DBNull.Value))
            {
                myEmployee.HomeCountryID = 0;
            }
            else
            {
                myEmployee.HomeCountryID = int.Parse(reader[LibraryMOD.GetFieldName(HomeCountryIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(HomeCityIDFN)].Equals(DBNull.Value))
            {
                myEmployee.HomeCityID = 0;
            }
            else
            {
                myEmployee.HomeCityID = int.Parse(reader[LibraryMOD.GetFieldName(HomeCityIDFN)].ToString());
            }
            myEmployee.POBox = reader[LibraryMOD.GetFieldName(POBoxFN)].ToString();
            myEmployee.Phone = reader[LibraryMOD.GetFieldName(PhoneFN)].ToString();
            myEmployee.Mobile = reader[LibraryMOD.GetFieldName(MobileFN)].ToString();
            myEmployee.Fax = reader[LibraryMOD.GetFieldName(FaxFN)].ToString();
            myEmployee.Email = reader[LibraryMOD.GetFieldName(EmailFN)].ToString();
            myEmployee.InternalEmail = reader[LibraryMOD.GetFieldName(InternalEmailFN)].ToString();
            myEmployee.ZipCode = reader[LibraryMOD.GetFieldName(ZipCodeFN)].ToString();
            myEmployee.Address = reader[LibraryMOD.GetFieldName(AddressFN)].ToString();
            if (reader[LibraryMOD.GetFieldName(SexFN)].Equals(DBNull.Value))
            {
                myEmployee.Sex = 0;
            }
            else
            {
                myEmployee.Sex = int.Parse(reader[LibraryMOD.GetFieldName(SexFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(MaritalStausFN)].Equals(DBNull.Value))
            {
                myEmployee.MaritalStaus = 0;
            }
            else
            {
                myEmployee.MaritalStaus = int.Parse(reader[LibraryMOD.GetFieldName(MaritalStausFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(ReligionIDFN)].Equals(DBNull.Value))
            {
                myEmployee.ReligionID = 0;
            }
            else
            {
                myEmployee.ReligionID = int.Parse(reader[LibraryMOD.GetFieldName(ReligionIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(NationalityIDFN)].Equals(DBNull.Value))
            {
                myEmployee.NationalityID = 0;
            }
            else
            {
                myEmployee.NationalityID = int.Parse(reader[LibraryMOD.GetFieldName(NationalityIDFN)].ToString());
            }
            //myEmployee.BloodType = reader[LibraryMOD.GetFieldName(BloodTypeFN)].ToString();
            myEmployee.PassportNo = reader[LibraryMOD.GetFieldName(PassportNoFN)].ToString();
            myEmployee.IssuePlace = reader[LibraryMOD.GetFieldName(IssuePlaceFN)].ToString();
            if (reader[LibraryMOD.GetFieldName(PassportIssueDateFN)].Equals(DBNull.Value))
            {
                myEmployee.PassportIssueDate = 0;
            }
            else
            {
                myEmployee.PassportIssueDate = int.Parse(reader[LibraryMOD.GetFieldName(PassportIssueDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(PassportExpireDateFN)].Equals(DBNull.Value))
            {
                myEmployee.PassportExpireDate = 0;
            }
            else
            {
                myEmployee.PassportExpireDate = int.Parse(reader[LibraryMOD.GetFieldName(PassportExpireDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(BirthDateFN)].Equals(DBNull.Value))
            {
                myEmployee.BirthDate = 0;
            }
            else
            {
                myEmployee.BirthDate = int.Parse(reader[LibraryMOD.GetFieldName(BirthDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(BirthCountryIDFN)].Equals(DBNull.Value))
            {
                myEmployee.BirthCountryID = 0;
            }
            else
            {
                myEmployee.BirthCountryID = int.Parse(reader[LibraryMOD.GetFieldName(BirthCountryIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(BirthCityIDFN)].Equals(DBNull.Value))
            {
                myEmployee.BirthCityID = 0;
            }
            else
            {
                myEmployee.BirthCityID = int.Parse(reader[LibraryMOD.GetFieldName(BirthCityIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(IsFullTimeFN)].Equals(DBNull.Value))
            {
                myEmployee.IsFullTime = 0;
            }
            else
            {
                myEmployee.IsFullTime = int.Parse(reader[LibraryMOD.GetFieldName(IsFullTimeFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(ContractTypeFN)].Equals(DBNull.Value))
            {
                myEmployee.ContractType = 0;
            }
            else
            {
                myEmployee.ContractType = int.Parse(reader[LibraryMOD.GetFieldName(ContractTypeFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(ContractIssueDateFN)].Equals(DBNull.Value))
            {
                myEmployee.ContractIssueDate = 0;
            }
            else
            {
                myEmployee.ContractIssueDate = int.Parse(reader[LibraryMOD.GetFieldName(ContractIssueDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(ContractExpireDateFN)].Equals(DBNull.Value))
            {
                myEmployee.ContractExpireDate = 0;
            }
            else
            {
                myEmployee.ContractExpireDate = int.Parse(reader[LibraryMOD.GetFieldName(ContractExpireDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(HireDateFN)].Equals(DBNull.Value))
            {
                myEmployee.HireDate = 0;
            }
            else
            {
                myEmployee.HireDate = int.Parse(reader[LibraryMOD.GetFieldName(HireDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(EndWorkDateFN)].Equals(DBNull.Value))
            {
                myEmployee.EndWorkDate = 0;
            }
            else
            {
                myEmployee.EndWorkDate = int.Parse(reader[LibraryMOD.GetFieldName(EndWorkDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(EndReasonIDFN)].Equals(DBNull.Value))
            {
                myEmployee.EndReasonID = 0;
            }
            else
            {
                myEmployee.EndReasonID = int.Parse(reader[LibraryMOD.GetFieldName(EndReasonIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(IsSuspendedFN)].Equals(DBNull.Value))
            {
                myEmployee.IsSuspended = 0;
            }
            else
            {
                myEmployee.IsSuspended = int.Parse(reader[LibraryMOD.GetFieldName(IsSuspendedFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(SuspendedFromDateFN)].Equals(DBNull.Value))
            {
                myEmployee.SuspendedFromDate = 0;
            }
            else
            {
                myEmployee.SuspendedFromDate = int.Parse(reader[LibraryMOD.GetFieldName(SuspendedFromDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(SuspendedToDateFN)].Equals(DBNull.Value))
            {
                myEmployee.SuspendedToDate = 0;
            }
            else
            {
                myEmployee.SuspendedToDate = int.Parse(reader[LibraryMOD.GetFieldName(SuspendedToDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(SuspendedReasonIDFN)].Equals(DBNull.Value))
            {
                myEmployee.SuspendedReasonID = 0;
            }
            else
            {
                myEmployee.SuspendedReasonID = int.Parse(reader[LibraryMOD.GetFieldName(SuspendedReasonIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(EmployeeGroupFN)].Equals(DBNull.Value))
            {
                myEmployee.EmployeeGroup = 0;
            }
            else
            {
                myEmployee.EmployeeGroup = int.Parse(reader[LibraryMOD.GetFieldName(EmployeeGroupFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(ManagerIDFN)].Equals(DBNull.Value))
            {
                myEmployee.ManagerID = 0;
            }
            else
            {
                myEmployee.ManagerID = int.Parse(reader[LibraryMOD.GetFieldName(ManagerIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
            {
                myEmployee.DepartmentID = 0;
            }
            else
            {
                myEmployee.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName(DepartmentIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(JobTitleIDFN)].Equals(DBNull.Value))
            {
                myEmployee.JobTitleID = 0;
            }
            else
            {
                myEmployee.JobTitleID = int.Parse(reader[LibraryMOD.GetFieldName(JobTitleIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(EmployeeGradeFN)].Equals(DBNull.Value))
            {
                myEmployee.EmployeeGrade = 0;
            }
            else
            {
                myEmployee.EmployeeGrade = int.Parse(reader[LibraryMOD.GetFieldName(EmployeeGradeFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(GradeCircleNoFN)].Equals(DBNull.Value))
            {
                myEmployee.GradeCircleNo = 0;
            }
            else
            {
                myEmployee.GradeCircleNo = int.Parse(reader[LibraryMOD.GetFieldName(GradeCircleNoFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(ShiftIDFN)].Equals(DBNull.Value))
            {
                myEmployee.ShiftID = 0;
            }
            else
            {
                myEmployee.ShiftID = int.Parse(reader[LibraryMOD.GetFieldName(ShiftIDFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(InsuranceCategoryIDFN)].Equals(DBNull.Value))
            {
                myEmployee.InsuranceCategoryID = 0;
            }
            else
            {
                myEmployee.InsuranceCategoryID = int.Parse(reader[LibraryMOD.GetFieldName(InsuranceCategoryIDFN)].ToString());
            }
            myEmployee.Notes = reader[LibraryMOD.GetFieldName(NotesFN)].ToString();
            if (reader[LibraryMOD.GetFieldName(IsActiveFN)].Equals(DBNull.Value))
            {
                myEmployee.IsActive = 0;
            }
            else
            {
                myEmployee.IsActive = int.Parse(reader[LibraryMOD.GetFieldName(IsActiveFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
            {
                myEmployee.CreationUserID = 0;
            }
            else
            {
                myEmployee.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
            }
            if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
            {
                myEmployee.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
            }
            if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
            {
                myEmployee.LastUpdateUserID = 0;
            }
            else
            {
                myEmployee.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
            }
            if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
            {
                myEmployee.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
            }
            myEmployee.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
            myEmployee.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
            myEmployee.TitleOfCourtesy = reader[LibraryMOD.GetFieldName(TitleOfCourtesyFN)].ToString();
            results.Add(myEmployee);
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

    public List< Employee > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Employee> results = new List<Employee>();
    try
    {
        //Default Value
        Employee myEmployee = new Employee();
        if (isDeafaultIncluded)
        {
            //Change the code here
            myEmployee.EmployeeID = 0;
            myEmployee.Name = "Select Employee ...";
            results.Add(myEmployee);
        }
        while (reader.Read())
        {
            myEmployee = new Employee();
            if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
            {
                myEmployee.EmployeeID = 0;
            }
            else
            {
                myEmployee.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName(EmployeeIDFN)].ToString());
            }
            myEmployee.Name = reader["Name"].ToString();

            results.Add(myEmployee);
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
    public int UpdateEmployee(InitializeModule.EnumCampus Campus, int iMode, int EmployeeID, string EmpFileNo, string EmpCardID, string FirstNameEn, string SecondNameEn, string ThirdNameEn, string FamilyNameEn, string FirstNameAr, string SecondNameAr, string ThirdNameAr, string FamilyNameAr, string SurnameEn, string SurnameAr, Image  EmpPicture, int HomeCountryID, int HomeCityID, string POBox, string Phone, string Mobile, string Fax, string Email, string InternalEmail, string ZipCode, string Address, string HomeCountryAddress, string IdentityCard, int Sex, int MaritalStaus, int ReligionID, int NationalityID, string PassportNo, string IssuePlace, int PassportIssueDate, int PassportExpireDate, int BirthDate, int BirthCountryID, int BirthCityID, int IsFullTime, int ContractType, int ContractIssueDate, int ContractExpireDate, int HireDate, int EndWorkDate, int EndReasonID, int IsSuspended, int SuspendedFromDate, int SuspendedToDate, int SuspendedReasonID, int EmployeeGroup, int ManagerID, int DepartmentID, int JobTitleID, int EmployeeGrade, int GradeCircleNo, int ShiftID, int InsuranceCategoryID, string Notes, int IsActive, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName, string TitleOfCourtesy) //string BloodType,
{
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        Conn.Open();
        string sql = "";
        Employee theEmployee = new Employee();
        //'Updates the  table
        switch (iMode)
        {
            case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                sql = GetUpdateCommand();
                break;
            case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
                sql = GetInsertCommand();
                break;
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);
        Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
        Cmd.Parameters.Add(new SqlParameter("@EmpFileNo", EmpFileNo));
        Cmd.Parameters.Add(new SqlParameter("@EmpCardID", EmpCardID));
        Cmd.Parameters.Add(new SqlParameter("@FirstNameEn", FirstNameEn));
        Cmd.Parameters.Add(new SqlParameter("@SecondNameEn", SecondNameEn));
        Cmd.Parameters.Add(new SqlParameter("@ThirdNameEn", ThirdNameEn));
        Cmd.Parameters.Add(new SqlParameter("@FamilyNameEn", FamilyNameEn));
        Cmd.Parameters.Add(new SqlParameter("@FirstNameAr", FirstNameAr));
        Cmd.Parameters.Add(new SqlParameter("@SecondNameAr", SecondNameAr));
        Cmd.Parameters.Add(new SqlParameter("@ThirdNameAr", ThirdNameAr));
        Cmd.Parameters.Add(new SqlParameter("@FamilyNameAr", FamilyNameAr));
        //Cmd.Parameters.Add(new SqlParameter("@SurnameEn", SurnameEn));
        //Cmd.Parameters.Add(new SqlParameter("@SurnameAr", SurnameAr));
      //  Cmd.Parameters.Add(new SqlParameter("@EmpPicture", EmpPicture));
        Cmd.Parameters.Add(new SqlParameter("@HomeCountryID", HomeCountryID));
        Cmd.Parameters.Add(new SqlParameter("@HomeCityID", HomeCityID));
        //Cmd.Parameters.Add(new SqlParameter("@POBox", POBox));
        Cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
        Cmd.Parameters.Add(new SqlParameter("@Mobile", Mobile));
        Cmd.Parameters.Add(new SqlParameter("@Fax", Fax));
        Cmd.Parameters.Add(new SqlParameter("@Email", Email));
        Cmd.Parameters.Add(new SqlParameter("@InternalEmail", InternalEmail));
        //Cmd.Parameters.Add(new SqlParameter("@ZipCode", ZipCode));
        Cmd.Parameters.Add(new SqlParameter("@Address", Address));
        Cmd.Parameters.Add(new SqlParameter("@HomeCountryAddress", HomeCountryAddress));
        Cmd.Parameters.Add(new SqlParameter("@IdentityCard", IdentityCard));
        Cmd.Parameters.Add(new SqlParameter("@Sex", Sex));
        Cmd.Parameters.Add(new SqlParameter("@MaritalStaus", MaritalStaus));
        //Cmd.Parameters.Add(new SqlParameter("@ReligionID", ReligionID));
        Cmd.Parameters.Add(new SqlParameter("@NationalityID", NationalityID));
        //Cmd.Parameters.Add(new SqlParameter("@BloodType", BloodType));
        Cmd.Parameters.Add(new SqlParameter("@PassportNo", PassportNo));
        Cmd.Parameters.Add(new SqlParameter("@IssuePlace", IssuePlace));
        Cmd.Parameters.Add(new SqlParameter("@PassportIssueDate", PassportIssueDate));
        Cmd.Parameters.Add(new SqlParameter("@PassportExpireDate", PassportExpireDate));
        Cmd.Parameters.Add(new SqlParameter("@BirthDate", BirthDate));
        Cmd.Parameters.Add(new SqlParameter("@BirthCountryID", BirthCountryID));
        Cmd.Parameters.Add(new SqlParameter("@BirthCityID", BirthCityID));
        //Cmd.Parameters.Add(new SqlParameter("@IsFullTime", IsFullTime));
        //Cmd.Parameters.Add(new SqlParameter("@ContractType", ContractType));
        //Cmd.Parameters.Add(new SqlParameter("@ContractIssueDate", ContractIssueDate));
        //Cmd.Parameters.Add(new SqlParameter("@ContractExpireDate", ContractExpireDate));
        //Cmd.Parameters.Add(new SqlParameter("@HireDate", HireDate));
        //Cmd.Parameters.Add(new SqlParameter("@EndWorkDate", EndWorkDate));
        //Cmd.Parameters.Add(new SqlParameter("@EndReasonID", EndReasonID));
        //Cmd.Parameters.Add(new SqlParameter("@IsSuspended", IsSuspended));
        //Cmd.Parameters.Add(new SqlParameter("@SuspendedFromDate", SuspendedFromDate));
        //Cmd.Parameters.Add(new SqlParameter("@SuspendedToDate", SuspendedToDate));
        //Cmd.Parameters.Add(new SqlParameter("@SuspendedReasonID", SuspendedReasonID));
        //Cmd.Parameters.Add(new SqlParameter("@EmployeeGroup", EmployeeGroup));
        //Cmd.Parameters.Add(new SqlParameter("@ManagerID", ManagerID));
        //Cmd.Parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
        //Cmd.Parameters.Add(new SqlParameter("@JobTitleID", JobTitleID));
        //Cmd.Parameters.Add(new SqlParameter("@EmployeeGrade", EmployeeGrade));
        //Cmd.Parameters.Add(new SqlParameter("@GradeCircleNo", GradeCircleNo));
        //Cmd.Parameters.Add(new SqlParameter("@ShiftID", ShiftID));
        //Cmd.Parameters.Add(new SqlParameter("@InsuranceCategoryID", InsuranceCategoryID));
        //Cmd.Parameters.Add(new SqlParameter("@Notes", Notes));
        //Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
        Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
        Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
        Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
        Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", LastUpdateDate));
        Cmd.Parameters.Add(new SqlParameter("@PCName", PCName));
        Cmd.Parameters.Add(new SqlParameter("@NetUserName", NetUserName));
        Cmd.Parameters.Add(new SqlParameter("@TitleOfCourtesy", TitleOfCourtesy));
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
public int DeleteEmployee(InitializeModule.EnumCampus Campus, int EmployeeID)
{
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        string sSQL = GetDeleteCommand();
        //sSQL += sCondition;
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));

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

public DataView GetDataView(string sCondition)
{
    DataTable dt = new DataTable("Employees");
    DataView dv = new DataView();
    List<Employee> myEmployees = new List<Employee>();
    try
    {
        myEmployees = GetList(InitializeModule.EnumCampus.ECTNew, sCondition, false);
        DataColumn col1 = new DataColumn("EmployeeID", Type.GetType("int"));
        dt.Columns.Add(col1);
        DataColumn col2 = new DataColumn("Name", Type.GetType("nvarchar"));
        dt.Columns.Add(col2);

        dt.Constraints.Add(new UniqueConstraint(col1));

        DataRow dr;
        for (int i = 0; i < myEmployees.Count; i++)
        {
            dr = dt.NewRow();
            dr[1] = myEmployees[i].EmployeeID;
            dr[2] = myEmployees[i].Name;
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
        myEmployees.Clear();
    }
    return dv;
}
public string GetEmployeeEmail( int iUserNo) 
{
        String sSQL ;
        String  sEmpEmail = "";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew );
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {

            sSQL = "SELECT ";
            sSQL += InternalEmailFN ;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + EmployeeIDFN + "=" + iUserNo;

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader ;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection );

            
            if ( datReader.Read() )
            {
            sEmpEmail = datReader.GetString(0);
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

        return sEmpEmail;
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
public class EmployeeCls : EmployeeDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daEmployee;
private DataSet m_dsEmployee;
public DataRow EmployeeDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsEmployee
{
get { return m_dsEmployee ; }
set { m_dsEmployee = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EmployeeCls()
{
try
{
dsEmployee= new DataSet();

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
public virtual SqlDataAdapter GetEmployeeDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daEmployee = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daEmployee);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daEmployee.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployee;
}
public virtual SqlDataAdapter GetEmployeeDataAdapter(SqlConnection con)  
{
try
{
daEmployee = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daEmployee.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdEmployee;
cmdEmployee = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, "EmployeeID" );
daEmployee.SelectCommand = cmdEmployee;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdEmployee = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdEmployee.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployee.Parameters.Add("@EmpFileNo", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(EmpFileNoFN));
cmdEmployee.Parameters.Add("@EmpCardID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(EmpCardIDFN));
cmdEmployee.Parameters.Add("@FirstNameEn", SqlDbType.VarChar,25, LibraryMOD.GetFieldName(FirstNameEnFN));
cmdEmployee.Parameters.Add("@SecondNameEn", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(SecondNameEnFN));
cmdEmployee.Parameters.Add("@ThirdNameEn", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(ThirdNameEnFN));
cmdEmployee.Parameters.Add("@FamilyNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(FamilyNameEnFN));
cmdEmployee.Parameters.Add("@FirstNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(FirstNameArFN));
cmdEmployee.Parameters.Add("@SecondNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(SecondNameArFN));
cmdEmployee.Parameters.Add("@ThirdNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(ThirdNameArFN));
cmdEmployee.Parameters.Add("@FamilyNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(FamilyNameArFN));
cmdEmployee.Parameters.Add("@SurnameEn", SqlDbType.VarChar,12, LibraryMOD.GetFieldName(SurnameEnFN));
cmdEmployee.Parameters.Add("@SurnameAr", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(SurnameArFN));
cmdEmployee.Parameters.Add("@EmpPicture", SqlDbType.Image,0, LibraryMOD.GetFieldName(EmpPictureFN));

cmdEmployee.Parameters.Add("@HomeCountryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(HomeCountryIDFN));
cmdEmployee.Parameters.Add("@HomeCityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(HomeCityIDFN));
cmdEmployee.Parameters.Add("@POBox", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(POBoxFN));
cmdEmployee.Parameters.Add("@Phone", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(PhoneFN));
cmdEmployee.Parameters.Add("@Mobile", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(MobileFN));
cmdEmployee.Parameters.Add("@Fax", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(FaxFN));
cmdEmployee.Parameters.Add("@Email", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(EmailFN));
cmdEmployee.Parameters.Add("@InternalEmail", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(InternalEmailFN));
cmdEmployee.Parameters.Add("@ZipCode", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(ZipCodeFN));
cmdEmployee.Parameters.Add("@Address", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(AddressFN));
cmdEmployee.Parameters.Add("@HomeCountryAddress", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(HomeCountryAddressFN));
cmdEmployee.Parameters.Add("@IdentityCard", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(IdentityCardFN));
cmdEmployee.Parameters.Add("@Sex", SqlDbType.Int,4, LibraryMOD.GetFieldName(SexFN));
cmdEmployee.Parameters.Add("@MaritalStaus", SqlDbType.Int,4, LibraryMOD.GetFieldName(MaritalStausFN));
cmdEmployee.Parameters.Add("@ReligionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ReligionIDFN));
cmdEmployee.Parameters.Add("@NationalityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityIDFN));
//cmdEmployee.Parameters.Add("@BloodType", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(BloodTypeFN));
cmdEmployee.Parameters.Add("@PassportNo", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(PassportNoFN));
cmdEmployee.Parameters.Add("@IssuePlace", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(IssuePlaceFN));
cmdEmployee.Parameters.Add("@PassportIssueDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(PassportIssueDateFN));
cmdEmployee.Parameters.Add("@PassportExpireDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(PassportExpireDateFN));
cmdEmployee.Parameters.Add("@BirthDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(BirthDateFN));
cmdEmployee.Parameters.Add("@BirthCountryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BirthCountryIDFN));
cmdEmployee.Parameters.Add("@BirthCityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BirthCityIDFN));
cmdEmployee.Parameters.Add("@IsFullTime", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsFullTimeFN));
cmdEmployee.Parameters.Add("@ContractType", SqlDbType.Int,4, LibraryMOD.GetFieldName(ContractTypeFN));
cmdEmployee.Parameters.Add("@ContractIssueDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(ContractIssueDateFN));
cmdEmployee.Parameters.Add("@ContractExpireDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(ContractExpireDateFN));
cmdEmployee.Parameters.Add("@HireDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(HireDateFN));
cmdEmployee.Parameters.Add("@EndWorkDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(EndWorkDateFN));
cmdEmployee.Parameters.Add("@EndReasonID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EndReasonIDFN));
cmdEmployee.Parameters.Add("@IsSuspended", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsSuspendedFN));
cmdEmployee.Parameters.Add("@SuspendedFromDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(SuspendedFromDateFN));
cmdEmployee.Parameters.Add("@SuspendedToDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(SuspendedToDateFN));
cmdEmployee.Parameters.Add("@SuspendedReasonID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SuspendedReasonIDFN));
cmdEmployee.Parameters.Add("@EmployeeGroup", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeGroupFN));
cmdEmployee.Parameters.Add("@ManagerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ManagerIDFN));
cmdEmployee.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdEmployee.Parameters.Add("@JobTitleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(JobTitleIDFN));
cmdEmployee.Parameters.Add("@EmployeeGrade", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeGradeFN));
cmdEmployee.Parameters.Add("@GradeCircleNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeCircleNoFN));
cmdEmployee.Parameters.Add("@ShiftID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ShiftIDFN));
cmdEmployee.Parameters.Add("@InsuranceCategoryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(InsuranceCategoryIDFN));
cmdEmployee.Parameters.Add("@Notes", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(NotesFN));
cmdEmployee.Parameters.Add("@IsActive", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsActiveFN));
cmdEmployee.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployee.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployee.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployee.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployee.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployee.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
cmdEmployee.Parameters.Add("@TitleOfCourtesy", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(TitleOfCourtesyFN));


Parmeter = cmdEmployee.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daEmployee.UpdateCommand = cmdEmployee;
daEmployee.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdEmployee = new SqlCommand(GetInsertCommand(), con);
cmdEmployee.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployee.Parameters.Add("@EmpFileNo", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(EmpFileNoFN));
cmdEmployee.Parameters.Add("@EmpCardID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(EmpCardIDFN));
cmdEmployee.Parameters.Add("@FirstNameEn", SqlDbType.VarChar,25, LibraryMOD.GetFieldName(FirstNameEnFN));
cmdEmployee.Parameters.Add("@SecondNameEn", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(SecondNameEnFN));
cmdEmployee.Parameters.Add("@ThirdNameEn", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(ThirdNameEnFN));
cmdEmployee.Parameters.Add("@FamilyNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(FamilyNameEnFN));
cmdEmployee.Parameters.Add("@FirstNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(FirstNameArFN));
cmdEmployee.Parameters.Add("@SecondNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(SecondNameArFN));
cmdEmployee.Parameters.Add("@ThirdNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(ThirdNameArFN));
cmdEmployee.Parameters.Add("@FamilyNameAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(FamilyNameArFN));
cmdEmployee.Parameters.Add("@SurnameEn", SqlDbType.VarChar,12, LibraryMOD.GetFieldName(SurnameEnFN));
cmdEmployee.Parameters.Add("@SurnameAr", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(SurnameArFN));
cmdEmployee.Parameters.Add("@EmpPicture", SqlDbType.Image, 0, LibraryMOD.GetFieldName(EmpPictureFN));

cmdEmployee.Parameters.Add("@HomeCountryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(HomeCountryIDFN));
cmdEmployee.Parameters.Add("@HomeCityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(HomeCityIDFN));
cmdEmployee.Parameters.Add("@POBox", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(POBoxFN));
cmdEmployee.Parameters.Add("@Phone", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(PhoneFN));
cmdEmployee.Parameters.Add("@Mobile", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(MobileFN));
cmdEmployee.Parameters.Add("@Fax", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(FaxFN));
cmdEmployee.Parameters.Add("@Email", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(EmailFN));
cmdEmployee.Parameters.Add("@InternalEmail", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(InternalEmailFN));
cmdEmployee.Parameters.Add("@ZipCode", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(ZipCodeFN));
cmdEmployee.Parameters.Add("@Address", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(AddressFN));
cmdEmployee.Parameters.Add("@HomeCountryAddress", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(HomeCountryAddressFN));
cmdEmployee.Parameters.Add("@IdentityCard", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(IdentityCardFN));
cmdEmployee.Parameters.Add("@Sex", SqlDbType.Int,4, LibraryMOD.GetFieldName(SexFN));
cmdEmployee.Parameters.Add("@MaritalStaus", SqlDbType.Int,4, LibraryMOD.GetFieldName(MaritalStausFN));
cmdEmployee.Parameters.Add("@ReligionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ReligionIDFN));
cmdEmployee.Parameters.Add("@NationalityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(NationalityIDFN));
//cmdEmployee.Parameters.Add("@BloodType", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(BloodTypeFN));
cmdEmployee.Parameters.Add("@PassportNo", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(PassportNoFN));
cmdEmployee.Parameters.Add("@IssuePlace", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(IssuePlaceFN));
cmdEmployee.Parameters.Add("@PassportIssueDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(PassportIssueDateFN));
cmdEmployee.Parameters.Add("@PassportExpireDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(PassportExpireDateFN));
cmdEmployee.Parameters.Add("@BirthDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(BirthDateFN));
cmdEmployee.Parameters.Add("@BirthCountryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BirthCountryIDFN));
cmdEmployee.Parameters.Add("@BirthCityID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BirthCityIDFN));
cmdEmployee.Parameters.Add("@IsFullTime", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsFullTimeFN));
cmdEmployee.Parameters.Add("@ContractType", SqlDbType.Int,4, LibraryMOD.GetFieldName(ContractTypeFN));
cmdEmployee.Parameters.Add("@ContractIssueDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(ContractIssueDateFN));
cmdEmployee.Parameters.Add("@ContractExpireDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(ContractExpireDateFN));
cmdEmployee.Parameters.Add("@HireDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(HireDateFN));
cmdEmployee.Parameters.Add("@EndWorkDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(EndWorkDateFN));
cmdEmployee.Parameters.Add("@EndReasonID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EndReasonIDFN));
cmdEmployee.Parameters.Add("@IsSuspended", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsSuspendedFN));
cmdEmployee.Parameters.Add("@SuspendedFromDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(SuspendedFromDateFN));
cmdEmployee.Parameters.Add("@SuspendedToDate", SqlDbType.Int,4, LibraryMOD.GetFieldName(SuspendedToDateFN));
cmdEmployee.Parameters.Add("@SuspendedReasonID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SuspendedReasonIDFN));
cmdEmployee.Parameters.Add("@EmployeeGroup", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeGroupFN));
cmdEmployee.Parameters.Add("@ManagerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ManagerIDFN));
cmdEmployee.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdEmployee.Parameters.Add("@JobTitleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(JobTitleIDFN));
cmdEmployee.Parameters.Add("@EmployeeGrade", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeGradeFN));
cmdEmployee.Parameters.Add("@GradeCircleNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeCircleNoFN));
cmdEmployee.Parameters.Add("@ShiftID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ShiftIDFN));
cmdEmployee.Parameters.Add("@InsuranceCategoryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(InsuranceCategoryIDFN));
cmdEmployee.Parameters.Add("@Notes", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(NotesFN));
cmdEmployee.Parameters.Add("@IsActive", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsActiveFN));
cmdEmployee.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployee.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployee.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployee.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployee.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployee.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
cmdEmployee.Parameters.Add("@TitleOfCourtesy", SqlDbType.NVarChar,30, LibraryMOD.GetFieldName(TitleOfCourtesyFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daEmployee.InsertCommand =cmdEmployee;
daEmployee.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdEmployee = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdEmployee.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daEmployee.DeleteCommand =cmdEmployee;
daEmployee.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daEmployee.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployee;
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
dr = dsEmployee.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
dr[LibraryMOD.GetFieldName(EmpFileNoFN)]=EmpFileNo;
dr[LibraryMOD.GetFieldName(EmpCardIDFN)]=EmpCardID;
dr[LibraryMOD.GetFieldName(FirstNameEnFN)]=FirstNameEn;
dr[LibraryMOD.GetFieldName(SecondNameEnFN)]=SecondNameEn;
dr[LibraryMOD.GetFieldName(ThirdNameEnFN)]=ThirdNameEn;
dr[LibraryMOD.GetFieldName(FamilyNameEnFN)]=FamilyNameEn;
dr[LibraryMOD.GetFieldName(FirstNameArFN)]=FirstNameAr;
dr[LibraryMOD.GetFieldName(SecondNameArFN)]=SecondNameAr;
dr[LibraryMOD.GetFieldName(ThirdNameArFN)]=ThirdNameAr;
dr[LibraryMOD.GetFieldName(FamilyNameArFN)]=FamilyNameAr;
dr[LibraryMOD.GetFieldName(SurnameEnFN)]=SurnameEn;
dr[LibraryMOD.GetFieldName(SurnameArFN)]=SurnameAr;
dr[LibraryMOD.GetFieldName(EmpPictureFN)]=EmpPicture;
dr[LibraryMOD.GetFieldName(HomeCountryIDFN)]=HomeCountryID;
dr[LibraryMOD.GetFieldName(HomeCityIDFN)]=HomeCityID;
dr[LibraryMOD.GetFieldName(POBoxFN)]=POBox;
dr[LibraryMOD.GetFieldName(PhoneFN)]=Phone;
dr[LibraryMOD.GetFieldName(MobileFN)]=Mobile;
dr[LibraryMOD.GetFieldName(FaxFN)]=Fax;
dr[LibraryMOD.GetFieldName(EmailFN)]=Email;
dr[LibraryMOD.GetFieldName(InternalEmailFN)]=InternalEmail;
dr[LibraryMOD.GetFieldName(ZipCodeFN)]=ZipCode;
dr[LibraryMOD.GetFieldName(AddressFN)]=Address;
dr[LibraryMOD.GetFieldName(HomeCountryAddressFN)]=HomeCountryAddress;
dr[LibraryMOD.GetFieldName(IdentityCardFN)]=IdentityCard;
dr[LibraryMOD.GetFieldName(SexFN)]=Sex;
dr[LibraryMOD.GetFieldName(MaritalStausFN)]=MaritalStaus;
dr[LibraryMOD.GetFieldName(ReligionIDFN)]=ReligionID;
dr[LibraryMOD.GetFieldName(NationalityIDFN)]=NationalityID;
//dr[LibraryMOD.GetFieldName(BloodTypeFN)]=BloodType;
dr[LibraryMOD.GetFieldName(PassportNoFN)]=PassportNo;
dr[LibraryMOD.GetFieldName(IssuePlaceFN)]=IssuePlace;
dr[LibraryMOD.GetFieldName(PassportIssueDateFN)]=PassportIssueDate;
dr[LibraryMOD.GetFieldName(PassportExpireDateFN)]=PassportExpireDate;
dr[LibraryMOD.GetFieldName(BirthDateFN)]=BirthDate;
dr[LibraryMOD.GetFieldName(BirthCountryIDFN)]=BirthCountryID;
dr[LibraryMOD.GetFieldName(BirthCityIDFN)]=BirthCityID;
dr[LibraryMOD.GetFieldName(IsFullTimeFN)]=IsFullTime;
dr[LibraryMOD.GetFieldName(ContractTypeFN)]=ContractType;
dr[LibraryMOD.GetFieldName(ContractIssueDateFN)]=ContractIssueDate;
dr[LibraryMOD.GetFieldName(ContractExpireDateFN)]=ContractExpireDate;
dr[LibraryMOD.GetFieldName(HireDateFN)]=HireDate;
dr[LibraryMOD.GetFieldName(EndWorkDateFN)]=EndWorkDate;
dr[LibraryMOD.GetFieldName(EndReasonIDFN)]=EndReasonID;
dr[LibraryMOD.GetFieldName(IsSuspendedFN)]=IsSuspended;
dr[LibraryMOD.GetFieldName(SuspendedFromDateFN)]=SuspendedFromDate;
dr[LibraryMOD.GetFieldName(SuspendedToDateFN)]=SuspendedToDate;
dr[LibraryMOD.GetFieldName(SuspendedReasonIDFN)]=SuspendedReasonID;
dr[LibraryMOD.GetFieldName(EmployeeGroupFN)]=EmployeeGroup;
dr[LibraryMOD.GetFieldName(ManagerIDFN)]=ManagerID;
dr[LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
dr[LibraryMOD.GetFieldName(JobTitleIDFN)]=JobTitleID;
dr[LibraryMOD.GetFieldName(EmployeeGradeFN)]=EmployeeGrade;
dr[LibraryMOD.GetFieldName(GradeCircleNoFN)]=GradeCircleNo;
dr[LibraryMOD.GetFieldName(ShiftIDFN)]=ShiftID;
dr[LibraryMOD.GetFieldName(InsuranceCategoryIDFN)]=InsuranceCategoryID;
dr[LibraryMOD.GetFieldName(NotesFN)]=Notes;
dr[LibraryMOD.GetFieldName(IsActiveFN)]=IsActive;
dr[LibraryMOD.GetFieldName(TitleOfCourtesyFN)]=TitleOfCourtesy;
dsEmployee.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsEmployee.Tables[TableName].Select(LibraryMOD.GetFieldName(EmployeeIDFN)  + "=" + EmployeeID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
drAry[0][LibraryMOD.GetFieldName(EmpFileNoFN)]=EmpFileNo;
drAry[0][LibraryMOD.GetFieldName(EmpCardIDFN)]=EmpCardID;
drAry[0][LibraryMOD.GetFieldName(FirstNameEnFN)]=FirstNameEn;
drAry[0][LibraryMOD.GetFieldName(SecondNameEnFN)]=SecondNameEn;
drAry[0][LibraryMOD.GetFieldName(ThirdNameEnFN)]=ThirdNameEn;
drAry[0][LibraryMOD.GetFieldName(FamilyNameEnFN)]=FamilyNameEn;
drAry[0][LibraryMOD.GetFieldName(FirstNameArFN)]=FirstNameAr;
drAry[0][LibraryMOD.GetFieldName(SecondNameArFN)]=SecondNameAr;
drAry[0][LibraryMOD.GetFieldName(ThirdNameArFN)]=ThirdNameAr;
drAry[0][LibraryMOD.GetFieldName(FamilyNameArFN)]=FamilyNameAr;
drAry[0][LibraryMOD.GetFieldName(SurnameEnFN)]=SurnameEn;
drAry[0][LibraryMOD.GetFieldName(SurnameArFN)]=SurnameAr;
drAry[0][LibraryMOD.GetFieldName(EmpPictureFN)]=EmpPicture;
drAry[0][LibraryMOD.GetFieldName(HomeCountryIDFN)]=HomeCountryID;
drAry[0][LibraryMOD.GetFieldName(HomeCityIDFN)]=HomeCityID;
drAry[0][LibraryMOD.GetFieldName(POBoxFN)]=POBox;
drAry[0][LibraryMOD.GetFieldName(PhoneFN)]=Phone;
drAry[0][LibraryMOD.GetFieldName(MobileFN)]=Mobile;
drAry[0][LibraryMOD.GetFieldName(FaxFN)]=Fax;
drAry[0][LibraryMOD.GetFieldName(EmailFN)]=Email;
drAry[0][LibraryMOD.GetFieldName(InternalEmailFN)]=InternalEmail;
drAry[0][LibraryMOD.GetFieldName(ZipCodeFN)]=ZipCode;
drAry[0][LibraryMOD.GetFieldName(AddressFN)]=Address;
drAry[0][LibraryMOD.GetFieldName(HomeCountryAddressFN)]=HomeCountryAddress;
drAry[0][LibraryMOD.GetFieldName(IdentityCardFN)]=IdentityCard;
drAry[0][LibraryMOD.GetFieldName(SexFN)]=Sex;
drAry[0][LibraryMOD.GetFieldName(MaritalStausFN)]=MaritalStaus;
drAry[0][LibraryMOD.GetFieldName(ReligionIDFN)]=ReligionID;
drAry[0][LibraryMOD.GetFieldName(NationalityIDFN)]=NationalityID;
//drAry[0][LibraryMOD.GetFieldName(BloodTypeFN)]=BloodType;
drAry[0][LibraryMOD.GetFieldName(PassportNoFN)]=PassportNo;
drAry[0][LibraryMOD.GetFieldName(IssuePlaceFN)]=IssuePlace;
drAry[0][LibraryMOD.GetFieldName(PassportIssueDateFN)]=PassportIssueDate;
drAry[0][LibraryMOD.GetFieldName(PassportExpireDateFN)]=PassportExpireDate;
drAry[0][LibraryMOD.GetFieldName(BirthDateFN)]=BirthDate;
drAry[0][LibraryMOD.GetFieldName(BirthCountryIDFN)]=BirthCountryID;
drAry[0][LibraryMOD.GetFieldName(BirthCityIDFN)]=BirthCityID;
drAry[0][LibraryMOD.GetFieldName(IsFullTimeFN)]=IsFullTime;
drAry[0][LibraryMOD.GetFieldName(ContractTypeFN)]=ContractType;
drAry[0][LibraryMOD.GetFieldName(ContractIssueDateFN)]=ContractIssueDate;
drAry[0][LibraryMOD.GetFieldName(ContractExpireDateFN)]=ContractExpireDate;
drAry[0][LibraryMOD.GetFieldName(HireDateFN)]=HireDate;
drAry[0][LibraryMOD.GetFieldName(EndWorkDateFN)]=EndWorkDate;
drAry[0][LibraryMOD.GetFieldName(EndReasonIDFN)]=EndReasonID;
drAry[0][LibraryMOD.GetFieldName(IsSuspendedFN)]=IsSuspended;
drAry[0][LibraryMOD.GetFieldName(SuspendedFromDateFN)]=SuspendedFromDate;
drAry[0][LibraryMOD.GetFieldName(SuspendedToDateFN)]=SuspendedToDate;
drAry[0][LibraryMOD.GetFieldName(SuspendedReasonIDFN)]=SuspendedReasonID;
drAry[0][LibraryMOD.GetFieldName(EmployeeGroupFN)]=EmployeeGroup;
drAry[0][LibraryMOD.GetFieldName(ManagerIDFN)]=ManagerID;
drAry[0][LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
drAry[0][LibraryMOD.GetFieldName(JobTitleIDFN)]=JobTitleID;
drAry[0][LibraryMOD.GetFieldName(EmployeeGradeFN)]=EmployeeGrade;
drAry[0][LibraryMOD.GetFieldName(GradeCircleNoFN)]=GradeCircleNo;
drAry[0][LibraryMOD.GetFieldName(ShiftIDFN)]=ShiftID;
drAry[0][LibraryMOD.GetFieldName(InsuranceCategoryIDFN)]=InsuranceCategoryID;
drAry[0][LibraryMOD.GetFieldName(NotesFN)]=Notes;
drAry[0][LibraryMOD.GetFieldName(IsActiveFN)]=IsActive;
drAry[0][LibraryMOD.GetFieldName(TitleOfCourtesyFN)]=TitleOfCourtesy;
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
public int CommitEmployee()  
{
//CommitEmployee= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daEmployee.Update(dsEmployee, TableName);
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
FindInMultiPKey(EmployeeID);
if (( EmployeeDataRow != null)) 
{
EmployeeDataRow.Delete();
CommitEmployee();
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
if (EmployeeDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)]== System.DBNull.Value)
{
  EmployeeID=0;
}
else
{
  EmployeeID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EmpFileNoFN)]== System.DBNull.Value)
{
  EmpFileNo="";
}
else
{
  EmpFileNo = (string)EmployeeDataRow[LibraryMOD.GetFieldName(EmpFileNoFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EmpCardIDFN)]== System.DBNull.Value)
{
  EmpCardID="";
}
else
{
  EmpCardID = (string)EmployeeDataRow[LibraryMOD.GetFieldName(EmpCardIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(FirstNameEnFN)]== System.DBNull.Value)
{
  FirstNameEn="";
}
else
{
  FirstNameEn = (string)EmployeeDataRow[LibraryMOD.GetFieldName(FirstNameEnFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SecondNameEnFN)]== System.DBNull.Value)
{
  SecondNameEn="";
}
else
{
  SecondNameEn = (string)EmployeeDataRow[LibraryMOD.GetFieldName(SecondNameEnFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ThirdNameEnFN)]== System.DBNull.Value)
{
  ThirdNameEn="";
}
else
{
  ThirdNameEn = (string)EmployeeDataRow[LibraryMOD.GetFieldName(ThirdNameEnFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(FamilyNameEnFN)]== System.DBNull.Value)
{
  FamilyNameEn="";
}
else
{
  FamilyNameEn = (string)EmployeeDataRow[LibraryMOD.GetFieldName(FamilyNameEnFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(FirstNameArFN)]== System.DBNull.Value)
{
  FirstNameAr="";
}
else
{
  FirstNameAr = (string)EmployeeDataRow[LibraryMOD.GetFieldName(FirstNameArFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SecondNameArFN)]== System.DBNull.Value)
{
  SecondNameAr="";
}
else
{
  SecondNameAr = (string)EmployeeDataRow[LibraryMOD.GetFieldName(SecondNameArFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ThirdNameArFN)]== System.DBNull.Value)
{
  ThirdNameAr="";
}
else
{
  ThirdNameAr = (string)EmployeeDataRow[LibraryMOD.GetFieldName(ThirdNameArFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(FamilyNameArFN)]== System.DBNull.Value)
{
  FamilyNameAr="";
}
else
{
  FamilyNameAr = (string)EmployeeDataRow[LibraryMOD.GetFieldName(FamilyNameArFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SurnameEnFN)]== System.DBNull.Value)
{
  SurnameEn="";
}
else
{
  SurnameEn = (string)EmployeeDataRow[LibraryMOD.GetFieldName(SurnameEnFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SurnameArFN)]== System.DBNull.Value)
{
  SurnameAr="";
}
else
{
  SurnameAr = (string)EmployeeDataRow[LibraryMOD.GetFieldName(SurnameArFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EmpPictureFN)]== System.DBNull.Value)
{
  EmpPicture.ImageUrl ="";
}
else
{
 // EmpPicture = (Image )EmployeeDataRow[LibraryMOD.GetFieldName(EmpPictureFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(HomeCountryIDFN)]== System.DBNull.Value)
{
  HomeCountryID=0;
}
else
{
  HomeCountryID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(HomeCountryIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(HomeCityIDFN)]== System.DBNull.Value)
{
  HomeCityID=0;
}
else
{
  HomeCityID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(HomeCityIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(POBoxFN)]== System.DBNull.Value)
{
  POBox="";
}
else
{
  POBox = (string)EmployeeDataRow[LibraryMOD.GetFieldName(POBoxFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(PhoneFN)]== System.DBNull.Value)
{
  Phone="";
}
else
{
  Phone = (string)EmployeeDataRow[LibraryMOD.GetFieldName(PhoneFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(MobileFN)]== System.DBNull.Value)
{
  Mobile="";
}
else
{
  Mobile = (string)EmployeeDataRow[LibraryMOD.GetFieldName(MobileFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(FaxFN)]== System.DBNull.Value)
{
  Fax="";
}
else
{
  Fax = (string)EmployeeDataRow[LibraryMOD.GetFieldName(FaxFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EmailFN)]== System.DBNull.Value)
{
  Email="";
}
else
{
  Email = (string)EmployeeDataRow[LibraryMOD.GetFieldName(EmailFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(InternalEmailFN)]== System.DBNull.Value)
{
  InternalEmail="";
}
else
{
  InternalEmail = (string)EmployeeDataRow[LibraryMOD.GetFieldName(InternalEmailFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ZipCodeFN)]== System.DBNull.Value)
{
  ZipCode="";
}
else
{
  ZipCode = (string)EmployeeDataRow[LibraryMOD.GetFieldName(ZipCodeFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(AddressFN)]== System.DBNull.Value)
{
  Address="";
}
else
{
  Address = (string)EmployeeDataRow[LibraryMOD.GetFieldName(AddressFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(HomeCountryAddressFN)]== System.DBNull.Value)
{
  HomeCountryAddress="";
}
else
{
  HomeCountryAddress = (string)EmployeeDataRow[LibraryMOD.GetFieldName(HomeCountryAddressFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(IdentityCardFN)]== System.DBNull.Value)
{
  IdentityCard="";
}
else
{
  IdentityCard = (string)EmployeeDataRow[LibraryMOD.GetFieldName(IdentityCardFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SexFN)]== System.DBNull.Value)
{
  Sex=0;
}
else
{
  Sex = (int)EmployeeDataRow[LibraryMOD.GetFieldName(SexFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(MaritalStausFN)]== System.DBNull.Value)
{
  MaritalStaus=0;
}
else
{
  MaritalStaus = (int)EmployeeDataRow[LibraryMOD.GetFieldName(MaritalStausFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ReligionIDFN)]== System.DBNull.Value)
{
  ReligionID=0;
}
else
{
  ReligionID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(ReligionIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(NationalityIDFN)]== System.DBNull.Value)
{
  NationalityID=0;
}
else
{
  NationalityID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(NationalityIDFN)];
}
//if (EmployeeDataRow[LibraryMOD.GetFieldName(BloodTypeFN)]== System.DBNull.Value)
//{
//  BloodType="";
//}
//else
//{
//  BloodType = (string)EmployeeDataRow[LibraryMOD.GetFieldName(BloodTypeFN)];
//}
if (EmployeeDataRow[LibraryMOD.GetFieldName(PassportNoFN)]== System.DBNull.Value)
{
  PassportNo="";
}
else
{
  PassportNo = (string)EmployeeDataRow[LibraryMOD.GetFieldName(PassportNoFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(IssuePlaceFN)]== System.DBNull.Value)
{
  IssuePlace="";
}
else
{
  IssuePlace = (string)EmployeeDataRow[LibraryMOD.GetFieldName(IssuePlaceFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(PassportIssueDateFN)]== System.DBNull.Value)
{
  PassportIssueDate=0;
}
else
{
  PassportIssueDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(PassportIssueDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(PassportExpireDateFN)]== System.DBNull.Value)
{
  PassportExpireDate=0;
}
else
{
  PassportExpireDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(PassportExpireDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(BirthDateFN)]== System.DBNull.Value)
{
  BirthDate=0;
}
else
{
  BirthDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(BirthDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(BirthCountryIDFN)]== System.DBNull.Value)
{
  BirthCountryID=0;
}
else
{
  BirthCountryID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(BirthCountryIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(BirthCityIDFN)]== System.DBNull.Value)
{
  BirthCityID=0;
}
else
{
  BirthCityID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(BirthCityIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(IsFullTimeFN)]== System.DBNull.Value)
{
  IsFullTime=0;
}
else
{
  IsFullTime = (int)EmployeeDataRow[LibraryMOD.GetFieldName(IsFullTimeFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ContractTypeFN)]== System.DBNull.Value)
{
  ContractType=0;
}
else
{
  ContractType = (int)EmployeeDataRow[LibraryMOD.GetFieldName(ContractTypeFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ContractIssueDateFN)]== System.DBNull.Value)
{
  ContractIssueDate=0;
}
else
{
  ContractIssueDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(ContractIssueDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ContractExpireDateFN)]== System.DBNull.Value)
{
  ContractExpireDate=0;
}
else
{
  ContractExpireDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(ContractExpireDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(HireDateFN)]== System.DBNull.Value)
{
  HireDate=0;
}
else
{
  HireDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(HireDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EndWorkDateFN)]== System.DBNull.Value)
{
  EndWorkDate=0;
}
else
{
  EndWorkDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(EndWorkDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EndReasonIDFN)]== System.DBNull.Value)
{
  EndReasonID=0;
}
else
{
  EndReasonID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(EndReasonIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(IsSuspendedFN)]== System.DBNull.Value)
{
  IsSuspended=0;
}
else
{
  IsSuspended = (int)EmployeeDataRow[LibraryMOD.GetFieldName(IsSuspendedFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SuspendedFromDateFN)]== System.DBNull.Value)
{
  SuspendedFromDate=0;
}
else
{
  SuspendedFromDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(SuspendedFromDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SuspendedToDateFN)]== System.DBNull.Value)
{
  SuspendedToDate=0;
}
else
{
  SuspendedToDate = (int)EmployeeDataRow[LibraryMOD.GetFieldName(SuspendedToDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(SuspendedReasonIDFN)]== System.DBNull.Value)
{
  SuspendedReasonID=0;
}
else
{
  SuspendedReasonID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(SuspendedReasonIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EmployeeGroupFN)]== System.DBNull.Value)
{
  EmployeeGroup=0;
}
else
{
  EmployeeGroup = (int)EmployeeDataRow[LibraryMOD.GetFieldName(EmployeeGroupFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ManagerIDFN)]== System.DBNull.Value)
{
  ManagerID=0;
}
else
{
  ManagerID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(ManagerIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)]== System.DBNull.Value)
{
  DepartmentID=0;
}
else
{
  DepartmentID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(JobTitleIDFN)]== System.DBNull.Value)
{
  JobTitleID=0;
}
else
{
  JobTitleID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(JobTitleIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(EmployeeGradeFN)]== System.DBNull.Value)
{
  EmployeeGrade=0;
}
else
{
  EmployeeGrade = (int)EmployeeDataRow[LibraryMOD.GetFieldName(EmployeeGradeFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(GradeCircleNoFN)]== System.DBNull.Value)
{
  GradeCircleNo=0;
}
else
{
  GradeCircleNo = (int)EmployeeDataRow[LibraryMOD.GetFieldName(GradeCircleNoFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(ShiftIDFN)]== System.DBNull.Value)
{
  ShiftID=0;
}
else
{
  ShiftID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(ShiftIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(InsuranceCategoryIDFN)]== System.DBNull.Value)
{
  InsuranceCategoryID=0;
}
else
{
  InsuranceCategoryID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(InsuranceCategoryIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(NotesFN)]== System.DBNull.Value)
{
  Notes="";
}
else
{
  Notes = (string)EmployeeDataRow[LibraryMOD.GetFieldName(NotesFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(IsActiveFN)]== System.DBNull.Value)
{
  IsActive=0;
}
else
{
  IsActive = (int)EmployeeDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)EmployeeDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)EmployeeDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)EmployeeDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)EmployeeDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)EmployeeDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
}
if (EmployeeDataRow[LibraryMOD.GetFieldName(TitleOfCourtesyFN)]== System.DBNull.Value)
{
  TitleOfCourtesy="";
}
else
{
  TitleOfCourtesy = (string)EmployeeDataRow[LibraryMOD.GetFieldName(TitleOfCourtesyFN)];
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
public int FindInMultiPKey(int PKEmployeeID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKEmployeeID;
EmployeeDataRow = dsEmployee.Tables[TableName].Rows.Find(findTheseVals);
if  ((EmployeeDataRow !=null)) 
{
lngCurRow = dsEmployee.Tables[TableName].Rows.IndexOf(EmployeeDataRow);
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
  lngCurRow = dsEmployee.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsEmployee.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsEmployee.Tables[TableName].Rows.Count > 0) 
{
  EmployeeDataRow = dsEmployee.Tables[TableName].Rows[lngCurRow];
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
daEmployee.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployee.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daEmployee.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployee.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
