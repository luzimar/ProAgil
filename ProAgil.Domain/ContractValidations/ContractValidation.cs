using Flunt.Validations;

namespace ProAgil.Domain.ContractValidations
{
    public abstract class ContractValidation : Contract
    {
        public abstract Contract GetContract();
    }
}
