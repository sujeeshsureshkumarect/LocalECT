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
    public partial class ManagePermissions : System.Web.UI.Page
    {
        struct myNode
        {
            public TreeNode tn;
            public int id;
            public int ParentID;

        }
        RoleDAL myRoleDAL = new RoleDAL();

        TreeNode myRoot = new TreeNode();
        TreeNode RoleRoot = new TreeNode();
        string myValuePath = "";
        string ValuePath = "";
        int RoleID = 0;
        int CurrentRole = 0;
        string sUserName = "";
        //TreeView myTree = new TreeView();
        protected void Page_Load(object sender, EventArgs e)
        {           
            //Security
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            //int CurrentRole = 0;
            sUserName = Session["CurrentUserName"].ToString();
            //CurrentRole = (int)Session["CurrentRole"];
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Setting_RolesManager,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            if (!string.IsNullOrEmpty(Request.QueryString["RoleID"]))
            {
                RoleID = int.Parse(Request.QueryString["RoleID"]);

            }

            lbl_Msg.Text = "";


            if (!IsPostBack)
            {
                //Fill_SystemsCBO();
                Retrieve();
                RetrieveRoleObjects();
                Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
                SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
                Conn.Open();
                divHeader.InnerText = LibraryMOD.GetColValue(Conn, "RoleNameEn", "Cmn_Role", "RoleID=" + RoleID);
                Conn.Close();
                Conn.Dispose();
            }
            else
            {
                if (Session["ObjectsRoot"] != null)
                {
                    myRoot = (TreeNode)Session["ObjectsRoot"];

                }
                if (Session["myValuePath"] != null)
                {
                    myValuePath = Session["myValuePath"].ToString();

                }

                if (Session["RoleRoot"] != null)
                {
                    RoleRoot = (TreeNode)Session["RoleRoot"];

                }
                if (Session["ValuePath"] != null)
                {
                    ValuePath = Session["ValuePath"].ToString();

                }


            }
            Show_Data();
            if(!IsPostBack)
            {
                myTree.CollapseAll();
                for (int i = 0; i < myTree.Nodes.Count; i++)
                {
                    myTree.Nodes[i].Expand();
                }
                RoleTree.CollapseAll();
                for (int i = 0; i < RoleTree.Nodes.Count; i++)
                {
                    RoleTree.Nodes[i].Expand();
                }
            }
        }
        private void Retrieve()
        {

            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            List<PrivilegeObjects> myObjects = new List<PrivilegeObjects>();
            PrivilegeObjectsDAL myMapsDAL = new PrivilegeObjectsDAL();
            myNode[] myNodes;
            try
            {


                myRoot = new TreeNode("Home", "0");

                //myRoot.NavigateUrl = "Default.aspx";



                int SystemID = int.Parse(LibraryMOD.GetColValue(Conn, "SystemID", "Cmn_Role", "RoleID=" + RoleID));


                string sCondition = " Where systemID=" + SystemID; //+ int.Parse(SystemsCBO.SelectedValue);
                string sOrder = " ORDER BY iLevel, ShowOrder DESC";
                myObjects = myMapsDAL.GetPrivilegeObjects(InitializeModule.EnumCampus.ECTNew, sCondition, sOrder, false);
                myNodes = new myNode[myObjects.Count];
                //Collect Nodes
                for (int i = 0; i < myObjects.Count; i++)
                {
                    myNodes[i].tn = new TreeNode(myObjects[i].DisplayObjectName, myObjects[i].ObjectID.ToString());
                    //myNodes[i].tn.NavigateUrl = myObjects[i].sURL;
                    myNodes[i].id = myObjects[i].ObjectID;
                    myNodes[i].ParentID = myObjects[i].ParentID;

                }


                //Build Nodes Tree
                int iIndex = 0;
                for (int i = myObjects.Count - 1; i > -1; i--)
                {
                    if (myNodes[i].id != myNodes[i].ParentID)
                    {
                        iIndex = Array.FindIndex(myNodes, delegate (myNode n) { return n.id == myNodes[i].ParentID; });
                        myNodes[iIndex].tn.ChildNodes.Add(myNodes[i].tn);
                    }
                    else
                    {
                        myRoot.ChildNodes.Add(myNodes[i].tn);
                    }

                }
                myNode[] myObjArr = myNodes;
                Session["ObjArr"] = myObjArr;




            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                myObjects.Clear();
                Session["ObjectsRoot"] = myRoot;
                Conn.Close();
                Conn.Dispose();
            }

        }

        private void RetrieveRoleObjects()
        {
            List<PrivilegeObjects> myObjects = new List<PrivilegeObjects>();
            //RoleDAL myRoleDAL = new RoleDAL();
            myNode[] myNodes;
            try
            {

                RoleRoot = new TreeNode("Home", "0");

                myObjects = myRoleDAL.GetRoleObjects(RoleID);
                myNodes = new myNode[myObjects.Count];
                //Collect Nodes
                for (int i = 0; i < myObjects.Count; i++)
                {
                    myNodes[i].tn = new TreeNode(myObjects[i].DisplayObjectName, myObjects[i].ObjectID.ToString());
                    //myNodes[i].tn.NavigateUrl = myObjects[i].sURL;
                    myNodes[i].id = myObjects[i].ObjectID;
                    myNodes[i].ParentID = myObjects[i].ParentID;

                }

                myNode[] myRoleObjArr = myNodes;
                Session["RoleObjArr"] = myRoleObjArr;

                //Build Nodes Tree
                int iIndex = 0;
                for (int i = myObjects.Count - 1; i > -1; i--)
                {
                    if (myNodes[i].id != myNodes[i].ParentID)
                    {
                        iIndex = Array.FindIndex(myNodes, delegate (myNode n) { return n.id == myNodes[i].ParentID; });
                        myNodes[iIndex].tn.ChildNodes.Add(myNodes[i].tn);
                    }
                    else
                    {
                        RoleRoot.ChildNodes.Add(myNodes[i].tn);
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
                Session["RoleRoot"] = RoleRoot;

            }

        }

        private int Show_Data()
        {
            int r = 0;

            try
            {
                myTree.Nodes.Clear();
                myTree.Nodes.Add(myRoot);

                myTree.ExpandAll();

                RoleTree.Nodes.Clear();
                RoleTree.Nodes.Add(RoleRoot);
                r = RoleTree.Nodes.Count;
                RoleTree.ExpandAll();               
            }

            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {


            }
            return r;


        }


        private void get_RoleObjNode()
        {

            TreeNode tn = new TreeNode();
            int ObjId = 0;
            try
            {
                tn = RoleTree.SelectedNode;
                string sValue = tn.Value;
                ObjId = int.Parse(sValue);
                fillPermissionslst(ObjId);
                fillObjectPrivilegeslst(ObjId);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {


            }


        }

        private void fillObjectPrivilegeslst(int iObjectID)
        {
            List<Privilege> myPrivileges = new List<Privilege>();
            PrivilegeDAL myPrivilegesDAL = new PrivilegeDAL();
            try
            {
                PermissionsLST.Items.Clear();

                myPrivileges = myPrivilegesDAL.GetObjectPrivileges(" Where OP.ObjectID=" + iObjectID);

                for (int i = 0; i < myPrivileges.Count; i++)
                {
                    PermissionsLST.Items.Add(new ListItem(myPrivileges[i].PriviligeNameEn, myPrivileges[i].PrivilegeID.ToString()));
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                myPrivileges.Clear();

            }
        }


        private void fillPermissionslst(int iObjectID)
        {
            List<Privilege> myPrivileges = new List<Privilege>();
            //RoleDAL myRoleDAL = new RoleDAL();
            try
            {
                ObjPermissionLST.Items.Clear();

                myPrivileges = myRoleDAL.GetRoleObjPermissions(iObjectID, RoleID);

                for (int i = 0; i < myPrivileges.Count; i++)
                {
                    ObjPermissionLST.Items.Add(new ListItem(myPrivileges[i].PriviligeNameEn, myPrivileges[i].PrivilegeID.ToString()));
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                myPrivileges.Clear();

            }
        }


        protected void myTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            //divMsg.InnerText = myTree.SelectedNode.ValuePath;
            Session["myValuePath"] = myTree.SelectedNode.ValuePath;
            //get_Node();
        }

        protected void AddObjCMD_Click(object sender, EventArgs e)
        {

            TreeNode tn = new TreeNode();

            try
            {
                if (myValuePath == "")
                {                    
                    lbl_Msg.Text = "Select node from system map tree";
                    div_msg.Visible = true;
                    return;
                }
                myTree.FindNode(myValuePath).Select();

                tn = myTree.SelectedNode;
                string sValue = tn.Value;

                AddObjsToRole(int.Parse(sValue));

                RetrieveRoleObjects();
                Show_Data();
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }

        protected void RemoveObjCMD_Click(object sender, EventArgs e)
        {
            //RoleDAL myRoleDAL = new RoleDAL();
            TreeNode tn = new TreeNode();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                if (ValuePath == "")
                {                    
                    lbl_Msg.Text = "Select node from role map tree";
                    div_msg.Visible = true;
                    return;
                }
                RoleTree.FindNode(ValuePath).Select();

                tn = RoleTree.SelectedNode;
                if (tn.ChildNodes.Count > 0)
                {                    
                    lbl_Msg.Text = "Delete children nodes first ...";
                    div_msg.Visible = true;
                    return;
                }
                string sValue = tn.Value;
                int o = myRoleDAL.DeleteObjectFromRole(RoleID, int.Parse(sValue), Conn, sUserName);
                RetrieveRoleObjects();
                Show_Data();
                ObjPermissionLST.Items.Clear();
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

            }
        }

        protected void RoleTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            Session["ValuePath"] = RoleTree.SelectedNode.ValuePath;
            get_RoleObjNode();

        }

        private void AddObjsToRole(int ObjStart)
        {
            //RoleDAL myRoleDAL = new RoleDAL();
            TreeNode tn = new TreeNode();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            myNode[] myObjArr = (myNode[])Session["ObjArr"];
            int i = 0;
            int iIndex = 0;

            Conn.Open();
            try
            {
                //Get Startup Node
                i = Array.FindIndex(myObjArr, delegate (myNode n) { return n.id == ObjStart; });
                bool isStop = false;
                int o = 0;
                //Add Startup Node
                o = myRoleDAL.AddObjectToRole(RoleID, myObjArr[i].id, Conn, sUserName, true);
                isStop = (myObjArr[i].id == myObjArr[i].ParentID);
                //Add Node Parents
                while (isStop != true)
                {
                    iIndex = Array.FindIndex(myObjArr, delegate (myNode n) { return n.id == myObjArr[i].ParentID; });
                    i = iIndex;
                    o = myRoleDAL.AddObjectToRole(RoleID, myObjArr[i].id, Conn, sUserName, true);
                    isStop = (myObjArr[iIndex].id == myObjArr[iIndex].ParentID);
                }


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        protected void AddPermissionCMD_Click(object sender, EventArgs e)
        {

            TreeNode tn = new TreeNode();
            SqlConnection Conn = new SqlConnection();
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);
            Conn.ConnectionString = sConn.Conn_string;
            Conn.Open();

            int r = 0;
            try
            {

                if (ValuePath == "")
                {                    
                    lbl_Msg.Text = "Select node from role map tree";
                    div_msg.Visible = true;
                    return;
                }
                RoleTree.FindNode(ValuePath).Select();

                tn = RoleTree.SelectedNode;

                int ObjId = int.Parse(tn.Value);
                bool isDuplicate = false;



                foreach (ListItem lst in PermissionsLST.Items)
                {
                    if (lst.Selected == true)
                    {
                        foreach (ListItem olst in ObjPermissionLST.Items)
                        {
                            if (lst.Value == olst.Value)
                            {
                                isDuplicate = true;
                            }
                            else
                            {
                                isDuplicate = false;
                            }
                        }

                        if (isDuplicate != true)
                        {
                            r += myRoleDAL.AddPermissionToRole(RoleID, ObjId, int.Parse(lst.Value), 1, Conn, sUserName);
                        }
                    }
                }
                fillPermissionslst(ObjId);



            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();
            }
        }
        protected void RemovePermissionCMD_Click(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode();
            SqlConnection Conn = new SqlConnection();
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);
            Conn.ConnectionString = sConn.Conn_string;
            Conn.Open();

            int r = 0;
            try
            {

                if (ValuePath == "")
                {                    
                    lbl_Msg.Text = "Select node from role map tree";
                    div_msg.Visible = true;
                    return;
                }
                RoleTree.FindNode(ValuePath).Select();

                tn = RoleTree.SelectedNode;

                int ObjId = int.Parse(tn.Value);


                string sCondition = " Where RoleID=" + RoleID + " And ObjectID=" + ObjId + " AND PrivilegeID IN (0";


                foreach (ListItem lst in ObjPermissionLST.Items)
                {
                    if (lst.Selected == true)
                    {
                        sCondition += "," + lst.Value;
                    }
                }
                sCondition += ")";


                r = myRoleDAL.DeletePermissionFromRole(sCondition, Conn, sUserName);
                fillPermissionslst(ObjId);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();
            }
        }
    }
}