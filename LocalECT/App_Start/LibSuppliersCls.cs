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
public class LibSuppliers
{
    //Creation Date: 25/01/2011 20:00:12
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_SupplierID;
    private string m_strSupplierAr;
    private string m_strSupplierEn;
    private int m_CountryID;
    private string m_strAddress;
    private int m_PoBox;
    private string m_Fax;
    private string m_Phone;
    private string m_Email;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int SupplierID
    {
        get { return m_SupplierID; }
        set { m_SupplierID = value; }
    }
    public string strSupplierAr
    {
        get { return m_strSupplierAr; }
        set { m_strSupplierAr = value; }
    }
    public string strSupplierEn
    {
        get { return m_strSupplierEn; }
        set { m_strSupplierEn = value; }
    }
    public int CountryID
    {
        get { return m_CountryID; }
        set { m_CountryID = value; }
    }
    public string strAddress
    {
        get { return m_strAddress; }
        set { m_strAddress = value; }
    }
    public int PoBox
    {
        get { return m_PoBox; }
        set { m_PoBox = value; }
    }
    public string Fax
    {
        get { return m_Fax; }
        set { m_Fax = value; }
    }
    public string Phone
    {
        get { return m_Phone; }
        set { m_Phone = value; }
    }
    public string Email
    {
        get { return m_Email; }
        set { m_Email = value; }
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
    public LibSuppliers()
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
public class LibSuppliersDAL : LibSuppliers
{
    #region "Decleration"
    private string m_TableName;
    private string m_SupplierIDFN;
    private string m_strSupplierArFN;
    private string m_strSupplierEnFN;
    private string m_CountryIDFN;
    private string m_strAddressFN;
    private string m_PoBoxFN;
    private string m_FaxFN;
    private string m_PhoneFN;
    private string m_EmailFN;
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
    public string SupplierIDFN
    {
        get { return m_SupplierIDFN; }
        set { m_SupplierIDFN = value; }
    }
    public string strSupplierArFN
    {
        get { return m_strSupplierArFN; }
        set { m_strSupplierArFN = value; }
    }
    public string strSupplierEnFN
    {
        get { return m_strSupplierEnFN; }
        set { m_strSupplierEnFN = value; }
    }
    public string CountryIDFN
    {
        get { return m_CountryIDFN; }
        set { m_CountryIDFN = value; }
    }
    public string strAddressFN
    {
        get { return m_strAddressFN; }
        set { m_strAddressFN = value; }
    }
    public string PoBoxFN
    {
        get { return m_PoBoxFN; }
        set { m_PoBoxFN = value; }
    }
    public string FaxFN
    {
        get { return m_FaxFN; }
        set { m_FaxFN = value; }
    }
    public string PhoneFN
    {
        get { return m_PhoneFN; }
        set { m_PhoneFN = value; }
    }
    public string EmailFN
    {
        get { return m_EmailFN; }
        set { m_EmailFN = value; }
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
    public LibSuppliersDAL()
    {
        try
        {
            this.TableName = "LibSuppliers";
            this.SupplierIDFN = m_TableName + ".SupplierID";
            this.strSupplierArFN = m_TableName + ".strSupplierAr";
            this.strSupplierEnFN = m_TableName + ".strSupplierEn";
            this.CountryIDFN = m_TableName + ".CountryID";
            this.strAddressFN = m_TableName + ".strAddress";
            this.PoBoxFN = m_TableName + ".PoBox";
            this.FaxFN = m_TableName + ".Fax";
            this.PhoneFN = m_TableName + ".Phone";
            this.EmailFN = m_TableName + ".Email";
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
            sSQL += SupplierIDFN;
            sSQL += " , " + strSupplierArFN;
            sSQL += " , " + strSupplierEnFN;
            sSQL += " , " + CountryIDFN;
            sSQL += " , " + strAddressFN;
            sSQL += " , " + PoBoxFN;
            sSQL += " , " + FaxFN;
            sSQL += " , " + PhoneFN;
            sSQL += " , " + EmailFN;
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
    //-----GetListSQl Function ---------------------------------
    public string GetListSQL(string sCondition)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += SupplierIDFN;
            sSQL += " , " + strSupplierArFN;
            sSQL += " , " + strSupplierEnFN;
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
            sSQL += SupplierIDFN;
            sSQL += " , " + strSupplierArFN;
            sSQL += " , " + strSupplierEnFN;
            sSQL += " , " + CountryIDFN;
            sSQL += " , " + strAddressFN;
            sSQL += " , " + PoBoxFN;
            sSQL += " , " + FaxFN;
            sSQL += " , " + PhoneFN;
            sSQL += " , " + EmailFN;
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
            sSQL += LibraryMOD.GetFieldName(SupplierIDFN) + "=@SupplierID";
            sSQL += " , " + LibraryMOD.GetFieldName(strSupplierArFN) + "=@strSupplierAr";
            sSQL += " , " + LibraryMOD.GetFieldName(strSupplierEnFN) + "=@strSupplierEn";
            sSQL += " , " + LibraryMOD.GetFieldName(CountryIDFN) + "=@CountryID";
            sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN) + "=@strAddress";
            sSQL += " , " + LibraryMOD.GetFieldName(PoBoxFN) + "=@PoBox";
            sSQL += " , " + LibraryMOD.GetFieldName(FaxFN) + "=@Fax";
            sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN) + "=@Phone";
            sSQL += " , " + LibraryMOD.GetFieldName(EmailFN) + "=@Email";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(SupplierIDFN) + "=@SupplierID";
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
            sSQL += LibraryMOD.GetFieldName(SupplierIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSupplierArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSupplierEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CountryIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PoBoxFN);
            sSQL += " , " + LibraryMOD.GetFieldName(FaxFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN);
            sSQL += " , " + LibraryMOD.GetFieldName(EmailFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @SupplierID";
            sSQL += " ,@strSupplierAr";
            sSQL += " ,@strSupplierEn";
            sSQL += " ,@CountryID";
            sSQL += " ,@strAddress";
            sSQL += " ,@PoBox";
            sSQL += " ,@Fax";
            sSQL += " ,@Phone";
            sSQL += " ,@Email";
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
            sSQL += LibraryMOD.GetFieldName(SupplierIDFN) + "=@SupplierID";
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
    public List<LibSuppliers> GetLibSuppliers(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibSuppliers
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
        List<LibSuppliers> results = new List<LibSuppliers>();
        try
        {
            //Default Value
            LibSuppliers myLibSuppliers = new LibSuppliers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibSuppliers.SupplierID = 0;
                results.Add(myLibSuppliers);
            }
            while (reader.Read())
            {
                myLibSuppliers = new LibSuppliers();
                if (reader[LibraryMOD.GetFieldName(SupplierIDFN)].Equals(DBNull.Value))
                {
                    myLibSuppliers.SupplierID = 0;
                }
                else
                {
                    myLibSuppliers.SupplierID = int.Parse(reader[LibraryMOD.GetFieldName(SupplierIDFN)].ToString());
                }
                myLibSuppliers.strSupplierAr = reader[LibraryMOD.GetFieldName(strSupplierArFN)].ToString();
                myLibSuppliers.strSupplierEn = reader[LibraryMOD.GetFieldName(strSupplierEnFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(CountryIDFN)].Equals(DBNull.Value))
                {
                    myLibSuppliers.CountryID = 0;
                }
                else
                {
                    myLibSuppliers.CountryID = int.Parse(reader[LibraryMOD.GetFieldName(CountryIDFN)].ToString());
                }
                myLibSuppliers.strAddress = reader[LibraryMOD.GetFieldName(strAddressFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(PoBoxFN)].Equals(DBNull.Value))
                {
                    myLibSuppliers.PoBox = 0;
                }
                else
                {
                    myLibSuppliers.PoBox = int.Parse(reader[LibraryMOD.GetFieldName(PoBoxFN)].ToString());
                }
                myLibSuppliers.Fax = reader[LibraryMOD.GetFieldName(FaxFN)].ToString();
                myLibSuppliers.Phone = reader[LibraryMOD.GetFieldName(PhoneFN)].ToString();
                myLibSuppliers.Email = reader[LibraryMOD.GetFieldName(EmailFN)].ToString();
                myLibSuppliers.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myLibSuppliers.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myLibSuppliers.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myLibSuppliers.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myLibSuppliers.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myLibSuppliers.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myLibSuppliers);
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
    public List<LibSuppliers> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibSuppliers> results = new List<LibSuppliers>();
        try
        {
            //Default Value
            LibSuppliers myLibSuppliers = new LibSuppliers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibSuppliers.SupplierID = -1;
                myLibSuppliers.strSupplierAr = "Select LibSuppliers";
                results.Add(myLibSuppliers);
            }
            while (reader.Read())
            {
                myLibSuppliers = new LibSuppliers();
                if (reader[LibraryMOD.GetFieldName(SupplierIDFN)].Equals(DBNull.Value))
                {
                    myLibSuppliers.SupplierID = 0;
                }
                else
                {
                    myLibSuppliers.SupplierID = int.Parse(reader[LibraryMOD.GetFieldName(SupplierIDFN)].ToString());
                }
                myLibSuppliers.strSupplierAr = reader[LibraryMOD.GetFieldName(strSupplierArFN)].ToString();
                myLibSuppliers.strSupplierEn = reader[LibraryMOD.GetFieldName(strSupplierEnFN)].ToString();
                results.Add(myLibSuppliers);
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
    public int UpdateLibSuppliers(InitializeModule.EnumCampus Campus, int iMode, int SupplierID, string strSupplierAr, string strSupplierEn, int CountryID, string strAddress, int PoBox, string Fax, string Phone, string Email, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibSuppliers theLibSuppliers = new LibSuppliers();
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
            Cmd.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));
            Cmd.Parameters.Add(new SqlParameter("@strSupplierAr", strSupplierAr));
            Cmd.Parameters.Add(new SqlParameter("@strSupplierEn", strSupplierEn));
            if (CountryID != -1)
                Cmd.Parameters.Add(new SqlParameter("@CountryID", CountryID));
            else
                Cmd.Parameters.AddWithValue("@CountryID", DBNull.Value);
            Cmd.Parameters.Add(new SqlParameter("@strAddress", strAddress));
            Cmd.Parameters.Add(new SqlParameter("@PoBox", PoBox));
            Cmd.Parameters.Add(new SqlParameter("@Fax", Fax));
            Cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
            Cmd.Parameters.Add(new SqlParameter("@Email", Email));
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
    public int DeleteLibSuppliers(InitializeModule.EnumCampus Campus, string SupplierID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));
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
        DataTable dt = new DataTable("LibSuppliers");
        DataView dv = new DataView();
        List<LibSuppliers> myLibSupplierss = new List<LibSuppliers>();
        try
        {
            myLibSupplierss = GetLibSuppliers(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("SupplierID", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myLibSupplierss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibSupplierss[i].SupplierID;
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
            myLibSupplierss.Clear();
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
            sSQL += SupplierIDFN;
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
public class LibSuppliersCls : LibSuppliersDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibSuppliers;
    private DataSet m_dsLibSuppliers;
    public DataRow LibSuppliersDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibSuppliers
    {
        get { return m_dsLibSuppliers; }
        set { m_dsLibSuppliers = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibSuppliersCls()
    {
        try
        {
            dsLibSuppliers = new DataSet();

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
    public virtual SqlDataAdapter GetLibSuppliersDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibSuppliers = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibSuppliers);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibSuppliers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibSuppliers;
    }
    public virtual SqlDataAdapter GetLibSuppliersDataAdapter(SqlConnection con)
    {
        try
        {
            daLibSuppliers = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibSuppliers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibSuppliers;
            cmdLibSuppliers = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@SupplierID", SqlDbType.Int, 4, "SupplierID" );
            daLibSuppliers.SelectCommand = cmdLibSuppliers;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibSuppliers = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibSuppliers.Parameters.Add("@SupplierID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SupplierIDFN));
            cmdLibSuppliers.Parameters.Add("@strSupplierAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSupplierArFN));
            cmdLibSuppliers.Parameters.Add("@strSupplierEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSupplierEnFN));
            cmdLibSuppliers.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            cmdLibSuppliers.Parameters.Add("@strAddress", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strAddressFN));
            cmdLibSuppliers.Parameters.Add("@PoBox", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PoBoxFN));
            cmdLibSuppliers.Parameters.Add("@Fax", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(FaxFN));
            cmdLibSuppliers.Parameters.Add("@Phone", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PhoneFN));
            cmdLibSuppliers.Parameters.Add("@Email", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(EmailFN));
            cmdLibSuppliers.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibSuppliers.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibSuppliers.Parameters.Add("@strUserSave", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibSuppliers.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibSuppliers.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibSuppliers.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdLibSuppliers.Parameters.Add("@SupplierID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SupplierIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibSuppliers.UpdateCommand = cmdLibSuppliers;
            daLibSuppliers.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibSuppliers = new SqlCommand(GetInsertCommand(), con);
            cmdLibSuppliers.Parameters.Add("@SupplierID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SupplierIDFN));
            cmdLibSuppliers.Parameters.Add("@strSupplierAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSupplierArFN));
            cmdLibSuppliers.Parameters.Add("@strSupplierEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSupplierEnFN));
            cmdLibSuppliers.Parameters.Add("@CountryID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CountryIDFN));
            cmdLibSuppliers.Parameters.Add("@strAddress", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strAddressFN));
            cmdLibSuppliers.Parameters.Add("@PoBox", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PoBoxFN));
            cmdLibSuppliers.Parameters.Add("@Fax", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(FaxFN));
            cmdLibSuppliers.Parameters.Add("@Phone", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PhoneFN));
            cmdLibSuppliers.Parameters.Add("@Email", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(EmailFN));
            cmdLibSuppliers.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibSuppliers.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibSuppliers.Parameters.Add("@strUserSave", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibSuppliers.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibSuppliers.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibSuppliers.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibSuppliers.InsertCommand = cmdLibSuppliers;
            daLibSuppliers.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibSuppliers = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibSuppliers.Parameters.Add("@SupplierID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SupplierIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibSuppliers.DeleteCommand = cmdLibSuppliers;
            daLibSuppliers.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibSuppliers.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibSuppliers;
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
                    dr = dsLibSuppliers.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(SupplierIDFN)] = SupplierID;
                    dr[LibraryMOD.GetFieldName(strSupplierArFN)] = strSupplierAr;
                    dr[LibraryMOD.GetFieldName(strSupplierEnFN)] = strSupplierEn;
                    dr[LibraryMOD.GetFieldName(CountryIDFN)] = CountryID;
                    dr[LibraryMOD.GetFieldName(strAddressFN)] = strAddress;
                    dr[LibraryMOD.GetFieldName(PoBoxFN)] = PoBox;
                    dr[LibraryMOD.GetFieldName(FaxFN)] = Fax;
                    dr[LibraryMOD.GetFieldName(PhoneFN)] = Phone;
                    dr[LibraryMOD.GetFieldName(EmailFN)] = Email;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsLibSuppliers.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibSuppliers.Tables[TableName].Select(LibraryMOD.GetFieldName(SupplierIDFN) + "=" + SupplierID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(SupplierIDFN)] = SupplierID;
                    drAry[0][LibraryMOD.GetFieldName(strSupplierArFN)] = strSupplierAr;
                    drAry[0][LibraryMOD.GetFieldName(strSupplierEnFN)] = strSupplierEn;
                    drAry[0][LibraryMOD.GetFieldName(CountryIDFN)] = CountryID;
                    drAry[0][LibraryMOD.GetFieldName(strAddressFN)] = strAddress;
                    drAry[0][LibraryMOD.GetFieldName(PoBoxFN)] = PoBox;
                    drAry[0][LibraryMOD.GetFieldName(FaxFN)] = Fax;
                    drAry[0][LibraryMOD.GetFieldName(PhoneFN)] = Phone;
                    drAry[0][LibraryMOD.GetFieldName(EmailFN)] = Email;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
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
    public int CommitLibSuppliers()
    {
        //CommitLibSuppliers= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibSuppliers.Update(dsLibSuppliers, TableName);
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
            FindInMultiPKey(SupplierID);
            if ((LibSuppliersDataRow != null))
            {
                LibSuppliersDataRow.Delete();
                CommitLibSuppliers();
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
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(SupplierIDFN)] == System.DBNull.Value)
            {
                SupplierID = 0;
            }
            else
            {
                SupplierID = (int)LibSuppliersDataRow[LibraryMOD.GetFieldName(SupplierIDFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(strSupplierArFN)] == System.DBNull.Value)
            {
                strSupplierAr = "";
            }
            else
            {
                strSupplierAr = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(strSupplierArFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(strSupplierEnFN)] == System.DBNull.Value)
            {
                strSupplierEn = "";
            }
            else
            {
                strSupplierEn = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(strSupplierEnFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(CountryIDFN)] == System.DBNull.Value)
            {
                CountryID = 0;
            }
            else
            {
                CountryID = (int)LibSuppliersDataRow[LibraryMOD.GetFieldName(CountryIDFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(strAddressFN)] == System.DBNull.Value)
            {
                strAddress = "";
            }
            else
            {
                strAddress = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(strAddressFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(PoBoxFN)] == System.DBNull.Value)
            {
                PoBox = 0;
            }
            else
            {
                PoBox = (int)LibSuppliersDataRow[LibraryMOD.GetFieldName(PoBoxFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(FaxFN)] == System.DBNull.Value)
            {
                Fax = "";
            }
            else
            {
                Fax = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(FaxFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(PhoneFN)] == System.DBNull.Value)
            {
                Phone = "";
            }
            else
            {
                Phone = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(PhoneFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(EmailFN)] == System.DBNull.Value)
            {
                Email = "";
            }
            else
            {
                Email = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(EmailFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)LibSuppliersDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)LibSuppliersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (LibSuppliersDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)LibSuppliersDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKSupplierID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKSupplierID;
            LibSuppliersDataRow = dsLibSuppliers.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibSuppliersDataRow != null))
            {
                lngCurRow = dsLibSuppliers.Tables[TableName].Rows.IndexOf(LibSuppliersDataRow);
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
            lngCurRow = dsLibSuppliers.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibSuppliers.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibSuppliers.Tables[TableName].Rows.Count > 0)
            {
                LibSuppliersDataRow = dsLibSuppliers.Tables[TableName].Rows[lngCurRow];
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
            daLibSuppliers.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibSuppliers.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibSuppliers.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibSuppliers.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
