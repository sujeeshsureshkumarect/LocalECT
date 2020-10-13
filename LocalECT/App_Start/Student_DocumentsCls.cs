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
public class Student_Documents
{
//Creation Date: 11/04/2013 3:54 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_intDocument; 
private string m_strDocumentEn; 
private string m_strDocumentAr; 
private string m_isMandatory; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intDocument
{
get { return  m_intDocument; }
set {m_intDocument  = value ; }
}
public string strDocumentEn
{
get { return  m_strDocumentEn; }
set {m_strDocumentEn  = value ; }
}
public string strDocumentAr
{
get { return  m_strDocumentAr; }
set {m_strDocumentAr  = value ; }
}
public string isMandatory
{
get { return  m_isMandatory; }
set {m_isMandatory  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Student_Documents()
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
public class Student_DocumentsDAL : Student_Documents
{
#region "Decleration"
private string m_TableName;
private string m_intDocumentFN ;
private string m_strDocumentEnFN ;
private string m_strDocumentArFN ;
private string m_isMandatoryFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string intDocumentFN 
{
get { return  m_intDocumentFN; }
set {m_intDocumentFN  = value ; }
}
public string strDocumentEnFN 
{
get { return  m_strDocumentEnFN; }
set {m_strDocumentEnFN  = value ; }
}
public string strDocumentArFN 
{
get { return  m_strDocumentArFN; }
set {m_strDocumentArFN  = value ; }
}
public string isMandatoryFN 
{
get { return  m_isMandatoryFN; }
set {m_isMandatoryFN  = value ; }
}
#endregion
//================End Properties ===================
public Student_DocumentsDAL()
{
try
{
this.TableName = "Lkp_Student_Documents";
this.intDocumentFN = m_TableName + ".intDocument";
this.strDocumentEnFN = m_TableName + ".strDocumentEn";
this.strDocumentArFN = m_TableName + ".strDocumentAr";
this.isMandatoryFN = m_TableName + ".isMandatory";
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
sSQL +=intDocumentFN;
sSQL += " , " + strDocumentEnFN;
sSQL += " , " + strDocumentArFN;
sSQL += " , " + isMandatoryFN;
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
sSQL +=intDocumentFN;
sSQL += " , " + strDocumentEnFN;
sSQL += " , " + strDocumentArFN;
sSQL += "  FROM " + m_TableName;
sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION  ;

if (sCondition != "")
{
    sSQL +=  sCondition ;
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
sSQL +=intDocumentFN;
sSQL += " , " + strDocumentEnFN;
sSQL += " , " + strDocumentArFN;
sSQL += " , " + isMandatoryFN;
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
sSQL += LibraryMOD.GetFieldName(intDocumentFN) + "=@intDocument";
sSQL += " , " + LibraryMOD.GetFieldName(strDocumentEnFN) + "=@strDocumentEn";
sSQL += " , " + LibraryMOD.GetFieldName(strDocumentArFN) + "=@strDocumentAr";
sSQL += " , " + LibraryMOD.GetFieldName(isMandatoryFN) + "=@isMandatory";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intDocumentFN)+"=@intDocument";
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
sSQL +=LibraryMOD.GetFieldName(intDocumentFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDocumentEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDocumentArFN);
sSQL += " , " + LibraryMOD.GetFieldName(isMandatoryFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intDocument";
sSQL += " ,@strDocumentEn";
sSQL += " ,@strDocumentAr";
sSQL += " ,@isMandatory";
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
sSQL += LibraryMOD.GetFieldName(intDocumentFN)+"=@intDocument";
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
public List< Student_Documents> GetStudent_Documents(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Student_Documents
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
List<Student_Documents> results = new List<Student_Documents>();
try
{
//Default Value
Student_Documents myStudent_Documents = new Student_Documents();
if (isDeafaultIncluded)
{
//Change the code here
myStudent_Documents.intDocument = 0;
myStudent_Documents.strDocumentEn  = "Select Student_Documents ...";
results.Add(myStudent_Documents);
}
while (reader.Read())
{
myStudent_Documents = new Student_Documents();
if (reader[LibraryMOD.GetFieldName(intDocumentFN)].Equals(DBNull.Value))
{
myStudent_Documents.intDocument = 0;
}
else
{
myStudent_Documents.intDocument = int.Parse(reader[LibraryMOD.GetFieldName( intDocumentFN) ].ToString());
}
myStudent_Documents.strDocumentEn =reader[LibraryMOD.GetFieldName( strDocumentEnFN) ].ToString();
myStudent_Documents.strDocumentAr =reader[LibraryMOD.GetFieldName( strDocumentArFN) ].ToString();
myStudent_Documents.isMandatory =reader[LibraryMOD.GetFieldName( isMandatoryFN) ].ToString();
 results.Add(myStudent_Documents);
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
public List< Student_Documents > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Student_Documents> results = new List<Student_Documents>();
try
{
//Default Value
Student_Documents myStudent_Documents= new Student_Documents();
if (isDeafaultIncluded)
 {
//Change the code here
 myStudent_Documents.intDocument = -1;
 myStudent_Documents.strDocumentEn = "Select Student_Documents" ;
results.Add(myStudent_Documents);
 }
while (reader.Read())
{
myStudent_Documents = new Student_Documents();
if (reader[LibraryMOD.GetFieldName(intDocumentFN)].Equals(DBNull.Value))
{
myStudent_Documents.intDocument = 0;
}
else
{
myStudent_Documents.intDocument = int.Parse(reader[LibraryMOD.GetFieldName( intDocumentFN) ].ToString());
}
myStudent_Documents.strDocumentEn =reader[LibraryMOD.GetFieldName( strDocumentEnFN) ].ToString();
myStudent_Documents.strDocumentAr =reader[LibraryMOD.GetFieldName( strDocumentArFN) ].ToString();
 results.Add(myStudent_Documents);
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
public int UpdateStudent_Documents(InitializeModule.EnumCampus Campus, int iMode,int intDocument,string strDocumentEn,string strDocumentAr,string isMandatory)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Student_Documents theStudent_Documents = new Student_Documents();
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
Cmd.Parameters.Add(new SqlParameter("@intDocument",intDocument));
Cmd.Parameters.Add(new SqlParameter("@strDocumentEn",strDocumentEn));
Cmd.Parameters.Add(new SqlParameter("@strDocumentAr",strDocumentAr));
Cmd.Parameters.Add(new SqlParameter("@isMandatory",isMandatory));
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
public int DeleteStudent_Documents(InitializeModule.EnumCampus Campus,string intDocument)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intDocument", intDocument ));
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
DataTable dt = new DataTable("Student_Documents");
DataView dv = new DataView();
List<Student_Documents> myStudent_Documentss = new List<Student_Documents>();
try
{
myStudent_Documentss = GetStudent_Documents(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("intDocument", Type.GetType("smallint"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myStudent_Documentss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myStudent_Documentss[i].intDocument;
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
myStudent_Documentss.Clear();
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
sSQL += intDocumentFN;
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
public class Student_DocumentsCls : Student_DocumentsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daStudent_Documents;
private DataSet m_dsStudent_Documents;
public DataRow Student_DocumentsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsStudent_Documents
{
get { return m_dsStudent_Documents ; }
set { m_dsStudent_Documents = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Student_DocumentsCls()
{
try
{
dsStudent_Documents= new DataSet();

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
public virtual SqlDataAdapter GetStudent_DocumentsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daStudent_Documents = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudent_Documents);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_Documents.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_Documents;
}
public virtual SqlDataAdapter GetStudent_DocumentsDataAdapter(SqlConnection con)  
{
try
{
daStudent_Documents = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daStudent_Documents.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdStudent_Documents;
cmdStudent_Documents = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intDocument", SqlDbType.Int, 4, "intDocument" );
daStudent_Documents.SelectCommand = cmdStudent_Documents;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdStudent_Documents = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdStudent_Documents.Parameters.Add("@intDocument", SqlDbType.Int,2, LibraryMOD.GetFieldName(intDocumentFN));
cmdStudent_Documents.Parameters.Add("@strDocumentEn", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(strDocumentEnFN));
cmdStudent_Documents.Parameters.Add("@strDocumentAr", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strDocumentArFN));
cmdStudent_Documents.Parameters.Add("@isMandatory", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isMandatoryFN));


Parmeter = cmdStudent_Documents.Parameters.Add("@intDocument", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intDocumentFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daStudent_Documents.UpdateCommand = cmdStudent_Documents;
daStudent_Documents.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdStudent_Documents = new SqlCommand(GetInsertCommand(), con);
cmdStudent_Documents.Parameters.Add("@intDocument", SqlDbType.Int,2, LibraryMOD.GetFieldName(intDocumentFN));
cmdStudent_Documents.Parameters.Add("@strDocumentEn", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(strDocumentEnFN));
cmdStudent_Documents.Parameters.Add("@strDocumentAr", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strDocumentArFN));
cmdStudent_Documents.Parameters.Add("@isMandatory", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isMandatoryFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daStudent_Documents.InsertCommand =cmdStudent_Documents;
daStudent_Documents.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdStudent_Documents = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdStudent_Documents.Parameters.Add("@intDocument", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intDocumentFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daStudent_Documents.DeleteCommand =cmdStudent_Documents;
daStudent_Documents.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daStudent_Documents.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudent_Documents;
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
dr = dsStudent_Documents.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intDocumentFN)]=intDocument;
dr[LibraryMOD.GetFieldName(strDocumentEnFN)]=strDocumentEn;
dr[LibraryMOD.GetFieldName(strDocumentArFN)]=strDocumentAr;
dr[LibraryMOD.GetFieldName(isMandatoryFN)]=isMandatory;
dsStudent_Documents.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsStudent_Documents.Tables[TableName].Select(LibraryMOD.GetFieldName(intDocumentFN)  + "=" + intDocument);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intDocumentFN)]=intDocument;
drAry[0][LibraryMOD.GetFieldName(strDocumentEnFN)]=strDocumentEn;
drAry[0][LibraryMOD.GetFieldName(strDocumentArFN)]=strDocumentAr;
drAry[0][LibraryMOD.GetFieldName(isMandatoryFN)]=isMandatory;
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
public int CommitStudent_Documents()  
{
//CommitStudent_Documents= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daStudent_Documents.Update(dsStudent_Documents, TableName);
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
FindInMultiPKey(intDocument);
if (( Student_DocumentsDataRow != null)) 
{
Student_DocumentsDataRow.Delete();
CommitStudent_Documents();
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
if (Student_DocumentsDataRow[LibraryMOD.GetFieldName(intDocumentFN)]== System.DBNull.Value)
{
  intDocument=0;
}
else
{
  intDocument = (int)Student_DocumentsDataRow[LibraryMOD.GetFieldName(intDocumentFN)];
}
if (Student_DocumentsDataRow[LibraryMOD.GetFieldName(strDocumentEnFN)]== System.DBNull.Value)
{
  strDocumentEn="";
}
else
{
  strDocumentEn = (string)Student_DocumentsDataRow[LibraryMOD.GetFieldName(strDocumentEnFN)];
}
if (Student_DocumentsDataRow[LibraryMOD.GetFieldName(strDocumentArFN)]== System.DBNull.Value)
{
  strDocumentAr="";
}
else
{
  strDocumentAr = (string)Student_DocumentsDataRow[LibraryMOD.GetFieldName(strDocumentArFN)];
}
if (Student_DocumentsDataRow[LibraryMOD.GetFieldName(isMandatoryFN)]== System.DBNull.Value)
{
  isMandatory="";
}
else
{
  isMandatory = (string)Student_DocumentsDataRow[LibraryMOD.GetFieldName(isMandatoryFN)];
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
public int FindInMultiPKey(int PKintDocument) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintDocument;
Student_DocumentsDataRow = dsStudent_Documents.Tables[TableName].Rows.Find(findTheseVals);
if  ((Student_DocumentsDataRow !=null)) 
{
lngCurRow = dsStudent_Documents.Tables[TableName].Rows.IndexOf(Student_DocumentsDataRow);
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
  lngCurRow = dsStudent_Documents.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsStudent_Documents.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsStudent_Documents.Tables[TableName].Rows.Count > 0) 
{
  Student_DocumentsDataRow = dsStudent_Documents.Tables[TableName].Rows[lngCurRow];
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
daStudent_Documents.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_Documents.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daStudent_Documents.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudent_Documents.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
