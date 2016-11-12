/****************************************************
 * Steps to define DependencyProperty in a control. *
 ****************************************************
 * (1) Declare a static DependencyProperty.
 * (2) Register it in the static constructor.
 *     Parameters:
 *     (a) Name of the property.
 *     (b) Type of the property.
 *     (c) Type of owner of this property.
 *     (d) Meta-data:
 *        (i)  default value.
 *        (ii) callback if the value changed.
 * (3) Define a clr property which get and set the dependency property.
 *    (*) Calls GetValue and SetValue of DependencyObject class 
 *        NOTE: DependencyProperty is registered in DependencyObject.
 * (4) Define callback for property changed.
 */
 
public class Button : ButtonBase
{
    // The dependency property
    public static readonly DependencyProperty IsDefaultProperty;
    static Button()
	{
            // Register the property
	    Button.IsDefaultProperty = 
		DependencyProperty.Register(
		    “IsDefault”,
		    typeof(bool), 
		    typeof(Button),
		    new FrameworkPropertyMetadata(
			false, new PropertyChangedCallback(OnIsDefaultChanged)));
	    //…
	}
    // A .NET property wrapper (optional)
    public bool IsDefault
	{
	    get 
	    { 
		return (bool)GetValue(Button.IsDefaultProperty); 
	    }
	    set 
	    { 
		SetValue(Button.IsDefaultProperty, value); 
	    }
	}
    // A property changed callback (optional)
    private static void OnIsDefaultChanged(
	DependencyObject o, DependencyPropertyChangedEventArgs e) { //… }
	//…
    }