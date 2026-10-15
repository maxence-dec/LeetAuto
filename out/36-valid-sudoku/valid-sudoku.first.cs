public class Solution {

    private static bool CheckPossibilities(char[][] board, int rowValue, int columnValue){
        for(byte cursor = 0; cursor < 9; cursor++)
        {
            if(cursor != rowValue && board[cursor][columnValue] == board[rowValue][columnValue])
                return false;
            if(cursor != columnValue && board[rowValue][cursor] == board[rowValue][columnValue])
                return false;
        }
        int[] smallRows;
        int[] smallColumns;
        if(rowValue < 3)
            smallRows = new int[3] {0,1,2};
        else if (rowValue < 6)
            smallRows = new int[3] {3,4,5};
        else
            smallRows = new int[3] {6,7,8};
        if(columnValue < 3)
            smallColumns  = new int[3] {0,1,2};
        else if (columnValue < 6)
            smallColumns  = new int[3] {3,4,5};
        else
            smallColumns  = new int[3] {6,7,8};
        foreach(int smallRow in smallRows)
        {
            if(smallRow == rowValue)
                continue;
            foreach(int smallColumn in smallColumns)
            {
                if(smallColumn == columnValue)
                    continue;
                if(board[smallRow][smallColumn] == board[rowValue][columnValue])
                    return false;
            }
        }
        return true;
    }

    public bool IsValidSudoku(char[][] board) {
        for(byte row = 0; row < 9; row++)
        {
            for(byte column = 0; column < 9; column++)
            {
                if(board[row][column] != '.')
                {
                    if(!CheckPossibilities(board, row, column))
                        return false;
                }
            }
        }
        return true;
    }
}