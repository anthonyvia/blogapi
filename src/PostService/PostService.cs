using System;
using System.Data;
using System.Linq;
using Common;
using Dapper;
using MySql.Data.MySqlClient;
using PostService.Properties;

namespace PostService
{
    public class PostService : IPostService
    {
        public Post CreatePost(Post post)
        {
            if (post == null)
                throw new ArgumentException("post cannot be null", "post");

            const string query = @"INSERT INTO
posts.posts (body, title, date_created)
VALUES ('@body', '@title', @dateCreated);

SELECT LAST_INSERT_ID();";

            int? id;
            DateTime dateCreated = DateTime.UtcNow;
            using (IDbConnection connection = new MySqlConnection(Settings.Default.MysqlConnectionString))
            using (Utility.Data.MySqlConnection.Create(connection))
            using (IDbTransaction transaction = connection.BeginTransaction())
            {
                id = transaction.Connection.Query<int?>(query, new
                {
                    body = post.Body,
                    title = post.Title,
                    dateCreated = dateCreated
                }).Single();

                transaction.Commit();
            }

            return new Post(id.ToString(), post.Title, post.Body, dateCreated);
        }

    }
}
