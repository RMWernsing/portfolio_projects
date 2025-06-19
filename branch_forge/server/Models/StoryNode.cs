namespace branch_forge.Models;

public class StoryNode : RepoItem<int>
{
  public string Body { get; set; }
  public bool? IsEnding { get; set; }
  public int StoryId { get; set; }
  public string CreatorId { get; set; }
}