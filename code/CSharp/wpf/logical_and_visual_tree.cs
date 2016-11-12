using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
public partial class AboutDialog : Window
{
    public AboutDialog()
	{
	    InitializeComponent();
	    PrintLogicalTree(0, this);
	}

    protected override void OnContentRendered(EventArgs e)
	{
	    base.OnContentRendered(e);
	    PrintVisualTree(0, this);
	}

    void PrintLogicalTree(int depth, object obj)
	{
	    Debug.WriteLine(new string(‘ ‘, depth) + obj);                      // Print the object with preceding spaces that represent its depth
	    if (!(obj is DependencyObject)) return;                             // Sometimes leaf nodes aren’t DependencyObjects (e.g. strings)
	    foreach (object child in LogicalTreeHelper.GetChildren(             // Recursive call for each logical child
			 obj as DependencyObject))		
		PrintLogicalTree(depth + 1, child);
	}

    void PrintVisualTree(int depth, DependencyObject obj)
	{
	    Debug.WriteLine(new string(‘ ‘, depth) + obj);                      // Print the object with preceding spaces that represent its depth
	    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)    // Recursive call for each visual child
		PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
	}
}