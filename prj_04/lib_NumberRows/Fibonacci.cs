using System;
using System.Collections.Generic;
using System.Linq;

namespace lib_NumberRows
{
    public class Fibonacci
    {
        private static List<long> _numbers;
        private long _previousNumber;
        private long _currentNumber;
        private long _nextNumber;

        public Fibonacci()
        {
            _numbers = new List<long>();
            _previousNumber = 0;
            _currentNumber = 1;
            _nextNumber = _previousNumber + _currentNumber;
        }

        private void InitializeNumbersWith(long parameter)
        {
            IsCorrect(parameter);
            _numbers.Clear();
            _previousNumber = 0;
            _currentNumber = 1;
            _numbers.Add(_previousNumber);
        }

        private void IsCorrect(long parameter)
        {
            if (parameter <= 0)
                throw new FormatException("Incorrect Fibonacci parameter! Must be > 0.");
        }

        private void CalculateNextNumber()
        {
            //case of overflow long
            if (_currentNumber < 0)
                throw new FormatException("Too large parameter! Overflow Fibonacci numbers type");
            _previousNumber = _currentNumber;
            _currentNumber = _nextNumber;
            _nextNumber += _previousNumber;
        }

        public bool IsFibonacci(long n)
        {
            InitializeNumbersWith(n);
            while (_currentNumber <= n)
            {
                _numbers.Add(_currentNumber);
                CalculateNextNumber();
            }
            return n == _numbers.Last();
        }

        //Fibonacci numbers to the particular number
        public List<long> NumbersTo(long n)
        {
            InitializeNumbersWith(n);
            while (_currentNumber <= n)
            {
                _numbers.Add(_currentNumber);
                CalculateNextNumber();
            }
            return _numbers;
        }

        //Fibonacci numbers in the particular quantity
        public List<long> NumbersInQuantity(int fibonacciCount)
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
    }
}
