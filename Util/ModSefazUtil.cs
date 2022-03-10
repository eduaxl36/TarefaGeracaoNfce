using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.teste;
using TarefasNFC2.Constraints;

namespace TarefasNFC2.Util
{
    internal class ModSefazUtil
    {
        private static SefazConstraints validarSefaz;
        private ModSefazUtil() { }

        /// <summary>
        /// metodo valida se resposta do sefaz é valida
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>bool</returns>
        
        public static bool validaPedidoSefaz(PedidoNfce pedido)
        {
            validarSefaz = new SefazConstraints();
            validarSefaz.validarRepostaSefaz(SimulacaoSourceMichel.chamaMetodoSefaz);
            return SimulacaoSourceMichel.chamaMetodoSefaz;
        }

        /// <summary>
        ///metodo responsavel por atrelar o booleano ao confirmacao do sefaz
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>PedidoNfce</returns>

        public static PedidoNfce incluirSefaz(PedidoNfce pedido) {pedido.NotaAutorizadaSefaz = true;return pedido;}

    }
}
