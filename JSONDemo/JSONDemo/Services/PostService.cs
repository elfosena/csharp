using JSONDemo.Models;
using JSONDemo.Repositories;
using JSONDemo.Repositories.Abstract;
using JSONDemo.Services.Abstract;

namespace JSONDemo.Services
{
    public class PostService : IPostService
    {
        IPostRepository _postRepository = new PostRepository();
        public void Create(Post entity)
        {
            _postRepository.Create(entity);
        }

        public void Delete(Post entity)
        {
            _postRepository.Delete(entity);
        }

        public Post Get(int id)
        {
            return _postRepository.Get(id);
        }

        public List<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public void Update(Post entity)
        {
            _postRepository.Update(entity);
        }
    }
}
