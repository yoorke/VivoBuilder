using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VivoBuilder.BL;
using VivoBuilder.Models;
using System.Configuration;
using System.Xml;

namespace VivoBuilder
{
    public partial class ClassBuilder : Form
    {
        public ClassBuilder()
        {
            InitializeComponent();
        }

        Dictionary<string, Dictionary<Table, ClassOptions>> GeneratedClasses = new Dictionary<string, Dictionary<Table, ClassOptions>>();
        //Dictionary<string, string> ModelClasses = new Dictionary<string, string>();
        

        private void ClassBuilder_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //GeneratedClasses.Add("ModelClasses", new Dictionary<Table, ClassOptions>());
            //GeneratedClasses.Add("ModelViewClasses", new Dictionary<Table, ClassOptions>());

            foreach (string classesName in ConfigurationManager.AppSettings["generatedClassesNames"].Split(','))
            { 
                //GeneratedClasses.Add(classesName, new Dictionary<Table, ClassOptions>());
                cmbType.Items.Add(classesName);
            }

            loadDataTables();

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Namespace))
                txtNamespace.Text = Properties.Settings.Default.Namespace;
            if (!String.IsNullOrEmpty(Properties.Settings.Default.SolutionFilename))
                txtSolutionFilename.Text = Properties.Settings.Default.SolutionFilename;

            //cmbType.Items.Add("Model");
            //cmbType.Items.Add("ModelView");
            //cmbType.Items.Add("BusinessLogic");
            
            cmbType.SelectedIndex = 0;
               
        }

        private void loadDataTables()
        {
            List<Table> tables = new DatabaseRepository().LoadDatabaseTables();
            lstDatabaseTables.Items.Clear();
            lstDatabaseTables.DataSource = tables;
            lstDatabaseTables.DisplayMember = "FullName";
            //lstDatabaseTables.Items.AddRange(tables.ToArray());
        }

        

        private void btnGenerateClasses_Click(object sender, EventArgs e)
        {
            try
            {
                //populateProjects();

                //GeneratedClasses["ModelClasses"].Clear();
                //GeneratedClasses["ModelViewClasses"].Clear();


                List<Table> tableList = new List<Table>();
                for (int i = 0; i < lstDatabaseTables.CheckedItems.Count; i++)
                {
                    //string tableName = lstDatabaseTables.CheckedItems[i].ToString().Substring(lstDatabaseTables.CheckedItems[i].ToString().IndexOf('.') + 1);
                    //string tableSchema = lstDatabaseTables.CheckedItems[i].ToString().Substring(0, lstDatabaseTables.CheckedItems[i].ToString().IndexOf('.'));
                    //Table table = ((Table)lstDatabaseTables.CheckedItems[i]);

                    tableList.Add(((Table)lstDatabaseTables.CheckedItems[i]));

                    //ClassOptions classOptions = new ClassOptions();
                    //classOptions.SetTable((Table)lstDatabaseTables.CheckedItems[i]);

                    //GeneratedClasses["ModelClasses"]
                    //.Add(lstDatabaseTables.CheckedItems[i].ToString(), new ClassGenerator().GenerateModelClass(lstDatabaseTables.CheckedItems[i].ToString(), tableSchema, txtLanguageTableSuffix.Text, txtNamespace.Text));
                    //.Add(table, new ClassGenerator().GenerateModelClass(table, txtLanguageTableSuffix.Text, txtNamespace.Text));

                    //GeneratedClasses["ModelViewClasses"]
                    //.Add(lstDatabaseTables.CheckedItems[i].ToString(), new ClassGenerator().GenerateModelViewClass(lstDatabaseTables.CheckedItems[i].ToString(), tableSchema, txtLanguageTableSuffix.Text, txtNamespace.Text));
                    //.Add(table, new ClassGenerator().GenerateModelViewClass(table, txtLanguageTableSuffix.Text, txtNamespace.Text));

                    
                }

                cmbProjects.DataSource = new ProjectBL().GetProjects(txtSolutionFilename.Text);
                cmbProjects.DisplayMember = "Name";
                cmbProjects.ValueMember = "ID";

                GeneratedClasses = new ClassGenerator().GenerateClasses(tableList, txtLanguageTableSuffix.Text, txtNamespace.Text, txtSolutionFilename.Text);

                

                showGeneratedClasses(lstDatabaseTables.SelectedIndex);

                Properties.Settings.Default.Namespace = txtNamespace.Text;
                Properties.Settings.Default.SolutionFilename = txtSolutionFilename.Text;
                Properties.Settings.Default.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showGeneratedClasses(int index)
        {
            try
            {
                //txtGeneratedClass.Text = ModelClasses.ElementAt(index).Value;

                //int index = 0;
                //int classIndex = 0;
                //foreach (KeyValuePair<string, Dictionary<Table, ClassOptions>> classList in GeneratedClasses)
                //{
                //if (classList.Value.ContainsKey(((Table)lstDatabaseTables.Items[index])))
                if (cmbType.SelectedItem != null && GeneratedClasses.ContainsKey(cmbType.SelectedItem.ToString() + "Classes") && GeneratedClasses[cmbType.SelectedItem + "Classes"].ContainsKey((Table)lstDatabaseTables.Items[index]))
                {
                        //ClassOptions classOptions = classList.Value[((Table)lstDatabaseTables.Items[index])];
                        ClassOptions classOptions = GeneratedClasses[cmbType.SelectedItem.ToString() + "Classes"][((Table)lstDatabaseTables.Items[index])];
                        //((TextBox)((TabPage)tbcGeneratedClasses.TabPages["tbp" + classList.Key]).Controls.Find("txt" + classList.Key, true)[0]).Text = classList.Value[((Table)lstDatabaseTables.Items[index])].ClassContent;
                        txtClassContent.Text = classOptions.ClassContent;
                        txtClassNamespace.Text = classOptions.Namespace;
                        //cmbProjects.SelectedItem = classOptions.Project;
                        cmbProjects.SelectedValue = classOptions.Project != null ? classOptions.Project.ID : -1;
                }
                else
                {
                    txtClassContent.Text = string.Empty;
                    cmbProjects.SelectedIndex = -1;
                }

                    //classIndex++;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbcGeneratedClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                //if (ModelClasses.ContainsKey(lstDatabaseTables.SelectedItem.ToString()))
                //txtGeneratedModel.Text = ModelClasses[lstDatabaseTables.SelectedItem.ToString()];
                //else
                //txtGeneratedModel.Text = string.Empty;

                //int index = 0;
                //foreach (Dictionary<string, string> classList in GeneratedClasses)
                //{
                    //if (classList.ContainsKey(lstDatabaseTables.SelectedItem.ToString()))
                        //((TextBox)((TabPage)tbcGeneratedClasses.TabPages[index]).Controls.Find("txtGeneratedClass" + index, true)[0]).Text = classList[lstDatabaseTables.SelectedItem.ToString()];

                    //index++;
                //}
            //}
            //catch(Exception ex)
            //{
                //MessageBox.Show(ex.Message);
            //}
        }

        private void lstDatabaseTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            showGeneratedClasses(lstDatabaseTables.SelectedIndex);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //ExportOptions objfrmExportOptions = new ExportOptions();
            //objfrmExportOptions.ShowDialog();

            ProjectBL projectBL = new ProjectBL();
            foreach (string classType in ConfigurationManager.AppSettings["generatedClassesNames"].Split(','))
            {
                if(!classType.Equals("SpNames"))
                    foreach(KeyValuePair<Table, ClassOptions> generatedClass in GeneratedClasses[classType + "Classes"])
                    {
                        projectBL.AddFileToProject(((ClassOptions)generatedClass.Value));
                    }
                else
                {
                    foreach(KeyValuePair<Table, ClassOptions> generatedClass in GeneratedClasses[classType + "Classes"])
                    {
                        projectBL.SaveSpNames(generatedClass.Value);
                    }
                }
            }

            MessageBox.Show("Export successfull");
        }

        private void btnSelectSolution_Click(object sender, EventArgs e)
        {
            string solutionFilename = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            if (Properties.Settings.Default.Folder != string.Empty)
                dialog.FileName = Properties.Settings.Default.Folder;

            if(dialog.ShowDialog() == DialogResult.OK && dialog.FileName != string.Empty)
            {
                Properties.Settings.Default.Folder = dialog.FileName;
                Properties.Settings.Default.Save();

                txtSolutionFilename.Text = dialog.FileName;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            showGeneratedClasses(lstDatabaseTables.SelectedIndex);
        }

        private void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbType.SelectedItem != null
                && GeneratedClasses.ContainsKey(cmbType.SelectedItem.ToString() + "Classes")
                && GeneratedClasses[cmbType.SelectedItem.ToString() + "Classes"].ContainsKey((Table)lstDatabaseTables.Items[lstDatabaseTables.SelectedIndex]))
            {
                GeneratedClasses[cmbType.SelectedItem.ToString() + "Classes"][(Table)lstDatabaseTables.Items[lstDatabaseTables.SelectedIndex]].Project = ((Project)cmbProjects.SelectedItem).ID != -1 ? (VivoBuilder.Models.Project)cmbProjects.SelectedItem : null;
            }
        }
    }
}
