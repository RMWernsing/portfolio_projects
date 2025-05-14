namespace branch_forge.Models;

public class Story : RepoItem<int>
{
  public string Description { get; set; }
  public string Title { get; set; }
  public string CoverImg { get; set; }
  public int LikeCount { get; set; }
  public string AuthorId { get; set; }
}