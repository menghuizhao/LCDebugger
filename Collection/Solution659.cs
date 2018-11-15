namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Solution659 : SolutionExecuter
    {
        private readonly int[] A;
        public Solution659(int[] A)
        {
            this.A = A;
        }
        public void Execute()
        {
            bool ret = IsPossible(A);
            Console.WriteLine(ret);
        }
        public bool IsPossible(int[] nums)
        {
            if (nums == null || nums.Length < 1) return false;
            List<int> ends = new List<int>();
            bool[] indexMarkAsDelete = new bool[nums.Length];//false by default
                                                             //First round get out all 3-in-a-row
            for (int i = 0; i + 2 < nums.Length; i++)
            {
                if (indexMarkAsDelete[i]) continue;// already taken
                int first = i;
                int? second = IndexOfNextConsecutive(nums, first, indexMarkAsDelete);
                if (!second.HasValue)
                {// not consecutive
                    continue;
                }
                else if (second.Value == nums.Length)
                { // array end, and the following elements are equal (= nums[first])
                    break;
                }
                else
                {
                    int? third = IndexOfNextConsecutive(nums, second.Value, indexMarkAsDelete);
                    if (!third.HasValue)
                    {// not consecutive
                        continue;
                    }
                    else if (third.Value == nums.Length)
                    { // array end, and the following elements are equal (= nums[second])
                        break;
                    }
                    else
                    {//Found 3 consecutive elements
                     //Record this is already used
                        indexMarkAsDelete[first] = true;
                        indexMarkAsDelete[second.Value] = true;
                        indexMarkAsDelete[third.Value] = true;
                        //Record the tail
                        ends.Add(nums[third.Value]);
                    }
                }
            }
            //see if anyone can be the 4th/5th/.. element of existing rows
            for (int i = 0; i < nums.Length; i++)
            {
                if (indexMarkAsDelete[i]) continue;// already taken
                for (int j = 0; j < ends.Count; j++)
                {
                    if (ends[j] + 1 == nums[i])
                    {//can append
                        indexMarkAsDelete[i] = true;
                        ends[j] += 1; // new tail
                        break;
                    }
                }
            }
            //Check if all elements are in use
            for (int i = 0; i < indexMarkAsDelete.Length; i++)
            {
                if (!indexMarkAsDelete[i])
                    return false;
            }
            return true;
        }

        public int? IndexOfNextConsecutive(int[] nums, int start, bool[] indexMarkAsDelete)
        {
            int i = 0;
            for (i = start + 1; i < nums.Length; i++)
            {
                if (indexMarkAsDelete[i]) continue;// already taken
                if (nums[i] - nums[start] > 1)
                { // Not consecutive
                    return null;
                }
                if (nums[i] - nums[start] == 1)
                {
                    return i;
                }
                else
                { // equals
                    continue;
                }
            }
            return nums.Length;// out of index
        }
    }
}
