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
public class Grade_Types
{
    //Creation Date: 22/04/2010 10:30:06 ص
    //Programmer Name : hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_byteGradeType;
    private string m_strGradeDesc;
    private double m_CurPercentage;
    private string m_bDefault;
    private string m_strShortCut;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int byteGradeType
    {
        get { return m_byteGradeType; }
        set { m_byteGradeType = value; }
    }
    public string strGradeDesc
    {
        get { return m_strGradeDesc; }
        set { m_strGradeDesc = value; }
    }
    public double CurPercentage
    {
        get { return m_CurPercentage; }
        set { m_CurPercentage = value; }
    }
    public string bDefault
    {
        get { return m_bDefault; }
        set { m_bDefault = value; }
    }
    public string strShortCut
    {
        get { return m_strShortCut; }
        set { m_strShortCut = value; }
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
    public Grade_Types()
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
public class Grade_TypesDAL : Grade_Types
{
    #region "Decleration"
    private string m_TableName;
    private string m_byteGradeTypeFN;
    private string m_strGradeDescFN;
    private string m_CurPercentageFN;
    private string m_bDefaultFN;
    private string m_strShortCutFN;
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
    public string byteGradeTypeFN
    {
        get { return m_byteGradeTypeFN; }
        set { m_byteGradeTypeFN = value; }
    }
    public string strGradeDescFN
    {
        get { return m_strGradeDescFN; }
        set { m_strGradeDescFN = value; }
    }
    public string CurPercentageFN
    {
        get { return m_CurPercentageFN; }
        set { m_CurPercentageFN = value; }
    }
    public string bDefaultFN
    {
        get { return m_bDefaultFN; }
        set { m_bDefaultFN = value; }
    }
    public string strShortCutFN
    {
        get { return m_strShortCutFN; }
        set { m_strShortCutFN = value; }
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
    public Grade_TypesDAL()
    {
        try
        {
            this.TableName = "Reg_Grade_Types";
            this.byteGradeTypeFN = m_TableName + ".byteGradeType";
            this.strGradeDescFN = m_TableName + ".strGradeDesc";
            this.CurPercentageFN = m_TableName + ".CurPercentage";
            this.bDefaultFN = m_TableName + ".bDefault";
            this.strShortCutFN = m_TableName + ".strShortCut";
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
            sSQL += byteGradeTypeFN;
            sSQL += " , " + strGradeDescFN;
            sSQL += " , " + CurPercentageFN;
            sSQL += " , " + bDefaultFN;
            sSQL += " , " + strShortCutFN;
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
            sSQL += byteGradeTypeFN;
            sSQL += " , " + strGradeDescFN;
            sSQL += " , " + CurPercentageFN;
            sSQL += " , " + bDefaultFN;
            sSQL += " , " + strShortCutFN;
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
            sSQL += LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";
            sSQL += " , " + LibraryMOD.GetFieldName(strGradeDescFN) + "=@strGradeDesc";
            sSQL += " , " + LibraryMOD.GetFieldName(CurPercentageFN) + "=@CurPercentage";
            sSQL += " , " + LibraryMOD.GetFieldName(bDefaultFN) + "=@bDefault";
            sSQL += " , " + LibraryMOD.GetFieldName(strShortCutFN) + "=@strShortCut";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";
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
            sSQL += LibraryMOD.GetFieldName(byteGradeTypeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strGradeDescFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CurPercentageFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bDefaultFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strShortCutFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @byteGradeType";
            sSQL += " ,@strGradeDesc";
            sSQL += " ,@CurPercentage";
            sSQL += " ,@bDefault";
            sSQL += " ,@strShortCut";
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
            sSQL += LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";
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
    public List<Grade_Types> GetGrade_Types(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Grade_Types
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
        List<Grade_Types> results = new List<Grade_Types>();
        try
        {
            //Default Value
            Grade_Types myGrade_Types = new Grade_Types();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myGrade_Types.byteGradeType = 0;
                myGrade_Types.strGradeDesc = "Select Grade_Types ...";
                results.Add(myGrade_Types);
            }
            while (reader.Read())
            {
                myGrade_Types = new Grade_Types();
                if (reader[LibraryMOD.GetFieldName(byteGradeTypeFN)].Equals(DBNull.Value))
                {
                    myGrade_Types.byteGradeType = 0;
                }
                else
                {
                    myGrade_Types.byteGradeType = int.Parse(reader[LibraryMOD.GetFieldName(byteGradeTypeFN)].ToString());
                }
                myGrade_Types.strGradeDesc = reader[LibraryMOD.GetFieldName(strGradeDescFN)].ToString();
                myGrade_Types.bDefault = reader[LibraryMOD.GetFieldName(bDefaultFN)].ToString();
                myGrade_Types.strShortCut = reader[LibraryMOD.GetFieldName(strShortCutFN)].ToString();
                myGrade_Types.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myGrade_Types.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myGrade_Types.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myGrade_Types.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myGrade_Types.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myGrade_Types.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myGrade_Types);
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
    public int UpdateGrade_Types(InitializeModule.EnumCampus Campus, int iMode, int byteGradeType, string strGradeDesc, double CurPercentage, string bDefault, string strShortCut, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Grade_Types theGrade_Types = new Grade_Types();
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
            Cmd.Parameters.Add(new SqlParameter("@byteGradeType", byteGradeType));
            Cmd.Parameters.Add(new SqlParameter("@strGradeDesc", strGradeDesc));
            Cmd.Parameters.Add(new SqlParameter("@CurPercentage", CurPercentage));
            Cmd.Parameters.Add(new SqlParameter("@bDefault", bDefault));
            Cmd.Parameters.Add(new SqlParameter("@strShortCut", strShortCut));
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
    public int DeleteGrade_Types(InitializeModule.EnumCampus Campus, string byteGradeType)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@byteGradeType", byteGradeType));
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
        DataTable dt = new DataTable("Grade_Types");
        DataView dv = new DataView();
        List<Grade_Types> myGrade_Typess = new List<Grade_Types>();
        try
        {
            myGrade_Typess = GetGrade_Types(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("byteGradeType", Type.GetType("smallint"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strGradeDesc", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("CurPercentage", Type.GetType("money"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myGrade_Typess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myGrade_Typess[i].byteGradeType;
                dr[2] = myGrade_Typess[i].strGradeDesc;
                dr[3] = myGrade_Typess[i].CurPercentage;
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
            myGrade_Typess.Clear();
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
            sSQL += byteGradeTypeFN;
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
public class Grade_TypesCls : Grade_TypesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daGrade_Types;
    private DataSet m_dsGrade_Types;
    public DataRow Grade_TypesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsGrade_Types
    {
        get { return m_dsGrade_Types; }
        set { m_dsGrade_Types = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Grade_TypesCls()
    {
        try
        {
            dsGrade_Types = new DataSet();

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
    public virtual SqlDataAdapter GetGrade_TypesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daGrade_Types = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daGrade_Types);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daGrade_Types.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daGrade_Types;
    }
    public virtual SqlDataAdapter GetGrade_TypesDataAdapter(SqlConnection con)
    {
        try
        {
            daGrade_Types = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daGrade_Types.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdGrade_Types;
            cmdGrade_Types = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@byteGradeType", SqlDbType.Int, 4, "byteGradeType" );
            daGrade_Types.SelectCommand = cmdGrade_Types;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdGrade_Types = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdGrade_Types.Parameters.Add("@byteGradeType", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteGradeTypeFN));
            cmdGrade_Types.Parameters.Add("@strGradeDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strGradeDescFN));
            cmdGrade_Types.Parameters.Add("@CurPercentage", SqlDbType.Money, 21, LibraryMOD.GetFieldName(CurPercentageFN));
            cmdGrade_Types.Parameters.Add("@bDefault", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bDefaultFN));
            cmdGrade_Types.Parameters.Add("@strShortCut", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strShortCutFN));
            cmdGrade_Types.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdGrade_Types.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdGrade_Types.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdGrade_Types.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdGrade_Types.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdGrade_Types.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdGrade_Types.Parameters.Add("@byteGradeType", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteGradeTypeFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daGrade_Types.UpdateCommand = cmdGrade_Types;
            daGrade_Types.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdGrade_Types = new SqlCommand(GetInsertCommand(), con);
            cmdGrade_Types.Parameters.Add("@byteGradeType", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteGradeTypeFN));
            cmdGrade_Types.Parameters.Add("@strGradeDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strGradeDescFN));
            cmdGrade_Types.Parameters.Add("@CurPercentage", SqlDbType.Money, 21, LibraryMOD.GetFieldName(CurPercentageFN));
            cmdGrade_Types.Parameters.Add("@bDefault", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bDefaultFN));
            cmdGrade_Types.Parameters.Add("@strShortCut", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strShortCutFN));
            cmdGrade_Types.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdGrade_Types.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdGrade_Types.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdGrade_Types.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdGrade_Types.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdGrade_Types.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daGrade_Types.InsertCommand = cmdGrade_Types;
            daGrade_Types.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdGrade_Types = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdGrade_Types.Parameters.Add("@byteGradeType", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteGradeTypeFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daGrade_Types.DeleteCommand = cmdGrade_Types;
            daGrade_Types.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daGrade_Types.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daGrade_Types;
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
                    dr = dsGrade_Types.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(byteGradeTypeFN)] = byteGradeType;
                    dr[LibraryMOD.GetFieldName(strGradeDescFN)] = strGradeDesc;
                    dr[LibraryMOD.GetFieldName(CurPercentageFN)] = CurPercentage;
                    dr[LibraryMOD.GetFieldName(bDefaultFN)] = bDefault;
                    dr[LibraryMOD.GetFieldName(strShortCutFN)] = strShortCut;
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
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)]= ECTGlobalDll.InitializeModule.gNetUserName;
                    dsGrade_Types.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsGrade_Types.Tables[TableName].Select(LibraryMOD.GetFieldName(byteGradeTypeFN) + "=" + byteGradeType);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(byteGradeTypeFN)] = byteGradeType;
                    drAry[0][LibraryMOD.GetFieldName(strGradeDescFN)] = strGradeDesc;
                    drAry[0][LibraryMOD.GetFieldName(CurPercentageFN)] = CurPercentage;
                    drAry[0][LibraryMOD.GetFieldName(bDefaultFN)] = bDefault;
                    drAry[0][LibraryMOD.GetFieldName(strShortCutFN)] = strShortCut;
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
    public int CommitGrade_Types()
    {
        //CommitGrade_Types= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daGrade_Types.Update(dsGrade_Types, TableName);
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
            FindInMultiPKey(byteGradeType);
            if ((Grade_TypesDataRow != null))
            {
                Grade_TypesDataRow.Delete();
                CommitGrade_Types();
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
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(byteGradeTypeFN)] == System.DBNull.Value)
            {
                byteGradeType = 0;
            }
            else
            {
                byteGradeType = (int)Grade_TypesDataRow[LibraryMOD.GetFieldName(byteGradeTypeFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(strGradeDescFN)] == System.DBNull.Value)
            {
                strGradeDesc = "";
            }
            else
            {
                strGradeDesc = (string)Grade_TypesDataRow[LibraryMOD.GetFieldName(strGradeDescFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(CurPercentageFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(bDefaultFN)] == System.DBNull.Value)
            {
                bDefault = "";
            }
            else
            {
                bDefault = (string)Grade_TypesDataRow[LibraryMOD.GetFieldName(bDefaultFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(strShortCutFN)] == System.DBNull.Value)
            {
                strShortCut = "";
            }
            else
            {
                strShortCut = (string)Grade_TypesDataRow[LibraryMOD.GetFieldName(strShortCutFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)Grade_TypesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)Grade_TypesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)Grade_TypesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)Grade_TypesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)Grade_TypesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (Grade_TypesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)Grade_TypesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKbyteGradeType)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKbyteGradeType;
            Grade_TypesDataRow = dsGrade_Types.Tables[TableName].Rows.Find(findTheseVals);
            if ((Grade_TypesDataRow != null))
            {
                lngCurRow = dsGrade_Types.Tables[TableName].Rows.IndexOf(Grade_TypesDataRow);
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
            lngCurRow = dsGrade_Types.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsGrade_Types.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsGrade_Types.Tables[TableName].Rows.Count > 0)
            {
                Grade_TypesDataRow = dsGrade_Types.Tables[TableName].Rows[lngCurRow];
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
            daGrade_Types.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daGrade_Types.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daGrade_Types.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daGrade_Types.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
