using System.Text;

namespace lib_Equation
{
    //Ax+B=0
    public class LinearEquation : Equation
    {
        public const string Type = "Linear";
        public double XCoefficient { get;  }
        public double FreeCoefficient { get;  }

        public LinearEquation(double coefficientWithX, double freeCoefficient)
        {
            XCoefficient = coefficientWithX;
            FreeCoefficient = freeCoefficient;
        }

        public override string GetEquationRecord()
        {
            StringBuilder equationRecord = new StringBuilder($"{XCoefficient}*x");
            if (FreeCoefficient > 0)
                equationRecord.Append("+");
            if (FreeCoefficient != 0)
                equationRecord.Append(FreeCoefficient);
            equationRecord.Append("=0");
            return equationRecord.ToString();
        }

        public override string GetSolutionRecord()
        {
            return string.Format("{0:0.##}", -FreeCoefficient / XCoefficient);
        }

        public override string GetEquationAndSolutionRecord()
        {
            return $"Linear: {GetEquationRecord()}. Solution is [{GetSolutionRecord()}]";
        }
    }
}
