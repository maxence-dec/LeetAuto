public class Solution {
    public int NumIslands(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int result = 0;

        for (int row = 0; row < m; row++) {
            for (int col = 0; col < n; col++) {
                if (grid[row][col] == '1') {
                    result++;
                    FloodFill(grid, row, col, m, n);
                }
            }
        }
        return result;
    }

    private void FloodFill(char[][] grid, int startRow, int startCol, int m, int n) {
        var stack = new Stack<(int row, int col)>();

        void TryVisit(int row, int col) {
            if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] != '1') return;
            grid[row][col] = '0';
            stack.Push((row, col));
        }

        stack.Push((startRow, startCol));
        grid[startRow][startCol] = '0';

        while (stack.Count > 0) {
            var (row, col) = stack.Pop();
            TryVisit(row + 1, col);
            TryVisit(row - 1, col);
            TryVisit(row, col + 1);
            TryVisit(row, col - 1);
        }
    }
}