using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace ProAgil.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int n1 = 5;
            int n2 = 37;
            int valorEsperado = 42;

            var resultadoSoma = Somar(n1, n2);
            resultadoSoma.Should().Be(valorEsperado, $"Resultado da soma entre {n1} e {n2} deve ser {valorEsperado}. Resultado {resultadoSoma}");
        }

        public int Somar(int n1, int n2){
            return n1 + n2;
        }
    }

    
}
