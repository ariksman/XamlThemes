using System.Windows;

namespace ReusableTheme.UI.WPF.Behaviors
{
  /// <summary>
  /// http://blog.excastle.com/2010/07/25/mvvm-and-dialogresult-with-no-code-behind/
  /// </summary>
  public static class DialogCloser
  {
    public static readonly DependencyProperty DialogResultProperty =
      DependencyProperty.RegisterAttached(
        "DialogResult",
        typeof(bool?),
        typeof(DialogCloser),
        new PropertyMetadata(DialogResultChanged));

    private static void DialogResultChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (d is Window window)
        window.DialogResult = e.NewValue as bool?;
    }
    public static void SetDialogResult(Window target, bool? value)
    {
      target.SetValue(DialogResultProperty, value);
    }
  }
}