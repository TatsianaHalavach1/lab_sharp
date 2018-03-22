
namespace prj_05
{
    public static class BigIntegerExtension
    {
        //1
        public static bool IsPrime(this BigInteger number)
        {
            if (number < 2)
            {
                return false;
            }
            for (BigInteger i = 2; i < number.sqrt(); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        //2
        public static BigInteger SumOfDigits(this BigInteger number)
        {
            BigInteger sum = 0;
            for (; number > 0; number /= 10)
                sum += number % 10;
            return sum;
        }
        //3
        public static bool IsDivideBy(this BigInteger number, BigInteger divider)
        {
            if (divider == 0)
                return false;
            return number % divider == 0;
        }

        //4
        public static bool Contains(this BigInteger number, int digit)
        {
            return number.ToString().Contains(digit.ToString());
        }

        //5
        public static int GetDigitOnIndex(this BigInteger number, int digitIndex)
        {
            string stringNumber = number.ToString();
            if (stringNumber.Length <= digitIndex)
                return -1;
            return int.Parse(stringNumber[digitIndex].ToString());
        }

        //7
        public static int SumOfSquaredDigits(this BigInteger number)
        {
            int sum = 0;
            for (; number > 0; number /= 10)
                sum += ((number % 10).IntValue() * (number % 10).IntValue());
            return sum;
        }
        //8
        public static int CountOfDigit(this BigInteger number, int digit)
        {
            int counter = 0;
            string stringNumber = number.ToString();
            foreach (var t in stringNumber)
            {
                if (t.ToString() == digit.ToString())
                    counter++;
            }
            return counter;
        }
    }
}
