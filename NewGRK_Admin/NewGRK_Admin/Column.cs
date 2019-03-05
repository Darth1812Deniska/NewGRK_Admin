using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public enum DataType
    {
        Integer = 1,
        String = 2,
        Date = 3,
        Time = 4,
        MultilineString = 5,
        Float = 7,
        DateTime = 8,
        Table = 9,
        FixedDateTime = 10
    }
    public class Column
    {
        private readonly int _id;

        public int ID => _id;
        public DataType DataType { get; set; }
        public string Name { get; set; }
        public string DisplayLabel { get; set; }
        public int Length { get; set; }
        public bool PKey { get; set; }
        public bool InfoField { get; set; }
        public int Alignment { get; set; }
        public bool GUIField { get; set; }
        public bool ResField { get; set; }
        public bool NotNull { get; set; }
        public string FullDisplayLabel { get; set; }
        public bool? UseLastVersion { get; set; }
        public string SortFields { get; set; }
        public int? ControlTypeID { get; set; }
        public ObjectType RefObjectType { get; set; }
        public bool Deleted { get; set; }

        public Column(int id,DataType dataType,string name,string displayLabel,int length,bool pkey,bool infoField,int alignment,
            bool guiField,bool resField,bool notNull,string fullDisplayLabel,bool useLastVersion,string sortFields,int controlTypeID,
            ObjectType refObjectType,bool deleted)
        {
            _id = id;
            DataType = dataType;
            Name = name;
            DisplayLabel = displayLabel;
            Length = length;
            PKey = pkey;
            InfoField = infoField;
            Alignment = alignment;
            GUIField = guiField;
            ResField = resField;
            NotNull = notNull;
            FullDisplayLabel = fullDisplayLabel;
            UseLastVersion = useLastVersion;
            SortFields = sortFields;
            ControlTypeID = controlTypeID;
            RefObjectType = refObjectType;
            Deleted = deleted;
        }

        public Column()
        {

        }
    }
}
