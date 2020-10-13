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
public class Prerequisites
{
    //Creation Date: 12/04/2010 09:43:46 ص
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private string m_strCourse;
    private string m_strPrerequisite;
    private string m_strCollege;
    private string m_strDegree;
    private string m_strSpecialization;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public string strCourse
    {
        get { return m_strCourse; }
        set { m_strCourse = value; }
    }
    public string strPrerequisite
    {
        get { return m_strPrerequisite; }
        set { m_strPrerequisite = value; }
    }
    public string strCollege
    {
        get { return m_strCollege; }
        set { m_strCollege = value; }
    }
    public string strDegree
    {
        get { return m_strDegree; }
        set { m_strDegree = value; }
    }
    public string strSpecialization
    {
        get { return m_strSpecialization; }
        set { m_strSpecialization = value; }
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
    public Prerequisites()
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
public class PrerequisitesDAL : Prerequisites
{
    #region "Decleration"
    private string m_TableName;
    private string m_strCourseFN;
    private string m_strPrerequisiteFN;
    private string m_strCollegeFN;
    private string m_strDegreeFN;
    private string m_strSpecializationFN;
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
    public string strCourseFN
    {
        get { return m_strCourseFN; }
        set { m_strCourseFN = value; }
    }
    public string strPrerequisiteFN
    {
        get { return m_strPrerequisiteFN; }
        set { m_strPrerequisiteFN = value; }
    }
    public string strCollegeFN
    {
        get { return m_strCollegeFN; }
        set { m_strCollegeFN = value; }
    }
    public string strDegreeFN
    {
        get { return m_strDegreeFN; }
        set { m_strDegreeFN = value; }
    }
    public string strSpecializationFN
    {
        get { return m_strSpecializationFN; }
        set { m_strSpecializationFN = value; }
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
    public PrerequisitesDAL()
    {
        try
        {
            this.TableName = "Reg_Prerequisites";
            this.strCourseFN = m_TableName + ".strCourse";
            this.strPrerequisiteFN = m_TableName + ".strPrerequisite";
            this.strCollegeFN = m_TableName + ".strCollege";
            this.strDegreeFN = m_TableName + ".strDegree";
            this.strSpecializationFN = m_TableName + ".strSpecialization";
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
            sSQL += strCourseFN;
            sSQL += " , " + strPrerequisiteFN;
            sSQL += " , " + strCollegeFN;
            sSQL += " , " + strDegreeFN;
            sSQL += " , " + strSpecializationFN;
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
            sSQL += strCourseFN;
            sSQL += " , " + strPrerequisiteFN;
            sSQL += " , " + strCollegeFN;
            sSQL += " , " + strDegreeFN;
            sSQL += " , " + strSpecializationFN;
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
            sSQL += LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
            sSQL += " , " + LibraryMOD.GetFieldName(strPrerequisiteFN) + "=@strPrerequisite";
            sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
            sSQL += " And " + LibraryMOD.GetFieldName(strPrerequisiteFN) + "=@strPrerequisite";
            sSQL += " And " + LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " And " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
            sSQL += " And " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
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
            sSQL += LibraryMOD.GetFieldName(strCourseFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strPrerequisiteFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @strCourse";
            sSQL += " ,@strPrerequisite";
            sSQL += " ,@strCollege";
            sSQL += " ,@strDegree";
            sSQL += " ,@strSpecialization";
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
            sSQL += LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
            sSQL += " And " + LibraryMOD.GetFieldName(strPrerequisiteFN) + "=@strPrerequisite";
            sSQL += " And " + LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " And " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
            sSQL += " And " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
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
    public List<Prerequisites> GetPrerequisites(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Prerequisites
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
        List<Prerequisites> results = new List<Prerequisites>();
        try
        {
            //Default Value
            Prerequisites myPrerequisites = new Prerequisites();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myPrerequisites.strCourse = "";
                myPrerequisites.strPrerequisite = "";
                myPrerequisites.strCollege = "";
                myPrerequisites.strDegree = "";
                myPrerequisites.strSpecialization = "";
                myPrerequisites.strUserCreate = "Select Prerequisites ...";
                results.Add(myPrerequisites);
            }
            while (reader.Read())
            {
                myPrerequisites = new Prerequisites();
                myPrerequisites.strCourse = reader[LibraryMOD.GetFieldName(strCourseFN)].ToString();
                myPrerequisites.strPrerequisite = reader[LibraryMOD.GetFieldName(strPrerequisiteFN)].ToString();
                myPrerequisites.strCollege = reader[LibraryMOD.GetFieldName(strCollegeFN)].ToString();
                myPrerequisites.strDegree = reader[LibraryMOD.GetFieldName(strDegreeFN)].ToString();
                myPrerequisites.strSpecialization = reader[LibraryMOD.GetFieldName(strSpecializationFN)].ToString();
                myPrerequisites.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myPrerequisites.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myPrerequisites.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myPrerequisites.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myPrerequisites.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myPrerequisites.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myPrerequisites);
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
    public int UpdatePrerequisites(InitializeModule.EnumCampus Campus, int iMode, string strCourse, string strPrerequisite, string strCollege, string strDegree, string strSpecialization, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Prerequisites thePrerequisites = new Prerequisites();
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
            Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse));
            Cmd.Parameters.Add(new SqlParameter("@strPrerequisite", strPrerequisite));
            Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege));
            Cmd.Parameters.Add(new SqlParameter("@strDegree", strDegree));
            Cmd.Parameters.Add(new SqlParameter("@strSpecialization", strSpecialization));
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
    public int DeletePrerequisites(InitializeModule.EnumCampus Campus, string strCourse, string strPrerequisite, string strCollege, string strDegree, string strSpecialization)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse));
            Cmd.Parameters.Add(new SqlParameter("@strPrerequisite", strPrerequisite));
            Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege));
            Cmd.Parameters.Add(new SqlParameter("@strDegree", strDegree));
            Cmd.Parameters.Add(new SqlParameter("@strSpecialization", strSpecialization));
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
        DataTable dt = new DataTable("Prerequisites");
        DataView dv = new DataView();
        List<Prerequisites> myPrerequisitess = new List<Prerequisites>();
        try
        {
            myPrerequisitess = GetPrerequisites(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("strCourse", Type.GetType("nvarchar"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strPrerequisite", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strCollege", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            DataColumn col4 = new DataColumn("strDegree", Type.GetType("nvarchar"));
            dt.Columns.Add(col4);
            DataColumn col5 = new DataColumn("strSpecialization", Type.GetType("nvarchar"));
            dt.Columns.Add(col5);
            dt.Constraints.Add(new UniqueConstraint(col1));
            dt.Constraints.Add(new UniqueConstraint(col2));
            dt.Constraints.Add(new UniqueConstraint(col3));
            dt.Constraints.Add(new UniqueConstraint(col4));
            dt.Constraints.Add(new UniqueConstraint(col5));

            DataRow dr;
            for (int i = 0; i < myPrerequisitess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myPrerequisitess[i].strCourse;
                dr[2] = myPrerequisitess[i].strPrerequisite;
                dr[3] = myPrerequisitess[i].strCollege;
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
            myPrerequisitess.Clear();
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
            sSQL += strCourseFN;
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
public class PrerequisitesCls : PrerequisitesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daPrerequisites;
    private DataSet m_dsPrerequisites;
    public DataRow PrerequisitesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsPrerequisites
    {
        get { return m_dsPrerequisites; }
        set { m_dsPrerequisites = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public PrerequisitesCls()
    {
        try
        {
            dsPrerequisites = new DataSet();

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
    public virtual SqlDataAdapter GetPrerequisitesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daPrerequisites = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daPrerequisites);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daPrerequisites.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daPrerequisites;
    }
    public virtual SqlDataAdapter GetPrerequisitesDataAdapter(SqlConnection con)
    {
        try
        {
            daPrerequisites = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daPrerequisites.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdPrerequisites;
            cmdPrerequisites = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
            //'cmdRolePermission.Parameters.Add("@strPrerequisite", SqlDbType.Int, 4, "strPrerequisite" );
            //'cmdRolePermission.Parameters.Add("@strCollege", SqlDbType.Int, 4, "strCollege" );
            //'cmdRolePermission.Parameters.Add("@strDegree", SqlDbType.Int, 4, "strDegree" );
            //'cmdRolePermission.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, "strSpecialization" );
            daPrerequisites.SelectCommand = cmdPrerequisites;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdPrerequisites = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdPrerequisites.Parameters.Add("@strCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strCourseFN));
            cmdPrerequisites.Parameters.Add("@strPrerequisite", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strPrerequisiteFN));
            cmdPrerequisites.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdPrerequisites.Parameters.Add("@strDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strDegreeFN));
            cmdPrerequisites.Parameters.Add("@strSpecialization", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strSpecializationFN));
            cmdPrerequisites.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdPrerequisites.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdPrerequisites.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdPrerequisites.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdPrerequisites.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdPrerequisites.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdPrerequisites.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strPrerequisite", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strPrerequisiteFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strSpecializationFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daPrerequisites.UpdateCommand = cmdPrerequisites;
            daPrerequisites.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdPrerequisites = new SqlCommand(GetInsertCommand(), con);
            cmdPrerequisites.Parameters.Add("@strCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strCourseFN));
            cmdPrerequisites.Parameters.Add("@strPrerequisite", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strPrerequisiteFN));
            cmdPrerequisites.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdPrerequisites.Parameters.Add("@strDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strDegreeFN));
            cmdPrerequisites.Parameters.Add("@strSpecialization", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strSpecializationFN));
            cmdPrerequisites.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdPrerequisites.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdPrerequisites.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdPrerequisites.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdPrerequisites.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdPrerequisites.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daPrerequisites.InsertCommand = cmdPrerequisites;
            daPrerequisites.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdPrerequisites = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdPrerequisites.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strPrerequisite", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strPrerequisiteFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
            Parmeter = cmdPrerequisites.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strSpecializationFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daPrerequisites.DeleteCommand = cmdPrerequisites;
            daPrerequisites.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daPrerequisites.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daPrerequisites;
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
                    dr = dsPrerequisites.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    dr[LibraryMOD.GetFieldName(strPrerequisiteFN)] = strPrerequisite;
                    dr[LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    dr[LibraryMOD.GetFieldName(strDegreeFN)] = strDegree;
                    dr[LibraryMOD.GetFieldName(strSpecializationFN)] = strSpecialization;
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
                    dsPrerequisites.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsPrerequisites.Tables[TableName].Select(LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse + " AND " + LibraryMOD.GetFieldName(strPrerequisiteFN) + "=" + strPrerequisite + " AND " + LibraryMOD.GetFieldName(strCollegeFN) + "=" + strCollege + " AND " + LibraryMOD.GetFieldName(strDegreeFN) + "=" + strDegree + " AND " + LibraryMOD.GetFieldName(strSpecializationFN) + "=" + strSpecialization);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    drAry[0][LibraryMOD.GetFieldName(strPrerequisiteFN)] = strPrerequisite;
                    drAry[0][LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    drAry[0][LibraryMOD.GetFieldName(strDegreeFN)] = strDegree;
                    drAry[0][LibraryMOD.GetFieldName(strSpecializationFN)] = strSpecialization;
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
    public int CommitPrerequisites()
    {
        //CommitPrerequisites= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daPrerequisites.Update(dsPrerequisites, TableName);
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
            FindInMultiPKey(strCourse, strPrerequisite, strCollege, strDegree, strSpecialization);
            if ((PrerequisitesDataRow != null))
            {
                PrerequisitesDataRow.Delete();
                CommitPrerequisites();
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
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strCourseFN)] == System.DBNull.Value)
            {
                strCourse = "";
            }
            else
            {
                strCourse = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strCourseFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strPrerequisiteFN)] == System.DBNull.Value)
            {
                strPrerequisite = "";
            }
            else
            {
                strPrerequisite = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strPrerequisiteFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strCollegeFN)] == System.DBNull.Value)
            {
                strCollege = "";
            }
            else
            {
                strCollege = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strDegreeFN)] == System.DBNull.Value)
            {
                strDegree = "";
            }
            else
            {
                strDegree = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strDegreeFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strSpecializationFN)] == System.DBNull.Value)
            {
                strSpecialization = "";
            }
            else
            {
                strSpecialization = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strSpecializationFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)PrerequisitesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)PrerequisitesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (PrerequisitesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)PrerequisitesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(string PKstrCourse, string PKstrPrerequisite, string PKstrCollege, string PKstrDegree, string PKstrSpecialization)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKstrCourse;
            findTheseVals[1] = PKstrPrerequisite;
            findTheseVals[2] = PKstrCollege;
            findTheseVals[3] = PKstrDegree;
            findTheseVals[4] = PKstrSpecialization;
            PrerequisitesDataRow = dsPrerequisites.Tables[TableName].Rows.Find(findTheseVals);
            if ((PrerequisitesDataRow != null))
            {
                lngCurRow = dsPrerequisites.Tables[TableName].Rows.IndexOf(PrerequisitesDataRow);
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
            lngCurRow = dsPrerequisites.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsPrerequisites.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsPrerequisites.Tables[TableName].Rows.Count > 0)
            {
                PrerequisitesDataRow = dsPrerequisites.Tables[TableName].Rows[lngCurRow];
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
            daPrerequisites.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daPrerequisites.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daPrerequisites.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daPrerequisites.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
