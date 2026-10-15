impl Solution {
    pub fn running_sum(nums: Vec<i32>) -> Vec<i32> {
        let mut result: Vec<i32> = nums.clone();
        for n in 1..nums.len() {
            result[n] += result[n-1];
        }
        result
    }
}