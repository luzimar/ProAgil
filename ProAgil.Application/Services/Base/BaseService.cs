namespace ProAgil.Application.Services.Base
{
    public abstract class BaseService<T> where T: new()
    {
        public T Response { get; set; } = new T();
    }
}
