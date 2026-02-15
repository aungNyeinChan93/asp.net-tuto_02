using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Share.EFCore.Models;

namespace One.MInimalApi.EndPoints
{
    public static class BlogEndPoint
    {
        public static AppDbContext db = new AppDbContext();

        public static void UseBlogs(this IEndpointRouteBuilder app)
        {
            //AppDbContext db = new AppDbContext();

            app.MapGet("/api/blogs", () =>
            {
                var result = db.TblBlogs.AsNoTracking().ToList();

                return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            app.MapGet("/api/blogs/{id:int}", ([FromRoute] int? id) =>
            {
                var result = db.TblBlogs.AsNoTracking().FirstOrDefault(b=>b.BlogId == id );

                return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            app.MapPost("/api/blogs", ([FromBody]TblBlog blog) =>
            {
                db.TblBlogs.Add(blog);
                var res = db.SaveChanges();
                return res >=1 ? Results.NoContent() : Results.BadRequest();
            });

            app.MapPut("/api/blogs/{id:int}", ([FromRoute] int? id , [FromBody] TblBlog blog ) =>
            {
                var b = db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
                if (b is null) return Results.NotFound();
                b.Title = blog.Title;
                b.Description = blog.Description;
                b.AuthorName = blog.AuthorName;

                db.Entry(b).State = EntityState.Modified;
                var res = db.SaveChanges();
                return res >= 1 ? Results.Ok("Update success"): Results.BadRequest("Update Fail");
            });

            app.MapDelete("/api/blogs/{id:int}", ([FromRoute]int id) =>
            {
                var b = db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);

                if (b is null) return Results.NotFound();

                db.Entry(b).State = EntityState.Deleted;

                var res = db.SaveChanges();

                return res >= 1 ? Results.Ok("Delete success") : Results.BadRequest("Delete Fail");
            });
        }
        public static void Test(this IEndpointRouteBuilder app )
        {
            Console.WriteLine("Test /.... ");
        }
    }
}
