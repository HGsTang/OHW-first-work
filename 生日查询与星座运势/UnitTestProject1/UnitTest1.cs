using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesttheDayBefore()
        {
            var daybefore = 生日查询与星座运势.Form1.theDayBefore(2, 20);
            Assert.AreEqual(51,daybefore);
        }
        [TestMethod]
		public void TesttheDayAfter()
		{
			var dayAfter = 生日查询与星座运势.Form1.theDayAfter(12, 20);
			Assert.AreEqual(11, dayAfter);
		}
		[TestMethod]
        public void TestTheDayBetween()
        {
            var result = 生日查询与星座运势.Form1.theDayBetween(6, 18, 8, 19);
            Assert.AreEqual(result, 62);
        }
        [TestMethod]
        public void Testnumber()
        {
            var daynum = 生日查询与星座运势.Form1.DayNumber(8, 19);
            Assert.AreEqual(9, daynum);
        }
        [TestMethod]
        public void TestFortuneToday()
        {
            var result = 生日查询与星座运势.Form2.FortuneToday(8);
            Assert.AreEqual(result, "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃。");
        }
        [TestMethod]
        public void Testlucky_num()
        {

            int month1 = 8, day1 = 19, month2 = 8, day2 = 20;
            int result = 生日查询与星座运势.Form1.LuckyNumber(month1, day1, month2, day2);//幸运数字
            //int result = 生日查询与星座运势.Form1.Span(year, month, day);
            Assert.AreEqual(8, result);
        }
        [TestMethod]
        public void Testspan()
        {
           
            int yearNow = DateTime.Now.Year;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            int year = yearNow-1, month = monthNow, day = dayNow;
            int result = 生日查询与星座运势.Form1.Span(year, month, day);
            Assert.AreEqual(365, result);
        }
    }
}
