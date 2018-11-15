namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution327 : SolutionExecuter
    {
        private readonly int[] nums;
        private readonly int lower;
        private readonly int upper;

        public Solution327(int[] nums, int lower, int upper)
        {
            this.nums = nums;
            this.lower = lower;
            this.upper = upper;
        }
        public void Execute()
        {
            int ret = CountRangeSum(nums, lower, upper);
            Console.WriteLine(ret);
        }



        public static int ans { get; set; }
        public static int wlower { get; set; }
        public static int wupper { get; set; }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            if (nums == null || nums.Length < 1) return 0;
            wlower = lower;
            wupper = upper;

            int[] sums = new int[nums.Length];

            // Load sums
            int accu = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                accu += nums[i];
                sums[i] = accu;
            }
            // count of range
            ans = 0;
            mergeSort(sums.ToList());
            return ans;
        }
        public List<int> mergeSort(List<int> arr)
        {
            if (arr?.Count == 1) return arr;
            int mid = arr.Count / 2;
            List<int> leftArr = arr.GetRange(0, mid);
            List<int> rightArr = arr.GetRange(mid, arr.Count - mid);
            return merge(mergeSort(new List<int>(leftArr)), mergeSort(new List<int>(rightArr)));
        }
        public List<int> merge(List<int> arr1, List<int> arr2)
        {
            ans += getAns(arr1, arr2);
            var tmp = new List<int>();

            while (arr1.Count > 0 && arr2.Count > 0)
            {
                if (arr1[0] < arr2[0]) {
                    tmp.Add(arr1[0]);
                    arr1.RemoveAt(0);
                }
                else
                {
                    tmp.Add(arr2[0]);
                    arr2.RemoveAt(0);
                }
            }
            tmp.AddRange(arr1);
            tmp.AddRange(arr2);
            return tmp;
        }
        public int getAns(List<int> l1, List<int> l2)
        {
            var sum = 0;
            var len1 = l1.Count;
            var len2 = l2.Count;

            var start = 0;
            var end = 0;

            for (var i = 0; i < len2; i++)
            {

                // to get start
                while (start < l1.Count && l2[i] - l1[start] >= wlower)
                {
                    start++;
                }

                // to get end
                while (end < l1.Count && l2[i] - l1[end] > wupper)
                {
                    end++;
                }

                sum += start - end;
            }

            return sum;
        }
    }
}
