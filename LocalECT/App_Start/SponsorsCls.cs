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
public class Sponsors
{
//Creation Date: 05/04/2010 10:29 AM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_intSponsor; 
private string m_strSponsorEn; 
private string m_strSponsorAr; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intSponsor
{
get { return  m_intSponsor; }
set {m_intSponsor  = value ; }
}
public string strSponsorEn
{
get { return  m_strSponsorEn; }
set {m_strSponsorEn  = value ; }
}
public string strSponsorAr
{
get { return  m_strSponsorAr; }
set {m_strSponsorAr  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Sponsors()
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
public class SponsorsDAL : Sponsors
{
#region "Decleration"
private string m_TableName;
private string m_intSponsorFN ;
private string m_strSponsorEnFN ;
private string m_strSponsorArFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string intSponsorFN 
{
get { return  m_intSponsorFN; }
set {m_intSponsorFN  = value ; }
}
public string strSponsorEnFN 
{
get { return  m_strSponsorEnFN; }
set {m_strSponsorEnFN  = value ; }
}
public string strSponsorArFN 
{
get { return  m_strSponsorArFN; }
set {m_strSponsorArFN  = value ; }
}
#endregion
//================End Properties ===================
public SponsorsDAL()
{
try
{
this.TableName = "Lkp_Sponsors";
this.intSponsorFN = m_TableName + ".intSponsor";
this.strSponsorEnFN = m_TableName + ".strSponsorEn";
this.strSponsorArFN = m_TableName + ".strSponsorAr";
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
sSQL +=intSponsorFN;
sSQL += " , " + strSponsorEnFN;
sSQL += " , " + strSponsorArFN;
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
sSQL +=intSponsorFN;
sSQL += " , " + strSponsorEnFN;
sSQL += " , " + strSponsorArFN;
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
sSQL += LibraryMOD.GetFieldName(intSponsorFN) + "=@intSponsor";
sSQL += " , " + LibraryMOD.GetFieldName(strSponsorEnFN) + "=@strSponsorEn";
sSQL += " , " + LibraryMOD.GetFieldName(strSponsorArFN) + "=@strSponsorAr";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intSponsorFN)+"=@intSponsor";
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
sSQL +=LibraryMOD.GetFieldName(intSponsorFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSponsorEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSponsorArFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intSponsor";
sSQL += " ,@strSponsorEn";
sSQL += " ,@strSponsorAr";
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
sSQL += LibraryMOD.GetFieldName(intSponsorFN)+"=@intSponsor";
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
public List< Sponsors> GetSponsors(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Sponsors
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
List<Sponsors> results = new List<Sponsors>();
try
{
//Default Value
Sponsors mySponsors = new Sponsors();
if (isDeafaultIncluded)
{
//Change the code here
mySponsors.intSponsor = 0;
mySponsors.strSponsorEn = "Select Sponsor ...";
results.Add(mySponsors);
}
while (reader.Read())
{
mySponsors = new Sponsors();
if (reader[LibraryMOD.GetFieldName(intSponsorFN)].Equals(DBNull.Value))
{
mySponsors.intSponsor = 0;
}
else
{
mySponsors.intSponsor = int.Parse(reader[LibraryMOD.GetFieldName( intSponsorFN) ].ToString());
}
mySponsors.strSponsorEn =reader[LibraryMOD.GetFieldName( strSponsorEnFN) ].ToString();
mySponsors.strSponsorAr =reader[LibraryMOD.GetFieldName( strSponsorArFN) ].ToString();
 results.Add(mySponsors);
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
public int UpdateSponsors(InitializeModule.EnumCampus Campus, int iMode,int intSponsor,string strSponsorEn,string strSponsorAr)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Sponsors theSponsors = new Sponsors();
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
Cmd.Parameters.Add(new SqlParameter("@intSponsor",intSponsor));
Cmd.Parameters.Add(new SqlParameter("@strSponsorEn",strSponsorEn));
Cmd.Parameters.Add(new SqlParameter("@strSponsorAr",strSponsorAr));
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
public int DeleteSponsors(InitializeModule.EnumCampus Campus,string intSponsor)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intSponsor", intSponsor ));
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
DataTable dt = new DataTable("Sponsors");
DataView dv = new DataView();
List<Sponsors> mySponsorss = new List<Sponsors>();
try
{
mySponsorss = GetSponsors(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intSponsor", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strSponsorEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strSponsorAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < mySponsorss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = mySponsorss[i].intSponsor;
  dr[2] = mySponsorss[i].strSponsorEn;
  dr[3] = mySponsorss[i].strSponsorAr;
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
mySponsorss.Clear();
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
sSQL += intSponsorFN;
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
public class SponsorsCls : SponsorsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daSponsors;
private DataSet m_dsSponsors;
public DataRow SponsorsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsSponsors
{
get { return m_dsSponsors ; }
set { m_dsSponsors = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public SponsorsCls()
{
try
{
dsSponsors= new DataSet();

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
public virtual SqlDataAdapter GetSponsorsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daSponsors = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSponsors);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daSponsors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSponsors;
}
public virtual SqlDataAdapter GetSponsorsDataAdapter(SqlConnection con)  
{
try
{
daSponsors = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daSponsors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdSponsors;
cmdSponsors = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intSponsor", SqlDbType.Int, 4, "intSponsor" );
daSponsors.SelectCommand = cmdSponsors;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdSponsors = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdSponsors.Parameters.Add("@intSponsor", SqlDbType.Int,4, LibraryMOD.GetFieldName(intSponsorFN));
cmdSponsors.Parameters.Add("@strSponsorEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSponsorEnFN));
cmdSponsors.Parameters.Add("@strSponsorAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSponsorArFN));


Parmeter = cmdSponsors.Parameters.Add("@intSponsor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intSponsorFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daSponsors.UpdateCommand = cmdSponsors;
daSponsors.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdSponsors = new SqlCommand(GetInsertCommand(), con);
cmdSponsors.Parameters.Add("@intSponsor", SqlDbType.Int,4, LibraryMOD.GetFieldName(intSponsorFN));
cmdSponsors.Parameters.Add("@strSponsorEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSponsorEnFN));
cmdSponsors.Parameters.Add("@strSponsorAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSponsorArFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daSponsors.InsertCommand =cmdSponsors;
daSponsors.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdSponsors = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdSponsors.Parameters.Add("@intSponsor", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intSponsorFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daSponsors.DeleteCommand =cmdSponsors;
daSponsors.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daSponsors.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daSponsors;
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
dr = dsSponsors.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intSponsorFN)]=intSponsor;
dr[LibraryMOD.GetFieldName(strSponsorEnFN)]=strSponsorEn;
dr[LibraryMOD.GetFieldName(strSponsorArFN)]=strSponsorAr;
dsSponsors.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsSponsors.Tables[TableName].Select(LibraryMOD.GetFieldName(intSponsorFN)  + "=" + intSponsor);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intSponsorFN)]=intSponsor;
drAry[0][LibraryMOD.GetFieldName(strSponsorEnFN)]=strSponsorEn;
drAry[0][LibraryMOD.GetFieldName(strSponsorArFN)]=strSponsorAr;
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
public int CommitSponsors()  
{
//CommitSponsors= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daSponsors.Update(dsSponsors, TableName);
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
FindInMultiPKey(intSponsor);
if (( SponsorsDataRow != null)) 
{
SponsorsDataRow.Delete();
CommitSponsors();
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
if (SponsorsDataRow[LibraryMOD.GetFieldName(intSponsorFN)]== System.DBNull.Value)
{
  intSponsor=0;
}
else
{
  intSponsor = (int)SponsorsDataRow[LibraryMOD.GetFieldName(intSponsorFN)];
}
if (SponsorsDataRow[LibraryMOD.GetFieldName(strSponsorEnFN)]== System.DBNull.Value)
{
  strSponsorEn="";
}
else
{
  strSponsorEn = (string)SponsorsDataRow[LibraryMOD.GetFieldName(strSponsorEnFN)];
}
if (SponsorsDataRow[LibraryMOD.GetFieldName(strSponsorArFN)]== System.DBNull.Value)
{
  strSponsorAr="";
}
else
{
  strSponsorAr = (string)SponsorsDataRow[LibraryMOD.GetFieldName(strSponsorArFN)];
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
public int FindInMultiPKey(int PKintSponsor) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintSponsor;
SponsorsDataRow = dsSponsors.Tables[TableName].Rows.Find(findTheseVals);
if  ((SponsorsDataRow !=null)) 
{
lngCurRow = dsSponsors.Tables[TableName].Rows.IndexOf(SponsorsDataRow);
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
  lngCurRow = dsSponsors.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsSponsors.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsSponsors.Tables[TableName].Rows.Count > 0) 
{
  SponsorsDataRow = dsSponsors.Tables[TableName].Rows[lngCurRow];
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
daSponsors.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSponsors.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daSponsors.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daSponsors.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
