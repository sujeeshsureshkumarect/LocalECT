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
public class IESOL_Equivalency
{
//Creation Date: 19/12/2018 3:44:57 PM
//Programmer Name : Bahaa Addin
//-----Decleration --------------
#region "Decleration"
private string m_GradeNumber; 
private string m_GradeID; 
private double m_EquivalentScore_TOEFL; 
private double m_EquivalentScore_IELTS; 
private double m_EquivalentScore_iBT; 
private double m_EquivalentScore_CBT; 
private double m_EquivalentScore_PTE; 
private double m_EquivalentScore_Cambridge; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public string GradeDesc
{
get { return  m_GradeNumber; }
set {m_GradeNumber  = value ; }
}
public string GradeID
{
get { return  m_GradeID; }
set {m_GradeID  = value ; }
}
public double EquivalentScore_TOEFL
{
get { return  m_EquivalentScore_TOEFL; }
set {m_EquivalentScore_TOEFL  = value ; }
}
public double EquivalentScore_IELTS
{
get { return  m_EquivalentScore_IELTS; }
set {m_EquivalentScore_IELTS  = value ; }
}
public double EquivalentScore_iBT
{
get { return  m_EquivalentScore_iBT; }
set {m_EquivalentScore_iBT  = value ; }
}
public double EquivalentScore_CBT
{
get { return  m_EquivalentScore_CBT; }
set {m_EquivalentScore_CBT  = value ; }
}
public double EquivalentScore_PTE
{
get { return  m_EquivalentScore_PTE; }
set {m_EquivalentScore_PTE  = value ; }
}
public double EquivalentScore_Cambridge
{
get { return  m_EquivalentScore_Cambridge; }
set {m_EquivalentScore_Cambridge  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public IESOL_Equivalency()
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
public class IESOL_EquivalencyDAL : IESOL_Equivalency
{
#region "Decleration"
private string m_TableName;
private string m_GradeDescFN;
private string m_GradeIDFN ;
private string m_EquivalentScore_TOEFLFN ;
private string m_EquivalentScore_IELTSFN ;
private string m_EquivalentScore_iBTFN ;
private string m_EquivalentScore_CBTFN ;
private string m_EquivalentScore_PTEFN ;
private string m_EquivalentScore_CambridgeFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string GradeDescFN 
{
    get { return m_GradeDescFN; }
    set { m_GradeDescFN = value; }
}
public string GradeIDFN 
{
get { return  m_GradeIDFN; }
set {m_GradeIDFN  = value ; }
}
public string EquivalentScore_TOEFLFN 
{
get { return  m_EquivalentScore_TOEFLFN; }
set {m_EquivalentScore_TOEFLFN  = value ; }
}
public string EquivalentScore_IELTSFN 
{
get { return  m_EquivalentScore_IELTSFN; }
set {m_EquivalentScore_IELTSFN  = value ; }
}
public string EquivalentScore_iBTFN 
{
get { return  m_EquivalentScore_iBTFN; }
set {m_EquivalentScore_iBTFN  = value ; }
}
public string EquivalentScore_CBTFN 
{
get { return  m_EquivalentScore_CBTFN; }
set {m_EquivalentScore_CBTFN  = value ; }
}
public string EquivalentScore_PTEFN 
{
get { return  m_EquivalentScore_PTEFN; }
set {m_EquivalentScore_PTEFN  = value ; }
}
public string EquivalentScore_CambridgeFN 
{
get { return  m_EquivalentScore_CambridgeFN; }
set {m_EquivalentScore_CambridgeFN  = value ; }
}
#endregion
//================End Properties ===================
public IESOL_EquivalencyDAL()
{
try
{
this.TableName = "Lkp_IESOL_Equivalency";
this.GradeDescFN = m_TableName + ".GradeDesc";
this.GradeIDFN = m_TableName + ".GradeID";
this.EquivalentScore_TOEFLFN = m_TableName + ".EquivalentScore_TOEFL";
this.EquivalentScore_IELTSFN = m_TableName + ".EquivalentScore_IELTS";
this.EquivalentScore_iBTFN = m_TableName + ".EquivalentScore_iBT";
this.EquivalentScore_CBTFN = m_TableName + ".EquivalentScore_CBT";
this.EquivalentScore_PTEFN = m_TableName + ".EquivalentScore_PTE";
this.EquivalentScore_CambridgeFN = m_TableName + ".EquivalentScore_Cambridge";
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
sSQL +=GradeDescFN;
sSQL += " , " + GradeIDFN;
sSQL += " , " + EquivalentScore_TOEFLFN;
sSQL += " , " + EquivalentScore_IELTSFN;
sSQL += " , " + EquivalentScore_iBTFN;
sSQL += " , " + EquivalentScore_CBTFN;
sSQL += " , " + EquivalentScore_PTEFN;
sSQL += " , " + EquivalentScore_CambridgeFN;
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
sSQL +=GradeDescFN;
sSQL += " , " + GradeIDFN;
sSQL += " , " + EquivalentScore_TOEFLFN;
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
sSQL +=GradeDescFN;
sSQL += " , " + GradeIDFN;
sSQL += " , " + EquivalentScore_TOEFLFN;
sSQL += " , " + EquivalentScore_IELTSFN;
sSQL += " , " + EquivalentScore_iBTFN;
sSQL += " , " + EquivalentScore_CBTFN;
sSQL += " , " + EquivalentScore_PTEFN;
sSQL += " , " + EquivalentScore_CambridgeFN;
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
sSQL += LibraryMOD.GetFieldName(GradeDescFN) + "=@GradeDesc";
sSQL += " , " + LibraryMOD.GetFieldName(GradeIDFN) + "=@GradeID";
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_TOEFLFN) + "=@EquivalentScore_TOEFL";
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_IELTSFN) + "=@EquivalentScore_IELTS";
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_iBTFN) + "=@EquivalentScore_iBT";
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_CBTFN) + "=@EquivalentScore_CBT";
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_PTEFN) + "=@EquivalentScore_PTE";
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_CambridgeFN) + "=@EquivalentScore_Cambridge";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(GradeIDFN)+"=@GradeID";
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
sSQL +=LibraryMOD.GetFieldName(GradeDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(GradeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_TOEFLFN);
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_IELTSFN);
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_iBTFN);
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_CBTFN);
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_PTEFN);
sSQL += " , " + LibraryMOD.GetFieldName(EquivalentScore_CambridgeFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @GradeDesc";
sSQL += " ,@GradeID";
sSQL += " ,@EquivalentScore_TOEFL";
sSQL += " ,@EquivalentScore_IELTS";
sSQL += " ,@EquivalentScore_iBT";
sSQL += " ,@EquivalentScore_CBT";
sSQL += " ,@EquivalentScore_PTE";
sSQL += " ,@EquivalentScore_Cambridge";
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
sSQL += LibraryMOD.GetFieldName(GradeIDFN)+"=@GradeID";
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
public List< IESOL_Equivalency> GetIESOL_Equivalency(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the IESOL_Equivalency
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
List<IESOL_Equivalency> results = new List<IESOL_Equivalency>();
try
{
//Default Value
IESOL_Equivalency myIESOL_Equivalency = new IESOL_Equivalency();
if (isDeafaultIncluded)
{
//Change the code here
myIESOL_Equivalency.GradeID = "-";
myIESOL_Equivalency.EquivalentScore_TOEFL= 0 ;
results.Add(myIESOL_Equivalency);
}
while (reader.Read())
{
myIESOL_Equivalency = new IESOL_Equivalency();
if (reader[LibraryMOD.GetFieldName(GradeDescFN)].Equals(DBNull.Value))
{
myIESOL_Equivalency.GradeDesc = "";
}
else
{
myIESOL_Equivalency.GradeDesc = reader[LibraryMOD.GetFieldName( GradeDescFN) ].ToString();
}
myIESOL_Equivalency.GradeID =reader[LibraryMOD.GetFieldName( GradeIDFN) ].ToString();
 results.Add(myIESOL_Equivalency);
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
public List< IESOL_Equivalency > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<IESOL_Equivalency> results = new List<IESOL_Equivalency>();
try
{
//Default Value
IESOL_Equivalency myIESOL_Equivalency= new IESOL_Equivalency();
if (isDeafaultIncluded)
 {
//Change the code here
 myIESOL_Equivalency.GradeID = "-";
 myIESOL_Equivalency.GradeDesc = "Select IESOL_Equivalency";
results.Add(myIESOL_Equivalency);
 }
while (reader.Read())
{
myIESOL_Equivalency = new IESOL_Equivalency();
if (reader[LibraryMOD.GetFieldName(GradeDescFN)].Equals(DBNull.Value))
{
myIESOL_Equivalency.GradeDesc = "";
}
else
{
myIESOL_Equivalency.GradeDesc = reader[LibraryMOD.GetFieldName( GradeDescFN) ].ToString();
}
myIESOL_Equivalency.GradeID =reader[LibraryMOD.GetFieldName( GradeIDFN) ].ToString();
 results.Add(myIESOL_Equivalency);
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
public int UpdateIESOL_Equivalency(InitializeModule.EnumCampus Campus, int iMode,string GradeDesc,string GradeID,double EquivalentScore_TOEFL,double EquivalentScore_IELTS,double EquivalentScore_iBT,double EquivalentScore_CBT,double EquivalentScore_PTE,double EquivalentScore_Cambridge)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
IESOL_Equivalency theIESOL_Equivalency = new IESOL_Equivalency();
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
Cmd.Parameters.Add(new SqlParameter("@GradeDesc",GradeDesc));
Cmd.Parameters.Add(new SqlParameter("@GradeID",GradeID));
Cmd.Parameters.Add(new SqlParameter("@EquivalentScore_TOEFL",EquivalentScore_TOEFL));
Cmd.Parameters.Add(new SqlParameter("@EquivalentScore_IELTS",EquivalentScore_IELTS));
Cmd.Parameters.Add(new SqlParameter("@EquivalentScore_iBT",EquivalentScore_iBT));
Cmd.Parameters.Add(new SqlParameter("@EquivalentScore_CBT",EquivalentScore_CBT));
Cmd.Parameters.Add(new SqlParameter("@EquivalentScore_PTE",EquivalentScore_PTE));
Cmd.Parameters.Add(new SqlParameter("@EquivalentScore_Cambridge",EquivalentScore_Cambridge));
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
public int DeleteIESOL_Equivalency(InitializeModule.EnumCampus Campus,string GradeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@GradeID", GradeID ));
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
public DataView GetDataView(bool isFromRole,string PK,string sCondition)
{
DataTable dt = new DataTable("IESOL_Equivalency");
DataView dv = new DataView();
List<IESOL_Equivalency> myIESOL_Equivalencys = new List<IESOL_Equivalency>();
try
{
myIESOL_Equivalencys = GetIESOL_Equivalency(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("GradeID", Type.GetType("string"));
dt.Columns.Add(col0 );
dt.Constraints.Add(new UniqueConstraint(col0));

DataRow dr;
for (int i = 0; i < myIESOL_Equivalencys.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myIESOL_Equivalencys[i].GradeID;
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
myIESOL_Equivalencys.Clear();
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
sSQL += GradeIDFN;
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
public class IESOL_EquivalencyCls : IESOL_EquivalencyDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daIESOL_Equivalency;
private DataSet m_dsIESOL_Equivalency;
public DataRow IESOL_EquivalencyDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsIESOL_Equivalency
{
get { return m_dsIESOL_Equivalency ; }
set { m_dsIESOL_Equivalency = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public IESOL_EquivalencyCls()
{
try
{
dsIESOL_Equivalency= new DataSet();

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
public virtual SqlDataAdapter GetIESOL_EquivalencyDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daIESOL_Equivalency = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daIESOL_Equivalency);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daIESOL_Equivalency.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daIESOL_Equivalency;
}
public virtual SqlDataAdapter GetIESOL_EquivalencyDataAdapter(SqlConnection con)  
{
try
{
daIESOL_Equivalency = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daIESOL_Equivalency.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdIESOL_Equivalency;
cmdIESOL_Equivalency = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@GradeID", SqlDbType.Int, 4, "GradeID" );
daIESOL_Equivalency.SelectCommand = cmdIESOL_Equivalency;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdIESOL_Equivalency = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdIESOL_Equivalency.Parameters.Add("@GradeDesc", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(GradeDescFN));
cmdIESOL_Equivalency.Parameters.Add("@GradeID", SqlDbType.VarChar,2, LibraryMOD.GetFieldName(GradeIDFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_TOEFL", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_TOEFLFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_IELTS", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_IELTSFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_iBT", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_iBTFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_CBT", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_CBTFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_PTE", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_PTEFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_Cambridge", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_CambridgeFN));


Parmeter = cmdIESOL_Equivalency.Parameters.Add("@GradeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(GradeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daIESOL_Equivalency.UpdateCommand = cmdIESOL_Equivalency;
daIESOL_Equivalency.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdIESOL_Equivalency = new SqlCommand(GetInsertCommand(), con);
cmdIESOL_Equivalency.Parameters.Add("@GradeDesc", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(GradeDescFN));
cmdIESOL_Equivalency.Parameters.Add("@GradeID", SqlDbType.VarChar,2, LibraryMOD.GetFieldName(GradeIDFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_TOEFL", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_TOEFLFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_IELTS", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_IELTSFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_iBT", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_iBTFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_CBT", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_CBTFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_PTE", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_PTEFN));
cmdIESOL_Equivalency.Parameters.Add("@EquivalentScore_Cambridge", SqlDbType.Decimal, 8, LibraryMOD.GetFieldName(EquivalentScore_CambridgeFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daIESOL_Equivalency.InsertCommand =cmdIESOL_Equivalency;
daIESOL_Equivalency.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdIESOL_Equivalency = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdIESOL_Equivalency.Parameters.Add("@GradeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(GradeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daIESOL_Equivalency.DeleteCommand =cmdIESOL_Equivalency;
daIESOL_Equivalency.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daIESOL_Equivalency.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daIESOL_Equivalency;
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
dr = dsIESOL_Equivalency.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(GradeDescFN)]=GradeDesc;
dr[LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
dr[LibraryMOD.GetFieldName(EquivalentScore_TOEFLFN)]=EquivalentScore_TOEFL;
dr[LibraryMOD.GetFieldName(EquivalentScore_IELTSFN)]=EquivalentScore_IELTS;
dr[LibraryMOD.GetFieldName(EquivalentScore_iBTFN)]=EquivalentScore_iBT;
dr[LibraryMOD.GetFieldName(EquivalentScore_CBTFN)]=EquivalentScore_CBT;
dr[LibraryMOD.GetFieldName(EquivalentScore_PTEFN)]=EquivalentScore_PTE;
dr[LibraryMOD.GetFieldName(EquivalentScore_CambridgeFN)]=EquivalentScore_Cambridge;
dsIESOL_Equivalency.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsIESOL_Equivalency.Tables[TableName].Select(LibraryMOD.GetFieldName(GradeIDFN)  + "=" + GradeID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(GradeDescFN)]=GradeDesc;
drAry[0][LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
drAry[0][LibraryMOD.GetFieldName(EquivalentScore_TOEFLFN)]=EquivalentScore_TOEFL;
drAry[0][LibraryMOD.GetFieldName(EquivalentScore_IELTSFN)]=EquivalentScore_IELTS;
drAry[0][LibraryMOD.GetFieldName(EquivalentScore_iBTFN)]=EquivalentScore_iBT;
drAry[0][LibraryMOD.GetFieldName(EquivalentScore_CBTFN)]=EquivalentScore_CBT;
drAry[0][LibraryMOD.GetFieldName(EquivalentScore_PTEFN)]=EquivalentScore_PTE;
drAry[0][LibraryMOD.GetFieldName(EquivalentScore_CambridgeFN)]=EquivalentScore_Cambridge;
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
public int CommitIESOL_Equivalency()  
{
//CommitIESOL_Equivalency= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daIESOL_Equivalency.Update(dsIESOL_Equivalency, TableName);
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
FindInMultiPKey(GradeID);
if (( IESOL_EquivalencyDataRow != null)) 
{
IESOL_EquivalencyDataRow.Delete();
CommitIESOL_Equivalency();
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
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(GradeDescFN)]== System.DBNull.Value)
{
  GradeDesc="";
}
else
{
  GradeDesc = IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(GradeIDFN ).ToString ()].ToString ();
}
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(GradeIDFN)]== System.DBNull.Value)
{
  GradeID="";
}
else
{
  GradeID = (string)IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(GradeIDFN)];
}
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(EquivalentScore_TOEFLFN)]== System.DBNull.Value)
{
}
else
{
}
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(EquivalentScore_IELTSFN)]== System.DBNull.Value)
{
}
else
{
}
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(EquivalentScore_iBTFN)]== System.DBNull.Value)
{
}
else
{
}
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(EquivalentScore_CBTFN)]== System.DBNull.Value)
{
}
else
{
}
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(EquivalentScore_PTEFN)]== System.DBNull.Value)
{
}
else
{
}
if (IESOL_EquivalencyDataRow[LibraryMOD.GetFieldName(EquivalentScore_CambridgeFN)]== System.DBNull.Value)
{
}
else
{
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
public int FindInMultiPKey(string PKGradeID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKGradeID;
IESOL_EquivalencyDataRow = dsIESOL_Equivalency.Tables[TableName].Rows.Find(findTheseVals);
if  ((IESOL_EquivalencyDataRow !=null)) 
{
lngCurRow = dsIESOL_Equivalency.Tables[TableName].Rows.IndexOf(IESOL_EquivalencyDataRow);
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
  lngCurRow = dsIESOL_Equivalency.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsIESOL_Equivalency.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsIESOL_Equivalency.Tables[TableName].Rows.Count > 0) 
{
  IESOL_EquivalencyDataRow = dsIESOL_Equivalency.Tables[TableName].Rows[lngCurRow];
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
daIESOL_Equivalency.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daIESOL_Equivalency.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daIESOL_Equivalency.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daIESOL_Equivalency.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
