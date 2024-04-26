using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivoBuilder.Models;

namespace VivoBuilder.BL
{
    public class ExportHandler
    {
        public void SaveClassFile(Project project, string className, string classContent)
        {
            string filename = project.ProjectFile.Substring(0, project.ProjectFile.LastIndexOf('\\')) + "//" + new Common().ToPascalCase(className) + ".cs";

            using (TextWriter tw = new StreamWriter(filename, false))
            {
                tw.Write(classContent);
                tw.Close();
            }
        }

        private void addClassToProject(string projectFile, string className, string includeType = "Compile")
        {

        }
    }
}
