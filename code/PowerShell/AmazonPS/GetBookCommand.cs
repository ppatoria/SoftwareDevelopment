using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using ByteBlocks.AmazonAPI;
using Microsoft.PowerShell.Commands;

namespace AmazonPS
{
	public class Search-Info  
	{
		public Search-Info()
		{
			SelectStringCommand  ss = new SelectStringCommand();
			
		}
	}
	
	public class GetBookCommand : Cmdlet
	{
		#region Class Members

		private string _associateTag;
		private string _accessKey;
		private string _searchTerm;
		private int _resultsToFetch;

		private BookSearch _search;
		private BookSearchParameters _searchParams = new BookSearchParameters();
		private List<Book> _books;

		#endregion

		#region Parameters
		/// <summary>
		/// 
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage="Specify associate tag issued by Amazon.com")]
		[ValidateNotNullOrEmpty]
		public string AssociateTag
		{
			get { return _associateTag; }
			set{ _associateTag = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		/// 
		[Parameter(Mandatory = true, HelpMessage = "Specify access key issued by Amazon.com")]
		public string AccessKey
		{
			get { return _accessKey; }
			set{ _accessKey = value;}
		}

		[Parameter(Mandatory = true, HelpMessage = "Query to use for search")]
		public string SearchTerm
		{
			get { return _searchTerm; }
			set{ _searchTerm = value;}
		}

		[Parameter(Mandatory = true, HelpMessage = "Maximum number of results to return")]
		[ValidateRange(1,500)]
		public int Count
		{
			get { return _resultsToFetch; }
			set { _resultsToFetch = value;}
		}
		#endregion

		#region Override Methods
		protected override void BeginProcessing()
		{
			base.BeginProcessing();
			CreateDataAPI();
			ExecuteSearch();
		}

		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			foreach (Book book in _books)
			{
				WriteObject(book);
			}
		}

		protected override void EndProcessing()
		{
			base.EndProcessing();
		}

		protected override void StopProcessing()
		{
			base.StopProcessing();
		}
		#endregion

		#region Data Access
		private void CreateDataAPI()
		{
			_search = new BookSearch();
			_searchParams = new BookSearchParameters();
			_search.AccessKeyId = "xx";
			_search.AssociateTag = "xx";
			_searchParams.Keywords = SearchTerm;
			_searchParams.MaxResults = Count;
		}

		private void ExecuteSearch()
		{
			WriteVerbose("Connecting to Amazon.com to search for book(s)");
			_books = _search.Search(_searchParams);
		}
		#endregion
	}
}
