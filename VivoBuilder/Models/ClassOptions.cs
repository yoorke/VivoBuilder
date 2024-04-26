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
        public string ClassContent { get; set; }
        public string Schema { get; set; }
        //public Table Table { get; set; }
        public string Sufix { get; set; } = string.Empty;

        public ClassOptions()
        {
            
        }

        public ClassOptions SetClassName(string className)
        {
            this.ClassName = className;
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

        public ClassOptions SetClassContent(string classContent)
        {
            this.ClassContent = classContent;
            return this;
        }

        public ClassOptions SetSchema(string schema)
        {
            this.Schema = schema;
            return this;
        }

        //public ClassOptions SetTable(Table table)
        //{
            //this.Table = table;
            //return this;
        //}

        public ClassOptions SetSufix(string sufix)
        {
            this.Sufix = sufix;
            return this;
        }

        public string ClassFilename
        {
            get { return this.Project.Path.Substring(0, this.Project.Path.LastIndexOf("\\") + 1) + (!string.IsNullOrWhiteSpace(this.Sufix) ? this.Sufix + "\\" : string.Empty) + ClassName + ".cs"; }
        }
    }
}
