using System;
using NUnit.Framework;

namespace SunnyCalc.Maths.Tests
{
    [TestFixture]
    public class MathsServiceTests
    {
        private IMathsService _service;
        
        [SetUp]
        public void Setup()
        {
            _service = new MathsService();
        }

        [Test]
        public void IntegerAdd()
        {
            Assert.AreEqual(5, _service.Add(2, 3));
            Assert.AreEqual(1, _service.Add(-3, 4));
            Assert.AreEqual(-1, _service.Add(-4, 3));
            Assert.AreEqual(-5, _service.Add(-2, -3));

            Assert.AreEqual(5, _service.Add(5, 0));
            Assert.AreEqual(5, _service.Add(0, 5));

            Assert.AreEqual(130, _service.Add(80, 50));
            Assert.AreEqual(-130, _service.Add(-80, -50));
        }

        [Test]
        public void DoubleAdd()
        {
            Assert.AreEqual(5.0, _service.Add(2.5, 2.5), Double.Epsilon);
            Assert.AreEqual(4.8, _service.Add(2.3, 2.5), Double.Epsilon);
            Assert.AreEqual(0.5, _service.Add(-1.0, 1.5), Double.Epsilon);
            Assert.AreEqual(0.5, _service.Add(1.5, -1.0), Double.Epsilon);
            Assert.AreEqual(-0.5, _service.Add(-1.5, 1.0), Double.Epsilon);
            Assert.AreEqual(-0.5, _service.Add(1.0, -1.5), Double.Epsilon);

            Assert.AreEqual(-4.8, _service.Add(-2.5, -2.3), Double.Epsilon);
            Assert.AreEqual(-4.8, _service.Add(-2.3, -2.5), Double.Epsilon);

            Assert.AreEqual(42.42, _service.Add(42.42, 0), Double.Epsilon);
            Assert.AreEqual(42.42, _service.Add(0, 42.42), Double.Epsilon);
            Assert.AreEqual(-42.42, _service.Add(-42.42, 0), Double.Epsilon);
            Assert.AreEqual(-42.42, _service.Add(0, -42.42), Double.Epsilon);
        }

        [Test]
        public void DecimalAdd()
        {
            Assert.AreEqual(5.0m, _service.Add(2.5m, 2.5m));
            Assert.AreEqual(4.8m, _service.Add(2.3m, 2.5m));
            Assert.AreEqual(0.5m, _service.Add(-1.0m, 1.5m));
            Assert.AreEqual(0.5m, _service.Add(1.5m, -1.0m));
            Assert.AreEqual(-0.5m, _service.Add(-1.5m, 1.0m));
            Assert.AreEqual(-0.5m, _service.Add(1.0m, -1.5m));

            Assert.AreEqual(-4.8m, _service.Add(-2.5m, -2.3m));
            Assert.AreEqual(-4.8m, _service.Add(-2.3m, -2.5m));
            
            Assert.AreEqual(0.0000002m, _service.Add(0.0000001m, 0.0000001m));
            Assert.AreEqual(0.0000000002m, _service.Add(0.0000000001m, 0.0000000001m));

            Assert.AreEqual(42.42m, _service.Add(42.42m, 0m));
            Assert.AreEqual(42.42m, _service.Add(0m, 42.42m));
            Assert.AreEqual(-42.42m, _service.Add(-42.42m, 0m));
            Assert.AreEqual(-42.42m, _service.Add(0m, -42.42m));
        }

        [Test]
        public void IntegerSubtract()
        {
            Assert.AreEqual(5, _service.Subtract(9, 4));
            Assert.AreEqual(1, _service.Subtract(-3, -4));
            Assert.AreEqual(-7, _service.Subtract(-4, 3));
            Assert.AreEqual(7, _service.Subtract(3, -4));

            Assert.AreEqual(5, _service.Subtract(5, 0));
            Assert.AreEqual(-5, _service.Subtract(0, 5));

            Assert.AreEqual(30, _service.Subtract(80, 50));
            Assert.AreEqual(-30, _service.Subtract(-80, -50));
        }
        
