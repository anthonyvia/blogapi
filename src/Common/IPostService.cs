namespace Common
{
    public interface IPostService
    {
        Post CreatePost(Post post);
        Post GetPost(string id);
    }
}
