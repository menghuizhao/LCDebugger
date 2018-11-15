namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Solution354 : SolutionExecuter
    {
        private int[,] envelopes { get; set; }

        public Solution354(int[,] envelopes)
        {
            this.envelopes = envelopes;
        }
        public void Execute()
        {
            int a = MaxEnvelopes(this.envelopes);
            Console.WriteLine(a);
        }

        public class Envelope
        {
            public int w { get; set; }
            public int h { get; set; }
        }

        public class EnvelopeComparer : IComparer<Envelope>
        {
            public int Compare(Envelope x, Envelope y)
            {
                if (x.w < y.w) return -1;
                if (x.w > y.w) return 1;
                if (x.h < y.h) return 1;
                if (x.h > y.h) return -1;
                return 0;
            }
        }
        public int MaxEnvelopes(int[,] envelopes)
        {
            if (envelopes == null || envelopes.Length == 0) return 0;
            List<Envelope> envList = new List<Envelope>();
            int numOfEnvelopes = envelopes.Length / 2;
            for (int i = 0; i < numOfEnvelopes; i++)
            {
                envList.Add(new Envelope
                {
                    w = envelopes[i, 0],
                    h = envelopes[i, 1]
                });
            }

            Envelope[] envArray = envList.ToArray();
            Array.Sort(envArray, new EnvelopeComparer());
            int[] heightsArr = envArray.Select(k => k.h).ToArray();
            return LengthOfLIS(heightsArr);

        }
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            // dp: dp[i] = LengthofLIS ending at index I
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
            }
            int maxDp = dp[0];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        if (dp[i] > maxDp)
                        {
                            maxDp = dp[i];
                        }
                    }
                }
            }
            return maxDp;
        }
    }
}
