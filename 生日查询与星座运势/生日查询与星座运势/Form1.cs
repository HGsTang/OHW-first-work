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

        public static int[] months = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

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

        public static bool Judge(int year)
        {
            bool judge=false;
            if((year%4==0&&year%100!=0)||(year%400==0))
            {
                judge = true;
            }
            return judge;
        }
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

        public static string Constellation(int month,int day)
        {
            int[] dayArr = new int[] { 20, 19, 21, 20, 21, 22, 23, 23, 23, 24, 23, 22 };
            String[] constellationArr = new String[] { "摩羯座", "水瓶座", "双鱼座", "白羊座", "金牛座", "双子座", "巨蟹座", "狮子座", "处女座", "天秤座", "天蝎座", "射手座", "摩羯座" };
            string result ="您的星座是" +(day < dayArr[month - 1] ? constellationArr[month - 1] : constellationArr[month])+"。";
            return result;
        }

        public static int DayNumber(int month, int day)
        {
            int daynumber = month / 10 + month % 10 + day / 10 + day % 10;
            do
            {
                daynumber = daynumber / 10 + daynumber % 10;
            } while (daynumber > 9);
            return daynumber;
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            string result1 = Constellation(month, day);
            MessageBox.Show(result1);
        }

        
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
