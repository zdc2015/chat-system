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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nickName = this.textBox1.Text;
            String account = this.textBox2.Text;
            String password = this.textBox3.Text;
            String confirm = this.textBox4.Text;

            if(nickName=="" || account=="" || password=="" || confirm == "")
            {
                prompt.Text = "输入框不能有空";
                return;
            }

            if (Util.IsExist("Consumer", "account", account))
            {
                prompt.Text = "账号已注册";
                return;
            }

            if (confirm != password)
            {
                prompt.Text = "两次输入密码不同！";
                return;
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("account", account);
            dic.Add("nickname", nickName);
            dic.Add("password", password);
            dic.Add("status", "waiting");
            Util.Insert("Applicant", dic);
            MessageBox.Show("申请成功，请等待审核");
            this.Close();
        }
    }
}
