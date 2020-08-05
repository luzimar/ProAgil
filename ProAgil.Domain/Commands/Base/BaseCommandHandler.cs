using ProAgil.Domain.Commands.Eventos;

namespace ProAgil.Domain.Commands.Base
{
    public abstract class BaseCommandHandler<T> where T: new()
    {
        public T Response { get; protected set; } = new T();
    }
}
