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
public class LibAuthor
{
    //Creation Date: 07/12/2010 1:19:43 PM
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_AuthorID;
    private string m_StrFirstName;
    private string m_StrSecondName;
    private string m_StrLastName;
    private int m_AuthorRoleID;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int AuthorID
    {
        get { return m_AuthorID; }
        set { m_AuthorID = value; }
    }
    public string StrFirstName
    {
        get { return m_StrFirstName; }
        set { m_StrFirstName = value; }
    }
    public string StrSecondName
    {
        get { return m_StrSecondName; }
        set { m_StrSecondName = value; }
    }
    public string StrLastName
    {
        get { return m_StrLastName; }
        set { m_StrLastName = value; }
    }
    public int AuthorRoleID
    {
        get { return m_AuthorRoleID; }
        set { m_AuthorRoleID = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibAuthor()
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
public class LibAuthorDAL : LibAuthor
{
    #region "Decleration"
    private string m_TableName;
    private string m_AuthorIDFN;
    private string m_StrFirstNameFN;
    private string m_StrSecondNameFN;
    private string m_StrLastNameFN;
    private string m_AuthorRoleIDFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string AuthorIDFN
    {
        get { return m_AuthorIDFN; }
        set { m_AuthorIDFN = value; }
    }
    public string StrFirstNameFN
    {
        get { return m_StrFirstNameFN; }
        set { m_StrFirstNameFN = value; }
    }
    public string StrSecondNameFN
    {
        get { return m_StrSecondNameFN; }
        set { m_StrSecondNameFN = value; }
    }
    public string StrLastNameFN
    {
        get { return m_StrLastNameFN; }
        set { m_StrLastNameFN = value; }
    }
    public string AuthorRoleIDFN
    {
        get { return m_AuthorRoleIDFN; }
        set { m_AuthorRoleIDFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibAuthorDAL()
    {
        try
        {
            this.TableName = "LibAuthor";
            this.AuthorIDFN = m_TableName + ".AuthorID";
            this.StrFirstNameFN = m_TableName + ".StrFirstName";
            this.StrSecondNameFN = m_TableName + ".StrSecondName";
            this.StrLastNameFN = m_TableName + ".StrLastName";
            this.AuthorRoleIDFN = m_TableName + ".AuthorRoleID";
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
            sSQL += AuthorIDFN;
            sSQL += " , " + StrFirstNameFN;
            sSQL += " , " + StrSecondNameFN;
            sSQL += " , " + StrLastNameFN;
            sSQL += " , " + AuthorRoleIDFN;
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
            sSQL += AuthorIDFN;
            sSQL += " , " + StrFirstNameFN;
            sSQL += " , " + StrSecondNameFN;
            sSQL += " , " + StrLastNameFN;
            sSQL += " , " + AuthorRoleIDFN;
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
            sSQL += LibraryMOD.GetFieldName(AuthorIDFN) + "=@AuthorID";
            sSQL += " , " + LibraryMOD.GetFieldName(StrFirstNameFN) + "=@StrFirstName";
            sSQL += " , " + LibraryMOD.GetFieldName(StrSecondNameFN) + "=@StrSecondName";
            sSQL += " , " + LibraryMOD.GetFieldName(StrLastNameFN) + "=@StrLastName";
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorRoleIDFN) + "=@AuthorRoleID";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(AuthorIDFN) + "=@AuthorID";
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
            sSQL += LibraryMOD.GetFieldName(AuthorIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(StrFirstNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(StrSecondNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(StrLastNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorRoleIDFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @AuthorID";
            sSQL += " ,@StrFirstName";
            sSQL += " ,@StrSecondName";
            sSQL += " ,@StrLastName";
            sSQL += " ,@AuthorRoleID";
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
            sSQL += LibraryMOD.GetFieldName(AuthorIDFN) + "=@AuthorID";
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
    public List<LibAuthor> GetLibAuthor(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibAuthor
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
        List<LibAuthor> results = new List<LibAuthor>();
        try
        {
            //Default Value
            LibAuthor myLibAuthor = new LibAuthor();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibAuthor.AuthorID = 0;
                myLibAuthor.StrFirstName = "Select LibAuthor ...";
                results.Add(myLibAuthor);
            }
            while (reader.Read())
            {
                myLibAuthor = new LibAuthor();
                if (reader[LibraryMOD.GetFieldName(AuthorIDFN)].Equals(DBNull.Value))
                {
                    myLibAuthor.AuthorID = 0;
                }
                else
                {
                    myLibAuthor.AuthorID = int.Parse(reader[LibraryMOD.GetFieldName(AuthorIDFN)].ToString());
                }
                myLibAuthor.StrFirstName = reader[LibraryMOD.GetFieldName(StrFirstNameFN)].ToString();
                myLibAuthor.StrSecondName = reader[LibraryMOD.GetFieldName(StrSecondNameFN)].ToString();
                myLibAuthor.StrLastName = reader[LibraryMOD.GetFieldName(StrLastNameFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].Equals(DBNull.Value))
                {
                    myLibAuthor.AuthorRoleID = 0;
                }
                else
                {
                    myLibAuthor.AuthorRoleID = int.Parse(reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].ToString());
                }
                results.Add(myLibAuthor);
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
    public int UpdateLibAuthor(InitializeModule.EnumCampus Campus, int iMode, int AuthorID, string StrFirstName, string StrSecondName, string StrLastName, int AuthorRoleID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibAuthor theLibAuthor = new LibAuthor();
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
            Cmd.Parameters.Add(new SqlParameter("@AuthorID", AuthorID));
            Cmd.Parameters.Add(new SqlParameter("@StrFirstName", StrFirstName));
            Cmd.Parameters.Add(new SqlParameter("@StrSecondName", StrSecondName));
            Cmd.Parameters.Add(new SqlParameter("@StrLastName", StrLastName));
            if (AuthorRoleID != -1)
                Cmd.Parameters.Add(new SqlParameter("@AuthorRoleID", AuthorRoleID));
            else
                Cmd.Parameters.AddWithValue("@AuthorRoleID", DBNull.Value);

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
    public int DeleteLibAuthor(InitializeModule.EnumCampus Campus, string AuthorID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@AuthorID", AuthorID));
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
        DataTable dt = new DataTable("LibAuthor");
        DataView dv = new DataView();
        List<LibAuthor> myLibAuthors = new List<LibAuthor>();
        try
        {
            myLibAuthors = GetLibAuthor(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("AuthorID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("StrFirstName", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("StrSecondName", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibAuthors.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibAuthors[i].AuthorID;
                dr[2] = myLibAuthors[i].StrFirstName;
                dr[3] = myLibAuthors[i].StrSecondName;
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
            myLibAuthors.Clear();
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
            sSQL += AuthorIDFN;
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
public class LibAuthorCls : LibAuthorDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibAuthor;
    private DataSet m_dsLibAuthor;
    public DataRow LibAuthorDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibAuthor
    {
        get { return m_dsLibAuthor; }
        set { m_dsLibAuthor = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibAuthorCls()
    {
        try
        {
            dsLibAuthor = new DataSet();

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
    public virtual SqlDataAdapter GetLibAuthorDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibAuthor = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibAuthor);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibAuthor.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibAuthor;
    }
    public virtual SqlDataAdapter GetLibAuthorDataAdapter(SqlConnection con)
    {
        try
        {
            daLibAuthor = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibAuthor.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibAuthor;
            cmdLibAuthor = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@AuthorID", SqlDbType.Int, 4, "AuthorID" );
            daLibAuthor.SelectCommand = cmdLibAuthor;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibAuthor = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibAuthor.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            cmdLibAuthor.Parameters.Add("@StrFirstName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(StrFirstNameFN));
            cmdLibAuthor.Parameters.Add("@StrSecondName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(StrSecondNameFN));
            cmdLibAuthor.Parameters.Add("@StrLastName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(StrLastNameFN));
            cmdLibAuthor.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));


            Parmeter = cmdLibAuthor.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibAuthor.UpdateCommand = cmdLibAuthor;
            daLibAuthor.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibAuthor = new SqlCommand(GetInsertCommand(), con);
            cmdLibAuthor.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            cmdLibAuthor.Parameters.Add("@StrFirstName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(StrFirstNameFN));
            cmdLibAuthor.Parameters.Add("@StrSecondName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(StrSecondNameFN));
            cmdLibAuthor.Parameters.Add("@StrLastName", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(StrLastNameFN));
            cmdLibAuthor.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibAuthor.InsertCommand = cmdLibAuthor;
            daLibAuthor.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibAuthor = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibAuthor.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibAuthor.DeleteCommand = cmdLibAuthor;
            daLibAuthor.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibAuthor.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibAuthor;
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
                    dr = dsLibAuthor.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(AuthorIDFN)] = AuthorID;
                    dr[LibraryMOD.GetFieldName(StrFirstNameFN)] = StrFirstName;
                    dr[LibraryMOD.GetFieldName(StrSecondNameFN)] = StrSecondName;
                    dr[LibraryMOD.GetFieldName(StrLastNameFN)] = StrLastName;
                    dr[LibraryMOD.GetFieldName(AuthorRoleIDFN)] = AuthorRoleID;
                    dsLibAuthor.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibAuthor.Tables[TableName].Select(LibraryMOD.GetFieldName(AuthorIDFN) + "=" + AuthorID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(AuthorIDFN)] = AuthorID;
                    drAry[0][LibraryMOD.GetFieldName(StrFirstNameFN)] = StrFirstName;
                    drAry[0][LibraryMOD.GetFieldName(StrSecondNameFN)] = StrSecondName;
                    drAry[0][LibraryMOD.GetFieldName(StrLastNameFN)] = StrLastName;
                    drAry[0][LibraryMOD.GetFieldName(AuthorRoleIDFN)] = AuthorRoleID;
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
    public int CommitLibAuthor()
    {
        //CommitLibAuthor= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibAuthor.Update(dsLibAuthor, TableName);
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
            FindInMultiPKey(AuthorID);
            if ((LibAuthorDataRow != null))
            {
                LibAuthorDataRow.Delete();
                CommitLibAuthor();
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
            if (LibAuthorDataRow[LibraryMOD.GetFieldName(AuthorIDFN)] == System.DBNull.Value)
            {
                AuthorID = 0;
            }
            else
            {
                AuthorID = (int)LibAuthorDataRow[LibraryMOD.GetFieldName(AuthorIDFN)];
            }
            if (LibAuthorDataRow[LibraryMOD.GetFieldName(StrFirstNameFN)] == System.DBNull.Value)
            {
                StrFirstName = "";
            }
            else
            {
                StrFirstName = (string)LibAuthorDataRow[LibraryMOD.GetFieldName(StrFirstNameFN)];
            }
            if (LibAuthorDataRow[LibraryMOD.GetFieldName(StrSecondNameFN)] == System.DBNull.Value)
            {
                StrSecondName = "";
            }
            else
            {
                StrSecondName = (string)LibAuthorDataRow[LibraryMOD.GetFieldName(StrSecondNameFN)];
            }
            if (LibAuthorDataRow[LibraryMOD.GetFieldName(StrLastNameFN)] == System.DBNull.Value)
            {
                StrLastName = "";
            }
            else
            {
                StrLastName = (string)LibAuthorDataRow[LibraryMOD.GetFieldName(StrLastNameFN)];
            }
            if (LibAuthorDataRow[LibraryMOD.GetFieldName(AuthorRoleIDFN)] == System.DBNull.Value)
            {
                AuthorRoleID = 0;
            }
            else
            {
                AuthorRoleID = (int)LibAuthorDataRow[LibraryMOD.GetFieldName(AuthorRoleIDFN)];
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
    public int FindInMultiPKey(int PKAuthorID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKAuthorID;
            LibAuthorDataRow = dsLibAuthor.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibAuthorDataRow != null))
            {
                lngCurRow = dsLibAuthor.Tables[TableName].Rows.IndexOf(LibAuthorDataRow);
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
            lngCurRow = dsLibAuthor.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibAuthor.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibAuthor.Tables[TableName].Rows.Count > 0)
            {
                LibAuthorDataRow = dsLibAuthor.Tables[TableName].Rows[lngCurRow];
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
            daLibAuthor.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibAuthor.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibAuthor.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibAuthor.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
