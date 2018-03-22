using System.Text;

namespace lib_Equation
{
    public class MatrixWriter
    {
        public static string GetMatrixView(double[,] Matrix)
        {
            StringBuilder builder = new StringBuilder("");
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    builder.AppendFormat("{0:0.##}", Matrix[i, j]);
                    builder.Append("\t");
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
