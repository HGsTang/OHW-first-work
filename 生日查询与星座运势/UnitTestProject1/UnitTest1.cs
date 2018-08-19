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
        public void TesttheDayafter()
        {
            var dayafter = 生日查询与星座运势.Form1.theDayAfter(10, 20);
            Assert.AreEqual(72, dayafter);
        }
        [TestMethod]
        public void Testnumber()
        {
            var daynum = 生日查询与星座运势.Form1.DayNumber(8, 19);
            Assert.AreEqual(9, daynum);
        }
    }
}
