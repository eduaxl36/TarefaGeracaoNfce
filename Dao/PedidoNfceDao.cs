
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TarefaGeracaoNfce.teste;
using TarefaGeracaoNfce.Util;
using TarefaGeracaoNfce.views;
using TarefasNFC2.Util;

namespace TarefaGeracaoNfce.Dao
{
    internal class PedidoNfceDao
    {
        /// <summary>
        /// Metodo que realiza a comunicacao com a API que traz os pedidos.
        /// </summary>
        /// <returns>List<PedidoNfce> </returns>
        
        public List<PedidoNfce> obterListaChamadaExterna(){return SimulacaoSourceMichel.obterListaTipo1();}

        /// <summary>
        /// metodo retorna to tamanho da lista, com o objetivo de usar para validacoes diversas
        /// </summary>
        /// <returns>bool</returns>
        
        public  bool validaSeListaEstaComConteudo()
        {
            if (obterListaChamadaExterna().Count > 0) return true;
            return false;
        }

        /// <summary>
        /// Recebe os pedidos da API e atribui horarios sortidos
        /// </summary>
        /// <returns>PedidoNfce</returns>
        public List<PedidoNfce> atribuirEobterListaComNovosPeriodos()
        {
            Queue<object> TempQueue = PedidoNfceUtil.gerarPeriodosEnfileiradosPorTempo(obterListaChamadaExterna().Count + 4);
            List<PedidoNfce> listaEntryPoint = obterListaChamadaExterna();
            listaEntryPoint.Sort();
            listaEntryPoint.ForEach(dadosObjetos =>
            {
                object periodo = TempQueue.Dequeue();
                dadosObjetos.DataAgendadaParaGeracaoNota = ConversoresUTeis.converterHoraStringEmObjetoTempo(periodo.ToString());
            });
            new Logview().gravarLog();
            return listaEntryPoint;
        }

        /// <summary>
        /// Se houver conteudo vindo da API que traz os pedidos, a informação é consistida 
        /// no banco
        /// </summary>
        public  void gravarInformacoesVindasDaAPI()
        {
            if (validaSeListaEstaComConteudo())
            {
                List<PedidoNfce> lstTemp = atribuirEobterListaComNovosPeriodos().Select(val =>
                {
                    SimulacaoSourceMichel.gravar(val);
                    return val;
                }
            ).ToList();
            }
            else {
                Console.WriteLine("A Api não trouxe nenhuma informação, aguardando....");
            }
        }

        /// <summary>
        /// Solicita ao metodo especialista a lista vindo diretamente da base de dados.
        /// </summary>
        /// <returns>List<PedidoNfce></returns>
        
        public List<PedidoNfce> solicitarPedidosDaBase() {return SimulacaoSourceMichel.obterPedidosdoBanco();}

        public void atualizarNfeSefaz()
        {
            //// realiza a ordenação para pegar o px da fila que esta setado como false
            List<PedidoNfce> lstTemps =solicitarPedidosDaBase();
            
            lstTemps.ForEach(PxFila =>
            {
                /// verifica se o sistema de notas esta ok, caso nao dispara exceção se sim pega o numero da nota
                if (ModNfeUtil.obterNumeroDoPedido(PxFila) > 0)
                {
                    PxFila = ModNfeUtil.gerarNotaFiscal(PxFila, ModNfeUtil.obterNumeroDoPedido(PxFila));
                }
                Thread.Sleep(new AgendadorDao().gerarNumeroAleatorio());

                //// verifica se o servico do sefaz esta ok, caso nao dispara exceção se sim seta como true 
                if (ModSefazUtil.validaPedidoSefaz(PxFila) == true)
                {
                    PxFila = ModSefazUtil.incluirSefaz(PxFila);
                }

                /// chama o metodo do michel que realiza o update na base de dados
                SimulacaoSourceMichel.atualizar(PxFila);
                Console.WriteLine(PxFila);
                Thread.Sleep(new AgendadorDao().gerarNumeroAleatorio());

            });
        }
    }
}
