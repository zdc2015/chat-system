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
    public partial class Chatting : Form
    {
        String account;
        String friendAccount;
        String friendName;

        public Chatting(String account, String friendAccount)
        {
            this.account = account;
            this.friendAccount = friendAccount;
            friendName = Util.GetTableDataSet("Consumer", "account", friendAccount).Tables[0].Rows[0]["account"].ToString();
            InitializeComponent();
        }

        class P
        {
            public String view { get; set; }
        }

        private void history_Click(object sender, EventArgs e)
        {
            DataSet ds = Util.GetDialogue(account, friendAccount);
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "time";
            DataTable dt = dv.ToTable();
            foreach(DataRow dr in dt.Rows)
            {

            }
        }
    }
}
