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


public class AttendanceCLS
{
    //Public Enum MyDataStatus 
    // NewData = 0 
    // OldData = 1 
    //End Enum 

    #region "Private Member Variables"
    //SELECT A.intStudyYear, A.byteSemester, A.strCourse, A.byteClass, A.byteShift 
    //,A.lngStudentNumber, A.dateAttendance, A.byteDay, A.curHours, A.byteAttStatus 
    //FROM Reg_Attendance AS A 
    private int _StudyYear;
    private byte _Semester;
    private byte _Shift;
    private string _Course;
    private byte _Class;
    private string _StudentNumber;
    private string _StudentName;
    private System.DateTime _DateAttendance;
    private byte _Day;
    private decimal _Hours;
    private byte _Status;
    private string _Desc;
    private bool _bFainance;
    private string _Remind;
    private int _DataStatus;
    private byte _isDataGhanged;

    private decimal _AttSesseions;
    private decimal _AttAll;
    private decimal _AttPer;

    #endregion

    #region "Constructors"
    public AttendanceCLS()
    {
    }
    public AttendanceCLS(int StudyYear, byte Semester, byte Shift, string Course, byte AttClass, string StudentNumber, string Name, System.DateTime DateAttendance, byte Day, decimal Hours,
    byte Status, string Desc, bool bFainance, string Remind, int DataStatus, byte isDataGhanged, decimal AttSesseions, decimal AttAll, decimal AttPer)
    {
        this._StudyYear = StudyYear;
        this._Semester = Semester;
        this._Shift = Shift;
        this._Course = Course;
        this._Class = AttClass;
        this._StudentNumber = StudentNumber;
        this._StudentName = Name;
        this._DateAttendance = DateAttendance;
        this._Day = Day;
        this._Hours = Hours;
        this._Status = Status;
        this._Desc = Desc;
        this._DataStatus = DataStatus;
        this._isDataGhanged = isDataGhanged;
        this._bFainance=bFainance;
        this._Remind = Remind;
        this._AttSesseions = AttSesseions;
        this._AttAll = AttAll;
        this._AttPer = AttPer;

    }

    #endregion

    #region "Public Properties"

    public int StudyYear
    {
        get { return _StudyYear; }
        set { _StudyYear = value; }
    }

    public byte Semester
    {
        get { return _Semester; }
        set { _Semester = value; }
    }

    public byte Shift
    {
        get { return _Shift; }
        set { _Shift = value; }
    }

    public string Course
    {
        get { return _Course; }
        set { _Course = value; }
    }

    public byte AttClass
    {
        get { return _Class; }
        set { _Class = value; }
    }

    public string StudentNumber
    {
        get { return _StudentNumber; }
        set { _StudentNumber = value; }
    }

    public string StudentName
    {
        get { return _StudentName; }
        set { _StudentName = value; }
    }

    public System.DateTime DateAttendance
    {
        get { return _DateAttendance; }
        set { _DateAttendance = value; }
    }

    public byte Day
    {
        get { return _Day; }
        set { _Day = value; }
    }

    public decimal Hours
    {
        get { return _Hours; }
        set { _Hours = value; }
    }

    public byte Status
    {
        get { return _Status; }
        set
        {
            //Throw New ArgumentException("UnitsInStock must be " & _ 
            //"greater than or equal to zero.") 
            _Status = value;
            isDataGhanged = 1;
        }
    }

    public string Desc
    {
        get { return _Desc; }
        //Throw New ArgumentException("UnitsInStock must be " & _ 
        //"greater than or equal to zero.") 
        set { _Desc = value; }
    }

    public bool BFainance
    {
        get { return _bFainance; }
        set { _bFainance = value; }
    }

    public string Remind
    {
        get { return _Remind; }
        set { _Remind = value; }
    }

    public int DataStatus
    {
        get { return _DataStatus; }
        //Throw New ArgumentException("UnitsInStock must be " & _ 
        //"greater than or equal to zero.") 
        set { _DataStatus = value; }
    }

    public byte isDataGhanged
    {
        get { return _isDataGhanged; }
        //Throw New ArgumentException("UnitsInStock must be " & _ 
        //"greater than or equal to zero.") 
        set { _isDataGhanged = value; }
    }

