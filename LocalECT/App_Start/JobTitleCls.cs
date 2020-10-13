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
public class JobTitle
{
//Creation Date: 04/10/2010 10:59 AM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_JobTitleID; 
private int m_DepartmentID; 
private int m_GradeID; 
private string m_JobTitleEn; 
private string m_JobTitleAr; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
//private int m_IsHeadOfDepartment //not used; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int JobTitleID
{
get { return  m_JobTitleID; }
set {m_JobTitleID  = value ; }
}
public int DepartmentID
{
get { return  m_DepartmentID; }
set {m_DepartmentID  = value ; }
}
public int GradeID
{
get { return  m_GradeID; }
set {m_GradeID  = value ; }
}
public string JobTitleEn
{
get { return  m_JobTitleEn; }
set {m_JobTitleEn  = value ; }
}
public string JobTitleAr
{
get { return  m_JobTitleAr; }
set {m_JobTitleAr  = value ; }
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
//public int IsHeadOfDepartment not used
//{
//get { return  m_IsHeadOfDepartment not used; }
//set {m_IsHeadOfDepartment not used  = value ; }
//}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public JobTitle()
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
public class JobTitleDAL : JobTitle
{
#region "Decleration"
private string m_TableName;
private string m_JobTitleIDFN ;
private string m_DepartmentIDFN ;
private string m_GradeIDFN ;
private string m_JobTitleEnFN ;
private string m_JobTitleArFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
//private string m_IsHeadOfDepartment not usedFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string JobTitleIDFN 
{
get { return  m_JobTitleIDFN; }
set {m_JobTitleIDFN  = value ; }
}
public string DepartmentIDFN 
{
get { return  m_DepartmentIDFN; }
set {m_DepartmentIDFN  = value ; }
}
public string GradeIDFN 
{
get { return  m_GradeIDFN; }
set {m_GradeIDFN  = value ; }
}
public string JobTitleEnFN 
{
get { return  m_JobTitleEnFN; }
set {m_JobTitleEnFN  = value ; }
}
public string JobTitleArFN 
{
get { return  m_JobTitleArFN; }
set {m_JobTitleArFN  = value ; }
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
//public string IsHeadOfDepartment not usedFN 
//{
//get { return  m_IsHeadOfDepartment not usedFN; }
//set {m_IsHeadOfDepartment not usedFN  = value ; }
//}
#endregion
//================End Properties ===================
public JobTitleDAL()
{
try
{
this.TableName = "Lkp_JobTitle";
this.JobTitleIDFN = m_TableName + ".JobTitleID";
this.DepartmentIDFN = m_TableName + ".DepartmentID";
this.GradeIDFN = m_TableName + ".GradeID";
this.JobTitleEnFN = m_TableName + ".JobTitleEn";
this.JobTitleArFN = m_TableName + ".JobTitleAr";
this.CreationUserIDFN = m_TableName + ".CreationUserID";
this.CreationDateFN = m_TableName + ".CreationDate";
this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
this.PCNameFN = m_TableName + ".PCName";
this.NetUserNameFN = m_TableName + ".NetUserName";
//this.IsHeadOfDepartment not usedFN = m_TableName + ".IsHeadOfDepartment not used";
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
sSQL +=JobTitleIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + GradeIDFN;
sSQL += " , " + JobTitleEnFN;
sSQL += " , " + JobTitleArFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
//sSQL += " , " + IsHeadOfDepartment not usedFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE 1=1";
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
sSQL +=JobTitleIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + GradeIDFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION  ;
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
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=JobTitleIDFN;
sSQL += " , " + DepartmentIDFN;
sSQL += " , " + GradeIDFN;
sSQL += " , " + JobTitleEnFN;
sSQL += " , " + JobTitleArFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
//sSQL += " , " + IsHeadOfDepartment not usedFN;
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
sSQL += LibraryMOD.GetFieldName(JobTitleIDFN) + "=@JobTitleID";
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN) + "=@DepartmentID";
sSQL += " , " + LibraryMOD.GetFieldName(GradeIDFN) + "=@GradeID";
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleEnFN) + "=@JobTitleEn";
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleArFN) + "=@JobTitleAr";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
//sSQL += " , " + LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN) + "=@IsHeadOfDepartment not used";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(JobTitleIDFN)+"=@JobTitleID";
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
sSQL +=LibraryMOD.GetFieldName(JobTitleIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(DepartmentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(GradeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleArFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
//sSQL += " , " + LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @JobTitleID";
sSQL += " ,@DepartmentID";
sSQL += " ,@GradeID";
sSQL += " ,@JobTitleEn";
sSQL += " ,@JobTitleAr";
sSQL += " ,@CreationUserID";
sSQL += " ,@CreationDate";
sSQL += " ,@LastUpdateUserID";
sSQL += " ,@LastUpdateDate";
sSQL += " ,@PCName";
sSQL += " ,@NetUserName";
//sSQL += " ,@IsHeadOfDepartment not used";
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
sSQL += LibraryMOD.GetFieldName(JobTitleIDFN)+"=@JobTitleID";
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
public List< JobTitle> GetJobTitle(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the JobTitle
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
List<JobTitle> results = new List<JobTitle>();
try
{
//Default Value
JobTitle myJobTitle = new JobTitle();
if (isDeafaultIncluded)
{
//Change the code here
myJobTitle.JobTitleID = 0;
myJobTitle.JobTitleEn  = "Select JobTitle ...";
results.Add(myJobTitle);
}
while (reader.Read())
{
myJobTitle = new JobTitle();
if (reader[LibraryMOD.GetFieldName(JobTitleIDFN)].Equals(DBNull.Value))
{
myJobTitle.JobTitleID = 0;
}
else
{
myJobTitle.JobTitleID = int.Parse(reader[LibraryMOD.GetFieldName( JobTitleIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
{
myJobTitle.DepartmentID = 0;
}
else
{
myJobTitle.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(GradeIDFN)].Equals(DBNull.Value))
{
myJobTitle.GradeID = 0;
}
else
{
myJobTitle.GradeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeIDFN) ].ToString());
}
myJobTitle.JobTitleEn =reader[LibraryMOD.GetFieldName( JobTitleEnFN) ].ToString();
myJobTitle.JobTitleAr =reader[LibraryMOD.GetFieldName( JobTitleArFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myJobTitle.CreationUserID = 0;
}
else
{
myJobTitle.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myJobTitle.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myJobTitle.LastUpdateUserID = 0;
}
else
{
myJobTitle.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myJobTitle.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myJobTitle.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myJobTitle.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
//if (reader[LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN)].Equals(DBNull.Value))
//{
//myJobTitle.IsHeadOfDepartment not used = 0;
//}
//else
//{
//myJobTitle.IsHeadOfDepartment not used = int.Parse(reader[LibraryMOD.GetFieldName( IsHeadOfDepartment not usedFN) ].ToString());
//}
 results.Add(myJobTitle);
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
public List< JobTitle > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<JobTitle> results = new List<JobTitle>();
try
{
//Default Value
JobTitle myJobTitle= new JobTitle();
if (isDeafaultIncluded) 
 {
//Change the code here
 myJobTitle.JobTitleID = -1;
 myJobTitle.JobTitleEn  = "Select JobTitle" ;
results.Add(myJobTitle);
 }
while (reader.Read())
{
myJobTitle = new JobTitle();
if (reader[LibraryMOD.GetFieldName(JobTitleIDFN)].Equals(DBNull.Value))
{
myJobTitle.JobTitleID = 0;
}
else
{
myJobTitle.JobTitleID = int.Parse(reader[LibraryMOD.GetFieldName( JobTitleIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(DepartmentIDFN)].Equals(DBNull.Value))
{
myJobTitle.DepartmentID = 0;
}
else
{
myJobTitle.DepartmentID = int.Parse(reader[LibraryMOD.GetFieldName( DepartmentIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(GradeIDFN)].Equals(DBNull.Value))
{
myJobTitle.GradeID = 0;
}
else
{
myJobTitle.GradeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeIDFN) ].ToString());
}
 results.Add(myJobTitle);
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
public int UpdateJobTitle(InitializeModule.EnumCampus Campus, int iMode,int JobTitleID,int DepartmentID,int GradeID,string JobTitleEn,string JobTitleAr,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)//,int IsHeadOfDepartment not used
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
JobTitle theJobTitle = new JobTitle();
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
Cmd.Parameters.Add(new SqlParameter("@JobTitleID",JobTitleID));
Cmd.Parameters.Add(new SqlParameter("@DepartmentID",DepartmentID));
Cmd.Parameters.Add(new SqlParameter("@GradeID",GradeID));
Cmd.Parameters.Add(new SqlParameter("@JobTitleEn",JobTitleEn));
Cmd.Parameters.Add(new SqlParameter("@JobTitleAr",JobTitleAr));
Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
//Cmd.Parameters.Add(new SqlParameter("@IsHeadOfDepartment not used",IsHeadOfDepartment not used));
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
public int DeleteJobTitle(InitializeModule.EnumCampus Campus,string JobTitleID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@JobTitleID", JobTitleID ));
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
DataTable dt = new DataTable("JobTitle");
DataView dv = new DataView();
List<JobTitle> myJobTitles = new List<JobTitle>();
try
{
myJobTitles = GetJobTitle(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("JobTitleID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("DepartmentID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("GradeID", Type.GetType("int"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myJobTitles.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myJobTitles[i].JobTitleID;
  dr[2] = myJobTitles[i].DepartmentID;
  dr[3] = myJobTitles[i].GradeID;
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
myJobTitles.Clear();
}
 return dv;
}
//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += JobTitleIDFN;
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
public class JobTitleCls : JobTitleDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daJobTitle;
private DataSet m_dsJobTitle;
public DataRow JobTitleDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsJobTitle
{
get { return m_dsJobTitle ; }
set { m_dsJobTitle = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public JobTitleCls()
{
try
{
dsJobTitle= new DataSet();

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
public virtual SqlDataAdapter GetJobTitleDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daJobTitle = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daJobTitle);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daJobTitle.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daJobTitle;
}
public virtual SqlDataAdapter GetJobTitleDataAdapter(SqlConnection con)  
{
try
{
daJobTitle = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daJobTitle.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdJobTitle;
cmdJobTitle = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@JobTitleID", SqlDbType.Int, 4, "JobTitleID" );
daJobTitle.SelectCommand = cmdJobTitle;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdJobTitle = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdJobTitle.Parameters.Add("@JobTitleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(JobTitleIDFN));
cmdJobTitle.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdJobTitle.Parameters.Add("@GradeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeIDFN));
cmdJobTitle.Parameters.Add("@JobTitleEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(JobTitleEnFN));
cmdJobTitle.Parameters.Add("@JobTitleAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(JobTitleArFN));
cmdJobTitle.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdJobTitle.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdJobTitle.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdJobTitle.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdJobTitle.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdJobTitle.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
//cmdJobTitle.Parameters.Add("@IsHeadOfDepartment not used", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN));


Parmeter = cmdJobTitle.Parameters.Add("@JobTitleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(JobTitleIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daJobTitle.UpdateCommand = cmdJobTitle;
daJobTitle.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdJobTitle = new SqlCommand(GetInsertCommand(), con);
cmdJobTitle.Parameters.Add("@JobTitleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(JobTitleIDFN));
cmdJobTitle.Parameters.Add("@DepartmentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(DepartmentIDFN));
cmdJobTitle.Parameters.Add("@GradeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeIDFN));
cmdJobTitle.Parameters.Add("@JobTitleEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(JobTitleEnFN));
cmdJobTitle.Parameters.Add("@JobTitleAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(JobTitleArFN));
cmdJobTitle.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdJobTitle.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdJobTitle.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdJobTitle.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdJobTitle.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdJobTitle.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
//cmdJobTitle.Parameters.Add("@IsHeadOfDepartment not used", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daJobTitle.InsertCommand =cmdJobTitle;
daJobTitle.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdJobTitle = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdJobTitle.Parameters.Add("@JobTitleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(JobTitleIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daJobTitle.DeleteCommand =cmdJobTitle;
daJobTitle.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daJobTitle.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daJobTitle;
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
dr = dsJobTitle.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(JobTitleIDFN)]=JobTitleID;
dr[LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
dr[LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
dr[LibraryMOD.GetFieldName(JobTitleEnFN)]=JobTitleEn;
dr[LibraryMOD.GetFieldName(JobTitleArFN)]=JobTitleAr;
//dr[LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN)]=IsHeadOfDepartment not used;
dsJobTitle.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsJobTitle.Tables[TableName].Select(LibraryMOD.GetFieldName(JobTitleIDFN)  + "=" + JobTitleID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(JobTitleIDFN)]=JobTitleID;
drAry[0][LibraryMOD.GetFieldName(DepartmentIDFN)]=DepartmentID;
drAry[0][LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
drAry[0][LibraryMOD.GetFieldName(JobTitleEnFN)]=JobTitleEn;
drAry[0][LibraryMOD.GetFieldName(JobTitleArFN)]=JobTitleAr;
//drAry[0][LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN)]=IsHeadOfDepartment not used;
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
public int CommitJobTitle()  
{
//CommitJobTitle= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daJobTitle.Update(dsJobTitle, TableName);
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
FindInMultiPKey(JobTitleID);
if (( JobTitleDataRow != null)) 
{
JobTitleDataRow.Delete();
CommitJobTitle();
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
if (JobTitleDataRow[LibraryMOD.GetFieldName(JobTitleIDFN)]== System.DBNull.Value)
{
  JobTitleID=0;
}
else
{
  JobTitleID = (int)JobTitleDataRow[LibraryMOD.GetFieldName(JobTitleIDFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)]== System.DBNull.Value)
{
  DepartmentID=0;
}
else
{
  DepartmentID = (int)JobTitleDataRow[LibraryMOD.GetFieldName(DepartmentIDFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(GradeIDFN)]== System.DBNull.Value)
{
  GradeID=0;
}
else
{
  GradeID = (int)JobTitleDataRow[LibraryMOD.GetFieldName(GradeIDFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(JobTitleEnFN)]== System.DBNull.Value)
{
  JobTitleEn="";
}
else
{
  JobTitleEn = (string)JobTitleDataRow[LibraryMOD.GetFieldName(JobTitleEnFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(JobTitleArFN)]== System.DBNull.Value)
{
  JobTitleAr="";
}
else
{
  JobTitleAr = (string)JobTitleDataRow[LibraryMOD.GetFieldName(JobTitleArFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)JobTitleDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)JobTitleDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)JobTitleDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)JobTitleDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)JobTitleDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (JobTitleDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)JobTitleDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
}
//if (JobTitleDataRow[LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN)]== System.DBNull.Value)
//{
//  IsHeadOfDepartment not used=0;
//}
//else
//{
//  IsHeadOfDepartment not used = (int)JobTitleDataRow[LibraryMOD.GetFieldName(IsHeadOfDepartment not usedFN)];
//}
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
public int FindInMultiPKey(int PKJobTitleID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKJobTitleID;
JobTitleDataRow = dsJobTitle.Tables[TableName].Rows.Find(findTheseVals);
if  ((JobTitleDataRow !=null)) 
{
lngCurRow = dsJobTitle.Tables[TableName].Rows.IndexOf(JobTitleDataRow);
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
  lngCurRow = dsJobTitle.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsJobTitle.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsJobTitle.Tables[TableName].Rows.Count > 0) 
{
  JobTitleDataRow = dsJobTitle.Tables[TableName].Rows[lngCurRow];
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
daJobTitle.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daJobTitle.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daJobTitle.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daJobTitle.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
