using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_2._0
{
    class Pattern
    {
        private readonly int[,] patterns;

        public Pattern()
        {
            patterns = new int[17, 4] {
                { 1, 2, 3, 4 }, //1  [ a , b ; c , d ]
                { 1, 1, 2, 3 }, //2  [ a , b ; c , d ]
                { 1, 2, 1, 3 }, //3  [ a , b ; c , d ]
                { 1, 2, 3, 1 }, //4  [ a , b ; c , d ]
                { 1, 2, 3,-1 }, //5  [ a , b ; c , d ]
                { 1, 2, 2,-1 }, //6  [ a , b ; c , d ]
                { 1, 2, 2, 1 }, //7  [ a , b ; c , d ]
                { 1, 2,-2,-1 }, //8  [ a , b ; c , d ]
                { 1, 2, 2, 2 }, //9  [ a , b ; c , d ]
                { 1,-2, 2, 2 }, //10 [ a , b ; c , d ]
                { 1, 1, 2,-2 }, //11 [ a , b ; c , d ]
                { 1, 2, 1,-2 }, //12 [ a , b ; a ,-b ]
                { 1, 1, 2, 2 }, //13 [ a , a ; b , b ]
                { 1, 2, 1, 2 }, //14 [ a , b ; a , b ]
                { 1, 1, 1, 1 }, //15 [ a , a ; a , a ]
                {-1, 1, 1,-1 }, //16 [-a , a ; a ,-a ]
                { 1, 1, 1,-1 }, //17 [ a , a ; a ,-a ]
            };
        }

        public int CompareMatrixWithPatterns(int[] matrix)
        {
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (patterns[i, j] != matrix[j]) break;
                    if (j == 3) return (i + 1);
                }
            }
            return 0;
        }
    }
}
