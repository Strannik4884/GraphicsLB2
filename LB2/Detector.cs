using System;
using System.Threading.Tasks;

namespace LB2
{
    public class Detector
    {
        private bool isMaxPrecision;
        private double lowerTreshold;
        private double upperTreshold;
        private double[,] extractedX;
        private double[,] extractedY;
        private double[,] gradientValue;
        private double[,] directionGradient;
        private readonly double[,] xMatrix = { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
        private readonly double[,] yMatrix = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        private readonly double[,] gaussMatrix = {
                                            {0.0121, 0.0261, 0.0337, 0.0261, 0.0121},
                                            {0.0261, 0.0561, 0.0724, 0.0561, 0.0261},
                                            {0.0337, 0.0724, 0.0935, 0.0724, 0.0337},
                                            {0.0261, 0.0561, 0.0724, 0.0561, 0.0261},
                                            {0.0121, 0.0261, 0.0337, 0.0261, 0.0121}
                                        };

        // флаг использования максимальной точности
        public bool IsMaxPrecision
        {
            get
            {
                return isMaxPrecision;
            }

            set
            {
                isMaxPrecision = value;
            }
        }

        // нижний порог срабатывания
        public double LowerTreshold
        {
            get
            {
                return lowerTreshold;
            }

            set
            {
                lowerTreshold = value;
            }
        }

        // верхний порог срабатывания
        public double UpperTreshold
        {
            get
            {
                return upperTreshold;
            }

            set
            {
                upperTreshold = value;
            }
        }

        // свёртка
        private double[,] Convolution(double[,] imageInput, double[,] kernel, int radius)
        {
            if (imageInput == null) return null;

            int yPosition = imageInput.GetLength(1);
            int xPosition = imageInput.GetLength(0);

            double[,] imageOutput = new double[xPosition, yPosition];

            Parallel.For(0, xPosition, i => {
                for (int j = 0; j < yPosition; j++)
                {
                    double newValue = 0;
                    for (int innerI = i - radius; innerI < i + radius + 1; innerI++)
                        for (int innerJ = j - radius; innerJ < j + radius + 1; innerJ++)
                        {
                            int idxX = (innerI + xPosition) % xPosition;
                            int idxY = (innerJ + yPosition) % yPosition;

                            int kernelX = innerI - (i - radius);
                            int kernelY = innerJ - (j - radius);
                            newValue += imageInput[idxX, idxY] * kernel[kernelX, kernelY];
                        }
                    imageOutput[i, j] = newValue;
                }
            });

            return imageOutput;
        }

        // расширение матрицы
        public double[,] ExpandMatrix(double[,] matrix, int expansion)
        {
            if (matrix == null) return null;

            int x = matrix.GetLength(0), y = matrix.GetLength(1);
            double[,] expandedMatrix = new double[x + 2 * expansion, y + 2 * expansion];
            for (int i = -expansion; i < x + expansion - 1; i++)
                for (int j = -expansion; j < y + expansion - 1; j++)
                {
                    var ii = (i + x) % x;
                    int jj = (j + y) % y;
                    expandedMatrix[i + 2, j + 2] = matrix[ii, jj];
                }

            return expandedMatrix;
        }

        // определение границ
        public double[,] Detection(double[,] normalImage, int precision)
        {
            if (normalImage == null) return null;
            int blurX, blurY;

            double[,] bluredMatrix;
            try
            {
                bluredMatrix = Convolution(normalImage, gaussMatrix, 2);

                blurX = bluredMatrix.GetLength(0); blurY = bluredMatrix.GetLength(1);

                extractedX = Convolution(bluredMatrix, xMatrix, 1);
                extractedY = Convolution(bluredMatrix, yMatrix, 1);
            }
            catch (OutOfMemoryException)
            {
                throw;
            }

            int xExcerptX = extractedX.GetLength(0), yExcerptY = extractedX.GetLength(1);
            gradientValue = new double[xExcerptX, yExcerptY];
            directionGradient = new double[xExcerptX, yExcerptY];

            for (int x = 0; x < blurX; x++)
            {
                for (int y = 0; y < blurY; y++)
                {
                    gradientValue[x, y] = Math.Sqrt(extractedX[x, y] * extractedX[x, y] + extractedY[x, y] * extractedY[x, y]);
                    double pom = Math.Atan2(extractedX[x, y], extractedY[x, y]);
                    if ((pom >= -Math.PI / 8 && pom < Math.PI / 8) || (pom <= -7 * Math.PI / 8 && pom > 7 * Math.PI / 8))
                        directionGradient[x, y] = 0;
                    else if ((pom >= Math.PI / 8 && pom < 3 * Math.PI / 8) || (pom <= -5 * Math.PI / 8 && pom > -7 * Math.PI / 8))
                        directionGradient[x, y] = Math.PI / 4;
                    else if ((pom >= 3 * Math.PI / 8 && pom <= 5 * Math.PI / 8) || (-3 * Math.PI / 8 >= pom && pom > -5 * Math.PI / 8))
                        directionGradient[x, y] = Math.PI / 2;
                    else if ((pom < -Math.PI / 8 && pom >= -3 * Math.PI / 8) || (pom > 5 * Math.PI / 8 && pom <= 7 * Math.PI / 8))
                        directionGradient[x, y] = -Math.PI / 4;
                }
            }

            var max = GetMatrixMaxValue(gradientValue);
            for (int i = 0; i < xExcerptX; i++)
            {
                for (int j = 0; j < yExcerptY; j++)
                {
                    gradientValue[i, j] /= max;
                }
            }

            if (upperTreshold == 0 && lowerTreshold == 0) GetThresholds(blurX, blurY);

            for (int i = 0; i < xExcerptX; i++)
            {
                for (int j = 0; j < yExcerptY; j++)
                {
                    gradientValue[i, j] = gradientValue[i, j] < lowerTreshold ? 0 : gradientValue[i, j];
                }
            }

            for (var x = 1; x < blurX - 1; x++)
            {
                for (var y = 1; y < blurY - 1; y++)
                {
                    if (directionGradient[x, y] == 0 && (gradientValue[x, y] <= gradientValue[x - 1, y] || gradientValue[x, y] <= gradientValue[x + 1, y]))
                        gradientValue[x, y] = 0;
                    else if (directionGradient[x, y] == Math.PI / 2 && (gradientValue[x, y] <= gradientValue[x, y - 1] || gradientValue[x, y + 1] >= gradientValue[x, y]))
                        gradientValue[x, y] = 0;
                    else if (directionGradient[x, y] == Math.PI / 4 && (gradientValue[x, y] <= gradientValue[x - 1, y + 1] || gradientValue[x, y] <= gradientValue[x + 1, y - 1]))
                        gradientValue[x, y] = 0;
                    else if (directionGradient[x, y] == -Math.PI / 4 && (gradientValue[x, y] <= gradientValue[x - 1, y - 1] || gradientValue[x, y] <= gradientValue[x + 1, y + 1]))
                        gradientValue[x, y] = 0;
                }
            }

            for (var x = 2; x < blurX - 2; x++)
            {
                for (var y = 2; y < blurY - 2; y++)
                {
                    if (directionGradient[x, y] == 0)
                        if (gradientValue[x - 2, y] > gradientValue[x, y] || gradientValue[x + 2, y] > gradientValue[x, y])
                            gradientValue[x, y] = 0;
                    if (directionGradient[x, y] == Math.PI / 2)
                        if (gradientValue[x, y - 2] > gradientValue[x, y] || gradientValue[x, y + 2] > gradientValue[x, y])
                            gradientValue[x, y] = 0;
                    if (directionGradient[x, y] == Math.PI / 4)
                        if (gradientValue[x - 2, y + 2] > gradientValue[x, y] || gradientValue[x + 2, y - 2] > gradientValue[x, y])
                            gradientValue[x, y] = 0;
                    if (directionGradient[x, y] == -Math.PI / 4)
                        if (gradientValue[x + 2, y + 2] > gradientValue[x, y] || gradientValue[x - 2, y - 2] > gradientValue[x, y])
                            gradientValue[x, y] = 0;
                }
            }

            for (var x = 0; x < blurX; x++)
            {
                for (var y = 0; y < blurY; y++)
                {
                    if (gradientValue[x, y] > upperTreshold)
                        gradientValue[x, y] = 1;
                }
            }

            // начало расчёта гистерезиса
            var pomH = 0;
            var pomStaro = -1;
            var passage = 0;

            var isContinue = true;
            while (isContinue)
            {
                passage++;
                pomStaro = pomH;
                for (int x = 1; x < xExcerptX - 1; x++)
                {
                    for (int y = 1; y < yExcerptY - 1; y++)
                    {
                        if (gradientValue[x, y] <= upperTreshold && gradientValue[x, y] >= lowerTreshold)
                        {
                            double pom1 = gradientValue[x - 1, y - 1];
                            double pom2 = gradientValue[x, y - 1];
                            double pom3 = gradientValue[x + 1, y - 1];
                            double pom4 = gradientValue[x - 1, y];
                            double pom5 = gradientValue[x + 1, y];
                            double pom6 = gradientValue[x - 1, y + 1];
                            double pom7 = gradientValue[x, y + 1];
                            double pom8 = gradientValue[x + 1, y + 1];

                            if (pom1 == 1 || pom2 == 1 || pom3 == 1 || pom4 == 1 || pom5 == 1 || pom6 == 1 || pom7 == 1 || pom8 == 1)
                            {
                                gradientValue[x, y] = 1;
                                pomH++;
                            }
                        }
                    }
                }

                if (isMaxPrecision)
                {
                    isContinue = pomH != pomStaro;
                }
                else
                {
                    isContinue = passage <= precision;
                }
            }

            for (int i = 0; i < xExcerptX; i++)
            {
                for (int j = 0; j < yExcerptY; j++)
                {
                    if (gradientValue[i, j] <= upperTreshold)
                        gradientValue[i, j] = 0;
                }
            }
            // конец расчёта гистерезиса

            return gradientValue;
        }

        // автоматическое определение значений порогов
        private void GetThresholds(int dimX, int dimY)
        {
            double sum = 0;
            double number = 0;

            for (var x = 1; x < dimX - 1; x++)
                for (var y = 1; y < dimY - 1; y++)
                {
                    if (gradientValue[x, y] != 0)
                    {
                        sum += gradientValue[x, y];
                        number++;
                    }
                }
            upperTreshold = sum / number;
            lowerTreshold = 0.4 * upperTreshold;
        }

        // поиск максимального значения в массиве
        private double GetMatrixMaxValue(double[,] mat)
        {
            double m = -1;

            foreach (var el in mat)
            {
                m = el > m ? el : m;
            }

            return m;
        }

        // очистка всех данных
        public void CleanUp()
        {
            extractedX = null;
            extractedY = null;
            gradientValue = null;
            directionGradient = null;
            GC.Collect();
        }
    }
}
