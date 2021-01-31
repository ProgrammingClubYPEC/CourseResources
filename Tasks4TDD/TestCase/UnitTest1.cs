using BackspacesInString;
using NUnit.Framework;

namespace TestCase
{
    public class Tests4Backspaces
    {
        [Test]
        public void SimpleTests()
        {
            Assert.AreEqual("ac", Solution.CleanString("abc#d##c"));
            Assert.AreEqual("", Solution.CleanString("abc##d######"));
        }

        [Test]
        public void ExtremeTests()
        {
            Assert.AreEqual("", Solution.CleanString("#######"));
            Assert.AreEqual("", Solution.CleanString(""));
        }
    }
}