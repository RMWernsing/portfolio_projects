


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

  internal List<Story> GetAllStories()
  {
    List<Story> stories = _repository.GetAllStories();
    return stories;
  }

  internal Story GetStoryById(int storyId)
  {
    Story story = _repository.GetStoryById(storyId);
    if (story == null)
    {
      throw new Exception("Invalid id: " + storyId);
    }
    return story;
  }
}