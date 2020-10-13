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
public class EctNewCity
{
    //Creation Date: 22/03/2010 08:49:38 م
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_CityID;
    private int m_CountryID;
    private string m_CityDescEn;
    private string m_CityDescAr;
    private int m_Area;
    private int m_CityMaleID;
    private int m_CountryMaleID;
    private int m_CityFemaleID;
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
    public int CityID
    {
        get { return m_CityID; }
        set { m_CityID = value; }
    }
    public int CountryID
    {
        get { return m_CountryID; }
        set { m_CountryID = value; }
    }
    public string CityDescEn
    {
        get { return m_CityDescEn; }
        set { m_CityDescEn = value; }
    }
    public string CityDescAr
    {
        get { return m_CityDescAr; }
        set { m_CityDescAr = value; }
    }
    public int Area
    {
        get { return m_Area; }
        set { m_Area = value; }
    }
    public int CityMaleID
    {
        get { return m_CityMaleID; }
        set { m_CityMaleID = value; }
    }
    public int CountryMaleID
    {
        get { return m_CountryMaleID; }
        set { m_CountryMaleID = value; }
    }
    public int CityFemaleID
    {
        get { return m_CityFemaleID; }
        set { m_CityFemaleID = value; }
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
    public EctNewCity()
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
public class EctNewCityDAL : EctNewCity
{
    #region "Decleration"
    private string m_TableName;
    private string m_CityIDFN;
    private string m_CountryIDFN;
    private string m_CityDescEnFN;
    private string m_CityDescArFN;
    private string m_AreaFN;
    private string m_CityMaleIDFN;
    private string m_CountryMaleIDFN;
    private string m_CityFemaleIDFN;
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
    public string CityIDFN
    {
        get { return m_CityIDFN; }
        set { m_CityIDFN = value; }
    }
    public string CountryIDFN
    {
        get { return m_CountryIDFN; }
        set { m_CountryIDFN = value; }
    }
    public string CityDescEnFN
    {
        get { return m_CityDescEnFN; }
        set { m_CityDescEnFN = value; }
    }
    public string CityDescArFN
    {
        get { return m_CityDescArFN; }
        set { m_CityDescArFN = value; }
    }
    public string AreaFN
    {
        get { return m_AreaFN; }
        set { m_AreaFN = value; }
    }
    public string CityMaleIDFN
    {
        get { return m_CityMaleIDFN; }
        set { m_CityMaleIDFN = value; }
    }
    public string CountryMaleIDFN
    {
        get { return m_CountryMaleIDFN; }
        set { m_CountryMaleIDFN = value; }
    }
    public string CityFemaleIDFN
    {
        get { return m_CityFemaleIDFN; }
        set { m_CityFemaleIDFN = value; }
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
    public EctNewCityDAL()
    {
        try
        {
            this.TableName = "Lkp_City";
            this.CityIDFN = m_TableName + ".CityID";
            this.CountryIDFN = m_TableName + ".CountryID";
            this.CityDescEnFN = m_TableName + ".CityDescEn";
            this.CityDescArFN = m_TableName + ".CityDescAr";
            this.AreaFN = m_TableName + ".Area";
            this.CityMaleIDFN = m_TableName + ".CityMaleID";
            this.CountryMaleIDFN = m_TableName + ".CountryMaleID";
            this.CityFemaleIDFN = m_TableName + ".CityFemaleID";
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
            sSQL += CityIDFN;
            sSQL += " , " + CountryIDFN;
            sSQL += " , " + CityDescEnFN;
            sSQL += " , " + CityDescArFN;
            sSQL += " , " + AreaFN;
            sSQL += " , " + CityMaleIDFN;
            sSQL += " , " + CountryMaleIDFN;
            sSQL += " , " + CityFemaleIDFN;
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
            sSQL += CityIDFN;
            sSQL += " , " + CountryIDFN;
            sSQL += " , " + CityDescEnFN;
            sSQL += " , " + CityDescArFN;
            sSQL += " , " + AreaFN;
            sSQL += " , " + CityMaleIDFN;
            sSQL += " , " + CountryMaleIDFN;
            sSQL += " , " + CityFemaleIDFN;
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
            sSQL += LibraryMOD.GetFieldName(CityIDFN) + "=@CityID";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryIDFN) + "=@CountryID";
            sSQL += " , " + LibraryMOD.GetFieldName(CityDescEnFN) + "=@CityDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(CityDescArFN) + "=@CityDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(AreaFN) + "=@Area";
            sSQL += " , " + LibraryMOD.GetFieldName(CityMaleIDFN) + "=@CityMaleID";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryMaleIDFN) + "=@CountryMaleID";
            sSQL += " , " + LibraryMOD.GetFieldName(CityFemaleIDFN) + "=@CityFemaleID";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryFemaleIDFN) + "=@CountryFemaleID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(CityIDFN) + "=@CityID";
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
            sSQL += LibraryMOD.GetFieldName(CityIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CityDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CityDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AreaFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CityMaleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryMaleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CityFemaleIDFN);
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
            sSQL += " @CityID";
            sSQL += " ,@CountryID";
            sSQL += " ,@CityDescEn";
            sSQL += " ,@CityDescAr";
            sSQL += " ,@Area";
            sSQL += " ,@CityMaleID";
            sSQL += " ,@CountryMaleID";
            sSQL += " ,@CityFemaleID";
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
            sSQL += LibraryMOD.GetFieldName(CityIDFN) + "=@CityID";
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
    public List<EctNewCity> GetCity(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the City
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
        List<EctNewCity> results = new List<EctNewCity>();
        try
        {
            //Default Value
            EctNewCity myCity = new EctNewCity();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCity.CityID = 0;
                myCity.CountryID = 0;
                results.Add(myCity);
            }
            while (reader.Read())
            {
                myCity = new EctNewCity();
                if (reader[LibraryMOD.GetFieldName(CityIDFN)].Equals(DBNull.Value))
                {
                    myCity.CityID = 0;
                }
                else
                {
                    myCity.CityID = int.Parse(reader[LibraryMOD.GetFieldName(CityIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CountryIDFN)].Equals(DBNull.Value))
                {
                    myCity.CountryID = 0;
                }
                else
                {
                    myCity.CountryID = int.Parse(reader[LibraryMOD.GetFieldName(CountryIDFN)].ToString());
                }
                myCity.CityDescEn = reader[LibraryMOD.GetFieldName(CityDescEnFN)].ToString();
                myCity.CityDescAr = reader[LibraryMOD.GetFieldName(CityDescArFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(AreaFN)].Equals(DBNull.Value))
                {
                    myCity.Area = 0;
                }
                else
                {
                    myCity.Area = int.Parse(reader[LibraryMOD.GetFieldName(AreaFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CityMaleIDFN)].Equals(DBNull.Value))
                {
                    myCity.CityMaleID = 0;
                }
                else
                {
                    myCity.CityMaleID = int.Parse(reader[LibraryMOD.GetFieldName(CityMaleIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CountryMaleIDFN)].Equals(DBNull.Value))
                {
                    myCity.CountryMaleID = 0;
                }
                else
                {
                    myCity.CountryMaleID = int.Parse(reader[LibraryMOD.GetFieldName(CountryMaleIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CityFemaleIDFN)].Equals(DBNull.Value))
                {
                    myCity.CityFemaleID = 0;
                }
                else
                {
                    myCity.CityFemaleID = int.Parse(reader[LibraryMOD.GetFieldName(CityFemaleIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CountryFemaleIDFN)].Equals(DBNull.Value))
                {
                    myCity.CountryFemaleID = 0;
                }
                else
                {
                    myCity.CountryFemaleID = int.Parse(reader[LibraryMOD.GetFieldName(CountryFemaleIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myCity.CreationUserID = 0;
                }
                else
                {
                    myCity.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myCity.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myCity.LastUpdateUserID = 0;
                }
                else
                {
                    myCity.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myCity.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myCity.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myCity.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(myCity);
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
    public int UpdateCity(InitializeModule.EnumCampus Campus, int iMode, int CityID, int CountryID, string CityDescEn, string CityDescAr, int Area, int CityMaleID, int CountryMaleID, int CityFemaleID, int CountryFemaleID, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            EctNewCity theCity = new EctNewCity();
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
            Cmd.Parameters.Add(new SqlParameter("@CityID", CityID));
            Cmd.Parameters.Add(new SqlParameter("@CountryID", CountryID));
            Cmd.Parameters.Add(new SqlParameter("@CityDescEn", CityDescEn));
            Cmd.Parameters.Add(new SqlParameter("@CityDescAr", CityDescAr));
            Cmd.Parameters.Add(new SqlParameter("@Area", Area));
            Cmd.Parameters.Add(new SqlParameter("@CityMaleID", CityMaleID));
            Cmd.Parameters.Add(new SqlParameter("@CountryMaleID", CountryMaleID));
            Cmd.Parameters.Add(new SqlParameter("@CityFemaleID", CityFemaleID));
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
    public int DeleteCity(InitializeModule.EnumCampus Campus, string CityID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@CityID", CityID));
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
        DataTable dt = new DataTable("City");
        DataView dv = new DataView();
        List<EctNewCity> myCitys = new List<EctNewCity>();
        try
        {
            myCitys = GetCity(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("CityID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("CountryID", Type.GetType("int"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("CityDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myCitys.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myCitys[i].CityID;
                dr[2] = myCitys[i].CountryID;
                dr[3] = myCitys[i].CityDescEn;
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
            myCitys.Clear();
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
            sSQL += CityIDFN;
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
public class EctNewCityCls : EctNewCityDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daCity;
    private DataSet m_dsCity;
    public DataRow CityDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsCity
    {
        get { return m_dsCity; }
        set { m_dsCity = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public EctNewCityCls()
    {
        try
        {
            dsCity = new DataSet();

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
    public virtual SqlDataAdapter GetCityDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daCity = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCity);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daCity.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCity;
    }
    public virtual SqlDataAdapter GetCityDataAdapter(SqlConnection con)
    {
        try
        {
            daCity = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daCity.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdCity;
            cmdCity = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@CityID", SqlDbType.Int, 4, "CityID" );
            daCity.SelectCommand = cmdCity;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdCity = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
           
            cmdCity.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            cmdCity.Parameters.Add("@CityDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(CityDescEnFN));
            cmdCity.Parameters.Add("@CityDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(CityDescArFN));
            cmdCity.Parameters.Add("@Area", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AreaFN));
            cmdCity.Parameters.Add("@CityMaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CityMaleIDFN));
            cmdCity.Parameters.Add("@CountryMaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryMaleIDFN));
            cmdCity.Parameters.Add("@CityFemaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CityFemaleIDFN));
            cmdCity.Parameters.Add("@CountryFemaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryFemaleIDFN));
            cmdCity.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdCity.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdCity.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdCity.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdCity.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdCity.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdCity.Parameters.Add("@CityID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CityIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daCity.UpdateCommand = cmdCity;
            daCity.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdCity = new SqlCommand(GetInsertCommand(), con);
            cmdCity.Parameters.Add("@CityID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CityIDFN));
            cmdCity.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            cmdCity.Parameters.Add("@CityDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(CityDescEnFN));
            cmdCity.Parameters.Add("@CityDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(CityDescArFN));
            cmdCity.Parameters.Add("@Area", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AreaFN));
            cmdCity.Parameters.Add("@CityMaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CityMaleIDFN));
            cmdCity.Parameters.Add("@CountryMaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryMaleIDFN));
            cmdCity.Parameters.Add("@CityFemaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CityFemaleIDFN));
            cmdCity.Parameters.Add("@CountryFemaleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryFemaleIDFN));
            cmdCity.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdCity.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdCity.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdCity.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdCity.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdCity.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daCity.InsertCommand = cmdCity;
            daCity.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdCity = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdCity.Parameters.Add("@CityID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CityIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daCity.DeleteCommand = cmdCity;
            daCity.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daCity.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCity;
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
                    dr = dsCity.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(CityIDFN)] = CityID;
                    dr[LibraryMOD.GetFieldName(CountryIDFN)] = CountryID;
                    dr[LibraryMOD.GetFieldName(CityDescEnFN)] = CityDescEn;
                    dr[LibraryMOD.GetFieldName(CityDescArFN)] = CityDescAr;
                    dr[LibraryMOD.GetFieldName(AreaFN)] = Area;
                    dr[LibraryMOD.GetFieldName(CityMaleIDFN)] = CityMaleID;
                    dr[LibraryMOD.GetFieldName(CountryMaleIDFN)] = CountryMaleID;
                    dr[LibraryMOD.GetFieldName(CityFemaleIDFN)] = CityFemaleID;
                    dr[LibraryMOD.GetFieldName(CountryFemaleIDFN)] = CountryFemaleID;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = ECTGlobalDll.InitializeModule.gNetUserName;
                    dsCity.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsCity.Tables[TableName].Select(LibraryMOD.GetFieldName(CityIDFN) + "=" + CityID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(CityIDFN)] = CityID;
                    drAry[0][LibraryMOD.GetFieldName(CountryIDFN)] = CountryID;
                    drAry[0][LibraryMOD.GetFieldName(CityDescEnFN)] = CityDescEn;
                    drAry[0][LibraryMOD.GetFieldName(CityDescArFN)] = CityDescAr;
                    drAry[0][LibraryMOD.GetFieldName(AreaFN)] = Area;
                    drAry[0][LibraryMOD.GetFieldName(CityMaleIDFN)] = CityMaleID;
                    drAry[0][LibraryMOD.GetFieldName(CountryMaleIDFN)] = CountryMaleID;
                    drAry[0][LibraryMOD.GetFieldName(CityFemaleIDFN)] = CityFemaleID;
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
    public int CommitCity()
    {
        //CommitCity= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daCity.Update(dsCity, TableName);
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
            FindInMultiPKey(CityID);
            if ((CityDataRow != null))
            {
                CityDataRow.Delete();
                CommitCity();
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
            if (CityDataRow[LibraryMOD.GetFieldName(CityIDFN)] == System.DBNull.Value)
            {
                CityID = 0;
            }
            else
            {
                CityID = (int)CityDataRow[LibraryMOD.GetFieldName(CityIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CountryIDFN)] == System.DBNull.Value)
            {
                CountryID = 0;
            }
            else
            {
                CountryID = (int)CityDataRow[LibraryMOD.GetFieldName(CountryIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CityDescEnFN)] == System.DBNull.Value)
            {
                CityDescEn = "";
            }
            else
            {
                CityDescEn = (string)CityDataRow[LibraryMOD.GetFieldName(CityDescEnFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CityDescArFN)] == System.DBNull.Value)
            {
                CityDescAr = "";
            }
            else
            {
                CityDescAr = (string)CityDataRow[LibraryMOD.GetFieldName(CityDescArFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(AreaFN)] == System.DBNull.Value)
            {
                Area = 0;
            }
            else
            {
                Area = (int)CityDataRow[LibraryMOD.GetFieldName(AreaFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CityMaleIDFN)] == System.DBNull.Value)
            {
                CityMaleID = 0;
            }
            else
            {
                CityMaleID = (int)CityDataRow[LibraryMOD.GetFieldName(CityMaleIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CountryMaleIDFN)] == System.DBNull.Value)
            {
                CountryMaleID = 0;
            }
            else
            {
                CountryMaleID = (int)CityDataRow[LibraryMOD.GetFieldName(CountryMaleIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CityFemaleIDFN)] == System.DBNull.Value)
            {
                CityFemaleID = 0;
            }
            else
            {
                CityFemaleID = (int)CityDataRow[LibraryMOD.GetFieldName(CityFemaleIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CountryFemaleIDFN)] == System.DBNull.Value)
            {
                CountryFemaleID = 0;
            }
            else
            {
                CountryFemaleID = (int)CityDataRow[LibraryMOD.GetFieldName(CountryFemaleIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)CityDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)CityDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)CityDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)CityDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)CityDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (CityDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)CityDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKCityID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKCityID;
            CityDataRow = dsCity.Tables[TableName].Rows.Find(findTheseVals);
            if ((CityDataRow != null))
            {
                lngCurRow = dsCity.Tables[TableName].Rows.IndexOf(CityDataRow);
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
            lngCurRow = dsCity.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsCity.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsCity.Tables[TableName].Rows.Count > 0)
            {
                CityDataRow = dsCity.Tables[TableName].Rows[lngCurRow];
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
            daCity.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCity.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daCity.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCity.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
