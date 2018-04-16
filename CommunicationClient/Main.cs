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
    public partial class Main : Form
    {
        private String account = "";
        private int selectedIndex = -1;

        public Main(String account)
        {
            this.account = account;
            InitializeComponent();
            lbaccount.Text += account;
            lbnickname.Text += Util.GetTableDataSet("Consumer", "account", account).Tables[0].Rows[0]["nickname"];
            bindData();
        }

        class Frienditem
        {
            public String name { get; set; }
            public String account { get; set; }
            public String status { get; set; }
            public String view { get; set; }

            
            public Frienditem()
            {
                int s = Convert.ToInt32(status) - 1;
                view = name;
                if (s == 0)
                {
                    view += " 在线";
                }
                else if (s > 0)
                {
                    view += " (" + s + ")";
                }
            }
        }

        private void bindData()
        {
            DataSet ds = Util.GetTableDataSet("Friend","self",account);
            DataView dv = ds.Tables[0].DefaultView;
            
            dv.Sort = "status desc";
            DataTable dt = dv.ToTable();
            List<Frienditem> list = new List<Frienditem>();
            foreach(DataRow dr in dt.Rows)
            {
                //没调用构造函数？
                list.Add(new Frienditem()
                {
                    name = dr["friend"].ToString(),
                    account = dr["friendaccount"].ToString(),
                    status = dr["status"].ToString(),
                    view = Convert.ToInt32(dr["status"].ToString()) - 1==0? dr["friend"].ToString() + " 在线":Convert.ToInt32(dr["status"].ToString()) - 1 > 0?dr["friend"].ToString() + " (" + (Convert.ToInt32(dr["status"].ToString()) - 1) + ")": dr["friend"].ToString(),
                });
            }
            
            friendlist.DataSource = list;
            friendlist.DisplayMember = "view";
            friendlist.ValueMember = "account";
            friendlist.SelectedItems.Clear();
        }

        private void friendlist_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String delacc = friendlist.SelectedValue.ToString();
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("self", account);
            dic.Add("friendaccount", delacc);
            Util.Delete("Friend", dic);
            dic.Clear();
            dic.Add("friendaccount", account);
            dic.Add("self", delacc);
            Util.Delete("Friend", dic);
            bindData();
            timer1.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddFriend af = new AddFriend(account);
            af.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            bindData();
            timer1.Enabled = true;
        }

        private void friendlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void friendlist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            int index = this.friendlist.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Frienditem drv = friendlist.Items[index] as Frienditem;
                MessageBox.Show(drv.account);
            }
            timer1.Enabled = true;
            return;
            Chatting chatting = new Chatting(account, friendlist.SelectedValue.ToString());
            chatting.Show();
        }
    }
}
