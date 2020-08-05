
namespace ProAgil.Domain.Commands.Base
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public InnerResponse InnerResponse { get; set; } = new InnerResponse();
    }
}
