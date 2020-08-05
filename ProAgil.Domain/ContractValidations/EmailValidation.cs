using Flunt.Validations;
using ProAgil.Domain.ValueObjects;

namespace ProAgil.Domain.ContractValidations
{
    public class EmailValidation : ContractValidation
    {
        private readonly Email _email;
        public EmailValidation(Email email)
        {
            _email = email;
        }

        public override Contract GetContract()
        {
            return Requires().IsEmail(_email.Address, "Email.Address", "E-mail inválido");
        }
    }
}
