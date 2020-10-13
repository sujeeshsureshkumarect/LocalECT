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
public class Student_AtRisk_D
{
//Creation Date: 27/03/2016 5:42:08 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_AtRiskTransactionID; 
private int m_GradeTypeID; 
private double m_Mark; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int AtRiskTransactionID
{
get { return  m_AtRiskTransactionID; }
set {m_AtRiskTransactionID  = value ; }
}
public int GradeTypeID
{
get { return  m_GradeTypeID; }
set {m_GradeTypeID  = value ; }
}
public double Mark
{
get { return  m_Mark; }
set {m_Mark  = value ; }
}
public int CreationUserID
{
get { return  m_CreationUserID; }
set {m_CreationUserID  = value ; }
}
public DateTime CreationDate
{
get { return  m_CreationDate; }
set {m_CreationDate  = value ; }
}
public int LastUpdateUserID
{
get { return  m_LastUpdateUserID; }
set {m_LastUpdateUserID  = value ; }
}
public DateTime LastUpdateDate
{
get { return  m_LastUpdateDate; }
set {m_LastUpdateDate  = value ; }
}
public string PCName
{
get { return  m_PCName; }
set {m_PCName  = value ; }
}
public string NetUserName
{
get { return  m_NetUserName; }
set {m_NetUserName  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Student_AtRisk_D()
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
public class Student_AtRisk_DDAL : Student_AtRisk_D
{
#region "Decleration"
private string m_TableName;
private string m_AtRiskTransactionIDFN ;
private string m_GradeTypeIDFN ;
private string m_MarkFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string AtRiskTransactionIDFN 
{
get { return  m_AtRiskTransactionIDFN; }
set {m_AtRiskTransactionIDFN  = value ; }
}
public string GradeTypeIDFN 
{
get { return  m_GradeTypeIDFN; }
set {m_GradeTypeIDFN  = value ; }
}
public string MarkFN 
{
get { return  m_MarkFN; }
set {m_MarkFN  = value ; }
}
public string CreationUserIDFN 
{
get { return  m_CreationUserIDFN; }
set {m_CreationUserIDFN  = value ; }
}
public string CreationDateFN 
{
get { return  m_CreationDateFN; }
set {m_CreationDateFN  = value ; }
}
public string LastUpdateUserIDFN 
{
get { return  m_LastUpdateUserIDFN; }
set {m_LastUpdateUserIDFN  = value ; }
}
public string LastUpdateDateFN 
{
get { return  m_LastUpdateDateFN; }
set {m_LastUpdateDateFN  = value ; }
}
public string PCNameFN 
{
get { return  m_PCNameFN; }
set {m_PCNameFN  = value ; }
}
public string NetUserNameFN 
{
get { return  m_NetUserNameFN; }
set {m_NetUserNameFN  = value ; }
}
#endregion
//================End Properties ===================
public Student_AtRisk_DDAL()
{
try
{
this.TableName = "Reg_Student_AtRisk_D";
this.AtRiskTransactionIDFN = m_TableName + ".AtRiskTransactionID";
this.GradeTypeIDFN = m_TableName + ".GradeTypeID";
this.MarkFN = m_TableName + ".Mark";
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
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=AtRiskTransactionIDFN;
sSQL += " , " + GradeTypeIDFN;
sSQL += " , " + MarkFN;
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
//-----GetListSQl Function ---------------------------------
public string GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
    sSQL = "SELECT ";
    sSQL +=AtRiskTransactionIDFN;
    sSQL += " , " + GradeTypeIDFN;
    sSQL += " , " + MarkFN;
    sSQL += " FROM " + m_TableName;
    sSQL += " WHERE 1=1";
    if (sCondition != "")
    {
        sSQL += sCondition;
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
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=AtRiskTransactionIDFN;
sSQL += " , " + GradeTypeIDFN;
sSQL += " , " + MarkFN;
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
string sSQL  = "";
try
{
sSQL = "UPDATE " + TableName;
sSQL += " SET ";
sSQL += LibraryMOD.GetFieldName(AtRiskTransactionIDFN) + "=@AtRiskTransactionID";
sSQL += " , " + LibraryMOD.GetFieldName(GradeTypeIDFN) + "=@GradeTypeID";
sSQL += " , " + LibraryMOD.GetFieldName(MarkFN) + "=@Mark";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(AtRiskTransactionIDFN)+"=@AtRiskTransactionID";
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
string sSQL= "";
try
{
sSQL = "INSERT intO "  + TableName;
sSQL += "( ";
sSQL +=LibraryMOD.GetFieldName(AtRiskTransactionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(GradeTypeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(MarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @AtRiskTransactionID";
sSQL += " ,@GradeTypeID";
sSQL += " ,@Mark";
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
public string  GetDeleteCommand()
{
string sSQL= "";
try
{
    sSQL = "DELETE FROM "  + TableName;
    sSQL += " WHERE ";
    sSQL += LibraryMOD.GetFieldName(AtRiskTransactionIDFN)+"=@AtRiskTransactionID";
    sSQL += " AND " + LibraryMOD.GetFieldName(GradeTypeIDFN) + "=@GradeTypeID";
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
public List< Student_AtRisk_D> GetStudent_AtRisk_D(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Student_AtRisk_D
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string  sSQL = GetSQL();
if (!string.IsNullOrEmpty(sCondition))
{
sSQL += sCondition;
}
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Student_AtRisk_D> results = new List<Student_AtRisk_D>();
try
{
//Default Value
Student_AtRisk_D myStudent_AtRisk_D = new Student_AtRisk_D();
if (isDeafaultIncluded)
{
//Change the code here
myStudent_AtRisk_D.AtRiskTransactionID = 0;
//myStudent_AtRisk_D.AtRiskTransactionID = "Select Student_AtRisk_D ...";
results.Add(myStudent_AtRisk_D);
}
while (reader.Read())
{
myStudent_AtRisk_D = new Student_AtRisk_D();
if (reader[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.AtRiskTransactionID = 0;
}
else
{
myStudent_AtRisk_D.AtRiskTransactionID = int.Parse(reader[LibraryMOD.GetFieldName( AtRiskTransactionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(GradeTypeIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.GradeTypeID = 0;
}
else
{
myStudent_AtRisk_D.GradeTypeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeTypeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.CreationUserID = 0;
}
else
{
myStudent_AtRisk_D.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.LastUpdateUserID = 0;
}
else
{
myStudent_AtRisk_D.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myStudent_AtRisk_D.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myStudent_AtRisk_D.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myStudent_AtRisk_D);
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
public List< Student_AtRisk_D > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Student_AtRisk_D> results = new List<Student_AtRisk_D>();
try
{
//Default Value
Student_AtRisk_D myStudent_AtRisk_D= new Student_AtRisk_D();
if (isDeafaultIncluded)
 {
//Change the code here
 myStudent_AtRisk_D.AtRiskTransactionID = -1;
 //myStudent_AtRisk_D.GradeTypeID = "Select Student_AtRisk_D" ;
results.Add(myStudent_AtRisk_D);
 }
while (reader.Read())
{
myStudent_AtRisk_D = new Student_AtRisk_D();
if (reader[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.AtRiskTransactionID = 0;
}
else
{
myStudent_AtRisk_D.AtRiskTransactionID = int.Parse(reader[LibraryMOD.GetFieldName( AtRiskTransactionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(GradeTypeIDFN)].Equals(DBNull.Value))
{
myStudent_AtRisk_D.GradeTypeID = 0;
}
else
{
myStudent_AtRisk_D.GradeTypeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeTypeIDFN) ].ToString());
}
 results.Add(myStudent_AtRisk_D);
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
public int UpdateStudent_AtRisk_D(InitializeModule.EnumCampus Campus, int iMode,int AtRiskTransactionID,int GradeTypeID,double Mark,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Student_AtRisk_D theStudent_AtRisk_D = new Student_AtRisk_D();
//'Updates the  table
switch(iMode) 
  {
  case  (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@AtRiskTransactionID",AtRiskTransactionID));
Cmd.Parameters.Add(new SqlParameter("@GradeTypeID",GradeTypeID));
Cmd.Parameters.Add(new SqlParameter("@Mark",Mark));
Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
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
public int DeleteStudent_AtRisk_D(InitializeModule.EnumCampus Campus,int AtRiskTransactionID,int iGradeTypeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Cmd.Parameters.Add(new SqlParameter("@AtRiskTransactionID", AtRiskTransactionID ));
    Cmd.Parameters.Add(new SqlParameter("@GradeTypeID", iGradeTypeID));
   
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
public DataView GetDataView(bool isFromRole,int PK,string sCondition)
{
DataTable dt = new DataTable("Student_AtRisk_D");
DataView dv = new DataView();
List<Student_AtRisk_D> myStudent_AtRisk_Ds = new List<Student_AtRisk_D>();
try
{
myStudent_AtRisk_Ds = GetStudent_AtRisk_D(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("AtRiskTransactionID", Type.GetType("int"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myStudent_AtRisk_Ds.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myStudent_AtRisk_Ds[i].AtRiskTransactionID;
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
myStudent_AtRisk_Ds.Clear();
}
 return dv;
}
public int IsStudentAtRiskExist(int iCampus,int iAtRiskTransactionID, int iGradeTypeID)
{
    String sSQL;
    int isExist = 0;

    Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        sSQL = "SELECT ";
        sSQL += GradeTypeIDFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + GradeTypeIDFN + "=" + iGradeTypeID ;
        sSQL += "  AND " + AtRiskTransactionIDFN + "=" + iAtRiskTransactionID;
     

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            isExist = Convert.ToInt32("0" + datReader[0].ToString());
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

public double  GetStudentAtRiskTotalMarks(int iCampus, string sStudentID, int iyear, int isem, string sCourse, int iSession, int iClass)
{
    String sSQL;
    double Marks = 0;

    Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        Student_AtRisk_HCls theStudent_AtRisk_H = new Student_AtRisk_HCls();                   

        sSQL = "SELECT SUM(" + MarkFN + ") AS TotalofMarks";
        sSQL += "  FROM " + theStudent_AtRisk_H.TableName + " INNER JOIN " + m_TableName;
        sSQL += "  ON " + theStudent_AtRisk_H.AtRiskTransactionIDFN + " = " + AtRiskTransactionIDFN ;
        sSQL += "  WHERE " + theStudent_AtRisk_H.StudentIDFN + "='" + sStudentID + "'";
        sSQL += "  AND " + theStudent_AtRisk_H.CourseIDFN + "='" + sCourse + "'";
        sSQL += "  AND " + theStudent_AtRisk_H.AcademicYearFN + "=" + iyear;
        sSQL += "  AND " + theStudent_AtRisk_H.SemesterFN + "=" + isem;
        sSQL += "  AND " + theStudent_AtRisk_H.SessionIDFN + "=" + iSession;
        sSQL += "  AND " + theStudent_AtRisk_H.ClassIDFN + "=" + iClass;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            Marks = Convert.ToDouble("0" + datReader[0].ToString());
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

    return Marks;
}

//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += AtRiskTransactionIDFN;
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
public class Student_AtRisk_DCls : Student_AtRisk_DDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daStudent_AtRisk_D;
private DataSet m_dsStudent_AtRisk_D;
public DataRow Student_AtRisk_DDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsStudent_AtRisk_D
{
get { return m_dsStudent_AtRisk_D ; }
set { m_dsStudent_AtRisk_D = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Student_AtRisk_DCls()
{
try
{
dsStudent_AtRisk_D= new DataSet();

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
public virtual SqlDataAdapter GetStudent_AtRisk_DDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daStudent_AtRisk_D = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudent_AtRisk_D);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_AtRisk_D.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_AtRisk_D;
}
public virtual SqlDataAdapter GetStudent_AtRisk_DDataAdapter(SqlConnection con)  
{
try
{
daStudent_AtRisk_D = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_AtRisk_D.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdStudent_AtRisk_D;
cmdStudent_AtRisk_D = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int, 4, "AtRiskTransactionID" );
daStudent_AtRisk_D.SelectCommand = cmdStudent_AtRisk_D;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdStudent_AtRisk_D = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdStudent_AtRisk_D.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@GradeTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeTypeIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@Mark", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(MarkFN));
cmdStudent_AtRisk_D.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudent_AtRisk_D.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudent_AtRisk_D.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdStudent_AtRisk_D.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdStudent_AtRisk_D.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daStudent_AtRisk_D.UpdateCommand = cmdStudent_AtRisk_D;
daStudent_AtRisk_D.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdStudent_AtRisk_D = new SqlCommand(GetInsertCommand(), con);
cmdStudent_AtRisk_D.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@GradeTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeTypeIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@Mark", SqlDbType.Decimal,6, LibraryMOD.GetFieldName(MarkFN));
cmdStudent_AtRisk_D.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudent_AtRisk_D.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudent_AtRisk_D.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudent_AtRisk_D.Parameters.Add("@PCName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PCNameFN));
cmdStudent_AtRisk_D.Parameters.Add("@NetUserName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daStudent_AtRisk_D.InsertCommand =cmdStudent_AtRisk_D;
daStudent_AtRisk_D.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdStudent_AtRisk_D = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdStudent_AtRisk_D.Parameters.Add("@AtRiskTransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AtRiskTransactionIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daStudent_AtRisk_D.DeleteCommand =cmdStudent_AtRisk_D;
daStudent_AtRisk_D.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daStudent_AtRisk_D.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_AtRisk_D;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsStudent_AtRisk_D.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)]=AtRiskTransactionID;
dr[LibraryMOD.GetFieldName(GradeTypeIDFN)]=GradeTypeID;
dr[LibraryMOD.GetFieldName(MarkFN)]=Mark;
dsStudent_AtRisk_D.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsStudent_AtRisk_D.Tables[TableName].Select(LibraryMOD.GetFieldName(AtRiskTransactionIDFN)  + "=" + AtRiskTransactionID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(AtRiskTransactionIDFN)]=AtRiskTransactionID;
drAry[0][LibraryMOD.GetFieldName(GradeTypeIDFN)]=GradeTypeID;
drAry[0][LibraryMOD.GetFieldName(MarkFN)]=Mark;
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
public int CommitStudent_AtRisk_D()  
{
//CommitStudent_AtRisk_D= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daStudent_AtRisk_D.Update(dsStudent_AtRisk_D, TableName);
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
FindInMultiPKey(AtRiskTransactionID);
if (( Student_AtRisk_DDataRow != null)) 
{
Student_AtRisk_DDataRow.Delete();
CommitStudent_AtRisk_D();
if (MoveNext() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)]== System.DBNull.Value)
{
  AtRiskTransactionID=0;
}
else
{
  AtRiskTransactionID = (int)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(AtRiskTransactionIDFN)];
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(GradeTypeIDFN)]== System.DBNull.Value)
{
  GradeTypeID=0;
}
else
{
  GradeTypeID = (int)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(GradeTypeIDFN)];
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(MarkFN)]== System.DBNull.Value)
{
}
else
{
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)Student_AtRisk_DDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKAtRiskTransactionID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKAtRiskTransactionID;
Student_AtRisk_DDataRow = dsStudent_AtRisk_D.Tables[TableName].Rows.Find(findTheseVals);
if  ((Student_AtRisk_DDataRow !=null)) 
{
lngCurRow = dsStudent_AtRisk_D.Tables[TableName].Rows.IndexOf(Student_AtRisk_DDataRow);
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
public int  MoveFirst()  
{
//MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
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
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
public int  MoveLast()  
{
//MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsStudent_AtRisk_D.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
public int  MoveNext() 
{
//MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsStudent_AtRisk_D.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
public int  GoToCurrentRow() 
{
//GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsStudent_AtRisk_D.Tables[TableName].Rows.Count > 0) 
{
  Student_AtRisk_DDataRow = dsStudent_AtRisk_D.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return ECTGlobalDll.InitializeModule.FAIL_RET;
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
daStudent_AtRisk_D.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_AtRisk_D.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daStudent_AtRisk_D.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_AtRisk_D.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
if (args.StatementType == StatementType.Delete )
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
private static void  OnRowUpdated( object sender, SqlRowUpdatedEventArgs args)
{
try
{
if (args.Status == UpdateStatus.ErrorsOccurred )
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
