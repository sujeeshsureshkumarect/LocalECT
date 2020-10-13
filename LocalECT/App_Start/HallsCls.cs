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
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Halls
{
    //Creation Date: 02/03/2010 09:50:51 ص
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_IDHall;
    private string m_strHall;
    private string m_strBuilding;
    private int m_intMaxSeats;
    private int m_intFloor;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int IDHall
    {
        get { return m_IDHall; }
        set { m_IDHall = value; }
    }
    public string strHall
    {
        get { return m_strHall; }
        set { m_strHall = value; }
    }
    public string strBuilding
    {
        get { return m_strBuilding; }
        set { m_strBuilding = value; }
    }
    public int intMaxSeats
    {
        get { return m_intMaxSeats; }
        set { m_intMaxSeats = value; }
    }
    public int intFloor
    {
        get { return m_intFloor; }
        set { m_intFloor = value; }
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
    public Halls()
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
public class HallsDAL : Halls
{
    #region "Decleration"
    private string m_TableName;
    private string m_IDHallFN;
    private string m_strHallFN;
    private string m_strBuildingFN;
    private string m_intMaxSeatsFN;
    private string m_intFloorFN;
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
    public string IDHallFN
    {
        get { return m_IDHallFN; }
        set { m_IDHallFN = value; }
    }
    public string strHallFN
    {
        get { return m_strHallFN; }
        set { m_strHallFN = value; }
    }
    public string strBuildingFN
    {
        get { return m_strBuildingFN; }
        set { m_strBuildingFN = value; }
    }
    public string intMaxSeatsFN
    {
        get { return m_intMaxSeatsFN; }
        set { m_intMaxSeatsFN = value; }
    }
    public string intFloorFN
    {
        get { return m_intFloorFN; }
        set { m_intFloorFN = value; }
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
    public HallsDAL()
    {
        try
        {
            this.TableName = "Lkp_Halls";
            this.IDHallFN = m_TableName + ".IDHall";
            this.strHallFN = m_TableName + ".strHall";
            this.strBuildingFN = m_TableName + ".strBuilding";
            this.intMaxSeatsFN = m_TableName + ".intMaxSeats";
            this.intFloorFN = m_TableName + ".intFloor";
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
            sSQL += IDHallFN;
            sSQL += " , " + strHallFN;
            sSQL += " , " + strBuildingFN;
            sSQL += " , " + intMaxSeatsFN;
            sSQL += " , " + intFloorFN;
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
            sSQL += IDHallFN;
            sSQL += " , " + strHallFN;
            sSQL += " , " + strBuildingFN;
            sSQL += " , " + intMaxSeatsFN;
            sSQL += " , " + intFloorFN;
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
            sSQL += LibraryMOD.GetFieldName(IDHallFN) + "=@IDHall";
            sSQL += " , " + LibraryMOD.GetFieldName(strHallFN) + "=@strHall";
            sSQL += " , " + LibraryMOD.GetFieldName(strBuildingFN) + "=@strBuilding";
            sSQL += " , " + LibraryMOD.GetFieldName(intMaxSeatsFN) + "=@intMaxSeats";
            sSQL += " , " + LibraryMOD.GetFieldName(intFloorFN) + "=@intFloor";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(IDHallFN) + "=@IDHall";
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
            sSQL += LibraryMOD.GetFieldName(IDHallFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strHallFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strBuildingFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intMaxSeatsFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intFloorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @IDHall";
            sSQL += " ,@strHall";
            sSQL += " ,@strBuilding";
            sSQL += " ,@intMaxSeats";
            sSQL += " ,@intFloor";
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
            sSQL += LibraryMOD.GetFieldName(IDHallFN) + "=@IDHall";
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
    public List<Halls> GetHalls(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Halls
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
        List<Halls> results = new List<Halls>();
        try
        {
            //Default Value
            Halls myHalls = new Halls();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myHalls.IDHall = 0;
                myHalls.strHall = "Select Hall ...";
                results.Add(myHalls);
            }
            while (reader.Read())
            {
                myHalls = new Halls();
                if (reader[LibraryMOD.GetFieldName(IDHallFN)].Equals(DBNull.Value))
                {
                    myHalls.IDHall = 0;
                }
                else
                {
                    myHalls.IDHall = int.Parse(reader[LibraryMOD.GetFieldName(IDHallFN)].ToString());
                }
                myHalls.strHall = reader[LibraryMOD.GetFieldName(strHallFN)].ToString();
                myHalls.strBuilding = reader[LibraryMOD.GetFieldName(strBuildingFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(intMaxSeatsFN)].Equals(DBNull.Value))
                {
                    myHalls.intMaxSeats = 0;
                }
                else
                {
                    myHalls.intMaxSeats = int.Parse(reader[LibraryMOD.GetFieldName(intMaxSeatsFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(intFloorFN)].Equals(DBNull.Value))
                {
                    myHalls.intFloor = 0;
                }
                else
                {
                    myHalls.intFloor = int.Parse(reader[LibraryMOD.GetFieldName(intFloorFN)].ToString());
                }
                myHalls.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myHalls.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myHalls.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myHalls.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myHalls.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myHalls.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myHalls);
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
    public int UpdateHalls(InitializeModule.EnumCampus Campus, int iMode, int IDHall, string strHall, string strBuilding, int intMaxSeats, int intFloor, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Halls theHalls = new Halls();
            //'Updates the  table
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    sql = GetUpdateCommand();
                    break;
                case (int)InitializeModule.enumModes.NewMode:
                    sql = GetInsertCommand();
                    break;
            }
            SqlCommand Cmd = new SqlCommand(sql, Conn);
            Cmd.Parameters.Add(new SqlParameter("@IDHall", IDHall));
            Cmd.Parameters.Add(new SqlParameter("@strHall", strHall));
            Cmd.Parameters.Add(new SqlParameter("@strBuilding", strBuilding));
            Cmd.Parameters.Add(new SqlParameter("@intMaxSeats", intMaxSeats));
            Cmd.Parameters.Add(new SqlParameter("@intFloor", intFloor));
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
    public int DeleteHalls(InitializeModule.EnumCampus Campus, string IDHall)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@IDHall", IDHall));
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
        DataTable dt = new DataTable("Halls");
        DataView dv = new DataView();
        List<Halls> myHallss = new List<Halls>();
        try
        {
            myHallss = GetHalls(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("IDHall", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strHall", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strBuilding", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myHallss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myHallss[i].IDHall;
                dr[2] = myHallss[i].strHall;
                dr[3] = myHallss[i].strBuilding;
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
            myHallss.Clear();
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
            sSQL += IDHallFN;
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
public class HallsCls : HallsDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daHalls;
    private DataSet m_dsHalls;
    public DataRow HallsDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsHalls
    {
        get { return m_dsHalls; }
        set { m_dsHalls = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public HallsCls()
    {
        try
        {
            dsHalls = new DataSet();

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
    public virtual SqlDataAdapter GetHallsDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daHalls = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daHalls);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daHalls.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daHalls;
    }
    public virtual SqlDataAdapter GetHallsDataAdapter(SqlConnection con)
    {
        try
        {
            daHalls = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daHalls.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdHalls;
            cmdHalls = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@IDHall", SqlDbType.Int, 4, "IDHall" );
            daHalls.SelectCommand = cmdHalls;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdHalls = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdHalls.Parameters.Add("@IDHall", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDHallFN));
            cmdHalls.Parameters.Add("@strHall", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strHallFN));
            cmdHalls.Parameters.Add("@strBuilding", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBuildingFN));
            cmdHalls.Parameters.Add("@intMaxSeats", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intMaxSeatsFN));
            cmdHalls.Parameters.Add("@intFloor", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intFloorFN));
            cmdHalls.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdHalls.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdHalls.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdHalls.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdHalls.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdHalls.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdHalls.Parameters.Add("@IDHall", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDHallFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daHalls.UpdateCommand = cmdHalls;
            daHalls.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdHalls = new SqlCommand(GetInsertCommand(), con);
            cmdHalls.Parameters.Add("@IDHall", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDHallFN));
            cmdHalls.Parameters.Add("@strHall", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strHallFN));
            cmdHalls.Parameters.Add("@strBuilding", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBuildingFN));
            cmdHalls.Parameters.Add("@intMaxSeats", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intMaxSeatsFN));
            cmdHalls.Parameters.Add("@intFloor", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intFloorFN));
            cmdHalls.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdHalls.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdHalls.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdHalls.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdHalls.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdHalls.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daHalls.InsertCommand = cmdHalls;
            daHalls.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdHalls = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdHalls.Parameters.Add("@IDHall", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IDHallFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daHalls.DeleteCommand = cmdHalls;
            daHalls.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daHalls.UpdateBatchSize = InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daHalls;
    }
    //'-------SaveData  -----------------------------
    public int SaveData(int lFormMode)
    {
        //SaveData= InitializeModule.FAIL_RET;
        try
        {
            switch (lFormMode)
            {
                case (int)InitializeModule.enumModes.NewMode:
                    DataRow dr = default(DataRow);
                    dr = dsHalls.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(IDHallFN)] = IDHall;
                    dr[LibraryMOD.GetFieldName(strHallFN)] = strHall;
                    dr[LibraryMOD.GetFieldName(strBuildingFN)] = strBuilding;
                    dr[LibraryMOD.GetFieldName(intMaxSeatsFN)] = intMaxSeats;
                    dr[LibraryMOD.GetFieldName(intFloorFN)] = intFloor;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    //dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    //dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    //dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
                    dsHalls.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsHalls.Tables[TableName].Select(LibraryMOD.GetFieldName(IDHallFN) + "=" + IDHall);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(IDHallFN)] = IDHall;
                    drAry[0][LibraryMOD.GetFieldName(strHallFN)] = strHall;
                    drAry[0][LibraryMOD.GetFieldName(strBuildingFN)] = strBuilding;
                    drAry[0][LibraryMOD.GetFieldName(intMaxSeatsFN)] = intMaxSeats;
                    drAry[0][LibraryMOD.GetFieldName(intFloorFN)] = intFloor;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    //drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
        return InitializeModule.SUCCESS_RET;
    }
    //'-------Commit  -----------------------------
    public int CommitHalls()
    {
        //CommitHalls= InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daHalls.Update(dsHalls, TableName);
            //'Sent Update to database.
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------DeleteRow  -----------------------------
    public int DeleteRow()
    {
        //DeleteRow= InitializeModule.FAIL_RET;
        try
        {
            FindInMultiPKey(IDHall);
            if ((HallsDataRow != null))
            {
                HallsDataRow.Delete();
                CommitHalls();
                if (MoveNext() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    #endregion
    //'-------SynchronizeDataRowToClass  -----------------------------
    private int SynchronizeDataRowToClass()
    {
        try
        {
            if (HallsDataRow[LibraryMOD.GetFieldName(IDHallFN)] == System.DBNull.Value)
            {
                IDHall = 0;
            }
            else
            {
                IDHall = (int)HallsDataRow[LibraryMOD.GetFieldName(IDHallFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(strHallFN)] == System.DBNull.Value)
            {
                strHall = "";
            }
            else
            {
                strHall = (string)HallsDataRow[LibraryMOD.GetFieldName(strHallFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(strBuildingFN)] == System.DBNull.Value)
            {
                strBuilding = "";
            }
            else
            {
                strBuilding = (string)HallsDataRow[LibraryMOD.GetFieldName(strBuildingFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(intMaxSeatsFN)] == System.DBNull.Value)
            {
                intMaxSeats = 0;
            }
            else
            {
                intMaxSeats = (int)HallsDataRow[LibraryMOD.GetFieldName(intMaxSeatsFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(intFloorFN)] == System.DBNull.Value)
            {
                intFloor = 0;
            }
            else
            {
                intFloor = (int)HallsDataRow[LibraryMOD.GetFieldName(intFloorFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)HallsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)HallsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)HallsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)HallsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)HallsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)HallsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------FindInMultiPKey  -----------------------------
    public int FindInMultiPKey(int PKIDHall)
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKIDHall;
            HallsDataRow = dsHalls.Tables[TableName].Rows.Find(findTheseVals);
            if ((HallsDataRow != null))
            {
                lngCurRow = dsHalls.Tables[TableName].Rows.IndexOf(HallsDataRow);
                SynchronizeDataRowToClass();
                return InitializeModule.SUCCESS_RET;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.FAIL_RET;
    }
    #region "Navigation"
    //'-------MoveFirst  -----------------------------
    public int MoveFirst()
    {
        //MoveFirst= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = 0;
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------MovePrevious  -----------------------------
    public int MovePrevious()
    {
        //MovePrevious= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Max(lngCurRow - 1, 0);
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------MoveLast  -----------------------------
    public int MoveLast()
    {
        //MoveLast= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = dsHalls.Tables[TableName].Rows.Count - 1; //'Zero based index
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------MoveNext  -----------------------------
    public int MoveNext()
    {
        //MoveNext= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Min(lngCurRow + 1, dsHalls.Tables[TableName].Rows.Count - 1);
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------GoToCurrentRow  -----------------------------
    public int GoToCurrentRow()
    {
        //GoToCurrentRow= InitializeModule.FAIL_RET;
        try
        {
            if (lngCurRow >= 0 & dsHalls.Tables[TableName].Rows.Count > 0)
            {
                HallsDataRow = dsHalls.Tables[TableName].Rows[lngCurRow];
                SynchronizeDataRowToClass();
            }
            else return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    #endregion
    #region "Events"
    //'-------AddDAEventHandler  -----------------------------
    public int AddDAEventHandler()
    {
        // InitializeModule.FAIL_RET;
        try
        {
            daHalls.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daHalls.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------RemoveDAEventHandler  -----------------------------
    public int RemoveDAEventHandler()
    {
        // InitializeModule.FAIL_RET;
        try
        {
            daHalls.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daHalls.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
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
