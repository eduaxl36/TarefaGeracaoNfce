using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.Services;

namespace TarefaGeracaoNfce.views
{
    internal class Logview
    {
        private LogServices log;
        public Logview(){log = new LogServices();}
        public Boolean checarValidade(){return log.checarValidade();}
        public void gravarLog(){log.gravarLog();}
        public void gravarErroLog(String p_msg){log.gravarErroLog(p_msg);}
    }

}