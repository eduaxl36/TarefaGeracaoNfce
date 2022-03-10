using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.Model;

namespace TarefaGeracaoNfce.Services
{
    internal class LogServices
    {
        private LogDao log;
        public LogServices(){log = new LogDao();}
        public Boolean checarValidade()
        {
            try
            {
                return log.checarValidade();
            }
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha ao checar o validade do log : \n" + ex.Message;
                Console.WriteLine(msg);
                log.gravarErroLog(msg);

            }
            return log.checarValidade();
        }

        public void gravarLog()
        {
            try
            {
                log.gravarLog();
            }
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha na gravação do log : \n" + ex.Message;
                Console.WriteLine(msg);
                log.gravarErroLog(msg);
            }
        }

        public void gravarErroLog(String p_msg)
        {
            try
            {
                log.gravarErroLog(p_msg);
            }
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha na gravação do log : \n" + ex.Message;
                Console.WriteLine(msg);
                log.gravarErroLog(msg);
            }
        }
    }
}
    
