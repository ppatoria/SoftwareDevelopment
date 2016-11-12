
// 1.
// Bind DataContext on the constructor (we will see a cleaner form to do this in the following section):

public SearchView()
{
  InitializeComponent();

  this.DataContext = new SearchViewModel();
}


// 2.
// Going back to XAML, subscribe to the Click event in the Search button:

// <Button Content="Search" 
//   Click="Button_Click"
//   (��)
// />


// 3.
// We launch the code in the Code-Behind to search:

private void Button_Click(object sender, RoutedEventArgs e)
{
  SearchViewModel svm = this.DataContext as SearchViewModel;
  svm.ExecuteSearch();
}

