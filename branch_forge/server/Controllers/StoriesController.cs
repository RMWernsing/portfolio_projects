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

  [HttpGet("{storyId}")]
  public ActionResult<Story> GetStoryById(int storyId)
  {
    try
    {
      Story story = _storiesService.GetStoryById(storyId);
      return Ok(story);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpPut("{storyId}")]
  public async Task<ActionResult<Story>> EditStory([FromBody] Story storyData, int storyId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Story story = _storiesService.EditStory(storyData, storyId, userInfo);
      return Ok(story);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{storyId}")]
  public async Task<ActionResult<String>> DeleteStory(int storyId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      String message = _storiesService.DeleteStory(userInfo, storyId);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}