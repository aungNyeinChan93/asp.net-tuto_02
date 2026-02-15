namespace Two.MinimalApi.Repositories
{
    

    public class PostRepo
    {
        public List<Post> posts { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string[] tags { get; set; }
        public Reactions reactions { get; set; }
        public int views { get; set; }
        public int userId { get; set; }
    }

    public class Reactions
    {
        public int likes { get; set; }
        public int dislikes { get; set; }
    }

}
