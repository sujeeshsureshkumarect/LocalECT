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
public class SemesterTargetHistory
{
    //Creation Date: 10/03/2016 1:42:28 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_iOrder;
    private string m_sMajor;
    private int m_AcademicYear;
    private int m_Semester;
    private int m_Target_NewStudentsM;
    private int m_Target_NewStudentsF;
    private int m_Target_ExtendedRegFromExpectedToGraduateM;
    private int m_Target_ExtendedRegFromGraduatedStudentsM;
    private int m_Target_OldStudentsM;
    private int m_Target_PostponedDiscontinuedStudentsM;
    private int m_NewRegisteredM;
    private int m_OldRegisteredM;
    private int m_Extended_ESL_M;
    private int m_ReadmittedM_Reg;
    private int m_ExtendedRegFromExpectedToGraduateM;
    private int m_ExtendedRegFromGraduatedStudentsM;
    private int m_AllStudentsRegisteredM;
    private int m_ExpectedtoExtendFromDiplomaM;
    private int m_NewUnRegisteredM;
    private int m_OldUnRegisteredM;
    private int m_ExtendedUnRegisteredM;
    private int m_AllStudentsUnRegisteredM;
    private int m_PostponedUnregisteredM;
    private int m_DiscontinuedUnRegisteredM;
    private int m_Target_ExtendedRegFromExpectedToGraduateF;
    private int m_Target_ExtendedRegFromGraduatedStudentsF;
    private int m_Target_OldStudentsF;
    private int m_Target_PostponedDiscontinuedStudentsF;
    private int m_NewRegisteredF;
    private int m_ExtendedRegFromExpectedToGraduateF;
    private int m_ExtendedRegFromGraduatedStudentsF;
    private int m_AllStudentsRegisteredF;
    private int m_ExpectedtoExtendFromDiplomaF;
    private int m_NewUnRegisteredF;
    private int m_OldUnRegisteredF;
    private int m_OldRegisteredF;
    private int m_Extended_ESL_F;
    private int m_ReadmittedF_Reg;
    private int m_ExtendedUnRegisteredF;
    private int m_AllStudentsUnRegisteredF;
    private int m_PostponedUnregisteredF;
    private int m_DiscontinuedUnRegisteredF;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int iOrder
    {
        get { return m_iOrder; }
        set { m_iOrder = value; }
    }
    public string sMajor
    {
        get { return m_sMajor; }
        set { m_sMajor = value; }
    }
    public int AcademicYear
    {
        get { return m_AcademicYear; }
        set { m_AcademicYear = value; }
    }
    public int Semester
    {
        get { return m_Semester; }
        set { m_Semester = value; }
    }
    public int Target_NewStudentsM
    {
        get { return m_Target_NewStudentsM; }
        set { m_Target_NewStudentsM = value; }
    }
    public int Target_NewStudentsF
    {
        get { return m_Target_NewStudentsF; }
        set { m_Target_NewStudentsF = value; }
    }
    public int Target_ExtendedRegFromExpectedToGraduateM
    {
        get { return m_Target_ExtendedRegFromExpectedToGraduateM; }
        set { m_Target_ExtendedRegFromExpectedToGraduateM = value; }
    }
    public int Target_ExtendedRegFromGraduatedStudentsM
    {
        get { return m_Target_ExtendedRegFromGraduatedStudentsM; }
        set { m_Target_ExtendedRegFromGraduatedStudentsM = value; }
    }
    public int Target_OldStudentsM
    {
        get { return m_Target_OldStudentsM; }
        set { m_Target_OldStudentsM = value; }
    }
    public int Target_PostponedDiscontinuedStudentsM
    {
        get { return m_Target_PostponedDiscontinuedStudentsM; }
        set { m_Target_PostponedDiscontinuedStudentsM = value; }
    }
    public int NewRegisteredM
    {
        get { return m_NewRegisteredM; }
        set { m_NewRegisteredM = value; }
    }
    public int OldRegisteredM
    {
        get { return m_OldRegisteredM; }
        set { m_OldRegisteredM = value; }
    }
    public int Extended_ESL_M
    {
        get { return m_Extended_ESL_M; }
        set { m_Extended_ESL_M = value; }
    }
    public int ReadmittedM_Reg
    {
        get { return m_ReadmittedM_Reg; }
        set { m_ReadmittedM_Reg = value; }
    }
     
