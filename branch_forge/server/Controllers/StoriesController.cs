namespace branch_forge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
  private readonly StoriesService _storiesService;
}