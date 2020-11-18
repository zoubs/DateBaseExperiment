using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
namespace StudentManager
{
    public partial class MillonTest : Form
    {
        public MillonTest()
        {
            InitializeComponent();
        }
        public static int[] age = new int[] { 18, 19, 20, 21, 22 };
        public static string[] sex = new string[] { "男", "女" };
        public static List<string> Xing = new List<string>() {"赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯", "陈", "楮", "卫", "蒋", "沈", "韩", "杨",
        "朱", "秦", "尤", "许", "何", "吕", "施", "张", "孔", "曹", "严", "华", "金", "魏", "陶", "姜",
        "戚", "谢", "邹", "喻", "柏", "水", "窦", "章", "云", "苏", "潘", "葛", "奚", "范", "彭", "郎",
        "鲁", "韦", "昌", "马", "苗", "凤", "花", "方", "俞", "任", "袁", "柳", "酆", "鲍", "史", "唐",
        "费", "廉", "岑", "薛", "雷", "贺", "倪", "汤", "滕", "殷", "罗", "毕", "郝", "邬", "安", "常",
        "乐", "于", "时", "傅", "皮", "卞", "齐", "康", "伍", "余", "元", "卜", "顾", "孟", "平", "黄",
        "和", "穆", "萧", "尹", "姚", "邵", "湛", "汪", "祁", "毛", "禹", "狄", "米", "贝", "明", "臧",
        "计", "伏", "成", "戴", "谈", "宋", "茅", "庞", "熊", "纪", "舒", "屈", "项", "祝", "董", "梁",
        "杜", "阮", "蓝", "闽", "席", "季", "麻", "强", "贾", "路", "娄", "危", "江", "童", "颜", "郭",
        "梅", "盛", "林", "刁", "锺", "徐", "丘", "骆", "高", "夏", "蔡", "田", "樊", "胡", "凌", "霍",
        "虞", "万", "支", "柯", "昝", "管", "卢", "莫", "经", "房", "裘", "缪", "干", "解", "应", "宗",
        "丁", "宣", "贲", "邓", "郁", "单", "杭", "洪", "包", "诸", "左", "石", "崔", "吉", "钮", "龚",
        "程", "嵇", "邢", "滑", "裴", "陆", "荣", "翁", "荀", "羊", "於", "惠", "甄", "麹", "家", "封",
        "芮", "羿", "储", "靳", "汲", "邴", "糜", "松", "井", "段", "富", "巫", "乌", "焦", "巴", "弓",
        "牧", "隗", "山", "谷", "车", "侯", "宓", "蓬", "全", "郗", "班", "仰", "秋", "仲", "伊", "宫",
        "宁", "仇", "栾", "暴", "甘", "斜", "厉", "戎", "祖", "武", "符", "刘", "景", "詹", "束", "龙",
        "叶", "幸", "司", "韶", "郜", "黎", "蓟", "薄", "印", "宿", "白", "怀", "蒲", "邰", "从", "鄂",
        "索", "咸", "籍", "赖", "卓", "蔺", "屠", "蒙", "池", "乔", "阴", "郁", "胥", "能", "苍", "双",
        "闻", "莘", "党", "翟", "谭", "贡", "劳", "逄", "姬", "申", "扶", "堵", "冉", "宰", "郦", "雍",
        "郤", "璩", "桑", "桂", "濮", "牛", "寿", "通", "边", "扈", "燕", "冀", "郏", "浦", "尚", "农",
        "温", "别", "庄", "晏", "柴", "瞿", "阎", "充", "慕", "连", "茹", "习", "宦", "艾", "鱼", "容",
        "向", "古", "易", "慎", "戈", "廖", "庾", "终", "暨", "居", "衡", "步", "都", "耿", "满", "弘",
        "匡", "国", "文", "寇", "广", "禄", "阙", "东", "欧", "殳", "沃", "利", "蔚", "越", "夔", "隆",
        "师", "巩", "厍", "聂", "晁", "勾", "敖", "融", "冷", "訾", "辛", "阚", "那", "简", "饶", "空",
        "曾", "毋", "沙", "乜", "养", "鞠", "须", "丰", "巢", "关", "蒯", "相", "查", "后", "荆", "红",
        "游", "竺", "权", "逑", "盖", "益", "桓", "公", "仉", "督", "晋", "楚", "阎", "法", "汝", "鄢",
        "涂", "钦", "岳", "帅", "缑", "亢", "况", "后", "有", "琴", "归", "海", "墨", "哈", "谯", "笪",
        "年", "爱", "阳", "佟", "商", "牟", "佘", "佴", "伯", "赏",
        "万俟", "司马", "上官", "欧阳", "夏侯", "诸葛", "闻人", "东方", "赫连", "皇甫", "尉迟", "公羊",
        "澹台", "公冶", "宗政", "濮阳", "淳于", "单于", "太叔", "申屠", "公孙", "仲孙", "轩辕", "令狐",
        "锺离", "宇文", "长孙", "慕容", "鲜于", "闾丘", "司徒", "司空", "丌官", "司寇", "子车", "微生",
        "颛孙", "端木", "巫马", "公西", "漆雕", "乐正", "壤驷", "公良", "拓拔", "夹谷", "宰父", "谷梁",
        "段干", "百里", "东郭", "南门", "呼延", "羊舌", "梁丘", "左丘", "东门", "西门", "南宫"};
        //public static List<string> name = new List<string>() { };
        //public static List<string> major = new List<string>() { "CS", "IS", "SL", "TE", "AU", "EE", "MS", "ME", "PM", "CE", "DP", "FD", "DG", "SM", "EM" };
        public static List<string> major = new List<string>() { "计算机科学与技术", "软件工程", "飞行器设计", "自动化", "电子信息", "信息安全", "电气工程", "机械工程", "土木工程", "交通运输", "摆摊工程", "经济管理", "行政", "法律", "飞行器动力" };
        public static List<string> hometown = new List<string>() { "河南", "河北", "上海", "北京", "广州", "江苏", "浙江", "四川", "广西", "福建" };
        public static string girl = "秀娟英华慧巧美娜静淑惠珠翠雅芝玉萍红娥玲芬芳燕彩春菊兰凤洁梅琳素云莲真" +
                                     "环雪荣爱妹霞香月莺媛艳瑞凡佳嘉琼勤珍贞莉桂娣叶璧璐娅琦晶妍茜秋珊莎锦黛" +
                                     "青倩婷姣婉娴瑾颖露瑶怡婵雁蓓纨仪荷丹蓉眉君琴蕊薇菁梦岚苑婕馨瑗琰韵融园" +
                                     "艺咏卿聪澜纯毓悦昭冰爽琬茗羽希宁欣飘育滢馥筠柔竹霭凝晓欢霄枫芸菲寒伊亚" +
                                     "宜可姬舒影荔枝思丽 ";  
        public static string boy = "伟刚勇毅俊峰强军平保东文辉力明永健世广志义兴良海山仁波宁贵福生龙元全国" +
                                    "胜学祥才发武新利清飞彬富顺信子杰涛昌成康星光天达安岩中茂进林有坚和彪博" +
                                    "诚先敬震振壮会思群豪心邦承乐绍功松善厚庆磊民友裕河哲江超浩亮政谦亨奇固" +
                                    "之轮翰朗伯宏言若鸣朋斌梁栋维启克伦翔旭鹏泽晨辰士以建家致树炎德行时泰盛" +
                                    "雄琛钧冠策腾楠榕风航弘";
        public static List<string> Grade = new List<string>() { "大一", "大二", "大三", "大四" };
        public static string password = "123456";
        public static string birth = "1950-01-01";
        private void gen_student()
        {
            int Xing_Num = Xing.Count;
            string Sname, Sno, Ssex, Shometown, Smajor, Sgrade;
            int Sage, Rand_Xing, Rand_Name1, Rand_Name2;
            int sno = 1;
            int Boy_Num = boy.Length;
            int Girl_Num = girl.Length;
            int Home_Num = hometown.Count;
            int Major_Num = major.Count();
            string sql;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            for (int i = 0; i < 1000000; i++, sno++)
            {
                Rand_Xing = new Random(Guid.NewGuid().GetHashCode()).Next(0, Xing_Num);
                Sname = Xing[Rand_Xing];
                Ssex = (Rand_Xing % 2 == 0) ? "男" : "女";
                if (Ssex.CompareTo("男") == 0)
                {
                    Rand_Name1 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Boy_Num);
                    Sname += boy[Rand_Name1];
                    if (Rand_Name1 % 4 != 0)
                    {
                        Rand_Name2 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Boy_Num);
                        Sname += boy[Rand_Name2];
                    }
                }
                else
                {
                    Rand_Name1 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Girl_Num);
                    Sname += girl[Rand_Name1];
                    if (Rand_Name1 % 4 != 0)
                    {
                        Rand_Name2 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Girl_Num);
                        Sname += girl[Rand_Name2];
                    }
                }

                Sage = age[Rand_Xing % 5];
                Shometown = hometown[Rand_Xing % Home_Num];
                Smajor = major[Rand_Xing % Major_Num];
                Sgrade = Grade[Rand_Xing % 4];
                Sno = sno.ToString();
                sql = "select * from Student where Sno = '" + Sno + "'";
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("已经存在的学生学号！");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    sql = "insert into Student(Sno,Sname,Spassword,Sbirth,Ssex,Smajor,Sgrade,Shometown, role)values('" + Sno + "','" + Sname + "','" + password + "','"
                           + birth + "','" + Ssex + "','" + Smajor + "','" + Sgrade + "','" + Shometown + "','学生')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("数据导入成功");
            conn.Close();
        }

        private void gen()
        {
            //string[] Sname[] = {""}
            int Xing_Num = Xing.Count;
            string Sname, Sno, Ssex, Shometown, Smajor, Sgrade;
            int Sage, Rand_Xing, Rand_Name1,Rand_Name2;
            int sno = 1;
            int Boy_Num = boy.Length;
            int Girl_Num = girl.Length;
            int Home_Num = hometown.Count;
            int Major_Num = major.Count();
            string sql;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            for (int i = 0; i < 1000000; i++, sno++)
            {
                Rand_Xing = new Random(Guid.NewGuid().GetHashCode()).Next(0, Xing_Num);
                Sname = Xing[Rand_Xing];
                Ssex = (Rand_Xing % 2 == 0) ? "男":"女";
                if(Ssex.CompareTo("男") == 0)
                {
                    Rand_Name1 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Boy_Num);
                    Sname += boy[Rand_Name1];
                    if(Rand_Name1%4 != 0)
                    {
                        Rand_Name2 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Boy_Num);
                        Sname += boy[Rand_Name2];
                    }
                }
                else
                {
                    Rand_Name1 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Girl_Num);
                    Sname += girl[Rand_Name1];
                    if (Rand_Name1 % 4 != 0)
                    {
                        Rand_Name2 = new Random(Guid.NewGuid().GetHashCode()).Next(0, Girl_Num);
                        Sname += girl[Rand_Name2];
                    }
                }

                Sage = age[Rand_Xing % 5];
                Shometown = hometown[Rand_Xing % Home_Num];
                Smajor = major[Rand_Xing % Major_Num];
                Sgrade = Grade[Rand_Xing % 4];
                Sno = sno.ToString();
                sql = "select * from millontest where Sno = '" + Sno + "'";
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("已经存在的学生学号！");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    sql = "insert into millontest(Sno,Sname,Ssex,Smajor,Sgrade,Shometown)values('" + Sno + "','" + Sname + "','" 
                           + Ssex + "','" + Smajor + "','" + Sgrade + "','" + Shometown + "')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("数据导入成功");
            conn.Close();
        }

        private void buttoninsert_Click(object sender, EventArgs e)
        {
            //this.buttoninsert.Enabled = false;
            //this.gen();
            //this.gen_student();
            
        }

        private void buttonselect_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            string Sno = textBoxSno.Text.Trim();
            if(Sno == "")
            {
                MessageBox.Show("请输入学号！");
            }
            else
            {
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                
                string sql = "select * from millontest where Sno = '" + Sno + "'";
                sw.Start();
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    textBoxTime.Text = time.TotalMilliseconds.ToString() + " ms";
                    MessageBox.Show("查询成功!");
                }
                else
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    textBoxTime.Text = time.TotalMilliseconds.ToString() + " ms";
                    MessageBox.Show("查询失败!");
                }
                conn.Close();
            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            string Sno = textBoxSno.Text.Trim();
            if (Sno == "")
            {
                MessageBox.Show("请输入学号！");
            }
            else
            {
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                //SqlCommand cmd = new SqlCommand("")
                string sql = "delete from millontest where Sno = '" + Sno + "'";
                sw.Start();

                SqlCommand cmd = new SqlCommand(sql, conn);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    textBoxTime.Text = time.TotalMilliseconds.ToString() + " ms";
                    MessageBox.Show("删除成功");
                }
                else
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    textBoxTime.Text = time.TotalMilliseconds.ToString() + " ms";
                    MessageBox.Show("删除失败");
                }
                conn.Close();
            }
        }
    }
}