        [Test]
        public void DoubleSubtract()
        {
            Assert.AreEqual(6.0, _service.Subtract(8.5, 2.5), Double.Epsilon);
            Assert.AreEqual(4.8, _service.Subtract(7.3, 2.5), Double.Epsilon);
            Assert.AreEqual(-2.5, _service.Subtract(-1.0, 1.5), Double.Epsilon);
            Assert.AreEqual(2.5, _service.Subtract(1.5, -1.0), Double.Epsilon);
            Assert.AreEqual(-2.5, _service.Subtract(-1.5, 1.0), Double.Epsilon);
            Assert.AreEqual(2.5, _service.Subtract(1.0, -1.5), Double.Epsilon);

            Assert.AreEqual(42.42, _service.Subtract(42.42, 0), Double.Epsilon);
            Assert.AreEqual(-42.42, _service.Subtract(0, 42.42), Double.Epsilon);
            Assert.AreEqual(-42.42, _service.Subtract(-42.42, 0), Double.Epsilon);
            Assert.AreEqual(42.42, _service.Subtract(0, -42.42), Double.Epsilon);
        }
        
        [Test] 
        public void DecimalSubtract()
        {
            Assert.AreEqual(6.0m, _service.Subtract(8.5m, 2.5m));
            Assert.AreEqual(4.8m, _service.Subtract(7.3m, 2.5m));
            Assert.AreEqual(-2.5m, _service.Subtract(-1.0m, 1.5m));
            Assert.AreEqual(2.5m, _service.Subtract(1.5m, -1.0m));
            Assert.AreEqual(-2.5m, _service.Subtract(-1.5m, 1.0m));
            Assert.AreEqual(2.5m, _service.Subtract(1.0m, -1.5m));
            
            Assert.AreEqual(0.0000002m, _service.Subtract(0.0000003m, 0.0000001m));
            Assert.AreEqual(0.0000000002m, _service.Subtract(0.0000000003m, 0.0000000001m));

            Assert.AreEqual(42.42m, _service.Subtract(42.42m, 0m));
            Assert.AreEqual(-42.42m, _service.Subtract(0m, 42.42m));
            Assert.AreEqual(-42.42m, _service.Subtract(-42.42m, 0));
            Assert.AreEqual(42.42m, _service.Subtract(0m, -42.42m));
        }

        [Test]
        public void IntegerMultiply()
        {
            Assert.AreEqual(5, _service.Multiply(5, 1));
            Assert.AreEqual(5, _service.Multiply(1, 5));
            Assert.AreEqual(20, _service.Multiply(4, 5));
            Assert.AreEqual(20, _service.Multiply(5, 4));

            Assert.AreEqual(-20, _service.Multiply(-4, 5));
            Assert.AreEqual(-20, _service.Multiply(-5, 4));
            Assert.AreEqual(20, _service.Multiply(-4, -5));
            Assert.AreEqual(20, _service.Multiply(-5, -4));

            Assert.AreEqual(0, _service.Multiply(42, 0));
            Assert.AreEqual(0, _service.Multiply(0, 42));
            Assert.AreEqual(0, _service.Multiply(0, -42));
            Assert.AreEqual(0, _service.Multiply(-42, 0));

            Assert.AreEqual(5, _service.Multiply(5, 1));
            Assert.AreEqual(5, _service.Multiply(1, 5));
            Assert.AreEqual(-5, _service.Multiply(-1, 5));
            Assert.AreEqual(-5, _service.Multiply(5, -1));
        }

        [Test]
        public void DoubleMultiply()
        {
            Assert.AreEqual(5.5, _service.Multiply(1.1, 5), Double.Epsilon);
            Assert.AreEqual(5.5, _service.Multiply(5, 1.1), Double.Epsilon);
            Assert.AreEqual(6.25, _service.Multiply(2.5, 2.5), Double.Epsilon);
            
            Assert.AreEqual(-5.5, _service.Multiply(1.1, -5), Double.Epsilon);
            Assert.AreEqual(-5.5, _service.Multiply(-5, 1.1), Double.Epsilon);
            Assert.AreEqual(5.5, _service.Multiply(-1.1, -5), Double.Epsilon);

            Assert.AreEqual(0, _service.Multiply(42.42, 0), Double.Epsilon);
            Assert.AreEqual(0, _service.Multiply(0, 42.42), Double.Epsilon);
            Assert.AreEqual(0, _service.Multiply(-42.42, 0), Double.Epsilon);
            Assert.AreEqual(0, _service.Multiply(0, -42.42), Double.Epsilon);

            Assert.AreEqual(42.42, _service.Multiply(1, 42.42), Double.Epsilon);
            Assert.AreEqual(42.42, _service.Multiply(42.42, 1), Double.Epsilon);
            Assert.AreEqual(-42.42, _service.Multiply(42.42, -1), Double.Epsilon);
            Assert.AreEqual(-42.42, _service.Multiply(-1, 42.42), Double.Epsilon);
        }
        
