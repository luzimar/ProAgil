using ProAgil.Domain.ContractValidations;

namespace ProAgil.Domain.ValueObjects
{
    public class QuantidadePessoas : ValueObject
    {
        public int Quantidade { get; private set; }
        public QuantidadePessoas(int quantidade)
        {
            Quantidade = quantidade;

            AddNotifications(new QuantidadePessoasValidation(this).GetContract());
        }
    }
}
