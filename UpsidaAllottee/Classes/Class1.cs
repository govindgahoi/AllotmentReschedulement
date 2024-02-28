using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Data.Common;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Drawing.Design;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using System.Data.OleDb;
using System.Drawing;
using System.Web.Script;
using System.Web.SessionState;


namespace Allotment.Classes
{
    public class Class1
    {

        //SqlConnection _mcon;
        //SqlCommand _mcom;
        public Class1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region All private method
        public void openConnection()
        {
            if (_mcon == null)
            {
                _mcon = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
            }
            if (_mcon.State == ConnectionState.Closed)
            {
                _mcon.Open();
            }
            // initilized Command Object
            _mcom = new SqlCommand();
            _mcom.Connection = _mcon;
        }
        private void closeConnection()
        {
            if (_mcon.State == ConnectionState.Open)
                _mcon.Close();
        }
        private void Dispose()
        {
            if (_mcon != null)
                _mcon.Dispose();
            _mcon = null;
        }

        # endregion
        # region All property

        private SqlConnection _mcon;

        public SqlConnection mcon
        {
            get { return _mcon; }
            set { _mcon = value; }
        }

        private SqlTransaction _mtr;

        public SqlTransaction mtr
        {
            get { return _mtr; }
            set { _mtr = value; }
        }
        private SqlCommand _mcom;

        public SqlCommand mcom
        {
            get { return _mcom; }
            set { _mcom = value; }
        }

        private SqlDataAdapter _mda;

        public SqlDataAdapter mda
        {
            get { return _mda; }
            set { _mda = value; }
        }
        private SqlDataReader _mdr;

        public SqlDataReader mdr
        {
            get { return _mdr; }
            set { _mdr = value; }
        }
        private string _str;

        public string str
        {
            get { return _str; }
            set { _str = value; }
        }
        private Int32 _maxId;

        public Int32 maxId
        {
            get { return _maxId; }
            set { _maxId = value; }
        }

        private int _count;

        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        # endregion
        //*******Java Script Alert Box Function*****
        public void showPDF(string ActualFileName, string AliasFileName, Page refP)
        {
            ScriptManager.RegisterClientScriptBlock(refP, refP.GetType(), "pdfFile", "openPDF('" + ActualFileName + "','" + AliasFileName + "');", true);
        }
        public void AlertBox(string Message, Page refP)
        {
            string str = "window.alert('" + Message + "')";
            ScriptManager.RegisterClientScriptBlock(refP, refP.GetType(), "UniqueKey", str, true);
        }
        public void SAlertBox(string Message, Page refP)
        {
            string str = "document.getElementById('ctl00_lnkMsgPop').click();";
            ScriptManager.RegisterClientScriptBlock(refP, refP.GetType(), "UniqueKey", str, true);
        }
        //***Execuable Function Procedure That Accept The Parameter From Code To Data Base *****,,, 
        public Boolean ExecuteProcedure(string ProcedureName, ParameterCollection Parameters, string ConnectionString)
        {
            Boolean flag = false;
            try
            {
                openConnection();
                _mcom.CommandType = CommandType.StoredProcedure;
                _mcom.CommandText = ProcedureName.Trim();
                _mcom.CommandTimeout = 1200;
                _mcom.Connection = _mcon;
                SqlCommandBuilder.DeriveParameters(_mcom);
                SqlParameterCollection PCollection;
                PCollection = _mcom.Parameters;
                for (int i = 0; i <= Parameters.Count - 1; i++)
                {
                    if (Parameters[i].DbType == DbType.Byte)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.FromBase64String(Parameters[i].DefaultValue);
                    }
                    else
                        if (Parameters[i].DbType == DbType.Binary)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.FromBase64String(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.DateTime)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDateTime(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Int32)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToInt32(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.String)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToString(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Date)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDateTime(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Decimal)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDecimal(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Double)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDecimal(Parameters[i].DefaultValue);
                    }
                    else
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToString(Parameters[i].DefaultValue);
                    }
                }
                _mcom.ExecuteNonQuery();

