using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;
using VivoBuilder.Models;

namespace VivoBuilder.BL
{
    public class ClassGenerator
    {
        public Dictionary<string, Dictionary<Table, ClassOptions>> GenerateClasses(
                List<Table> tableList, 
                string languageTableSuffix, 
                string namespaceName, 
                string solutionFilename
            )
        {
            Dictionary<string, Dictionary<Table, ClassOptions>> generatedClasses = new Dictionary<string, Dictionary<Table, ClassOptions>>();
            generatedClasses.Add("ModelClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("ModelViewClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("IBusinessLogicClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("BusinessLogicClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("IBusinessLogicViewClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("BusinessLogicViewClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("ControllerClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("SpNamesClasses", new Dictionary<Table, ClassOptions>());
            generatedClasses.Add("StoredProcedures", new Dictionary<Table, ClassOptions>());

            List<Project> projects = new ProjectBL().GetProjects(solutionFilename);
            //generatedClasses["ModelClasses"].Clear();
            //generatedClasses["ModelViewClasses"].Clear();

            foreach(Table table in tableList)
            {
                List<TableColumn> tableColumns = new DatabaseRepository().GetTableColumns(table, languageTableSuffix);

                generatedClasses["ModelClasses"]
                    .Add(table, generateModelClass(table, languageTableSuffix, namespaceName, tableColumns, projects));

                generatedClasses["ModelViewClasses"]
                    .Add(table, generateModelViewClass(table, languageTableSuffix, namespaceName, tableColumns, projects));

                generatedClasses["IBusinessLogicClasses"]
                    .Add(table, generateIBusinessLogicClass(table, languageTableSuffix, namespaceName, tableColumns, projects));

                generatedClasses["BusinessLogicClasses"]
                    .Add(table, generateBusinessLogicClass(table, languageTableSuffix, namespaceName, tableColumns, projects));

                generatedClasses["ControllerClasses"]
                    .Add(table, generateControllerClass(table, languageTableSuffix, namespaceName, tableColumns, projects));

                generatedClasses["SpNamesClasses"]
                    .Add(table, generateSpNamesClass(table, languageTableSuffix, namespaceName, tableColumns, projects));

                generatedClasses["IBusinessLogicViewClasses"]
                        .Add(table, generateIBusinessLogicClass(table, languageTableSuffix, namespaceName, tableColumns, projects, "View"));

                generatedClasses["BusinessLogicViewClasses"]
                        .Add(table, generateBusinessLogicClass(table, languageTableSuffix, namespaceName, tableColumns, projects, "View"));

                //generatedClasses["SpNamesClasses"]
                //.Add(table, generateSpNamesClass(table, languageTableSuffix, namespaceName, tableColumns, projects));

                generatedClasses["StoredProcedures"]
                        .Add(table, generateStoredProcedures(table, languageTableSuffix, namespaceName, tableColumns, projects));
            }

            return generatedClasses;
        }

        private ClassOptions generateModelClass(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns, List<Project> projects)
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions
                .SetClassName(new Common().ToPascalCase(table.Name))
                .SetNamespace(namespaceName + ".Models")
                .SetSchema(table.Schema)
                .SetProject(projects.Find(project => (project.Name.ToLower().Contains("models") && table.Schema.ToLower() == "dbo") || (project.Name.ToLower().Contains("models") && project.Name.ToLower().Contains(table.Schema.ToLower()))));

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

        private ClassOptions generateModelViewClass(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns, List<Project> projects)
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions.SetClassName(new Common().ToPascalCase(table.Name) + "View")
                .SetNamespace(namespaceName + ".Models")
                .SetSchema(table.Schema)
                .SetProject(projects.Find(project => (project.Name.Contains("Models") && table.Schema == "dbo") || (project.Name.Contains("Models") && project.Name.Contains(table.Schema))));

            Dictionary<string, string> classRT = new Dictionary<string, string>();
            Dictionary<string, string> propertyRT = new Dictionary<string, string>();            
            //List<TableColumn> tableColumns = new DatabaseRepository().GetTableColumns(table, languageTableSuffix);
            bool isForeignKey = false;

            StringBuilder classProperties = new StringBuilder();

            classRT.Add("NAMESPACE", classOptions.Namespace);
            classRT.Add("CLASS-NAME", classOptions.ClassName);

            foreach(TableColumn column in tableColumns)
            {
                isForeignKey = column.Name.ToLower().EndsWith(ConfigurationManager.AppSettings["foreignKeyEndsWith"].ToLower()) ? true : false;
                column.Name = isForeignKey ? column.Name.Substring(0, column.Name.ToLower().IndexOf(ConfigurationManager.AppSettings["foreignKeyEndsWith"].ToLower())) : column.Name;
                propertyRT.Clear();
                propertyRT.Add("FIELD-NAME", column.Name + (isForeignKey ? "Name" : string.Empty));
                propertyRT.Add("PROPERTY-NAME", new Common().ToPascalCase(column.Name + (isForeignKey ? "Name" : string.Empty)));
                propertyRT.Add("PROPERTY-TYPE", isForeignKey ? "string" : column.Type);

                classProperties.Append(Environment.NewLine).Append(new TemplateHandler().GenerateContent(propertyRT, "ModelViewPropertyTemplate"));
            }

            classRT.Add("CLASS-PROPERTIES", classProperties.ToString());

            classOptions.SetClassContent(new TemplateHandler().GenerateContent(classRT, "ModelViewTemplate"));

            return classOptions;
        }

        private ClassOptions generateIBusinessLogicClass(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns, List<Project> projects, string suffix = "")
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions.SetClassName("I" + new Common().ToPascalCase(table.Name) + suffix + "BL")
                .SetNamespace(namespaceName + ".BusinessLogic.Interfaces")
                .SetSchema(table.Schema)
                .SetProject(projects.Find(project => (project.Name.Contains("BusinessLogic.Interfaces") && table.Schema == "dbo") || (project.Name.Contains("BusinessLogic.Interfaces") && project.Name.Contains(table.Schema))));

            Dictionary<string, string> classRT = new Dictionary<string, string>();
            //Dictionary<string, string> propertyRT = new Dictionary<string, string>();

            classRT.Add("NAMESPACE", classOptions.Namespace);
            classRT.Add("CLASS-NAME", classOptions.ClassName);
            classRT.Add("MODEL-NAME", new Common().ToPascalCase(table.Name) + suffix);
            classRT.Add("MODEL-PROJECT-NAME", namespaceName + ".Models");

            classOptions.SetClassContent(new TemplateHandler().GenerateContent(classRT, "BusinessLogicInterfaceTemplate"));
            
            return classOptions;
        }

        private ClassOptions generateBusinessLogicClass(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns, List<Project> projects, string suffix = "")
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions.SetClassName(new Common().ToPascalCase(table.Name) + suffix + "BL")
                .SetNamespace(namespaceName + ".BusinessLogic")
                .SetSchema(table.Schema)
                .SetProject(projects.Find(project => (project.Name.Contains("BusinessLogic") && table.Schema == "dbo") || (project.Name.Contains("BusinessLogic") && project.Name.Contains(table.Schema))));

            Dictionary<string, string> classRT = new Dictionary<string, string>();

            classRT.Add("NAMESPACE", classOptions.Namespace);
            classRT.Add("CLASS-NAME", classOptions.ClassName);
            classRT.Add("MODEL-NAME", new Common().ToPascalCase(table.Name) + suffix);
            classRT.Add("INTERFACE-NAME", "I" + classOptions.ClassName);
            classRT.Add("MODEL-PROJECT-NAME", namespaceName + ".Models");
            classRT.Add("BUSINESS-LOGIC-INTERFACES-PROJECT-NAME", namespaceName + ".BusinessLogic.Interfaces");

            classOptions.SetClassContent(new TemplateHandler().GenerateContent(classRT, "BusinessLogicTemplate"));

            return classOptions;
        }

        private ClassOptions generateControllerClass(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns, List<Project> projects)
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions.SetClassName(new Common().ToPascalCase(table.Name) + "Controller")
                .SetNamespace(namespaceName + ".WebAPI.Controllers")
                .SetSchema(table.Schema)
                .SetProject(projects.Find(project => project.Name.Contains("WebApi") || project.Name.ToLower().EndsWith("api")))
                .SetSufix("Controllers");

            Dictionary<string, string> classRT = new Dictionary<string, string>();

            //classRT.Add("PROJECT-NAME", table.Schema.Equals("dbo") ? namespaceName + string.Empty : new Common().ToPascalCase(table.Schema));
            classRT.Add("PROJECT-NAME", namespaceName);
            classRT.Add("NAMESPACE", namespaceName + ".WebAPI");
            classRT.Add("CLASS-NAME", classOptions.ClassName);
            classRT.Add("IBL-NAME", "I" + new Common().ToPascalCase(table.Name) + "BL");
            classRT.Add("IBL-VIEW-NAME", "I" + new Common().ToPascalCase(table.Name) + "ViewBL");
            classRT.Add("MODEL-VIEW-NAME", new Common().ToPascalCase(table.Name) + "View");
            classRT.Add("MODEL-NAME", new Common().ToPascalCase(table.Name));
            classRT.Add("MODEL-NAME-TOLOWER", table.Name.ToLower());

            classOptions.SetClassContent(new TemplateHandler().GenerateContent(classRT, "ControllerTemplate"));

            return classOptions;
        }

