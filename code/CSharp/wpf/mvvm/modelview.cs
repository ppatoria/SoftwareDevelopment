
// 2.
// Create a class called SearchViewModel (Add | New Class) and implement the support to the interface:

using System.ComponentModel;
namespace MyTweet.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {
	// Usually implement this on a base class
#region INotifyPropertyChanged Members
	public event PropertyChangedEventHandler PropertyChanged;
	private void OnPropertyChanged(string propertyName)
	    {
		if (PropertyChanged != null)
		    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	    }
#endregion
    }
}


// 3.
// Create a member variable which will instantiate the model previously defined (we will see how to do this without coupling in subsequent chapters):

using MyTweet.Model;
namespace MyTweet.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {
#region fields
	private TweetModel _model = new TweetModel();
#endregion
    }
}


 

// INotifyPropertyChanged is covered in detail in Chapter 3, Data Binding.



// 4.

// Add a property of the string type, which contains the text string we have to search for:

public string SearchText
{
    get { return _searchText; }
    set
    {
	if (_searchText != value)
	{
	    _searchText = value;
	    // To notify any UI element bound to this property
	    RaisePropertyChanged("SearchText");
	}
    }
}


// 5.
// Add a collection containing the tweet search results:


// Code View: Scroll / Show All
private ObservableCollection<SearchResult> _members = new ObservableCollection<SearchResult>();
public ObservableCollection<SearchResult> Members
{
    get { return _members; }
    set
    {
	_members = value;
	RaisePropertyChanged("Members");
    }
}

					  


// 6.
// Add a public method, which will fire the search (Important: This should be exposed as a command. We will see how to do this in the following section):

public void ExecuteSearch()
{
    _model.TweetSearchAsync(SearchText);
}

// 7.

// Subscribe to the event of the Model, which will indicate to us when the result of the search has been retrieved, and assign the result to the property of the results already defined:


// Code View: Scroll / Show All
public SearchViewModel()
{
    _model.TweetSearchCompleted += new EventHandler<ResponseTweetSearchArgs>(_model_TweetSearchCompleted);
}
void _model_TweetSearchCompleted(object sender, ResponseTweetSearchArgs e)
{
    Members = e.searchResults;
}

				

