using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using System.Windows.Input;

namespace SunnyCalc.App.Controls
{
    public class DoubleButton : UserControl
    {
        // The properties here provide a way of changing the attributes of the two buttons
        // that we need to control in our scenario.
        // I wonder whether there isn't a more convenient way of doing this as this requires a lot of
        // repeating boilerplate code and using it in the XAML markup doesn't feel right – I'd like a solution
        // where the two buttons would be represented as two properties/elements inside of the DoubleButton
        // declaration – but for what we need atm, this is good enough. 

        public static readonly StyledProperty<object> FirstButtonProperty =
            AvaloniaProperty.Register<DoubleButton, object>(nameof(FirstButton));

        public static readonly StyledProperty<object> SecondButtonProperty =
            AvaloniaProperty.Register<DoubleButton, object>(nameof(SecondButton));

        public static readonly DirectProperty<DoubleButton, Classes> FirstButtonClassesProperty =
            AvaloniaProperty.RegisterDirect<DoubleButton, Classes>(
                nameof(FirstButtonClasses), o => o.FirstButtonClasses,
                (o, v) => o.FirstButtonClasses = v);

        public static readonly DirectProperty<DoubleButton, Classes> SecondButtonClassesProperty =
            AvaloniaProperty.RegisterDirect<DoubleButton, Classes>(
                nameof(SecondButtonClasses), o => o.SecondButtonClasses,
                (o, v) => o.SecondButtonClasses = v);

        public static readonly DirectProperty<DoubleButton, ICommand> FirstButtonCommandProperty =
            AvaloniaProperty.RegisterDirect<DoubleButton, ICommand>(nameof(FirstButtonCommand),
                d => d._firstBtn.Command,
                (d, c) =>
                {
                    if (c != d._firstBtn.Command)
                        d.RaisePropertyChanged(FirstButtonCommandProperty, d._firstBtn.Command, c);

                    d._firstBtn.Command = c;
                });

        public static readonly DirectProperty<DoubleButton, ICommand> SecondButtonCommandProperty =
            AvaloniaProperty.RegisterDirect<DoubleButton, ICommand>(nameof(SecondButtonCommand),
                d => d._secondBtn.Command,
                (d, c) =>
                {
                    if (c != d._secondBtn.Command)
                        d.RaisePropertyChanged(SecondButtonCommandProperty, d._secondBtn.Command, c);

                    d._secondBtn.Command = c;
                });

        public static readonly DirectProperty<DoubleButton, string> FirstButtonCommandParameterProperty =
            AvaloniaProperty.RegisterDirect<DoubleButton, string>(nameof(FirstButtonCommandParameter),
                d => d.FirstButtonCommandParameter,
                (d, c) => d.FirstButtonCommandParameter = c);

        public static readonly DirectProperty<DoubleButton, string> SecondButtonCommandParameterProperty =
            AvaloniaProperty.RegisterDirect<DoubleButton, string>(nameof(SecondButtonCommandParameter),
                d => d.SecondButtonCommandParameter,
                (d, c) => d.SecondButtonCommandParameter = c);

        /// <summary>
        /// The command of the left button.
        /// </summary>
        public ICommand FirstButtonCommand => _firstBtn.Command;

        /// <summary>
        /// The command of the right button.
        /// </summary>
        public ICommand SecondButtonCommand => _secondBtn.Command;

        /// <summary>
        /// The command parameter of the left button.
        /// </summary>
        public string FirstButtonCommandParameter
        {
            get => _firstBtn.CommandParameter?.ToString();
            set
            {
                var old = _firstBtn.CommandParameter;
                _firstBtn.CommandParameter = value;

                if (old?.ToString() != value)
                {
                    RaisePropertyChanged(FirstButtonCommandParameterProperty, _firstBtn.CommandParameter?.ToString(),
                        value);
                }
            }
        }

        /// <summary>
        /// The command parameter of the right button.
        /// </summary>
        public string SecondButtonCommandParameter
        {
            get => _secondBtn.CommandParameter?.ToString();
            set
            {
                var old = _secondBtn.CommandParameter;
                _secondBtn.CommandParameter = value;

                if (old?.ToString() != value)
                {
                    this.RaisePropertyChanged(FirstButtonCommandParameterProperty,
                        _secondBtn.CommandParameter?.ToString(), value);
                }
            }
        }

        /// <summary>
        /// The contents of the left button.
        /// </summary>
        public object FirstButton
        {
            get => this.GetValue(FirstButtonProperty);
            set
            {
                if (!(_firstBtn.CommandParameter is string cp) || string.IsNullOrEmpty(cp))
                {
                    _firstBtn.CommandParameter = value;
                }

                this.SetValue(FirstButtonProperty, value);
            }
        }

        /// <summary>
        /// The contents of the right button.
        /// </summary>
        public object SecondButton
        {
            get => this.GetValue(SecondButtonProperty);
            set
            {
                if (!(_secondBtn.CommandParameter is string cp) || string.IsNullOrEmpty(cp))
                {
                    _secondBtn.CommandParameter = value;
                }

                this.SetValue(SecondButtonProperty, value);
            }
        }

        /// <summary>
        /// The classes of the left button. The "doubleBtnInner" class is always added to the list.
        /// </summary>
        public Classes FirstButtonClasses
        {
            get { return _firstBtn.Classes; }

            set
            {
                var a = _firstBtn.Classes;
                _firstBtn.Classes = value;
                _firstBtn.Classes.Add("doubleBtnInner");

                this.RaisePropertyChanged(FirstButtonClassesProperty, a, value);
            }
        }

        /// <summary>
        /// The classes of the right button. The "doubleBtnInner" class is always added to the list.
        /// </summary>
        public Classes SecondButtonClasses
        {
            get { return _secondBtn.Classes; }

            set
            {
                var a = _secondBtn.Classes;
                _secondBtn.Classes = value;
                _secondBtn.Classes.Add("doubleBtnInner");

                this.RaisePropertyChanged(SecondButtonClassesProperty, a, value);
            }
        }

        private readonly Button _firstBtn;
        private readonly Button _secondBtn;

        public DoubleButton()
        {
            this.InitializeComponent();
            _firstBtn = this.FindControl<Button>("firstButton");
            _secondBtn = this.FindControl<Button>("secondButton");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
