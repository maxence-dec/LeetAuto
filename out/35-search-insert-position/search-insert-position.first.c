int searchInsert(int* nums, int numsSize, int target) {
    if(nums[0] > target) return 0;
    if(nums[numsSize-1] < target) return numsSize;

    int marge = 2;
    int pointer = numsSize/marge;
    while(nums[pointer] != target){
        marge += 2;
        if(nums[pointer] > target) pointer -= numsSize/marge == 0 ? 1 : numsSize/marge == 0;
        else pointer += numsSize/marge == 0 ? 1 : numsSize/marge == 0;

        if(nums[pointer] < target && nums[pointer+1] > target)
            return pointer +1;
    }
    return pointer;
}