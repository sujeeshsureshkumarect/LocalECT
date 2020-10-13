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
public class Journals_Details
{
    //Creation Date: 19/10/2010 2:50:02 PM
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_iJournal;
    private int m_iSerial;
    private string m_strTitle;
    private int m_iAutor;
    private string m_strPages;
    private string m_strTopic;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int iJournal
    {
        get { return m_iJournal; }
        set { m_iJournal = value; }
    }
    public int iSerial
    {
        get { return m_iSerial; }
        set { m_iSerial = value; }
    }
    public string strTitle
    {
        get { return m_strTitle; }
        set { m_strTitle = value; }
    }
    public int iAutor
    {
        get { return m_iAutor; }
        set { m_iAutor = value; }
    }
    public string strPages
    {
        get { return m_strPages; }
        set { m_strPages = value; }
    }
    public string strTopic
    {
        get { return m_strTopic; }
        set { m_strTopic = value; }
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
    public Journals_Details()
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
public class Journals_DetailsDAL : Journals_Details
{
    #region "Decleration"
    private string m_TableName;
    private string m_iJournalFN;
    private string m_iSerialFN;
    private string m_strTitleFN;
    private string m_iAutorFN;
    private string m_strPagesFN;
    private string m_strTopicFN;
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
    public string iJournalFN
    {
        get { return m_iJournalFN; }
        set { m_iJournalFN = value; }
    }
    public string iSerialFN
    {
        get { return m_iSerialFN; }
        set { m_iSerialFN = value; }
    }
    public string strTitleFN
    {
        get { return m_strTitleFN; }
        set { m_strTitleFN = value; }
    }
    public string iAutorFN
    {
        get { return m_iAutorFN; }
        set { m_iAutorFN = value; }
    }
    public string strPagesFN
    {
        get { return m_strPagesFN; }
        set { m_strPagesFN = value; }
    }
    public string strTopicFN
    {
        get { return m_strTopicFN; }
        set { m_strTopicFN = value; }
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
    public Journals_DetailsDAL()
    {
        try
        {
            this.TableName = "Lib_Journals_Details";
            this.iJournalFN = m_TableName + ".iJournal";
            this.iSerialFN = m_TableName + ".iSerial";
            this.strTitleFN = m_TableName + ".strTitle";
            this.iAutorFN = m_TableName + ".iAutor";
            this.strPagesFN = m_TableName + ".strPages";
            this.strTopicFN = m_TableName + ".strTopic";
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
            sSQL += iJournalFN;
            sSQL += " , " + iSerialFN;
            sSQL += " , " + strTitleFN;
            sSQL += " , " + iAutorFN;
            sSQL += " , " + strPagesFN;
            sSQL += " , " + strTopicFN;
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
            sSQL += iJournalFN;
            sSQL += " , " + iSerialFN;
            sSQL += " , " + strTitleFN;
            sSQL += " , " + iAutorFN;
            sSQL += " , " + strPagesFN;
            sSQL += " , " + strTopicFN;
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
            sSQL += LibraryMOD.GetFieldName(iJournalFN) + "=@iJournal";
            sSQL += " , " + LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleFN) + "=@strTitle";
            sSQL += " , " + LibraryMOD.GetFieldName(iAutorFN) + "=@iAutor";
            sSQL += " , " + LibraryMOD.GetFieldName(strPagesFN) + "=@strPages";
            sSQL += " , " + LibraryMOD.GetFieldName(strTopicFN) + "=@strTopic";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(iJournalFN) + "=@iJournal";
            sSQL += " And " + LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
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
            sSQL += LibraryMOD.GetFieldName(iJournalFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iSerialFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iAutorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strPagesFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strTopicFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @iJournal";
            sSQL += " ,@iSerial";
            sSQL += " ,@strTitle";
            sSQL += " ,@iAutor";
            sSQL += " ,@strPages";
            sSQL += " ,@strTopic";
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
            sSQL += LibraryMOD.GetFieldName(iJournalFN) + "=@iJournal";
            sSQL += " And " + LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
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
    public List<Journals_Details> GetJournals_Details(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Journals_Details
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
        List<Journals_Details> results = new List<Journals_Details>();
        try
        {
            //Default Value
            Journals_Details myJournals_Details = new Journals_Details();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myJournals_Details.iJournal = 0;
                myJournals_Details.iSerial = 0;
                myJournals_Details.strTitle = "Select Journals_Details ...";
                results.Add(myJournals_Details);
            }
            while (reader.Read())
            {
                myJournals_Details = new Journals_Details();
                if (reader[LibraryMOD.GetFieldName(iJournalFN)].Equals(DBNull.Value))
                {
                    myJournals_Details.iJournal = 0;
                }
                else
                {
                    myJournals_Details.iJournal = int.Parse(reader[LibraryMOD.GetFieldName(iJournalFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
                {
                    myJournals_Details.iSerial = 0;
                }
                else
                {
                    myJournals_Details.iSerial = int.Parse(reader[LibraryMOD.GetFieldName(iSerialFN)].ToString());
                }
                myJournals_Details.strTitle = reader[LibraryMOD.GetFieldName(strTitleFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(iAutorFN)].Equals(DBNull.Value))
                {
                    myJournals_Details.iAutor = 0;
                }
                else
                {
                    myJournals_Details.iAutor = int.Parse(reader[LibraryMOD.GetFieldName(iAutorFN)].ToString());
                }
                myJournals_Details.strPages = reader[LibraryMOD.GetFieldName(strPagesFN)].ToString();
                myJournals_Details.strTopic = reader[LibraryMOD.GetFieldName(strTopicFN)].ToString();
                myJournals_Details.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[dateCreateFN].Equals(DBNull.Value))
                {
                    myJournals_Details.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myJournals_Details.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[dateLastSaveFN].Equals(DBNull.Value))
                {
                    myJournals_Details.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myJournals_Details.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myJournals_Details.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myJournals_Details);
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
    public int UpdateJournals_Details(InitializeModule.EnumCampus Campus, int iMode, int iJournal, int iSerial, string strTitle, int iAutor, string strPages, string strTopic, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Journals_Details theJournals_Details = new Journals_Details();
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
            Cmd.Parameters.Add(new SqlParameter("@iJournal", iJournal));
            Cmd.Parameters.Add(new SqlParameter("@iSerial", iSerial));
            Cmd.Parameters.Add(new SqlParameter("@strTitle", strTitle));
            Cmd.Parameters.Add(new SqlParameter("@iAutor", iAutor));
            Cmd.Parameters.Add(new SqlParameter("@strPages", strPages));
            Cmd.Parameters.Add(new SqlParameter("@strTopic", strTopic));
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
    public int DeleteJournals_Details(InitializeModule.EnumCampus Campus, string iJournal, string iSerial)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@iJournal", iJournal));
            Cmd.Parameters.Add(new SqlParameter("@iSerial", iSerial));
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
        DataTable dt = new DataTable("Journals_Details");
        DataView dv = new DataView();
        List<Journals_Details> myJournals_Detailss = new List<Journals_Details>();
        try
        {
            myJournals_Detailss = GetJournals_Details(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("iJournal", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("iSerial", Type.GetType("int"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strTitle", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));
            dt.Constraints.Add(new UniqueConstraint(col2));

            DataRow dr;
            for (int i = 0; i < myJournals_Detailss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myJournals_Detailss[i].iJournal;
                dr[2] = myJournals_Detailss[i].iSerial;
                dr[3] = myJournals_Detailss[i].strTitle;
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
            myJournals_Detailss.Clear();
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
            sSQL += iJournalFN;
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
public class Journals_DetailsCls : Journals_DetailsDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daJournals_Details;
    private DataSet m_dsJournals_Details;
    public DataRow Journals_DetailsDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsJournals_Details
    {
        get { return m_dsJournals_Details; }
        set { m_dsJournals_Details = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Journals_DetailsCls()
    {
        try
        {
            dsJournals_Details = new DataSet();

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
    public virtual SqlDataAdapter GetJournals_DetailsDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daJournals_Details = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daJournals_Details);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daJournals_Details.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daJournals_Details;
    }
    public virtual SqlDataAdapter GetJournals_DetailsDataAdapter(SqlConnection con)
    {
        try
        {
            daJournals_Details = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daJournals_Details.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdJournals_Details;
            cmdJournals_Details = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@iJournal", SqlDbType.Int, 4, "iJournal" );
            //'cmdRolePermission.Parameters.Add("@iSerial", SqlDbType.Int, 4, "iSerial" );
            daJournals_Details.SelectCommand = cmdJournals_Details;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdJournals_Details = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdJournals_Details.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            cmdJournals_Details.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            cmdJournals_Details.Parameters.Add("@strTitle", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strTitleFN));
            cmdJournals_Details.Parameters.Add("@iAutor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iAutorFN));
            cmdJournals_Details.Parameters.Add("@strPages", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strPagesFN));
            cmdJournals_Details.Parameters.Add("@strTopic", SqlDbType.NVarChar, 400, LibraryMOD.GetFieldName(strTopicFN));
            cmdJournals_Details.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdJournals_Details.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdJournals_Details.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdJournals_Details.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdJournals_Details.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdJournals_Details.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdJournals_Details.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            Parmeter = cmdJournals_Details.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daJournals_Details.UpdateCommand = cmdJournals_Details;
            daJournals_Details.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdJournals_Details = new SqlCommand(GetInsertCommand(), con);
            cmdJournals_Details.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            cmdJournals_Details.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            cmdJournals_Details.Parameters.Add("@strTitle", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strTitleFN));
            cmdJournals_Details.Parameters.Add("@iAutor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iAutorFN));
            cmdJournals_Details.Parameters.Add("@strPages", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strPagesFN));
            cmdJournals_Details.Parameters.Add("@strTopic", SqlDbType.NVarChar, 400, LibraryMOD.GetFieldName(strTopicFN));
            cmdJournals_Details.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdJournals_Details.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdJournals_Details.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdJournals_Details.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdJournals_Details.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdJournals_Details.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daJournals_Details.InsertCommand = cmdJournals_Details;
            daJournals_Details.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdJournals_Details = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdJournals_Details.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            Parmeter = cmdJournals_Details.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daJournals_Details.DeleteCommand = cmdJournals_Details;
            daJournals_Details.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daJournals_Details.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daJournals_Details;
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
                    dr = dsJournals_Details.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(iJournalFN)] = iJournal;
                    dr[LibraryMOD.GetFieldName(iSerialFN)] = iSerial;
                    dr[LibraryMOD.GetFieldName(strTitleFN)] = strTitle;
                    dr[LibraryMOD.GetFieldName(iAutorFN)] = iAutor;
                    dr[LibraryMOD.GetFieldName(strPagesFN)] = strPages;
                    dr[LibraryMOD.GetFieldName(strTopicFN)] = strTopic;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsJournals_Details.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsJournals_Details.Tables[TableName].Select(LibraryMOD.GetFieldName(iJournalFN) + "=" + iJournal + " AND " + LibraryMOD.GetFieldName(iSerialFN) + "=" + iSerial);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(iJournalFN)] = iJournal;
                    drAry[0][LibraryMOD.GetFieldName(iSerialFN)] = iSerial;
                    drAry[0][LibraryMOD.GetFieldName(strTitleFN)] = strTitle;
                    drAry[0][LibraryMOD.GetFieldName(iAutorFN)] = iAutor;
                    drAry[0][LibraryMOD.GetFieldName(strPagesFN)] = strPages;
                    drAry[0][LibraryMOD.GetFieldName(strTopicFN)] = strTopic;
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
    public int CommitJournals_Details()
    {
        //CommitJournals_Details= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daJournals_Details.Update(dsJournals_Details, TableName);
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
            FindInMultiPKey(iJournal, iSerial);
            if ((Journals_DetailsDataRow != null))
            {
                Journals_DetailsDataRow.Delete();
                CommitJournals_Details();
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
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(iJournalFN)] == System.DBNull.Value)
            {
                iJournal = 0;
            }
            else
            {
                iJournal = (int)Journals_DetailsDataRow[LibraryMOD.GetFieldName(iJournalFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(iSerialFN)] == System.DBNull.Value)
            {
                iSerial = 0;
            }
            else
            {
                iSerial = (int)Journals_DetailsDataRow[LibraryMOD.GetFieldName(iSerialFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(strTitleFN)] == System.DBNull.Value)
            {
                strTitle = "";
            }
            else
            {
                strTitle = (string)Journals_DetailsDataRow[LibraryMOD.GetFieldName(strTitleFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(iAutorFN)] == System.DBNull.Value)
            {
                iAutor = 0;
            }
            else
            {
                iAutor = (int)Journals_DetailsDataRow[LibraryMOD.GetFieldName(iAutorFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(strPagesFN)] == System.DBNull.Value)
            {
                strPages = "";
            }
            else
            {
                strPages = (string)Journals_DetailsDataRow[LibraryMOD.GetFieldName(strPagesFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(strTopicFN)] == System.DBNull.Value)
            {
                strTopic = "";
            }
            else
            {
                strTopic = (string)Journals_DetailsDataRow[LibraryMOD.GetFieldName(strTopicFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)Journals_DetailsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)Journals_DetailsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)Journals_DetailsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)Journals_DetailsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)Journals_DetailsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (Journals_DetailsDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)Journals_DetailsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKiJournal, int PKiSerial)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKiJournal;
            findTheseVals[1] = PKiSerial;
            Journals_DetailsDataRow = dsJournals_Details.Tables[TableName].Rows.Find(findTheseVals);
            if ((Journals_DetailsDataRow != null))
            {
                lngCurRow = dsJournals_Details.Tables[TableName].Rows.IndexOf(Journals_DetailsDataRow);
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
            lngCurRow = dsJournals_Details.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsJournals_Details.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsJournals_Details.Tables[TableName].Rows.Count > 0)
            {
                Journals_DetailsDataRow = dsJournals_Details.Tables[TableName].Rows[lngCurRow];
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
            daJournals_Details.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daJournals_Details.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daJournals_Details.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daJournals_Details.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
