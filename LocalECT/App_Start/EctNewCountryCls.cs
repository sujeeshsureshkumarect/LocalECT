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
public class EctNewCountry
{
    //Creation Date: 18/03/2010 12:33:01 م
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_CountryID;
    private string m_CountryCode;
    private string m_CountryDescEn;
    private string m_CountryDescAr;
    private int m_GroupID;
    private int m_CountryMaleID;
    private int m_CountryFemaleID;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int CountryID
    {
        get { return m_CountryID; }
        set { m_CountryID = value; }
    }
    public string CountryCode
    {
        get { return m_CountryCode; }
        set { m_CountryCode = value; }
    }
    public string CountryDescEn
    {
        get { return m_CountryDescEn; }
        set { m_CountryDescEn = value; }
    }
    public string CountryDescAr
    {
        get { return m_CountryDescAr; }
        set { m_CountryDescAr = value; }
    }
    public int GroupID
    {
        get { return m_GroupID; }
        set { m_GroupID = value; }
    }
    public int CountryMaleID
    {
        get { return m_CountryMaleID; }
        set { m_CountryMaleID = value; }
    }
    public int CountryFemaleID
    {
        get { return m_CountryFemaleID; }
        set { m_CountryFemaleID = value; }
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
    public EctNewCountry()
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
public class EctNewCountryDAL : EctNewCountry
{
    #region "Decleration"
    private string m_TableName;
    private string m_CountryIDFN;
    private string m_CountryCodeFN;
    private string m_CountryDescEnFN;
    private string m_CountryDescArFN;
    private string m_GroupIDFN;
    private string m_CountryMaleIDFN;
    private string m_CountryFemaleIDFN;
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
    public string CountryIDFN
    {
        get { return m_CountryIDFN; }
        set { m_CountryIDFN = value; }
    }
    public string CountryCodeFN
    {
        get { return m_CountryCodeFN; }
        set { m_CountryCodeFN = value; }
    }
    public string CountryDescEnFN
    {
        get { return m_CountryDescEnFN; }
        set { m_CountryDescEnFN = value; }
    }
    public string CountryDescArFN
    {
        get { return m_CountryDescArFN; }
        set { m_CountryDescArFN = value; }
    }
    public string GroupIDFN
    {
        get { return m_GroupIDFN; }
        set { m_GroupIDFN = value; }
    }
    public string CountryMaleIDFN
    {
        get { return m_CountryMaleIDFN; }
        set { m_CountryMaleIDFN = value; }
    }
    public string CountryFemaleIDFN
    {
        get { return m_CountryFemaleIDFN; }
        set { m_CountryFemaleIDFN = value; }
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
    public EctNewCountryDAL()
    {
        try
        {
            this.TableName = "Lkp_Country";
            this.CountryIDFN = m_TableName + ".CountryID";
            this.CountryCodeFN = m_TableName + ".CountryCode";
            this.CountryDescEnFN = m_TableName + ".CountryDescEn";
            this.CountryDescArFN = m_TableName + ".CountryDescAr";
            this.GroupIDFN = m_TableName + ".GroupID";
            this.CountryMaleIDFN = m_TableName + ".CountryMaleID";
            this.CountryFemaleIDFN = m_TableName + ".CountryFemaleID";
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
            sSQL += CountryIDFN;
            sSQL += " , " + CountryCodeFN;
            sSQL += " , " + CountryDescEnFN;
            sSQL += " , " + CountryDescArFN;
            sSQL += " , " + GroupIDFN;
            sSQL += " , " + CountryMaleIDFN;
            sSQL += " , " + CountryFemaleIDFN;
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
            sSQL += CountryIDFN;
            sSQL += " , " + CountryCodeFN;
            sSQL += " , " + CountryDescEnFN;
            sSQL += " , " + CountryDescArFN;
            sSQL += " , " + GroupIDFN;
            sSQL += " , " + CountryMaleIDFN;
            sSQL += " , " + CountryFemaleIDFN;
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
            sSQL += LibraryMOD.GetFieldName(CountryIDFN) + "=@CountryID";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryCodeFN) + "=@CountryCode";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryDescEnFN) + "=@CountryDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryDescArFN) + "=@CountryDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(GroupIDFN) + "=@GroupID";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryMaleIDFN) + "=@CountryMaleID";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryFemaleIDFN) + "=@CountryFemaleID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(CountryIDFN) + "=@CountryID";
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
            sSQL += LibraryMOD.GetFieldName(CountryIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryCodeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(GroupIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryMaleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryFemaleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @CountryID";
            sSQL += " ,@CountryCode";
            sSQL += " ,@CountryDescEn";
            sSQL += " ,@CountryDescAr";
            sSQL += " ,@GroupID";
            sSQL += " ,@CountryMaleID";
            sSQL += " ,@CountryFemaleID";
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
            sSQL += LibraryMOD.GetFieldName(CountryIDFN) + "=@CountryID";
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
    public List<EctNewCountry> GetCountry(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Country
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
        List<EctNewCountry> results = new List<EctNewCountry>();
        try
        {
            //Default Value
            EctNewCountry myCountry = new EctNewCountry();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCountry.CountryID = 0;
                myCountry.CountryCode = "";
                myCountry.CountryDescEn = "Select Country";
                results.Add(myCountry);
            }
            while (reader.Read())
            {
                myCountry = new EctNewCountry();
                if (reader[LibraryMOD.GetFieldName(CountryIDFN)].Equals(DBNull.Value))
                {
                    myCountry.CountryID = 0;
                }
                else
                {
                    myCountry.CountryID = int.Parse(reader[LibraryMOD.GetFieldName(CountryIDFN)].ToString());
                }
                myCountry.CountryCode = reader[LibraryMOD.GetFieldName(CountryCodeFN)].ToString();
                myCountry.CountryDescEn = reader[LibraryMOD.GetFieldName(CountryDescEnFN)].ToString();
                myCountry.CountryDescAr = reader[LibraryMOD.GetFieldName(CountryDescArFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(GroupIDFN)].Equals(DBNull.Value))
                {
                    myCountry.GroupID = 0;
                }
                else
                {
                    myCountry.GroupID = int.Parse(reader[LibraryMOD.GetFieldName(GroupIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CountryMaleIDFN)].Equals(DBNull.Value))
                {
                    myCountry.CountryMaleID = 0;
                }
                else
                {
                    myCountry.CountryMaleID = int.Parse(reader[LibraryMOD.GetFieldName(CountryMaleIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CountryFemaleIDFN)].Equals(DBNull.Value))
                {
                    myCountry.CountryFemaleID = 0;
                }
                else
                {
                    myCountry.CountryFemaleID = int.Parse(reader[LibraryMOD.GetFieldName(CountryFemaleIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myCountry.CreationUserID = 0;
                }
                else
                {
                    myCountry.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myCountry.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myCountry.LastUpdateUserID = 0;
                }
                else
                {
                    myCountry.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myCountry.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myCountry.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myCountry.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(myCountry);
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
    public int UpdateCountry(InitializeModule.EnumCampus Campus, int iMode, int CountryID, string CountryCode, string CountryDescEn, string CountryDescAr, int GroupID, int CountryMaleID, int CountryFemaleID, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            EctNewCountry theCountry = new EctNewCountry();
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
            Cmd.Parameters.Add(new SqlParameter("@CountryID", CountryID));
            Cmd.Parameters.Add(new SqlParameter("@CountryCode", CountryCode));
            Cmd.Parameters.Add(new SqlParameter("@CountryDescEn", CountryDescEn));
            Cmd.Parameters.Add(new SqlParameter("@CountryDescAr", CountryDescAr));
            Cmd.Parameters.Add(new SqlParameter("@GroupID", GroupID));
            Cmd.Parameters.Add(new SqlParameter("@CountryMaleID", CountryMaleID));
            Cmd.Parameters.Add(new SqlParameter("@CountryFemaleID", CountryFemaleID));
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
    public int DeleteCountry(InitializeModule.EnumCampus Campus, string CountryID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@CountryID", CountryID));
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
        DataTable dt = new DataTable("Country");
        DataView dv = new DataView();
        List<EctNewCountry> myCountrys = new List<EctNewCountry>();
        try
        {
            myCountrys = GetCountry(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("CountryID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("CountryCode", Type.GetType("char"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("CountryDescEn", Type.GetType("varchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myCountrys.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myCountrys[i].CountryID;
                dr[2] = myCountrys[i].CountryCode;
                dr[3] = myCountrys[i].CountryDescEn;
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
            myCountrys.Clear();
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
            sSQL += CountryIDFN;
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
public class EctNewCountryCls : EctNewCountryDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daCountry;
    private DataSet m_dsCountry;
    public DataRow CountryDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsCountry
    {
        get { return m_dsCountry; }
        set { m_dsCountry = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public EctNewCountryCls()
    {
        try
        {
            dsCountry = new DataSet();

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
    public virtual SqlDataAdapter GetCountryDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daCountry = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCountry);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daCountry.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCountry;
    }
    public virtual SqlDataAdapter GetCountryDataAdapter(SqlConnection con)
    {
        try
        {
            daCountry = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daCountry.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdCountry;
            cmdCountry = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@CountryID", SqlDbType.Int, 4, "CountryID" );
            daCountry.SelectCommand = cmdCountry;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdCountry = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            //cmdCountry.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            cmdCountry.Parameters.Add("@CountryCode", SqlDbType.Char, 2, LibraryMOD.GetFieldName(CountryCodeFN));
            cmdCountry.Parameters.Add("@CountryDescEn", SqlDbType.VarChar, 100, LibraryMOD.GetFieldName(CountryDescEnFN));
            cmdCountry.Parameters.Add("@CountryDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(CountryDescArFN));
            cmdCountry.Parameters.Add("@GroupID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(GroupIDFN));
            cmdCountry.Parameters.Add("@CountryMaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryMaleIDFN));
            cmdCountry.Parameters.Add("@CountryFemaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryFemaleIDFN));
            cmdCountry.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdCountry.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdCountry.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdCountry.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdCountry.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdCountry.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdCountry.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daCountry.UpdateCommand = cmdCountry;
            daCountry.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdCountry = new SqlCommand(GetInsertCommand(), con);
            cmdCountry.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            cmdCountry.Parameters.Add("@CountryCode", SqlDbType.Char, 2, LibraryMOD.GetFieldName(CountryCodeFN));
            cmdCountry.Parameters.Add("@CountryDescEn", SqlDbType.VarChar, 100, LibraryMOD.GetFieldName(CountryDescEnFN));
            cmdCountry.Parameters.Add("@CountryDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(CountryDescArFN));
            cmdCountry.Parameters.Add("@GroupID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(GroupIDFN));
            cmdCountry.Parameters.Add("@CountryMaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryMaleIDFN));
            cmdCountry.Parameters.Add("@CountryFemaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryFemaleIDFN));
            cmdCountry.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdCountry.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdCountry.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdCountry.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdCountry.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdCountry.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daCountry.InsertCommand = cmdCountry;
            daCountry.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdCountry = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdCountry.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daCountry.DeleteCommand = cmdCountry;
            daCountry.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daCountry.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCountry;
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
                    dr = dsCountry.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(CountryIDFN)] = CountryID;
                    dr[LibraryMOD.GetFieldName(CountryCodeFN)] = CountryCode;
                    dr[LibraryMOD.GetFieldName(CountryDescEnFN)] = CountryDescEn;
                    dr[LibraryMOD.GetFieldName(CountryDescArFN)] = CountryDescAr;
                    dr[LibraryMOD.GetFieldName(GroupIDFN)] = GroupID;
                    dr[LibraryMOD.GetFieldName(CountryMaleIDFN)] = CountryMaleID;
                    dr[LibraryMOD.GetFieldName(CountryFemaleIDFN)] = CountryFemaleID;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
                    dsCountry.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsCountry.Tables[TableName].Select(LibraryMOD.GetFieldName(CountryIDFN) + "=" + CountryID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(CountryIDFN)] = CountryID;
                    drAry[0][LibraryMOD.GetFieldName(CountryCodeFN)] = CountryCode;
                    drAry[0][LibraryMOD.GetFieldName(CountryDescEnFN)] = CountryDescEn;
                    drAry[0][LibraryMOD.GetFieldName(CountryDescArFN)] = CountryDescAr;
                    drAry[0][LibraryMOD.GetFieldName(GroupIDFN)] = GroupID;
                    drAry[0][LibraryMOD.GetFieldName(CountryMaleIDFN)] = CountryMaleID;
                    drAry[0][LibraryMOD.GetFieldName(CountryFemaleIDFN)] = CountryFemaleID;
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
    public int CommitCountry()
    {
        //CommitCountry= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daCountry.Update(dsCountry, TableName);
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
            FindInMultiPKey(CountryID);
            if ((CountryDataRow != null))
            {
                CountryDataRow.Delete();
                CommitCountry();
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
            if (CountryDataRow[LibraryMOD.GetFieldName(CountryIDFN)] == System.DBNull.Value)
            {
                CountryID = 0;
            }
            else
            {
                CountryID = (int)CountryDataRow[LibraryMOD.GetFieldName(CountryIDFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(CountryCodeFN)] == System.DBNull.Value)
            {
                CountryCode = "";
            }
            else
            {
                CountryCode = (string)CountryDataRow[LibraryMOD.GetFieldName(CountryCodeFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(CountryDescEnFN)] == System.DBNull.Value)
            {
                CountryDescEn = "";
            }
            else
            {
                CountryDescEn = (string)CountryDataRow[LibraryMOD.GetFieldName(CountryDescEnFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(CountryDescArFN)] == System.DBNull.Value)
            {
                CountryDescAr = "";
            }
            else
            {
                CountryDescAr = (string)CountryDataRow[LibraryMOD.GetFieldName(CountryDescArFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(GroupIDFN)] == System.DBNull.Value)
            {
                GroupID = 0;
            }
            else
            {
                GroupID = (int)CountryDataRow[LibraryMOD.GetFieldName(GroupIDFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(CountryMaleIDFN)] == System.DBNull.Value)
            {
                CountryMaleID = 0;
            }
            else
            {
                CountryMaleID = (int)CountryDataRow[LibraryMOD.GetFieldName(CountryMaleIDFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(CountryFemaleIDFN)] == System.DBNull.Value)
            {
                CountryFemaleID = 0;
            }
            else
            {
                CountryFemaleID = (int)CountryDataRow[LibraryMOD.GetFieldName(CountryFemaleIDFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)CountryDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)CountryDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)CountryDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)CountryDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)CountryDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (CountryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)CountryDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKCountryID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKCountryID;
            CountryDataRow = dsCountry.Tables[TableName].Rows.Find(findTheseVals);
            if ((CountryDataRow != null))
            {
                lngCurRow = dsCountry.Tables[TableName].Rows.IndexOf(CountryDataRow);
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
            lngCurRow = dsCountry.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsCountry.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsCountry.Tables[TableName].Rows.Count > 0)
            {
                CountryDataRow = dsCountry.Tables[TableName].Rows[lngCurRow];
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
            daCountry.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCountry.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daCountry.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCountry.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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