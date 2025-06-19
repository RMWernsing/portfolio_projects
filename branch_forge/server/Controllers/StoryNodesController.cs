namespace branch_forge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoryNodesController : ControllerBase
{
  public StoryNodesController(StoryNodesService storyNodesService, Auth0Provider auth0Provider)
  {
    _storyNodesService = storyNodesService;
    _auth0Provider = auth0Provider;
  }
  private readonly StoryNodesService _storyNodesService;
  private readonly Auth0Provider _auth0Provider;

  [Authorize]
  [HttpPost]
  public ActionResult<StoryNode> CreateStoryNode([FromBody] StoryNode storyNodeData)
  {
    try
    {
      StoryNode storyNode = _storyNodesService.CreateStoryNode(storyNodeData);
      return Ok(storyNode);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{storyId}/first")]
  public ActionResult<StoryNode> GetFirstStoryNode(int storyId)
  {
    try
    {
      StoryNode storyNode = _storyNodesService.GetFirstStoryNode(storyId);
      return Ok(storyNode);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{storyId}")]
  public ActionResult<List<StoryNode>> GetAllStoryNodesForStory(int storyId)
  {
    try
    {
      List<StoryNode> storyNodes = _storyNodesService.GetAllStoryNodesForStory(storyId);
      return Ok(storyNodes);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
