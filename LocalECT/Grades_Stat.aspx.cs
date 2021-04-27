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
  public partial class Grades_Stat : System.Web.UI.Page
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

        string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
        ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Reg_Balance,
            InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
        {
          Server.Transfer("Authorization.aspx");

        }
        FillTerms();

      }
    }

    private void FillTerms()
    {
      List<Semesters> myTerms = new List<Semesters>();
      SemesterDAL myTermsDAL = new SemesterDAL();
      try
      {
        myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
        for (int i = 0; i < myTerms.Count; i++)
        {
          ddlRegTermFrom.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
          ddlRegTermTo.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
        }
        int iYear = 0;
        int iSem = 0;
        int iTerm = 0;
        iYear = (int)Session["RegYear"];
        iSem = (int)Session["RegSemester"];
        iTerm = iYear * 10 + iSem;
        ddlRegTermFrom.SelectedValue = iTerm.ToString();
        ddlRegTermTo.SelectedValue = iTerm.ToString();

      }
      catch (Exception ex)
      {
        LibraryMOD.ShowErrorMessage(ex);
        lbl_Msg.Text = ex.Message;
        div_msg.Visible = true;
      }
      finally
      {
        myTerms.Clear();
      }
    }

    protected void lnk_FieldGenerate_Click(object sender, EventArgs e)
    {

      //string Byshifts;
      //string GenderExt;
      //string iGender;

      //if (drp_Campus.SelectedItem.Text == "Males")
      //{
      //  Campus = InitializeModule.EnumCampus.Males;
      //  Byshifts = " AND (SD.byteShift = 3 OR SD.byteShift = 4 OR  SD.byteShift = 8) ";
      //  GenderExt = "M";
      //  iGender = "1";
      //}
      //else
      //{
      //  Campus = InitializeModule.EnumCampus.Females;
      //  Byshifts = " AND (SD.byteShift = 1 OR SD.byteShift = 2 OR  SD.byteShift = 9) ";
      //  GenderExt = "F";
      //  iGender = "0";
      //}
      //string sWhere = " WHERE 1=1";
      //int iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
      //int iYear, iSem;
      //iYear = LibraryMOD.SeperateTerm(iRegTerm, out iSem);
      //int iPYear, iPSem;
      //iPYear = iYear;
      //iPSem = iSem;
      //if (iSem == 1)
      //{
      //  iPSem = 4;
      //  iPYear -= 1;
      //}
      //else
      //{
      //  iPSem -= 1;
      //}

      Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
      SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
      string sSQL = "";

      sSQL = " SELECT        iTerm AS Semester, (CASE WHEN iGender = 0 THEN 'F' ELSE 'M' END) AS Gender, Department AS Faculty, sMajor AS Major, sCourse AS Code, sUnified AS Unified, sDesc AS Course, COUNT(sID) AS STDs,  ";
      sSQL += "                          SUM((CASE WHEN sGrade = 'EW' OR  ";
      sSQL += "                          sGrade = 'W' THEN 1 ELSE 0 END)) AS EW_W, SUM((CASE WHEN sGrade = 'F' THEN 1 ELSE 0 END)) AS Faild, SUM((CASE WHEN sGrade <> 'F' AND sGrade <> 'EW' AND sGrade <> 'W' THEN 1 ELSE 0 END)) AS Passed  ";
      sSQL += " FROM            (SELECT        TOP (100) PERCENT iTerm, iGender, sID, sMajor, sCourse, sUnified, sDesc, cMark, sGrade, Department  ";
      sSQL += "                           FROM            Mixed_Marks  ";
      sSQL += "                           WHERE        (iTerm BETWEEN "+ddlRegTermFrom.SelectedValue+" AND "+ddlRegTermTo.SelectedValue+")  ";
      sSQL += "                           ORDER BY iTerm, sMajor, sCourse, iGender) AS data  ";
      sSQL += " GROUP BY iTerm, (CASE WHEN iGender = 0 THEN 'F' ELSE 'M' END) , sMajor, sCourse, sUnified, sDesc, Department  ";
      sSQL += " ORDER BY Semester, Gender, Major, Unified, Code  ";



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
