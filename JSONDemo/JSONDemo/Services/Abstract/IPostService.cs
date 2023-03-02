using JSONDemo.Models;

namespace JSONDemo.Services.Abstract
{
    public interface IPostService
    {
        Post Get(int id);
        List<Post> GetAll();
        void Create(Post entity);
        void Delete(Post entity);
        void Update(Post entity);
    }
}