    public int ExtendedRegFromExpectedToGraduateM
    {
        get { return m_ExtendedRegFromExpectedToGraduateM; }
        set { m_ExtendedRegFromExpectedToGraduateM = value; }
    }
    public int ExtendedRegFromGraduatedStudentsM
    {
        get { return m_ExtendedRegFromGraduatedStudentsM; }
        set { m_ExtendedRegFromGraduatedStudentsM = value; }
    }
    public int AllStudentsRegisteredM
    {
        get { return m_AllStudentsRegisteredM; }
        set { m_AllStudentsRegisteredM = value; }
    }
    public int ExpectedtoExtendFromDiplomaM
    {
        get { return m_ExpectedtoExtendFromDiplomaM; }
        set { m_ExpectedtoExtendFromDiplomaM = value; }
    }
    public int NewUnRegisteredM
    {
        get { return m_NewUnRegisteredM; }
        set { m_NewUnRegisteredM = value; }
    }
    public int OldUnRegisteredM
    {
        get { return m_OldUnRegisteredM; }
        set { m_OldUnRegisteredM = value; }
    }
    public int ExtendedUnRegisteredM
    {
        get { return m_ExtendedUnRegisteredM; }
        set { m_ExtendedUnRegisteredM = value; }
    }
    public int AllStudentsUnRegisteredM
    {
        get { return m_AllStudentsUnRegisteredM; }
        set { m_AllStudentsUnRegisteredM = value; }
    }
    public int PostponedUnregisteredM
    {
        get { return m_PostponedUnregisteredM; }
        set { m_PostponedUnregisteredM = value; }
    }
    public int DiscontinuedUnRegisteredM
    {
        get { return m_DiscontinuedUnRegisteredM; }
        set { m_DiscontinuedUnRegisteredM = value; }
    }
    public int Target_ExtendedRegFromExpectedToGraduateF
    {
        get { return m_Target_ExtendedRegFromExpectedToGraduateF; }
        set { m_Target_ExtendedRegFromExpectedToGraduateF = value; }
    }
    public int Target_ExtendedRegFromGraduatedStudentsF
    {
        get { return m_Target_ExtendedRegFromGraduatedStudentsF; }
        set { m_Target_ExtendedRegFromGraduatedStudentsF = value; }
    }
    public int Target_OldStudentsF
    {
        get { return m_Target_OldStudentsF; }
        set { m_Target_OldStudentsF = value; }
    }
    public int Target_PostponedDiscontinuedStudentsF
    {
        get { return m_Target_PostponedDiscontinuedStudentsF; }
        set { m_Target_PostponedDiscontinuedStudentsF = value; }
    }
    public int NewRegisteredF
    {
        get { return m_NewRegisteredF; }
        set { m_NewRegisteredF = value; }
    }
    public int ExtendedRegFromExpectedToGraduateF
    {
        get { return m_ExtendedRegFromExpectedToGraduateF; }
        set { m_ExtendedRegFromExpectedToGraduateF = value; }
    }
    public int ExtendedRegFromGraduatedStudentsF
    {
        get { return m_ExtendedRegFromGraduatedStudentsF; }
        set { m_ExtendedRegFromGraduatedStudentsF = value; }
    }
    public int AllStudentsRegisteredF
    {
        get { return m_AllStudentsRegisteredF; }
        set { m_AllStudentsRegisteredF = value; }
    }
    public int ExpectedtoExtendFromDiplomaF
    {
        get { return m_ExpectedtoExtendFromDiplomaF; }
        set { m_ExpectedtoExtendFromDiplomaF = value; }
    }
    public int NewUnRegisteredF
    {
        get { return m_NewUnRegisteredF; }
        set { m_NewUnRegisteredF = value; }
    }
    public int OldUnRegisteredF
    {
        get { return m_OldUnRegisteredF; }
        set { m_OldUnRegisteredF = value; }
    }
    public int OldRegisteredF
    {
        get { return m_OldRegisteredF; }
        set { m_OldRegisteredF = value; }
    }
    public int Extended_ESL_F
    {
        get { return m_Extended_ESL_F; }
        set { m_Extended_ESL_F = value; }
    }
    public int ReadmittedF_Reg
    {
        get { return m_ReadmittedF_Reg; }
        set { m_ReadmittedF_Reg = value; }
    }
    public int ExtendedUnRegisteredF
    {
        get { return m_ExtendedUnRegisteredF; }
        set { m_ExtendedUnRegisteredF = value; }
    }
    public int AllStudentsUnRegisteredF
    {
        get { return m_AllStudentsUnRegisteredF; }
        set { m_AllStudentsUnRegisteredF = value; }
    }
    public int PostponedUnregisteredF
    {
        get { return m_PostponedUnregisteredF; }
        set { m_PostponedUnregisteredF = value; }
    }
    public int DiscontinuedUnRegisteredF
    {
        get { return m_DiscontinuedUnRegisteredF; }
        set { m_DiscontinuedUnRegisteredF = value; }
    }
    public int CreationUserID
    {
        get { return m_CreationUserID; }
        set { m_CreationUserID = value; }
    }
    public DateTime CreationDate
    {
        get { return m_CreationDate; }
        set { m_CreationDate = value; }
    }
    public int LastUpdateUserID
    {
        get { return m_LastUpdateUserID; }
        set { m_LastUpdateUserID = value; }
    }
    public DateTime LastUpdateDate
    {
        get { return m_LastUpdateDate; }
        set { m_LastUpdateDate = value; }
    }
    public string PCName
    {
        get { return m_PCName; }
        set { m_PCName = value; }
    }
    public string NetUserName
    {
        get { return m_NetUserName; }
        set { m_NetUserName = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public SemesterTargetHistory()
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
public class SemesterTargetHistoryDAL : SemesterTargetHistory
{
    #region "Decleration"
    private string m_TableName;
    private string m_iOrderFN;
    private string m_sMajorFN;
    private string m_AcademicYearFN;
    private string m_SemesterFN;
    private string m_Target_NewStudentsMFN;
    private string m_Target_NewStudentsFFN;
    private string m_Target_ExtendedRegFromExpectedToGraduateMFN;
    private string m_Target_ExtendedRegFromGraduatedStudentsMFN;
    private string m_Target_OldStudentsMFN;
    private string m_Target_PostponedDiscontinuedStudentsMFN;
    private string m_NewRegisteredMFN;
    private string m_OldRegisteredMFN;
    private string m_Extended_ESL_MFN;
    private string m_ReadmittedM_RegFN;
    private string m_ExtendedRegFromExpectedToGraduateMFN;
    private string m_ExtendedRegFromGraduatedStudentsMFN;
    private string m_AllStudentsRegisteredMFN;
    private string m_ExpectedtoExtendFromDiplomaMFN;
    private string m_NewUnRegisteredMFN;
    private string m_OldUnRegisteredMFN;
    private string m_ExtendedUnRegisteredMFN;
    private string m_AllStudentsUnRegisteredMFN;
    private string m_PostponedUnregisteredMFN;
    private string m_DiscontinuedUnRegisteredMFN;
    private string m_Target_ExtendedRegFromExpectedToGraduateFFN;
    private string m_Target_ExtendedRegFromGraduatedStudentsFFN;
    private string m_Target_OldStudentsFFN;
    private string m_Target_PostponedDiscontinuedStudentsFFN;
    private string m_NewRegisteredFFN;
    private string m_ExtendedRegFromExpectedToGraduateFFN;
    private string m_ExtendedRegFromGraduatedStudentsFFN;
    private string m_AllStudentsRegisteredFFN;
    private string m_ExpectedtoExtendFromDiplomaFFN;
    private string m_NewUnRegisteredFFN;
    private string m_OldUnRegisteredFFN;
    private string m_OldRegisteredFFN;
    private string m_Extended_ESL_FFN;
    private string m_ReadmittedF_RegFN;
    private string m_ExtendedUnRegisteredFFN;
    private string m_AllStudentsUnRegisteredFFN;
    private string m_PostponedUnregisteredFFN;
    private string m_DiscontinuedUnRegisteredFFN;
    
    private string m_AM_Discontinued_Postponed_Withdrawn_RegFN;
    private string m_AF_Discontinued_Postponed_Withdrawn_RegFN;
    private string m_NewESL_M_VS_WantedMajorFN;
    private string m_NewESL_F_VS_WantedMajorFN;
    private string m_CreationUserIDFN;
    private string m_CreationDateFN;
    private string m_LastUpdateUserIDFN;
    private string m_LastUpdateDateFN;
    private string m_PCNameFN;
    private string m_NetUserNameFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string iOrderFN
    {
        get { return m_iOrderFN; }
        set { m_iOrderFN = value; }
    }
    public string sMajorFN
    {
        get { return m_sMajorFN; }
        set { m_sMajorFN = value; }
    }
    public string AcademicYearFN
    {
        get { return m_AcademicYearFN; }
        set { m_AcademicYearFN = value; }
    }
    public string SemesterFN
    {
        get { return m_SemesterFN; }
        set { m_SemesterFN = value; }
    }
    public string Target_NewStudentsMFN
    {
        get { return m_Target_NewStudentsMFN; }
        set { m_Target_NewStudentsMFN = value; }
    }
    public string Target_NewStudentsFFN
    {
        get { return m_Target_NewStudentsFFN; }
        set { m_Target_NewStudentsFFN = value; }
    }
    public string Target_ExtendedRegFromExpectedToGraduateMFN
    {
        get { return m_Target_ExtendedRegFromExpectedToGraduateMFN; }
        set { m_Target_ExtendedRegFromExpectedToGraduateMFN = value; }
    }
    public string Target_ExtendedRegFromGraduatedStudentsMFN
    {
        get { return m_Target_ExtendedRegFromGraduatedStudentsMFN; }
        set { m_Target_ExtendedRegFromGraduatedStudentsMFN = value; }
    }
    public string Target_OldStudentsMFN
    {
        get { return m_Target_OldStudentsMFN; }
        set { m_Target_OldStudentsMFN = value; }
    }
    public string Target_PostponedDiscontinuedStudentsMFN
    {
        get { return m_Target_PostponedDiscontinuedStudentsMFN; }
        set { m_Target_PostponedDiscontinuedStudentsMFN = value; }
    }
    public string NewRegisteredMFN
    {
        get { return m_NewRegisteredMFN; }
        set { m_NewRegisteredMFN = value; }
    }
    public string OldRegisteredMFN
    {
        get { return m_OldRegisteredMFN; }
        set { m_OldRegisteredMFN = value; }
    }
    public string Extended_ESL_MFN
    {
        get { return m_Extended_ESL_MFN; }
        set { m_Extended_ESL_MFN = value; }
    }
    public string ReadmittedM_RegFN
    {
        get { return m_ReadmittedM_RegFN; }
        set { m_ReadmittedM_RegFN = value; }
    }
    public string ExtendedRegFromExpectedToGraduateMFN
    {
        get { return m_ExtendedRegFromExpectedToGraduateMFN; }
        set { m_ExtendedRegFromExpectedToGraduateMFN = value; }
    }
    public string ExtendedRegFromGraduatedStudentsMFN
    {
        get { return m_ExtendedRegFromGraduatedStudentsMFN; }
        set { m_ExtendedRegFromGraduatedStudentsMFN = value; }
    }
    public string AllStudentsRegisteredMFN
    {
        get { return m_AllStudentsRegisteredMFN; }
        set { m_AllStudentsRegisteredMFN = value; }
    }
    public string ExpectedtoExtendFromDiplomaMFN
    {
        get { return m_ExpectedtoExtendFromDiplomaMFN; }
        set { m_ExpectedtoExtendFromDiplomaMFN = value; }
    }
    public string NewUnRegisteredMFN
    {
        get { return m_NewUnRegisteredMFN; }
        set { m_NewUnRegisteredMFN = value; }
    }
    public string OldUnRegisteredMFN
    {
        get { return m_OldUnRegisteredMFN; }
        set { m_OldUnRegisteredMFN = value; }
    }
    public string ExtendedUnRegisteredMFN
    {
        get { return m_ExtendedUnRegisteredMFN; }
        set { m_ExtendedUnRegisteredMFN = value; }
    }
    public string AllStudentsUnRegisteredMFN
    {
        get { return m_AllStudentsUnRegisteredMFN; }
        set { m_AllStudentsUnRegisteredMFN = value; }
    }
    public string PostponedUnregisteredMFN
    {
        get { return m_PostponedUnregisteredMFN; }
        set { m_PostponedUnregisteredMFN = value; }
    }
    public string DiscontinuedUnRegisteredMFN
    {
        get { return m_DiscontinuedUnRegisteredMFN; }
        set { m_DiscontinuedUnRegisteredMFN = value; }
    }
    public string Target_ExtendedRegFromExpectedToGraduateFFN
    {
        get { return m_Target_ExtendedRegFromExpectedToGraduateFFN; }
        set { m_Target_ExtendedRegFromExpectedToGraduateFFN = value; }
    }
    public string Target_ExtendedRegFromGraduatedStudentsFFN
    {
        get { return m_Target_ExtendedRegFromGraduatedStudentsFFN; }
        set { m_Target_ExtendedRegFromGraduatedStudentsFFN = value; }
    }
    public string Target_OldStudentsFFN
    {
        get { return m_Target_OldStudentsFFN; }
        set { m_Target_OldStudentsFFN = value; }
    }
    public string Target_PostponedDiscontinuedStudentsFFN
    {
        get { return m_Target_PostponedDiscontinuedStudentsFFN; }
        set { m_Target_PostponedDiscontinuedStudentsFFN = value; }
    }
    public string NewRegisteredFFN
    {
        get { return m_NewRegisteredFFN; }
        set { m_NewRegisteredFFN = value; }
    }
    public string ExtendedRegFromExpectedToGraduateFFN
    {
        get { return m_ExtendedRegFromExpectedToGraduateFFN; }
        set { m_ExtendedRegFromExpectedToGraduateFFN = value; }
    }
    public string ExtendedRegFromGraduatedStudentsFFN
    {
        get { return m_ExtendedRegFromGraduatedStudentsFFN; }
        set { m_ExtendedRegFromGraduatedStudentsFFN = value; }
    }
    public string AllStudentsRegisteredFFN
    {
        get { return m_AllStudentsRegisteredFFN; }
        set { m_AllStudentsRegisteredFFN = value; }
    }
    public string ExpectedtoExtendFromDiplomaFFN
    {
        get { return m_ExpectedtoExtendFromDiplomaFFN; }
        set { m_ExpectedtoExtendFromDiplomaFFN = value; }
    }
    public string NewUnRegisteredFFN
    {
        get { return m_NewUnRegisteredFFN; }
        set { m_NewUnRegisteredFFN = value; }
    }
    public string OldUnRegisteredFFN
    {
        get { return m_OldUnRegisteredFFN; }
        set { m_OldUnRegisteredFFN = value; }
    }
    public string OldRegisteredFFN
    {
        get { return m_OldRegisteredFFN; }
        set { m_OldRegisteredFFN = value; }
    }
    public string Extended_ESL_FFN
    {
        get { return m_Extended_ESL_FFN; }
        set { m_Extended_ESL_FFN = value; }
    }
    public string ReadmittedF_RegFN
    {
        get { return m_ReadmittedF_RegFN; }
        set { m_ReadmittedF_RegFN = value; }
    }
    
    public string ExtendedUnRegisteredFFN
    {
        get { return m_ExtendedUnRegisteredFFN; }
        set { m_ExtendedUnRegisteredFFN = value; }
    }
    public string AllStudentsUnRegisteredFFN
    {
        get { return m_AllStudentsUnRegisteredFFN; }
        set { m_AllStudentsUnRegisteredFFN = value; }
    }
    public string PostponedUnregisteredFFN
    {
        get { return m_PostponedUnregisteredFFN; }
        set { m_PostponedUnregisteredFFN = value; }
    }
    public string DiscontinuedUnRegisteredFFN
    {
        get { return m_DiscontinuedUnRegisteredFFN; }
        set { m_DiscontinuedUnRegisteredFFN = value; }
    }
    
    public string AM_Discontinued_Postponed_Withdrawn_RegFN
    {
        get { return m_AM_Discontinued_Postponed_Withdrawn_RegFN; }
        set { m_AM_Discontinued_Postponed_Withdrawn_RegFN = value; }
    }
    public string AF_Discontinued_Postponed_Withdrawn_RegFN
    {
        get { return m_AF_Discontinued_Postponed_Withdrawn_RegFN; }
        set { m_AF_Discontinued_Postponed_Withdrawn_RegFN = value; }
    }
    public string NewESL_M_VS_WantedMajorFN
    {
        get { return m_NewESL_M_VS_WantedMajorFN; }
        set { m_NewESL_M_VS_WantedMajorFN = value; }
    }
    public string NewESL_F_VS_WantedMajorFN
    {
        get { return m_NewESL_F_VS_WantedMajorFN; }
        set { m_NewESL_F_VS_WantedMajorFN = value; }
    }
    public string CreationUserIDFN
    {
        get { return m_CreationUserIDFN; }
        set { m_CreationUserIDFN = value; }
    }
    public string CreationDateFN
    {
        get { return m_CreationDateFN; }
        set { m_CreationDateFN = value; }
    }
    public string LastUpdateUserIDFN
    {
        get { return m_LastUpdateUserIDFN; }
        set { m_LastUpdateUserIDFN = value; }
    }
    public string LastUpdateDateFN
    {
        get { return m_LastUpdateDateFN; }
        set { m_LastUpdateDateFN = value; }
    }
    public string PCNameFN
    {
        get { return m_PCNameFN; }
        set { m_PCNameFN = value; }
    }
    public string NetUserNameFN
    {
        get { return m_NetUserNameFN; }
        set { m_NetUserNameFN = value; }
    }
    #endregion
    //================End Properties ===================
    public SemesterTargetHistoryDAL()
    {
        try
        {
            this.TableName = "ECT_SemesterTargetHistory";
            this.iOrderFN = m_TableName + ".iOrder";
            this.sMajorFN = m_TableName + ".sMajor";
            this.AcademicYearFN = m_TableName + ".AcademicYear";
            this.SemesterFN = m_TableName + ".Semester";
            this.Target_NewStudentsMFN = m_TableName + ".Target_NewStudentsM";
            this.Target_NewStudentsFFN = m_TableName + ".Target_NewStudentsF";
            this.Target_ExtendedRegFromExpectedToGraduateMFN = m_TableName + ".Target_ExtendedRegFromExpectedToGraduateM";
            this.Target_ExtendedRegFromGraduatedStudentsMFN = m_TableName + ".Target_ExtendedRegFromGraduatedStudentsM";
            this.Target_OldStudentsMFN = m_TableName + ".Target_OldStudentsM";
            this.Target_PostponedDiscontinuedStudentsMFN = m_TableName + ".Target_PostponedDiscontinuedStudentsM";
            this.NewRegisteredMFN = m_TableName + ".NewRegisteredM";
            this.OldRegisteredMFN = m_TableName + ".OldRegisteredM";
            this.Extended_ESL_MFN = m_TableName + ".Extended_ESL_M";
            this.ReadmittedM_RegFN = m_TableName + ".ReadmittedM_Reg";
            this.ExtendedRegFromExpectedToGraduateMFN = m_TableName + ".ExtendedRegFromExpectedToGraduateM";
            this.ExtendedRegFromGraduatedStudentsMFN = m_TableName + ".ExtendedRegFromGraduatedStudentsM";
            this.AllStudentsRegisteredMFN = m_TableName + ".AllStudentsRegisteredM";
            this.ExpectedtoExtendFromDiplomaMFN = m_TableName + ".ExpectedtoExtendFromDiplomaM";
            this.NewUnRegisteredMFN = m_TableName + ".NewUnRegisteredM";
            this.OldUnRegisteredMFN = m_TableName + ".OldUnRegisteredM";
            this.ExtendedUnRegisteredMFN = m_TableName + ".ExtendedUnRegisteredM";
            this.AllStudentsUnRegisteredMFN = m_TableName + ".AllStudentsUnRegisteredM";
            this.PostponedUnregisteredMFN = m_TableName + ".PostponedUnregisteredM";
            this.DiscontinuedUnRegisteredMFN = m_TableName + ".DiscontinuedUnRegisteredM";
            this.Target_ExtendedRegFromExpectedToGraduateFFN = m_TableName + ".Target_ExtendedRegFromExpectedToGraduateF";
            this.Target_ExtendedRegFromGraduatedStudentsFFN = m_TableName + ".Target_ExtendedRegFromGraduatedStudentsF";
            this.Target_OldStudentsFFN = m_TableName + ".Target_OldStudentsF";
            this.Target_PostponedDiscontinuedStudentsFFN = m_TableName + ".Target_PostponedDiscontinuedStudentsF";
            this.NewRegisteredFFN = m_TableName + ".NewRegisteredF";
            this.ExtendedRegFromExpectedToGraduateFFN = m_TableName + ".ExtendedRegFromExpectedToGraduateF";
            this.ExtendedRegFromGraduatedStudentsFFN = m_TableName + ".ExtendedRegFromGraduatedStudentsF";
            this.AllStudentsRegisteredFFN = m_TableName + ".AllStudentsRegisteredF";
            this.ExpectedtoExtendFromDiplomaFFN = m_TableName + ".ExpectedtoExtendFromDiplomaF";
            this.NewUnRegisteredFFN = m_TableName + ".NewUnRegisteredF";
            this.OldUnRegisteredFFN = m_TableName + ".OldUnRegisteredF";
            this.OldRegisteredFFN = m_TableName + ".OldRegisteredF";
            this.Extended_ESL_FFN = m_TableName + ".Extended_ESL_F";
            this.ReadmittedF_RegFN = m_TableName + ".ReadmittedF_Reg";
            this.ExtendedUnRegisteredFFN = m_TableName + ".ExtendedUnRegisteredF";
            this.AllStudentsUnRegisteredFFN = m_TableName + ".AllStudentsUnRegisteredF";
            this.PostponedUnregisteredFFN = m_TableName + ".PostponedUnregisteredF";
            this.DiscontinuedUnRegisteredFFN = m_TableName + ".DiscontinuedUnRegisteredF";
            this.m_AM_Discontinued_Postponed_Withdrawn_RegFN = m_TableName + ".AM_Discontinued_Postponed_Withdrawn_Reg";
            this.m_AF_Discontinued_Postponed_Withdrawn_RegFN = m_TableName + ".AF_Discontinued_Postponed_Withdrawn_Reg";
            this.m_NewESL_M_VS_WantedMajorFN = m_TableName + ".NewESL_M_VS_WantedMajor";
            this.m_NewESL_F_VS_WantedMajorFN = m_TableName + ".NewESL_F_VS_WantedMajor";
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
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += iOrderFN;
            sSQL += " , " + sMajorFN;
            sSQL += " , " + AcademicYearFN;
            sSQL += " , " + SemesterFN;
            sSQL += " , " + Target_NewStudentsMFN;
            sSQL += " , " + Target_NewStudentsFFN;
            sSQL += " , " + Target_ExtendedRegFromExpectedToGraduateMFN;
            sSQL += " , " + Target_ExtendedRegFromGraduatedStudentsMFN;
            sSQL += " , " + Target_OldStudentsMFN;
            sSQL += " , " + Target_PostponedDiscontinuedStudentsMFN;
            sSQL += " , " + NewRegisteredMFN;
            sSQL += " , " + OldRegisteredMFN;
            sSQL += " , " + Extended_ESL_MFN;
            sSQL += " , " + ReadmittedM_RegFN;
            sSQL += " , " + ExtendedRegFromExpectedToGraduateMFN;
            sSQL += " , " + ExtendedRegFromGraduatedStudentsMFN;
            sSQL += " , " + AllStudentsRegisteredMFN;
            sSQL += " , " + ExpectedtoExtendFromDiplomaMFN;
            sSQL += " , " + NewUnRegisteredMFN;
            sSQL += " , " + ExtendedUnRegisteredMFN;
            sSQL += " , " + AllStudentsUnRegisteredMFN;
            sSQL += " , " + PostponedUnregisteredMFN;
            sSQL += " , " + DiscontinuedUnRegisteredMFN;
            sSQL += " , " + Target_ExtendedRegFromExpectedToGraduateFFN;
            sSQL += " , " + Target_ExtendedRegFromGraduatedStudentsFFN;
            sSQL += " , " + Target_OldStudentsFFN;
            sSQL += " , " + Target_PostponedDiscontinuedStudentsFFN;
            sSQL += " , " + NewRegisteredFFN;
            sSQL += " , " + ExtendedRegFromExpectedToGraduateFFN;
            sSQL += " , " + ExtendedRegFromGraduatedStudentsFFN;
            sSQL += " , " + AllStudentsRegisteredFFN;
            sSQL += " , " + ExpectedtoExtendFromDiplomaFFN;
            sSQL += " , " + NewUnRegisteredFFN;
            sSQL += " , " + OldUnRegisteredFFN;
            sSQL += " , " + OldRegisteredFFN;
            sSQL += " , " + Extended_ESL_FFN;
            sSQL += " , " + ReadmittedF_RegFN;
            sSQL += " , " + ExtendedUnRegisteredFFN;
            sSQL += " , " + AllStudentsUnRegisteredFFN;
            sSQL += " , " + PostponedUnregisteredFFN;
            sSQL += " , " + DiscontinuedUnRegisteredFFN;
            sSQL += " , " + AM_Discontinued_Postponed_Withdrawn_RegFN;
            sSQL += " , " + AF_Discontinued_Postponed_Withdrawn_RegFN;
            sSQL += " , " + NewESL_M_VS_WantedMajorFN;
            sSQL += " , " + NewESL_F_VS_WantedMajorFN;
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
    public string GetListSQL(string sCondition)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += iOrderFN;
            sSQL += " , " + sMajorFN;
            sSQL += " , " + AcademicYearFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE 1=1 ";
            if (sCondition != "")
            {
                sSQL += " " + sCondition;
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
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += iOrderFN;
            sSQL += " , " + sMajorFN;
            sSQL += " , " + AcademicYearFN;
            sSQL += " , " + SemesterFN;
            sSQL += " , " + Target_NewStudentsMFN;
            sSQL += " , " + Target_NewStudentsFFN;
            sSQL += " , " + Target_ExtendedRegFromExpectedToGraduateMFN;
            sSQL += " , " + Target_ExtendedRegFromGraduatedStudentsMFN;
            sSQL += " , " + Target_OldStudentsMFN;
            sSQL += " , " + Target_PostponedDiscontinuedStudentsMFN;
            sSQL += " , " + NewRegisteredMFN;
            sSQL += " , " + OldRegisteredMFN;
            sSQL += " , " + Extended_ESL_MFN;
            sSQL += " , " + ReadmittedM_RegFN;
            sSQL += " , " + ExtendedRegFromExpectedToGraduateMFN;
            sSQL += " , " + ExtendedRegFromGraduatedStudentsMFN;
            sSQL += " , " + AllStudentsRegisteredMFN;
            sSQL += " , " + ExpectedtoExtendFromDiplomaMFN;
            sSQL += " , " + NewUnRegisteredMFN;
            sSQL += " , " + OldUnRegisteredMFN;
            sSQL += " , " + ExtendedUnRegisteredMFN;
            sSQL += " , " + AllStudentsUnRegisteredMFN;
            sSQL += " , " + PostponedUnregisteredMFN;
            sSQL += " , " + DiscontinuedUnRegisteredMFN;
            sSQL += " , " + Target_ExtendedRegFromExpectedToGraduateFFN;
            sSQL += " , " + Target_ExtendedRegFromGraduatedStudentsFFN;
            sSQL += " , " + Target_OldStudentsFFN;
            sSQL += " , " + Target_PostponedDiscontinuedStudentsFFN;
            sSQL += " , " + NewRegisteredFFN;
            sSQL += " , " + ExtendedRegFromExpectedToGraduateFFN;
            sSQL += " , " + ExtendedRegFromGraduatedStudentsFFN;
            sSQL += " , " + AllStudentsRegisteredFFN;
            sSQL += " , " + ExpectedtoExtendFromDiplomaFFN;
            sSQL += " , " + NewUnRegisteredFFN;
            sSQL += " , " + OldUnRegisteredFFN;
            sSQL += " , " + OldRegisteredFFN;
            sSQL += " , " + Extended_ESL_FFN;
            sSQL += " , " + ReadmittedF_RegFN;
            sSQL += " , " + ExtendedUnRegisteredFFN;
            sSQL += " , " + AllStudentsUnRegisteredFFN;
            sSQL += " , " + PostponedUnregisteredFFN;
            sSQL += " , " + DiscontinuedUnRegisteredFFN;
            sSQL += " , " + AM_Discontinued_Postponed_Withdrawn_RegFN;
            sSQL += " , " + AF_Discontinued_Postponed_Withdrawn_RegFN;
            sSQL += " , " + NewESL_M_VS_WantedMajorFN;
            sSQL += " , " + NewESL_F_VS_WantedMajorFN;
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
        string sSQL = "";
        try
        {
            sSQL = "UPDATE " + TableName;
            sSQL += " SET ";
            sSQL += LibraryMOD.GetFieldName(iOrderFN) + "=@iOrder";
            sSQL += " , " + LibraryMOD.GetFieldName(sMajorFN) + "=@sMajor";
            sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_NewStudentsMFN) + "=@Target_NewStudentsM";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_NewStudentsFFN) + "=@Target_NewStudentsF";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN) + "=@Target_ExtendedRegFromExpectedToGraduateM";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN) + "=@Target_ExtendedRegFromGraduatedStudentsM";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_OldStudentsMFN) + "=@Target_OldStudentsM";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN) + "=@Target_PostponedDiscontinuedStudentsM";
            sSQL += " , " + LibraryMOD.GetFieldName(NewRegisteredMFN) + "=@NewRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(OldRegisteredMFN) + "=@OldRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(Extended_ESL_MFN) + "=@Extended_ESL_M";
            sSQL += " , " + LibraryMOD.GetFieldName(ReadmittedM_RegFN) + "=@ReadmittedM_Reg";
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN) + "=@ExtendedRegFromExpectedToGraduateM";
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN) + "=@ExtendedRegFromGraduatedStudentsM";
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsRegisteredMFN) + "=@AllStudentsRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN) + "=@ExpectedtoExtendFromDiplomaM";
            sSQL += " , " + LibraryMOD.GetFieldName(NewUnRegisteredMFN) + "=@NewUnRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(OldUnRegisteredMFN) + "=@OldUnRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN) + "=@ExtendedUnRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN) + "=@AllStudentsUnRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(PostponedUnregisteredMFN) + "=@PostponedUnregisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN) + "=@DiscontinuedUnRegisteredM";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN) + "=@Target_ExtendedRegFromExpectedToGraduateF";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN) + "=@Target_ExtendedRegFromGraduatedStudentsF";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_OldStudentsFFN) + "=@Target_OldStudentsF";
            sSQL += " , " + LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN) + "=@Target_PostponedDiscontinuedStudentsF";
            sSQL += " , " + LibraryMOD.GetFieldName(NewRegisteredFFN) + "=@NewRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN) + "=@ExtendedRegFromExpectedToGraduateF";
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN) + "=@ExtendedRegFromGraduatedStudentsF";
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsRegisteredFFN) + "=@AllStudentsRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN) + "=@ExpectedtoExtendFromDiplomaF";
            sSQL += " , " + LibraryMOD.GetFieldName(NewUnRegisteredFFN) + "=@NewUnRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(OldUnRegisteredFFN) + "=@OldUnRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(OldRegisteredFFN) + "=@OldRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(Extended_ESL_FFN) + "=@Extended_ESL_F";
            sSQL += " , " + LibraryMOD.GetFieldName(ReadmittedF_RegFN) + "=@ReadmittedF_Reg";
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN) + "=@ExtendedUnRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN) + "=@AllStudentsUnRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(PostponedUnregisteredFFN) + "=@PostponedUnregisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN) + "=@DiscontinuedUnRegisteredF";
            sSQL += " , " + LibraryMOD.GetFieldName(AM_Discontinued_Postponed_Withdrawn_RegFN) + "=@AM_Discontinued_Postponed_Withdrawn_Reg";
            sSQL += " , " + LibraryMOD.GetFieldName(AF_Discontinued_Postponed_Withdrawn_RegFN) + "=@AF_Discontinued_Postponed_Withdrawn_Reg";
            sSQL += " , " + LibraryMOD.GetFieldName(NewESL_M_VS_WantedMajorFN) + "=@NewESL_M_VS_WantedMajor";
            sSQL += " , " + LibraryMOD.GetFieldName(NewESL_F_VS_WantedMajorFN) + "=@NewESL_F_VS_WantedMajor";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(sMajorFN) + "=@sMajor";
            sSQL += " And " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
            sSQL += " And " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
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
        string sSQL = "";
        try
        {
            sSQL = "INSERT intO " + TableName;
            sSQL += "( ";
            sSQL += LibraryMOD.GetFieldName(iOrderFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sMajorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_NewStudentsMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_NewStudentsFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_OldStudentsMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NewRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(OldRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Extended_ESL_MFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ReadmittedM_RegFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NewUnRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(OldUnRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PostponedUnregisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_OldStudentsFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NewRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NewUnRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(OldUnRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(OldRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(Extended_ESL_FFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ReadmittedF_RegFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PostponedUnregisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AM_Discontinued_Postponed_Withdrawn_RegFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AF_Discontinued_Postponed_Withdrawn_RegFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NewESL_M_VS_WantedMajorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NewESL_F_VS_WantedMajorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @iOrder";
            sSQL += " ,@sMajor";
            sSQL += " ,@AcademicYear";
            sSQL += " ,@Semester";
            sSQL += " ,@Target_NewStudentsM";
            sSQL += " ,@Target_NewStudentsF";
            sSQL += " ,@Target_ExtendedRegFromExpectedToGraduateM";
            sSQL += " ,@Target_ExtendedRegFromGraduatedStudentsM";
            sSQL += " ,@Target_OldStudentsM";
            sSQL += " ,@Target_PostponedDiscontinuedStudentsM";
            sSQL += " ,@NewRegisteredM";
            sSQL += " ,@OldRegisteredM";
            sSQL += " ,@Extended_ESL_M";
            sSQL += " ,@ReadmittedM_Reg";
            sSQL += " ,@ExtendedRegFromExpectedToGraduateM";
            sSQL += " ,@ExtendedRegFromGraduatedStudentsM";
            sSQL += " ,@AllStudentsRegisteredM";
            sSQL += " ,@ExpectedtoExtendFromDiplomaM";
            sSQL += " ,@NewUnRegisteredM";
            sSQL += " ,@OldUnRegisteredM";
            sSQL += " ,@ExtendedUnRegisteredM";
            sSQL += " ,@AllStudentsUnRegisteredM";
            sSQL += " ,@PostponedUnregisteredM";
            sSQL += " ,@DiscontinuedUnRegisteredM";
            sSQL += " ,@Target_ExtendedRegFromExpectedToGraduateF";
            sSQL += " ,@Target_ExtendedRegFromGraduatedStudentsF";
            sSQL += " ,@Target_OldStudentsF";
            sSQL += " ,@Target_PostponedDiscontinuedStudentsF";
            sSQL += " ,@NewRegisteredF";
            sSQL += " ,@ExtendedRegFromExpectedToGraduateF";
            sSQL += " ,@ExtendedRegFromGraduatedStudentsF";
            sSQL += " ,@AllStudentsRegisteredF";
            sSQL += " ,@ExpectedtoExtendFromDiplomaF";
            sSQL += " ,@NewUnRegisteredF";
            sSQL += " ,@OldUnRegisteredF";
            sSQL += " ,@OldRegisteredF";
            sSQL += " ,@Extended_ESL_F";
            sSQL += " ,@ReadmittedF_Reg";
            sSQL += " ,@ExtendedUnRegisteredF";
            sSQL += " ,@AllStudentsUnRegisteredF";
            sSQL += " ,@PostponedUnregisteredF";
            sSQL += " ,@DiscontinuedUnRegisteredF";
            sSQL += " ,@AM_Discontinued_Postponed_Withdrawn_Reg";
            sSQL += " ,@AF_Discontinued_Postponed_Withdrawn_Reg";
            sSQL += " ,@NewESL_M_VS_WantedMajor";
            sSQL += " ,@NewESL_F_VS_WantedMajor";
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
    public string GetDeleteCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "DELETE FROM " + TableName;
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(sMajorFN) + "=@sMajor";
            sSQL += " And " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
            sSQL += " And " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
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
    public List<SemesterTargetHistory> GetSemesterTargetHistory(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the SemesterTargetHistory
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
        List<SemesterTargetHistory> results = new List<SemesterTargetHistory>();
        try
        {
            //Default Value
            SemesterTargetHistory mySemesterTargetHistory = new SemesterTargetHistory();
            if (isDeafaultIncluded)
            {
                //Change the code here
                mySemesterTargetHistory.sMajor = "";
                mySemesterTargetHistory.AcademicYear = 0;
                mySemesterTargetHistory.Semester = 0;
            
                results.Add(mySemesterTargetHistory);
            }
            while (reader.Read())
            {
                mySemesterTargetHistory = new SemesterTargetHistory();
                if (reader[LibraryMOD.GetFieldName(iOrderFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.iOrder = 0;
                }
                else
                {
                    mySemesterTargetHistory.iOrder = int.Parse(reader[LibraryMOD.GetFieldName(iOrderFN)].ToString());
                }
                mySemesterTargetHistory.sMajor = reader[LibraryMOD.GetFieldName(sMajorFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.AcademicYear = 0;
                }
                else
                {
                    mySemesterTargetHistory.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName(AcademicYearFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Semester = 0;
                }
                else
                {
                    mySemesterTargetHistory.Semester = int.Parse(reader[LibraryMOD.GetFieldName(SemesterFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_NewStudentsMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_NewStudentsM = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_NewStudentsM = int.Parse(reader[LibraryMOD.GetFieldName(Target_NewStudentsMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_NewStudentsFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_NewStudentsF = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_NewStudentsF = int.Parse(reader[LibraryMOD.GetFieldName(Target_NewStudentsFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromExpectedToGraduateM = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromExpectedToGraduateM = int.Parse(reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromGraduatedStudentsM = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromGraduatedStudentsM = int.Parse(reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_OldStudentsMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_OldStudentsM = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_OldStudentsM = int.Parse(reader[LibraryMOD.GetFieldName(Target_OldStudentsMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_PostponedDiscontinuedStudentsM = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_PostponedDiscontinuedStudentsM = int.Parse(reader[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(NewRegisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.NewRegisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.NewRegisteredM = int.Parse(reader[LibraryMOD.GetFieldName(NewRegisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(OldRegisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.OldRegisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.OldRegisteredM = int.Parse(reader[LibraryMOD.GetFieldName(OldRegisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Extended_ESL_MFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Extended_ESL_M = 0;
                }
                else
                {
                    mySemesterTargetHistory.Extended_ESL_M = int.Parse(reader[LibraryMOD.GetFieldName(Extended_ESL_MFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExtendedRegFromExpectedToGraduateM = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExtendedRegFromExpectedToGraduateM = int.Parse(reader[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExtendedRegFromGraduatedStudentsM = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExtendedRegFromGraduatedStudentsM = int.Parse(reader[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AllStudentsRegisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.AllStudentsRegisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.AllStudentsRegisteredM = int.Parse(reader[LibraryMOD.GetFieldName(AllStudentsRegisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExpectedtoExtendFromDiplomaM = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExpectedtoExtendFromDiplomaM = int.Parse(reader[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(NewUnRegisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.NewUnRegisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.NewUnRegisteredM = int.Parse(reader[LibraryMOD.GetFieldName(NewUnRegisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExtendedUnRegisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExtendedUnRegisteredM = int.Parse(reader[LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.AllStudentsUnRegisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.AllStudentsUnRegisteredM = int.Parse(reader[LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(PostponedUnregisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.PostponedUnregisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.PostponedUnregisteredM = int.Parse(reader[LibraryMOD.GetFieldName(PostponedUnregisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.DiscontinuedUnRegisteredM = 0;
                }
                else
                {
                    mySemesterTargetHistory.DiscontinuedUnRegisteredM = int.Parse(reader[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromExpectedToGraduateF = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromExpectedToGraduateF = int.Parse(reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromGraduatedStudentsF = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_ExtendedRegFromGraduatedStudentsF = int.Parse(reader[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_OldStudentsFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_OldStudentsF = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_OldStudentsF = int.Parse(reader[LibraryMOD.GetFieldName(Target_OldStudentsFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Target_PostponedDiscontinuedStudentsF = 0;
                }
                else
                {
                    mySemesterTargetHistory.Target_PostponedDiscontinuedStudentsF = int.Parse(reader[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(NewRegisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.NewRegisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.NewRegisteredF = int.Parse(reader[LibraryMOD.GetFieldName(NewRegisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExtendedRegFromExpectedToGraduateF = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExtendedRegFromExpectedToGraduateF = int.Parse(reader[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExtendedRegFromGraduatedStudentsF = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExtendedRegFromGraduatedStudentsF = int.Parse(reader[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AllStudentsRegisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.AllStudentsRegisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.AllStudentsRegisteredF = int.Parse(reader[LibraryMOD.GetFieldName(AllStudentsRegisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExpectedtoExtendFromDiplomaF = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExpectedtoExtendFromDiplomaF = int.Parse(reader[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(NewUnRegisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.NewUnRegisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.NewUnRegisteredF = int.Parse(reader[LibraryMOD.GetFieldName(NewUnRegisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(OldRegisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.OldRegisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.OldRegisteredF = int.Parse(reader[LibraryMOD.GetFieldName(OldRegisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(Extended_ESL_FFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.Extended_ESL_F = 0;
                }
                else
                {
                    mySemesterTargetHistory.Extended_ESL_F = int.Parse(reader[LibraryMOD.GetFieldName(Extended_ESL_FFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.ExtendedUnRegisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.ExtendedUnRegisteredF = int.Parse(reader[LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.AllStudentsUnRegisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.AllStudentsUnRegisteredF = int.Parse(reader[LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(PostponedUnregisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.PostponedUnregisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.PostponedUnregisteredF = int.Parse(reader[LibraryMOD.GetFieldName(PostponedUnregisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.DiscontinuedUnRegisteredF = 0;
                }
                else
                {
                    mySemesterTargetHistory.DiscontinuedUnRegisteredF = int.Parse(reader[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.CreationUserID = 0;
                }
                else
                {
                    mySemesterTargetHistory.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.LastUpdateUserID = 0;
                }
                else
                {
                    mySemesterTargetHistory.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                mySemesterTargetHistory.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                mySemesterTargetHistory.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(mySemesterTargetHistory);
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
    public List<SemesterTargetHistory> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<SemesterTargetHistory> results = new List<SemesterTargetHistory>();
        try
        {
            //Default Value
            SemesterTargetHistory mySemesterTargetHistory = new SemesterTargetHistory();
            if (isDeafaultIncluded)
            {
                //Change the code here
                mySemesterTargetHistory.iOrder = -1;
                mySemesterTargetHistory.sMajor = "Select SemesterTargetHistory";
                results.Add(mySemesterTargetHistory);
            }
            while (reader.Read())
            {
                mySemesterTargetHistory = new SemesterTargetHistory();
                if (reader[LibraryMOD.GetFieldName(iOrderFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.iOrder = 0;
                }
                else
                {
                    mySemesterTargetHistory.iOrder = int.Parse(reader[LibraryMOD.GetFieldName(iOrderFN)].ToString());
                }
                mySemesterTargetHistory.sMajor = reader[LibraryMOD.GetFieldName(sMajorFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
                {
                    mySemesterTargetHistory.AcademicYear = 0;
                }
                else
                {
                    mySemesterTargetHistory.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName(AcademicYearFN)].ToString());
                }
                results.Add(mySemesterTargetHistory);
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
    public int UpdateSemesterTargetHistory(InitializeModule.EnumCampus Campus, int iMode, int iOrder, string sMajor, int AcademicYear
        , int Semester, int Target_NewStudentsM, int Target_NewStudentsF, int Target_ExtendedRegFromExpectedToGraduateM
        , int Target_ExtendedRegFromGraduatedStudentsM, int Target_OldStudentsM, int Target_PostponedDiscontinuedStudentsM
        , int NewRegisteredM, int OldRegisteredM, int Extended_ESL_M,int ReadmittedM_Reg, int ExtendedRegFromExpectedToGraduateM
        , int ExtendedRegFromGraduatedStudentsM, int AllStudentsRegisteredM, int ExpectedtoExtendFromDiplomaM
        , int NewUnRegisteredM, int OldUnRegisteredM, int ExtendedUnRegisteredM, int AllStudentsUnRegisteredM
        , int PostponedUnregisteredM, int DiscontinuedUnRegisteredM, int Target_ExtendedRegFromExpectedToGraduateF
        , int Target_ExtendedRegFromGraduatedStudentsF, int Target_OldStudentsF
        , int Target_PostponedDiscontinuedStudentsF, int NewRegisteredF, int OldRegisteredF
        , int Extended_ESL_F,int ReadmittedF_Reg, int ExtendedRegFromExpectedToGraduateF
        , int ExtendedRegFromGraduatedStudentsF, int AllStudentsRegisteredF
        , int ExpectedtoExtendFromDiplomaF, int NewUnRegisteredF, int OldUnRegisteredF, int ExtendedUnRegisteredF
        , int AllStudentsUnRegisteredF, int PostponedUnregisteredF, int DiscontinuedUnRegisteredF
        , int AM_Discontinued_Postponed_Withdrawn_Reg, int AF_Discontinued_Postponed_Withdrawn_Reg
        , int NewESL_M_VS_WantedMajor, int NewESL_F_VS_WantedMajor
        , int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate
        , string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            SemesterTargetHistory theSemesterTargetHistory = new SemesterTargetHistory();
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
            Cmd.Parameters.Add(new SqlParameter("@iOrder", iOrder));
            Cmd.Parameters.Add(new SqlParameter("@sMajor", sMajor));
            Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear));
            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
            Cmd.Parameters.Add(new SqlParameter("@Target_NewStudentsM", Target_NewStudentsM));
            Cmd.Parameters.Add(new SqlParameter("@Target_NewStudentsF", Target_NewStudentsF));
            Cmd.Parameters.Add(new SqlParameter("@Target_ExtendedRegFromExpectedToGraduateM", Target_ExtendedRegFromExpectedToGraduateM));
            Cmd.Parameters.Add(new SqlParameter("@Target_ExtendedRegFromGraduatedStudentsM", Target_ExtendedRegFromGraduatedStudentsM));
            Cmd.Parameters.Add(new SqlParameter("@Target_OldStudentsM", Target_OldStudentsM));
            Cmd.Parameters.Add(new SqlParameter("@Target_PostponedDiscontinuedStudentsM", Target_PostponedDiscontinuedStudentsM));
            Cmd.Parameters.Add(new SqlParameter("@NewRegisteredM", NewRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@OldRegisteredM", OldRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@Extended_ESL_M", Extended_ESL_M));
            Cmd.Parameters.Add(new SqlParameter("@ReadmittedM_Reg", ReadmittedM_Reg));

            Cmd.Parameters.Add(new SqlParameter("@ExtendedRegFromExpectedToGraduateM", ExtendedRegFromExpectedToGraduateM));
            Cmd.Parameters.Add(new SqlParameter("@ExtendedRegFromGraduatedStudentsM", ExtendedRegFromGraduatedStudentsM));
            Cmd.Parameters.Add(new SqlParameter("@AllStudentsRegisteredM", AllStudentsRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@ExpectedtoExtendFromDiplomaM", ExpectedtoExtendFromDiplomaM));
            Cmd.Parameters.Add(new SqlParameter("@NewUnRegisteredM", NewUnRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@OldUnRegisteredM", OldUnRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@ExtendedUnRegisteredM", ExtendedUnRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@AllStudentsUnRegisteredM", AllStudentsUnRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@PostponedUnregisteredM", PostponedUnregisteredM));
            Cmd.Parameters.Add(new SqlParameter("@DiscontinuedUnRegisteredM", DiscontinuedUnRegisteredM));
            Cmd.Parameters.Add(new SqlParameter("@Target_ExtendedRegFromExpectedToGraduateF", Target_ExtendedRegFromExpectedToGraduateF));
            Cmd.Parameters.Add(new SqlParameter("@Target_ExtendedRegFromGraduatedStudentsF", Target_ExtendedRegFromGraduatedStudentsF));
            Cmd.Parameters.Add(new SqlParameter("@Target_OldStudentsF", Target_OldStudentsF));
            Cmd.Parameters.Add(new SqlParameter("@Target_PostponedDiscontinuedStudentsF", Target_PostponedDiscontinuedStudentsF));
            Cmd.Parameters.Add(new SqlParameter("@NewRegisteredF", NewRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@ExtendedRegFromExpectedToGraduateF", ExtendedRegFromExpectedToGraduateF));
            Cmd.Parameters.Add(new SqlParameter("@ExtendedRegFromGraduatedStudentsF", ExtendedRegFromGraduatedStudentsF));
            Cmd.Parameters.Add(new SqlParameter("@AllStudentsRegisteredF", AllStudentsRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@ExpectedtoExtendFromDiplomaF", ExpectedtoExtendFromDiplomaF));
            Cmd.Parameters.Add(new SqlParameter("@NewUnRegisteredF", NewUnRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@OldUnRegisteredF", OldUnRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@OldRegisteredF", OldRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@Extended_ESL_F", Extended_ESL_F));
            Cmd.Parameters.Add(new SqlParameter("@ReadmittedF_Reg", ReadmittedF_Reg));
            Cmd.Parameters.Add(new SqlParameter("@ExtendedUnRegisteredF", ExtendedUnRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@AllStudentsUnRegisteredF", AllStudentsUnRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@PostponedUnregisteredF", PostponedUnregisteredF));
            Cmd.Parameters.Add(new SqlParameter("@DiscontinuedUnRegisteredF", DiscontinuedUnRegisteredF));
            Cmd.Parameters.Add(new SqlParameter("@AM_Discontinued_Postponed_Withdrawn_Reg", AM_Discontinued_Postponed_Withdrawn_Reg));
            Cmd.Parameters.Add(new SqlParameter("@AF_Discontinued_Postponed_Withdrawn_Reg", AF_Discontinued_Postponed_Withdrawn_Reg));
            
            Cmd.Parameters.Add(new SqlParameter("@NewESL_M_VS_WantedMajor", NewESL_M_VS_WantedMajor));
            Cmd.Parameters.Add(new SqlParameter("@NewESL_F_VS_WantedMajor", NewESL_F_VS_WantedMajor));

            Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
            Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", LastUpdateDate));
            Cmd.Parameters.Add(new SqlParameter("@PCName", PCName));
            Cmd.Parameters.Add(new SqlParameter("@NetUserName", NetUserName));

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
    public int DeleteSemesterTargetHistory(InitializeModule.EnumCampus Campus, string sMajor, string AcademicYear, string Semester)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@sMajor", sMajor));
            Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear));
            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
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
    public DataView GetDataView(bool isFromRole, int PK, string sCondition)
    {
        DataTable dt = new DataTable("SemesterTargetHistory");
        DataView dv = new DataView();
        List<SemesterTargetHistory> mySemesterTargetHistorys = new List<SemesterTargetHistory>();
        try
        {
            mySemesterTargetHistorys = GetSemesterTargetHistory(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("iOrder", Type.GetType("int"));
            dt.Columns.Add(col0);
            DataColumn col1 = new DataColumn("sMajor", Type.GetType("nvarchar"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("AcademicYear", Type.GetType("int"));
            dt.Columns.Add(col2);
            
            dt.Constraints.Add(new UniqueConstraint(col0));
            dt.Constraints.Add(new UniqueConstraint(col1));
            dt.Constraints.Add(new UniqueConstraint(col2));

            DataRow dr;
            for (int i = 0; i < mySemesterTargetHistorys.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = mySemesterTargetHistorys[i].iOrder;
                dr[2] = mySemesterTargetHistorys[i].sMajor;
                dr[3] = mySemesterTargetHistorys[i].AcademicYear;
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
            mySemesterTargetHistorys.Clear();
        }
        return dv;
    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con)
    {
        string sSQL = "";
        DataTable table = new DataTable();
        try
        {
            sSQL = "SELECT";
            sSQL += sMajorFN;
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
public class SemesterTargetHistoryCls : SemesterTargetHistoryDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daSemesterTargetHistory;
    private DataSet m_dsSemesterTargetHistory;
    public DataRow SemesterTargetHistoryDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsSemesterTargetHistory
    {
        get { return m_dsSemesterTargetHistory; }
        set { m_dsSemesterTargetHistory = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public SemesterTargetHistoryCls()
    {
        try
        {
            dsSemesterTargetHistory = new DataSet();

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
    public virtual SqlDataAdapter GetSemesterTargetHistoryDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daSemesterTargetHistory = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSemesterTargetHistory);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daSemesterTargetHistory.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSemesterTargetHistory;
    }
    public virtual SqlDataAdapter GetSemesterTargetHistoryDataAdapter(SqlConnection con)
    {
        try
        {
            daSemesterTargetHistory = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daSemesterTargetHistory.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdSemesterTargetHistory;
            cmdSemesterTargetHistory = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@sMajor", SqlDbType.Int, 4, "sMajor" );
            //'cmdRolePermission.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, "AcademicYear" );
            //'cmdRolePermission.Parameters.Add("@Semester", SqlDbType.Int, 4, "Semester" );
            daSemesterTargetHistory.SelectCommand = cmdSemesterTargetHistory;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdSemesterTargetHistory = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdSemesterTargetHistory.Parameters.Add("@iOrder", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iOrderFN));
            cmdSemesterTargetHistory.Parameters.Add("@sMajor", SqlDbType.NVarChar, 400, LibraryMOD.GetFieldName(sMajorFN));
            cmdSemesterTargetHistory.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            cmdSemesterTargetHistory.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_NewStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_NewStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_NewStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_NewStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromExpectedToGraduateM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromGraduatedStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_OldStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_OldStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_PostponedDiscontinuedStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@OldRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(OldRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Extended_ESL_M", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Extended_ESL_MFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromExpectedToGraduateM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromGraduatedStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExpectedtoExtendFromDiplomaM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@PostponedUnregisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PostponedUnregisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@DiscontinuedUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromExpectedToGraduateF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromGraduatedStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_OldStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_OldStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_PostponedDiscontinuedStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromExpectedToGraduateF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromGraduatedStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExpectedtoExtendFromDiplomaF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@OldRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(OldRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Extended_ESL_F", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Extended_ESL_FFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@PostponedUnregisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PostponedUnregisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@DiscontinuedUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSemesterTargetHistory.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSemesterTargetHistory.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSemesterTargetHistory.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSemesterTargetHistory.Parameters.Add("@PCName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PCNameFN));
            cmdSemesterTargetHistory.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdSemesterTargetHistory.Parameters.Add("@sMajor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sMajorFN));
            Parmeter = cmdSemesterTargetHistory.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            Parmeter = cmdSemesterTargetHistory.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daSemesterTargetHistory.UpdateCommand = cmdSemesterTargetHistory;
            daSemesterTargetHistory.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdSemesterTargetHistory = new SqlCommand(GetInsertCommand(), con);
            cmdSemesterTargetHistory.Parameters.Add("@iOrder", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iOrderFN));
            cmdSemesterTargetHistory.Parameters.Add("@sMajor", SqlDbType.NVarChar, 400, LibraryMOD.GetFieldName(sMajorFN));
            cmdSemesterTargetHistory.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            cmdSemesterTargetHistory.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_NewStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_NewStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_NewStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_NewStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromExpectedToGraduateM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromGraduatedStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_OldStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_OldStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_PostponedDiscontinuedStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@OldRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(OldRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Extended_ESL_M", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Extended_ESL_MFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromExpectedToGraduateM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromGraduatedStudentsM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExpectedtoExtendFromDiplomaM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@PostponedUnregisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PostponedUnregisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@DiscontinuedUnRegisteredM", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromExpectedToGraduateF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_ExtendedRegFromGraduatedStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_OldStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_OldStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Target_PostponedDiscontinuedStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromExpectedToGraduateF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedRegFromGraduatedStudentsF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExpectedtoExtendFromDiplomaF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN));
            cmdSemesterTargetHistory.Parameters.Add("@NewUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NewUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@OldRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(OldRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@Extended_ESL_F", SqlDbType.Int, 4, LibraryMOD.GetFieldName(Extended_ESL_FFN));
            cmdSemesterTargetHistory.Parameters.Add("@ExtendedUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@AllStudentsUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@PostponedUnregisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PostponedUnregisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@DiscontinuedUnRegisteredF", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN));
            cmdSemesterTargetHistory.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSemesterTargetHistory.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSemesterTargetHistory.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSemesterTargetHistory.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSemesterTargetHistory.Parameters.Add("@PCName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PCNameFN));
            cmdSemesterTargetHistory.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daSemesterTargetHistory.InsertCommand = cmdSemesterTargetHistory;
            daSemesterTargetHistory.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdSemesterTargetHistory = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdSemesterTargetHistory.Parameters.Add("@sMajor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sMajorFN));
            Parmeter = cmdSemesterTargetHistory.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            Parmeter = cmdSemesterTargetHistory.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daSemesterTargetHistory.DeleteCommand = cmdSemesterTargetHistory;
            daSemesterTargetHistory.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daSemesterTargetHistory.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSemesterTargetHistory;
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
                    dr = dsSemesterTargetHistory.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(iOrderFN)] = iOrder;
                    dr[LibraryMOD.GetFieldName(sMajorFN)] = sMajor;
                    dr[LibraryMOD.GetFieldName(AcademicYearFN)] = AcademicYear;
                    dr[LibraryMOD.GetFieldName(SemesterFN)] = Semester;
                    dr[LibraryMOD.GetFieldName(Target_NewStudentsMFN)] = Target_NewStudentsM;
                    dr[LibraryMOD.GetFieldName(Target_NewStudentsFFN)] = Target_NewStudentsF;
                    dr[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN)] = Target_ExtendedRegFromExpectedToGraduateM;
                    dr[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN)] = Target_ExtendedRegFromGraduatedStudentsM;
                    dr[LibraryMOD.GetFieldName(Target_OldStudentsMFN)] = Target_OldStudentsM;
                    dr[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN)] = Target_PostponedDiscontinuedStudentsM;
                    dr[LibraryMOD.GetFieldName(NewRegisteredMFN)] = NewRegisteredM;
                    dr[LibraryMOD.GetFieldName(OldRegisteredMFN)] = OldRegisteredM;
                    dr[LibraryMOD.GetFieldName(Extended_ESL_MFN)] = Extended_ESL_M;
                    dr[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN)] = ExtendedRegFromExpectedToGraduateM;
                    dr[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN)] = ExtendedRegFromGraduatedStudentsM;
                    dr[LibraryMOD.GetFieldName(AllStudentsRegisteredMFN)] = AllStudentsRegisteredM;
                    dr[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN)] = ExpectedtoExtendFromDiplomaM;
                    dr[LibraryMOD.GetFieldName(NewUnRegisteredMFN)] = NewUnRegisteredM;
                    dr[LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN)] = ExtendedUnRegisteredM;
                    dr[LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN)] = AllStudentsUnRegisteredM;
                    dr[LibraryMOD.GetFieldName(PostponedUnregisteredMFN)] = PostponedUnregisteredM;
                    dr[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN)] = DiscontinuedUnRegisteredM;
                    dr[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN)] = Target_ExtendedRegFromExpectedToGraduateF;
                    dr[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN)] = Target_ExtendedRegFromGraduatedStudentsF;
                    dr[LibraryMOD.GetFieldName(Target_OldStudentsFFN)] = Target_OldStudentsF;
                    dr[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN)] = Target_PostponedDiscontinuedStudentsF;
                    dr[LibraryMOD.GetFieldName(NewRegisteredFFN)] = NewRegisteredF;
                    dr[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN)] = ExtendedRegFromExpectedToGraduateF;
                    dr[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN)] = ExtendedRegFromGraduatedStudentsF;
                    dr[LibraryMOD.GetFieldName(AllStudentsRegisteredFFN)] = AllStudentsRegisteredF;
                    dr[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN)] = ExpectedtoExtendFromDiplomaF;
                    dr[LibraryMOD.GetFieldName(NewUnRegisteredFFN)] = NewUnRegisteredF;
                    dr[LibraryMOD.GetFieldName(OldRegisteredFFN)] = OldRegisteredF;
                    dr[LibraryMOD.GetFieldName(Extended_ESL_FFN)] = Extended_ESL_F;
                    dr[LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN)] = ExtendedUnRegisteredF;
                    dr[LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN)] = AllStudentsUnRegisteredF;
                    dr[LibraryMOD.GetFieldName(PostponedUnregisteredFFN)] = PostponedUnregisteredF;
                    dr[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN)] = DiscontinuedUnRegisteredF;
                    dsSemesterTargetHistory.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsSemesterTargetHistory.Tables[TableName].Select(LibraryMOD.GetFieldName(sMajorFN) + "=" + sMajor + " AND " + LibraryMOD.GetFieldName(AcademicYearFN) + "=" + AcademicYear + " AND " + LibraryMOD.GetFieldName(SemesterFN) + "=" + Semester);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(iOrderFN)] = iOrder;
                    drAry[0][LibraryMOD.GetFieldName(sMajorFN)] = sMajor;
                    drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)] = AcademicYear;
                    drAry[0][LibraryMOD.GetFieldName(SemesterFN)] = Semester;
                    drAry[0][LibraryMOD.GetFieldName(Target_NewStudentsMFN)] = Target_NewStudentsM;
                    drAry[0][LibraryMOD.GetFieldName(Target_NewStudentsFFN)] = Target_NewStudentsF;
                    drAry[0][LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN)] = Target_ExtendedRegFromExpectedToGraduateM;
                    drAry[0][LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN)] = Target_ExtendedRegFromGraduatedStudentsM;
                    drAry[0][LibraryMOD.GetFieldName(Target_OldStudentsMFN)] = Target_OldStudentsM;
                    drAry[0][LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN)] = Target_PostponedDiscontinuedStudentsM;
                    drAry[0][LibraryMOD.GetFieldName(NewRegisteredMFN)] = NewRegisteredM;
                    drAry[0][LibraryMOD.GetFieldName(OldRegisteredMFN)] = OldRegisteredM;
                    drAry[0][LibraryMOD.GetFieldName(Extended_ESL_MFN)] = Extended_ESL_M;
                    drAry[0][LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN)] = ExtendedRegFromExpectedToGraduateM;
                    drAry[0][LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN)] = ExtendedRegFromGraduatedStudentsM;
                    drAry[0][LibraryMOD.GetFieldName(AllStudentsRegisteredMFN)] = AllStudentsRegisteredM;
                    drAry[0][LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN)] = ExpectedtoExtendFromDiplomaM;
                    drAry[0][LibraryMOD.GetFieldName(NewUnRegisteredMFN)] = NewUnRegisteredM;
                    drAry[0][LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN)] = ExtendedUnRegisteredM;
                    drAry[0][LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN)] = AllStudentsUnRegisteredM;
                    drAry[0][LibraryMOD.GetFieldName(PostponedUnregisteredMFN)] = PostponedUnregisteredM;
                    drAry[0][LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN)] = DiscontinuedUnRegisteredM;
                    drAry[0][LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN)] = Target_ExtendedRegFromExpectedToGraduateF;
                    drAry[0][LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN)] = Target_ExtendedRegFromGraduatedStudentsF;
                    drAry[0][LibraryMOD.GetFieldName(Target_OldStudentsFFN)] = Target_OldStudentsF;
                    drAry[0][LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN)] = Target_PostponedDiscontinuedStudentsF;
                    drAry[0][LibraryMOD.GetFieldName(NewRegisteredFFN)] = NewRegisteredF;
                    drAry[0][LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN)] = ExtendedRegFromExpectedToGraduateF;
                    drAry[0][LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN)] = ExtendedRegFromGraduatedStudentsF;
                    drAry[0][LibraryMOD.GetFieldName(AllStudentsRegisteredFFN)] = AllStudentsRegisteredF;
                    drAry[0][LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN)] = ExpectedtoExtendFromDiplomaF;
                    drAry[0][LibraryMOD.GetFieldName(NewUnRegisteredFFN)] = NewUnRegisteredF;
                    drAry[0][LibraryMOD.GetFieldName(OldRegisteredFFN)] = OldRegisteredF;
                    drAry[0][LibraryMOD.GetFieldName(Extended_ESL_FFN)] = Extended_ESL_F;
                    drAry[0][LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN)] = ExtendedUnRegisteredF;
                    drAry[0][LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN)] = AllStudentsUnRegisteredF;
                    drAry[0][LibraryMOD.GetFieldName(PostponedUnregisteredFFN)] = PostponedUnregisteredF;
                    drAry[0][LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN)] = DiscontinuedUnRegisteredF;
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
    public int CommitSemesterTargetHistory()
    {
        //CommitSemesterTargetHistory= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daSemesterTargetHistory.Update(dsSemesterTargetHistory, TableName);
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
            FindInMultiPKey(sMajor, AcademicYear, Semester);
            if ((SemesterTargetHistoryDataRow != null))
            {
                SemesterTargetHistoryDataRow.Delete();
                CommitSemesterTargetHistory();
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
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(iOrderFN)] == System.DBNull.Value)
            {
                iOrder = 0;
            }
            else
            {
                iOrder = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(iOrderFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(sMajorFN)] == System.DBNull.Value)
            {
                sMajor = "";
            }
            else
            {
                sMajor = (string)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(sMajorFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AcademicYearFN)] == System.DBNull.Value)
            {
                AcademicYear = 0;
            }
            else
            {
                AcademicYear = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(SemesterFN)] == System.DBNull.Value)
            {
                Semester = 0;
            }
            else
            {
                Semester = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(SemesterFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_NewStudentsMFN)] == System.DBNull.Value)
            {
                Target_NewStudentsM = 0;
            }
            else
            {
                Target_NewStudentsM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_NewStudentsMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_NewStudentsFFN)] == System.DBNull.Value)
            {
                Target_NewStudentsF = 0;
            }
            else
            {
                Target_NewStudentsF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_NewStudentsFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN)] == System.DBNull.Value)
            {
                Target_ExtendedRegFromExpectedToGraduateM = 0;
            }
            else
            {
                Target_ExtendedRegFromExpectedToGraduateM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN)] == System.DBNull.Value)
            {
                Target_ExtendedRegFromGraduatedStudentsM = 0;
            }
            else
            {
                Target_ExtendedRegFromGraduatedStudentsM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_OldStudentsMFN)] == System.DBNull.Value)
            {
                Target_OldStudentsM = 0;
            }
            else
            {
                Target_OldStudentsM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_OldStudentsMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN)] == System.DBNull.Value)
            {
                Target_PostponedDiscontinuedStudentsM = 0;
            }
            else
            {
                Target_PostponedDiscontinuedStudentsM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewRegisteredMFN)] == System.DBNull.Value)
            {
                NewRegisteredM = 0;
            }
            else
            {
                NewRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldRegisteredMFN)] == System.DBNull.Value)
            {
                OldRegisteredM = 0;
            }
            else
            {
                OldRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Extended_ESL_MFN)] == System.DBNull.Value)
            {
                Extended_ESL_M = 0;
            }
            else
            {
                Extended_ESL_M = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Extended_ESL_MFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN)] == System.DBNull.Value)
            {
                ExtendedRegFromExpectedToGraduateM = 0;
            }
            else
            {
                ExtendedRegFromExpectedToGraduateM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN)] == System.DBNull.Value)
            {
                ExtendedRegFromGraduatedStudentsM = 0;
            }
            else
            {
                ExtendedRegFromGraduatedStudentsM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsRegisteredMFN)] == System.DBNull.Value)
            {
                AllStudentsRegisteredM = 0;
            }
            else
            {
                AllStudentsRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN)] == System.DBNull.Value)
            {
                ExpectedtoExtendFromDiplomaM = 0;
            }
            else
            {
                ExpectedtoExtendFromDiplomaM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewUnRegisteredMFN)] == System.DBNull.Value)
            {
                NewUnRegisteredM = 0;
            }
            else
            {
                NewUnRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewUnRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldUnRegisteredMFN)] == System.DBNull.Value)
            {
                OldUnRegisteredM = 0;
            }
            else
            {
                OldUnRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldUnRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN)] == System.DBNull.Value)
            {
                ExtendedUnRegisteredM = 0;
            }
            else
            {
                ExtendedUnRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedUnRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN)] == System.DBNull.Value)
            {
                AllStudentsUnRegisteredM = 0;
            }
            else
            {
                AllStudentsUnRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsUnRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(PostponedUnregisteredMFN)] == System.DBNull.Value)
            {
                PostponedUnregisteredM = 0;
            }
            else
            {
                PostponedUnregisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(PostponedUnregisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN)] == System.DBNull.Value)
            {
                DiscontinuedUnRegisteredM = 0;
            }
            else
            {
                DiscontinuedUnRegisteredM = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredMFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN)] == System.DBNull.Value)
            {
                Target_ExtendedRegFromExpectedToGraduateF = 0;
            }
            else
            {
                Target_ExtendedRegFromExpectedToGraduateF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromExpectedToGraduateFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN)] == System.DBNull.Value)
            {
                Target_ExtendedRegFromGraduatedStudentsF = 0;
            }
            else
            {
                Target_ExtendedRegFromGraduatedStudentsF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_ExtendedRegFromGraduatedStudentsFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_OldStudentsFFN)] == System.DBNull.Value)
            {
                Target_OldStudentsF = 0;
            }
            else
            {
                Target_OldStudentsF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_OldStudentsFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN)] == System.DBNull.Value)
            {
                Target_PostponedDiscontinuedStudentsF = 0;
            }
            else
            {
                Target_PostponedDiscontinuedStudentsF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Target_PostponedDiscontinuedStudentsFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewRegisteredFFN)] == System.DBNull.Value)
            {
                NewRegisteredF = 0;
            }
            else
            {
                NewRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN)] == System.DBNull.Value)
            {
                ExtendedRegFromExpectedToGraduateF = 0;
            }
            else
            {
                ExtendedRegFromExpectedToGraduateF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromExpectedToGraduateFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN)] == System.DBNull.Value)
            {
                ExtendedRegFromGraduatedStudentsF = 0;
            }
            else
            {
                ExtendedRegFromGraduatedStudentsF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedRegFromGraduatedStudentsFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsRegisteredFFN)] == System.DBNull.Value)
            {
                AllStudentsRegisteredF = 0;
            }
            else
            {
                AllStudentsRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN)] == System.DBNull.Value)
            {
                ExpectedtoExtendFromDiplomaF = 0;
            }
            else
            {
                ExpectedtoExtendFromDiplomaF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExpectedtoExtendFromDiplomaFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewUnRegisteredFFN)] == System.DBNull.Value)
            {
                NewUnRegisteredF = 0;
            }
            else
            {
                NewUnRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NewUnRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldUnRegisteredFFN)] == System.DBNull.Value)
            {
                OldUnRegisteredF = 0;
            }
            else
            {
                OldUnRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldUnRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldRegisteredFFN)] == System.DBNull.Value)
            {
                OldRegisteredF = 0;
            }
            else
            {
                OldRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(OldRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Extended_ESL_FFN)] == System.DBNull.Value)
            {
                Extended_ESL_F = 0;
            }
            else
            {
                Extended_ESL_F = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(Extended_ESL_FFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN)] == System.DBNull.Value)
            {
                ExtendedUnRegisteredF = 0;
            }
            else
            {
                ExtendedUnRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(ExtendedUnRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN)] == System.DBNull.Value)
            {
                AllStudentsUnRegisteredF = 0;
            }
            else
            {
                AllStudentsUnRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(AllStudentsUnRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(PostponedUnregisteredFFN)] == System.DBNull.Value)
            {
                PostponedUnregisteredF = 0;
            }
            else
            {
                PostponedUnregisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(PostponedUnregisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN)] == System.DBNull.Value)
            {
                DiscontinuedUnRegisteredF = 0;
            }
            else
            {
                DiscontinuedUnRegisteredF = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(DiscontinuedUnRegisteredFFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)SemesterTargetHistoryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(string PKsMajor, int PKAcademicYear, int PKSemester)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKsMajor;
            findTheseVals[1] = PKAcademicYear;
            findTheseVals[2] = PKSemester;
            SemesterTargetHistoryDataRow = dsSemesterTargetHistory.Tables[TableName].Rows.Find(findTheseVals);
            if ((SemesterTargetHistoryDataRow != null))
            {
                lngCurRow = dsSemesterTargetHistory.Tables[TableName].Rows.IndexOf(SemesterTargetHistoryDataRow);
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
            lngCurRow = dsSemesterTargetHistory.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsSemesterTargetHistory.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsSemesterTargetHistory.Tables[TableName].Rows.Count > 0)
            {
                SemesterTargetHistoryDataRow = dsSemesterTargetHistory.Tables[TableName].Rows[lngCurRow];
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
            daSemesterTargetHistory.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSemesterTargetHistory.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daSemesterTargetHistory.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSemesterTargetHistory.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
