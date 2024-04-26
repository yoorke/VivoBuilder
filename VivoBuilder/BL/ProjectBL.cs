using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
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
            //var projects = matches.Select(x => x.Groups[2].Value.Replace(x.Groups[1].Value + "\\", string.Empty)).ToList();
            var projects = matches.ToList();

            for(int i = 0; i < projects.Count; i++)
            {
                string projectPath = string.Empty;
                string projectsFile = projects[i].Groups[2].Value.Replace(projects[i].Groups[1].Value + "\\", string.Empty);
                string projectName = projects[i].Groups[1].Value.Replace(".csproj", string.Empty);
                if (!Path.IsPathRooted(projects[i].Groups[2].Value))
                    //projects[i] = Path.Combine(solutionFolder, projects[i].Groups[2].Value);
                    projectPath = Path.Combine(solutionFolder, projects[i].Groups[2].Value);
                //projects[i] = Path.GetFullPath(projects[i]);
                projectList.Add(new Project(projectName, projectPath, projectsFile, projectName, i + 1));
                //projectList.Add(new Project(projectName, projects[i], projectsFile, projectName, i + 1));
            }

            projectList.Insert(0, new Project("None", string.Empty, string.Empty, string.Empty, -1));

            return projectList;
        }

        public void AddFileToProject(ClassOptions classOptions)
        {
            XmlDocument projectFile = new XmlDocument();
            if(classOptions.Project != null)
            { 
                projectFile.Load(classOptions.Project.Path);

                XmlNode itemGroup = projectFile.GetElementsByTagName("ItemGroup")[projectFile.GetElementsByTagName("ItemGroup").Count - 1];

                bool exists = false;

                for(int i = 0; i < itemGroup.ChildNodes.Count; i++)
                    for(int j = 0; j < itemGroup.ChildNodes[i].Attributes.Count; j++)
                        if(itemGroup.ChildNodes[i].Attributes[j].Value == (!string.IsNullOrWhiteSpace(classOptions.Sufix) ? classOptions.Sufix + "\\" : string.Empty) + classOptions.ClassName + ".cs")
                        {
                            exists = true;
                            break;
                        }

                bool saved = saveFileToProjectFolder(classOptions.ClassFilename, classOptions.ClassContent);
                if (!exists && saved)
                {

                    XmlElement element = projectFile.CreateElement("Compile", itemGroup.NamespaceURI);
                    element.SetAttribute("Include", (!string.IsNullOrWhiteSpace(classOptions.Sufix) ? classOptions.Sufix + "\\" : string.Empty) + classOptions.ClassName + ".cs");
                    itemGroup.AppendChild(element);
                    //projectFile.Save(classOptions.Project.ProjectFile);
                    projectFile.Save(classOptions.Project.Path);
                }
            }
        }

        private bool saveFileToProjectFolder(string filename, string content)
        {
            try
            { 
                using (TextWriter tw = new StreamWriter(filename, false))
                {
                    tw.Write(content);
                    tw.Close();
                }
            }
            catch(Exception ex)
            {
                return false;
                throw;
            }

            return true;
        }

        public void SaveSpNames(ClassOptions classOptions)
        {
            XmlDocument spNames = new XmlDocument();
            if(classOptions.Project != null)
            { 
                string spNamesFilename = classOptions.Project.Path.Substring(0, classOptions.Project.Path.LastIndexOf("\\") + 1) + "spNames.xml";

                XmlDocument generatedSpNames = new XmlDocument();
                generatedSpNames.LoadXml(classOptions.ClassContent);

                if (File.Exists(spNamesFilename))
                { 
                    spNames.Load(classOptions.Project.Path.Substring(0, classOptions.Project.Path.LastIndexOf("\\") + 1) + "\\spNames.xml");
                    foreach(XmlNode newClassTag in generatedSpNames.DocumentElement.SelectNodes("Class"))
                    {
                        bool exists = false;
                        foreach(XmlNode classTag in spNames.DocumentElement.SelectNodes("Class"))
                        {
                            if(classTag.SelectNodes("name")[0].InnerText == newClassTag.SelectNodes("name")[0].InnerText)
                            {
                                exists = true;
                                break;
                            }
                    
                        }

                        if (!exists)
                        {
                            XmlNode newTag = spNames.DocumentElement;
                            newTag = newClassTag;
                        
                            spNames.DocumentElement.AppendChild(spNames.ImportNode(newTag, true));
                        }
                    }
                    spNames.Save(spNamesFilename);
                }
                else
                { 
                    generatedSpNames.Save(spNamesFilename);
                    addSpNamesToProject(classOptions.Project.Path);
                }
            }

        }

        private bool addSpNamesToProject(string projectFilename)
        {
            XmlDocument projectFile = new XmlDocument();
            projectFile.Load(projectFilename);

            XmlNode itemGroup = projectFile.GetElementsByTagName("ItemGroup")[projectFile.GetElementsByTagName("ItemGroup").Count - 1];

            bool exists = false;

            for(int i = 0; i < itemGroup.ChildNodes.Count; i++)
                for(int j = 0; j < itemGroup.ChildNodes[i].Attributes.Count; j++)
                    if(itemGroup.ChildNodes[i].Attributes[j].Value == "spNames.xml")
                    {
                        exists = true;
                        break;
                    }

            if(!exists)
            {
                XmlElement element = projectFile.CreateElement("Content", itemGroup.NamespaceURI);
                element.SetAttribute("Include", "spNames.xml");
                itemGroup.AppendChild(element);
                projectFile.Save(projectFilename);
            }

            return true;
        }

        public void AddReferenceToProject(Project project, string referenceName, string referencePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(project.ProjectFile);

            XmlNode itemGroup = xmlDoc.GetElementsByTagName("ItemGroup")[0];

            bool exists = false;
            for(int i = 0; i < itemGroup.ChildNodes.Count; i++)
            {
                for(int j = 0; j < itemGroup.ChildNodes[i].Attributes.Count; j++)
                {
                    if(itemGroup.ChildNodes[i].Attributes[j].Value == referenceName)
                    {
                        exists = true;
                        break;
                    }
                }
            }

            if(!exists)
            {
                XmlElement element = xmlDoc.CreateElement("Reference", itemGroup.NamespaceURI);
                element.SetAttribute("Include", referenceName);

                if(referencePath != string.Empty)
                {
                    XmlElement pathElement = xmlDoc.CreateElement("HintPath", itemGroup.NamespaceURI);
                    pathElement.InnerText = referencePath;

                    element.AppendChild(pathElement);
                }

                itemGroup.AppendChild(element);
                xmlDoc.Save(project.ProjectFile);
            }
        }
    }
}
