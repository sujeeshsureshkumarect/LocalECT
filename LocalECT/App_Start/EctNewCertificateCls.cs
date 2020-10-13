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
public class EctNewCertificate
{
    //Creation Date: 28/03/2010 09:56:19 ص
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_CertificateID;
    private string m_DescEn;
    private string m_DescAr;
    private decimal m_MaxScore;
    private decimal m_MinScore;
    private decimal m_PassScore;
    private string m_AliasCert;
    private int m_MaleCertID;
    private int m_FemaleCertID;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int CertificateID
    {
        get { return m_CertificateID; }
        set { m_CertificateID = value; }
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
    public decimal MaxScore
    {
        get { return m_MaxScore; }
        set { m_MaxScore = value; }
    }
    public decimal MinScore
    {
        get { return m_MinScore; }
        set { m_MinScore = value; }
    }
    public decimal PassScore
    {
        get { return m_PassScore; }
        set { m_PassScore = value; }
    }
    public string AliasCert
    {
        get { return m_AliasCert; }
        set { m_AliasCert = value; }
    }
    public int MaleCertID
    {
        get { return m_MaleCertID; }
        set { m_MaleCertID = value; }
    }
    public int FemaleCertID
    {
        get { return m_FemaleCertID; }
        set { m_FemaleCertID = value; }
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
    public EctNewCertificate()
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
public class EctNewCertificateDAL : EctNewCertificate
{
    #region "Decleration"
    private string m_TableName;
    private string m_CertificateIDFN;
    private string m_DescEnFN;
    private string m_DescArFN;
    private string m_MaxScoreFN;
    private string m_MinScoreFN;
    private string m_PassScoreFN;
    private string m_AliasCertFN;
    private string m_MaleCertIDFN;
    private string m_FemaleCertIDFN;
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
    public string CertificateIDFN
    {
        get { return m_CertificateIDFN; }
        set { m_CertificateIDFN = value; }
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
    public string MaxScoreFN
    {
        get { return m_MaxScoreFN; }
        set { m_MaxScoreFN = value; }
    }
    public string MinScoreFN
    {
        get { return m_MinScoreFN; }
        set { m_MinScoreFN = value; }
    }
    public string PassScoreFN
    {
        get { return m_PassScoreFN; }
        set { m_PassScoreFN = value; }
    }
    public string AliasCertFN
    {
        get { return m_AliasCertFN; }
        set { m_AliasCertFN = value; }
    }
    public string MaleCertIDFN
    {
        get { return m_MaleCertIDFN; }
        set { m_MaleCertIDFN = value; }
    }
    public string FemaleCertIDFN
    {
        get { return m_FemaleCertIDFN; }
        set { m_FemaleCertIDFN = value; }
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
    public EctNewCertificateDAL()
    {
        try
        {
            this.TableName = "Lkp_Certificate";
            this.CertificateIDFN = m_TableName + ".CertificateID";
            this.DescEnFN = m_TableName + ".DescEn";
            this.DescArFN = m_TableName + ".DescAr";
            this.MaxScoreFN = m_TableName + ".MaxScore";
            this.MinScoreFN = m_TableName + ".MinScore";
            this.PassScoreFN = m_TableName + ".PassScore";
            this.AliasCertFN = m_TableName + ".AliasCert";
            this.MaleCertIDFN = m_TableName + ".MaleCertID";
            this.FemaleCertIDFN = m_TableName + ".FemaleCertID";
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
            sSQL += CertificateIDFN;
            sSQL += " , " + DescEnFN;
            sSQL += " , " + DescArFN;
            sSQL += " , " + MaxScoreFN;
            sSQL += " , " + MinScoreFN;
            sSQL += " , " + PassScoreFN;
            sSQL += " , " + AliasCertFN;
            sSQL += " , " + MaleCertIDFN;
            sSQL += " , " + FemaleCertIDFN;
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
            sSQL += CertificateIDFN;
            sSQL += " , " + DescEnFN;
            sSQL += " , " + DescArFN;
            sSQL += " , " + MaxScoreFN;
            sSQL += " , " + MinScoreFN;
            sSQL += " , " + PassScoreFN;
            sSQL += " , " + AliasCertFN;
            sSQL += " , " + MaleCertIDFN;
            sSQL += " , " + FemaleCertIDFN;
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
            sSQL += LibraryMOD.GetFieldName(CertificateIDFN) + "=@CertificateID";
            sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN) + "=@DescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(DescArFN) + "=@DescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(MaxScoreFN) + "=@MaxScore";
            sSQL += " , " + LibraryMOD.GetFieldName(MinScoreFN) + "=@MinScore";
            sSQL += " , " + LibraryMOD.GetFieldName(PassScoreFN) + "=@PassScore";
            sSQL += " , " + LibraryMOD.GetFieldName(AliasCertFN) + "=@AliasCert";
            sSQL += " , " + LibraryMOD.GetFieldName(MaleCertIDFN) + "=@MaleCertID";
            sSQL += " , " + LibraryMOD.GetFieldName(FemaleCertIDFN) + "=@FemaleCertID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(CertificateIDFN) + "=@CertificateID";
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
            sSQL += LibraryMOD.GetFieldName(CertificateIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(DescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MaxScoreFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MinScoreFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PassScoreFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AliasCertFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MaleCertIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(FemaleCertIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @CertificateID";
            sSQL += " ,@DescEn";
            sSQL += " ,@DescAr";
            sSQL += " ,@MaxScore";
            sSQL += " ,@MinScore";
            sSQL += " ,@PassScore";
            sSQL += " ,@AliasCert";
            sSQL += " ,@MaleCertID";
            sSQL += " ,@FemaleCertID";
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
            sSQL += LibraryMOD.GetFieldName(CertificateIDFN) + "=@CertificateID";
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
    public List<EctNewCertificate> GetCertificate(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Certificate
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
        List<EctNewCertificate> results = new List<EctNewCertificate>();
        try
        {
            //Default Value
            EctNewCertificate myCertificate = new EctNewCertificate();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCertificate.CertificateID = 0;
                myCertificate.DescEn = "Select Certificate ...";
                results.Add(myCertificate);
            }
            while (reader.Read())
            {
                myCertificate = new EctNewCertificate();
                if (reader[LibraryMOD.GetFieldName(CertificateIDFN)].Equals(DBNull.Value))
                {
                    myCertificate.CertificateID = 0;
                }
                else
                {
                    myCertificate.CertificateID = int.Parse(reader[LibraryMOD.GetFieldName(CertificateIDFN)].ToString());
                }
                myCertificate.DescEn = reader[LibraryMOD.GetFieldName(DescEnFN)].ToString();
                myCertificate.DescAr = reader[LibraryMOD.GetFieldName(DescArFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(MaxScoreFN)].Equals(DBNull.Value))
                {
                    myCertificate.MaxScore = 0;
                }
                else
                {
                    myCertificate.MaxScore = decimal.Parse(reader[LibraryMOD.GetFieldName(MaxScoreFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(MinScoreFN)].Equals(DBNull.Value))
                {
                    myCertificate.MinScore = 0;
                }
                else
                {
                    myCertificate.MinScore = decimal.Parse(reader[LibraryMOD.GetFieldName(MinScoreFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(PassScoreFN)].Equals(DBNull.Value))
                {
                    myCertificate.PassScore = 0;
                }
                else
                {
                    myCertificate.PassScore = decimal.Parse(reader[LibraryMOD.GetFieldName(PassScoreFN)].ToString());
                }
                myCertificate.AliasCert = reader[LibraryMOD.GetFieldName(AliasCertFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(MaleCertIDFN)].Equals(DBNull.Value))
                {
                    myCertificate.MaleCertID = 0;
                }
                else
                {
                    myCertificate.MaleCertID = int.Parse(reader[LibraryMOD.GetFieldName(MaleCertIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(FemaleCertIDFN)].Equals(DBNull.Value))
                {
                    myCertificate.FemaleCertID = 0;
                }
                else
                {
                    myCertificate.FemaleCertID = int.Parse(reader[LibraryMOD.GetFieldName(FemaleCertIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myCertificate.CreationUserID = 0;
                }
                else
                {
                    myCertificate.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myCertificate.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myCertificate.LastUpdateUserID = 0;
                }
                else
                {
                    myCertificate.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myCertificate.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myCertificate.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myCertificate.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(myCertificate);
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
    public int UpdateCertificate(InitializeModule.EnumCampus Campus, int iMode, int CertificateID, string DescEn, string DescAr, decimal MaxScore, decimal MinScore, decimal PassScore, string AliasCert, int MaleCertID, int FemaleCertID, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            EctNewCertificate theCertificate = new EctNewCertificate();
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
            Cmd.Parameters.Add(new SqlParameter("@CertificateID", CertificateID));
            Cmd.Parameters.Add(new SqlParameter("@DescEn", DescEn));
            Cmd.Parameters.Add(new SqlParameter("@DescAr", DescAr));
            Cmd.Parameters.Add(new SqlParameter("@MaxScore", MaxScore));
            Cmd.Parameters.Add(new SqlParameter("@MinScore", MinScore));
            Cmd.Parameters.Add(new SqlParameter("@PassScore", PassScore));
            Cmd.Parameters.Add(new SqlParameter("@AliasCert", AliasCert));
            Cmd.Parameters.Add(new SqlParameter("@MaleCertID", MaleCertID));
            Cmd.Parameters.Add(new SqlParameter("@FemaleCertID", FemaleCertID));
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
    public int DeleteCertificate(InitializeModule.EnumCampus Campus, string CertificateID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@CertificateID", CertificateID));
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
        DataTable dt = new DataTable("Certificate");
        DataView dv = new DataView();
        List<EctNewCertificate> myCertificates = new List<EctNewCertificate>();
        try
        {
            myCertificates = GetCertificate(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("CertificateID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("DescEn", Type.GetType("varchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("DescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myCertificates.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myCertificates[i].CertificateID;
                dr[2] = myCertificates[i].DescEn;
                dr[3] = myCertificates[i].DescAr;
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
            myCertificates.Clear();
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
            sSQL += CertificateIDFN;
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
public class EctNewCertificateCls : EctNewCertificateDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daCertificate;
    private DataSet m_dsCertificate;
    public DataRow CertificateDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsCertificate
    {
        get { return m_dsCertificate; }
        set { m_dsCertificate = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public EctNewCertificateCls()
    {
        try
        {
            dsCertificate = new DataSet();

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
    public virtual SqlDataAdapter GetCertificateDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daCertificate = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCertificate);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daCertificate.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCertificate;
    }
    public virtual SqlDataAdapter GetCertificateDataAdapter(SqlConnection con)
    {
        try
        {
            daCertificate = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daCertificate.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdCertificate;
            cmdCertificate = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@CertificateID", SqlDbType.Int, 4, "CertificateID" );
            daCertificate.SelectCommand = cmdCertificate;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdCertificate = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            //cmdCertificate.Parameters.Add("@CertificateID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CertificateIDFN));
            cmdCertificate.Parameters.Add("@DescEn", SqlDbType.VarChar, 250, LibraryMOD.GetFieldName(DescEnFN));
            cmdCertificate.Parameters.Add("@DescAr", SqlDbType.NVarChar, 500, LibraryMOD.GetFieldName(DescArFN));
            cmdCertificate.Parameters.Add("@MaxScore", SqlDbType.Decimal, 20, LibraryMOD.GetFieldName(MaxScoreFN));
            cmdCertificate.Parameters.Add("@MinScore", SqlDbType.Decimal, 20, LibraryMOD.GetFieldName(MinScoreFN));
            cmdCertificate.Parameters.Add("@PassScore", SqlDbType.Decimal, 20, LibraryMOD.GetFieldName(PassScoreFN));
            cmdCertificate.Parameters.Add("@AliasCert", SqlDbType.VarChar, 50, LibraryMOD.GetFieldName(AliasCertFN));
            cmdCertificate.Parameters.Add("@MaleCertID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MaleCertIDFN));
            cmdCertificate.Parameters.Add("@FemaleCertID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(FemaleCertIDFN));
            cmdCertificate.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdCertificate.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdCertificate.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdCertificate.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdCertificate.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdCertificate.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdCertificate.Parameters.Add("@CertificateID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CertificateIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daCertificate.UpdateCommand = cmdCertificate;
            daCertificate.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdCertificate = new SqlCommand(GetInsertCommand(), con);
            cmdCertificate.Parameters.Add("@CertificateID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CertificateIDFN));
            cmdCertificate.Parameters.Add("@DescEn", SqlDbType.VarChar, 250, LibraryMOD.GetFieldName(DescEnFN));
            cmdCertificate.Parameters.Add("@DescAr", SqlDbType.NVarChar, 500, LibraryMOD.GetFieldName(DescArFN));
            cmdCertificate.Parameters.Add("@MaxScore", SqlDbType.Decimal, 20, LibraryMOD.GetFieldName(MaxScoreFN));
            cmdCertificate.Parameters.Add("@MinScore", SqlDbType.Decimal, 20, LibraryMOD.GetFieldName(MinScoreFN));
            cmdCertificate.Parameters.Add("@PassScore", SqlDbType.Decimal, 20, LibraryMOD.GetFieldName(PassScoreFN));
            cmdCertificate.Parameters.Add("@AliasCert", SqlDbType.VarChar, 50, LibraryMOD.GetFieldName(AliasCertFN));
            cmdCertificate.Parameters.Add("@MaleCertID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(MaleCertIDFN));
            cmdCertificate.Parameters.Add("@FemaleCertID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(FemaleCertIDFN));
            cmdCertificate.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdCertificate.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdCertificate.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdCertificate.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdCertificate.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdCertificate.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daCertificate.InsertCommand = cmdCertificate;
            daCertificate.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdCertificate = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdCertificate.Parameters.Add("@CertificateID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CertificateIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daCertificate.DeleteCommand = cmdCertificate;
            daCertificate.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daCertificate.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCertificate;
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
                    dr = dsCertificate.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(CertificateIDFN)] = CertificateID;
                    dr[LibraryMOD.GetFieldName(DescEnFN)] = DescEn;
                    dr[LibraryMOD.GetFieldName(DescArFN)] = DescAr;
                    dr[LibraryMOD.GetFieldName(MaxScoreFN)] = MaxScore;
                    dr[LibraryMOD.GetFieldName(MinScoreFN)] = MinScore;
                    dr[LibraryMOD.GetFieldName(PassScoreFN)] = PassScore;
                    dr[LibraryMOD.GetFieldName(AliasCertFN)] = AliasCert;
                    dr[LibraryMOD.GetFieldName(MaleCertIDFN)] = MaleCertID;
                    dr[LibraryMOD.GetFieldName(FemaleCertIDFN)] = FemaleCertID;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
                    dsCertificate.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsCertificate.Tables[TableName].Select(LibraryMOD.GetFieldName(CertificateIDFN) + "=" + CertificateID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(CertificateIDFN)] = CertificateID;
                    drAry[0][LibraryMOD.GetFieldName(DescEnFN)] = DescEn;
                    drAry[0][LibraryMOD.GetFieldName(DescArFN)] = DescAr;
                    drAry[0][LibraryMOD.GetFieldName(MaxScoreFN)] = MaxScore;
                    drAry[0][LibraryMOD.GetFieldName(MinScoreFN)] = MinScore;
                    drAry[0][LibraryMOD.GetFieldName(PassScoreFN)] = PassScore;
                    drAry[0][LibraryMOD.GetFieldName(AliasCertFN)] = AliasCert;
                    drAry[0][LibraryMOD.GetFieldName(MaleCertIDFN)] = MaleCertID;
                    drAry[0][LibraryMOD.GetFieldName(FemaleCertIDFN)] = FemaleCertID;
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
    public int CommitCertificate()
    {
        //CommitCertificate= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daCertificate.Update(dsCertificate, TableName);
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
            FindInMultiPKey(CertificateID);
            if ((CertificateDataRow != null))
            {
                CertificateDataRow.Delete();
                CommitCertificate();
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
            if (CertificateDataRow[LibraryMOD.GetFieldName(CertificateIDFN)] == System.DBNull.Value)
            {
                CertificateID = 0;
            }
            else
            {
                CertificateID = (int)CertificateDataRow[LibraryMOD.GetFieldName(CertificateIDFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(DescEnFN)] == System.DBNull.Value)
            {
                DescEn = "";
            }
            else
            {
                DescEn = (string)CertificateDataRow[LibraryMOD.GetFieldName(DescEnFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(DescArFN)] == System.DBNull.Value)
            {
                DescAr = "";
            }
            else
            {
                DescAr = (string)CertificateDataRow[LibraryMOD.GetFieldName(DescArFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(MaxScoreFN)] == System.DBNull.Value)
            {
                MaxScore = 0;
            }
            else
            {
                MaxScore = (decimal)CertificateDataRow[LibraryMOD.GetFieldName(MaxScoreFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(MinScoreFN)] == System.DBNull.Value)
            {
                MinScore = 0;
            }
            else
            {
                MinScore = (decimal)CertificateDataRow[LibraryMOD.GetFieldName(MinScoreFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(PassScoreFN)] == System.DBNull.Value)
            {
                PassScore = 0;
            }
            else
            {
                PassScore = (decimal)CertificateDataRow[LibraryMOD.GetFieldName(PassScoreFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(AliasCertFN)] == System.DBNull.Value)
            {
                AliasCert = "";
            }
            else
            {
                AliasCert = (string)CertificateDataRow[LibraryMOD.GetFieldName(AliasCertFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(MaleCertIDFN)] == System.DBNull.Value)
            {
                MaleCertID = 0;
            }
            else
            {
                MaleCertID = (int)CertificateDataRow[LibraryMOD.GetFieldName(MaleCertIDFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(FemaleCertIDFN)] == System.DBNull.Value)
            {
                FemaleCertID = 0;
            }
            else
            {
                FemaleCertID = (int)CertificateDataRow[LibraryMOD.GetFieldName(FemaleCertIDFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)CertificateDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)CertificateDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)CertificateDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)CertificateDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)CertificateDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (CertificateDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)CertificateDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKCertificateID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKCertificateID;
            CertificateDataRow = dsCertificate.Tables[TableName].Rows.Find(findTheseVals);
            if ((CertificateDataRow != null))
            {
                lngCurRow = dsCertificate.Tables[TableName].Rows.IndexOf(CertificateDataRow);
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
            lngCurRow = dsCertificate.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsCertificate.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsCertificate.Tables[TableName].Rows.Count > 0)
            {
                CertificateDataRow = dsCertificate.Tables[TableName].Rows[lngCurRow];
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
            daCertificate.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCertificate.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daCertificate.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCertificate.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
