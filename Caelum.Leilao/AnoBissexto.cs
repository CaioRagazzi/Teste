using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class AnoBissexto
    {
        public bool EhBissexto(int ano)
        {
            if (DateTime.IsLeapYear(ano))
            {
                return true;
            }
            return false;
        }
    }
}
