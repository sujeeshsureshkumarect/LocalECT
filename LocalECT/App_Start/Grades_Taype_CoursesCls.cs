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
public class Grades_Taype_Courses
{
    //Creation Date: 15/04/2010 09:29:45 ص
    //Programmer Name : نـمــــــــوذج طـلـــب إجازة رسمية من العمل (إجازة hazem
    //-----Decleration --------------
    #region "Decleration"
    private string m_strCourse;
    private int m_byteGradeType;
    private int m_intDistribution;
    private double m_curPercentage;
    private int m_byteOrder;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public string strCourse
    {
        get { return m_strCourse; }
        set { m_strCourse = value; }
    }
    public int byteGradeType
    {
        get { return m_byteGradeType; }
        set { m_byteGradeType = value; }
    }
    public int intDistribution
    {
        get { return m_intDistribution; }
        set { m_intDistribution = value; }
    }
    public double curPercentage
    {
        get { return m_curPercentage; }
        set { m_curPercentage = value; }
    }
    public int byteOrder
    {
        get { return m_byteOrder; }
        set { m_byteOrder = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public Grades_Taype_Courses()
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
public class Grades_Taype_CoursesDAL : Grades_Taype_Courses
{
    #region "Decleration"
    private string m_TableName;
    private string m_strCourseFN;
    private string m_byteGradeTypeFN;
    private string m_intDistributionFN;
    private string m_curPercentageFN;
    private string m_byteOrderFN;
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
    public string byteGradeTypeFN
    {
        get { return m_byteGradeTypeFN; }
        set { m_byteGradeTypeFN = value; }
    }
    public string intDistributionFN
    {
        get { return m_intDistributionFN; }
        set { m_intDistributionFN = value; }
    }
    public string curPercentageFN
    {
        get { return m_curPercentageFN; }
        set { m_curPercentageFN = value; }
    }
    public string byteOrderFN
    {
        get { return m_byteOrderFN; }
        set { m_byteOrderFN = value; }
    }
    #endregion
    //================End Properties ===================
    public Grades_Taype_CoursesDAL()
    {
        try
        {
            this.TableName = "Reg_Grades_Taype_Courses";
            this.strCourseFN = m_TableName + ".strCourse";
            this.byteGradeTypeFN = m_TableName + ".byteGradeType";
            this.intDistributionFN = m_TableName + ".intDistribution";
            this.curPercentageFN = m_TableName + ".curPercentage";
            this.byteOrderFN = m_TableName + ".byteOrder";
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
            sSQL += " , " + byteGradeTypeFN;
            sSQL += " , " + intDistributionFN;
            sSQL += " , " + curPercentageFN;
            sSQL += " , " + byteOrderFN;
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
            sSQL += " , " + byteGradeTypeFN;
            sSQL += " , " + intDistributionFN;
            sSQL += " , " + curPercentageFN;
            sSQL += " , " + byteOrderFN;
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
            sSQL += " , " + LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";
            sSQL += " , " + LibraryMOD.GetFieldName(intDistributionFN) + "=@intDistribution";
            sSQL += " , " + LibraryMOD.GetFieldName(curPercentageFN) + "=@curPercentage";
            sSQL += " , " + LibraryMOD.GetFieldName(byteOrderFN) + "=@byteOrder";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
            sSQL += " And " + LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";
            sSQL += " And " + LibraryMOD.GetFieldName(intDistributionFN) + "=@intDistribution";
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
            sSQL += " , " + LibraryMOD.GetFieldName(byteGradeTypeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intDistributionFN);
            sSQL += " , " + LibraryMOD.GetFieldName(curPercentageFN);
            sSQL += " , " + LibraryMOD.GetFieldName(byteOrderFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @strCourse";
            sSQL += " ,@byteGradeType";
            sSQL += " ,@intDistribution";
            sSQL += " ,@curPercentage";
            sSQL += " ,@byteOrder";
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
            sSQL += " And " + LibraryMOD.GetFieldName(byteGradeTypeFN) + "=@byteGradeType";
            sSQL += " And " + LibraryMOD.GetFieldName(intDistributionFN) + "=@intDistribution";
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
    public List<Grades_Taype_Courses> GetGrades_Taype_Courses(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Grades_Taype_Courses
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
        List<Grades_Taype_Courses> results = new List<Grades_Taype_Courses>();
        try
        {
            //Default Value
            Grades_Taype_Courses myGrades_Taype_Courses = new Grades_Taype_Courses();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myGrades_Taype_Courses.strCourse = "";
                myGrades_Taype_Courses.byteGradeType = 0;
                myGrades_Taype_Courses.intDistribution = 0;
                myGrades_Taype_Courses.curPercentage = 0;
                results.Add(myGrades_Taype_Courses);
            }
            while (reader.Read())
            {
                myGrades_Taype_Courses = new Grades_Taype_Courses();
                myGrades_Taype_Courses.strCourse = reader[LibraryMOD.GetFieldName(strCourseFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(byteGradeTypeFN)].Equals(DBNull.Value))
                {
                    myGrades_Taype_Courses.byteGradeType = 0;
                }
                else
                {
                    myGrades_Taype_Courses.byteGradeType = int.Parse(reader[LibraryMOD.GetFieldName(byteGradeTypeFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(intDistributionFN)].Equals(DBNull.Value))
                {
                    myGrades_Taype_Courses.intDistribution = 0;
                }
                else
                {
                    myGrades_Taype_Courses.intDistribution = int.Parse(reader[LibraryMOD.GetFieldName(intDistributionFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(byteOrderFN)].Equals(DBNull.Value))
                {
                    myGrades_Taype_Courses.byteOrder = 0;
                }
                else
                {
                    myGrades_Taype_Courses.byteOrder = int.Parse(reader[LibraryMOD.GetFieldName(byteOrderFN)].ToString());
                }
                results.Add(myGrades_Taype_Courses);
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
    public int UpdateGrades_Taype_Courses(InitializeModule.EnumCampus Campus, int iMode, string strCourse, int byteGradeType, int intDistribution, double curPercentage, int byteOrder)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Grades_Taype_Courses theGrades_Taype_Courses = new Grades_Taype_Courses();
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
            Cmd.Parameters.Add(new SqlParameter("@byteGradeType", byteGradeType));
            Cmd.Parameters.Add(new SqlParameter("@intDistribution", intDistribution));
            Cmd.Parameters.Add(new SqlParameter("@curPercentage", curPercentage));
            Cmd.Parameters.Add(new SqlParameter("@byteOrder", byteOrder));
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
    public int DeleteGrades_Taype_Courses(InitializeModule.EnumCampus Campus, string strCourse, string byteGradeType, string intDistribution)
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
            Cmd.Parameters.Add(new SqlParameter("@byteGradeType", byteGradeType));
            Cmd.Parameters.Add(new SqlParameter("@intDistribution", intDistribution));
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
        DataTable dt = new DataTable("Grades_Taype_Courses");
        DataView dv = new DataView();
        List<Grades_Taype_Courses> myGrades_Taype_Coursess = new List<Grades_Taype_Courses>();
        try
        {
            myGrades_Taype_Coursess = GetGrades_Taype_Courses(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("strCourse", Type.GetType("nvarchar"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("byteGradeType", Type.GetType("smallint"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("intDistribution", Type.GetType("smallint"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));
            dt.Constraints.Add(new UniqueConstraint(col2));
            dt.Constraints.Add(new UniqueConstraint(col3));

            DataRow dr;
            for (int i = 0; i < myGrades_Taype_Coursess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myGrades_Taype_Coursess[i].strCourse;
                dr[2] = myGrades_Taype_Coursess[i].byteGradeType;
                dr[3] = myGrades_Taype_Coursess[i].intDistribution;
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
            myGrades_Taype_Coursess.Clear();
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
public class Grades_Taype_CoursesCls : Grades_Taype_CoursesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daGrades_Taype_Courses;
    private DataSet m_dsGrades_Taype_Courses;
    public DataRow Grades_Taype_CoursesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsGrades_Taype_Courses
    {
        get { return m_dsGrades_Taype_Courses; }
        set { m_dsGrades_Taype_Courses = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Grades_Taype_CoursesCls()
    {
        try
        {
            dsGrades_Taype_Courses = new DataSet();

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
    public virtual SqlDataAdapter GetGrades_Taype_CoursesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daGrades_Taype_Courses = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daGrades_Taype_Courses);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daGrades_Taype_Courses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daGrades_Taype_Courses;
    }
    public virtual SqlDataAdapter GetGrades_Taype_CoursesDataAdapter(SqlConnection con)
    {
        try
        {
            daGrades_Taype_Courses = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daGrades_Taype_Courses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdGrades_Taype_Courses;
            cmdGrades_Taype_Courses = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
            //'cmdRolePermission.Parameters.Add("@byteGradeType", SqlDbType.Int, 4, "byteGradeType" );
            //'cmdRolePermission.Parameters.Add("@intDistribution", SqlDbType.Int, 4, "intDistribution" );
            daGrades_Taype_Courses.SelectCommand = cmdGrades_Taype_Courses;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdGrades_Taype_Courses = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdGrades_Taype_Courses.Parameters.Add("@strCourse", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCourseFN));
            cmdGrades_Taype_Courses.Parameters.Add("@byteGradeType", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteGradeTypeFN));
            cmdGrades_Taype_Courses.Parameters.Add("@intDistribution", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intDistributionFN));
            cmdGrades_Taype_Courses.Parameters.Add("@curPercentage", SqlDbType.Money, 21, LibraryMOD.GetFieldName(curPercentageFN));
            cmdGrades_Taype_Courses.Parameters.Add("@byteOrder", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteOrderFN));


            Parmeter = cmdGrades_Taype_Courses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter = cmdGrades_Taype_Courses.Parameters.Add("@byteGradeType", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteGradeTypeFN));
            Parmeter = cmdGrades_Taype_Courses.Parameters.Add("@intDistribution", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intDistributionFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daGrades_Taype_Courses.UpdateCommand = cmdGrades_Taype_Courses;
            daGrades_Taype_Courses.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdGrades_Taype_Courses = new SqlCommand(GetInsertCommand(), con);
            cmdGrades_Taype_Courses.Parameters.Add("@strCourse", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strCourseFN));
            cmdGrades_Taype_Courses.Parameters.Add("@byteGradeType", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteGradeTypeFN));
            cmdGrades_Taype_Courses.Parameters.Add("@intDistribution", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intDistributionFN));
            cmdGrades_Taype_Courses.Parameters.Add("@curPercentage", SqlDbType.Money, 21, LibraryMOD.GetFieldName(curPercentageFN));
            cmdGrades_Taype_Courses.Parameters.Add("@byteOrder", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteOrderFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daGrades_Taype_Courses.InsertCommand = cmdGrades_Taype_Courses;
            daGrades_Taype_Courses.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdGrades_Taype_Courses = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdGrades_Taype_Courses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter = cmdGrades_Taype_Courses.Parameters.Add("@byteGradeType", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteGradeTypeFN));
            Parmeter = cmdGrades_Taype_Courses.Parameters.Add("@intDistribution", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intDistributionFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daGrades_Taype_Courses.DeleteCommand = cmdGrades_Taype_Courses;
            daGrades_Taype_Courses.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daGrades_Taype_Courses.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daGrades_Taype_Courses;
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
                    dr = dsGrades_Taype_Courses.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    dr[LibraryMOD.GetFieldName(byteGradeTypeFN)] = byteGradeType;
                    dr[LibraryMOD.GetFieldName(intDistributionFN)] = intDistribution;
                    dr[LibraryMOD.GetFieldName(curPercentageFN)] = curPercentage;
                    dr[LibraryMOD.GetFieldName(byteOrderFN)] = byteOrder;
                    //dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;
                    //dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    //dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = ECTGlobalDll.InitializeModule.gUserNo;  //'LastUpdateUserID
                    //dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //dr[LibraryMOD.GetFieldName(PCNameFN)] = ECTGlobalDll.InitializeModule.gPCName;
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)]= ECTGlobalDll.InitializeModule.gNetUserName;
                    dsGrades_Taype_Courses.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsGrades_Taype_Courses.Tables[TableName].Select(LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse + " AND " + LibraryMOD.GetFieldName(byteGradeTypeFN) + "=" + byteGradeType + " AND " + LibraryMOD.GetFieldName(intDistributionFN) + "=" + intDistribution);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    drAry[0][LibraryMOD.GetFieldName(byteGradeTypeFN)] = byteGradeType;
                    drAry[0][LibraryMOD.GetFieldName(intDistributionFN)] = intDistribution;
                    drAry[0][LibraryMOD.GetFieldName(curPercentageFN)] = curPercentage;
                    drAry[0][LibraryMOD.GetFieldName(byteOrderFN)] = byteOrder;
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
    public int CommitGrades_Taype_Courses()
    {
        //CommitGrades_Taype_Courses= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daGrades_Taype_Courses.Update(dsGrades_Taype_Courses, TableName);
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
            FindInMultiPKey(strCourse, byteGradeType, intDistribution);
            if ((Grades_Taype_CoursesDataRow != null))
            {
                Grades_Taype_CoursesDataRow.Delete();
                CommitGrades_Taype_Courses();
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
            if (Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)] == System.DBNull.Value)
            {
                strCourse = "";
            }
            else
            {
                strCourse = (string)Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)];
            }
            if (Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(byteGradeTypeFN)] == System.DBNull.Value)
            {
                byteGradeType = 0;
            }
            else
            {
                byteGradeType = (int)Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(byteGradeTypeFN)];
            }
            if (Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(intDistributionFN)] == System.DBNull.Value)
            {
                intDistribution = 0;
            }
            else
            {
                intDistribution = (int)Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(intDistributionFN)];
            }
            if (Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(curPercentageFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(byteOrderFN)] == System.DBNull.Value)
            {
                byteOrder = 0;
            }
            else
            {
                byteOrder = (int)Grades_Taype_CoursesDataRow[LibraryMOD.GetFieldName(byteOrderFN)];
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
    public int FindInMultiPKey(string PKstrCourse, int PKbyteGradeType, int PKintDistribution)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKstrCourse;
            findTheseVals[1] = PKbyteGradeType;
            findTheseVals[2] = PKintDistribution;
            Grades_Taype_CoursesDataRow = dsGrades_Taype_Courses.Tables[TableName].Rows.Find(findTheseVals);
            if ((Grades_Taype_CoursesDataRow != null))
            {
                lngCurRow = dsGrades_Taype_Courses.Tables[TableName].Rows.IndexOf(Grades_Taype_CoursesDataRow);
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
            lngCurRow = dsGrades_Taype_Courses.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsGrades_Taype_Courses.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsGrades_Taype_Courses.Tables[TableName].Rows.Count > 0)
            {
                Grades_Taype_CoursesDataRow = dsGrades_Taype_Courses.Tables[TableName].Rows[lngCurRow];
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
            daGrades_Taype_Courses.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daGrades_Taype_Courses.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daGrades_Taype_Courses.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daGrades_Taype_Courses.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
