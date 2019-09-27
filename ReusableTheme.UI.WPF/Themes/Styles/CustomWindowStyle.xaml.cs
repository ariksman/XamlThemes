using System.Windows;

namespace ReusableTheme.UI.WPF.Themes.Styles
{
  public partial class CustomWindow : ResourceDictionary
  {
    public CustomWindow()
    {
      InitializeComponent();
    }

    private void OnCloseClick(object sender, RoutedEventArgs e)
    {
      var window = (Window)((FrameworkElement)sender).TemplatedParent;

      window.Close();
    }

    private void OnMaximizeRestoreClick(object sender, RoutedEventArgs e)
    {
      var window = (Window)((FrameworkElement)sender).TemplatedParent;

      window.WindowState = window.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
    }

    private void OnMinimizeClick(object sender, RoutedEventArgs e)
    {
      var window = (Window)((FrameworkElement)sender).TemplatedParent;

      window.WindowState = WindowState.Minimized;
    }

    private void OnThemeClick(object sender, RoutedEventArgs e)
    {
      var theme = Theme.ThemeType == ThemeType.Light ? ThemeType.Dark : ThemeType.Light;
      Theme.LoadThemeType(theme);
    }
  }
}
