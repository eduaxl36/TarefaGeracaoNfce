
using System;
using System.Globalization;
using System.Threading;
using TarefaGeracaoNfce.db_locker;
using TarefaGeracaoNfce.model;
using TarefaGeracaoNfce.Util;
using TarefaGeracaoNfce.views;
using TarefasNFC2.Util;

namespace TarefaGeracaoNfce.Dao
{
    internal class AgendadorDao
    {

        private Agendador Agendador;
        private ConfigFileView Config;
        private Logview Log;
        private int Ininop;
        private int Fnnop;

        /// <summary>
        /// Construtor inicializa os objetos chave para funcionamentod da classe
        /// </summary>
        /// 
        public AgendadorDao() {
          
            Config = new ConfigFileView();
            Log = new Logview();
            Ininop = Config.obterConfiguracao().TempoInicial1;
            Fnnop = Config.obterConfiguracao().TempoFinal1;
            Agendador = obterAgendador();

        }

        /// <summary>
        /// Metodo Auxiliar que gera numero aleatorios. Para configurar o periodo deste metoddo
        /// favor abrir appconfig.xml
        /// </summary>
        /// <returns>int</returns>
        
        public int gerarNumeroAleatorio()
        {
            Console.WriteLine();
            Random rnd = new Random();
            int ret = rnd.Next(Config.obterConfiguracao().PrimeiroNumeroDosAleatoriosSefaz1, Config.obterConfiguracao().UltimoNumeroDosAleatoriosSefaz1);
            return ret;
        }

        /// <summary>
        /// Incia uma instancia do agendador
        /// </summary>
        /// <returns>Agendador</returns>
        
        public Agendador obterAgendador() {

        int intervalo = int.Parse(ConfigFileUtil.retornarValoresConfig("Intervalo"));

        Agendador = new Agendador(intervalo, Ininop, Fnnop);
                    
        return Agendador;
        
        }

        /// <summary>
        /// Checa se a data atual corresponde com alguma do log, caso ja existe seta como  = true,
        /// com isso, a primeira requisição de pedidos a API, é bloqueada.
        /// </summary>
        /// <returns>bool</returns>
        
        public bool verificarLogPermissivo() {return Log.checarValidade();}

        /// <summary>
        /// Metodo verifica se periodo atual esta dentro do periodo operativo,
        /// para mais configuracoes verificar appConfig.xml
        /// </summary>
        /// <returns>bool</returns>
        
        public bool checarPeriodoInoperante() {

           var data = Convert.ToInt32(DataUtil.AtualizarHora().ToString("HHmm"));
           var ini = obterAgendador().IncioOperacao;
           var fim = obterAgendador().FimOperacao;

           if (data >= ini && data <= fim) {return true;} return false;
        }

        /// <summary>
        /// Metodo que de fato executa o agendador.
        /// </summary>
        /// <param name="p_method"></param>
        
        public void ExecutaAgendador(Action p_method)
        {
            while (true)
            {
                //// verificar se ha log para o dia
                if (verificarLogPermissivo() == false)
                {
                    ///verifica se esta dentro do periodo util
                    if (checarPeriodoInoperante() == false)
                    {
                        Console.WriteLine("Este horario atual esta configurado como inoperante");
                        Thread.Sleep(Agendador.intervalo * 1000);
                    }
                    else
                    {
                        Console.WriteLine("Buscando pedidos junto a API... aguarde");
                        p_method();
                        Thread.Sleep(Agendador.intervalo * 1000);
                    }
                }
                else
                {
                    /// faz toda parte da chamada ao banco
                    int tempoEstimadoEspera = gerarNumeroAleatorio();
                    Console.WriteLine("Primeira importacao já realizada!, Buscando pedidos no banco ..");
                    Console.WriteLine("O tempo estimado em espera ate o proximo loop é de : "+((tempoEstimadoEspera/1000)/60)+" Minutos");
                    new PedidoNfceView().atualizarNfeSefaz();                    
                    Thread.Sleep(tempoEstimadoEspera);

                }

                ///autaliza hora
                DataUtil.AtualizarHora();
                //checa inoperancia
                checarPeriodoInoperante();
                //checa permissividade
                verificarLogPermissivo();
            }
        }
    }

}

