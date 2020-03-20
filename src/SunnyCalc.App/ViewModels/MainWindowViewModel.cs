using SunnyCalc.Maths;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyCalc.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Hello World!";
        private readonly IMathsService _service;

        public MainWindowViewModel(IMathsService mathsService)
        {
            _service = mathsService;
        }
    }
}
