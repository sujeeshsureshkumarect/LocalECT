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
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Form_Types
{
//Creation Date: 23/03/2010 7:11:08 PM
//Programmer Name : Ihab Awad
//-----Decleration --------------
#region "Decleration"
private int m_byteForm; 
private string m_strFormDesc; 
private int m_byteFormBase; 
private string m_bTrans; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int byteForm
{
get { return  m_byteForm; }
set {m_byteForm  = value ; }
}
public string strFormDesc
{
get { return  m_strFormDesc; }
set {m_strFormDesc  = value ; }
}
public int byteFormBase
{
get { return  m_byteFormBase; }
set {m_byteFormBase  = value ; }
}
public string bTrans
{
get { return  m_bTrans; }
set {m_bTrans  = value ; }
}
public string strUserCreate
{
get { return  m_strUserCreate; }
set {m_strUserCreate  = value ; }
}
public DateTime dateCreate
{
get { return  m_dateCreate; }
set {m_dateCreate  = value ; }
}
public string strUserSave
{
get { return  m_strUserSave; }
set {m_strUserSave  = value ; }
}
public DateTime dateLastSave
{
get { return  m_dateLastSave; }
set {m_dateLastSave  = value ; }
}
public string strMachine
{
get { return  m_strMachine; }
set {m_strMachine  = value ; }
}
public string strNUser
{
get { return  m_strNUser; }
set {m_strNUser  = value ; }
}
#endregion
//'-----------------------------------------------------
public Form_Types()
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
public class Form_TypesDAL : Form_Types
{
#region "Decleration"
private string m_TableName;
private string m_byteFormFN ;
private string m_strFormDescFN ;
private string m_byteFormBaseFN ;
private string m_bTransFN ;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string byteFormFN 
{
get { return  m_byteFormFN; }
set {m_byteFormFN  = value ; }
}
public string strFormDescFN 
{
get { return  m_strFormDescFN; }
set {m_strFormDescFN  = value ; }
}
public string byteFormBaseFN 
{
get { return  m_byteFormBaseFN; }
set {m_byteFormBaseFN  = value ; }
}
public string bTransFN 
{
get { return  m_bTransFN; }
set {m_bTransFN  = value ; }
}
public string strUserCreateFN 
{
get { return  m_strUserCreateFN; }
set {m_strUserCreateFN  = value ; }
}
public string dateCreateFN 
{
get { return  m_dateCreateFN; }
set {m_dateCreateFN  = value ; }
}
public string strUserSaveFN 
{
get { return  m_strUserSaveFN; }
set {m_strUserSaveFN  = value ; }
}
public string dateLastSaveFN 
{
get { return  m_dateLastSaveFN; }
set {m_dateLastSaveFN  = value ; }
}
public string strMachineFN 
{
get { return  m_strMachineFN; }
set {m_strMachineFN  = value ; }
}
public string strNUserFN 
{
get { return  m_strNUserFN; }
set {m_strNUserFN  = value ; }
}
#endregion
//================End Properties ===================
public Form_TypesDAL()
{
try
{
this.TableName = "Reg_Form_Types";
this.byteFormFN = m_TableName + ".byteForm";
this.strFormDescFN = m_TableName + ".strFormDesc";
this.byteFormBaseFN = m_TableName + ".byteFormBase";
this.bTransFN = m_TableName + ".bTrans";
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
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=byteFormFN;
sSQL += " , " + strFormDescFN;
sSQL += " , " + byteFormBaseFN;
sSQL += " , " + bTransFN;
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
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=byteFormFN;
sSQL += " , " + strFormDescFN;
sSQL += " , " + byteFormBaseFN;
sSQL += " , " + bTransFN;
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
public string GetListSQL(string sWhere)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += byteFormFN;
        sSQL += " , " + strFormDescFN;
        sSQL += "  FROM " + m_TableName;
        if (!string.IsNullOrEmpty(sWhere))
        {
            sSQL += "  Where " + sWhere;
        }
        sSQL += " Order By " + strFormDescFN;
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
sSQL += LibraryMOD.GetFieldName(byteFormFN) + "=@byteForm";
sSQL += " , " + LibraryMOD.GetFieldName(strFormDescFN) + "=@strFormDesc";
sSQL += " , " + LibraryMOD.GetFieldName(byteFormBaseFN) + "=@byteFormBase";
sSQL += " , " + LibraryMOD.GetFieldName(bTransFN) + "=@bTrans";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(byteFormFN)+"=@byteForm";
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
sSQL +=LibraryMOD.GetFieldName(byteFormFN);
sSQL += " , " + LibraryMOD.GetFieldName(strFormDescFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteFormBaseFN);
sSQL += " , " + LibraryMOD.GetFieldName(bTransFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @byteForm";
sSQL += " ,@strFormDesc";
sSQL += " ,@byteFormBase";
sSQL += " ,@bTrans";
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
public string  GetDeleteCommand()
{
string sSQL= "";
try
{
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(byteFormFN)+"=@byteForm";
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
public List< Form_Types> GetForm_Types(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Form_Types
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
List<Form_Types> results = new List<Form_Types>();
try
{
//Default Value
Form_Types myForm_Types = new Form_Types();
if (isDeafaultIncluded)
{
//Change the code here
myForm_Types.byteForm = 0;
myForm_Types.strFormDesc = "Select Form_Type ...";
results.Add(myForm_Types);
}
while (reader.Read())
{
myForm_Types = new Form_Types();
if (reader[LibraryMOD.GetFieldName(byteFormFN)].Equals(DBNull.Value))
{
myForm_Types.byteForm = 0;
}
else
{
myForm_Types.byteForm = int.Parse(reader[LibraryMOD.GetFieldName( byteFormFN) ].ToString());
}
myForm_Types.strFormDesc =reader[LibraryMOD.GetFieldName( strFormDescFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteFormBaseFN)].Equals(DBNull.Value))
{
myForm_Types.byteFormBase = 0;
}
else
{
myForm_Types.byteFormBase = int.Parse(reader[LibraryMOD.GetFieldName( byteFormBaseFN) ].ToString());
}
myForm_Types.bTrans =reader[LibraryMOD.GetFieldName( bTransFN) ].ToString();
myForm_Types.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myForm_Types.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myForm_Types.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myForm_Types.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myForm_Types.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myForm_Types.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myForm_Types);
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
public List<Form_Types> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
    
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);
    
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Form_Types> results = new List<Form_Types>();
    try
    {
        //Default Value
        Form_Types myForm_Types = new Form_Types();
        if (isDeafaultIncluded)
        {
            //Change the code here
            myForm_Types.byteForm = 0;
            myForm_Types.strFormDesc = "Select Form_Type ...";
            results.Add(myForm_Types);
        }
        while (reader.Read())
        {
            myForm_Types = new Form_Types();
            if (reader[LibraryMOD.GetFieldName(byteFormFN)].Equals(DBNull.Value))
            {
                myForm_Types.byteForm = 0;
            }
            else
            {
                myForm_Types.byteForm = int.Parse(reader[LibraryMOD.GetFieldName(byteFormFN)].ToString());
            }
            myForm_Types.strFormDesc = reader[LibraryMOD.GetFieldName(strFormDescFN)].ToString();
            
            results.Add(myForm_Types);
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
public int UpdateForm_Types(InitializeModule.EnumCampus Campus, int iMode,int byteForm,string strFormDesc,int byteFormBase,string bTrans,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Form_Types theForm_Types = new Form_Types();
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
Cmd.Parameters.Add(new SqlParameter("@byteForm",byteForm));
Cmd.Parameters.Add(new SqlParameter("@strFormDesc",strFormDesc));
Cmd.Parameters.Add(new SqlParameter("@byteFormBase",byteFormBase));
Cmd.Parameters.Add(new SqlParameter("@bTrans",bTrans));
Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));
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
public int DeleteForm_Types(InitializeModule.EnumCampus Campus,string byteForm)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@byteForm", byteForm ));
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
DataTable dt = new DataTable("Form_Types");
DataView dv = new DataView();
List<Form_Types> myForm_Typess = new List<Form_Types>();
try
{
myForm_Typess = GetForm_Types(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("byteForm", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strFormDesc", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("byteFormBase", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myForm_Typess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myForm_Typess[i].byteForm;
  dr[2] = myForm_Typess[i].strFormDesc;
  dr[3] = myForm_Typess[i].byteFormBase;
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
myForm_Typess.Clear();
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
sSQL += byteFormFN;
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
public class Form_TypesCls : Form_TypesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daForm_Types;
private DataSet m_dsForm_Types;
public DataRow Form_TypesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsForm_Types
{
get { return m_dsForm_Types ; }
set { m_dsForm_Types = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Form_TypesCls()
{
try
{
dsForm_Types= new DataSet();

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
public virtual SqlDataAdapter GetForm_TypesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daForm_Types = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daForm_Types);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daForm_Types.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daForm_Types;
}
public virtual SqlDataAdapter GetForm_TypesDataAdapter(SqlConnection con)  
{
try
{
daForm_Types = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daForm_Types.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdForm_Types;
cmdForm_Types = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@byteForm", SqlDbType.Int, 4, "byteForm" );
daForm_Types.SelectCommand = cmdForm_Types;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdForm_Types = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdForm_Types.Parameters.Add("@byteForm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormFN));
cmdForm_Types.Parameters.Add("@strFormDesc", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strFormDescFN));
cmdForm_Types.Parameters.Add("@byteFormBase", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormBaseFN));
cmdForm_Types.Parameters.Add("@bTrans", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bTransFN));
cmdForm_Types.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdForm_Types.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdForm_Types.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdForm_Types.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdForm_Types.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdForm_Types.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdForm_Types.Parameters.Add("@byteForm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFormFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daForm_Types.UpdateCommand = cmdForm_Types;
daForm_Types.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdForm_Types = new SqlCommand(GetInsertCommand(), con);
cmdForm_Types.Parameters.Add("@byteForm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormFN));
cmdForm_Types.Parameters.Add("@strFormDesc", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strFormDescFN));
cmdForm_Types.Parameters.Add("@byteFormBase", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormBaseFN));
cmdForm_Types.Parameters.Add("@bTrans", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bTransFN));
cmdForm_Types.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdForm_Types.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdForm_Types.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdForm_Types.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdForm_Types.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdForm_Types.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daForm_Types.InsertCommand =cmdForm_Types;
daForm_Types.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdForm_Types = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdForm_Types.Parameters.Add("@byteForm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFormFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daForm_Types.DeleteCommand =cmdForm_Types;
daForm_Types.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daForm_Types.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daForm_Types;
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
dr = dsForm_Types.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(byteFormFN)]=byteForm;
dr[LibraryMOD.GetFieldName(strFormDescFN)]=strFormDesc;
dr[LibraryMOD.GetFieldName(byteFormBaseFN)]=byteFormBase;
dr[LibraryMOD.GetFieldName(bTransFN)]=bTrans;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsForm_Types.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsForm_Types.Tables[TableName].Select(LibraryMOD.GetFieldName(byteFormFN)  + "=" + byteForm);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(byteFormFN)]=byteForm;
drAry[0][LibraryMOD.GetFieldName(strFormDescFN)]=strFormDesc;
drAry[0][LibraryMOD.GetFieldName(byteFormBaseFN)]=byteFormBase;
drAry[0][LibraryMOD.GetFieldName(bTransFN)]=bTrans;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
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
public int CommitForm_Types()  
{
//CommitForm_Types= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daForm_Types.Update(dsForm_Types, TableName);
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
FindInMultiPKey(byteForm);
if (( Form_TypesDataRow != null)) 
{
Form_TypesDataRow.Delete();
CommitForm_Types();
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
if (Form_TypesDataRow[LibraryMOD.GetFieldName(byteFormFN)]== System.DBNull.Value)
{
  byteForm=0;
}
else
{
  byteForm = (int)Form_TypesDataRow[LibraryMOD.GetFieldName(byteFormFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(strFormDescFN)]== System.DBNull.Value)
{
  strFormDesc="";
}
else
{
  strFormDesc = (string)Form_TypesDataRow[LibraryMOD.GetFieldName(strFormDescFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(byteFormBaseFN)]== System.DBNull.Value)
{
  byteFormBase=0;
}
else
{
  byteFormBase = (int)Form_TypesDataRow[LibraryMOD.GetFieldName(byteFormBaseFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(bTransFN)]== System.DBNull.Value)
{
  bTrans="";
}
else
{
  bTrans = (string)Form_TypesDataRow[LibraryMOD.GetFieldName(bTransFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Form_TypesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Form_TypesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Form_TypesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Form_TypesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Form_TypesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Form_TypesDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Form_TypesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKbyteForm) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKbyteForm;
Form_TypesDataRow = dsForm_Types.Tables[TableName].Rows.Find(findTheseVals);
if  ((Form_TypesDataRow !=null)) 
{
lngCurRow = dsForm_Types.Tables[TableName].Rows.IndexOf(Form_TypesDataRow);
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
  lngCurRow = dsForm_Types.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsForm_Types.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsForm_Types.Tables[TableName].Rows.Count > 0) 
{
  Form_TypesDataRow = dsForm_Types.Tables[TableName].Rows[lngCurRow];
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
daForm_Types.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daForm_Types.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daForm_Types.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daForm_Types.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
