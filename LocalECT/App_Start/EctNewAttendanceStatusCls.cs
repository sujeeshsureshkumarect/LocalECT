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
public class EctNewAttendanceStatus
{
    //Creation Date: 24/03/2010 10:30:29 ص
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_StatusID;
    private string m_DescEn;
    private string m_DescAr;
    private string m_Factor;
    private int m_MaleStatusID;
    private int m_FemaleStatusID;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int StatusID
    {
        get { return m_StatusID; }
        set { m_StatusID = value; }
    }
    public string DescEn
    {
        get { return m_DescEn; }
        set { m_DescEn = value; }
    }
    public string DescAr
    {
        get { return m_DescAr; }
        set { m_DescAr = value; }
    }
    public string Factor
    {
        get { return m_Factor; }
        set { m_Factor = value; }
    }
    public int MaleStatusID
    {
        get { return m_MaleStatusID; }
        set { m_MaleStatusID = value; }
    }
    public int FemaleStatusID
    {
        get { return m_FemaleStatusID; }
        set { m_FemaleStatusID = value; }
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
    public EctNewAttendanceStatus()
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
public class EctNewAttendanceStatusDAL : EctNewAttendanceStatus
{
    #region "Decleration"
    private string m_TableName;
    private string m_StatusIDFN;
    private string m_DescEnFN;
    private string m_DescArFN;
    private string m_FactorFN;
    private string m_MaleStatusIDFN;
    private string m_FemaleStatusIDFN;
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
    public string StatusIDFN
    {
        get { return m_StatusIDFN; }
        set { m_StatusIDFN = value; }
    }
    public string DescEnFN
    {
        get { return m_DescEnFN; }
        set { m_DescEnFN = value; }
    }
    public string DescArFN
    {
        get { return m_DescArFN; }
        set { m_DescArFN = value; }
    }
    public string FactorFN
    {
        get { return m_FactorFN; }
        set { m_FactorFN = value; }
    }
    public string MaleStatusIDFN
    {
        get { return m_MaleStatusIDFN; }
        set { m_MaleStatusIDFN = value; }
    }
    public string FemaleStatusIDFN
    {
        get { return m_FemaleStatusIDFN; }
        set { m_FemaleStatusIDFN = value; }
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
    public EctNewAttendanceStatusDAL()
    {
        try
        {
            this.TableName = "Lkp_AttendanceStatus";
            this.StatusIDFN = m_TableName + ".StatusID";
            this.DescEnFN = m_TableName + ".DescEn";
            this.DescArFN = m_TableName + ".DescAr";
            this.FactorFN = m_TableName + ".Factor";
            this.MaleStatusIDFN = m_TableName + ".MaleStatusID";
            this.FemaleStatusIDFN = m_TableName + ".FemaleStatusID";
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
            sSQL += StatusIDFN;
            sSQL += " , " + DescEnFN;
            sSQL += " , " + DescArFN;
            sSQL += " , " + FactorFN;
            sSQL += " , " + MaleStatusIDFN;
            sSQL += " , " + FemaleStatusIDFN;
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
            sSQL += StatusIDFN;
            sSQL += " , " + DescEnFN;
            sSQL += " , " + DescArFN;
            sSQL += " , " + FactorFN;
            sSQL += " , " + MaleStatusIDFN;
            sSQL += " , " + FemaleStatusIDFN;
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
            sSQL += LibraryMOD.GetFieldName(StatusIDFN) + "=@StatusID";
            sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN) + "=@DescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(DescArFN) + "=@DescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(FactorFN) + "=@Factor";
            sSQL += " , " + LibraryMOD.GetFieldName(MaleStatusIDFN) + "=@MaleStatusID";
            sSQL += " , " + LibraryMOD.GetFieldName(FemaleStatusIDFN) + "=@FemaleStatusID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(StatusIDFN) + "=@StatusID";
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
            sSQL += LibraryMOD.GetFieldName(StatusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(FactorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MaleStatusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(FemaleStatusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @StatusID";
            sSQL += " ,@DescEn";
            sSQL += " ,@DescAr";
            sSQL += " ,@Factor";
            sSQL += " ,@MaleStatusID";
            sSQL += " ,@FemaleStatusID";
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
            sSQL += LibraryMOD.GetFieldName(StatusIDFN) + "=@StatusID";
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
    public List<EctNewAttendanceStatus> GetAttendanceStatus(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the AttendanceStatus
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
        List<EctNewAttendanceStatus> results = new List<EctNewAttendanceStatus>();
        try
        {
            //Default Value
            EctNewAttendanceStatus myAttendanceStatus = new EctNewAttendanceStatus();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myAttendanceStatus.StatusID = 0;
                myAttendanceStatus.DescEn = "Select AttendanceStatu ...";
                results.Add(myAttendanceStatus);
            }
            while (reader.Read())
            {
                myAttendanceStatus = new EctNewAttendanceStatus();
                if (reader[LibraryMOD.GetFieldName(StatusIDFN)].Equals(DBNull.Value))
                {
                    myAttendanceStatus.StatusID = 0;
                }
                else
                {
                    myAttendanceStatus.StatusID = int.Parse(reader[LibraryMOD.GetFieldName(StatusIDFN)].ToString());
                }
                myAttendanceStatus.DescEn = reader[LibraryMOD.GetFieldName(DescEnFN)].ToString();
                myAttendanceStatus.DescAr = reader[LibraryMOD.GetFieldName(DescArFN)].ToString();
                myAttendanceStatus.Factor = reader[LibraryMOD.GetFieldName(FactorFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(MaleStatusIDFN)].Equals(DBNull.Value))
                {
                    myAttendanceStatus.MaleStatusID = 0;
                }
                else
                {
                    myAttendanceStatus.MaleStatusID = int.Parse(reader[LibraryMOD.GetFieldName(MaleStatusIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(FemaleStatusIDFN)].Equals(DBNull.Value))
                {
                    myAttendanceStatus.FemaleStatusID = 0;
                }
                else
                {
                    myAttendanceStatus.FemaleStatusID = int.Parse(reader[LibraryMOD.GetFieldName(FemaleStatusIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myAttendanceStatus.CreationUserID = 0;
                }
                else
                {
                    myAttendanceStatus.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myAttendanceStatus.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myAttendanceStatus.LastUpdateUserID = 0;
                }
                else
                {
                    myAttendanceStatus.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myAttendanceStatus.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myAttendanceStatus.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myAttendanceStatus.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(myAttendanceStatus);
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
    public int UpdateAttendanceStatus(InitializeModule.EnumCampus Campus, int iMode, int StatusID, string DescEn, string DescAr, string Factor, int MaleStatusID, int FemaleStatusID, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            EctNewAttendanceStatus theAttendanceStatus = new EctNewAttendanceStatus();
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
            Cmd.Parameters.Add(new SqlParameter("@StatusID", StatusID));
            Cmd.Parameters.Add(new SqlParameter("@DescEn", DescEn));
            Cmd.Parameters.Add(new SqlParameter("@DescAr", DescAr));
            Cmd.Parameters.Add(new SqlParameter("@Factor", Factor));
            Cmd.Parameters.Add(new SqlParameter("@MaleStatusID", MaleStatusID));
            Cmd.Parameters.Add(new SqlParameter("@FemaleStatusID", FemaleStatusID));
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
    public int DeleteAttendanceStatus(InitializeModule.EnumCampus Campus, string StatusID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@StatusID", StatusID));
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
        DataTable dt = new DataTable("AttendanceStatus");
        DataView dv = new DataView();
        List<EctNewAttendanceStatus> myAttendanceStatuss = new List<EctNewAttendanceStatus>();
        try
        {
            myAttendanceStatuss = GetAttendanceStatus(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("StatusID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("DescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("DescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myAttendanceStatuss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myAttendanceStatuss[i].StatusID;
                dr[2] = myAttendanceStatuss[i].DescEn;
                dr[3] = myAttendanceStatuss[i].DescAr;
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
            myAttendanceStatuss.Clear();
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
            sSQL += StatusIDFN;
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
public class EctNewAttendanceStatusCls : EctNewAttendanceStatusDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daAttendanceStatus;
    private DataSet m_dsAttendanceStatus;
    public DataRow AttendanceStatusDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsAttendanceStatus
    {
        get { return m_dsAttendanceStatus; }
        set { m_dsAttendanceStatus = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public EctNewAttendanceStatusCls()
    {
        try
        {
            dsAttendanceStatus = new DataSet();

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
    public virtual SqlDataAdapter GetAttendanceStatusDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daAttendanceStatus = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daAttendanceStatus);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daAttendanceStatus.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daAttendanceStatus;
    }
    public virtual SqlDataAdapter GetAttendanceStatusDataAdapter(SqlConnection con)
    {
        try
        {
            daAttendanceStatus = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daAttendanceStatus.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdAttendanceStatus;
            cmdAttendanceStatus = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@StatusID", SqlDbType.Int, 4, "StatusID" );
            daAttendanceStatus.SelectCommand = cmdAttendanceStatus;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdAttendanceStatus = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdAttendanceStatus.Parameters.Add("@StatusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StatusIDFN));
            cmdAttendanceStatus.Parameters.Add("@DescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(DescEnFN));
            cmdAttendanceStatus.Parameters.Add("@DescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(DescArFN));
            cmdAttendanceStatus.Parameters.Add("@Factor", SqlDbType.Decimal, 7, LibraryMOD.GetFieldName(FactorFN));
            cmdAttendanceStatus.Parameters.Add("@MaleStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MaleStatusIDFN));
            cmdAttendanceStatus.Parameters.Add("@FemaleStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(FemaleStatusIDFN));
            cmdAttendanceStatus.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdAttendanceStatus.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdAttendanceStatus.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdAttendanceStatus.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdAttendanceStatus.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdAttendanceStatus.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdAttendanceStatus.Parameters.Add("@StatusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StatusIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daAttendanceStatus.UpdateCommand = cmdAttendanceStatus;
            daAttendanceStatus.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdAttendanceStatus = new SqlCommand(GetInsertCommand(), con);
            cmdAttendanceStatus.Parameters.Add("@StatusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StatusIDFN));
            cmdAttendanceStatus.Parameters.Add("@DescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(DescEnFN));
            cmdAttendanceStatus.Parameters.Add("@DescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(DescArFN));
            cmdAttendanceStatus.Parameters.Add("@Factor", SqlDbType.Decimal, 7, LibraryMOD.GetFieldName(FactorFN));
            cmdAttendanceStatus.Parameters.Add("@MaleStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MaleStatusIDFN));
            cmdAttendanceStatus.Parameters.Add("@FemaleStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(FemaleStatusIDFN));
            cmdAttendanceStatus.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdAttendanceStatus.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdAttendanceStatus.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdAttendanceStatus.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdAttendanceStatus.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdAttendanceStatus.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daAttendanceStatus.InsertCommand = cmdAttendanceStatus;
            daAttendanceStatus.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdAttendanceStatus = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdAttendanceStatus.Parameters.Add("@StatusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StatusIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daAttendanceStatus.DeleteCommand = cmdAttendanceStatus;
            daAttendanceStatus.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daAttendanceStatus.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daAttendanceStatus;
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
                    dr = dsAttendanceStatus.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(StatusIDFN)] = StatusID;
                    dr[LibraryMOD.GetFieldName(DescEnFN)] = DescEn;
                    dr[LibraryMOD.GetFieldName(DescArFN)] = DescAr;
                    dr[LibraryMOD.GetFieldName(FactorFN)] = Factor;
                    dr[LibraryMOD.GetFieldName(MaleStatusIDFN)] = MaleStatusID;
                    dr[LibraryMOD.GetFieldName(FemaleStatusIDFN)] = FemaleStatusID;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
                    dsAttendanceStatus.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsAttendanceStatus.Tables[TableName].Select(LibraryMOD.GetFieldName(StatusIDFN) + "=" + StatusID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(StatusIDFN)] = StatusID;
                    drAry[0][LibraryMOD.GetFieldName(DescEnFN)] = DescEn;
                    drAry[0][LibraryMOD.GetFieldName(DescArFN)] = DescAr;
                    drAry[0][LibraryMOD.GetFieldName(FactorFN)] = Factor;
                    drAry[0][LibraryMOD.GetFieldName(MaleStatusIDFN)] = MaleStatusID;
                    drAry[0][LibraryMOD.GetFieldName(FemaleStatusIDFN)] = FemaleStatusID;
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
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
    public int CommitAttendanceStatus()
    {
        //CommitAttendanceStatus= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daAttendanceStatus.Update(dsAttendanceStatus, TableName);
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
            FindInMultiPKey(StatusID);
            if ((AttendanceStatusDataRow != null))
            {
                AttendanceStatusDataRow.Delete();
                CommitAttendanceStatus();
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
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(StatusIDFN)] == System.DBNull.Value)
            {
                StatusID = 0;
            }
            else
            {
                StatusID = (int)AttendanceStatusDataRow[LibraryMOD.GetFieldName(StatusIDFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(DescEnFN)] == System.DBNull.Value)
            {
                DescEn = "";
            }
            else
            {
                DescEn = (string)AttendanceStatusDataRow[LibraryMOD.GetFieldName(DescEnFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(DescArFN)] == System.DBNull.Value)
            {
                DescAr = "";
            }
            else
            {
                DescAr = (string)AttendanceStatusDataRow[LibraryMOD.GetFieldName(DescArFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(FactorFN)] == System.DBNull.Value)
            {
                Factor = "";
            }
            else
            {
                Factor = (string)AttendanceStatusDataRow[LibraryMOD.GetFieldName(FactorFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(MaleStatusIDFN)] == System.DBNull.Value)
            {
                MaleStatusID = 0;
            }
            else
            {
                MaleStatusID = (int)AttendanceStatusDataRow[LibraryMOD.GetFieldName(MaleStatusIDFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(FemaleStatusIDFN)] == System.DBNull.Value)
            {
                FemaleStatusID = 0;
            }
            else
            {
                FemaleStatusID = (int)AttendanceStatusDataRow[LibraryMOD.GetFieldName(FemaleStatusIDFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)AttendanceStatusDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)AttendanceStatusDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)AttendanceStatusDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)AttendanceStatusDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)AttendanceStatusDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (AttendanceStatusDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)AttendanceStatusDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKStatusID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKStatusID;
            AttendanceStatusDataRow = dsAttendanceStatus.Tables[TableName].Rows.Find(findTheseVals);
            if ((AttendanceStatusDataRow != null))
            {
                lngCurRow = dsAttendanceStatus.Tables[TableName].Rows.IndexOf(AttendanceStatusDataRow);
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
            lngCurRow = dsAttendanceStatus.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsAttendanceStatus.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsAttendanceStatus.Tables[TableName].Rows.Count > 0)
            {
                AttendanceStatusDataRow = dsAttendanceStatus.Tables[TableName].Rows[lngCurRow];
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
            daAttendanceStatus.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daAttendanceStatus.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daAttendanceStatus.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daAttendanceStatus.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
