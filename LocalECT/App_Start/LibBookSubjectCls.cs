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
public class LibBookSubject
{
    //Creation Date: 03/01/2011 1:37:51 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_BookID;
    private int m_SubjectTypeID;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int BookID
    {
        get { return m_BookID; }
        set { m_BookID = value; }
    }
    public int SubjectTypeID
    {
        get { return m_SubjectTypeID; }
        set { m_SubjectTypeID = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibBookSubject()
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
public class LibBookSubjectDAL : LibBookSubject
{
    #region "Decleration"
    private string m_TableName;
    private string m_BookIDFN;
    private string m_SubjectTypeIDFN;
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
    public string SubjectTypeIDFN
    {
        get { return m_SubjectTypeIDFN; }
        set { m_SubjectTypeIDFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibBookSubjectDAL()
    {
        try
        {
            this.TableName = "LibBookSubject";
            this.BookIDFN = m_TableName + ".BookID";
            this.SubjectTypeIDFN = m_TableName + ".SubjectTypeID";
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
            sSQL += " , " + SubjectTypeIDFN;
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
            sSQL += " , " + SubjectTypeIDFN;
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
            sSQL += " , " + SubjectTypeIDFN;
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
            sSQL += " , " + LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=@SubjectTypeID";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " And " + LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=@SubjectTypeID";
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
            sSQL += " , " + LibraryMOD.GetFieldName(SubjectTypeIDFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @BookID";
            sSQL += " ,@SubjectTypeID";
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
            sSQL += " And " + LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=@SubjectTypeID";
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
    public List<LibBookSubject> GetLibBookSubject(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibBookSubject
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
        List<LibBookSubject> results = new List<LibBookSubject>();
        try
        {
            //Default Value
            LibBookSubject myLibBookSubject = new LibBookSubject();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookSubject.BookID = 0;
                myLibBookSubject.SubjectTypeID = 0;
                results.Add(myLibBookSubject);
            }
            while (reader.Read())
            {
                myLibBookSubject = new LibBookSubject();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookSubject.BookID = 0;
                }
                else
                {
                    myLibBookSubject.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SubjectTypeIDFN)].Equals(DBNull.Value))
                {
                    myLibBookSubject.SubjectTypeID = 0;
                }
                else
                {
                    myLibBookSubject.SubjectTypeID = int.Parse(reader[LibraryMOD.GetFieldName(SubjectTypeIDFN)].ToString());
                }
                results.Add(myLibBookSubject);
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
    public List<LibBookSubject> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibBookSubject> results = new List<LibBookSubject>();
        try
        {
            //Default Value
            LibBookSubject myLibBookSubject = new LibBookSubject();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookSubject.BookID = -1;
                myLibBookSubject.SubjectTypeID = -1;
                results.Add(myLibBookSubject);
            }
            while (reader.Read())
            {
                myLibBookSubject = new LibBookSubject();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookSubject.BookID = 0;
                }
                else
                {
                    myLibBookSubject.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SubjectTypeIDFN)].Equals(DBNull.Value))
                {
                    myLibBookSubject.SubjectTypeID = 0;
                }
                else
                {
                    myLibBookSubject.SubjectTypeID = int.Parse(reader[LibraryMOD.GetFieldName(SubjectTypeIDFN)].ToString());
                }
                results.Add(myLibBookSubject);
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
    public int UpdateLibBookSubject(InitializeModule.EnumCampus Campus, int iMode, int BookID, int SubjectTypeID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibBookSubject theLibBookSubject = new LibBookSubject();
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
            Cmd.Parameters.Add(new SqlParameter("@SubjectTypeID", SubjectTypeID));
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
    public int DeleteLibBookSubject(InitializeModule.EnumCampus Campus, string BookID, string SubjectTypeID)
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
            Cmd.Parameters.Add(new SqlParameter("@SubjectTypeID", SubjectTypeID));
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
        DataTable dt = new DataTable("LibBookSubject");
        DataView dv = new DataView();
        List<LibBookSubject> myLibBookSubjects = new List<LibBookSubject>();
        try
        {
            myLibBookSubjects = GetLibBookSubject(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("BookID", Type.GetType("int"));
            dt.Columns.Add(col0);
            DataColumn col1 = new DataColumn("SubjectTypeID", Type.GetType("int"));
            dt.Columns.Add(col1);
            dt.Constraints.Add(new UniqueConstraint(col0));
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibBookSubjects.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibBookSubjects[i].BookID;
                dr[2] = myLibBookSubjects[i].SubjectTypeID;
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
            myLibBookSubjects.Clear();
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
public class LibBookSubjectCls : LibBookSubjectDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibBookSubject;
    private DataSet m_dsLibBookSubject;
    public DataRow LibBookSubjectDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibBookSubject
    {
        get { return m_dsLibBookSubject; }
        set { m_dsLibBookSubject = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibBookSubjectCls()
    {
        try
        {
            dsLibBookSubject = new DataSet();

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
    public virtual SqlDataAdapter GetLibBookSubjectDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibBookSubject = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibBookSubject);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookSubject.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookSubject;
    }
    public virtual SqlDataAdapter GetLibBookSubjectDataAdapter(SqlConnection con)
    {
        try
        {
            daLibBookSubject = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookSubject.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibBookSubject;
            cmdLibBookSubject = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@BookID", SqlDbType.Int, 4, "BookID" );
            //'cmdRolePermission.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, "SubjectTypeID" );
            daLibBookSubject.SelectCommand = cmdLibBookSubject;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibBookSubject = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibBookSubject.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookSubject.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));


            Parmeter = cmdLibBookSubject.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter = cmdLibBookSubject.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibBookSubject.UpdateCommand = cmdLibBookSubject;
            daLibBookSubject.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibBookSubject = new SqlCommand(GetInsertCommand(), con);
            cmdLibBookSubject.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookSubject.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibBookSubject.InsertCommand = cmdLibBookSubject;
            daLibBookSubject.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibBookSubject = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibBookSubject.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter = cmdLibBookSubject.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibBookSubject.DeleteCommand = cmdLibBookSubject;
            daLibBookSubject.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibBookSubject.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookSubject;
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
                    dr = dsLibBookSubject.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    dr[LibraryMOD.GetFieldName(SubjectTypeIDFN)] = SubjectTypeID;
                    dsLibBookSubject.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibBookSubject.Tables[TableName].Select(LibraryMOD.GetFieldName(BookIDFN) + "=" + BookID + " AND " + LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=" + SubjectTypeID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    drAry[0][LibraryMOD.GetFieldName(SubjectTypeIDFN)] = SubjectTypeID;
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
    public int CommitLibBookSubject()
    {
        //CommitLibBookSubject= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibBookSubject.Update(dsLibBookSubject, TableName);
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
            FindInMultiPKey(BookID, SubjectTypeID);
            if ((LibBookSubjectDataRow != null))
            {
                LibBookSubjectDataRow.Delete();
                CommitLibBookSubject();
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
            if (LibBookSubjectDataRow[LibraryMOD.GetFieldName(BookIDFN)] == System.DBNull.Value)
            {
                BookID = 0;
            }
            else
            {
                BookID = (int)LibBookSubjectDataRow[LibraryMOD.GetFieldName(BookIDFN)];
            }
            if (LibBookSubjectDataRow[LibraryMOD.GetFieldName(SubjectTypeIDFN)] == System.DBNull.Value)
            {
                SubjectTypeID = 0;
            }
            else
            {
                SubjectTypeID = (int)LibBookSubjectDataRow[LibraryMOD.GetFieldName(SubjectTypeIDFN)];
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
    public int FindInMultiPKey(int PKBookID, int PKSubjectTypeID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKBookID;
            findTheseVals[1] = PKSubjectTypeID;
            LibBookSubjectDataRow = dsLibBookSubject.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibBookSubjectDataRow != null))
            {
                lngCurRow = dsLibBookSubject.Tables[TableName].Rows.IndexOf(LibBookSubjectDataRow);
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
            lngCurRow = dsLibBookSubject.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibBookSubject.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibBookSubject.Tables[TableName].Rows.Count > 0)
            {
                LibBookSubjectDataRow = dsLibBookSubject.Tables[TableName].Rows[lngCurRow];
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
            daLibBookSubject.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookSubject.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibBookSubject.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookSubject.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
