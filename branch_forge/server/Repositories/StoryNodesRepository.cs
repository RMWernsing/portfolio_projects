namespace branch_forge.Repositories;

public class StoryNodesRepository
{
  public StoryNodesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

}