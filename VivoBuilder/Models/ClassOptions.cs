using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivoBuilder.Models
{
    public class ClassOptions
    {
        public string ClassName { get; set; }
        public string Namespace { get; set; }
        public Project Project { get; set; }
        public Table Table { get; set; }

        public ClassOptions()
        {
            
        }

        public ClassOptions SetClassName(string className)
        {
            this.ClassName = ClassName;
            return this;
        }

        public ClassOptions SetNamespace(string namespaceName)
        {
            this.Namespace = namespaceName;
            return this;
        }

        public ClassOptions SetProject(Project project)
        {
            this.Project = project;
            return this;
        }

        public ClassOptions SetTable(Table table)
        {
            this.Table = table;
            return this;
        }
    }
}
