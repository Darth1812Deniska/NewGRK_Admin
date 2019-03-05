using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public class ObjectType
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _displayLabel;

        //private readonly GRKType _gRKType;

        public int ID => _id;
        public string Name => _name;
        public string DisplayLabel => _displayLabel;         
        
        //public GRKType GRKType => _gRKType;
        public ObjectType(int id, string name, string displayLabel
            //, GRKType type
            )
        {
            _id = id;
            _name = name;
            _displayLabel = displayLabel;
            //_gRKType = type;
        }

        public override string ToString()
        {
            string tmpRes = $"{ID}. {Name} ({DisplayLabel})";
            return tmpRes;
        }
    }

}
