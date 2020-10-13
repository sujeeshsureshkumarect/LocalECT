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
public class LibSeries
{
    //Creation Date: 12/01/2011 4:53:12 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_SeriesID;
    private string m_SeriesDescEn;
    private string m_SeriesDescAr;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int SeriesID
    {
        get { return m_SeriesID; }
        set { m_SeriesID = value; }
    }
    public string SeriesDescEn
    {
        get { return m_SeriesDescEn; }
        set { m_SeriesDescEn = value; }
    }
    public string SeriesDescAr
    {
        get { return m_SeriesDescAr; }
        set { m_SeriesDescAr = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibSeries()
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
public class LibSeriesDAL : LibSeries
{
    #region "Decleration"
    private string m_TableName;
    private string m_SeriesIDFN;
    private string m_SeriesDescEnFN;
    private string m_SeriesDescArFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string SeriesIDFN
    {
        get { return m_SeriesIDFN; }
        set { m_SeriesIDFN = value; }
    }
    public string SeriesDescEnFN
    {
        get { return m_SeriesDescEnFN; }
        set { m_SeriesDescEnFN = value; }
    }
    public string SeriesDescArFN
    {
        get { return m_SeriesDescArFN; }
        set { m_SeriesDescArFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibSeriesDAL()
    {
        try
        {
            this.TableName = "LibSeries";
            this.SeriesIDFN = m_TableName + ".SeriesID";
            this.SeriesDescEnFN = m_TableName + ".SeriesDescEn";
            this.SeriesDescArFN = m_TableName + ".SeriesDescAr";
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
            sSQL += SeriesIDFN;
            sSQL += " , " + SeriesDescEnFN;
            sSQL += " , " + SeriesDescArFN;
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
            sSQL += SeriesIDFN;
            sSQL += " , " + SeriesDescEnFN;
            sSQL += " , " + SeriesDescArFN;
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
            sSQL += SeriesIDFN;
            sSQL += " , " + SeriesDescEnFN;
            sSQL += " , " + SeriesDescArFN;
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
            sSQL += LibraryMOD.GetFieldName(SeriesIDFN) + "=@SeriesID";
            sSQL += " , " + LibraryMOD.GetFieldName(SeriesDescEnFN) + "=@SeriesDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(SeriesDescArFN) + "=@SeriesDescAr";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(SeriesIDFN) + "=@SeriesID";
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
            sSQL += LibraryMOD.GetFieldName(SeriesIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SeriesDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SeriesDescArFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @SeriesID";
            sSQL += " ,@SeriesDescEn";
            sSQL += " ,@SeriesDescAr";
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
            sSQL += LibraryMOD.GetFieldName(SeriesIDFN) + "=@SeriesID";
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
    public List<LibSeries> GetLibSeries(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibSeries
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
        List<LibSeries> results = new List<LibSeries>();
        try
        {
            //Default Value
            LibSeries myLibSeries = new LibSeries();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibSeries.SeriesID = 0;
                results.Add(myLibSeries);
            }
            while (reader.Read())
            {
                myLibSeries = new LibSeries();
                if (reader[LibraryMOD.GetFieldName(SeriesIDFN)].Equals(DBNull.Value))
                {
                    myLibSeries.SeriesID = 0;
                }
                else
                {
                    myLibSeries.SeriesID = int.Parse(reader[LibraryMOD.GetFieldName(SeriesIDFN)].ToString());
                }
                myLibSeries.SeriesDescEn = reader[LibraryMOD.GetFieldName(SeriesDescEnFN)].ToString();
                myLibSeries.SeriesDescAr = reader[LibraryMOD.GetFieldName(SeriesDescArFN)].ToString();
                results.Add(myLibSeries);
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
    public List<LibSeries> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibSeries> results = new List<LibSeries>();
        try
        {
            //Default Value
            LibSeries myLibSeries = new LibSeries();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibSeries.SeriesID = -1;
                myLibSeries.SeriesDescEn = "Select LibSeries";
                results.Add(myLibSeries);
            }
            while (reader.Read())
            {
                myLibSeries = new LibSeries();
                if (reader[LibraryMOD.GetFieldName(SeriesIDFN)].Equals(DBNull.Value))
                {
                    myLibSeries.SeriesID = 0;
                }
                else
                {
                    myLibSeries.SeriesID = int.Parse(reader[LibraryMOD.GetFieldName(SeriesIDFN)].ToString());
                }
                myLibSeries.SeriesDescEn = reader[LibraryMOD.GetFieldName(SeriesDescEnFN)].ToString();
                myLibSeries.SeriesDescAr = reader[LibraryMOD.GetFieldName(SeriesDescArFN)].ToString();
                results.Add(myLibSeries);
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
    public int UpdateLibSeries(InitializeModule.EnumCampus Campus, int iMode, int SeriesID, string SeriesDescEn, string SeriesDescAr)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibSeries theLibSeries = new LibSeries();
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
            Cmd.Parameters.Add(new SqlParameter("@SeriesID", SeriesID));
            Cmd.Parameters.Add(new SqlParameter("@SeriesDescEn", SeriesDescEn));
            Cmd.Parameters.Add(new SqlParameter("@SeriesDescAr", SeriesDescAr));
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
    public int DeleteLibSeries(InitializeModule.EnumCampus Campus, string SeriesID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@SeriesID", SeriesID));
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
        DataTable dt = new DataTable("LibSeries");
        DataView dv = new DataView();
        List<LibSeries> myLibSeriess = new List<LibSeries>();
        try
        {
            myLibSeriess = GetLibSeries(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("SeriesID", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myLibSeriess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibSeriess[i].SeriesID;
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
            myLibSeriess.Clear();
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
            sSQL += SeriesIDFN;
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
public class LibSeriesCls : LibSeriesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibSeries;
    private DataSet m_dsLibSeries;
    public DataRow LibSeriesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibSeries
    {
        get { return m_dsLibSeries; }
        set { m_dsLibSeries = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibSeriesCls()
    {
        try
        {
            dsLibSeries = new DataSet();

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
    public virtual SqlDataAdapter GetLibSeriesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibSeries = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibSeries);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibSeries.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibSeries;
    }
    public virtual SqlDataAdapter GetLibSeriesDataAdapter(SqlConnection con)
    {
        try
        {
            daLibSeries = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibSeries.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibSeries;
            cmdLibSeries = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@SeriesID", SqlDbType.Int, 4, "SeriesID" );
            daLibSeries.SelectCommand = cmdLibSeries;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibSeries = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibSeries.Parameters.Add("@SeriesID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeriesIDFN));
            cmdLibSeries.Parameters.Add("@SeriesDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SeriesDescEnFN));
            cmdLibSeries.Parameters.Add("@SeriesDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SeriesDescArFN));


            Parmeter = cmdLibSeries.Parameters.Add("@SeriesID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeriesIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibSeries.UpdateCommand = cmdLibSeries;
            daLibSeries.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibSeries = new SqlCommand(GetInsertCommand(), con);
            cmdLibSeries.Parameters.Add("@SeriesID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeriesIDFN));
            cmdLibSeries.Parameters.Add("@SeriesDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SeriesDescEnFN));
            cmdLibSeries.Parameters.Add("@SeriesDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SeriesDescArFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibSeries.InsertCommand = cmdLibSeries;
            daLibSeries.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibSeries = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibSeries.Parameters.Add("@SeriesID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeriesIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibSeries.DeleteCommand = cmdLibSeries;
            daLibSeries.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibSeries.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibSeries;
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
                    dr = dsLibSeries.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(SeriesIDFN)] = SeriesID;
                    dr[LibraryMOD.GetFieldName(SeriesDescEnFN)] = SeriesDescEn;
                    dr[LibraryMOD.GetFieldName(SeriesDescArFN)] = SeriesDescAr;
                    dsLibSeries.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibSeries.Tables[TableName].Select(LibraryMOD.GetFieldName(SeriesIDFN) + "=" + SeriesID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(SeriesIDFN)] = SeriesID;
                    drAry[0][LibraryMOD.GetFieldName(SeriesDescEnFN)] = SeriesDescEn;
                    drAry[0][LibraryMOD.GetFieldName(SeriesDescArFN)] = SeriesDescAr;
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
    public int CommitLibSeries()
    {
        //CommitLibSeries= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibSeries.Update(dsLibSeries, TableName);
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
            FindInMultiPKey(SeriesID);
            if ((LibSeriesDataRow != null))
            {
                LibSeriesDataRow.Delete();
                CommitLibSeries();
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
            if (LibSeriesDataRow[LibraryMOD.GetFieldName(SeriesIDFN)] == System.DBNull.Value)
            {
                SeriesID = 0;
            }
            else
            {
                SeriesID = (int)LibSeriesDataRow[LibraryMOD.GetFieldName(SeriesIDFN)];
            }
            if (LibSeriesDataRow[LibraryMOD.GetFieldName(SeriesDescEnFN)] == System.DBNull.Value)
            {
                SeriesDescEn = "";
            }
            else
            {
                SeriesDescEn = (string)LibSeriesDataRow[LibraryMOD.GetFieldName(SeriesDescEnFN)];
            }
            if (LibSeriesDataRow[LibraryMOD.GetFieldName(SeriesDescArFN)] == System.DBNull.Value)
            {
                SeriesDescAr = "";
            }
            else
            {
                SeriesDescAr = (string)LibSeriesDataRow[LibraryMOD.GetFieldName(SeriesDescArFN)];
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
    public int FindInMultiPKey(int PKSeriesID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKSeriesID;
            LibSeriesDataRow = dsLibSeries.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibSeriesDataRow != null))
            {
                lngCurRow = dsLibSeries.Tables[TableName].Rows.IndexOf(LibSeriesDataRow);
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
            lngCurRow = dsLibSeries.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibSeries.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibSeries.Tables[TableName].Rows.Count > 0)
            {
                LibSeriesDataRow = dsLibSeries.Tables[TableName].Rows[lngCurRow];
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
            daLibSeries.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibSeries.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibSeries.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibSeries.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
