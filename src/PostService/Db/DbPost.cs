namespace PostService.Db
{
    public class DbPost
    {
        public DbPost(int? id, string title, string body)
        {
            m_id = id;
            m_body = body;
            m_title = title;
        }

        public int? Id { get { return m_id; }}
        public string Body { get { return m_body; }}
        public string Title { get { return m_title; }}

        private readonly int? m_id;
        private readonly string m_title;
        private readonly string m_body;
    }
}
