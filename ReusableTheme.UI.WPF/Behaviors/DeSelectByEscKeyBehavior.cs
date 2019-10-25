using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Xaml.Behaviors;

namespace ReusableTheme.UI.WPF.Behaviors
{
  public class DeSelectByEscKeyBehavior : Behavior<ListBox>
  {
    protected override void OnAttached()
    {
      AssociatedObject.KeyDown += AssociatedObject_KeyDown;
      base.OnAttached();
    }

    protected override void OnDetaching()
    {
      AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
      base.OnDetaching();
    }

    private static void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
    {
      if (!(sender is ListBox listBox))
        return;

      void SetSelectedItemNull()
      {
        listBox.SelectedItem = null;
      }

      listBox.Dispatcher?.BeginInvoke((Action) SetSelectedItemNull, DispatcherPriority.ContextIdle);
    }
  }
}