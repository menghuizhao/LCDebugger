using System.Collections;
using System.Collections.Generic;

namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Solution125 : SolutionExecuter
    {
        private string s;

        public Solution125(string s)
        {
            this.s = s;
        }
        public void Execute()
        {
            bool a = IsPalindrome(this.s);
            Console.WriteLine(a);
        }

        public bool IsPalindrome(string s)
        {
            if (s == null) return false;
            if (string.Equals(s, string.Empty)) return true;
            char[] arr = s.ToLower().ToCharArray();
            arr = Array.FindAll<char>(arr, c => char.IsLetter(c));
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - 1 - i]) return false;
            }
            return true;
        }
    }
}