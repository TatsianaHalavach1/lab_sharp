using System;
using System.IO;

namespace lib_Equation
{
    public class MatrixReader
    {
        private static string fileContent;
        private static string[] NumbersFromFile;
        private static int fileContentIterator = 0;

        public MatrixReader(string filePath)
        {
            if (File.Exists(filePath))
            {
                fileContent = File.ReadAllText(filePath);
                NumbersFromFile = fileContent.Split(new Char[] { ' ', '\n' });
            }
            else
                fileContent = "";
        }

        public double[,] GetMatrix()
        {
            if (NumbersFromFile == null)
                return null;
            if (NumbersFromFile.Length - fileContentIterator <= 1 || !int.TryParse(NumbersFromFile[fileContentIterator].Replace(',', '.'), out int verticalDimension) |
                    !int.TryParse(NumbersFromFile[++fileContentIterator].Replace(',', '.'), out int horisontalDimension))
                return null;
            else
            {
                double[,] ResultMatrix = new double[verticalDimension, horisontalDimension];
                fileContentIterator++;
                for (int i = 0; i < verticalDimension; i++)
                {
                    for (int j = 0; j < horisontalDimension && fileContentIterator < NumbersFromFile.Length; j++, fileContentIterator++)
                    {
                        if (!double.TryParse(NumbersFromFile[fileContentIterator].Replace(',', '.'), out ResultMatrix[i, j]))
                            return null;
                    }
                }
                return ResultMatrix;
            }
        }

    }
}
