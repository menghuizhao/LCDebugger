using System.Collections;
using System.Collections.Generic;

namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Solution697 : SolutionExecuter
    {
        private int[] nums;

        public Solution697(int[] nums)
        {
            this.nums = nums;
        }
        public void Execute()
        {
            int a = FindShortestSubArray(this.nums);
            Console.WriteLine(a);
        }

        public int FindShortestSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            Dictionary<int, int[]> locationMap = new Dictionary<int, int[]>();
            Dictionary<int, int> degreeMap = new Dictionary<int, int>();
            int degree = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!locationMap.ContainsKey(nums[i]))
                {
                    locationMap[nums[i]] = new int[2] { i, i };
                }
                else
                {
                    locationMap[nums[i]][1] = i;
                }
                if (!degreeMap.ContainsKey(nums[i]))
                {
                    degreeMap[nums[i]] = 1;
                }
                else
                {
                    degreeMap[nums[i]] += 1;
                }
                if (degreeMap[nums[i]] >= degree)
                {
                    degree = degreeMap[nums[i]];
                }
            }
            //filter candidates
            var candidates = degreeMap.Where(kv => kv.Value == degree).Select(kv => kv.Key).ToList();
            int max = 0;
            foreach (int candidate in candidates)
            {
                int distance = locationMap[candidate][1] - locationMap[candidate][0] + 1;
                if (distance > max)
                {
                    max = distance;
                }
            }
            return max;
        }
    }
}