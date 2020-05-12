using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BlogApi.Infrastructure.Dtos;
using BlogApi.Infrastructure.Interfaces;
using BlogApi.Infrastructure.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    /// <summary>
    /// Class for Blog Post Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        /// <summary>
        /// Constructor for Blog Post Controller
        /// </summary>
        /// <param name="blogPostService"></param>
        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        /// <summary>
        /// Endpoint to get all Blog Posts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BlogPostDto>>> GetBlogPost()
        {
            return Ok(await _blogPostService.GetAllBlogPostsAsync());
        }
        /// <summary>
        /// Endpoint to get Blog Post by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlogPostDto>> GetBlogPost(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostById(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return Ok(blogPost);
        }
        /// <summary>
        /// Endpoint to PUT Blog Post for Specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blogPostResource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBlogPost(int id, BlogPostResource blogPostResource)
        {
            var blogPost = await _blogPostService.SaveBlogPost(id, blogPostResource);
            if (blogPost == null)
            {
                return NotFound();
            }
            return Ok(blogPost);
        }
        /// <summary>
        /// Endpoint to Create new BlogPost
        /// </summary>
        /// <param name="blogPostResource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BlogPostDto>> PostBlogPost(BlogPostResource blogPostResource)
        {
            return StatusCode((int)HttpStatusCode.Created, await _blogPostService.CreateBlogPost(blogPostResource));
        }
        /// <summary>
        /// Endpoint to Delete BlogPost by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogPostDto>> DeleteBlogPost(int id)
        {
            return await _blogPostService.DeleteBlogPostById(id);
        }
    }
}
