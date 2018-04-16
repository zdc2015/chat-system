using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilLib;

namespace CommunicationClient
{
    public partial class AddFriend : Form
    {
        private String account;

        public AddFriend(String account)
        {
            this.account = account;
            InitializeComponent();
        }

        class P
        {
            public String account { get; set; }
            public String status { get; set; }
            public String nickName { get; set; }
            public String view { get; set; }

        }
        /// <summary>
        /// 点击，搜索好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("account", textBox1.Text);
            dic.Add("nickname", textBox2.Text);
            DataSet ds = Util.GetTableDataSet("Consumer",dic);

            if (ds.Tables[0].Rows.Count == 0)
            {
                prompt.Text = "查无此人";
                return;
            }

            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "status desc";
            DataTable dt = dv.ToTable();
            List<P> list = new List<P>();
            foreach(DataRow dr in dt.Rows)
            {
                P p = new P()
                {
                    account = dr["account"].ToString(),
                    nickName = dr["nickname"].ToString(),
                    status = dr["status"].ToString(),
                    view = dr["nickname"].ToString()+ "  "+dr["status"].ToString()=="on"?"在线":"离线"
                };
                list.Add(p);
            }
            listBox1.DataSource = list;
            listBox1.DisplayMember = "view";
            listBox1.ValueMember = "account";
        }

    }
}
