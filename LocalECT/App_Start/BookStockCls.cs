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

public class BookStock
{
    //Creation Date: 14/03/2012 12:39:57 PM
    //Programmer Name : Hazem Galal
    //-----Decleration --------------
    #region "Decleration"
    private int m_BookId;
    private int m_StockId;
    private int m_BookCount;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int BookId
    {
        get { return m_BookId; }
        set { m_BookId = value; }
    }
    public int StockId
    {
        get { return m_StockId; }
        set { m_StockId = value; }
    }
    public int BookCount
    {
        get { return m_BookCount; }
        set { m_BookCount = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public BookStock()
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

public class BookStockDAL : BookStock
{
    #region "Decleration"
    private string m_TableName;
    private string m_BookIdFN;
    private string m_StockIdFN;
    private string m_BookCountFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string BookIdFN
    {
        get { return m_BookIdFN; }
        set { m_BookIdFN = value; }
    }
    public string StockIdFN
    {
        get { return m_StockIdFN; }
        set { m_StockIdFN = value; }
    }
    public string BookCountFN
    {
        get { return m_BookCountFN; }
        set { m_BookCountFN = value; }
    }
    #endregion
    //================End Properties ===================
    public BookStockDAL()
    {
        try
        {
            this.TableName = "Sto_BookStock";
            this.BookIdFN = m_TableName + ".BookId";
            this.StockIdFN = m_TableName + ".StockId";
            this.BookCountFN = m_TableName + ".BookCount";
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
            sSQL += BookIdFN;
            sSQL += " , " + StockIdFN;
            sSQL += " , " + BookCountFN;
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
            sSQL += BookIdFN;
            sSQL += " , " + StockIdFN;
            sSQL += " , " + BookCountFN;
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
            sSQL += BookIdFN;
            sSQL += " , " + StockIdFN;
            sSQL += " , " + BookCountFN;
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
            sSQL += LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
            sSQL += " , " + LibraryMOD.GetFieldName(StockIdFN) + "=@StockId";
            sSQL += " , " + LibraryMOD.GetFieldName(BookCountFN) + "=@BookCount";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
            sSQL += " And " + LibraryMOD.GetFieldName(StockIdFN) + "=@StockId";
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
            sSQL += LibraryMOD.GetFieldName(BookIdFN);
            sSQL += " , " + LibraryMOD.GetFieldName(StockIdFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookCountFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @BookId";
            sSQL += " ,@StockId";
            sSQL += " ,@BookCount";
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
            sSQL += LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
            sSQL += " And " + LibraryMOD.GetFieldName(StockIdFN) + "=@StockId";
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
    public List<BookStock> GetBookStock(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the BookStock
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
        List<BookStock> results = new List<BookStock>();
        try
        {
            //Default Value
            BookStock myBookStock = new BookStock();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myBookStock.BookId = 0;
                myBookStock.StockId = 0;
                results.Add(myBookStock);
            }
            while (reader.Read())
            {
                myBookStock = new BookStock();
                if (reader[LibraryMOD.GetFieldName(BookIdFN)].Equals(DBNull.Value))
                {
                    myBookStock.BookId = 0;
                }
                else
                {
                    myBookStock.BookId = int.Parse(reader[LibraryMOD.GetFieldName(BookIdFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(StockIdFN)].Equals(DBNull.Value))
                {
                    myBookStock.StockId = 0;
                }
                else
                {
                    myBookStock.StockId = int.Parse(reader[LibraryMOD.GetFieldName(StockIdFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookCountFN)].Equals(DBNull.Value))
                {
                    myBookStock.BookCount = 0;
                }
                else
                {
                    myBookStock.BookCount = int.Parse(reader[LibraryMOD.GetFieldName(BookCountFN)].ToString());
                }
                results.Add(myBookStock);
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
    public List<BookStock> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<BookStock> results = new List<BookStock>();
        try
        {
            //Default Value
            BookStock myBookStock = new BookStock();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myBookStock.BookId = -1;
                myBookStock.StockId = -1;
                results.Add(myBookStock);
            }
            while (reader.Read())
            {
                myBookStock = new BookStock();
                if (reader[LibraryMOD.GetFieldName(BookIdFN)].Equals(DBNull.Value))
                {
                    myBookStock.BookId = 0;
                }
                else
                {
                    myBookStock.BookId = int.Parse(reader[LibraryMOD.GetFieldName(BookIdFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(StockIdFN)].Equals(DBNull.Value))
                {
                    myBookStock.StockId = 0;
                }
                else
                {
                    myBookStock.StockId = int.Parse(reader[LibraryMOD.GetFieldName(StockIdFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookCountFN)].Equals(DBNull.Value))
                {
                    myBookStock.BookCount = 0;
                }
                else
                {
                    myBookStock.BookCount = int.Parse(reader[LibraryMOD.GetFieldName(BookCountFN)].ToString());
                }
                results.Add(myBookStock);
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
    public int UpdateBookStock(InitializeModule.EnumCampus Campus, int iMode, int BookId, int StockId, int BookCount)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            BookStock theBookStock = new BookStock();
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
            Cmd.Parameters.Add(new SqlParameter("@BookId", BookId));
            Cmd.Parameters.Add(new SqlParameter("@StockId", StockId));
            Cmd.Parameters.Add(new SqlParameter("@BookCount", BookCount));
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
    public int DeleteBookStock(InitializeModule.EnumCampus Campus, string BookId, string StockId)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@BookId", BookId));
            Cmd.Parameters.Add(new SqlParameter("@StockId", StockId));
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
        DataTable dt = new DataTable("BookStock");
        DataView dv = new DataView();
        List<BookStock> myBookStocks = new List<BookStock>();
        try
        {
            myBookStocks = GetBookStock(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("BookId", Type.GetType("int"));
            dt.Columns.Add(col0);
            DataColumn col1 = new DataColumn("StockId", Type.GetType("int"));
            dt.Columns.Add(col1);
            dt.Constraints.Add(new UniqueConstraint(col0));
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myBookStocks.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myBookStocks[i].BookId;
                dr[2] = myBookStocks[i].StockId;
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
            myBookStocks.Clear();
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
            sSQL += BookIdFN;
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

public class BookStockCls : BookStockDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daBookStock;
    private DataSet m_dsBookStock;
    public DataRow BookStockDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsBookStock
    {
        get { return m_dsBookStock; }
        set { m_dsBookStock = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public BookStockCls()
    {
        try
        {
            dsBookStock = new DataSet();

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
    public virtual SqlDataAdapter GetBookStockDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daBookStock = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daBookStock);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daBookStock.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daBookStock;
    }
    public virtual SqlDataAdapter GetBookStockDataAdapter(SqlConnection con)
    {
        try
        {
            daBookStock = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daBookStock.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdBookStock;
            cmdBookStock = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@BookId", SqlDbType.Int, 4, "BookId" );
            //'cmdRolePermission.Parameters.Add("@StockId", SqlDbType.Int, 4, "StockId" );
            daBookStock.SelectCommand = cmdBookStock;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdBookStock = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdBookStock.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            cmdBookStock.Parameters.Add("@StockId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StockIdFN));
            cmdBookStock.Parameters.Add("@BookCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookCountFN));


            Parmeter = cmdBookStock.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            Parmeter = cmdBookStock.Parameters.Add("@StockId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StockIdFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daBookStock.UpdateCommand = cmdBookStock;
            daBookStock.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdBookStock = new SqlCommand(GetInsertCommand(), con);
            cmdBookStock.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            cmdBookStock.Parameters.Add("@StockId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StockIdFN));
            cmdBookStock.Parameters.Add("@BookCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookCountFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daBookStock.InsertCommand = cmdBookStock;
            daBookStock.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdBookStock = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdBookStock.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            Parmeter = cmdBookStock.Parameters.Add("@StockId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StockIdFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daBookStock.DeleteCommand = cmdBookStock;
            daBookStock.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daBookStock.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daBookStock;
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
                    dr = dsBookStock.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(BookIdFN)] = BookId;
                    dr[LibraryMOD.GetFieldName(StockIdFN)] = StockId;
                    dr[LibraryMOD.GetFieldName(BookCountFN)] = BookCount;
                    dsBookStock.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsBookStock.Tables[TableName].Select(LibraryMOD.GetFieldName(BookIdFN) + "=" + BookId + " AND " + LibraryMOD.GetFieldName(StockIdFN) + "=" + StockId);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(BookIdFN)] = BookId;
                    drAry[0][LibraryMOD.GetFieldName(StockIdFN)] = StockId;
                    drAry[0][LibraryMOD.GetFieldName(BookCountFN)] = BookCount;
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
    public int CommitBookStock()
    {
        //CommitBookStock= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daBookStock.Update(dsBookStock, TableName);
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
            FindInMultiPKey(BookId, StockId);
            if ((BookStockDataRow != null))
            {
                BookStockDataRow.Delete();
                CommitBookStock();
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
            if (BookStockDataRow[LibraryMOD.GetFieldName(BookIdFN)] == System.DBNull.Value)
            {
                BookId = 0;
            }
            else
            {
                BookId = (int)BookStockDataRow[LibraryMOD.GetFieldName(BookIdFN)];
            }
            if (BookStockDataRow[LibraryMOD.GetFieldName(StockIdFN)] == System.DBNull.Value)
            {
                StockId = 0;
            }
            else
            {
                StockId = (int)BookStockDataRow[LibraryMOD.GetFieldName(StockIdFN)];
            }
            if (BookStockDataRow[LibraryMOD.GetFieldName(BookCountFN)] == System.DBNull.Value)
            {
                BookCount = 0;
            }
            else
            {
                BookCount = (int)BookStockDataRow[LibraryMOD.GetFieldName(BookCountFN)];
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
    public int FindInMultiPKey(int PKBookId, int PKStockId)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKBookId;
            findTheseVals[1] = PKStockId;
            BookStockDataRow = dsBookStock.Tables[TableName].Rows.Find(findTheseVals);
            if ((BookStockDataRow != null))
            {
                lngCurRow = dsBookStock.Tables[TableName].Rows.IndexOf(BookStockDataRow);
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
            lngCurRow = dsBookStock.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsBookStock.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsBookStock.Tables[TableName].Rows.Count > 0)
            {
                BookStockDataRow = dsBookStock.Tables[TableName].Rows[lngCurRow];
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
            daBookStock.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daBookStock.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daBookStock.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daBookStock.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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