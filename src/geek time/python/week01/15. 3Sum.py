class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        if nums is None or len(nums) == 0:
            return nums
        sorted(nums)
        result = []
        for k in range(0, len(nums)):
            if nums[k] > 0:
                break
            if k > 0 and nums[k] == nums[k - 1]:
                continue
            i = k + 1
            j = len(nums) - 1
            while i < j:
                sum = nums[k] + nums[i] + nums[j]
                if sum < 0:
                    while i < j and nums[i] == nums[i + 1]:
                        i += 1
                elif sum > 0:
                    while i < j and nums[j] == nums[j - 1]:
                        j -= 1
                else:
                    result.append([nums[k], nums[i], nums[j]])
                    while i < j and nums[i] == nums[i + 1]:
                        i += 1
                    while i < j and nums[j] == nums[j - 1]:
                        j -= 1
        return result