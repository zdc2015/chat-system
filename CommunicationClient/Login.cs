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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String account = this.tbaccount.Text;
            String password = this.tbpassword.Text;
            if(account=="" || password == "")
            {
                prompt.Text = "输入框不能为空";
                return;
            }
            int code = Util.Login(account, password);
            if (code == 1)
            {
                Main main = new Main(account);
                main.Show();
                this.Close();
            }
            else if (code == 2)
            {
                prompt.Text = "申请被拒绝";
            }
            else if (code == 3)
            {
                prompt.Text = "账号或密码错误";
                return;
            }
            else if (code == 4)
            {
                prompt.Text = "该账号申请审核中";
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            this.tbaccount.Focus();
        }
    }
}
