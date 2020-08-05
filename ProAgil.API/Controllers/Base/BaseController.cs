using Microsoft.AspNetCore.Mvc;
using ProAgil.Application.Response.Base;

namespace ProAgil.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public IActionResult GetResponse(BaseResponse response)
        {
            if (response.Success)
                return Ok(response.InnerResponse);

            return BadRequest(response.InnerResponse);
        }

        public string GetCustomMessageError500(string verb)
        {
            return $"Erro ao { verb }, tente novamente em alguns instantes";
        }
    }
}
