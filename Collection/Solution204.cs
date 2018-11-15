using System.Collections;
using System.Collections.Generic;

namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Solution204 : SolutionExecuter
    {
        private int n;

        public Solution204(int n)
        {
            this.n = n;
        }
        public void Execute()
        {
            int a = CountPrimes(this.n);
            Console.WriteLine(a);
        }

        public int CountPrimes(int n)
        {
            if (n <= 2) return 0;
            int count = n - 1;
            bool[] isPrime = Enumerable.Repeat(true, n + 1).ToArray();
            isPrime[1] = false;
            count--;
            for (int i = 2; i < n + 1; i++)
            {
                if (i * i >= n)
                {
                    break;
                }
                if (isPrime[i])
                {
                    int j = i;
                    while (i * j < n)
                    {
                        isPrime[i * j] = false;
                        count--;
                        j++;
                    }
                }
            }
            return count;
        }
    }
}