using System;

namespace lib_01
{
    public class SimpleCalculator
    {

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public SimpleCalculator(int a, int b)
        {
            FirstNumber = a;
            SecondNumber = b;
        }
        public long Sum()
        {
            return FirstNumber + SecondNumber;
        }
        public long Sub()
        {
            return FirstNumber - SecondNumber;
        }
        public long Mult()
        {
            return FirstNumber * SecondNumber;
        }
        public double Div()
        {
            if (SecondNumber!=0)
                return FirstNumber / SecondNumber;
            else
                throw new DivideByZeroException();
        }
        public void DemonstrateAll()
        {
            Console.WriteLine("Library result: " + Sum() + " " + Sub() + " " + Mult() + " " + Div());
        }
    }
}