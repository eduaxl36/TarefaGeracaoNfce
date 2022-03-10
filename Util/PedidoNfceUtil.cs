using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.teste;
using TarefaGeracaoNfce.views;

namespace TarefaGeracaoNfce.Util
{
    internal class PedidoNfceUtil
    {
        private static ConfigFileView config = new ConfigFileView();   
        private static Logview Logview = new Logview(); 
        private PedidoNfceUtil() {}

        /// <summary>
        /// Recebe uma lista com os valores da hora atribuidas ao objeto pedido
        /// </summary>
        /// <param name="p_qtdElementos"></param>
        /// <returns></returns>
       
        public static Queue<Object> gerarPeriodosEnfileiradosPorTempo(int p_qtdElementos){return PedidoNfceUtil.obterFilaAleatoriaHorarios(p_qtdElementos);}

        /// <summary>
        /// Metodo recebe a quantidade de elementos da primeira requisição, e faz uma distribuição
        /// de horarios.
        /// </summary>
        /// <param name="p_qtdelementos"></param>
        /// <returns>Queue</returns>
        public static Queue<object> obterFilaAleatoriaHorarios(int p_qtdelementos) {

            var random = new Random();

            DateTime HoraAtual = DateTime.Now;
           
            var duracaoMaxima = TimeSpan.FromHours(config.obterConfiguracao().LimiteGeracaoDasNotas1.Hour - HoraAtual.Hour);

            var values = Enumerable.Range(0, p_qtdelementos)

                .Select(x => {
                    var rndSeconds = random.Next(0, 60);
                    var duration = random.Next(0, (int)duracaoMaxima.TotalMinutes);
                    return HoraAtual.AddMinutes(duration).AddSeconds(rndSeconds).ToString("HH:mm:s");
                })
                .ToList();

            List<string> obterListaRetorno = values.Distinct().ToList();

            var obterListaRetornoDistinct = new HashSet<string>(obterListaRetorno);

            var OrdenarLista = obterListaRetornoDistinct.OrderBy(val => val).Distinct().ToList();

            Queue<object> PilhaRetorno = new Queue<object>(OrdenarLista);

            return PilhaRetorno;
        
        }
    }
}
