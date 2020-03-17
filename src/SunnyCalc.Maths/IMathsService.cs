using System;

namespace SunnyCalc.Maths
{
    public interface IMathsService
    {
        int Sum(int a, int b);
        double Sum(double a, double b);
        decimal Sum(decimal a, decimal b);
        
        int Difference(int a, int b);
        double Difference(double a, double b);
        decimal Difference(decimal a, decimal b);

        int Multiply(int a, int b);
        double Multiply(double a, double b);
        decimal Multiply(decimal a, decimal b);
        
        int Divide(int a, int b);
        double Divide(double a, double b);
        decimal Divide(decimal a, decimal b);

        int Factorial(int a);

        int Power(int a, uint exp);
        double Power(double a, uint exp);
        decimal Power(decimal a, uint exp);

        double Root(int a, uint n);
        double Root(double a, uint n);
        decimal Root(decimal a, uint n);

        double SolveExpression(string expression);
    }
}
