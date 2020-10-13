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
public class LibSubjectType
{
    //Creation Date: 09/12/2010 2:42:51 PM
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_SubjectTypeID;
    private string m_SubjectTypeDescEn;
    private string m_SubjectTypeDescAr;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int SubjectTypeID
    {
        get { return m_SubjectTypeID; }
        set { m_SubjectTypeID = value; }
    }
    public string SubjectTypeDescEn
    {
        get { return m_SubjectTypeDescEn; }
        set { m_SubjectTypeDescEn = value; }
    }
    public string SubjectTypeDescAr
    {
        get { return m_SubjectTypeDescAr; }
        set { m_SubjectTypeDescAr = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibSubjectType()
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
public class LibSubjectTypeDAL : LibSubjectType
{
    #region "Decleration"
    private string m_TableName;
    private string m_SubjectTypeIDFN;
    private string m_SubjectTypeDescEnFN;
    private string m_SubjectTypeDescArFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string SubjectTypeIDFN
    {
        get { return m_SubjectTypeIDFN; }
        set { m_SubjectTypeIDFN = value; }
    }
    public string SubjectTypeDescEnFN
    {
        get { return m_SubjectTypeDescEnFN; }
        set { m_SubjectTypeDescEnFN = value; }
    }
    public string SubjectTypeDescArFN
    {
        get { return m_SubjectTypeDescArFN; }
        set { m_SubjectTypeDescArFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibSubjectTypeDAL()
    {
        try
        {
            this.TableName = "LibSubjectType";
            this.SubjectTypeIDFN = m_TableName + ".SubjectTypeID";
            this.SubjectTypeDescEnFN = m_TableName + ".SubjectTypeDescEn";
            this.SubjectTypeDescArFN = m_TableName + ".SubjectTypeDescAr";
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
            sSQL += SubjectTypeIDFN;
            sSQL += " , " + SubjectTypeDescEnFN;
            sSQL += " , " + SubjectTypeDescArFN;
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
            sSQL += SubjectTypeIDFN;
            sSQL += " , " + SubjectTypeDescEnFN;
            sSQL += " , " + SubjectTypeDescArFN;
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
            sSQL += LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=@SubjectTypeID";
            sSQL += " , " + LibraryMOD.GetFieldName(SubjectTypeDescEnFN) + "=@SubjectTypeDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(SubjectTypeDescArFN) + "=@SubjectTypeDescAr";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=@SubjectTypeID";
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
            sSQL += LibraryMOD.GetFieldName(SubjectTypeIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SubjectTypeDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SubjectTypeDescArFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @SubjectTypeID";
            sSQL += " ,@SubjectTypeDescEn";
            sSQL += " ,@SubjectTypeDescAr";
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
            sSQL += LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=@SubjectTypeID";
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
    public List<LibSubjectType> GetLibSubjectType(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibSubjectType
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
        List<LibSubjectType> results = new List<LibSubjectType>();
        try
        {
            //Default Value
            LibSubjectType myLibSubjectType = new LibSubjectType();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibSubjectType.SubjectTypeID = 0;
                myLibSubjectType.SubjectTypeDescEn = "Select LibSubjectType ...";
                results.Add(myLibSubjectType);
            }
            while (reader.Read())
            {
                myLibSubjectType = new LibSubjectType();
                if (reader[LibraryMOD.GetFieldName(SubjectTypeIDFN)].Equals(DBNull.Value))
                {
                    myLibSubjectType.SubjectTypeID = 0;
                }
                else
                {
                    myLibSubjectType.SubjectTypeID = int.Parse(reader[LibraryMOD.GetFieldName(SubjectTypeIDFN)].ToString());
                }
                myLibSubjectType.SubjectTypeDescEn = reader[LibraryMOD.GetFieldName(SubjectTypeDescEnFN)].ToString();
                myLibSubjectType.SubjectTypeDescAr = reader[LibraryMOD.GetFieldName(SubjectTypeDescArFN)].ToString();
                results.Add(myLibSubjectType);
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
    public int UpdateLibSubjectType(InitializeModule.EnumCampus Campus, int iMode, int SubjectTypeID, string SubjectTypeDescEn, string SubjectTypeDescAr)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibSubjectType theLibSubjectType = new LibSubjectType();
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
            Cmd.Parameters.Add(new SqlParameter("@SubjectTypeID", SubjectTypeID));
            Cmd.Parameters.Add(new SqlParameter("@SubjectTypeDescEn", SubjectTypeDescEn));
            Cmd.Parameters.Add(new SqlParameter("@SubjectTypeDescAr", SubjectTypeDescAr));
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
    public int DeleteLibSubjectType(InitializeModule.EnumCampus Campus, string SubjectTypeID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
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
        DataTable dt = new DataTable("LibSubjectType");
        DataView dv = new DataView();
        List<LibSubjectType> myLibSubjectTypes = new List<LibSubjectType>();
        try
        {
            myLibSubjectTypes = GetLibSubjectType(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("SubjectTypeID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("SubjectTypeDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("SubjectTypeDescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibSubjectTypes.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibSubjectTypes[i].SubjectTypeID;
                dr[2] = myLibSubjectTypes[i].SubjectTypeDescEn;
                dr[3] = myLibSubjectTypes[i].SubjectTypeDescAr;
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
            myLibSubjectTypes.Clear();
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
            sSQL += SubjectTypeIDFN;
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
public class LibSubjectTypeCls : LibSubjectTypeDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibSubjectType;
    private DataSet m_dsLibSubjectType;
    public DataRow LibSubjectTypeDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibSubjectType
    {
        get { return m_dsLibSubjectType; }
        set { m_dsLibSubjectType = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibSubjectTypeCls()
    {
        try
        {
            dsLibSubjectType = new DataSet();

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
    public virtual SqlDataAdapter GetLibSubjectTypeDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibSubjectType = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibSubjectType);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibSubjectType.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibSubjectType;
    }
    public virtual SqlDataAdapter GetLibSubjectTypeDataAdapter(SqlConnection con)
    {
        try
        {
            daLibSubjectType = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibSubjectType.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibSubjectType;
            cmdLibSubjectType = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, "SubjectTypeID" );
            daLibSubjectType.SelectCommand = cmdLibSubjectType;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibSubjectType = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibSubjectType.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));
            cmdLibSubjectType.Parameters.Add("@SubjectTypeDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SubjectTypeDescEnFN));
            cmdLibSubjectType.Parameters.Add("@SubjectTypeDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SubjectTypeDescArFN));


            Parmeter = cmdLibSubjectType.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibSubjectType.UpdateCommand = cmdLibSubjectType;
            daLibSubjectType.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibSubjectType = new SqlCommand(GetInsertCommand(), con);
            cmdLibSubjectType.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));
            cmdLibSubjectType.Parameters.Add("@SubjectTypeDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SubjectTypeDescEnFN));
            cmdLibSubjectType.Parameters.Add("@SubjectTypeDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(SubjectTypeDescArFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibSubjectType.InsertCommand = cmdLibSubjectType;
            daLibSubjectType.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibSubjectType = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibSubjectType.Parameters.Add("@SubjectTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SubjectTypeIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibSubjectType.DeleteCommand = cmdLibSubjectType;
            daLibSubjectType.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibSubjectType.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibSubjectType;
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
                    dr = dsLibSubjectType.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(SubjectTypeIDFN)] = SubjectTypeID;
                    dr[LibraryMOD.GetFieldName(SubjectTypeDescEnFN)] = SubjectTypeDescEn;
                    dr[LibraryMOD.GetFieldName(SubjectTypeDescArFN)] = SubjectTypeDescAr;
                    dsLibSubjectType.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibSubjectType.Tables[TableName].Select(LibraryMOD.GetFieldName(SubjectTypeIDFN) + "=" + SubjectTypeID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(SubjectTypeIDFN)] = SubjectTypeID;
                    drAry[0][LibraryMOD.GetFieldName(SubjectTypeDescEnFN)] = SubjectTypeDescEn;
                    drAry[0][LibraryMOD.GetFieldName(SubjectTypeDescArFN)] = SubjectTypeDescAr;
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
    public int CommitLibSubjectType()
    {
        //CommitLibSubjectType= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibSubjectType.Update(dsLibSubjectType, TableName);
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
            FindInMultiPKey(SubjectTypeID);
            if ((LibSubjectTypeDataRow != null))
            {
                LibSubjectTypeDataRow.Delete();
                CommitLibSubjectType();
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
            if (LibSubjectTypeDataRow[LibraryMOD.GetFieldName(SubjectTypeIDFN)] == System.DBNull.Value)
            {
                SubjectTypeID = 0;
            }
            else
            {
                SubjectTypeID = (int)LibSubjectTypeDataRow[LibraryMOD.GetFieldName(SubjectTypeIDFN)];
            }
            if (LibSubjectTypeDataRow[LibraryMOD.GetFieldName(SubjectTypeDescEnFN)] == System.DBNull.Value)
            {
                SubjectTypeDescEn = "";
            }
            else
            {
                SubjectTypeDescEn = (string)LibSubjectTypeDataRow[LibraryMOD.GetFieldName(SubjectTypeDescEnFN)];
            }
            if (LibSubjectTypeDataRow[LibraryMOD.GetFieldName(SubjectTypeDescArFN)] == System.DBNull.Value)
            {
                SubjectTypeDescAr = "";
            }
            else
            {
                SubjectTypeDescAr = (string)LibSubjectTypeDataRow[LibraryMOD.GetFieldName(SubjectTypeDescArFN)];
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
    public int FindInMultiPKey(int PKSubjectTypeID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKSubjectTypeID;
            LibSubjectTypeDataRow = dsLibSubjectType.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibSubjectTypeDataRow != null))
            {
                lngCurRow = dsLibSubjectType.Tables[TableName].Rows.IndexOf(LibSubjectTypeDataRow);
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
            lngCurRow = dsLibSubjectType.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibSubjectType.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibSubjectType.Tables[TableName].Rows.Count > 0)
            {
                LibSubjectTypeDataRow = dsLibSubjectType.Tables[TableName].Rows[lngCurRow];
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
            daLibSubjectType.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibSubjectType.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibSubjectType.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibSubjectType.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
