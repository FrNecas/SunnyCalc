using ReactiveUI;
using SunnyCalc.Maths;
using System;
using System.Collections.Generic;
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
            get => _curState;
            set => this.RaiseAndSetIfChanged(ref _curState, value);
        }

        /// <summary>
        /// Controls whether the decimal point button can be used, in context of the currently displayed number.
        /// </summary>
        public bool DecimalPointEnabled
        {
            get => _canUseDecimal;
            set => this.RaiseAndSetIfChanged(ref _canUseDecimal, value);
        }

        private Operation _nextOp;
        private string _curState = "0";
        private bool _canUseDecimal = true;
        private decimal _lastResult = 0;
        private IMathsService _serv;

        public StandardCalculatorViewModel(IMathsService mathsService)
        {
            _serv = mathsService;

            this.NumberCommand = ReactiveCommand.Create<string>(PerformNumberCommand);
            this.OperationCommand = ReactiveCommand.Create<string>(PerformOperationCommand);
            this.DecimalPointCommand =
                ReactiveCommand.Create(AddDecimalPoint, this.WhenAnyValue(x => x.DecimalPointEnabled));
        }

        private void UpdateState(decimal newNumber)
        {
        }

        private void UpdateLastResult()
        {
            
        }
        
        public void PerformOperationCommand(string op)
        {

            this.DecimalPointEnabled = true;
        }

        public void PerformNumberCommand(string number)
        {
            this.CurrentState = number;
        }

        public void AddDecimalPoint()
        {
            this.DecimalPointEnabled = false;
            this.CurrentState += ".";
        }
    }
}
