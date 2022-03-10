using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefasNFC2.Exceptions;

namespace TarefaGeracaoNfce.Services
{
    
    internal class AgendadorServices
    {
        private AgendadorDao Agendador;
        public AgendadorServices() { Agendador = new AgendadorDao();}
        public int gerarNumeroAleatorio() {

            try
            {
                return Agendador.gerarNumeroAleatorio();
            }
    
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha : \n" + ex.Message;
                Console.WriteLine(msg);
                new LogDao().gravarErroLog(msg);
            }
            return Agendador.gerarNumeroAleatorio();
        }

        public void IniciarAgendador(Action p_acao) {

            try
            {
                Agendador.ExecutaAgendador(p_acao);
            }
            catch (ConfigFileExceptions ex)
            {
                String msg = "Ocorreu uma falha com o arquivo de configuração: \n" + ex.Message;
                Console.WriteLine(msg);
                new LogDao().gravarErroLog(msg);
            }
            catch (NfeException ex)
            {
                String msg = "Ocorreu uma falha na geração da nota: \n" + ex.Message;
                Console.WriteLine(msg);
                new LogDao().gravarErroLog(msg);
            }
            catch (SefazException ex)
            {
                String msg = "Ocorreu uma falha na chamada do sefaz: \n" + ex.Message;
                Console.WriteLine(msg);
                new LogDao().gravarErroLog(msg);
            }
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha : \n" + ex.Message;
                Console.WriteLine(msg);
                new LogDao().gravarErroLog(msg);
       
            }
        }
    }
}
