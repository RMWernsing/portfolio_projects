
namespace branch_forge.Services;

public class StoriesService
{
  public StoriesService(StoriesRepository repository)
  {
    _repository = repository;
  }
  private readonly StoriesRepository _repository;

  internal Story CreateStory(Story storyData)
  {
    Story story = _repository.CreateStory(storyData);
    return story;
  }
}