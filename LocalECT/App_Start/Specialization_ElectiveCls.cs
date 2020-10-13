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

public class Specialization_Elective
{
    //Creation Date: 25/04/2012 04:46:27 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private string m_sCollege;
    private string m_sDegree;
    private string m_sMajor;
    private string m_sEelecive;
    private int m_intOrder;
    private int m_intLevel;
    private int m_intCourseClass;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public string sCollege
    {
        get { return m_sCollege; }
        set { m_sCollege = value; }
    }
    public string sDegree
    {
        get { return m_sDegree; }
        set { m_sDegree = value; }
    }
    public string sMajor
    {
        get { return m_sMajor; }
        set { m_sMajor = value; }
    }
    public string sEelecive
    {
        get { return m_sEelecive; }
        set { m_sEelecive = value; }
    }
    public int intOrder
    {
        get { return m_intOrder; }
        set { m_intOrder = value; }
    }
    public int intLevel
    {
        get { return m_intLevel; }
        set { m_intLevel = value; }
    }
    public int intCourseClass
    {
        get { return m_intCourseClass; }
        set { m_intCourseClass = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public Specialization_Elective()
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

public class Specialization_ElectiveDAL : Specialization_Elective
{
    #region "Decleration"
    private string m_TableName;
    private string m_sCollegeFN;
    private string m_sDegreeFN;
    private string m_sMajorFN;
    private string m_sEeleciveFN;
    private string m_intOrderFN;
    private string m_intLevelFN;
    private string m_intCourseClassFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string sCollegeFN
    {
        get { return m_sCollegeFN; }
        set { m_sCollegeFN = value; }
    }
    public string sDegreeFN
    {
        get { return m_sDegreeFN; }
        set { m_sDegreeFN = value; }
    }
    public string sMajorFN
    {
        get { return m_sMajorFN; }
        set { m_sMajorFN = value; }
    }
    public string sEeleciveFN
    {
        get { return m_sEeleciveFN; }
        set { m_sEeleciveFN = value; }
    }
    public string intOrderFN
    {
        get { return m_intOrderFN; }
        set { m_intOrderFN = value; }
    }
    public string intLevelFN
    {
        get { return m_intLevelFN; }
        set { m_intLevelFN = value; }
    }
    public string intCourseClassFN
    {
        get { return m_intCourseClassFN; }
        set { m_intCourseClassFN = value; }
    }
    #endregion
    //================End Properties ===================
    public Specialization_ElectiveDAL()
    {
        try
        {
            this.TableName = "Reg_Specialization_Elective";
            this.sCollegeFN = m_TableName + ".sCollege";
            this.sDegreeFN = m_TableName + ".sDegree";
            this.sMajorFN = m_TableName + ".sMajor";
            this.sEeleciveFN = m_TableName + ".sEelecive";
            this.intOrderFN = m_TableName + ".intOrder";
            this.intLevelFN = m_TableName + ".intLevel";
            this.intCourseClassFN = m_TableName + ".intCourseClass";
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
            sSQL += sCollegeFN;
            sSQL += " , " + sDegreeFN;
            sSQL += " , " + sMajorFN;
            sSQL += " , " + sEeleciveFN;
            sSQL += " , " + intOrderFN;
            sSQL += " , " + intLevelFN;
            sSQL += " , " + intCourseClassFN;
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
    public string GetListSQL(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += sCollegeFN;
            sSQL += " , " + sDegreeFN;
            sSQL += " , " + sMajorFN;
            sSQL += "  FROM " + m_TableName;
            if (!string.IsNullOrEmpty(sWhere))
            {
                sSQL += " WHERE " + sWhere;
            }
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
            sSQL += sCollegeFN;
            sSQL += " , " + sDegreeFN;
            sSQL += " , " + sMajorFN;
            sSQL += " , " + sEeleciveFN;
            sSQL += " , " + intOrderFN;
            sSQL += " , " + intLevelFN;
            sSQL += " , " + intCourseClassFN;
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
            sSQL += LibraryMOD.GetFieldName(sCollegeFN) + "=@sCollege";
            sSQL += " , " + LibraryMOD.GetFieldName(sDegreeFN) + "=@sDegree";
            sSQL += " , " + LibraryMOD.GetFieldName(sMajorFN) + "=@sMajor";
            sSQL += " , " + LibraryMOD.GetFieldName(sEeleciveFN) + "=@sEelecive";
            sSQL += " , " + LibraryMOD.GetFieldName(intOrderFN) + "=@intOrder";
            sSQL += " , " + LibraryMOD.GetFieldName(intLevelFN) + "=@intLevel";
            sSQL += " , " + LibraryMOD.GetFieldName(intCourseClassFN) + "=@intCourseClass";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(sCollegeFN) + "=@sCollege";
            sSQL += " And " + LibraryMOD.GetFieldName(sDegreeFN) + "=@sDegree";
            sSQL += " And " + LibraryMOD.GetFieldName(sMajorFN) + "=@sMajor";
            sSQL += " And " + LibraryMOD.GetFieldName(sEeleciveFN) + "=@sEelecive";
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
            sSQL += LibraryMOD.GetFieldName(sCollegeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sDegreeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sMajorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sEeleciveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intOrderFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intLevelFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intCourseClassFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @sCollege";
            sSQL += " ,@sDegree";
            sSQL += " ,@sMajor";
            sSQL += " ,@sEelecive";
            sSQL += " ,@intOrder";
            sSQL += " ,@intLevel";
            sSQL += " ,@intCourseClass";
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
            sSQL += LibraryMOD.GetFieldName(sCollegeFN) + "=@sCollege";
            sSQL += " And " + LibraryMOD.GetFieldName(sDegreeFN) + "=@sDegree";
            sSQL += " And " + LibraryMOD.GetFieldName(sMajorFN) + "=@sMajor";
            sSQL += " And " + LibraryMOD.GetFieldName(sEeleciveFN) + "=@sEelecive";
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

    public Boolean IsElectivsInMajorPlan(string sDegree, string sMajor, string sElective)
    {
        String sSQL;
        Boolean isExist = false;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {

            sSQL = "SELECT sEelecive";
            sSQL += "  FROM Reg_Specialization_Elective";
            sSQL += " Where sDegree='" + sDegree + "'";
            sSQL += " And sMajor='" + sMajor + "'";
            sSQL += " And sEelecive='" + sElective + "'";

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


            if (datReader.Read())
            {
                isExist = true;
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

        return isExist;
    }
    public List<Specialization_Elective> GetSpecialization_Elective(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Specialization_Elective
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
        List<Specialization_Elective> results = new List<Specialization_Elective>();
        try
        {
            //Default Value
            Specialization_Elective mySpecialization_Elective = new Specialization_Elective();
            if (isDeafaultIncluded)
            {
                //Change the code here
                mySpecialization_Elective.sCollege = "";
                mySpecialization_Elective.sDegree = "";
                mySpecialization_Elective.sMajor = "";
                mySpecialization_Elective.sEelecive = "";
                mySpecialization_Elective.sEelecive = "Select Specialization_Elective ...";
                results.Add(mySpecialization_Elective);
            }
            while (reader.Read())
            {
                mySpecialization_Elective = new Specialization_Elective();
                mySpecialization_Elective.sCollege = reader[LibraryMOD.GetFieldName(sCollegeFN)].ToString();
                mySpecialization_Elective.sDegree = reader[LibraryMOD.GetFieldName(sDegreeFN)].ToString();
                mySpecialization_Elective.sMajor = reader[LibraryMOD.GetFieldName(sMajorFN)].ToString();
                mySpecialization_Elective.sEelecive = reader[LibraryMOD.GetFieldName(sEeleciveFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(intOrderFN)].Equals(DBNull.Value))
                {
                    mySpecialization_Elective.intOrder = 0;
                }
                else
                {
                    mySpecialization_Elective.intOrder = int.Parse(reader[LibraryMOD.GetFieldName(intOrderFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(intLevelFN)].Equals(DBNull.Value))
                {
                    mySpecialization_Elective.intLevel = 0;
                }
                else
                {
                    mySpecialization_Elective.intLevel = int.Parse(reader[LibraryMOD.GetFieldName(intLevelFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(intCourseClassFN)].Equals(DBNull.Value))
                {
                    mySpecialization_Elective.intCourseClass = 0;
                }
                else
                {
                    mySpecialization_Elective.intCourseClass = int.Parse(reader[LibraryMOD.GetFieldName(intCourseClassFN)].ToString());
                }
                results.Add(mySpecialization_Elective);
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
    public List<Specialization_Elective> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Specialization_Elective> results = new List<Specialization_Elective>();
        try
        {
            //Default Value
            Specialization_Elective mySpecialization_Elective = new Specialization_Elective();
            if (isDeafaultIncluded)
            {
                //Change the code here
                mySpecialization_Elective.sCollege = "";
                mySpecialization_Elective.sDegree = "Select Specialization_Elective";
                results.Add(mySpecialization_Elective);
            }
            while (reader.Read())
            {
                mySpecialization_Elective = new Specialization_Elective();
                mySpecialization_Elective.sCollege = reader[LibraryMOD.GetFieldName(sCollegeFN)].ToString();
                mySpecialization_Elective.sDegree = reader[LibraryMOD.GetFieldName(sDegreeFN)].ToString();
                mySpecialization_Elective.sMajor = reader[LibraryMOD.GetFieldName(sMajorFN)].ToString();
                results.Add(mySpecialization_Elective);
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
    public int UpdateSpecialization_Elective(InitializeModule.EnumCampus Campus, int iMode, string sCollege, string sDegree, string sMajor, string sEelecive, int intOrder, int intLevel, int intCourseClass)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Specialization_Elective theSpecialization_Elective = new Specialization_Elective();
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
            Cmd.Parameters.Add(new SqlParameter("@sCollege", sCollege));
            Cmd.Parameters.Add(new SqlParameter("@sDegree", sDegree));
            Cmd.Parameters.Add(new SqlParameter("@sMajor", sMajor));
            Cmd.Parameters.Add(new SqlParameter("@sEelecive", sEelecive));
            Cmd.Parameters.Add(new SqlParameter("@intOrder", intOrder));
            Cmd.Parameters.Add(new SqlParameter("@intLevel", intLevel));
            Cmd.Parameters.Add(new SqlParameter("@intCourseClass", intCourseClass));
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
    public int DeleteSpecialization_Elective(InitializeModule.EnumCampus Campus, string sCollege, string sDegree, string sMajor, string sEelecive)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@sCollege", sCollege));
            Cmd.Parameters.Add(new SqlParameter("@sDegree", sDegree));
            Cmd.Parameters.Add(new SqlParameter("@sMajor", sMajor));
            Cmd.Parameters.Add(new SqlParameter("@sEelecive", sEelecive));
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
        DataTable dt = new DataTable("Specialization_Elective");
        DataView dv = new DataView();
        List<Specialization_Elective> mySpecialization_Electives = new List<Specialization_Elective>();
        try
        {
            mySpecialization_Electives = GetSpecialization_Elective(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("sCollege", Type.GetType("nvarchar"));
            dt.Columns.Add(col0);
            DataColumn col1 = new DataColumn("sDegree", Type.GetType("nvarchar"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("sMajor", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("sMajor", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col0));
            dt.Constraints.Add(new UniqueConstraint(col1));
            dt.Constraints.Add(new UniqueConstraint(col2));
            dt.Constraints.Add(new UniqueConstraint(col3));

            DataRow dr;
            for (int i = 0; i < mySpecialization_Electives.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = mySpecialization_Electives[i].sCollege;
                dr[2] = mySpecialization_Electives[i].sDegree;
                dr[3] = mySpecialization_Electives[i].sMajor;
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
            mySpecialization_Electives.Clear();
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
            sSQL += sCollegeFN;
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



public class Specialization_ElectiveCls : Specialization_ElectiveDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daSpecialization_Elective;
    private DataSet m_dsSpecialization_Elective;
    public DataRow Specialization_ElectiveDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsSpecialization_Elective
    {
        get { return m_dsSpecialization_Elective; }
        set { m_dsSpecialization_Elective = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Specialization_ElectiveCls()
    {
        try
        {
            dsSpecialization_Elective = new DataSet();

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
    public virtual SqlDataAdapter GetSpecialization_ElectiveDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daSpecialization_Elective = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSpecialization_Elective);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daSpecialization_Elective.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSpecialization_Elective;
    }
    public virtual SqlDataAdapter GetSpecialization_ElectiveDataAdapter(SqlConnection con)
    {
        try
        {
            daSpecialization_Elective = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daSpecialization_Elective.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdSpecialization_Elective;
            cmdSpecialization_Elective = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@sCollege", SqlDbType.Int, 4, "sCollege" );
            //'cmdRolePermission.Parameters.Add("@sDegree", SqlDbType.Int, 4, "sDegree" );
            //'cmdRolePermission.Parameters.Add("@sMajor", SqlDbType.Int, 4, "sMajor" );
            //'cmdRolePermission.Parameters.Add("@sEelecive", SqlDbType.Int, 4, "sEelecive" );
            daSpecialization_Elective.SelectCommand = cmdSpecialization_Elective;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdSpecialization_Elective = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdSpecialization_Elective.Parameters.Add("@sCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sCollegeFN));
            cmdSpecialization_Elective.Parameters.Add("@sDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sDegreeFN));
            cmdSpecialization_Elective.Parameters.Add("@sMajor", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sMajorFN));
            cmdSpecialization_Elective.Parameters.Add("@sEelecive", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(sEeleciveFN));
            cmdSpecialization_Elective.Parameters.Add("@intOrder", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intOrderFN));
            cmdSpecialization_Elective.Parameters.Add("@intLevel", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intLevelFN));
            cmdSpecialization_Elective.Parameters.Add("@intCourseClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intCourseClassFN));


            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sCollegeFN));
            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sDegreeFN));
            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sMajor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sMajorFN));
            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sEelecive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sEeleciveFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daSpecialization_Elective.UpdateCommand = cmdSpecialization_Elective;
            daSpecialization_Elective.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdSpecialization_Elective = new SqlCommand(GetInsertCommand(), con);
            cmdSpecialization_Elective.Parameters.Add("@sCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sCollegeFN));
            cmdSpecialization_Elective.Parameters.Add("@sDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sDegreeFN));
            cmdSpecialization_Elective.Parameters.Add("@sMajor", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sMajorFN));
            cmdSpecialization_Elective.Parameters.Add("@sEelecive", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(sEeleciveFN));
            cmdSpecialization_Elective.Parameters.Add("@intOrder", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intOrderFN));
            cmdSpecialization_Elective.Parameters.Add("@intLevel", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intLevelFN));
            cmdSpecialization_Elective.Parameters.Add("@intCourseClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intCourseClassFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daSpecialization_Elective.InsertCommand = cmdSpecialization_Elective;
            daSpecialization_Elective.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdSpecialization_Elective = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sCollegeFN));
            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sDegreeFN));
            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sMajor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sMajorFN));
            Parmeter = cmdSpecialization_Elective.Parameters.Add("@sEelecive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(sEeleciveFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daSpecialization_Elective.DeleteCommand = cmdSpecialization_Elective;
            daSpecialization_Elective.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daSpecialization_Elective.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSpecialization_Elective;
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
                    dr = dsSpecialization_Elective.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(sCollegeFN)] = sCollege;
                    dr[LibraryMOD.GetFieldName(sDegreeFN)] = sDegree;
                    dr[LibraryMOD.GetFieldName(sMajorFN)] = sMajor;
                    dr[LibraryMOD.GetFieldName(sEeleciveFN)] = sEelecive;
                    dr[LibraryMOD.GetFieldName(intOrderFN)] = intOrder;
                    dr[LibraryMOD.GetFieldName(intLevelFN)] = intLevel;
                    dr[LibraryMOD.GetFieldName(intCourseClassFN)] = intCourseClass;
                    dsSpecialization_Elective.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsSpecialization_Elective.Tables[TableName].Select(LibraryMOD.GetFieldName(sCollegeFN) + "=" + sCollege + " AND " + LibraryMOD.GetFieldName(sDegreeFN) + "=" + sDegree + " AND " + LibraryMOD.GetFieldName(sMajorFN) + "=" + sMajor + " AND " + LibraryMOD.GetFieldName(sEeleciveFN) + "=" + sEelecive);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(sCollegeFN)] = sCollege;
                    drAry[0][LibraryMOD.GetFieldName(sDegreeFN)] = sDegree;
                    drAry[0][LibraryMOD.GetFieldName(sMajorFN)] = sMajor;
                    drAry[0][LibraryMOD.GetFieldName(sEeleciveFN)] = sEelecive;
                    drAry[0][LibraryMOD.GetFieldName(intOrderFN)] = intOrder;
                    drAry[0][LibraryMOD.GetFieldName(intLevelFN)] = intLevel;
                    drAry[0][LibraryMOD.GetFieldName(intCourseClassFN)] = intCourseClass;
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
    public int CommitSpecialization_Elective()
    {
        //CommitSpecialization_Elective= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daSpecialization_Elective.Update(dsSpecialization_Elective, TableName);
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
            FindInMultiPKey(sCollege, sDegree, sMajor, sEelecive);
            if ((Specialization_ElectiveDataRow != null))
            {
                Specialization_ElectiveDataRow.Delete();
                CommitSpecialization_Elective();
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
            if (Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sCollegeFN)] == System.DBNull.Value)
            {
                sCollege = "";
            }
            else
            {
                sCollege = (string)Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sCollegeFN)];
            }
            if (Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sDegreeFN)] == System.DBNull.Value)
            {
                sDegree = "";
            }
            else
            {
                sDegree = (string)Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sDegreeFN)];
            }
            if (Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sMajorFN)] == System.DBNull.Value)
            {
                sMajor = "";
            }
            else
            {
                sMajor = (string)Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sMajorFN)];
            }
            if (Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sEeleciveFN)] == System.DBNull.Value)
            {
                sEelecive = "";
            }
            else
            {
                sEelecive = (string)Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(sEeleciveFN)];
            }
            if (Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(intOrderFN)] == System.DBNull.Value)
            {
                intOrder = 0;
            }
            else
            {
                intOrder = (int)Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(intOrderFN)];
            }
            if (Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(intLevelFN)] == System.DBNull.Value)
            {
                intLevel = 0;
            }
            else
            {
                intLevel = (int)Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(intLevelFN)];
            }
            if (Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(intCourseClassFN)] == System.DBNull.Value)
            {
                intCourseClass = 0;
            }
            else
            {
                intCourseClass = (int)Specialization_ElectiveDataRow[LibraryMOD.GetFieldName(intCourseClassFN)];
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
    public int FindInMultiPKey(string PKsCollege, string PKsDegree, string PKsMajor, string PKsEelecive)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKsCollege;
            findTheseVals[1] = PKsDegree;
            findTheseVals[2] = PKsMajor;
            findTheseVals[3] = PKsEelecive;
            Specialization_ElectiveDataRow = dsSpecialization_Elective.Tables[TableName].Rows.Find(findTheseVals);
            if ((Specialization_ElectiveDataRow != null))
            {
                lngCurRow = dsSpecialization_Elective.Tables[TableName].Rows.IndexOf(Specialization_ElectiveDataRow);
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
            lngCurRow = dsSpecialization_Elective.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsSpecialization_Elective.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsSpecialization_Elective.Tables[TableName].Rows.Count > 0)
            {
                Specialization_ElectiveDataRow = dsSpecialization_Elective.Tables[TableName].Rows[lngCurRow];
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
            daSpecialization_Elective.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSpecialization_Elective.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daSpecialization_Elective.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSpecialization_Elective.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
