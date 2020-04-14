using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyCalc.Maths
{
    public class ExpressionSolvingException : Exception
    {
        public string Expression { get; }

        public ExpressionSolvingException(string expression, string message = "The expression couldn't be solved.") :
            base(message)
        {
            this.Expression = expression;
        }

        public ExpressionSolvingException(string expression, Exception innerException,
            string message = "The expression couldn't be solved.") : base(message, innerException)
        {
            this.Expression = expression;
        }
    }
}
