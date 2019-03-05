using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public enum GRKType
    {
        Document,
        Vocabulary
    }

    public class GRKObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DisplayLabel { get; set; }
        public ObjectType Parent { get; set; }
        public Guid UUID { get; set; }
        public GRKType GRKType { get; }
        public Table Table { get; set; }
    }
}
