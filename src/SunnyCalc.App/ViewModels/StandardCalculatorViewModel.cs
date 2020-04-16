using ReactiveUI;
using SunnyCalc.Maths;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reactive;
using System.Text;
using System.Windows.Input;

namespace SunnyCalc.App.ViewModels
{
    public class StandardCalculatorViewModel : ViewModelBase
    {
        private enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            NRoot,
            NPow,
            None
        }

        public ICommand NumberCommand { get; }
        public ICommand OperationCommand { get; }
        public ICommand DecimalPointCommand { get; }

        /// <summary>
        /// The text to show on the calculator "display".
        /// </summary>
        public string CurrentState
        {
            get => _display;
            set => this.RaiseAndSetIfChanged(ref _display, value);
        }

        /// <summary>
        /// Controls whether the decimal point button can be used, in context of the currently displayed number.
        /// </summary>
        public bool DecimalPointEnabled
        {
            get => _canUseDecimal;
            set => this.RaiseAndSetIfChanged(ref _canUseDecimal, value);
        }

        // The binary operation to perform when another binary operation or equals is used.
        private Operation _previousOp = Operation.None;

        // The current "working value" on the display.
        private string _display = "0";

        // The last calculated value, to be used as the left operand in binary operations.
        private decimal _lastResult = 0;

        // Flag indicating whether the decimal point button can be used.
        private bool _canUseDecimal = true;

        // Set to true if the display is in "clear" state – the next press of a number should overwrite
        // the currently displayed value (typically Error or 0).
        private bool _initialState = true;

        private readonly IMathsService _serv;

        public StandardCalculatorViewModel(IMathsService mathsService)
        {
            _serv = mathsService;

            this.NumberCommand = ReactiveCommand.Create<string>(this.PerformNumberCommand);
            this.OperationCommand = ReactiveCommand.Create<string>(this.PerformOperationCommand);
            this.DecimalPointCommand = ReactiveCommand.Create(this.AddDecimalPoint,
                this.WhenAnyValue(x => x.DecimalPointEnabled));
        }

        /// <summary>
        /// Removes the last digit/character from the display.
        /// If the current display state ends with a decimal point, enables the decimal point button.
        /// If there is nothing (or only the minus sign) left on the display after removing the last digit,
        /// the <see cref="_initialState"/> flag is set.
        /// </summary>
        private void DisplayBackspace()
        {
            if (_initialState)
            {
                return;
            }

            if (_display.Length > 1 && _display[^1] == '.')
            {
                this.DecimalPointEnabled = true;
            }

            var newSt = _display.Substring(0, _display.Length - 1);

            if (newSt.Length == 0)
            {
                newSt = "0";
                _initialState = true;
            }

            if (newSt.Length == 1 && newSt[0] == '-')
            {
                newSt = "0";
                _initialState = true;
            }

            this.CurrentState = newSt;
        }

        /// <summary>
        /// Clears the display and the memory, turning the calculator to the begin state.
        /// </summary>
        private void DisplayClear()
        {
            this.CurrentState = "0";
            this.DecimalPointEnabled = true;
            _initialState = true;
            _lastResult = 0;
            _previousOp = Operation.None;
        }

        /// <summary>
        /// Toggles the sign of the number currently on the display.
        /// The <see cref="_initialState"/> flag must not be set. 
        /// </summary>
        private void DisplayNegate()
        {
            if (_initialState)
            {
                return;
            }

            if (_display[0] == '-')
            {
                this.CurrentState = _display.Substring(1);
            }
            else
            {
                this.CurrentState = "-" + _display;
            }
        }

        /// <summary>
        /// Displays an error message on the display, disables the decimal point button
        /// and sets the <see cref="_initialState"/> flag.
        /// </summary>
        private void DisplayError()
        {
            this.CurrentState = "Error";
            this.DecimalPointEnabled = false;
            _initialState = true;
            _lastResult = 0;
            _previousOp = Operation.None;
        }

        /// <summary>
        /// Displays the specified number and sets it as the <see cref="_lastResult"/> value.
        /// </summary>
        private void DisplayNumber(decimal number)
        {
            this.CurrentState = number.ToString(CultureInfo.InvariantCulture);
            this.DecimalPointEnabled = !_display.Contains(".");
            _initialState = number == 0;
            _lastResult = number;
            _previousOp = Operation.None;
        }

