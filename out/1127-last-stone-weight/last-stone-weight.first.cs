public class Solution {
    public int LastStoneWeight(int[] stones) {
        if(stones.Length == 1)
            return stones[0];
        else if(stones.Length == 0)
            return 0;
        int x, y;
        int[] xArr, yArr;
        (x, xArr) = removeFirstMaxValue(stones);
        (y, yArr) = removeFirstMaxValue(xArr);
        if(x!=y)
            yArr = [.. yArr, Math.Abs(x-y)];
        return LastStoneWeight(yArr);
    }
    private (int, int[]) removeFirstMaxValue(int[] arr){
        var result = arr.Max();
        var resultIdx = arr.IndexOf(result);
        int[] resultArr = new int[arr.Length - 1];
        int a = 0;
        for(int i = 0; i < arr.Length; i++){
            if(i != resultIdx)
                resultArr[a++]=arr[i];
        }
        return (result, resultArr);
    }
}