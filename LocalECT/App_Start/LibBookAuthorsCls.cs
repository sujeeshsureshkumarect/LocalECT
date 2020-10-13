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
public class LibBookAuthors
{
    //Creation Date: 21/03/2011 12:18:34 PM
    //Programmer Name : hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_BookID;
    private int m_AuthorID;
    private int m_AuthorRoleID;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int BookID
    {
        get { return m_BookID; }
        set { m_BookID = value; }
    }
    public int AuthorID
    {
        get { return m_AuthorID; }
        set { m_AuthorID = value; }
    }
    public int AuthorRoleID
    {
        get { return m_AuthorRoleID; }
        set { m_AuthorRoleID = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibBookAuthors()
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
public class LibBookAuthorsDAL : LibBookAuthors
{
    #region "Decleration"
    private string m_TableName;
    private string m_BookIDFN;
    private string m_AuthorIDFN;
    private string m_AuthorRoleIDFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string BookIDFN
    {
        get { return m_BookIDFN; }
        set { m_BookIDFN = value; }
    }
    public string AuthorIDFN
    {
        get { return m_AuthorIDFN; }
        set { m_AuthorIDFN = value; }
    }
    public string AuthorRoleIDFN
    {
        get { return m_AuthorRoleIDFN; }
        set { m_AuthorRoleIDFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibBookAuthorsDAL()
    {
        try
        {
            this.TableName = "LibBookAuthors";
            this.BookIDFN = m_TableName + ".BookID";
            this.AuthorIDFN = m_TableName + ".AuthorID";
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
            sSQL += BookIDFN;
            sSQL += " , " + AuthorIDFN;
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
    //-----GetListSQl Function ---------------------------------
    public string GetListSQL(string sCondition)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += BookIDFN;
            sSQL += " , " + AuthorIDFN;
            sSQL += " , " + AuthorRoleIDFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION;
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
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += BookIDFN;
            sSQL += " , " + AuthorIDFN;
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
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorIDFN) + "=@AuthorID";
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorRoleIDFN) + "=@AuthorRoleID";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " And " + LibraryMOD.GetFieldName(AuthorIDFN) + "=@AuthorID";
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
            sSQL += LibraryMOD.GetFieldName(BookIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorRoleIDFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @BookID";
            sSQL += " ,@AuthorID";
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
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " And " + LibraryMOD.GetFieldName(AuthorIDFN) + "=@AuthorID";
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
    public List<LibBookAuthors> GetLibBookAuthors(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibBookAuthors
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
        List<LibBookAuthors> results = new List<LibBookAuthors>();
        try
        {
            //Default Value
            LibBookAuthors myLibBookAuthors = new LibBookAuthors();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookAuthors.BookID = 0;
                myLibBookAuthors.AuthorID = 0;
                results.Add(myLibBookAuthors);
            }
            while (reader.Read())
            {
                myLibBookAuthors = new LibBookAuthors();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookAuthors.BookID = 0;
                }
                else
                {
                    myLibBookAuthors.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AuthorIDFN)].Equals(DBNull.Value))
                {
                    myLibBookAuthors.AuthorID = 0;
                }
                else
                {
                    myLibBookAuthors.AuthorID = int.Parse(reader[LibraryMOD.GetFieldName(AuthorIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].Equals(DBNull.Value))
                {
                    myLibBookAuthors.AuthorRoleID = 0;
                }
                else
                {
                    myLibBookAuthors.AuthorRoleID = int.Parse(reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].ToString());
                }
                results.Add(myLibBookAuthors);
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
    public List<LibBookAuthors> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibBookAuthors> results = new List<LibBookAuthors>();
        try
        {
            //Default Value
            LibBookAuthors myLibBookAuthors = new LibBookAuthors();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookAuthors.BookID = -1;
                myLibBookAuthors.AuthorID = -1;
                results.Add(myLibBookAuthors);
            }
            while (reader.Read())
            {
                myLibBookAuthors = new LibBookAuthors();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookAuthors.BookID = 0;
                }
                else
                {
                    myLibBookAuthors.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AuthorIDFN)].Equals(DBNull.Value))
                {
                    myLibBookAuthors.AuthorID = 0;
                }
                else
                {
                    myLibBookAuthors.AuthorID = int.Parse(reader[LibraryMOD.GetFieldName(AuthorIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].Equals(DBNull.Value))
                {
                    myLibBookAuthors.AuthorRoleID = 0;
                }
                else
                {
                    myLibBookAuthors.AuthorRoleID = int.Parse(reader[LibraryMOD.GetFieldName(AuthorRoleIDFN)].ToString());
                }
                results.Add(myLibBookAuthors);
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
    public int UpdateLibBookAuthors(InitializeModule.EnumCampus Campus, int iMode, int BookID, int AuthorID, int AuthorRoleID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibBookAuthors theLibBookAuthors = new LibBookAuthors();
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
            Cmd.Parameters.Add(new SqlParameter("@BookID", BookID));
            Cmd.Parameters.Add(new SqlParameter("@AuthorID", AuthorID));
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
    public int DeleteLibBookAuthors(InitializeModule.EnumCampus Campus, string BookID, string AuthorID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@BookID", BookID));
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
        DataTable dt = new DataTable("LibBookAuthors");
        DataView dv = new DataView();
        List<LibBookAuthors> myLibBookAuthorss = new List<LibBookAuthors>();
        try
        {
            myLibBookAuthorss = GetLibBookAuthors(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("BookID", Type.GetType("int"));
            dt.Columns.Add(col0);
            DataColumn col1 = new DataColumn("AuthorID", Type.GetType("int"));
            dt.Columns.Add(col1);
            dt.Constraints.Add(new UniqueConstraint(col0));
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibBookAuthorss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibBookAuthorss[i].BookID;
                dr[2] = myLibBookAuthorss[i].AuthorID;
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
            myLibBookAuthorss.Clear();
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
            sSQL += BookIDFN;
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
public class LibBookAuthorsCls : LibBookAuthorsDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibBookAuthors;
    private DataSet m_dsLibBookAuthors;
    public DataRow LibBookAuthorsDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibBookAuthors
    {
        get { return m_dsLibBookAuthors; }
        set { m_dsLibBookAuthors = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibBookAuthorsCls()
    {
        try
        {
            dsLibBookAuthors = new DataSet();

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
    public virtual SqlDataAdapter GetLibBookAuthorsDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibBookAuthors = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibBookAuthors);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookAuthors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookAuthors;
    }
    public virtual SqlDataAdapter GetLibBookAuthorsDataAdapter(SqlConnection con)
    {
        try
        {
            daLibBookAuthors = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookAuthors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibBookAuthors;
            cmdLibBookAuthors = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@BookID", SqlDbType.Int, 4, "BookID" );
            //'cmdRolePermission.Parameters.Add("@AuthorID", SqlDbType.Int, 4, "AuthorID" );
            daLibBookAuthors.SelectCommand = cmdLibBookAuthors;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibBookAuthors = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibBookAuthors.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookAuthors.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            cmdLibBookAuthors.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));


            Parmeter = cmdLibBookAuthors.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter = cmdLibBookAuthors.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibBookAuthors.UpdateCommand = cmdLibBookAuthors;
            daLibBookAuthors.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibBookAuthors = new SqlCommand(GetInsertCommand(), con);
            cmdLibBookAuthors.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookAuthors.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            cmdLibBookAuthors.Parameters.Add("@AuthorRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorRoleIDFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibBookAuthors.InsertCommand = cmdLibBookAuthors;
            daLibBookAuthors.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibBookAuthors = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibBookAuthors.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter = cmdLibBookAuthors.Parameters.Add("@AuthorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuthorIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibBookAuthors.DeleteCommand = cmdLibBookAuthors;
            daLibBookAuthors.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibBookAuthors.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookAuthors;
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
                    dr = dsLibBookAuthors.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    dr[LibraryMOD.GetFieldName(AuthorIDFN)] = AuthorID;
                    dr[LibraryMOD.GetFieldName(AuthorRoleIDFN)] = AuthorRoleID;
                    dsLibBookAuthors.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibBookAuthors.Tables[TableName].Select(LibraryMOD.GetFieldName(BookIDFN) + "=" + BookID + " AND " + LibraryMOD.GetFieldName(AuthorIDFN) + "=" + AuthorID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    drAry[0][LibraryMOD.GetFieldName(AuthorIDFN)] = AuthorID;
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
    public int CommitLibBookAuthors()
    {
        //CommitLibBookAuthors= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibBookAuthors.Update(dsLibBookAuthors, TableName);
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
            FindInMultiPKey(BookID, AuthorID);
            if ((LibBookAuthorsDataRow != null))
            {
                LibBookAuthorsDataRow.Delete();
                CommitLibBookAuthors();
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
            if (LibBookAuthorsDataRow[LibraryMOD.GetFieldName(BookIDFN)] == System.DBNull.Value)
            {
                BookID = 0;
            }
            else
            {
                BookID = (int)LibBookAuthorsDataRow[LibraryMOD.GetFieldName(BookIDFN)];
            }
            if (LibBookAuthorsDataRow[LibraryMOD.GetFieldName(AuthorIDFN)] == System.DBNull.Value)
            {
                AuthorID = 0;
            }
            else
            {
                AuthorID = (int)LibBookAuthorsDataRow[LibraryMOD.GetFieldName(AuthorIDFN)];
            }
            if (LibBookAuthorsDataRow[LibraryMOD.GetFieldName(AuthorRoleIDFN)] == System.DBNull.Value)
            {
                AuthorRoleID = 0;
            }
            else
            {
                AuthorRoleID = (int)LibBookAuthorsDataRow[LibraryMOD.GetFieldName(AuthorRoleIDFN)];
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
    public int FindInMultiPKey(int PKBookID, int PKAuthorID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKBookID;
            findTheseVals[1] = PKAuthorID;
            LibBookAuthorsDataRow = dsLibBookAuthors.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibBookAuthorsDataRow != null))
            {
                lngCurRow = dsLibBookAuthors.Tables[TableName].Rows.IndexOf(LibBookAuthorsDataRow);
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
            lngCurRow = dsLibBookAuthors.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibBookAuthors.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibBookAuthors.Tables[TableName].Rows.Count > 0)
            {
                LibBookAuthorsDataRow = dsLibBookAuthors.Tables[TableName].Rows[lngCurRow];
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
            daLibBookAuthors.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookAuthors.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibBookAuthors.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookAuthors.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
