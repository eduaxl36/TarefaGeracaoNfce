using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.Model;
using TarefaGeracaoNfce.views;
using TarefasNFC2.Exceptions;

namespace TarefaGeracaoNfce.Services
{
    internal class ConfigFileServices
    {
        private TarefaGeracaoNfce.Dao.ConfigFileDAO Config;
        public ConfigFileServices() {Config = new ConfigFileDAO();}
        public ConfigFile obterConfiguracao() {

            try
            {
                return Config.obterObjetoConfig();

            }
            catch (ConfigFileExceptions ex)
            {
                String msg = "Ocorreu uma falha com o arquivo de configuração: \n" + ex.Message;
                Console.WriteLine(msg);
                new Logview().gravarErroLog(msg);
            }
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha : \n" + ex.Message;
                Console.WriteLine(msg);
                new Logview().gravarErroLog(msg);
            }
            return Config.obterObjetoConfig();
        }
    }
}
