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
  public async Task<ActionResult<StoryNode>> CreateStoryNode([FromBody] StoryNode storyNodeData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      storyNodeData.CreatorId = userInfo.Id;
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

  [HttpGet("{storyId}/story")]
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

  [HttpGet("{storyNodeId}")]
  public ActionResult<StoryNode> GetStoryNodeById(int storyNodeId)
  {
    try
    {
      StoryNode storyNode = _storyNodesService.GetStoryNodeById(storyNodeId);
      return Ok(storyNode);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [Authorize]
  // [HttpPut("{storyNodeId}")]
  // public async Task<ActionResult<StoryNode>> EditStoryNode(int storyNodeId)
  // {
  //   try
  //   {
  //     Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
  //     StoryNode storyNode = _storyNodesService.EditStoryNode(storyNodeId, userInfo);
  //     return Ok(storyNode);
  //   }
  //   catch (Exception exception)
  //   {
  //     return BadRequest(exception.Message);
  //   }
  // }
}
