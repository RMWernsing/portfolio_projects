namespace branch_forge.Services;

public class StoryNodesService
{
  public StoryNodesService(StoryNodesRepository repository)
  {
    _repository = repository;
  }
  private readonly StoryNodesRepository _repository;

}