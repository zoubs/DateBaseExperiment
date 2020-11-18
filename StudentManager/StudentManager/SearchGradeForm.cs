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
    public partial class searchgradeForm : Form
    {
        public searchgradeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string term = comboBox1.SelectedItem.ToString();
            //首先得到用户的id
            string stuxuehao = loginForm.getStudent();
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sid from Student where Sno = '" + stuxuehao + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();
            int stuid = 0;
            int.TryParse(id1, out stuid);
            //用到两个数据库的连接操作
            sql = "select Class.Cname as 课程名称,Class.Cterm as 学期,SC.Grade as 成绩 from SC,Class where Class.Cid=SC.Cid and SC.Sid=" + stuid;
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();




        }

        private void groupbox5_Enter(object sender, EventArgs e)
        {

        }

        private void searchgradeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
