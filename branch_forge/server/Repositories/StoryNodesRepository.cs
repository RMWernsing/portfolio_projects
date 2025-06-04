

namespace branch_forge.Repositories;

public class StoryNodesRepository
{
  public StoryNodesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal StoryNode CreateStory(StoryNode storyNodeData)
  {
    string sql = @"
    INSERT INTO 
    story_nodes(body, is_ending, story_id)
    VALUES(@Body, @IsEnding, @StoryId);

    SELECT * FROM story_nodes WHERE id = LAST_INSERT_ID();
    ";

    StoryNode createdStoryNode = _db.Query<StoryNode>(sql, storyNodeData).SingleOrDefault();
    return createdStoryNode;
  }

  internal StoryNode GetFirstStoryNode(int storyId)
  {
    string sql = @"
    SELECT * FROM story_node WHERE story_id = @storyId
    ";
  }
}