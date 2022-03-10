using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.teste;
using TarefasNFC2.Constraints;
using TarefasNFC2.Exceptions;

namespace TarefasNFC2.Util
{
    internal class ModNfeUtil
    {
        static private NfeConstraints validarNfe;
        private ModNfeUtil() { }

        /// <summary>
        /// metodo responsavel por atrelar o numero da nota ao objeto
        /// </summary>
        /// <param name="p_pedido"></param>
        /// <param name="p_numero"></param>
        /// <returns>PedidoNfce</returns>
        public static PedidoNfce gerarNotaFiscal(PedidoNfce p_pedido,int p_numero)
        {
            validarNfe = new NfeConstraints();
            p_pedido.Nota = "" + p_numero;
            p_pedido.NotaGerada = true;
            return p_pedido;

        }
        /// <summary>
        /// Metodo solicita e a nota e valida o numero da nota.
        /// </summary>
        /// <param name="p_nota"></param>
        /// <returns>int</returns>
        public static int obterNumeroDoPedido(PedidoNfce p_nota) {

            validarNfe = new NfeConstraints();
            validarNfe.verificarValidadeNfe(SimulacaoSourceMichel.chamaMetodoGeraNota);
            return SimulacaoSourceMichel.chamaMetodoGeraNota;
        }
    }
}
