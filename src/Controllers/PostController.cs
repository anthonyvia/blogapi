﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogApi.Models;
using Common;

namespace BlogApi.Controllers
{
    public class PostController : ApiController
    {
        public PostController(IPostService postService)
        {
            m_postService = postService;
        }

        [HttpPost]
        public HttpResponseMessage CreatePost(PostDto post)
        {
            if (post == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "post cannot be null");
            if (string.IsNullOrWhiteSpace(post.Body))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "post body cannot be empty");
            if (string.IsNullOrWhiteSpace(post.Title))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "post title cannot be empty");
            if (post.Body.Length > Utility.Constants.MaxPostBodyLength)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("post body length cannot exceed {0} characters", Utility.Constants.MaxPostBodyLength));
            if (post.Title.Length > Utility.Constants.MaxPostTitleLength)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("post title length cannot exceed {0} characters", Utility.Constants.MaxPostTitleLength));

            Post createdPost = m_postService.CreatePost(new Post(null, post.Title, post.Body, null));

            return Request.CreateResponse(
                HttpStatusCode.Created,
                new PostDto
                {
                    Id = createdPost.Id,
                    Body = createdPost.Body,
                    Title = createdPost.Title,
                    DateCreated = createdPost.DateCreated
                });
        }

        [HttpGet]
        public HttpResponseMessage GetPost(string id = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "postId is required");

            Post post = m_postService.GetPost(id);

            if (post == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("post {0} not found", id));

            return Request.CreateResponse(
                HttpStatusCode.OK,
                new PostDto
                {
                    Id = post.Id,
                    Body = post.Body,
                    Title = post.Title,
                    DateCreated = post.DateCreated
                });
        }

        private readonly IPostService m_postService;
    }
}
