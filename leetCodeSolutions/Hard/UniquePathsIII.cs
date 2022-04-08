using System.Linq;
namespace leetCodeSolutions.Hard
{
    public partial class Solution
    {
        static int filasX;
        static int columnasY;
        static int nonObstacles = 0;
        /// <summary>
        /// https://leetcode.com/problems/unique-paths-iii
        /// <br/>On a 2-dimensional grid, there are 4 types of squares:
        /// <br/>1 represents the starting square.There is exactly one starting square.
        /// <br/>2 represents the ending square.  There is exactly one ending square.
        /// <br/>0 represents empty squares we can walk over.
        /// <br/>-1 represents obstacles that we cannot walk over.
        /// <br/>Return the number of 4-directional walks from the starting square to the ending square, that walk over every non-obstacle square exactly once.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int UniquePathsIII(int[][] grid)
        {
            Point inicio = new(0, 0);
            filasX = grid.Length;
            columnasY = grid[0].Length;
            nonObstacles = 0;
            for (int x = 0; x < filasX; x++)
            {
                for (int y = 0; y < columnasY; y++)
                {
                    // gridA[x][y] = grid[x][y];
                    if (grid[x][y] == 1)
                    {
                        inicio.x = x; //acá tengo el inicio
                        inicio.y = y;
                    }
                    else if (grid[x][y] == 0)
                    {
                        nonObstacles++;
                    }
                }
            }
            List<Point> start = new(); // { inicio };            
            return inicio.Mover(ref start, ref grid);
        }
        public class Point
        {
            public int Mover(ref List<Point> stack, ref int[][] gridA)
            {
                if (y == columnasY)
                {
                    //   System.Diagnostics.Debug.WriteLine($"\t< tope derecho ({x},{y})");
                    return 0;
                }//no se puede avanzar finalizar ruta
                else if (x == filasX)
                {
                    //  System.Diagnostics.Debug.WriteLine($"\t^ tope abajo ({x},{y})");
                    return 0;
                }//no se puede avanzar fin de ruta
                else if (y < 0)
                {
                    //  System.Diagnostics.Debug.WriteLine($"\t< tope izquierdo ({x},{y})");
                    return 0;
                }//no se puede avanzar finalizar ruta
                else if (x < 0)
                {
                    //      System.Diagnostics.Debug.WriteLine($"\tv tope arriba ({x},{y})");
                    return 0;
                }//no se puede avanzar fin de ruta
                else if (gridA[x][y] == 2)
                {
                    if ((stack.Count - 1) == nonObstacles)
                    {
                        // System.Diagnostics.Debug.WriteLine("OK");
                        foreach (var s in stack)
                        {
                            System.Diagnostics.Debug.Write($"({s.x},{s.y}) ");
                        }
                        System.Diagnostics.Debug.WriteLine("");
                        return 1;
                    }
                    else
                    {
                        //  System.Diagnostics.Debug.WriteLine($"\tincompleta");
                        return 0;
                    }
                }
                else if (gridA[x][y] == -1)
                {
                    //System.Diagnostics.Debug.WriteLine($"\tobstaculo ({x},{y})");
                    return 0;
                }
                else
                {
                    //   System.Diagnostics.Debug.Write($"({x},{y})");
                    stack.Add(this);
                    int j = 0, k = 0, l = 0, m = 0;
                    var jr = new Point(x + 1, y);
                    if (!stack.Any(n => n.x == jr.x && n.y == jr.y))
                    {
                        j = jr.Mover(ref stack, ref gridA); //abajo.
                    }
                    else
                    {
                        // System.Diagnostics.Debug.WriteLine($"\tno puedo volver abajo ({x},{y})");
                    }
                    var lr = new Point(x, y + 1);
                    if (!stack.Any(n => n.x == lr.x && n.y == lr.y))
                    {
                        l = lr.Mover(ref stack, ref gridA); //derecha
                    }
                    else
                    {
                        //  System.Diagnostics.Debug.WriteLine($"\tno puedo volver a la derecha ({x},{y})");
                    }
                    var kr = new Point(x - 1, y);
                    if (!stack.Any(n => n.x == kr.x && n.y == kr.y))
                    {
                        k = kr.Mover(ref stack, ref gridA); //arriba
                    }
                    else
                    {
                        // System.Diagnostics.Debug.WriteLine($"\tno puedo volver arriba ({x},{y})");
                    }
                    var mr = new Point(x, y - 1);
                    if (!stack.Any(n => n.x == mr.x && n.y == mr.y))
                    {
                        m = mr.Mover(ref stack, ref gridA); //izquierda
                    }
                    else
                    {
                        //  System.Diagnostics.Debug.WriteLine($"\tno puedo volver izquierda ({x},{y})");
                    }
                    var result = j + k + l + m;
                    stack.Remove(this);
                    //System.Diagnostics.Debug.WriteLine("<=====");
                    return result;
                }
            }
            public Point(int _x, int _Y)
            {
                x = _x;
                y = _Y;
            }
            public int x;
            public int y;
        }
    }
}