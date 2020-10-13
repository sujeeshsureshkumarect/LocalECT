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

public class GradesTypes 
{ 
    #region "Private Member Variables" 
    private byte _GradeType; 
    private string _GradeDesc; 
    private decimal _Percentage; 
    private decimal _Grade; 
    private byte _Order;
    private byte _bHidden;
    private int _DataStatus; 
    private int _isDataChanged; 
    #endregion 
    
    #region "Constructors" 
    
    public GradesTypes() 
    { 
    }
    public GradesTypes(byte GradeType, string GradeDesc, decimal Percentage, decimal Grade, byte Order, byte bHidden) 
    { 
        this._GradeType = GradeType; 
        this._GradeDesc = GradeDesc; 
        this._Percentage = Percentage; 
        this._Grade = Grade; 
        this._Order = Order;
        this._bHidden = bHidden;
        this._DataStatus = 0; 
        this._isDataChanged = 0; 
    } 
    
    #endregion 
    
    #region "Public Properties" 
    
    public byte GradeType { 
        get { return _GradeType; } 
        set { _GradeType = value; } 
    } 
    
    public string GradeDesc { 
        get { return _GradeDesc; } 
        set { _GradeDesc = value; } 
    } 
    
    public decimal Percentage { 
        get { return _Percentage; } 
        set { _Percentage = value; } 
    } 
    
    public decimal Grade { 
        get { return _Grade; } 
        set { _Grade = value; } 
    } 
    
    public byte Order { 
        get { return _Order; } 
        set { _Order = value; }
    }

    public byte BHidden
    {
        get { return _bHidden; }
        set { _bHidden = value; }
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

public class GradesTypesDAL 
{
    public List<GradesTypes> GetGradesTypes(InitializeModule.EnumCampus Campus, string sCourse, int iYear, byte iSem, bool bIsShowFinalExam_Midterm = true) 
    { 
        
        // returns a list of Classes instances based on the 
        // data in the Classes View
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);  
              
        string sql = "SELECT GC.byteGradeType, GT.strGradeDesc, GC.curPercentage,GT.byteHidden";
        sql+=" FROM Reg_Grades_Distributions AS dis INNER JOIN Reg_Grades_Taype_Courses AS GC INNER JOIN";
        sql += " Reg_Grade_Types AS GT ON GC.byteGradeType = GT.byteGradeType ON dis.intDistribution = GC.intDistribution";
        //sql+= " FROM Reg_Grades_Distributions AS dis INNER JOIN  Reg_Grades_Taype_Courses AS GC INNER JOIN";
        //sql+= " Reg_Grade_Types AS GT ON GC.byteGradeType = GT.byteGradeType ON dis.intDistribution = GC.intDistribution INNER JOIN";
        //sql += " Cmn_Firm ON dis.byteSemester = Cmn_Firm.byteCurrentSemester AND dis.intStudyYear = Cmn_Firm.intCurrentYear";
        sql += " Where dis.intStudyYear ="+iYear ;
        sql += " AND dis.byteSemester =" + iSem;

        if (!bIsShowFinalExam_Midterm)
        {
            sql += " And GC.byteGradeType<> 14 And GC.byteGradeType<> 3  And GC.byteGradeType<> 57 ";
        }

        if (!string.IsNullOrEmpty(sCourse)) { 
            sql = sql + " And GC.strCourse='" + sCourse + "'"; 
        } 
        
        sql += " Order By GC.byteOrder"; 
        
        SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string); 
        
        SqlCommand myCommand = new SqlCommand(sql, myConnection); 
        myConnection.Open(); 
        SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection); 
        List<GradesTypes> results = new List<GradesTypes>(); 
        try { 
            while (reader.Read()) { 
                GradesTypes Grades = new GradesTypes(); 
                Grades.GradeType = Convert.ToByte(reader["byteGradeType"]); 
                Grades.GradeDesc = (reader["strGradeDesc"]).ToString(); 
                Grades.Percentage = Convert.ToDecimal(reader["CurPercentage"]);
                Grades.BHidden = Convert.ToByte(reader["byteHidden"]);
                results.Add(Grades); 
                
            } 
        } 
        catch (Exception ex) {
            LibraryMOD.ShowErrorMessage(ex);
        } 
        finally { 
            reader.Close();
            reader.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        } 
        return results; 
    } 
} 

