using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void JudgeRun()
        {
            bool result = 生日查询与星座运势.Form1.Judge(2016);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void JudgeConstellation()
        {
            string result = 生日查询与星座运势.Form1.Constellation(2, 21);
            Assert.AreEqual("您的星座是双鱼座。", result);
        }

        [TestMethod]
        public void TestFortuneToday()
        {
            string result = 生日查询与星座运势.SearchFortune.FortuneToday(8);
            Assert.AreEqual(result, "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃。");
        }

        [TestMethod]
        public void TesttheDayBefore()
        {
            var daybefore = 生日查询与星座运势.Form1.theDayBefore(2, 20);
            Assert.AreEqual(51, daybefore);
        }

        [TestMethod]
        public void TesttheDayAfter()
        {
            var dayAfter = 生日查询与星座运势.Form1.theDayAfter(12, 20);
            Assert.AreEqual(11, dayAfter);
        }
        [TestMethod]
        public void Testnumber()
        {
            var daynum = 生日查询与星座运势.Form1.DayNumber(8, 19);
            Assert.AreEqual(9, daynum);
        }

        [TestMethod]
        public void Testlucky_num()
        {

            int month1 = 8, day1 = 19, month2 = 8, day2 = 20;
            int result = 生日查询与星座运势.Form1.LuckyNumber(month1, day1, month2, day2);
            Assert.AreEqual(8, result);
        }

        /// <summary>
        /// 测试Span函数，该函数用于计算用户输入的日期到程序运行的当日过了几天，即用户出生了几天
        /// 需要注意的是由于程序调用了运行当天的日期，我们进行测试的时间是2018年8月20日，测试函数的预期结果为904
        /// 如果在其他日期测试，需要更改预期结果，否则测试就会出错
        /// </summary>
        [TestMethod]
        public void Testspan()
        {
            int result = 生日查询与星座运势.Form1.Span(2016,2,28);
            Assert.AreEqual(904, result);
        }

        /// <summary>
        /// 测试theNextBirthday函数，该函数用于计算程序运行的当日到用户用户下一个生日还需要多少天
        /// 需要注意的是由于程序调用了运行当天的日期，我们进行测试的时间是2018年8月20日，测试函数的预期结果为558
        /// 如果在其他日期测试，需要更改预期结果，否则测试就会出错
        /// </summary>
        [TestMethod]
        public void TesttheNextBirthday()
        {
            int result = 生日查询与星座运势.Form1.theNextBirthday(2, 29);
            Assert.AreEqual(558, result);
        }
		[TestMethod]
		public void Testlucky_num()
		{

			int month1 = 8, day1 = 19, month2 = 8, day2 = 20;
			int result = 生日查询与星座运势.Form1.LuckyNumber(month1, day1, month2, day2);
			Assert.AreEqual(8, result);
		}

	}
}
