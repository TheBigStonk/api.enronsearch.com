using SolrNet.Attributes;

namespace api.enronsearch.com
{
    public class Email
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }

        [SolrField("Date")]
        public List<string> Date { get; set; }

        [SolrField("From")]
        public List<string> From { get; set; }

        [SolrField("To")]
        public List<string> To { get; set; }

        [SolrField("Cc")]
        public List<string> Cc { get; set; }

        [SolrField("Subject")]
        public List<string> Subject { get; set; }

        [SolrField("Content")]
        public List<string> Content { get; set; }
    }
}
