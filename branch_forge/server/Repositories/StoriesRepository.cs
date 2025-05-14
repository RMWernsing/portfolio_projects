namespace branch_forge.Repositories;

public class StoriesRepository
{
  public StoriesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;
}