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
public class LibBookPublishers
{
    //Creation Date: 02/01/2011 2:24:37 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_BookID;
    private int m_PublisherID;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int BookID
    {
        get { return m_BookID; }
        set { m_BookID = value; }
    }
    public int PublisherID
    {
        get { return m_PublisherID; }
        set { m_PublisherID = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibBookPublishers()
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
public class LibBookPublishersDAL : LibBookPublishers
{
    #region "Decleration"
    private string m_TableName;
    private string m_BookIDFN;
    private string m_PublisherIDFN;
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
    public string PublisherIDFN
    {
        get { return m_PublisherIDFN; }
        set { m_PublisherIDFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibBookPublishersDAL()
    {
        try
        {
            this.TableName = "LibBookPublishers";
            this.BookIDFN = m_TableName + ".BookID";
            this.PublisherIDFN = m_TableName + ".PublisherID";
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
            sSQL += " , " + PublisherIDFN;
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
            sSQL += " , " + PublisherIDFN;
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
            sSQL += " , " + PublisherIDFN;
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
            sSQL += " , " + LibraryMOD.GetFieldName(PublisherIDFN) + "=@PublisherID";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " And " + LibraryMOD.GetFieldName(PublisherIDFN) + "=@PublisherID";
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
            sSQL += " , " + LibraryMOD.GetFieldName(PublisherIDFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @BookID";
            sSQL += " ,@PublisherID";
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
            sSQL += " And " + LibraryMOD.GetFieldName(PublisherIDFN) + "=@PublisherID";
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
    public List<LibBookPublishers> GetLibBookPublishers(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibBookPublishers
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
        List<LibBookPublishers> results = new List<LibBookPublishers>();
        try
        {
            //Default Value
            LibBookPublishers myLibBookPublishers = new LibBookPublishers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookPublishers.BookID = 0;
                myLibBookPublishers.PublisherID = 0;
                myLibBookPublishers.PublisherID = 0;
                results.Add(myLibBookPublishers);
            }
            while (reader.Read())
            {
                myLibBookPublishers = new LibBookPublishers();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookPublishers.BookID = 0;
                }
                else
                {
                    myLibBookPublishers.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(PublisherIDFN)].Equals(DBNull.Value))
                {
                    myLibBookPublishers.PublisherID = 0;
                }
                else
                {
                    myLibBookPublishers.PublisherID = int.Parse(reader[LibraryMOD.GetFieldName(PublisherIDFN)].ToString());
                }
                results.Add(myLibBookPublishers);
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

    public List<LibBookPublishers> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibBookPublishers> results = new List<LibBookPublishers>();
        try
        {
            //Default Value
            LibBookPublishers myLibBookPublishers = new LibBookPublishers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookPublishers.BookID = -1;
                myLibBookPublishers.PublisherID = -1;
                results.Add(myLibBookPublishers);
            }
            while (reader.Read())
            {
                myLibBookPublishers = new LibBookPublishers();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookPublishers.BookID = 0;
                }
                else
                {
                    myLibBookPublishers.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(PublisherIDFN)].Equals(DBNull.Value))
                {
                    myLibBookPublishers.PublisherID = 0;
                }
                else
                {
                    myLibBookPublishers.PublisherID = int.Parse(reader[LibraryMOD.GetFieldName(PublisherIDFN)].ToString());
                }
                results.Add(myLibBookPublishers);
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
    public int UpdateLibBookPublishers(InitializeModule.EnumCampus Campus, int iMode, int BookID, int PublisherID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibBookPublishers theLibBookPublishers = new LibBookPublishers();
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
            Cmd.Parameters.Add(new SqlParameter("@PublisherID", PublisherID));
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
    public int DeleteLibBookPublishers(InitializeModule.EnumCampus Campus, string BookID, string PublisherID)
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
            Cmd.Parameters.Add(new SqlParameter("@PublisherID", PublisherID));
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
        DataTable dt = new DataTable("LibBookPublishers");
        DataView dv = new DataView();
        List<LibBookPublishers> myLibBookPublisherss = new List<LibBookPublishers>();
        try
        {
            myLibBookPublisherss = GetLibBookPublishers(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("BookID", Type.GetType("int"));
            dt.Columns.Add(col0);
            DataColumn col1 = new DataColumn("PublisherID", Type.GetType("int"));
            dt.Columns.Add(col1);
            dt.Constraints.Add(new UniqueConstraint(col0));
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibBookPublisherss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibBookPublisherss[i].BookID;
                dr[2] = myLibBookPublisherss[i].PublisherID;
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
            myLibBookPublisherss.Clear();
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
public class LibBookPublishersCls : LibBookPublishersDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibBookPublishers;
    private DataSet m_dsLibBookPublishers;
    public DataRow LibBookPublishersDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibBookPublishers
    {
        get { return m_dsLibBookPublishers; }
        set { m_dsLibBookPublishers = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibBookPublishersCls()
    {
        try
        {
            dsLibBookPublishers = new DataSet();

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
    public virtual SqlDataAdapter GetLibBookPublishersDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibBookPublishers = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibBookPublishers);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookPublishers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookPublishers;
    }
    public virtual SqlDataAdapter GetLibBookPublishersDataAdapter(SqlConnection con)
    {
        try
        {
            daLibBookPublishers = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookPublishers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibBookPublishers;
            cmdLibBookPublishers = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@BookID", SqlDbType.Int, 4, "BookID" );
            //'cmdRolePermission.Parameters.Add("@PublisherID", SqlDbType.Int, 4, "PublisherID" );
            daLibBookPublishers.SelectCommand = cmdLibBookPublishers;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibBookPublishers = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibBookPublishers.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookPublishers.Parameters.Add("@PublisherID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublisherIDFN));


            Parmeter = cmdLibBookPublishers.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter = cmdLibBookPublishers.Parameters.Add("@PublisherID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublisherIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibBookPublishers.UpdateCommand = cmdLibBookPublishers;
            daLibBookPublishers.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibBookPublishers = new SqlCommand(GetInsertCommand(), con);
            cmdLibBookPublishers.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookPublishers.Parameters.Add("@PublisherID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublisherIDFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibBookPublishers.InsertCommand = cmdLibBookPublishers;
            daLibBookPublishers.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibBookPublishers = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibBookPublishers.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter = cmdLibBookPublishers.Parameters.Add("@PublisherID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublisherIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibBookPublishers.DeleteCommand = cmdLibBookPublishers;
            daLibBookPublishers.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibBookPublishers.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookPublishers;
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
                    dr = dsLibBookPublishers.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    dr[LibraryMOD.GetFieldName(PublisherIDFN)] = PublisherID;
                    dsLibBookPublishers.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibBookPublishers.Tables[TableName].Select(LibraryMOD.GetFieldName(BookIDFN) + "=" + BookID + " AND " + LibraryMOD.GetFieldName(PublisherIDFN) + "=" + PublisherID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    drAry[0][LibraryMOD.GetFieldName(PublisherIDFN)] = PublisherID;
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
    public int CommitLibBookPublishers()
    {
        //CommitLibBookPublishers= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibBookPublishers.Update(dsLibBookPublishers, TableName);
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
            FindInMultiPKey(BookID, PublisherID);
            if ((LibBookPublishersDataRow != null))
            {
                LibBookPublishersDataRow.Delete();
                CommitLibBookPublishers();
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
            if (LibBookPublishersDataRow[LibraryMOD.GetFieldName(BookIDFN)] == System.DBNull.Value)
            {
                BookID = 0;
            }
            else
            {
                BookID = (int)LibBookPublishersDataRow[LibraryMOD.GetFieldName(BookIDFN)];
            }
            if (LibBookPublishersDataRow[LibraryMOD.GetFieldName(PublisherIDFN)] == System.DBNull.Value)
            {
                PublisherID = 0;
            }
            else
            {
                PublisherID = (int)LibBookPublishersDataRow[LibraryMOD.GetFieldName(PublisherIDFN)];
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
    public int FindInMultiPKey(int PKBookID, int PKPublisherID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKBookID;
            findTheseVals[1] = PKPublisherID;
            LibBookPublishersDataRow = dsLibBookPublishers.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibBookPublishersDataRow != null))
            {
                lngCurRow = dsLibBookPublishers.Tables[TableName].Rows.IndexOf(LibBookPublishersDataRow);
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
            lngCurRow = dsLibBookPublishers.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibBookPublishers.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibBookPublishers.Tables[TableName].Rows.Count > 0)
            {
                LibBookPublishersDataRow = dsLibBookPublishers.Tables[TableName].Rows[lngCurRow];
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
            daLibBookPublishers.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookPublishers.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibBookPublishers.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookPublishers.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
