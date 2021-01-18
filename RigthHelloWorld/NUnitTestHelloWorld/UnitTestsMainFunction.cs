using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using NUnit.Framework;

using HelloWorld;

namespace NUnitTestHelloWorld
{
    class UnitTestsMainFunction
    {
        [Test]
        public void TestMainMethood()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(null);
                Assert.AreEqual(sw.ToString(), "Hello World!\r\n");
            }
        }

        [Test]
        public void TestFalseOutputMainMethood()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(null);
                Assert.IsTrue(sw.ToString().Equals("Hello World!\r\n"));
            }
        }
    }
}
