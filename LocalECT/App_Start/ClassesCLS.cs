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

public class ClassesCLS 
{ 
    
    #region "Private Member Variables" 
    //SELECT intStudyYear, byteSemester, byteShift, strShortcut, strCourse, 
    // byteClass, strHall, dateTimeFrom, dateTimeTo, days, intLecturer 
    //FROM dbo.Classes 
    private int _StudyYear; 
    private byte _Semester; 
    private byte _Shift; 
    private string _Shortcut; 
    private string _Course; 
    private byte _Class; 
    private string _Hall; 
    private string _TimeFrom; 
    private string _Timeto; 
    private string _Days; 
    private int _Lecturer; 
    #endregion 
    
    #region "Constructors" 
    public ClassesCLS() 
    { 
    } 
    public ClassesCLS(int StudyYear, byte Semester, byte Shift, string Shortcut, string Course, byte AttClass, string Hall, string TimeFrom, string TimeTo, string Days, 
    int Lecturer) 
    { 
        this._StudyYear = StudyYear; 
        this._Semester = Semester; 
        this._Shift = Shift; 
        this._Shortcut = Shortcut; 
        this._Course = Course; 
        this._Class = AttClass; 
        this._Hall = Hall; 
        this._TimeFrom = TimeFrom; 
        this._Timeto = TimeTo; 
        this._Days = Days; 
        this._Lecturer = Lecturer; 
    } 
    
    #endregion 
    
    #region "Public Properties" 
    
    public int StudyYear { 
        get { return _StudyYear; } 
        set { _StudyYear = value; } 
    } 
    
    public byte Semester { 
        get { return _Semester; } 
        set { _Semester = value; } 
    } 
    
    public byte Shift { 
        get { return _Shift; } 
        set { _Shift = value; } 
    } 
    
    public string Shortcut { 
        get { return _Shortcut; } 
        set { _Shortcut = value; } 
    } 
    
    public string Course { 
        get { return _Course; } 
        set { _Course = value; } 
    } 
    
    public byte AttClass { 
        get { return _Class; } 
        set { _Class = value; } 
    } 
    
    public string Hall { 
        get { return _Hall; } 
        set { _Hall = value; } 
    } 
    
    public string TimeFrom { 
        get { return _TimeFrom; } 
        set { _TimeFrom = value; } 
    } 
    
    public string TimeTo { 
        get { return _Timeto; } 
        set { _Timeto = value; } 
    } 
    
    public string Days { 
        get { return _Days; } 
        set { _Days = value; } 
    } 
    
    public int Lecturer { 
        get { return _Lecturer; } 
        set { _Lecturer = value; } 
    } 
    
    
    
    #endregion 
    
} 

public class ClassesDAL 
{
    public List<ClassesCLS> GetClasses(InitializeModule.EnumCampus Campus, string Condition) 
    {      
        
        Connection_StringCLS sConn = new Connection_StringCLS(Campus);
           
        
        string sSQL = "SELECT intStudyYear, byteSemester, byteShift, strShortcut, strCourse, " + "byteClass, strHall, dateTimeFrom, dateTimeTo, days, intLecturer FROM dbo.Classes"; 
        if (Condition != "" && Condition != "vbNullString") {
            if (Condition.Contains("Where")==true )
            {
                sSQL = sSQL + Condition;
            }
            else
            {

                ECTNewLecturersDAL myLecturersDAL = new ECTNewLecturersDAL();
                List<ECTNewLecturers> myLecturers = new List<ECTNewLecturers>();
                myLecturers = myLecturersDAL.GetLecturers(InitializeModule.EnumCampus.ECTNew, " Where LecturerID=" + Condition, false);
                int myLecturer = 0;
                if (myLecturers.Count > 0)
                {
                    if (Campus == InitializeModule.EnumCampus.Females)
                    {
                        myLecturer = myLecturers[0].FCampusID;
                    }
                    else
                    {
                        myLecturer = myLecturers[0].MCampusID;
                    }
                    myLecturers.Clear();
                }

                sSQL = sSQL + " Where intLecturer=" + myLecturer;
                
            }
        } 
        
        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString()); 
        
