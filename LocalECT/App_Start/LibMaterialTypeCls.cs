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
public class LibMaterialType
{
    //Creation Date: 09/12/2010 1:17:04 PM
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_MaterialTypeID;
    private string m_MaterialTypeDescEn;
    private string m_MaterialTypeDescAr;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int MaterialTypeID
    {
        get { return m_MaterialTypeID; }
        set { m_MaterialTypeID = value; }
    }
    public string MaterialTypeDescEn
    {
        get { return m_MaterialTypeDescEn; }
        set { m_MaterialTypeDescEn = value; }
    }
    public string MaterialTypeDescAr
    {
        get { return m_MaterialTypeDescAr; }
        set { m_MaterialTypeDescAr = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibMaterialType()
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
public class LibMaterialTypeDAL : LibMaterialType
{
    #region "Decleration"
    private string m_TableName;
    private string m_MaterialTypeIDFN;
    private string m_MaterialTypeDescEnFN;
    private string m_MaterialTypeDescArFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string MaterialTypeIDFN
    {
        get { return m_MaterialTypeIDFN; }
        set { m_MaterialTypeIDFN = value; }
    }
    public string MaterialTypeDescEnFN
    {
        get { return m_MaterialTypeDescEnFN; }
        set { m_MaterialTypeDescEnFN = value; }
    }
    public string MaterialTypeDescArFN
    {
        get { return m_MaterialTypeDescArFN; }
        set { m_MaterialTypeDescArFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibMaterialTypeDAL()
    {
        try
        {
            this.TableName = "LibMaterialType";
            this.MaterialTypeIDFN = m_TableName + ".MaterialTypeID";
            this.MaterialTypeDescEnFN = m_TableName + ".MaterialTypeDescEn";
            this.MaterialTypeDescArFN = m_TableName + ".MaterialTypeDescAr";
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
            sSQL += MaterialTypeIDFN;
            sSQL += " , " + MaterialTypeDescEnFN;
            sSQL += " , " + MaterialTypeDescArFN;
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
            sSQL += MaterialTypeIDFN;
            sSQL += " , " + MaterialTypeDescEnFN;
            sSQL += " , " + MaterialTypeDescArFN;
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
            sSQL += LibraryMOD.GetFieldName(MaterialTypeIDFN) + "=@MaterialTypeID";
            sSQL += " , " + LibraryMOD.GetFieldName(MaterialTypeDescEnFN) + "=@MaterialTypeDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(MaterialTypeDescArFN) + "=@MaterialTypeDescAr";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(MaterialTypeIDFN) + "=@MaterialTypeID";
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
            sSQL += LibraryMOD.GetFieldName(MaterialTypeIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MaterialTypeDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MaterialTypeDescArFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @MaterialTypeID";
            sSQL += " ,@MaterialTypeDescEn";
            sSQL += " ,@MaterialTypeDescAr";
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
            sSQL += LibraryMOD.GetFieldName(MaterialTypeIDFN) + "=@MaterialTypeID";
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
    public List<LibMaterialType> GetLibMaterialType(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibMaterialType
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
        List<LibMaterialType> results = new List<LibMaterialType>();
        try
        {
            //Default Value
            LibMaterialType myLibMaterialType = new LibMaterialType();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibMaterialType.MaterialTypeID = 0;
                myLibMaterialType.MaterialTypeDescEn = "Select LibMaterialType ...";
                results.Add(myLibMaterialType);
            }
            while (reader.Read())
            {
                myLibMaterialType = new LibMaterialType();
                if (reader[LibraryMOD.GetFieldName(MaterialTypeIDFN)].Equals(DBNull.Value))
                {
                    myLibMaterialType.MaterialTypeID = 0;
                }
                else
                {
                    myLibMaterialType.MaterialTypeID = int.Parse(reader[LibraryMOD.GetFieldName(MaterialTypeIDFN)].ToString());
                }
                myLibMaterialType.MaterialTypeDescEn = reader[LibraryMOD.GetFieldName(MaterialTypeDescEnFN)].ToString();
                myLibMaterialType.MaterialTypeDescAr = reader[LibraryMOD.GetFieldName(MaterialTypeDescArFN)].ToString();
                results.Add(myLibMaterialType);
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
    public int UpdateLibMaterialType(InitializeModule.EnumCampus Campus, int iMode, int MaterialTypeID, string MaterialTypeDescEn, string MaterialTypeDescAr)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibMaterialType theLibMaterialType = new LibMaterialType();
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
            Cmd.Parameters.Add(new SqlParameter("@MaterialTypeID", MaterialTypeID));
            Cmd.Parameters.Add(new SqlParameter("@MaterialTypeDescEn", MaterialTypeDescEn));
            Cmd.Parameters.Add(new SqlParameter("@MaterialTypeDescAr", MaterialTypeDescAr));
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
    public int DeleteLibMaterialType(InitializeModule.EnumCampus Campus, string MaterialTypeID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@MaterialTypeID", MaterialTypeID));
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
        DataTable dt = new DataTable("LibMaterialType");
        DataView dv = new DataView();
        List<LibMaterialType> myLibMaterialTypes = new List<LibMaterialType>();
        try
        {
            myLibMaterialTypes = GetLibMaterialType(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("MaterialTypeID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("MaterialTypeDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("MaterialTypeDescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLibMaterialTypes.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibMaterialTypes[i].MaterialTypeID;
                dr[2] = myLibMaterialTypes[i].MaterialTypeDescEn;
                dr[3] = myLibMaterialTypes[i].MaterialTypeDescAr;
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
            myLibMaterialTypes.Clear();
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
            sSQL += MaterialTypeIDFN;
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
public class LibMaterialTypeCls : LibMaterialTypeDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibMaterialType;
    private DataSet m_dsLibMaterialType;
    public DataRow LibMaterialTypeDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibMaterialType
    {
        get { return m_dsLibMaterialType; }
        set { m_dsLibMaterialType = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibMaterialTypeCls()
    {
        try
        {
            dsLibMaterialType = new DataSet();

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
    public virtual SqlDataAdapter GetLibMaterialTypeDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibMaterialType = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibMaterialType);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibMaterialType.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibMaterialType;
    }
    public virtual SqlDataAdapter GetLibMaterialTypeDataAdapter(SqlConnection con)
    {
        try
        {
            daLibMaterialType = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibMaterialType.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibMaterialType;
            cmdLibMaterialType = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, "MaterialTypeID" );
            daLibMaterialType.SelectCommand = cmdLibMaterialType;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibMaterialType = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibMaterialType.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaterialTypeIDFN));
            cmdLibMaterialType.Parameters.Add("@MaterialTypeDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(MaterialTypeDescEnFN));
            cmdLibMaterialType.Parameters.Add("@MaterialTypeDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(MaterialTypeDescArFN));


            Parmeter = cmdLibMaterialType.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaterialTypeIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibMaterialType.UpdateCommand = cmdLibMaterialType;
            daLibMaterialType.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibMaterialType = new SqlCommand(GetInsertCommand(), con);
            cmdLibMaterialType.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaterialTypeIDFN));
            cmdLibMaterialType.Parameters.Add("@MaterialTypeDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(MaterialTypeDescEnFN));
            cmdLibMaterialType.Parameters.Add("@MaterialTypeDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(MaterialTypeDescArFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibMaterialType.InsertCommand = cmdLibMaterialType;
            daLibMaterialType.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibMaterialType = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibMaterialType.Parameters.Add("@MaterialTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaterialTypeIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibMaterialType.DeleteCommand = cmdLibMaterialType;
            daLibMaterialType.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibMaterialType.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibMaterialType;
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
                    dr = dsLibMaterialType.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(MaterialTypeIDFN)] = MaterialTypeID;
                    dr[LibraryMOD.GetFieldName(MaterialTypeDescEnFN)] = MaterialTypeDescEn;
                    dr[LibraryMOD.GetFieldName(MaterialTypeDescArFN)] = MaterialTypeDescAr;
                    dsLibMaterialType.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibMaterialType.Tables[TableName].Select(LibraryMOD.GetFieldName(MaterialTypeIDFN) + "=" + MaterialTypeID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(MaterialTypeIDFN)] = MaterialTypeID;
                    drAry[0][LibraryMOD.GetFieldName(MaterialTypeDescEnFN)] = MaterialTypeDescEn;
                    drAry[0][LibraryMOD.GetFieldName(MaterialTypeDescArFN)] = MaterialTypeDescAr;
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
    public int CommitLibMaterialType()
    {
        //CommitLibMaterialType= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibMaterialType.Update(dsLibMaterialType, TableName);
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
            FindInMultiPKey(MaterialTypeID);
            if ((LibMaterialTypeDataRow != null))
            {
                LibMaterialTypeDataRow.Delete();
                CommitLibMaterialType();
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
            if (LibMaterialTypeDataRow[LibraryMOD.GetFieldName(MaterialTypeIDFN)] == System.DBNull.Value)
            {
                MaterialTypeID = 0;
            }
            else
            {
                MaterialTypeID = (int)LibMaterialTypeDataRow[LibraryMOD.GetFieldName(MaterialTypeIDFN)];
            }
            if (LibMaterialTypeDataRow[LibraryMOD.GetFieldName(MaterialTypeDescEnFN)] == System.DBNull.Value)
            {
                MaterialTypeDescEn = "";
            }
            else
            {
                MaterialTypeDescEn = (string)LibMaterialTypeDataRow[LibraryMOD.GetFieldName(MaterialTypeDescEnFN)];
            }
            if (LibMaterialTypeDataRow[LibraryMOD.GetFieldName(MaterialTypeDescArFN)] == System.DBNull.Value)
            {
                MaterialTypeDescAr = "";
            }
            else
            {
                MaterialTypeDescAr = (string)LibMaterialTypeDataRow[LibraryMOD.GetFieldName(MaterialTypeDescArFN)];
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
    public int FindInMultiPKey(int PKMaterialTypeID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKMaterialTypeID;
            LibMaterialTypeDataRow = dsLibMaterialType.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibMaterialTypeDataRow != null))
            {
                lngCurRow = dsLibMaterialType.Tables[TableName].Rows.IndexOf(LibMaterialTypeDataRow);
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
            lngCurRow = dsLibMaterialType.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibMaterialType.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibMaterialType.Tables[TableName].Rows.Count > 0)
            {
                LibMaterialTypeDataRow = dsLibMaterialType.Tables[TableName].Rows[lngCurRow];
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
            daLibMaterialType.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibMaterialType.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibMaterialType.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibMaterialType.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
