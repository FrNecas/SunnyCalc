using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyCalc.Maths
{
    public class ExpressionSolvingException : Exception
    {
        public string Expression { get; }

        public ExpressionSolvingException(string expression) : base("The expression couldn't be solved.")
        {
            Expression = expression;
        }

        public ExpressionSolvingException(string expression, Exception innerException) : base("The expression couldn't be solved.", innerException)
        {
            Expression = expression;
        }
    }
}
