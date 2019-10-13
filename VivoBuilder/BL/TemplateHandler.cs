using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VivoBuilder
{
    public class TemplateHandler
    {
        private string loadTemplate(string name)
        {
            string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            using (TextReader tr = new StreamReader(assemblyLocation.Substring(0, assemblyLocation.LastIndexOf("\\")) + "\\templates\\serverside\\" + name + ".txt"))
            {
                return tr.ReadToEnd();
            }
        }

        public string GenerateContent(Dictionary<string, string> replaceTags, string templateName)
        {
            string template = loadTemplate(templateName);

            Regex regex;
            foreach(KeyValuePair<string, string> tag in replaceTags)
            {
                regex = new Regex("\\[" + tag.Key + "\\]");
                template = regex.Replace(template, tag.Value);
            }

            return template;
        }
    }
}
