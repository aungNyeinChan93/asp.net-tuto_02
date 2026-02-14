

using AdoDotNetService;
using System.Data;
using System.Reflection.Metadata;

namespace One.WebApplication1.Repositories
{
    public class BlogRepo
    {
        private readonly string _connectionStr = $"Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private readonly AdoService adoService;
        

        public BlogRepo()
        {
            this.adoService = new AdoService(this._connectionStr);
        }

        public List<BLogDataModel>? GetAll()
        {
            string query = @"select * from Tbl_blogs where DeleteFlag = 0";
            var blogData = adoService.Query(query);
            List<BLogDataModel> blogs = blogData!.AsEnumerable().Select((r) =>
                new BLogDataModel
                {
                    BlogId = r.Field<int>("BlogId"),
                    Title = r.Field<string>("Title"),
                    AuthorName = r.Field<string>("AuthorName"),
                    Description = r.Field<string>("Description"),
                    DeleteFlage = r.Field<bool>("DeleteFlag")
                }
            ).ToList();

            return blogs.Count >=1 ? blogs : null;

        }

        public BLogDataModel? GetOne(int? id)
        {
            string query = @"select * from tbl_blogs where blogId = @BlogId";
            var blogData = adoService.Query(query, new SqlQueryParameter { Name = "@BlogId", Value = id });

            var blog = blogData!.AsEnumerable().Select(r => new BLogDataModel
            {
                BlogId = r.Field<int>("BlogId"),
                Title = r.Field<string>("Title"),
                AuthorName = r.Field<string>("AuthorName"),
                Description = r.Field<string>("Description"),
                DeleteFlage = r.Field<bool>("DeleteFlag")
            }).FirstOrDefault();

            return blog;
        }

        public bool Create(BLogDataModel blog)
        {
            string query = @"insert into tbl_blogs values (@Title,@Description,@AuthorName,@DeleteFlag)";

            List<SqlQueryParameter> parameters = new List<SqlQueryParameter>
            {
                new SqlQueryParameter { Name = "@Title" , Value = blog?.Title},
                new SqlQueryParameter { Name = "@Description" ,Value = blog?.Description},
                new SqlQueryParameter {Name = "@AuthorName" ,Value = blog?.AuthorName},
                new SqlQueryParameter {Name = "@DeleteFlag" ,Value = 0}
            };
            var result = adoService.Excute(query, parameters);
            return result;
        }

        public bool UpdateAll(int? id, BLogDataModel blog)
        {
            string query = @"update tbl_blogs 
                            set 
                                Title = @Title,
                                Description = @Description,
                                Authorname = @AuthorName
                            where tbl_blogs.BlogId = @BlogId
                            ";
            List<SqlQueryParameter> parameters = new List<SqlQueryParameter>
            {
                new SqlQueryParameter { Name = "@Title" , Value = blog?.Title},
                new SqlQueryParameter { Name = "@Description" ,Value = blog?.Description},
                new SqlQueryParameter {Name = "@AuthorName" ,Value = blog?.AuthorName},
                new SqlQueryParameter {Name = "@BlogId" ,Value = id}
            };

            var result = adoService.Excute(query, parameters);
            return result;
        }

        public bool Delete(int? id)
        {
            string query = @"delete from tbl_blogs where BlogId = @BlogId";
            var result = adoService.Excute(query, new SqlQueryParameter { Name ="@BLogId" ,Value = id});
            return result;
        }
    }

    public class BLogDataModel
    {
        public int BlogId { get; set; }

        public string? Title { get; set; }   

        public string? Description { get; set; } = null;    

        public string? AuthorName { get; set; }

        public bool DeleteFlage { get; set; } = false;
    }
}
