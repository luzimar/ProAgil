using ProAgil.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgil.Application.ViewModels
{
    public class LoteViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int Quantidade { get; set; }

    }
}