        [Test]
        public void DecimalMultiply()
        {
            Assert.AreEqual(5.5m, _service.Multiply(1.1m, 5m));
            Assert.AreEqual(5.5m, _service.Multiply(5m, 1.1m));
            Assert.AreEqual(6.25m, _service.Multiply(2.5m, 2.5m));
            
            Assert.AreEqual(-5.5m, _service.Multiply(1.1m, -5m));
            Assert.AreEqual(-5.5m, _service.Multiply(-5m, 1.1m));
            Assert.AreEqual(5.5m, _service.Multiply(-1.1m, -5m));
            
            Assert.AreEqual(0.000001m, _service.Multiply(0.001m, 0.001m));
            Assert.AreEqual(0.0000000001m, _service.Multiply(0.00001m, 0.00001m));

            Assert.AreEqual(0, _service.Multiply(42.42m, 0m));
            Assert.AreEqual(0, _service.Multiply(0m, 42.42m));
            Assert.AreEqual(0, _service.Multiply(-42.42m, 0m));
            Assert.AreEqual(0, _service.Multiply(0m, -42.42m));

            Assert.AreEqual(42.42m, _service.Multiply(1, 42.42m));
            Assert.AreEqual(42.42m, _service.Multiply(42.42m, 1m));
            Assert.AreEqual(-42.42m, _service.Multiply(42.42m, -1m));
            Assert.AreEqual(-42.42m, _service.Multiply(-1m, 42.42m));
        }

        [Test]
        public void IntegerDivide()
        {
            Assert.AreEqual(3, _service.Divide(6, 2));
            Assert.AreEqual(0, _service.Divide(2, 6));
            Assert.AreEqual(40, _service.Divide(120, 3));

            Assert.AreEqual(-3, _service.Divide(6, -2));
            Assert.AreEqual(-3, _service.Divide(-6, 2));
            Assert.AreEqual(3, _service.Divide(-6, -2));

            Assert.AreEqual(5, _service.Divide(5, 1));
            Assert.AreEqual(-5, _service.Divide(-5, 1));
            Assert.AreEqual(-5, _service.Divide(5, -1));
            Assert.AreEqual(5, _service.Divide(-5, -1));
            
            Assert.AreEqual(0, _service.Divide(0, 5));
            Assert.AreEqual(0, _service.Divide(0, -5));
            
            Assert.AreEqual(1, _service.Divide(5, 5));
            Assert.AreEqual(-1, _service.Divide(-5, 5));
            Assert.AreEqual(-1, _service.Divide(5, -5));
            Assert.AreEqual(1, _service.Divide(-5, -5));

            Assert.Throws<DivideByZeroException>(() => _service.Divide(5, 0));
            Assert.Throws<DivideByZeroException>(() => _service.Divide(-5, 0));
            Assert.Throws<DivideByZeroException>(() => _service.Divide(0, 0));
        }

