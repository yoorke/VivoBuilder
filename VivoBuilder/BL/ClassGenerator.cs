using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using VivoBuilder.Models;

namespace VivoBuilder.BL
{
    public class ClassGenerator
    {
        public Dictionary<string, Dictionary<Table, ClassOptions>> GenerateClasses(List<Table> tableList, string languageTableSuffix, string namespaceName)
        {
            Dictionary<string, Dictionary<Table, ClassOptions>> generatedClasses = new Dictionary<string, Dictionary<Table, ClassOptions>>();
            generatedClasses.Add("ModelClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("ModelViewClasses", new Dictionary<Table, ClassOptions>());
            //generatedClasses["ModelClasses"].Clear();
            //generatedClasses["ModelViewClasses"].Clear();

            foreach(Table table in tableList)
            {
                List<TableColumn> tableColumns = new DatabaseRepository().GetTableColumns(table, languageTableSuffix);

                generatedClasses["ModelClasses"]
                    .Add(table, GenerateModelClass(table, languageTableSuffix, namespaceName, tableColumns));
            }

            return generatedClasses;
        }

        public ClassOptions GenerateModelClass(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns)
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions
                .SetClassName(new Common().ToPascalCase(table.Name))
                .SetNamespace(namespaceName + ".Models")
                .SetSchema(table.Schema);

            Dictionary<string, string> propertyRT = new Dictionary<string, string>();
            Dictionary<string, string> classRT = new Dictionary<string, string>();
            //List<TableColumn> tableColumns = new DatabaseRepository().GetTableColumns(table, languageTableSuffix);

            StringBuilder classProperties = new StringBuilder();

            classRT.Add("NAMESPACE", classOptions.Namespace);
            classRT.Add("CLASS-NAME", classOptions.ClassName);

            foreach (TableColumn column in tableColumns)
            {
                propertyRT.Clear();
                propertyRT.Add("REQUIRED", !column.IsNullable ? "[Required]" : string.Empty);
                propertyRT.Add("STRING-LENGTH", column.Type.Equals("string") ? "[StringLength(" + column.Size + ")]" : string.Empty);
                propertyRT.Add("FIELD-NAME", column.Name);
                propertyRT.Add("PROPERTY-TYPE", column.Type);
                propertyRT.Add("PROPERTY-NAME", new Common().ToPascalCase(column.Name));

                classProperties.Append(Environment.NewLine).Append(new TemplateHandler().GenerateContent(propertyRT, "ModelPropertyTemplate"));
            }

            classRT.Add("CLASS-PROPERTIES", classProperties.ToString());

            classOptions.SetClassContent(new TemplateHandler().GenerateContent(classRT, "ModelTemplate"));

            return classOptions;

            //return string.Empty;
        }

        public ClassOptions GenerateModelViewClass(Table table, string languageTableSuffix, string namespaceName)
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions.SetClassName(new Common().ToPascalCase(table.Name) + "View")
                .SetNamespace(namespaceName + ".Models")
                .SetSchema(table.Schema);

            Dictionary<string, string> classRT = new Dictionary<string, string>();
            Dictionary<string, string> propertyRT = new Dictionary<string, string>();            
            List<TableColumn> tableColumns = new DatabaseRepository().GetTableColumns(table, languageTableSuffix);
            bool isForeignKey = false;

            StringBuilder classProperties = new StringBuilder();

            classRT.Add("NAMESPACE", classOptions.Namespace);
            classRT.Add("CLASS-NAME", classOptions.ClassName);

            foreach(TableColumn column in tableColumns)
            {
                isForeignKey = column.Name.EndsWith(ConfigurationManager.AppSettings["foreignKeyEndsWith"]) ? true : false;
                column.Name = isForeignKey ? column.Name.Substring(0, column.Name.IndexOf(ConfigurationManager.AppSettings["foreignKeyEndsWith"])) : column.Name;
                propertyRT.Clear();
                propertyRT.Add("FIELD-NAME", column.Name + "_name");
                propertyRT.Add("PROPERTY-NAME", new Common().ToPascalCase(column.Name + "Name"));
                propertyRT.Add("PROPERTY-TYPE", column.Type);

                classProperties.Append(Environment.NewLine).Append(new TemplateHandler().GenerateContent(propertyRT, "ModelViewPropertyTemplate"));
            }

            classRT.Add("CLASS-PROPERTIES", classProperties.ToString());

            classOptions.SetClassContent(new TemplateHandler().GenerateContent(classRT, "ModelViewTemplate"));

            return classOptions;
        }

        private Dictionary<string, string> getBaseClassRT(Table table, string namespaceName)
        {
            Dictionary<string, string> classRT = new Dictionary<string, string>();
            return classRT;
        }
    }
}
