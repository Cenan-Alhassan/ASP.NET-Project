
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase // causes unforseen errors if not include : controllerBase
    {
        
        
    }
}