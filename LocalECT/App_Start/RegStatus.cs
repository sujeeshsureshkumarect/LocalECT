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
using System.Data.SqlClient;

/// <summary>
/// Summary description for RegStatus
/// </summary>
public class RegStatus
{
    #region "Private Member Variables"
    private string _Serial;
    private string _Period;
    private int _Count;
    #endregion

    #region "Constructors"
    public RegStatus()
    {
    }
    public RegStatus(string Serial, string Period, byte Count)
    {
        this._Serial = Serial;
        this._Period = Period;
        this._Count = Count;
    }

    #endregion

    #region "Public Properties"

    public string Serial
    {
        get { return _Serial; }
        set { _Serial = value; }
    }

    public string Period
    {
        get { return _Period; }
        set { _Period = value; }
    }

    public int Count
    {
        get { return _Count; }
        set { _Count = value; }
    }


    #endregion 
}

public class RegStatusDAL 
{
    public List<RegStatus> GetRegStatus(InitializeModule.EnumCampus Campus,int iCampus, InitializeModule.Grds RegStatus, int iFilter, int iYear, byte bSem, string sDegree, string sHours,int iLTR , bool bNew) 
    { 
        
        
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        int iY = 0; 
        int iSem = 0; 
        
        
        iY = iFilter / 10; 
        iSem = iFilter - (iY * 10); 
        string sql = null; 
        sql = "SELECT SH.strShortcut AS Period, COUNT(A.lngStudentNumber) AS Counts";
        sql += " FROM Reg_Shifts AS SH INNER JOIN Reg_Students_Data AS SD ";
        sql += " ON SH.byteShift = SD.byteShift INNER JOIN"; 
        sql += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial ";
        sql += " INNER JOIN dbo.Reg_Specializations AS S ON A.strCollege = S.strCollege ";
        sql += " AND A.strDegree = S.strDegree AND A.strSpecialization = S.strSpecialization";

        if (sHours == "Is Null")
        {
            sql += " LEFT OUTER JOIN dbo.Last_Time_Registered";
            sql += " ON A.lngStudentNumber = dbo.Last_Time_Registered.Student";
        }
        //update query to include students open another file at same semester to counted as new (ex:convert to BA or open esl then pass and open BA file)
        sql += " LEFT OUTER JOIN";
        sql += " dbo.Reg_Applications AS A1 ON A.sReference = A1.lngStudentNumber";

        sql += " LEFT OUTER JOIN"; 
        sql += " dbo.Reg_Function(" + iY + "," + iSem + " ) AS REG ON A.lngStudentNumber = REG.sSno COLLATE Arabic_CI_AS"; 
       
        switch (Campus) { 
            case InitializeModule.EnumCampus.Males : 
                sql += " WHERE (SD.byteShift = 3 OR SD.byteShift = 4 OR SD.byteShift = 8)"; 
                break; 
            case InitializeModule.EnumCampus.Females: 
                sql += " WHERE (SD.byteShift = 1 OR SD.byteShift = 2 OR SD.byteShift = 9)"; 
                break; 
        }
        if (iCampus != 0)
        {
            //sql += " And S.iCampus =" + iCampus;
            sql += " And S.iMajorClassification=" + iCampus;
        } 

        if (bNew) { 
            if (iYear != 0) {
                sql += " And A.intStudyYear*10 +  A.byteSemester =" + iFilter; 
            } 
            
            //if (bSem != 0) { 
            //    sql += " And A.byteSemester =" + bSem; 
            //}
            switch (RegStatus)
            {
                case InitializeModule.Grds.BaExtendedFReg:
                case InitializeModule.Grds.BaExtendedMReg:
                case InitializeModule.Grds.BaExtendedFNReg:
                case InitializeModule.Grds.BaExtendedMNReg:
                case InitializeModule.Grds.BaMediaExtendedFReg:
                case InitializeModule.Grds.BaMediaExtendedMReg:
                case InitializeModule.Grds.BaMediaExtendedFNReg:
                case InitializeModule.Grds.BaMediaExtendedMNReg:
                    sql += " AND (A.sReference Is Not NULL)";
                    sql += " AND (A1.strDegree = N'1' OR A1.strDegree = N'3')"; // extended from diploma to BA 
                    //add extended from BA to BA ( OR A1.strDegree = N'3') //added: 26-12-2016
                    sql += " AND (A1.byteCancelReason = 3 OR A1.byteCancelReason = 25)";

                    //added in 24-11-2015 to exclude students open two files at the same semester
                    sql += " AND (A1.intStudyYear * 10 + A1.byteSemester <> A.intStudyYear * 10 + A.byteSemester)";
                    break;
                case InitializeModule.Grds.DiplomaExtendedMReg:
                case InitializeModule.Grds.DiplomaExtendedMnReg:
                case InitializeModule.Grds.DiplomaExtendedFReg:
                case InitializeModule.Grds.DiplomaExtendedFnReg:
                case InitializeModule.Grds.DiplomaMediaExtendedMReg:
                case InitializeModule.Grds.DiplomaMediaExtendedMNReg:
                case InitializeModule.Grds.DiplomaMediaExtendedFReg:
                case InitializeModule.Grds.DiplomaMediaExtendedFnReg:
                    sql += " AND (A.sReference Is Not NULL)";
                    sql += " AND (A1.strDegree = N'1' OR A1.strDegree = N'3')"; // diploma readmitted & BA readmitted
                    sql += " AND (A1.byteCancelReason <> 3 AND A1.byteCancelReason <> 25)";
                    //added in 24-11-2015 to exclude students open two files at the same semester
                    sql += " AND (A1.intStudyYear * 10 + A1.byteSemester <> A.intStudyYear * 10 + A.byteSemester)";
                    break;
                case InitializeModule.Grds.ESLExtendedMReg:
                case InitializeModule.Grds.ESLExtendedMnReg:
                case InitializeModule.Grds.ESLExtendedFReg:
                case InitializeModule.Grds.ESLExtendedFNReg:
                case InitializeModule.Grds.ESLMediaExtendedMReg:
                case InitializeModule.Grds.ESLMediaExtendedMNReg:
                case InitializeModule.Grds.ESLMediaExtendedFReg:
                case InitializeModule.Grds.ESLMediaExtendedFNReg:
                    sql += " AND (A.sReference Is Not NULL)";
                    sql += " AND (A1.strDegree = N'2')"; // extended from ESL to {Diploma} or {BA}
                    //added in 24-11-2015 to exclude students open two files at the same semester
                    sql += " AND (A1.intStudyYear * 10 + A1.byteSemester <> A.intStudyYear * 10 + A.byteSemester)";
                    break;

                case InitializeModule.Grds.BaNewFReg:
                case InitializeModule.Grds.BaNewMReg:
                case InitializeModule.Grds.BaNewFNReg:
                case InitializeModule.Grds.BaNewMNReg:
                case InitializeModule.Grds.NewFReg:
                case InitializeModule.Grds.NewMReg:
                case InitializeModule.Grds.NewFNReg:
                case InitializeModule.Grds.NewMNReg:
                case InitializeModule.Grds.EslNFReg:
                case InitializeModule.Grds.EslNMReg:
                case InitializeModule.Grds.EslNFNReg:
                case InitializeModule.Grds.EslNMNReg:
                case InitializeModule.Grds.FndNFReg:
                case InitializeModule.Grds.FndNMReg:
                case InitializeModule.Grds.FndNFNReg:
                case InitializeModule.Grds.FndNMNReg:

                case InitializeModule.Grds.BaMediaNewFReg:
                case InitializeModule.Grds.BaMediaNewMReg:
                case InitializeModule.Grds.BaMediaNewFNReg:
                case InitializeModule.Grds.BaMediaNewMNReg:
                case InitializeModule.Grds.NewMediaFReg:
                case InitializeModule.Grds.NewMediaMReg:
                case InitializeModule.Grds.NewMediaFNReg:
                case InitializeModule.Grds.NewMediaMNReg:
                    //sql += " AND (A.sReference Is NULL)";
                    sql += " AND (A1.intStudyYear * 10 + A1.byteSemester = A.intStudyYear * 10 + A.byteSemester";
                    sql += " OR A1.intStudyYear * 10 + A1.byteSemester IS NULL)";
                      
                    break;
            } 
        
        } 
        else { 
            //sql += "AND ( (A.intStudyYear =" + iYear + " AND A.byteSemester<" + bSem + ")"; 
            //sql += " OR(A.intStudyYear <" + iYear + "))"; 
            sql += "AND ( A.intStudyYear*10 + A.byteSemester <>" + iFilter + ")"; 
        }


        switch (RegStatus)
        {
            case InitializeModule.Grds.EslNFReg:
            case InitializeModule.Grds.EslOFReg:
            case InitializeModule.Grds.EslNFNReg:
            case InitializeModule.Grds.EslOFNReg:
            case InitializeModule.Grds.EslNMReg:
            case InitializeModule.Grds.EslOMReg:
            case InitializeModule.Grds.EslNMNReg:
            case InitializeModule.Grds.EslOMNReg:
            case InitializeModule.Grds.EslMediaNFReg:
            case InitializeModule.Grds.EslMediaOFReg:
            case InitializeModule.Grds.EslMediaNFNReg:
            case InitializeModule.Grds.EslMediaOFNReg:
            case InitializeModule.Grds.EslMediaNMReg:
            case InitializeModule.Grds.EslMediaOMReg:
            case InitializeModule.Grds.EslMediaNMNReg:
            case InitializeModule.Grds.EslMediaOMNReg:

                sql += " And A.strSpecialization <>'2' And A.strSpecialization <>'3' And A.strSpecialization <>'4'";
                break;
            case InitializeModule.Grds.VisitingMediaNFReg:
            case InitializeModule.Grds.VisitingMediaNMReg:
            case InitializeModule.Grds.VisitingNewFReg:
            case InitializeModule.Grds.VisitingNewMReg:
                sql += " And (A.strSpecialization ='999')";

                break;
            case InitializeModule.Grds.VisitingOldFReg:
            case InitializeModule.Grds.VisitingOldMReg:
            case InitializeModule.Grds.VisitingMediaOldFReg:
            case InitializeModule.Grds.VisitingMediaOldMReg:
                sql += " And (A.strSpecialization ='999')";
                break;
            case InitializeModule.Grds.FndNFReg:
            case InitializeModule.Grds.FndOFReg:
            case InitializeModule.Grds.FndNFNReg:
            case InitializeModule.Grds.FndOFNReg:
            case InitializeModule.Grds.FndNMReg:
            case InitializeModule.Grds.FndOMReg:
            case InitializeModule.Grds.FndNMNReg:
            case InitializeModule.Grds.FndOMNReg:
            case InitializeModule.Grds.FndMediaNFReg:
            case InitializeModule.Grds.FndMediaOFReg:
            case InitializeModule.Grds.FndMediaNFNReg:
            case InitializeModule.Grds.FndMediaOFNReg:
            case InitializeModule.Grds.FndMediaNMReg:
            case InitializeModule.Grds.FndMediaOMReg:
            case InitializeModule.Grds.FndMediaNMNReg:
            case InitializeModule.Grds.FndMediaOMNReg:

                sql += " And (A.strSpecialization ='2')";
                break;
        }

        if (!string.IsNullOrEmpty(sDegree)) {
            sql += " And (A.strDegree ='" + sDegree + "')";
        } 
        
        if (!string.IsNullOrEmpty(sHours)) { 
            sql += " And REG.cCount " + sHours; 
        }
        if (sHours == "Is Null")
        {
            if (iLTR > 0)
            {
                sql += " AND (dbo.Last_Time_Registered.MaxYear >=" + iLTR + " OR dbo.Last_Time_Registered.MaxYear Is NULL)";
            }
        }
         
        if (sHours == "Is Null") { 
           // sql += " And A.byteCancelReason " + sHours;
            //updated 23/10/2019 b/c statuses updated to postponed and discontinued before saving the history
            //unregister either reason null or postponed and year is null or = registration year
            sql += " AND (A.byteCancelReason IS NULL OR A.byteCancelReason = 11)";
            sql += " AND (A.intGraduationYear IS NULL OR A.intGraduationYear =" +  iY + ") ";
            sql += " AND (A.byteGraduationSemester IS NULL OR A.byteGraduationSemester = " + iSem + ")";
            sql += " AND (A.byteStudentType != 1)";
            //sql += " AND (A.byteStudentType=0 OR A.byteStudentType =3 OR A.byteStudentType IS NULL)"; 
        }
       

        sql += " GROUP BY SH.strShortcut"; 
        sql += " ORDER BY SH.strShortcut"; 
        
        
        SqlConnection myConnection = new SqlConnection(MyConnection_string.Conn_string); 
        
        SqlCommand myCommand = new SqlCommand(sql, myConnection);
        myCommand.CommandTimeout = 900;
        myConnection.Open(); 

        SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection); 
        List<RegStatus> results = new List<RegStatus>(); 
        int i = 1; 
        int iSum = 0; 
        try { 
            
            while (reader.Read()) { 
                RegStatus myRegStatus = new RegStatus(); 
                myRegStatus.Serial = i.ToString(); 
                myRegStatus.Period = reader["Period"].ToString(); 
                if (reader["Counts"].Equals(DBNull.Value)) { 
                    myRegStatus.Count = 0; 
                } 
                else { 
                    myRegStatus.Count = Convert.ToInt32(reader["Counts"]); 
                } 
                iSum += myRegStatus.Count; 
                results.Add(myRegStatus); 
                i += 1; 
            } 
            RegStatus iRegStatus = new RegStatus(); 
            iRegStatus.Serial = "Total"; 
            switch (Campus) { 
                case InitializeModule.EnumCampus.Males : 
                    iRegStatus.Period = "Males"; 
                    break; 
                case InitializeModule.EnumCampus.Females: 
                    iRegStatus.Period = "Females"; 
                    break; 
            } 
            
            iRegStatus.Count = iSum; 
                
            results.Add(iRegStatus); 
        } 
        catch (Exception ex) {
            LibraryMOD.ShowErrorMessage(ex);
        } 
        finally { 
            
            reader.Close(); 
            reader = null; 
            myConnection.Close(); 
            myConnection = null; 
        } 
        return results; 
    }

    public DataSet GetRegStatusFromHistory(InitializeModule.EnumCampus Campus, int iCampus, int iFilter) 
    {

        DataSet dsResult = new DataSet();
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
       
        SqlConnection myConnection = new SqlConnection(MyConnection_string.Conn_string); 

        string sql = null; 
        
        try
        { 
        sql = "SELECT Reg_Shifts.strShortcut AS Period";
        sql += " , ECT_Reg_History.RegOld_Diploma As RegOld_Diploma";
        sql += " , ECT_Reg_History.RegOld_BA As RegOld_BA";
        sql += " , ECT_Reg_History.RegNew_Diploma As RegNew_Diploma";
        sql += " , ECT_Reg_History.RegNew_BA As RegNew_BA";
        sql += " , ECT_Reg_History.RegExtended_Diploma As RegExtended_Diploma";
        sql += " , ECT_Reg_History.RegExtended_BA As RegExtended_BA";
        sql += " , ECT_Reg_History.RegExtended_ESL As RegExtended_ESL";
        sql += " , ECT_Reg_History.RegOld_ESL As RegOld_ESL";
        sql += " , ECT_Reg_History.RegNew_ESL As RegNew_ESL";
        sql += " , ECT_Reg_History.RegOld_Foundation As RegOld_Foundation";
        sql += " , ECT_Reg_History.RegNew_Foundation As RegNew_Foundation";
        sql += " , ECT_Reg_History.UnRegOld_Diploma As UnRegOld_Diploma";
        sql += " , ECT_Reg_History.UnRegOld_BA As UnRegOld_BA";
        sql += " , ECT_Reg_History.UnRegNew_Diploma As UnRegNew_Diploma";
        sql += " , ECT_Reg_History.UnRegNew_BA As UnRegNew_BA";
        sql += " , ECT_Reg_History.UnRegExtended_Diploma As UnRegExtended_Diploma";
        sql += " , ECT_Reg_History.UnRegExtended_BA As UnRegExtended_BA";
        sql += " , ECT_Reg_History.UnRegExtended_ESL As UnRegExtended_ESL";
        sql += " , ECT_Reg_History.UnRegOld_ESL As UnRegOld_ESL";
        sql += " , ECT_Reg_History.UnRegNew_ESL As UnRegNew_ESL";
        sql += " , ECT_Reg_History.UnRegOld_Foundation As UnRegOld_Foundation";
        sql += " , ECT_Reg_History.UnRegNew_Foundation As UnRegNew_Foundation";
        sql += " , ECT_Reg_History.RegOld_Visiting";
        sql += " , ECT_Reg_History.RegNew_Visiting";	
        sql += " , ECT_Reg_History.AllGraduatedDiploma";
        sql += " , ECT_Reg_History.AllExtendedtoBA";
        sql += " , ECT_Reg_History.OldDiplomaRetention_LastYear";
        sql += " , ECT_Reg_History.OldDiplomaRetention_LastSem";
        sql += " , ECT_Reg_History.OldBARetention_LastYear";
        sql += " , ECT_Reg_History.OldBARetention_LastSem";
        sql += " , ECT_Reg_History.AllOldRetention_LastYear";
        sql += " , ECT_Reg_History.AllOldRetention_LastSem";
        sql += " , ECT_Reg_History.AllOldUnregister_LastYear";
        sql += " , ECT_Reg_History.AllOldUnregister_LastSem";
        sql += " , ECT_Reg_History.AllPostponed";
        sql += " , ECT_Reg_History.AllPostponed_LastYear";
        sql += " , ECT_Reg_History.AllPostponed_LastSem";
        sql += " , ECT_Reg_History.AllDiplomaGraduated_Last2Years";
        sql += " , ECT_Reg_History.AllDiplomaGraduated_LastYear";
        sql += " , ECT_Reg_History.AllDiplomaGraduated_LastSem";
        sql += " , ECT_Reg_History.AllPotentialNotExtendedBA_Last2Years";
        sql += " , ECT_Reg_History.AllPotentialNotExtendedBA_LastYear";
        sql += " , ECT_Reg_History.AllPotentialNotExtendedBA_LastSem";
        sql += " FROM ECT_Reg_History INNER JOIN";
        sql += " Reg_Shifts ON ECT_Reg_History.Session = Reg_Shifts.byteShift";
     
        switch (Campus) { 
            case InitializeModule.EnumCampus.Males :
                sql += " WHERE (ECT_Reg_History.Session = 3 OR ECT_Reg_History.Session = 4 OR ECT_Reg_History.Session = 8)"; 
                break; 
            case InitializeModule.EnumCampus.Females:
                sql += " WHERE (ECT_Reg_History.Session = 1 OR ECT_Reg_History.Session = 2 OR ECT_Reg_History.Session = 9)"; 
                break; 
        }
        if (iCampus != 0)
        {
            sql += " And ECT_Reg_History.CampusID =" + iCampus;
        }

        if (iFilter != 0)
        {
            sql += " And ECT_Reg_History.Term =" + iFilter;
        }
       // sql += " GROUP BY dbo.Reg_Shifts.strShortcut";

        myConnection.Open(); 
      
        SqlDataAdapter da= new SqlDataAdapter(sql, myConnection);
        da.Fill(dsResult, "result");

        } 
        catch (Exception ex) {
            LibraryMOD.ShowErrorMessage(ex);
        } 
        finally 
        { 
            myConnection.Close(); 
            myConnection = null; 
        } 
        return dsResult; 
    } 

    public int GetRegCount(InitializeModule.EnumCampus Campus, int iFilter,int iYear,byte bSem, string sDegree, string sHours, bool bNew) 
    { 
        
        
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

        int iY = 0; 
        int iSem = 0; 
       
        int iCount = 0; 
        
        
        
        iY = iFilter / 10; 
        iSem = iFilter - (iY * 10); 
        string sql = null; 
        sql = "SELECT COUNT(A.lngStudentNumber) AS Counts"; 
        sql += " FROM Reg_Shifts AS SH INNER JOIN Reg_Students_Data AS SD ON SH.byteShift = SD.byteShift INNER JOIN"; 
        sql += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial LEFT OUTER JOIN"; 
        sql += " dbo.Reg_Function(" + iY + "," + iSem + " ) AS REG ON A.lngStudentNumber = REG.sSno COLLATE Arabic_CI_AS"; 
        switch (Campus) { 
            case InitializeModule.EnumCampus.Males: 
                sql += " WHERE (SD.byteShift = 3 OR SD.byteShift = 4 OR SD.byteShift = 8)"; 
                break; 
            case InitializeModule.EnumCampus.Females: 
                sql += " WHERE (SD.byteShift = 1 OR SD.byteShift = 2 OR SD.byteShift = 9)"; 
                break; 
        } 
        
        if (bNew) { 
            if (iYear != 0) { 
                sql += " And A.intStudyYear =" + iYear; 
            } 
            
            if (bSem != 0) { 
                sql += " And A.byteSemester =" + bSem; 
            } 

        } 
        else { 
            sql += "AND ( (A.intStudyYear =" + iYear + " AND A.byteSemester<" + bSem + ")"; 
            sql += " OR(A.intStudyYear <" + iYear + "))"; 
        } 
        
        if (!string.IsNullOrEmpty(sDegree)) { 
            sql += " And A.strDegree ='" + sDegree + "'"; 
        } 
        
        if (!string.IsNullOrEmpty(sHours)) { 
            sql += " And REG.cCount " + sHours; 
        } 
        
        
        if (sHours == "Is Null") { 
            //sql += " And A.byteCancelReason " + sHours;
            //updated 23/10/2019 b/c statuses updated to postponed and discontinued before saving the history
            //unregister either reason null or postponed and year is null or = registration year
            sql += " AND (A.byteCancelReason IS NULL OR A.byteCancelReason = 11)";
            sql += " AND (A.intGraduationYear IS NULL OR A.intGraduationYear =" + iY + ") ";
            sql += " AND (A.byteGraduationSemester IS NULL OR A.byteGraduationSemester = " + iSem + ")";
            
            sql += " AND (A.byteStudentType != 1)";
            //sql += " AND (A.byteStudentType=0 OR A.byteStudentType=3 OR A.byteStudentType IS NULL)"; 
        } 
        
        
        SqlConnection myConnection = new SqlConnection(MyConnection_string.Conn_string); 
        
        SqlCommand myCommand = new SqlCommand(sql, myConnection);
        myCommand.CommandTimeout = 600;
        myConnection.Open(); 
        
        iCount = (int)myCommand.ExecuteScalar(); 
        
        
        return iCount; 
    }
    public int GetRegCountAllYears(InitializeModule.EnumCampus Campus, int iYearSem, int iYear, byte bSem, string sDegree, string sCancelReason, bool IsExtended)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

        int iY = 0;
        int iSem = 0;
        int iCount = 0;

        iY = iYearSem / 10;
        iSem = iYearSem - (iY * 10);
        string sql = null;

        sql = "SELECT COUNT(A.lngStudentNumber) AS Counts";
        sql += " FROM Reg_Shifts AS SH INNER JOIN Reg_Students_Data AS SD";
        sql += " ON SH.byteShift = SD.byteShift ";
        sql += " INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial";
        sql += " LEFT OUTER JOIN dbo.Reg_Applications AS A_Ref ";
        if (IsExtended)
        {
            sql += " ON A.sReference = A_Ref.lngStudentNumber";
        }
        else 
        {
            sql += " ON A.lngStudentNumber = A_Ref.sReference";
        }
        //sql += "  LEFT OUTER JOIN dbo.Reg_Function(" + iY + "," + iSem + " ) AS REG ON A.lngStudentNumber = REG.sSno COLLATE Arabic_CI_AS";
           
        switch (Campus)
        {
            case InitializeModule.EnumCampus.Males:
                sql += " WHERE (SD.byteShift = 3 OR SD.byteShift = 4 OR SD.byteShift = 8)";
                //sql += " AND (SD.bSex=1)";
                break;
            case InitializeModule.EnumCampus.Females:
                sql += " WHERE (SD.byteShift = 1 OR SD.byteShift = 2 OR SD.byteShift = 9)";
               // sql += " AND (SD.bSex=0)";
                break;
        }
       
        if (IsExtended)
        {
            sql += " AND (A.sReference Is Not NULL)";
            sql += " AND (A_Ref.byteCancelReason = 3 OR A_Ref.byteCancelReason = 25)";
            //sql += " AND (A.strSpecialization <> '10')";
        }
        else
        {
            sql += " AND (A_Ref.sReference IS NULL) ";
            sql += " AND (A.IsCompleteBAFromOtherInstitution = 0)";
            sql += " AND (A.IsCompleteMasterFromOtherInstitution = 0)";
            sql += " AND (A.byteCancelReason = 3 OR A.byteCancelReason = 25)";
            sql += " AND (A.intGraduationYear * 10 + A.byteGraduationSemester >= " + iYearSem + ")";
            sql += " AND (A.strSpecialization <> N'10') AND (A.bDontCall = 0)";

           // sql += " AND (A.sReference Is NULL)";
        }
       
        if (!string.IsNullOrEmpty(sDegree))
        {
            sql += " And A.strDegree ='" + sDegree + "'";
        }

        if (sCancelReason == "Is Null")
        {
            sql += " And A.byteCancelReason " + sCancelReason;
            sql += " AND (A.byteStudentType=0 OR A.byteStudentType=3 OR A.byteStudentType IS NULL)";
        }

        SqlConnection myConnection = new SqlConnection(MyConnection_string.Conn_string);

        SqlCommand myCommand = new SqlCommand(sql, myConnection);
        myCommand.CommandTimeout = 600;
        myConnection.Open();

        iCount = (int)myCommand.ExecuteScalar();


        return iCount;
    }
    public int GetCompleted_BA_Master_FromOtherInstitutions(InitializeModule.EnumCampus Campus, bool IsCompleteBA, bool IsCompleteMaster)
    {


        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

        int iCount = 0;
        string sql = null;
        sql = "SELECT COUNT(A.lngStudentNumber) AS Counts";
        sql += " FROM Reg_Students_Data AS SD INNER JOIN";
        sql += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial";
       
        switch (Campus)
        {
            case InitializeModule.EnumCampus.Males:
                sql += " WHERE (SD.bSex=1)";
                break;
            case InitializeModule.EnumCampus.Females:
                sql += " WHERE (SD.bSex=0)";
                break;
        }
      
        if (IsCompleteBA)
        {
            sql += " AND (A.IsCompleteBAFromOtherInstitution =1)";
        }
       
        if (IsCompleteMaster)
        {
            sql += " AND (A.IsCompleteMasterFromOtherInstitution =1)";
        }
       
        SqlConnection myConnection = new SqlConnection(MyConnection_string.Conn_string);

        SqlCommand myCommand = new SqlCommand(sql, myConnection);
        myCommand.CommandTimeout = 600;
        myConnection.Open();

        iCount = (int)myCommand.ExecuteScalar();

        return iCount;
    } 

} 