        [Test]
        public void DoubleDivide()
        {
            Assert.AreEqual(1.1, _service.Divide(5.5, 5), Double.Epsilon);
            Assert.AreEqual(-1.1, _service.Divide(-5.5, 5), Double.Epsilon);
            Assert.AreEqual(-1.1, _service.Divide(5.5, -5), Double.Epsilon);
            Assert.AreEqual(1.1, _service.Divide(5.5, 5), Double.Epsilon);

            Assert.AreEqual(5.5, _service.Divide(5.5, 1), Double.Epsilon);
            Assert.AreEqual(-5.5, _service.Divide(5.5, -1), Double.Epsilon);
            Assert.AreEqual(-5.5, _service.Divide(-5.5, 1), Double.Epsilon);
            Assert.AreEqual(5.5, _service.Divide(-5.5, -1), Double.Epsilon);
            
            Assert.AreEqual(0, _service.Divide(0, 5.5), Double.Epsilon);
            Assert.AreEqual(0, _service.Divide(0, -5.5), Double.Epsilon);
            
            Assert.AreEqual(1, _service.Divide(5.5, 5.5), Double.Epsilon);
            Assert.AreEqual(-1, _service.Divide(-5.5, 5.5), Double.Epsilon);
            Assert.AreEqual(-1, _service.Divide(5.5, -5.5), Double.Epsilon);
            Assert.AreEqual(1, _service.Divide(-5.5, -5.5), Double.Epsilon);
            
            Assert.Throws<DivideByZeroException>(() => _service.Divide(5.5, 0));
            Assert.Throws<DivideByZeroException>(() => _service.Divide(-5.5, 0));
            Assert.Throws<DivideByZeroException>(() => _service.Divide(0.0, 0.0));
        }
        
        [Test]
        public void DecimalDivide()
        {
            Assert.AreEqual(1.1m, _service.Divide(5.5m, 5m));
            Assert.AreEqual(-1.1m, _service.Divide(-5.5m, 5m));
            Assert.AreEqual(-1.1m, _service.Divide(5.5m, -5m));
            Assert.AreEqual(1.1m, _service.Divide(5.5m, 5m));

            Assert.AreEqual(5.5m, _service.Divide(5.5m, 1m));
            Assert.AreEqual(-5.5m, _service.Divide(5.5m, -1m));
            Assert.AreEqual(-5.5m, _service.Divide(-5.5m, 1m));
            Assert.AreEqual(5.5m, _service.Divide(-5.5m, -1m));
            
            Assert.AreEqual(100000, _service.Divide(1m, 0.00001m));
            Assert.AreEqual(100000000, _service.Divide(1m, 0.00000001m));
            
            Assert.AreEqual(0, _service.Divide(0m, 5.5m));
            Assert.AreEqual(0, _service.Divide(0m, -5.5m));
            
            Assert.AreEqual(1m, _service.Divide(5.5m, 5.5m));
            Assert.AreEqual(-1m, _service.Divide(-5.5m, 5.5m));
            Assert.AreEqual(-1m, _service.Divide(5.5m, -5.5m));
            Assert.AreEqual(1m, _service.Divide(-5.5m, -5.5m));
            
            Assert.Throws<DivideByZeroException>(() => _service.Divide(5.5m, 0m));
            Assert.Throws<DivideByZeroException>(() => _service.Divide(-5.5m, 0m));
            Assert.Throws<DivideByZeroException>(() => _service.Divide(0m, 0m));
        }

        [Test]
        public void Factorial()
        {
            Assert.AreEqual(120, _service.Factorial(5));
            Assert.AreEqual(1, _service.Factorial(0));
            Assert.AreEqual(2, _service.Factorial(2));
            Assert.AreEqual(3628800 , _service.Factorial(10));
            
            // On most systems this would result in Stack Overflow if Factorial was implemented using
            // recursion. But at the same time it's not going to slow down the tests.
            _service.Factorial(1000000);
        }

        [Test]
        public void IntegerPower()
        {
            Assert.AreEqual(1, _service.Power(5, 0));
            Assert.AreEqual(5, _service.Power(5, 1));
            Assert.AreEqual(125, _service.Power(5, 3));
            Assert.AreEqual(3111696, _service.Power(42, 4));
        }

        [Test]
        public void DoublePower()
        {
            Assert.AreEqual(2.5, _service.Power(2.5, 1), Double.Epsilon);
            Assert.AreEqual(1, _service.Power(2.5, 0), Double.Epsilon);
            Assert.AreEqual(6.25, _service.Power(2.5, 2), Double.Epsilon);
            Assert.AreEqual(3262539.0625, _service.Power(42.5, 4), Double.Epsilon);
        }
        
