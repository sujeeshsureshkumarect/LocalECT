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
public class LibTransactionDetails
{
//Creation Date: 28/10/2014 6:17 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_TransactionID; 
private int m_TransNo; 
private int m_BookID; 
private int m_Quantity; 
private double m_Price; 
private int m_StockID; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int TransactionID
{
get { return  m_TransactionID; }
set {m_TransactionID  = value ; }
}
public int TransNo
{
get { return  m_TransNo; }
set {m_TransNo  = value ; }
}
public int BookID
{
get { return  m_BookID; }
set {m_BookID  = value ; }
}
public int Quantity
{
get { return  m_Quantity; }
set {m_Quantity  = value ; }
}
public double Price
{
get { return  m_Price; }
set {m_Price  = value ; }
}
public int StockID
{
get { return  m_StockID; }
set {m_StockID  = value ; }
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
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public LibTransactionDetails()
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
public class LibTransactionDetailsDAL : LibTransactionDetails
{
#region "Decleration"
private string m_TableName;
private string m_TransactionIDFN ;
private string m_TransNoFN ;
private string m_BookIDFN ;
private string m_QuantityFN ;
private string m_PriceFN ;
private string m_StockIDFN ;
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
public string TransactionIDFN 
{
get { return  m_TransactionIDFN; }
set {m_TransactionIDFN  = value ; }
}
public string TransNoFN 
{
get { return  m_TransNoFN; }
set {m_TransNoFN  = value ; }
}
public string BookIDFN 
{
get { return  m_BookIDFN; }
set {m_BookIDFN  = value ; }
}
public string QuantityFN 
{
get { return  m_QuantityFN; }
set {m_QuantityFN  = value ; }
}
public string PriceFN 
{
get { return  m_PriceFN; }
set {m_PriceFN  = value ; }
}
public string StockIDFN 
{
get { return  m_StockIDFN; }
set {m_StockIDFN  = value ; }
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
public LibTransactionDetailsDAL()
{
try
{
this.TableName = "LibTransactionDetails";
this.TransactionIDFN = m_TableName + ".TransactionID";
this.TransNoFN = m_TableName + ".TransNo";
this.BookIDFN = m_TableName + ".BookID";
this.QuantityFN = m_TableName + ".Quantity";
this.PriceFN = m_TableName + ".Price";
this.StockIDFN = m_TableName + ".StockID";
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
sSQL +=TransactionIDFN;
sSQL += " , " + TransNoFN;
sSQL += " , " + BookIDFN;
sSQL += " , " + QuantityFN;
sSQL += " , " + PriceFN;
sSQL += " , " + StockIDFN;
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
//-----GetListSQl Function ---------------------------------
public string GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=TransactionIDFN;
sSQL += " , " + TransNoFN;
sSQL += " , " + BookIDFN;
sSQL += "  FROM " + m_TableName;
sSQL += " " + sCondition;
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
sSQL +=TransactionIDFN;
sSQL += " , " + TransNoFN;
sSQL += " , " + BookIDFN;
sSQL += " , " + QuantityFN;
sSQL += " , " + PriceFN;
sSQL += " , " + StockIDFN;
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
string sSQL  = "";
try
{
sSQL = "UPDATE " + TableName;
sSQL += " SET ";
sSQL += LibraryMOD.GetFieldName(TransactionIDFN) + "=@TransactionID";
sSQL += " , " + LibraryMOD.GetFieldName(TransNoFN) + "=@TransNo";
sSQL += " , " + LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
sSQL += " , " + LibraryMOD.GetFieldName(QuantityFN) + "=@Quantity";
sSQL += " , " + LibraryMOD.GetFieldName(PriceFN) + "=@Price";
sSQL += " , " + LibraryMOD.GetFieldName(StockIDFN) + "=@StockID";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(TransactionIDFN)+"=@TransactionID";
sSQL +=  " And " + LibraryMOD.GetFieldName(TransNoFN)+"=@TransNo";
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
sSQL = "INSERT INTO "  + TableName;
sSQL += "( ";
sSQL +=LibraryMOD.GetFieldName(TransactionIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(TransNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(BookIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(QuantityFN);
sSQL += " , " + LibraryMOD.GetFieldName(PriceFN);
sSQL += " , " + LibraryMOD.GetFieldName(StockIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @TransactionID";
sSQL += " ,@TransNo";
sSQL += " ,@BookID";
sSQL += " ,@Quantity";
sSQL += " ,@Price";
sSQL += " ,@StockID";
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
sSQL += LibraryMOD.GetFieldName(TransactionIDFN)+"=@TransactionID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(TransNoFN)+"=@TransNo";
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
    public int GetTotalItems(int iTransID)
    {
     String sSQL ;
        int iTotalItems=0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew );
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
           
            sSQL = "SELECT SUM(Quantity) AS TotalItems";
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + TransactionIDFN + "=" + iTransID;

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader ;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection );

            
            if ( datReader.Read() )
            {
            iTotalItems  = datReader.GetInt32 (0);
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

        return iTotalItems;
    }
public List< LibTransactionDetails> GetLibTransactionDetails(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the LibTransactionDetails
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
List<LibTransactionDetails> results = new List<LibTransactionDetails>();
try
{
//Default Value
LibTransactionDetails myLibTransactionDetails = new LibTransactionDetails();
if (isDeafaultIncluded)
{
//Change the code here
myLibTransactionDetails.TransactionID = 0;
myLibTransactionDetails.TransNo = 0;
//myLibTransactionDetails.TransNo = "Select LibTransactionDetails ...";
results.Add(myLibTransactionDetails);
}
while (reader.Read())
{
myLibTransactionDetails = new LibTransactionDetails();
if (reader[LibraryMOD.GetFieldName(TransactionIDFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.TransactionID = 0;
}
else
{
myLibTransactionDetails.TransactionID = int.Parse(reader[LibraryMOD.GetFieldName( TransactionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(TransNoFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.TransNo = 0;
}
else
{
myLibTransactionDetails.TransNo = int.Parse(reader[LibraryMOD.GetFieldName( TransNoFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.BookID = 0;
}
else
{
myLibTransactionDetails.BookID = int.Parse(reader[LibraryMOD.GetFieldName( BookIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(QuantityFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.Quantity = 0;
}
else
{
myLibTransactionDetails.Quantity = int.Parse(reader[LibraryMOD.GetFieldName( QuantityFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(StockIDFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.StockID = 0;
}
else
{
myLibTransactionDetails.StockID = int.Parse(reader[LibraryMOD.GetFieldName( StockIDFN) ].ToString());
}
myLibTransactionDetails.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myLibTransactionDetails.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myLibTransactionDetails.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myLibTransactionDetails.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myLibTransactionDetails);
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
public List< LibTransactionDetails > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<LibTransactionDetails> results = new List<LibTransactionDetails>();
try
{
//Default Value
LibTransactionDetails myLibTransactionDetails= new LibTransactionDetails();
if (isDeafaultIncluded)
 {
//Change the code here
 myLibTransactionDetails.TransactionID = -1;
 myLibTransactionDetails.TransNo =0 ;
results.Add(myLibTransactionDetails);
 }
while (reader.Read())
{
myLibTransactionDetails = new LibTransactionDetails();
if (reader[LibraryMOD.GetFieldName(TransactionIDFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.TransactionID = 0;
}
else
{
myLibTransactionDetails.TransactionID = int.Parse(reader[LibraryMOD.GetFieldName( TransactionIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(TransNoFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.TransNo = 0;
}
else
{
myLibTransactionDetails.TransNo = int.Parse(reader[LibraryMOD.GetFieldName( TransNoFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
{
myLibTransactionDetails.BookID = 0;
}
else
{
myLibTransactionDetails.BookID = int.Parse(reader[LibraryMOD.GetFieldName( BookIDFN) ].ToString());
}
 results.Add(myLibTransactionDetails);
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
public int UpdateLibTransactionDetails(InitializeModule.EnumCampus Campus, int iMode,int TransactionID,int TransNo,int BookID,int Quantity,double Price,int StockID,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
LibTransactionDetails theLibTransactionDetails = new LibTransactionDetails();
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
Cmd.Parameters.Add(new SqlParameter("@TransactionID",TransactionID));
Cmd.Parameters.Add(new SqlParameter("@TransNo",TransNo));
Cmd.Parameters.Add(new SqlParameter("@BookID",BookID));
Cmd.Parameters.Add(new SqlParameter("@Quantity",Quantity));
Cmd.Parameters.Add(new SqlParameter("@Price",Price));
Cmd.Parameters.Add(new SqlParameter("@StockID",StockID));
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
public int DeleteLibTransactionDetails(InitializeModule.EnumCampus Campus,int TransactionID,int TransNo)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@TransactionID", TransactionID ));
Cmd.Parameters.Add(new SqlParameter("@TransNo", TransNo ));
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
DataTable dt = new DataTable("LibTransactionDetails");
DataView dv = new DataView();
List<LibTransactionDetails> myLibTransactionDetailss = new List<LibTransactionDetails>();
try
{
myLibTransactionDetailss = GetLibTransactionDetails(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("TransactionID", Type.GetType("int"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("TransNo", Type.GetType("int"));
dt.Columns.Add(col1 );
dt.Constraints.Add(new UniqueConstraint(col0));
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myLibTransactionDetailss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myLibTransactionDetailss[i].TransactionID;
  dr[2] = myLibTransactionDetailss[i].TransNo;
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
myLibTransactionDetailss.Clear();
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
sSQL += TransactionIDFN;
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
public class LibTransactionDetailsCls : LibTransactionDetailsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daLibTransactionDetails;
private DataSet m_dsLibTransactionDetails;
public DataRow LibTransactionDetailsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsLibTransactionDetails
{
get { return m_dsLibTransactionDetails ; }
set { m_dsLibTransactionDetails = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public LibTransactionDetailsCls()
{
try
{
dsLibTransactionDetails= new DataSet();

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
public virtual SqlDataAdapter GetLibTransactionDetailsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daLibTransactionDetails = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibTransactionDetails);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daLibTransactionDetails.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibTransactionDetails;
}
public virtual SqlDataAdapter GetLibTransactionDetailsDataAdapter(SqlConnection con)  
{
try
{
daLibTransactionDetails = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daLibTransactionDetails.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdLibTransactionDetails;
cmdLibTransactionDetails = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@TransactionID", SqlDbType.Int, 4, "TransactionID" );
//'cmdRolePermission.Parameters.Add("@TransNo", SqlDbType.Int, 4, "TransNo" );
daLibTransactionDetails.SelectCommand = cmdLibTransactionDetails;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdLibTransactionDetails = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdLibTransactionDetails.Parameters.Add("@TransactionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(TransactionIDFN));
cmdLibTransactionDetails.Parameters.Add("@TransNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(TransNoFN));
cmdLibTransactionDetails.Parameters.Add("@BookID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BookIDFN));
cmdLibTransactionDetails.Parameters.Add("@Quantity", SqlDbType.Int,4, LibraryMOD.GetFieldName(QuantityFN));
cmdLibTransactionDetails.Parameters.Add("@Price", SqlDbType.Decimal,7, LibraryMOD.GetFieldName(PriceFN));
cmdLibTransactionDetails.Parameters.Add("@StockID", SqlDbType.Int,4, LibraryMOD.GetFieldName(StockIDFN));
cmdLibTransactionDetails.Parameters.Add("@strUserCreate", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(strUserCreateFN));
cmdLibTransactionDetails.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdLibTransactionDetails.Parameters.Add("@strUserSave", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(strUserSaveFN));
cmdLibTransactionDetails.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdLibTransactionDetails.Parameters.Add("@strMachine", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(strMachineFN));
cmdLibTransactionDetails.Parameters.Add("@strNUser", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdLibTransactionDetails.Parameters.Add("@TransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransactionIDFN));
Parmeter = cmdLibTransactionDetails.Parameters.Add("@TransNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daLibTransactionDetails.UpdateCommand = cmdLibTransactionDetails;
daLibTransactionDetails.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdLibTransactionDetails = new SqlCommand(GetInsertCommand(), con);
cmdLibTransactionDetails.Parameters.Add("@TransactionID", SqlDbType.Int,4, LibraryMOD.GetFieldName(TransactionIDFN));
cmdLibTransactionDetails.Parameters.Add("@TransNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(TransNoFN));
cmdLibTransactionDetails.Parameters.Add("@BookID", SqlDbType.Int,4, LibraryMOD.GetFieldName(BookIDFN));
cmdLibTransactionDetails.Parameters.Add("@Quantity", SqlDbType.Int,4, LibraryMOD.GetFieldName(QuantityFN));
cmdLibTransactionDetails.Parameters.Add("@Price", SqlDbType.Decimal,7, LibraryMOD.GetFieldName(PriceFN));
cmdLibTransactionDetails.Parameters.Add("@StockID", SqlDbType.Int,4, LibraryMOD.GetFieldName(StockIDFN));
cmdLibTransactionDetails.Parameters.Add("@strUserCreate", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(strUserCreateFN));
cmdLibTransactionDetails.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdLibTransactionDetails.Parameters.Add("@strUserSave", SqlDbType.VarChar,20, LibraryMOD.GetFieldName(strUserSaveFN));
cmdLibTransactionDetails.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdLibTransactionDetails.Parameters.Add("@strMachine", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(strMachineFN));
cmdLibTransactionDetails.Parameters.Add("@strNUser", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daLibTransactionDetails.InsertCommand =cmdLibTransactionDetails;
daLibTransactionDetails.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdLibTransactionDetails = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdLibTransactionDetails.Parameters.Add("@TransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransactionIDFN));
Parmeter = cmdLibTransactionDetails.Parameters.Add("@TransNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransNoFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daLibTransactionDetails.DeleteCommand =cmdLibTransactionDetails;
daLibTransactionDetails.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daLibTransactionDetails.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daLibTransactionDetails;
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
dr = dsLibTransactionDetails.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(TransactionIDFN)]=TransactionID;
dr[LibraryMOD.GetFieldName(TransNoFN)]=TransNo;
dr[LibraryMOD.GetFieldName(BookIDFN)]=BookID;
dr[LibraryMOD.GetFieldName(QuantityFN)]=Quantity;
dr[LibraryMOD.GetFieldName(PriceFN)]=Price;
dr[LibraryMOD.GetFieldName(StockIDFN)]=StockID;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsLibTransactionDetails.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsLibTransactionDetails.Tables[TableName].Select(LibraryMOD.GetFieldName(TransactionIDFN)  + "=" + TransactionID  + " AND " + LibraryMOD.GetFieldName(TransNoFN) + "=" + TransNo);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(TransactionIDFN)]=TransactionID;
drAry[0][LibraryMOD.GetFieldName(TransNoFN)]=TransNo;
drAry[0][LibraryMOD.GetFieldName(BookIDFN)]=BookID;
drAry[0][LibraryMOD.GetFieldName(QuantityFN)]=Quantity;
drAry[0][LibraryMOD.GetFieldName(PriceFN)]=Price;
drAry[0][LibraryMOD.GetFieldName(StockIDFN)]=StockID;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
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
public int CommitLibTransactionDetails()  
{
//CommitLibTransactionDetails= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daLibTransactionDetails.Update(dsLibTransactionDetails, TableName);
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
FindInMultiPKey(TransactionID,TransNo);
if (( LibTransactionDetailsDataRow != null)) 
{
LibTransactionDetailsDataRow.Delete();
CommitLibTransactionDetails();
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
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(TransactionIDFN)]== System.DBNull.Value)
{
  TransactionID=0;
}
else
{
  TransactionID = (int)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(TransactionIDFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(TransNoFN)]== System.DBNull.Value)
{
  TransNo=0;
}
else
{
  TransNo = (int)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(TransNoFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(BookIDFN)]== System.DBNull.Value)
{
  BookID=0;
}
else
{
  BookID = (int)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(BookIDFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(QuantityFN)]== System.DBNull.Value)
{
  Quantity=0;
}
else
{
  Quantity = (int)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(QuantityFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(PriceFN)]== System.DBNull.Value)
{
}
else
{
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(StockIDFN)]== System.DBNull.Value)
{
  StockID=0;
}
else
{
  StockID = (int)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(StockIDFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)LibTransactionDetailsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKTransactionID,int PKTransNo) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKTransactionID;
findTheseVals[1] = PKTransNo;
LibTransactionDetailsDataRow = dsLibTransactionDetails.Tables[TableName].Rows.Find(findTheseVals);
if  ((LibTransactionDetailsDataRow !=null)) 
{
lngCurRow = dsLibTransactionDetails.Tables[TableName].Rows.IndexOf(LibTransactionDetailsDataRow);
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
  lngCurRow = dsLibTransactionDetails.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsLibTransactionDetails.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsLibTransactionDetails.Tables[TableName].Rows.Count > 0) 
{
  LibTransactionDetailsDataRow = dsLibTransactionDetails.Tables[TableName].Rows[lngCurRow];
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
daLibTransactionDetails.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibTransactionDetails.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daLibTransactionDetails.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daLibTransactionDetails.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
