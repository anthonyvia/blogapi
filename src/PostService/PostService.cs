using System;
using System.Data;
using Common;
using Dapper;
using MySql.Data.MySqlClient;
using PostService.Db;
using PostService.Properties;

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
            string query = @"INSERT INTO posts.posts (body, title) VALUES ('@body', '@title');";

            using (IDbConnection connection = new MySqlConnection(Settings.Default.MysqlConnectionString))
            {
                connection.Execute(query, new
                {
                    body = dbPost.Body,
                    title = dbPost.Title
                });
            }

            return new Post(dbPost.Title, dbPost.Body);
        }

    }
}
