using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VivoBuilder.Models;

namespace VivoBuilder.BL
{
    public class ProjectBL
    {
        public List<Project> GetProjects(string solutionFilename)
        {
            List<Project> projectList = new List<Project>();

            string solutionFolder = solutionFilename.Substring(0, solutionFilename.LastIndexOf("\\"));

            var solutionContent = File.ReadAllText(solutionFilename);

            Regex projReg = new Regex("Project\\(\"\\{[\\w-]*\\}\"\\) = \"([\\w _]*.*)\", \"(.*\\.(cs|vcx|vb)proj)\"", RegexOptions.Compiled);
            var matches = projReg.Matches(solutionContent).Cast<Match>();
            var projects = matches.Select(x => x.Groups[2].Value.Replace(x.Groups[1].Value + "\\", string.Empty)).ToList();

            for(int i = 0; i < projects.Count; i++)
            {
                string projectsFile = projects[i];
                string projectName = projects[i].Replace(".csproj", string.Empty);
                if (!Path.IsPathRooted(projects[i]))
                    projects[i] = Path.Combine(solutionFolder, projects[i]);
                projects[i] = Path.GetFullPath(projects[i]);

                projectList.Add(new Project(projectName, projects[i], projectsFile, projectName, i + 1));
            }

            return projectList;
        }
    }
}
