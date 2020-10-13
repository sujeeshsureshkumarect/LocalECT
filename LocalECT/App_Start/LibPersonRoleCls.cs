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
public class LibPersonRole
{
    //Creation Date: 07/02/2011 09:43:08 AM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_PersonRoleID;
    private string m_PersonRoleDesc;
    private int m_Duration;
    private int m_BookCount;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int PersonRoleID
    {
        get { return m_PersonRoleID; }
        set { m_PersonRoleID = value; }
    }
    public string PersonRoleDesc
    {
        get { return m_PersonRoleDesc; }
        set { m_PersonRoleDesc = value; }
    }
    public int Duration
    {
        get { return m_Duration; }
        set { m_Duration = value; }
    }
    public int BookCount
    {
        get { return m_BookCount; }
        set { m_BookCount = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibPersonRole()
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
public class LibPersonRoleDAL : LibPersonRole
{
    #region "Decleration"
    private string m_TableName;
    private string m_PersonRoleIDFN;
    private string m_PersonRoleDescFN;
    private string m_DurationFN;
    private string m_BookCountFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string PersonRoleIDFN
    {
        get { return m_PersonRoleIDFN; }
        set { m_PersonRoleIDFN = value; }
    }
    public string PersonRoleDescFN
    {
        get { return m_PersonRoleDescFN; }
        set { m_PersonRoleDescFN = value; }
    }
    public string DurationFN
    {
        get { return m_DurationFN; }
        set { m_DurationFN = value; }
    }
    public string BookCountFN
    {
        get { return m_BookCountFN; }
        set { m_BookCountFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibPersonRoleDAL()
    {
        try
        {
            this.TableName = "LibPersonRole";
            this.PersonRoleIDFN = m_TableName + ".PersonRoleID";
            this.PersonRoleDescFN = m_TableName + ".PersonRoleDesc";
            this.DurationFN = m_TableName + ".Duration";
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
            sSQL += PersonRoleIDFN;
            sSQL += " , " + PersonRoleDescFN;
            sSQL += " , " + DurationFN;
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
            sSQL += PersonRoleIDFN;
            sSQL += " , " + PersonRoleDescFN;
            sSQL += " , " + DurationFN;
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
            sSQL += PersonRoleIDFN;
            sSQL += " , " + PersonRoleDescFN;
            sSQL += " , " + DurationFN;
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
            sSQL += LibraryMOD.GetFieldName(PersonRoleIDFN) + "=@PersonRoleID";
            sSQL += " , " + LibraryMOD.GetFieldName(PersonRoleDescFN) + "=@PersonRoleDesc";
            sSQL += " , " + LibraryMOD.GetFieldName(DurationFN) + "=@Duration";
            sSQL += " , " + LibraryMOD.GetFieldName(BookCountFN) + "=@BookCount";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(PersonRoleIDFN) + "=@PersonRoleID";
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
            sSQL += LibraryMOD.GetFieldName(PersonRoleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PersonRoleDescFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DurationFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookCountFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @PersonRoleID";
            sSQL += " ,@PersonRoleDesc";
            sSQL += " ,@Duration";
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
            sSQL += LibraryMOD.GetFieldName(PersonRoleIDFN) + "=@PersonRoleID";
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
    public List<LibPersonRole> GetLibPersonRole(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibPersonRole
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
        List<LibPersonRole> results = new List<LibPersonRole>();
        try
        {
            //Default Value
            LibPersonRole myLibPersonRole = new LibPersonRole();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibPersonRole.PersonRoleID = 0;
                results.Add(myLibPersonRole);
            }
            while (reader.Read())
            {
                myLibPersonRole = new LibPersonRole();
                if (reader[LibraryMOD.GetFieldName(PersonRoleIDFN)].Equals(DBNull.Value))
                {
                    myLibPersonRole.PersonRoleID = 0;
                }
                else
                {
                    myLibPersonRole.PersonRoleID = int.Parse(reader[LibraryMOD.GetFieldName(PersonRoleIDFN)].ToString());
                }
                myLibPersonRole.PersonRoleDesc = reader[LibraryMOD.GetFieldName(PersonRoleDescFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(DurationFN)].Equals(DBNull.Value))
                {
                    myLibPersonRole.Duration = 0;
                }
                else
                {
                    myLibPersonRole.Duration = int.Parse(reader[LibraryMOD.GetFieldName(DurationFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookCountFN)].Equals(DBNull.Value))
                {
                    myLibPersonRole.BookCount = 0;
                }
                else
                {
                    myLibPersonRole.BookCount = int.Parse(reader[LibraryMOD.GetFieldName(BookCountFN)].ToString());
                }
                results.Add(myLibPersonRole);
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
    public List<LibPersonRole> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibPersonRole> results = new List<LibPersonRole>();
        try
        {
            //Default Value
            LibPersonRole myLibPersonRole = new LibPersonRole();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibPersonRole.PersonRoleID = -1;
                myLibPersonRole.PersonRoleDesc = "Select LibPersonRole";
                results.Add(myLibPersonRole);
            }
            while (reader.Read())
            {
                myLibPersonRole = new LibPersonRole();
                if (reader[LibraryMOD.GetFieldName(PersonRoleIDFN)].Equals(DBNull.Value))
                {
                    myLibPersonRole.PersonRoleID = 0;
                }
                else
                {
                    myLibPersonRole.PersonRoleID = int.Parse(reader[LibraryMOD.GetFieldName(PersonRoleIDFN)].ToString());
                }
                myLibPersonRole.PersonRoleDesc = reader[LibraryMOD.GetFieldName(PersonRoleDescFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(DurationFN)].Equals(DBNull.Value))
                {
                    myLibPersonRole.Duration = 0;
                }
                else
                {
                    myLibPersonRole.Duration = int.Parse(reader[LibraryMOD.GetFieldName(DurationFN)].ToString());
                }
                results.Add(myLibPersonRole);
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
    public int UpdateLibPersonRole(InitializeModule.EnumCampus Campus, int iMode, int PersonRoleID, string PersonRoleDesc, int Duration, int BookCount)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibPersonRole theLibPersonRole = new LibPersonRole();
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
            Cmd.Parameters.Add(new SqlParameter("@PersonRoleID", PersonRoleID));
            Cmd.Parameters.Add(new SqlParameter("@PersonRoleDesc", PersonRoleDesc));
            Cmd.Parameters.Add(new SqlParameter("@Duration", Duration));
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
    public int DeleteLibPersonRole(InitializeModule.EnumCampus Campus, string PersonRoleID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@PersonRoleID", PersonRoleID));
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
        DataTable dt = new DataTable("LibPersonRole");
        DataView dv = new DataView();
        List<LibPersonRole> myLibPersonRoles = new List<LibPersonRole>();
        try
        {
            myLibPersonRoles = GetLibPersonRole(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("PersonRoleID", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myLibPersonRoles.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibPersonRoles[i].PersonRoleID;
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
            myLibPersonRoles.Clear();
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
            sSQL += PersonRoleIDFN;
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
public class LibPersonRoleCls : LibPersonRoleDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibPersonRole;
    private DataSet m_dsLibPersonRole;
    public DataRow LibPersonRoleDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibPersonRole
    {
        get { return m_dsLibPersonRole; }
        set { m_dsLibPersonRole = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibPersonRoleCls()
    {
        try
        {
            dsLibPersonRole = new DataSet();

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
    public virtual SqlDataAdapter GetLibPersonRoleDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibPersonRole = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibPersonRole);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibPersonRole.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibPersonRole;
    }
    public virtual SqlDataAdapter GetLibPersonRoleDataAdapter(SqlConnection con)
    {
        try
        {
            daLibPersonRole = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibPersonRole.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibPersonRole;
            cmdLibPersonRole = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@PersonRoleID", SqlDbType.Int, 4, "PersonRoleID" );
            daLibPersonRole.SelectCommand = cmdLibPersonRole;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibPersonRole = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibPersonRole.Parameters.Add("@PersonRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PersonRoleIDFN));
            cmdLibPersonRole.Parameters.Add("@PersonRoleDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PersonRoleDescFN));
            cmdLibPersonRole.Parameters.Add("@Duration", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DurationFN));
            cmdLibPersonRole.Parameters.Add("@BookCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookCountFN));


            Parmeter = cmdLibPersonRole.Parameters.Add("@PersonRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PersonRoleIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibPersonRole.UpdateCommand = cmdLibPersonRole;
            daLibPersonRole.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibPersonRole = new SqlCommand(GetInsertCommand(), con);
            cmdLibPersonRole.Parameters.Add("@PersonRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PersonRoleIDFN));
            cmdLibPersonRole.Parameters.Add("@PersonRoleDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PersonRoleDescFN));
            cmdLibPersonRole.Parameters.Add("@Duration", SqlDbType.Int, 4, LibraryMOD.GetFieldName(DurationFN));
            cmdLibPersonRole.Parameters.Add("@BookCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookCountFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibPersonRole.InsertCommand = cmdLibPersonRole;
            daLibPersonRole.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibPersonRole = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibPersonRole.Parameters.Add("@PersonRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PersonRoleIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibPersonRole.DeleteCommand = cmdLibPersonRole;
            daLibPersonRole.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibPersonRole.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibPersonRole;
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
                    dr = dsLibPersonRole.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(PersonRoleIDFN)] = PersonRoleID;
                    dr[LibraryMOD.GetFieldName(PersonRoleDescFN)] = PersonRoleDesc;
                    dr[LibraryMOD.GetFieldName(DurationFN)] = Duration;
                    dr[LibraryMOD.GetFieldName(BookCountFN)] = BookCount;
                    dsLibPersonRole.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibPersonRole.Tables[TableName].Select(LibraryMOD.GetFieldName(PersonRoleIDFN) + "=" + PersonRoleID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(PersonRoleIDFN)] = PersonRoleID;
                    drAry[0][LibraryMOD.GetFieldName(PersonRoleDescFN)] = PersonRoleDesc;
                    drAry[0][LibraryMOD.GetFieldName(DurationFN)] = Duration;
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
    public int CommitLibPersonRole()
    {
        //CommitLibPersonRole= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibPersonRole.Update(dsLibPersonRole, TableName);
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
            FindInMultiPKey(PersonRoleID);
            if ((LibPersonRoleDataRow != null))
            {
                LibPersonRoleDataRow.Delete();
                CommitLibPersonRole();
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
            if (LibPersonRoleDataRow[LibraryMOD.GetFieldName(PersonRoleIDFN)] == System.DBNull.Value)
            {
                PersonRoleID = 0;
            }
            else
            {
                PersonRoleID = (int)LibPersonRoleDataRow[LibraryMOD.GetFieldName(PersonRoleIDFN)];
            }
            if (LibPersonRoleDataRow[LibraryMOD.GetFieldName(PersonRoleDescFN)] == System.DBNull.Value)
            {
                PersonRoleDesc = "";
            }
            else
            {
                PersonRoleDesc = (string)LibPersonRoleDataRow[LibraryMOD.GetFieldName(PersonRoleDescFN)];
            }
            if (LibPersonRoleDataRow[LibraryMOD.GetFieldName(DurationFN)] == System.DBNull.Value)
            {
                Duration = 0;
            }
            else
            {
                Duration = (int)LibPersonRoleDataRow[LibraryMOD.GetFieldName(DurationFN)];
            }
            if (LibPersonRoleDataRow[LibraryMOD.GetFieldName(BookCountFN)] == System.DBNull.Value)
            {
                BookCount = 0;
            }
            else
            {
                BookCount = (int)LibPersonRoleDataRow[LibraryMOD.GetFieldName(BookCountFN)];
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
    public int FindInMultiPKey(int PKPersonRoleID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKPersonRoleID;
            LibPersonRoleDataRow = dsLibPersonRole.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibPersonRoleDataRow != null))
            {
                lngCurRow = dsLibPersonRole.Tables[TableName].Rows.IndexOf(LibPersonRoleDataRow);
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
            lngCurRow = dsLibPersonRole.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibPersonRole.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibPersonRole.Tables[TableName].Rows.Count > 0)
            {
                LibPersonRoleDataRow = dsLibPersonRole.Tables[TableName].Rows[lngCurRow];
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
            daLibPersonRole.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibPersonRole.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibPersonRole.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibPersonRole.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
