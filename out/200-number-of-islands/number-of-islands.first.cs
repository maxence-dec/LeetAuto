public class Solution {
    public int NumIslands(char[][] grid) {
        int result = 0, idx = 0;
        int m = grid.Length, n = grid[0].Length;

        while ( idx < m*n){
            int x = idx % m, y = idx / m;
            idx++;
            switch(grid[x][y]){
                case '3':
                    continue;
                case '0':
                    grid[x][y] = '3';
                    break;
                default:
                    result += 1;
                    tagIsland(x, y, grid);
                    break;
            }
        }
        return result;
    }

    private void tagIsland(int x, int y, char[][] grid){
        grid[x][y] = '3';
        if(x+1 < grid.Length){
            if(grid[x+1][y] == '1')
                tagIsland(x+1, y, grid);
            else
                grid[x+1][y] = '3';
        }
        if(x-1 >= 0){
            if(grid[x-1][y] == '1')
                tagIsland(x-1, y, grid);
            else
                grid[x-1][y] = '3';
        }
        if(y+1 < grid[0].Length) {
            if(grid[x][y+1] == '1')
                tagIsland(x, y+1, grid);
            else
                grid[x][y+1] = '3';
        }
        if(y-1 >= 0) {
            if(grid[x][y-1] == '1')
                tagIsland(x, y-1, grid);
            else
                grid[x][y-1] = '3';
        }
    }
}