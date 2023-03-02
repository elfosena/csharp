using JSONDemo.Models;
using JSONDemo.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JSONDemo.Repositories
{
    public class PostRepository : IPostRepository
    {
        JsonContext db = new JsonContext();

        public void Create(Post entity)
        {
            db.Posts.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Post entity)
        {
            db.Posts.Remove(entity);
            db.SaveChanges();
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public List<Post> GetAll()
        {
            return db.Posts.ToList();
        }

        public void Update(Post entity)
        {
            db.Posts.Update(entity);
            db.SaveChanges();
        }
    }
}