    public decimal AttSesseions
    {
        get { return _AttSesseions; }
        set { _AttSesseions = value; }
    }

    public decimal AttAll
    {
        get { return _AttAll; }
        set { _AttAll = value; }
    }

    public decimal AttPer
    {
        get { return _AttPer; }
        set { _AttPer = value; }
    }

    #endregion

} 

public class AttendanceDAL 
{ 
    public byte GetToDay(string sDate) 
    {
        byte byteDay = 0;
        DateTime dDay = LibraryMOD.GetDateFromString(sDate);

        try {

            switch (dDay.DayOfWeek)
            { 
                case DayOfWeek.Saturday: 
                    byteDay = 1; 
                    break; 
                case DayOfWeek.Sunday: 
                    byteDay = 2; 
                    break; 
                case DayOfWeek.Monday: 
                    byteDay = 3; 
                    break; 
                case DayOfWeek.Tuesday: 
                    byteDay = 4; 
                    break; 
                case DayOfWeek.Wednesday: 
                    byteDay = 5; 
                    break; 
                case DayOfWeek.Thursday: 
                    byteDay = 6; 
                    break; 
                case DayOfWeek.Friday: 
                    byteDay = 7; 
                    break; 
            } 
            
             
        } 
        catch (Exception ex) {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        return byteDay;
    }

    public List<AttendanceCLS> GetAttendance(InitializeModule.EnumCampus Campus, string Condition,string sDate)
    {


        Connection_StringCLS sConn = new Connection_StringCLS(Campus);
        string sUDate = LibraryMOD.GetUniversalDate(sDate);
        DateTime dDate = LibraryMOD.GetDateFromString(sDate);
        byte bDay = GetToDay(sDate);
        //'//Check Registration Balance 
        //'//Create Reg_Attendence_Query as View 

        //string sSQL = "SELECT CB.iYear AS intStudyYear, CB.Sem AS byteSemester, CB.Shift AS byteShift, CB.Course AS strCourse,CB.Class AS byteClass, CB.Student AS lngStudentNumber, SD.strLastDescEn AS sName, Q.dateAttendance, Q.byteAttStatus,AL.byteDay, AL.cLoad AS curHours";
        //sSQL += " FROM dbo.Reg_Applications AS AP INNER JOIN dbo.Reg_Students_Data AS SD ON AP.lngSerial = SD.lngSerial INNER JOIN";
        //sSQL += " dbo.Registration_Balance AS CB LEFT OUTER JOIN dbo.Current_Attendance AS Q ON CB.Student = Q.lngStudentNumber AND CB.Shift = Q.byteShift AND CB.Class = Q.byteClass AND ";
        //sSQL += " CB.Course = Q.strCourse AND CB.Sem = Q.byteSemester AND CB.iYear = Q.intStudyYear ON AP.lngStudentNumber = CB.Student INNER JOIN dbo.Available_Loads AS AL ON CB.iYear = AL.intStudyYear AND CB.Sem = AL.byteSemester AND CB.Shift = AL.byteShift AND ";
        //sSQL += " CB.Course = AL.strCourse AND CB.Class = AL.byteClass";

        string sSQL = "SELECT CB.iYear AS intStudyYear, CB.Sem AS byteSemester, CB.Shift AS byteShift, CB.Course AS strCourse, CB.Class AS byteClass, ";
        sSQL += " CB.Student AS lngStudentNumber, SD.strLastDescEn AS sName, Att.dateAttendance, Att.byteAttStatus, AL.byteDay, AL.cLoad AS curHours,AP.bOtherCollege as bFainance,AP.intRemind";
        sSQL += " FROM Reg_Applications AS AP INNER JOIN Reg_Students_Data AS SD ON AP.lngSerial = SD.lngSerial INNER JOIN";
        sSQL += " Registration_Balance AS CB ON AP.lngStudentNumber = CB.Student INNER JOIN Available_Loads AS AL ON CB.iYear = AL.intStudyYear AND CB.Sem = AL.byteSemester AND CB.Shift = AL.byteShift AND CB.Course = AL.strCourse AND";
        sSQL += " CB.Class = AL.byteClass LEFT OUTER JOIN dbo.GetAtt('"+sUDate+"') AS Att ON CB.Student = Att.lngStudentNumber COLLATE Arabic_CI_AS AND CB.Class = Att.byteClass AND ";
        sSQL += " CB.Course = Att.strCourse COLLATE Arabic_CI_AS AND CB.Shift = Att.byteShift AND CB.iYear = Att.intStudyYear AND CB.Sem = Att.byteSemester";

        sSQL += " Where AL.byteDay=" + bDay;


        if (Condition != "" && Condition != "vbNullString")
        {
            sSQL = sSQL + " And " + Condition;
        }

        sSQL = sSQL + " Order By SD.strLastDescEn";

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<AttendanceCLS> results = new List<AttendanceCLS>();
        //Dim myStatus As New List(Of AttStatus) 
        int i = 0;
        try
        {
            //myStatus.Clear() 
            //myStatus = AttStatusDAL.GetAttStatuses(iCampus) 

            //If Not (Rd.HasRows) Then 
            // MsgBox("No Lecture today", MsgBoxStyle.Information, "ECT Local") 
            //End If 

            while (Rd.Read())
            {
                AttendanceCLS attendance = new AttendanceCLS();
                attendance.StudyYear = Convert.ToInt32(Rd["intStudyYear"]);
                attendance.Semester = Convert.ToByte(Rd["byteSemester"]);
                attendance.Shift = Convert.ToByte(Rd["byteShift"]);
                attendance.Course = Rd["strCourse"].ToString();
                attendance.AttClass = Convert.ToByte(Rd["byteClass"]);
                attendance.StudentNumber = Rd["lngStudentNumber"].ToString();
                attendance.StudentName = Rd["sName"].ToString();


                attendance.DateAttendance = dDate;

                attendance.Day = bDay;
                

                if (Rd["curHours"].Equals(DBNull.Value))
                {
                    attendance.Hours = 1;
                }
                else
                {
                    attendance.Hours = Convert.ToDecimal(Rd["curHours"]);
                }


                //attendance.Status = Convert.ToByte(Rd("byteAttStatus")) 

                if (Rd["byteAttStatus"].Equals(DBNull.Value))
                {
                    //For ESL courses make the default value =Absent
                    if (attendance.Course.Contains("ESL"))
                    {
                        attendance.Status = 5;  //Absent
                    }
                    else
                    {
                        //attendance.Status = 5;  //Absent   
                        attendance.Status = 1; //Attended
                    }
                }
                else
                {
                    attendance.Status = Convert.ToByte(Rd["byteAttStatus"]);
                }

                attendance.BFainance = bool.Parse( Rd["bFainance"].ToString());

                if (Rd["intRemind"].Equals(DBNull.Value))
                {
                    attendance.Remind = "";
                }
                else
                {
                    attendance.Remind = Rd["intRemind"].ToString();
                }
                
                //Dim index As Integer 

                //For index = 0 To myStatus.Count - 1 
                // If myStatus(index).AttStatus = attendance.Status Then 
                // attendance.Desc = myStatus(index).AttDescEn.ToString 
                // Exit For 
                // End If 
                //Next 

                if (Rd["byteAttStatus"].Equals(DBNull.Value))
                {
                    //New Record 
                    attendance.DataStatus = 0;
                }
                else
                {
                    //Old Record 
                    attendance.DataStatus = 1;
                }

                attendance.isDataGhanged = 0;

                results.Add(attendance);
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

            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        //myStatus.Clear() 

        return results;
    } 
    
    public int UpdateAttendance(int StudyYear, byte Semester, byte Shift, string Course, byte AttClass, string StudentNumber, string StudentName, string  sDate, decimal Hours,
    byte Status, int DataStatus, InitializeModule.EnumCampus Campus, string sUser, string sNetUser, string sPCName) 
    {
        int iEffected = 0;
        
        Connection_StringCLS sConn = new Connection_StringCLS(Campus); 
        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());
        string sUDate = LibraryMOD.GetUniversalDate(sDate);
        byte bDay = GetToDay(sDate);

        string sToday = string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date);
        sToday = LibraryMOD.GetUniversalDate(sToday);
        try { 
            //Updates the Attendance table 
            
            Conn.Open(); 
            
            string sSQL = null; 
            
            if (DataStatus == 1) {
                sSQL = "UPDATE Reg_Attendance SET byteAttStatus =@AttStatus,strUserSave=@sUser,dateLastSave=GETDATE() ,strNUser=@NetUser,";
                sSQL = sSQL + " strMachine=@PCName ";
                sSQL = sSQL + " Where intStudyYear=@StudyYear"; 
                sSQL = sSQL + " And byteSemester=@Semester"; 
                sSQL = sSQL + " And byteShift=@Shift"; 
                sSQL = sSQL + " And strCourse=@Course"; 
                sSQL = sSQL + " And byteClass=@Class"; 
                sSQL = sSQL + " And lngStudentNumber=@Student"; 
                sSQL = sSQL + " And dateAttendance=@DateAtt"; 
                
                SqlCommand Cmd = new SqlCommand(sSQL, Conn); 
                
                Cmd.Parameters.Add(new SqlParameter("@AttStatus", Status)); 
                Cmd.Parameters.Add(new SqlParameter("@sUser", sUser)); 
                //Cmd.Parameters.Add(new SqlParameter("@dateSaved", sToday)); 
                Cmd.Parameters.Add(new SqlParameter("@StudyYear", StudyYear)); 
                Cmd.Parameters.Add(new SqlParameter("@Semester", Semester)); 
                Cmd.Parameters.Add(new SqlParameter("@Shift", Shift)); 
                Cmd.Parameters.Add(new SqlParameter("@Course", Course)); 
                Cmd.Parameters.Add(new SqlParameter("@Class", AttClass)); 
                Cmd.Parameters.Add(new SqlParameter("@Student", StudentNumber)); 
                Cmd.Parameters.Add(new SqlParameter("@DateAtt", sUDate));

                Cmd.Parameters.Add(new SqlParameter("@NetUser", sNetUser ));
                Cmd.Parameters.Add(new SqlParameter("@PCName", sPCName)); 

                iEffected=Cmd.ExecuteNonQuery(); 
            } 
            else { 
                
                sSQL = "Insert Into Reg_Attendance (intStudyYear, byteSemester, strCourse, byteClass, byteShift,";
                sSQL = sSQL + "lngStudentNumber, dateAttendance, byteDay, curHours, byteAttStatus, strUserCreate, dateCreate,strNUser,strMachine)"; 
                sSQL = sSQL + " Values (@StudyYear,@Semester,@Course,@Class,@Shift,@Student,@DateAtt,@AttDay,";
                sSQL = sSQL + "@Hours,@AttStatus,@User,GETDATE(),@NetUser,@PCName)"; 
                
                SqlCommand Cmd = new SqlCommand(sSQL, Conn); 
                Cmd.Parameters.Add(new SqlParameter("@StudyYear", StudyYear)); 
                Cmd.Parameters.Add(new SqlParameter("@Semester", Semester)); 
                Cmd.Parameters.Add(new SqlParameter("@Course", Course)); 
                Cmd.Parameters.Add(new SqlParameter("@Class", AttClass)); 
                Cmd.Parameters.Add(new SqlParameter("@Shift", Shift)); 
                Cmd.Parameters.Add(new SqlParameter("@Student", StudentNumber)); 
                Cmd.Parameters.Add(new SqlParameter("@DateAtt", sUDate)); 
                Cmd.Parameters.Add(new SqlParameter("@AttDay", bDay)); 
                Cmd.Parameters.Add(new SqlParameter("@Hours", Hours)); 
                Cmd.Parameters.Add(new SqlParameter("@AttStatus", Status)); 
                Cmd.Parameters.Add(new SqlParameter("@User", sUser)); 
                //Cmd.Parameters.Add(new SqlParameter("@DateCreated", sToday));
                Cmd.Parameters.Add(new SqlParameter("@NetUser", sNetUser)); 
                Cmd.Parameters.Add(new SqlParameter("@PCName", sPCName)); 

                iEffected=Cmd.ExecuteNonQuery(); 
                
            } 
        } 
        catch (Exception ex) {




            Console.WriteLine("{0} Exception caught.", ex.Message);
        } 
        finally { 
            Conn.Close();
            Conn.Dispose(); 
        }
        return iEffected;
    }

    //public int UpdateAttendance(int StudyYear, byte Semester, byte Shift, string Course, byte AttClass, string StudentNumber, string StudentName, System.DateTime DateAttendance, byte Day, decimal Hours,
    //byte Status, int DataStatus, SqlConnection Conn, string sUser)
    //{
    //    int iEffected = 0;
    //    try
    //    {
    //        //Updates the Attendance table 
    //        string sSQL = null;

    //        if (DataStatus == 1)
    //        {
    //            sSQL = "UPDATE Reg_Attendance SET byteAttStatus =@AttStatus,strUserSave=@sUser,dateLastSave=@dateSaved";
    //            sSQL = sSQL + " Where intStudyYear=@StudyYear";
    //            sSQL = sSQL + " And byteSemester=@Semester";
    //            sSQL = sSQL + " And byteShift=@Shift";
    //            sSQL = sSQL + " And strCourse=@Course";
    //            sSQL = sSQL + " And byteClass=@Class";
    //            sSQL = sSQL + " And lngStudentNumber=@Student";
    //            sSQL = sSQL + " And dateAttendance=@DateAtt";

    //            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

    //            Cmd.Parameters.Add(new SqlParameter("@AttStatus", Status));
    //            Cmd.Parameters.Add(new SqlParameter("@sUser", sUser));
    //            Cmd.Parameters.Add(new SqlParameter("@dateSaved", DateTime.Today.Date));
    //            Cmd.Parameters.Add(new SqlParameter("@StudyYear", StudyYear));
    //            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
    //            Cmd.Parameters.Add(new SqlParameter("@Shift", Shift));
    //            Cmd.Parameters.Add(new SqlParameter("@Course", Course));
    //            Cmd.Parameters.Add(new SqlParameter("@Class", AttClass));
    //            Cmd.Parameters.Add(new SqlParameter("@Student", StudentNumber));
    //            Cmd.Parameters.Add(new SqlParameter("@DateAtt", DateAttendance));


    //            iEffected= Cmd.ExecuteNonQuery();
    //        }
    //        else
    //        {

    //            sSQL = "Insert Into Reg_Attendance (intStudyYear, byteSemester, strCourse, byteClass, byteShift,";
    //            sSQL = sSQL + "lngStudentNumber, dateAttendance, byteDay, curHours, byteAttStatus, strUserCreate, dateCreate)";
    //            sSQL = sSQL + " Values (@StudyYear,@Semester,@Course,@Class,@Shift,@Student,@DateAtt,@AttDay,";
    //            sSQL = sSQL + "@Hours,@AttStatus,@User,@DateCreated)";

    //            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    //            Cmd.Parameters.Add(new SqlParameter("@StudyYear", StudyYear));
    //            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
    //            Cmd.Parameters.Add(new SqlParameter("@Course", Course));
    //            Cmd.Parameters.Add(new SqlParameter("@Class", AttClass));
    //            Cmd.Parameters.Add(new SqlParameter("@Shift", Shift));
    //            Cmd.Parameters.Add(new SqlParameter("@Student", StudentNumber));
    //            Cmd.Parameters.Add(new SqlParameter("@DateAtt", DateAttendance));
    //            Cmd.Parameters.Add(new SqlParameter("@AttDay", Day));
    //            Cmd.Parameters.Add(new SqlParameter("@Hours", Hours));
    //            Cmd.Parameters.Add(new SqlParameter("@AttStatus", Status));
    //            Cmd.Parameters.Add(new SqlParameter("@User", sUser));
    //            Cmd.Parameters.Add(new SqlParameter("@DateCreated", DateTime.Today.Date));

    //            iEffected = Cmd.ExecuteNonQuery();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("{0} Exception caught.", ex.Message);

    //    }
    //    finally
    //    {
    //        //Conn.Close();

    //    }
    //    return iEffected;
    //}
    
    
    public int GetAttendanceDaysAllowed(int iAcademicYear, int iSemester)
    {
Connection_StringCLS sConn = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);

        string sSQL = "SELECT AttendanceDaysAllowed ";
        sSQL += "FROM Reg_Semester ";
        sSQL += "WHERE AcademicYear=" + iAcademicYear + " AND Semester=" + iSemester;
        
        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

        int iAttendanceDaysAllowed = 0;
        try
        {
            if(Rd.HasRows)
            {
                Rd.Read();
                iAttendanceDaysAllowed = int.Parse(Rd[0].ToString());
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        

        return iAttendanceDaysAllowed;
    
    }
} 


