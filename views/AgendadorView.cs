using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Services;

namespace TarefaGeracaoNfce.views
{
    internal class AgendadorView
    {
        private AgendadorServices Agendador;
        public AgendadorView() {Agendador = new AgendadorServices();}
        public int gerarNumeroAleatorio() {return Agendador.gerarNumeroAleatorio();}
        public void IniciarAgendador(Action p_acao){Agendador.IniciarAgendador(p_acao);}
    }
}
