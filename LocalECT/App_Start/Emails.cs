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
using System.Data.SqlClient; 
using System.Collections.Generic; 

public class Current_Courses 
{ 
    #region "Private Member Variables" 
    private byte _bShift;
    private string _sCourse;
    private byte _bClass;
    #endregion 
    
    #region "Constructors" 
    
    public Current_Courses () 
    { 
    } 
    public Current_Courses (byte bShift,string sCourse,byte bClass)
    {
        this._bShift = bShift;
        this._sCourse = sCourse;
        this._bClass = bClass;
    } 
    
    #endregion 
    
    #region "Public Properties"  

    public byte BShift
    {
        get { return _bShift; }
        set { _bShift = value; }
    }

    public string SCourse
    {
        get { return _sCourse; }
        set { _sCourse = value; }
    }

    public byte BClass
    {
        get { return _bClass; }
        set { _bClass = value; }
    }  
    
    #endregion 
} 


public class Emails
{ 
    
    
    #region "Private Member Variables" 
        
    private string _sStudentNo;
    private string _sFirstName;
    private string _sFullName;
    private string _sEmail;
    private string _sPassword;
    private List<Current_Courses> _CoursesList;
    private int _DataStatus; 
    private int _isDataChanged; 
    
    #endregion 
    
    #region "Constructors" 
    
    public Emails() 
    { 
    }
    public Emails(string sStudentNo, string sFirstName, string sFullName, string sEmail, string sPassword, List<Current_Courses> CoursesList) 
    {
        this._sStudentNo = sStudentNo;
        this._sFirstName = sFirstName;
        this._sFullName = sFullName;
        this._sEmail = sEmail;
        this._sPassword = sPassword;
        this._CoursesList = CoursesList;
        this._DataStatus = 0; 
        this._isDataChanged = 0; 
    } 
    
    #endregion 
    
    #region "Public Properties"

    public string SStudentNo
    {
        get { return _sStudentNo; }
        set { _sStudentNo = value; }
    }

    public string SFirstName
    {
        get { return _sFirstName; }
        set { _sFirstName = value; }
    }

    public string SFullName
    {
        get { return _sFullName; }
        set { _sFullName = value; }
    }

    public string SEmail
    {
        get { return _sEmail; }
        set { _sEmail = value; }
    }

    public string SPassword
    {
        get { return _sPassword; }
        set { _sPassword = value; }
    }

    public List<Current_Courses> CoursesList
    {
        get { return _CoursesList; }
        set { _CoursesList = value; }
    }
    
    
    
    public int DataStatus { 
        get { return _DataStatus; } 
        set { _DataStatus = value; } 
    } 
    
    public int isDataChanged { 
        get { return _isDataChanged; } 
        set { _isDataChanged = value; }
    }

    
    
    
    #endregion 
    
    
    
} 

public class EmailsDAL 
{

    public List<Emails> GetEmails(InitializeModule.EnumCampus Campus, int StudyYear, byte Semester, byte Shift, string Course, byte bClass, string sStudentNo,bool isCreate) 
    { 
        
        // returns a list of Classes instances based on the 
        // data in the Classes View 
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        
        string sSql = "SELECT A.lngStudentNumber, SD.strFirstDescEn as FirstName, SD.strLastDescEn as FullName, E.sEmail, E.sPassword, CB.Shift, CB.Course, CB.Class";
        sSql+=" FROM dbo.Reg_Applications AS A INNER JOIN dbo.Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN";
        sSql+=" dbo.Course_Balance_View AS CB ON A.lngStudentNumber = CB.Student LEFT OUTER JOIN dbo.Reg_Students_Emails AS E ON A.lngStudentNumber = E.sStudentNo";
        sSql+=" WHERE (CB.iYear ="+ StudyYear +") AND (CB.Sem ="+ Semester +") ";
        sSql+=" AND (A.byteStudentType = 0 OR A.byteStudentType IS NULL)";

        if (Shift > 0)
        {
            sSql += " AND SD.byteShift ="+Shift;
        }
        else
        {
            switch (Campus)
            {
                case InitializeModule.EnumCampus.Females :
                    sSql += " AND (SD.byteShift = 1 OR SD.byteShift = 2 OR SD.byteShift = 9)";
                    break;
                case InitializeModule.EnumCampus.Males:
                    sSql += " AND (SD.byteShift = 3 OR SD.byteShift = 4 OR SD.byteShift = 8)";
                    break;
            }
        }
        if (!string.IsNullOrEmpty(Course))
        {
            sSql += " AND CB.Course ='" + Course +"'";

        }
        if (bClass > 0)
        {
            sSql += " AND CB.Class =" + bClass ;
        }
        if (!string.IsNullOrEmpty(sStudentNo))
        {
            sSql += " AND A.lngStudentNumber ='" + sStudentNo + "'";


        }
        

        
        SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string);
        myConnection.Open();
        string sCountSQL = "SELECT  COUNT(sStudentNo) AS ECount FROM  dbo.Reg_Students_Emails AS SE";
        SqlCommand cmd = new SqlCommand(sCountSQL, myConnection);
        int iCount =(int) cmd.ExecuteScalar();


