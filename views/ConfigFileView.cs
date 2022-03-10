using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Model;
using TarefaGeracaoNfce.Services;

namespace TarefaGeracaoNfce.views
{
    
    internal class ConfigFileView
    {    
        private ConfigFileServices Config;
        public ConfigFileView() {Config = new ConfigFileServices();}
        public ConfigFile obterConfiguracao(){return Config.obterConfiguracao();}
    }
}
