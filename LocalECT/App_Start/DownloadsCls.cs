using System;
using System.Data;
using System.Configuration;
////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Collections.Generic;
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Downloads
{
//Creation Date: 13/09/2010 7:07:24 PM
//Programmer Name :ihab Awad 
//-----Decleration --------------
#region "Decleration"
private int m_iDownload; 
private string m_sPath; 
private string m_sFileName; 
private string m_sExt; 
private int m_iCategory; 
private DateTime m_dUploaded; 
private int m_iUserUploaded; 
private DateTime m_dDownloaded; 
private int m_iUserDownloaded; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int iDownload
{
get { return  m_iDownload; }
set {m_iDownload  = value ; }
}
public string sPath
{
get { return  m_sPath; }
set {m_sPath  = value ; }
}
public string sFileName
{
get { return  m_sFileName; }
set {m_sFileName  = value ; }
}
public string sExt
{
get { return  m_sExt; }
set {m_sExt  = value ; }
}
public int iCategory
{
get { return  m_iCategory; }
set {m_iCategory  = value ; }
}
public DateTime dUploaded
{
get { return  m_dUploaded; }
set {m_dUploaded  = value ; }
}
public int iUserUploaded
{
get { return  m_iUserUploaded; }
set {m_iUserUploaded  = value ; }
}
public DateTime dDownloaded
{
get { return  m_dDownloaded; }
set {m_dDownloaded  = value ; }
}
public int iUserDownloaded
{
get { return  m_iUserDownloaded; }
set {m_iUserDownloaded  = value ; }
}
#endregion
//'-----------------------------------------------------
public Downloads()
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
public class DownloadsDAL : Downloads
{
#region "Decleration"
private string m_TableName;
private string m_iDownloadFN ;
private string m_sPathFN ;
private string m_sFileNameFN ;
private string m_sExtFN ;
private string m_iCategoryFN ;
private string m_dUploadedFN ;
private string m_iUserUploadedFN ;
private string m_dDownloadedFN ;
private string m_iUserDownloadedFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string iDownloadFN 
{
get { return  m_iDownloadFN; }
set {m_iDownloadFN  = value ; }
}
public string sPathFN 
{
get { return  m_sPathFN; }
set {m_sPathFN  = value ; }
}
public string sFileNameFN 
{
get { return  m_sFileNameFN; }
set {m_sFileNameFN  = value ; }
}
public string sExtFN 
{
get { return  m_sExtFN; }
set {m_sExtFN  = value ; }
}
public string iCategoryFN 
{
get { return  m_iCategoryFN; }
set {m_iCategoryFN  = value ; }
}
public string dUploadedFN 
{
get { return  m_dUploadedFN; }
set {m_dUploadedFN  = value ; }
}
public string iUserUploadedFN 
{
get { return  m_iUserUploadedFN; }
set {m_iUserUploadedFN  = value ; }
}
public string dDownloadedFN 
{
get { return  m_dDownloadedFN; }
set {m_dDownloadedFN  = value ; }
}
public string iUserDownloadedFN 
{
get { return  m_iUserDownloadedFN; }
set {m_iUserDownloadedFN  = value ; }
}
#endregion
//================End Properties ===================
public DownloadsDAL()
{
try
{
this.TableName = "ECT_Downloads";
this.iDownloadFN = m_TableName + ".iDownload";
this.sPathFN = m_TableName + ".sPath";
this.sFileNameFN = m_TableName + ".sFileName";
this.sExtFN = m_TableName + ".sExt";
this.iCategoryFN = m_TableName + ".iCategory";
this.dUploadedFN = m_TableName + ".dUploaded";
this.iUserUploadedFN = m_TableName + ".iUserUploaded";
this.dDownloadedFN = m_TableName + ".dDownloaded";
this.iUserDownloadedFN = m_TableName + ".iUserDownloaded";
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
sSQL +=iDownloadFN;
sSQL += " , " + sPathFN;
sSQL += " , " + sFileNameFN;
sSQL += " , " + sExtFN;
sSQL += " , " + iCategoryFN;
sSQL += " , " + dUploadedFN;
sSQL += " , " + iUserUploadedFN;
sSQL += " , " + dDownloadedFN;
sSQL += " , " + iUserDownloadedFN;
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
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=iDownloadFN;
sSQL += " , " + sPathFN;
sSQL += " , " + sFileNameFN;
sSQL += " , " + sExtFN;
sSQL += " , " + iCategoryFN;
sSQL += " , " + dUploadedFN;
sSQL += " , " + iUserUploadedFN;
sSQL += " , " + dDownloadedFN;
sSQL += " , " + iUserDownloadedFN;
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
//sSQL += LibraryMOD.GetFieldName(iDownloadFN) + "=@iDownload";
sSQL +=LibraryMOD.GetFieldName(sPathFN) + "=@sPath";
sSQL += " , " + LibraryMOD.GetFieldName(sFileNameFN) + "=@sFileName";
sSQL += " , " + LibraryMOD.GetFieldName(sExtFN) + "=@sExt";
sSQL += " , " + LibraryMOD.GetFieldName(iCategoryFN) + "=@iCategory";
sSQL += " , " + LibraryMOD.GetFieldName(dUploadedFN) + "=@dUploaded";
sSQL += " , " + LibraryMOD.GetFieldName(iUserUploadedFN) + "=@iUserUploaded";
sSQL += " , " + LibraryMOD.GetFieldName(dDownloadedFN) + "=@dDownloaded";
sSQL += " , " + LibraryMOD.GetFieldName(iUserDownloadedFN) + "=@iUserDownloaded";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(iDownloadFN)+"=@iDownload";
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
//sSQL +=LibraryMOD.GetFieldName(iDownloadFN);
sSQL += LibraryMOD.GetFieldName(sPathFN);
sSQL += " , " + LibraryMOD.GetFieldName(sFileNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(sExtFN);
sSQL += " , " + LibraryMOD.GetFieldName(iCategoryFN);
sSQL += " , " + LibraryMOD.GetFieldName(dUploadedFN);
sSQL += " , " + LibraryMOD.GetFieldName(iUserUploadedFN);
sSQL += " , " + LibraryMOD.GetFieldName(dDownloadedFN);
sSQL += " , " + LibraryMOD.GetFieldName(iUserDownloadedFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
//sSQL += " @iDownload";
sSQL += " @sPath";
sSQL += " ,@sFileName";
sSQL += " ,@sExt";
sSQL += " ,@iCategory";
sSQL += " ,@dUploaded";
sSQL += " ,@iUserUploaded";
sSQL += " ,@dDownloaded";
sSQL += " ,@iUserDownloaded";
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
sSQL += LibraryMOD.GetFieldName(iDownloadFN)+"=@iDownload";
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
public List< Downloads> GetDownloads(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Downloads
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
List<Downloads> results = new List<Downloads>();
try
{
//Default Value
Downloads myDownloads = new Downloads();
if (isDeafaultIncluded)
{
//Change the code here
myDownloads.iDownload = 0;
myDownloads.sPath = "Select Downloads ...";
results.Add(myDownloads);
}
while (reader.Read())
{
myDownloads = new Downloads();
if (reader[LibraryMOD.GetFieldName(iDownloadFN)].Equals(DBNull.Value))
{
myDownloads.iDownload = 0;
}
else
{
myDownloads.iDownload = int.Parse(reader[LibraryMOD.GetFieldName( iDownloadFN) ].ToString());
}
myDownloads.sPath =reader[LibraryMOD.GetFieldName( sPathFN) ].ToString();
myDownloads.sFileName =reader[LibraryMOD.GetFieldName( sFileNameFN) ].ToString();
myDownloads.sExt =reader[LibraryMOD.GetFieldName( sExtFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(iCategoryFN)].Equals(DBNull.Value))
{
myDownloads.iCategory = 0;
}
else
{
myDownloads.iCategory = int.Parse(reader[LibraryMOD.GetFieldName( iCategoryFN) ].ToString());
}
if (!reader[dUploadedFN].Equals(DBNull.Value))
{
myDownloads.dUploaded = DateTime.Parse(reader[LibraryMOD.GetFieldName( dUploadedFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(iUserUploadedFN)].Equals(DBNull.Value))
{
myDownloads.iUserUploaded = 0;
}
else
{
myDownloads.iUserUploaded = int.Parse(reader[LibraryMOD.GetFieldName( iUserUploadedFN) ].ToString());
}
if (!reader[dDownloadedFN].Equals(DBNull.Value))
{
myDownloads.dDownloaded = DateTime.Parse(reader[LibraryMOD.GetFieldName( dDownloadedFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(iUserDownloadedFN)].Equals(DBNull.Value))
{
myDownloads.iUserDownloaded = 0;
}
else
{
myDownloads.iUserDownloaded = int.Parse(reader[LibraryMOD.GetFieldName( iUserDownloadedFN) ].ToString());
}
 results.Add(myDownloads);
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
public int UpdateDownloads(InitializeModule.EnumCampus Campus, int iMode,int iDownload,string sPath,string sFileName,string sExt,int iCategory,DateTime dUploaded,int iUserUploaded,DateTime dDownloaded,int iUserDownloaded)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Downloads theDownloads = new Downloads();
//'Updates the  table
switch(iMode) 
  {
  case  (int)InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@iDownload",iDownload));
Cmd.Parameters.Add(new SqlParameter("@sPath",sPath));
Cmd.Parameters.Add(new SqlParameter("@sFileName",sFileName));
Cmd.Parameters.Add(new SqlParameter("@sExt",sExt));
Cmd.Parameters.Add(new SqlParameter("@iCategory",iCategory));
Cmd.Parameters.Add(new SqlParameter("@dUploaded",dUploaded));
Cmd.Parameters.Add(new SqlParameter("@iUserUploaded",iUserUploaded));
Cmd.Parameters.Add(new SqlParameter("@dDownloaded",dDownloaded));
Cmd.Parameters.Add(new SqlParameter("@iUserDownloaded",iUserDownloaded));
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
public int DeleteDownloads(InitializeModule.EnumCampus Campus,string iDownload)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@iDownload", iDownload ));
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
DataTable dt = new DataTable("Downloads");
DataView dv = new DataView();
List<Downloads> myDownloadss = new List<Downloads>();
try
{
myDownloadss = GetDownloads(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("iDownload", Type.GetType("int identity"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("sPath", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("sFileName", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myDownloadss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myDownloadss[i].iDownload;
  dr[2] = myDownloadss[i].sPath;
  dr[3] = myDownloadss[i].sFileName;
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
myDownloadss.Clear();
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
sSQL += iDownloadFN;
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
public class DownloadsCls : DownloadsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daDownloads;
private DataSet m_dsDownloads;
public DataRow DownloadsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsDownloads
{
get { return m_dsDownloads ; }
set { m_dsDownloads = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public DownloadsCls()
{
try
{
dsDownloads= new DataSet();

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
public virtual SqlDataAdapter GetDownloadsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daDownloads = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daDownloads);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daDownloads.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDownloads;
}
public virtual SqlDataAdapter GetDownloadsDataAdapter(SqlConnection con)  
{
try
{
daDownloads = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daDownloads.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdDownloads;
cmdDownloads = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@iDownload", SqlDbType.Int, 4, "iDownload" );
daDownloads.SelectCommand = cmdDownloads;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdDownloads = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdDownloads.Parameters.Add("@iDownload", SqlDbType.Int,4, LibraryMOD.GetFieldName(iDownloadFN));
cmdDownloads.Parameters.Add("@sPath", SqlDbType.NVarChar,400, LibraryMOD.GetFieldName(sPathFN));
cmdDownloads.Parameters.Add("@sFileName", SqlDbType.NVarChar,400, LibraryMOD.GetFieldName(sFileNameFN));
cmdDownloads.Parameters.Add("@sExt", SqlDbType.VarChar,5, LibraryMOD.GetFieldName(sExtFN));
cmdDownloads.Parameters.Add("@iCategory", SqlDbType.Int,2, LibraryMOD.GetFieldName(iCategoryFN));
cmdDownloads.Parameters.Add("@dUploaded", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dUploadedFN));
cmdDownloads.Parameters.Add("@iUserUploaded", SqlDbType.Int,4, LibraryMOD.GetFieldName(iUserUploadedFN));
cmdDownloads.Parameters.Add("@dDownloaded", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dDownloadedFN));
cmdDownloads.Parameters.Add("@iUserDownloaded", SqlDbType.Int,4, LibraryMOD.GetFieldName(iUserDownloadedFN));


Parmeter = cmdDownloads.Parameters.Add("@iDownload", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iDownloadFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daDownloads.UpdateCommand = cmdDownloads;
daDownloads.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdDownloads = new SqlCommand(GetInsertCommand(), con);
cmdDownloads.Parameters.Add("@iDownload", SqlDbType.Int,4, LibraryMOD.GetFieldName(iDownloadFN));
cmdDownloads.Parameters.Add("@sPath", SqlDbType.NVarChar,400, LibraryMOD.GetFieldName(sPathFN));
cmdDownloads.Parameters.Add("@sFileName", SqlDbType.NVarChar,400, LibraryMOD.GetFieldName(sFileNameFN));
cmdDownloads.Parameters.Add("@sExt", SqlDbType.VarChar,5, LibraryMOD.GetFieldName(sExtFN));
cmdDownloads.Parameters.Add("@iCategory", SqlDbType.Int,2, LibraryMOD.GetFieldName(iCategoryFN));
cmdDownloads.Parameters.Add("@dUploaded", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dUploadedFN));
cmdDownloads.Parameters.Add("@iUserUploaded", SqlDbType.Int,4, LibraryMOD.GetFieldName(iUserUploadedFN));
cmdDownloads.Parameters.Add("@dDownloaded", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dDownloadedFN));
cmdDownloads.Parameters.Add("@iUserDownloaded", SqlDbType.Int,4, LibraryMOD.GetFieldName(iUserDownloadedFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daDownloads.InsertCommand =cmdDownloads;
daDownloads.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdDownloads = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdDownloads.Parameters.Add("@iDownload", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iDownloadFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daDownloads.DeleteCommand =cmdDownloads;
daDownloads.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daDownloads.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daDownloads;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsDownloads.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(iDownloadFN)]=iDownload;
dr[LibraryMOD.GetFieldName(sPathFN)]=sPath;
dr[LibraryMOD.GetFieldName(sFileNameFN)]=sFileName;
dr[LibraryMOD.GetFieldName(sExtFN)]=sExt;
dr[LibraryMOD.GetFieldName(iCategoryFN)]=iCategory;
dr[LibraryMOD.GetFieldName(dUploadedFN)]=dUploaded;
dr[LibraryMOD.GetFieldName(iUserUploadedFN)]=iUserUploaded;
dr[LibraryMOD.GetFieldName(dDownloadedFN)]=dDownloaded;
dr[LibraryMOD.GetFieldName(iUserDownloadedFN)]=iUserDownloaded;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsDownloads.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsDownloads.Tables[TableName].Select(LibraryMOD.GetFieldName(iDownloadFN)  + "=" + iDownload);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(iDownloadFN)]=iDownload;
drAry[0][LibraryMOD.GetFieldName(sPathFN)]=sPath;
drAry[0][LibraryMOD.GetFieldName(sFileNameFN)]=sFileName;
drAry[0][LibraryMOD.GetFieldName(sExtFN)]=sExt;
drAry[0][LibraryMOD.GetFieldName(iCategoryFN)]=iCategory;
drAry[0][LibraryMOD.GetFieldName(dUploadedFN)]=dUploaded;
drAry[0][LibraryMOD.GetFieldName(iUserUploadedFN)]=iUserUploaded;
drAry[0][LibraryMOD.GetFieldName(dDownloadedFN)]=dDownloaded;
drAry[0][LibraryMOD.GetFieldName(iUserDownloadedFN)]=iUserDownloaded;
//drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
return InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitDownloads()  
{
//CommitDownloads= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daDownloads.Update(dsDownloads, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow= InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(iDownload);
if (( DownloadsDataRow != null)) 
{
DownloadsDataRow.Delete();
CommitDownloads();
if (MoveNext() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (DownloadsDataRow[LibraryMOD.GetFieldName(iDownloadFN)]== System.DBNull.Value)
{
  iDownload=0;
}
else
{
  iDownload = (int)DownloadsDataRow[LibraryMOD.GetFieldName(iDownloadFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(sPathFN)]== System.DBNull.Value)
{
  sPath="";
}
else
{
  sPath = (string)DownloadsDataRow[LibraryMOD.GetFieldName(sPathFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(sFileNameFN)]== System.DBNull.Value)
{
  sFileName="";
}
else
{
  sFileName = (string)DownloadsDataRow[LibraryMOD.GetFieldName(sFileNameFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(sExtFN)]== System.DBNull.Value)
{
  sExt="";
}
else
{
  sExt = (string)DownloadsDataRow[LibraryMOD.GetFieldName(sExtFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(iCategoryFN)]== System.DBNull.Value)
{
  iCategory=0;
}
else
{
  iCategory = (int)DownloadsDataRow[LibraryMOD.GetFieldName(iCategoryFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(dUploadedFN)]== System.DBNull.Value)
{
}
else
{
  dUploaded = (DateTime)DownloadsDataRow[LibraryMOD.GetFieldName(dUploadedFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(iUserUploadedFN)]== System.DBNull.Value)
{
  iUserUploaded=0;
}
else
{
  iUserUploaded = (int)DownloadsDataRow[LibraryMOD.GetFieldName(iUserUploadedFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(dDownloadedFN)]== System.DBNull.Value)
{
}
else
{
  dDownloaded = (DateTime)DownloadsDataRow[LibraryMOD.GetFieldName(dDownloadedFN)];
}
if (DownloadsDataRow[LibraryMOD.GetFieldName(iUserDownloadedFN)]== System.DBNull.Value)
{
  iUserDownloaded=0;
}
else
{
  iUserDownloaded = (int)DownloadsDataRow[LibraryMOD.GetFieldName(iUserDownloadedFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(int PKiDownload) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKiDownload;
DownloadsDataRow = dsDownloads.Tables[TableName].Rows.Find(findTheseVals);
if  ((DownloadsDataRow !=null)) 
{
lngCurRow = dsDownloads.Tables[TableName].Rows.IndexOf(DownloadsDataRow);
SynchronizeDataRowToClass();
return InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst= InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast= InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsDownloads.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsDownloads.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow= InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsDownloads.Tables[TableName].Rows.Count > 0) 
{
  DownloadsDataRow = dsDownloads.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
// InitializeModule.FAIL_RET;
try
{
daDownloads.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDownloads.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daDownloads.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daDownloads.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
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
