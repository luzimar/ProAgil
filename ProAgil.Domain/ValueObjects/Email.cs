using ProAgil.Domain.ContractValidations;

namespace ProAgil.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;

            AddNotifications(new EmailValidation(this).GetContract());
        }
    }
}
