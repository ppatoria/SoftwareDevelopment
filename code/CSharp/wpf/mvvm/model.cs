
// 1.
// Right-click on the project and choose Add | Class on the contextual menu.


// 2.
// Name this new class ResponseTweetSearchArgs. We will be able to couple in it the event we define:

using System;
using System.Collections.ObjectModel;
using RIAtec.Libs.TweetAPI.Entities;
namespace MyTweet.Model
{
    public class ResponseTweetSearchArgs : EventArgs
    {
	public ObservableCollection<SearchResult> searchResults;
    }
}


 

// Why use an ObservableCollection instead of a List? ObservableCollection works in a similar way to INotifyProperty; in this case the UI gets notified when an element is added or removed from the collection.




// 3.
// Create a new class (Add | Class) that we will name Model.

// 4.

// Define a tweet petition and subscribe the library event indicating the petition has been completed:



using System;
using RIAtec.Libs.TweetAPI;
namespace MyTweet.Model
{
    public class TweetModel
    {
	Search _searchAPI;
	// Instatiate the search API and hook to the completed event//of the SearchForTweet async call
	public TweetModel()
	    {
		_searchAPI = new Search();
		_searchAPI.SearchForTweetCompleted += new EventHandler<ServiceResponseSearchTweetsArgs>(_searchAPI_SearchForTweetCompleted);
	    }
	// This event will be fired once we get the callback from the //tweet library
	public event EventHandler<ResponseTweetSearchArgs> TweetSearchCompleted;

	// Helper method to fire the event
	private void OnTweetSearchCompleted(ResponseTweetSearchArgs e)
	    {
		EventHandler<ResponseTweetSearchArgs> eventHandler = TweetSearchCompleted;
		if (eventHandler != null)
		{
		    eventHandler(this, e);
		}
	    }
    }
}

					  

// 5.

// Within the TweetModel class, we will define the public method that will allow us to make an asynchronous call for the tweet petition:

public void TweetSearchAsync(string substringToFind)
{
    // Retrieve the first 50 results of the search. 
    // This method is asynchronous, once we get the
    // response and notification will be fired.
    _searchAPI.SearchForTweetsAsync(substringToFind, 0);
}


// 6.
// When the petition has completed, we fire our own event. This will be picked by an upper layer (the associated ViewModel):


// Code View: Scroll / Show All
void _searchAPI_SearchForTweetCompleted(object sender, ServiceResponseSearchTweetsArgs e)
{
    ResponseTweetSearchArgs responseArgs = new ResponseTweetSearchArgs();
    // Call succeeded?
    if (e.Result == ServiceResponseType.Succeeded)
    {
	// Add to the response event the list of tweets
	responseArgs.searchResults = e.searchResults;
    }
    // Fire this event (the ViewModel will be listening)
    OnTweetSearchCompleted(responseArgs);
}



