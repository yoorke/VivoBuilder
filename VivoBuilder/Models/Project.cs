using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivoBuilder.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string ProjectFile { get; set; }
        public string Namespace { get; set; }

        public Project()
        { }

        public Project(string name, string path, string projectFile, string namespaceName)
        {
            this.Name = name;
            this.Path = path;
            this.ProjectFile = ProjectFile;
            this.Namespace = namespaceName;
        }
    }
}
