using DAL_Blogging.ModelEnity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Blogging.Interface
{
    public interface IRepository<T>
    {
        public List<T> GetBlogLists();
        public Task<T> AddPost(T _object);
        public void UpdatePost(T _object);
        public void DeletePost(T _object);
    }
}
