using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TarefaGeracaoNfce.db_locker;
using TarefaGeracaoNfce.Model;
using TarefaGeracaoNfce.views;

namespace TarefaGeracaoNfce.Dao
{
    internal class LogDao
    {
        private Log log;
        private ConfigFileView Config;

        /// <summary>
        /// inicializa uma instancia da configuração
        /// </summary>
       
        public LogDao(){Config = new ConfigFileView();}

        /// <summary>
        /// Metodo faz a leitura do log e armazena uma lista de objetos LOG
        /// </summary>
        /// <returns>List<Log></returns>
       
        public List<Log> ObterListaDeLogs()
        {
            List<Log> ListaDeLogs = new List<Log>();

            using (StreamReader Leitor = new StreamReader(Config.obterConfiguracao().LogPath1))
            {
                String linha = Leitor.ReadLine();

                while (linha != null)
                {
                    string[] array = linha.Split(';');

                    Regex rg = new Regex("\\d{1,}.*");
 
                    MatchCollection validacao = rg.Matches(linha);

                    if (validacao.Count>0) {

                        DateTime Registro = DateTime.ParseExact(array[0] + " " + array[1], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        log = new Log(Registro);
                        ListaDeLogs.Add(log);
                    }
                    linha = Leitor.ReadLine();
                }
                return ListaDeLogs;
            }
        }

        /// <summary>
        /// Data atual é passada e recebe o retorno de um objeto LOG
        /// </summary>
        /// <param name="dataAtual"></param>
        /// <returns>Log</returns>
        
        public Log obterLog(String dataAtual) {

            using (StreamReader Leitor = new StreamReader(Config.obterConfiguracao().LogPath1))
            {
                String linha = Leitor.ReadLine();
               
                while (linha != null)
                {
                    string[] array = linha.Split(';');

                    if (dataAtual.Equals(array[0].ToString()))
                    {
                        DateTime Registro = DateTime.ParseExact(array[0] + " " + array[1], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        log = new Log(Registro);
                        return log;
                    }

                    linha = Leitor.ReadLine();
                }
                return null;
            }
        }

        /// <summary>
        /// Metodo verifica se log ja existe, com base na data atual
        /// </summary>
        /// <returns>Boolean</returns>
        
        public Boolean checarValidade() {

            DateTime Data = DataUtil.AtualizarHora();
            String DataAtualAsString = Data.ToString("dd/MM/yyyy");
            if (obterLog(DataAtualAsString)==null) {return false;}
            return true;
        }

        /// <summary>
        /// Apos a importacao inicial da api, metodo é invocado para gravar o log no 'log.csv'
        /// </summary>
        
        public void gravarLog() {

            DateTime Data = DataUtil.AtualizarHora();
            using (StreamWriter Leitor = new StreamWriter(Config.obterConfiguracao().LogPath1,true)) {
                Leitor.WriteLine(Data.ToString("dd/MM/yyyy")+";"+ Data.ToString("hh:MM"));
            }
        }


        public void gravarErroLog(String p_msg)
        {
            DateTime Data = DataUtil.AtualizarHora();
            using (StreamWriter Leitor = new StreamWriter(Config.obterConfiguracao().LogErrorPath1+"/"+Data.ToString("ddMMyyyy")+".txt", true))
            {
                Leitor.WriteLine(Data.ToString("ddMMyyyy")+" "+ Data.ToString("HH:mm")+" -> \n"+p_msg+"\n"+"<-");
            }
        }

    }
}