        [Test]
        public void DecimalPower()
        {
            Assert.AreEqual(2.5m, _service.Power(2.5m, 1));
            Assert.AreEqual(1m, _service.Power(2.5m, 0));
            Assert.AreEqual(6.25m, _service.Power(2.5m, 2));
            Assert.AreEqual(3262539.0625m, _service.Power(42.5m, 4));
        }

        [Test]
        public void IntegerRoot()
        {
            Assert.AreEqual(2, _service.Root(4, 2), 1e-10);
            Assert.AreEqual(4, _service.Root(4, 1), 1e-10);
            Assert.AreEqual(5, _service.Root(125, 3), 1e-10);
            Assert.AreEqual(-3, _service.Root(-27, 3), 1e-10);
            Assert.AreEqual(1.41421356, _service.Root(2, 2), 1e-5);
            
            Assert.Throws<InvalidOperationException>(() => _service.Root(-5, 2));
            Assert.Throws<InvalidOperationException>(() => _service.Root(-42, 4));
            
            Assert.Throws<ArgumentException>(() => _service.Root(5, 0));
            Assert.Throws<ArgumentException>(() => _service.Root(-5, 0));
        }

        [Test]
        public void DoubleRoot()
        {
            Assert.AreEqual(2.5, _service.Root(6.25, 2), 1e-10);
            Assert.AreEqual(2.5, _service.Root(2.5, 1), 1e-10);
            Assert.AreEqual(2.5, _service.Root(15.625, 3), 1e-10);
            Assert.AreEqual(-2.5, _service.Root(-15.625, 3), 1e-10);
            
            Assert.Throws<InvalidOperationException>(() => _service.Root(-5.5, 2));
            Assert.Throws<InvalidOperationException>(() => _service.Root(-5.5, 4));
            
            Assert.Throws<ArgumentException>(() => _service.Root(5.5, 0));
            Assert.Throws<ArgumentException>(() => _service.Root(-5.5, 0));
        }
        
        [Test]
        public void DecimalRoot()
        {
            Assert.AreEqual(2.5m, _service.Root(6.25m, 2));
            Assert.AreEqual(2.5m, _service.Root(2.5m, 1));
            Assert.AreEqual(2.5m, _service.Root(15.625m, 3));
            Assert.AreEqual(-2.5m, _service.Root(-15.625m, 3));
            
            Assert.Throws<InvalidOperationException>(() => _service.Root(-5.5m, 2));
            Assert.Throws<InvalidOperationException>(() => _service.Root(-5.5m, 4));
            
            Assert.Throws<ArgumentException>(() => _service.Root(5.5m, 0));
            Assert.Throws<ArgumentException>(() => _service.Root(-5.5m, 0));
        }

        [Test]
        public void Sin()
        {
            // Trigonometric calculations are imprecise, check only a few decimals.
            Assert.AreEqual(0, _service.Sin(0), 1e-10);
            Assert.AreEqual(0.5, _service.Sin(Math.PI/6), 1e-10);
            Assert.AreEqual(Math.Sqrt(2)/2, _service.Sin(Math.PI/4), 1e-10);
            Assert.AreEqual(Math.Sqrt(3)/2, _service.Sin(Math.PI/3), 1e-10);
            Assert.AreEqual(1, _service.Sin(Math.PI / 2), 1e-10);
            Assert.AreEqual(0, _service.Sin(Math.PI), 1e-10);
            Assert.AreEqual(-1, _service.Sin(3 * Math.PI/2), 1e-10);
            Assert.AreEqual(0, _service.Sin(2 * Math.PI), 1e-10);
        }
        
        [Test]
        public void Cos()
        {
            // Trigonometric calculations are imprecise, check only a few decimals.
            Assert.AreEqual(1, _service.Cos(0), 1e-10);
            Assert.AreEqual(Math.Sqrt(3)/2, _service.Cos(Math.PI/6), 1e-10);
            Assert.AreEqual(Math.Sqrt(2)/2, _service.Cos(Math.PI/4), 1e-10);
            Assert.AreEqual(0.5, _service.Cos(Math.PI/3), 1e-10);
            Assert.AreEqual(0, _service.Cos(Math.PI / 2), 1e-10);
            Assert.AreEqual(-1, _service.Cos(Math.PI), 1e-10);
            Assert.AreEqual(0, _service.Cos(3 * Math.PI/2), 1e-10);
            Assert.AreEqual(1, _service.Cos(2 * Math.PI), 1e-10);
        }
        
