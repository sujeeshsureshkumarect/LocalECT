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
public class Certificates
{
    //Creation Date: 28/03/2010 09:57:06 ص
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_intCertificate;
    private string m_strCertificateDescEn;
    private string m_strCertificateDescAr;
    private double m_curMin;
    private double m_curMax;
    private double m_curPassed;
    private string m_strCert;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int intCertificate
    {
        get { return m_intCertificate; }
        set { m_intCertificate = value; }
    }
    public string strCertificateDescEn
    {
        get { return m_strCertificateDescEn; }
        set { m_strCertificateDescEn = value; }
    }
    public string strCertificateDescAr
    {
        get { return m_strCertificateDescAr; }
        set { m_strCertificateDescAr = value; }
    }
    public double curMin
    {
        get { return m_curMin; }
        set { m_curMin = value; }
    }
    public double curMax
    {
        get { return m_curMax; }
        set { m_curMax = value; }
    }
    public double curPassed
    {
        get { return m_curPassed; }
        set { m_curPassed = value; }
    }
    public string strCert
    {
        get { return m_strCert; }
        set { m_strCert = value; }
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
    public Certificates()
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
public class CertificatesDAL : Certificates
{
    #region "Decleration"
    private string m_TableName;
    private string m_intCertificateFN;
    private string m_strCertificateDescEnFN;
    private string m_strCertificateDescArFN;
    private string m_curMinFN;
    private string m_curMaxFN;
    private string m_curPassedFN;
    private string m_strCertFN;
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
    public string intCertificateFN
    {
        get { return m_intCertificateFN; }
        set { m_intCertificateFN = value; }
    }
    public string strCertificateDescEnFN
    {
        get { return m_strCertificateDescEnFN; }
        set { m_strCertificateDescEnFN = value; }
    }
    public string strCertificateDescArFN
    {
        get { return m_strCertificateDescArFN; }
        set { m_strCertificateDescArFN = value; }
    }
    public string curMinFN
    {
        get { return m_curMinFN; }
        set { m_curMinFN = value; }
    }
    public string curMaxFN
    {
        get { return m_curMaxFN; }
        set { m_curMaxFN = value; }
    }
    public string curPassedFN
    {
        get { return m_curPassedFN; }
        set { m_curPassedFN = value; }
    }
    public string strCertFN
    {
        get { return m_strCertFN; }
        set { m_strCertFN = value; }
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
    public CertificatesDAL()
    {
        try
        {
            this.TableName = "Lkp_Certificates";
            this.intCertificateFN = m_TableName + ".intCertificate";
            this.strCertificateDescEnFN = m_TableName + ".strCertificateDescEn";
            this.strCertificateDescArFN = m_TableName + ".strCertificateDescAr";
            this.curMinFN = m_TableName + ".curMin";
            this.curMaxFN = m_TableName + ".curMax";
            this.curPassedFN = m_TableName + ".curPassed";
            this.strCertFN = m_TableName + ".strCert";
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
            sSQL += intCertificateFN;
            sSQL += " , " + strCertificateDescEnFN;
            sSQL += " , " + strCertificateDescArFN;
            sSQL += " , " + curMinFN;
            sSQL += " , " + curMaxFN;
            sSQL += " , " + curPassedFN;
            sSQL += " , " + strCertFN;
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
            sSQL += intCertificateFN;
            sSQL += " , " + strCertificateDescEnFN;
            sSQL += " , " + strCertificateDescArFN;
            sSQL += " , " + curMinFN;
            sSQL += " , " + curMaxFN;
            sSQL += " , " + curPassedFN;
            sSQL += " , " + strCertFN;
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
            sSQL += LibraryMOD.GetFieldName(intCertificateFN) + "=@intCertificate";
            sSQL += " , " + LibraryMOD.GetFieldName(strCertificateDescEnFN) + "=@strCertificateDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(strCertificateDescArFN) + "=@strCertificateDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(curMinFN) + "=@curMin";
            sSQL += " , " + LibraryMOD.GetFieldName(curMaxFN) + "=@curMax";
            sSQL += " , " + LibraryMOD.GetFieldName(curPassedFN) + "=@curPassed";
            sSQL += " , " + LibraryMOD.GetFieldName(strCertFN) + "=@strCert";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(intCertificateFN) + "=@intCertificate";
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
            sSQL += LibraryMOD.GetFieldName(intCertificateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCertificateDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCertificateDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(curMinFN);
            sSQL += " , " + LibraryMOD.GetFieldName(curMaxFN);
            sSQL += " , " + LibraryMOD.GetFieldName(curPassedFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCertFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @intCertificate";
            sSQL += " ,@strCertificateDescEn";
            sSQL += " ,@strCertificateDescAr";
            sSQL += " ,@curMin";
            sSQL += " ,@curMax";
            sSQL += " ,@curPassed";
            sSQL += " ,@strCert";
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
            sSQL += LibraryMOD.GetFieldName(intCertificateFN) + "=@intCertificate";
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
    public List<Certificates> GetCertificates(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Certificates
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
        List<Certificates> results = new List<Certificates>();
        try
        {
            //Default Value
            Certificates myCertificates = new Certificates();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCertificates.intCertificate = 0;
                myCertificates.strCertificateDescEn = "Select Certificate ...";
                results.Add(myCertificates);
            }
            while (reader.Read())
            {
                myCertificates = new Certificates();
                if (reader[LibraryMOD.GetFieldName(intCertificateFN)].Equals(DBNull.Value))
                {
                    myCertificates.intCertificate = 0;
                }
                else
                {
                    myCertificates.intCertificate = int.Parse(reader[LibraryMOD.GetFieldName(intCertificateFN)].ToString());
                }
                myCertificates.strCertificateDescEn = reader[LibraryMOD.GetFieldName(strCertificateDescEnFN)].ToString();
                myCertificates.strCertificateDescAr = reader[LibraryMOD.GetFieldName(strCertificateDescArFN)].ToString();
                myCertificates.strCert = reader[LibraryMOD.GetFieldName(strCertFN)].ToString();
                myCertificates.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myCertificates.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myCertificates.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myCertificates.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myCertificates.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myCertificates.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myCertificates);
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
    public int UpdateCertificates(InitializeModule.EnumCampus Campus, int iMode, int intCertificate, string strCertificateDescEn, string strCertificateDescAr, double curMin, double curMax, double curPassed, string strCert, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Certificates theCertificates = new Certificates();
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
            Cmd.Parameters.Add(new SqlParameter("@intCertificate", intCertificate));
            Cmd.Parameters.Add(new SqlParameter("@strCertificateDescEn", strCertificateDescEn));
            Cmd.Parameters.Add(new SqlParameter("@strCertificateDescAr", strCertificateDescAr));
            Cmd.Parameters.Add(new SqlParameter("@curMin", curMin));
            Cmd.Parameters.Add(new SqlParameter("@curMax", curMax));
            Cmd.Parameters.Add(new SqlParameter("@curPassed", curPassed));
            Cmd.Parameters.Add(new SqlParameter("@strCert", strCert));
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
    public int DeleteCertificates(InitializeModule.EnumCampus Campus, string intCertificate)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@intCertificate", intCertificate));
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
        DataTable dt = new DataTable("Certificates");
        DataView dv = new DataView();
        List<Certificates> myCertificatess = new List<Certificates>();
        try
        {
            myCertificatess = GetCertificates(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("intCertificate", Type.GetType("smallint"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strCertificateDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strCertificateDescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myCertificatess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myCertificatess[i].intCertificate;
                dr[2] = myCertificatess[i].strCertificateDescEn;
                dr[3] = myCertificatess[i].strCertificateDescAr;
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
            myCertificatess.Clear();
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
            sSQL += intCertificateFN;
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
public class CertificatesCls : CertificatesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daCertificates;
    private DataSet m_dsCertificates;
    public DataRow CertificatesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsCertificates
    {
        get { return m_dsCertificates; }
        set { m_dsCertificates = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public CertificatesCls()
    {
        try
        {
            dsCertificates = new DataSet();

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
    public virtual SqlDataAdapter GetCertificatesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daCertificates = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCertificates);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daCertificates.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCertificates;
    }
    public virtual SqlDataAdapter GetCertificatesDataAdapter(SqlConnection con)
    {
        try
        {
            daCertificates = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daCertificates.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdCertificates;
            cmdCertificates = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@intCertificate", SqlDbType.Int, 4, "intCertificate" );
            daCertificates.SelectCommand = cmdCertificates;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdCertificates = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdCertificates.Parameters.Add("@intCertificate", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intCertificateFN));
            cmdCertificates.Parameters.Add("@strCertificateDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCertificateDescEnFN));
            cmdCertificates.Parameters.Add("@strCertificateDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCertificateDescArFN));
            cmdCertificates.Parameters.Add("@curMin", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curMinFN));
            cmdCertificates.Parameters.Add("@curMax", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curMaxFN));
            cmdCertificates.Parameters.Add("@curPassed", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curPassedFN));
            cmdCertificates.Parameters.Add("@strCert", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCertFN));
            cmdCertificates.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdCertificates.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdCertificates.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdCertificates.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdCertificates.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdCertificates.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdCertificates.Parameters.Add("@intCertificate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intCertificateFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daCertificates.UpdateCommand = cmdCertificates;
            daCertificates.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdCertificates = new SqlCommand(GetInsertCommand(), con);
            cmdCertificates.Parameters.Add("@intCertificate", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intCertificateFN));
            cmdCertificates.Parameters.Add("@strCertificateDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCertificateDescEnFN));
            cmdCertificates.Parameters.Add("@strCertificateDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCertificateDescArFN));
            cmdCertificates.Parameters.Add("@curMin", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curMinFN));
            cmdCertificates.Parameters.Add("@curMax", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curMaxFN));
            cmdCertificates.Parameters.Add("@curPassed", SqlDbType.Decimal, 21, LibraryMOD.GetFieldName(curPassedFN));
            cmdCertificates.Parameters.Add("@strCert", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCertFN));
            cmdCertificates.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdCertificates.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdCertificates.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdCertificates.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdCertificates.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdCertificates.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daCertificates.InsertCommand = cmdCertificates;
            daCertificates.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdCertificates = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdCertificates.Parameters.Add("@intCertificate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intCertificateFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daCertificates.DeleteCommand = cmdCertificates;
            daCertificates.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daCertificates.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCertificates;
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
                    dr = dsCertificates.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(intCertificateFN)] = intCertificate;
                    dr[LibraryMOD.GetFieldName(strCertificateDescEnFN)] = strCertificateDescEn;
                    dr[LibraryMOD.GetFieldName(strCertificateDescArFN)] = strCertificateDescAr;
                    dr[LibraryMOD.GetFieldName(curMinFN)] = curMin;
                    dr[LibraryMOD.GetFieldName(curMaxFN)] = curMax;
                    dr[LibraryMOD.GetFieldName(curPassedFN)] = curPassed;
                    dr[LibraryMOD.GetFieldName(strCertFN)] = strCert;
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
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
                    dsCertificates.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsCertificates.Tables[TableName].Select(LibraryMOD.GetFieldName(intCertificateFN) + "=" + intCertificate);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(intCertificateFN)] = intCertificate;
                    drAry[0][LibraryMOD.GetFieldName(strCertificateDescEnFN)] = strCertificateDescEn;
                    drAry[0][LibraryMOD.GetFieldName(strCertificateDescArFN)] = strCertificateDescAr;
                    drAry[0][LibraryMOD.GetFieldName(curMinFN)] = curMin;
                    drAry[0][LibraryMOD.GetFieldName(curMaxFN)] = curMax;
                    drAry[0][LibraryMOD.GetFieldName(curPassedFN)] = curPassed;
                    drAry[0][LibraryMOD.GetFieldName(strCertFN)] = strCert;
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
    public int CommitCertificates()
    {
        //CommitCertificates= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daCertificates.Update(dsCertificates, TableName);
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
            FindInMultiPKey(intCertificate);
            if ((CertificatesDataRow != null))
            {
                CertificatesDataRow.Delete();
                CommitCertificates();
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
            if (CertificatesDataRow[LibraryMOD.GetFieldName(intCertificateFN)] == System.DBNull.Value)
            {
                intCertificate = 0;
            }
            else
            {
                intCertificate = (int)CertificatesDataRow[LibraryMOD.GetFieldName(intCertificateFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(strCertificateDescEnFN)] == System.DBNull.Value)
            {
                strCertificateDescEn = "";
            }
            else
            {
                strCertificateDescEn = (string)CertificatesDataRow[LibraryMOD.GetFieldName(strCertificateDescEnFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(strCertificateDescArFN)] == System.DBNull.Value)
            {
                strCertificateDescAr = "";
            }
            else
            {
                strCertificateDescAr = (string)CertificatesDataRow[LibraryMOD.GetFieldName(strCertificateDescArFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(curMinFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(curMaxFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(curPassedFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(strCertFN)] == System.DBNull.Value)
            {
                strCert = "";
            }
            else
            {
                strCert = (string)CertificatesDataRow[LibraryMOD.GetFieldName(strCertFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)CertificatesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)CertificatesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)CertificatesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)CertificatesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)CertificatesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (CertificatesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)CertificatesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKintCertificate)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKintCertificate;
            CertificatesDataRow = dsCertificates.Tables[TableName].Rows.Find(findTheseVals);
            if ((CertificatesDataRow != null))
            {
                lngCurRow = dsCertificates.Tables[TableName].Rows.IndexOf(CertificatesDataRow);
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
            lngCurRow = dsCertificates.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsCertificates.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsCertificates.Tables[TableName].Rows.Count > 0)
            {
                CertificatesDataRow = dsCertificates.Tables[TableName].Rows[lngCurRow];
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
            daCertificates.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCertificates.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daCertificates.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCertificates.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
