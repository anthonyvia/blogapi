using System.Net;
using System.Net.Http;
using System.Web.Http;
using blogapi.Models;
using Common;

namespace blogapi.Controllers
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

            Post createdPost = m_postService.CreatePost(new Post(post.Title, post.Body));

            return Request.CreateResponse(
                HttpStatusCode.Created,
                new PostDto
                {
                    Body = createdPost.Body,
                    Title = createdPost.Title
                });
        }

        private readonly IPostService m_postService;
    }
}
