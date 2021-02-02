using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Matrix_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 16; int n2 = n;

            List<int[,]> bestCombinations = new List<int[,]>();

            Matrix matrix = new Matrix();
            Combination combination = new Combination(n, matrix.getMatrix());

            int[,] variations = combination.GetAllVariations(n);
            bestCombinations = combination.FindBestCombinate(variations);

             int currCount = bestCombinations.Count;
            
            for (int i = 0; i < (n / 2) - 1; i++)
            {
                //Wykonanie do końca w dół względem wierszy
                n2 -= 2;

                for (int ii = 0; ii < currCount; ii++)
                {
                    variations = combination.GetAllVariations(n2, 1, bestCombinations[ii]);
                    bestCombinations = combination.FindBestCombinate(variations, 1, bestCombinations[ii]);
                }
                if(currCount- bestCombinations.Count!=0)
                {
                    bestCombinations.RemoveRange(0, currCount);
                    currCount = bestCombinations.Count;
               }
            }


            n2 = n-2;

            for (int j = 0; j < (n / 2) - 1; j++) 
            {
                for (int i = 1; i <= (n / 2); i++)
                {
                    if (i == 1)
                    {
                        for (int ii = 0; ii < currCount; ii++)
                        {
                            variations = combination.GetAllVariations(n2, 0, bestCombinations[ii]);
                            bestCombinations = combination.FindBestCombinate(variations, 0, bestCombinations[ii]);
                        }

                        if (currCount - bestCombinations.Count != 0)
                        {
                            bestCombinations.RemoveRange(0, currCount);
                            currCount = bestCombinations.Count;
                        }
                    }
                    else
                    {
                        for (int ii = 0; ii < currCount; ii++)
                        {
                            int[,] temp = new int[1, 2];

                            for (int jj = (i * 2) - 2, k = 0; jj < (i * 2); jj++, k++) // <--
                                temp[0, k] = (bestCombinations[ii])[1, jj];

                            bestCombinations = combination.FindBestCombinate(temp, 1, bestCombinations[ii]);
                        }

                        if (currCount - bestCombinations.Count != 0){

                            bestCombinations.RemoveRange(0, currCount);
                            currCount = bestCombinations.Count;
                        }
                    }
                }

                n2 -= 2;
            }

            int blocks = n / 4;
            int size = 4;

            do
            {
                for (int i = 1; i <= blocks; i++) // 1 2 
                    for (int j = 1; j <= blocks; j++) // 1 2 
                    {
                        for (int ii = 0; ii < currCount; ii++)
                        {
                            if((bestCombinations[ii])[0,0]==4 && (bestCombinations[ii])[0, 1] == 0){ 

                            }


                            bestCombinations = combination.FindBestCombinateFor4Part(bestCombinations[ii], i, j, size);
                        }
                            
                            
                        //if (currCount - bestCombinations.Count != 0){
                        bestCombinations.RemoveRange(0, currCount);
                        currCount = bestCombinations.Count;
                       // }
                    }

                size *= 2;      
                


                blocks /= 2;

            } while (blocks != 0);
            
        }
    }
}
