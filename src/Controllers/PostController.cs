using System.Net;
using System.Net.Http;
using System.Web.Http;
using blogapi.Models;

namespace blogapi.Controllers
{
    public class PostController : ApiController
    {
        public HttpResponseMessage CreatePost(Post post = null)
        {
            if (post == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "post cannot be null");
            if (string.IsNullOrWhiteSpace(post.Body))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "post body cannot be empty");
            if (string.IsNullOrWhiteSpace(post.Title))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "post title cannot be empty");

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "create post not allowed");
        }
    }
}
