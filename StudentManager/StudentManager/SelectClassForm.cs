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
    public partial class chooseForm : Form
    {
        int stuid = 0;
        public chooseForm()
        {
            InitializeComponent();
        }



        private void chooseForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = loginForm.getStudent();
            string Sno = textBox1.Text;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sid from Student where Sno = '" + Sno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();

            int.TryParse(id1, out stuid);
           
            this.ShowSelected();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string flags = "1";
            //得到Sid
            string Sno = textBox1.Text;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sid from Student where Sno = '" + Sno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();

            int.TryParse(id1, out stuid);
            //得到课程的id
            int Cid = 0;
            int.TryParse(textBoxid.Text, out Cid);
            //查询你在该时间是否有课
            if (Cid > 0)
            {
                sql = "select Ctime from Ctime where Cid =" + Cid;
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string time = dr[0].ToString();//第一列
                    sql = "select * from SC,Ctime,Class where Class.Cid = SC.Cid and Class.Cid = Ctime.Cid and Ctime = '" + time + "' and SC.Sid =" + stuid;
                    SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                    DataSet ds1 = new DataSet();
                    adp1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        flags = "2";
                        MessageBox.Show("课程上课时间冲突！");
                        break;
                    }
                }
                if (flags == "1")
                {
                    sql = "insert into SC(Cid,Sid) values(" + Cid + "," + stuid + ")";
                    cmd.CommandText = sql;
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("选课成功！");

                    }

                }
            }
            if (listBox1.Items.Count > 0)
            {//清空所有项
                listBox1.Items.Clear();
            }
            sql = "select Class.Cname  from SC,Class where SC.Cid = Class.Cid and Sid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                listBox1.Items.Add(row[0].ToString());
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }
            string term = comboBox1.SelectedItem.ToString();
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Cid as 课程id,Cname as 课程 from Class where Cterm='" + term + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mos_click(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBoxclass.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string claname = listBox1.SelectedItem.ToString();
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Cid from Class where Cname = '" + claname + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();
            int claid = 0;
            int.TryParse(id1, out claid);
            sql = "delete from  SC  where  Cid = " + claid + " and Sid = " + stuid;
            cmd.CommandText = sql;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("删除成功！");
                if (listBox1.Items.Count > 0)
                {//清空所有项
                    listBox1.Items.Clear();
                }
                sql = "select Class.Cname  from SC,Class where SC.Cid = Class.Cid and Sid=" + stuid;
                SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                foreach (DataRow row in ds2.Tables[0].Rows)
                {
                    listBox1.Items.Add(row[0].ToString());
                }

            }

            conn.Close();

        }

        private void ShowSelected()
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            if (listBox1.Items.Count > 0)
            {//清空所有项
                listBox1.Items.Clear();
            }
            string sql = "select Class.Cname  from SC,Class where Class.Cid = SC.Cid and Sid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                listBox1.Items.Add(row[0].ToString());
            }
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonshow_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            if (listBox1.Items.Count > 0)
            {//清空所有项
                listBox1.Items.Clear();
            }
            string sql = "select Class.Cname  from SC,Class where SC.Cid = Class.Cid and Sid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                listBox1.Items.Add(row[0].ToString());
            }
            conn.Close();
        }
    }
}
