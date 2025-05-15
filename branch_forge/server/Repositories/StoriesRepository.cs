



namespace branch_forge.Repositories;

public class StoriesRepository
{
  public StoriesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Story CreateStory(Story storyData)
  {
    string sql = @"
    INSERT INTO 
    stories(description, title, cover_img, like_count, author_id)
    VALUES(@Description, @Title, @CoverImg, @LikeCount, @AuthorId);

    SELECT 
    stories.*,
    accounts.*
    FROM stories
    INNER JOIN accounts ON accounts.id = stories.author_id
    WHERE stories.id = LAST_INSERT_ID();
    ";

    Story createdStory = _db.Query(sql, (Story story, Profile account) =>
    {
      story.Creator = account;
      return story;
    }, storyData).SingleOrDefault();
    return createdStory;
  }

  internal List<Story> GetAllStories()
  {
    string sql = @"
    SELECT 
    stories.*,
    accounts.*
    FROM stories 
    INNER JOIN accounts ON accounts.id = stories.author_id;";

    List<Story> stories = _db.Query(sql, (Story story, Profile account) =>
    {
      story.Creator = account;
      return story;
    }).ToList();
    return stories;
  }

  internal Story GetStoryById(int storyId)
  {
    string sql = @"
    SELECT 
    stories.*,
    accounts.*
    FROM stories
    INNER JOIN accounts ON accounts.id = stories.author_id
    WHERE stories.id = @storyId;";

    Story story = _db.Query(sql, (Story story, Profile account) =>
    {
      story.Creator = account;
      return story;
    }, new { storyId }).SingleOrDefault();

    return story;
  }

  internal void EditStory(Story story)
  {
    string sql = @"
    UPDATE stories
    SET 
    description = @Description,
    title = @Title,
    cover_img = @CoverImg
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, story);
    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected. please ensure no unnecessary data was changed");
    }
  }

  internal void DeleteStory(int storyId)
  {
    String sql = "DELETE FROM stories WHERE id = @storyId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { storyId });
    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " stories were deleted. Please ensure no unnecessary data was deleted");
    }
  }

  // TODO fix the postman test. something is not right
}