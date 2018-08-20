using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 生日查询与星座运势
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置DateTimePicker中用户能选择的最大日期为当天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        /// <summary>
        /// 设数组储存每个月的天数
        /// </summary>
        public static int[] months = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// 计算一年当中的某一天的前面有多少天，计算结果包括这一天，不考虑闰年是否会多出一天的情况
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int theDayBefore(int month,int day)
        {
            int thedaybefore = 0;
            for(int i=0;i<month-1;i++)
            {
                thedaybefore += months[i];
            }
            thedaybefore += day;
            return thedaybefore;
        }

        /// <summary>
        /// 计算一年当中的某一天的后面还有多少天，计算结果不包括这一天，不考虑闰年是否会多出一天的情况
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int theDayAfter(int month, int day)
        {
            int thedayafter = 0;
            for (int i = month; i < 12; i++)
            {
                thedayafter += months[i];
            }
            int number = month - 1;
            thedayafter=thedayafter+months[number]-day ;
            return thedayafter;
        }

        /// <summary>
        /// 判断一个年份是不是闰年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool Judge(int year)
        {
            bool judge=false;
            if((year%4==0&&year%100!=0)||(year%400==0))
            {
                judge = true;
            }
            return judge;
        }

        /// <summary>
        /// 计算某一天出生的人在程序运行当天已经出生了多少天，利用了上面的theDayBefore和theDayAfter函数简化程序，计算过程考虑了闰年的情况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int Span(int year, int month, int day)
        {
            int datespan = 0;
            int yearNow = DateTime.Now.Year;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            for(int yearspan=year+1;yearspan<yearNow;yearspan++)
            {
                if (Judge(yearspan))
                {
                    datespan += 366;
                }
                else
                {
                    datespan += 365;
                }
            } 
            if (year != yearNow)
            {
                int before = theDayBefore(monthNow, dayNow);
                int after = theDayAfter(month, day);
                datespan = datespan + before + after;
                if (Judge(year)&&month<=2)
                {
                    datespan++;
                }
                if (Judge(yearNow)&&monthNow>2)
                {
                    datespan++;
                }
            }
            else
            {
                int between = theDayBefore(monthNow, dayNow)-theDayBefore(month,day);
                datespan += between;
                if (Judge(year)&&monthNow>2&&month<=2)
                {
                        datespan++;
                }
            }
            return datespan;
        }

        /// <summary>
        /// 计算某一天出生的人在程序运行当天距离他的下一个生日还有多少天，利用了上面的theDayBefore和theDayAfter函数简化程序，计算过程考虑了闰年的情况
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int theNextBirthday(int month, int day)
        {
            int yearNow = DateTime.Now.Year;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            int thenextspan = 0;
            if (month == 2 && day == 29)
            {
                if (Judge(yearNow) && (monthNow == 1 || (monthNow == 2 && dayNow < 29)))
                {
                    thenextspan = theDayBefore( 2, 28)-theDayBefore(monthNow,dayNow);
                    thenextspan++;
                }
                else
                {
                    int after = theDayAfter(monthNow, dayNow);
                    if (monthNow == 2 && dayNow == 29)
                    {
                        after = theDayAfter(2,28);
                    }
                    for(int number=yearNow+1;!(Judge(number));number++)
                    {
                        thenextspan += 365;
                    }
                    thenextspan = thenextspan + after + 31 + 29;
                }
            }
            else
            {
                if (month > monthNow || (month == monthNow && day > dayNow))
                {
                    thenextspan = theDayBefore(month, day)-theDayBefore(monthNow,dayNow);
                    if (Judge(yearNow) && monthNow > 2 && month <= 2)
                    {
                        thenextspan++;
                    }
                }
                else
                {
                    int before = theDayBefore(month, day);
                    int after = theDayAfter(monthNow, dayNow);
                    thenextspan = before + after;
                    if (Judge(yearNow) && monthNow <= 2)
                    {
                        thenextspan++;
                    }
                    int thenextyear = yearNow + 1;
                    if (Judge(thenextyear) && month > 2)
                    {
                        thenextyear++;
                    }
                }
            }
            return thenextspan;
        }

        /// <summary>
        /// 根据日期判断返回对应的星座
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string Constellation(int month,int day)
        {
            int[] dayArr = new int[] { 20, 19, 21, 20, 21, 22, 23, 23, 23, 24, 23, 22 };
            String[] constellationArr = new String[] { "摩羯座", "水瓶座", "双鱼座", "白羊座", "金牛座", "双子座", "巨蟹座", "狮子座", "处女座", "天秤座", "天蝎座", "射手座", "摩羯座" };
            string result ="您的星座是" +(day < dayArr[month - 1] ? constellationArr[month - 1] : constellationArr[month])+"。";
            return result;
        }

        /// <summary>
        /// 计算属于不同日期的特殊数字
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int DayNumber(int month, int day)
        {
            int daynumber = month / 10 + month % 10 + day / 10 + day % 10;
            do
            {
                daynumber = daynumber / 10 + daynumber % 10;
            } while (daynumber > 9);
            return daynumber;
        }

        /// <summary>
        /// 计算用户在程序运行当天的幸运数字，利用DayNumber函数计算用户输入日期和程序运行当天的特殊数字，两个特殊数字相减求得
        /// </summary>
        /// <param name="month1"></param>
        /// <param name="day1"></param>
        /// <param name="month2"></param>
        /// <param name="day2"></param>
        /// <returns></returns>
        public static int LuckyNumber(int month1, int day1, int month2, int day2)
        {
            int number1 = DayNumber(month1, day1);
            int number2 = DayNumber(month2, day2);
            int luckynumber;
            if (number1 < number2)
                luckynumber = number2 - number1;
            else luckynumber = number1 - number2;
            return luckynumber;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 对应生日查询的按钮，一旦按下就会运行函数出现一个对话框显示距离下一个生日有多少天和已经出生了多少天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            int datesapn = Span(year, month, day);
            int thenextsapn = theNextBirthday(month, day);
            int time1 = datesapn;
            int time2 = thenextsapn;
            string a = time2.ToString();
            string b = time1.ToString();
            MessageBox.Show("距离您的下一个生日还有" + a + "天\n您已经出生了" + b + "天");
        }

        /// <summary>
        /// 对应星座查询的按钮，一旦按下就会运行函数出现一个对话框显示对应星座
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            string result1 = Constellation(month, day);
            MessageBox.Show(result1);
        }

        /// <summary>
        /// 对应运势查询按钮，一旦按下运行函数得到用户在当天的幸运数字，这个幸运数字通过Class1可以被Form2使用，并出现一个窗体显示对应的运势
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SearchFortune form2 = new SearchFortune();
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            Class1.luckynumber = LuckyNumber( month, day, monthNow, dayNow);
            form2.Show();
        }
    }
}
