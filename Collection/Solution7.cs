namespace LCdebugger.Collection
{
    using System;

    public class Solution7 : SolutionExecuter
    {
        private readonly int x;
        public Solution7(int x)
        {
            this.x = x;
        }
        public void Execute()
        {
            int ret = Reverse(x);
            Console.WriteLine(ret);
        }
        public int Reverse(int x)
        {
            if (x == 0) return 0;
            long y = (long)x;
            long reverse = Helper(y);
            //overflow
            if (reverse > Int32.MaxValue || reverse < Int32.MinValue)
            {
                return 0;
            }
            return (int)reverse;
        }
        public long Helper(long x)
        {
            string s = Math.Abs(x).ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            string newStr = new string(arr);
            return x < 0 ? 0 - Int64.Parse(newStr) : Int64.Parse(newStr);
        }
    }
}
