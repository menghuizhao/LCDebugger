namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Solution738 : SolutionExecuter
    {
        private readonly int N;
        public Solution738(int N)
        {
            this.N = N;
        }
        public void Execute()
        {
            int ret = MonotoneIncreasingDigits(N);
            Console.WriteLine(ret);
        }
        public int MonotoneIncreasingDigits(int N)
        {
            if (N < 10) return 0;
            int length = N.ToString().Length;
            int k = 1;
            bool nochange = false;
            for (int i = 1; i + 1 <= length; i++)
            {
                int a = NthFromLeft(i, N);
                int b = NthFromLeft(i + 1, N);
                if (a < b)
                {
                    k = i + 1;
                    if (i + 1 == length)
                    {
                        nochange = true; // no need to change
                    }
                }
                else if (a == b) {
                }
                else if (a > b)
                {
                    break;
                }
            }
            if (nochange) return N;
            string strN = N.ToString();
            char[] arr = strN.ToCharArray();
            int kDigit = arr[k - 1] - '0';
            arr[k - 1] = (char)('0' + kDigit - 1);
            for (int i = k; i < arr.Length; i++)
            {
                arr[i] = '9';
            }
            string newInt = new string(arr);
            return Int32.Parse(newInt);
        }

        //nth digit from left
        public int NthFromLeft(int n, int num)
        {
            string s = num.ToString();
            return (int)(s[n - 1] - '0');
        }
    }
}
