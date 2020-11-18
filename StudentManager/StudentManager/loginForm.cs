using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace StudentManager
{
    public partial class loginForm : Form
    {
        public static string connectionString = "uid=sa;pwd=123456;database=student;server=DESKTOP-Q7H2RSA";
        public static string name;
        public static string role;

        public loginForm()
        {


            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBoxname.Text.Trim();
           
            if (name == "" || textBoxpasswd.Text.Trim() == "" || this.comboBoxrole.SelectedItem == null)
            {
                MessageBox.Show("请将信息输入完整！");
            }
            else
            {
                role = this.comboBoxrole.SelectedItem.ToString();
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                if (role == "管理员")
                {
                    string sql = "select Mname,Mpassword from Manager where role='管理员'and Mname='" + name +
                     "' and Mpassword='" + textBoxpasswd.Text.Trim() + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        conn.Close();
                        Form1 mainframe = new Form1();
                        mainframe.BringToFront();
                        mainframe.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("用户名或者密码错误！");
                    }
                }
                else if (role == "学生")
                {
                    string sql1 = "select Sno,Spassword from Student where role='学生'and Sno='" + name +
                     "' and Spassword='" + textBoxpasswd.Text.Trim() + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql1, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //this.Close();
                        conn.Close();
                        Form3 mainframe = new Form3();
                        mainframe.BringToFront();
                        mainframe.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或者密码错误！");
                    }
                }

            }



        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void loginForm_Load(object sender, EventArgs e)
        {


        }

        private void comboBoxrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static String getStudent()
        {
            String stuxuehao = "";
            stuxuehao = loginForm.name;
            return stuxuehao;
        }

        public static String getRole()
        {
            String role1 = "";
            role1 = role;
            return role1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttontest_Click(object sender, EventArgs e)
        {
            MillonTest test = new MillonTest();
            //test.TopLevel = false;
            //test.FormBorderStyle = FormBorderStyle.None;
            test.WindowState = FormWindowState.Normal;
            test.Show();
        }
    }
}
