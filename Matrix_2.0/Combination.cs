using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;


namespace Matrix_2._0
{
    class Combination
    {
        private int n;
        private int[] baseNumber;
        decimal[,] matrix;

        private int[,] Variations { get; set; }

        private List<int[,]> bestCombinations = new List<int[,]>();
        public Combination(int n, decimal[,] matrix)
        {
            this.n = n;
            this.matrix = matrix;
            baseNumber = new int[n];

            for (int i = 0; i < n; i++)
                baseNumber[i] = i;

        }

        public int[,] GetAllVariations(int n, int way = 2, int[,] numbersSought = null)
        {
            int[] nextValues = null;
            
            int numberOfVariationsWD = NumberOfVariationWithoutDuplicates((ulong)n, 2); //30

            if (numbersSought == null)
            {                                      // Case with optional parameter.
                numbersSought = new int[2, n];     // First induction must used this,
                for (int i = 0; i < n; i++)
                {
                    numbersSought[0, i] = i;       // because we'll trying find best
                    numbersSought[1, i] = i;       // combinate for first submatrix.
                }
            }
            else
            {
                nextValues = GetNextValuesofCombinations(n,way, numbersSought);
            }

            int start_index = 0;
            int[] index = new int[2] { start_index, start_index + 2 }; // 2 ; 4 

            Variations = new int[numberOfVariationsWD, 2]; //30

            if(way ==2)
            {
                Variations[0, 0] = numbersSought[0, start_index];
                Variations[0, 1] = numbersSought[1, start_index + 1];
            }
            else
            {
                Variations[0, 0] = nextValues[0];
                Variations[0, 1] = nextValues[1];
            }

            if (n == 2) // Case for 2 variations, algoritm isn't nessesery for this n 
            {
                Variations[1, 0] = nextValues[1]; Variations[1, 1] = nextValues[0];
                return Variations;
            }

            for (int i = 1; i < numberOfVariationsWD; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (way == 2)
                    {
                        Variations[i, j] = numbersSought[1, index[j]];

                        if (j == (index.Length - 1) && index[j] + 1 == numbersSought.GetLength(1))
                        {
                            index[0]++;
                            index[1] = 0;
                        }
                        else if ((j == (index.Length - 1)) && (++index[1] == index[0])) index[1]++;
                    }
                    else
                    {
                        Variations[i, j] = nextValues[index[j]];

                        if (j == (index.Length - 1) && index[j] + 1 == nextValues.Length)
                        {
                            index[0]++;
                            index[1] = 0;
                        }
                        else if ((j == (index.Length - 1)) && (++index[1] == index[0])) index[1]++;
                    }
                        
                    
                }
            }

            return Variations;
        }

        public List<int[,]> FindBestCombinate(int[,] Variations,int way = 2, int[,] numbersSought = null)
        {
            int[,] constVariations;
            int endOfNumbers = 0;

            if (way == 2) constVariations = (int[,])Variations.Clone();
            else
            {                                                   
                int i = (way == 1 ? 0 : 1); // i =` 0 

                if (i == 0) // W dół 
                {
                    constVariations = new int[1, 2];


                    for (endOfNumbers = 0; endOfNumbers < numbersSought.GetLength(1); endOfNumbers++)
                        if (numbersSought[i, endOfNumbers] == -1)
                        {

                            int endBegin = endOfNumbers - 2;


                            for (int ii = endBegin, ii2 = 0; ii < endOfNumbers; ii++, ii2++)
                                constVariations[0, ii2] = numbersSought[i, ii];

                            break;
                        }
                        else if (endOfNumbers == numbersSought.GetLength(1) - 1)
                        {
                            int endBegin = endOfNumbers - 1; // Kończymy na 3 dlatego iterujemy od 2 by miec 2 i 3 < 4


                            for (int ii = endBegin, ii2 = 0; ii < endOfNumbers + 1; ii++, ii2++)
                                constVariations[0, ii2] = numbersSought[i, ii];

                            break;
                        }
                }
                else // W prawo 
                {
                    endOfNumbers = 2;
                    constVariations = new int[1, endOfNumbers];

                    for (int ii = 0; ii < endOfNumbers; ii++)
                        constVariations[0, ii] = numbersSought[i, ii];


                    endOfNumbers -= 2;
                }

               //for (endOfNumbers = 0; endOfNumbers < numbersSought.GetLength(1); endOfNumbers++)
                // if (numbersSought[i, endOfNumbers] == -1 || (endOfNumbers == numbersSought.GetLength(1)-1)) break;

                
            }

            

            decimal[,] vectors = new decimal[4,1];
            for (int ii = 0; ii < (way==0 ? constVariations.GetLength(0) : Variations.GetLength(0)); ii++)
            {
                for (int jj = 0; jj < (way==1 ? constVariations.GetLength(0) : Variations.GetLength(0)); jj++)
                {
                    for (int iv = 0, x = 0 ; x < 2; x++)       
                        for (int y = 0 ; y < 2; y++, iv++)       
                            vectors[iv,0] = matrix[(way == 0 ? constVariations[ii, x] : Variations[ii, x]), (way == 1 ? constVariations[jj, y] : Variations[jj, y])];


                    if (FindSimilarElements(vectors) > 1)// <---
                    {
                        if (way == 2)
                        {
                            numbersSought = new int[2, n];

                            for (int i = 0; i < Variations.GetLength(1); i++)
                                numbersSought[1, i] = Variations[ii, i];

                            for (int i = 0; i < constVariations.GetLength(1); i++)
                                numbersSought[0, i] = constVariations[jj, i];

                            for (int i = Variations.GetLength(1); i < n; i++)
                            {
                                numbersSought[0, i] = -1; numbersSought[1, i] = -1;
                            }

                            bestCombinations.Add(numbersSought);
                        }
                        else if(Variations.GetLength(0)==1)
                        {
                            bestCombinations.Add(numbersSought);
                        }
                        else
                        {
                            int j;
                            int[,] numberSoughtCopy = (int[,]) numbersSought.Clone();

                            for (j = 0; j < numbersSought.GetLength(1); j++)
                                if (numberSoughtCopy[way, j] == -1) break; 


                            for(int j2=j, i = 0; j2 < (j+2); j2++, i++)
                                numberSoughtCopy[way, j2] = Variations[(way==1 ? ii : jj), i];

                               

                            bestCombinations.Add(numberSoughtCopy);
                        }
                    }
                }
            }

            return bestCombinations;
        }