                _mcon.Close();
                _mcon.Dispose();
                flag = true;

            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
        //****Executable Function Procedure That Accept The Parameter  Without Connection String*****,,,,,,
        public int ExecuteProcedure1(string ProcedureName, ParameterCollection Parameters)
        {
            int flag = 0;
            try
            {
                openConnection();
                _mcom.CommandType = CommandType.StoredProcedure;
                _mcom.CommandText = ProcedureName.Trim();
                _mcom.CommandTimeout = 1200;
                _mcom.Connection = _mcon;
                SqlCommandBuilder.DeriveParameters(_mcom);
                SqlParameterCollection PCollection;
                PCollection = _mcom.Parameters;
                for (int i = 0; i <= Parameters.Count - 1; i++)
                {
                    if (Parameters[i].DbType == DbType.Byte)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.FromBase64String(Parameters[i].DefaultValue);
                    }
                    else
                        if (Parameters[i].DbType == DbType.Binary)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.FromBase64String(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.DateTime)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDateTime(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Int32)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToInt32(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.String)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToString(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Date)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDateTime(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Decimal)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDecimal(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Double)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDecimal(Parameters[i].DefaultValue);
                    }
                    else
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToString(Parameters[i].DefaultValue);
                    }
                }
                _mcom.ExecuteNonQuery();

                _mcon.Close();
                _mcon.Dispose();
                flag = 1;

            }
            catch (Exception ex)
            {
                flag = 0;
            }
            return flag;
        }

        //Proceedure To Be Execute The Output Method Through Data Base Without Connection String *****,,,,Powered  
        public string ExecuteProcedureOutput(string ProcedureName, ParameterCollection Parameters)
        {
            string flag = "0";
            try
            {

                openConnection();
                _mcom.CommandType = CommandType.StoredProcedure;
                _mcom.CommandText = ProcedureName.Trim();
                _mcom.CommandTimeout = 1200;
                _mcom.Connection = _mcon;
                SqlCommandBuilder.DeriveParameters(_mcom);
                SqlParameterCollection PCollection;
                PCollection = _mcom.Parameters;
                for (int i = 0; i <= Parameters.Count - 1; i++)
                {
                    if (Parameters[i].DbType == DbType.Byte)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.FromBase64String(Parameters[i].DefaultValue);
                    }
                    else
                        if (Parameters[i].DbType == DbType.Binary)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.FromBase64String(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.DateTime)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDateTime(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Int32)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToInt32(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.String)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToString(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Date)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDateTime(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Decimal)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDecimal(Parameters[i].DefaultValue);
                    }
                    else if (Parameters[i].DbType == DbType.Double)
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToDecimal(Parameters[i].DefaultValue);
                    }
                    else
                    {
                        PCollection[Parameters[i].Name].Value = Convert.ToString(Parameters[i].DefaultValue);
                    }
                }
                _mcom.ExecuteNonQuery();
                string t = Convert.ToString(_mcom.Parameters["@res"].Value);
                _mcon.Close();
                _mcon.Dispose();
                flag = t;

            }
            catch (Exception ex)
            {
                flag = "0";
            }
            return flag;
        }

        public int ExecuteSql1(string strSql)
        {
            openConnection();
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strSql;
            _mcom.CommandTimeout = 1200;
            int result = _mcom.ExecuteNonQuery();
            return result;
        }
        //***Execute Scalar Function*******///
        public void ExecuteSql(string strSql)
        {
            openConnection();
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strSql;
            _mcom.CommandTimeout = 1200;
            _mcom.ExecuteNonQuery();
        }

        public void ExecuteSqlWhTr(string strSql)
        {
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strSql;
            _mcom.Transaction = _mtr;
            _mcom.CommandTimeout = 1200;
            _mcom.ExecuteNonQuery();

        }
        //***Execute Scalar With Transaction ***************************
        public int ExecuteSqlWhTr1(string strSql)
        {
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strSql;
            _mcom.Transaction = _mtr;
            _mcom.CommandTimeout = 1200;
            int result = _mcom.ExecuteNonQuery();
            return result;
        }
        //Funtion For Defining Datatable*******//
        public DataTable GetDataTable(string strsql)
        {
            openConnection();
            DataTable dt = new DataTable();
            _mda = new SqlDataAdapter();
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strsql;
            _mcom.CommandTimeout = 1200;
            _mda.SelectCommand = _mcom;
            _mda.Fill(dt);
            closeConnection();
            return dt;
        }

        //**** Get DataTable With Transaction********//

        public DataTable GetDataTableWTTR(string strsql)
        {
            DataTable dt = new DataTable();
            _mda = new SqlDataAdapter();
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strsql;
            _mcom.Transaction = _mtr;
            _mcom.CommandTimeout = 1200;
            _mda.SelectCommand = _mcom;
            _mda.Fill(dt);
            return dt;
        }
        //*****Predefine Function For Date Time Directly Through Data Base Including Base Directory
        public DateTime getdatetime()
        {
            DateTime d1 = new DateTime();
            return d1 = System.DateTime.Now;
            //return d1 = Convert.ToDateTime(System.DateTime.UtcNow.AddHours(+5.30).ToString());
        }
        //** Predefine Funtion Converting For Getting Time  
        public DateTime getdatetime2()
        {
            DateTime d1 = new DateTime();
            return d1 = Convert.ToDateTime(System.DateTime.UtcNow.AddHours(+5.50).ToString());
        }
        //****Predefine Function  For Getting MaxId****//
        public int MaxId(string strSql)
        {
            int st;
            openConnection();
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strSql;
            _mcom.CommandTimeout = 1200;
            object o = _mcom.ExecuteScalar();
            if (o.ToString() == "")
            {
                st = 1000;
            }
            else
            {
                st = Convert.ToInt32(o) + 1;
            }
            return st;
        }

        public string randomNo(Int32 len)
        {
            Random r = new Random();
            string temp = null;
            Int32 n;
            char[] y = new char[50];
            y = "0123456789".ToCharArray();
            for (Int32 x = 0; x < len; x++)
            {
                n = r.Next(1, 10);
                temp = temp + y[n];
            }
            return temp.ToString();
        }

        //** Funtion To Execute Scaler With Transaction***** ......
        public object ExecuteScaler(string strSql)
        {
            openConnection();
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strSql;
            _mcom.CommandTimeout = 1200;
            object o = _mcom.ExecuteScalar();
            return o;
        }
        //***Funtion For Executing Scaler With Transaction**** Powered **** 
        public object ExecuteScalerWhTr(string strSql)
        {
            _mcom.CommandType = CommandType.Text;
            _mcom.CommandText = strSql;
            _mcom.Transaction = _mtr;
            _mcom.CommandTimeout = 1200;
            object o = _mcom.ExecuteScalar();
            return o;
        }





        //  Funtion To Show Message While Any Excution Performed **** 

        public void showMsg(Label label1, string type, string msg)
        {
            if (type == "y")
            {
                label1.ForeColor = System.Drawing.Color.Green;
                label1.Text = msg;
            }
            else if (type == "N")
            {
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = msg;
            }
        }


        public void UpdateTabcounter(int count, string tablename)
        {
            str = "update tabcounter set counter_id=" + count + "  where table_name='" + tablename + "'";
            ExecuteScaler(str);
        }

        public int TabCounterwttr(string tablename)
        {
            str = "select (counter_id) from tabcounter where table_name='" + tablename + "'";
            int no = Convert.ToInt32(ExecuteScalerWhTr(str));
            return no;
        }

        public void updateTabCounterwttr(int count, string tablename)
        {
            str = "update tabcounter set counter_id=" + count + "  where table_name='" + tablename + "'";
            ExecuteScalerWhTr(str);
        }

        //Show Grid.............................................................................................................
        public void ShowGrid(string query, GridView gd, Label lblrecord)
        {
            DataTable dt = new DataTable();
            str = query;
            dt = GetDataTable(str);
            if (dt.Rows.Count > 0)
            {
                gd.DataSource = dt;
                gd.DataBind();
            }
            else
            {
                gd.DataSource = null;
                gd.DataBind();
            }
            lblrecord.Text = dt.Rows.Count.ToString();
        }


        public int SalClosingapprove(double SIncome, double TDS, double Adminchg, string uids, string Saldate)
        {
            int x = 0;
            if (SIncome > 0)
            {
                str = "EXEC InsertIncome '" + uids + "','cr','" + SIncome + "','Salary Income','" + Saldate + "'; ";
                ExecuteSqlWhTr(str);
            }
            if (TDS > 0)
            {
                str = "EXEC InsertIncome '" + uids + "','dr','" + TDS + "','Tds Deduction on Income','" + Saldate + "'; ";
                ExecuteSqlWhTr(str);
            }
            if (TDS > 0)
            {
                str = "EXEC InsertIncome '" + uids + "','dr','" + Adminchg + "','Admin Charge','" + Saldate + "'; ";
                ExecuteSqlWhTr(str);
            }
            x = 1;
            return x;
        }


        public string TabCounterWithoutTable(string tablename, string Colums)
        {
            string maxids = "";
            str = "select max(" + Colums + ") from " + tablename + "";
            maxids = Convert.ToString(ExecuteScaler(str));
            if (maxids == "")
            {
                maxids = "0";
            }
            else if (maxids != "")
            {
                maxids = (Convert.ToInt32(maxids) + 1).ToString();
            }
            return maxids;
        }

        public string TabCounterWithoutTableWhTr(string tablename, string Colums)
        {
            string maxids = "";
            str = "select max(" + Colums + ") from " + tablename + "";
            maxids = Convert.ToString(ExecuteScalerWhTr(str));
            if (maxids == "")
            {
                maxids = "0";
            }
            else if (maxids != "")
            {
                maxids = (Convert.ToInt32(maxids) + 1).ToString();
            }
            return maxids;
        }

        public string autoIds(string columname, string tablename)
        {
            string maxids = "";
            str = "select max(convert(INT," + columname + ")) from " + tablename + "";
            maxids = Convert.ToString(ExecuteScaler(str));
            if (maxids == "")
            {
                maxids = "1";
            }
            else
            {
                maxids = (Convert.ToInt32(maxids) + 1).ToString();
            }
            return maxids;
        }

        public string autoIdsWhTr(string columname, string tablename)
        {
            string maxids = "";
            str = "select max(convert(INT," + columname + ")) from " + tablename + "";
            maxids = Convert.ToString(ExecuteScalerWhTr(str));
            if (maxids == "")
            {
                maxids = "1";
            }
            else
            {
                maxids = (Convert.ToInt32(maxids) + 1).ToString();
            }
            return maxids;
        }

    }
}