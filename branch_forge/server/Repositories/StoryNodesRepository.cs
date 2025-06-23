




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
    story_nodes(body, is_ending, story_id, creator_id)
    VALUES(@Body, @IsEnding, @StoryId, @CreatorId);

    SELECT * FROM story_nodes WHERE id = LAST_INSERT_ID();
    ";

    StoryNode createdStoryNode = _db.Query<StoryNode>(sql, storyNodeData).SingleOrDefault();
    return createdStoryNode;
  }

  internal StoryNode GetFirstStoryNode(int storyId)
  {
    string sql = @"
    SELECT * FROM story_nodes WHERE story_id = @storyId ORDER BY id ASC LIMIT 1;";
    StoryNode storyNode = _db.Query<StoryNode>(sql, new { storyId }).SingleOrDefault();
    return storyNode;
  }

  internal List<StoryNode> GetAllStoryNodesForStory(int storyId)
  {
    string sql = @"SELECT * FROM story_nodes WHERE story_id = @storyId";
    List<StoryNode> storyNodes = _db.Query<StoryNode>(sql, new { storyId }).ToList();
    return storyNodes;
  }

  internal StoryNode GetStoryNodeById(int storyNodeId)
  {
    string sql = "SELECT * FROM story_nodes WHERE id = @storyNodeId";

    StoryNode storyNode = _db.Query<StoryNode>(sql, new { storyNodeId }).SingleOrDefault();
    return storyNode;
  }

  internal void EditStoryNode(StoryNode storyNode)
  {
    string sql = @"
    UPDATE story_nodes
    SET 
    body = @Body,
    is_ending = @IsEnding
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, storyNode);
    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected. Somethings went wrong. Please check to make sure your data is intact.");
    }
  }

  internal void DeleteStoryNode(int storyNodeId)
  {
    string sql = @"DELETE FROM story_nodes WHERE id = @storyNodeId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { storyNodeId });

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected. Something went wrong. Please check to make sure your data is intact.");
    }
  }
}