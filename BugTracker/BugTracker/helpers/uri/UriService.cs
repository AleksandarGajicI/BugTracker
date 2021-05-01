using BugTracker.infrastructure.contracts.requests;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers.uri
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllUri(PagedQuery query)
        {
            var uri = new Uri(_baseUri);

            if (query == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "PageNumber", query.PageNum.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "PageSize", query.PageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}
