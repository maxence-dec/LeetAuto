impl Solution {
    pub fn running_sum(nums: Vec<i32>) -> Vec<i32> {
        let mut result: Vec<i32> = Vec::new();
        result.push(nums[0]);
        for n in 1..nums.len() {
            result.push(result[n-1] + nums[n]);
        }
        result
    }
}