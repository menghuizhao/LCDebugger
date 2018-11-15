namespace LCdebugger.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution483 : SolutionExecuter
    {
        private readonly string s;
        private readonly string p;
        public Solution483(string s, string p)
        {
            this.s = s;
            this.p = p;
        }
        public void Execute()
        {
            IList<int> ret = FindAnagrams(s, p);
            Console.WriteLine(ret);
        }
        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) || s.Length < p.Length) return result;
            // make dictionary for p
            Dictionary<char, int> dictP = DictP(p);
            HashSet<char> setP = SetP(p);
            var P = dictP.ToDictionary(kv => kv.Key, kv => kv.Value);
            int left = 0, right = 0;
            //move right
            while (right < s.Length)
            {
                if (!setP.Contains(s[right]))
                {
                    P = dictP.ToDictionary(kv => kv.Key, kv => kv.Value);
                    right++;
                    left = right;
                    continue;
                }
                Decrease(P, s[right]);
                if (right - left + 1 == p.Length)
                {
                    if (P.Count == 0)
                    {
                        result.Add(left);//record
                    }
                    Increase(P, s[left]);
                    left++;
                }
                if (P.Count == 0)
                {
                    result.Add(left);//record
                    Increase(P, s[left]);
                    left++;
                }
                right++;
            }
            return result;
        }
        private void Increase(Dictionary<char, int> d, char c)
        {
            if (!d.ContainsKey(c))
            {
                d[c] = 1;
            }
            else
            {
                d[c]++;
                if (d[c] == 0)
                {
                    d.Remove(c);
                }
            }
        }
        private void Decrease(Dictionary<char, int> d, char c)
        {
            if (!d.ContainsKey(c))
            {
                d[c] = -1;
            }
            else
            {
                d[c]--;
                if (d[c] == 0)
                {
                    d.Remove(c);
                }
            }
        }
        private Dictionary<char, int> DictP(string p)
        {
            var dictP = new Dictionary<char, int>();
            for (int i = 0; i < p.Length; i++)
            {
                if (!dictP.ContainsKey(p[i]))
                {
                    dictP[p[i]] = 1;
                }
                else
                {
                    dictP[p[i]]++;
                }
            }
            return dictP;
        }
        private HashSet<char> SetP(string p)
        {
            var setP = new HashSet<char>();
            for (int i = 0; i < p.Length; i++)
            {
                setP.Add(p[i]);
            }
            return setP;
        }
    }
}
