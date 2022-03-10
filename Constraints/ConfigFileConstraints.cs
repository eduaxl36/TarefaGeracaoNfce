using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Util;
using TarefaGeracaoNfce.views;
using TarefasNFC2.Exceptions;

namespace TarefasNFC2.Constraints
{
    internal class ConfigFileConstraints
    {

        ConfigFileView Configuracao;
        public void validadorIntegridadeInicioFimValidade()
        {
            Configuracao = new ConfigFileView();

            if (Configuracao.obterConfiguracao().TempoInicial1 >= Configuracao.obterConfiguracao().TempoFinal1) {

                throw new ConfigFileExceptions("O periodo inicial não pode ser maior ou igual ao periodo final. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "TempoInicial\n" + "Tempo Final");
            }
        }

        public void verificadorDeTamanhoData()
        {
            Configuracao = new ConfigFileView();

            string padrao = "\\d{3,4}";
            string EntradaTempoInicial = Configuracao.obterConfiguracao().TempoInicial1.ToString();
            string EntradaTempoFinal = Configuracao.obterConfiguracao().TempoFinal1.ToString();

            Match VerPer1 = Regex.Match(EntradaTempoInicial, padrao, RegexOptions.IgnoreCase);
            Match VerPer2 = Regex.Match(EntradaTempoFinal, padrao, RegexOptions.IgnoreCase);

            Boolean VerPer1Check = VerPer1.Success;
            Boolean VerPer2Check = VerPer2.Success;

            if (!VerPer1Check || !VerPer2Check)
            {
                throw new ConfigFileExceptions("As chaves correspondentes ao periodo não conferem com um tamanho valido!. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "TempoInicial\n" + "TempoFinal");
            }
        }

        public void verificadorNumeracaoInicioFimValidade()
        {
            Configuracao = new ConfigFileView();

            string padrao = "\\d{1,3}";
            string EntradaTempoInicial = Configuracao.obterConfiguracao().TempoInicial1.ToString();
            string EntradaTempoFinal = Configuracao.obterConfiguracao().TempoInicial1.ToString();

            Match VerPer1 = Regex.Match(EntradaTempoInicial, padrao, RegexOptions.IgnoreCase);
            Match VerPer2 = Regex.Match(EntradaTempoFinal, padrao, RegexOptions.IgnoreCase);

            Boolean VerPer1Check = VerPer1.Success;
            Boolean VerPer2Check = VerPer2.Success;

            if (!VerPer1Check || !VerPer2Check) {

                throw new ConfigFileExceptions("As chaves correspondentes ao periodo só aceitam numeros como inserções. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "TempoInicial\n" + "TempoFinal");
            }
        }
        public void verificadorNumeracaoIntervalo()
        {
            Configuracao = new ConfigFileView();

            string padrao = "\\d{1,}";
            string Intervalo = ConfigFileUtil.retornarValoresConfig("Intervalo");

            Match VerInter = Regex.Match(Intervalo, padrao, RegexOptions.IgnoreCase);

            Boolean VerInterCheck = VerInter.Success;

            if (!VerInterCheck)
            {
                throw new ConfigFileExceptions("As chaves correspondentes ao intervalo só aceitam numeros. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "Intervalo");
            }
        }

        public void verificadorLimiteGeracaoNotas()
        {
            Configuracao = new ConfigFileView();
            string padrao = "^([0-1][0-9]|[2][0-3]):[0-5][0-9]$";
            string limite = ConfigFileUtil.retornarValoresConfig("LimiteGeracaoDasNotas");

            Match VerLimite = Regex.Match(limite, padrao, RegexOptions.IgnoreCase);

            Boolean VerLimiteCheck = VerLimite.Success;

            if (!VerLimiteCheck)
            {
                throw new System.FormatException("As chaves correspondentes ao Limite de Geracao de Notas não estão no padrao correto 'HH:MM'. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "LimiteGeracaoDasNotas");
            }
        }

        public void verificadorPausaSefaz()
        {
            Configuracao = new ConfigFileView();

            string padrao = "\\d{1,}";
            string PrimeiroNumeroDosAleatoriosSefaz = ConfigFileUtil.retornarValoresConfig("PrimeiroNumeroDosAleatoriosSefaz");
            string UltimoNumeroDosAleatoriosSefaz = ConfigFileUtil.retornarValoresConfig("UltimoNumeroDosAleatoriosSefaz");

            Match VerPm = Regex.Match(PrimeiroNumeroDosAleatoriosSefaz, padrao, RegexOptions.IgnoreCase);
            Match VerUl = Regex.Match(UltimoNumeroDosAleatoriosSefaz, padrao, RegexOptions.IgnoreCase);

            Boolean VerPBm = VerPm.Success;
            Boolean VerUBl = VerUl.Success;

            if (!VerPBm || !VerPBm)
            {
                throw new ConfigFileExceptions("As chaves correspondentes ao inicio da pausa do sefaznfe só aceitam numeros. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "PrimeiroNumeroDosAleatoriosSefaz\n" + "UltimoNumeroDosAleatoriosSefaz");
            }
        }

        public void checarSeRotaLogErro()
        {
            Configuracao = new ConfigFileView();
            string rota = Configuracao.obterConfiguracao().LogErrorPath1;

            if (!Directory.Exists(rota))
            {
                throw new ConfigFileExceptions("A rota de logErro possui um direcao invalida. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "LogDeFalhasPath\n");
            }
        }
        public void checarSeArquivoLogExiste()
        {

            Configuracao = new ConfigFileView();
            string rota = Configuracao.obterConfiguracao().LogPath1;

            if (!File.Exists(rota))
            {
                throw new ConfigFileExceptions("O arquivo de log possui um direcao invalida. Por favor revise o arquivo AppConfig.xml as seguintes chaves: \n" + "LogDiarioPath\n");
            }
        }

    }
}
