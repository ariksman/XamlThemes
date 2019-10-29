using System.Windows;

namespace ReusableTheme.UI.WPF.AttachedProperties
{
  public static class GroupBoxProperties
  {
    /// <summary>
    /// Identifies the CornerRadius property.
    /// </summary>
    public static readonly DependencyProperty CornerRadiusProperty =
      DependencyProperty.RegisterAttached(
        "CornerRadius",
        typeof(double),
        typeof(GroupBoxProperties),
        new FrameworkPropertyMetadata(0d));

    /// <summary>
    /// Gets the corner radius.
    /// </summary>
    public static double GetCornerRadius(DependencyObject obj)
    {
      return (double)obj.GetValue(CornerRadiusProperty);
    }

    /// <summary>
    /// Sets the corner radius.
    /// </summary>
    public static void SetCornerRadius(DependencyObject obj, double value)
    {
      obj.SetValue(CornerRadiusProperty, value);
    }
  }
}