using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SunnyCalc.Maths
{
    public class MathsService : IMathsService
    {
        /// <inheritdoc/>
        public int Add(int a, int b)
        {
            return a + b; 
        }

        /// <inheritdoc/>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <inheritdoc/>
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        /// <inheritdoc/>
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        /// <inheritdoc/>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <inheritdoc/>
        public decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        /// <inheritdoc/>
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        /// <inheritdoc/>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <inheritdoc/>
        public decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        /// <inheritdoc/>
        public int Divide(int a, int b)
        {
            //  trying to divide by 0
            if (b == 0) throw new System.DivideByZeroException("Trying to divide by 0.");
            
            return a / b;
        }

        /// <inheritdoc/>
        public double Divide(double a, double b)
        {
            // trying to divide by 0
            if (b == 0) throw new System.DivideByZeroException("Trying to divide by 0.");
            
            return a / b;
        }

        /// <inheritdoc/>
        public decimal Divide(decimal a, decimal b)
        {
            // trying to divide by 0
            if (b == 0) throw new System.DivideByZeroException("Trying to divide by 0.");
            
            return a / b;
        }

        /// <inheritdoc/>
        public uint Factorial(uint a)
        {
            uint fact = 1;
            for (var i = a; i > 1; i--)
            {
                fact *= i;
            }
            
            return fact;
        }

        /// <inheritdoc/>
        public int Power(int a, uint exp)
        {
            if (exp == 0) // valid even for 0 to the power of 0 (0^0)
            {
                return 1;
            }
            
            var pow = a;
            while (exp > 1)
            {
                pow *= a;
                exp--;
            }

            return pow;
        }

        /// <inheritdoc/>
        public double Power(double a, uint exp)
        {
            if (exp == 0) // valid even for 0 to the power of 0 (0^0)
            {
                return 1;
            }
            
            var pow = a;
            while (exp > 1)
            {
                pow *= a;
                exp--;
            }

            return pow;
        }

        /// <inheritdoc/>
        public decimal Power(decimal a, uint exp)
        {
            if (exp == 0) // valid even for 0 to the power of 0 (0^0)
            {
                return 1;
            }
            
            var pow = a;
            while (exp > 1)
            {
                pow *= a;
                exp--;
            }

            return pow;
        }
        
        
        /// <inheritdoc/>
        public double Root(int a, uint n)
        {
            // The exception is thrown when the degree of the root is zero.
            if (n == 0) throw new System.ArgumentException("A degree of a root cannot be equal to 0.");
            
            // The exception is thrown if the degree of the root is even number and value of the base is less than zero.
            if (a < 0 && n % 2 == 0) throw new System.InvalidOperationException("Root operation with base value less than 0 and root being even number cannot be evaluated.");
            
            // valid arguments 
            if (a < 0 && n % 2 == 1)
            {
                return - Math.Pow(Math.Abs(a), 1.0 / n);    
            }
            return Math.Pow(a, 1.0 / n);
        }

        /// <inheritdoc/>
        public double Root(double a, uint n)
        {
            // The exception is thrown when the degree of the root is zero.
            if (n == 0) throw new System.ArgumentException("A degree of a root cannot be equal to 0.");
            
            // The exception is thrown if the degree of the root is even number and value of the base is less than zero.
            if (a < 0 && n % 2 == 0) throw new System.InvalidOperationException("Root operation with base value less than 0 and root being even number cannot be evaluated.");
            
            // valid arguments
            if (a < 0 && n % 2 == 1)
            {
                return - Math.Pow(Math.Abs(a), 1.0 / n);    
            }
            return Math.Pow(a, 1.0 / n);
        }

        /// <inheritdoc/>
        public decimal Root(decimal a, uint n)
        {
            // The exception is thrown when the degree of the root is zero.
            if (n == 0) throw new System.ArgumentException("A degree of a root cannot be equal to 0.");
            
            // The exception is thrown if the degree of the root is even number and value of the base is less than zero.
            if (a < 0 && n % 2 == 0) throw new System.InvalidOperationException("Root operation with base value less than 0 and root being even number cannot be evaluated.");
            
            // valid arguments
            if (a < 0 && n % 2 == 1)
            {
                return (decimal) - Math.Pow((double) Math.Abs(a), 1.0 / n);    
            }
            return (decimal) Math.Pow((double) a, 1.0 / n);
        }

        /// <inheritdoc/>
        public double Sin(double a)
        {
            return Math.Sin(a);
        }

        /// <inheritdoc/>
        public double Cos(double a)
        {
            return Math.Cos(a);
        }

        /// <inheritdoc/>
        public double Tan(double a)
        {
            const double eps = 1e-10d; //  acceptable epsilon for testing for undefined angles of tangent, where is better to throw exception than get a completely inaccurate result
            var isOdd = Math.Abs(a * 2 / Constants.Pi); // isOdd must be odd number in order to parameter a being equal to pi/2 + k*pi 
            if (Math.Abs(isOdd % 2 - 1) <= eps) throw new System.InvalidOperationException("Tangent is not defined in given angle equal to pi/2 + k * pi.");
            
            return Math.Tan(a);
        }

        /// <inheritdoc/>
        public double SolveExpression(string expression)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public static class Constants
    {
        /// <summary>
        /// Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.
        /// </summary>
        /// <remarks>
        /// Constant set to a value of System.Math.PI which is considered valid value for Pi number to be used in SunnyCalc calculations.
        /// </remarks>
        public const double Pi = System.Math.PI;
    }
}
