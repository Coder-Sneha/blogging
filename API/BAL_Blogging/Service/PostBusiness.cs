using DAL_Blogging.Interface;
using DAL_Blogging.ModelEnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_Blogging.Service
{
    public class PostBusiness
    {
        private readonly IRepository<Post> _repository;

        public PostBusiness(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public Post GetPostByPostId(int postid)
        {
            return _repository.GetBlogLists().Where(p => p.PostId == postid).FirstOrDefault();
        }
        public List<PostDto> GetAllPosts()
        {
            try
            {
                List<PostDto> postDtos = new List<PostDto>();
                var blogList= _repository.GetBlogLists();
                foreach(var blog in blogList)
                {
                    PostDto postDto = new PostDto();
                    postDto.PostId = blog.PostId;
                    postDto.PostTitle = blog.PostTitle;
                    postDto.PostContent = blog.PostContent;
                    postDto.PostAuthor = blog.PostAuthor;
                    postDto.IsDeleted = blog.IsDeleted;

                    postDtos.Add(postDto);
                }
                return postDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePost(int postId)
        {
            try
            {
                var post = GetPostByPostId(postId);
                if (post != null)
                {
                    post.IsDeleted = true;
                    post.DateEdited = DateTime.Now;
                    _repository.UpdatePost(post);
                }
                else
                {
                   throw new ApplicationException($"Post with Id:{post.PostId} doesnot exist.");
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        public void UpdatePost(PostDto upPost)
        {
            try
            {
                var post = GetPostByPostId(upPost.PostId);
                if (post != null)
                {
                    post.PostTitle = upPost.PostTitle;
                    post.PostContent = upPost.PostContent;
                    post.PostAuthor = upPost.PostAuthor;
                    post.DateEdited = DateTime.Now;
                    post.IsDeleted = false;

                    _repository.UpdatePost(post);
                }
                else
                {
                  throw  new ApplicationException($"Post with Id:{upPost.PostId} doesnot exist.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Post> AddPost(Post post)
        {
            post.IsDeleted = false;
            
            return await _repository.AddPost(post);
        }
    }
}
