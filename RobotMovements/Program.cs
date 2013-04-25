using System.IO;
using System.Collections.Generic;
using System;

public class Program
{
    static void Main(string[] args)
    {
        int colMax = 4;
        int rowMax = 4;
        int[,] usedGrid = new int[rowMax,colMax];
        int totalPaths = 0;

        WalkGrid(0, 0, ref totalPaths, ref usedGrid);
        Console.WriteLine(totalPaths);
    }

    public static void WalkGrid(int startRow, int startCol, ref int totalPaths, ref int[,] usedGrid)
    {
        var rowIndexLimit = usedGrid.GetLength(0) - 1;
        var columnIndexLimit = usedGrid.GetLength(1) - 1;

        if (startRow == rowIndexLimit && startCol == columnIndexLimit) 
        {
            totalPaths++;
            return;
        }

        usedGrid[startRow, startCol] = 1;

        //right
        if (startCol + 1 <= columnIndexLimit && usedGrid[startRow, startCol + 1] == 0)
        {
            WalkGrid(startRow, startCol + 1, ref totalPaths, ref usedGrid);
        }

        //down
        if (startRow + 1 <= rowIndexLimit && usedGrid[startRow + 1, startCol] == 0)
        {
            WalkGrid(startRow + 1, startCol, ref totalPaths, ref usedGrid);
        }
        
        //up
        if (startRow - 1 >= 0 && usedGrid[startRow - 1, startCol] == 0)
        {
            WalkGrid(startRow - 1, startCol, ref totalPaths, ref usedGrid);
        }
        
        //left
        if (startCol - 1 >= 0 && usedGrid[startRow, startCol - 1] == 0)
        {
            WalkGrid(startRow, startCol - 1, ref totalPaths, ref usedGrid);
        }
        
        usedGrid[startRow, startCol] = 0;
    }
}