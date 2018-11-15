using System.Collections;
using System.Collections.Generic;

namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Solution12 : SolutionExecuter
    {
        private int num;

        public Solution12(int num)
        {
            this.num = num;
        }
        public void Execute()
        {
            string a = IntToRoman(this.num);
            Console.WriteLine(a);
        }

        public string IntToRoman(int num)
        {
            string[] symbol = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] value = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; num != 0; i++)
            {
                while (num >= value[i])
                {
                    num -= value[i];
                    sb.Append(symbol[i]);
                }
            }
            return sb.ToString();
        }
    }
}