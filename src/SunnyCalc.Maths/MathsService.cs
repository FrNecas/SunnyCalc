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
            if (b.Equals(0)) throw new System.DivideByZeroException("Trying to divide by 0.");
            
            return a / b;
        }

        /// <inheritdoc/>
        public double Divide(double a, double b)
        {
            // trying to divide by 0
            if (b.Equals(0)) throw new System.DivideByZeroException("Trying to divide by 0.");
            
            return a / b;
        }

        /// <inheritdoc/>
        public decimal Divide(decimal a, decimal b)
        {
            // trying to divide by 0
            if (b.Equals(0)) throw new System.DivideByZeroException("Trying to divide by 0.");
            
            return a / b;
        }

        /// <inheritdoc/>
        public uint Factorial(uint a)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public int Power(int a, uint exp)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public double Power(double a, uint exp)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public decimal Power(decimal a, uint exp)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public double Root(int a, uint n)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public double Root(double a, uint n)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public decimal Root(decimal a, uint n)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public double Sin(double a)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public double Cos(double a)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public double Tan(double a)
        {
            throw new System.NotImplementedException();
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
