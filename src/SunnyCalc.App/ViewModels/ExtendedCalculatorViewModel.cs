using ReactiveUI;
using SunnyCalc.Maths;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reactive;
using System.Text;
using System.Windows.Input;

namespace SunnyCalc.App.ViewModels
{
    public class ExtendedCalculatorViewModel : ViewModelBase
    {
        private const string ErrorMessage = "Chyba";

        public ICommand InputCommand { get; }
        public ICommand ControlCommand { get; }

        /// <summary>
        /// The text to show on the calculator "display".
        /// </summary>
        public string CurrentState
        {
            get => _display;
            set => this.RaiseAndSetIfChanged(ref _display, value);
        }

        public int CaretPosition
        {
            get => _curPosCurrent;
            set
            {
                Debug.WriteLine($"Current: {_curPosCurrent}\tNew: {value}");

                this.RaiseAndSetIfChanged(ref _curPosCurrent, value);
            }
        }

        // The current "working value" on the display.
        private string _display = "0";

        private int _curPosCurrent = 1;

        private readonly IMathsService _serv;

        public ExtendedCalculatorViewModel(IMathsService mathsService)
        {
            _serv = mathsService;

            this.InputCommand = ReactiveCommand.Create<string>(this.PerformInputCommand);
            this.ControlCommand = ReactiveCommand.Create<string>(this.PerformControlCommand);
        }

        /// <summary>
        /// Handles the press of one of the control buttons.
        /// </summary>
        /// <param name="op">The control operation to perform. One of "clear", "backspace" or "=".</param>
        public void PerformControlCommand(string op)
        {
            if (op == "clear")
            {
                this.CurrentState = "0";
                this.CaretPosition = 1;
            }
            else if (op == "backspace")
            {
                if (_display == ErrorMessage || (_display.Length == 1 && _curPosCurrent == 1))
                {
                    this.CurrentState = "0";
                    this.CaretPosition = 1;
                    return;
                }

                if (_curPosCurrent == 0) return;
                
                this.CurrentState = _display.Remove(_curPosCurrent - 1, 1);
                
                if (_curPosCurrent != _display.Length)
                {
                    this.CaretPosition = _curPosCurrent - 1;
                }
            }
            else if (op == "=")
            {
                if (string.IsNullOrWhiteSpace(_display)) return;
                var expr = _display.Replace('×', '*').Replace('÷', '/');
                try
                {
                    var res = _serv.SolveExpression(expr);
                    this.CurrentState = res.ToString(CultureInfo.InvariantCulture);
                    this.CaretPosition = _display.Length;
                }
                catch
                {
                    this.CurrentState = ErrorMessage;
                    this.CaretPosition = _display.Length;
                }
            }
        }

        /// <summary>
        /// Handles the press of one of the input buttons.
        /// </summary>
        /// <param name="input">The number pressed.</param>
        public void PerformInputCommand(string input)
        {
            var curPos = _curPosCurrent;

            // If the command parameter starts with _, add parentheses and move the caret between them
            var offset = 0;
            if (input.StartsWith("_"))
            {
                input = input[1..] + (input == "_rt" ? "(,)" : "()");
                offset--;
            }

            // Clear the display if only zero or Error is currently displayed.
            if (_display == "0" || _display == ErrorMessage)
            {
                _display = "";
                curPos = 0;
            }

            // Prepend zero back if a symbol that makes sense with zero before it is being appended
            if ((input == "." || input.StartsWith("^") || input == "!") && _display == "")
            {
                _display = "0";
                curPos = 1;
            }

            if (curPos == _display.Length)
            {
                // The cursor is at the end, append the input
                this.CurrentState = _display + input;
                this.CaretPosition = _display.Length + offset;
            }
            else
            {
                // The cursor is in the middle, insert the input where it should be
                this.CurrentState = _display.Insert(curPos, input);
                this.CaretPosition = curPos + input.Length + offset;
            }
        }
    }
}