        private ClassOptions generateSpNamesClass(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns, List<Project> projects, string suffix = "")
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions.SetClassName(new Common().ToPascalCase(table.Name) + suffix)
            .SetProject(projects.Find(project => project.Name.Contains("WebApi") || project.Name.EndsWith("API")));

            Dictionary<string, string> classRT = new Dictionary<string, string>();

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement classes = xmlDoc.CreateElement("Classes");
            XmlElement className = xmlDoc.CreateElement("Class");

            className.AppendChild(createXmlElement("name", new Common().ToPascalCase(table.Name), xmlDoc));

            className.AppendChild(createXmlElement("get", table.Name + suffix + "_get", xmlDoc));
            className.AppendChild(createXmlElement("insert", table.Name + suffix + "_insert", xmlDoc));
            className.AppendChild(createXmlElement("update", table.Name + suffix + "_update", xmlDoc));
            className.AppendChild(createXmlElement("select", table.Name + suffix + "_select", xmlDoc));
            className.AppendChild(createXmlElement("delete", table.Name + suffix + "_delete", xmlDoc));

            //(XmlElement)
            //xmlDoc.AppendChild(className);
            classes.AppendChild(className);

            XmlElement classNameView = xmlDoc.CreateElement("Class");
            classNameView.AppendChild(createXmlElement("name", new Common().ToPascalCase(table.Name) + "View" + string.Empty, xmlDoc));
            classNameView.AppendChild(createXmlElement("get", table.Name + "View" + "_get", xmlDoc));
            classNameView.AppendChild(createXmlElement("insert", table.Name + "View" + "_insert", xmlDoc));
            classNameView.AppendChild(createXmlElement("update", table.Name + "View" + "_update", xmlDoc));
            classNameView.AppendChild(createXmlElement("select", table.Name + "View" + "_select", xmlDoc));
            classNameView.AppendChild(createXmlElement("delete", table.Name + "View" + "_delete", xmlDoc));

