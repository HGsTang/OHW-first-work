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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        public static int Span(int year1, int month1, int day1)
        {
            int datespan = 0;
            int yearNow = DateTime.Now.Year;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            for(int yearspan=year1+1;yearspan<yearNow;yearspan++)
            {
                if ((yearspan / 4 == 0 && yearspan / 100 != 0)||(yearspan/400==0))
                {
                    datespan += 366;
                }
                else
                {
                    datespan += 365;
                }
            } 
            int[] months = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (year1 != yearNow)
            {
                if ((year1 / 4 == 0 && year1 / 100 != 0) || (year1 / 400 == 0))
                {
                    if (month1 <= 2)
                        datespan = datespan + 1;
                }
                for (int i = 0; i < monthNow - 1; i++)
                {
                    datespan += months[i];
                }
                if ((yearNow / 4 == 0 && yearNow / 100 != 0) || (yearNow / 400 == 0))
                {
                    if (monthNow > 2)
                        datespan++;
                }
                for (int j = month1; j < 12; j++)
                {
                    datespan += months[j];
                }
                
                int nub = month1 - 1;
                datespan = datespan + dayNow + months[nub] - day1;
            }
            else
            {
                if ((yearNow / 4 == 0 && yearNow / 100 != 0) || (yearNow / 400 == 0))
                {
                    if (monthNow > 2 && month1 <= 2)
                        datespan++;
                }
                if(month1==monthNow)
                {
                    datespan = datespan + dayNow - day1;
                }
                else
                {
                    for (int i = month1; i < monthNow - 1; i++)
                    {
                        datespan += months[i];
                    }
                    int nub = month1 - 1;
                    datespan = datespan + dayNow + months[nub] - day1;
                }
            }
            return datespan;
        }

        public static int theNextBirthday(int year2, int month2, int day2)
        {
            int yearNow = DateTime.Now.Year;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            int thenextspan = 0;
            int[] months = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int i = 0;
            do
            {
                thenextspan += months[i];
                i++;
            } while (i < (month2 - 1));
            if ((year2 / 4 == 0 && year2 / 100 != 0 )|| year2/400==0)
            {
                if(month2>2)
                    thenextspan++;
            }
            thenextspan += day2;
            int j = monthNow;
            do
            {
                thenextspan += months[j];
                j++;
            } while (j <= 11&&j>monthNow);
            if ((yearNow / 4 == 0 && yearNow / 100 != 0)||yearNow/400==0)
            {
                if(monthNow==2||monthNow==1)
                    thenextspan++;
            }
            thenextspan = months[monthNow] - dayNow;
            return thenextspan;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.year = dateTimePicker1.Value.Year;
            Class1.month = dateTimePicker1.Value.Month;
            Class1.day = dateTimePicker1.Value.Day;
            int datesapn = Span(Class1.year, Class1.month, Class1.day);
            int thenextsapn = theNextBirthday(Class1.year, Class1.month, Class1.day);
            Class1.time1 = datesapn;
            Class1.time2 = thenextsapn;
            string a = Class1.time2.ToString();
            string b = Class1.time1.ToString();
            MessageBox.Show("距离您的下一个生日还有" + a + "天\n您已经出生了" + b + "天");
        }

        public static string Constellation(int month3,int day3)
        {
            string result;
            if(month3==1)
            {
                if (day3 >= 20)
                    result = "您的星座是水瓶座。";
                else
                    result = "您的星座是摩羯座。";
            }
            else if (month3 == 2)
            {
                if (day3 >= 19)
                    result = "您的星座是双鱼座。";
                else
                    result = "您的星座是水瓶座。";
            }
            else if (month3 == 3)
            {
                if (day3 >= 21)
                    result = "您的星座是白羊座。";
                else
                    result = "您的星座是双鱼座。";
            }
            else if (month3 == 4)
            {
                if (day3 >= 20)
                    result = "您的星座是金牛座。";
                else
                    result = "您的星座是双鱼座。";
            }
            else if (month3 == 5)
            {
                if (day3 >= 21)
                    result = "您的星座是双子座。";
                else
                    result = "您的星座是金牛座。";
            }
            else if (month3 == 6)
            {
                if (day3 >= 22)
                    result = "您的星座是巨蟹座。";
                else
                    result = "您的星座是双子座。";
            }
            else if (month3 == 7)
            {
                if (day3 >= 23)
                    result = "您的星座是狮子座。";
                else
                    result = "您的星座是巨蟹座。";
            }
            else if (month3 == 8)
            {
                if (day3 >= 23)
                    result = "您的星座是处女座。";
                else
                    result = "您的星座是狮子座。";
            }
            else if (month3 == 9)
            {
                if (day3 >= 23)
                    result = "您的星座是天秤座。";
                else
                    result = "您的星座是处女座。";
            }
            else if (month3 == 10)
            {
                if (day3 >= 24)
                    result = "您的星座是天蝎座。";
                else
                    result = "您的星座是天秤座。";
            }
            else if (month3 == 11)
            {
                if (day3 >= 23)
                    result = "您的星座是射手座。";
                else
                    result = "您的星座是天蝎座。";
            }
            else
            {
                if (day3 >= 22)
                    result = "您的星座是射手座。";
                else
                    result = "您的星座是摩羯座。";
            }
            return result;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.month = dateTimePicker1.Value.Month;
            Class1.day = dateTimePicker1.Value.Day;
            string result1 = Constellation(Class1.month,Class1.day);
            MessageBox.Show(result1);
        }
    }
}
