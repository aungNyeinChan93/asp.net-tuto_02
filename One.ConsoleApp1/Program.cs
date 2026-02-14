


using One.ConsoleApp1;
using Share.Dapper;

DapperService dapper = new DapperService("Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True");

string query = "select * from Tbl_Blogs";

var blogs = dapper.Query<BlogModel>(query);

foreach (var b in blogs!)
{
    Console.WriteLine($"Author name is {b.AuthorName}");
}

string getOneQuery = @"select 8 from tbl_blogs where BlogId = @BLogId";

var blog = dapper.Query<BlogModel>(query,new { @BlogId = 55 })![0];
Console.WriteLine($"Blog Title is {blog.Title}");