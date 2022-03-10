using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasNFC2.Constraints;

namespace TarefaGeracaoNfce.Util
{
    internal class ConfigFileUtil
    {

        private static ConfigFileConstraints regras;

        //instanciação da classe nao permitida
        private ConfigFileUtil() { }
        /// <summary>
        /// Metodo responsavel por fazer o loop nos arquivos de configuracao
        /// </summary>
        /// <param name="p_key"></param>
        /// <returns>string</returns>
        public static string retornarValoresConfig(String p_key) {

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (var chave in configuration.Sections.Keys)
            {
                var section = configuration.GetSection(chave.ToString());
                var appSettings = section as AppSettingsSection;
            
                if (appSettings == null) continue;
         
                foreach (var key in appSettings.Settings.AllKeys)
                {
                    if (key.Equals(p_key)) {return appSettings.Settings[key].Value;}
                }
            }
            Console.ReadLine();
            return "Nenhum valor encontrado para a chave passada.";
        }

        /// <summary>
        /// metodo responsavel por validar se as chaves criadas estao com os padroes corretos
        /// </summary>
        public static void checadorDechaves() {

            regras = new ConfigFileConstraints();
            regras.checarSeArquivoLogExiste();
            regras.verificadorDeTamanhoData();
            regras.verificadorPausaSefaz();
            regras.validadorIntegridadeInicioFimValidade();
            regras.verificadorNumeracaoInicioFimValidade();
            regras.verificadorNumeracaoIntervalo();
            regras.verificadorLimiteGeracaoNotas();
        }
    }
}
