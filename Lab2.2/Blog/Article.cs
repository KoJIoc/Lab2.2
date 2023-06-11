
namespace Blog
{
    public class Article
    {
        public string Description { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>(); 
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public DateTime DateOfCreation { get; set; }
        public int Id { get; set; }
    }
}