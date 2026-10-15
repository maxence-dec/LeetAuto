impl Solution {
    fn local_max_area(
        height: &Vec<i32>,
        sizeToIndex: &std::collections::HashMap<i32, usize>,
        upperBound: usize,
        upperValue: i32,
    ) -> i32 {
        let mut result = 0;
        for (lowerValue, lowerBound) in sizeToIndex.into_iter() {
            let currentArea =
                (upperBound - lowerBound) as i32 * std::cmp::min(height[*lowerBound], upperValue);
            if (currentArea > result) {
                result = currentArea;
            }
        }
        result as i32
    }

    pub fn max_area(height: Vec<i32>) -> i32 {
        let mut sizeToIndex: std::collections::HashMap<i32, usize> =
            std::collections::HashMap::new();
        sizeToIndex.entry(height[0]).or_insert(0);
        let mut maxArea = std::cmp::min(height[0], height[1]);

        for upperBound in 0..height.len() as usize {
            let upperValue = height[upperBound];
            let max_key = sizeToIndex.keys().copied().max();
            if(upperValue > max_key.expect("REASON")){
                sizeToIndex.entry(upperValue).or_insert(upperBound);
            }
            if (upperBound + 1 == height.len() || upperValue > height[upperBound + 1]) {
                let localMaxArea =
                    Self::local_max_area(&height, &sizeToIndex, upperBound, upperValue);
                if (localMaxArea > maxArea) {
                    maxArea = localMaxArea;
                }
            }
        }
        maxArea
    }
}
