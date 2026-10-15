public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
    int[] result = new int[2];

    int lower = 0;
    int upper = numbers.Count() - 1;
    int sum = numbers[lower] + numbers[upper];
    while(sum != target){
        if(sum > target)
            upper--;
        else
            lower++;
        sum = numbers[lower] + numbers[upper];
    }
    result[0] = lower+1;
    result[1] = upper+1;
    return result;
    }
}