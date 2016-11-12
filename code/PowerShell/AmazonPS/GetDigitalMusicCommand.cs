using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using ByteBlocks.AmazonAPI;

namespace AmazonPS
{
    public class GetDigitalMusicCommand : Cmdlet
    {
        #region Class Members

        private string _associateTag;
        private string _accessKey;
        private string _searchTerm;
        private int _resultsToFetch;

        private DigitalMusicSearch _search;
        private DigitalMusicSearchParameters _searchParams = new DigitalMusicSearchParameters();
        private List<DigitalMusic> _items;

        #endregion

        #region Parameters
        /// <summary>
        /// 
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Specify associate tag issued by Amazon.com")]
        [ValidateNotNullOrEmpty]
        public string AssociateTag
        {
            get { return _associateTag; }
            set { _associateTag = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [Parameter(Mandatory = true, HelpMessage = "Specify access key issued by Amazon.com")]
        public string AccessKey
        {
            get { return _accessKey; }
            set { _accessKey = value; }
        }

        [Parameter(Mandatory = true, HelpMessage = "Query to use for search")]
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; }
        }

        [Parameter(Mandatory = true, HelpMessage = "Maximum number of results to return")]
        [ValidateRange(1, 500)]
        public int Count
        {
            get { return _resultsToFetch; }
            set { _resultsToFetch = value; }
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
            foreach (DigitalMusic digmusic in _items)
            {
                WriteObject(digmusic);
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
            _search = new DigitalMusicSearch();
            _searchParams = new DigitalMusicSearchParameters();
            _search.AccessKeyId = "xx";
            _search.AssociateTag = "xx";
            _searchParams.Keywords = SearchTerm;
            _searchParams.MaxResults = Count;
        }

        private void ExecuteSearch()
        {
            WriteVerbose("Connecting to Amazon.com to search for digital music items");
            _items = _search.Search(_searchParams);
        }
        #endregion
    }
}
