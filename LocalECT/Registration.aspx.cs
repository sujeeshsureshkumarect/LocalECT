using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Registration : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        List<MirrorCLS> myList = new List<MirrorCLS>();
        Plans myPlan = new Plans();
        int iRegYear = 0;
        int iRegSem = 0;
        int iTerm = 0;
        byte bShift = 0;
        string sCourse = "";
        byte bClass = 0;
        string sNo = "";
        string sName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                iRegYear = (int)Session["RegYear"];
                iRegSem = (int)Session["RegSemester"];
                CurrentRole = (int)Session["CurrentRole"];

                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                   InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                }
                if (!IsPostBack)
                {
                    if (Session["CurrentCampus"] != null)
                    {
                        string sCampus = Session["CurrentCampus"].ToString();
                        Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    }
                    Session["myList"] = null;
                    Session["myPlan"] = null;
                    if (Session["CurrentStudent"] != null)
                    {
                        sSelectedValue.Value = Session["CurrentStudent"].ToString();
                        sSelectedText.Value = Session["CurrentStudentName"].ToString();
                        sNo = sSelectedValue.Value;
                        sName = sSelectedText.Value;
                        if (LibraryMOD.IsFileVerifiedFromRegistrar(sNo, Campus) == InitializeModule.FALSE_VALUE)
                        {
                            Server.Transfer("Authorization.aspx");
                            return;
                        }
                    }
                    if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                    {
                        string sid = Request.QueryString["sid"];
                        sSelectedValue.Value = sid;
                        sSelectedText.Value = getstudentname(sid);
                        sNo = sSelectedValue.Value;
                        sName = sSelectedText.Value;
                        if (LibraryMOD.IsFileVerifiedFromRegistrar(sNo, Campus) == InitializeModule.FALSE_VALUE)
                        {
                            Server.Transfer("Authorization.aspx");
                            return;
                        }
                    }
                }
                else
                {
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    if (Session["myList"] != null)
                    {
                        myList = (List<MirrorCLS>)Session["myList"];
                        myPlan = (Plans)Session["myPlan"];

                    }
                    sNo = sSelectedValue.Value;
                    sName = sSelectedText.Value;
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        public string getstudentname(string sid)
        {
            string sName = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select * from Web_Students_Search where sNo=@sNo", Conn);
            cmd.Parameters.AddWithValue("@sNo", sid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Conn.Open();
                da.Fill(dt);
                Conn.Close();
                if(dt.Rows.Count>0)
                {
                    sName = dt.Rows[0]["sName"].ToString();
                }
            }
            catch(Exception ex)
            {
                Conn.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
            return sName;
        }
    }
}