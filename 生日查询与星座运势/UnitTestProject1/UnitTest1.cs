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
            var result = 生日查询与星座运势.Form1.Judge(2016);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void JudgeConstellation()
        {
            var result = 生日查询与星座运势.Form1.Constellation(2, 21);
            Assert.AreEqual("您的星座是双鱼座。", result);
        }
        [TestMethod]
        public void TestFortuneToday()
        {
            var result = 生日查询与星座运势.SearchFortune.FortuneToday(8);
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
            int result = 生日查询与星座运势.Form1.LuckyNumber(month1, day1, month2, day2);//幸运数字
            //int result = 生日查询与星座运势.Form1.Span(year, month, day);
            Assert.AreEqual(8, result);
        }
        [TestMethod]
        public void Testspan()
        {
            int result = 生日查询与星座运势.Form1.Span(2016,2,28);
            Assert.AreEqual(904, result);
        }
        [TestMethod]
        public void TesttheNextBirthday()
        {
            int result = 生日查询与星座运势.Form1.theNextBirthday(2, 29);
            Assert.AreEqual(558, result);
        }

    }
}
