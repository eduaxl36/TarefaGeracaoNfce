using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaGeracaoNfce.Dao
{

    internal class PedidoNfce : IComparable
    {
        public string ID { get; set; }
        public int Numero { get; set; }
        public DateTime DataEntradaPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataAgendadaParaGeracaoNota { get; set; }
        public string Nota { get; set; }
        public bool NotaGerada { get; set; }
        public bool NotaAutorizadaSefaz { get; set; }

        public PedidoNfce(string iD, int numero, DateTime dataEntradaPedido, DateTime dataPedido, DateTime dataAgendadaParaGeracaoNota, string nota, bool notaGerada, bool notaAutorizadaSefaz)
        {
            ID = iD;
            Numero = numero;
            DataEntradaPedido = dataEntradaPedido;
            DataPedido = dataPedido;
            DataAgendadaParaGeracaoNota = dataAgendadaParaGeracaoNota;
            Nota = nota;
            NotaGerada = notaGerada;
            NotaAutorizadaSefaz = notaAutorizadaSefaz;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            PedidoNfce otherTemperature = obj as PedidoNfce;
            if (otherTemperature != null)
                return this.Numero.CompareTo(otherTemperature.Numero);
            else
                throw new ArgumentException("Objeto não é uma nota!");
        }

        public override bool Equals(object obj)
        {
            return obj is PedidoNfce nfce &&
                   ID == nfce.ID &&
                   Numero == nfce.Numero &&
                   DataEntradaPedido == nfce.DataEntradaPedido &&
                   DataPedido == nfce.DataPedido &&
                   DataAgendadaParaGeracaoNota == nfce.DataAgendadaParaGeracaoNota &&
                   Nota == nfce.Nota &&
                   NotaGerada == nfce.NotaGerada &&
                   NotaAutorizadaSefaz == nfce.NotaAutorizadaSefaz;
        }
        public override string ToString()
        {
            return 
                   ID + "\n" 
                   +"\n" + Numero + "\n" 
                   +"\n" + DataEntradaPedido + "\n" 
                   +"\n" + DataPedido + "\n" 
                   +"\n" + DataAgendadaParaGeracaoNota + "\n" 
                   +"\n" + Nota + "\n" 
                   +"\n" + NotaGerada + "\n" 
                   +"\n" + NotaAutorizadaSefaz + "\n";
        }
    }
}
