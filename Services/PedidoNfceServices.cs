using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.views;
using TarefasNFC2.Exceptions;

namespace TarefaGeracaoNfce.Services
{
    internal class PedidoNfceServices
    {
        private PedidoNfceDao Pedido;
        private Logview Log;
        public PedidoNfceServices(){
            Pedido = new PedidoNfceDao();
            Log = new Logview();    
        }

        public void requisitarPedidosParaBaseDeDados()
        {
            try
            {
                Pedido.gravarInformacoesVindasDaAPI();
            }
            catch (ConfigFileExceptions ex)
            {
                String msg = "Ocorreu uma falha com o arquivo de configuração: \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
            catch (NfeException ex)
            {
                String msg = "Ocorreu uma falha na geração da nota: \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
            catch (SefazException ex)
            {
                String msg = "Ocorreu uma falha na chamada do sefaz: \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha : \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
        }

        public void atualizarNfeSefaz() {
            try
            {
                Pedido.atualizarNfeSefaz();
            }
            catch (ConfigFileExceptions ex)
            {
                String msg = "Ocorreu uma falha com o arquivo de configuração: \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
            catch (NfeException ex)
            {
                String msg = "Ocorreu uma falha na geração da nota: \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
            catch (SefazException ex)
            {
                String msg = "Ocorreu uma falha na chamada do sefaz: \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
            catch (Exception ex)
            {
                String msg = "Ocorreu uma falha : \n" + ex.Message;
                Console.WriteLine(msg);
                Log.gravarErroLog(msg);
            }
        }
    }
}
