namespace Common
{
    public class Post
    {
        public Post(string id, string title, string body)
        {
            m_id = id;
            m_body = body;
            m_title = title;
        }

        public string Id { get { return m_id; }}
        public string Body { get { return m_body; } }
        public string Title { get { return m_title; } }

        private readonly string m_id;
        private readonly string m_title;
        private readonly string m_body;
    }
}
