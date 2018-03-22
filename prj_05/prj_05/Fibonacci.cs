using System;
using System.Collections.Generic;

namespace prj_05
{
    public static class Fibonacci
    {
        private static List<BigInteger> _numbers = new List<BigInteger>();
        private static BigInteger _previousNumber = 1;
        private static BigInteger _currentNumber = 1;
        private static BigInteger _nextNumber = _previousNumber + _currentNumber;
        
        //Fibonacci numbers in the particular quantity
        public static List<BigInteger> NumbersInQuantity(int fibonacciCount)
        {
            InitializeNumbersWith(fibonacciCount);
            if (fibonacciCount == 1)
                return _numbers;
            while (_numbers.Count < fibonacciCount)
            {
                _numbers.Add(_currentNumber);
                CalculateNextNumber();
            }
            return _numbers;
        }

        private static void InitializeNumbersWith(long parameter)
        {
            IsCorrect(parameter);
            _numbers.Clear();
            _previousNumber = 1;
            _currentNumber = 1;
            _numbers.Add(_previousNumber);
        }

        private static void IsCorrect(long parameter)
        {
            if (parameter <= 0)
                throw new FormatException("Incorrect Fibonacci parameter! Must be > 0.");
        }

        private static void CalculateNextNumber()
        {
            //case of overflow long
            if (_currentNumber < 0)
                throw new FormatException("Too large parameter! Overflow Fibonacci numbers type");
            _previousNumber = _currentNumber;
            _currentNumber = _nextNumber;
            _nextNumber += _previousNumber;
        }
    }
}
