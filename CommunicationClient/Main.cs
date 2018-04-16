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

        public Main(String account)
        {
            this.account = account;
            InitializeComponent();
            lbaccount.Text += account;
            lbnickname.Text += Util.GetTableDataSet("Consumer", "account", account).Tables[0].Rows[0]["nickname"];
        }

        class frienditem
        {

        }

        private void bindData()
        {
            DataSet ds = Util.GetTableDataSet("Friend","self",account);
            DataView dv = ds.Tables[0].DefaultView;
            
            dv.Sort = "status desc";
            friendlist.DataSource = dv;
            friendlist.DisplayMember = "friend";
            friendlist.ValueMember = "friendaccount";
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

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String delacc = friendlist.SelectedValue.ToString();
            this.friendlist.Items.Remove(friendlist.SelectedItem);
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("self", account);
            dic.Add("friendaccount", delacc);
            Util.Delete("Friend", dic);
            dic.Clear();
            dic.Add("friendaccount", account);
            dic.Add("self", delacc);
            Util.Delete("Friend", dic);
            bindData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddFriend af = new AddFriend(account);
            af.Show();
        }
    }
}
