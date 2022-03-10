using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TarefaGeracaoNfce.model
{
    internal class Agendador
    {
        public int intervalo { get; set; }
        public int IncioOperacao { get; set; }
        public int FimOperacao { get; set; }
        public Agendador(int intervalo, int incioOperacao, int fimOperacao)
        {
            this.intervalo = intervalo;
            IncioOperacao = incioOperacao;
            FimOperacao = fimOperacao;
        }
    }
}
