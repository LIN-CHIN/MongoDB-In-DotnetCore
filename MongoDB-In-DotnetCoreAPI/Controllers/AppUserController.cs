using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.ResultModel;
using Service.interfaces;
using System.Collections.Generic;

namespace MongoDB_In_DotnetCoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService) 
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public ReturnModel Get() 
        {
            return _appUserService.Get().GetResult();
        }

        [HttpPost]
        public ReturnModel Post([FromBody] AppUserInsertDTO dto)
        {
            return _appUserService.Post(dto).GetResult();
        }

        [HttpPatch]
        public ReturnModel Update([FromBody] AppUserUpdateDTO dto)
        {
            return _appUserService.Update(dto).GetResult();
        }

        [HttpDelete]
        public ReturnModel Delete([FromBody] AppUserDeleteDTO dto)
        {
            return _appUserService.Delete(dto).GetResult();
        }

    }
}
