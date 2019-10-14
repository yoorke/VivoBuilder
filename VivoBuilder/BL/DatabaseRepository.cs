using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivoBuilder.Models;

namespace VivoBuilder.BL
{
    public class DatabaseRepository
    {
        private string[] excludedColumns = new string[]
        {
            "id",
            "useridcr",
            "useridch",
            "useridlk",
            "datetimecr",
            "datetimech",
            "datetimelk",
            "is_active",
            "yt",
            "company_id",
            "language_id",
            "firma_id",
            "org_jed_id"
        };

        public List<Table> LoadDatabaseTables()
        {
            try
            {
                DataTable dtSchema;
                List<Table> tables = new List<Table>();

                if (Properties.Settings.Default.ConnString != string.Empty)
                {
                    using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                    {
                        conn.Open();

                        dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });

                        for (int i = 0; i < dtSchema.Rows.Count - 1; i++)
                            tables.Add(new Table(dtSchema.Rows[i].ItemArray[1].ToString(), dtSchema.Rows[i].ItemArray[2].ToString()));

                        
                    }
                }

                return tables;
            }
            catch
            {
                throw;
            }
        }

        public List<TableColumn> GetTableColumns(Table table, string languageSuffix)
        {
            DataTable tableFields;
            DataTable languageTableFields;
            List<TableColumn> columns = new List<TableColumn>();
            

            using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
            {
                conn.Open();

                tableFields = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, table.Name });

                if (!languageSuffix.Equals(string.Empty))
                {
                    languageTableFields = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, table.Name + "_" + languageSuffix });
                    foreach (DataRow row in languageTableFields.Rows)
                        if (!row["COLUMN_NAME"].ToString().Equals(table.Name + "_id"))
                            tableFields.Rows.Add(row.ItemArray);
                }

                foreach (DataRow row in tableFields.Rows)
                {
                    if (!excludedColumns.Contains(row["COLUMN_NAME"].ToString()))
                    {
                        DataTable columnData = getTableColumnData(row["COLUMN_NAME"].ToString(), table.Name);
                        columns.Add(new TableColumn(
                                            row["COLUMN_NAME"].ToString(),
                                            row["TABLE_NAME"].ToString(),
                                            dataTypeConvert(columnData.Rows[0]["DataType"].ToString()),
                                            bool.Parse(columnData.Rows[0]["AllowDBNull"].ToString()),
                                            bool.Parse(columnData.Rows[0]["IsKey"].ToString()),
                                            int.Parse(columnData.Rows[0]["ColumnSize"].ToString())
                            ));
                    }
                }
            }

            return columns;
        }

        private DataTable getTableColumnData(string columnName, string tableName)
        {
            DataTable schemaTable;
            using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
            {
                conn.Open();

                using (OleDbCommand comm = new OleDbCommand("SELECT [" + columnName + "] FROM [" + tableName + "]", conn))
                {
                    using (OleDbDataReader reader = comm.ExecuteReader(CommandBehavior.KeyInfo))
                    {
                        schemaTable = reader.GetSchemaTable();
                    }
                }
            }
            return schemaTable;
        }

        private string dataTypeConvert(string datatype)
        {
            switch (datatype)
            {
                case "System.String": return "string";
                case "System.Boolean": return "bool";
                case "System.Int32": return "int";
                case "System.DateTime": return "datetime";
                case "System.Double": return "double";
                case "System.Decimal": return "decimal";
                default: return datatype;
            }
        }
    }
}
