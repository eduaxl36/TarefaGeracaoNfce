
using System;
using System.Globalization;
using TarefaGeracaoNfce.db_locker;
using TarefaGeracaoNfce.Model;
using TarefaGeracaoNfce.Util;


namespace TarefaGeracaoNfce.Dao
{
    internal class ConfigFileDAO
    {

        private ConfigFile Config;
        private DateTime LimiteGeracaoDasNotas;
        private int PrimeiroNumeroDosAleatoriosSefaz;
        private int UltimoNumeroDosAleatoriosSefaz;
        private string LogPath;
        private string LogErrorPath;
        private int Inicio;
        private int Fim;


        /// <summary>
        /// Construtor inicializa os parametros
        /// </summary>
        public ConfigFileDAO()
        {        
            LimiteGeracaoDasNotas = DateTime.ParseExact(DataUtil.AtualizarHora().ToString("dd/MM/yyyy") + " " + ConfigFileUtil.retornarValoresConfig("LimiteGeracaoDasNotas"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            PrimeiroNumeroDosAleatoriosSefaz = int.Parse(ConfigFileUtil.retornarValoresConfig("PrimeiroNumeroDosAleatoriosSefaz"));
            UltimoNumeroDosAleatoriosSefaz = int.Parse(ConfigFileUtil.retornarValoresConfig("UltimoNumeroDosAleatoriosSefaz"));
            LogPath = ConfigFileUtil.retornarValoresConfig("LogDiarioPath");
            Inicio = Convert.ToInt32(ConfigFileUtil.retornarValoresConfig("TempoInicial"));
            Fim = Convert.ToInt32(ConfigFileUtil.retornarValoresConfig("TempoFinal"));
            LogErrorPath = ConfigFileUtil.retornarValoresConfig("LogDeFalhasPath");

            /// objeto inicializado
            Config = new ConfigFile(LimiteGeracaoDasNotas, PrimeiroNumeroDosAleatoriosSefaz, UltimoNumeroDosAleatoriosSefaz, Inicio, Fim, LogPath, LogErrorPath);
        }

        /// <summary>
        /// Metodo retorna uma instancia da configuração
        /// </summary>
        /// <returns>ConfigFile</returns>
      
        public ConfigFile obterObjetoConfig(){return Config; }
    }
}
