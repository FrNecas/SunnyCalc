using Avalonia.Controls.Shapes;
using ReactiveUI;
using SunnyCalc.Maths;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;

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
            _helpAvailable = this.HasHelp();
        }

        public MainWindowViewModel(IMathsService mathsService)
        {
            _service = mathsService;
            _helpAvailable = this.HasHelp();

            this.StandardCalculatorViewModel = new StandardCalculatorViewModel(mathsService);
            this.ExtendedCalculatorViewModel = new ExtendedCalculatorViewModel(mathsService);
            this.CurrentViewModel = this.StandardCalculatorViewModel;
        }

        public void SwapViews()
        {
            this.CurrentViewModel = _currentVm == _cvm ? (ViewModelBase)_evm : _cvm;
        }

        private bool HasHelp()
        {
            string appDir = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string helpFile = System.IO.Path.Combine(appDir, "Help.html");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return File.Exists(helpFile);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return File.Exists("/usr/share/doc/SunnyCalc/Help.html") || File.Exists(helpFile);
            }

            return false;
        }

        private bool _helpAvailable = false;
        public bool HelpAvailable => _helpAvailable;

        public void OpenHelp()
        {
            string appDir = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string helpFile = System.IO.Path.Combine(appDir, "Help.html");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = helpFile
                });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (File.Exists(helpFile))
                {
                    Process.Start("xdg-open", helpFile);

                }
                else
                {
                    Process.Start("xdg-open", "/usr/share/doc/SunnyCalc/Help.html");
                }
            }
        }
    }
}
