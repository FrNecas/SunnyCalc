using ReactiveUI;
using SunnyCalc.Maths;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyCalc.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IMathsService _service;

        private StandardCalculatorViewModel _cvm;

        public StandardCalculatorViewModel StandardCalculatorViewModel
        {
            get => _cvm;
            set => this.RaiseAndSetIfChanged(ref _cvm, value);
        }

        private ExtendedCalculatorViewModel _evm;

        public ExtendedCalculatorViewModel ExtendedCalculatorViewModel
        {
            get => _evm;
            set => this.RaiseAndSetIfChanged(ref _evm, value);
        }


        private ViewModelBase _currentVm;

        public ViewModelBase CurrentViewModel
        {
            get => _currentVm;
            private set => this.RaiseAndSetIfChanged(ref _currentVm, value);
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(IMathsService mathsService)
        {
            _service = mathsService;

            this.StandardCalculatorViewModel = new StandardCalculatorViewModel(mathsService);
            this.ExtendedCalculatorViewModel = new ExtendedCalculatorViewModel(mathsService);
            this.CurrentViewModel = this.StandardCalculatorViewModel;
        }

        public void SwapViews()
        {
            this.CurrentViewModel = _currentVm == _cvm ? (ViewModelBase) _evm : _cvm;
        }
    }
}
