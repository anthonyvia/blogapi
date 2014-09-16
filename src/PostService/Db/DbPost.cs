using System;

namespace PostService.Db
{
    public class DbPost
    {
        public int? Id { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime? DateCreated { get; set; }

        private readonly int? m_id;
        private readonly string m_title;
        private readonly string m_body;
        private DateTime m_dateCreated;
    }
}
