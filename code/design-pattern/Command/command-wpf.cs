public static class CommandBank
{
    /*
     * --------------- Command definition --------------------------------
     * -------------- for Closing a window -------------------------------
     */    
    public static RoutedUICommand CloseWindowCommand { get; private set; }

    /// Static private constructor, sets up all application wide commands.
    static CommandBank(){      
        CloseWindowCommand = new RoutedUICommand();

        /*
         * --------------------- Input Binding ---------------------------------
         */
        CloseWindowCommand.InputGestures.Add(new KeyGesture(Key.F4, ModifierKeys.Alt));
        // ...
    }

    /*
     * --------------------------- Command Implementation ------------------------------
     */
    /// Closes the window provided as a parameter
    public static void CloseWindowCommandExecute(object sender, ExecutedRoutedEventArgs e){
        ((Window)e.Parameter).Close();
    }

    /// Allows a Command to execute if the CommandParameter is not a null value
    public static void CanExecuteIfParameterIsNotNull(object sender, CanExecuteRoutedEventArgs e){
        e.CanExecute = e.Parameter != null;
        e.Handled = true;
    }
}

public partial class SimpleWindow : Window
{
    private void WindowLoaded(object sender, RoutedEventArgs e){
        // ...

        /* 
         * ------------------ Command Binding ----------------------------
         */
        this.CommandBindings.Add(
            /* 
             * CommandBinding Constructor (ICommand, ExecutedRoutedEventHandler, CanExecuteRoutedEventHandler) 
             */
            new CommandBinding(
                CommandBank.CloseWindowCommand,               // System.Windows.Input.ICommand. The command to base the new RoutedCommand on.
                CommandBank.CloseWindowCommandExecute,        // Input.ExecutedRoutedEventHandler. Handler for Executed event on new RoutedCommand.
                CommandBank.CanExecuteIfParameterIsNotNull)); // Input.CanExecuteRoutedEventHandler. The handler for CanExecute event on new RoutedCommand.

        /* 
         * ------------------ Input Binding ------------------------------
         */
        foreach (CommandBinding binding in this.CommandBindings){
            RoutedCommand command = (RoutedCommand)binding.Command;
            if (command.InputGestures.Count > 0){
                foreach (InputGesture gesture in command.InputGestures){
                    var iBind = new InputBinding(command, gesture);
                    iBind.CommandParameter = this;
                    this.InputBindings.Add(iBind);
                }
            }
        }

        // menuItemExit is defined in XAML
        menuItemExit.Command = CommandBank.CloseWindow;
        menuItemExit.CommandParameter = this;
        // ...
    }

    // ....
}