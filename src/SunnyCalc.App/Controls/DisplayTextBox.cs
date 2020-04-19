using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SunnyCalc.App.Controls
{
    /// <summary>
    /// A TextBox that doesn't keep track of its caret position after it loses focus.
    /// </summary>
    public class DisplayTextBox : TextBox
    {
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            var caretIndex = this.CaretIndex;
            base.OnLostFocus(e);
            this.CaretIndex = caretIndex;
        }
    }
}
