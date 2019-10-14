using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivoBuilder.Models
{
    public class Table
    {
        public string Schema { get; set; }
        public string Name { get; set; }

        public Table()
        {

        }

        public Table(string schema, string name)
        {
            this.Schema = schema;
            this.Name = name;
        }

        public string FullName { get { return Schema + '.' + Name; } }
    }
}
