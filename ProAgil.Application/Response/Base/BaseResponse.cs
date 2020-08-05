
namespace ProAgil.Application.Response.Base
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public InnerResponse InnerResponse { get; set; } = new InnerResponse();
    }
}