        SqlCommand Cmd = new SqlCommand(sSQL, Conn); 
        Conn.Open(); 
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection); 
        List<ClassesCLS> results = new List<ClassesCLS>(); 
        try { 
            while (Rd.Read()) { 
                ClassesCLS classes = new ClassesCLS(); 
                classes.StudyYear = Convert.ToInt32(Rd["intStudyYear"]); 
                classes.Semester = Convert.ToByte(Rd["byteSemester"]); 
                classes.Shift = Convert.ToByte(Rd["byteShift"]); 
                classes.Shortcut = Rd["strShortcut"].ToString(); 
                classes.Course = Rd["strCourse"].ToString(); 
                classes.AttClass = Convert.ToByte(Rd["byteClass"]); 
                classes.Hall = Rd["strHall"].ToString();
                classes.TimeFrom = Convert.ToDateTime(Rd["dateTimeFrom"].ToString()).ToShortTimeString();
                classes.TimeTo = Convert.ToDateTime(Rd["dateTimeTo"].ToString()).ToShortTimeString(); 
                classes.Days = Rd["Days"].ToString(); 
                classes.Lecturer = Convert.ToInt32(Rd["intLecturer"]); 
                
                    
                results.Add(classes); 
                
            } 
        } 
        catch (Exception ex) { 
        } 
        finally { 
            
            Rd.Close(); 
            Rd.Dispose(); 
            Conn.Close(); 
            Conn.Dispose(); 
        } 
        return results; 
    }

    public List<ClassesCLS> GetClasses(InitializeModule.EnumCampus Campus, int iLecturer,int iYear,byte bSemester )
    {

        Connection_StringCLS sConn = new Connection_StringCLS(Campus);


        string sSQL = "SELECT intStudyYear";
        sSQL += " , byteSemester";
        sSQL += " , byteShift";
        sSQL += " , strShortcut";
        sSQL += " , strCourse";
        sSQL += " , byteClass";
        sSQL += " , strHall";
        sSQL += " , dateTimeFrom";
        sSQL += " , dateTimeTo";
        sSQL += " , days";
        sSQL += " , intLecturer ";
        sSQL += " FROM dbo.Classes_All";
        sSQL += " Where bLab=0";
        if (iLecturer > 0)
        {
            ECTNewLecturersDAL myLecturersDAL = new ECTNewLecturersDAL();
            List<ECTNewLecturers> myLecturers = new List<ECTNewLecturers>();
            myLecturers = myLecturersDAL.GetLecturers(InitializeModule.EnumCampus.ECTNew, " Where LecturerID=" + iLecturer, false);
            int myLecturer = 0;
            string myCollege = "";
            if (myLecturers.Count > 0)
            {
                if (Campus == InitializeModule.EnumCampus.Females)
                {
                    myLecturer = myLecturers[0].FCampusID;
                }
                else
                {
                    myLecturer = myLecturers[0].MCampusID;
                }
                myCollege = Convert.ToString(myLecturers[0].CollegeID);
                myLecturers.Clear();
            }

            sSQL += " And intLecturer=" + myLecturer;
        }
        sSQL += " And intStudyYear=" + iYear;
        sSQL += " And byteSemester=" + bSemester;            

        

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<ClassesCLS> results = new List<ClassesCLS>();
        try
        {
            while (Rd.Read())
            {
                ClassesCLS classes = new ClassesCLS();
                classes.StudyYear = Convert.ToInt32(Rd["intStudyYear"]);
                classes.Semester = Convert.ToByte(Rd["byteSemester"]);
                classes.Shift = Convert.ToByte(Rd["byteShift"]);
                classes.Shortcut = Rd["strShortcut"].ToString();
                classes.Course = Rd["strCourse"].ToString();
                classes.AttClass = Convert.ToByte(Rd["byteClass"]);
                classes.Hall = Rd["strHall"].ToString();
                classes.TimeFrom = Convert.ToDateTime(Rd["dateTimeFrom"].ToString()).ToShortTimeString();
                classes.TimeTo = Convert.ToDateTime(Rd["dateTimeTo"].ToString()).ToShortTimeString();
                classes.Days = Rd["Days"].ToString();
                classes.Lecturer = Convert.ToInt32(Rd["intLecturer"]);


                results.Add(classes);

            }
        }
        catch (Exception ex)
        {
        }
        finally
        {

            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return results;
    }

    public List<ClassesCLS> GetClasses(InitializeModule.EnumCampus Campus, int iLecturer, int iYear, byte bSemester,bool isIncludeLabs)
    {

        Connection_StringCLS sConn = new Connection_StringCLS(Campus);

        string sSQL = "SELECT intStudyYear";
        sSQL += " , byteSemester";
        sSQL += " , byteShift";
        sSQL += " , strShortcut";
        sSQL += " , strCourse";
        sSQL += " , byteClass";
        sSQL += " , strHall";
        sSQL += " , dateTimeFrom";
        sSQL += " , dateTimeTo";
        sSQL += " , days";
        sSQL += " , intLecturer ";
        sSQL += " FROM dbo.Classes_All";
        sSQL += " Where 1=1 "; 
        if (!isIncludeLabs)
        {
            sSQL += " AND bLab=0";
        }
       
        if (iLecturer > 0)
        {
            ECTNewLecturersDAL myLecturersDAL = new ECTNewLecturersDAL();
            List<ECTNewLecturers> myLecturers = new List<ECTNewLecturers>();
            myLecturers = myLecturersDAL.GetLecturers(InitializeModule.EnumCampus.ECTNew, " Where LecturerID=" + iLecturer, false);
            int myLecturer = 0;
            string myCollege = "";
            if (myLecturers.Count > 0)
            {
                if (Campus == InitializeModule.EnumCampus.Females)
                {
                    myLecturer = myLecturers[0].FCampusID;
                }
                else
                {
                    myLecturer = myLecturers[0].MCampusID;
                }
                myCollege = Convert.ToString(myLecturers[0].CollegeID);
                myLecturers.Clear();
            }

            sSQL += " And intLecturer=" + myLecturer;
        }
        sSQL += " And intStudyYear=" + iYear;
        sSQL += " And byteSemester=" + bSemester;



        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<ClassesCLS> results = new List<ClassesCLS>();
        try
        {
            while (Rd.Read())
            {
                ClassesCLS classes = new ClassesCLS();
                classes.StudyYear = Convert.ToInt32(Rd["intStudyYear"]);
                classes.Semester = Convert.ToByte(Rd["byteSemester"]);
                classes.Shift = Convert.ToByte(Rd["byteShift"]);
                classes.Shortcut = Rd["strShortcut"].ToString();
                classes.Course = Rd["strCourse"].ToString();
                classes.AttClass = Convert.ToByte(Rd["byteClass"]);
                classes.Hall = Rd["strHall"].ToString();
                classes.TimeFrom = Convert.ToDateTime(Rd["dateTimeFrom"].ToString()).ToShortTimeString();
                classes.TimeTo = Convert.ToDateTime(Rd["dateTimeTo"].ToString()).ToShortTimeString();
                classes.Days = Rd["Days"].ToString();
                classes.Lecturer = Convert.ToInt32(Rd["intLecturer"]);


                results.Add(classes);

            }
        }
        catch (Exception ex)
        {
        }
        finally
        {

            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return results;
    }

    public List<ClassesCLS> GetClasses(InitializeModule.EnumCampus Campus, int iYear, byte bSemester,byte bPeriod,string sCourse,byte bClass)
    {

        Connection_StringCLS sConn = new Connection_StringCLS(Campus);

        string sSQL = "SELECT intStudyYear";
        sSQL += " , byteSemester";
        sSQL += " , byteShift";
        sSQL += " , strShortcut";
        sSQL += " , strCourse";
        sSQL += " , byteClass";
        sSQL += " , strHall";
        sSQL += " , dateTimeFrom";
        sSQL += " , dateTimeTo";
        sSQL += " , days";
        sSQL += " , intLecturer ";
        sSQL += " FROM dbo.Classes_All";

        sSQL += " Where intStudyYear=" + iYear;
        sSQL += " And byteSemester=" + bSemester;
        sSQL += " And byteShift=" + bPeriod;
        sSQL += " And strCourse='" + sCourse  + "'";
        sSQL += " And byteClass=" + bClass;
        
        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<ClassesCLS> results = new List<ClassesCLS>();
        try
        {
            while (Rd.Read())
            {
                ClassesCLS classes = new ClassesCLS();
                classes.StudyYear = Convert.ToInt32(Rd["intStudyYear"]);
                classes.Semester = Convert.ToByte(Rd["byteSemester"]);
                classes.Shift = Convert.ToByte(Rd["byteShift"]);
                classes.Shortcut = Rd["strShortcut"].ToString();
                classes.Course = Rd["strCourse"].ToString();
                classes.AttClass = Convert.ToByte(Rd["byteClass"]);
                classes.Hall = Rd["strHall"].ToString();
                classes.TimeFrom = Convert.ToDateTime(Rd["dateTimeFrom"].ToString()).ToShortTimeString();
                classes.TimeTo = Convert.ToDateTime(Rd["dateTimeTo"].ToString()).ToShortTimeString();
                classes.Days = Rd["Days"].ToString();
                classes.Lecturer = Convert.ToInt32(Rd["intLecturer"]);


                results.Add(classes);

            }
        }
        catch (Exception ex)
        {
        }
        finally
        {

            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return results;
    }

    public List<ClassesCLS> GetClasses(InitializeModule.EnumCampus Campus, string Condition, int iYear, byte bSemester)
    {

        Connection_StringCLS sConn = new Connection_StringCLS(Campus);


        string sSQL = "SELECT intStudyYear, byteSemester, byteShift, strShortcut";
        sSQL += " , strCourse, byteClass, strHall, dateTimeFrom, dateTimeTo";
        sSQL += " , days, intLecturer FROM dbo.Classes_All";

        if (Condition != "" && Condition != "vbNullString")
        {
            if (Condition.Contains("Where") == true)
            {
                sSQL = sSQL + Condition;
            }
            else
            {

                ECTNewLecturersDAL myLecturersDAL = new ECTNewLecturersDAL();
                List<ECTNewLecturers> myLecturers = new List<ECTNewLecturers>();
                myLecturers = myLecturersDAL.GetLecturers(InitializeModule.EnumCampus.ECTNew, " Where LecturerID=" + Condition, false);
                int myLecturer = 0;
                if (myLecturers.Count > 0)
                {
                    if (Campus == InitializeModule.EnumCampus.Females)
                    {
                        myLecturer = myLecturers[0].FCampusID;
                    }
                    else
                    {
                        myLecturer = myLecturers[0].MCampusID;
                    }
                    myLecturers.Clear();
                }

                sSQL = sSQL + " Where intLecturer=" + myLecturer;
                sSQL += " And intStudyYear=" + iYear;
                sSQL += " And byteSemester=" + bSemester;     
            }
        }

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<ClassesCLS> results = new List<ClassesCLS>();
        try
        {
            while (Rd.Read())
            {
                ClassesCLS classes = new ClassesCLS();
                classes.StudyYear = Convert.ToInt32(Rd["intStudyYear"]);
                classes.Semester = Convert.ToByte(Rd["byteSemester"]);
                classes.Shift = Convert.ToByte(Rd["byteShift"]);
                classes.Shortcut = Rd["strShortcut"].ToString();
                classes.Course = Rd["strCourse"].ToString();
                classes.AttClass = Convert.ToByte(Rd["byteClass"]);
                classes.Hall = Rd["strHall"].ToString();
                classes.TimeFrom = Convert.ToDateTime(Rd["dateTimeFrom"].ToString()).ToShortTimeString();
                classes.TimeTo = Convert.ToDateTime(Rd["dateTimeTo"].ToString()).ToShortTimeString();
                classes.Days = Rd["Days"].ToString();
                classes.Lecturer = Convert.ToInt32(Rd["intLecturer"]);


                results.Add(classes);

            }
        }
        catch (Exception ex)
        {
        }
        finally
        {

            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return results;
    }
} 

