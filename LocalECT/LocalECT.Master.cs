using LocalECT.DAL;
using System;
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
    public partial class LocalECT : System.Web.UI.MasterPage
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        DataTable Menus = new DataTable();
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.ECTNew;
        TreeNode myRoot = new TreeNode();
        string myValuePath = "";
        struct myNode
        {
            public TreeNode tn;
            public int id;
            public int ParentID;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {                                    
                    getcurrentterm();
                    Generate_Menu();
                    if (Session["MainRoot"] != null)
                    {
                        myRoot = (TreeNode)Session["MainRoot"];
                    }
                    if (Session["myValuePath"] != null)
                    {
                        myValuePath = Session["myValuePath"].ToString();
                        //myTree.FindNode(myValuePath).Select();
                    }
                    int r = Show_Data();
                    //TVMain.CollapseAll();
                    //TVMain.Nodes[0].Expand();                                          
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        private int Show_Data()
        {
            int r = 0;

            try
            {
                TVMain.Nodes.Clear();
                TVMain.Nodes.Add(myRoot);

                TVMain.ExpandAll();
                r = TVMain.Nodes.Count;

            }

            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
            return r;
        }
        public void getcurrentterm()
        {
            int iCSem = 0;
            int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
            Session["CurrentYear"] = iCYear;
            Session["CurrentSemester"] = iCSem;
            lbl_System.Text = Session["CurrentSystemName"].ToString();

            string sYear = iCYear.ToString() + " / " + (iCYear + 1).ToString();
            string sSem = LibraryMOD.GetSemesterString(iCSem);
            lbl_term.Text = sYear + " " + sSem;
            getprofilepic();
        }

        public void Generate_Menu()
        {
            int RoleId = 0;
            int SystemID = 10;

            if (Session["CurrentRole"] != null)
            {
                RoleId = (int)Session["CurrentRole"];
            }
            if (Session["CurrentSystem"] != null)
            {
                SystemID = (int)Session["CurrentSystem"];
            }

            var Menu = new DAL.DAL();
            Menus = Menu.GetMenuData(RoleId, SystemID);
            if (SystemID == 14)//Corporate Strategy
            {
                BuildMainTree();
                //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.CS_Execution,
                //        InitializeModule.enumPrivilege.CS_ShowAll, RoleId) != true)
                //{
                //Show all initiatives
                //DataTable dt_dynamicmenu = new DataTable();
                //dt_dynamicmenu.Clear();
                //dt_dynamicmenu.Columns.Add("ObjectID", typeof(int));
                //dt_dynamicmenu.Columns.Add("ObjectNameEn");
                //dt_dynamicmenu.Columns.Add("DisplayObjectName");
                //dt_dynamicmenu.Columns.Add("ShowOrder", typeof(int));
                //dt_dynamicmenu.Columns.Add("SystemID", typeof(int));
                //dt_dynamicmenu.Columns.Add("ParentID", typeof(int));
                //dt_dynamicmenu.Columns.Add("sURL");
                //dt_dynamicmenu.Columns.Add("iLevel", typeof(int));
                //dt_dynamicmenu.Columns.Add("Privileges", typeof(int));

                //SqlCommand cmdtheme = new SqlCommand("SELECT DISTINCT CS_Strategic_Initiative.iTheme,CS_Strategic_Theme.iOrder, CS_Strategic_Theme.sThemeCode, CS_Strategic_Theme.sThemeDesc FROM CS_Strategic_Initiative INNER JOIN CS_Strategic_Theme ON CS_Strategic_Initiative.iTheme = CS_Strategic_Theme.iSerial order by CS_Strategic_Theme.iOrder asc", sc);
                //DataTable dttheme = new DataTable();
                //SqlDataAdapter datheme = new SqlDataAdapter(cmdtheme);
                //try
                //{
                //    sc.Open();
                //    datheme.Fill(dttheme);
                //    sc.Close();

                //    if (dttheme.Rows.Count > 0)
                //    {
                //        int themeid = 3000;
                //        int goalid = 4000;
                //        int projectid = 5000;
                //        int objectiveid = 6000;
                //        int initiativeid = 7000;

                //        for (int i = 0; i < dttheme.Rows.Count; i++)
                //        {
                //            DataRow _dt_dynamicmenu = dt_dynamicmenu.NewRow();
                //            _dt_dynamicmenu["ObjectID"] = themeid;
                //            _dt_dynamicmenu["ObjectNameEn"] = dttheme.Rows[i]["sThemeCode"].ToString();
                //            _dt_dynamicmenu["DisplayObjectName"] = dttheme.Rows[i]["sThemeCode"].ToString();
                //            _dt_dynamicmenu["ShowOrder"] = i;
                //            _dt_dynamicmenu["SystemID"] = "14";//Corporate Strategy
                //            _dt_dynamicmenu["ParentID"] = "1299";//CS Execution
                //            _dt_dynamicmenu["sURL"] = "Authorization.aspx?id=" + dttheme.Rows[i]["iTheme"].ToString() + "";//Authorization.aspx?id=" + dttheme.Rows[i]["iTheme"].ToString() + "
                //            _dt_dynamicmenu["iLevel"] = "1";
                //            _dt_dynamicmenu["Privileges"] = "2";
                //            dt_dynamicmenu.Rows.Add(_dt_dynamicmenu);

                //            SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT(CS_Strategic_Initiative.iGoal),CS_Strategic_Goal.iOrder, CS_Strategic_Goal.sStrategicGoalID FROM CS_Strategic_Initiative INNER JOIN CS_Strategic_Goal ON CS_Strategic_Initiative.iGoal = CS_Strategic_Goal.iSerial WHERE (CS_Strategic_Initiative.iTheme = @iTheme) order by CS_Strategic_Goal.iOrder asc", sc);
                //            cmd1.Parameters.AddWithValue("@iTheme", dttheme.Rows[i]["iTheme"].ToString());
                //            DataTable dt1 = new DataTable();
                //            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                //            try
                //            {
                //                sc.Open();
                //                da1.Fill(dt1);
                //                sc.Close();

                //                if (dt1.Rows.Count > 0)
                //                {
                //                    for (int j = 0; j < dt1.Rows.Count; j++)
                //                    {
                //                        DataRow _dt_dynamicmenu1 = dt_dynamicmenu.NewRow();
                //                        _dt_dynamicmenu1["ObjectID"] = goalid;
                //                        _dt_dynamicmenu1["ObjectNameEn"] = dt1.Rows[j]["sStrategicGoalID"].ToString();
                //                        _dt_dynamicmenu1["DisplayObjectName"] = dt1.Rows[j]["sStrategicGoalID"].ToString();
                //                        _dt_dynamicmenu1["ShowOrder"] = j;
                //                        _dt_dynamicmenu1["SystemID"] = "14";//Corporate Strategy
                //                        _dt_dynamicmenu1["ParentID"] = themeid;//themeid
                //                        _dt_dynamicmenu1["sURL"] = "CHEDS_Enrollment.aspx?id=" + dt1.Rows[j]["iGoal"].ToString() + "";//Authorization.aspx?id=" + dt1.Rows[j]["iGoal"].ToString() + "
                //                        _dt_dynamicmenu1["iLevel"] = "2";
                //                        _dt_dynamicmenu1["Privileges"] = "2";
                //                        dt_dynamicmenu.Rows.Add(_dt_dynamicmenu1);

                //                        SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT CS_Strategic_Initiative.iProject,CS_Strategic_Project.iOrder, CS_Strategic_Project.sStrategicProjectID FROM CS_Strategic_Initiative INNER JOIN CS_Strategic_Project ON CS_Strategic_Initiative.iProject = CS_Strategic_Project.iSerial WHERE (CS_Strategic_Initiative.iTheme = @iTheme) AND (CS_Strategic_Initiative.iGoal = @iGoal) order by CS_Strategic_Project.iOrder asc", sc);
                //                        cmd2.Parameters.AddWithValue("@iTheme", dttheme.Rows[i]["iTheme"].ToString());
                //                        cmd2.Parameters.AddWithValue("@iGoal", dt1.Rows[j]["iGoal"].ToString());
                //                        DataTable dt2 = new DataTable();
                //                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                //                        try
                //                        {
                //                            sc.Open();
                //                            da2.Fill(dt2);
                //                            sc.Close();

                //                            if (dt2.Rows.Count > 0)
                //                            {
                //                                for (int k = 0; k < dt2.Rows.Count; k++)
                //                                {
                //                                    DataRow _dt_dynamicmenu2 = dt_dynamicmenu.NewRow();
                //                                    _dt_dynamicmenu2["ObjectID"] = projectid;
                //                                    _dt_dynamicmenu2["ObjectNameEn"] = dt2.Rows[k]["sStrategicProjectID"].ToString();
                //                                    _dt_dynamicmenu2["DisplayObjectName"] = dt2.Rows[k]["sStrategicProjectID"].ToString();
                //                                    _dt_dynamicmenu2["ShowOrder"] = k;
                //                                    _dt_dynamicmenu2["SystemID"] = "14";//Corporate Strategy
                //                                    _dt_dynamicmenu2["ParentID"] = goalid;//goalid
                //                                    _dt_dynamicmenu2["sURL"] = "CHEDS_New_Applicants.aspx?id=" + dt2.Rows[k]["iProject"].ToString() + "";//Authorization.aspx?id=" + dt2.Rows[k]["iProject"].ToString() + "
                //                                    _dt_dynamicmenu2["iLevel"] = "3";
                //                                    _dt_dynamicmenu2["Privileges"] = "2";
                //                                    dt_dynamicmenu.Rows.Add(_dt_dynamicmenu2);

                //                                    SqlCommand cmd3 = new SqlCommand("SELECT DISTINCT CS_Strategic_Initiative.iObjective,CS_Strategic_Objective.iOrder, CS_Strategic_Objective.sStrategicObjectiveID FROM CS_Strategic_Initiative INNER JOIN CS_Strategic_Objective ON CS_Strategic_Initiative.iObjective = CS_Strategic_Objective.iSerial WHERE (CS_Strategic_Initiative.iTheme = @iTheme) AND (CS_Strategic_Initiative.iGoal = @iGoal) AND (CS_Strategic_Initiative.iProject = @iProject) order by CS_Strategic_Objective.iOrder asc", sc);
                //                                    cmd3.Parameters.AddWithValue("@iTheme", dttheme.Rows[i]["iTheme"].ToString());
                //                                    cmd3.Parameters.AddWithValue("@iGoal", dt1.Rows[j]["iGoal"].ToString());
                //                                    cmd3.Parameters.AddWithValue("@iProject", dt2.Rows[k]["iProject"].ToString());
                //                                    DataTable dt3 = new DataTable();
                //                                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                //                                    try
                //                                    {
                //                                        sc.Open();
                //                                        da3.Fill(dt3);
                //                                        sc.Close();

                //                                        if (dt3.Rows.Count > 0)
                //                                        {
                //                                            for (int l = 0; l < dt3.Rows.Count; l++)
                //                                            {
                //                                                DataRow _dt_dynamicmenu3 = dt_dynamicmenu.NewRow();
                //                                                _dt_dynamicmenu3["ObjectID"] = objectiveid;
                //                                                _dt_dynamicmenu3["ObjectNameEn"] = dt3.Rows[l]["sStrategicObjectiveID"].ToString();
                //                                                _dt_dynamicmenu3["DisplayObjectName"] = dt3.Rows[l]["sStrategicObjectiveID"].ToString();
                //                                                _dt_dynamicmenu3["ShowOrder"] = l;
                //                                                _dt_dynamicmenu3["SystemID"] = "14";//Corporate Strategy
                //                                                _dt_dynamicmenu3["ParentID"] = projectid;//projectid
                //                                                _dt_dynamicmenu3["sURL"] = "CHEDS_New_Attrition.aspx?id=" + dt3.Rows[l]["iObjective"].ToString() + "";//Authorization.aspx?id=" + dt3.Rows[l]["iObjective"].ToString() + "
                //                                                _dt_dynamicmenu3["iLevel"] = "4";
                //                                                _dt_dynamicmenu3["Privileges"] = "2";
                //                                                dt_dynamicmenu.Rows.Add(_dt_dynamicmenu3);

                //                                                SqlCommand cmd4 = new SqlCommand("select distinct([iSerial]),[sInitiativeID],[sInitiativeDesc],iOrder from CS_Strategic_Initiative where iTheme=@iTheme and iGoal=@iGoal and iProject=@iProject and iObjective=@iObjective order by iOrder", sc);
                //                                                cmd4.Parameters.AddWithValue("@iTheme", dttheme.Rows[i]["iTheme"].ToString());
                //                                                cmd4.Parameters.AddWithValue("@iGoal", dt1.Rows[j]["iGoal"].ToString());
                //                                                cmd4.Parameters.AddWithValue("@iProject", dt2.Rows[k]["iProject"].ToString());
                //                                                cmd4.Parameters.AddWithValue("@iObjective", dt3.Rows[l]["iObjective"].ToString());
                //                                                DataTable dt4 = new DataTable();
                //                                                SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                //                                                try
                //                                                {
                //                                                    sc.Open();
                //                                                    da4.Fill(dt4);
                //                                                    sc.Close();

                //                                                    if (dt4.Rows.Count > 0)
                //                                                    {
                //                                                        for (int m = 0; m < dt4.Rows.Count; m++)
                //                                                        {
                //                                                            DataRow _dt_dynamicmenu4 = dt_dynamicmenu.NewRow();
                //                                                            _dt_dynamicmenu4["ObjectID"] = initiativeid;
                //                                                            _dt_dynamicmenu4["ObjectNameEn"] = dt4.Rows[m]["sInitiativeID"].ToString();
                //                                                            _dt_dynamicmenu4["DisplayObjectName"] = dt4.Rows[m]["sInitiativeID"].ToString();
                //                                                            _dt_dynamicmenu4["ShowOrder"] = m;
                //                                                            _dt_dynamicmenu4["SystemID"] = "14";//Corporate Strategy
                //                                                            _dt_dynamicmenu4["ParentID"] = objectiveid;//objectiveid
                //                                                            _dt_dynamicmenu4["sURL"] = "CHEDS_New_Graduated.aspx?id=" + dt4.Rows[m]["iSerial"].ToString() + "";//Authorization.aspx?id=" + dt4.Rows[l]["iSerial"].ToString() + "
                //                                                            _dt_dynamicmenu4["iLevel"] = "5";
                //                                                            _dt_dynamicmenu4["Privileges"] = "2";
                //                                                            dt_dynamicmenu.Rows.Add(_dt_dynamicmenu4);

                //                                                            initiativeid++;
                //                                                        }
                //                                                    }
                //                                                }
                //                                                catch (Exception ex)
                //                                                {
                //                                                    sc.Close();
                //                                                    Console.WriteLine(ex.Message);
                //                                                }
                //                                                finally
                //                                                {
                //                                                    sc.Close();
                //                                                }

                //                                                objectiveid++;
                //                                            }
                //                                        }
                //                                    }
                //                                    catch (Exception ex)
                //                                    {
                //                                        sc.Close();
                //                                        Console.WriteLine(ex.Message);
                //                                    }
                //                                    finally
                //                                    {
                //                                        sc.Close();
                //                                    }

                //                                    projectid++;
                //                                }
                //                            }
                //                        }
                //                        catch (Exception ex)
                //                        {
                //                            sc.Close();
                //                            Console.WriteLine(ex.Message);
                //                        }
                //                        finally
                //                        {
                //                            sc.Close();
                //                        }


                //                        goalid++;
                //                    }
                //                }
                //            }
                //            catch (Exception ex)
                //            {
                //                sc.Close();
                //                Console.WriteLine(ex.Message);
                //            }
                //            finally
                //            {
                //                sc.Close();
                //            }
                //            themeid++;
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    sc.Close();
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    sc.Close();
                //}
                //}
                //else
                //{
                //    //Show Initiatives under His/Her Dept/Section
                //}
                //Menus.Merge(dt_dynamicmenu);
            }
            DataView view = new DataView(Menus);
            view.RowFilter = "iLevel=0";
            this.rptCategories.DataSource = view;
            this.rptCategories.DataBind();
        }     
        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (Menus != null)
                    {
                        DataRowView drv = e.Item.DataItem as DataRowView;
                        string ID = drv["ObjectID"].ToString();
                        string Title = drv["DisplayObjectName"].ToString();
                        DataRow[] rows = Menus.Select("ParentID='" + ID + "' AND iLevel <> 0");
                        // DataRow[] rows = Menus.Select("ParentID=" + ID);
                        if (rows.Length > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<ul class='nav child_menu'>");
                            foreach (var item in rows)
                            {
                                string parentId = item["ObjectID"].ToString();
                                string parentTitle = item["DisplayObjectName"].ToString();


                                DataRow[] parentRow = Menus.Select("ParentID=" + parentId);

                                if (parentRow.Count() > 0)
                                {
                                    int SystemID = 10;
                                    if (Session["CurrentSystem"] != null)
                                    {
                                        SystemID = (int)Session["CurrentSystem"];
                                    }
                                    if (SystemID == 14)
                                    {
                                        //string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                                        sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                                        //sb.Append("<li><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                                        //sb.Append("<li><a onclick='location.href='"+ strUrl + "''>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                                    }
                                    else
                                    {
                                        sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                                        //sb.Append("</li>");
                                    }
                                }
                                else
                                {
                                    string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                                    //sb.Append("<li><a href='" + item["sURL"] + "'>" + item["DisplayObjectName"] + "</a>"); old with aspx
                                    sb.Append("<li><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "</a>");
                                    //sb.Append("</li>");
                                }
                                sb = CreateChild(sb, parentId, parentTitle, parentRow);
                            }
                            sb.Append("</li>");
                            sb.Append("</ul>");
                            (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                        }
                    }
                }
            }
        }
        private StringBuilder CreateChild(StringBuilder sb, string parentId, string parentTitle, DataRow[] parentRows)
        {
            if (parentRows.Length > 0)
            {
                //sb.Append("<ul class='nav child_menu'>");sub_menu
                sb.Append("<ul class='nav child_menu'>");
                foreach (var item in parentRows)
                {
                    string childId = item["ObjectID"].ToString();
                    string childTitle = item["DisplayObjectName"].ToString();
                    DataRow[] childRow = Menus.Select("ParentID=" + childId);

                    if (childRow.Count() > 0)
                    {
                        int SystemID = 10;
                        if (Session["CurrentSystem"] != null)
                        {
                            SystemID = (int)Session["CurrentSystem"];
                        }
                        if (SystemID == 14)
                        {
                            //string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                            //sb.Append("<li><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                            //sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                        }
                        else
                        {
                            sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                        }                            
                        //sb.Append("</li>");
                    }
                    else
                    {
                        //sb.Append("<li  class='sub_menu'><a href='" + item["sURL"] + "'>" + item["DisplayObjectName"] + "</a>"); old with aspx
                        string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                        sb.Append("<li  class='sub_menu'><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "</a>");
                        // sb.Append("</li>");
                    }
                    CreateChild(sb, childId, childTitle, childRow);
                }
                sb.Append("</li>");
                sb.Append("</ul>");
            }
            return sb;
        }
        protected void lnk_Logout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        public void getprofilepic()
        {
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            string employeeid = Session["EmployeeID"].ToString();
            var services = new DAL.DAL();
            DataTable dtEmployeeProfile = services.GetEmployeeProfilePic(employeeid, connstr.Conn_string);
            if (dtEmployeeProfile.Rows.Count > 0)
            {
                Session["ProfilePIc"] = dtEmployeeProfile.Rows[0]["PIC"].ToString();
                lblUser.Text = dtEmployeeProfile.Rows[0]["Title"].ToString() + " " + dtEmployeeProfile.Rows[0]["MiddleName"].ToString();
                //lblUser1.Text = dtEmployeeProfile.Rows[0]["Name"].ToString();
            }
        }
        private void BuildMainTree()
        {
            TVMain.Visible = true;
            List<PrivilegeObjects> myObjects = new List<PrivilegeObjects>();
            RoleDAL myRoleDAL = new RoleDAL();
            myNode[] myNodes;            
            int RoleId = 0;
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    RoleId = (int)Session["CurrentRole"];
                }

                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.CS_Execution,
                        InitializeModule.enumPrivilege.CS_ShowAll, RoleId) != true)
                {
                    myObjects = myRoleDAL.GetSCAllMenu_ID(Session["EmployeeID"].ToString());
                }
                else
                {                    
                    //Show all initiatives
                    myObjects = myRoleDAL.GetSCAllMenu();
                    //myObjects = myRoleDAL.GetSCAllMenu_ID(Session["EmployeeID"].ToString());
                }

                myNodes = new myNode[myObjects.Count];
                //Collect Nodes
                for (int i = 0; i < myObjects.Count; i++)
                {
                    myNodes[i].tn = new TreeNode(myObjects[i].DisplayObjectName, myObjects[i].ObjectID.ToString());
                    if (!string.IsNullOrEmpty(myObjects[i].sURL))
                    {
                        myNodes[i].tn.NavigateUrl = myObjects[i].sURL;
                    }
                    myNodes[i].id = myObjects[i].ObjectID;
                    myNodes[i].ParentID = myObjects[i].ParentID;
                    myNodes[i].tn.ToolTip= myObjects[i].ObjectNameEn;
                    //switch (myNodes[i].tn.Text)
                    //{
                    //    case "Home":
                    //    case "Reports":
                    //    case "Accounting":
                    //    case "Classes":
                    //    case "Registration":
                    //        myNodes[i].tn.Expand();
                    //        break;
                    //    default:
                    //        myNodes[i].tn.Collapse();
                    //        break;
                    //}
                }


                //Build Nodes Tree
                int iIndex = 0;
                for (int i = myObjects.Count - 1; i > -1; i--)
                {
                    if (myNodes[i].id != myNodes[i].ParentID)
                    {
                        iIndex = Array.FindIndex(myNodes, delegate (myNode n) { return n.id == myNodes[i].ParentID; });
                        myNodes[iIndex].tn.ChildNodes.Add(myNodes[i].tn);

                        //switch (myNodes[i].tn.Text )
                        //{ 
                        //    case "Home":
                        //    case "Reports":
                        //    case "Accounting":
                        //    case "Classes":
                        //    case "Registration":
                        //        myNodes[i].tn.Expand();
                        //        break ;
                        //    default :
                        //        myNodes[i].tn.Collapse();
                        //        break ;
                        //}
                    }
                    else
                    {
                        myRoot.ChildNodes.Add(myNodes[i].tn);
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                myObjects.Clear();
                Session["MainRoot"] = myRoot;

            }

        }

        //protected void TVMain_SelectedNodeChanged(object sender, EventArgs e)
        //{
        //    Session["myValuePath"] = TVMain.SelectedNode.ValuePath;

        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "selectNode", "var elem = document.getElementById('" + TVMain.ClientID + "_SelectedNode');var node = document.getElementById(elem.value);node.scrollIntoView(true);elem.scrollLeft=0;", true);
        //}       
    }
}