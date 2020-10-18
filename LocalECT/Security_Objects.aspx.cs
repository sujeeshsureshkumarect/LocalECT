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
    public partial class Security_Objects : System.Web.UI.Page
    {
        struct myNode
        {
            public TreeNode tn;
            public int id;
            public int ParentID;

        }
        TreeNode myRoot = new TreeNode();
        string myValuePath = "";
        int CurrentRole = 0;
        string sUserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                sUserName = Session["CurrentUserName"].ToString();
                //CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_MapsManager,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");

                    }
                }
                lbl_Msg.Text = "";

                if (!IsPostBack)
                {
                    Fill_SystemsCBO();                    
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
                        //myTree.FindNode(myValuePath).Select();
                    }

                    //if (Session["ObjectsArray"] != null)
                    //{
                    //    string myObjects = Session["ObjectsArray"].ToString();
                    //    //SetArgs(sArgs);

                    //}
                    Show_Data();


                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        private void Fill_SystemsCBO()
        {
            List<Lookups> mySystems = new List<Lookups>();
            LookupsDAL myLookupsDAL = new LookupsDAL();

            try
            {
                mySystems = myLookupsDAL.GetLookup("", LookupsDAL.LkpHeaders.Systems);
                for (int i = 0; i < mySystems.Count; i++)
                {
                    ListItem lst = new ListItem(mySystems[i].DescEn, mySystems[i].MinorID.ToString());
                    SystemsCBO.Items.Add(lst);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                mySystems.Clear();

            }
        }

        protected void SystemsCBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            Retrieve();
            Clear_Controls();
            myTree.CollapseAll();
            for (int i = 0; i < myTree.Nodes.Count; i++)
            {
                myTree.Nodes[i].Expand();
            }
        }
        private void Retrieve()
        {

            List<PrivilegeObjects> myObjects = new List<PrivilegeObjects>();
            PrivilegeObjectsDAL myMapsDAL = new PrivilegeObjectsDAL();

            myNode[] myNodes;
            try
            {

                myRoot = new TreeNode("Home", "0");

                //myRoot.NavigateUrl = "Default.aspx";


                string sCondition = " Where systemID=" + int.Parse(SystemsCBO.SelectedValue);
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


                Show_Data();

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                myObjects.Clear();
                Session["ObjectsRoot"] = myRoot;
            }

        }
        private int Show_Data()
        {
            int r = 0;

            try
            {
                myTree.Nodes.Clear();
                myTree.Nodes.Add(myRoot);
                r = myTree.Nodes.Count;
                myTree.ExpandAll();

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
        private void get_Node()
        {
            TreeNode tn = new TreeNode();
            List<PrivilegeObjects> myObjects = new List<PrivilegeObjects>();
            PrivilegeObjectsDAL myMapsDAL = new PrivilegeObjectsDAL();
            try
            {
                tn = myTree.SelectedNode;
                string sValue = tn.Value;

                string sCondition = " Where objectID=" + int.Parse(sValue);
                string sOrder = " ORDER BY iLevel, ShowOrder DESC";
                myObjects = myMapsDAL.GetPrivilegeObjects(InitializeModule.EnumCampus.ECTNew, sCondition, sOrder, false);


                for (int i = 0; i < myObjects.Count; i++)
                {
                    IDTXT.Text = myObjects[i].ObjectID.ToString();
                    DescTXT.Text = myObjects[i].ObjectNameEn;
                    CaptionTXT.Text = myObjects[i].DisplayObjectName;
                    ParentLBL.Text = myObjects[i].ParentID.ToString();
                    UrlTXT.Text = myObjects[i].sURL;
                    LevelLBL.Text = myObjects[i].iLevel.ToString();
                    OrderCBO.SelectedValue = myObjects[i].ShowOrder.ToString();
                    DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                    //isDataChanged.Value = false.ToString();
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


            }


        }
        protected void NewCMD_Click(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode();
            List<PrivilegeObjects> myObjects = new List<PrivilegeObjects>();
            PrivilegeObjectsDAL myMapsDAL = new PrivilegeObjectsDAL();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                if (myValuePath == "")
                {
                    lbl_Msg.Text = "Select parent node from the tree";
                    div_msg.Visible = true;
                    return;
                }
                myTree.FindNode(myValuePath).Select();

                tn = myTree.SelectedNode;
                string sValue = tn.Value;
                int iLevel = int.Parse("0" + LevelLBL.Text) + 1;
                Clear_Controls();

                int iNewID = LibraryMOD.GetMaxID(Conn, "ObjectID", "Cmn_PrivilegeObjects") + 1;
                IDTXT.Text = iNewID.ToString();
                //isDataChanged.Value = true.ToString();
                DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();
                if (sValue == "0")
                {
                    ParentLBL.Text = IDTXT.Text;
                    iLevel = 0;
                }
                else
                {
                    ParentLBL.Text = sValue;
                }
                LevelLBL.Text = iLevel.ToString();
                int iSystem = int.Parse(SystemsCBO.SelectedValue);

                OrderCBO.SelectedValue = myMapsDAL.GetNewOrder(iLevel, iSystem).ToString();

                //lbl_Msg.Text = "Node Added Successfully";
                //div_msg.Visible = true;
                //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
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
        protected void SaveCMD_Click(object sender, EventArgs e)
        {
            PrivilegeObjectsDAL myMapsDAL = new PrivilegeObjectsDAL();
            try
            {

                int iOrder = 1;
                int iLevel = int.Parse(LevelLBL.Text);
                int iSystem = int.Parse(SystemsCBO.SelectedValue);

                myTree.FindNode(myValuePath).Select();
                TreeNode tn;

                if (DataStatus.Value == ((int)InitializeModule.enumModes.NewMode).ToString())//new record
                {

                    tn = new TreeNode(CaptionTXT.Text, IDTXT.Text);
                    myTree.SelectedNode.ChildNodes.Add(tn);
                    myValuePath += "/" + IDTXT.Text;
                    myTree.FindNode(myValuePath).Select();

                    iOrder = int.Parse(OrderCBO.SelectedValue);
                    Session["myValuePath"] = myValuePath;
                }
                else
                {
                    myTree.SelectedNode.Text = CaptionTXT.Text;
                    iOrder = int.Parse(OrderCBO.SelectedValue);
                }

                int r = myMapsDAL.UpdatePrivilegeObjects(InitializeModule.EnumCampus.ECTNew, int.Parse(DataStatus.Value), int.Parse(IDTXT.Text), "", DescTXT.Text, CaptionTXT.Text, iOrder,
                    iSystem, int.Parse(ParentLBL.Text), UrlTXT.Text,
                    iLevel);
                if (r > 0)
                {
                    if (DataStatus.Value == ((int)InitializeModule.enumModes.NewMode).ToString())//new record
                    {
                        r = AddPrivileges(int.Parse(IDTXT.Text));
                    }
                    DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                    lbl_Msg.Text = "Data Updated Successfully";
                    div_msg.Visible = true;                    
                    div_Alert.Attributes.Add("class","alert alert-success alert-dismissible");                    
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


            }


        }
        protected void DeleteCMD_Click(object sender, EventArgs e)
        {
            PrivilegeObjectsDAL myMapsDAL = new PrivilegeObjectsDAL();
            string sValue = "";
            string sParent = "";
            try
            {

                myTree.FindNode(myValuePath).Select();
                if (myTree.SelectedNode.ChildNodes.Count > 0)
                {
                    lbl_Msg.Text = "You must delete children nodes before deleting this node";
                    div_msg.Visible = true;
                }
                else
                {
                    sValue = myTree.SelectedNode.Value;
                    int r = myMapsDAL.DeletePrivilegeObjects(InitializeModule.EnumCampus.ECTNew, int.Parse(sValue));
                    if (r > 0)
                    {
                        r = DeletePrivileges(int.Parse(sValue));
                        myTree.SelectedNode.Parent.ChildNodes.Remove(myTree.SelectedNode);
                        //myTree.FindNode(myValuePath).Parent.ChildNodes.Remove();
                        sParent = myValuePath.Substring(0, myValuePath.LastIndexOf('/'));
                        myTree.FindNode(sParent).Select();
                        Session["myValuePath"] = sParent;

                        //myTree.Nodes.Remove(myTree.SelectedNode);
                        Clear_Controls();
                        get_Node();
                        lbl_Msg.Text = "Node Deleted Successfully";
                        div_msg.Visible = true;
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    }


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


            }

        }
        protected void myTree_SelectedNodeChanged(object sender, EventArgs e)
        {
           // divMsg.InnerText = myTree.SelectedNode.ValuePath;
            Session["myValuePath"] = myTree.SelectedNode.ValuePath;
            get_Node();
        }

        private int AddPrivileges(int iObjectID)
        {
            SqlConnection Conn = new SqlConnection();
            PrivilegeDAL myPrivilegesDAL = new PrivilegeDAL();
            List<Privilege> myPrivileges = new List<Privilege>();
            int r = 0;
            try
            {
                InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
                Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

                Conn.ConnectionString = sConn.Conn_string;
                string sCondition = " Where PrivilegeID<6 and DefaultEffect=1";
                myPrivileges = myPrivilegesDAL.GetPrivilege(InitializeModule.EnumCampus.ECTNew, sCondition, false);
                Conn.Open();

                for (int i = 0; i < myPrivileges.Count; i++)
                {
                    r += myPrivilegesDAL.AddPrivilegeToObject(iObjectID, myPrivileges[i].PrivilegeID, Conn, sUserName);

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
                myPrivileges.Clear();
            }
            return r;
        }

        private int DeletePrivileges(int iObjectID)
        {
            SqlConnection Conn = new SqlConnection();
            PrivilegeDAL myPrivilegesDAL = new PrivilegeDAL();
            int r = 0;
            try
            {
                InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
                Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

                Conn.ConnectionString = sConn.Conn_string;
                string sCondition = " Where ObjectID=" + iObjectID;

                Conn.Open();

                r = myPrivilegesDAL.DeletePrivilegeFromObject(sCondition, Conn, sUserName);




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
            return r;
        }

        protected void ManageLNK_Command(object sender, CommandEventArgs e)
        {
            if (IDTXT.Text != "")
            {
                Response.Redirect("ManagePrivileges.aspx?ObjectID=" + IDTXT.Text + "&ObjectName=" + DescTXT.Text);
            }
            else
            {
                lbl_Msg.Text = "Select any Object First !";
                div_msg.Visible = true;
            }
        }
        private void Clear_Controls()
        {
            IDTXT.Text = "";
            DescTXT.Text = "";
            CaptionTXT.Text = "";
            ParentLBL.Text = "";
            UrlTXT.Text = "";
            LevelLBL.Text = "";
            OrderCBO.SelectedValue = "0";
            DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
            //isDataChanged.Value = false.ToString();

        }
    }
}