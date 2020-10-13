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
public class EctNewHalls
{
    //Creation Date: 02/03/2010 09:49:31 ص
    //Programmer Name : Hazem Galal
    //-----Decleration --------------
    #region "Decleration"
    private string m_HallID;
    private int m_HallTypeID;
    private int m_BuildingID;
    private int m_MaxSeats;
    private int m_intFloor;
    private int m_MaleHallID;
    private int m_FemaleHallID;
    private string m_Notes;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public string HallID
    {
        get { return m_HallID; }
        set { m_HallID = value; }
    }
    public int HallTypeID
    {
        get { return m_HallTypeID; }
        set { m_HallTypeID = value; }
    }
    public int BuildingID
    {
        get { return m_BuildingID; }
        set { m_BuildingID = value; }
    }
    public int MaxSeats
    {
        get { return m_MaxSeats; }
        set { m_MaxSeats = value; }
    }
    public int intFloor
    {
        get { return m_intFloor; }
        set { m_intFloor = value; }
    }
    public int MaleHallID
    {
        get { return m_MaleHallID; }
        set { m_MaleHallID = value; }
    }
    public int FemaleHallID
    {
        get { return m_FemaleHallID; }
        set { m_FemaleHallID = value; }
    }
    public string Notes
    {
        get { return m_Notes; }
        set { m_Notes = value; }
    }
    public int CreationUserID
    {
        get { return m_CreationUserID; }
        set { m_CreationUserID = value; }
    }
    public DateTime CreationDate
    {
        get { return m_CreationDate; }
        set { m_CreationDate = value; }
    }
    public int LastUpdateUserID
    {
        get { return m_LastUpdateUserID; }
        set { m_LastUpdateUserID = value; }
    }
    public DateTime LastUpdateDate
    {
        get { return m_LastUpdateDate; }
        set { m_LastUpdateDate = value; }
    }
    public string PCName
    {
        get { return m_PCName; }
        set { m_PCName = value; }
    }
    public string NetUserName
    {
        get { return m_NetUserName; }
        set { m_NetUserName = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public EctNewHalls()
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
public class EctNewHallsDAL : EctNewHalls
{
    #region "Decleration"
    private string m_TableName;
    private string m_HallIDFN;
    private string m_HallTypeIDFN;
    private string m_BuildingIDFN;
    private string m_MaxSeatsFN;
    private string m_intFloorFN;
    private string m_MaleHallIDFN;
    private string m_FemaleHallIDFN;
    private string m_NotesFN;
    private string m_CreationUserIDFN;
    private string m_CreationDateFN;
    private string m_LastUpdateUserIDFN;
    private string m_LastUpdateDateFN;
    private string m_PCNameFN;
    private string m_NetUserNameFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string HallIDFN
    {
        get { return m_HallIDFN; }
        set { m_HallIDFN = value; }
    }
    public string HallTypeIDFN
    {
        get { return m_HallTypeIDFN; }
        set { m_HallTypeIDFN = value; }
    }
    public string BuildingIDFN
    {
        get { return m_BuildingIDFN; }
        set { m_BuildingIDFN = value; }
    }
    public string MaxSeatsFN
    {
        get { return m_MaxSeatsFN; }
        set { m_MaxSeatsFN = value; }
    }
    public string intFloorFN
    {
        get { return m_intFloorFN; }
        set { m_intFloorFN = value; }
    }
    public string MaleHallIDFN
    {
        get { return m_MaleHallIDFN; }
        set { m_MaleHallIDFN = value; }
    }
    public string FemaleHallIDFN
    {
        get { return m_FemaleHallIDFN; }
        set { m_FemaleHallIDFN = value; }
    }
    public string NotesFN
    {
        get { return m_NotesFN; }
        set { m_NotesFN = value; }
    }
    public string CreationUserIDFN
    {
        get { return m_CreationUserIDFN; }
        set { m_CreationUserIDFN = value; }
    }
    public string CreationDateFN
    {
        get { return m_CreationDateFN; }
        set { m_CreationDateFN = value; }
    }
    public string LastUpdateUserIDFN
    {
        get { return m_LastUpdateUserIDFN; }
        set { m_LastUpdateUserIDFN = value; }
    }
    public string LastUpdateDateFN
    {
        get { return m_LastUpdateDateFN; }
        set { m_LastUpdateDateFN = value; }
    }
    public string PCNameFN
    {
        get { return m_PCNameFN; }
        set { m_PCNameFN = value; }
    }
    public string NetUserNameFN
    {
        get { return m_NetUserNameFN; }
        set { m_NetUserNameFN = value; }
    }
    #endregion
    //================End Properties ===================
    public EctNewHallsDAL()
    {
        try
        {
            this.TableName = "Lkp_Halls";
            this.HallIDFN = m_TableName + ".HallID";
            this.HallTypeIDFN = m_TableName + ".HallTypeID";
            this.BuildingIDFN = m_TableName + ".BuildingID";
            this.MaxSeatsFN = m_TableName + ".MaxSeats";
            this.intFloorFN = m_TableName + ".intFloor";
            this.MaleHallIDFN = m_TableName + ".MaleHallID";
            this.FemaleHallIDFN = m_TableName + ".FemaleHallID";
            this.NotesFN = m_TableName + ".Notes";
            this.CreationUserIDFN = m_TableName + ".CreationUserID";
            this.CreationDateFN = m_TableName + ".CreationDate";
            this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
            this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
            this.PCNameFN = m_TableName + ".PCName";
            this.NetUserNameFN = m_TableName + ".NetUserName";
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
            sSQL += HallIDFN;
            sSQL += " , " + HallTypeIDFN;
            sSQL += " , " + BuildingIDFN;
            sSQL += " , " + MaxSeatsFN;
            sSQL += " , " + intFloorFN;
            sSQL += " , " + MaleHallIDFN;
            sSQL += " , " + FemaleHallIDFN;
            sSQL += " , " + NotesFN;
            sSQL += " , " + CreationUserIDFN;
            sSQL += " , " + CreationDateFN;
            sSQL += " , " + LastUpdateUserIDFN;
            sSQL += " , " + LastUpdateDateFN;
            sSQL += " , " + PCNameFN;
            sSQL += " , " + NetUserNameFN;
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
            sSQL += HallIDFN;
            sSQL += " , " + HallTypeIDFN;
            sSQL += " , " + BuildingIDFN;
            sSQL += " , " + MaxSeatsFN;
            sSQL += " , " + intFloorFN;
            sSQL += " , " + MaleHallIDFN;
            sSQL += " , " + FemaleHallIDFN;
            sSQL += " , " + NotesFN;
            sSQL += " , " + CreationUserIDFN;
            sSQL += " , " + CreationDateFN;
            sSQL += " , " + LastUpdateUserIDFN;
            sSQL += " , " + LastUpdateDateFN;
            sSQL += " , " + PCNameFN;
            sSQL += " , " + NetUserNameFN;
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
            sSQL += LibraryMOD.GetFieldName(HallIDFN) + "=@HallID";
            sSQL += " , " + LibraryMOD.GetFieldName(HallTypeIDFN) + "=@HallTypeID";
            sSQL += " , " + LibraryMOD.GetFieldName(BuildingIDFN) + "=@BuildingID";
            sSQL += " , " + LibraryMOD.GetFieldName(MaxSeatsFN) + "=@MaxSeats";
            sSQL += " , " + LibraryMOD.GetFieldName(intFloorFN) + "=@intFloor";
            sSQL += " , " + LibraryMOD.GetFieldName(MaleHallIDFN) + "=@MaleHallID";
            sSQL += " , " + LibraryMOD.GetFieldName(FemaleHallIDFN) + "=@FemaleHallID";
            sSQL += " , " + LibraryMOD.GetFieldName(NotesFN) + "=@Notes";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(HallIDFN) + "=@HallID";
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
            sSQL += LibraryMOD.GetFieldName(HallIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(HallTypeIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BuildingIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MaxSeatsFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intFloorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MaleHallIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(FemaleHallIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NotesFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @HallID";
            sSQL += " ,@HallTypeID";
            sSQL += " ,@BuildingID";
            sSQL += " ,@MaxSeats";
            sSQL += " ,@intFloor";
            sSQL += " ,@MaleHallID";
            sSQL += " ,@FemaleHallID";
            sSQL += " ,@Notes";
            sSQL += " ,@CreationUserID";
            sSQL += " ,@CreationDate";
            sSQL += " ,@LastUpdateUserID";
            sSQL += " ,@LastUpdateDate";
            sSQL += " ,@PCName";
            sSQL += " ,@NetUserName";
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
            sSQL += LibraryMOD.GetFieldName(HallIDFN) + "=@HallID";
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
    public List<EctNewHalls> GetHalls(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
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
        List<EctNewHalls> results = new List<EctNewHalls>();
        try
        {
            //Default Value
            EctNewHalls myHalls = new EctNewHalls();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myHalls.HallID = "";
                myHalls.HallTypeID = 0;
                results.Add(myHalls);
            }
            while (reader.Read())
            {
                myHalls = new EctNewHalls();
                myHalls.HallID = reader[LibraryMOD.GetFieldName(HallIDFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(HallTypeIDFN)].Equals(DBNull.Value))
                {
                    myHalls.HallTypeID = 0;
                }
                else
                {
                    myHalls.HallTypeID = int.Parse(reader[LibraryMOD.GetFieldName(HallTypeIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BuildingIDFN)].Equals(DBNull.Value))
                {
                    myHalls.BuildingID = 0;
                }
                else
                {
                    myHalls.BuildingID = int.Parse(reader[LibraryMOD.GetFieldName(BuildingIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(MaxSeatsFN)].Equals(DBNull.Value))
                {
                    myHalls.MaxSeats = 0;
                }
                else
                {
                    myHalls.MaxSeats = int.Parse(reader[LibraryMOD.GetFieldName(MaxSeatsFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(intFloorFN)].Equals(DBNull.Value))
                {
                    myHalls.intFloor = 0;
                }
                else
                {
                    myHalls.intFloor = int.Parse(reader[LibraryMOD.GetFieldName(intFloorFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(MaleHallIDFN)].Equals(DBNull.Value))
                {
                    myHalls.MaleHallID = 0;
                }
                else
                {
                    myHalls.MaleHallID = int.Parse(reader[LibraryMOD.GetFieldName(MaleHallIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(FemaleHallIDFN)].Equals(DBNull.Value))
                {
                    myHalls.FemaleHallID = 0;
                }
                else
                {
                    myHalls.FemaleHallID = int.Parse(reader[LibraryMOD.GetFieldName(FemaleHallIDFN)].ToString());
                }
                myHalls.Notes = reader[LibraryMOD.GetFieldName(NotesFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myHalls.CreationUserID = 0;
                }
                else
                {
                    myHalls.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myHalls.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myHalls.LastUpdateUserID = 0;
                }
                else
                {
                    myHalls.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myHalls.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myHalls.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myHalls.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
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
    public int UpdateHalls(InitializeModule.EnumCampus Campus, int iMode, string HallID, int HallTypeID, int BuildingID, int MaxSeats, int intFloor, int MaleHallID, int FemaleHallID, string Notes, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            EctNewHalls theHalls = new EctNewHalls();
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
            Cmd.Parameters.Add(new SqlParameter("@HallID", HallID));
            Cmd.Parameters.Add(new SqlParameter("@HallTypeID", HallTypeID));
            Cmd.Parameters.Add(new SqlParameter("@BuildingID", BuildingID));
            Cmd.Parameters.Add(new SqlParameter("@MaxSeats", MaxSeats));
            Cmd.Parameters.Add(new SqlParameter("@intFloor", intFloor));
            Cmd.Parameters.Add(new SqlParameter("@MaleHallID", MaleHallID));
            Cmd.Parameters.Add(new SqlParameter("@FemaleHallID", FemaleHallID));
            Cmd.Parameters.Add(new SqlParameter("@Notes", Notes));
            Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
            Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", LastUpdateDate));
            Cmd.Parameters.Add(new SqlParameter("@PCName", PCName));
            Cmd.Parameters.Add(new SqlParameter("@NetUserName", NetUserName));
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
    public int DeleteHalls(InitializeModule.EnumCampus Campus, string HallID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@HallID", HallID));
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
        List<EctNewHalls> myHallss = new List<EctNewHalls>();
        try
        {
            myHallss = GetHalls(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("HallID", Type.GetType("nvarchar"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("HallTypeID", Type.GetType("int"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("BuildingID", Type.GetType("int"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myHallss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myHallss[i].HallID;
                dr[2] = myHallss[i].HallTypeID;
                dr[3] = myHallss[i].BuildingID;
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
            sSQL += HallIDFN;
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
public class EctNewHallsCls : EctNewHallsDAL
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
    public EctNewHallsCls()
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
            //'cmdRolePermission.Parameters.Add("@HallID", SqlDbType.Int, 4, "HallID" );
            daHalls.SelectCommand = cmdHalls;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdHalls = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
          
            cmdHalls.Parameters.Add("@HallTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HallTypeIDFN));
            cmdHalls.Parameters.Add("@BuildingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BuildingIDFN));
            cmdHalls.Parameters.Add("@MaxSeats", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MaxSeatsFN));
            cmdHalls.Parameters.Add("@intFloor", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intFloorFN));
            cmdHalls.Parameters.Add("@MaleHallID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaleHallIDFN));
            cmdHalls.Parameters.Add("@FemaleHallID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FemaleHallIDFN));
            cmdHalls.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000, LibraryMOD.GetFieldName(NotesFN));
            cmdHalls.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdHalls.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdHalls.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdHalls.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdHalls.Parameters.Add("@PCName", SqlDbType.VarChar, 16, LibraryMOD.GetFieldName(PCNameFN));
            cmdHalls.Parameters.Add("@NetUserName", SqlDbType.VarChar, 16, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdHalls.Parameters.Add("@HallID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HallIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daHalls.UpdateCommand = cmdHalls;
            daHalls.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdHalls = new SqlCommand(GetInsertCommand(), con);
            cmdHalls.Parameters.Add("@HallID", SqlDbType.NVarChar, 40, LibraryMOD.GetFieldName(HallIDFN));
            cmdHalls.Parameters.Add("@HallTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HallTypeIDFN));
            cmdHalls.Parameters.Add("@BuildingID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BuildingIDFN));
            cmdHalls.Parameters.Add("@MaxSeats", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MaxSeatsFN));
            cmdHalls.Parameters.Add("@intFloor", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intFloorFN));
            cmdHalls.Parameters.Add("@MaleHallID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaleHallIDFN));
            cmdHalls.Parameters.Add("@FemaleHallID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FemaleHallIDFN));
            cmdHalls.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000, LibraryMOD.GetFieldName(NotesFN));
            cmdHalls.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdHalls.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdHalls.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdHalls.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdHalls.Parameters.Add("@PCName", SqlDbType.VarChar, 16, LibraryMOD.GetFieldName(PCNameFN));
            cmdHalls.Parameters.Add("@NetUserName", SqlDbType.VarChar, 16, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daHalls.InsertCommand = cmdHalls;
            daHalls.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdHalls = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdHalls.Parameters.Add("@HallID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HallIDFN));
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
                    dr[LibraryMOD.GetFieldName(HallIDFN)] = HallID;
                    dr[LibraryMOD.GetFieldName(HallTypeIDFN)] = HallTypeID;
                    dr[LibraryMOD.GetFieldName(BuildingIDFN)] = BuildingID;
                    dr[LibraryMOD.GetFieldName(MaxSeatsFN)] = MaxSeats;
                    dr[LibraryMOD.GetFieldName(intFloorFN)] = intFloor;
                    dr[LibraryMOD.GetFieldName(MaleHallIDFN)] = MaleHallID;
                    dr[LibraryMOD.GetFieldName(FemaleHallIDFN)] = FemaleHallID;
                    dr[LibraryMOD.GetFieldName(NotesFN)] = Notes;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
                    dsHalls.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsHalls.Tables[TableName].Select(LibraryMOD.GetFieldName(HallIDFN) + "=" + HallID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(HallIDFN)] = HallID;
                    drAry[0][LibraryMOD.GetFieldName(HallTypeIDFN)] = HallTypeID;
                    drAry[0][LibraryMOD.GetFieldName(BuildingIDFN)] = BuildingID;
                    drAry[0][LibraryMOD.GetFieldName(MaxSeatsFN)] = MaxSeats;
                    drAry[0][LibraryMOD.GetFieldName(intFloorFN)] = intFloor;
                    drAry[0][LibraryMOD.GetFieldName(MaleHallIDFN)] = MaleHallID;
                    drAry[0][LibraryMOD.GetFieldName(FemaleHallIDFN)] = FemaleHallID;
                    drAry[0][LibraryMOD.GetFieldName(NotesFN)] = Notes;
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
            FindInMultiPKey(HallID);
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
            if (HallsDataRow[LibraryMOD.GetFieldName(HallIDFN)] == System.DBNull.Value)
            {
                HallID = "";
            }
            else
            {
                HallID = (string)HallsDataRow[LibraryMOD.GetFieldName(HallIDFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(HallTypeIDFN)] == System.DBNull.Value)
            {
                HallTypeID = 0;
            }
            else
            {
                HallTypeID = (int)HallsDataRow[LibraryMOD.GetFieldName(HallTypeIDFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(BuildingIDFN)] == System.DBNull.Value)
            {
                BuildingID = 0;
            }
            else
            {
                BuildingID = (int)HallsDataRow[LibraryMOD.GetFieldName(BuildingIDFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(MaxSeatsFN)] == System.DBNull.Value)
            {
                MaxSeats = 0;
            }
            else
            {
                MaxSeats = (int)HallsDataRow[LibraryMOD.GetFieldName(MaxSeatsFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(intFloorFN)] == System.DBNull.Value)
            {
                intFloor = 0;
            }
            else
            {
                intFloor = (int)HallsDataRow[LibraryMOD.GetFieldName(intFloorFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(MaleHallIDFN)] == System.DBNull.Value)
            {
                MaleHallID = 0;
            }
            else
            {
                MaleHallID = (int)HallsDataRow[LibraryMOD.GetFieldName(MaleHallIDFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(FemaleHallIDFN)] == System.DBNull.Value)
            {
                FemaleHallID = 0;
            }
            else
            {
                FemaleHallID = (int)HallsDataRow[LibraryMOD.GetFieldName(FemaleHallIDFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(NotesFN)] == System.DBNull.Value)
            {
                Notes = "";
            }
            else
            {
                Notes = (string)HallsDataRow[LibraryMOD.GetFieldName(NotesFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)HallsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)HallsDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)HallsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)HallsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)HallsDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (HallsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)HallsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(string PKHallID)
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKHallID;
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
