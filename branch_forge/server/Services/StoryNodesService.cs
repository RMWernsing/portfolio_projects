


namespace branch_forge.Services;

public class StoryNodesService
{
  public StoryNodesService(StoryNodesRepository repository)
  {
    _repository = repository;
  }
  private readonly StoryNodesRepository _repository;

  internal StoryNode CreateStoryNode(StoryNode storyNodeData)
  {
    StoryNode storyNode = _repository.CreateStory(storyNodeData);
    return storyNode;
  }

  internal StoryNode GetFirstStoryNode(int storyId)
  {
    StoryNode storyNode = _repository.GetFirstStoryNode(storyId);
    return storyNode;
  }

  internal List<StoryNode> GetAllStoryNodesForStory(int storyId)
  {
    List<StoryNode> storyNodes = _repository.GetAllStoryNodesForStory(storyId);
    return storyNodes;
  }
}