using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using VivoBuilder.Models;

namespace VivoBuilder.BL
{
    public class ClassGenerator
    {
        public string GenerateModelClass(string tableName, string languageTableSuffix, string namespaceName)
        {
            Dictionary<string, string> propertyRT = new Dictionary<string, string>();
            Dictionary<string, string> classRT = new Dictionary<string, string>();
            List<TableColumn> tableColumns = new DatabaseRepository().GetTableColumns(tableName, languageTableSuffix);

            StringBuilder classProperties = new StringBuilder();

            classRT.Add("NAMESPACE", namespaceName);
            classRT.Add("CLASS-NAME", new Common().ToPascalCase(tableName));

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

            return new TemplateHandler().GenerateContent(classRT, "ModelTemplate");

            //return string.Empty;
        }

        public string GenerateModelViewClass(string tableName, string languageTableSuffix, string namespaceName)
        {
            Dictionary<string, string> classRT = new Dictionary<string, string>();
            Dictionary<string, string> propertyRT = new Dictionary<string, string>();            
            List<TableColumn> tableColumns = new DatabaseRepository().GetTableColumns(tableName, languageTableSuffix);
            bool isForeignKey = false;

            StringBuilder classProperties = new StringBuilder();

            classRT.Add("NAMESPACE", namespaceName);
            classRT.Add("CLASS-NAME", new Common().ToPascalCase(tableName) + "View");

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

            return new TemplateHandler().GenerateContent(classRT, "ModelViewTemplate");
        }
    }
}
