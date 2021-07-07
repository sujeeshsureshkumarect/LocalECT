using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AdmissionRequirments
/// </summary>
public class AdmissionRequirments
{
    //enum RemedialCourseRequirment
    //{
    //    HS = "HS",
    //    Remedial = "Remedial",
    //    HSandRemedial = "HS and Remedial",
    //    HSorRemedial = "HS or Remedial",
    //    Graduation = "Graduation",
    //    None = "None"
    //}

    //public AdmissionRequirments()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}
    //public static bool IsFulfilledAdmissionRequirements(InitializeModule.EnumCampus Campus, string StudentID, out bool IsMTH001Required, out bool IsCHEM001Required, out bool IsBIOL001Required, out bool IsPHYS001Required)
    //{
    //    bool IsFulfilledRequirements = false;

    //    //IsMTH001Required = false;
    //    //IsCHEM001Required = false;
    //    //IsBIOL001Required = false;
    //    //IsPHYS001Required = false;

    //    IsMTH001Required = true;
    //    IsCHEM001Required = true;
    //    IsBIOL001Required = true;
    //    IsPHYS001Required = true;

    //    Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus );
    //    SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
    //    Conn.Open();
    //    try
    //    {
    //        string sQuery = "";
    //        sQuery = "SELECT  HSR.iHSMajor, HSR.cMinCRSScore";
    //        sQuery += " , HSR.MTH001, HSR.CHEM001, HSR.PHYS001, HSR.BIOL001, HSR.HSScience";
    //        sQuery += " , HSR.sHSTrack, HSR.sDesc, HSR.isFNDReplacement, HSR.cHSMinScore"; 
    //        sQuery += " ,HSR.cHSMaxScore, HSR.strCollege, HSR.strDegree, HSR.strSpecialization";
    //        sQuery += " , Q.intCertificate, Q.sngGrade, A.lngStudentNumber";
    //        sQuery += " , Q.ScoreOfMath, Q.ScoreOfChemistry, Q.ScoreOfBiology,Q.ScoreOfPhysics";

    //        sQuery += " FROM dbo.Reg_Student_Qualifications AS Q INNER JOIN";
    //        sQuery += " dbo.Reg_Applications AS A ON Q.lngSerial = A.lngSerial INNER JOIN";
    //        sQuery += " dbo.HighSchool_AdmissionRequirments AS HSR ON A.strCollege = HSR.strCollege ";
    //        sQuery += " AND A.strDegree = HSR.strDegree AND A.strSpecialization = HSR.strSpecialization ";
    //        sQuery += " AND Q.intMajor = HSR.iHSMajor AND Q.sngGrade >= HSR.cHSMinScore ";
    //        sQuery += " AND Q.sngGrade < HSR.cHSMaxScore";
    //        sQuery += " WHERE A.lngStudentNumber ='" + StudentID + "'";
    //        sQuery += " AND Q.intCertificate = 1";


    //        int iHSMajor = 0;
    //        int iScoreofMath = 0;
    //        int iScoreofChem = 0;
    //        int iScoreofBiol = 0;
    //        int iScoreofPhys = 0;
    //        decimal dFoundationCourseMinScore = 0;

    //        string sMTH001_Requirment = "None";
    //        string sCHEM001_Requirment = "None";
    //        string sPHYS001_Requirment = "None";
    //        string sBIOL001_Requirment = "None";

    //        SqlCommand Cmd = new SqlCommand(sQuery, Conn);
    //        SqlDataReader Rd = Cmd.ExecuteReader();

    //        while (Rd.Read())
    //        {
    //            iHSMajor = int.Parse("0" + Rd["iHSMajor"].ToString());
    //            iScoreofMath = int.Parse("0" + Rd["ScoreOfMath"].ToString());
    //            iScoreofChem = int.Parse("0" + Rd["ScoreOfChemistry"].ToString());
    //            iScoreofBiol = int.Parse("0" + Rd["ScoreOfBiology"].ToString());
    //            iScoreofPhys = int.Parse("0" + Rd["ScoreOfPhysics"].ToString());

    //            sMTH001_Requirment = Rd["MTH001"].ToString();
    //            sCHEM001_Requirment = Rd["CHEM001"].ToString();
    //            sPHYS001_Requirment = Rd["PHYS001"].ToString();
    //            sBIOL001_Requirment = Rd["BIOL001"].ToString();

