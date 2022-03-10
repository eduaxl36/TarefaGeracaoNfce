using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Services;

namespace TarefaGeracaoNfce.views
{
    internal class PedidoNfceView
    {
        private PedidoNfceServices Pedido;
        public PedidoNfceView() { Pedido = new PedidoNfceServices();}
        public void requisitarPedidosParaBaseDeDados() {Pedido.requisitarPedidosParaBaseDeDados();}
        public void atualizarNfeSefaz(){Pedido.atualizarNfeSefaz();}
    }
}
