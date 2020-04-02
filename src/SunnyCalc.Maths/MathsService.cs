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

        //===========================================================================
        // SolveExpression() method and supporting members

        private class Operator
        {
            public string Name { get; set; }
            public string Notation { get; set; }
            public int Precedence { get; set; }
            public bool RightAssociative { get; set; }
            public int Operands { get; set; }
        }

        private readonly Dictionary<string, MathsService.Operator> _operatorsDict = new Dictionary<string, MathsService.Operator>
        {
            ["+"] = new MathsService.Operator { Name = "Add", Notation = "+", Precedence = 1, RightAssociative = false, Operands = 2, },
            ["-"] = new MathsService.Operator { Name = "Subtract", Notation = "-", Precedence = 1, RightAssociative = false, Operands = 2,  },
            ["*"] = new MathsService.Operator { Name = "Multiply", Notation = "*", Precedence = 2, RightAssociative = false, Operands = 2,  },
            ["/"] = new MathsService.Operator { Name = "Divide", Notation = "/", Precedence = 2, RightAssociative = false, Operands = 2,  },
            ["^"] = new MathsService.Operator { Name = "Power", Notation = "^", Precedence = 4, RightAssociative = true, Operands = 2, },
            ["!"] = new MathsService.Operator { Name = "Factorial", Notation = "!", Precedence = 5, RightAssociative = false, Operands = 1, },
            ["sin("] = new MathsService.Operator { Name = "Sin", Notation = "sin(", Precedence = 3, RightAssociative = false, Operands = 1, },
            ["cos("] = new MathsService.Operator { Name = "Cos", Notation = "cos(", Precedence = 3, RightAssociative = false, Operands = 1, },
            ["tan("] = new MathsService.Operator { Name = "Tan", Notation = "tan(", Precedence = 3, RightAssociative = false, Operands = 1, },
            ["pi"] = new MathsService.Operator { Name = "Pi", Notation = "pi", Precedence = 6, RightAssociative = false, Operands = 0, },
            ["sqrt("] = new MathsService.Operator { Name = "SquareRoot", Notation = "sqrt(", Precedence = 3, RightAssociative = false, Operands = 1, },
            ["rt("] = new MathsService.Operator { Name = "Root", Notation = "rt(", Precedence = 3, RightAssociative = false, Operands = 3, },
            [","] = new MathsService.Operator { Name = "Comma", Notation = ",", Precedence = 0, RightAssociative = false, Operands = 0, },
            ["("] = new MathsService.Operator { Name = "LeftParenthesis", Notation = "(", Precedence = 3, RightAssociative = false, Operands = 0, },
            
        };

        /// <inheritdoc/>
        public double SolveExpression(string expression)
        {
            // local function to decide which operator should be evaluated first
            bool SolvePrecedence(string operator1, string operator2)
            {
                _operatorsDict.TryGetValue(operator1, out var oper1);
                _operatorsDict.TryGetValue(operator2, out var oper2);
                return oper1.RightAssociative ? oper1.Precedence < oper2.Precedence : oper1.Precedence <= oper2.Precedence;
            }
            
            var stack = new Stack<string>(); // stack of operators to be evaluate and operands to be used in operation
            var expressionQueue = new Queue<string>(); // queue for evaluating operations
            var leftParenthesis = new List<string> { "(", "sqrt(", "rt(", "sin(", "cos(", "tan(", }; // list of all allowed left parenthesis formats
            var listSingleOperators = new List<string>(); // list of single operators (every operator is one element) in an appropriate order

            // exception for string being null, empty or string that consists only of white-space characters
            if (string.IsNullOrWhiteSpace(expression))
                throw new System.ArgumentException(
                    "The expression is null, an empty string or consists only of white-space characters.");

            expression = expression.Replace(" ", string.Empty); // get rid of all whitespaces in exception

            // get all numbers in expression
            string[] operators = {"(", ")", "+", "-", "*", "/", "^", "!", "sqrt(", "rt(", "sin(", "cos(", "tan(", ",", "pi"}; // allowed operators for splitting of expression
            var strOperands = expression.Split(operators, System.StringSplitOptions.RemoveEmptyEntries); // string array of operators-only characters
            // get all operators in expression
            string[] numbers = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "m", "d", }; // allowed number characters for splitting of expression 
            var strOperators = expression.Split(numbers, System.StringSplitOptions.RemoveEmptyEntries); // get array of operators (possible groups of operators in one element) 

             
            foreach (var strElement in strOperators) // divide single string element into valid operators and operands 
            {
                var characters = strElement.ToCharArray(); // char array of single string element got from 'expression.split' operations
                for (var i = 0; i < strElement.Length; i++)
                {

                    switch (strElement[i])
                    {
                        // one-char operators
                        case '!': // factorial operator
                        case '+': // addition operator
                        case '-': // subtract operator
                        case '*': // multiplication operator
                        case '/': // division operator
                        case '^': // power operator
                        case ',': // comma
                        case '(': // opening parenthesis
                        case ')': // closing parenthesis
                            listSingleOperators.Add(strElement[i].ToString());
                            break;
                        
                        // operators with two and more chars
                        case 'p':
                            if (strElement.Length >= 2 && strElement.Substring(i, 2) == "pi") // pi constant operator equal to 'Constants.Pi'
                            {
                                listSingleOperators.Add("pi");
                                i += 1;
                            }
                            else // not a valid operator
                            {
                                throw new Maths.ExpressionSolvingException("Not a valid operator in an expression.");
                            }
                            break;
                        
                        case 'r':
                            if (strElement.Length >= 3 && strElement.Substring(i, 3) == "rt(") // root operator
                            {
                                listSingleOperators.Add("rt(");
                                i += 2;
                            }
                            else // not a valid operator
                            {
                                throw new Maths.ExpressionSolvingException("Not a valid operator in an expression.");
                            }
                            break;
                        
                        case 'c':
                            if (strElement.Length >= 4 && strElement.Substring(i, 4) == "cos(") // cosinus operator
                            {
                                listSingleOperators.Add("cos(");
                                i += 3;
                            }
                            else // not a valid operator
                            {
                                throw new Maths.ExpressionSolvingException("Not a valid operator in an expression.");
                            }
                            break;
                        
                        case 't':
                            if (strElement.Length >= 4 && strElement.Substring(i, 4) == "tan(") // tangens operator
                            {
                                listSingleOperators.Add("tan(");
                                i += 3;
                            }
                            else // not a valid operator
                            {
                                throw new Maths.ExpressionSolvingException("Not a valid operator in an expression.");
                            }
                            break;
                        
                        case 's':
                            if (strElement.Length >= 4 && strElement.Substring(i, 4) == "sin(") // sinus operator
                            {
                                listSingleOperators.Add("sin(");
                                i += 3;
                            }
                            else if (strElement.Length >= 5 && strElement.Substring(i, 5) == "sqrt(") // square root operator
                            {
                                listSingleOperators.Add("sqrt(");
                                i += 4;
                            }
                            else // not a valid operator
                            {
                                throw new Maths.ExpressionSolvingException("Not a valid operator in an expression.");
                            }
                            break;
                        
                        default: // not a valid operator
                            throw new Maths.ExpressionSolvingException("Not a valid operator in an expression.");
                    }
                }
            }
            
            var listOperands = new List<string>(strOperands); // list of operands in expression
            var listExpression = new List<string>(); // complete expression in written order split in tokens as operands, operators, parenthesis and commas
            var indexOperands = 0; // index of operands in 'listOperands' list
            var indexOperators = 0; // index of operators in 'listSingleOperators' list
            var parenthesisBeforeFactorial = false; // if there is a parenthesis before factorial in expression
            string[] allowedOperatorsBeforeMinus = {"(", "+", "-", "*", "/", "^", "sqrt(", "rt(", "sin(", "cos(", "tan(", ",",}; // operators that can be before unary '-'
            var arrExpression = expression.ToCharArray(); // char array of expression to build 'listExpression' list
            for (var i = 0; i < arrExpression.Length && arrExpression[i] != '\0';)
            {
                if (char.IsDigit(expression, i)) // if char is a digit, add whole number to 'listExpression' 
                {
                    listExpression.Add(listOperands[indexOperands]);
                    i += listOperands[indexOperands++].Length;
                }
                
                // solve negative numbers (with unary '-')
                else if (arrExpression[i] == '-' && i + 1 < arrExpression.Length && char.IsDigit(arrExpression[i + 1]) &&
                         (i == 0 || allowedOperatorsBeforeMinus.Contains(arrExpression[i - 1].ToString()))
                         ) 
                {
                    if (listSingleOperators.Count > indexOperators + 1) // if there's other operator after '-'
                    {
                        if (_operatorsDict.TryGetValue(listSingleOperators[indexOperators + 1], out var nextOperator)) // test what next operator is, if there's one
                        {
                            // depending on 'RightAssociative' decide if you should add current '-' to 'listExpression' or not
                            if (nextOperator != null && nextOperator.RightAssociative) 
                            {
                                listExpression.Add(listSingleOperators[indexOperators]);
                                i += listSingleOperators[indexOperators++].Length;
                            }    
                        }
                    }
                    
                    // remove unary '-' from operators and append it to the number as a negative number which should be added to 'listExpression'  
                    listSingleOperators.RemoveAt(indexOperators);
                    listExpression.Add("-" + listOperands[indexOperands]);
                    listOperands[indexOperands++] = listExpression.Last();
                    i += listExpression.Last().Length;
                }
                
                // solve positive numbers with additional unary '+'
                else if (arrExpression[i] == '+' && i + 1 < arrExpression.Length && char.IsDigit(arrExpression[i + 1]) &&
                         (i == 0 || allowedOperatorsBeforeMinus.Contains(arrExpression[i - 1].ToString()))
                         ) 
                {
                    // just remove unary '+' from 'listSingleOperators' list
                    listSingleOperators.RemoveAt(indexOperators);
                    listExpression.Add(listOperands[indexOperands]);
                    listOperands[indexOperands++] = listExpression.Last();
                    i += listExpression.Last().Length + 1;
                }
                else // anything else add to the 'listExpression'
                {
                    listExpression.Add(listSingleOperators[indexOperators]);
                    i += listSingleOperators[indexOperators++].Length;
                }
            }

            // test correct factorial format
            if (listExpression.Contains("!"))
            {
                for (var i = 0; i < listExpression.Count; i++)
                {
                    if (listExpression[i] == "!")
                    {
                        if (i == 0 || (! double.TryParse(listExpression[i - 1], out _) && listExpression[i - 1] != ")")) // number of closing parenthesis before factorial
                        {
                            throw new Maths.ExpressionSolvingException("Factorial without operand before it.");
                        }
                        if (i > 0 && listExpression[i - 1] == ")") // set 'parenthesisBeforeFactorial' to test if parenthesis evaluated into valid operand 
                        {
                            parenthesisBeforeFactorial = true;
                        }
                    }
                }
            }
            
            indexOperands = 0; // resetting index of operands in 'listOperands' list
            var operandAfterMinus = true; // test for appropriate amount of operands for binary/unary '-'
            foreach (var element in listExpression)
            {
                if (numbers.Contains(element[element.Length > 1 ? 1 : 0].ToString())) // 'element' is a number
                {
                    if (indexOperands < listOperands.Count && element == listOperands[indexOperands]) // enqueue all valid operands
                    {
                        expressionQueue.Enqueue(element);
                        indexOperands++;
                        operandAfterMinus = true; // these is an operand after '-' in case these is '-' in expression
                    }
                    else // operand wasn't expected
                    {
                        throw new Maths.ExpressionSolvingException("There is an unreadable operand in an expression.");
                    }
                }
                else // 'element' is an operator
                {
                    if (element == "-") // there should be an operand after '-' (binary or unary)
                    {
                        operandAfterMinus = false;
                    }
                    
                    if (element == ")") // if the 'element' is closing parenthesis, enqueue from stack everything till an opening parenthesis
                    {
                        var popped = stack.Pop(); // element to be popped from the stack
                        while (!leftParenthesis.Contains(popped)) // enqueue everything if 'popped' is NOT an opening parenthesis
                        {
                            expressionQueue.Enqueue(popped);
                            popped = stack.Pop();
                        }

                        if (popped != "(") // if there is an operator attached to opening parenthesis, enqueue it too
                        {
                            expressionQueue.Enqueue(popped);
                        }
                    }
                    else if (stack.Any() && (!leftParenthesis.Contains(stack.Peek()))) // stack is not empty
                    {
                        // solve which operator should be evaluated first in case of more operators in the row
                        if (SolvePrecedence(element, stack.Peek()))
                        {
                            var popped = stack.Pop();
                            expressionQueue.Enqueue(popped);
                            stack.Push(element);
                        }
                        else
                        {
                            stack.Push(element);
                        }
                    }
                    else // if the stack is empty, push 'element' to stack
                    {
                        stack.Push(element);
                    }
                }
            }

            if (! operandAfterMinus) // there is '-' in the expression without appropriate operands 
            {
                throw new Maths.ExpressionSolvingException("There is no operand after minus operator.");
            }


            while (stack.Any()) // if there are any tokens on stack, enqueue them.
            {
                var popped = stack.Pop();
                expressionQueue.Enqueue(popped);
            } // stack is empty (and ready to be used for operands in evaluating operations)
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
