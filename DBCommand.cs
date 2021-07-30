using System;

namespace MultipleDBConnectionAbstractClassesPractice
{
    public class DBCommand
    {
        public string DbQuery { get; set; }
        public DbConnection DbConnection { get; set; }
        public DBCommand(DbConnection dbConnection, string dbQuery)
        {
            if (dbConnection == null || string.IsNullOrWhiteSpace(dbQuery))
            {
                throw new ArgumentNullException("Connection string or instruction cannot be null");
            }
            else
            {
                DbQuery = dbQuery;
                DbConnection = dbConnection;
            }
        }

        public void Execute()
        {

            DbConnection.OpenConnection();
            Console.WriteLine("Command executed {0}", DbQuery);
            DbConnection.CloseConnection();
        }

        
    }
}