public class Grades 
{ 
    
    
    #region "Private Member Variables" 
        
    private int _StudyYear; 
    private byte _Semester; 
    private byte _Shift; 
    private string _Course; 
    private byte _bClass; 
    private string _Stno; 
    private string _SName;
    private string _SEmail; 
    private decimal _Mark; 
    private string _Grade; 
    private List<GradesTypes> _GradesDatails;
    private string _Degree;
    private string _Major;
    private int _FGP;//Forgivness Applied Times
    private int _FGPReady;//Ready F & D Marks to be Forgiven for the same course
    private bool _isHidden;
    private string _Remind;
    private int _DataStatus; 
    private int _isDataChanged;
    private decimal _CGPA;
    private int _IsIncluded_AtRisk;

    #endregion 
    
    #region "Constructors" 
    
    public Grades() 
    { 
    }
    public Grades(int StudyYear, byte Semester, byte Shift, string Course, byte bClass, string Stno,
    string SName, string SEmail, decimal Mark, string Grade, List<GradesTypes> GradesDatails, string Degree, string Major, int FGP, int FGPReady, bool isHidden, string Remind) 
    { 
        this._StudyYear = StudyYear; 
        this._Semester = Semester; 
        this._Shift = Shift; 
        this._Course = Course; 
        this._bClass = bClass; 
        this._Stno = Stno; 
        this._SName = SName;
        this._SEmail = SEmail; 
        this._Mark = Mark; 
        this._Grade = Grade;
        this._GradesDatails = GradesDatails;
        this._Degree = Degree;
        this._Major = Major;
        this._FGP = FGP;
        this._FGPReady = FGPReady;
        this._isHidden = isHidden;
        this._Remind = Remind;
        this._DataStatus = 0; 
        this._isDataChanged = 0;
        this._CGPA = 0;
        this._IsIncluded_AtRisk = 0;
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
    
    public string Course { 
        get { return _Course; } 
        set { _Course = value; } 
    } 
    
    public byte bClass { 
        get { return _bClass; } 
        set { _bClass = value; } 
    } 
    
    public string Stno { 
        get { return _Stno; } 
        set { _Stno = value; } 
    } 
    
    public string SName { 
        get { return _SName; } 
        set { _SName = value; } 
    }
    public string SEmail
    {
        get { return _SEmail; }
        set { _SEmail = value; }
    } 
    public decimal Mark { 
        get { return _Mark; } 
        set { _Mark = value; } 
    } 
    
    public string Grade { 
        get { return _Grade; } 
        set { _Grade = value; } 
    }

    public List<GradesTypes> GradesDatails
    {
        get { return _GradesDatails; }
        set { _GradesDatails = value; }
    }

    public string Degree
    {
        get { return _Degree; }
        set { _Degree = value; }
    }

    public string Major
    {
        get { return _Major; }
        set { _Major = value; }
    }

    public int FGP
    {
        get { return _FGP; }
        set { _FGP = value; }
    }

    public int FGPReady
    {
        get { return _FGPReady; }
        set { _FGPReady = value; }
    } 
    
    public int DataStatus { 
        get { return _DataStatus; } 
        set { _DataStatus = value; } 
    } 
    
    public int isDataChanged { 
        get { return _isDataChanged; } 
        set { _isDataChanged = value; }
    }

    public bool IsHidden
    {
        get { return _isHidden; }
        set { _isHidden = value; }
    }

    public string Remind
    {
        get { return _Remind; }
        set { _Remind = value; }
    }
    public decimal CGPA
    {
        get { return _CGPA; }
        set { _CGPA = value; }
    }
    public int IsIncluded_AtRisk
    {
        get { return _IsIncluded_AtRisk; }
        set { _IsIncluded_AtRisk = value; }
    }
    

    #endregion 
    
    
    
} 

public class GradesDAL 
{ 
    
