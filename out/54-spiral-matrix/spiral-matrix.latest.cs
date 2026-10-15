public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        int left = 0, top = 0, right = matrix[0].Length-1, bottom = matrix.Length-1;
        int[]  _result = new int[matrix.Length * matrix[0].Length];
        int _k = 0;
        while(_k != matrix.Length * matrix[0].Length){
            for(int idx = left; idx <= right; idx++)
                _result[_k++] = matrix[top][idx];
            top++;

            for(int idx = top; idx <= bottom; idx++)
                _result[_k++] = matrix[idx][right];
            right--;
            if(_k == matrix.Length * matrix[0].Length)
                break;
            
            for(int idx = right; idx >= left; idx--)
                _result[_k++] = matrix[bottom][idx];
            bottom--;

            for(int idx = bottom; idx >= top; idx--)
                _result[_k++] = matrix[idx][left];
            left++;
        }
        return _result;
    }
}