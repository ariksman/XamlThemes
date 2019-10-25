using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace ReusableTheme.UI.WPF.Behaviors
{
  /// <summary> A key up to command behaviour. Usage in xaml:
  ///           <TextBox ....
  ///    <i:Interaction.Behaviors>
  ///    <attachedBehaviors:KeyUpToCommandBehaviour Key = "Enter" Command="{Binding OpenFxTradeTargetingWizardCommand}"/>
  ///    </i:Interaction.Behaviors>
  ///    </TextBox> </summary>
  public class KeyUpToCommandBehaviour : Behavior<UIElement>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", 
            typeof(ICommand),
            typeof(KeyUpToCommandBehaviour), 
            new PropertyMetadata(default(ICommand)));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(
            "Key",
            typeof(Key),
            typeof(KeyUpToCommandBehaviour),
            new PropertyMetadata(default(Key)));

        private RoutedEventHandler _routedEventHandler;

        public Key Key
        {
            get => (Key)GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            _routedEventHandler = AssociatedObject_KeyUp;

            AssociatedObject.AddHandler(UIElement.KeyUpEvent, _routedEventHandler, true);
        }

        void AssociatedObject_KeyUp(object sender, RoutedEventArgs e)
        {
            if (!(e is KeyEventArgs keyArgs))
                return;

            if (keyArgs.Key == Key)
                Command?.Execute(null);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.RemoveHandler(UIElement.KeyUpEvent, _routedEventHandler);
        }
    }
}