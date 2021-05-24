using BAL_Blogging;
using BAL_Blogging.Service;
using DAL_Blogging.ModelEnity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApiWithAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggingController : BaseController
    {
        private readonly PostBusiness _postBusiness;

        #region Contructor Injector
        /// <summary>
        /// Constructor Injection to access all methods or simply DI(Dependency Injection)
        /// </summary>
        public BloggingController(PostBusiness postBusiness)
        {
            _postBusiness = postBusiness;
        }
        #endregion

        #region Add New Blog
        /// <summary>
        /// Post a new blog
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        {
            try
            {
                await _postBusiness.AddPost(post);
                return Ok("Successfully added post.");

            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Get all blog list
        /// <summary>
        /// Display list og blogs
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet("BlogsList")]
        public async Task<IActionResult> GetAllBlog()
        {
            try
            {
                var blogs = _postBusiness.GetAllPosts();
                if (blogs.Count > 0)
                    return Ok(blogs);
                else
                    return NoContent();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Update blog
        /// <summary>
        /// Update a particular blog
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut("UpdateBlog")]
        public async Task<IActionResult> UpdateBlog([FromBody] PostDto post)
        {
            try
            {
                _postBusiness.UpdatePost(post);
                return Ok("Updated successfully");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete blog
        /// <summary>
        /// Delete a particular blog
        /// </summary>
        /// <param name="postID"></param>
        /// <returns></returns>
        [HttpGet("DeleteBlog/{postId}")]
        public async Task<IActionResult> DeleteBlog(int postId)
        {
            try
            {
              _postBusiness.DeletePost(postId);
               return Ok("Deleted successfully");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
