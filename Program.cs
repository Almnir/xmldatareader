using System;
using System.Data.SqlClient;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        public static string GetConnectionString(string ServerText, string DatabaseText, string LoginText, string PasswordText)
        {
            return string.Format("Server={0};Database={1};User Id={2};Password={3};", ServerText, DatabaseText, LoginText, PasswordText);
        }

        private static void SetupBulkCopy(SqlBulkCopy sqlBulkCopy)
        {
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(0, "AreaID"));
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(1, "Region"));
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(2, "AreaCode"));
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(3, "AreaName"));

            sqlBulkCopy.DestinationTableName = "rbd_Areas";
        }

        static void Main(string[] args)
        {
            using (XmlTextReader xmlTextReader = new XmlTextReader(@"j:\trash\xml70\70_Areas.xml"))
            using(SqlConnection connection = new SqlConnection(GetConnectionString("127.0.0.1", "testdb", "sa", "Njkmrjcdjb")))
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection))
            {
                connection.Open();
                SetupBulkCopy(sqlBulkCopy);

                sqlBulkCopy.BatchSize = 1;
                sqlBulkCopy.NotifyAfter = 1;
                sqlBulkCopy.SqlRowsCopied += (sender, eventArgs) => Console.WriteLine("Wrote " + eventArgs.RowsCopied + " records.");

                var reader = new ResultDataReader(xmlTextReader);
                sqlBulkCopy.WriteToServer(reader);
            }

        }
    }
}
