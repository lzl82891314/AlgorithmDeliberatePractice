using System.Collections.Generic;

public partial class Solution {
    public int[] TwoSum(int[] nums, int target) {
        List<int> result = new List<int>();
        for(int i=0; i < nums.Length - 1; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] + nums[j] == target) {
                    result.Add(i);
                    result.Add(j);
                    break;
                }
            }
        }
        return result.ToArray();
    }
}