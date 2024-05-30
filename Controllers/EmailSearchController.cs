using Microsoft.AspNetCore.Mvc;
using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;

namespace api.enronsearch.com.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmailSearchController : ControllerBase
    {
        private readonly ISolrOperations<Email> _solr;

        public EmailSearchController(ISolrOperations<Email> solr)
        {
            _solr = solr;
        }

        [HttpGet]
        public IEnumerable<Email> Get([FromQuery] string searchQuery)
        {
            // Limit the query to return only 10 documents and also return different results each time. Although I am limiting by 10, I also want to avoid making some emails hidden if the search term is generic (i.e., fraud)
            var randomSeed = new System.Random().Next();
            var queryOptions = new QueryOptions
            {
                Rows = 10,
                OrderBy = new[] { new SortOrder("random_" + randomSeed.ToString()) }
            };

            var results = _solr.Query(new SolrQueryByField("Content", searchQuery), queryOptions);
            return results;
        }
    }
}