    public List<Grades> GetGrades(InitializeModule.EnumCampus Campus, int StudyYear, byte Semester, byte Shift, string Course, string bClass, int iGradesTypeCount,bool isFinalShown ) 
    { 
        
        // returns a list of Classes instances based on the 
        // data in the Classes View 
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        
        string sql ="SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass,";
        sql+="lngStudentNumber,Name,curUseMark, strGrade,byteGradeType, curPercentage,";
        sql += " byteOrder, curGrade,strDegree,strSpecialization,FGPCounts,FGPReady,isHidden,byteHidden,intRemind,CGPA ";
        sql+=" From dbo.GD_Dis";
        sql+=" Where intStudyYear=" + StudyYear + " And byteSemester=" + Semester;
        sql+=" And byteShift=" + Shift + " And strCourse='" + Course + "' And byteClass=" + bClass;
        sql+=" Order By intStudyYear, byteSemester, byteShift, strCourse, byteClass, Name,byteOrder";
        
        SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string); 
        
        SqlCommand myCommand = new SqlCommand(sql, myConnection); 
        myConnection.Open(); 
        SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection); 
        List<Grades> results = new List<Grades>(); 
        string sNo = null; 
        Grades MyGrades = new Grades(); 
        //Dim myGradesTypes As New List(Of GradesTypes) 
        GradesTypes MyGradeType = new GradesTypes(); 
        int iGradesCounter = 0; 
        try { 
            while (reader.Read()) { 
                
                if (iGradesCounter == 0) { 
                    MyGrades = new Grades(); 
                    MyGrades.GradesDatails = new List<GradesTypes>(); 
                    
                    MyGrades.StudyYear = Convert.ToInt32(reader["intStudyYear"]); 
                    MyGrades.Semester = Convert.ToByte(reader["byteSemester"]); 
                    MyGrades.Shift = Convert.ToByte(reader["byteShift"]); 
                    MyGrades.Course = reader["strCourse"].ToString(); 
                    MyGrades.bClass = Convert.ToByte(reader["byteClass"]); 
                    MyGrades.Stno = reader["lngStudentNumber"].ToString(); 
                    MyGrades.SName = reader["Name"].ToString();
                    MyGrades.Degree = reader["strDegree"].ToString();
                    MyGrades.Major = reader["strSpecialization"].ToString();

                    if (!(reader["intRemind"].Equals(DBNull.Value)))
                    {
                        MyGrades.Remind = reader["intRemind"].ToString();

                    }
                    else
                    {
                        MyGrades.Remind = "";
                    }

                    if (!(reader["FGPCounts"].Equals(DBNull.Value)))
                    {
                        MyGrades.FGP = int.Parse(reader["FGPCounts"].ToString());
                        
                    }
                    else
                    {
                        MyGrades.FGP = 0;
                    }

                    if (!(reader["FGPReady"].Equals(DBNull.Value)))
                    {
                        MyGrades.FGPReady = int.Parse(reader["FGPReady"].ToString());
                    }
                    else
                    {
                        MyGrades.FGPReady = 0;
                    }

                    if (!(reader["isHidden"].Equals(DBNull.Value)))
                    {
                        MyGrades.IsHidden = bool.Parse(reader["isHidden"].ToString());
                    }
                    else
                    {
                        MyGrades.IsHidden = false;
                    }
 
                    if (!(reader["curUseMark"].Equals(DBNull.Value))) { 
                        MyGrades.DataStatus = 1; 
                        MyGrades.Mark = Convert.ToDecimal(reader["curUseMark"]); 
                    } 
                    else 
                    { 
                        MyGrades.DataStatus = 0; 
                    } 
                    MyGrades.Grade = reader["strGrade"].ToString(); 
                        
                    MyGrades.isDataChanged = 0;
                    MyGrades.CGPA = Convert.ToDecimal(reader["CGPA"]);
                  
                } 
                
                MyGradeType = new GradesTypes(); 
                
                //'//Fill Grades Type 
                
                MyGradeType.GradeType = Convert.ToByte(reader["byteGradeType"]); 
                MyGradeType.GradeDesc = null; 
                MyGradeType.Percentage = Convert.ToDecimal(reader["curPercentage"]); 
                MyGradeType.Order = Convert.ToByte(reader["byteOrder"]); 
                if (reader["curGrade"].Equals(DBNull.Value)) { 
                    MyGradeType.DataStatus = 0; 
                    //New Record 
                    MyGradeType.Grade = -1; 
                } 
                else { 
                    MyGradeType.DataStatus = 1; 
                    //Old Record 
                    MyGradeType.Grade = Convert.ToDecimal(reader["curGrade"]);
                    //Hide Final Grades
                    if (!isFinalShown)
                    {
                        MyGradeType.BHidden = Convert.ToByte(reader["byteHidden"]);
                        switch (MyGradeType.BHidden)
                        {
                            case 1:
                                if (MyGrades.Grade == "EW" || MyGrades.Grade == "W" || MyGrades.Grade == "I")
                                {
                                    MyGradeType.Grade = -1;
                                }

                                break;
                            case 2:
                                if (MyGrades.Grade == "W")
                                {
                                    MyGradeType.Grade = -1;
                                }

                                break;
                        }
                    }

                }

                
                
                MyGradeType.isDataChanged = 0;

                MyGrades.GradesDatails.Add(MyGradeType); 
                
                iGradesCounter += 1; 
                if (iGradesCounter == iGradesTypeCount) { 
                    results.Add(MyGrades); 
                    iGradesCounter = 0; 
                    
                } 
                
            } 
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

    public List<Grades> GetGrades(InitializeModule.EnumCampus Campus, int StudyYear, byte Semester, byte Shift, string Course, string bClass, int iGradesTypeCount, bool isFinalShown, string sStudent, int iLecturer=0, bool bIsShowFinalExam_Midterm=true)
    {

        // returns a list of Classes instances based on the 
        // data in the Classes View 
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
       
        int iPreYear = StudyYear;
        int iPreSem = Semester;

        if (Semester == 1)
        {
            iPreSem = 4;
            iPreYear = StudyYear - 1;
        }
        else
        {
            iPreSem = Semester - 1;
            iPreYear = StudyYear;
        }
        //string sql = "SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass,";
        //sql += "lngStudentNumber,Name,curUseMark, strGrade,byteGradeType, curPercentage,";
        //sql += " byteOrder, curGrade,strDegree,strSpecialization,FGPCounts,FGPReady,isHidden,byteHidden,intRemind,CGPA ";
        //sql += " From dbo.GD_Dis";

        string sql = "SELECT DISTINCT GD_Dis.intStudyYear, GD_Dis.byteSemester, GD_Dis.byteShift, GD_Dis.strCourse, GD_Dis.byteClass";
        sql += ", GD_Dis.lngStudentNumber, GD_Dis.Name,GD_Dis.sECTemail ";
        sql += ", GD_Dis.curUseMark, GD_Dis.strGrade, GD_Dis.byteGradeType, GD_Dis.curPercentage, GD_Dis.byteOrder, GD_Dis.curGrade, GD_Dis.strDegree,";
        sql += " GD_Dis.strSpecialization, GD_Dis.FGPCounts, GD_Dis.FGPReady";
        sql += ", GD_Dis.isHidden, GD_Dis.byteHidden, GD_Dis.intRemind";
        sql += ", SCGPA.CGPA,GD_Dis.IsIncluded_AtRisk"; //, CTS.intLecturer

        sql += " FROM GD_Dis INNER JOIN";

        sql += " (SELECT     A.lngStudentNumber, dbo.GetCGPA(A.lngStudentNumber, " + iPreYear + "," + iPreSem + ", ISNULL(M.strDegree, A.strDegree), ISNULL(M.strMajor, A.strSpecialization)) AS CGPA";
        sql += " FROM Reg_Applications AS A LEFT OUTER JOIN";
        sql += " (SELECT lngStudentNumber, strDegree, strMajor FROM Reg_Student_Majors AS SM";
        sql += " WHERE (intStudyYear = " + StudyYear + ") AND (byteSemester =" + Semester +")) AS M ON A.lngStudentNumber = M.lngStudentNumber) AS SCGPA ";
        sql += " ON  GD_Dis.lngStudentNumber = SCGPA.lngStudentNumber";
        sql += " INNER JOIN dbo.Reg_CourseTime_Schedule AS CTS ON dbo.GD_Dis.intStudyYear = CTS.intStudyYear ";
        sql += " AND dbo.GD_Dis.byteSemester = CTS.byteSemester AND dbo.GD_Dis.strCourse = CTS.strCourse";
        sql += " AND dbo.GD_Dis.byteShift = CTS.byteShift AND dbo.GD_Dis.byteClass = CTS.byteClass";

        sql += " Where  GD_Dis.intStudyYear=" + StudyYear + " And GD_Dis.byteSemester=" + Semester;
        sql += " And  GD_Dis.strCourse='" + Course + "'";

        if (!bIsShowFinalExam_Midterm)
        {
            sql += " And GD_Dis.byteGradeType<> 14 And GD_Dis.byteGradeType<> 3  And GD_Dis.byteGradeType<> 57 ";
        }
        if (Shift != 0)
        {
            sql += " And  GD_Dis.byteShift=" + Shift;
        }
        if (bClass != "0")
        {
            sql += " And  GD_Dis.byteClass=" + bClass;
        }
        if (!string.IsNullOrEmpty(sStudent))
        {
            sql += " And GD_Dis.lngStudentNumber='" + sStudent + "'";
        }
        if (iLecturer != 0)
        {
            sql += " And CTS.intLecturer=" + iLecturer;
        }
        sql += " Order By  GD_Dis.intStudyYear,  GD_Dis.byteSemester,  GD_Dis.byteShift,  GD_Dis.strCourse,  GD_Dis.byteClass,  GD_Dis.Name,byteOrder";

        SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string);

        SqlCommand myCommand = new SqlCommand(sql, myConnection);
        myConnection.Open();
        SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        List<Grades> results = new List<Grades>();
        string sNo = null;
        Grades MyGrades = new Grades();
        //Dim myGradesTypes As New List(Of GradesTypes) 
        GradesTypes MyGradeType = new GradesTypes();
        int iGradesCounter = 0;
        try
        {
            while (reader.Read())
            {
                if (iGradesCounter == 0)
                {
                    MyGrades = new Grades();
                    MyGrades.GradesDatails = new List<GradesTypes>();
                    //if (reader["lngStudentNumber"].ToString() == "ESF1609142")
                    //{
                    //    MyGrades.Stno = reader["lngStudentNumber"].ToString();

                    //}
                    MyGrades.StudyYear = Convert.ToInt32(reader["intStudyYear"]);
                    MyGrades.Semester = Convert.ToByte(reader["byteSemester"]);
                    MyGrades.Shift = Convert.ToByte(reader["byteShift"]);
                    MyGrades.Course = reader["strCourse"].ToString();
                    MyGrades.bClass = Convert.ToByte(reader["byteClass"]);
                    MyGrades.Stno = reader["lngStudentNumber"].ToString();

                    MyGrades.SName = reader["Name"].ToString();
                    MyGrades.SEmail = reader["sECTemail"].ToString();

                    MyGrades.Degree = reader["strDegree"].ToString();
                    MyGrades.Major = reader["strSpecialization"].ToString();
                    
                    if (!(reader["intRemind"].Equals(DBNull.Value)))
                    {
                        MyGrades.Remind = reader["intRemind"].ToString();

                    }
                    else
                    {
                        MyGrades.Remind = "";
                    }

                    if (!(reader["FGPCounts"].Equals(DBNull.Value)))
                    {
                        MyGrades.FGP = int.Parse(reader["FGPCounts"].ToString());

                    }
                    else
                    {
                        MyGrades.FGP = 0;
                    }

                    if (!(reader["FGPReady"].Equals(DBNull.Value)))
                    {
                        MyGrades.FGPReady = int.Parse(reader["FGPReady"].ToString());
                    }
                    else
                    {
                        MyGrades.FGPReady = 0;
                    }

                    if (!(reader["isHidden"].Equals(DBNull.Value)))
                    {
                        MyGrades.IsHidden = bool.Parse(reader["isHidden"].ToString());
                    }
                    else
                    {
                        MyGrades.IsHidden = false;
                    }

                    if (!(reader["curUseMark"].Equals(DBNull.Value)))
                    {
                        MyGrades.DataStatus = 1;
                        MyGrades.Mark = Convert.ToDecimal(reader["curUseMark"]);
                    }
                    else
                    {
                        MyGrades.DataStatus = 0;
                    }
                    MyGrades.Grade = reader["strGrade"].ToString();
                    if (!DBNull.Value.Equals(reader["CGPA"]))
                    {
                        //not null
                        MyGrades.CGPA = Convert.ToDecimal("0" + reader["CGPA"]);
                    }
                    else
                    {
                        //null
                        MyGrades.CGPA = 101;
                    }

                 //   MyGrades.IsIncluded_AtRisk = Convert.ToInt32("0" + reader["IsIncluded_AtRisk"]);
                    if (!DBNull.Value.Equals(reader["IsIncluded_AtRisk"]))
                    {
                        //not null
                        MyGrades.IsIncluded_AtRisk = Convert.ToInt32(reader["IsIncluded_AtRisk"]);
                    }
                    else
                    {
                        //null
                        MyGrades.IsIncluded_AtRisk = 0;
                    }
                   
                    MyGrades.isDataChanged = 0;
                } // end if (iGradesCounter == 0)

                MyGradeType = new GradesTypes();

                //'//Fill Grades Type 

                MyGradeType.GradeType = Convert.ToByte(reader["byteGradeType"]);
                MyGradeType.GradeDesc = null;
                MyGradeType.Percentage = Convert.ToDecimal(reader["curPercentage"]);
                MyGradeType.Order = Convert.ToByte(reader["byteOrder"]);
                if (reader["curGrade"].Equals(DBNull.Value))
                {
                    MyGradeType.DataStatus = 0;
                    //New Record 
                    MyGradeType.Grade = -1;
                }
                else
                {
                    MyGradeType.DataStatus = 1;
                    //Old Record 
                    MyGradeType.Grade = Convert.ToDecimal(reader["curGrade"]);
                    //Hide Final Grades
                    if (!isFinalShown)
                    {
                        MyGradeType.BHidden = Convert.ToByte(reader["byteHidden"]);
                        switch (MyGradeType.BHidden)
                        {
                            case 1:
                                if (MyGrades.Grade == "EW" || MyGrades.Grade == "W" || MyGrades.Grade == "I")
                                {
                                    MyGradeType.Grade = -1;
                                }

                                break;
                            case 2:
                                if (MyGrades.Grade == "W")
                                {
                                    MyGradeType.Grade = -1;
                                }

                                break;
                        }
                    }

                }

                MyGradeType.isDataChanged = 0;

                MyGrades.GradesDatails.Add(MyGradeType);

                iGradesCounter += 1;
                if (iGradesCounter == iGradesTypeCount)
                {
                    results.Add(MyGrades);
                    iGradesCounter = 0;

                }

            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            reader.Close();
            reader = null;
            myConnection.Close();
            myConnection = null;
        }
        return results;
    }


    public int UpdateGrades(int StudyYear, byte Semester, byte Shift, string Course, byte bClass, string StudentNumber,
    decimal Mark, string Grade,string Degree,string Major,int FGP,int FGPReady, List<GradesTypes> GradesDatails,
    int DataStatus,InitializeModule.EnumCampus Campus, string sUser,string sNetUser,string sPCName) 
    {

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);

        SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string); 
        SqlCommand myCommand = new SqlCommand();
        int iEffected = 0;

