using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;

namespace LocalECT
{
    public partial class Search1 : System.Web.UI.UserControl
    {
        public class ChangedEventArgs : EventArgs
        {
            private string _sValue1;

            public string SValue1
            {
                get { return _sValue1; }
                set { _sValue1 = value; }
            }

            private string _sValue2;

            public string SValue2
            {
                get { return _sValue2; }
                set { _sValue2 = value; }
            }

            private string _sValue3;

            public string SValue3
            {
                get { return _sValue3; }
                set { _sValue3 = value; }
            }

            private string _sValue4;

            public string SValue4
            {
                get { return _sValue4; }
                set { _sValue4 = value; }
            }

            private string _sValue5;

            public string SValue5
            {
                get { return _sValue5; }
                set { _sValue5 = value; }
            }

            //private string _sValue6;

            //public string SValue6
            //{
            //    get { return _sValue6; }
            //    set { _sValue6 = value; }
            //}
        }

        private string _sField1;

        public string SField1
        {
            get { return _sField1; }
            set { _sField1 = value; }
        }
        private string _sCaption1;

        public string SCaption1
        {
            get { return _sCaption1; }
            set { _sCaption1 = value; }
        }

        private string _sField2;

        public string SField2
        {
            get { return _sField2; }
            set { _sField2 = value; }
        }
        private string _sCaption2;

        public string SCaption2
        {
            get { return _sCaption2; }
            set { _sCaption2 = value; }
        }

        private string _sField3;

        public string SField3
        {
            get { return _sField3; }
            set { _sField3 = value; }
        }
        private string _sCaption3;

        public string SCaption3
        {
            get { return _sCaption3; }
            set { _sCaption3 = value; }
        }

        private string _sField4;

        public string SField4
        {
            get { return _sField4; }
            set { _sField4 = value; }
        }
        private string _sCaption4;

        public string SCaption4
        {
            get { return _sCaption4; }
            set { _sCaption4 = value; }
        }

        private string _sField5;

        public string SField5
        {
            get { return _sField5; }
            set { _sField5 = value; }
        }
        private string _sCaption5;

        public string SCaption5
        {
            get { return _sCaption5; }
            set { _sCaption5 = value; }
        }

        //private string _sField6;

        //public string SField6
        //{
        //    get { return _sField6; }
        //    set { _sField6 = value; }
        //}
        //private string _sCaption6;

        //public string SCaption6
        //{
        //    get { return _sCaption6; }
        //    set { _sCaption6 = value; }
        //}

        private string _sSQL;

        public string SSQL
        {
            get { return _sSQL; }
            set { _sSQL = value; }
        }

        private InitializeModule.EnumCampus _Campus;

        public InitializeModule.EnumCampus Campus
        {
            get { return _Campus; }
            set { _Campus = value; }
        }



        // Declare the delegate (if using non-generic pattern).
        public delegate void ChangedEventHandler(object sender, ChangedEventArgs e);

        // Declare the event.
        public event ChangedEventHandler ChangedEvent;
        public event ChangedEventHandler NewEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseChangedEvent()
        {
            // Raise the event by using the () operator.
            ChangedEventArgs e = new ChangedEventArgs();
            e.SValue1 = hdn_Field1.Value;
            e.SValue2 = hdn_Field2.Value;
            e.SValue3 = hdn_Field3.Value;
            e.SValue4 = hdn_Field4.Value;
            e.SValue5 = hdn_Field5.Value;
            //e.SValue6 = hdn_Field6.Value;
            ChangedEvent(this, e);
        }

