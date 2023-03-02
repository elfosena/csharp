using JSONDemo.Models;

namespace JSONDemo.Repositories.Abstract
{
    public interface IPostRepository
    {
        Post Get(int id);
        List<Post> GetAll();
        void Create(Post entity);
        void Delete(Post entity);
        void Update(Post entity);
    }
}