        try { 
                       
            myConnection.Open(); 
            
            string sSQL = null; 
            string sCon = null; 
            string sExec = null; 
            int iDetail = 0; 
            
            if (DataStatus == 1) { 
                
                //'//Update Header 
                sSQL = "Update Reg_Grade_Header Set"; 
                sSQL = sSQL + " curUseMark=@Mark,"; 
                sSQL = sSQL + " strGrade=@Grade,"; 
                sSQL = sSQL + " strUserSave=@User,"; 
                sSQL = sSQL + " dateLastSave=@Date,"; 
                sSQL = sSQL + " strNUser=@NetUser,";
                sSQL = sSQL + " strMachine=@PCName";
                sCon = " Where "; 
                sCon = sCon + " intStudyYear=@StudyYear"; 
                sCon = sCon + " And byteSemester=@Semester"; 
                sCon = sCon + " And strCourse=@Course"; 
                sCon = sCon + " And byteClass=@Class"; 
                sCon = sCon + " And byteShift=@Shift"; 
                sCon = sCon + " And lngStudentNumber=@StudentNumber"; 
                
                sExec = sSQL + sCon; 
                
                myCommand = new SqlCommand(sExec, myConnection); 
                
                myCommand.Parameters.Add(new SqlParameter("@StudyYear", StudyYear)); 
                myCommand.Parameters.Add(new SqlParameter("@Semester", Semester)); 
                myCommand.Parameters.Add(new SqlParameter("@Shift", Shift)); 
                myCommand.Parameters.Add(new SqlParameter("@Course", Course)); 
                myCommand.Parameters.Add(new SqlParameter("@Class", bClass)); 
                myCommand.Parameters.Add(new SqlParameter("@StudentNumber", StudentNumber)); 
                myCommand.Parameters.Add(new SqlParameter("@Mark", Mark)); 
                myCommand.Parameters.Add(new SqlParameter("@Grade", Grade)); 
                myCommand.Parameters.Add(new SqlParameter("@User", sUser)); 
                myCommand.Parameters.Add(new SqlParameter("@Date", DateTime.Today.Date));
                myCommand.Parameters.Add(new SqlParameter("@NetUser", sNetUser ));
                myCommand.Parameters.Add(new SqlParameter("@PCName", sPCName)); 
                    
                iEffected = myCommand.ExecuteNonQuery();
            } 
            else 
            { 
                //'//Insert Header 
                
                sSQL = "Insert Into Reg_Grade_Header"; 
                sSQL = sSQL + " (intStudyYear,byteSemester,byteShift,strCourse,"; 
                sSQL = sSQL + " byteClass, lngStudentNumber, curUseMark, strGrade, ";
                sSQL = sSQL + " strDegree,strMajor,";
                sSQL = sSQL + "strUserCreate, dateCreate, strNUser,strMachine) Values("; 
                sSQL = sSQL + " @StudyYear,"; 
                sSQL = sSQL + " @Semester,"; 
                sSQL = sSQL + " @Shift,"; 
                sSQL = sSQL + " @Course,"; 
                sSQL = sSQL + " @Class,"; 
                sSQL = sSQL + " @StudentNumber,"; 
                sSQL = sSQL + " @Mark,"; 
                sSQL = sSQL + " @Grade,";
                sSQL = sSQL + " @Degree,";
                sSQL = sSQL + " @Major,";
                sSQL = sSQL + " @User,"; 
                sSQL = sSQL + " @Date,"; 
                sSQL = sSQL + " @NetUser,";
                sSQL = sSQL + " @PCName";
                sSQL = sSQL + " )"; 
                
                sExec = sSQL; 
                
                myCommand = new SqlCommand(sExec, myConnection); 
                
                myCommand.Parameters.Add(new SqlParameter("@StudyYear", StudyYear)); 
                myCommand.Parameters.Add(new SqlParameter("@Semester", Semester)); 
                myCommand.Parameters.Add(new SqlParameter("@Shift", Shift)); 
                myCommand.Parameters.Add(new SqlParameter("@Course", Course)); 
                myCommand.Parameters.Add(new SqlParameter("@Class", bClass)); 
                myCommand.Parameters.Add(new SqlParameter("@StudentNumber", StudentNumber)); 
                myCommand.Parameters.Add(new SqlParameter("@Mark", Mark)); 
                myCommand.Parameters.Add(new SqlParameter("@Grade", Grade));
                myCommand.Parameters.Add(new SqlParameter("@Degree", Degree));
                myCommand.Parameters.Add(new SqlParameter("@Major", Major)); 
                myCommand.Parameters.Add(new SqlParameter("@User", sUser)); 
                myCommand.Parameters.Add(new SqlParameter("@Date", DateTime.Today.Date));
                myCommand.Parameters.Add(new SqlParameter("@NetUser", sNetUser));
                myCommand.Parameters.Add(new SqlParameter("@PCName", sPCName));

                iEffected = myCommand.ExecuteNonQuery();
            } 

            ////apply forgivness
            //if ((Grade != "F") && (Grade != "I") && (Grade != "NG") && (Grade != "EW") && (Grade != "W") && (Grade != "NC"))
            //{
            //    if ((FGP < 2) && (FGPReady>0))
            //    {
            //        sSQL = "UPDATE Reg_Grade_Header SET bDisActivated = 1";
            //        sSQL += " WHERE (lngStudentNumber = '"+ StudentNumber +"') AND (strCourse = '"+ Course +"') AND (intStudyYear = "+ StudyYear +") AND (byteSemester < "+ Semester +") AND (strGrade IN ('F', 'D')) AND (bDisActivated = 0)";
            //        sSQL += " OR (lngStudentNumber = '" + StudentNumber + "') AND (strCourse = '" + Course + "') AND (intStudyYear < " + StudyYear + ") AND (strGrade IN ('F', 'D')) AND (bDisActivated = 0)";

            //        myCommand.CommandText = sSQL;
            //        myCommand.ExecuteNonQuery();
                      
            //    }
            //}
            
                        
            //'//Update or Insert Detail 
            sSQL = "Delete From Reg_Grade_Detail Where"; 
            sCon = " intStudyYear=@StudyYear And"; 
            sCon = sCon + " byteSemester=@Semester And"; 
            sCon = sCon + " strCourse=@Course And"; 
            sCon = sCon + " byteClass=@Class And"; 
            sCon = sCon + " byteShift=@Shift And"; 
            sCon = sCon + " lngStudentNumber=@StudentNumber"; 
            
            sExec = sSQL + sCon; 
            myCommand.CommandText = sExec; 
            myCommand.ExecuteNonQuery(); 
            
            sSQL = "Insert Into Reg_Grade_Detail"; 
            sSQL = sSQL + " (intStudyYear, byteSemester, byteShift, strCourse,"; 
            sSQL = sSQL + " byteClass, lngStudentNumber, byteGradeType, curGrade,";
            sSQL = sSQL + " strUserCreate, dateCreate, strNUser,strMachine)";
            sSQL = sSQL + " Values("; 
            sSQL = sSQL + " @StudyYear,"; 
            sSQL = sSQL + " @Semester,"; 
            sSQL = sSQL + " @Shift,"; 
            sSQL = sSQL + " @Course,"; 
            sSQL = sSQL + " @Class,"; 
            sSQL = sSQL + " @StudentNumber,"; 
            sSQL = sSQL + " @GradeType,"; 
            sSQL = sSQL + " @Grade,";
            sSQL = sSQL + " @User,";
            sSQL = sSQL + " @Date,";
            sSQL = sSQL + " @NetUser,";
            sSQL = sSQL + " @PCName";
            sSQL = sSQL + " )"; 
            
            sExec = sSQL; 
            myCommand.CommandText = sExec;
           
            myCommand.Parameters.Add(new SqlParameter("@GradeType", 1));
            for (iDetail = 0; iDetail <= GradesDatails.Count - 1; iDetail++)
            {
                if (GradesDatails[iDetail].Grade  != -1)
                {                     
                    myCommand.Parameters.RemoveAt("@GradeType"); 
                    myCommand.Parameters.RemoveAt("@Grade");

                    myCommand.Parameters.RemoveAt("@User");
                    myCommand.Parameters.RemoveAt("@Date");
                    myCommand.Parameters.RemoveAt("@NetUser");
                    myCommand.Parameters.RemoveAt("@PCName");


                    
                    myCommand.Parameters.Add(new SqlParameter("@GradeType", GradesDatails[iDetail].GradeType));
                    myCommand.Parameters.Add(new SqlParameter("@Grade", GradesDatails[iDetail].Grade));
                    
                    myCommand.Parameters.Add(new SqlParameter("@User", sUser));
                    myCommand.Parameters.Add(new SqlParameter("@Date", DateTime.Today.Date));
                    myCommand.Parameters.Add(new SqlParameter("@NetUser", sNetUser));
                    myCommand.Parameters.Add(new SqlParameter("@PCName", sPCName)); 

                   
                    iEffected += myCommand.ExecuteNonQuery();                    
                } 
                
            } 
        } 
        catch (Exception ex) {
            LibraryMOD.ShowErrorMessage(ex);
        } 
        finally { 
            myConnection.Close();
            myConnection.Dispose();
        }
        return iEffected;
    } 
    
} 

