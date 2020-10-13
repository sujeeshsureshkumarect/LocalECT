using System;
using System.Data;
using System.Configuration;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Att_Status
{
    //Creation Date: 24/03/2010 10:31:01 ص
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_byteAttStatus;
    private string m_strAttDescEn;
    private string m_strAttDescAr;
    private double m_curFactor;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int byteAttStatus
    {
        get { return m_byteAttStatus; }
        set { m_byteAttStatus = value; }
    }
    public string strAttDescEn
    {
        get { return m_strAttDescEn; }
        set { m_strAttDescEn = value; }
    }
    public string strAttDescAr
    {
        get { return m_strAttDescAr; }
        set { m_strAttDescAr = value; }
    }
    public double curFactor
    {
        get { return m_curFactor; }
        set { m_curFactor = value; }
    }
    public string strUserCreate
    {
        get { return m_strUserCreate; }
        set { m_strUserCreate = value; }
    }
    public DateTime dateCreate
    {
        get { return m_dateCreate; }
        set { m_dateCreate = value; }
    }
    public string strUserSave
    {
        get { return m_strUserSave; }
        set { m_strUserSave = value; }
    }
    public DateTime dateLastSave
    {
        get { return m_dateLastSave; }
        set { m_dateLastSave = value; }
    }
    public string strMachine
    {
        get { return m_strMachine; }
        set { m_strMachine = value; }
    }
    public string strNUser
    {
        get { return m_strNUser; }
        set { m_strNUser = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public Att_Status()
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
public class Att_StatusDAL : Att_Status
{
    #region "Decleration"
    private string m_TableName;
    private string m_byteAttStatusFN;
    private string m_strAttDescEnFN;
    private string m_strAttDescArFN;
    private string m_curFactorFN;
    private string m_strUserCreateFN;
    private string m_dateCreateFN;
    private string m_strUserSaveFN;
    private string m_dateLastSaveFN;
    private string m_strMachineFN;
    private string m_strNUserFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string byteAttStatusFN
    {
        get { return m_byteAttStatusFN; }
        set { m_byteAttStatusFN = value; }
    }
    public string strAttDescEnFN
    {
        get { return m_strAttDescEnFN; }
        set { m_strAttDescEnFN = value; }
    }
    public string strAttDescArFN
    {
        get { return m_strAttDescArFN; }
        set { m_strAttDescArFN = value; }
    }
    public string curFactorFN
    {
        get { return m_curFactorFN; }
        set { m_curFactorFN = value; }
    }
    public string strUserCreateFN
    {
        get { return m_strUserCreateFN; }
        set { m_strUserCreateFN = value; }
    }
    public string dateCreateFN
    {
        get { return m_dateCreateFN; }
        set { m_dateCreateFN = value; }
    }
    public string strUserSaveFN
    {
        get { return m_strUserSaveFN; }
        set { m_strUserSaveFN = value; }
    }
    public string dateLastSaveFN
    {
        get { return m_dateLastSaveFN; }
        set { m_dateLastSaveFN = value; }
    }
    public string strMachineFN
    {
        get { return m_strMachineFN; }
        set { m_strMachineFN = value; }
    }
    public string strNUserFN
    {
        get { return m_strNUserFN; }
        set { m_strNUserFN = value; }
    }
    #endregion
    //================End Properties ===================
    public Att_StatusDAL()
    {
        try
        {
            this.TableName = "Lkp_Att_Status";
            this.byteAttStatusFN = m_TableName + ".byteAttStatus";
            this.strAttDescEnFN = m_TableName + ".strAttDescEn";
            this.strAttDescArFN = m_TableName + ".strAttDescAr";
            this.curFactorFN = m_TableName + ".curFactor";
            this.strUserCreateFN = m_TableName + ".strUserCreate";
            this.dateCreateFN = m_TableName + ".dateCreate";
            this.strUserSaveFN = m_TableName + ".strUserSave";
            this.dateLastSaveFN = m_TableName + ".dateLastSave";
            this.strMachineFN = m_TableName + ".strMachine";
            this.strNUserFN = m_TableName + ".strNUser";
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
            sSQL += byteAttStatusFN;
            sSQL += " , " + strAttDescEnFN;
            sSQL += " , " + strAttDescArFN;
            sSQL += " , " + curFactorFN;
            sSQL += " , " + strUserCreateFN;
            sSQL += " , " + dateCreateFN;
            sSQL += " , " + strUserSaveFN;
            sSQL += " , " + dateLastSaveFN;
            sSQL += " , " + strMachineFN;
            sSQL += " , " + strNUserFN;
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
            sSQL += byteAttStatusFN;
            sSQL += " , " + strAttDescEnFN;
            sSQL += " , " + strAttDescArFN;
            sSQL += " , " + curFactorFN;
            sSQL += " , " + strUserCreateFN;
            sSQL += " , " + dateCreateFN;
            sSQL += " , " + strUserSaveFN;
            sSQL += " , " + dateLastSaveFN;
            sSQL += " , " + strMachineFN;
            sSQL += " , " + strNUserFN;
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
            sSQL += LibraryMOD.GetFieldName(byteAttStatusFN) + "=@byteAttStatus";
            sSQL += " , " + LibraryMOD.GetFieldName(strAttDescEnFN) + "=@strAttDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(strAttDescArFN) + "=@strAttDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(curFactorFN) + "=@curFactor";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(byteAttStatusFN) + "=@byteAttStatus";
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
            sSQL += LibraryMOD.GetFieldName(byteAttStatusFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strAttDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strAttDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(curFactorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @byteAttStatus";
            sSQL += " ,@strAttDescEn";
            sSQL += " ,@strAttDescAr";
            sSQL += " ,@curFactor";
            sSQL += " ,@strUserCreate";
            sSQL += " ,@dateCreate";
            sSQL += " ,@strUserSave";
            sSQL += " ,@dateLastSave";
            sSQL += " ,@strMachine";
            sSQL += " ,@strNUser";
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
            sSQL += LibraryMOD.GetFieldName(byteAttStatusFN) + "=@byteAttStatus";
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
    public List<Att_Status> GetAtt_Status(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Att_Status
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
        List<Att_Status> results = new List<Att_Status>();
        try
        {
            //Default Value
            Att_Status myAtt_Status = new Att_Status();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myAtt_Status.byteAttStatus = 0;
                myAtt_Status.strAttDescEn = "Select Att_Status ...";
                results.Add(myAtt_Status);
            }
            while (reader.Read())
            {
                myAtt_Status = new Att_Status();
                if (reader[LibraryMOD.GetFieldName(byteAttStatusFN)].Equals(DBNull.Value))
                {
                    myAtt_Status.byteAttStatus = 0;
                }
                else
                {
                    myAtt_Status.byteAttStatus = int.Parse(reader[LibraryMOD.GetFieldName(byteAttStatusFN)].ToString());
                }
                myAtt_Status.strAttDescEn = reader[LibraryMOD.GetFieldName(strAttDescEnFN)].ToString();
                myAtt_Status.strAttDescAr = reader[LibraryMOD.GetFieldName(strAttDescArFN)].ToString();
                myAtt_Status.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myAtt_Status.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myAtt_Status.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myAtt_Status.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myAtt_Status.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myAtt_Status.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myAtt_Status);
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
    public List<Att_Status> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Att_Status> results = new List<Att_Status>();
        try
        {
            //Default Value
            Att_Status myAtt_Status = new Att_Status();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myAtt_Status.byteAttStatus = -1;
                myAtt_Status.strAttDescEn  = "Select Attendance Status ...";
                results.Add(myAtt_Status);
            }

            while (reader.Read())
            {
                myAtt_Status = new Att_Status();

                if (reader[LibraryMOD.GetFieldName(byteAttStatusFN)].Equals(DBNull.Value))
                {
                    myAtt_Status.byteAttStatus = 0;
                }
                else
                {
                    myAtt_Status.byteAttStatus = int.Parse(reader[LibraryMOD.GetFieldName(byteAttStatusFN)].ToString());
                }
                myAtt_Status.strAttDescEn  = reader[LibraryMOD.GetFieldName(strAttDescEnFN)].ToString();

                results.Add(myAtt_Status);
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
    public string GetListSQL(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += byteAttStatusFN ;
            sSQL += " , " + strAttDescEnFN ;
            sSQL += "  FROM " + TableName;
            sSQL += sWhere;
            sSQL += " Order By " + byteAttStatusFN;

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

    public int UpdateAtt_Status(InitializeModule.EnumCampus Campus, int iMode, int byteAttStatus, string strAttDescEn, string strAttDescAr, double curFactor, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Att_Status theAtt_Status = new Att_Status();
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
            Cmd.Parameters.Add(new SqlParameter("@byteAttStatus", byteAttStatus));
            Cmd.Parameters.Add(new SqlParameter("@strAttDescEn", strAttDescEn));
            Cmd.Parameters.Add(new SqlParameter("@strAttDescAr", strAttDescAr));
            Cmd.Parameters.Add(new SqlParameter("@curFactor", curFactor));
            Cmd.Parameters.Add(new SqlParameter("@strUserCreate", strUserCreate));
            Cmd.Parameters.Add(new SqlParameter("@dateCreate", dateCreate));
            Cmd.Parameters.Add(new SqlParameter("@strUserSave", strUserSave));
            Cmd.Parameters.Add(new SqlParameter("@dateLastSave", dateLastSave));
            Cmd.Parameters.Add(new SqlParameter("@strMachine", strMachine));
            Cmd.Parameters.Add(new SqlParameter("@strNUser", strNUser));
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

    public int DeleteAtt_Status(InitializeModule.EnumCampus Campus, string byteAttStatus)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@byteAttStatus", byteAttStatus));
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
        DataTable dt = new DataTable("Att_Status");
        DataView dv = new DataView();
        List<Att_Status> myAtt_Statuss = new List<Att_Status>();
        try
        {
            myAtt_Statuss = GetAtt_Status(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("byteAttStatus", Type.GetType("smallint"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strAttDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strAttDescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myAtt_Statuss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myAtt_Statuss[i].byteAttStatus;
                dr[2] = myAtt_Statuss[i].strAttDescEn;
                dr[3] = myAtt_Statuss[i].strAttDescAr;
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
            myAtt_Statuss.Clear();
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
            sSQL += byteAttStatusFN;
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
public class Att_StatusCls : Att_StatusDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daAtt_Status;
    private DataSet m_dsAtt_Status;
    public DataRow Att_StatusDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsAtt_Status
    {
        get { return m_dsAtt_Status; }
        set { m_dsAtt_Status = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Att_StatusCls()
    {
        try
        {
            dsAtt_Status = new DataSet();

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
    public virtual SqlDataAdapter GetAtt_StatusDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daAtt_Status = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daAtt_Status);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daAtt_Status.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daAtt_Status;
    }
    public virtual SqlDataAdapter GetAtt_StatusDataAdapter(SqlConnection con)
    {
        try
        {
            daAtt_Status = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daAtt_Status.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdAtt_Status;
            cmdAtt_Status = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@byteAttStatus", SqlDbType.Int, 4, "byteAttStatus" );
            daAtt_Status.SelectCommand = cmdAtt_Status;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdAtt_Status = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdAtt_Status.Parameters.Add("@byteAttStatus", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteAttStatusFN));
            cmdAtt_Status.Parameters.Add("@strAttDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strAttDescEnFN));
            cmdAtt_Status.Parameters.Add("@strAttDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strAttDescArFN));
            cmdAtt_Status.Parameters.Add("@curFactor", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curFactorFN));
            cmdAtt_Status.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdAtt_Status.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdAtt_Status.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdAtt_Status.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdAtt_Status.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdAtt_Status.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdAtt_Status.Parameters.Add("@byteAttStatus", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteAttStatusFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daAtt_Status.UpdateCommand = cmdAtt_Status;
            daAtt_Status.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdAtt_Status = new SqlCommand(GetInsertCommand(), con);
            cmdAtt_Status.Parameters.Add("@byteAttStatus", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteAttStatusFN));
            cmdAtt_Status.Parameters.Add("@strAttDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strAttDescEnFN));
            cmdAtt_Status.Parameters.Add("@strAttDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strAttDescArFN));
            cmdAtt_Status.Parameters.Add("@curFactor", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curFactorFN));
            cmdAtt_Status.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdAtt_Status.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdAtt_Status.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdAtt_Status.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdAtt_Status.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdAtt_Status.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daAtt_Status.InsertCommand = cmdAtt_Status;
            daAtt_Status.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdAtt_Status = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdAtt_Status.Parameters.Add("@byteAttStatus", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteAttStatusFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daAtt_Status.DeleteCommand = cmdAtt_Status;
            daAtt_Status.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daAtt_Status.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daAtt_Status;
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
                    dr = dsAtt_Status.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(byteAttStatusFN)] = byteAttStatus;
                    dr[LibraryMOD.GetFieldName(strAttDescEnFN)] = strAttDescEn;
                    dr[LibraryMOD.GetFieldName(strAttDescArFN)] = strAttDescAr;
                    dr[LibraryMOD.GetFieldName(curFactorFN)] = curFactor;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    //dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    //dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    //dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)]= ECTGlobalDll.InitializeModule.gNetUserName;
                    dsAtt_Status.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsAtt_Status.Tables[TableName].Select(LibraryMOD.GetFieldName(byteAttStatusFN) + "=" + byteAttStatus);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(byteAttStatusFN)] = byteAttStatus;
                    drAry[0][LibraryMOD.GetFieldName(strAttDescEnFN)] = strAttDescEn;
                    drAry[0][LibraryMOD.GetFieldName(strAttDescArFN)] = strAttDescAr;
                    drAry[0][LibraryMOD.GetFieldName(curFactorFN)] = curFactor;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    //drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
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
    public int CommitAtt_Status()
    {
        //CommitAtt_Status= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daAtt_Status.Update(dsAtt_Status, TableName);
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
            FindInMultiPKey(byteAttStatus);
            if ((Att_StatusDataRow != null))
            {
                Att_StatusDataRow.Delete();
                CommitAtt_Status();
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
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(byteAttStatusFN)] == System.DBNull.Value)
            {
                byteAttStatus = 0;
            }
            else
            {
                byteAttStatus = (int)Att_StatusDataRow[LibraryMOD.GetFieldName(byteAttStatusFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(strAttDescEnFN)] == System.DBNull.Value)
            {
                strAttDescEn = "";
            }
            else
            {
                strAttDescEn = (string)Att_StatusDataRow[LibraryMOD.GetFieldName(strAttDescEnFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(strAttDescArFN)] == System.DBNull.Value)
            {
                strAttDescAr = "";
            }
            else
            {
                strAttDescAr = (string)Att_StatusDataRow[LibraryMOD.GetFieldName(strAttDescArFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(curFactorFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)Att_StatusDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)Att_StatusDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)Att_StatusDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)Att_StatusDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)Att_StatusDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (Att_StatusDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)Att_StatusDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKbyteAttStatus)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKbyteAttStatus;
            Att_StatusDataRow = dsAtt_Status.Tables[TableName].Rows.Find(findTheseVals);
            if ((Att_StatusDataRow != null))
            {
                lngCurRow = dsAtt_Status.Tables[TableName].Rows.IndexOf(Att_StatusDataRow);
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
            lngCurRow = dsAtt_Status.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsAtt_Status.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsAtt_Status.Tables[TableName].Rows.Count > 0)
            {
                Att_StatusDataRow = dsAtt_Status.Tables[TableName].Rows[lngCurRow];
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
            daAtt_Status.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daAtt_Status.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daAtt_Status.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daAtt_Status.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