        [Test]
        public void Tan()
        {
            // Trigonometric calculations are imprecise, check only a few decimals.
            Assert.AreEqual(0, _service.Tan(0), 1e-10);
            Assert.AreEqual(Math.Sqrt(3)/3, _service.Tan(Math.PI/6), 1e-10);
            Assert.AreEqual(1, _service.Tan(Math.PI/4), 1e-10);
            Assert.AreEqual(Math.Sqrt(3), _service.Tan(Math.PI/3), 1e-10);
            Assert.AreEqual(0, _service.Tan(Math.PI), 1e-10);
            Assert.AreEqual(0, _service.Tan(2 * Math.PI), 1e-10);

            Assert.Throws<InvalidOperationException>(() => _service.Tan(Math.PI / 2));
            Assert.Throws<InvalidOperationException>(() => _service.Tan(3 * Math.PI / 2));
            Assert.Throws<InvalidOperationException>(() => _service.Tan(-Math.PI / 2));
            Assert.Throws<InvalidOperationException>(() => _service.Tan(-3 * Math.PI / 2));
        }

        [Test]
        public void SolveExpressionSimpleArithmetic()
        {
            // Check whitespace handling
            Assert.AreEqual(10, _service.SolveExpression("5 + 5"));
            Assert.AreEqual(10, _service.SolveExpression("5+ 5"));
            Assert.AreEqual(10, _service.SolveExpression("5 +5"));
            Assert.AreEqual(10, _service.SolveExpression("5+5"));
            
            // Check single operand expression
            Assert.AreEqual(-5, _service.SolveExpression(" -5"));
            Assert.AreEqual(5, _service.SolveExpression(" +5"));

            // Check all operations
            // Add
            Assert.AreEqual(6, _service.SolveExpression("3+3"));
            Assert.AreEqual(9, _service.SolveExpression("3 + 3+ 3"));
            Assert.AreEqual(0, _service.SolveExpression("-3 + 3"));
            Assert.AreEqual(7.5, _service.SolveExpression("5+2.5"), Double.Epsilon);
            
            // Subtract
            Assert.AreEqual(3, _service.SolveExpression("6-3"));
            Assert.AreEqual(3, _service.SolveExpression("6-2-1"));
            Assert.AreEqual(0, _service.SolveExpression("-3 - -3"));
            Assert.AreEqual(2.5, _service.SolveExpression("5-2.5"), Double.Epsilon);
            
            // Multiply
            Assert.AreEqual(9, _service.SolveExpression("3*3"));
            Assert.AreEqual(27, _service.SolveExpression("3*3*3"));
            Assert.AreEqual(-9, _service.SolveExpression("-3 * 3"));
            Assert.AreEqual(9, _service.SolveExpression("-3 * -3"));
            Assert.AreEqual(6.25, _service.SolveExpression("2.5 * 2.5"), Double.Epsilon);
            
            // Divide
            Assert.AreEqual(3, _service.SolveExpression("9/3"));
            Assert.AreEqual(-3, _service.SolveExpression("-9/3"));
            Assert.AreEqual(-3, _service.SolveExpression("9/-3"));
            Assert.AreEqual(3, _service.SolveExpression("-9/-3"));
            Assert.AreEqual(2.5, _service.SolveExpression("6.25 / 2.5"), Double.Epsilon);
        }

