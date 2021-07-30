using System.Collections.Generic;

namespace MultipleDBConnectionAbstractClassesPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlCommand = new DBCommand(new SqlConnection("sqlDB1991"), "Update table...");
            sqlCommand.Execute();

            var oracleCommand = new DBCommand(new OracleConnection("Oracle_DB_1"), "Insert table...");
            oracleCommand.Execute();
        }
    }
}
