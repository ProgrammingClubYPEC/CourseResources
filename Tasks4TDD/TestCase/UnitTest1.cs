using BackspacesInString;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            Assert.AreEqual("jf", Solution.CleanString("abjd####jfk#"));
            Assert.AreEqual("gdasda", Solution.CleanString("gfh#jds###d#dsd####dasdaskhj###dhkjs####df##s##d##"));
            Assert.AreEqual("6+yqw8hfklsd-=-f", Solution.CleanString("831####jns###s#cas/*####-5##s##6+yqw87e##hfklsd-=-28##fds##"));
            Assert.AreEqual("jdsfdasns", Solution.CleanString("######831###dhkj####jd#dsfsdnjkf###d####dasns"));
            Assert.AreEqual("", Solution.CleanString(""));
            Assert.AreEqual("", Solution.CleanString("#######"));
            Assert.AreEqual("sa", Solution.CleanString("####gfdsgf##hhs#dg####fjhsd###dbs########afns#######sdanfl##db#####s#a"));
            Assert.AreEqual("hskjdgd", Solution.CleanString("#hskjdf#gd"));
            Assert.AreEqual("hsk48hjjdfgd", Solution.CleanString("hsk48hjjdfgd"));
            Assert.AreEqual("Io4f", Solution.CleanString("fjnwui#NI#(*N#ION#Onfjen################Io4f"));
            Assert.AreEqual("6d87hbaskj$$%$$2332ff", Solution.CleanString("####6d87hbaskjdnf###$$%W#$@#$2332fr#f"));
            Assert.AreEqual("9OooooO", Solution.CleanString("#9#9#9#9o#9#9#9#Oooooo#OOOooO#OO######"));
            Assert.AreEqual("0", Solution.CleanString("0###0###0"));
            Assert.AreEqual("904rfDj*fsf09mfednkmfd;m", Solution.CleanString("904rfn#jlkcn#####Djva2###*(#fsdgfd####fsdg###09849###mfenf##dnjn##kmfd;l#mg03###"));
        }

         

        private static string solve(string s)
        {
            List<char> result = new List<char>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '#' && result.Count > 0) result.RemoveAt(result.Count - 1);
                else if (s[i] != '#') result.Add(s[i]);
            }
            return String.Join("", result);
        }

        [Test]
        public void RandomTest()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; ++i)
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@$%^&*()";
                string test = "";
                int loop = rnd.Next(1, 100);
                for (int j = 0; j < loop; ++j)
                {
                    test += (rnd.Next(0, 2) == 0) ? '#' : chars[rnd.Next(0, chars.Length)];
                }
                string expected = solve(test);
                string actual = Solution.CleanString(test);
                Assert.AreEqual(expected, actual);
            }
        }

    }

    public class Tests4SimpleTime
    {
        [Test]
        public void SimpleTests()
        {
            Assert.AreEqual("23:59", SimpleTimeDifferrence.MaximunTimeInterval(new string[] { "14:51" }));
            Assert.AreEqual("09:10", SimpleTimeDifferrence.MaximunTimeInterval(new string[] { "21:14", "15:34", "14:51", "06:25", "15:30" }));
            Assert.AreEqual("11:40", SimpleTimeDifferrence.MaximunTimeInterval(new string[] { "23:00", "04:22", "18:05", "06:24" }));
        }

        private static string mjk(string[] arr)
        {
            List<int> t = new List<int>();
            foreach (String e in arr)
            {
                int h = Int32.Parse(e.Substring(0, 2)), m = Int32.Parse(e.Substring(3, 2));
                t.Add(h * 60 + m);
            }
            t.Sort();
            int a = t[t.Count - 1] - 24 * 60 + 1, b = 0;
            for (int i = 0; i < t.Count; i++)
            {
                b = Math.Max(t[i] - a, b);
                a = t[i] + 1;
            }
            return ((b / 60 < 10 ? "0" : "") + b / 60 + ":" + (b % 60 < 10 ? "0" : "") + b % 60);
        }

        [Test]
        public void RandomTests()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int len = random.Next(1, 1000);
                string[] res = new string[len];
                for (int j = 0; j < len; ++j)
                {
                    int h = random.Next(0, 24);
                    int m = random.Next(0, 60);
                    string t = "";
                    if (h == 0) 
                        t += "00";
                    else if (h < 10) 
                        t += "0" + h.ToString();
                    else 
                        t += h.ToString();
                    t += ":";

                    if (m == 0) 
                        t += "00";
                    else if (m < 10) 
                        t += "0" + m.ToString();
                    else 
                        t += m.ToString();
                    res[j] = t;
                }
                string exp = mjk(res);
                Assert.AreEqual(exp, SimpleTimeDifferrence.MaximunTimeInterval(res));
            }
        }
    }

    public class Tests4PhoneNumber
    {
        [Test]
        public void SimpleTests()
        {
            Assert.AreEqual("(123) 456-7890", CreatePhoneNumber.ConvertToPhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            Assert.AreEqual("(111) 111-1111", CreatePhoneNumber.ConvertToPhoneNumber(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        private static string Solve(int[] numbers)
        {
            string result = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0) result += "(";
                result += numbers[i];
                if (i == 2) result += ") ";
                if (i == 5) result += "-";
            }
            return result;
        }

        [Test]
        public static void RandomTest([Random(0, 9, 50)] int num)
        {
            List<int> list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++) 
                list.Add(r.Next(10));
            int[] numbers = list.ToArray();
            Assert.AreEqual(Solve(numbers), CreatePhoneNumber.ConvertToPhoneNumber(numbers));
        }



    }
}