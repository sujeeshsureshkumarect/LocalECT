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
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

    public class LogHistory
    {
    //Creation Date: 29/06/2011 4:51 PM
    //Programmer Name : Bahaa Addin Ghaleb Najem
    //-----Decleration --------------
    #region "Decleration"
    private int m_LogID; 
    private int m_UserID; 
    private DateTime m_LoginDate; 
    private string m_PCName; 
    private string m_NetUserName; 
    private int m_SystemID; 
    private int m_ScreenID; 
    private int m_AcademicYear; 
    private int m_Semester; 
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int LogID
    {
    get { return  m_LogID; }
    set {m_LogID  = value ; }
    }
    public int UserID
    {
    get { return  m_UserID; }
    set {m_UserID  = value ; }
    }
    public DateTime LoginDate
    {
    get { return  m_LoginDate; }
    set {m_LoginDate  = value ; }
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
    public int SystemID
    {
    get { return  m_SystemID; }
    set {m_SystemID  = value ; }
    }
    public int ScreenID
    {
    get { return  m_ScreenID; }
    set {m_ScreenID  = value ; }
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
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LogHistory()
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
    public class LogHistoryDAL : LogHistory
    {
    #region "Decleration"
    private string m_TableName;
    private string m_LogIDFN ;
    private string m_UserIDFN ;
    private string m_LoginDateFN ;
    private string m_PCNameFN ;
    private string m_NetUserNameFN ;
    private string m_SystemIDFN ;
    private string m_ScreenIDFN ;
    private string m_AcademicYearFN ;
    private string m_SemesterFN ;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName 
    {
    get { return m_TableName; }
    set { m_TableName = value; }
    }
    public string LogIDFN 
    {
    get { return  m_LogIDFN; }
    set {m_LogIDFN  = value ; }
    }
    public string UserIDFN 
    {
    get { return  m_UserIDFN; }
    set {m_UserIDFN  = value ; }
    }
    public string LoginDateFN 
    {
    get { return  m_LoginDateFN; }
    set {m_LoginDateFN  = value ; }
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
    public string SystemIDFN 
    {
    get { return  m_SystemIDFN; }
    set {m_SystemIDFN  = value ; }
    }
    public string ScreenIDFN 
    {
    get { return  m_ScreenIDFN; }
    set {m_ScreenIDFN  = value ; }
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
    #endregion
    //================End Properties ===================
    public LogHistoryDAL()
    {
    try
    {
    this.TableName = "cmn_LogHistory";
    this.LogIDFN = m_TableName + ".LogID";
    this.UserIDFN = m_TableName + ".UserID";
    this.LoginDateFN = m_TableName + ".LoginDate";
    this.PCNameFN = m_TableName + ".PCName";
    this.NetUserNameFN = m_TableName + ".NetUserName";
    this.SystemIDFN = m_TableName + ".SystemID";
    this.ScreenIDFN = m_TableName + ".ScreenID";
    this.AcademicYearFN = m_TableName + ".AcademicYear";
    this.SemesterFN = m_TableName + ".Semester";
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
    sSQL +=LogIDFN;
    sSQL += " , " + UserIDFN;
    sSQL += " , " + LoginDateFN;
    sSQL += " , " + PCNameFN;
    sSQL += " , " + NetUserNameFN;
    sSQL += " , " + SystemIDFN;
    sSQL += " , " + ScreenIDFN;
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
    //-----GetListSQl Function ---------------------------------
    public string  GetListSQL(string sCondition   ) 
    {
    string sSQL  = "";
    try
    {
    sSQL = "SELECT ";
    sSQL +=LogIDFN;
    sSQL += " , " + UserIDFN;
    sSQL += " , " + LoginDateFN;
    sSQL += "  FROM " + m_TableName;
    
    if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL+=" Where " + sCondition;
        }
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
    sSQL +=LogIDFN;
    sSQL += " , " + UserIDFN;
    sSQL += " , " + LoginDateFN;
    sSQL += " , " + PCNameFN;
    sSQL += " , " + NetUserNameFN;
    sSQL += " , " + SystemIDFN;
    sSQL += " , " + ScreenIDFN;
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
    //-----Get GetUpdateCommand Function -----------------------
    public string GetUpdateCommand()  
    {
    string sSQL  = "";
    try
    {
    sSQL = "UPDATE " + TableName;
    sSQL += " SET ";
    sSQL += LibraryMOD.GetFieldName(UserIDFN) + "=@UserID";
    sSQL += " , " + LibraryMOD.GetFieldName(LoginDateFN) + "=@LoginDate";
    sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
    sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
    sSQL += " , " + LibraryMOD.GetFieldName(SystemIDFN) + "=@SystemID";
    sSQL += " , " + LibraryMOD.GetFieldName(ScreenIDFN) + "=@ScreenID";
    sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
    sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
    sSQL += " WHERE ";
    sSQL += LibraryMOD.GetFieldName(LogIDFN)+"=@LogID";
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
    sSQL +=LibraryMOD.GetFieldName(UserIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(LoginDateFN);
    sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
    sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
    sSQL += " , " + LibraryMOD.GetFieldName(SystemIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(ScreenIDFN);
    sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
    sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
    sSQL += ")";
    sSQL += " VALUES ";
    sSQL += "( ";
    sSQL += " @UserID";
    sSQL += " ,@LoginDate";
    sSQL += " ,@PCName";
    sSQL += " ,@NetUserName";
    sSQL += " ,@SystemID";
    sSQL += " ,@ScreenID";
    sSQL += " ,@AcademicYear";
    sSQL += " ,@Semester";
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
    sSQL += LibraryMOD.GetFieldName(LogIDFN)+"=@LogID";
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
    public List< LogHistory> GetLogHistory(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    {
    //' returns a list of Classes instances based on the
    //' data in the LogHistory
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
    List<LogHistory> results = new List<LogHistory>();
    try
    {
    //Default Value
    LogHistory myLogHistory = new LogHistory();
    if (isDeafaultIncluded)
    {
    //Change the code here
    myLogHistory.LogID = 0;
    //myLogHistory.LogID = "Select LogHistory ...";
    results.Add(myLogHistory);
    }
    while (reader.Read())
    {
    myLogHistory = new LogHistory();
    if (reader[LibraryMOD.GetFieldName(LogIDFN)].Equals(DBNull.Value))
    {
    myLogHistory.LogID = 0;
    }
    else
    {
    myLogHistory.LogID = int.Parse(reader[LibraryMOD.GetFieldName( LogIDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UserIDFN)].Equals(DBNull.Value))
    {
    myLogHistory.UserID = 0;
    }
    else
    {
    myLogHistory.UserID = int.Parse(reader[LibraryMOD.GetFieldName( UserIDFN) ].ToString());
    }
    if (!reader[LibraryMOD.GetFieldName(LoginDateFN)].Equals(DBNull.Value))
    {
    myLogHistory.LoginDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LoginDateFN) ].ToString());
    }
    myLogHistory.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
    myLogHistory.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
    if (reader[LibraryMOD.GetFieldName(SystemIDFN)].Equals(DBNull.Value))
    {
    myLogHistory.SystemID = 0;
    }
    else
    {
    myLogHistory.SystemID = int.Parse(reader[LibraryMOD.GetFieldName( SystemIDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(ScreenIDFN)].Equals(DBNull.Value))
    {
    myLogHistory.ScreenID = 0;
    }
    else
    {
    myLogHistory.ScreenID = int.Parse(reader[LibraryMOD.GetFieldName( ScreenIDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
    {
    myLogHistory.AcademicYear = 0;
    }
    else
    {
    myLogHistory.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
    {
    myLogHistory.Semester = 0;
    }
    else
    {
    myLogHistory.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
    }
     results.Add(myLogHistory);
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
    public List< LogHistory > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<LogHistory> results = new List<LogHistory>();
    try
    {
    //Default Value
    LogHistory myLogHistory= new LogHistory();
    if (isDeafaultIncluded)
     {
    //Change the code here
     myLogHistory.LogID = -1;
    // myLogHistory.UserID = "Select LogHistory" ;
    results.Add(myLogHistory);
     }
    while (reader.Read())
    {
    myLogHistory = new LogHistory();
    if (reader[LibraryMOD.GetFieldName(LogIDFN)].Equals(DBNull.Value))
    {
    myLogHistory.LogID = 0;
    }
    else
    {
    myLogHistory.LogID = int.Parse(reader[LibraryMOD.GetFieldName( LogIDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UserIDFN)].Equals(DBNull.Value))
    {
    myLogHistory.UserID = 0;
    }
    else
    {
    myLogHistory.UserID = int.Parse(reader[LibraryMOD.GetFieldName( UserIDFN) ].ToString());
    }
    if (!reader[LibraryMOD.GetFieldName(LoginDateFN)].Equals(DBNull.Value))
    {
    myLogHistory.LoginDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LoginDateFN) ].ToString());
    }
     results.Add(myLogHistory);
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
    public int UpdateLogHistory(InitializeModule.EnumCampus Campus, int iMode,int LogID,int UserID,DateTime LoginDate,string PCName,string NetUserName,int SystemID,int ScreenID,int AcademicYear,int Semester)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    Conn.Open();
    string sql = "";
    LogHistory theLogHistory = new LogHistory();
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
    //Cmd.Parameters.Add(new SqlParameter("@LogID",LogID));
    Cmd.Parameters.Add(new SqlParameter("@UserID",UserID));
    Cmd.Parameters.Add(new SqlParameter("@LoginDate",LoginDate));
    Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
    Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
    Cmd.Parameters.Add(new SqlParameter("@SystemID",SystemID));
    Cmd.Parameters.Add(new SqlParameter("@ScreenID",ScreenID));
    Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
    Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
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
    public int DeleteLogHistory(InitializeModule.EnumCampus Campus,string LogID)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    string sSQL = GetDeleteCommand();
    //sSQL += sCondition;
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Cmd.Parameters.Add(new SqlParameter("@LogID", LogID ));
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
    DataTable dt = new DataTable("LogHistory");
    DataView dv = new DataView();
    List<LogHistory> myLogHistorys = new List<LogHistory>();
    try
    {
    myLogHistorys = GetLogHistory(InitializeModule.EnumCampus.ECTNew,sCondition,false);
    DataColumn col0= new DataColumn("LogID", Type.GetType("int identity"));
    dt.Columns.Add(col0 );
    dt.Constraints.Add(new UniqueConstraint(col0));

    DataRow dr;
    for (int i = 0; i < myLogHistorys.Count; i++)
    {
    dr = dt.NewRow();
      dr[1] = myLogHistorys[i].LogID;
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
    myLogHistorys.Clear();
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
    sSQL += LogIDFN;
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
    public class LogHistoryCls : LogHistoryDAL
    {
    #region "Decleration"
    private int m_lngCurRow=0;
    public SqlDataAdapter daLogHistory;
    private DataSet m_dsLogHistory;
    public DataRow LogHistoryDataRow ;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLogHistory
    {
    get { return m_dsLogHistory ; }
    set { m_dsLogHistory = value ; }
    }
    //-----------------------------------------------------
    public int lngCurRow 
    {
    get { return  m_lngCurRow ; }
    set {m_lngCurRow = value ; }
    }
    #endregion
    public LogHistoryCls()
    {
    try
    {
    dsLogHistory= new DataSet();

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
    public virtual SqlDataAdapter GetLogHistoryDataAdapter(string sCondition ,SqlConnection con ) 
    {
    string sSQL =""; 
    try
    {
    sSQL = GetSQL();
    sSQL += " " + sCondition;
    //-----------------------------------------
    daLogHistory = new SqlDataAdapter(sSQL, con);
    // Create command builder. This line automatically generates the update commands for you, so you don't
    // have to provide or create your own.
    SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLogHistory);
    //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    // key + unique key information to be retrieved unless AddWithKey is specified.
    daLogHistory.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daLogHistory;
    }
    public virtual SqlDataAdapter GetLogHistoryDataAdapter(SqlConnection con)  
    {
    try
    {
    daLogHistory = new SqlDataAdapter();
    //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    //'' key + unique key information to be retrieved unless AddWithKey is specified.
    daLogHistory.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    //-----------------------------------------
    SqlParameter Parmeter = default(SqlParameter); 
    //[SELECT COMMAND]
    SqlCommand cmdLogHistory;
    cmdLogHistory = new SqlCommand(GetSelectCommand(), con);
    //'cmdRolePermission.Parameters.Add("@LogID", SqlDbType.Int, 4, "LogID" );
    daLogHistory.SelectCommand = cmdLogHistory;
    //'Add Handlers
    //'RowUpdating,RowUpdated
    AddDAEventHandler();
    //'[UPDATE COMMAND].
    cmdLogHistory = new SqlCommand(GetUpdateCommand(), con);
    //'Delete PK Parameteres from here. b/c its declared below
   
    cmdLogHistory.Parameters.Add("@UserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(UserIDFN));
    cmdLogHistory.Parameters.Add("@LoginDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LoginDateFN));
    cmdLogHistory.Parameters.Add("@PCName", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(PCNameFN));
    cmdLogHistory.Parameters.Add("@NetUserName", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(NetUserNameFN));
    cmdLogHistory.Parameters.Add("@SystemID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SystemIDFN));
    cmdLogHistory.Parameters.Add("@ScreenID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ScreenIDFN));
    cmdLogHistory.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
    cmdLogHistory.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));


    Parmeter = cmdLogHistory.Parameters.Add("@LogID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LogIDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    //'Its should be none for batch updating
    //'UpdateCommand, InsertCommand, and DeleteCommand 
    //'should be set to None or OutputParameters
    daLogHistory.UpdateCommand = cmdLogHistory;
    daLogHistory.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
    //'-------------------------------------------------------------------------
    //'/INSERT COMMAND
     cmdLogHistory = new SqlCommand(GetInsertCommand(), con);
    cmdLogHistory.Parameters.Add("@LogID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LogIDFN));
    cmdLogHistory.Parameters.Add("@UserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(UserIDFN));
    cmdLogHistory.Parameters.Add("@LoginDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LoginDateFN));
    cmdLogHistory.Parameters.Add("@PCName", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(PCNameFN));
    cmdLogHistory.Parameters.Add("@NetUserName", SqlDbType.VarChar,30, LibraryMOD.GetFieldName(NetUserNameFN));
    cmdLogHistory.Parameters.Add("@SystemID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SystemIDFN));
    cmdLogHistory.Parameters.Add("@ScreenID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ScreenIDFN));
    cmdLogHistory.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
    cmdLogHistory.Parameters.Add("@Semester", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterFN));
    Parmeter.SourceVersion = DataRowVersion.Current;
    daLogHistory.InsertCommand =cmdLogHistory;
    daLogHistory.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'------------------------
    //'/DELETE COMMAND
     cmdLogHistory = new SqlCommand(GetDeleteCommand(), con);
    Parmeter = cmdLogHistory.Parameters.Add("@LogID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LogIDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    daLogHistory.DeleteCommand =cmdLogHistory;
    daLogHistory.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'Batch Size
    //'Set the batch size.
    daLogHistory.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daLogHistory;
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
    dr = dsLogHistory.Tables[TableName].NewRow();
    dr[LibraryMOD.GetFieldName(LogIDFN)]=LogID;
    dr[LibraryMOD.GetFieldName(UserIDFN)]=UserID;
    dr[LibraryMOD.GetFieldName(LoginDateFN)]=LoginDate;
    dr[LibraryMOD.GetFieldName(SystemIDFN)]=SystemID;
    dr[LibraryMOD.GetFieldName(ScreenIDFN)]=ScreenID;
    dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
    dr[LibraryMOD.GetFieldName(SemesterFN)]=Semester;
    dsLogHistory.Tables[TableName].Rows.Add(dr);
    break;
    case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
     DataRow[] drAry = null;
    drAry = dsLogHistory.Tables[TableName].Select(LibraryMOD.GetFieldName(LogIDFN)  + "=" + LogID);
    //'its return array of rows and we can access the first by index 0
    drAry[0][LibraryMOD.GetFieldName(LogIDFN)]=LogID;
    drAry[0][LibraryMOD.GetFieldName(UserIDFN)]=UserID;
    drAry[0][LibraryMOD.GetFieldName(LoginDateFN)]=LoginDate;
    drAry[0][LibraryMOD.GetFieldName(SystemIDFN)]=SystemID;
    drAry[0][LibraryMOD.GetFieldName(ScreenIDFN)]=ScreenID;
    drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
    drAry[0][LibraryMOD.GetFieldName(SemesterFN)]=Semester;
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
    public int CommitLogHistory()  
    {
    //CommitLogHistory= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //'' Update Database with SqlDataAdapter
    daLogHistory.Update(dsLogHistory, TableName);
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
    FindInMultiPKey(LogID);
    if (( LogHistoryDataRow != null)) 
    {
    LogHistoryDataRow.Delete();
    CommitLogHistory();
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
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(LogIDFN)]== System.DBNull.Value)
    {
      LogID=0;
    }
    else
    {
      LogID = (int)LogHistoryDataRow[LibraryMOD.GetFieldName(LogIDFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(UserIDFN)]== System.DBNull.Value)
    {
      UserID=0;
    }
    else
    {
      UserID = (int)LogHistoryDataRow[LibraryMOD.GetFieldName(UserIDFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(LoginDateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      LoginDate = (DateTime)LogHistoryDataRow[LibraryMOD.GetFieldName(LoginDateFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
    {
      PCName="";
    }
    else
    {
      PCName = (string)LogHistoryDataRow[LibraryMOD.GetFieldName(PCNameFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
    {
      NetUserName="";
    }
    else
    {
      NetUserName = (string)LogHistoryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(SystemIDFN)]== System.DBNull.Value)
    {
      SystemID=0;
    }
    else
    {
      SystemID = (int)LogHistoryDataRow[LibraryMOD.GetFieldName(SystemIDFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(ScreenIDFN)]== System.DBNull.Value)
    {
      ScreenID=0;
    }
    else
    {
      ScreenID = (int)LogHistoryDataRow[LibraryMOD.GetFieldName(ScreenIDFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
    {
      AcademicYear=0;
    }
    else
    {
      AcademicYear = (int)LogHistoryDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
    }
    if (LogHistoryDataRow[LibraryMOD.GetFieldName(SemesterFN)]== System.DBNull.Value)
    {
      Semester=0;
    }
    else
    {
      Semester = (int)LogHistoryDataRow[LibraryMOD.GetFieldName(SemesterFN)];
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
    public int FindInMultiPKey(int PKLogID) 
    {
    //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //' Create an array for the key values to find.
    object[] findTheseVals = new object[1] ; 
    //' Set the values of the keys to find.
    findTheseVals[0] = PKLogID;
    LogHistoryDataRow = dsLogHistory.Tables[TableName].Rows.Find(findTheseVals);
    if  ((LogHistoryDataRow !=null)) 
    {
    lngCurRow = dsLogHistory.Tables[TableName].Rows.IndexOf(LogHistoryDataRow);
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
      lngCurRow = dsLogHistory.Tables[TableName].Rows.Count - 1; //'Zero based index
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
      lngCurRow = Math.Min(lngCurRow + 1, dsLogHistory.Tables[TableName].Rows.Count - 1);
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
      if (lngCurRow >= 0 & dsLogHistory.Tables[TableName].Rows.Count > 0) 
    {
      LogHistoryDataRow = dsLogHistory.Tables[TableName].Rows[lngCurRow];
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
    daLogHistory.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daLogHistory.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
    daLogHistory.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daLogHistory.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
