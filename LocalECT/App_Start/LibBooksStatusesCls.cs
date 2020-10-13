using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class LibBooksStatuses
{
    //Creation Date: 08/12/2010 1:30:57 PM
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_BookStatusID;
    private string m_strBookStatusAr;
    private string m_strBookStatusEn;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int BookStatusID
    {
        get { return m_BookStatusID; }
        set { m_BookStatusID = value; }
    }
    public string strBookStatusAr
    {
        get { return m_strBookStatusAr; }
        set { m_strBookStatusAr = value; }
    }
    public string strBookStatusEn
    {
        get { return m_strBookStatusEn; }
        set { m_strBookStatusEn = value; }
    }
    public string strUserCreate
    {
        get { return m_strUserCreate; }
        set { m_strUserCreate = value; }
    }
    public DateTime dateCreate
    {
        get { return m_dateCreate; }
        set { m_dateCreate = value; }
    }
    public string strUserSave
    {
        get { return m_strUserSave; }
        set { m_strUserSave = value; }
    }
    public DateTime dateLastSave
    {
        get { return m_dateLastSave; }
        set { m_dateLastSave = value; }
    }
    public string strMachine
    {
        get { return m_strMachine; }
        set { m_strMachine = value; }
    }
    public string strNUser
    {
        get { return m_strNUser; }
        set { m_strNUser = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibBooksStatuses()
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
public class LibBooksStatusesDAL : LibBooksStatuses
{
    #region "Decleration"
    private string m_TableName;
    private string m_BookStatusIDFN;
    private string m_strBookStatusArFN;
    private string m_strBookStatusEnFN;
    private string m_strUserCreateFN;
    private string m_dateCreateFN;
    private string m_strUserSaveFN;
    private string m_dateLastSaveFN;
    private string m_strMachineFN;
    private string m_strNUserFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string BookStatusIDFN
    {
        get { return m_BookStatusIDFN; }
        set { m_BookStatusIDFN = value; }
    }
    public string strBookStatusArFN
    {
        get { return m_strBookStatusArFN; }
        set { m_strBookStatusArFN = value; }
    }
    public string strBookStatusEnFN
    {
        get { return m_strBookStatusEnFN; }
        set { m_strBookStatusEnFN = value; }
    }
    public string strUserCreateFN
    {
        get { return m_strUserCreateFN; }
        set { m_strUserCreateFN = value; }
    }
    public string dateCreateFN
    {
        get { return m_dateCreateFN; }
        set { m_dateCreateFN = value; }
    }
    public string strUserSaveFN
    {
        get { return m_strUserSaveFN; }
        set { m_strUserSaveFN = value; }
    }
    public string dateLastSaveFN
    {
        get { return m_dateLastSaveFN; }
        set { m_dateLastSaveFN = value; }
    }
    public string strMachineFN
    {
        get { return m_strMachineFN; }
        set { m_strMachineFN = value; }
    }
    public string strNUserFN
    {
        get { return m_strNUserFN; }
        set { m_strNUserFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibBooksStatusesDAL()
    {
        try
        {
            this.TableName = "LibBooksStatuses";
            this.BookStatusIDFN = m_TableName + ".BookStatusID";
            this.strBookStatusArFN = m_TableName + ".strBookStatusAr";
            this.strBookStatusEnFN = m_TableName + ".strBookStatusEn";
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
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += BookStatusIDFN;
            sSQL += " , " + strBookStatusArFN;
            sSQL += " , " + strBookStatusEnFN;
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
    //-----Get GetSelectCommand Function -----------------------
    public string GetSelectCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += BookStatusIDFN;
            sSQL += " , " + strBookStatusArFN;
            sSQL += " , " + strBookStatusEnFN;
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
        string sSQL = "";
        try
        {
            sSQL = "UPDATE " + TableName;
            sSQL += " SET ";
            sSQL += LibraryMOD.GetFieldName(BookStatusIDFN) + "=@BookStatusID";
            sSQL += " , " + LibraryMOD.GetFieldName(strBookStatusArFN) + "=@strBookStatusAr";
            sSQL += " , " + LibraryMOD.GetFieldName(strBookStatusEnFN) + "=@strBookStatusEn";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookStatusIDFN) + "=@BookStatusID";
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
        string sSQL = "";
        try
        {
            sSQL = "INSERT intO " + TableName;
            sSQL += "( ";
            sSQL += LibraryMOD.GetFieldName(BookStatusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strBookStatusArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strBookStatusEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @BookStatusID";
            sSQL += " ,@strBookStatusAr";
            sSQL += " ,@strBookStatusEn";
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
    public string GetDeleteCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "DELETE FROM " + TableName;
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookStatusIDFN) + "=@BookStatusID";
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
    public List<LibBooksStatuses> GetLibBooksStatuses(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibBooksStatuses
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetSQL();
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibBooksStatuses> results = new List<LibBooksStatuses>();
        try
        {
            //Default Value
            LibBooksStatuses myLibBooksStatuses = new LibBooksStatuses();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBooksStatuses.BookStatusID = 0;
                myLibBooksStatuses.strBookStatusAr = "Select LibBooksStatuses ...";
                results.Add(myLibBooksStatuses);
            }
            while (reader.Read())
            {
                myLibBooksStatuses = new LibBooksStatuses();
                if (reader[LibraryMOD.GetFieldName(BookStatusIDFN)].Equals(DBNull.Value))
                {
                    myLibBooksStatuses.BookStatusID = 0;
                }
                else
                {
                    myLibBooksStatuses.BookStatusID = int.Parse(reader[LibraryMOD.GetFieldName(BookStatusIDFN)].ToString());
                }
                myLibBooksStatuses.strBookStatusAr = reader[LibraryMOD.GetFieldName(strBookStatusArFN)].ToString();
                myLibBooksStatuses.strBookStatusEn = reader[LibraryMOD.GetFieldName(strBookStatusEnFN)].ToString();
                myLibBooksStatuses.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[dateCreateFN].Equals(DBNull.Value))
                {
                    myLibBooksStatuses.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myLibBooksStatuses.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[dateLastSaveFN].Equals(DBNull.Value))
                {
                    myLibBooksStatuses.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myLibBooksStatuses.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myLibBooksStatuses.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myLibBooksStatuses);
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
    public int UpdateLibBooksStatuses(InitializeModule.EnumCampus Campus, int iMode, int BookStatusID, string strBookStatusAr, string strBookStatusEn, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibBooksStatuses theLibBooksStatuses = new LibBooksStatuses();
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
            Cmd.Parameters.Add(new SqlParameter("@BookStatusID", BookStatusID));
            Cmd.Parameters.Add(new SqlParameter("@strBookStatusAr", strBookStatusAr));
            Cmd.Parameters.Add(new SqlParameter("@strBookStatusEn", strBookStatusEn));
            Cmd.Parameters.Add(new SqlParameter("@strUserCreate", strUserCreate));
            Cmd.Parameters.Add(new SqlParameter("@dateCreate", dateCreate));
            Cmd.Parameters.Add(new SqlParameter("@strUserSave", strUserSave));
            Cmd.Parameters.Add(new SqlParameter("@dateLastSave", dateLastSave));
            Cmd.Parameters.Add(new SqlParameter("@strMachine", strMachine));
            Cmd.Parameters.Add(new SqlParameter("@strNUser", strNUser));
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
    public int DeleteLibBooksStatuses(InitializeModule.EnumCampus Campus, string BookStatusID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@BookStatusID", BookStatusID));
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
    public DataView GetDataView(bool isFromRole, int PK, string sCondition)
    {
        DataTable dt = new DataTable("LibBooksStatuses");
        DataView dv = new DataView();
        List<LibBooksStatuses> myLibBooksStatusess = new List<LibBooksStatuses>();
        try
        {
            myLibBooksStatusess = GetLibBooksStatuses(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("BookStatusID", Type.GetType("smallint"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strBookStatusAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strBookStatusEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibBooksStatusess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibBooksStatusess[i].BookStatusID;
                dr[2] = myLibBooksStatusess[i].strBookStatusAr;
                dr[3] = myLibBooksStatusess[i].strBookStatusEn;
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
            myLibBooksStatusess.Clear();
        }
        return dv;
    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con)
    {
        string sSQL = "";
        DataTable table = new DataTable();
        try
        {
            sSQL = "SELECT";
            sSQL += BookStatusIDFN;
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
public class LibBooksStatusesCls : LibBooksStatusesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibBooksStatuses;
    private DataSet m_dsLibBooksStatuses;
    public DataRow LibBooksStatusesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibBooksStatuses
    {
        get { return m_dsLibBooksStatuses; }
        set { m_dsLibBooksStatuses = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibBooksStatusesCls()
    {
        try
        {
            dsLibBooksStatuses = new DataSet();

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
    public virtual SqlDataAdapter GetLibBooksStatusesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibBooksStatuses = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibBooksStatuses);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBooksStatuses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBooksStatuses;
    }
    public virtual SqlDataAdapter GetLibBooksStatusesDataAdapter(SqlConnection con)
    {
        try
        {
            daLibBooksStatuses = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBooksStatuses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibBooksStatuses;
            cmdLibBooksStatuses = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@BookStatusID", SqlDbType.Int, 4, "BookStatusID" );
            daLibBooksStatuses.SelectCommand = cmdLibBooksStatuses;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibBooksStatuses = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibBooksStatuses.Parameters.Add("@BookStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(BookStatusIDFN));
            cmdLibBooksStatuses.Parameters.Add("@strBookStatusAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBookStatusArFN));
            cmdLibBooksStatuses.Parameters.Add("@strBookStatusEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBookStatusEnFN));
            cmdLibBooksStatuses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibBooksStatuses.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibBooksStatuses.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibBooksStatuses.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibBooksStatuses.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibBooksStatuses.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdLibBooksStatuses.Parameters.Add("@BookStatusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookStatusIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibBooksStatuses.UpdateCommand = cmdLibBooksStatuses;
            daLibBooksStatuses.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibBooksStatuses = new SqlCommand(GetInsertCommand(), con);
            cmdLibBooksStatuses.Parameters.Add("@BookStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(BookStatusIDFN));
            cmdLibBooksStatuses.Parameters.Add("@strBookStatusAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBookStatusArFN));
            cmdLibBooksStatuses.Parameters.Add("@strBookStatusEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBookStatusEnFN));
            cmdLibBooksStatuses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibBooksStatuses.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibBooksStatuses.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibBooksStatuses.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibBooksStatuses.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibBooksStatuses.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibBooksStatuses.InsertCommand = cmdLibBooksStatuses;
            daLibBooksStatuses.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibBooksStatuses = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibBooksStatuses.Parameters.Add("@BookStatusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookStatusIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibBooksStatuses.DeleteCommand = cmdLibBooksStatuses;
            daLibBooksStatuses.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibBooksStatuses.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBooksStatuses;
    }
    //'-------SaveData  -----------------------------
    public int SaveData(int lFormMode)
    {
        //SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            switch (lFormMode)
            {
                case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
                    DataRow dr = default(DataRow);
                    dr = dsLibBooksStatuses.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(BookStatusIDFN)] = BookStatusID;
                    dr[LibraryMOD.GetFieldName(strBookStatusArFN)] = strBookStatusAr;
                    dr[LibraryMOD.GetFieldName(strBookStatusEnFN)] = strBookStatusEn;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsLibBooksStatuses.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibBooksStatuses.Tables[TableName].Select(LibraryMOD.GetFieldName(BookStatusIDFN) + "=" + BookStatusID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(BookStatusIDFN)] = BookStatusID;
                    drAry[0][LibraryMOD.GetFieldName(strBookStatusArFN)] = strBookStatusAr;
                    drAry[0][LibraryMOD.GetFieldName(strBookStatusEnFN)] = strBookStatusEn;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
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
    public int CommitLibBooksStatuses()
    {
        //CommitLibBooksStatuses= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibBooksStatuses.Update(dsLibBooksStatuses, TableName);
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
            FindInMultiPKey(BookStatusID);
            if ((LibBooksStatusesDataRow != null))
            {
                LibBooksStatusesDataRow.Delete();
                CommitLibBooksStatuses();
                if (MoveNext() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(BookStatusIDFN)] == System.DBNull.Value)
            {
                BookStatusID = 0;
            }
            else
            {
                BookStatusID = (int)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(BookStatusIDFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strBookStatusArFN)] == System.DBNull.Value)
            {
                strBookStatusAr = "";
            }
            else
            {
                strBookStatusAr = (string)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strBookStatusArFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strBookStatusEnFN)] == System.DBNull.Value)
            {
                strBookStatusEn = "";
            }
            else
            {
                strBookStatusEn = (string)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strBookStatusEnFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)LibBooksStatusesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKBookStatusID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKBookStatusID;
            LibBooksStatusesDataRow = dsLibBooksStatuses.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibBooksStatusesDataRow != null))
            {
                lngCurRow = dsLibBooksStatuses.Tables[TableName].Rows.IndexOf(LibBooksStatusesDataRow);
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
    public int MoveFirst()
    {
        //MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = 0;
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
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
    public int MovePrevious()
    {
        //MovePrevious= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Max(lngCurRow - 1, 0);
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
    public int MoveLast()
    {
        //MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = dsLibBooksStatuses.Tables[TableName].Rows.Count - 1; //'Zero based index
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
    public int MoveNext()
    {
        //MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Min(lngCurRow + 1, dsLibBooksStatuses.Tables[TableName].Rows.Count - 1);
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
    public int GoToCurrentRow()
    {
        //GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            if (lngCurRow >= 0 & dsLibBooksStatuses.Tables[TableName].Rows.Count > 0)
            {
                LibBooksStatusesDataRow = dsLibBooksStatuses.Tables[TableName].Rows[lngCurRow];
                SynchronizeDataRowToClass();
            }
            else return ECTGlobalDll.InitializeModule.FAIL_RET;
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
            daLibBooksStatuses.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBooksStatuses.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibBooksStatuses.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBooksStatuses.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            if (args.StatementType == StatementType.Delete)
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
    private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs args)
    {
        try
        {
            if (args.Status == UpdateStatus.ErrorsOccurred)
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
