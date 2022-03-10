using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasNFC2.Exceptions;

namespace TarefasNFC2.Constraints
{
    internal class SefazConstraints
    {
        public void validarRepostaSefaz(Boolean validador) {

            if(validador==false)
            throw new SefazException("A requisição trouxe uma resposta negativa para geração no sefaz, contacte o adm do sistema.");

        }

    }
}
