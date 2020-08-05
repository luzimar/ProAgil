using Flunt.Validations;
using ProAgil.Domain.ValueObjects;

namespace ProAgil.Domain.ContractValidations
{
    public class QuantidadePessoasValidation : ContractValidation
    {

        private readonly QuantidadePessoas _quantidadePessoas;
        public QuantidadePessoasValidation(QuantidadePessoas quantidadePessoas)
        {
            _quantidadePessoas = quantidadePessoas;
        }
        public override Contract GetContract()
        {
            return Requires().IsGreaterThan(_quantidadePessoas.Quantidade, 20, "QuantidadePessoas.Quantidade", "Quantidade de pessoas deve ser no mínimo 20")
                             .IsLowerThan(_quantidadePessoas.Quantidade, 20000, "QuantidadePessoas.Quantidade", "Quantidade de pessoas deve ser no máximo 20.000");
        }
    }
}
