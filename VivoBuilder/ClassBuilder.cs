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

namespace VivoBuilder
{
    public partial class ClassBuilder : Form
    {
        public ClassBuilder()
        {
            InitializeComponent();
        }

        Dictionary<string, Dictionary<string, string>> GeneratedClasses = new Dictionary<string, Dictionary<string, string>>();
        //Dictionary<string, string> ModelClasses = new Dictionary<string, string>();
        

        private void ClassBuilder_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            GeneratedClasses.Add("ModelClasses", new Dictionary<string, string>());
            GeneratedClasses.Add("ModelViewClasses", new Dictionary<string, string>());

            loadDataTables();
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

                GeneratedClasses["ModelClasses"].Clear();
                GeneratedClasses["ModelViewClasses"].Clear();

                for(int i = 0; i < lstDatabaseTables.CheckedItems.Count; i++)
                {
                    //string tableName = lstDatabaseTables.CheckedItems[i].ToString().Substring(lstDatabaseTables.CheckedItems[i].ToString().IndexOf('.') + 1);
                    //string tableSchema = lstDatabaseTables.CheckedItems[i].ToString().Substring(0, lstDatabaseTables.CheckedItems[i].ToString().IndexOf('.'));
                    Table table = ((Table)lstDatabaseTables.CheckedItems[i]);

                    //ClassOptions classOptions = new ClassOptions();
                    //classOptions.SetTable((Table)lstDatabaseTables.CheckedItems[i]);

                    GeneratedClasses["ModelClasses"]
                        //.Add(lstDatabaseTables.CheckedItems[i].ToString(), new ClassGenerator().GenerateModelClass(lstDatabaseTables.CheckedItems[i].ToString(), tableSchema, txtLanguageTableSuffix.Text, txtNamespace.Text));
                        .Add(table.Name, new ClassGenerator().GenerateModelClass(table, txtLanguageTableSuffix.Text, txtNamespace.Text));

                    GeneratedClasses["ModelViewClasses"]
                        //.Add(lstDatabaseTables.CheckedItems[i].ToString(), new ClassGenerator().GenerateModelViewClass(lstDatabaseTables.CheckedItems[i].ToString(), tableSchema, txtLanguageTableSuffix.Text, txtNamespace.Text));
                        .Add(table.Name, new ClassGenerator().GenerateModelViewClass(table, txtLanguageTableSuffix.Text, txtNamespace.Text));
                }

                showGeneratedClasses(lstDatabaseTables.SelectedIndex);
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
                foreach (KeyValuePair<string, Dictionary<string, string>> classList in GeneratedClasses)
                {
                    if (classList.Value.ContainsKey(((Table)lstDatabaseTables.Items[index]).Name))
                        ((TextBox)((TabPage)tbcGeneratedClasses.TabPages["tbp" + classList.Key]).Controls.Find("txt" + classList.Key, true)[0]).Text = classList.Value[((Table)lstDatabaseTables.Items[index]).Name];

                    //classIndex++;
                }
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
            ExportOptions objfrmExportOptions = new ExportOptions();
            objfrmExportOptions.ShowDialog();
        }
    }
}
