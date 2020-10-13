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
public class Lecturer_Office_Hours
    {
    //Creation Date: 01/03/2012 6:32 PM
    //Programmer Name : Bahaa Addin Ghaleb Najem
    //-----Decleration --------------
    #region "Decleration"
    private int m_ID; 
    private int m_AcademicYear; 
    private int m_Semester; 
    private int m_Campus; 
    private int m_LecturerID; 
    private DateTime  m_FromTime;
    private DateTime m_ToTime; 
    private int m_Days;
    private string m_Office;
    private int m_CreationUserID; 
    private DateTime m_CreationDate; 
    private int m_LastUpdateUserID; 
    private DateTime m_LastUpdateDate; 
    private string m_PCName; 
    private string m_NetUserName; 
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int ID
    {
    get { return  m_ID; }
    set {m_ID  = value ; }
    }
    public int AcademicYear
    {
    get { return  m_AcademicYear; }
    set {m_AcademicYear  = value ; }
    }
    public int Semester
    {
    get { return  m_Semester; }
    set {m_Semester  = value ; }
    }
    public int Campus
    {
    get { return  m_Campus; }
    set {m_Campus  = value ; }
    }
    public int LecturerID
    {
    get { return  m_LecturerID; }
    set {m_LecturerID  = value ; }
    }
    public DateTime DateFromTime
    {
    get { return  m_FromTime; }
    set {m_FromTime  = value ; }
    }
    public DateTime DateToTime
    {
    get { return  m_ToTime; }
    set {m_ToTime  = value ; }
    }
    public int Days
    {
    get { return  m_Days; }
    set {m_Days  = value ; }
    }
    public string Office
    {
    get { return  m_Office; }
    set {m_Office  = value ; }
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
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public Lecturer_Office_Hours()
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
    public class Lecturer_Office_HoursDAL : Lecturer_Office_Hours
    {
    #region "Decleration"
    private string m_TableName;
    private string m_IDFN ;
    private string m_AcademicYearFN ;
    private string m_SemesterFN ;
    private string m_CampusFN ;
    private string m_LecturerIDFN ;
    private string m_FromTimeFN ;
    private string m_ToTimeFN ;
    private string m_DaysFN ;
    private string m_OfficeFN ;
    private string m_CreationUserIDFN ;
    private string m_CreationDateFN ;
    private string m_LastUpdateUserIDFN ;
    private string m_LastUpdateDateFN ;
    private string m_PCNameFN ;
    private string m_NetUserNameFN ;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName 
    {
    get { return m_TableName; }
    set { m_TableName = value; }
    }
    public string IDFN 
    {
    get { return  m_IDFN; }
    set {m_IDFN  = value ; }
    }
    public string AcademicYearFN 
    {
    get { return  m_AcademicYearFN; }
    set {m_AcademicYearFN  = value ; }
    }
    public string SemesterFN 
    {
    get { return  m_SemesterFN; }
    set {m_SemesterFN  = value ; }
    }
    public string CampusFN 
    {
    get { return  m_CampusFN; }
    set {m_CampusFN  = value ; }
    }
    public string LecturerIDFN 
    {
    get { return  m_LecturerIDFN; }
    set {m_LecturerIDFN  = value ; }
    }
    public string FromTimeFN 
    {
    get { return  m_FromTimeFN; }
    set {m_FromTimeFN  = value ; }
    }
    public string ToTimeFN 
    {
    get { return  m_ToTimeFN; }
    set {m_ToTimeFN  = value ; }
    }
    public string DaysFN 
    {
    get { return  m_DaysFN; }
    set {m_DaysFN  = value ; }
    }
    public string OfficeFN 
    {
        get { return m_OfficeFN; }
        set {m_OfficeFN  = value ; }
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
    #endregion
    //================End Properties ===================
    public Lecturer_Office_HoursDAL()
    {
    try
    {
    this.TableName = "Reg_Lecturer_Office_Hours";
    this.IDFN = m_TableName + ".ID";
    this.AcademicYearFN = m_TableName + ".AcademicYear";
    this.SemesterFN = m_TableName + ".Semester";
    this.CampusFN = m_TableName + ".Campus";
    this.LecturerIDFN = m_TableName + ".LecturerID";
    this.FromTimeFN = m_TableName + ".DateFromTime";
    this.ToTimeFN = m_TableName + ".DateToTime";
    this.DaysFN = m_TableName + ".Days";
    this.OfficeFN = m_TableName + ".Office";
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
    public string  GetSQL() 
    {
    string sSQL  = "";
    try
    {
    sSQL = "SELECT ";
    sSQL +=IDFN;
    sSQL += " , " + AcademicYearFN;
    sSQL += " , " + SemesterFN;
    sSQL += " , " + CampusFN;
    sSQL += " , " + LecturerIDFN;
    sSQL += " , " + FromTimeFN;
    sSQL += " , " + ToTimeFN;
    sSQL += " , " + DaysFN;
    sSQL += " , " + OfficeFN;
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
    public string  GetListSQL() 
    {
    string sSQL  = "";
    try
    {
    sSQL = "SELECT ";
    sSQL +=IDFN;
    sSQL += " , " + AcademicYearFN;
    sSQL += " , " + SemesterFN;
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
        public string  GetListSQL(string sCondition) 
    {
    string sSQL  = "";
    try
    {
    sSQL = "SELECT ";
    sSQL +=IDFN;
    sSQL += " , " + AcademicYearFN;
    sSQL += " , " + SemesterFN;
    sSQL += "  FROM " + m_TableName;
    sSQL += "  WHERE " + sCondition;

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
    sSQL +=IDFN;
    sSQL += " , " + AcademicYearFN;
    sSQL += " , " + SemesterFN;
    sSQL += " , " + CampusFN;
    sSQL += " , " + LecturerIDFN;
    sSQL += " , " + FromTimeFN;
    sSQL += " , " + ToTimeFN;
    sSQL += " , " + DaysFN;
    sSQL += " , " + OfficeFN;
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
    string sSQL  = "";
    try
    {
    sSQL = "UPDATE " + TableName;
    sSQL += " SET ";
    //sSQL += LibraryMOD.GetFieldName(IDFN) + "=@ID";
    sSQL += LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
    sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
    sSQL += " , " + LibraryMOD.GetFieldName(CampusFN) + "=@Campus";
    sSQL += " , " + LibraryMOD.GetFieldName(LecturerIDFN) + "=@LecturerID";
    sSQL += " , " + LibraryMOD.GetFieldName(FromTimeFN) + "=@DateFromTime";
    sSQL += " , " + LibraryMOD.GetFieldName(ToTimeFN) + "=@DateToTime";
    sSQL += " , " + LibraryMOD.GetFieldName(DaysFN) + "=@Days";
    sSQL += " , " + LibraryMOD.GetFieldName(OfficeFN) + "=@Office";
    sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
    sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
    sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
    sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
    sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
    sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
    sSQL += " WHERE ";
    sSQL += LibraryMOD.GetFieldName(IDFN)+"=@ID";
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
   // sSQL +=LibraryMOD.GetFieldName(IDFN);
    sSQL +=  LibraryMOD.GetFieldName(AcademicYearFN);
    sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
    sSQL += " , " + LibraryMOD.GetFieldName(CampusFN);
    sSQL += " , " + LibraryMOD.GetFieldName(LecturerIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(FromTimeFN);
    sSQL += " , " + LibraryMOD.GetFieldName(ToTimeFN);
    sSQL += " , " + LibraryMOD.GetFieldName(DaysFN);
    sSQL += " , " + LibraryMOD.GetFieldName(OfficeFN);
    sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
    sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
    sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
    sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
    sSQL += ")";
    sSQL += " VALUES ";
    sSQL += "( ";
    //sSQL += " @ID";
    sSQL += " @AcademicYear";
    sSQL += " ,@Semester";
    sSQL += " ,@Campus";
    sSQL += " ,@LecturerID";
    sSQL += " ,@DateFromTime";
    sSQL += " ,@DateToTime";
    sSQL += " ,@Days";
    sSQL += " ,@Office";
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
    public string  GetDeleteCommand()
    {
    string sSQL= "";
    try
    {
    sSQL = "DELETE FROM "  + TableName;
    sSQL += " WHERE ";
    sSQL += LibraryMOD.GetFieldName(IDFN)+"=@ID";
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
    public List< Lecturer_Office_Hours> GetLecturer_Office_Hours(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    {
    //' returns a list of Classes instances based on the
    //' data in the Lecturer_Office_Hours
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string  sSQL = GetSQL();
    if (!string.IsNullOrEmpty(sCondition))
    {
    sSQL += sCondition;
    }
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Lecturer_Office_Hours> results = new List<Lecturer_Office_Hours>();
    try
    {
    //Default Value
    Lecturer_Office_Hours myLecturer_Office_Hours = new Lecturer_Office_Hours();
    if (isDeafaultIncluded)
    {
    //Change the code here
    //myLecturer_Office_Hours.ID = 0;
    //myLecturer_Office_Hours.ID = "Select Lecturer_Office_Hours ...";
    //results.Add(myLecturer_Office_Hours);
    }
    while (reader.Read())
    {
    myLecturer_Office_Hours = new Lecturer_Office_Hours();
    if (reader[LibraryMOD.GetFieldName(IDFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.ID = 0;
    }
    else
    {
    myLecturer_Office_Hours.ID = int.Parse(reader[LibraryMOD.GetFieldName( IDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.AcademicYear = 0;
    }
    else
    {
    myLecturer_Office_Hours.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.Semester = 0;
    }
    else
    {
    myLecturer_Office_Hours.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(CampusFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.Campus = 0;
    }
    else
    {
    myLecturer_Office_Hours.Campus = int.Parse(reader[LibraryMOD.GetFieldName( CampusFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(LecturerIDFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.LecturerID = 0;
    }
    else
    {
    myLecturer_Office_Hours.LecturerID = int.Parse(reader[LibraryMOD.GetFieldName( LecturerIDFN) ].ToString());
    }
    myLecturer_Office_Hours.DateFromTime = Convert.ToDateTime(reader[LibraryMOD.GetFieldName(FromTimeFN)]);
    myLecturer_Office_Hours.DateToTime =Convert.ToDateTime (reader[LibraryMOD.GetFieldName( ToTimeFN)]);
    if (reader[LibraryMOD.GetFieldName(DaysFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.Days = 0;
    }
    else
    {
    myLecturer_Office_Hours.Days = int.Parse(reader[LibraryMOD.GetFieldName( DaysFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(OfficeFN )].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.Office = "";
    }
    else
    {
    myLecturer_Office_Hours.Office = reader[LibraryMOD.GetFieldName( OfficeFN ) ].ToString();
    }
    if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.CreationUserID = 0;
    }
    else
    {
    myLecturer_Office_Hours.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
    }
    if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.LastUpdateUserID = 0;
    }
    else
    {
    myLecturer_Office_Hours.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
    }
    if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
    }
    myLecturer_Office_Hours.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
    myLecturer_Office_Hours.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
     results.Add(myLecturer_Office_Hours);
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
    public List< Lecturer_Office_Hours > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Lecturer_Office_Hours> results = new List<Lecturer_Office_Hours>();
    try
    {
    //Default Value
    Lecturer_Office_Hours myLecturer_Office_Hours= new Lecturer_Office_Hours();
    if (isDeafaultIncluded)
     {
    //Change the code here
     myLecturer_Office_Hours.ID = -1;
     myLecturer_Office_Hours.AcademicYear = -1;
    results.Add(myLecturer_Office_Hours);
     }
    while (reader.Read())
    {
    myLecturer_Office_Hours = new Lecturer_Office_Hours();
    if (reader[LibraryMOD.GetFieldName(IDFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.ID = 0;
    }
    else
    {
    myLecturer_Office_Hours.ID = int.Parse(reader[LibraryMOD.GetFieldName( IDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.AcademicYear = 0;
    }
    else
    {
    myLecturer_Office_Hours.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
    {
    myLecturer_Office_Hours.Semester = 0;
    }
    else
    {
    myLecturer_Office_Hours.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
    }
     results.Add(myLecturer_Office_Hours);
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
    public int UpdateLecturer_Office_Hours(InitializeModule.EnumCampus Campus, int iMode,int ID,int AcademicYear,int Semester,int iCampus,int LecturerID,DateTime DateFromTime,DateTime DateToTime,int Days,string Office,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    Conn.Open();
    string sql = "";
    Lecturer_Office_Hours theLecturer_Office_Hours = new Lecturer_Office_Hours();
    //'Updates the  table
    switch(iMode) 
      {
      case  (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
          sql = GetUpdateCommand();
          break ;
      case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
          sql = GetInsertCommand();
          break ;
      }
        DateTime EndTime;
        EndTime = DateToTime;

       
        while (DateFromTime.AddHours(1.5) <= EndTime)
        {
        SqlCommand Cmd = new SqlCommand(sql, Conn);

        
        DateToTime = DateFromTime.AddHours(1.5);

        Cmd.Parameters.Add(new SqlParameter("@ID",ID));
        Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
        Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
        Cmd.Parameters.Add(new SqlParameter("@Campus",iCampus));
        Cmd.Parameters.Add(new SqlParameter("@LecturerID",LecturerID));
        Cmd.Parameters.Add(new SqlParameter("@DateFromTime",DateFromTime));
        Cmd.Parameters.Add(new SqlParameter("@DateToTime",DateToTime));
        Cmd.Parameters.Add(new SqlParameter("@Days",Days));
        Cmd.Parameters.Add(new SqlParameter("@Office", Office));
        Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
        Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
        Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
        Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
        Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
        Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
       
        iEffected = Cmd.ExecuteNonQuery();

        DateFromTime = DateFromTime.AddHours(1.5);

        }
    

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
    public double GeTotalOfficeHours(int iYear, int iSemestre, int iLecturerID)
    {
        System.Data.SqlClient.SqlCommand sqlCmd;

        sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetLecturerOfficeHours";


        System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@AcademicYear";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iYear;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);


        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@Semester";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iSemestre;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@LecturerID";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iLecturerID;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        //'====================================
        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@dblTotal";
        parameter.IsNullable = true;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Output;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        Conn.Open();

        sqlCmd.Connection = Conn;


        //System.Data.SqlClient.SqlDataReader reader;
        //reader = sqlCmd.ExecuteReader();

        sqlCmd.ExecuteNonQuery();
        double total = Convert.ToDouble(sqlCmd.Parameters["@dblTotal"].Value.ToString()) / 60;

        Conn.Close();
        return total;

    }

    public double GeTotalOfficeHoursInDay(int iYear, int iSemestre, int iLecturerID,int iDayID)
    {
        System.Data.SqlClient.SqlCommand sqlCmd;

        sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetLecturerOfficeHoursInDay";


        System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@AcademicYear";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iYear;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);


        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@Semester";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iSemestre;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@LecturerID";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iLecturerID;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@Days";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iDayID;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        //'====================================
        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@dblTotal";
        parameter.IsNullable = true;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Output;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        Conn.Open();

        sqlCmd.Connection = Conn;


        //System.Data.SqlClient.SqlDataReader reader;
        //reader = sqlCmd.ExecuteReader();

        sqlCmd.ExecuteNonQuery();
        double total = Convert.ToDouble(sqlCmd.Parameters["@dblTotal"].Value.ToString()) / 60;

        Conn.Close();
        return total;

    }
    public int UpdateLecturer_Office_HoursOnlyone(InitializeModule.EnumCampus Campus, int iMode, int ID, int AcademicYear, int Semester, int iCampus, int LecturerID, DateTime DateFromTime, DateTime DateToTime, int Days, string Office, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Lecturer_Office_Hours theLecturer_Office_Hours = new Lecturer_Office_Hours();
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


        

                Cmd.Parameters.Add(new SqlParameter("@ID", ID));
                Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear));
                Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
                Cmd.Parameters.Add(new SqlParameter("@Campus", iCampus));
                Cmd.Parameters.Add(new SqlParameter("@LecturerID", LecturerID));
                Cmd.Parameters.Add(new SqlParameter("@DateFromTime", DateFromTime));
                Cmd.Parameters.Add(new SqlParameter("@DateToTime", DateToTime));
                Cmd.Parameters.Add(new SqlParameter("@Days", Days));
                Cmd.Parameters.Add(new SqlParameter("@Office", Office));
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
    public int DeleteLecturer_Office_Hours(InitializeModule.EnumCampus Campus,int ID)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    string sSQL = GetDeleteCommand();
    //sSQL += sCondition;
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Cmd.Parameters.Add(new SqlParameter("@ID", ID ));
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
    public DataView GetDataView(bool isFromRole,int PK,string sCondition)
    {
    DataTable dt = new DataTable("Lecturer_Office_Hours");
    DataView dv = new DataView();
    List<Lecturer_Office_Hours> myLecturer_Office_Hourss = new List<Lecturer_Office_Hours>();
    try
    {
    myLecturer_Office_Hourss = GetLecturer_Office_Hours(InitializeModule.EnumCampus.ECTNew,sCondition,false);
    DataColumn col0= new DataColumn("ID", Type.GetType("int"));
    dt.Columns.Add(col0 );
    //dt.Constraints.Add(new UniqueConstraint(col1));

    DataRow dr;
    for (int i = 0; i < myLecturer_Office_Hourss.Count; i++)
    {
    dr = dt.NewRow();
      dr[1] = myLecturer_Office_Hourss[i].ID;
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
    myLecturer_Office_Hourss.Clear();
    }
     return dv;
    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con) 
    {
    string sSQL =""; 
    DataTable table = new DataTable();
    try
    {
    sSQL = "SELECT";
    sSQL += IDFN;
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
    public class Lecturer_Office_HoursCls : Lecturer_Office_HoursDAL
    {
    #region "Decleration"
    private int m_lngCurRow=0;
    public SqlDataAdapter daLecturer_Office_Hours;
    private DataSet m_dsLecturer_Office_Hours;
    public DataRow Lecturer_Office_HoursDataRow ;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLecturer_Office_Hours
    {
    get { return m_dsLecturer_Office_Hours ; }
    set { m_dsLecturer_Office_Hours = value ; }
    }
    //-----------------------------------------------------
    public int lngCurRow 
    {
    get { return  m_lngCurRow ; }
    set {m_lngCurRow = value ; }
    }
    #endregion
    public Lecturer_Office_HoursCls()
    {
    try
    {
    dsLecturer_Office_Hours= new DataSet();

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
    public virtual SqlDataAdapter GetLecturer_Office_HoursDataAdapter(string sCondition ,SqlConnection con ) 
    {
    string sSQL =""; 
    try
    {
    sSQL = GetSQL();
    sSQL += " " + sCondition;
    //-----------------------------------------
    daLecturer_Office_Hours = new SqlDataAdapter(sSQL, con);
    // Create command builder. This line automatically generates the update commands for you, so you don't
    // have to provide or create your own.
    SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLecturer_Office_Hours);
    //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    // key + unique key information to be retrieved unless AddWithKey is specified.
    daLecturer_Office_Hours.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daLecturer_Office_Hours;
    }
    public virtual SqlDataAdapter GetLecturer_Office_HoursDataAdapter(SqlConnection con)  
    {
    try
    {
    daLecturer_Office_Hours = new SqlDataAdapter();
    //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    //'' key + unique key information to be retrieved unless AddWithKey is specified.
    daLecturer_Office_Hours.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    //-----------------------------------------
    SqlParameter Parmeter = default(SqlParameter); 
    //[SELECT COMMAND]
    SqlCommand cmdLecturer_Office_Hours;
    cmdLecturer_Office_Hours = new SqlCommand(GetSelectCommand(), con);
    //'cmdRolePermission.Parameters.Add("@ID", SqlDbType.Int, 4, "ID" );
    daLecturer_Office_Hours.SelectCommand = cmdLecturer_Office_Hours;
    //'Add Handlers
    //'RowUpdating,RowUpdated
    AddDAEventHandler();
    //'[UPDATE COMMAND].
    cmdLecturer_Office_Hours = new SqlCommand(GetUpdateCommand(), con);
    //'Delete PK Parameteres from here. b/c its declared below
    cmdLecturer_Office_Hours.Parameters.Add("@ID", SqlDbType.Int,4, LibraryMOD.GetFieldName(IDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Campus", SqlDbType.Int,4, LibraryMOD.GetFieldName(CampusFN));
    cmdLecturer_Office_Hours.Parameters.Add("@LecturerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LecturerIDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@DateFromTime", SqlDbType.DateTime  ,32, LibraryMOD.GetFieldName(FromTimeFN));
    cmdLecturer_Office_Hours.Parameters.Add("@DateToTime", SqlDbType.DateTime, 32, LibraryMOD.GetFieldName(ToTimeFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Days", SqlDbType.Int,4, LibraryMOD.GetFieldName(DaysFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Office", SqlDbType.NVarChar, 20, LibraryMOD.GetFieldName(OfficeFN));
    cmdLecturer_Office_Hours.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
    cmdLecturer_Office_Hours.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
    cmdLecturer_Office_Hours.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
    cmdLecturer_Office_Hours.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


    Parmeter = cmdLecturer_Office_Hours.Parameters.Add("@ID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    //'Its should be none for batch updating
    //'UpdateCommand, InsertCommand, and DeleteCommand 
    //'should be set to None or OutputParameters
    daLecturer_Office_Hours.UpdateCommand = cmdLecturer_Office_Hours;
    daLecturer_Office_Hours.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
    //'-------------------------------------------------------------------------
    //'/INSERT COMMAND
     cmdLecturer_Office_Hours = new SqlCommand(GetInsertCommand(), con);
    cmdLecturer_Office_Hours.Parameters.Add("@ID", SqlDbType.Int,4, LibraryMOD.GetFieldName(IDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Campus", SqlDbType.Int,4, LibraryMOD.GetFieldName(CampusFN));
    cmdLecturer_Office_Hours.Parameters.Add("@LecturerID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LecturerIDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@DateFromTime", SqlDbType.DateTime, 32, LibraryMOD.GetFieldName(FromTimeFN));
    cmdLecturer_Office_Hours.Parameters.Add("@DateToTime", SqlDbType.DateTime, 32, LibraryMOD.GetFieldName(ToTimeFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Days", SqlDbType.Int,4, LibraryMOD.GetFieldName(DaysFN));
    cmdLecturer_Office_Hours.Parameters.Add("@Office", SqlDbType.NVarChar, 20, LibraryMOD.GetFieldName(OfficeFN));
    cmdLecturer_Office_Hours.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
    cmdLecturer_Office_Hours.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
    cmdLecturer_Office_Hours.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
    cmdLecturer_Office_Hours.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
    cmdLecturer_Office_Hours.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
    Parmeter.SourceVersion = DataRowVersion.Current;
    daLecturer_Office_Hours.InsertCommand =cmdLecturer_Office_Hours;
    daLecturer_Office_Hours.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'------------------------
    //'/DELETE COMMAND
     cmdLecturer_Office_Hours = new SqlCommand(GetDeleteCommand(), con);
    Parmeter = cmdLecturer_Office_Hours.Parameters.Add("@ID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    daLecturer_Office_Hours.DeleteCommand =cmdLecturer_Office_Hours;
    daLecturer_Office_Hours.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'Batch Size
    //'Set the batch size.
    daLecturer_Office_Hours.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daLecturer_Office_Hours;
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
    dr = dsLecturer_Office_Hours.Tables[TableName].NewRow();
    dr[LibraryMOD.GetFieldName(IDFN)]=ID;
    dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
    dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
    dr[LibraryMOD.GetFieldName(CampusFN)]=Campus;
    dr[LibraryMOD.GetFieldName(LecturerIDFN)]=LecturerID;
    dr[LibraryMOD.GetFieldName(FromTimeFN)]=DateFromTime;
    dr[LibraryMOD.GetFieldName(ToTimeFN)]=DateToTime;
    dr[LibraryMOD.GetFieldName(DaysFN)]=Days;
    dr[LibraryMOD.GetFieldName(OfficeFN )] = Office ;
    dsLecturer_Office_Hours.Tables[TableName].Rows.Add(dr);
    break;
    case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
     DataRow[] drAry = null;
    drAry = dsLecturer_Office_Hours.Tables[TableName].Select(LibraryMOD.GetFieldName(IDFN)  + "=" + ID);
    //'its return array of rows and we can access the first by index 0
    drAry[0][LibraryMOD.GetFieldName(IDFN)]=ID;
    drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
    drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
    drAry[0][LibraryMOD.GetFieldName(CampusFN)]=Campus;
    drAry[0][LibraryMOD.GetFieldName(LecturerIDFN)]=LecturerID;
    drAry[0][LibraryMOD.GetFieldName(FromTimeFN)]=DateFromTime;
    drAry[0][LibraryMOD.GetFieldName(ToTimeFN)]=DateToTime;
    drAry[0][LibraryMOD.GetFieldName(DaysFN)]=Days;
    drAry[0][LibraryMOD.GetFieldName(OfficeFN)]=Office ;

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
    public int CommitLecturer_Office_Hours()  
    {
    //CommitLecturer_Office_Hours= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //'' Update Database with SqlDataAdapter
    daLecturer_Office_Hours.Update(dsLecturer_Office_Hours, TableName);
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
    FindInMultiPKey(ID);
    if (( Lecturer_Office_HoursDataRow != null)) 
    {
    Lecturer_Office_HoursDataRow.Delete();
    CommitLecturer_Office_Hours();
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
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(IDFN)]== System.DBNull.Value)
    {
      ID=0;
    }
    else
    {
      ID = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(IDFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
    {
      AcademicYear=0;
    }
    else
    {
      AcademicYear = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
    {
      Semester=0;
    }
    else
    {
      Semester = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(SemesterFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(CampusFN)]== System.DBNull.Value)
    {
      Campus=0;
    }
    else
    {
      Campus = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(CampusFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(LecturerIDFN)]== System.DBNull.Value)
    {
      LecturerID=0;
    }
    else
    {
      LecturerID = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(LecturerIDFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(FromTimeFN)]== System.DBNull.Value)
    {
      DateFromTime=default (DateTime );
    }
    else
    {
        DateFromTime = (DateTime)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(FromTimeFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(ToTimeFN)]== System.DBNull.Value)
    {
      DateToTime=default(DateTime ) ;
    }
    else
    {
        DateToTime = (DateTime)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(ToTimeFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(DaysFN)]== System.DBNull.Value)
    {
      Days=0;
    }
    else
    {
      Days = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(DaysFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(OfficeFN)]== System.DBNull.Value)
    {
      Office="";
    }
    else
    {
      Office = Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(OfficeFN)].ToString ();
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
    {
      CreationUserID=0;
    }
    else
    {
      CreationUserID = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      CreationDate = (DateTime)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
    {
      LastUpdateUserID=0;
    }
    else
    {
      LastUpdateUserID = (int)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      LastUpdateDate = (DateTime)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
    {
      PCName="";
    }
    else
    {
      PCName = (string)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(PCNameFN)];
    }
    if (Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
    {
      NetUserName="";
    }
    else
    {
      NetUserName = (string)Lecturer_Office_HoursDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKID) 
    {
    //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //' Create an array for the key values to find.
    object[] findTheseVals = new object[1] ; 
    //' Set the values of the keys to find.
    findTheseVals[0] = PKID;
    Lecturer_Office_HoursDataRow = dsLecturer_Office_Hours.Tables[TableName].Rows.Find(findTheseVals);
    if  ((Lecturer_Office_HoursDataRow !=null)) 
    {
    lngCurRow = dsLecturer_Office_Hours.Tables[TableName].Rows.IndexOf(Lecturer_Office_HoursDataRow);
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
      lngCurRow = dsLecturer_Office_Hours.Tables[TableName].Rows.Count - 1; //'Zero based index
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
      lngCurRow = Math.Min(lngCurRow + 1, dsLecturer_Office_Hours.Tables[TableName].Rows.Count - 1);
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
      if (lngCurRow >= 0 & dsLecturer_Office_Hours.Tables[TableName].Rows.Count > 0) 
    {
      Lecturer_Office_HoursDataRow = dsLecturer_Office_Hours.Tables[TableName].Rows[lngCurRow];
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
    daLecturer_Office_Hours.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daLecturer_Office_Hours.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
    daLecturer_Office_Hours.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daLecturer_Office_Hours.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
