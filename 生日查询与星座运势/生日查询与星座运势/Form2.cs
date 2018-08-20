using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 生日查询与星座运势
{
    public partial class SearchFortune : Form
    {
        public SearchFortune()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 通过Class1使用Form1中按下运势查询按钮得到的幸运数字，并返回对应的运势字符串的函数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string FortuneToday(int number)
        {
            string fortune = "";
            switch (number)
            {
                case 8:
                    fortune = "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃。";
                    break;
                case 7:
                    fortune = "今天的财运旺盛，适合做投资和理财，会得到惊喜呦！";
                    break;
                case 6:
                    fortune = "健康运良好；适当食用带有咸味的食物，有利于运势。";
                    break;
                case 5:
                    fortune = "今天的事业运旺盛，凭着自己专业技能和认真的工作态度，领导早已属意与你，升职加薪指日可待,再换一台车也不是问题呦！";
                    break;
                case 4:
                    fortune = "今天的运势上多有不稳，做事难以顺心，心情难以舒畅，需要注意自我调整心态，毕竟和气才能生财嘛！";
                    break;
                case 3:
                    fortune = "好心情自然是要跟最重要的人一起分享，带着他（她）来一场说走就走的旅行吧。";
                    break;
                case 2:
                    fortune = "今天的运势比较有利，做事多能达到自己的要求，但是还需要注意自我调整心态，不要对某件事耿耿于怀，以免影响自己的判断力而失去机会，得不偿失。";
                    break;
                case 1:
                    fortune = "今天的运势是顺中有阻，可能会有一些原因导致事情进展的缓慢，但务必耐下性子，事情的结果并不会那么坏。";
                    break;
                case 0:
                    fortune = "有些事情看似都是在往好的方向发展，但是往往多为是虚假之象，结果并没有想象的那么好，因为今天会有小人出现，所以遇到事情的时候， 不要太相信别人，一定要慎重。";
                    break;
            }
            return fortune;
        }

        /// <summary>
        /// textbox显示对应的运势字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = FortuneToday(Class1.luckynumber);
        }

        /// <summary>
        /// 对应确认按钮，一旦按下该窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 对应导出结果按钮，一旦按下就将运势内容保存在C:\fortune.txt下，若已存在该文本文件就覆盖，若不存在则新建这个文件再存入内容，内容导出后会出现一个对话框提示用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\fortune.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            string appendText = "您今日的运势为：" +textBox1.Text;
            File.AppendAllText(path, appendText, Encoding.Default);
            if (File.Exists(path))
            {
                MessageBox.Show("运势内容已经导入文本文件\n文件为fortune.txt");
            }
        }
    }
}
