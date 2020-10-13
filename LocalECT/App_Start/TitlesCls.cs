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
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Titles
{
    //Creation Date: 25/04/2010 10:49:46 ص
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_intTitle;
    private string m_strTitleDescEn;
    private string m_strTitleDescAr;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int intTitle
    {
        get { return m_intTitle; }
        set { m_intTitle = value; }
    }
    public string strTitleDescEn
    {
        get { return m_strTitleDescEn; }
        set { m_strTitleDescEn = value; }
    }
    public string strTitleDescAr
    {
        get { return m_strTitleDescAr; }
        set { m_strTitleDescAr = value; }
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
    public Titles()
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
public class TitlesDAL : Titles
{
    #region "Decleration"
    private string m_TableName;
    private string m_intTitleFN;
    private string m_strTitleDescEnFN;
    private string m_strTitleDescArFN;
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
    public string intTitleFN
    {
        get { return m_intTitleFN; }
        set { m_intTitleFN = value; }
    }
    public string strTitleDescEnFN
    {
        get { return m_strTitleDescEnFN; }
        set { m_strTitleDescEnFN = value; }
    }
    public string strTitleDescArFN
    {
        get { return m_strTitleDescArFN; }
        set { m_strTitleDescArFN = value; }
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
    public TitlesDAL()
    {
        try
        {
            this.TableName = "Lkp_Titles";
            this.intTitleFN = m_TableName + ".intTitle";
            this.strTitleDescEnFN = m_TableName + ".strTitleDescEn";
            this.strTitleDescArFN = m_TableName + ".strTitleDescAr";
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
            sSQL += intTitleFN;
            sSQL += " , " + strTitleDescEnFN;
            sSQL += " , " + strTitleDescArFN;
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
            sSQL += intTitleFN;
            sSQL += " , " + strTitleDescEnFN;
            sSQL += " , " + strTitleDescArFN;
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
            sSQL += LibraryMOD.GetFieldName(intTitleFN) + "=@intTitle";
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleDescEnFN) + "=@strTitleDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleDescArFN) + "=@strTitleDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(intTitleFN) + "=@intTitle";
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
            sSQL += LibraryMOD.GetFieldName(intTitleFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @intTitle";
            sSQL += " ,@strTitleDescEn";
            sSQL += " ,@strTitleDescAr";
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
            sSQL += LibraryMOD.GetFieldName(intTitleFN) + "=@intTitle";
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
    public List<Titles> GetTitles(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Titles
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
        List<Titles> results = new List<Titles>();
        try
        {
            //Default Value
            Titles myTitles = new Titles();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myTitles.intTitle = 0;
                myTitles.strTitleDescEn = "Select Titles ...";
                results.Add(myTitles);
            }
            while (reader.Read())
            {
                myTitles = new Titles();
                if (reader[LibraryMOD.GetFieldName(intTitleFN)].Equals(DBNull.Value))
                {
                    myTitles.intTitle = 0;
                }
                else
                {
                    myTitles.intTitle = int.Parse(reader[LibraryMOD.GetFieldName(intTitleFN)].ToString());
                }
                myTitles.strTitleDescEn = reader[LibraryMOD.GetFieldName(strTitleDescEnFN)].ToString();
                myTitles.strTitleDescAr = reader[LibraryMOD.GetFieldName(strTitleDescArFN)].ToString();
                myTitles.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[dateCreateFN].Equals(DBNull.Value))
                {
                    myTitles.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myTitles.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[dateLastSaveFN].Equals(DBNull.Value))
                {
                    myTitles.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myTitles.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myTitles.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myTitles);
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
    public int UpdateTitles(InitializeModule.EnumCampus Campus, int iMode, int intTitle, string strTitleDescEn, string strTitleDescAr, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Titles theTitles = new Titles();
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
            Cmd.Parameters.Add(new SqlParameter("@intTitle", intTitle));
            Cmd.Parameters.Add(new SqlParameter("@strTitleDescEn", strTitleDescEn));
            Cmd.Parameters.Add(new SqlParameter("@strTitleDescAr", strTitleDescAr));
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
    public int DeleteTitles(InitializeModule.EnumCampus Campus, string intTitle)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@intTitle", intTitle));
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
        DataTable dt = new DataTable("Titles");
        DataView dv = new DataView();
        List<Titles> myTitless = new List<Titles>();
        try
        {
            myTitless = GetTitles(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("intTitle", Type.GetType("smallint"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strTitleDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strTitleDescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myTitless.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myTitless[i].intTitle;
                dr[2] = myTitless[i].strTitleDescEn;
                dr[3] = myTitless[i].strTitleDescAr;
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
            myTitless.Clear();
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
            sSQL += intTitleFN;
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
public class TitlesCls : TitlesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daTitles;
    private DataSet m_dsTitles;
    public DataRow TitlesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsTitles
    {
        get { return m_dsTitles; }
        set { m_dsTitles = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public TitlesCls()
    {
        try
        {
            dsTitles = new DataSet();

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
    public virtual SqlDataAdapter GetTitlesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daTitles = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daTitles);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daTitles.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daTitles;
    }
    public virtual SqlDataAdapter GetTitlesDataAdapter(SqlConnection con)
    {
        try
        {
            daTitles = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daTitles.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdTitles;
            cmdTitles = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@intTitle", SqlDbType.Int, 4, "intTitle" );
            daTitles.SelectCommand = cmdTitles;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdTitles = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdTitles.Parameters.Add("@intTitle", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intTitleFN));
            cmdTitles.Parameters.Add("@strTitleDescEn", SqlDbType.NVarChar, 120, LibraryMOD.GetFieldName(strTitleDescEnFN));
            cmdTitles.Parameters.Add("@strTitleDescAr", SqlDbType.NVarChar, 120, LibraryMOD.GetFieldName(strTitleDescArFN));
            cmdTitles.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdTitles.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdTitles.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdTitles.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdTitles.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdTitles.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdTitles.Parameters.Add("@intTitle", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intTitleFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daTitles.UpdateCommand = cmdTitles;
            daTitles.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdTitles = new SqlCommand(GetInsertCommand(), con);
            cmdTitles.Parameters.Add("@intTitle", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intTitleFN));
            cmdTitles.Parameters.Add("@strTitleDescEn", SqlDbType.NVarChar, 120, LibraryMOD.GetFieldName(strTitleDescEnFN));
            cmdTitles.Parameters.Add("@strTitleDescAr", SqlDbType.NVarChar, 120, LibraryMOD.GetFieldName(strTitleDescArFN));
            cmdTitles.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdTitles.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdTitles.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdTitles.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdTitles.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdTitles.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daTitles.InsertCommand = cmdTitles;
            daTitles.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdTitles = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdTitles.Parameters.Add("@intTitle", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intTitleFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daTitles.DeleteCommand = cmdTitles;
            daTitles.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daTitles.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daTitles;
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
                    dr = dsTitles.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(intTitleFN)] = intTitle;
                    dr[LibraryMOD.GetFieldName(strTitleDescEnFN)] = strTitleDescEn;
                    dr[LibraryMOD.GetFieldName(strTitleDescArFN)] = strTitleDescAr;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    //dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    //dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    //dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)]= ECTGlobalDll.InitializeModule.gNetUserName;
                    dsTitles.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsTitles.Tables[TableName].Select(LibraryMOD.GetFieldName(intTitleFN) + "=" + intTitle);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(intTitleFN)] = intTitle;
                    drAry[0][LibraryMOD.GetFieldName(strTitleDescEnFN)] = strTitleDescEn;
                    drAry[0][LibraryMOD.GetFieldName(strTitleDescArFN)] = strTitleDescAr;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    //drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
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
    public int CommitTitles()
    {
        //CommitTitles= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daTitles.Update(dsTitles, TableName);
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
            FindInMultiPKey(intTitle);
            if ((TitlesDataRow != null))
            {
                TitlesDataRow.Delete();
                CommitTitles();
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
            if (TitlesDataRow[LibraryMOD.GetFieldName(intTitleFN)] == System.DBNull.Value)
            {
                intTitle = 0;
            }
            else
            {
                intTitle = (int)TitlesDataRow[LibraryMOD.GetFieldName(intTitleFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(strTitleDescEnFN)] == System.DBNull.Value)
            {
                strTitleDescEn = "";
            }
            else
            {
                strTitleDescEn = (string)TitlesDataRow[LibraryMOD.GetFieldName(strTitleDescEnFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(strTitleDescArFN)] == System.DBNull.Value)
            {
                strTitleDescAr = "";
            }
            else
            {
                strTitleDescAr = (string)TitlesDataRow[LibraryMOD.GetFieldName(strTitleDescArFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)TitlesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)TitlesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)TitlesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)TitlesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)TitlesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (TitlesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)TitlesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKintTitle)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKintTitle;
            TitlesDataRow = dsTitles.Tables[TableName].Rows.Find(findTheseVals);
            if ((TitlesDataRow != null))
            {
                lngCurRow = dsTitles.Tables[TableName].Rows.IndexOf(TitlesDataRow);
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
            lngCurRow = dsTitles.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsTitles.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsTitles.Tables[TableName].Rows.Count > 0)
            {
                TitlesDataRow = dsTitles.Tables[TableName].Rows[lngCurRow];
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
            daTitles.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daTitles.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daTitles.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daTitles.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