public class Status_Counts 
{
    public int GetStatusCount(InitializeModule.EnumCampus Campus, byte bStatus, int iYear, int bSemester, bool bNew, int iStatusYear, byte bStatusSem, string sDegree, int iLTR) 
    { 
        int iCount = 0; 
        string sSQL = ""; 
        int iPrevYear = 0; 
        int bPrevSemester = 0; 
        
        try { 
            
            iCount = 0;

            Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
//            SELECT Count(Reg_Applications.lngStudentNumber) AS iCount
//FROM Reg_Applications INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial
//WHERE (((Reg_Applications.byteCancelReason)=3 Or (Reg_Applications.byteCancelReason)=25) 
            //AND ((Reg_Applications.strDegree)='1') AND ((Reg_Students_Data.bSex)=True));

            if (bNew) {

                sSQL = "SELECT COUNT(Reg_Applications.lngStudentNumber) AS iCount";
                sSQL += " FROM dbo.Reg_Applications ";
                sSQL += " INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial";

                sSQL += " Where (byteCancelReason =" + bStatus + ")"; 
                
                if (iYear != 0) sSQL += " AND (intStudyYear = " + iYear + ") AND (byteSemester = " + bSemester + ")";
                if (iLTR > 0)
                {
                    sSQL += " AND (intGraduationYear*10 + byteGraduationSemester >=" + iLTR + ")";
                }
    
                if (iStatusYear != 0) sSQL += " AND (intGraduationYear = " + iStatusYear + ") AND (byteGraduationSemester = " + bStatusSem + ")";
                if (sDegree != "") sSQL += " AND (Reg_Applications.strDegree = '" + sDegree + "')";
               
                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        sSQL += " AND (Reg_Students_Data.bSex=1)";

                        break;
                    case InitializeModule.EnumCampus.Females:
                        sSQL += " AND (Reg_Students_Data.bSex=0)";
                        break;
                }
            } 
            else { 
                sSQL = "SELECT COUNT(REG.lngStudentNo) AS iCount"; 
                sSQL += " FROM dbo.Registration_Hours REG INNER JOIN dbo.Reg_Applications A ON REG.lngStudentNo = A.lngStudentNumber"; 
                if (bSemester == 1) { 
                    bPrevSemester = 3; 
                    iPrevYear = iYear - 1; 
                } 
                else { 
                    bPrevSemester = bSemester - 1; 
                    iPrevYear = iYear; 
                } 
                
                    
                sSQL += " Where (A.byteCancelReason =" + bStatus + ") AND (REG.intStudyYear = " + iPrevYear + ") AND (REG.byteSemester >= " + bPrevSemester + ")"; 
            }

            SqlConnection myConnection = new SqlConnection(MyConnection_string.Conn_string); 
            
            SqlCommand myCommand = new SqlCommand(sSQL, myConnection); 
            myConnection.Open(); 
            
            iCount = (int)myCommand.ExecuteScalar(); 
            
            myConnection.Close(); 
            
            
        } 
        catch (Exception ex) {
            LibraryMOD.ShowErrorMessage(ex);
        } 
        finally { 
            
            
        }
        return iCount; 
    } 
} 

