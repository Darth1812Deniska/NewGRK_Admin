using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public class Table
    {
        private readonly int _id;

        public int ID => _id;
        public string Name { get; set; }
        public string DisplayLabel { get; set; }

        public List<Column> Columns { get; }

        public Table()
        {

        }

        public Table(int id, string name, string displayLabel)
        {
            _id = id;
            Name = name;
            DisplayLabel = displayLabel;
        }

    }
}
