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
using System.Data.SqlClient;
using System.Data.Sql;

public class StudentTimeTable
{
	public StudentTimeTable()
	{

    }
    #region "Decleration"
    public struct Students
    {
        public int _Serial;
        public string _StudentNumber;
        public string _Name;
        public string _Period;
        public string _Major;
        public decimal _CGPA;
        public string _ENG;
        public decimal _Score;
        public string _Phone1;
        public string _Phone2;

    }
    public struct Times
    {
        public int _iLecturer;
        public string _sLecturer;
        public DateTime _dFrom;
        public DateTime _dTo;
        public int _iDays;
        public string _sDays;
        public int _iClass;
        public string _sHall;
        public decimal _dTeachingHours;
        public string _sPeriod;
        public string _sCourse;
        public int _iCapacity;
        public int _iMaxSeats;
    }
    
    private int iPeriod;
    //private string sPeriod;
    //private string sCourse;
    //private int iC;
    //private string sLecturer;
    //private string sHall;
    //private string sTFrom;
    //private string sTTo;
    //private string sDays;
    #endregion

        #region "Puplic Properties"
    public int IPeriod
    {
        get { return iPeriod; }
        set { iPeriod = value; }
    }
    //public string SPeriod
    //{
    //    get { return sPeriod; }
    //    set { sPeriod = value; }
    //}
    //public string SCourse
    //{
    //    get { return sCourse; }
    //    set { sCourse = value; }
    //}
    //public string SLecturer
    //{
    //    get { return sLecturer; }
    //    set { sLecturer = value; }
    //}
    //public string SHall
    //{
    //    get { return sHall; }
    //    set { sHall = value; }
    //}
        #endregion
}

public class StudentTimeTableDAL : StudentTimeTable
{
    
    public List<StudentTimeTable.Times> GetStudentTimeTable(InitializeModule.EnumCampus Campus, int iPeriod, string sCourse)
    {
        //string sSql = "SELECT Reg_CourseTime_Schedule.intStudyYear, Reg_CourseTime_Schedule.byteSemester, Reg_CourseTime_Schedule.strCourse, ";
        string sSql = "SELECT CT.intStudyYear, CT.byteSemester, CT.strCourse, CT.byteClass, ";
        sSql += " CT.byteShift, L.strLecturerDescEn, C.byteCreditHours, C.strEquivalent, ";
        sSql += " COALESCE (CC.RegCapacity, 0) AS RegCapacity, H.intMaxSeats, CT.strHall, ";
        sSql += " dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.dateTimeFrom, CT.dateTimeTo ";
        sSql += " FROM Reg_CourseTime_Schedule AS CT INNER JOIN ";
        sSql += " Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN ";
        sSql += " Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN ";
        sSql += " Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear ";
        sSql += " AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND ";
        sSql += " CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN ";
        sSql += " Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN ";
        sSql += " ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem ";
        sSql += " AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class ";
        sSql += " AND CT.byteShift = CC.Shift";
        sSql += " WHERE CT.strCourse='" + sCourse + "' AND CT.byteShift=" + iPeriod;

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string);

