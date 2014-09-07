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
            if (post.Body.Length > Utility.Constants.MaxPostBodyLength)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("post body length cannot exceed {0} characters", Utility.Constants.MaxPostBodyLength));
            if (post.Title.Length > Utility.Constants.MaxPostTitleLength)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("post title length cannot exceed {0} characters", Utility.Constants.MaxPostTitleLength));

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "create post not allowed");
        }
    }
}
