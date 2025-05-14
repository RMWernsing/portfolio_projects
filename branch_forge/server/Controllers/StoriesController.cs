namespace branch_forge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
  public StoriesController(StoriesService storiesService)
  {
    _storiesService = storiesService;
  }
  private readonly StoriesService _storiesService;

  [Authorize]
  [HttpPost]

}