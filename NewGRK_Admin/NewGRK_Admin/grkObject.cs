using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    enum grkType
    {
        Document,
        Vocabulary
    }
    class grkObject
    {
        int ID { get; set; }
        string Name { get; set; }
        string DisplayLabel { get; set; }
        int Parent { get; set; }
        Guid UUID { get; set; }
    }
}
