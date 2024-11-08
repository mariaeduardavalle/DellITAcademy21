using Microsoft.Identity.Client;

public class Tag{
    public int Id {get; set;}
    public List<Post> Posts {get;} = [];
}