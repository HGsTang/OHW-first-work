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

        public static int theDayBetween(int month1,int day1,int month2,int day2)
        {
            int thedaybetween = 0;
            for (int i = month1; i < month2-1; i++)
            {
                thedaybetween += months[i];
            }
            if (month1 != month2)
            {
                thedaybetween += day2;
                int number = month1 - 1;
                thedaybetween = thedaybetween + months[number] - day1;
            }
            else
                thedaybetween = day2 - day1;
            return thedaybetween;
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
                int between = theDayBetween(month, day, monthNow, dayNow);
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
                    thenextspan = theDayBetween(monthNow, dayNow, 2, 28);
                    thenextspan++;
                }
                else
                {
                    int after = theDayAfter(monthNow, dayNow);
                    if (month == 2 && day == 29)
                    {
                        after = theDayAfter(2,28);
                        after++;
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
                    thenextspan = theDayBetween(monthNow, dayNow, month, day);
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
            Class1.year = dateTimePicker1.Value.Year;
            Class1.month = dateTimePicker1.Value.Month;
            Class1.day = dateTimePicker1.Value.Day;
            int datesapn = Span(Class1.year, Class1.month, Class1.day);
            int thenextsapn = theNextBirthday(Class1.month, Class1.day);
            int time1 = datesapn;
            int time2 = thenextsapn;
            string a = time2.ToString();
            string b = time1.ToString();
            MessageBox.Show("距离您的下一个生日还有" + a + "天\n您已经出生了" + b + "天");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.year = dateTimePicker1.Value.Year;
            Class1.month = dateTimePicker1.Value.Month;
            Class1.day = dateTimePicker1.Value.Day;
            string result1 = Constellation(Class1.month,Class1.day);
            MessageBox.Show(result1);
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Class1.month = dateTimePicker1.Value.Month;
            Class1.day = dateTimePicker1.Value.Day;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            Class1.luckynumber = LuckyNumber(Class1.month, Class1.day, monthNow, dayNow);
            form2.Show();
        }
    }
}
