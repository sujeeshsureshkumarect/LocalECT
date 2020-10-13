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
public class FinalExam_StudentSchedule_H
{
    //Creation Date: 20/05/2014 6:58 PM
    //Programmer Name : Bahaa Addin Ghaleb
    //-----Decleration --------------
    #region "Decleration"
    private int m_iSerial; 
    private int m_iYear; 
    private int m_iSemester; 
    private string m_sCourse; 
    private int m_iShift; 
    private int m_iClass; 
    private int m_iClass_PartNo; 
    private string m_sHall; 
    private int m_iProctor1; 
    private int m_iProctor2; 
    private int m_iProctor3; 
    private string m_strUserCreate; 
    private DateTime m_dateCreate; 
    private string m_strUserSave; 
    private DateTime m_dateLastSave; 
    private string m_strMachine; 
    private string m_strNUser; 
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int iSerial
    {
    get { return  m_iSerial; }
    set {m_iSerial  = value ; }
    }
    public int iYear
    {
    get { return  m_iYear; }
    set {m_iYear  = value ; }
    }
    public int iSemester
    {
    get { return  m_iSemester; }
    set {m_iSemester  = value ; }
    }
    public string sCourse
    {
    get { return  m_sCourse; }
    set {m_sCourse  = value ; }
    }
    public int iShift
    {
    get { return  m_iShift; }
    set {m_iShift  = value ; }
    }
    public int iClass
    {
    get { return  m_iClass; }
    set {m_iClass  = value ; }
    }
    public int iClass_PartNo
    {
    get { return  m_iClass_PartNo; }
    set {m_iClass_PartNo  = value ; }
    }
    public string sHall
    {
    get { return  m_sHall; }
    set {m_sHall  = value ; }
    }
    public int iProctor1
    {
    get { return  m_iProctor1; }
    set {m_iProctor1  = value ; }
    }
    public int iProctor2
    {
    get { return  m_iProctor2; }
    set {m_iProctor2  = value ; }
    }
    public int iProctor3
    {
    get { return  m_iProctor3; }
    set {m_iProctor3  = value ; }
    }
    public string strUserCreate
    {
    get { return  m_strUserCreate; }
    set {m_strUserCreate  = value ; }
    }
    public DateTime dateCreate
    {
    get { return  m_dateCreate; }
    set {m_dateCreate  = value ; }
    }
    public string strUserSave
    {
    get { return  m_strUserSave; }
    set {m_strUserSave  = value ; }
    }
    public DateTime dateLastSave
    {
    get { return  m_dateLastSave; }
    set {m_dateLastSave  = value ; }
    }
    public string strMachine
    {
    get { return  m_strMachine; }
    set {m_strMachine  = value ; }
    }
    public string strNUser
    {
    get { return  m_strNUser; }
    set {m_strNUser  = value ; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public FinalExam_StudentSchedule_H()
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
public class FinalExam_StudentSchedule_HDAL : FinalExam_StudentSchedule_H
    {
    #region "Decleration"
    private string m_TableName;
    private string m_iSerialFN ;
    private string m_iYearFN ;
    private string m_iSemesterFN ;
    private string m_sCourseFN ;
    private string m_iShiftFN ;
    private string m_iClassFN ;
    private string m_iClass_PartNoFN ;
    private string m_sHallFN ;
    private string m_iProctor1FN ;
    private string m_iProctor2FN ;
    private string m_iProctor3FN ;
    private string m_strUserCreateFN ;
    private string m_dateCreateFN ;
    private string m_strUserSaveFN ;
    private string m_dateLastSaveFN ;
    private string m_strMachineFN ;
    private string m_strNUserFN ;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName 
    {
    get { return m_TableName; }
    set { m_TableName = value; }
    }
    public string iSerialFN 
    {
    get { return  m_iSerialFN; }
    set {m_iSerialFN  = value ; }
    }
    public string iYearFN 
    {
    get { return  m_iYearFN; }
    set {m_iYearFN  = value ; }
    }
    public string iSemesterFN 
    {
    get { return  m_iSemesterFN; }
    set {m_iSemesterFN  = value ; }
    }
    public string sCourseFN 
    {
    get { return  m_sCourseFN; }
    set {m_sCourseFN  = value ; }
    }
    public string iShiftFN 
    {
    get { return  m_iShiftFN; }
    set {m_iShiftFN  = value ; }
    }
    public string iClassFN 
    {
    get { return  m_iClassFN; }
    set {m_iClassFN  = value ; }
    }
    public string iClass_PartNoFN 
    {
    get { return  m_iClass_PartNoFN; }
    set {m_iClass_PartNoFN  = value ; }
    }
    public string sHallFN 
    {
    get { return  m_sHallFN; }
    set {m_sHallFN  = value ; }
    }
    public string iProctor1FN 
    {
    get { return  m_iProctor1FN; }
    set {m_iProctor1FN  = value ; }
    }
    public string iProctor2FN 
    {
    get { return  m_iProctor2FN; }
    set {m_iProctor2FN  = value ; }
    }
    public string iProctor3FN 
    {
    get { return  m_iProctor3FN; }
    set {m_iProctor3FN  = value ; }
    }
    public string strUserCreateFN 
    {
    get { return  m_strUserCreateFN; }
    set {m_strUserCreateFN  = value ; }
    }
    public string dateCreateFN 
    {
    get { return  m_dateCreateFN; }
    set {m_dateCreateFN  = value ; }
    }
    public string strUserSaveFN 
    {
    get { return  m_strUserSaveFN; }
    set {m_strUserSaveFN  = value ; }
    }
    public string dateLastSaveFN 
    {
    get { return  m_dateLastSaveFN; }
    set {m_dateLastSaveFN  = value ; }
    }
    public string strMachineFN 
    {
    get { return  m_strMachineFN; }
    set {m_strMachineFN  = value ; }
    }
    public string strNUserFN 
    {
    get { return  m_strNUserFN; }
    set {m_strNUserFN  = value ; }
    }
    #endregion
    //================End Properties ===================
    public FinalExam_StudentSchedule_HDAL()
    {
    try
    {
    this.TableName = "Reg_FinalExam_StudentSchedule_H";
    this.iSerialFN = m_TableName + ".iSerial";
    this.iYearFN = m_TableName + ".iYear";
    this.iSemesterFN = m_TableName + ".iSemester";
    this.sCourseFN = m_TableName + ".sCourse";
    this.iShiftFN = m_TableName + ".iShift";
    this.iClassFN = m_TableName + ".iClass";
    this.iClass_PartNoFN = m_TableName + ".iClass_PartNo";
    this.sHallFN = m_TableName + ".sHall";
    this.iProctor1FN = m_TableName + ".iProctor1";
    this.iProctor2FN = m_TableName + ".iProctor2";
    this.iProctor3FN = m_TableName + ".iProctor3";
    this.strUserCreateFN = m_TableName + ".strUserCreate";
    this.dateCreateFN = m_TableName + ".dateCreate";
    this.strUserSaveFN = m_TableName + ".strUserSave";
    this.dateLastSaveFN = m_TableName + ".dateLastSave";
    this.strMachineFN = m_TableName + ".strMachine";
    this.strNUserFN = m_TableName + ".strNUser";
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
    sSQL +=iSerialFN;
    sSQL += " , " + iYearFN;
    sSQL += " , " + iSemesterFN;
    sSQL += " , " + sCourseFN;
    sSQL += " , " + iShiftFN;
    sSQL += " , " + iClassFN;
    sSQL += " , " + iClass_PartNoFN;
    sSQL += " , " + sHallFN;
    sSQL += " , " + iProctor1FN;
    sSQL += " , " + iProctor2FN;
    sSQL += " , " + iProctor3FN;
    sSQL += " , " + strUserCreateFN;
    sSQL += " , " + dateCreateFN;
    sSQL += " , " + strUserSaveFN;
    sSQL += " , " + dateLastSaveFN;
    sSQL += " , " + strMachineFN;
    sSQL += " , " + strNUserFN;
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
    public string GetListSQL(string sCondition) 
    {
    string sSQL  = "";
    try
    {

    sSQL = "SELECT ";
    sSQL +=iSerialFN;
    sSQL += " , " + iYearFN;
    sSQL += " , " + iSemesterFN;
    sSQL += "  FROM " + m_TableName;
    sSQL += sCondition;

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
    sSQL +=iSerialFN;
    sSQL += " , " + iYearFN;
    sSQL += " , " + iSemesterFN;
    sSQL += " , " + sCourseFN;
    sSQL += " , " + iShiftFN;
    sSQL += " , " + iClassFN;
    sSQL += " , " + iClass_PartNoFN;
    sSQL += " , " + sHallFN;
    sSQL += " , " + iProctor1FN;
    sSQL += " , " + iProctor2FN;
    sSQL += " , " + iProctor3FN;
    sSQL += " , " + strUserCreateFN;
    sSQL += " , " + dateCreateFN;
    sSQL += " , " + strUserSaveFN;
    sSQL += " , " + dateLastSaveFN;
    sSQL += " , " + strMachineFN;
    sSQL += " , " + strNUserFN;
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
    sSQL += LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
    sSQL += " , " + LibraryMOD.GetFieldName(iYearFN) + "=@iYear";
    sSQL += " , " + LibraryMOD.GetFieldName(iSemesterFN) + "=@iSemester";
    sSQL += " , " + LibraryMOD.GetFieldName(sCourseFN) + "=@sCourse";
    sSQL += " , " + LibraryMOD.GetFieldName(iShiftFN) + "=@iShift";
    sSQL += " , " + LibraryMOD.GetFieldName(iClassFN) + "=@iClass";
    sSQL += " , " + LibraryMOD.GetFieldName(iClass_PartNoFN) + "=@iClass_PartNo";
    sSQL += " , " + LibraryMOD.GetFieldName(sHallFN) + "=@sHall";
    sSQL += " , " + LibraryMOD.GetFieldName(iProctor1FN) + "=@iProctor1";
    sSQL += " , " + LibraryMOD.GetFieldName(iProctor2FN) + "=@iProctor2";
    sSQL += " , " + LibraryMOD.GetFieldName(iProctor3FN) + "=@iProctor3";
    sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
    sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
    sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
    sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
    sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
    sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
    sSQL += " WHERE ";
    sSQL += LibraryMOD.GetFieldName(iSerialFN)+"=@iSerial";
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
    sSQL +=LibraryMOD.GetFieldName(iSerialFN);
    sSQL += " , " + LibraryMOD.GetFieldName(iYearFN);
    sSQL += " , " + LibraryMOD.GetFieldName(iSemesterFN);
    sSQL += " , " + LibraryMOD.GetFieldName(sCourseFN);
    sSQL += " , " + LibraryMOD.GetFieldName(iShiftFN);
    sSQL += " , " + LibraryMOD.GetFieldName(iClassFN);
    sSQL += " , " + LibraryMOD.GetFieldName(iClass_PartNoFN);
    sSQL += " , " + LibraryMOD.GetFieldName(sHallFN);
    sSQL += " , " + LibraryMOD.GetFieldName(iProctor1FN);
    sSQL += " , " + LibraryMOD.GetFieldName(iProctor2FN);
    sSQL += " , " + LibraryMOD.GetFieldName(iProctor3FN);
    sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
    sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
    sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
    sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
    sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
    sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
    sSQL += ")";
    sSQL += " VALUES ";
    sSQL += "( ";
    sSQL += " @iSerial";
    sSQL += " ,@iYear";
    sSQL += " ,@iSemester";
    sSQL += " ,@sCourse";
    sSQL += " ,@iShift";
    sSQL += " ,@iClass";
    sSQL += " ,@iClass_PartNo";
    sSQL += " ,@sHall";
    sSQL += " ,@iProctor1";
    sSQL += " ,@iProctor2";
    sSQL += " ,@iProctor3";
    sSQL += " ,@strUserCreate";
    sSQL += " ,@dateCreate";
    sSQL += " ,@strUserSave";
    sSQL += " ,@dateLastSave";
    sSQL += " ,@strMachine";
    sSQL += " ,@strNUser";
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
    sSQL += LibraryMOD.GetFieldName(iSerialFN)+"=@iSerial";
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
    public List< FinalExam_StudentSchedule_H> GetFinalExam_StudentSchedule_H(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    {
    //' returns a list of Classes instances based on the
    //' data in the FinalExam_StudentSchedule_H
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
    List<FinalExam_StudentSchedule_H> results = new List<FinalExam_StudentSchedule_H>();
    try
    {
    //Default Value
    FinalExam_StudentSchedule_H myFinalExam_StudentSchedule_H = new FinalExam_StudentSchedule_H();
    if (isDeafaultIncluded)
    {
    //Change the code here
    myFinalExam_StudentSchedule_H.iSerial = 0;
    //myFinalExam_StudentSchedule_H.iSerial = "Select FinalExam_StudentSchedule_H ...";

    results.Add(myFinalExam_StudentSchedule_H);
    }
    while (reader.Read())
    {
    myFinalExam_StudentSchedule_H = new FinalExam_StudentSchedule_H();
    if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iSerial = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iYearFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iYear = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iYear = int.Parse(reader[LibraryMOD.GetFieldName( iYearFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iSemesterFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iSemester = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iSemester = int.Parse(reader[LibraryMOD.GetFieldName( iSemesterFN) ].ToString());
    }
    myFinalExam_StudentSchedule_H.sCourse =reader[LibraryMOD.GetFieldName( sCourseFN) ].ToString();
    if (reader[LibraryMOD.GetFieldName(iShiftFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iShift = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iShift = int.Parse(reader[LibraryMOD.GetFieldName( iShiftFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iClassFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iClass = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iClass = int.Parse(reader[LibraryMOD.GetFieldName( iClassFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iClass_PartNoFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iClass_PartNo = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iClass_PartNo = int.Parse(reader[LibraryMOD.GetFieldName( iClass_PartNoFN) ].ToString());
    }
    myFinalExam_StudentSchedule_H.sHall =reader[LibraryMOD.GetFieldName( sHallFN) ].ToString();
    if (reader[LibraryMOD.GetFieldName(iProctor1FN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iProctor1 = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iProctor1 = int.Parse(reader[LibraryMOD.GetFieldName( iProctor1FN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iProctor2FN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iProctor2 = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iProctor2 = int.Parse(reader[LibraryMOD.GetFieldName( iProctor2FN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iProctor3FN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iProctor3 = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iProctor3 = int.Parse(reader[LibraryMOD.GetFieldName( iProctor3FN) ].ToString());
    }
    myFinalExam_StudentSchedule_H.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
    }
    myFinalExam_StudentSchedule_H.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
    }
    myFinalExam_StudentSchedule_H.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
    myFinalExam_StudentSchedule_H.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
     results.Add(myFinalExam_StudentSchedule_H);
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
    public List< FinalExam_StudentSchedule_H > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<FinalExam_StudentSchedule_H> results = new List<FinalExam_StudentSchedule_H>();
    try
    {
    //Default Value
    FinalExam_StudentSchedule_H myFinalExam_StudentSchedule_H= new FinalExam_StudentSchedule_H();
    if (isDeafaultIncluded)
     {
    //Change the code here
     myFinalExam_StudentSchedule_H.iSerial = -1;
     //myFinalExam_StudentSchedule_H.iYear = "Select FinalExam_StudentSchedule_H" ;
    results.Add(myFinalExam_StudentSchedule_H);
     }
    while (reader.Read())
    {
    myFinalExam_StudentSchedule_H = new FinalExam_StudentSchedule_H();
    if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iSerial = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iYearFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iYear = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iYear = int.Parse(reader[LibraryMOD.GetFieldName( iYearFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(iSemesterFN)].Equals(DBNull.Value))
    {
    myFinalExam_StudentSchedule_H.iSemester = 0;
    }
    else
    {
    myFinalExam_StudentSchedule_H.iSemester = int.Parse(reader[LibraryMOD.GetFieldName( iSemesterFN) ].ToString());
    }
     results.Add(myFinalExam_StudentSchedule_H);
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
    public int UpdateFinalExam_StudentSchedule_H(InitializeModule.EnumCampus Campus, int iMode,int iSerial,int iYear,int iSemester,string sCourse,int iShift,int iClass,int iClass_PartNo,string sHall,int iProctor1,int iProctor2,int iProctor3,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    Conn.Open();
    string sql = "";
    FinalExam_StudentSchedule_H theFinalExam_StudentSchedule_H = new FinalExam_StudentSchedule_H();
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
    Cmd.Parameters.Add(new SqlParameter("@iSerial",iSerial));
    Cmd.Parameters.Add(new SqlParameter("@iYear",iYear));
    Cmd.Parameters.Add(new SqlParameter("@iSemester",iSemester));
    Cmd.Parameters.Add(new SqlParameter("@sCourse",sCourse));
    Cmd.Parameters.Add(new SqlParameter("@iShift",iShift));
    Cmd.Parameters.Add(new SqlParameter("@iClass",iClass));
    Cmd.Parameters.Add(new SqlParameter("@iClass_PartNo",iClass_PartNo));
    Cmd.Parameters.Add(new SqlParameter("@sHall",sHall));
    Cmd.Parameters.Add(new SqlParameter("@iProctor1",iProctor1));
    Cmd.Parameters.Add(new SqlParameter("@iProctor2",iProctor2));
    Cmd.Parameters.Add(new SqlParameter("@iProctor3",iProctor3));
    Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
    Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
    Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
    Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
    Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
    Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));
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
    public int DeleteFinalExam_StudentSchedule_H(InitializeModule.EnumCampus Campus,string iSerial)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    string sSQL = GetDeleteCommand();
    //sSQL += sCondition;
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Cmd.Parameters.Add(new SqlParameter("@iSerial", iSerial ));
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
    DataTable dt = new DataTable("FinalExam_StudentSchedule_H");
    DataView dv = new DataView();
    List<FinalExam_StudentSchedule_H> myFinalExam_StudentSchedule_Hs = new List<FinalExam_StudentSchedule_H>();
    try
    {
    myFinalExam_StudentSchedule_Hs = GetFinalExam_StudentSchedule_H(InitializeModule.EnumCampus.ECTNew,sCondition,false);
    DataColumn col0= new DataColumn("iSerial", Type.GetType("int"));
    dt.Columns.Add(col0 );
   
    dt.Constraints.Add(new UniqueConstraint(col0));

    DataRow dr;
    for (int i = 0; i < myFinalExam_StudentSchedule_Hs.Count; i++)
    {
    dr = dt.NewRow();
      dr[1] = myFinalExam_StudentSchedule_Hs[i].iSerial;
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
    myFinalExam_StudentSchedule_Hs.Clear();
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
    sSQL += iSerialFN;
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
public class FinalExam_StudentSchedule_HCls : FinalExam_StudentSchedule_HDAL
    {
    #region "Decleration"
    private int m_lngCurRow=0;
    public SqlDataAdapter daFinalExam_StudentSchedule_H;
    private DataSet m_dsFinalExam_StudentSchedule_H;
    public DataRow FinalExam_StudentSchedule_HDataRow ;
    #endregion
    #region "Puplic Properties"
    public DataSet dsFinalExam_StudentSchedule_H
    {
    get { return m_dsFinalExam_StudentSchedule_H ; }
    set { m_dsFinalExam_StudentSchedule_H = value ; }
    }
    //-----------------------------------------------------
    public int lngCurRow 
    {
    get { return  m_lngCurRow ; }
    set {m_lngCurRow = value ; }
    }
    #endregion
    public FinalExam_StudentSchedule_HCls()
    {
    try
    {
    dsFinalExam_StudentSchedule_H= new DataSet();

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
    public virtual SqlDataAdapter GetFinalExam_StudentSchedule_HDataAdapter(string sCondition ,SqlConnection con ) 
    {
    string sSQL =""; 
    try
    {
    sSQL = GetSQL();
    sSQL += " " + sCondition;
    //-----------------------------------------
    daFinalExam_StudentSchedule_H = new SqlDataAdapter(sSQL, con);
    // Create command builder. This line automatically generates the update commands for you, so you don't
    // have to provide or create your own.
    SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daFinalExam_StudentSchedule_H);
    //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    // key + unique key information to be retrieved unless AddWithKey is specified.
    daFinalExam_StudentSchedule_H.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daFinalExam_StudentSchedule_H;
    }
    public virtual SqlDataAdapter GetFinalExam_StudentSchedule_HDataAdapter(SqlConnection con)  
    {
    try
    {
    daFinalExam_StudentSchedule_H = new SqlDataAdapter();
    //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    //'' key + unique key information to be retrieved unless AddWithKey is specified.
    daFinalExam_StudentSchedule_H.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    //-----------------------------------------
    SqlParameter Parmeter = default(SqlParameter); 
    //[SELECT COMMAND]
    SqlCommand cmdFinalExam_StudentSchedule_H;
    cmdFinalExam_StudentSchedule_H = new SqlCommand(GetSelectCommand(), con);
    //'cmdRolePermission.Parameters.Add("@iSerial", SqlDbType.Int, 4, "iSerial" );
    daFinalExam_StudentSchedule_H.SelectCommand = cmdFinalExam_StudentSchedule_H;
    //'Add Handlers
    //'RowUpdating,RowUpdated
    AddDAEventHandler();
    //'[UPDATE COMMAND].
    cmdFinalExam_StudentSchedule_H = new SqlCommand(GetUpdateCommand(), con);
    //'Delete PK Parameteres from here. b/c its declared below
    //cmdFinalExam_StudentSchedule_H.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(iYearFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iSemester", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSemesterFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@sCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(sCourseFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iShift", SqlDbType.Int,4, LibraryMOD.GetFieldName(iShiftFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iClass", SqlDbType.Int,4, LibraryMOD.GetFieldName(iClassFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iClass_PartNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(iClass_PartNoFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@sHall", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(sHallFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iProctor1", SqlDbType.Int,4, LibraryMOD.GetFieldName(iProctor1FN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iProctor2", SqlDbType.Int,4, LibraryMOD.GetFieldName(iProctor2FN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iProctor3", SqlDbType.Int,4, LibraryMOD.GetFieldName(iProctor3FN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


    Parmeter = cmdFinalExam_StudentSchedule_H.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    //'Its should be none for batch updating
    //'UpdateCommand, InsertCommand, and DeleteCommand 
    //'should be set to None or OutputParameters
    daFinalExam_StudentSchedule_H.UpdateCommand = cmdFinalExam_StudentSchedule_H;
    daFinalExam_StudentSchedule_H.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
    //'-------------------------------------------------------------------------
    //'/INSERT COMMAND
     cmdFinalExam_StudentSchedule_H = new SqlCommand(GetInsertCommand(), con);
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(iYearFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iSemester", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSemesterFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@sCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(sCourseFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iShift", SqlDbType.Int,4, LibraryMOD.GetFieldName(iShiftFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iClass", SqlDbType.Int,4, LibraryMOD.GetFieldName(iClassFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iClass_PartNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(iClass_PartNoFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@sHall", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(sHallFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iProctor1", SqlDbType.Int,4, LibraryMOD.GetFieldName(iProctor1FN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iProctor2", SqlDbType.Int,4, LibraryMOD.GetFieldName(iProctor2FN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@iProctor3", SqlDbType.Int,4, LibraryMOD.GetFieldName(iProctor3FN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
    cmdFinalExam_StudentSchedule_H.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
    Parmeter.SourceVersion = DataRowVersion.Current;
    daFinalExam_StudentSchedule_H.InsertCommand =cmdFinalExam_StudentSchedule_H;
    daFinalExam_StudentSchedule_H.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'------------------------
    //'/DELETE COMMAND
     cmdFinalExam_StudentSchedule_H = new SqlCommand(GetDeleteCommand(), con);
    Parmeter = cmdFinalExam_StudentSchedule_H.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    daFinalExam_StudentSchedule_H.DeleteCommand =cmdFinalExam_StudentSchedule_H;
    daFinalExam_StudentSchedule_H.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'Batch Size
    //'Set the batch size.
    daFinalExam_StudentSchedule_H.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daFinalExam_StudentSchedule_H;
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
    dr = dsFinalExam_StudentSchedule_H.Tables[TableName].NewRow();
    dr[LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
    dr[LibraryMOD.GetFieldName(iYearFN)]=iYear;
    dr[LibraryMOD.GetFieldName(iSemesterFN)]=iSemester;
    dr[LibraryMOD.GetFieldName(sCourseFN)]=sCourse;
    dr[LibraryMOD.GetFieldName(iShiftFN)]=iShift;
    dr[LibraryMOD.GetFieldName(iClassFN)]=iClass;
    dr[LibraryMOD.GetFieldName(iClass_PartNoFN)]=iClass_PartNo;
    dr[LibraryMOD.GetFieldName(sHallFN)]=sHall;
    dr[LibraryMOD.GetFieldName(iProctor1FN)]=iProctor1;
    dr[LibraryMOD.GetFieldName(iProctor2FN)]=iProctor2;
    dr[LibraryMOD.GetFieldName(iProctor3FN)]=iProctor3;
    dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
    dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
    dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
    dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
    dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
    dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
    dsFinalExam_StudentSchedule_H.Tables[TableName].Rows.Add(dr);
    break;
    case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
     DataRow[] drAry = null;
    drAry = dsFinalExam_StudentSchedule_H.Tables[TableName].Select(LibraryMOD.GetFieldName(iSerialFN)  + "=" + iSerial);
    //'its return array of rows and we can access the first by index 0
    drAry[0][LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
    drAry[0][LibraryMOD.GetFieldName(iYearFN)]=iYear;
    drAry[0][LibraryMOD.GetFieldName(iSemesterFN)]=iSemester;
    drAry[0][LibraryMOD.GetFieldName(sCourseFN)]=sCourse;
    drAry[0][LibraryMOD.GetFieldName(iShiftFN)]=iShift;
    drAry[0][LibraryMOD.GetFieldName(iClassFN)]=iClass;
    drAry[0][LibraryMOD.GetFieldName(iClass_PartNoFN)]=iClass_PartNo;
    drAry[0][LibraryMOD.GetFieldName(sHallFN)]=sHall;
    drAry[0][LibraryMOD.GetFieldName(iProctor1FN)]=iProctor1;
    drAry[0][LibraryMOD.GetFieldName(iProctor2FN)]=iProctor2;
    drAry[0][LibraryMOD.GetFieldName(iProctor3FN)]=iProctor3;
    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
    drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
    drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
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
    public int CommitFinalExam_StudentSchedule_H()  
    {
    //CommitFinalExam_StudentSchedule_H= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //'' Update Database with SqlDataAdapter
    daFinalExam_StudentSchedule_H.Update(dsFinalExam_StudentSchedule_H, TableName);
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
    FindInMultiPKey(iSerial);
    if (( FinalExam_StudentSchedule_HDataRow != null)) 
    {
    FinalExam_StudentSchedule_HDataRow.Delete();
    CommitFinalExam_StudentSchedule_H();
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
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iSerialFN)]== System.DBNull.Value)
    {
      iSerial=0;
    }
    else
    {
      iSerial = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iSerialFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iYearFN)]== System.DBNull.Value)
    {
      iYear=0;
    }
    else
    {
      iYear = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iYearFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iSemesterFN)]== System.DBNull.Value)
    {
      iSemester=0;
    }
    else
    {
      iSemester = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iSemesterFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(sCourseFN)]== System.DBNull.Value)
    {
      sCourse="";
    }
    else
    {
      sCourse = (string)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(sCourseFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iShiftFN)]== System.DBNull.Value)
    {
      iShift=0;
    }
    else
    {
      iShift = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iShiftFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iClassFN)]== System.DBNull.Value)
    {
      iClass=0;
    }
    else
    {
      iClass = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iClassFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iClass_PartNoFN)]== System.DBNull.Value)
    {
      iClass_PartNo=0;
    }
    else
    {
      iClass_PartNo = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iClass_PartNoFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(sHallFN)]== System.DBNull.Value)
    {
      sHall="";
    }
    else
    {
      sHall = (string)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(sHallFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iProctor1FN)]== System.DBNull.Value)
    {
      iProctor1=0;
    }
    else
    {
      iProctor1 = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iProctor1FN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iProctor2FN)]== System.DBNull.Value)
    {
      iProctor2=0;
    }
    else
    {
      iProctor2 = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iProctor2FN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iProctor3FN)]== System.DBNull.Value)
    {
      iProctor3=0;
    }
    else
    {
      iProctor3 = (int)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(iProctor3FN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
    {
      strUserCreate="";
    }
    else
    {
      strUserCreate = (string)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      dateCreate = (DateTime)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
    {
      strUserSave="";
    }
    else
    {
      strUserSave = (string)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
    {
    }
    else
    {
      dateLastSave = (DateTime)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
    {
      strMachine="";
    }
    else
    {
      strMachine = (string)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strMachineFN)];
    }
    if (FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
    {
      strNUser="";
    }
    else
    {
      strNUser = (string)FinalExam_StudentSchedule_HDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKiSerial) 
    {
    //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //' Create an array for the key values to find.
    object[] findTheseVals = new object[1] ; 
    //' Set the values of the keys to find.
    findTheseVals[0] = PKiSerial;
    FinalExam_StudentSchedule_HDataRow = dsFinalExam_StudentSchedule_H.Tables[TableName].Rows.Find(findTheseVals);
    if  ((FinalExam_StudentSchedule_HDataRow !=null)) 
    {
    lngCurRow = dsFinalExam_StudentSchedule_H.Tables[TableName].Rows.IndexOf(FinalExam_StudentSchedule_HDataRow);
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
      lngCurRow = dsFinalExam_StudentSchedule_H.Tables[TableName].Rows.Count - 1; //'Zero based index
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
      lngCurRow = Math.Min(lngCurRow + 1, dsFinalExam_StudentSchedule_H.Tables[TableName].Rows.Count - 1);
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
      if (lngCurRow >= 0 & dsFinalExam_StudentSchedule_H.Tables[TableName].Rows.Count > 0) 
    {
      FinalExam_StudentSchedule_HDataRow = dsFinalExam_StudentSchedule_H.Tables[TableName].Rows[lngCurRow];
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
    daFinalExam_StudentSchedule_H.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daFinalExam_StudentSchedule_H.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
    daFinalExam_StudentSchedule_H.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daFinalExam_StudentSchedule_H.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
