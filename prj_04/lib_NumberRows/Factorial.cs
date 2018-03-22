using System;

namespace lib_NumberRows
{
    public static class Factorial
    {
        private static bool IsCorrectFactorialParameter(int n)
        {
            return n >= 0;
        }

        /// <summary>
        /// comment
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long FactorialOf(int n)
        {
            if (!IsCorrectFactorialParameter(n))
                throw new FormatException("Incorrect factorial parameter < 0!");
            if (n == 0 || n == 1)
                return 1;
            long factorialResult = 1;
            for (int i = 1; i <= n; i++)
            {
                factorialResult *= i;
                if (factorialResult < 0)
                    throw new FormatException("Too large parameter! Overflow Factorial");
            }
            return factorialResult;
        }

        public static bool IsFactorial(int N)
        {
            try
            {
                ReverseFactorialOf(N);
                return true;
            }
            catch (NotFoundReverseFactorialException e)
            {
                return false;
            }
            catch (FormatException e)
            {
                return false;
            }
        }

        public static int ReverseFactorialOf(int N)
        {
            if (!IsCorrectFactorialParameter(N) || N == 0)
                throw new FormatException("Incorrect reverse factorial parameter <= 0!");
            if (N == 1)
                return 1;
            else
            {
                int i;
                for (i = 1; N > 1; i++)
                {
                    if (N % i != 0)
                        throw new NotFoundReverseFactorialException("");
                    N /= i;
                }
                return i - 1;
            }
        }
    }
}
