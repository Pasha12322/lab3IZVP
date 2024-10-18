using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class ElementList
    {
        public string PIB;
        public ElementList next;

        public ElementList(string PIB)
        {
            this.PIB = PIB;
        }
    }
}
