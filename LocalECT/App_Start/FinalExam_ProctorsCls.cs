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
public class FinalExam_Proctors
    {
    //Creation Date: 24/06/2014 5:25 PM
    //Programmer Name : bahaa Addin Ghaleb
    //-----Decleration --------------
    #region "Decleration"
    private int m_iSerial; 
    private int m_ProctorID; 
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
    public int ProctorID
    {
    get { return  m_ProctorID; }
    set {m_ProctorID  = value ; }
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
    public FinalExam_Proctors()
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
    public class FinalExam_ProctorsDAL : FinalExam_Proctors
    {
    #region "Decleration"
    private string m_TableName;
    private string m_iSerialFN ;
    private string m_ProctorIDFN ;
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
    public string ProctorIDFN 
    {
    get { return  m_ProctorIDFN; }
    set {m_ProctorIDFN  = value ; }
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
    public FinalExam_ProctorsDAL()
    {
    try
    {
    this.TableName = "Reg_FinalExam_Proctors";
    this.iSerialFN = m_TableName + ".iSerial";
    this.ProctorIDFN = m_TableName + ".ProctorID";
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
    sSQL += " , " + ProctorIDFN;
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
    sSQL += " , " + ProctorIDFN;
    sSQL += " , " + strUserCreateFN;
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
    sSQL += " , " + ProctorIDFN;
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
    sSQL += " , " + LibraryMOD.GetFieldName(ProctorIDFN) + "=@ProctorID";
    sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
    sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
    sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
    sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
    sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
    sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
    sSQL += " WHERE ";
    sSQL += LibraryMOD.GetFieldName(iSerialFN)+"=@iSerial";
    sSQL +=  " And " + LibraryMOD.GetFieldName(ProctorIDFN)+"=@ProctorID";
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
    sSQL += " , " + LibraryMOD.GetFieldName(ProctorIDFN);
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
    sSQL += " ,@ProctorID";
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
    sSQL +=  " And " +  LibraryMOD.GetFieldName(ProctorIDFN)+"=@ProctorID";
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
    public List< FinalExam_Proctors> GetFinalExam_Proctors(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    {
    //' returns a list of Classes instances based on the
    //' data in the FinalExam_Proctors
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
    List<FinalExam_Proctors> results = new List<FinalExam_Proctors>();
    try
    {
    //Default Value
    FinalExam_Proctors myFinalExam_Proctors = new FinalExam_Proctors();
    if (isDeafaultIncluded)
    {
    //Change the code here
    myFinalExam_Proctors.iSerial = 0;
    myFinalExam_Proctors.ProctorID = 0;
    myFinalExam_Proctors.ProctorID = 0;
    results.Add(myFinalExam_Proctors);
    }
    while (reader.Read())
    {
    myFinalExam_Proctors = new FinalExam_Proctors();
    if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
    {
    myFinalExam_Proctors.iSerial = 0;
    }
    else
    {
    myFinalExam_Proctors.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(ProctorIDFN)].Equals(DBNull.Value))
    {
    myFinalExam_Proctors.ProctorID = 0;
    }
    else
    {
    myFinalExam_Proctors.ProctorID = int.Parse(reader[LibraryMOD.GetFieldName( ProctorIDFN) ].ToString());
    }
    myFinalExam_Proctors.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
    {
    myFinalExam_Proctors.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
    }
    myFinalExam_Proctors.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
    if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
    {
    myFinalExam_Proctors.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
    }
    myFinalExam_Proctors.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
    myFinalExam_Proctors.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
     results.Add(myFinalExam_Proctors);
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
    public List< FinalExam_Proctors > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<FinalExam_Proctors> results = new List<FinalExam_Proctors>();
    try
    {
    //Default Value
    FinalExam_Proctors myFinalExam_Proctors= new FinalExam_Proctors();
    if (isDeafaultIncluded)
     {
    //Change the code here
     myFinalExam_Proctors.iSerial = -1;
     myFinalExam_Proctors.ProctorID = 0;
    results.Add(myFinalExam_Proctors);
     }
    while (reader.Read())
    {
    myFinalExam_Proctors = new FinalExam_Proctors();
    if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
    {
    myFinalExam_Proctors.iSerial = 0;
    }
    else
    {
    myFinalExam_Proctors.iSerial = int.Parse(reader[LibraryMOD.GetFieldName( iSerialFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(ProctorIDFN)].Equals(DBNull.Value))
    {
    myFinalExam_Proctors.ProctorID = 0;
    }
    else
    {
    myFinalExam_Proctors.ProctorID = int.Parse(reader[LibraryMOD.GetFieldName( ProctorIDFN) ].ToString());
    }
    myFinalExam_Proctors.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
     results.Add(myFinalExam_Proctors);
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
    public int UpdateFinalExam_Proctors(InitializeModule.EnumCampus Campus, int iMode,int iSerial,int ProctorID,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    Conn.Open();
    string sql = "";
    FinalExam_Proctors theFinalExam_Proctors = new FinalExam_Proctors();
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
    Cmd.Parameters.Add(new SqlParameter("@ProctorID",ProctorID));
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
    public int DeleteFinalExam_Proctors(InitializeModule.EnumCampus Campus,string iSerial,string ProctorID)
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
    Cmd.Parameters.Add(new SqlParameter("@ProctorID", ProctorID ));
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
    DataTable dt = new DataTable("FinalExam_Proctors");
    DataView dv = new DataView();
    List<FinalExam_Proctors> myFinalExam_Proctorss = new List<FinalExam_Proctors>();
    try
    {
    myFinalExam_Proctorss = GetFinalExam_Proctors(InitializeModule.EnumCampus.ECTNew,sCondition,false);
    DataColumn col0= new DataColumn("iSerial", Type.GetType("int"));
    dt.Columns.Add(col0 );
    DataColumn col1= new DataColumn("ProctorID", Type.GetType("int"));
    dt.Columns.Add(col1 );
    dt.Constraints.Add(new UniqueConstraint(col1));


    DataRow dr;
    for (int i = 0; i < myFinalExam_Proctorss.Count; i++)
    {
    dr = dt.NewRow();
      dr[1] = myFinalExam_Proctorss[i].iSerial;
      dr[2] = myFinalExam_Proctorss[i].ProctorID;
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
    myFinalExam_Proctorss.Clear();
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
    public class FinalExam_ProctorsCls : FinalExam_ProctorsDAL
    {
    #region "Decleration"
    private int m_lngCurRow=0;
    public SqlDataAdapter daFinalExam_Proctors;
    private DataSet m_dsFinalExam_Proctors;
    public DataRow FinalExam_ProctorsDataRow ;
    #endregion
    #region "Puplic Properties"
    public DataSet dsFinalExam_Proctors
    {
    get { return m_dsFinalExam_Proctors ; }
    set { m_dsFinalExam_Proctors = value ; }
    }
    //-----------------------------------------------------
    public int lngCurRow 
    {
    get { return  m_lngCurRow ; }
    set {m_lngCurRow = value ; }
    }
    #endregion
    public FinalExam_ProctorsCls()
    {
    try
    {
    dsFinalExam_Proctors= new DataSet();

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
    public virtual SqlDataAdapter GetFinalExam_ProctorsDataAdapter(string sCondition ,SqlConnection con ) 
    {
    string sSQL =""; 
    try
    {
    sSQL = GetSQL();
    sSQL += " " + sCondition;
    //-----------------------------------------
    daFinalExam_Proctors = new SqlDataAdapter(sSQL, con);
    // Create command builder. This line automatically generates the update commands for you, so you don't
    // have to provide or create your own.
    SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daFinalExam_Proctors);
    //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    // key + unique key information to be retrieved unless AddWithKey is specified.
    daFinalExam_Proctors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daFinalExam_Proctors;
    }
    public virtual SqlDataAdapter GetFinalExam_ProctorsDataAdapter(SqlConnection con)  
    {
    try
    {
    daFinalExam_Proctors = new SqlDataAdapter();
    //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    //'' key + unique key information to be retrieved unless AddWithKey is specified.
    daFinalExam_Proctors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    //-----------------------------------------
    SqlParameter Parmeter = default(SqlParameter); 
    //[SELECT COMMAND]
    SqlCommand cmdFinalExam_Proctors;
    cmdFinalExam_Proctors = new SqlCommand(GetSelectCommand(), con);
    //'cmdRolePermission.Parameters.Add("@iSerial", SqlDbType.Int, 4, "iSerial" );
    //'cmdRolePermission.Parameters.Add("@ProctorID", SqlDbType.Int, 4, "ProctorID" );
    daFinalExam_Proctors.SelectCommand = cmdFinalExam_Proctors;
    //'Add Handlers
    //'RowUpdating,RowUpdated
    AddDAEventHandler();
    //'[UPDATE COMMAND].
    cmdFinalExam_Proctors = new SqlCommand(GetUpdateCommand(), con);
    //'Delete PK Parameteres from here. b/c its declared below
    cmdFinalExam_Proctors.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
    cmdFinalExam_Proctors.Parameters.Add("@ProctorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ProctorIDFN));
    cmdFinalExam_Proctors.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
    cmdFinalExam_Proctors.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
    cmdFinalExam_Proctors.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
    cmdFinalExam_Proctors.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
    cmdFinalExam_Proctors.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
    cmdFinalExam_Proctors.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


    Parmeter = cmdFinalExam_Proctors.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
    Parmeter = cmdFinalExam_Proctors.Parameters.Add("@ProctorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ProctorIDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    //'Its should be none for batch updating
    //'UpdateCommand, InsertCommand, and DeleteCommand 
    //'should be set to None or OutputParameters
    daFinalExam_Proctors.UpdateCommand = cmdFinalExam_Proctors;
    daFinalExam_Proctors.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
    //'-------------------------------------------------------------------------
    //'/INSERT COMMAND
     cmdFinalExam_Proctors = new SqlCommand(GetInsertCommand(), con);
    cmdFinalExam_Proctors.Parameters.Add("@iSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(iSerialFN));
    cmdFinalExam_Proctors.Parameters.Add("@ProctorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ProctorIDFN));
    cmdFinalExam_Proctors.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
    cmdFinalExam_Proctors.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
    cmdFinalExam_Proctors.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
    cmdFinalExam_Proctors.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
    cmdFinalExam_Proctors.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
    cmdFinalExam_Proctors.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
    Parmeter.SourceVersion = DataRowVersion.Current;
    daFinalExam_Proctors.InsertCommand =cmdFinalExam_Proctors;
    daFinalExam_Proctors.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'------------------------
    //'/DELETE COMMAND
     cmdFinalExam_Proctors = new SqlCommand(GetDeleteCommand(), con);
    Parmeter = cmdFinalExam_Proctors.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
    Parmeter = cmdFinalExam_Proctors.Parameters.Add("@ProctorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ProctorIDFN));
    Parmeter.SourceVersion = DataRowVersion.Original;
    daFinalExam_Proctors.DeleteCommand =cmdFinalExam_Proctors;
    daFinalExam_Proctors.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
    //'Batch Size
    //'Set the batch size.
    daFinalExam_Proctors.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
    }
    catch (Exception ex)
    {
    LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return daFinalExam_Proctors;
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
    dr = dsFinalExam_Proctors.Tables[TableName].NewRow();
    dr[LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
    dr[LibraryMOD.GetFieldName(ProctorIDFN)]=ProctorID;
    dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
    dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
    dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
    dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
    dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
    dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
    dsFinalExam_Proctors.Tables[TableName].Rows.Add(dr);
    break;
    case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
     DataRow[] drAry = null;
    drAry = dsFinalExam_Proctors.Tables[TableName].Select(LibraryMOD.GetFieldName(iSerialFN)  + "=" + iSerial  + " AND " + LibraryMOD.GetFieldName(ProctorIDFN) + "=" + ProctorID);
    //'its return array of rows and we can access the first by index 0
    drAry[0][LibraryMOD.GetFieldName(iSerialFN)]=iSerial;
    drAry[0][LibraryMOD.GetFieldName(ProctorIDFN)]=ProctorID;
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
    public int CommitFinalExam_Proctors()  
    {
    //CommitFinalExam_Proctors= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //'' Update Database with SqlDataAdapter
    daFinalExam_Proctors.Update(dsFinalExam_Proctors, TableName);
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
    FindInMultiPKey(iSerial,ProctorID);
    if (( FinalExam_ProctorsDataRow != null)) 
    {
    FinalExam_ProctorsDataRow.Delete();
    CommitFinalExam_Proctors();
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
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(iSerialFN)]== System.DBNull.Value)
    {
      iSerial=0;
    }
    else
    {
      iSerial = (int)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(iSerialFN)];
    }
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(ProctorIDFN)]== System.DBNull.Value)
    {
      ProctorID=0;
    }
    else
    {
      ProctorID = (int)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(ProctorIDFN)];
    }
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
    {
      strUserCreate="";
    }
    else
    {
      strUserCreate = (string)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
    }
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      dateCreate = (DateTime)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
    }
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
    {
      strUserSave="";
    }
    else
    {
      strUserSave = (string)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
    }
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
    {
    }
    else
    {
      dateLastSave = (DateTime)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
    }
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
    {
      strMachine="";
    }
    else
    {
      strMachine = (string)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
    }
    if (FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
    {
      strNUser="";
    }
    else
    {
      strNUser = (string)FinalExam_ProctorsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKiSerial,int PKProctorID) 
    {
    //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //' Create an array for the key values to find.
    object[] findTheseVals = new object[1] ; 
    //' Set the values of the keys to find.
    findTheseVals[0] = PKiSerial;
    findTheseVals[1] = PKProctorID;
    FinalExam_ProctorsDataRow = dsFinalExam_Proctors.Tables[TableName].Rows.Find(findTheseVals);
    if  ((FinalExam_ProctorsDataRow !=null)) 
    {
    lngCurRow = dsFinalExam_Proctors.Tables[TableName].Rows.IndexOf(FinalExam_ProctorsDataRow);
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
      lngCurRow = dsFinalExam_Proctors.Tables[TableName].Rows.Count - 1; //'Zero based index
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
      lngCurRow = Math.Min(lngCurRow + 1, dsFinalExam_Proctors.Tables[TableName].Rows.Count - 1);
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
      if (lngCurRow >= 0 & dsFinalExam_Proctors.Tables[TableName].Rows.Count > 0) 
    {
      FinalExam_ProctorsDataRow = dsFinalExam_Proctors.Tables[TableName].Rows[lngCurRow];
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
    daFinalExam_Proctors.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daFinalExam_Proctors.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
    daFinalExam_Proctors.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
    daFinalExam_Proctors.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
