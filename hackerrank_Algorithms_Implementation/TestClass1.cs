using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank_Algorithms_Implementation
{
    [TestFixture, Description("Simple Tests")]
    public class TestClass1
    {
        [TestCase(1918, "26.09.1918")]
        [TestCase(2017, "13.09.2017")]
        public void TestDayOfTheProggrammer(int y,string exp)
        {
            // TODO: Add your test code here
            Assert.AreEqual(exp, DayoftheProgrammer.solve(y));
        }
    }
}
