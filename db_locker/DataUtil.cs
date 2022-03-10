using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaGeracaoNfce.db_locker
{
    internal class DataUtil
    {
        // classe utilitaria, por este motivo nao estou permitindo sua instanciação
        private DataUtil() { }
        /// <summary>
        /// retorna hora atual estatica
        /// </summary>
        /// <returns></returns>
        public static DateTime AtualizarHora() {return DateTime.Now;}

    }
}
