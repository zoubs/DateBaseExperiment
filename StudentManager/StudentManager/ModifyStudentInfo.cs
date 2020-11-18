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
    public partial class modifystuForm : Form
    {
        public modifystuForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void modifystuForm_Load(object sender, EventArgs e)
        {
            this.getRusult();
            textBoxpage.Text = (page + 1).ToString();
        }

        public static int page = 0;
        private void getRusult()
        {
            //SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY ID ASC) AS rowid,* FROM infoTab)t WHERE t.rowid > 100000 AND t.rowid <= 100050
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string start_row, end_row;
            int start, end;
            start = page * 50;
            end = (page + 1) * 50;
            start_row = start.ToString();
            end_row = end.ToString();
            //textBox1.Text.Trim()  textBox2.Text.Trim()
            string sql = "select Sid as 用户id,Sname as 真实姓名,Sno as 学号,Spassword as 密码,Sgrade as 年级,Smajor as 专业,Ssex as 性别,Sbirth as 出生日期,Shometown as 籍贯 from (SELECT ROW_NUMBER() OVER(ORDER BY Sid ASC) AS rowid,* FROM Student)t where t.rowid >= "+ start_row +" and t.rowid < " + end_row;
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            textBoxpage.Text = (page + 1).ToString();
            conn.Close();
        }

        private void mos_click(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBoxborn.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            comboBoxgrade.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBoxhometown.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            comboBoxmajor.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBoxpasswd.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBoxpname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string gender = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            if (gender == "男")
            {
                radioButton1.Select();
            }
            else
            {
                radioButton2.Select();
            }
        }

        private void textBoxname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string gender = radioButton1.Checked ? "男" : "女";
            int id = 0;
            int.TryParse(textBoxid.Text, out id);
            //this.comboBoxrole.SelectedItem.ToString()
            string major = comboBoxmajor.SelectedItem.ToString();
            string grade = comboBoxgrade.SelectedItem.ToString();
            string sql = "update Student set Sname = '" + textBoxname.Text + "',Sbirth = '" + textBoxborn.Text + "' ,Sgrade = '" + grade + "' ,Shometown = '" + textBoxhometown.Text + "' ,Smajor = '" + major + "',Spassword = '" + textBoxpasswd.Text + "',Sno = '" + textBoxpname.Text + "',Ssex = '" + gender + "' where Sid = " + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("更改成功！");
                this.getRusult();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            int id = 0;
            int.TryParse(textBoxid.Text, out id);
            string sql = "delete from  Student  where  Sid = " + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("删除成功！");
                this.getRusult();
            }

            conn.Close();
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            string Select_Sno = textBox_select_sno.Text.Trim();
            if (Select_Sno == "")
            {
                MessageBox.Show("请输入要查询的学号!");
                page = 0;
                this.getRusult();
               
            }
            else
            {
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                string sql = "select Sid as 用户id,Sname as 真实姓名,Sno as 学号,Spassword as 密码,Sgrade as 年级,Smajor as 专业,Ssex as 性别,Sbirth as 出生日期,Shometown as 籍贯 from Student where Sno = " + "'" + Select_Sno + "'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                textBoxpage.Text = "1";
                conn.Close();
            }
        }

        private void buttonnext_Click(object sender, EventArgs e)
        {
            page++;
            this.getRusult();
        }

        private void buttonlast_Click(object sender, EventArgs e)
        {
            if (page == 0)
            {
                MessageBox.Show("已经是第1页!");
            }
            else
            {
                page--;
            }
            this.getRusult();
        }
    }
}

