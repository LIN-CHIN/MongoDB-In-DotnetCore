using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System.Collections.Generic;

namespace MongoDB_In_DotnetCoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _appUserService;
        public AppUserController(AppUserService appUserService) 
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public ActionResult<IList<AppUserModel>> Get() 
        {
            return Ok(_appUserService.Get().GetResult());
        }

    }
}