        protected virtual void RaiseNewEvent()
        {
            // Raise the event by using the () operator.
            ChangedEventArgs e = new ChangedEventArgs();
            e.SValue1 = hdn_Field1.Value;
            e.SValue2 = hdn_Field2.Value;
            e.SValue3 = hdn_Field3.Value;
            e.SValue4 = hdn_Field4.Value;
            e.SValue5 = hdn_Field5.Value;
            //e.SValue6 = hdn_Field6.Value;
            NewEvent(this, e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txt1.Focus();

        }
        protected void Search1_btn_Click(object sender, EventArgs e)
        {

            string sCondition = " Where 1=1";

            if (!string.IsNullOrEmpty(txt1.Text))
            {
                sCondition += " And " + _sField1 + " like '%" + txt1.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txt2.Text))
            {
                sCondition += " And " + _sField2 + " like '%" + txt2.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txt3.Text))
            {
                sCondition += " And " + _sField3 + " like '%" + txt3.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txt4.Text))
            {
                sCondition += " And " + _sField4 + " like '%" + txt4.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txt5.Text))
            {
                sCondition += " And " + _sField5 + " like '%" + txt5.Text + "%'";
            }
            //if (!string.IsNullOrEmpty(txt5.Text))
            //{
            //    sCondition += " And " + _sField6 + " like '%" + txt5.Text + "%'";
            //}
            SetSearchList(sCondition);
            Search_lst.Visible = (Search_lst.Items.Count > 0);

        }

        protected void Search_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSearchValues();
        }

        private void SetSearchList(string sCondition)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            List<SearchCLS> mySearchList = new List<SearchCLS>();
            Conn.Open();
            try
            {
                string sSQL = _sSQL;
                sSQL += sCondition;
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                SearchCLS mySearch;
                Search_lst.Items.Clear();

                while (Rd.Read())
                {
                    Search_lst.Items.Add(new ListItem(Rd[_sField1].ToString() + " | " + Rd[_sField2].ToString(), Rd[_sField1].ToString()));
                    mySearch = new SearchCLS();
                    if (!string.IsNullOrEmpty(_sField1))
                    {
                        mySearch.SField1 = Rd[_sField1].ToString();
                    }
                    if (!string.IsNullOrEmpty(_sField2))
                    {
                        mySearch.SField2 = Rd[_sField2].ToString();
                    }
                    if (!string.IsNullOrEmpty(_sField3))
                    {
                        mySearch.SField3 = Rd[_sField3].ToString();
                    }
                    if (!string.IsNullOrEmpty(_sField4))
                    {
                        mySearch.SField4 = Rd[_sField4].ToString();
                    }
                    if (!string.IsNullOrEmpty(_sField5))
                    {
                        mySearch.SField5 = Rd[_sField5].ToString();
                    }
                    //if (!string.IsNullOrEmpty(_sField6))
                    //{
                    //    mySearch.SField6 = Rd[_sField6].ToString();
                    //}


                    mySearchList.Add(mySearch);


                }
                Rd.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
            finally
            {
                Session["SearchList"] = mySearchList;
                //mySearchList.Clear();
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void SetSearchValues()
        {
            List<SearchCLS> mySearchList = new List<SearchCLS>();
            try
            {
                mySearchList = (List<SearchCLS>)Session["SearchList"];
                int iIndex = Search_lst.SelectedIndex;

                hdn_Field1.Value = mySearchList[iIndex].SField1;
                txt1.Text = mySearchList[iIndex].SField1;
                hdn_Field2.Value = mySearchList[iIndex].SField2;
                txt2.Text = mySearchList[iIndex].SField2;
                hdn_Field3.Value = mySearchList[iIndex].SField3;
                txt3.Text = mySearchList[iIndex].SField3;
                hdn_Field4.Value = mySearchList[iIndex].SField4;
                txt4.Text = mySearchList[iIndex].SField4;
                hdn_Field5.Value = mySearchList[iIndex].SField5;
                txt5.Text = mySearchList[iIndex].SField5;
                //hdn_Field6.Value = mySearchList[iIndex].SField6;
                //txt6.Text = mySearchList[iIndex].SField6;

                RaiseChangedEvent();

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                mySearchList.Clear();
                Search_lst.Items.Clear();
                Search_lst.Visible = false;
            }
        }

        protected void Page_PreRender(object Sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_sField1) && !string.IsNullOrEmpty(_sCaption1))
            {
                lbl1.Text = _sCaption1;
            }
            else
            {
                lbl1.Visible = false;
                txt1.Visible = false;
            }

            if (!string.IsNullOrEmpty(_sField2) && !string.IsNullOrEmpty(_sCaption2))
            {
                lbl2.Text = _sCaption2;
            }
            else
            {
                lbl2.Visible = false;
                txt2.Visible = false;
            }

            if (!string.IsNullOrEmpty(_sField3) && !string.IsNullOrEmpty(_sCaption3))
            {
                lbl3.Text = _sCaption3;
            }
            else
            {
                lbl3.Visible = false;
                txt3.Visible = false;
            }

            if (!string.IsNullOrEmpty(_sField4) && !string.IsNullOrEmpty(_sCaption4))
            {
                lbl4.Text = _sCaption4;
            }
            else
            {
                lbl4.Visible = false;
                txt4.Visible = false;
            }

            if (!string.IsNullOrEmpty(_sField5) && !string.IsNullOrEmpty(_sCaption5))
            {
                lbl5.Text = _sCaption5;
            }
            else
            {
                lbl5.Visible = false;
                txt5.Visible = false;
            }

            //if (!string.IsNullOrEmpty(_sField6) && !string.IsNullOrEmpty(_sCaption6))
            //{
            //    lbl6.Text = _sCaption6;
            //}
            //else
            //{
            //    lbl6.Visible = false;
            //    txt6.Visible = false;
            //}


        }

        protected void Clear_LNK_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        public void ClearControls()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt5.Text = "";
            hdn_Field1.Value = "";
            hdn_Field2.Value = "";
            hdn_Field3.Value = "";
            hdn_Field4.Value = "";
            hdn_Field5.Value = "";
            //hdn_Field6.Value = "";
            Search_lst.Items.Clear();
            RaiseNewEvent();
        }
        protected void txt3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txt1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txt2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}