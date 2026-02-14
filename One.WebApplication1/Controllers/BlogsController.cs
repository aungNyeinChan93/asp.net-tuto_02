using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using One.WebApplication1.Filters.ActionFilters;
using One.WebApplication1.Repositories;

namespace One.WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var blogs = new BlogRepo().GetAll();
            return blogs is not null ? Ok(blogs) : BadRequest("Blogs Not Found!");
        }

        [HttpGet("{id:int}")]
        [BlogGetOneActionFilter]
        public IActionResult GetById([FromRoute]int? id)
        {
            var blog = new BlogRepo().GetOne(id);
            return blog is not null ? Ok(new { blog }) : NotFound();
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody]BLogDataModel blog)
        {
            var isSuccess = new BlogRepo().Create(blog);
            return isSuccess ? NoContent() : BadRequest();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAll([FromRoute]int? id, [FromBody]BLogDataModel blog)
        {
            var result = new BlogRepo().UpdateAll(id, blog);
            return result ? Ok("Update Success") : BadRequest("Update Fail");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBlog([FromRoute]int? id)
        {
            var result = new BlogRepo().Delete(id);
            return result ? NoContent() : BadRequest("Delete fail");
        }
    }
}
