using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VivoBuilder
{
    public partial class ExportOptions : Form
    {
        public ExportOptions()
        {
            InitializeComponent();
        }

        private void btnSelectSolution_Click(object sender, EventArgs e)
        {
            string solutionFolder = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            if (Properties.Settings.Default.Folder != string.Empty)
                dialog.FileName = Properties.Settings.Default.Folder;

            if(dialog.ShowDialog() == DialogResult.OK && dialog.FileName != string.Empty)
            {
                Properties.Settings.Default.Folder = dialog.FileName;
                Properties.Settings.Default.Save();

                txtSolutionFilename.Text = dialog.FileName;
                solutionFolder = dialog.FileName.Substring(0, dialog.FileName.LastIndexOf("\\"));

                var solution = File.ReadAllText(dialog.FileName);
                Regex projReg = new Regex("Project\\(\"\\{[\\w-]*\\}\"\\) = \"([\\w _]*.*)\", \"(.*\\.(cs|vcx|vb)proj)\"", RegexOptions.Compiled);
                var matches = projReg.Matches(solution).Cast<Match>();
                var projects = matches.Select(x => x.Groups[2].Value.Replace(x.Groups[1].Value + "\\", string.Empty)).ToList();

                List<KeyValuePair<string, string>> projectItems = new List<KeyValuePair<string, string>>();

                for(int i = 0; i < projects.Count; i++)
                {
                    string projectName = projects[i].Replace(".csproj", string.Empty);
                    //projectName = projectName.Substring(projectName.LastIndexOf("\\") + 1, projectName.Length - projectName.LastIndexOf("\\") - 1);
                    //projectName = projectName.Substring(projectName.LastIndexOf('.') + 1, projectName.Length - projectName.LastIndexOf('.') - 1);
                    if (!Path.IsPathRooted(projects[i]))
                        projects[i] = Path.Combine(solutionFolder, projects[i]);
                    projects[i] = Path.GetFullPath(projects[i]);

                    //projectItems.Add(new KeyValuePair<string, string>(projects[i].Replace(".csproj", string.Empty), projects[i]));
                    projectItems.Add(new KeyValuePair<string, string>(projectName, projects[i]));
                }

                //cmbModel.DataSource = projectItems;
                //cmbModel.ValueMember = "Value";
                //cmbModel.DisplayMember = "Key";
                //cmbModel.SelectedItem = projectItems.Find(item => item.Key.Contains("Model"));

                //cmbModelView.DataSource = projectItems;
                //cmbModelView.ValueMember = "Value";
                //cmbModelView.DisplayMember = "Key";

                populateControls(projectItems);
            }
        }

        private void populateControls(List<KeyValuePair<string, string>> projects)
        {
            foreach (Control control in grpProjects.Controls)
                if (control.GetType() == typeof(ComboBox) && control.Name.StartsWith("cmb"))
                {
                    ((ComboBox)control).BindingContext = new BindingContext();
                    ((ComboBox)control).DataSource = projects;
                    ((ComboBox)control).ValueMember = "Value";
                    ((ComboBox)control).DisplayMember = "Key";
                    ((ComboBox)control).SelectedItem = projects.Find(item => item.Key.Contains(control.Name.Substring(3)));
                }
        }
    }
}
