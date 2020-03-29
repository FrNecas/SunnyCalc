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
        int Add(int a, int b);
        /// <summary>
        /// Calculates the sum of two real numbers represented as <see cref="System.Double"/> (<paramref name="a"/> + <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> + <paramref name="b"/>).</returns>
        double Add(double a, double b);
        /// <summary>
        /// Calculates the sum of two real numbers represented as <see cref="System.Decimal"/> (<paramref name="a"/> + <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> + <paramref name="b"/>).</returns>
        decimal Add(decimal a, decimal b);

        /// <summary>
        /// Calculates the difference of two integers (<paramref name="a"/> - <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The difference of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> - <paramref name="b"/>).</returns>
        int Subtract(int a, int b);
        /// <summary>
        /// Calculates the difference of two real numbers represented as <see cref="System.Double"/> (<paramref name="a"/> - <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The difference of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> - <paramref name="b"/>).</returns>
        double Subtract(double a, double b);
        /// <summary>
        /// Calculates the difference of two real numbers represented as <see cref="System.Decimal"/> (<paramref name="a"/> - <paramref name="b"/>).
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The difference of <paramref name="a"/> and <paramref name="b"/> (<paramref name="a"/> - <paramref name="b"/>).</returns>
        decimal Subtract(decimal a, decimal b);

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
        /// <remarks>Precision only up to 1e-5 can be guaranteed for any number, however for calculations yielding integer values, the precision can be much better.</remarks>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="n">The degree of the root. Must not be zero.</param>
        /// <exception cref="InvalidOperationException">Thrown when the value of <paramref name="a"/> is less than zero and <paramref name="n"/> is even.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="n"/> is zero.</exception>
        /// <returns>The <paramref name="exp"/>-th root of <paramref name="a"/>, a real number represented as <see cref="System.Double"/>.</returns>
        double Root(int a, uint n);
        /// <summary>
        /// Calculates the <paramref name="exp"/>-th root of the real number <paramref name="a"/> represented as <see cref="System.Double"/>.
        /// </summary>
        /// <remarks>The n-th root of a number x, when n is a positive integer, is a number r which, when raised to the power n, yields the number x.</remarks>
        /// <remarks>Precision only up to 1e-5 can be guaranteed for any number, however for calculations yielding integer values, the precision can be much better.</remarks>
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
        /// <remarks>Precision only up to 1e-5 can be guaranteed for any number, however for calculations yielding integer values, the precision can be much better.</remarks>
        /// <param name="a">The base of exponentiation.</param>
        /// <param name="n">The degree of the root. Must not be zero.</param>
        /// <exception cref="InvalidOperationException">Thrown when the value of <paramref name="a"/> is less than zero and <paramref name="n"/> is even.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="n"/> is zero.</exception>
        /// <returns>The <paramref name="exp"/>-th root of <paramref name="a"/>, a real number represented as <see cref="System.Decimal"/>.</returns>
        decimal Root(decimal a, uint n);

        /// <summary>
        /// Calculates the sine of <paramref name="a"/> given in radians.
        /// </summary>
        /// <remarks>
        /// The implementations should return accurate values when the value of the <see cref="SunnyCalc.Maths.Constants.Pi"/> constant is passed.
        /// Otherwise precision of 1e-10 can be expected.
        /// </remarks>
        /// <param name="a">The argument of sine.</param>
        /// <returns>The result of sin(<paramref name="a"/>).</returns>
        double Sin(double a);

        /// <summary>
        /// Calculates the cosine of <paramref name="a"/> given in radians.
        /// </summary>
        /// <remarks>
        /// The implementations should return accurate values when the value of the <see cref="SunnyCalc.Maths.Constants.Pi"/> constant is passed.
        /// Otherwise precision of 1e-10 can be expected.
        /// </remarks>
        /// <param name="a">The argument of cosine.</param>
        /// <returns>The result of cos(<paramref name="a"/>).</returns>
        double Cos(double a);

        /// <summary>
        /// Calculates the tangent of <paramref name="a"/> given in radians.
        /// </summary>
        /// <remarks>
        /// The implementations should return accurate values when the value of the <see cref="SunnyCalc.Maths.Constants.Pi"/> constant is passed.
        /// Otherwise precision of 1e-10 can be expected.
        /// </remarks>
        /// <param name="a">The argument of tangent.</param>
        /// <exception cref="InvalidOperationException">Thrown when <paramref name="a"/> is equal to pi/2 + k * pi.</exception>
        /// <returns>The result of tan(<paramref name="a"/>).</returns>
        double Tan(double a);

        /// <summary>
        /// Solves a mathematical expression.
        /// </summary>
        /// <remarks>
        /// The expression may contain the following symbols: +,-,*,/,(,),^,sqrt,rt,sin,cos,tan,pi.
        /// Whitespaces are ignored.
        /// The "pi" symbol will be interpreted as the value of <see cref="SunnyCalc.Maths.Constants.Pi"/>.
        /// The precision may vary depending on the operations used.
        /// </remarks>
        /// <param name="expression">The expression to solve.</param>
        /// <exception cref="ArgumentException">Thrown when the expression is null or an empty string.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the expression contains an invalid operation (e.g. sqrt of a negative number).</exception>
        /// <exception cref="ExpressionSolvingException">Thrown when the expression cannot be solved.</exception>
        /// <returns>The value of the expression.</returns>
        double SolveExpression(string expression);
    }
}
