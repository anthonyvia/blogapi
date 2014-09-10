namespace Common
{
    public class Post
    {
        public Post(string title, string body)
        {
            m_body = body;
            m_title = title;
        }

        public string Body { get { return m_body; } }
        public string Title { get { return m_title; } }

        private readonly string m_title;
        private readonly string m_body;
    }
}
