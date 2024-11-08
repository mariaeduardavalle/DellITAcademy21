public class Post
{
    public int Id { get; set; }
    public required string Texto { get; set; }
    public required Blog B {get; set;}
    public int blogId {get; set;}
    public List<Tag> Tags{get;} = [];

}