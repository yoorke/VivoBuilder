using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivoBuilder.Models
{
    public class Table : IEquatable<Table>
    {
        public string Schema { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }

        public Table()
        {
            this.ID = new Random().Next(1, 1000000);
        }

        public Table(string schema, string name)
        {
            this.Schema = schema;
            this.Name = name;
            this.ID = new Random().Next(1, 1000000);
        }

        public string FullName { get { return Schema + '.' + Name; } }

        public override bool Equals(object obj)
        {
            return Equals(obj as Table);
        }

        public bool Equals(Table table)
        {
            return table != null && table.ID == this.ID;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