        // TODO: check bounds
        /// <summary>
        /// Handles an unary operation and sets the display, <see cref="_lastResult"/> and other flags accordingly.
        /// </summary>
        /// <param name="op">The operation to perform. One of "sq", "sqrt" or "fact".</param>
        /// <param name="state">The current number on the display parsed as a <see cref="decimal"/>.</param>
        private void UnaryOperation(string op, decimal state)
        {
            decimal res;

            switch (op)
            {
                case "sq":
                    res = _serv.Power(state, 2);
                    break;
                case "sqrt":
                    if (_display.Contains("-"))
                    {
                        this.DisplayError();
                        return;
                    }

                    res = _serv.Root(state, 2);
                    break;
                case "fact":
                    if (_display.Contains(".") || state < 0)
                    {
                        this.DisplayError();
                        return;
                    }

                    res = _serv.Factorial((uint) state);
                    break;
                default:
                    return;
            }

            this.DisplayNumber(res);
        }

        /// <summary>
        /// Performs the binary operation saved in <see cref="_previousOp"/>, taking <see cref="_lastResult"/>
        /// for the left operand and the number currently on the display for the right operand.
        /// Sets the display, <see cref="_lastResult"/> and other flags accordingly.
        /// </summary>
        /// <param name="state"></param>
        private void FinishBinaryOperation(decimal state)
        {
            try
            {
                decimal newValue;

                switch (_previousOp)
                {
                    case Operation.Add:
                        newValue = _serv.Add(_lastResult, state);
                        break;
                    case Operation.Subtract:
                        newValue = _serv.Subtract(_lastResult, state);
                        break;
                    case Operation.Multiply:
                        newValue = _serv.Multiply(_lastResult, state);
                        break;
                    case Operation.Divide:
                        newValue = _serv.Divide(_lastResult, state);
                        break;
                    case Operation.NRoot:
                        if (_display.Contains(".") || state < 0)
                        {
                            this.DisplayError();
                            return;
                        }

                        newValue = _serv.Root(_lastResult, (uint) state);
                        break;
                    case Operation.NPow:
                        if (_display.Contains(".") || state < 0)
                        {
                            this.DisplayError();
                            return;
                        }

                        newValue = _serv.Power(_lastResult, (uint) state);
                        break;
                    case Operation.None:
                    default:
                        return;
                }

                this.DisplayNumber(newValue);
            }
            catch
            {
                this.DisplayError();
            }
        }

        /// <summary>
        /// Handles the press of one of the operation buttons.
        /// </summary>
        /// <param name="op">The operation code (passed from the corresponding Button control).
        /// One of +,-,×,÷,=,nroot,npow,backspace,neg,sq,sqrt,fact,clear</param>
        public void PerformOperationCommand(string op)
        {
            if (op == "clear")
            {
                this.DisplayClear();
                return;
            }

            if (!decimal.TryParse(_display, NumberStyles.Any, CultureInfo.InvariantCulture, out var cs))
            {
                this.DisplayError();
                return;
            }

            if (op == "=" && _previousOp != Operation.None)
            {
                this.FinishBinaryOperation(cs);
                return;
            }

            var thisOp = op switch
            {
                "+" => Operation.Add,
                "-" => Operation.Subtract,
                "×" => Operation.Multiply,
                "÷" => Operation.Divide,
                "nroot" => Operation.NRoot,
                "npow" => Operation.NPow,
                _ => Operation.None
            };

            if (thisOp != Operation.None)
            {
                // One of the binary operations was used. 
                if (_previousOp != Operation.None)
                {
                    this.FinishBinaryOperation(cs);
                }

                _previousOp = thisOp;
                _initialState = true;
                _lastResult = cs;
                return;
            }

            switch (op)
            {
                case "backspace":
                    this.DisplayBackspace();
                    break;
                case "neg":
                    this.DisplayNegate();
                    break;
                case "sq":
                case "sqrt":
                case "fact":
                    this.UnaryOperation(op, cs);
                    break;
            }
        }

        /// <summary>
        /// Handles the press of one of the number buttons.
        /// </summary>
        /// <param name="number">The number pressed.</param>
        public void PerformNumberCommand(string number)
        {
            if (_initialState)
            {
                // Clear the initial zero
                this.CurrentState = number;
                this.DecimalPointEnabled = true;
            }
            else
            {
                this.CurrentState += number;
            }

            _initialState = false;
        }

        /// <summary>
        /// Handles the press of the decimal point button.
        /// </summary>
        public void AddDecimalPoint()
        {
            this.DecimalPointEnabled = false;
            this.CurrentState += ".";
            _initialState = false;
        }
    }
}
