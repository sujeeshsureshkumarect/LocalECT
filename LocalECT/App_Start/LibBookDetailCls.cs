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
public class LibBookDetail
{
    //Creation Date: 24/01/2011 4:22:13 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_AccesstionNo;
    private int m_BookID;
    private double m_BookPrice;
    private int m_BookStatusID;
    private int m_OwnTypeID;
    private string m_strInvoiceNo;
    private string m_strBarcode;
    private string m_strEncode;
    private int m_CampusID;
    private string m_strRemark;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int AccesstionNo
    {
        get { return m_AccesstionNo; }
        set { m_AccesstionNo = value; }
    }
    public int BookID
    {
        get { return m_BookID; }
        set { m_BookID = value; }
    }
    public double BookPrice
    {
        get { return m_BookPrice; }
        set { m_BookPrice = value; }
    }
    public int BookStatusID
    {
        get { return m_BookStatusID; }
        set { m_BookStatusID = value; }
    }
    public int OwnTypeID
    {
        get { return m_OwnTypeID; }
        set { m_OwnTypeID = value; }
    }
    public string strInvoiceNo
    {
        get { return m_strInvoiceNo; }
        set { m_strInvoiceNo = value; }
    }
    public string strBarcode
    {
        get { return m_strBarcode; }
        set { m_strBarcode = value; }
    }
    public string strEncode
    {
        get { return m_strEncode; }
        set { m_strEncode = value; }
    }
    public int CampusID
    {
        get { return m_CampusID; }
        set { m_CampusID = value; }
    }
    public string strRemark
    {
        get { return m_strRemark; }
        set { m_strRemark = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibBookDetail()
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
public class LibBookDetailDAL : LibBookDetail
{
    #region "Decleration"
    private string m_TableName;
    private string m_AccesstionNoFN;
    private string m_BookIDFN;
    private string m_BookPriceFN;
    private string m_BookStatusIDFN;
    private string m_OwnTypeIDFN;
    private string m_strInvoiceNoFN;
    private string m_strBarcodeFN;
    private string m_strEncodeFN;
    private string m_CampusIDFN;
    private string m_strRemarkFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string AccesstionNoFN
    {
        get { return m_AccesstionNoFN; }
        set { m_AccesstionNoFN = value; }
    }
    public string BookIDFN
    {
        get { return m_BookIDFN; }
        set { m_BookIDFN = value; }
    }
    public string BookPriceFN
    {
        get { return m_BookPriceFN; }
        set { m_BookPriceFN = value; }
    }
    public string BookStatusIDFN
    {
        get { return m_BookStatusIDFN; }
        set { m_BookStatusIDFN = value; }
    }
    public string OwnTypeIDFN
    {
        get { return m_OwnTypeIDFN; }
        set { m_OwnTypeIDFN = value; }
    }
    public string strInvoiceNoFN
    {
        get { return m_strInvoiceNoFN; }
        set { m_strInvoiceNoFN = value; }
    }
    public string strBarcodeFN
    {
        get { return m_strBarcodeFN; }
        set { m_strBarcodeFN = value; }
    }
    public string strEncodeFN
    {
        get { return m_strEncodeFN; }
        set { m_strEncodeFN = value; }
    }
    public string CampusIDFN
    {
        get { return m_CampusIDFN; }
        set { m_CampusIDFN = value; }
    }
    public string strRemarkFN
    {
        get { return m_strRemarkFN; }
        set { m_strRemarkFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibBookDetailDAL()
    {
        try
        {
            this.TableName = "LibBookDetail";
            this.AccesstionNoFN = m_TableName + ".AccesstionNo";
            this.BookIDFN = m_TableName + ".BookID";
            this.BookPriceFN = m_TableName + ".BookPrice";
            this.BookStatusIDFN = m_TableName + ".BookStatusID";
            this.OwnTypeIDFN = m_TableName + ".OwnTypeID";
            this.strInvoiceNoFN = m_TableName + ".strInvoiceNo";
            this.strBarcodeFN = m_TableName + ".strBarcode";
            this.strEncodeFN = m_TableName + ".strEncode";
            this.CampusIDFN = m_TableName + ".CampusID";
            this.strRemarkFN = m_TableName + ".strRemark";
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
            sSQL += AccesstionNoFN;
            sSQL += " , " + BookIDFN;
            sSQL += " , " + BookPriceFN;
            sSQL += " , " + BookStatusIDFN;
            sSQL += " , " + OwnTypeIDFN;
            sSQL += " , " + strInvoiceNoFN;
            sSQL += " , " + strBarcodeFN;
            sSQL += " , " + strEncodeFN;
            sSQL += " , " + CampusIDFN;
            sSQL += " , " + strRemarkFN;
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
            sSQL += AccesstionNoFN;
            sSQL += " , " + BookIDFN;
            sSQL += " , " + BookPriceFN;
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
            sSQL += AccesstionNoFN;
            sSQL += " , " + BookIDFN;
            sSQL += " , " + BookPriceFN;
            sSQL += " , " + BookStatusIDFN;
            sSQL += " , " + OwnTypeIDFN;
            sSQL += " , " + strInvoiceNoFN;
            sSQL += " , " + strBarcodeFN;
            sSQL += " , " + strEncodeFN;
            sSQL += " , " + CampusIDFN;
            sSQL += " , " + strRemarkFN;
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
            sSQL += LibraryMOD.GetFieldName(AccesstionNoFN) + "=@AccesstionNo";
            sSQL += " , " + LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " , " + LibraryMOD.GetFieldName(BookPriceFN) + "=@BookPrice";
            sSQL += " , " + LibraryMOD.GetFieldName(BookStatusIDFN) + "=@BookStatusID";
            sSQL += " , " + LibraryMOD.GetFieldName(OwnTypeIDFN) + "=@OwnTypeID";
            sSQL += " , " + LibraryMOD.GetFieldName(strInvoiceNoFN) + "=@strInvoiceNo";
            sSQL += " , " + LibraryMOD.GetFieldName(strBarcodeFN) + "=@strBarcode";
            sSQL += " , " + LibraryMOD.GetFieldName(strEncodeFN) + "=@strEncode";
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN) + "=@CampusID";
            sSQL += " , " + LibraryMOD.GetFieldName(strRemarkFN) + "=@strRemark";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(AccesstionNoFN) + "=@AccesstionNo";
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
            sSQL += LibraryMOD.GetFieldName(AccesstionNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookPriceFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookStatusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(OwnTypeIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strInvoiceNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strBarcodeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strEncodeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strRemarkFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @AccesstionNo";
            sSQL += " ,@BookID";
            sSQL += " ,@BookPrice";
            sSQL += " ,@BookStatusID";
            sSQL += " ,@OwnTypeID";
            sSQL += " ,@strInvoiceNo";
            sSQL += " ,@strBarcode";
            sSQL += " ,@strEncode";
            sSQL += " ,@CampusID";
            sSQL += " ,@strRemark";
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
            sSQL += LibraryMOD.GetFieldName(AccesstionNoFN) + "=@AccesstionNo";
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
    public List<LibBookDetail> GetLibBookDetail(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibBookDetail
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
        List<LibBookDetail> results = new List<LibBookDetail>();
        try
        {
            //Default Value
            LibBookDetail myLibBookDetail = new LibBookDetail();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookDetail.AccesstionNo = 0;
                results.Add(myLibBookDetail);
            }
            while (reader.Read())
            {
                myLibBookDetail = new LibBookDetail();
                if (reader[LibraryMOD.GetFieldName(AccesstionNoFN)].Equals(DBNull.Value))
                {
                    myLibBookDetail.AccesstionNo = 0;
                }
                else
                {
                    myLibBookDetail.AccesstionNo = int.Parse(reader[LibraryMOD.GetFieldName(AccesstionNoFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookDetail.BookID = 0;
                }
                else
                {
                    myLibBookDetail.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookStatusIDFN)].Equals(DBNull.Value))
                {
                    myLibBookDetail.BookStatusID = 0;
                }
                else
                {
                    myLibBookDetail.BookStatusID = int.Parse(reader[LibraryMOD.GetFieldName(BookStatusIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(OwnTypeIDFN)].Equals(DBNull.Value))
                {
                    myLibBookDetail.OwnTypeID = 0;
                }
                else
                {
                    myLibBookDetail.OwnTypeID = int.Parse(reader[LibraryMOD.GetFieldName(OwnTypeIDFN)].ToString());
                }
                myLibBookDetail.strInvoiceNo = reader[LibraryMOD.GetFieldName(strInvoiceNoFN)].ToString();
                myLibBookDetail.strBarcode = reader[LibraryMOD.GetFieldName(strBarcodeFN)].ToString();
                myLibBookDetail.strEncode = reader[LibraryMOD.GetFieldName(strEncodeFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(CampusIDFN)].Equals(DBNull.Value))
                {
                    myLibBookDetail.CampusID = 0;
                }
                else
                {
                    myLibBookDetail.CampusID = int.Parse(reader[LibraryMOD.GetFieldName(CampusIDFN)].ToString());
                }
                myLibBookDetail.strRemark = reader[LibraryMOD.GetFieldName(strRemarkFN)].ToString();
                results.Add(myLibBookDetail);
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
    public List<LibBookDetail> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibBookDetail> results = new List<LibBookDetail>();
        try
        {
            //Default Value
            LibBookDetail myLibBookDetail = new LibBookDetail();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookDetail.AccesstionNo = -1;
                myLibBookDetail.BookID = -1;
                results.Add(myLibBookDetail);
            }
            while (reader.Read())
            {
                myLibBookDetail = new LibBookDetail();
                if (reader[LibraryMOD.GetFieldName(AccesstionNoFN)].Equals(DBNull.Value))
                {
                    myLibBookDetail.AccesstionNo = 0;
                }
                else
                {
                    myLibBookDetail.AccesstionNo = int.Parse(reader[LibraryMOD.GetFieldName(AccesstionNoFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookDetail.BookID = 0;
                }
                else
                {
                    myLibBookDetail.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                results.Add(myLibBookDetail);
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
    public int UpdateLibBookDetail(InitializeModule.EnumCampus Campus, int iMode, int AccesstionNo, int BookID, double BookPrice, int BookStatusID, int OwnTypeID, string strInvoiceNo, string strBarcode, string strEncode, int CampusID, string strRemark)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibBookDetail theLibBookDetail = new LibBookDetail();
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
            Cmd.Parameters.Add(new SqlParameter("@AccesstionNo", AccesstionNo));
            Cmd.Parameters.Add(new SqlParameter("@BookID", BookID));
            Cmd.Parameters.Add(new SqlParameter("@BookPrice", BookPrice));
            
            if (BookStatusID != -1)
                Cmd.Parameters.Add(new SqlParameter("@BookStatusID", BookStatusID));
            else
                Cmd.Parameters.AddWithValue("@BookStatusID", DBNull.Value);

            if (OwnTypeID != -1)
                Cmd.Parameters.Add(new SqlParameter("@OwnTypeID", OwnTypeID));
            else
                Cmd.Parameters.AddWithValue("@OwnTypeID", DBNull.Value);

            Cmd.Parameters.Add(new SqlParameter("@strInvoiceNo", strInvoiceNo));
            Cmd.Parameters.Add(new SqlParameter("@strBarcode", strBarcode));
            Cmd.Parameters.Add(new SqlParameter("@strEncode", strEncode));
            
            if (CampusID != -1)
                Cmd.Parameters.Add(new SqlParameter("@CampusID", CampusID));
            else
                Cmd.Parameters.AddWithValue("@CampusID", DBNull.Value);

            Cmd.Parameters.Add(new SqlParameter("@strRemark", strRemark));
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
    public int DeleteLibBookDetail(InitializeModule.EnumCampus Campus, string AccesstionNo)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@AccesstionNo", AccesstionNo));
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
        DataTable dt = new DataTable("LibBookDetail");
        DataView dv = new DataView();
        List<LibBookDetail> myLibBookDetails = new List<LibBookDetail>();
        try
        {
            myLibBookDetails = GetLibBookDetail(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("AccesstionNo", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myLibBookDetails.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibBookDetails[i].AccesstionNo;
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
            myLibBookDetails.Clear();
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
            sSQL += AccesstionNoFN;
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
public class LibBookDetailCls : LibBookDetailDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibBookDetail;
    private DataSet m_dsLibBookDetail;
    public DataRow LibBookDetailDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibBookDetail
    {
        get { return m_dsLibBookDetail; }
        set { m_dsLibBookDetail = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibBookDetailCls()
    {
        try
        {
            dsLibBookDetail = new DataSet();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    public int GetBookID(int iAccesstionNo)
    {
        
        int iBookID = 0;
        String sSQL;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
           
            sSQL = "SELECT ";
            sSQL += BookIDFN;
            sSQL += "  FROM " + TableName;
            sSQL += "  WHERE " + AccesstionNoFN + "=" + iAccesstionNo;

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


            if (datReader.Read())
            {
                iBookID = datReader.GetInt32(0);
            }
            datReader.Close();

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
        return iBookID;
    }
    public int GetRecords(string BookID)
    {
        int iTotalRecords=0;
        string sSQL = "";
        DataSet ds=new DataSet ();
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew );
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
           
            sSQL = "SELECT ";
            sSQL += AccesstionNoFN ;
            sSQL += "  FROM " +  TableName;
            sSQL += "  WHERE " + BookIDFN  + "='" + BookID + "'";

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
          
            
            SqlDataAdapter adapter = new SqlDataAdapter(sSQL, Conn );
            adapter.Fill(ds);
            
            iTotalRecords = ds.Tables[0].Rows.Count; 
         
            
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {

        }
        return iTotalRecords;
    }
    //-------Get DataAdapter  -----------------------------
    #region "DataAdapter"
    public virtual SqlDataAdapter GetLibBookDetailDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibBookDetail = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibBookDetail);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookDetail.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookDetail;
    }
    public virtual SqlDataAdapter GetLibBookDetailDataAdapter(SqlConnection con)
    {
        try
        {
            daLibBookDetail = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookDetail.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibBookDetail;
            cmdLibBookDetail = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@AccesstionNo", SqlDbType.Int, 4, "AccesstionNo" );
            daLibBookDetail.SelectCommand = cmdLibBookDetail;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibBookDetail = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibBookDetail.Parameters.Add("@AccesstionNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AccesstionNoFN));
            cmdLibBookDetail.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookDetail.Parameters.Add("@BookPrice", SqlDbType.Decimal, 12, LibraryMOD.GetFieldName(BookPriceFN));
            cmdLibBookDetail.Parameters.Add("@BookStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(BookStatusIDFN));
            cmdLibBookDetail.Parameters.Add("@OwnTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(OwnTypeIDFN));
            cmdLibBookDetail.Parameters.Add("@strInvoiceNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strInvoiceNoFN));
            cmdLibBookDetail.Parameters.Add("@strBarcode", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBarcodeFN));
            cmdLibBookDetail.Parameters.Add("@strEncode", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strEncodeFN));
            cmdLibBookDetail.Parameters.Add("@CampusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(CampusIDFN));
            cmdLibBookDetail.Parameters.Add("@strRemark", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(strRemarkFN));


            Parmeter = cmdLibBookDetail.Parameters.Add("@AccesstionNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AccesstionNoFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibBookDetail.UpdateCommand = cmdLibBookDetail;
            daLibBookDetail.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibBookDetail = new SqlCommand(GetInsertCommand(), con);
            cmdLibBookDetail.Parameters.Add("@AccesstionNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AccesstionNoFN));
            cmdLibBookDetail.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookDetail.Parameters.Add("@BookPrice", SqlDbType.Decimal, 12, LibraryMOD.GetFieldName(BookPriceFN));
            cmdLibBookDetail.Parameters.Add("@BookStatusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(BookStatusIDFN));
            cmdLibBookDetail.Parameters.Add("@OwnTypeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(OwnTypeIDFN));
            cmdLibBookDetail.Parameters.Add("@strInvoiceNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strInvoiceNoFN));
            cmdLibBookDetail.Parameters.Add("@strBarcode", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strBarcodeFN));
            cmdLibBookDetail.Parameters.Add("@strEncode", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strEncodeFN));
            cmdLibBookDetail.Parameters.Add("@CampusID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(CampusIDFN));
            cmdLibBookDetail.Parameters.Add("@strRemark", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(strRemarkFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibBookDetail.InsertCommand = cmdLibBookDetail;
            daLibBookDetail.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibBookDetail = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibBookDetail.Parameters.Add("@AccesstionNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AccesstionNoFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibBookDetail.DeleteCommand = cmdLibBookDetail;
            daLibBookDetail.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibBookDetail.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookDetail;
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
                    dr = dsLibBookDetail.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(AccesstionNoFN)] = AccesstionNo;
                    dr[LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    dr[LibraryMOD.GetFieldName(BookPriceFN)] = BookPrice;
                    dr[LibraryMOD.GetFieldName(BookStatusIDFN)] = BookStatusID;
                    dr[LibraryMOD.GetFieldName(OwnTypeIDFN)] = OwnTypeID;
                    dr[LibraryMOD.GetFieldName(strInvoiceNoFN)] = strInvoiceNo;
                    dr[LibraryMOD.GetFieldName(strBarcodeFN)] = strBarcode;
                    dr[LibraryMOD.GetFieldName(strEncodeFN)] = strEncode;
                    dr[LibraryMOD.GetFieldName(CampusIDFN)] = CampusID;
                    dr[LibraryMOD.GetFieldName(strRemarkFN)] = strRemark;
                    dsLibBookDetail.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibBookDetail.Tables[TableName].Select(LibraryMOD.GetFieldName(AccesstionNoFN) + "=" + AccesstionNo);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(AccesstionNoFN)] = AccesstionNo;
                    drAry[0][LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    drAry[0][LibraryMOD.GetFieldName(BookPriceFN)] = BookPrice;
                    drAry[0][LibraryMOD.GetFieldName(BookStatusIDFN)] = BookStatusID;
                    drAry[0][LibraryMOD.GetFieldName(OwnTypeIDFN)] = OwnTypeID;
                    drAry[0][LibraryMOD.GetFieldName(strInvoiceNoFN)] = strInvoiceNo;
                    drAry[0][LibraryMOD.GetFieldName(strBarcodeFN)] = strBarcode;
                    drAry[0][LibraryMOD.GetFieldName(strEncodeFN)] = strEncode;
                    drAry[0][LibraryMOD.GetFieldName(CampusIDFN)] = CampusID;
                    drAry[0][LibraryMOD.GetFieldName(strRemarkFN)] = strRemark;
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
    public int CommitLibBookDetail()
    {
        //CommitLibBookDetail= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibBookDetail.Update(dsLibBookDetail, TableName);
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
            FindInMultiPKey(AccesstionNo);
            if ((LibBookDetailDataRow != null))
            {
                LibBookDetailDataRow.Delete();
                CommitLibBookDetail();
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
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(AccesstionNoFN)] == System.DBNull.Value)
            {
                AccesstionNo = 0;
            }
            else
            {
                AccesstionNo = (int)LibBookDetailDataRow[LibraryMOD.GetFieldName(AccesstionNoFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(BookIDFN)] == System.DBNull.Value)
            {
                BookID = 0;
            }
            else
            {
                BookID = (int)LibBookDetailDataRow[LibraryMOD.GetFieldName(BookIDFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(BookPriceFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(BookStatusIDFN)] == System.DBNull.Value)
            {
                BookStatusID = 0;
            }
            else
            {
                BookStatusID = (int)LibBookDetailDataRow[LibraryMOD.GetFieldName(BookStatusIDFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(OwnTypeIDFN)] == System.DBNull.Value)
            {
                OwnTypeID = 0;
            }
            else
            {
                OwnTypeID = (int)LibBookDetailDataRow[LibraryMOD.GetFieldName(OwnTypeIDFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(strInvoiceNoFN)] == System.DBNull.Value)
            {
                strInvoiceNo = "";
            }
            else
            {
                strInvoiceNo = (string)LibBookDetailDataRow[LibraryMOD.GetFieldName(strInvoiceNoFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(strBarcodeFN)] == System.DBNull.Value)
            {
                strBarcode = "";
            }
            else
            {
                strBarcode = (string)LibBookDetailDataRow[LibraryMOD.GetFieldName(strBarcodeFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(strEncodeFN)] == System.DBNull.Value)
            {
                strEncode = "";
            }
            else
            {
                strEncode = (string)LibBookDetailDataRow[LibraryMOD.GetFieldName(strEncodeFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(CampusIDFN)] == System.DBNull.Value)
            {
                CampusID = 0;
            }
            else
            {
                CampusID = (int)LibBookDetailDataRow[LibraryMOD.GetFieldName(CampusIDFN)];
            }
            if (LibBookDetailDataRow[LibraryMOD.GetFieldName(strRemarkFN)] == System.DBNull.Value)
            {
                strRemark = "";
            }
            else
            {
                strRemark = (string)LibBookDetailDataRow[LibraryMOD.GetFieldName(strRemarkFN)];
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
    public int FindInMultiPKey(int PKAccesstionNo)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKAccesstionNo;
            LibBookDetailDataRow = dsLibBookDetail.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibBookDetailDataRow != null))
            {
                lngCurRow = dsLibBookDetail.Tables[TableName].Rows.IndexOf(LibBookDetailDataRow);
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
            lngCurRow = dsLibBookDetail.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibBookDetail.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibBookDetail.Tables[TableName].Rows.Count > 0)
            {
                LibBookDetailDataRow = dsLibBookDetail.Tables[TableName].Rows[lngCurRow];
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
            daLibBookDetail.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookDetail.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibBookDetail.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookDetail.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
