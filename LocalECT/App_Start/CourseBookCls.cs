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

public class CourseBook
{
    //Creation Date: 04/03/2012 09:08:38 AM
    //Programmer Name : Hazem Galal
    //-----Decleration --------------
    #region "Decleration"
    private string m_StrCourse;
    private int m_BookId;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public string StrCourse
    {
        get { return m_StrCourse; }
        set { m_StrCourse = value; }
    }
    public int BookId
    {
        get { return m_BookId; }
        set { m_BookId = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public CourseBook()
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

public class CourseBookDAL : CourseBook
{
    #region "Decleration"
    private string m_TableName;
    private string m_StrCourseFN;
    private string m_BookIdFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string StrCourseFN
    {
        get { return m_StrCourseFN; }
        set { m_StrCourseFN = value; }
    }
    public string BookIdFN
    {
        get { return m_BookIdFN; }
        set { m_BookIdFN = value; }
    }
    #endregion
    //================End Properties ===================
    public CourseBookDAL()
    {
        try
        {
            this.TableName = "Sto_CourseBook";
            this.StrCourseFN = m_TableName + ".StrCourse";
            this.BookIdFN = m_TableName + ".BookId";
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
            sSQL += StrCourseFN;
            sSQL += " , " + BookIdFN;
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
            sSQL += StrCourseFN;
            sSQL += " , " + BookIdFN;
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
            sSQL += StrCourseFN;
            sSQL += " , " + BookIdFN;
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
            sSQL += LibraryMOD.GetFieldName(StrCourseFN) + "=@StrCourse";
            sSQL += " , " + LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(StrCourseFN) + "=@StrCourse";
            sSQL += " And " + LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
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
            sSQL += LibraryMOD.GetFieldName(StrCourseFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookIdFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @StrCourse";
            sSQL += " ,@BookId";
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
            sSQL += LibraryMOD.GetFieldName(StrCourseFN) + "=@StrCourse";
            sSQL += " And " + LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
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
    public List<CourseBook> GetCourseBook(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the CourseBook
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
        List<CourseBook> results = new List<CourseBook>();
        try
        {
            //Default Value
            CourseBook myCourseBook = new CourseBook();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCourseBook.BookId = 0;
                myCourseBook.StrCourse = "Select Course Book ...";
                results.Add(myCourseBook);
            }
            while (reader.Read())
            {
                myCourseBook = new CourseBook();
                myCourseBook.StrCourse = reader[LibraryMOD.GetFieldName(StrCourseFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(BookIdFN)].Equals(DBNull.Value))
                {
                    myCourseBook.BookId = 0;
                }
                else
                {
                    myCourseBook.BookId = int.Parse(reader[LibraryMOD.GetFieldName(BookIdFN)].ToString());
                }
                results.Add(myCourseBook);
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
    public List<CourseBook> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<CourseBook> results = new List<CourseBook>();
        try
        {
            //Default Value
            CourseBook myCourseBook = new CourseBook();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCourseBook.StrCourse = "Select CourseBook";
                myCourseBook.BookId = -1;
                results.Add(myCourseBook);
            }
            while (reader.Read())
            {
                myCourseBook = new CourseBook();
                myCourseBook.StrCourse = reader[LibraryMOD.GetFieldName(StrCourseFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(BookIdFN)].Equals(DBNull.Value))
                {
                    myCourseBook.BookId = 0;
                }
                else
                {
                    myCourseBook.BookId = int.Parse(reader[LibraryMOD.GetFieldName(BookIdFN)].ToString());
                }
                results.Add(myCourseBook);
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
    public int UpdateCourseBook(InitializeModule.EnumCampus Campus, int iMode, string StrCourse, int BookId)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            CourseBook theCourseBook = new CourseBook();
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
            Cmd.Parameters.Add(new SqlParameter("@StrCourse", StrCourse));
            Cmd.Parameters.Add(new SqlParameter("@BookId", BookId));
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
    public int DeleteCourseBook(InitializeModule.EnumCampus Campus, string StrCourse, string BookId)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@StrCourse", StrCourse));
            Cmd.Parameters.Add(new SqlParameter("@BookId", BookId));
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
        DataTable dt = new DataTable("CourseBook");
        DataView dv = new DataView();
        List<CourseBook> myCourseBooks = new List<CourseBook>();
        try
        {
            myCourseBooks = GetCourseBook(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("StrCourse", Type.GetType("nvarchar"));
            dt.Columns.Add(col0);
            DataColumn col1 = new DataColumn("BookId", Type.GetType("int"));
            dt.Columns.Add(col1);
            dt.Constraints.Add(new UniqueConstraint(col1));
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myCourseBooks.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myCourseBooks[i].StrCourse;
                dr[2] = myCourseBooks[i].BookId;
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
            myCourseBooks.Clear();
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
            sSQL += StrCourseFN;
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

public class CourseBookCls : CourseBookDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daCourseBook;
    private DataSet m_dsCourseBook;
    public DataRow CourseBookDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsCourseBook
    {
        get { return m_dsCourseBook; }
        set { m_dsCourseBook = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public CourseBookCls()
    {
        try
        {
            dsCourseBook = new DataSet();

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
    public virtual SqlDataAdapter GetCourseBookDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daCourseBook = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCourseBook);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daCourseBook.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCourseBook;
    }
    public virtual SqlDataAdapter GetCourseBookDataAdapter(SqlConnection con)
    {
        try
        {
            daCourseBook = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daCourseBook.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdCourseBook;
            cmdCourseBook = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@StrCourse", SqlDbType.Int, 4, "StrCourse" );
            //'cmdRolePermission.Parameters.Add("@BookId", SqlDbType.Int, 4, "BookId" );
            daCourseBook.SelectCommand = cmdCourseBook;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdCourseBook = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdCourseBook.Parameters.Add("@StrCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(StrCourseFN));
            cmdCourseBook.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));


            Parmeter = cmdCourseBook.Parameters.Add("@StrCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StrCourseFN));
            Parmeter = cmdCourseBook.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daCourseBook.UpdateCommand = cmdCourseBook;
            daCourseBook.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdCourseBook = new SqlCommand(GetInsertCommand(), con);
            cmdCourseBook.Parameters.Add("@StrCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(StrCourseFN));
            cmdCourseBook.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daCourseBook.InsertCommand = cmdCourseBook;
            daCourseBook.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdCourseBook = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdCourseBook.Parameters.Add("@StrCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StrCourseFN));
            Parmeter = cmdCourseBook.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daCourseBook.DeleteCommand = cmdCourseBook;
            daCourseBook.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daCourseBook.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCourseBook;
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
                    dr = dsCourseBook.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(StrCourseFN)] = StrCourse;
                    dr[LibraryMOD.GetFieldName(BookIdFN)] = BookId;
                    dsCourseBook.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsCourseBook.Tables[TableName].Select(LibraryMOD.GetFieldName(StrCourseFN) + "=" + StrCourse + " AND " + LibraryMOD.GetFieldName(BookIdFN) + "=" + BookId);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(StrCourseFN)] = StrCourse;
                    drAry[0][LibraryMOD.GetFieldName(BookIdFN)] = BookId;
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
    public int CommitCourseBook()
    {
        //CommitCourseBook= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daCourseBook.Update(dsCourseBook, TableName);
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
            FindInMultiPKey(StrCourse, BookId);
            if ((CourseBookDataRow != null))
            {
                CourseBookDataRow.Delete();
                CommitCourseBook();
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
            if (CourseBookDataRow[LibraryMOD.GetFieldName(StrCourseFN)] == System.DBNull.Value)
            {
                StrCourse = "";
            }
            else
            {
                StrCourse = (string)CourseBookDataRow[LibraryMOD.GetFieldName(StrCourseFN)];
            }
            if (CourseBookDataRow[LibraryMOD.GetFieldName(BookIdFN)] == System.DBNull.Value)
            {
                BookId = 0;
            }
            else
            {
                BookId = (int)CourseBookDataRow[LibraryMOD.GetFieldName(BookIdFN)];
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
    public int FindInMultiPKey(string PKStrCourse, int PKBookId)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKStrCourse;
            findTheseVals[1] = PKBookId;
            CourseBookDataRow = dsCourseBook.Tables[TableName].Rows.Find(findTheseVals);
            if ((CourseBookDataRow != null))
            {
                lngCurRow = dsCourseBook.Tables[TableName].Rows.IndexOf(CourseBookDataRow);
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
            lngCurRow = dsCourseBook.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsCourseBook.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsCourseBook.Tables[TableName].Rows.Count > 0)
            {
                CourseBookDataRow = dsCourseBook.Tables[TableName].Rows[lngCurRow];
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
            daCourseBook.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCourseBook.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daCourseBook.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCourseBook.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
