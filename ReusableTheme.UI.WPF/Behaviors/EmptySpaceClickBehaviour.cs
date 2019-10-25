using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Xaml.Behaviors;

namespace ReusableTheme.UI.WPF.Behaviors
{
  public class EmptySpaceClickBehaviour : Behavior<ListBox>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
    }

    protected override void OnDetaching()
    {
      base.OnDetaching();
      AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObject_PreviewMouseLeftButtonDown;
    }

    private static void AssociatedObject_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      if (!(sender is ListBox listBox))
        return;

      HitTestResult hitTestResult =
        VisualTreeHelper.HitTest(listBox, e.GetPosition(listBox));
      Control controlUnderMouse = hitTestResult.VisualHit.GetParentOfType<Control>();

      void SetSelectedItemNull()
      {
        listBox.SelectedItem = null;
      }

      if (controlUnderMouse.GetType() != typeof(ListBoxItem))
      {
        listBox.Dispatcher.BeginInvoke((Action) SetSelectedItemNull, DispatcherPriority.ContextIdle);
      }
    }
  }
}