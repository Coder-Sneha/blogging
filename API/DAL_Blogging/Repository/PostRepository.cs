using DAL_Blogging.Interface;
using DAL_Blogging.ModelEnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Blogging.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private readonly AppDbContext _appDb;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDb = appDbContext;
        }
        public async Task<Post> AddPost(Post post)
        {
            var newPost = await _appDb.Posts.AddAsync(post);
            _appDb.SaveChanges();
            return newPost.Entity;
        }

        public void DeletePost(Post post)
        {
            _appDb.Remove(post);
            _appDb.SaveChanges();
        }

        public List<Post> GetBlogLists()
        {
            try
            {
                return _appDb.Posts.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdatePost(Post post)
        {
            _appDb.Posts.Update(post);
            _appDb.SaveChanges();
        }
    }
}
