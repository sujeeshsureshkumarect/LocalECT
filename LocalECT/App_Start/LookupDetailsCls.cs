using System;
using System.Data;
using System.Configuration;
////////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//////using System.Xml.Linq;
using System.Collections.Generic;
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class LookupDetails
{
    //Creation Date: 24/11/2009 8:32:10 AM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_SeqID;
    private int m_MajorID;
    private int m_MinorID;
    private string m_DescEn;
    private string m_DescAr;
    private int m_IsActive;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int SeqID
    {
        get { return m_SeqID; }
        set { m_SeqID = value; }
    }
    public int MajorID
    {
        get { return m_MajorID; }
        set { m_MajorID = value; }
    }
    public int MinorID
    {
        get { return m_MinorID; }
        set { m_MinorID = value; }
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
    public int IsActive
    {
        get { return m_IsActive; }
        set { m_IsActive = value; }
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
    #endregion
    //'-----------------------------------------------------
    public LookupDetails()
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
public class LookupDetailsDAL : LookupDetails
{
    #region "Decleration"
    private string m_TableName;
    private string m_SeqIDFN;
    private string m_MajorIDFN;
    private string m_MinorIDFN;
    private string m_DescEnFN;
    private string m_DescArFN;
    private string m_IsActiveFN;
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
    public string SeqIDFN
    {
        get { return m_SeqIDFN; }
        set { m_SeqIDFN = value; }
    }
    public string MajorIDFN
    {
        get { return m_MajorIDFN; }
        set { m_MajorIDFN = value; }
    }
    public string MinorIDFN
    {
        get { return m_MinorIDFN; }
        set { m_MinorIDFN = value; }
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
    public string IsActiveFN
    {
        get { return m_IsActiveFN; }
        set { m_IsActiveFN = value; }
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
    public LookupDetailsDAL()
    {
        try
        {
            this.TableName = "Cmn_LookupDetails";
            this.SeqIDFN = m_TableName + ".SeqID";
            this.MajorIDFN = m_TableName + ".MajorID";
            this.MinorIDFN = m_TableName + ".MinorID";
            this.DescEnFN = m_TableName + ".DescEn";
            this.DescArFN = m_TableName + ".DescAr";
            this.IsActiveFN = m_TableName + ".IsActive";
            this.CreationUserIDFN = m_TableName + ".CreationUserID";
            this.CreationDateFN = m_TableName + ".CreationDate";
            this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
            this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
            this.PCNameFN = m_TableName + ".PCName";
            this.NetUserNameFN = m_TableName + ".NetUserName";
            //dsLookupDetails= new DataSet();

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
            sSQL += SeqIDFN;
            sSQL += " , " + MajorIDFN;
            sSQL += " , " + MinorIDFN;
            sSQL += " , " + DescEnFN;
            sSQL += " , " + DescArFN;
            sSQL += " , " + IsActiveFN;
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
            sSQL += SeqIDFN;
            sSQL += " , " + MajorIDFN;
            sSQL += " , " + MinorIDFN;
            sSQL += " , " + DescEnFN;
            sSQL += " , " + DescArFN;
            sSQL += " , " + IsActiveFN;
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
            sSQL += LibraryMOD.GetFieldName(MajorIDFN) + "=@MajorID";
            //sSQL += " , " + LibraryMOD.GetFieldName(SeqIDFN) + "=@SeqID";
            sSQL += " , " + LibraryMOD.GetFieldName(MinorIDFN) + "=@MinorID";
            sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN) + "=@DescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(DescArFN) + "=@DescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(SeqIDFN) + "=@SeqID";
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
            sSQL += LibraryMOD.GetFieldName(MajorIDFN);
            //sSQL += " , " + LibraryMOD.GetFieldName(SeqIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MinorIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @MajorID";
            //sSQL += " ,@SeqID";
            sSQL += " ,@MinorID";
            sSQL += " ,@DescEn";
            sSQL += " ,@DescAr";
            sSQL += " ,@IsActive";
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
            sSQL += LibraryMOD.GetFieldName(SeqIDFN) + "=@SeqID";
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
    public List<LookupDetails> GetLookupDetails(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded, string sDefault, InitializeModule.enumLookupType Major)
    {
        //' returns a list of Classes instances based on the
        //' data in the LookupDetails
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetSQL();
        sSQL += " Where " + LibraryMOD.GetFieldName(MajorIDFN) + "=" + (int)Major;
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LookupDetails> results = new List<LookupDetails>();
        try
        {
            //Default Value
            LookupDetails myLookupDetails = new LookupDetails();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLookupDetails.SeqID = 0;
                myLookupDetails.MajorID = 0;
                //myLookupDetails.MinorID = 0;
                myLookupDetails.DescEn = sDefault;
                results.Add(myLookupDetails);
            }
            while (reader.Read())
            {
                myLookupDetails = new LookupDetails();
                if (reader[LibraryMOD.GetFieldName(SeqIDFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.SeqID = 0;
                }
                else
                {
                    myLookupDetails.SeqID = int.Parse(reader[LibraryMOD.GetFieldName(SeqIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(MajorIDFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.MajorID = 0;
                }
                else
                {
                    myLookupDetails.MajorID = int.Parse(reader[LibraryMOD.GetFieldName(MajorIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(MinorIDFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.MinorID = 0;
                }
                else
                {
                    myLookupDetails.MinorID = int.Parse(reader[LibraryMOD.GetFieldName(MinorIDFN)].ToString());
                }
                myLookupDetails.DescEn = reader[LibraryMOD.GetFieldName(DescEnFN)].ToString();
                myLookupDetails.DescAr = reader[LibraryMOD.GetFieldName(DescArFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(IsActiveFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.IsActive = 0;
                }
                else
                {
                    myLookupDetails.IsActive = int.Parse(reader[LibraryMOD.GetFieldName(IsActiveFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.CreationUserID = 0;
                }
                else
                {
                    myLookupDetails.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.LastUpdateUserID = 0;
                }
                else
                {
                    myLookupDetails.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myLookupDetails.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myLookupDetails.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myLookupDetails.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(myLookupDetails);
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
    public int UpdateLookupDetails(InitializeModule.EnumCampus Campus, int iMode, int SeqID, int MajorID, int MinorID, string DescEn, string DescAr, int IsActive, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LookupDetails theLookupDetails = new LookupDetails();
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
            Cmd.Parameters.Add(new SqlParameter("@SeqID", SeqID));
            Cmd.Parameters.Add(new SqlParameter("@MajorID", MajorID));
            Cmd.Parameters.Add(new SqlParameter("@MinorID", MinorID));
            Cmd.Parameters.Add(new SqlParameter("@DescEn", DescEn));
            Cmd.Parameters.Add(new SqlParameter("@DescAr", DescAr));
            Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
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
    public int DeleteLookupDetails(InitializeModule.EnumCampus Campus, string SeqID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@SeqID", SeqID));
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
    public DataView GetDataView(bool isFromRole, int PK, string sCondition, InitializeModule.enumLookupType Major)
    {
        DataTable dt = new DataTable("LookupDetails");
        DataView dv = new DataView();
        List<LookupDetails> myLookupDetailss = new List<LookupDetails>();
        try
        {
            myLookupDetailss = GetLookupDetails(InitializeModule.EnumCampus.ECTNew, sCondition, false, "", Major);
            DataColumn col1 = new DataColumn("SeqID", Type.GetType("int identity"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("MajorID", Type.GetType("int"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("MinorID", Type.GetType("int"));
            dt.Columns.Add(col3);
            DataColumn col4 = new DataColumn("DescEn", Type.GetType("string"));
            dt.Columns.Add(col4);

            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLookupDetailss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLookupDetailss[i].SeqID;
                dr[2] = myLookupDetailss[i].MajorID;
                dr[3] = myLookupDetailss[i].MinorID;
                dr[4] = myLookupDetailss[i].DescEn;
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
            myLookupDetailss.Clear();
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
            sSQL += SeqIDFN;
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
public class LookupDetailsCls : LookupDetailsDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLookupDetails;
    private DataSet m_dsLookupDetails;
    public DataRow LookupDetailsDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLookupDetails
    {
        get { return m_dsLookupDetails; }
        set { m_dsLookupDetails = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LookupDetailsCls()
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
    //-------Get DataAdapter  -----------------------------
    #region "DataAdapter"
    public virtual SqlDataAdapter GetLookupDetailsDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLookupDetails = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLookupDetails);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLookupDetails.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLookupDetails;
    }
    public virtual SqlDataAdapter GetLookupDetailsDataAdapter(SqlConnection con)
    {
        try
        {
            daLookupDetails = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLookupDetails.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLookupDetails;
            cmdLookupDetails = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@SeqID", SqlDbType.Int, 4, "SeqID" );
            daLookupDetails.SelectCommand = cmdLookupDetails;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLookupDetails = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLookupDetails.Parameters.Add("@SeqID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeqIDFN));
            cmdLookupDetails.Parameters.Add("@MajorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MajorIDFN));
            cmdLookupDetails.Parameters.Add("@MinorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MinorIDFN));
            cmdLookupDetails.Parameters.Add("@DescEn", SqlDbType.NVarChar, 200, LibraryMOD.GetFieldName(DescEnFN));
            cmdLookupDetails.Parameters.Add("@DescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(DescArFN));
            cmdLookupDetails.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            cmdLookupDetails.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdLookupDetails.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdLookupDetails.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdLookupDetails.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdLookupDetails.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdLookupDetails.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdLookupDetails.Parameters.Add("@SeqID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeqIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLookupDetails.UpdateCommand = cmdLookupDetails;
            daLookupDetails.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------
            //'/INSERT COMMAND
            cmdLookupDetails = new SqlCommand(GetInsertCommand(), con);
            cmdLookupDetails.Parameters.Add("@SeqID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeqIDFN));
            cmdLookupDetails.Parameters.Add("@MajorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MajorIDFN));
            cmdLookupDetails.Parameters.Add("@MinorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MinorIDFN));
            cmdLookupDetails.Parameters.Add("@DescEn", SqlDbType.NVarChar, 200, LibraryMOD.GetFieldName(DescEnFN));
            cmdLookupDetails.Parameters.Add("@DescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(DescArFN));
            cmdLookupDetails.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            cmdLookupDetails.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdLookupDetails.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdLookupDetails.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdLookupDetails.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdLookupDetails.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdLookupDetails.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLookupDetails.InsertCommand = cmdLookupDetails;
            daLookupDetails.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLookupDetails = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLookupDetails.Parameters.Add("@SeqID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeqIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLookupDetails.DeleteCommand = cmdLookupDetails;
            daLookupDetails.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLookupDetails.UpdateBatchSize = InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLookupDetails;
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
                    dr = dsLookupDetails.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(SeqIDFN)] = SeqID;
                    dr[LibraryMOD.GetFieldName(MajorIDFN)] = MajorID;
                    dr[LibraryMOD.GetFieldName(MinorIDFN)] = MinorID;
                    dr[LibraryMOD.GetFieldName(DescEnFN)] = DescEn;
                    dr[LibraryMOD.GetFieldName(DescArFN)] = DescAr;
                    dr[LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
                    dsLookupDetails.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLookupDetails.Tables[TableName].Select(LibraryMOD.GetFieldName(SeqIDFN) + "=" + SeqID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(SeqIDFN)] = SeqID;
                    drAry[0][LibraryMOD.GetFieldName(MajorIDFN)] = MajorID;
                    drAry[0][LibraryMOD.GetFieldName(MinorIDFN)] = MinorID;
                    drAry[0][LibraryMOD.GetFieldName(DescEnFN)] = DescEn;
                    drAry[0][LibraryMOD.GetFieldName(DescArFN)] = DescAr;
                    drAry[0][LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
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
    public int CommitLookupDetails()
    {
        //CommitLookupDetails= InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLookupDetails.Update(dsLookupDetails, TableName);
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
            FindInMultiPKey(SeqID);
            if ((LookupDetailsDataRow != null))
            {
                LookupDetailsDataRow.Delete();
                CommitLookupDetails();
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
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(SeqIDFN)] == System.DBNull.Value)
            {
                SeqID = 0;
            }
            else
            {
                SeqID = (int)LookupDetailsDataRow[LibraryMOD.GetFieldName(SeqIDFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(MajorIDFN)] == System.DBNull.Value)
            {
                MajorID = 0;
            }
            else
            {
                MajorID = (int)LookupDetailsDataRow[LibraryMOD.GetFieldName(MajorIDFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(MinorIDFN)] == System.DBNull.Value)
            {
                MinorID = 0;
            }
            else
            {
                MinorID = (int)LookupDetailsDataRow[LibraryMOD.GetFieldName(MinorIDFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(DescEnFN)] == System.DBNull.Value)
            {
                DescEn = "";
            }
            else
            {
                DescEn = (string)LookupDetailsDataRow[LibraryMOD.GetFieldName(DescEnFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(DescArFN)] == System.DBNull.Value)
            {
                DescAr = "";
            }
            else
            {
                DescAr = (string)LookupDetailsDataRow[LibraryMOD.GetFieldName(DescArFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(IsActiveFN)] == System.DBNull.Value)
            {
                IsActive = 0;
            }
            else
            {
                IsActive = (int)LookupDetailsDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)LookupDetailsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)LookupDetailsDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)LookupDetailsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)LookupDetailsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)LookupDetailsDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (LookupDetailsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)LookupDetailsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    //DataColumn col1= new DataColumn("SeqID", Type.GetType("int identity"));
    //dt.Columns.Add(col1 );
    //DataColumn col2= new DataColumn("MajorID", Type.GetType("int"));
    //dt.Columns.Add(col2 );
    //DataColumn col3= new DataColumn("MinorID", Type.GetType("int"));
    //dt.Columns.Add(col3 );
    public int FindInMultiPKey(int PKSeqID)
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKSeqID;
            LookupDetailsDataRow = dsLookupDetails.Tables[TableName].Rows.Find(findTheseVals);
            if ((LookupDetailsDataRow != null))
            {
                lngCurRow = dsLookupDetails.Tables[TableName].Rows.IndexOf(LookupDetailsDataRow);
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
            lngCurRow = dsLookupDetails.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLookupDetails.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLookupDetails.Tables[TableName].Rows.Count > 0)
            {
                LookupDetailsDataRow = dsLookupDetails.Tables[TableName].Rows[lngCurRow];
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
            daLookupDetails.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLookupDetails.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLookupDetails.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLookupDetails.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
