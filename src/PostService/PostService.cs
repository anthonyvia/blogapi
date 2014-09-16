using System;
using System.Data;
using System.Linq;
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

        public Post GetPost(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("id must be set", "id");

            int? convertedId;
            bool wasConverted = Utility.NumberUtility.TryConvert(id, out convertedId);
            if (!wasConverted || !convertedId.HasValue)
                throw new ArgumentException("id is not valid", "id");

            const string query = @"
SELECT p.id AS 'Id', p.body AS 'Body', p.title AS 'Title', p.date_created AS 'DateCreated'
FROM posts.posts p
WHERE p.id = @id;";

            DbPost dbPost;
            using (IDbConnection connection = new MySqlConnection(Settings.Default.MysqlConnectionString))
            {
                dbPost = connection.Query<DbPost>(query, new
                {
                    id = convertedId.Value
                }).SingleOrDefault();
            }

            if (dbPost == null)
                return null;

            return new Post(dbPost.Id.ToString(), dbPost.Title, dbPost.Body, dbPost.DateCreated);
        }

    }
}
