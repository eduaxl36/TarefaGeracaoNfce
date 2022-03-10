using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.teste;
using TarefaGeracaoNfce.Util;
using TarefaGeracaoNfce.views;


namespace TarefasNFC2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PedidoNfceView sd = new PedidoNfceView();
            AgendadorView obj = new AgendadorView();

            obj.IniciarAgendador(sd.requisitarPedidosParaBaseDeDados);

        }
    }
}
