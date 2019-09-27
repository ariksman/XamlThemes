using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReusableTheme.UI.WPF;

namespace Demo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = this;
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
      var theme = Theme.ThemeType == ThemeType.Light ? ThemeType.Dark : ThemeType.Light;
      Theme.LoadThemeType(theme);
    }

    public string XamlImageKey { get; set; } = "Icon_TeRex";
  }
}
