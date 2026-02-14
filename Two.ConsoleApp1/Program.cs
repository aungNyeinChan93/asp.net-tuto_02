

using Microsoft.EntityFrameworkCore;
using Share.EFCore.Models;

AppDbContext db = new AppDbContext();

var blogs = db.TblBlogs.AsNoTracking().ToList();

foreach (var b in blogs)
{
    Console.WriteLine($"Blog Title is {b.Title}");
}


var blog = db.TblBlogs.AsNoTracking().Where(b=>b.BlogId == 68).FirstOrDefault();
Console.WriteLine($"Find BLog Title is {blog!.Title}");


blog.Title = "Change Title";
db.Entry(blog).State = EntityState.Modified;
db.SaveChanges();

db.Entry(blog).State = EntityState.Deleted;
db.SaveChanges();
