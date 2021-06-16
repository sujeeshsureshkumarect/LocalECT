using System;
using System.Collections;
using System.Configuration;
using LocalECT.DAL;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace LocalECT
{
  public partial class CS_Survey_Form_Create : System.Web.UI.Page
  {
    InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
    Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
    int CurrentRole = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (Session["CurrentRole"] != null)
        {
          CurrentRole = (int)Session["CurrentRole"];
          if (!IsPostBack)
          {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
            InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
            {
              //Server.Transfer("Authorization.aspx");
            }
          }
        }
        else
        {
          Session.RemoveAll();
          Response.Redirect("Login.aspx");

        }
        if (Session["CurrentUserName"] != null)
        {
          if (!IsPostBack)
          {

            //hdn_sCode.Value = Create16DigitString();
            //  txt_dAdded.Text = DateTime.Today.ToString();

          }
        }
      }
      catch (Exception exp)
      {
        Console.WriteLine("{0} Exception caught.", exp);
      }
      finally
      {

      }
    }


    public string Create16DigitString()
    {
      var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      var stringChars = new char[5];
      var random = new Random((int)DateTime.Now.Ticks);
      for (int i = 0; i < stringChars.Length; i++)
      {
        stringChars[i] = chars[random.Next(chars.Length)];
      }
      var finalString = new String(stringChars);
      return finalString.ToString();
    }
    public void ClearSession()
    {
      Session["CurrentUserName"] = null;
      Session["CurrentUserNo"] = null;
      Session["CurrentYear"] = null;
      Session["CurrentSemester"] = null;
      Session["CurrentCampus"] = null;
      Session["CurrentRole"] = null;
      Session["CurrentSystem"] = null;
      Session["CurrentLecturer"] = null;
      Session["MarkYear"] = null;
      Session["MarkSemester"] = null;
      Session["CurrentStudent"] = null;
      Session["CurrentStudentName"] = null;
      Session["CurrentMajorCampus"] = null;
    }
    private void showErr(string sMsg)
    {
      Session["errMsg"] = sMsg;
      Response.Redirect("ErrPage.aspx");
    }

    protected void btn_Create_Click(object sender, EventArgs e)
    {
      SqlCommand cmd = new SqlCommand("insert into CS_Survey_Form values(@sRef,@sName,@dAdded,@sAddedby,@dUpdated,@sUpdatedby)", sc);


      cmd.Parameters.AddWithValue("@sRef", txt_Ref.Text.Trim());
      
      cmd.Parameters.AddWithValue("@sName", txt_sName.Text.Trim());
   
      cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
      cmd.Parameters.AddWithValue("@sAddedby", Session["CurrentUserName"].ToString());
      cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
      cmd.Parameters.AddWithValue("@sUpdatedby", Session["CurrentUserName"].ToString());

      try
      {
        sc.Open();
        cmd.ExecuteNonQuery();
        sc.Close();

        lbl_Msg.Text = "Survey Form Created Successfully ";
        div_msg.Visible = true;

        txt_Ref.Text = "";
        txt_sName.Text = "";
       
      }
      catch (Exception ex)
      {
        sc.Close();
        Console.WriteLine("{0} Exception caught.", ex);
      }
      finally
      {
        sc.Close();
      }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("Strategy_Survey_Form");
    }
  }
}
