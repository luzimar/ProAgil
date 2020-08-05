using ProAgil.Domain.Commands.Base;
using ProAgil.Domain.Models;

namespace ProAgil.Domain.Response
{
    public class PalestranteResponse : BaseResponse
    {
        public Palestrante Palestrante { get; set; }
        public Palestrante[] Palestrantes { get; set; }
    }
}
