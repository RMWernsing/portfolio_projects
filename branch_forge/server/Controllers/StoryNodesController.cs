namespace branch_forge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoryNodesController : ControllerBase
{
  public StoryNodesController(StoryNodesService storyNodesService)
  {
    _storyNodesService = storyNodesService;
  }
  private readonly StoryNodesService _storyNodesService;

}