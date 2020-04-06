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
            if (a < 0 && n % 2 == 0)
                throw new System.InvalidOperationException(
                    "Root operation with base value less than 0 and root being even number cannot be evaluated.");

            // valid arguments 
            if (a < 0 && n % 2 == 1)
            {
                return -Math.Pow(Math.Abs(a), 1.0 / n);
            }

            return Math.Pow(a, 1.0 / n);
        }

        /// <inheritdoc/>
        public double Root(double a, uint n)
        {
            // The exception is thrown when the degree of the root is zero.
            if (n == 0) throw new System.ArgumentException("A degree of a root cannot be equal to 0.");

            // The exception is thrown if the degree of the root is even number and value of the base is less than zero.
            if (a < 0 && n % 2 == 0)
                throw new System.InvalidOperationException(
                    "Root operation with base value less than 0 and root being even number cannot be evaluated.");

            // valid arguments
            if (a < 0 && n % 2 == 1)
            {
                return -Math.Pow(Math.Abs(a), 1.0 / n);
            }

            return Math.Pow(a, 1.0 / n);
        }

        /// <inheritdoc/>
        public decimal Root(decimal a, uint n)
        {
            // The exception is thrown when the degree of the root is zero.
            if (n == 0) throw new System.ArgumentException("A degree of a root cannot be equal to 0.");

            // The exception is thrown if the degree of the root is even number and value of the base is less than zero.
            if (a < 0 && n % 2 == 0)
                throw new System.InvalidOperationException(
                    "Root operation with base value less than 0 and root being even number cannot be evaluated.");

            // valid arguments
            if (a < 0 && n % 2 == 1)
            {
                return (decimal) -Math.Pow((double) Math.Abs(a), 1.0 / n);
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
            const double
                eps = 1e-10d; //  acceptable epsilon for testing for undefined angles of tangent, where is better to throw exception than get a completely inaccurate result
            var isOdd = Math.Abs(a * 2 / Constants
                                     .Pi); // isOdd must be odd number in order to parameter a being equal to pi/2 + k*pi 
            if (Math.Abs(isOdd % 2 - 1) <= eps)
                throw new System.InvalidOperationException(
                    "Tangent is not defined in given angle equal to pi/2 + k * pi.");

            return Math.Tan(a);
        }

        #region Expression Solver

        /// <summary>
        /// Operators that can be used before unary '-'.
        /// </summary>
        private static readonly string[] AllowedOperatorsBeforeMinus =
            {"(", "+", "-", "*", "/", "^", "sqrt(", "rt(", "sin(", "cos(", "tan(", ",",};

        /// <summary>
        /// List of all allowed left parenthesis formats.
        /// </summary>
        private static readonly List<string> LeftParenthesis = new List<string>
            {"(", "sqrt(", "rt(", "sin(", "cos(", "tan(",};

        /// <summary>
        /// Allowed operators for splitting an expression.
        /// </summary>
        private static readonly string[] Operators =
            {"(", ")", "+", "-", "*", "/", "^", "!", "sqrt(", "rt(", "sin(", "cos(", "tan(", ",", "pi",};

        /// <summary>
        /// Allowed number characters for splitting an expression.
        /// </summary>
        private static readonly string[] Numbers =
            {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "m", "d",};

        private enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Power,
            Factorial,
            Sin,
            Cos,
            Tan,
            Pi,
            SquareRoot,
            Root,
            Comma,
            LeftParenthesis
        }

        private class Operator
        {
            public Operation Operation { get; set; }
            public string Notation { get; set; }
            public int Precedence { get; set; }
            public bool RightAssociative { get; set; }
            public int Operands { get; set; }

            /// <summary>
            /// Compares the precedence of given operators. 
            /// </summary>
            /// <param name="first">The first operator to be compared.</param>
            /// <param name="second">The second operator to be compared.</param>
            /// <returns>True if <paramref name="first"/> has higher precedence and should be evaluated first.</returns>
            public static bool operator >(Operator first, Operator second)
            {
                return first.RightAssociative
                    ? first.Precedence < second.Precedence
                    : first.Precedence <= second.Precedence;
            }

            public static bool operator <(Operator first, Operator second)
            {
                return !(first > second);
            }

            protected bool Equals(Operator other)
            {
                return this.Operation == other.Operation && this.Notation == other.Notation &&
                       this.Precedence == other.Precedence && this.RightAssociative == other.RightAssociative &&
                       this.Operands == other.Operands;
            }
        }

        private readonly Dictionary<string, Operator> _operatorsDict =
            new Dictionary<string, Operator>
            {
                ["+"] = new Operator
                    {Operation = Operation.Add, Notation = "+", Precedence = 1, RightAssociative = false, Operands = 2,},
                ["-"] = new Operator
                {
                    Operation = Operation.Subtract, Notation = "-", Precedence = 1, RightAssociative = false, Operands = 2,
                },
                ["*"] = new Operator
                {
                    Operation = Operation.Multiply, Notation = "*", Precedence = 2, RightAssociative = false, Operands = 2,
                },
                ["/"] = new Operator
                    {Operation = Operation.Divide, Notation = "/", Precedence = 2, RightAssociative = false, Operands = 2,},
                ["^"] = new Operator
                    {Operation = Operation.Power, Notation = "^", Precedence = 4, RightAssociative = true, Operands = 2,},
                ["!"] = new Operator
                {
                    Operation = Operation.Factorial, Notation = "!", Precedence = 5, RightAssociative = false, Operands = 1,
                },
                ["sin("] = new Operator
                    {Operation = Operation.Sin, Notation = "sin(", Precedence = 3, RightAssociative = false, Operands = 1,},
                ["cos("] = new Operator
                    {Operation = Operation.Cos, Notation = "cos(", Precedence = 3, RightAssociative = false, Operands = 1,},
                ["tan("] = new Operator
                    {Operation = Operation.Tan, Notation = "tan(", Precedence = 3, RightAssociative = false, Operands = 1,},
                ["pi"] = new Operator
                    {Operation = Operation.Pi, Notation = "pi", Precedence = 6, RightAssociative = false, Operands = 0,},
                ["sqrt("] = new Operator
                {
                    Operation = Operation.SquareRoot, Notation = "sqrt(", Precedence = 3, RightAssociative = false,
                    Operands = 1,
                },
                ["rt("] = new Operator
                    {Operation = Operation.Root, Notation = "rt(", Precedence = 3, RightAssociative = false, Operands = 3,},
                [","] = new Operator
                    {Operation = Operation.Comma, Notation = ",", Precedence = 0, RightAssociative = false, Operands = 0,},
                ["("] = new Operator
                {
                    Operation = Operation.LeftParenthesis, Notation = "(", Precedence = 3, RightAssociative = false,
                    Operands = 0,
                },
            };

        /// <inheritdoc/>
        public double SolveExpression(string expression)
        {
            // stack of operators to be evaluate and operands to be used in operation
            var stack = new Stack<string>();
            // queue for evaluating operations
            var expressionQueue = new Queue<string>();
            // list of single operators (every operator is one element) in an appropriate order
            var listSingleOperators = new List<string>();

            // exception for string being null, empty or string that consists only of white-space characters
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression must not be empty.", nameof(expression));

            // get rid of all whitespaces in expression
            expression = expression.Replace(" ", string.Empty);

            // get all numbers in expression
            // string array of operators-only characters
            var strOperands = expression.Split(Operators, StringSplitOptions.RemoveEmptyEntries);

            // get all operators in expression
            // get array of operators (possible groups of operators in one element)
            var strOperators = expression.Split(Numbers, StringSplitOptions.RemoveEmptyEntries);

            // divide single string element into valid operators and operands
            foreach (var strElement in strOperators)
            {
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
                            if (strElement.Length >= 2 && strElement.Substring(i, 2) == "pi")
                            {
                                // pi constant operator equal to 'Constants.Pi'
                                listSingleOperators.Add("pi");
                                i += 1;
                            }
                            else
                            {
                                // not a valid operator
                                throw new ExpressionSolvingException(expression, $"Invalid operator at index {i}.");
                            }

                            break;

                        case 'r':
                            if (strElement.Length >= 3 && strElement.Substring(i, 3) == "rt(")
                            {
                                // root operator
                                listSingleOperators.Add("rt(");
                                i += 2;
                            }
                            else
                            {
                                // not a valid operator
                                throw new ExpressionSolvingException(expression, $"Invalid operator at index {i}.");
                            }

                            break;

                        case 'c':
                            if (strElement.Length >= 4 && strElement.Substring(i, 4) == "cos(")
                            {
                                // cosine operator
                                listSingleOperators.Add("cos(");
                                i += 3;
                            }
                            else
                            {
                                // not a valid operator
                                throw new ExpressionSolvingException(expression, $"Invalid operator at index {i}.");
                            }

                            break;

                        case 't':
                            if (strElement.Length >= 4 && strElement.Substring(i, 4) == "tan(")
                            {
                                // tangent operator
                                listSingleOperators.Add("tan(");
                                i += 3;
                            }
                            else
                            {
                                // not a valid operator
                                throw new ExpressionSolvingException(expression, $"Invalid operator at index {i}.");
                            }

                            break;

                        case 's':
                            if (strElement.Length >= 4 && strElement.Substring(i, 4) == "sin(")
                            {
                                // sine operator
                                listSingleOperators.Add("sin(");
                                i += 3;
                            }
                            else if (strElement.Length >= 5 && strElement.Substring(i, 5) == "sqrt(")
                            {
                                // square root operator
                                listSingleOperators.Add("sqrt(");
                                i += 4;
                            }
                            else
                            {
                                // not a valid operator
                                throw new ExpressionSolvingException(expression, $"Invalid operator at index {i}.");
                            }

                            break;

                        default: // not a valid operator
                            throw new ExpressionSolvingException(expression, $"Invalid operator at index {i}.");
                    }
                }
            }

            // list of operands in expression
            var listOperands = new List<string>(strOperands);
            // complete expression in written order split in tokens as operands, operators, parenthesis and commas
            var listExpression = new List<string>();
            // index of operands in 'listOperands' list
            var indexOperands = 0;
            // index of operators in 'listSingleOperators' list
            var indexOperators = 0;
            // if there is a parenthesis before factorial in expression
            var parenthesisBeforeFactorial = false;

            for (var i = 0; i < expression.Length;)
            {
                // if char is a digit, add whole number to 'listExpression'
                if (char.IsDigit(expression, i))
                {
                    listExpression.Add(listOperands[indexOperands]);
                    i += listOperands[indexOperands++].Length;
                }

                // solve negative numbers (with unary '-')
                else if (expression[i] == '-' && i + 1 < expression.Length && char.IsDigit(expression[i + 1]) &&
                         (i == 0 || AllowedOperatorsBeforeMinus.Contains(expression[i - 1].ToString())))
                {
                    if (listSingleOperators.Count > indexOperators + 1)
                    {
                        // if there's other operator after '-'
                        // test what next operator is, if there's one
                        if (_operatorsDict.TryGetValue(listSingleOperators[indexOperators + 1], out var nextOperator))
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
                else if (expression[i] == '+' && i + 1 < expression.Length && char.IsDigit(expression[i + 1]) &&
                         (i == 0 || AllowedOperatorsBeforeMinus.Contains(expression[i - 1].ToString())))
                {
                    // just remove unary '+' from 'listSingleOperators' list
                    listSingleOperators.RemoveAt(indexOperators);
                    listExpression.Add(listOperands[indexOperands]);
                    listOperands[indexOperands++] = listExpression.Last();
                    i += listExpression.Last().Length + 1;
                }
                else
                {
                    // anything else add to the 'listExpression'
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
                        if (i == 0 || (!double.TryParse(listExpression[i - 1], NumberStyles.Any,
                                           CultureInfo.InvariantCulture, out _) && listExpression[i - 1] != ")"))
                        {
                            // amount of closing parenthesis before factorial
                            throw new ExpressionSolvingException(
                                $"No operand found for the factorial operation at index {i}.");
                        }

                        if (i > 0 && listExpression[i - 1] == ")")
                        {
                            // set 'parenthesisBeforeFactorial' to test if parenthesis evaluated into valid operand
                            parenthesisBeforeFactorial = true;
                        }
                    }
                }
            }

            // resetting index of operands in 'listOperands' list
            indexOperands = 0;
            // test for appropriate amount of operands for binary/unary '-'
            var operandAfterMinus = true;
            foreach (var element in listExpression)
            {
                if (Numbers.Contains(element[element.Length > 1 ? 1 : 0].ToString()))
                {
                    // 'element' is a number

                    if (indexOperands < listOperands.Count && element == listOperands[indexOperands])
                    {
                        // enqueue all valid operands
                        expressionQueue.Enqueue(element);
                        indexOperands++;
                        // these is an operand after '-' in case these is '-' in expression
                        operandAfterMinus = true;
                    }
                    else
                    {
                        // operand wasn't expected
                        throw new ExpressionSolvingException($"Unexpected operand {listOperands[indexOperands]}.");
                    }
                }
                else
                {
                    // 'element' is an operator
                    if (element == "-")
                    {
                        // there should be an operand after '-' (binary or unary)
                        operandAfterMinus = false;
                    }

                    // if the 'element' is closing parenthesis, enqueue from stack everything till an opening parenthesis
                    if (element == ")")
                    {
                        // element to be popped from the stack
                        var popped = stack.Pop();
                        // enqueue everything if 'popped' is NOT an opening parenthesis
                        while (!LeftParenthesis.Contains(popped))
                        {
                            expressionQueue.Enqueue(popped);
                            popped = stack.Pop();
                        }

                        if (popped != "(")
                        {
                            // if there is an operator attached to opening parenthesis, enqueue it too
                            expressionQueue.Enqueue(popped);
                        }
                    }
                    else if (stack.Count > 0 && !LeftParenthesis.Contains(stack.Peek())) // stack is not empty
                    {
                        // Decide which operator should be evaluated first in case of more operators in the row
                        // At this point, the operators should be guaranteed to be present in _operatorsDict
                        if (_operatorsDict[element] > _operatorsDict[stack.Peek()])
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
                    else
                    {
                        // if the stack is empty, push 'element' to stack
                        stack.Push(element);
                    }
                }
            }

            if (!operandAfterMinus)
            {
                // there is '-' in the expression without appropriate operands
                throw new ExpressionSolvingException(expression, "No valid operand found after the minus operator.");
            }

            // if there are any tokens on stack, enqueue them.
            while (stack.TryPop(out var popped))
            {
                expressionQueue.Enqueue(popped);
            } // the stack is empty (and ready to be used for operands in evaluating operations)

            while (expressionQueue.TryDequeue(out var dequeued)) // solve queue
            {
                if (double.TryParse(dequeued, NumberStyles.Any, CultureInfo.InvariantCulture, out var _))
                {
                    // 'dequeued' is a number
                    stack.Push(dequeued);
                }
                else
                {
                    // 'dequeued' is an operator
                    // maximal amount of operators to be popped from the stack
                    var operands = new List<string>(3);

                    if (_operatorsDict.TryGetValue(dequeued, out var @operator))
                    {
                        for (var i = 0; i < @operator.Operands; i++) // get expected amount of operators from stack
                        {
                            try
                            {
                                operands.Add(stack.Pop());
                            }
                            catch (InvalidOperationException)
                            {
                                if (@operator.Notation == "-" && i == 1)
                                {
                                    // handling unary '-' and negative numbers in expression
                                    operands.Add("0");
                                }
                                else
                                {
                                    // not enough operands for given operator
                                    throw new ExpressionSolvingException(expression,
                                        $"Expected {@operator.Operands} operands for the '{dequeued}' operator.");
                                }
                            }
                        }

                        // push ',' to stack so it can be tested for correct single operation format 
                        if (dequeued == ",")
                        {
                            stack.Push(dequeued);
                            continue;
                        }
                    }
                    else
                    {
                        // There is no such operator in _operatorsDict
                        throw new ExpressionSolvingException(expression, $"'{dequeued}' is not a valid operator.");
                    }

                    // evaluate single operation
                    double result = 0;
                    switch (@operator.Operation)
                    {
                        case Operation.Add:
                            result = this.Add(double.Parse(operands[1], CultureInfo.InvariantCulture),
                                double.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Subtract:
                            result = this.Subtract(double.Parse(operands[1], CultureInfo.InvariantCulture),
                                double.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Multiply:
                            result = this.Multiply(double.Parse(operands[1], CultureInfo.InvariantCulture),
                                double.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Divide:
                            result = this.Divide(double.Parse(operands[1], CultureInfo.InvariantCulture),
                                double.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Factorial:
                            if (!long.TryParse(operands[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var op))
                            {
                                throw new InvalidOperationException(
                                    "The operand of a factorial is not a valid unsigned integer.");
                            }

                            if (op < 0)
                            {
                                if (parenthesisBeforeFactorial)
                                {
                                    throw new InvalidOperationException(
                                        "Cannot calculate the factorial of a negative number.");
                                }

                                op = -op;
                                if (op <= uint.MaxValue)
                                {
                                    result = -this.Factorial((uint) op);
                                }
                                else
                                {
                                    throw new InvalidOperationException(
                                        "The operand of a factorial is not a valid unsigned integer (it is too large).");
                                }
                            }
                            else
                            {
                                result = this.Factorial((uint) op);
                            }

                            break;
                        case Operation.Power:
                            result = this.Power(double.Parse(operands[1], CultureInfo.InvariantCulture),
                                uint.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Sin:
                            result = this.Sin(double.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Cos:
                            result = this.Cos(double.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Tan:
                            result = this.Tan(double.Parse(operands[0], CultureInfo.InvariantCulture));
                            break;
                        case Operation.Pi:
                            result = Constants.Pi;
                            break;
                        case Operation.SquareRoot:
                            result = this.Root(double.Parse(operands[0], CultureInfo.InvariantCulture), 2);
                            break;
                        case Operation.Root:
                            if (operands[0] != ",")
                            {
                                // root operation without separating ','
                                throw new ExpressionSolvingException("Missing ',' in expression.");
                            }

                            try
                            {
                                result = this.Root(double.Parse(operands[2], CultureInfo.InvariantCulture),
                                    uint.Parse(operands[1], CultureInfo.InvariantCulture));
                            }
                            catch (Exception e)
                            {
                                // any exception is considered as 'InvalidOperationException'
                                throw new InvalidOperationException(
                                    "Wrong format of a root expression.", e);
                            }

                            break;
                    }

                    // push result of single operation to stack
                    stack.Push(result.ToString(CultureInfo.InvariantCulture));
                }
            }

            // get the final result from stack
            return double.Parse(stack.Pop(), CultureInfo.InvariantCulture);
        }

        #endregion
    }
}
