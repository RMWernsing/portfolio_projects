namespace branch_forge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
  public StoriesController(StoriesService storiesService, Auth0Provider auth0Provider)
  {
    _storiesService = storiesService;
    _auth0Provider = auth0Provider;
  }
  private readonly StoriesService _storiesService;
  private readonly Auth0Provider _auth0Provider;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Story>> CreateStory([FromBody] Story storyData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      storyData.AuthorId = userInfo.Id;
      Story story = _storiesService.CreateStory(storyData);
      return Ok(story);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }

  }

  [HttpGet]
  public ActionResult<List<Story>> GetAllStories()
  {
    try
    {
      List<Story> stories = _storiesService.GetAllStories();
      return Ok(stories);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}