using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public int[] CountPairs(int n, int[][] edges, int[] queries)
        {
            var degrees = new int[n];
            var edgeCount = new Dictionary<int, int>();
            const int M = 20005;
            foreach (var edge in edges)
            {
                var a = Math.Min(edge[0], edge[1]) - 1;
                var b = Math.Max(edge[0], edge[1]) - 1;
                degrees[a]++;
                degrees[b]++;
                edgeCount[a * M + b]++;
            }

            var result = new List<int>();
            foreach (var query in queries)
            {
                var sum = 0;
                var right = n - 1;
                for (var left = 0; left < n - 1; left++)
                {
                    if (left >= right) sum += n - left - 1;
                    else
                    {
                        while (left < right && degrees[left] + degrees[right] > query) right--;
                        sum += n - right - 1;
                    }
                }
                foreach (var edgeItem in edgeCount)
                {
                    var a = edgeItem.Key / M;
                    var b = edgeItem.Key % M;
                    if (degrees[a] + degrees[b] > query && degrees[a] + degrees[b] - edgeItem.Value <= query) 
                    {
                        sum--;
                    }
                }
                result.Add(sum);
            }
            return result.ToArray();
        }
    }
}
