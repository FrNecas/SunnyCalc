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
        public StandardCalculatorViewModel CalcViewModel
        {
            get => _cvm;
            set => this.RaiseAndSetIfChanged(ref _cvm, value);
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(IMathsService mathsService)
        {
            _service = mathsService;
            this.CalcViewModel = new StandardCalculatorViewModel(mathsService);
        }
    }
}
