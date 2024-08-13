using Microsoft.AspNetCore.Mvc;

namespace Insure.X.Api.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public abstract class InsureXController : ControllerBase
{
}
