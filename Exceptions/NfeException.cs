using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasNFC2.Exceptions
{
    internal class NfeException:Exception{ public NfeException(string message) : base(message) { }}
}
