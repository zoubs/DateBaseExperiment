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
    public partial class countForm : Form
    {
        public countForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string term = comboBox1.SelectedItem.ToString();
            string claname = textBoxclass.Text;
            string g1 = textBox1.Text;
            int grade1 = 0;
            int.TryParse(g1, out grade1);
            string g2 = textBox2.Text;
            int grade2 = 0;
            int.TryParse(g2, out grade2);
            if (term == "" || claname == "")
            {
                MessageBox.Show("请将信息输入完整！");
            }
            else
            {


                if (g1 == "" || g2 == "")
                {
                    SqlConnection conn = new SqlConnection(loginForm.connectionString);
                    conn.Open();
                    //textBox1.Text.Trim()  textBox2.Text.Trim()
                    string sql = "select Class.Cname as 课程名称,Student.Sno as 学生学号,Sname as 学生姓名,SC.Grade as 成绩,Class.Cterm as 开课学期,Class.Cteacher as 开课教师 from Student,SC,Class where Student.Sid = SC.Sid and SC.Cid = Class.Cid and Cterm = '" + term + "' and Class.Cname = '" + claname + "'";
                    SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp1.Fill(ds);
                    //载入基本信息
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    //求的平均成绩并显示
                    sql = "select avg(Grade) from SC,Class where SC.Cid = Class.Cid and Class.Cname ='" + claname + "'";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    String avg = cmd.ExecuteScalar().ToString();
                    textBoxav.Text = avg;
                    //求的最高成绩并显示
                    sql = "select max(Grade) from SC,Class where SC.Cid = Class.Cid and Class.Cname ='" + claname + "'";

                    cmd.CommandText = sql;
                    String max = cmd.ExecuteScalar().ToString();
                    textBoxmax.Text = max;
                    //求的最低成绩并显示
                    sql = "select min(Grade) from SC,Class where SC.Cid = Class.Cid and Class.Cname ='" + claname + "'";
                    cmd.CommandText = sql;
                    String min = cmd.ExecuteScalar().ToString();
                    textBoxmin.Text = min;
                    conn.Close();
                }
                else
                {
                    SqlConnection conn = new SqlConnection(loginForm.connectionString);
                    conn.Open();
                    //textBox1.Text.Trim()  textBox2.Text.Trim()
                    string sql = "select Class.Cname as 课程名称,Sno as 学生学号,Student.Sname as 学生姓名,SC.Grade as 成绩,Class.Cterm as 开课学期,Class.Cteacher as 开课教师 from Student,SC,Class where Student.Sid = SC.Sid and SC.Cid = Class.Cid and Cterm = '" + term + "' and Class.Cname = '" + claname + "'and Grade between " + grade1 + " and " + grade2;
                    SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp1.Fill(ds);
                    //载入基本信息
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    conn.Close();
                }


            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void countForm_Load(object sender, EventArgs e)
        {

        }
    }
}