            classes.AppendChild(classNameView);

            xmlDoc.AppendChild(classes);

            classOptions.ClassContent = xmlDoc.InnerXml;
            return classOptions;
        }

        private ClassOptions generateStoredProcedures(Table table, string languageTableSuffix, string namespaceName, List<TableColumn> tableColumns, List<Project> projects)
        {
            ClassOptions classOptions = new ClassOptions();
            classOptions.SetClassName(new Common().ToPascalCase(table.Name));

            Dictionary<string, string> classRT = new Dictionary<string, string>();
            //StringBuilder parameters = new StringBuilder();
            //Dictionary<string, string> parameterRT = new Dictionary<string, string>();
            Dictionary<string, string> languageTableJoinRT = new Dictionary<string, string>();

            classRT.Add("DATABASE-NAME", namespaceName);
            classRT.Add("SCHEMA", namespaceName);
            classRT.Add("TABLE-NAME", classOptions.ClassName);

            
            if(hasLanguageTable(tableColumns, languageTableSuffix))
            {
                languageTableJoinRT.Add("LANGUAGE-TABLE-NAME", table.Name + "_" + languageTableSuffix);
            }
            //classRT.Add("LANGUAGE-TABLE-JOIN", )

            //foreach(TableColumn column in tableColumns)
            //{
                //parameterRT.Clear();
                //parameters.Append(Environment.NewLine).Append(new TemplateHandler().GenerateContent(parameterRT, "StoreProcedureParametersTemplate"));
            //}

            //classRT.Add("PARAMETERS", parameters.ToString());


            classOptions.SetClassContent(new TemplateHandler().GenerateContent(classRT, "StoreProceduresTemplate"));

            return classOptions;
        }

        private bool hasLanguageTable(List<TableColumn> tableColumns, string languageTableSuffix)
        {
            bool hasLanguageTable = false;

            foreach(TableColumn column in tableColumns)
            {
                if (column.TableName.Contains("_" + languageTableSuffix))
                { 
                    hasLanguageTable = true;
                    break;
                }
            }

            return hasLanguageTable;
        }

        private XmlElement createXmlElement(string name, string innerText, XmlDocument xmlDoc)
        {
            XmlElement element = xmlDoc.CreateElement(name);
            element.InnerText = innerText;

            return element;
        }

        private Dictionary<string, string> getBaseClassRT(Table table, string namespaceName)
        {
            Dictionary<string, string> classRT = new Dictionary<string, string>();
            return classRT;
        }
    }
}
