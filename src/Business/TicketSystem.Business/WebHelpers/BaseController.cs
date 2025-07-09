using System.Security.Claims;
using Gronio.Web.Helpers.WebApi;

namespace TicketSystem.Business.WebHelpers;

public abstract class BaseController : BaseApiController
{
    protected short AdminId => Convert.ToInt16(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
    protected string IpAddress => "127.0.0.1";
}