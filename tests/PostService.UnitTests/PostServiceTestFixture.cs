using System;
using Common;
using NUnit.Framework;

namespace PostService.UnitTests
{
    [TestFixture]
    public class PostServiceTestFixture
    {
        [TestFixtureSetUp]
        public void SetupTests()
        {
            m_postService = new PostService();
        }

        [TestCase]
        [ExpectedException (typeof(ArgumentException))]
        public void CreatePostWithNullPost()
        {
            m_postService.CreatePost(null);
        }

        [TestCase]
        public void CreatePost()
        {
            Post postToCreate = new Post(null, c_testTitle, c_testBody, null);
            DateTime timeBeforeCreate = DateTime.UtcNow;
            Post createdPost = m_postService.CreatePost(postToCreate);
            DateTime timeAfterCreate = DateTime.UtcNow;

            Assert.IsNotNull(createdPost);
            Assert.IsFalse(string.IsNullOrWhiteSpace(createdPost.Id));
            Assert.IsNotNull(createdPost.DateCreated);
            Assert.AreEqual(postToCreate.Body, createdPost.Body);
            Assert.AreEqual(postToCreate.Title, createdPost.Title);
            Assert.IsTrue(createdPost.DateCreated >= timeBeforeCreate && createdPost.DateCreated <= timeAfterCreate);
        }

        [ExpectedException (typeof(ArgumentException))]
        public void GetPostWithNullId()
        {
            m_postService.GetPost(null);
        }

        [ExpectedException(typeof (ArgumentException))]
        public void GetPostWithInvalidId()
        {
            m_postService.GetPost("badId");
        }

        [TestCase]
        public void GetPost()
        {
            Post postToCreate = new Post(null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), null);
            Post createdPost = m_postService.CreatePost(postToCreate);
            Post retrievedPost = m_postService.GetPost(createdPost.Id);

            Assert.IsNotNull(retrievedPost);
            Assert.IsFalse(string.IsNullOrWhiteSpace(retrievedPost.Id));
            Assert.AreEqual(createdPost.Id, retrievedPost.Id);
            Assert.AreEqual(postToCreate.Body, retrievedPost.Body);
            Assert.AreEqual(postToCreate.Title, retrievedPost.Title);
            Assert.IsNotNull(createdPost.DateCreated);
            Assert.IsNotNull(retrievedPost.DateCreated);
            Assert.IsTrue(TestUtility.TestUtility.AreEqualDates(createdPost.DateCreated.Value, retrievedPost.DateCreated.Value));
        }

        private PostService m_postService;
        private const string c_testTitle = "title";
        private const string c_testBody = "body";
    }
}