        SqlCommand myCommand = new SqlCommand(sSql, myConnection); 
        
        
        SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection); 
        List<Emails> results = new List<Emails>(); 
        string sNo = null;
        Emails MyEmail = new Emails(); 
        //Dim myGradesTypes As New List(Of GradesTypes) 
        Current_Courses MyCourses = new Current_Courses();
        string sStNo = "";
        string sCurrentStNo = "";
        try { 
            while (reader.Read()) {
                sStNo = reader["lngStudentNumber"].ToString();
                if (sCurrentStNo != sStNo)
                {
                    if (sCurrentStNo != "")
                    {
                        results.Add(MyEmail);
                    }
                    sCurrentStNo = sStNo;
                    MyEmail = new Emails(); 
                    MyEmail.CoursesList = new List<Current_Courses>();

                    MyEmail.SStudentNo = reader["lngStudentNumber"].ToString();
                    MyEmail.SFirstName=reader["FirstName"].ToString();
                    MyEmail.SFullName = reader["FullName"].ToString();

                    if (string.IsNullOrEmpty(reader["sEmail"].ToString()))
                    {
                        if (isCreate)
                        {
                            iCount += 1;
                            string sEmail = MyEmail.SStudentNo + "@ectuae.com";
                            string sPwd = "";
                            //Password Encryption 
                            EncryptionCls theEncryption = new EncryptionCls();

                            string sEncryptedPwd = theEncryption.getMd5Hash(sPwd);

                            switch (Campus)
                            {
                                case InitializeModule.EnumCampus.Females :
                                    sPwd = "F";
                                    break;
                                case InitializeModule.EnumCampus.Males:
                                    sPwd = "M";
                                    break;
                            }
                            int iYear=DateTime.Today.Year;
                            iYear*=100;
                            iYear += DateTime.Today.Month;
                            iYear *= 1000;
                            iYear+=iCount;
                            sPwd += iYear.ToString();

                            MyEmail.SEmail = sEmail;
                            MyEmail.SPassword = sPwd;
                            //MyEmail.SPassword = sEncryptedPwd;
                        }
                    }
                    else
                    {

                        MyEmail.SEmail = reader["sEmail"].ToString();
                        MyEmail.SPassword = reader["sPassword"].ToString();
                    }

                    if (!(reader["sEmail"].Equals(DBNull.Value)))
                    { 
                        MyEmail.DataStatus = 1; 
                    } 
                    else 
                    {
                        MyEmail.DataStatus = 0; 
                    } 
                                            
                    MyEmail.isDataChanged = 0; 
                } 
                
                MyCourses = new Current_Courses(); 
                
                //'//Fill Courses
 
                //, CB.Class                    
                MyCourses.BShift=Convert.ToByte(reader["Shift"]);
                MyCourses.SCourse = reader["Course"].ToString();
                MyCourses.BClass = Convert.ToByte(reader["Class"]);

                MyEmail.CoursesList.Add(MyCourses);
                                                
            }
            results.Add(MyEmail);
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

    //public void UpdateGrades(int StudyYear, byte Semester, byte Shift, string Course, byte bClass, string StudentNumber,
    //decimal Mark, string Grade,string Degree,string Major,int FGP,int FGPReady, List<GradesTypes> GradesDatails,
    //int DataStatus,InitializeModule.EnumCampus Campus, string sUser) 
    //{

    //    Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);

    //    SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string); 
    //    SqlCommand myCommand = new SqlCommand(); 
    //    try { 
                       
    //        myConnection.Open(); 
            
    //        string sSQL = null; 
    //        string sCon = null; 
    //        string sExec = null; 
    //        int iDetail = 0; 
            
    //        if (DataStatus == 1) { 
                
    //            //'//Update Header 
    //            sSQL = "Update Reg_Grade_Header Set"; 
    //            sSQL = sSQL + " curUseMark=@Mark,"; 
    //            sSQL = sSQL + " strGrade=@Grade,"; 
    //            sSQL = sSQL + " strUserSave=@User,"; 
    //            sSQL = sSQL + " dateLastSave=@Date,"; 
    //            sSQL = sSQL + " strNUser='ECTLocal'"; 
    //            sCon = " Where "; 
    //            sCon = sCon + " intStudyYear=@StudyYear"; 
    //            sCon = sCon + " And byteSemester=@Semester"; 
    //            sCon = sCon + " And strCourse=@Course"; 
    //            sCon = sCon + " And byteClass=@Class"; 
    //            sCon = sCon + " And byteShift=@Shift"; 
    //            sCon = sCon + " And lngStudentNumber=@StudentNumber"; 
                
    //            sExec = sSQL + sCon; 
                
    //            myCommand = new SqlCommand(sExec, myConnection); 
                
    //            myCommand.Parameters.Add(new SqlParameter("@StudyYear", StudyYear)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Semester", Semester)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Shift", Shift)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Course", Course)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Class", bClass)); 
    //            myCommand.Parameters.Add(new SqlParameter("@StudentNumber", StudentNumber)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Mark", Mark)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Grade", Grade)); 
    //            myCommand.Parameters.Add(new SqlParameter("@User", sUser)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Date", DateTime.Today.Date)); 
                    
    //            myCommand.ExecuteNonQuery(); 
    //        } 
    //        else 
    //        { 
    //            //'//Insert Header 
                
    //            sSQL = "Insert Into Reg_Grade_Header"; 
    //            sSQL = sSQL + " (intStudyYear,byteSemester,byteShift,strCourse,"; 
    //            sSQL = sSQL + " byteClass, lngStudentNumber, curUseMark, strGrade, ";
    //            sSQL = sSQL + " strDegree,strMajor,";
    //            sSQL = sSQL + "strUserCreate, dateCreate, strNUser) Values("; 
    //            sSQL = sSQL + " @StudyYear,"; 
    //            sSQL = sSQL + " @Semester,"; 
    //            sSQL = sSQL + " @Shift,"; 
    //            sSQL = sSQL + " @Course,"; 
    //            sSQL = sSQL + " @Class,"; 
    //            sSQL = sSQL + " @StudentNumber,"; 
    //            sSQL = sSQL + " @Mark,"; 
    //            sSQL = sSQL + " @Grade,";
    //            sSQL = sSQL + " @Degree,";
    //            sSQL = sSQL + " @Major,";
    //            sSQL = sSQL + " @User,"; 
    //            sSQL = sSQL + " @Date,"; 
    //            sSQL = sSQL + " 'ECTLocal')"; 
                
    //            sExec = sSQL; 
                
    //            myCommand = new SqlCommand(sExec, myConnection); 
                
    //            myCommand.Parameters.Add(new SqlParameter("@StudyYear", StudyYear)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Semester", Semester)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Shift", Shift)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Course", Course)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Class", bClass)); 
    //            myCommand.Parameters.Add(new SqlParameter("@StudentNumber", StudentNumber)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Mark", Mark)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Grade", Grade));
    //            myCommand.Parameters.Add(new SqlParameter("@Degree", Degree));
    //            myCommand.Parameters.Add(new SqlParameter("@Major", Major)); 
    //            myCommand.Parameters.Add(new SqlParameter("@User", sUser)); 
    //            myCommand.Parameters.Add(new SqlParameter("@Date", DateTime.Today.Date)); 
                
                    
    //            myCommand.ExecuteNonQuery(); 
    //        } 

    //        //apply forgivness
    //        if ((Grade != "F") && (Grade != "I") && (Grade != "NG") && (Grade != "EW") && (Grade != "W") && (Grade != "NC"))
    //        {
    //            if ((FGP < 2) && (FGPReady>0))
    //            {
    //                sSQL = "UPDATE Reg_Grade_Header SET bDisActivated = 1";
    //                sSQL += " WHERE (lngStudentNumber = '"+ StudentNumber +"') AND (strCourse = '"+ Course +"') AND (intStudyYear = "+ StudyYear +") AND (byteSemester < "+ Semester +") AND (strGrade IN ('F', 'D')) AND (bDisActivated = 0)";
    //                sSQL += " OR (lngStudentNumber = '" + StudentNumber + "') AND (strCourse = '" + Course + "') AND (intStudyYear < " + StudyYear + ") AND (strGrade IN ('F', 'D')) AND (bDisActivated = 0)";

    //                myCommand.CommandText = sSQL;
    //                myCommand.ExecuteNonQuery();
                      
    //            }
    //        }
            
                        
    //        //'//Update or Insert Detail 
    //        sSQL = "Delete From Reg_Grade_Detail Where"; 
    //        sCon = " intStudyYear=@StudyYear And"; 
    //        sCon = sCon + " byteSemester=@Semester And"; 
    //        sCon = sCon + " strCourse=@Course And"; 
    //        sCon = sCon + " byteClass=@Class And"; 
    //        sCon = sCon + " byteShift=@Shift And"; 
    //        sCon = sCon + " lngStudentNumber=@StudentNumber"; 
            
    //        sExec = sSQL + sCon; 
    //        myCommand.CommandText = sExec; 
    //        myCommand.ExecuteNonQuery(); 
            
    //        sSQL = "Insert Into Reg_Grade_Detail"; 
    //        sSQL = sSQL + " (intStudyYear, byteSemester, byteShift, strCourse,"; 
    //        sSQL = sSQL + "byteClass, lngStudentNumber, byteGradeType, curGrade)"; 
    //        sSQL = sSQL + " Values("; 
    //        sSQL = sSQL + " @StudyYear,"; 
    //        sSQL = sSQL + " @Semester,"; 
    //        sSQL = sSQL + " @Shift,"; 
    //        sSQL = sSQL + " @Course,"; 
    //        sSQL = sSQL + " @Class,"; 
    //        sSQL = sSQL + " @StudentNumber,"; 
    //        sSQL = sSQL + " @GradeType,"; 
    //        sSQL = sSQL + " @Grade)"; 
            
    //        sExec = sSQL; 
    //        myCommand.CommandText = sExec; 
            
    //        myCommand.Parameters.Add(new SqlParameter("@GradeType", 1));
    //        for (iDetail = 0; iDetail <= GradesDatails.Count - 1; iDetail++)
    //        {
    //            if (GradesDatails[iDetail].Grade  != -1)
    //            {                     
    //                myCommand.Parameters.RemoveAt("@GradeType"); 
    //                myCommand.Parameters.RemoveAt("@Grade"); 
                    
    //                myCommand.Parameters.Add(new SqlParameter("@GradeType", GradesDatails[iDetail].GradeType));
    //                myCommand.Parameters.Add(new SqlParameter("@Grade", GradesDatails[iDetail].Grade)); 
                    
    //                myCommand.ExecuteNonQuery(); 
                    
    //            } 
                
    //        } 
    //    } 
    //    catch (Exception ex) {
    //        LibraryMOD.ShowErrorMessage(ex);
    //    } 
    //    finally { 
    //        myConnection.Close();
    //        myConnection.Dispose();
    //    } 
    //} 
    
} 


