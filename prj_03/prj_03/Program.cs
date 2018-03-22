using System;
using System.Configuration;
using lib_Equation;

namespace prj_03
{
    class Program
    {
        static void Main(string[] args)
        {
            const string LogFile = "log.txt";
            LogFileWriter logWriter = new LogFileWriter(LogFile);
            if (logWriter.LogFile == null)//throw exception
                Console.WriteLine("LogFile doesn't exist or is readOnly!");

            Console.WriteLine("Choose type of equation you want to solve: 'L' - linear, 'Q' - quadratic\n" +
                "or any other key to exit and press 'Enter':");
            Equation equation = ChooseEquationType(Console.ReadLine().ToUpper(), logWriter);
            if (equation != null)
            {
                string result = equation.GetEquationAndSolutionRecord();
                Console.WriteLine(result);
                logWriter.WriteEquationToLog(result);
            }


            string fileNameWithMatrix = ConfigurationManager.AppSettings["fileNameWithMatrix"];
            MatrixReader matrixReader = new MatrixReader(fileNameWithMatrix);
            double[,] matrix1 = matrixReader.GetMatrix();
            double[,] matrix2 = matrixReader.GetMatrix();
            Console.WriteLine(MatrixCalculator.GetMultiplicationStringResult(matrix1, matrix2));
            Console.ReadKey();
        }

        public static Equation ChooseEquationType(string type, LogFileWriter logWriter)
        {
            Equation equation;
            double x2Coefficient, xCoefficient, freeCoefficient;
            switch (type)
            {
                case "L":
                    xCoefficient = DoubleNumberInputter.ReadNumberFromConsole(logWriter);
                    DoubleNumberInputter.ReadNumberNotZero(ref xCoefficient, logWriter);
                    freeCoefficient = DoubleNumberInputter.ReadNumberFromConsole(logWriter);
                    equation = new LinearEquation(xCoefficient, freeCoefficient);
                    return equation;
                case "Q":
                    x2Coefficient = DoubleNumberInputter.ReadNumberFromConsole(logWriter);
                    DoubleNumberInputter.ReadNumberNotZero(ref x2Coefficient, logWriter);
                    xCoefficient = DoubleNumberInputter.ReadNumberFromConsole(logWriter);
                    freeCoefficient = DoubleNumberInputter.ReadNumberFromConsole(logWriter);
                    equation = new QuadraticEquation(x2Coefficient, xCoefficient, freeCoefficient);
                    return equation;
                default:
                    return null;
            }
        }
    }
}
