using Microsoft.AspNetCore.Mvc;
using Two.MinimalApi.Repositories;

namespace Two.MinimalApi.EndPoints
{
    public static class BlogEndPoint
    {
        public static void UseBlog(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/blogs", () =>
            {
                var blogs = BlogRepo.GetAllBlogs();
                return blogs is not null ? Results.Ok(new { blogs }) : Results.NotFound();
            });

            app.MapGet("/api/blogs/{id:int}", ([FromRoute]int? id) =>
            {
                var blog = BlogRepo.GetOne(id);
                return blog is null ? Results.NotFound() :Results.Ok(blog);
            });

          
        }
    }

    
}
