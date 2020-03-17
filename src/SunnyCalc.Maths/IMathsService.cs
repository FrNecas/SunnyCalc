using System;

namespace SunnyCalc.Maths
{
    public interface IMathsService
    {
        /// <summary>
        /// Calculates the sum of two integers (<paramref name="a"/> + <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> + <paramref name="b"/>).</returns>
        int Sum(int a, int b);
        /// <summary>
        /// Calculates the sum of two real numbers represented as <see cref="System.Double"/> (<paramref name="a"/> + <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> + <paramref name="b"/>).</returns>
        double Sum(double a, double b);
        /// <summary>
        /// Calculates the sum of two real numbers represented as <see cref="System.Decimal"/> (<paramref name="a"/> + <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> + <paramref name="b"/>).</returns>
        decimal Sum(decimal a, decimal b);

        /// <summary>
        /// Calculates the difference of two integers (<paramref name="a"/> - <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The difference of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> - <paramref name="b"/>).</returns>
        int Difference(int a, int b);
        /// <summary>
        /// Calculates the difference of two real numbers represented as <see cref="System.Double"/> (<paramref name="a"/> - <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The difference of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> - <paramref name="b"/>).</returns>
        double Difference(double a, double b);
        /// <summary>
        /// Calculates the difference of two real numbers represented as <see cref="System.Decimal"/> (<paramref name="a"/> - <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The difference of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> - <paramref name="b"/>).</returns>
        decimal Difference(decimal a, decimal b);

        /// <summary>
        /// Calculates the product of two integers (<paramref name="a"/> * <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The product of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> * <paramref name="b"/>).</returns>
        int Multiply(int a, int b);
        /// <summary>
        /// Calculates the product of two real numbers represented as <see cref="System.Double"/> (<paramref name="a"/> * <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The product of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> * <paramref name="b"/>).</returns>
        double Multiply(double a, double b);
        /// <summary>
        /// Calculates the product of two real numbers represented as <see cref="System.Decimal"/> (<paramref name="a"/> * <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The product of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> * <paramref name="b"/>).</returns>
        decimal Multiply(decimal a, decimal b);

        /// <summary>
        /// Calculates the integer quotient of two integers (<paramref name="a"/> / <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand (the dividend).</param>
        /// <param name="b">The second operand (the divisor). Must not be zero.</param>
        /// <exception cref="System.DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        /// <returns>The integer quotient of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> / <paramref name="b"/>).</returns>
        int Divide(int a, int b);
        /// <summary>
        /// Calculates the decimal fraction of two real numbers represented as <see cref="System.Double"/> (<paramref name="a"/> / <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand (the dividend).</param>
        /// <param name="b">The second operand (the divisor). Must not be zero.</param>
        /// <exception cref="System.DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        /// <returns>The integer quotient of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> / <paramref name="b"/>).</returns>
        double Divide(double a, double b);
        /// <summary>
        /// Calculates the decimal fraction of two real numbers represented as <see cref="System.Decimal"/> (<paramref name="a"/> / <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand (the dividend).</param>
        /// <param name="b">The second operand (the divisor). Must not be zero.</param>
        /// <exception cref="System.DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        /// <returns>The decimal fraction of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> / <paramref name="b"/>).</returns>
        decimal Divide(decimal a, decimal b);

        /// <summary>
        /// Calculates the factorial of a positive integer <paramref name="a"/>.
        /// </summary>
        /// <remarks>A factorial is the product of all positive integers less than or equal to the operand.</remarks>
        /// <param name="a">The integer to calculate factorial for.</param>
        /// <returns>The factorial of <paramref name="a"/>. One if <paramref name="a"/> is zero.</returns>
        uint Factorial(uint a);

        /// <summary>
        /// Calculates the <paramref name="exp"/>-th power of the integer <paramref name="a"/>.
        /// </summary>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="exp">The exponent.</param>
        /// <returns>The <paramref name="exp"/>-th power of <paramref name="a"/>.</returns>
        int Power(int a, uint exp);
        /// <summary>
        /// Calculates the <paramref name="exp"/>-th power of the real number <paramref name="a"/> represented as <see cref="System.Double"/>.
        /// </summary>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="exp">The exponent.</param>
        /// <returns>The <paramref name="exp"/>-th power of <paramref name="a"/>.</returns>
        double Power(double a, uint exp);
        /// <summary>
        /// Calculates the <paramref name="exp"/>-th power of the real number <paramref name="a"/> represented as <see cref="System.Decimal"/>.
        /// </summary>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="exp">The exponent.</param>
        /// <returns>The <paramref name="exp"/>-th power of <paramref name="a"/>.</returns>
        decimal Power(decimal a, uint exp);

        /// <summary>
        /// Calculates the <paramref name="exp"/>-th root of the integer <paramref name="a"/>.
        /// </summary>
        /// <remarks>The n-th root of a number x, when n is a positive integer, is a number r which, when raised to the power n, yields the number x.</remarks>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="n">The degree of the root. Must not be zero.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="n"/> is zero.</exception>
        /// <returns>The <paramref name="exp"/>-th root of <paramref name="a"/>, a real number represented as <see cref="System.Double"/>.</returns>
        double Root(int a, uint n);
        /// <summary>
        /// Calculates the <paramref name="exp"/>-th root of the real number <paramref name="a"/> represented as <see cref="System.Double"/>.
        /// </summary>
        /// <remarks>The n-th root of a number x, when n is a positive integer, is a number r which, when raised to the power n, yields the number x.</remarks>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="n">The degree of the root. Must not be zero.</param>
        /// <exception cref="InvalidOperationException">Thrown when the value of <paramref name="a"/> is less than zero and <paramref name="n"/> is even.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="n"/> is zero.</exception>
        /// <returns>The <paramref name="exp"/>-th root of <paramref name="a"/>, a real number represented as <see cref="System.Double"/>.</returns>
        double Root(double a, uint n);
        /// <summary>
        /// Calculates the <paramref name="exp"/>-th root of the real number <paramref name="a"/> represented as <see cref="System.Decimal"/>.
        /// </summary>
        /// <remarks>The n-th root of a number x, when n is a positive integer, is a number r which, when raised to the power n, yields the number x.</remarks>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="n">The degree of the root. Must not be zero.</param>
        /// <exception cref="InvalidOperationException">Thrown when the value of <paramref name="a"/> is less than zero and <paramref name="n"/> is even.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="n"/> is zero.</exception>
        /// <returns>The <paramref name="exp"/>-th root of <paramref name="a"/>, a real number represented as <see cref="System.Decimal"/>.</returns>
        decimal Root(decimal a, uint n);

        /// <summary>
        /// Solves a mathematical expression.
        /// </summary>
        /// <remarks>
        /// The expression may contain the following symbols: +,-,*,/,(,),^,sqrt,sin,cos,tan.
        /// Whitespaces are ignored.
        /// </remarks>
        /// <param name="expression">The expression to solve.</param>
        /// <returns>The value of the expression.</returns>
        double SolveExpression(string expression);
    }
}