        public List<int[,]> FindBestCombinateFor4Part(int[,] numbersSought, int halfX, int halfY, int size)
        {
            int iv = 0,jv = 0;
            decimal[,] vectors = new decimal[4, (size/2)*(size/2)];

            halfX = (halfX - 1) * size;
            halfY = (halfY - 1) * size;

            int cX = halfX;
            int cY = halfY;

            for (int xx = 0; xx < 2; xx++, cX = cX + (size / 2), cY = halfY)
            {
                for (int yy = 0; yy < 2; yy++, iv++, jv=0, cY = cY + (size / 2))
                {
                    for (int x = cX; x < cX + (size/2) ; x++)
                        for (int y = cY; y < cY + (size / 2); y++, jv++)
                            vectors[iv, jv] = matrix[numbersSought[1, x], numbersSought[0, y]];
                }
            }

            if (FindSimilarElements(vectors) > 1) bestCombinations.Add(numbersSought);
                
            
            return bestCombinations;
        }

        public static int FindSimilarElements(decimal[,] vector)
        {
           int patt = 1;
            
            int[] patern = new int[4]; patern[0] = 1;
            Pattern pattern = new Pattern();

            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    bool minus = false;

                    for (int x = 0; x < vector.GetLength(1); x++)
                    {
                        if ((vector[i, x] != 0) && (vector[i, x] == (vector[j, x] * (-1))))
                        {
                            minus = true;
                            break;
                        }
                    }

                    for (int ii = 0; ii < vector.GetLength(1); ii++)
                    {
                        if (minus == false && vector[i, ii] == vector[j, ii] && ii == vector.GetLength(1)-1)
                        {
                            patern[i] = patern[j];
                            j = i - 1;
                        }
                        else if (minus == true && vector[i, ii] == (vector[j, ii] * (-1)) && ii == vector.GetLength(1) - 1)
                        {
                            patern[i] = patern[j] * (-1);
                            j = i - 1;
                        }
                        else if (minus == false && vector[i, ii] == vector[j, ii]) continue;
                        else if (minus == true && vector[i, ii] == (vector[j, ii] * (-1))) continue;
                        else
                        {
                            patern[i] = patt + 1;
                            if (i == j + 1) patt++;
                            break;
                        }
                    }
                }
            }


            int xx = pattern.CompareMatrixWithPatterns(patern);
           
            return xx;
        }

        public static ulong Factor(ulong f)
        {
            if (f > 1) return (f * Factor(--f));
            return 1;
        }

        public static int NumberOfVariationWithoutDuplicates(ulong n, ulong k)
        {
            k = Factor(n - k);
            n = Factor(n);

            return (int) (n / k);
        }

        public int[] GetNextValuesofCombinations(int n, int way,int[,] numbersSounght)
        {
            int[] tab = new int[n];
            int tab_i = 0;

            for(int i=0; i<baseNumber.GetLength(0); i++)
            {
                for(int j=0; j<numbersSounght.GetLength(1); j++)
                {
                    if (numbersSounght[way, j] == -1 || baseNumber[i] == numbersSounght[way, j]) break;
                    if ((baseNumber[i] != numbersSounght[way, j]) && (numbersSounght[way, j+1] == -1)) { tab[tab_i] = baseNumber[i]; tab_i++; }
                }   
            }
            return tab;
        }

    }
}
