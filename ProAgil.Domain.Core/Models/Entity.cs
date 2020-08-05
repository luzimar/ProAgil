using Flunt.Notifications;

namespace ProAgil.Domain.Core.Models
{
    public abstract class Entity : Notifiable
    {
        public int Id { get; set; }
    }
}
