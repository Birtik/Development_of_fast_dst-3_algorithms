﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_2._0
{
    class Matrix : IMatrix
    {
        private decimal[,] baseMatrix;

        public Matrix()
        {
            baseMatrix = new decimal[16, 16]
            {//   0  1  2  3  4  5  6  7
                /*{ 1, 2, 3, 4, 5, 6, 7, 8 }, // a = 1
                { 2, 5, 8,-6,-3,-1,-4,-7 }, // b = 2
                { 3, 8,-4,-2,-7, 5, 1, 6 }, // c = 3 
                { 4,-6,-2, 8, 1, 7,-3,-5 }, // d = 4
                { 5,-3,-7, 1,-8,-2, 6, 4 }, // e = 5 
                { 6,-1, 5, 7,-2, 4, 8,-3 }, // f = 6
                { 7,-4, 1,-3, 6, 8,-5, 2 }, // g = 7 
                { 8,-7, 6,-5, 4,-3, 2,-1 }*/
               /* { 1, 2, 3, 2},
                { 3, 2,-1,-2},
                { 3,-2,-1, 2},
                { 1,-2, 3,-2},*/

                /*{ 1, 2, 3, 4, 5, 6, 7, 4 }, // a = 1
                { 3, 6, 7, 4, 1,-2,-5,-4 }, // b = 2
                { 5, 6, 1,-4,-7,-2, 3, 4 }, // c = 3 
                { 7, 2,-5,-4, 3, 6,-1,-4 }, // d = 4
                { 7,-2,-5, 4, 3,-6,-1, 4 }, // e = 5 
                { 5,-6, 1, 4,-7, 2, 3,-4 }, // f = 6
                { 3,-6, 7,-4, 1, 2,-5, 4 }, // g = 7 
                { 1,-2, 3,-4, 5,-6, 7,-4 }*/

                { 3, 6, 7, 4, 1,-2,-5,-4, 3, 6, 7, 4, 1,-2,-5,-4 }, // b = 2
                { 5, 6, 1,-4,-7,-2, 3, 4, 3, 6, 7, 4, 1,-2,-5,-4 }, // c = 3 
                { 7, 2,-5,-4, 3, 6,-1,-4 ,3, 6, 7, 4, 1,-2,-5,-4}, // d = 4
                { 7,-2,-5, 4, 3,-6,-1, 4 ,3, 6, 7, 4, 1,-2,-5,-4}, // e = 5 
                { 5,-6, 1, 4,-7, 2, 3,-4 ,3, 6, 7, 4, 1,-2,-5,-4}, // f = 6
                { 3,-6, 7,-4, 1, 2,-5, 4 ,3, 6, 7, 4, 1,-2,-5,-4}, // g = 7 
                { 1,-2, 3,-4, 5,-6, 7,-4,3, 6, 7, 4, 1,-2,-5,-4 },
                { 3, 6, 7, 4, 1,-2,-5,-4 ,3, 6, 7, 4, 1,-2,-5,-4}, // b = 2
                { 5, 6, 1,-4,-7,-2, 3, 4 ,3, 6, 7, 4, 1,-2,-5,-4}, // c = 3 
                { 7, 2,-5,-4, 3, 6,-1,-4 ,3, 6, 7, 4, 1,-2,-5,-4}, // d = 4
                { 7,-2,-5, 4, 3,-6,-1, 4 ,3, 6, 7, 4, 1,-2,-5,-4}, // e = 5 
                { 5,-6, 1, 4,-7, 2, 3,-4 ,3, 6, 7, 4, 1,-2,-5,-4}, // f = 6
                { 3,-6, 7,-4, 1, 2,-5, 4 ,3, 6, 7, 4, 1,-2,-5,-4}, // g = 7 
                { 1,-2, 3,-4, 5,-6, 7,-4 ,3, 6, 7, 4, 1,-2,-5,-4},
                { 3,-6, 7,-4, 1, 2,-5, 4 ,3, 6, 7, 4, 1,-2,-5,-4}, // g = 7 
                { 1,-2, 3,-4, 5,-6, 7,-4 ,3, 6, 7, 4, 1,-2,-5,-4}

            };
        }

        public decimal[,] getMatrix() => baseMatrix;
    }
}