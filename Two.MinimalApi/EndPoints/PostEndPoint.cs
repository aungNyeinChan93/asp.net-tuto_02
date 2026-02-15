using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Two.MinimalApi.Repositories;

namespace Two.MinimalApi.EndPoints
{
    public static class PostEndPoint
    {

        public static void UsePost(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/posts", () =>
            {
                string filePath = "Data/Posts.json";
                var jsonData = File.ReadAllText(filePath,Encoding.UTF8);

                var postRepo = JsonConvert.DeserializeObject<PostRepo>(jsonData);

                return postRepo is not null ? Results.Ok(new { Posts = postRepo?.posts }) : Results.BadRequest();
            });

            app.MapGet("/api/posts/{id:int}", ([FromRoute]int? id) =>
            {
                string filePath = "Data/Posts.json";
                var jsonData = File.ReadAllText(filePath, Encoding.UTF8);

                var postRepo = JsonConvert.DeserializeObject<PostRepo>(jsonData);

                var post = postRepo!.posts.FirstOrDefault(p => p.id == id);
                return post is not null ? Results.Ok(post) : Results.NotFound();
            });
        }
    }
}