        [Test]
        public void SolveExpressionAdvancedOperations()
        {
            // Factorial
            Assert.AreEqual(120, _service.SolveExpression("5!"));
            Assert.AreEqual(-120, _service.SolveExpression("-5!"));
            Assert.AreEqual(1, _service.SolveExpression("0!"));
            
            // Power
            Assert.AreEqual(4, _service.SolveExpression("2^2"));
            Assert.AreEqual(4, _service.SolveExpression("(-2)^2"));
            Assert.AreEqual(-4, _service.SolveExpression("-2^2"));
            Assert.AreEqual(6.25, _service.SolveExpression("2.5^2"), Double.Epsilon);
            
            // Square root
            Assert.AreEqual(4, _service.SolveExpression("sqrt(16)"));
            Assert.AreEqual(2.5, _service.SolveExpression("sqrt(6.25)"), Double.Epsilon);
            
            // Root
            Assert.AreEqual(4, _service.SolveExpression("rt(16, 2)"));
            Assert.AreEqual(-3, _service.SolveExpression("rt(-27, 3)"));
            Assert.AreEqual(2.5, _service.SolveExpression("rt(6.25, 2)"), Double.Epsilon);

            // Trigonometry
            Assert.AreEqual(0, _service.SolveExpression("sin(0)"), 1e-10);
            Assert.AreEqual(1, _service.SolveExpression("sin(pi/2)"), 1e-10);
            Assert.AreEqual(1, _service.SolveExpression("cos(0)"), 1e-10);
            Assert.AreEqual(-1, _service.SolveExpression("cos(pi)"), 1e-10);
            Assert.AreEqual(0, _service.SolveExpression("tan(0)"), 1e-10);
            Assert.AreEqual(0, _service.SolveExpression("tan(pi)"), 1e-10);
            Assert.AreEqual(1, _service.SolveExpression("tan(pi/4)"), 1e-10);
            
        }

        [Test]
        public void SolveExpressionTrigonometry()
        {
            Assert.AreEqual(0, _service.SolveExpression("sin(0)"), 1e-10);
            Assert.AreEqual(1, _service.SolveExpression("sin(pi/2)"), 1e-10);
            Assert.AreEqual(1, _service.SolveExpression("cos(0)"), 1e-10);
            Assert.AreEqual(-1, _service.SolveExpression("cos(pi)"), 1e-10);
            Assert.AreEqual(0, _service.SolveExpression("tan(0)"), 1e-10);
            Assert.AreEqual(0, _service.SolveExpression("tan(pi)"), 1e-10);
            Assert.AreEqual(1, _service.SolveExpression("tan(pi/4 + 0)"), 1e-10);
        }
        
        [Test]
        public void SolveExpressionSquareRootNRoot()
        {
             // Square root
            Assert.AreEqual(4, _service.SolveExpression("sqrt(14+2)"));
            Assert.AreEqual(2.5, _service.SolveExpression("sqrt(6.25)"), Double.Epsilon);
            Assert.AreEqual(6, _service.SolveExpression("2 + sqrt(14+2)"));
                
            // Root
            Assert.AreEqual(4, _service.SolveExpression("rt(16, 2)"));
            Assert.AreEqual(-3, _service.SolveExpression("rt(-27, 3)"));
            Assert.AreEqual(2.5, _service.SolveExpression("rt(6.25, 2)"), Double.Epsilon);
        }

        [Test]
        public void SolveExpressionParenthesis()
        {
            Assert.AreEqual(4, _service.SolveExpression("(3+1)"));
            Assert.AreEqual(-4, _service.SolveExpression("-(4)"));
            Assert.AreEqual(-16, _service.SolveExpression("-(2^4)"));
            Assert.AreEqual(-6, _service.SolveExpression("-(2+4)"));
            
            Assert.AreEqual(25, _service.SolveExpression("5 * (3 + 2)"));
            Assert.AreEqual(2, _service.SolveExpression("10 / (3 + 2)"));
            Assert.AreEqual(25, _service.SolveExpression("(3+2) * (2 + 3)"));
            Assert.AreEqual(1, _service.SolveExpression("(3+2) / (2+ 3)"));
            
            Assert.AreEqual(5, _service.SolveExpression("(((((5)))))"));
            Assert.AreEqual(25, _service.SolveExpression("(((((5) * (2+3)))))"));
            Assert.AreEqual(5, _service.SolveExpression("(((2 + 3) / (2+3)) * 5)"));
            Assert.AreEqual(5, _service.SolveExpression("rt(5 * 5, 2)")); 
            Assert.AreEqual(5, _service.SolveExpression("rt(5 * (2 + 3), 2"));
            
            Assert.AreEqual(120, _service.SolveExpression("(2 + 3)!"));
            Assert.AreEqual(5, _service.SolveExpression("5 * (sin(2 * pi) + cos(2 * pi))"), 1e-10);
            Assert.AreEqual(100000, _service.SolveExpression("10 * (10 * (10 * (10 * (5 + 5))))"));
        }

