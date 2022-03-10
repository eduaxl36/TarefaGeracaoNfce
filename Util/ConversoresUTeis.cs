using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaGeracaoNfce.Util
{
    internal class ConversoresUTeis
    {
        //recebe uma String(hora) e devolve um 'DateTime'
         public static DateTime converterHoraStringEmObjetoTempo(string p_tempo) {return DateTime.ParseExact(p_tempo, "HH:mm:s", CultureInfo.InvariantCulture); }
        //recebe uma String(data) e devolve um 'DateTime'
         public static DateTime converterDataStringEmObjetoTempo(string p_tempo){return DateTime.ParseExact(p_tempo, "yyyy-MM-dd", CultureInfo.InvariantCulture);}
        //recebe uma String(datatime) e devolve um 'DateTime'
         public static DateTime converterDataHoraStringEmObjetoTempo(string p_tempo){return DateTime.ParseExact(p_tempo.Substring(0,16), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);}
    }
}
