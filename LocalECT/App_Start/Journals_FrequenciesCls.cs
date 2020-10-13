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
public class Journals_Frequencies
{
    //Creation Date: 17/10/2010 3:13:07 PM
    //Programmer Name : Hazem Galal
    //-----Decleration --------------
    #region "Decleration"
    private int m_iFrequency;
    private string m_sFrequencyEn;
    private string m_sFrequencyAr;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int iFrequency
    {
        get { return m_iFrequency; }
        set { m_iFrequency = value; }
    }
    public string sFrequencyEn
    {
        get { return m_sFrequencyEn; }
        set { m_sFrequencyEn = value; }
    }
    public string sFrequencyAr
    {
        get { return m_sFrequencyAr; }
        set { m_sFrequencyAr = value; }
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
    public Journals_Frequencies()
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
public class Journals_FrequenciesDAL : Journals_Frequencies
{
    #region "Decleration"
    private string m_TableName;
    private string m_iFrequencyFN;
    private string m_sFrequencyEnFN;
    private string m_sFrequencyArFN;
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
    public string iFrequencyFN
    {
        get { return m_iFrequencyFN; }
        set { m_iFrequencyFN = value; }
    }
    public string sFrequencyEnFN
    {
        get { return m_sFrequencyEnFN; }
        set { m_sFrequencyEnFN = value; }
    }
    public string sFrequencyArFN
    {
        get { return m_sFrequencyArFN; }
        set { m_sFrequencyArFN = value; }
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
    public Journals_FrequenciesDAL()
    {
        try
        {
            this.TableName = "Lib_Journals_Frequencies";
            this.iFrequencyFN = m_TableName + ".iFrequency";
            this.sFrequencyEnFN = m_TableName + ".sFrequencyEn";
            this.sFrequencyArFN = m_TableName + ".sFrequencyAr";
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
            sSQL += iFrequencyFN;
            sSQL += " , " + sFrequencyEnFN;
            sSQL += " , " + sFrequencyArFN;
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
            sSQL += iFrequencyFN;
            sSQL += " , " + sFrequencyEnFN;
            sSQL += " , " + sFrequencyArFN;
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
            sSQL += LibraryMOD.GetFieldName(iFrequencyFN) + "=@iFrequency";
            sSQL += " , " + LibraryMOD.GetFieldName(sFrequencyEnFN) + "=@sFrequencyEn";
            sSQL += " , " + LibraryMOD.GetFieldName(sFrequencyArFN) + "=@sFrequencyAr";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(iFrequencyFN) + "=@iFrequency";
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
            sSQL += LibraryMOD.GetFieldName(iFrequencyFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sFrequencyEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sFrequencyArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @iFrequency";
            sSQL += " ,@sFrequencyEn";
            sSQL += " ,@sFrequencyAr";
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
            sSQL += LibraryMOD.GetFieldName(iFrequencyFN) + "=@iFrequency";
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
    public List<Journals_Frequencies> GetJournals_Frequencies(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Journals_Frequencies
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
        List<Journals_Frequencies> results = new List<Journals_Frequencies>();
        try
        {
            //Default Value
            Journals_Frequencies myJournals_Frequencies = new Journals_Frequencies();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myJournals_Frequencies.iFrequency = 0;
                myJournals_Frequencies.sFrequencyEn = "Select Journals_Frequencies ...";
                results.Add(myJournals_Frequencies);
            }
            while (reader.Read())
            {
                myJournals_Frequencies = new Journals_Frequencies();
                if (reader[LibraryMOD.GetFieldName(iFrequencyFN)].Equals(DBNull.Value))
                {
                    myJournals_Frequencies.iFrequency = 0;
                }
                else
                {
                    myJournals_Frequencies.iFrequency = int.Parse(reader[LibraryMOD.GetFieldName(iFrequencyFN)].ToString());
                }
                myJournals_Frequencies.sFrequencyEn = reader[LibraryMOD.GetFieldName(sFrequencyEnFN)].ToString();
                myJournals_Frequencies.sFrequencyAr = reader[LibraryMOD.GetFieldName(sFrequencyArFN)].ToString();
                myJournals_Frequencies.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[dateCreateFN].Equals(DBNull.Value))
                {
                    myJournals_Frequencies.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myJournals_Frequencies.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[dateLastSaveFN].Equals(DBNull.Value))
                {
                    myJournals_Frequencies.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myJournals_Frequencies.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myJournals_Frequencies.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myJournals_Frequencies);
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
    public int UpdateJournals_Frequencies(InitializeModule.EnumCampus Campus, int iMode, int iFrequency, string sFrequencyEn, string sFrequencyAr, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Journals_Frequencies theJournals_Frequencies = new Journals_Frequencies();
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
            Cmd.Parameters.Add(new SqlParameter("@iFrequency", iFrequency));
            Cmd.Parameters.Add(new SqlParameter("@sFrequencyEn", sFrequencyEn));
            Cmd.Parameters.Add(new SqlParameter("@sFrequencyAr", sFrequencyAr));
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
    public int DeleteJournals_Frequencies(InitializeModule.EnumCampus Campus, string iFrequency)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@iFrequency", iFrequency));
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
        DataTable dt = new DataTable("Journals_Frequencies");
        DataView dv = new DataView();
        List<Journals_Frequencies> myJournals_Frequenciess = new List<Journals_Frequencies>();
        try
        {
            myJournals_Frequenciess = GetJournals_Frequencies(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("iFrequency", Type.GetType("smallint"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("sFrequencyEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("sFrequencyAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myJournals_Frequenciess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myJournals_Frequenciess[i].iFrequency;
                dr[2] = myJournals_Frequenciess[i].sFrequencyEn;
                dr[3] = myJournals_Frequenciess[i].sFrequencyAr;
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
            myJournals_Frequenciess.Clear();
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
            sSQL += iFrequencyFN;
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
public class Journals_FrequenciesCls : Journals_FrequenciesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daJournals_Frequencies;
    private DataSet m_dsJournals_Frequencies;
    public DataRow Journals_FrequenciesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsJournals_Frequencies
    {
        get { return m_dsJournals_Frequencies; }
        set { m_dsJournals_Frequencies = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Journals_FrequenciesCls()
    {
        try
        {
            dsJournals_Frequencies = new DataSet();

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
    public virtual SqlDataAdapter GetJournals_FrequenciesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daJournals_Frequencies = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daJournals_Frequencies);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daJournals_Frequencies.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daJournals_Frequencies;
    }
    public virtual SqlDataAdapter GetJournals_FrequenciesDataAdapter(SqlConnection con)
    {
        try
        {
            daJournals_Frequencies = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daJournals_Frequencies.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdJournals_Frequencies;
            cmdJournals_Frequencies = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@iFrequency", SqlDbType.Int, 4, "iFrequency" );
            daJournals_Frequencies.SelectCommand = cmdJournals_Frequencies;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdJournals_Frequencies = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdJournals_Frequencies.Parameters.Add("@iFrequency", SqlDbType.Int, 2, LibraryMOD.GetFieldName(iFrequencyFN));
            cmdJournals_Frequencies.Parameters.Add("@sFrequencyEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sFrequencyEnFN));
            cmdJournals_Frequencies.Parameters.Add("@sFrequencyAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sFrequencyArFN));
            cmdJournals_Frequencies.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdJournals_Frequencies.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdJournals_Frequencies.Parameters.Add("@strUserSave", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdJournals_Frequencies.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdJournals_Frequencies.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdJournals_Frequencies.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdJournals_Frequencies.Parameters.Add("@iFrequency", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iFrequencyFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daJournals_Frequencies.UpdateCommand = cmdJournals_Frequencies;
            daJournals_Frequencies.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdJournals_Frequencies = new SqlCommand(GetInsertCommand(), con);
            cmdJournals_Frequencies.Parameters.Add("@iFrequency", SqlDbType.Int, 2, LibraryMOD.GetFieldName(iFrequencyFN));
            cmdJournals_Frequencies.Parameters.Add("@sFrequencyEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sFrequencyEnFN));
            cmdJournals_Frequencies.Parameters.Add("@sFrequencyAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sFrequencyArFN));
            cmdJournals_Frequencies.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdJournals_Frequencies.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdJournals_Frequencies.Parameters.Add("@strUserSave", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdJournals_Frequencies.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdJournals_Frequencies.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdJournals_Frequencies.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daJournals_Frequencies.InsertCommand = cmdJournals_Frequencies;
            daJournals_Frequencies.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdJournals_Frequencies = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdJournals_Frequencies.Parameters.Add("@iFrequency", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iFrequencyFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daJournals_Frequencies.DeleteCommand = cmdJournals_Frequencies;
            daJournals_Frequencies.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daJournals_Frequencies.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daJournals_Frequencies;
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
                    dr = dsJournals_Frequencies.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(iFrequencyFN)] = iFrequency;
                    dr[LibraryMOD.GetFieldName(sFrequencyEnFN)] = sFrequencyEn;
                    dr[LibraryMOD.GetFieldName(sFrequencyArFN)] = sFrequencyAr;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsJournals_Frequencies.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsJournals_Frequencies.Tables[TableName].Select(LibraryMOD.GetFieldName(iFrequencyFN) + "=" + iFrequency);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(iFrequencyFN)] = iFrequency;
                    drAry[0][LibraryMOD.GetFieldName(sFrequencyEnFN)] = sFrequencyEn;
                    drAry[0][LibraryMOD.GetFieldName(sFrequencyArFN)] = sFrequencyAr;
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
    public int CommitJournals_Frequencies()
    {
        //CommitJournals_Frequencies= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daJournals_Frequencies.Update(dsJournals_Frequencies, TableName);
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
            FindInMultiPKey(iFrequency);
            if ((Journals_FrequenciesDataRow != null))
            {
                Journals_FrequenciesDataRow.Delete();
                CommitJournals_Frequencies();
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
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(iFrequencyFN)] == System.DBNull.Value)
            {
                iFrequency = 0;
            }
            else
            {
                iFrequency = (int)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(iFrequencyFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(sFrequencyEnFN)] == System.DBNull.Value)
            {
                sFrequencyEn = "";
            }
            else
            {
                sFrequencyEn = (string)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(sFrequencyEnFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(sFrequencyArFN)] == System.DBNull.Value)
            {
                sFrequencyAr = "";
            }
            else
            {
                sFrequencyAr = (string)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(sFrequencyArFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)Journals_FrequenciesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKiFrequency)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKiFrequency;
            Journals_FrequenciesDataRow = dsJournals_Frequencies.Tables[TableName].Rows.Find(findTheseVals);
            if ((Journals_FrequenciesDataRow != null))
            {
                lngCurRow = dsJournals_Frequencies.Tables[TableName].Rows.IndexOf(Journals_FrequenciesDataRow);
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
            lngCurRow = dsJournals_Frequencies.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsJournals_Frequencies.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsJournals_Frequencies.Tables[TableName].Rows.Count > 0)
            {
                Journals_FrequenciesDataRow = dsJournals_Frequencies.Tables[TableName].Rows[lngCurRow];
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
            daJournals_Frequencies.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daJournals_Frequencies.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daJournals_Frequencies.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daJournals_Frequencies.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
