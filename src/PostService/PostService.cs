using System;
using Common;
using PostService.Db;

namespace PostService
{
    public class PostService : IPostService
    {
        public Post CreatePost(Post post)
        {
            if (post == null)
                throw new ArgumentException("post cannot be null", "post");

            DbPost dbPost = new DbPost(post.Title, post.Body);

            // TODO: Add MySQL connection/query

            return new Post(dbPost.Title, dbPost.Body);
        }

    }
}
