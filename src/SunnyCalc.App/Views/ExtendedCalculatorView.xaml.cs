using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SunnyCalc.App.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace SunnyCalc.App.Views
{
    public class ExtendedCalculatorView : UserControl
    {
        public ExtendedCalculatorView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void InputKeyPressedHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                (this.DataContext as ExtendedCalculatorViewModel)?.PerformControlCommand("=");
                e.Handled = true;
            }
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);

            // The numpad buttons have to be generated after the data context is bound,
            // so that their commands can be assigned to the viewmodel.
            this.InitNumpad();
        }

        /// <summary>
        /// Generates the 1 to 9 buttons and adds them to the "numpad" grid.
        /// </summary>
        private void InitNumpad()
        {
            var numpad = this.FindControl<Grid>("numpad");

            // This should never happen, as the data context will never get changed more than once,
            // but as a precaution, remove the number buttons that might be present in the grid.
            var currentBtns = numpad.Children.Where(
                c => c.Name?.StartsWith("numberBtn_") ?? false).ToList();

            if (currentBtns.Count > 0)
            {
                numpad.Children.RemoveAll(currentBtns);
            }

            for (var i = 0; i < 9; i++)
            {
                var numBtn = new Button {Name = "numberBtn_" + i};

                numBtn.Classes.Add("numBtn");
                numBtn.Content = (i + 1).ToString();
                numpad.Children.Add(numBtn);

                numBtn.Command = (this.DataContext as ExtendedCalculatorViewModel)?.InputCommand;
                numBtn.CommandParameter = numBtn.Content;

                Grid.SetColumn(numBtn, i % 3);
                Grid.SetRow(numBtn, 2 - (i / 3));
            }
        }
    }
}
