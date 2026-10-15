public class Solution {
    private int _k;
    private int _x;
    private int _y;
    private int _xmax;
    private int _ymax;
    private int _nbValues;

    private void extractValues(int[][] matrix, int[] result, int val, int valmax, int constVal, bool increase, bool isRow){
        if(increase){
            for(int idx = val; idx <= valmax; idx++)
                result[_k++] = !isRow ? matrix[idx][constVal] : matrix[constVal][idx];
        }
        else{
            for(int idx = val; idx >= valmax; idx--)
                result[_k++] = !isRow ? matrix[idx][constVal] : matrix[constVal][idx];
        }

    }

    private bool stepsRight(int[][] matrix, int[] result){
        extractValues(matrix, result, _x, _xmax, _y++, true, true);
        return _k < _nbValues;
    }

    private bool stepsDown(int[][] matrix, int[] result){
        extractValues(matrix, result, _y, _ymax, _xmax--, true, false);
        return _k < _nbValues;
    }

    private bool stepsLeft(int[][] matrix, int[] result){
        extractValues(matrix, result, _xmax, _x, _ymax--, false, true);
        return _k < _nbValues;
    }

    private bool stepsUp(int[][] matrix, int[] result){
        extractValues(matrix, result, _ymax, _y, _x++, false, false);
        return _k < _nbValues;
    }

    public IList<int> SpiralOrder(int[][] matrix) {
        _nbValues = matrix.Length * matrix[0].Length;
        _k = 0;
        _x = 0;
        _y = 0;
        _xmax = matrix[0].Length-1;
        _ymax = matrix.Length-1;

        int[] result = new int[_nbValues];
        while(true){
            if(!stepsRight(matrix, result))
                break;
            if(!stepsDown(matrix, result))
                break;
            if(!stepsLeft(matrix, result))
                break;
            if(!stepsUp(matrix, result))
                break;
        }
        return result;
    }
}