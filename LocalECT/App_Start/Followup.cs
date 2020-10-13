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
using System.Data.SqlClient;
using System.Collections.Generic;

public class Followup
{
    
    #region "Private Member Variables"
    private int _Serial;
    private string _Major;
    private string _Period;
    private string _No;
    private string _Name;
    private decimal _HS;
    private decimal _CGPA;
    private string _ENG;
    private decimal _SCORE;
    private string _Phone1;
    private string _Phone2;
    private string _Status;
    private string _sYear;
    private string _sSemester;
    private string _isFollowed;
    private string _LTR;
    private string _RMD;
    private string _Campus;

   

    #endregion

    #region "Constructors"
    public Followup()
    {
    }
    public Followup(int Serial, string Major, string Period, string No, string Name, decimal HS, decimal CGPA, string ENG, decimal SCORE, string Phone1,
    string Phone2, string Status, string sYear, string sSemester, string isFollowed,string LTR,string RMD,string Campus)
    {
        this._Serial = Serial;
        this._Major = Major;
        this._Period = Period;
        this._No = No;
        this._Name = Name;
        this._HS = HS;
        this._CGPA = CGPA;
        this._ENG = ENG;
        this._SCORE = SCORE;
        this._Phone1 = Phone1;
        this._Phone2 = Phone2;
        this._Status = Status;
        this._sYear = sYear;
        this._sSemester = sSemester;

        this._isFollowed = isFollowed;
        this._LTR = LTR;
        this.RMD = RMD;
        this._Campus = Campus;
    }

    #endregion

    #region "Public Properties"

    public int Serial
    {
        get { return _Serial; }
        set { _Serial = value; }
    }

    public string Major
    {
        get { return _Major; }
        set { _Major = value; }
    }

    public string Period
    {
        get { return _Period; }
        set { _Period = value; }
    }

