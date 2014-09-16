using System;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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

            DbPost dbPost = new DbPost(null, post.Title, post.Body);

            const string query = @"INSERT INTO
posts.posts (body, title)
VALUES ('@body', '@title');

SELECT LAST_INSERT_ID();";

            int? id;
            using (IDbConnection connection = new MySqlConnection(Settings.Default.MysqlConnectionString))
            using (Utility.Data.MySqlConnection.Create(connection))
            using (IDbTransaction transaction = connection.BeginTransaction())
            {
                id = transaction.Connection.Query<int?>(query, new
                {
                    body = dbPost.Body,
                    title = dbPost.Title
                }).Single();

                transaction.Commit();
            }

            return new Post(id.ToString(), dbPost.Title, dbPost.Body);
        }

    }
}