        [Test]
        public void SolveExpressionPrecedence()
        {
            // Simple operations
            Assert.AreEqual(20, _service.SolveExpression("5 + 5 * 3"));
            Assert.AreEqual(28, _service.SolveExpression("5 * 5 + 3"));
            
            Assert.AreEqual(-10, _service.SolveExpression("5 - 5 * 3"));
            Assert.AreEqual(22, _service.SolveExpression("5 * 5 - 3"));
            
            Assert.AreEqual(4, _service.SolveExpression("5 /5 + 3"));
            Assert.AreEqual(8, _service.SolveExpression("4 + 20/5"));
            Assert.AreEqual(5, _service.SolveExpression("5 * 5 / 5"));
            
            Assert.AreEqual(34, _service.SolveExpression("3 * 3 + 5 * 5"));
            Assert.AreEqual(2, _service.SolveExpression("3 /3 + 5 / 5"));
            
            // Advanced operations
            
            Assert.AreEqual(125, _service.SolveExpression("5 + 5!"));
            Assert.AreEqual(125, _service.SolveExpression("5 * 5^2"));
            Assert.AreEqual(25, _service.SolveExpression("5 * rt(25, 2)"));
            Assert.AreEqual(5, _service.SolveExpression("sqrt(5 * 5)"));
            Assert.AreEqual(5, _service.SolveExpression("rt(5 * 5, 2)"));
        }

        [Test]
        public void SolveExpressionInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => _service.SolveExpression(null));
            Assert.Throws<ArgumentException>(() => _service.SolveExpression(""));
            Assert.Throws<ArgumentException>(() => _service.SolveExpression("  "));

            // Incomplete expressions
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("5 +"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("5 -"));
            
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("5 *"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("*5"));
            
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("5 /"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("5 ^ "));
            
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("!"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("!5"));
                
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("sqrt()"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("rt(5)"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("rt(,2)"));
            
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("sin()"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("cos()"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("tan()"));

            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("(5))"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("((5)"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("(((((5))))"));
            Assert.Throws<ExpressionSolvingException>(() => _service.SolveExpression("(((((5))))))))"));

            // Invalid operations
            Assert.Throws<DivideByZeroException>(() => _service.SolveExpression("5/0"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("sqrt(-2)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("rt(-2, 2)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("rt(-2, 4)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("rt(2, -4)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("rt(2, -4.5)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("rt(2, 4.5)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("(-1)!"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("0.5!"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("(-0.5)!"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("tan(pi/2)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("tan(5*pi/2)"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("tan((-3)*pi/2)"));
        }

        [Test]
        public void SolveExpressionUnaryMinus()
        {
            // unary minus and parenthesis
            Assert.AreEqual(-3, _service.SolveExpression("-3"));
            Assert.AreEqual(3, _service.SolveExpression("--3"));
            Assert.AreEqual(-3, _service.SolveExpression("-(3+5) + 5"));
            Assert.AreEqual(-4, _service.SolveExpression("-2^2"));
            Assert.AreEqual(-4, _service.SolveExpression("-(2)^2"));
            Assert.AreEqual(-4, _service.SolveExpression("-(2^2)"));
            Assert.AreEqual(4, _service.SolveExpression("(-2)^2"));
            Assert.AreEqual(-4, _service.SolveExpression("-(-2)^2"));
            Assert.AreEqual(9, _service.SolveExpression("-3 * -3"));
            Assert.AreEqual(-9, _service.SolveExpression("--3 * -3"));
            Assert.AreEqual(9, _service.SolveExpression("(-3) * (-3)"));
            Assert.AreEqual(9, _service.SolveExpression("-(3 * -3)"));
            
            // unary minus with factorial
            Assert.AreEqual(-6, _service.SolveExpression("-3!"));
            Assert.Throws<InvalidOperationException>(() => _service.SolveExpression("(-5)!"));
        }
    }
}
