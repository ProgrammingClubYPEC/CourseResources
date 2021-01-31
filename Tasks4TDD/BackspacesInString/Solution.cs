using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackspacesInString
{
    public class Solution
    {
        public static string CleanString(string str)
        {
            string cleaned = "";

            foreach (char c in str)
            {
                if (!c.Equals('#'))
                    cleaned += c;
                else if (cleaned.Length > 0)
                    cleaned = cleaned.Remove(cleaned.Length - 1);
            }

            return cleaned;
        }
    }
}