    public string No
    {
        get { return _No; }
        set { _No = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public decimal HS
    {
        get { return _HS; }
        set { _HS = value; }
    }

    public decimal CGPA
    {
        get { return _CGPA; }
        set { _CGPA = value; }
    }

    public string ENG
    {
        get { return _ENG; }
        set { _ENG = value; }
    }

    public decimal SCORE
    {
        get { return _SCORE; }
        set { _SCORE = value; }
    }

    public string Phone1
    {
        get { return _Phone1; }
        set { _Phone1 = value; }
    }

    public string Phone2
    {
        get { return _Phone2; }
        set { _Phone2 = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public string sYear
    {
        get { return _sYear; }
        set { _sYear = value; }
    }

    public string sSemester
    {
        get { return _sSemester; }
        set { _sSemester = value; }
    }

    public string isFollowed
    {
        get { return _isFollowed; }

        set { _isFollowed = value; }
    }

    public string LTR
    {
        get { return _LTR; }
        set { _LTR = value; }
    }



    public string RMD
    {
        get { return _RMD; }
        set { _RMD = value; }
    }

    public string Campus
    {
        get { return _Campus; }
        set { _Campus = value; }
    }



    #endregion

}



public class FollowupDAL
{

    public string GetSQL(int iYear, byte bSem, int isEqual, string Status,bool inlExpected)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT UR.strMajor AS Major, UR.strShortcut AS P";
            sSQL += ", UR.lngStudentNumber AS No, UR.strLastDescEn AS Name";
            sSQL += ", " + " UR.sngGrade AS HS, UR.GPA AS CGPA, UR.strCert AS ENG";
            sSQL += ", UR.Mark AS SCORE, UR.strPhone1 AS Phone1";
            sSQL += ", UR.strPhone2 AS Phone2, " + " UR.byteCancelReason AS Status";
            sSQL += ", UR.intGraduationYear AS sYear, UR.byteGraduationSemester AS sSemester";
            sSQL += ", F.iTRKTimes as TRK, LTR.MaxYear AS LTR,UR.RMD";
            sSQL += ", UR.iCampus";
            sSQL += " FROM Current_Unregister AS UR ";
            sSQL += " LEFT OUTER JOIN Last_Time_Registered AS LTR ";
            sSQL += " ON UR.lngStudentNumber = LTR.Student ";
            sSQL += " LEFT OUTER JOIN Lkp_Reasons ";
            sSQL += " ON UR.byteCancelReason = Lkp_Reasons.byteReason ";
            sSQL += " LEFT OUTER JOIN Reg_Students_Followup AS F ";
            sSQL += " ON UR.lngStudentNumber = F.sStudentNo";

            //, UR.intStudyYear, UR.byteSemester 

            if (isEqual == 1)
            {
                sSQL += " Where UR.intStudyYear=" + iYear + " And UR.byteSemester=" + bSem;
                if (!string.IsNullOrEmpty(Status))
                {
                    sSQL += " AND (UR.byteCancelReason =0 " + Status + ")";
                }
                if (!inlExpected)
                {
                    sSQL += " AND  NOT(UR.lngStudentNumber IN(SELECT  E.sStudentNumber FROM ECT_Expected AS E INNER JOIN Cmn_Firm AS F ON E.iStudyYear = F.intCurrentYear AND E.iSemester = F.byteCurrentSemester))";
                }
            }
            else
            {
                sSQL += " Where (UR.intStudyYear=" + iYear + " And UR.byteSemester<" + bSem;
                if (!string.IsNullOrEmpty(Status))
                {
                    sSQL += " AND (UR.byteCancelReason=0 " + Status + ")";
                }
                if (!inlExpected)
                {
                    sSQL += " AND  NOT(UR.lngStudentNumber IN(SELECT  E.sStudentNumber FROM ECT_Expected AS E INNER JOIN Cmn_Firm AS F ON E.iStudyYear = F.intCurrentYear AND E.iSemester = F.byteCurrentSemester))";
                }
                sSQL += ")";

                sSQL += " Or (UR.intStudyYear<" + iYear;
                if (!string.IsNullOrEmpty(Status))
                {
                    sSQL += " AND (UR.byteCancelReason=0 " + Status + ")";
                }
                if (!inlExpected)
                {
                    sSQL += " AND  NOT(UR.lngStudentNumber IN(SELECT  E.sStudentNumber FROM ECT_Expected AS E INNER JOIN Cmn_Firm AS F ON E.iStudyYear = F.intCurrentYear AND E.iSemester = F.byteCurrentSemester))";
                }
                sSQL += ")";
            }


            sSQL += " Order By UR.strLastDescEn";
        }
        catch (Exception ex)
        {

            LibraryMOD.ShowErrorMessage(ex);

        }
        return sSQL;
    }

    public string GetExcelSQL(int iYear, byte bSem, int isEqual, string Status)
    {
        string sSQL = "";
        try
        {
                       
            sSQL = "SELECT UR.strMajor AS Major, UR.strShortcut AS P, UR.lngStudentNumber AS No, UR.strLastDescEn AS Name, UR.sngGrade AS HS, UR.GPA AS CGPA, ";
            sSQL += " UR.strCert AS ENG, UR.Mark AS SCORE, UR.strPhone1 AS Phone1, UR.strPhone2 AS Phone2, dbo.Lkp_Reasons.strReasonDesc AS Status,LTR.MaxYear AS LTR,UR.RMD,UR.iCampus";
            sSQL+=" FROM dbo.Current_Unregister AS UR LEFT OUTER JOIN dbo.Last_Time_Registered AS LTR ON UR.lngStudentNumber = LTR.Student LEFT OUTER JOIN";
            sSQL+= " dbo.Lkp_Reasons ON UR.byteCancelReason = dbo.Lkp_Reasons.byteReason LEFT OUTER JOIN dbo.Reg_Students_Followup AS F ON UR.lngStudentNumber = F.sStudentNo";
            
            if (isEqual == 1)
            {
                sSQL += " Where UR.intStudyYear=" + iYear + " And UR.byteSemester=" + bSem;
                if (!string.IsNullOrEmpty(Status))
                {
                    sSQL += " AND (UR.byteCancelReason =0 " + Status + ")";
                }
            }
            else
            {
                sSQL += " Where (UR.intStudyYear=" + iYear + " And UR.byteSemester<" + bSem;
                if (!string.IsNullOrEmpty(Status))
                {
                    sSQL += " AND (UR.byteCancelReason=0 " + Status + ")";
                }
                sSQL += ")";

                sSQL += " Or (UR.intStudyYear<" + iYear;
                if (!string.IsNullOrEmpty(Status))
                {
                    sSQL += " AND (UR.byteCancelReason=0 " + Status + ")";
                }
                sSQL += ")";
            }


            sSQL += " Order By UR.strLastDescEn";
        }
        catch (Exception ex)
        {

            LibraryMOD.ShowErrorMessage(ex);

        }
        return sSQL;
    }


    public List<Followup> GetFollowup(int iCampus, int iYear, byte bSem, int isEqual, string Status,bool inlExpected)
    {

        InitializeModule.EnumCampus Campus = (InitializeModule.EnumCampus)iCampus;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);

        string sSQL = GetSQL(iYear, bSem, isEqual, Status, inlExpected);

        SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string);

        SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
        myConnection.Open();
        SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        List<Followup> results = new List<Followup>();
        int iCMP = 0;
        int i = 1;
        try
        {

            while (reader.Read())
            {
                Followup Follow = new Followup();

                Follow.Serial = i;

                Follow.Major = reader["Major"].ToString();
                Follow.Campus = "";
                if (!(reader["iCampus"].Equals(DBNull.Value)))
                {
                    iCMP = Convert.ToInt32(reader["iCampus"]);
                    switch (iCMP)
                    {
                        case 1:
                            Follow.Campus = "Males";
                            break;
                        case 2:
                            Follow.Campus = "Females";
                            break;
                        case 3:
                            Follow.Campus = "Media";
                            break;
                    }
                }

                Follow.Major += " - " + Follow.Campus;

                Follow.Period = reader["P"].ToString();
                Follow.No = reader["No"].ToString();
                Follow.Name = reader["Name"].ToString();

                if (!(reader["HS"].Equals(DBNull.Value)))
                {
                    Follow.HS = decimal.Parse(reader["HS"].ToString());
                }

                if (!(reader["CGPA"].Equals(DBNull.Value)))
                {
                    Follow.CGPA = decimal.Parse(reader["CGPA"].ToString());
                }

                Follow.ENG = reader["ENG"].ToString();

                if (!(reader["SCORE"].Equals(DBNull.Value)))
                {
                    Follow.SCORE = decimal.Parse(reader["SCORE"].ToString());
                }

                Follow.Phone1 = reader["Phone1"].ToString();
                Follow.Phone2 = reader["Phone2"].ToString();

                if (!(reader["Status"].Equals(DBNull.Value)))
                {
                    switch (byte.Parse(reader["Status"].ToString()))
                    {
                        case 1:
                            Follow.Status = "Withdrawn";
                            break;
                        case 2:
                            Follow.Status = "Transferred";
                            break;
                        case 3:
                            Follow.Status = "Graduated";
                            break;
                        case 7:
                            Follow.Status = "Discontinued";
                            break;
                        case 8:
                            //Suspended 
                            Follow.Status = "Suspended";
                            break;
                        case 11:
                            //Postponed 
                            Follow.Status = "Postponed";
                            break;
                        case 13:
                            //Postponed 
                            Follow.Status = "TOEFL Enter Required";
                            break;
                        case 17:
                            //Postponed 
                            Follow.Status = "Intend to register";
                            break;
                        case 18:
                            //Postponed 
                            Follow.Status = "Never Registered";

                            break;

                    }
                }

                if (!(reader["sYear"].Equals(DBNull.Value)))
                {
                    int Year = 0;
                    Year = int.Parse(reader["sYear"].ToString());
                    Follow.sYear = Year + " / " + Year + 1;
                }

                if (!(reader["sSemester"].Equals(DBNull.Value)))
                {
                    switch (byte.Parse(reader["sSemester"].ToString()))
                    {
                        case 1:
                            //Fall 
                            Follow.sSemester = "Fall";
                            break;
                        case 2:
                            //Winter 
                            Follow.sSemester = "Spring";
                            break;
                        case 3:
                            //Summer 1 
                            Follow.sSemester = "S1";
                            break;
                        case 4:
                            //Summer 2 
                            Follow.sSemester = "S2";
                            break;
                    }
                }

                if (!(reader["TRK"].Equals(DBNull.Value)))
                {
                    Follow.isFollowed = reader["TRK"].ToString();
                }
                else
                {
                    Follow.isFollowed = "0";
                }

                if (!(reader["LTR"].Equals(DBNull.Value)))
                {
                    Follow.LTR = reader["LTR"].ToString();
                }
                else
                {
                    Follow.isFollowed = "";
                }

                
               
                results.Add(Follow);
                i += 1;

            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);                
        }
        finally
        {
            //'Response.Write(ex.Message) 

            reader.Close();
            reader.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }
        //myStatus.Clear() 

        return results;
    }
} 

