using System.Text;

namespace lib_Equation
{
    public class MatrixCalculator
    {
        public static double[,] Multiply(double[,] Matrix1, double[,] Matrix2)
        {
            if (Matrix1.GetLength(1) == Matrix2.GetLength(0))
            {
                double[,] ResultMatrix = new double[Matrix1.GetLength(0), Matrix2.GetLength(1)];
                for (int i = 0; i < Matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix2.GetLength(1); j++)
                    {
                        for (int k = 0; k < Matrix1.GetLength(1); k++)
                        {
                            ResultMatrix[i, j] += Matrix1[i, k] * Matrix2[k, j];
                        }
                    }                    
                }
                return ResultMatrix;
            }
            else
                return null;
        }

        public static string GetMultiplicationStringResult(double[,] Matrix1, double[,] Matrix2)
        {
            StringBuilder resultString = new StringBuilder("");
            if (Matrix1 != null && Matrix2 != null)
            {
                resultString.AppendLine("Multiplication of");
                resultString.Append(MatrixWriter.GetMatrixView(Matrix1));
                resultString.AppendLine("and");
                resultString.Append(MatrixWriter.GetMatrixView(Matrix2));
                resultString.AppendLine("is");
                double[,] resultMatrix = MatrixCalculator.Multiply(Matrix1, Matrix2);
                if (resultMatrix == null)
                    resultString.AppendLine("[Can't multiply (incorrect dimension)]");
                else
                    resultString.AppendLine(MatrixWriter.GetMatrixView(resultMatrix));
                return resultString.ToString();
            }
            else
                return "Any problems with Matrix data in file: not enough numbers or numbers aren't double values";
        }

    }
}
