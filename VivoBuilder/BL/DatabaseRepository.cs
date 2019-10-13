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

        public ArrayList LoadDatabaseTables()
        {
            try
            {
                DataTable dtSchema;
                ArrayList tables = new ArrayList();

                if (Properties.Settings.Default.ConnString != string.Empty)
                {
                    using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                    {
                        conn.Open();

                        dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });

                        for (int i = 0; i < dtSchema.Rows.Count - 1; i++)
                            tables.Add(dtSchema.Rows[i].ItemArray[2].ToString());

                        
                    }
                }

                return tables;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TableColumn> GetTableColumns(string tableName, string languageSuffix)
        {
            DataTable tableFields;
            DataTable languageTableFields;
            List<TableColumn> columns = new List<TableColumn>();
            

            using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
            {
                conn.Open();

                tableFields = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName });

                if (!languageSuffix.Equals(string.Empty))
                {
                    languageTableFields = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName + "_" + languageSuffix });
                    foreach (DataRow row in languageTableFields.Rows)
                        if (!row["COLUMN_NAME"].ToString().Equals(tableName + "_id"))
                            tableFields.Rows.Add(row.ItemArray);
                }

                foreach (DataRow row in tableFields.Rows)
                {
                    if (!excludedColumns.Contains(row["COLUMN_NAME"].ToString()))
                    {
                        DataTable columnData = getTableColumnData(row["COLUMN_NAME"].ToString(), tableName);
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