        SqlCommand Cmd = new SqlCommand(sSql, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<StudentTimeTable.Times> results = new List<StudentTimeTable.Times>();
        try
        {

            while (reader.Read())
            {
                StudentTimeTable.Times myTimes = new StudentTimeTable.Times();

                myTimes._sPeriod = reader["byteShift"].ToString();
                myTimes._sCourse = reader["strCourse"].ToString();
                myTimes._sLecturer = reader["strLecturerDescEn"].ToString();
                myTimes._iClass = int.Parse(reader["byteClass"].ToString());
                myTimes._sHall = reader["strHall"].ToString();
                //DateTime dTimeFrom = DateTime.Parse(String.Format("{0:d}", reader["dateTimeFrom"]));
                //myTimes._dFrom = dTimeFrom;
                myTimes._dFrom = DateTime.Parse(reader["dateTimeFrom"].ToString());
                myTimes._dTo = DateTime.Parse(reader["dateTimeTo"].ToString());
                myTimes._sDays = reader["strDays"].ToString();
                myTimes._iCapacity = int.Parse(reader["RegCapacity"].ToString());
                myTimes._iMaxSeats = int.Parse(reader["intMaxSeats"].ToString());
                results.Add(myTimes);
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

    public List<StudentTimeTable.Times> GetCurrentSemesterCourses(InitializeModule.EnumCampus Campus, int iYear, int iSemester, string sStudentId)
    {
        string sSql = "SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, ";
        sSql += " Reg_Shifts.strShortcut, CT.strCourse, CT.byteClass, Reg_Lecturers.strLecturerDescEn, ";
        sSql += " CT.strHall, CT.dateTimeFrom, CT.dateTimeTo, COALESCE(CT.byteDay,0) AS byteDay,";
        //sSql += " Reg_Courses.strEquivalent, Course_Balance_View.Student";
        sSql += " CT.dateTimeFrom, CT.dateTimeTo, COALESCE(CT.byteDay,0) AS byteDay, ";
        sSql += " Reg_Courses.strEquivalent, Course_Balance_View.Student";
        sSql += " FROM Course_Balance_View INNER JOIN";
        sSql += " Reg_Courses ON Course_Balance_View.Course = Reg_Courses.strCourse INNER JOIN";
        sSql += " Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Shifts ";
        sSql += " ON CT.byteShift = Reg_Shifts.byteShift INNER JOIN";
        sSql += "Reg_Lecturers ON CT.intLecturer = Reg_Lecturers.intLecturer ";
        sSql += " ON Course_Balance_View.iYear = CT.intStudyYear AND ";
        sSql += " Course_Balance_View.Sem = CT.byteSemester AND Course_Balance_View.Shift = CT.byteShift ";
        sSql += " AND Course_Balance_View.Course = CT.strCourse AND ";
        sSql += " Course_Balance_View.Class = CT.byteClass";
        sSql += " WHERE intStudyYear=" + iYear + " AND byteSemester=" + iSemester;

        if(!sStudentId.Equals(null) || !sStudentId.Equals(""))
        sSql += " AND Student='" + sStudentId +"'";

        sSql += " ORDER BY CT.byteShift, CT.strCourse";

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string);

        SqlCommand Cmd = new SqlCommand(sSql, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<StudentTimeTable.Times> results = new List<StudentTimeTable.Times>();
        try
        {
            while (reader.Read())
            {
                StudentTimeTable.Times myTimes = new StudentTimeTable.Times();

                myTimes._sPeriod = reader["byteShift"].ToString();
                myTimes._sCourse = reader["strCourse"].ToString();
                myTimes._sLecturer = reader["strLecturerDescEn"].ToString();
                myTimes._iClass = int.Parse(reader["byteClass"].ToString());
                myTimes._sHall = reader["strHall"].ToString();
                myTimes._dFrom = DateTime.Parse(reader["dateTimeFrom"].ToString());
                myTimes._dTo = DateTime.Parse(reader["dateTimeTo"].ToString());
                myTimes._sDays = reader["strDays"].ToString();
                results.Add(myTimes);
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

    #region "Data Access Layer"
    //-----Get SQl Function ---------------------------------
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            //sSQL = "SELECT ";
            //sSQL += intTitleFN;
            //sSQL += " , " + strTitleDescEnFN;
            //sSQL += " , " + strTitleDescArFN;
            //sSQL += " , " + strUserCreateFN;
            //sSQL += " , " + dateCreateFN;
            //sSQL += " , " + strUserSaveFN;
            //sSQL += " , " + dateLastSaveFN;
            //sSQL += " , " + strMachineFN;
            //sSQL += " , " + strNUserFN;
            //sSQL += "  FROM " + m_TableName;
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
            //sSQL = "SELECT ";
            //sSQL += intTitleFN;
            //sSQL += " , " + strTitleDescEnFN;
            //sSQL += " , " + strTitleDescArFN;
            //sSQL += " , " + strUserCreateFN;
            //sSQL += " , " + dateCreateFN;
            //sSQL += " , " + strUserSaveFN;
            //sSQL += " , " + dateLastSaveFN;
            //sSQL += " , " + strMachineFN;
            //sSQL += " , " + strNUserFN;
            //sSQL += "  FROM " + m_TableName;
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
}