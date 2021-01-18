using NUnit.Framework;

using HelloWorld;
using System.IO;
using System;

namespace NUnitTestHelloWorld
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMainMethood()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(null);
                Assert.AreEqual(sw.ToString(), "Hello world!\r\n");
            }
        }

        [Test]
        public void TestFalseOutputMainMethood()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(null);
                Assert.IsTrue(sw.ToString().Equals("Hello world!\r\n"));
            }
        }
    }
}