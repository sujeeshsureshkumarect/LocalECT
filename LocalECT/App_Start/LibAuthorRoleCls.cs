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
public class LibAuthorRole
{
    //Creation Date: 06/12/2010 10:13:56 AM
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_AuthorRoleID;
    private string m_ArRoleDesc;
    private string m_EnRoleDesc;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int AuthorRoleID
    {
        get { return m_AuthorRoleID; }
        set { m_AuthorRoleID = value; }
    }
    public string ArRoleDesc
    {
        get { return m_ArRoleDesc; }
        set { m_ArRoleDesc = value; }
    }
    public string EnRoleDesc
    {
        get { return m_EnRoleDesc; }
        set { m_EnRoleDesc = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibAuthorRole()
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
public class LibAuthorRoleDAL : LibAuthorRole
{
    #region "Decleration"
    private string m_TableName;
    private string m_AuthorRoleIDFN;
    private string m_ArRoleDescFN;
    private string m_EnRoleDescFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string AuthorRoleIDFN
    {
        get { return m_AuthorRoleIDFN; }
        set { m_AuthorRoleIDFN = value; }
    }
    public string ArRoleDescFN
    {
        get { return m_ArRoleDescFN; }
        set { m_ArRoleDescFN = value; }
    }
    public string EnRoleDescFN
    {
        get { return m_EnRoleDescFN; }
        set { m_EnRoleDescFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibAuthorRoleDAL()
    {
        try
        {
            this.TableName = "LibAuthorRole";
            this.AuthorRoleIDFN = m_TableName + ".AuthorRoleID";
            this.ArRoleDescFN = m_TableName + ".ArRoleDesc";
            this.EnRoleDescFN = m_TableName + ".EnRoleDesc";
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
            sSQL += AuthorRoleIDFN;
            sSQL += " , " + ArRoleDescFN;
            sSQL += " , " + EnRoleDescFN;
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
            sSQL += AuthorRoleIDFN;
            sSQL += " , " + ArRoleDescFN;
            sSQL += " , " + EnRoleDescFN;
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
            sSQL += LibraryMOD.GetFieldName(AuthorRoleIDFN) + "=@AuthorRoleID";
            sSQL += " , " + LibraryMOD.GetFieldName(ArRoleDescFN) + "=@ArRoleDesc";
            sSQL += " , " + LibraryMOD.GetFieldName(EnRoleDescFN) + "=@EnRoleDesc";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(AuthorRoleIDFN) + "=@AuthorRoleID";
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
            sSQL += LibraryMOD.GetFieldName(AuthorRoleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ArRoleDescFN);
            sSQL += " , " + LibraryMOD.GetFieldName(EnRoleDescFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @AuthorRoleID";
            sSQL += " ,@ArRoleDesc";
            sSQL += " ,@EnRoleDesc";
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
            sSQL += LibraryMOD.GetFieldName(AuthorRoleIDFN) + "=@AuthorRoleID";
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
    public List<LibAuthorRole> GetLibAuthorRole(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibAuthorRole
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
        List<LibAuthorRole> results = new List<LibAuthorRole>();
        try
        {
            //Default Value
            LibAuthorRole myLibAuthorRole = new LibAuthorRole();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibAuthorRole.AuthorRoleID = 0;
                myLibAuthorRole.ArRoleDesc = "Select LibAuthorRole ...";
                results.Add(myLibAuthorRole);
            }
            while (reader.Read())
            {
                myLibAuthorRole = new LibAuthorRole();
                if (reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].Equals(DBNull.Value))
                {
                    myLibAuthorRole.AuthorRoleID = 0;
                }
                else
                {
                    myLibAuthorRole.AuthorRoleID = int.Parse(reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].ToString());
                }
                myLibAuthorRole.ArRoleDesc = reader[LibraryMOD.GetFieldName(ArRoleDescFN)].ToString();
                myLibAuthorRole.EnRoleDesc = reader[LibraryMOD.GetFieldName(EnRoleDescFN)].ToString();
                results.Add(myLibAuthorRole);
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
    public int UpdateLibAuthorRole(InitializeModule.EnumCampus Campus, int iMode, int AuthorRoleID, string ArRoleDesc, string EnRoleDesc)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibAuthorRole theLibAuthorRole = new LibAuthorRole();
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
            Cmd.Parameters.Add(new SqlParameter("@AuthorRoleID", AuthorRoleID));
            Cmd.Parameters.Add(new SqlParameter("@ArRoleDesc", ArRoleDesc));
            Cmd.Parameters.Add(new SqlParameter("@EnRoleDesc", EnRoleDesc));
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
    public int DeleteLibAuthorRole(InitializeModule.EnumCampus Campus, string AuthorRoleID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@AuthorRoleID", AuthorRoleID));
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
        DataTable dt = new DataTable("LibAuthorRole");
        DataView dv = new DataView();
        List<LibAuthorRole> myLibAuthorRoles = new List<LibAuthorRole>();
        try
        {
            myLibAuthorRoles = GetLibAuthorRole(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("AuthorRoleID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("ArRoleDesc", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("EnRoleDesc", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibAuthorRoles.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibAuthorRoles[i].AuthorRoleID;
                dr[2] = myLibAuthorRoles[i].ArRoleDesc;
                dr[3] = myLibAuthorRoles[i].EnRoleDesc;
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
            myLibAuthorRoles.Clear();
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
            sSQL += AuthorRoleIDFN;
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
public class LibAuthorRoleCls : LibAuthorRoleDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibAuthorRole;
    private DataSet m_dsLibAuthorRole;
    public DataRow LibAuthorRoleDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibAuthorRole
    {
        get { return m_dsLibAuthorRole; }
        set { m_dsLibAuthorRole = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibAuthorRoleCls()
    {
        try
        {
            dsLibAuthorRole = new DataSet();

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
    public virtual SqlDataAdapter GetLibAuthorRoleDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibAuthorRole = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibAuthorRole);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibAuthorRole.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibAuthorRole;
    }
    public virtual SqlDataAdapter GetLibAuthorRoleDataAdapter(SqlConnection con)
    {
        try
        {
            daLibAuthorRole = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibAuthorRole.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibAuthorRole;
            cmdLibAuthorRole = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, "AuthorRoleID" );
            daLibAuthorRole.SelectCommand = cmdLibAuthorRole;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibAuthorRole = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibAuthorRole.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));
            cmdLibAuthorRole.Parameters.Add("@ArRoleDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(ArRoleDescFN));
            cmdLibAuthorRole.Parameters.Add("@EnRoleDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(EnRoleDescFN));


            Parmeter = cmdLibAuthorRole.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibAuthorRole.UpdateCommand = cmdLibAuthorRole;
            daLibAuthorRole.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibAuthorRole = new SqlCommand(GetInsertCommand(), con);
            cmdLibAuthorRole.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));
            cmdLibAuthorRole.Parameters.Add("@ArRoleDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(ArRoleDescFN));
            cmdLibAuthorRole.Parameters.Add("@EnRoleDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(EnRoleDescFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibAuthorRole.InsertCommand = cmdLibAuthorRole;
            daLibAuthorRole.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibAuthorRole = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibAuthorRole.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibAuthorRole.DeleteCommand = cmdLibAuthorRole;
            daLibAuthorRole.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibAuthorRole.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibAuthorRole;
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
                    dr = dsLibAuthorRole.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(AuthorRoleIDFN)] = AuthorRoleID;
                    dr[LibraryMOD.GetFieldName(ArRoleDescFN)] = ArRoleDesc;
                    dr[LibraryMOD.GetFieldName(EnRoleDescFN)] = EnRoleDesc;
                    dsLibAuthorRole.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibAuthorRole.Tables[TableName].Select(LibraryMOD.GetFieldName(AuthorRoleIDFN) + "=" + AuthorRoleID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(AuthorRoleIDFN)] = AuthorRoleID;
                    drAry[0][LibraryMOD.GetFieldName(ArRoleDescFN)] = ArRoleDesc;
                    drAry[0][LibraryMOD.GetFieldName(EnRoleDescFN)] = EnRoleDesc;
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
    public int CommitLibAuthorRole()
    {
        //CommitLibAuthorRole= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibAuthorRole.Update(dsLibAuthorRole, TableName);
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
            FindInMultiPKey(AuthorRoleID);
            if ((LibAuthorRoleDataRow != null))
            {
                LibAuthorRoleDataRow.Delete();
                CommitLibAuthorRole();
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
            if (LibAuthorRoleDataRow[LibraryMOD.GetFieldName(AuthorRoleIDFN)] == System.DBNull.Value)
            {
                AuthorRoleID = 0;
            }
            else
            {
                AuthorRoleID = (int)LibAuthorRoleDataRow[LibraryMOD.GetFieldName(AuthorRoleIDFN)];
            }
            if (LibAuthorRoleDataRow[LibraryMOD.GetFieldName(ArRoleDescFN)] == System.DBNull.Value)
            {
                ArRoleDesc = "";
            }
            else
            {
                ArRoleDesc = (string)LibAuthorRoleDataRow[LibraryMOD.GetFieldName(ArRoleDescFN)];
            }
            if (LibAuthorRoleDataRow[LibraryMOD.GetFieldName(EnRoleDescFN)] == System.DBNull.Value)
            {
                EnRoleDesc = "";
            }
            else
            {
                EnRoleDesc = (string)LibAuthorRoleDataRow[LibraryMOD.GetFieldName(EnRoleDescFN)];
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
    public int FindInMultiPKey(int PKAuthorRoleID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKAuthorRoleID;
            LibAuthorRoleDataRow = dsLibAuthorRole.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibAuthorRoleDataRow != null))
            {
                lngCurRow = dsLibAuthorRole.Tables[TableName].Rows.IndexOf(LibAuthorRoleDataRow);
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
            lngCurRow = dsLibAuthorRole.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibAuthorRole.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibAuthorRole.Tables[TableName].Rows.Count > 0)
            {
                LibAuthorRoleDataRow = dsLibAuthorRole.Tables[TableName].Rows[lngCurRow];
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
            daLibAuthorRole.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibAuthorRole.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibAuthorRole.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibAuthorRole.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
