using System;
using System.Text;

namespace lib_Equation
{
    //ax^2+bx+c=0
    public class QuadraticEquation : LinearEquation
    {
        public new const string Type = "Quadratic";
        protected double X2Coefficient { get; set; }

        private double x1;
        private double x2;

        public QuadraticEquation(double coefficientWithX2, double coefficientWithX, double freeCoefficient) :
            base(coefficientWithX, freeCoefficient)
        {
            X2Coefficient = coefficientWithX2;
        }

        //D = b^2 - 4ac
        private double GetDiscriminant()
        {
            return Math.Pow(XCoefficient, 2) - 4 * X2Coefficient * FreeCoefficient;
        }

        public override string GetSolutionRecord()
        {
            double discriminant = GetDiscriminant();
            if (discriminant < 0)
                return "No solution";
            else if (discriminant == 0)
            {
                x1 = x2 = -XCoefficient / (2 * X2Coefficient);
                return string.Format("{0:0.##}", x1);
            }
            else
            {
                x1 = (-XCoefficient - Math.Sqrt(discriminant)) / (2 * X2Coefficient);
                x2 = (-XCoefficient + Math.Sqrt(discriminant)) / (2 * X2Coefficient);
                return string.Format("{0:0.##};  {1:0.##}", x1, x2);
            }
        }

        public override string GetEquationRecord()
        {
            StringBuilder equationRecord = new StringBuilder($"{X2Coefficient}*x^2");
            if (XCoefficient > 0)
                equationRecord.Append("+");
            if (XCoefficient != 0)
                equationRecord.Append(XCoefficient + "*x");
            if (FreeCoefficient > 0)
                equationRecord.Append("+");
            if (FreeCoefficient != 0)
                equationRecord.Append(FreeCoefficient);
            equationRecord.Append("=0");
            return equationRecord.ToString();
        }

        public override string GetEquationAndSolutionRecord()
        {
            return string.Format($"Quadratic: {GetEquationRecord()}. Solution is [{GetSolutionRecord()}]");
        }
    }
}
