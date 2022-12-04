using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
     
    }
}
