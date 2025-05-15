


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

  internal Story EditStory(Story storyData, int storyId, Account userInfo)
  {
    Story story = GetStoryById(storyId);
    if (story.AuthorId != userInfo.Id)
    {
      throw new Exception("YOU DO NOT HAVE PERMISSION TO EDIT SOMEONE ELSES STORY!");
    }

    story.Description = storyData.Description ?? story.Description;
    story.Title = storyData.Title ?? story.Title;
    story.CoverImg = storyData.CoverImg ?? story.CoverImg;

    _repository.EditStory(story);
    return story;
  }

  internal string DeleteStory(Account userInfo, int storyId)
  {
    Story story = GetStoryById(storyId);
    if (story.AuthorId != userInfo.Id)
    {
      throw new Exception("YOU DO NOT HAVE PERMISSION TO DELETE SOMEONE ELSES STORY!");
    }
    _repository.DeleteStory(storyId);
    // NOTE this is creating a variable that puts quotes around the story's title
    char quote = '"';
    return $"The story named {quote}{story.Title}{quote} has been deleted successfully!";
  }
}