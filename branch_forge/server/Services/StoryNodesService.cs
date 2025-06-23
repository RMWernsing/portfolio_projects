



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

  internal StoryNode GetStoryNodeById(int storyNodeId)
  {
    StoryNode storyNode = _repository.GetStoryNodeById(storyNodeId);
    // Null Check to be abstracted when this method is called in other places
    if (storyNode == null)
    {
      throw new Exception("Invalid Id: " + storyNodeId + " Your story does not exist.");
    }
    return storyNode;
  }

  internal StoryNode EditStoryNode(StoryNode storyNodeData, int storyNodeId, Account userInfo)
  {
    StoryNode storyNode = GetStoryNodeById(storyNodeId);
    if (storyNode.CreatorId != userInfo.Id)
    {
      throw new Exception("YOU DO NOT HAVE PERMISSION TO EDIT ANOTHER PERSONS STORY NODE!");
    }
    storyNode.Body = storyNodeData.Body ?? storyNode.Body;
    storyNode.IsEnding = storyNodeData.IsEnding ?? storyNode.IsEnding;

    _repository.EditStoryNode(storyNode);
    return storyNode;
  }

  internal string DelteStoryNode(int storyNodeId, Account userInfo)
  {
    StoryNode storyNode = GetStoryNodeById(storyNodeId);
    if (storyNode.CreatorId != userInfo.Id)
    {
      throw new Exception("YOU CANNOT DELETE SOMEONE ELSES STORY NODE " + userInfo.Name.ToUpper() + "!!!");
    }
    _repository.DeleteStoryNode(storyNodeId);
    return "Your Story Node has been deleted";
  }
}