    //            dFoundationCourseMinScore = decimal.Parse("0" + Rd["cMinCRSScore"].ToString());
    //        }
    //        Rd.Close();
    //        string sFndCourse = "MTH001";
    //        IsMTH001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sMTH001_Requirment, iScoreofMath, dFoundationCourseMinScore);
    //        if (IsMTH001Required) { IsFulfilledRequirements = false; }
    //        //=====================================================
    //        sFndCourse = "CHEM001";
    //        IsCHEM001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sCHEM001_Requirment, iScoreofChem, dFoundationCourseMinScore);
    //        if (IsCHEM001Required) { IsFulfilledRequirements = false; }
    //        //=====================================================
    //        sFndCourse = "BIOL001";
    //        IsBIOL001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sBIOL001_Requirment, iScoreofBiol, dFoundationCourseMinScore);
    //        if (IsBIOL001Required) { IsFulfilledRequirements = false; }
    //        //=====================================================
    //        sFndCourse = "PHYS001";
    //        IsPHYS001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sPHYS001_Requirment, iScoreofPhys, dFoundationCourseMinScore);
    //        if (IsPHYS001Required) { IsFulfilledRequirements = false; }


    //    }
    //    catch (Exception ex)
    //    {

    //        LibraryMOD.ShowErrorMessage(ex);
    //        IsFulfilledRequirements = false;
    //    }
    //    finally
    //    {
    //        Conn.Close();
    //        Conn.Dispose();
    //    }
    //    return IsFulfilledRequirements;
    //}
    public static bool IsFulfilledAdmissionRequirements(InitializeModule.EnumCampus Campus, int iCurrentRegTerm, string StudentID, out bool IsMTH001Required, out bool IsCHEM001Required, out bool IsBIOL001Required, out bool IsPHYS001Required, out bool is_EmSAT_Arabic_Required, out bool is_EmSAT_Math_Required, out bool is_EmSAT_Physics_Required)
    {
        bool IsFulfilledRequirements = false;

        //IsMTH001Required = false;
        //IsCHEM001Required = false;
        //IsBIOL001Required = false;
        //IsPHYS001Required = false;

        IsMTH001Required = true;
        IsCHEM001Required = true;
        IsBIOL001Required = true;
        IsPHYS001Required = true;

        is_EmSAT_Arabic_Required = true;
        is_EmSAT_Math_Required = true;
        is_EmSAT_Physics_Required = true;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            //get the admission requirments ID depends on student admission year, semester
            //and if admission requirments is active
            int iAdmissionRequirmentsID = 0;

            int StudentAdmissionTerm = LibraryMOD.GetStudentTerm(Campus, StudentID);
            iAdmissionRequirmentsID = LibraryMOD.GetAdmissionRequirmentsID(StudentAdmissionTerm, Campus);
            if (iAdmissionRequirmentsID == 0)
            {
                iAdmissionRequirmentsID = LibraryMOD.GetCurrentAdmissionRequirmentsID(iCurrentRegTerm);
            }
            string sQuery = "";
            sQuery = "SELECT DISTINCT HSR.iAdmissionRequirmentsID, HSR.iRequirement";
            sQuery += " , HSR.iHSMajor, HSR.cMinCRSScore";
            sQuery += " , HSR.MTH001, HSR.CHEM001, HSR.PHYS001, HSR.BIOL001, HSR.HSScience";
            sQuery += " , HSR.sHSTrack, HSR.sDesc, HSR.isFNDReplacement, HSR.cHSMinScore";
            sQuery += " ,HSR.cHSMaxScore, HSR.strCollege, HSR.strDegree, HSR.strSpecialization";
            sQuery += " , Q.intCertificate, Q.sngGrade, A.lngStudentNumber";
            sQuery += " , Q.ScoreOfMath, Q.ScoreOfChemistry, Q.ScoreOfBiology,Q.ScoreOfPhysics";
            sQuery += " ,HSR.EmSAT_Arabic,HSR.EmSAT_Math,EmSAT_Physics";

            sQuery += " FROM dbo.Reg_Student_Qualifications AS Q INNER JOIN";
            sQuery += " dbo.Reg_Applications AS A ON Q.lngSerial = A.lngSerial INNER JOIN";
            sQuery += " dbo.HighSchool_AdmissionRequirments AS HSR ON A.strCollege = HSR.strCollege ";
            sQuery += " AND A.strDegree = HSR.strDegree AND A.strSpecialization = HSR.strSpecialization ";
            sQuery += " AND Q.intMajor = HSR.iHSMajor AND Q.sngGrade >= HSR.cHSMinScore ";
            sQuery += " AND Q.sngGrade < HSR.cHSMaxScore";
            sQuery += " WHERE A.lngStudentNumber ='" + StudentID + "'";
            sQuery += " AND Q.intCertificate = 1";
            sQuery += " AND HSR.iAdmissionRequirmentsID=" + iAdmissionRequirmentsID;



            int iHSMajor = 0;
            int iScoreofMath = 0;
            int iScoreofChem = 0;
            int iScoreofBiol = 0;
            int iScoreofPhys = 0;
            int iEmSAT_ArabicRequiredScore = 0;
            int iEmSAT_MathRequiredScore = 0;
            int iEmSAT_PhysicsRequiredScore = 0;

            decimal dFoundationCourseMinScore = 0;

            string sMTH001_Requirment = "None";
            string sCHEM001_Requirment = "None";
            string sPHYS001_Requirment = "None";
            string sBIOL001_Requirment = "None";

            SqlCommand Cmd = new SqlCommand(sQuery, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                iHSMajor = int.Parse("0" + Rd["iHSMajor"].ToString());
                iScoreofMath = int.Parse("0" + Rd["ScoreOfMath"].ToString());
                iScoreofChem = int.Parse("0" + Rd["ScoreOfChemistry"].ToString());
                iScoreofBiol = int.Parse("0" + Rd["ScoreOfBiology"].ToString());
                iScoreofPhys = int.Parse("0" + Rd["ScoreOfPhysics"].ToString());

                iEmSAT_ArabicRequiredScore = int.Parse("0" + Rd["EmSAT_Arabic"].ToString());
                iEmSAT_MathRequiredScore = int.Parse("0" + Rd["EmSAT_Math"].ToString());
                iEmSAT_PhysicsRequiredScore = int.Parse("0" + Rd["EmSAT_Physics"].ToString());

                sMTH001_Requirment = Rd["MTH001"].ToString();
                sCHEM001_Requirment = Rd["CHEM001"].ToString();
                sPHYS001_Requirment = Rd["PHYS001"].ToString();
                sBIOL001_Requirment = Rd["BIOL001"].ToString();

                dFoundationCourseMinScore = decimal.Parse("0" + Rd["cMinCRSScore"].ToString());
            }
            Rd.Close();
            string sFndCourse = "MTH001";
            IsMTH001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sMTH001_Requirment, iScoreofMath, dFoundationCourseMinScore);
            if (IsMTH001Required) { IsFulfilledRequirements = false; }
            //=====================================================
            sFndCourse = "CHEM001";
            IsCHEM001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sCHEM001_Requirment, iScoreofChem, dFoundationCourseMinScore);
            if (IsCHEM001Required) { IsFulfilledRequirements = false; }
            //=====================================================
            sFndCourse = "BIOL001";
            IsBIOL001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sBIOL001_Requirment, iScoreofBiol, dFoundationCourseMinScore);
            if (IsBIOL001Required) { IsFulfilledRequirements = false; }
            //=====================================================
            sFndCourse = "PHYS001";
            IsPHYS001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sPHYS001_Requirment, iScoreofPhys, dFoundationCourseMinScore);
            if (IsPHYS001Required) { IsFulfilledRequirements = false; }
            int iSerialNumber = LibraryMOD.GetStudentSerialNo(StudentID, Convert.ToInt32(Campus));
            if (iEmSAT_ArabicRequiredScore > 0)
            {
                is_EmSAT_Arabic_Required = isEmSAT_ArabicPassed(Campus, iSerialNumber);
            }
            if (is_EmSAT_Arabic_Required) { IsFulfilledRequirements = false; }
            if (iEmSAT_MathRequiredScore > 0)
            {
                is_EmSAT_Math_Required = isEmSAT_MathPassed(Campus, iSerialNumber);
            }
            if (is_EmSAT_Math_Required) { IsFulfilledRequirements = false; }


            if (iEmSAT_PhysicsRequiredScore > 0)
            {
                is_EmSAT_Physics_Required = isEmSAT_PhysicsPassed(Campus, iSerialNumber);
            }
            if (is_EmSAT_Physics_Required) { IsFulfilledRequirements = false; }
        }
        catch (Exception ex)
        {

            LibraryMOD.ShowErrorMessage(ex);
            IsFulfilledRequirements = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return IsFulfilledRequirements;
    }
    public static bool isEmSAT_ArabicPassed(InitializeModule.EnumCampus Campus, int iSerial)
    {
        bool isPassed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT(CASE WHEN SQ.sngGrade >= C.curPassed THEN 'True' ELSE 'False' END) AS isPass_EmSAT ";
            sSQL += " FROM Reg_Student_Qualifications AS SQ INNER JOIN ";
            sSQL += " Lkp_Certificates AS C ON SQ.intCertificate = C.intCertificate";
            sSQL += " Where SQ.lngSerial=" + iSerial;
            sSQL += " AND SQ.intCertificate = 26";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                isPassed = Convert.ToBoolean(Rd["isPass_EmSAT"].ToString());
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isPassed = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isPassed;

    }

    public static bool isEmSAT_MathPassed(InitializeModule.EnumCampus Campus, int iSerial)
    {
        bool isPassed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT(CASE WHEN SQ.sngGrade >= C.curPassed THEN 'True' ELSE 'False' END) AS isPass_EmSAT ";
            sSQL += " FROM Reg_Student_Qualifications AS SQ INNER JOIN ";
            sSQL += " Lkp_Certificates AS C ON SQ.intCertificate = C.intCertificate";
            sSQL += " Where SQ.lngSerial=" + iSerial;
            sSQL += " AND SQ.intCertificate = 27";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                isPassed = Convert.ToBoolean(Rd["isPass_EmSAT"].ToString());
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isPassed = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isPassed;

    }


    public static bool isEmSAT_PhysicsPassed(InitializeModule.EnumCampus Campus, int iSerial)
    {
        bool isPassed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT(CASE WHEN SQ.sngGrade >= C.curPassed THEN 'True' ELSE 'False' END) AS isPass_EmSAT ";
            sSQL += " FROM Reg_Student_Qualifications AS SQ INNER JOIN ";
            sSQL += " Lkp_Certificates AS C ON SQ.intCertificate = C.intCertificate";
            sSQL += " Where SQ.lngSerial=" + iSerial;
            sSQL += " AND SQ.intCertificate = 28";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                isPassed = Convert.ToBoolean(Rd["isPass_EmSAT"].ToString());
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isPassed = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isPassed;

    }
    public static bool IsFndCourseRequired(InitializeModule.EnumCampus Campus, string StudentID, string sFndCourse, string sRequirment, int iScoreofFndCourse, decimal dFoundationCourseMinScore)
    {
        bool isRequired = false;
        try
        {
        switch (sRequirment)
        {
            case "HS":
                if (iScoreofFndCourse < dFoundationCourseMinScore)
                {
                    isRequired = true;
                }
                break;
            case "Remedial":
                if (!isFndCoursePassed(Campus, StudentID, sFndCourse))
                {
                    isRequired = true;
                }
                break;
            case "HS and Remedial":

                if (iScoreofFndCourse < dFoundationCourseMinScore || !isFndCoursePassed(Campus, StudentID, sFndCourse))
                {
                    isRequired = true;
                }

                break;
            case "HS or Remedial":
                if (iScoreofFndCourse < dFoundationCourseMinScore && !isFndCoursePassed(Campus, StudentID, sFndCourse))
                {
                    isRequired = true;
                }
                break;
            case "Graduation":
                //allow to change major from ESL to academic program, can register remedial + major courses
                isRequired = false;
                break;
            case "None":
                isRequired = false;
                break;
        }
        }
        catch (Exception ex)
        {

            LibraryMOD.ShowErrorMessage(ex);
            isRequired = true;
        }
        finally
        {
            
        }
        return isRequired;
    }

    public static bool isFndCoursePassed(InitializeModule.EnumCampus Campus, string StudentID, string sFndCourse)
    {
        bool isPassed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT Reg_Grade_System.bPassIt";
            sSQL += " FROM Reg_Grade_System INNER JOIN";
            sSQL += " Reg_Grade_Header ON Reg_Grade_System.strGrade = Reg_Grade_Header.strGrade";
            sSQL += " WHERE Reg_Grade_Header.lngStudentNumber = '" + StudentID + "'";
            sSQL += " AND dbo.Reg_Grade_Header.strCourse = '" + sFndCourse + "'";
            sSQL += " AND Reg_Grade_System.bPassIt = 1";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                isPassed = true;
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isPassed = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isPassed;

    }
}