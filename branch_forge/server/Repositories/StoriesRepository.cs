
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
    VALUES(@Description, @Title, @CoverImg, @LikeCount, @AuthorId)

    SELECT 
    stories.*,
    accounts.*
    INNER JOIN accounts ON accounts.id = stories.author_id
    WHERE stories.id = LAST_CREATED_ID();
    ";

    Story createdStory = _db.Query(sql, (Story story, Profile account) =>
    {
      story.Creator = account;
      return story;
    }, storyData).SingleOrDefault();
    return createdStory;
  }
  // TODO fix the postman test. something is not right
}