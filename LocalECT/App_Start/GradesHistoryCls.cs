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

public class GradesHistory
    {
    //Creation Date: 07/07/2011 3:48 PM
    //Programmer Name : Bahaa Addin Ghaleb Najem
    //-----Decleration --------------
    #region "Decleration"
    private int m_HistoryID; 
    private string m_StudentID; 
    private int m_AcademicYear; 
    private int m_Semester; 
    private int m_Session; 
    private string m_Course; 
    private int m_Section; 
    private int m_GradeTypeID; 
    private double m_OldValue; 
    private double m_NewValue; 
    private int m_CreationUserID; 
    private DateTime m_CreationDate; 
    private string m_PCName; 
    private string m_NetUserName; 
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int HistoryID
    {
    get { return  m_HistoryID; }
    set {m_HistoryID  = value ; }
    }
    public string StudentID
    {
    get { return  m_StudentID; }
    set {m_StudentID  = value ; }
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
    public int Session
    {
    get { return  m_Session; }
    set {m_Session  = value ; }
    }
    public string Course
    {
    get { return  m_Course; }
    set {m_Course  = value ; }
    }
    public int Section
    {
    get { return  m_Section; }
    set {m_Section  = value ; }
    }
    public int GradeTypeID
    {
    get { return  m_GradeTypeID; }
    set {m_GradeTypeID  = value ; }
    }
    public double  OldValue
    {
    get { return  m_OldValue; }
    set {m_OldValue  = value ; }
    }
    public double  NewValue
    {
    get { return  m_NewValue; }
    set {m_NewValue  = value ; }
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
    public GradesHistory()
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
    public class GradesHistoryDAL : GradesHistory
    {
    #region "Decleration"
    private string m_TableName;
    private string m_HistoryIDFN ;
    private string m_StudentIDFN ;
    private string m_AcademicYearFN ;
    private string m_SemesterFN ;
    private string m_SessionFN ;
    private string m_CourseFN ;
    private string m_SectionFN ;
    private string m_GradeTypeIDFN ;
    private string m_OldValueFN ;
    private string m_NewValueFN ;
    private string m_CreationUserIDFN ;
    private string m_CreationDateFN ;
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
    public string HistoryIDFN 
    {
    get { return  m_HistoryIDFN; }
    set {m_HistoryIDFN  = value ; }
    }
    public string StudentIDFN 
    {
    get { return  m_StudentIDFN; }
    set {m_StudentIDFN  = value ; }
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
    public string SessionFN 
    {
    get { return  m_SessionFN; }
    set {m_SessionFN  = value ; }
    }
    public string CourseFN 
    {
    get { return  m_CourseFN; }
    set {m_CourseFN  = value ; }
    }
    public string SectionFN 
    {
    get { return  m_SectionFN; }
    set {m_SectionFN  = value ; }
    }
    public string GradeTypeIDFN 
    {
    get { return  m_GradeTypeIDFN; }
    set {m_GradeTypeIDFN  = value ; }
    }
    public string OldValueFN 
    {
    get { return  m_OldValueFN; }
    set {m_OldValueFN  = value ; }
    }
    public string NewValueFN 
    {
    get { return  m_NewValueFN; }
    set {m_NewValueFN  = value ; }
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
    public GradesHistoryDAL()
    {
    try
    {
    this.TableName = "Reg_GradesHistory";
    this.HistoryIDFN = m_TableName + ".HistoryID";
    this.StudentIDFN = m_TableName + ".StudentID";
    this.AcademicYearFN = m_TableName + ".AcademicYear";
    this.SemesterFN = m_TableName + ".Semester";
    this.SessionFN = m_TableName + ".Session";
    this.CourseFN = m_TableName + ".Course";
    this.SectionFN = m_TableName + ".Section";
    this.GradeTypeIDFN = m_TableName + ".GradeTypeID";
    this.OldValueFN = m_TableName + ".OldValue";
    this.NewValueFN = m_TableName + ".NewValue";
    this.CreationUserIDFN = m_TableName + ".CreationUserID";
    this.CreationDateFN = m_TableName + ".CreationDate";
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
    sSQL +=HistoryIDFN;
    sSQL += " , " + StudentIDFN;
    sSQL += " , " + AcademicYearFN;
    sSQL += " , " + SemesterFN;
    sSQL += " , " + SessionFN;
    sSQL += " , " + CourseFN;
    sSQL += " , " + SectionFN;
    sSQL += " , " + GradeTypeIDFN;
    sSQL += " , " + OldValueFN;
    sSQL += " , " + NewValueFN;
    sSQL += " , " + CreationUserIDFN;
    sSQL += " , " + CreationDateFN;
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
    public string GetListSQL(string  sCondition) 
    {
    string sSQL  = "";
    try
    {
    sSQL = "SELECT ";
    sSQL +=HistoryIDFN;
    sSQL += " , " + StudentIDFN;
    sSQL += " , " + AcademicYearFN;
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

    //-----Get GetSelectCommand Function -----------------------
    public string GetSelectCommand() 
    {
    string sSQL= "";
    try
    {
    sSQL = "SELECT ";
    sSQL +=HistoryIDFN;
    sSQL += " , " + StudentIDFN;
    sSQL += " , " + AcademicYearFN;
    sSQL += " , " + SemesterFN;
    sSQL += " , " + SessionFN;
    sSQL += " , " + CourseFN;
    sSQL += " , " + SectionFN;
    sSQL += " , " + GradeTypeIDFN;
    sSQL += " , " + OldValueFN;
    sSQL += " , " + NewValueFN;
    sSQL += " , " + CreationUserIDFN;
    sSQL += " , " + CreationDateFN;
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
    sSQL += LibraryMOD.GetFieldName(HistoryIDFN) + "=@HistoryID";
    sSQL += " , " + LibraryMOD.GetFieldName(StudentIDFN) + "=@StudentID";
    sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
    sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
    sSQL += " , " + LibraryMOD.GetFieldName(SessionFN) + "=@Session";
    sSQL += " , " + LibraryMOD.GetFieldName(CourseFN) + "=@Course";
    sSQL += " , " + LibraryMOD.GetFieldName(SectionFN) + "=@Section";
    sSQL += " , " + LibraryMOD.GetFieldName(GradeTypeIDFN) + "=@GradeTypeID";
    sSQL += " , " + LibraryMOD.GetFieldName(OldValueFN) + "=@OldValue";
    sSQL += " , " + LibraryMOD.GetFieldName(NewValueFN) + "=@NewValue";
    sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
    sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
    sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
    sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
    sSQL += " WHERE ";
    sSQL += LibraryMOD.GetFieldName(HistoryIDFN)+"=@HistoryID";
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
   // sSQL +=LibraryMOD.GetFieldName(HistoryIDFN);
    sSQL +=  LibraryMOD.GetFieldName(StudentIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
    sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
    sSQL += " , " + LibraryMOD.GetFieldName(SessionFN);
    sSQL += " , " + LibraryMOD.GetFieldName(CourseFN);
    sSQL += " , " + LibraryMOD.GetFieldName(SectionFN);
    sSQL += " , " + LibraryMOD.GetFieldName(GradeTypeIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(OldValueFN);
    sSQL += " , " + LibraryMOD.GetFieldName(NewValueFN);
    sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
    sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
    sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
    sSQL += ")";
    sSQL += " VALUES ";
    sSQL += "( ";
   // sSQL += " @HistoryID";
    sSQL += " @StudentID";
    sSQL += " ,@AcademicYear";
    sSQL += " ,@Semester";
    sSQL += " ,@Session";
    sSQL += " ,@Course";
    sSQL += " ,@Section";
    sSQL += " ,@GradeTypeID";
    sSQL += " ,@OldValue";
    sSQL += " ,@NewValue";
    sSQL += " ,@CreationUserID";
    sSQL += " ,@CreationDate";
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
    sSQL += LibraryMOD.GetFieldName(HistoryIDFN)+"=@HistoryID";
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
    public List< GradesHistory> GetGradesHistory(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    {
    //' returns a list of Classes instances based on the
    //' data in the GradesHistory
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
    List<GradesHistory> results = new List<GradesHistory>();
    try
    {
    //Default Value
    GradesHistory myGradesHistory = new GradesHistory();
    if (isDeafaultIncluded)
    {
    //Change the code here
    myGradesHistory.HistoryID = 0;
    //myGradesHistory.HistoryID = "Select GradesHistory ...";

    results.Add(myGradesHistory);
    }
    while (reader.Read())
    {
    myGradesHistory = new GradesHistory();
    if (reader[LibraryMOD.GetFieldName(HistoryIDFN)].Equals(DBNull.Value))
    {
    myGradesHistory.HistoryID = 0;
    }
    else
    {
    myGradesHistory.HistoryID = int.Parse(reader[LibraryMOD.GetFieldName( HistoryIDFN) ].ToString());
    }
    myGradesHistory.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
    if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
    {
    myGradesHistory.AcademicYear = 0;
    }
    else
    {
    myGradesHistory.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
    {
    myGradesHistory.Semester = 0;
    }
    else
    {
    myGradesHistory.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(SessionFN)].Equals(DBNull.Value))
    {
    myGradesHistory.Session = 0;
    }
    else
    {
    myGradesHistory.Session = int.Parse(reader[LibraryMOD.GetFieldName( SessionFN) ].ToString());
    }
    myGradesHistory.Course =reader[LibraryMOD.GetFieldName( CourseFN) ].ToString();
    if (reader[LibraryMOD.GetFieldName(SectionFN)].Equals(DBNull.Value))
    {
    myGradesHistory.Section = 0;
    }
    else
    {
    myGradesHistory.Section = int.Parse(reader[LibraryMOD.GetFieldName( SectionFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(GradeTypeIDFN)].Equals(DBNull.Value))
    {
    myGradesHistory.GradeTypeID = 0;
    }
    else
    {
    myGradesHistory.GradeTypeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeTypeIDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(OldValueFN)].Equals(DBNull.Value))
    {
    myGradesHistory.OldValue = 0;
    }
    else
    {
    myGradesHistory.OldValue = double.Parse(reader[LibraryMOD.GetFieldName( OldValueFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(NewValueFN)].Equals(DBNull.Value))
    {
    myGradesHistory.NewValue = 0;
    }
    else
    {
    myGradesHistory.NewValue = double.Parse(reader[LibraryMOD.GetFieldName( NewValueFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
    {
    myGradesHistory.CreationUserID = 0;
    }
    else
    {
    myGradesHistory.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
    }
    if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
    {
    myGradesHistory.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
    }
    myGradesHistory.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
    myGradesHistory.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
     results.Add(myGradesHistory);
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
    public List< GradesHistory > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<GradesHistory> results = new List<GradesHistory>();
    try
    {
    //Default Value
    GradesHistory myGradesHistory= new GradesHistory();
    if (isDeafaultIncluded)
     {
    //Change the code here
     myGradesHistory.HistoryID = -1;
     myGradesHistory.StudentID = "Select GradesHistory" ;
    results.Add(myGradesHistory);
     }
    while (reader.Read())
    {
    myGradesHistory = new GradesHistory();
    if (reader[LibraryMOD.GetFieldName(HistoryIDFN)].Equals(DBNull.Value))
    {
    myGradesHistory.HistoryID = 0;
    }
    else
    {
    myGradesHistory.HistoryID = int.Parse(reader[LibraryMOD.GetFieldName( HistoryIDFN) ].ToString());
    }
    myGradesHistory.StudentID =reader[LibraryMOD.GetFieldName( StudentIDFN) ].ToString();
    if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
    {
    myGradesHistory.AcademicYear = 0;
    }
    else
    {
    myGradesHistory.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
    }
     results.Add(myGradesHistory);
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
    public int UpdateGradesHistory(InitializeModule.EnumCampus Campus, 
        int iMode,int HistoryID,string StudentID,int AcademicYear,
        int Semester,int Session,string Course,int Section,
        int GradeTypeID,double OldValue,double NewValue,int CreationUserID,
        DateTime CreationDate,string PCName,string NetUserName)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    Conn.Open();
    string sql = "";
    GradesHistory theGradesHistory = new GradesHistory();
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
    SqlCommand Cmd = new SqlCommand(sql, Conn);
    //Cmd.Parameters.Add(new SqlParameter("@HistoryID",HistoryID));
    Cmd.Parameters.Add(new SqlParameter("@StudentID",StudentID));
    Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
    Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
    Cmd.Parameters.Add(new SqlParameter("@Session",Session));
    Cmd.Parameters.Add(new SqlParameter("@Course",Course));
    Cmd.Parameters.Add(new SqlParameter("@Section",Section));
    Cmd.Parameters.Add(new SqlParameter("@GradeTypeID",GradeTypeID));
    Cmd.Parameters.Add(new SqlParameter("@OldValue",OldValue));
    Cmd.Parameters.Add(new SqlParameter("@NewValue",NewValue));
    Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
    Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
    Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
    Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
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
    public int DeleteGradesHistory(InitializeModule.EnumCampus Campus,int HistoryID)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    string sSQL = GetDeleteCommand();
    //sSQL += sCondition;
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Cmd.Parameters.Add(new SqlParameter("@HistoryID", HistoryID ));
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
    DataTable dt = new DataTable("GradesHistory");
    DataView dv = new DataView();
    List<GradesHistory> myGradesHistorys = new List<GradesHistory>();
    try
    {
    myGradesHistorys = GetGradesHistory(InitializeModule.EnumCampus.ECTNew,sCondition,false);
    DataColumn col0= new DataColumn("HistoryID", Type.GetType("int"));
    dt.Columns.Add(col0 );
    dt.Constraints.Add(new UniqueConstraint(col0));

    DataRow dr;
    for (int i = 0; i < myGradesHistorys.Count; i++)
    {
    dr = dt.NewRow();
      dr[1] = myGradesHistorys[i].HistoryID;
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
    myGradesHistorys.Clear();
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
    sSQL += HistoryIDFN;
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
    public class GradesHistoryCls : GradesHistoryDAL
    {
    #region "Decleration"
    private int m_lngCurRow=0;
    public SqlDataAdapter daGradesHistory;
    private DataSet m_dsGradesHistory;
    public DataRow GradesHistoryDataRow ;
    #endregion
    #region "Puplic Properties"
    public DataSet dsGradesHistory
    {
    get { return m_dsGradesHistory ; }
    set { m_dsGradesHistory = value ; }
    }
    //-----------------------------------------------------
    public int lngCurRow 
    {
    get { return  m_lngCurRow ; }
    set {m_lngCurRow = value ; }
    }
    #endregion
    public GradesHistoryCls()
    {
    try
    {
    dsGradesHistory= new DataSet();

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
    public virtual SqlDataAdapter GetGradesHistoryDataAdapter(string sCondition ,SqlConnection con ) 
    {
    string sSQL =""; 
    try
    {
    sSQL = GetSQL();
    sSQL += " " + sCondition;
    //-----------------------------------------
    daGradesHistory = new SqlDataAdapter(sSQL, con);
    // Create command builder. This line automatically generates the update commands for you, so you don't
    // have to provide or create your own.
    SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daGradesHistory);
    //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    // key + unique key information to be retrieved unless AddWithKey is specified.
    daGradesHistory.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daGradesHistory;
    }
    public virtual SqlDataAdapter GetGradesHistoryDataAdapter(SqlConnection con)  
    {
    try
    {
    daGradesHistory = new SqlDataAdapter();
    //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    //'' key + unique key information to be retrieved unless AddWithKey is specified.
    daGradesHistory.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    //-----------------------------------------
    SqlParameter Parmeter = default(SqlParameter); 
    //[SELECT COMMAND]
    SqlCommand cmdGradesHistory;
    cmdGradesHistory = new SqlCommand(GetSelectCommand(), con);
    //'cmdRolePermission.Parameters.Add("@HistoryID", SqlDbType.Int, 4, "HistoryID" );
    daGradesHistory.SelectCommand = cmdGradesHistory;
    //'Add Handlers
    //'RowUpdating,RowUpdated
    AddDAEventHandler();
    //'[UPDATE COMMAND].
    cmdGradesHistory = new SqlCommand(GetUpdateCommand(), con);
    //'Delete PK Parameteres from here. b/c its declared below
    //cmdGradesHistory.Parameters.Add("@HistoryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(HistoryIDFN));
    cmdGradesHistory.Parameters.Add("@StudentID", SqlDbType.VarChar,12, LibraryMOD.GetFieldName(StudentIDFN));
    cmdGradesHistory.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
    cmdGradesHistory.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
    cmdGradesHistory.Parameters.Add("@Session", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionFN));
    cmdGradesHistory.Parameters.Add("@Course", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(CourseFN));
    cmdGradesHistory.Parameters.Add("@Section", SqlDbType.Int,4, LibraryMOD.GetFieldName(SectionFN));
    cmdGradesHistory.Parameters.Add("@GradeTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeTypeIDFN));
    cmdGradesHistory.Parameters.Add("@OldValue", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(OldValueFN));
    cmdGradesHistory.Parameters.Add("@NewValue", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(NewValueFN));
    cmdGradesHistory.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
    cmdGradesHistory.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
    cmdGradesHistory.Parameters.Add("@PCName", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(PCNameFN));
    cmdGradesHistory.Parameters.Add("@NetUserName", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(NetUserNameFN));


    Parmeter = cmdGradesHistory.Parameters.Add("@HistoryID", SqlDbType.Int ,  4, LibraryMOD.GetFieldName(HistoryIDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    //'Its should be none for batch updating
    //'UpdateCommand, InsertCommand, and DeleteCommand 
    //'should be set to None or OutputParameters
    daGradesHistory.UpdateCommand = cmdGradesHistory;
    daGradesHistory.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
    //'-------------------------------------------------------------------------
    //'/INSERT COMMAND
     cmdGradesHistory = new SqlCommand(GetInsertCommand(), con);
    cmdGradesHistory.Parameters.Add("@HistoryID", SqlDbType.Int,4, LibraryMOD.GetFieldName(HistoryIDFN));
    cmdGradesHistory.Parameters.Add("@StudentID", SqlDbType.VarChar,12, LibraryMOD.GetFieldName(StudentIDFN));
    cmdGradesHistory.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
    cmdGradesHistory.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
    cmdGradesHistory.Parameters.Add("@Session", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionFN));
    cmdGradesHistory.Parameters.Add("@Course", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(CourseFN));
    cmdGradesHistory.Parameters.Add("@Section", SqlDbType.Int,4, LibraryMOD.GetFieldName(SectionFN));
    cmdGradesHistory.Parameters.Add("@GradeTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeTypeIDFN));
    cmdGradesHistory.Parameters.Add("@OldValue", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(OldValueFN));
    cmdGradesHistory.Parameters.Add("@NewValue", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(NewValueFN));
    cmdGradesHistory.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
    cmdGradesHistory.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
    cmdGradesHistory.Parameters.Add("@PCName", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(PCNameFN));
    cmdGradesHistory.Parameters.Add("@NetUserName", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(NetUserNameFN));
    Parmeter.SourceVersion = DataRowVersion.Current;
    daGradesHistory.InsertCommand =cmdGradesHistory;
    daGradesHistory.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'------------------------
    //'/DELETE COMMAND
     cmdGradesHistory = new SqlCommand(GetDeleteCommand(), con);
    Parmeter = cmdGradesHistory.Parameters.Add("@HistoryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HistoryIDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    daGradesHistory.DeleteCommand =cmdGradesHistory;
    daGradesHistory.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'Batch Size
    //'Set the batch size.
    daGradesHistory.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daGradesHistory;
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
    dr = dsGradesHistory.Tables[TableName].NewRow();
    dr[LibraryMOD.GetFieldName(HistoryIDFN)]=HistoryID;
    dr[LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
    dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
    dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
    dr[LibraryMOD.GetFieldName(SessionFN)]=Session;
    dr[LibraryMOD.GetFieldName(CourseFN)]=Course;
    dr[LibraryMOD.GetFieldName(SectionFN)]=Section;
    dr[LibraryMOD.GetFieldName(GradeTypeIDFN)]=GradeTypeID;
    dr[LibraryMOD.GetFieldName(OldValueFN)]=OldValue;
    dr[LibraryMOD.GetFieldName(NewValueFN)]=NewValue;
    dsGradesHistory.Tables[TableName].Rows.Add(dr);
    break;
    case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
     DataRow[] drAry = null;
    drAry = dsGradesHistory.Tables[TableName].Select(LibraryMOD.GetFieldName(HistoryIDFN)  + "=" + HistoryID);
    //'its return array of rows and we can access the first by index 0
    drAry[0][LibraryMOD.GetFieldName(HistoryIDFN)]=HistoryID;
    drAry[0][LibraryMOD.GetFieldName(StudentIDFN)]=StudentID;
    drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
    drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
    drAry[0][LibraryMOD.GetFieldName(SessionFN)]=Session;
    drAry[0][LibraryMOD.GetFieldName(CourseFN)]=Course;
    drAry[0][LibraryMOD.GetFieldName(SectionFN)]=Section;
    drAry[0][LibraryMOD.GetFieldName(GradeTypeIDFN)]=GradeTypeID;
    drAry[0][LibraryMOD.GetFieldName(OldValueFN)]=OldValue;
    drAry[0][LibraryMOD.GetFieldName(NewValueFN)]=NewValue;
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
    public int CommitGradesHistory()  
    {
    //CommitGradesHistory= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //'' Update Database with SqlDataAdapter
    daGradesHistory.Update(dsGradesHistory, TableName);
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
    FindInMultiPKey(HistoryID);
    if (( GradesHistoryDataRow != null)) 
    {
    GradesHistoryDataRow.Delete();
    CommitGradesHistory();
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
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(HistoryIDFN)]== System.DBNull.Value)
    {
      HistoryID=0;
    }
    else
    {
      HistoryID = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(HistoryIDFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(StudentIDFN)]== System.DBNull.Value)
    {
      StudentID="";
    }
    else
    {
      StudentID = (string)GradesHistoryDataRow[LibraryMOD.GetFieldName(StudentIDFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
    {
      AcademicYear=0;
    }
    else
    {
      AcademicYear = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
    {
      Semester=0;
    }
    else
    {
      Semester = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(SemesterFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(SessionFN)]== System.DBNull.Value)
    {
      Session=0;
    }
    else
    {
      Session = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(SessionFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(CourseFN)]== System.DBNull.Value)
    {
      Course="";
    }
    else
    {
      Course = (string)GradesHistoryDataRow[LibraryMOD.GetFieldName(CourseFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(SectionFN)]== System.DBNull.Value)
    {
      Section=0;
    }
    else
    {
      Section = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(SectionFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(GradeTypeIDFN)]== System.DBNull.Value)
    {
      GradeTypeID=0;
    }
    else
    {
      GradeTypeID = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(GradeTypeIDFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(OldValueFN)]== System.DBNull.Value)
    {
      OldValue=0;
    }
    else
    {
      OldValue = Convert.ToDouble (  GradesHistoryDataRow[LibraryMOD.GetFieldName(OldValueFN)]);
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(NewValueFN)]== System.DBNull.Value)
    {
      NewValue=0;
    }
    else
    {
      NewValue = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(NewValueFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
    {
      CreationUserID=0;
    }
    else
    {
      CreationUserID = (int)GradesHistoryDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      CreationDate = (DateTime)GradesHistoryDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
    {
      PCName="";
    }
    else
    {
      PCName = (string)GradesHistoryDataRow[LibraryMOD.GetFieldName(PCNameFN)];
    }
    if (GradesHistoryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
    {
      NetUserName="";
    }
    else
    {
      NetUserName = (string)GradesHistoryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKHistoryID) 
    {
    //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //' Create an array for the key values to find.
    object[] findTheseVals = new object[1] ; 
    //' Set the values of the keys to find.
    findTheseVals[0] = PKHistoryID;
    GradesHistoryDataRow = dsGradesHistory.Tables[TableName].Rows.Find(findTheseVals);
    if  ((GradesHistoryDataRow !=null)) 
    {
    lngCurRow = dsGradesHistory.Tables[TableName].Rows.IndexOf(GradesHistoryDataRow);
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
      lngCurRow = dsGradesHistory.Tables[TableName].Rows.Count - 1; //'Zero based index
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
      lngCurRow = Math.Min(lngCurRow + 1, dsGradesHistory.Tables[TableName].Rows.Count - 1);
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
      if (lngCurRow >= 0 & dsGradesHistory.Tables[TableName].Rows.Count > 0) 
    {
      GradesHistoryDataRow = dsGradesHistory.Tables[TableName].Rows[lngCurRow];
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
    daGradesHistory.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daGradesHistory.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
    daGradesHistory.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daGradesHistory.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
