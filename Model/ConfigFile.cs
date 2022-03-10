using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaGeracaoNfce.Model
{
    internal class ConfigFile
    {
        private DateTime LimiteGeracaoDasNotas;
        private int PrimeiroNumeroDosAleatoriosSefaz;
        private int UltimoNumeroDosAleatoriosSefaz;
        private int TempoInicial;
        private int TempoFinal;
        private string LogPath;
        private string LogErrorPath;

        public ConfigFile(DateTime limiteGeracaoDasNotas, int primeiroNumeroDosAleatoriosSefaz, int ultimoNumeroDosAleatoriosSefaz, int tempoInicial, int tempoFinal, string logPath,string logErrorPath)
        {
            LimiteGeracaoDasNotas1 = limiteGeracaoDasNotas;
            PrimeiroNumeroDosAleatoriosSefaz1 = primeiroNumeroDosAleatoriosSefaz;
            UltimoNumeroDosAleatoriosSefaz1 = ultimoNumeroDosAleatoriosSefaz;
            TempoInicial1 = tempoInicial;
            TempoFinal1 = tempoFinal;
            LogPath1 = logPath;
            LogErrorPath1 = logErrorPath;
        }
        public DateTime LimiteGeracaoDasNotas1 { get => LimiteGeracaoDasNotas; set => LimiteGeracaoDasNotas = value; }
        public int PrimeiroNumeroDosAleatoriosSefaz1 { get => PrimeiroNumeroDosAleatoriosSefaz; set => PrimeiroNumeroDosAleatoriosSefaz = value; }
        public int UltimoNumeroDosAleatoriosSefaz1 { get => UltimoNumeroDosAleatoriosSefaz; set => UltimoNumeroDosAleatoriosSefaz = value; }
        public int TempoInicial1 { get => TempoInicial; set => TempoInicial = value; }
        public int TempoFinal1 { get => TempoFinal; set => TempoFinal = value; }
        public string LogPath1 { get => LogPath; set => LogPath = value; }
        public string LogErrorPath1 { get => LogErrorPath; set => LogErrorPath = value; }
    }
}
