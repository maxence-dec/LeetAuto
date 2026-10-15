impl Solution {

    pub fn max_area(height: Vec<i32>) -> i32 {
        let mut lowerBound = 0;
        let mut upperBound = height.len() - 1;

        let mut maxArea = 0;// std::cmp::min(height[lowerBound], height[upperBound]);

        while lowerBound < upperBound {
            let currentArea = (upperBound - lowerBound) as i32 * std::cmp::min(height[lowerBound], height[upperBound]);
            if(currentArea > maxArea){
                maxArea = currentArea;
            }
            if(height[lowerBound] > height[upperBound]) {
                upperBound -= 1;
            }
            else {
                lowerBound += 1;
            }
        }
        maxArea
    }
}
