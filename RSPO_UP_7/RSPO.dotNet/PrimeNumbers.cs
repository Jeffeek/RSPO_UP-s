﻿using System;
using System.Collections.Generic;

namespace RSPO.dotNet
{
    /// <summary>
    /// Find all prime numbers on the natural segment [1000.9999],
    /// the sum of the first and second digits of which is equal to the
    /// sum of the third and fourth digits.
    /// </summary>
    public class PrimeNumbers
    {
        /// <summary>
        /// Internal <seealso cref="IEnumerable{T}"/> numbers
        /// </summary>
        private IEnumerable<int> _numbers;
        
        public PrimeNumbers(IEnumerable<int> numbers)
        {
            _numbers = numbers;
        }

        /// <summary>
        /// Check for number - is it prime or not
        /// </summary>
        /// <param name="n">Number<see cref="int"/></param>
        /// <returns>True is <see cref="n"/> prime</returns>
        public bool IsPrime(int n)
        {
            if (n < 0) throw new Exception("Number was lower than zero");
            if (n == 0) return false;
            if (n == 2) return true;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns <see cref="IEnumerable{<see cref="int"/>}"/> where the sum of 1 and 2 digits
        /// are equals to the sum of third and fourth digits
        /// </summary>
        /// <returns><see cref="IEnumerable{<seealso cref="int"/>}"/> of taken numbers</returns>
        public IEnumerable<int> FirstSecondEqualsThirdFourth()
        {
            foreach (var num in _numbers)
            {
                if (IsTaken(num))
                    yield return num;
            }
        }

        /// <summary>
        /// Checks is number fit's conditions
        /// </summary>
        /// <param name="n"></param>
        /// <returns><see cref="bool"/> - <value>true</value> if fit's and
        /// <value>False</value> if NOT</returns>
        private bool IsTaken(int n)
        {
            if (n < 1000 || n > 9999) return false;
            var @string = n.ToString();
            if (int.Parse(@string[0].ToString()) +
                int.Parse(@string[1].ToString()) ==
                          int.Parse(@string[2].ToString()) +
                          int.Parse(@string[3].ToString()) && IsPrime(n)) return true;
            return false;
        }
    }
}