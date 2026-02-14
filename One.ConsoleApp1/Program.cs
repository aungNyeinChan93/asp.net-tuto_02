


using One.ConsoleApp1;
using Share.Dapper;

DapperService dapper = new DapperService("Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True");

string query = "select * from Tbl_Blogs";

var blogs = dapper.Query<BlogModel>(query);

foreach (var b in blogs!)
{
    Console.WriteLine($"Author name is {b.AuthorName}");
}

string getOneQuery = @"select * from tbl_blogs where BlogId = @BLogId";

var blog = dapper.Query<BlogModel>(getOneQuery,new { @BlogId = 72 })![0];
Console.WriteLine($"Blog Title is {blog.Title}");


string createQuery = @"insert into tbl_blogs values (@Title,@Description,@AuthorName,@DeleteFlag)";
var res = dapper.Excute(createQuery, new BlogModel { Title = "Tttt", Description = "DDDD", AuthorName = "AAAAA",DeleteFlag = false});

Console.WriteLine(res ? "success":"false");

string updateQuery = @"update tbl_blogs set Title = @Title where BlogId = @BlogId";
var res2 = dapper.Excute(updateQuery,new {Title = "change title" , BlogId = 70});
Console.WriteLine(res2 ? "Update success":"Update Fail");

string deleteQuery = @"delete from tbl_blogs where BlogId  = @BlogId";
var res3 = dapper.Excute(deleteQuery, new { BlogId = 70 });
Console.WriteLine(res3 ? "Delete success":"Delete Fail");