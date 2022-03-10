using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaGeracaoNfce.Model
{
    internal class Log
    {
        public DateTime Registro { get; set; }
        public Log(DateTime registro)
        {
            Registro = registro;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Registro.ToString();
        }
    }
}
