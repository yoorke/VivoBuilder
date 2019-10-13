using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivoBuilder.Models
{
    public class TableColumn
    {
        public string Name { get; set; }
        public string TableName { get; set; }
        public string Type { get; set; }
        public bool IsNullable { get; set; }
        public bool IsKey { get; set; }
        public int Size { get; set; }

        public TableColumn() { }

        public TableColumn(string name, string tableName, string type, bool isNullable, bool isKey, int size)
        {
            Name = name;
            TableName = tableName;
            Type = type;
            IsNullable = isNullable;
            IsKey = isKey;
            Size = size;
        }
    }
}
