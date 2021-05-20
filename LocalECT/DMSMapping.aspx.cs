using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
  public partial class DMSMapping : System.Web.UI.Page
  {
    
      int CurrentRole = 0;
      InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
      protected void Page_Load(object sender, EventArgs e)
      {
        if (Session["CurrentRole"] != null)
        {

          CurrentRole = (int)Session["CurrentRole"];

        }
        else
        {
          Session.RemoveAll();
          Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
          if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.DMSMapping,
              InitializeModule.enumPrivilege.DMSView, CurrentRole) != true)
          {
            Server.Transfer("Authorization.aspx");
          }                  
        }
      }          
      protected void lnk_FieldGenerate_Click(object sender, EventArgs e)
      {
        if (drp_Campus.SelectedItem.Text == "Males")
        {
          Campus = InitializeModule.EnumCampus.Males;          
        }
        else
        {
          Campus = InitializeModule.EnumCampus.Females;          
        }
               
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
        string sSQL = "SELECT [iSerial] as Serial,[sSID] as SID,[iUnifiedID] as UID,[sName] as Name,[iPlace] as Storage,[isDBFound],[isScanned],[dAdded] as Added,[sAddedby] as [Added by],[sNote] as Note,[sMFilesLink] as [DMS Link] FROM [dbo].[ECT_MFiles_Scan_Mapping]";

     
        SqlCommand cmd1 = new SqlCommand(sSQL, sc);
        cmd1.CommandTimeout = 180;
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        try
        {
          sc.Open();
          da1.Fill(dt1);
          sc.Close();

          if (dt1.Rows.Count > 0)
          {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table id='example' class='table table-striped table-bordered' style='width: 100%'>" + Environment.NewLine + "");

            //Add Table Header
            sb.Append("<thead>" + Environment.NewLine + "<tr class='headings'>" + Environment.NewLine + "");
            sb.Append("<th>#</th> " + Environment.NewLine + "");
            foreach (DataColumn column in dt1.Columns)
            {
              sb.Append("<th>" + column.ColumnName + "</th> " + Environment.NewLine + "");
            }
            sb.Append("</tr>" + Environment.NewLine + "</thead>" + Environment.NewLine + "");


            //Add Table Rows
            int i = 1;
            foreach (DataRow row in dt1.Rows)
            {
              sb.Append("<tr>" + Environment.NewLine + "");
              sb.Append("<td>" + i + "</td>" + Environment.NewLine + "");
              //Add Table Columns
              foreach (DataColumn column in dt1.Columns)
              {
                sb.Append("<td>" + row[column.ColumnName].ToString() + "</td>" + Environment.NewLine + "");
              }
              sb.Append("</tr>" + Environment.NewLine + "");
              i++;
            }

            sb.Append("</table>" + Environment.NewLine + "");
            DynamicTable.Text = sb.ToString();
          }
          else
          {
            DynamicTable.Text = "<p><b>No Results to show</b></p>";
          }
        }
        catch (Exception ex)
        {
          sc.Close();
          Console.WriteLine(ex.Message);
        }
        finally
        {
          sc.Close();
        }

      }
    }
}
