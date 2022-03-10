using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TarefasNFC2.Exceptions;

namespace TarefasNFC2.Constraints
{
    internal class NfeConstraints
    {
        public void verificarValidadeNfe(int p_nota) {

            if (p_nota == 0)
            {
                throw new NfeException("Falha ao buscar o numero da nota, favor contactar o adm do sistema.");
            }

            Match VerNota = Regex.Match(""+p_nota, "\\d{1,}", RegexOptions.IgnoreCase);

            Boolean VerPerNota = VerNota.Success;

            if (!VerPerNota) {
                throw new NfeException("A requisição trouxe um formato invalido para a nota, favor contactar o adm do sistema.");
            }

        }

    }
}
