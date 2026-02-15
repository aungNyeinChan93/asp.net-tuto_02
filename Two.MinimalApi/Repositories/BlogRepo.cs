using Microsoft.EntityFrameworkCore;
using Share.EFCore.Models;

namespace Two.MinimalApi.Repositories
{
    public static class BlogRepo
    {
        private static AppDbContext _db = new AppDbContext();

        public static List<TblBlog>? GetAllBlogs()
        {
            var blogs = _db.TblBlogs.AsNoTracking().ToList();
            return blogs;
        }

        public static TblBlog? GetOne(int? id)
        {
            var blog = _db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            return blog;
        }
    }
}
