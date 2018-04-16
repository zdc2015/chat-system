using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilLib
{
    public class Util
    {
        public static String sqlCon = "Data Source=(local);Database=communication;Uid=sa;Pwd=123456";
        private static Dictionary<String, String> dic = new Dictionary<string, string>();

        /// <summary>
        /// 1 登录成功 2 申请拒绝 3 用户名或密码错误 4 申请审核中
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static public int Login(String account, String password)
        {
            dic.Clear();
            dic.Add("account", account);
            dic.Add("password", password);
            DataSet ds = GetTableDataSet("Consumer", dic);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return 1;
            }
            ds = GetTableDataSet("Applicant", dic);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["status"].ToString() == "refuse")
                {
                    return 2;
                }else if(row["status"].ToString() == "waiting")
                {
                    return 4;
                }
            }
            return 3;
        }

        public static Boolean IsExist(String tableName, String key ,String value)
        {
            DataSet ds = GetTableDataSet(tableName, key, value);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static DataSet GetTableDataSet(String tableName, String Key, String Value)
        {
            string sqlstr = "select * from " + tableName.Trim() + " where " + Key.Trim() + " like '%" + Value.Trim() + "%'";
            return GetDataSet(sqlstr, tableName);
        }

        public static DataSet GetTableDataSet(String tableName, Dictionary<String, String> dic)
        {
            string sqlstr = "select * from " + tableName.Trim() + " where ";
            foreach (KeyValuePair<String, String> kvp in dic)
            {
                sqlstr += kvp.Key.Trim() + " like '%" + kvp.Value.Trim() + "%' and ";
            }
            sqlstr = sqlstr.Substring(0, sqlstr.Length - 5);
            return GetDataSet(sqlstr, tableName);
        }

        private static DataSet GetDataSet(String sqlstr, String tableName)
        {
            SqlConnection scn = new SqlConnection(sqlCon);
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, scn);
            DataSet myds = new DataSet();
            scn.Open();
            myda.Fill(myds, tableName);
            scn.Close();
            return myds;
        }

        public static DataSet GetDialogue(String account1, String account2)
        {
            string sqlstr = "select * from Dialogue where (from='" + account1 + "' and to='"+account2+ "') or (from='" + account2 + "' and to='" + account1 + "')";
            return GetDataSet(sqlstr, "Dialogue");
        }

        public static void Insert(String tableName, Dictionary<String, String> dic)
        {
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            String sqlstr = "insert into " + tableName.Trim() + " (";
            foreach (KeyValuePair<String, String> kvp in dic)
            {
                sqlstr += kvp.Key.Trim() + ",";
            }
            sqlstr = sqlstr.Substring(0, sqlstr.Length - 1);
            sqlstr += ") values (";
            foreach (KeyValuePair<String, String> kvp in dic)
            {
                sqlstr += "'" + kvp.Value.Trim() + "',";
            }
            sqlstr = sqlstr.Substring(0, sqlstr.Length - 1);
            sqlstr += ")";
            SqlConnection sqlcon = new SqlConnection(sqlCon);
            SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        public static Boolean Delete(String tableName, String Key, String Value)
        {
            String sqlstr = "delete from " + tableName.Trim() + " where " + Key.Trim() + " = '" + Value.Trim() + "'";
            SqlConnection sqlcon = new SqlConnection(sqlCon);
            SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            return true;
        }

        public static Boolean Delete(String tableName, Dictionary<String,String> dic)
        {
            String sqlstr = "delete from " + tableName.Trim() + " where ";
            foreach (KeyValuePair<String, String> kvp in dic)
            {
                sqlstr += kvp.Key.Trim() + " = '" + kvp.Value.Trim() + "' and ";
            }
            sqlstr = sqlstr.Substring(0, sqlstr.Length - 5);
            SqlConnection sqlcon = new SqlConnection(sqlCon);
            SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            return true;
        }

        public static Boolean IsNameExist(String tableName, String name)
        {
            DataSet ds = GetTableDataSet(tableName, "name", name);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean IsStudentExist(String id)
        {
            DataSet ds = GetTableDataSet("Student", "id", id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void Update(Dictionary<String, String> dic, String tableName, String Key, String Value)
        {
            string sqlstr = "update " + tableName + " set ";
            foreach (KeyValuePair<String, String> kvp in dic)
            {
                sqlstr += kvp.Key.Trim() + "='" + kvp.Value.Trim() + "',";
            }
            sqlstr = sqlstr.Substring(0, sqlstr.Length - 1);
            sqlstr += " where " + Key.Trim() + "='" + Value.Trim() + "'";
            SqlConnection sqlcon = new SqlConnection(sqlCon);
            SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        public static DataSet GetTableDataSet(String tableName)
        {
            string sqlstr = "select * from " + tableName;
            return GetDataSet(sqlstr, tableName);
        }
    }
}