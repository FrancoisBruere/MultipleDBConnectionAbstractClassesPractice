using System;
using System.Collections.Generic;

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

    public class OracleConnection: DbConnection
    {
        public OracleConnection(string connectionstring) :base(connectionstring)
        {

        }
       
        public override void CloseConnection()
        {
            Console.WriteLine("Oracle connection closed!");
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Connection timeout: " + Timeout);
            Console.WriteLine("Connected to Oracle-DB! with string: " + this.ConnectionString);
            

        }
    }
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionstring) : base(connectionstring)
        {

        }

        public override void CloseConnection()
        {
            Console.WriteLine("SQL connection closed!");
            
           
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Connection timeout: " + Timeout);
            Console.WriteLine("Connected to SQL-DB! with string: " + this.ConnectionString);
            
           
        }
    }

    public abstract class DbConnection
    {
        public string ConnectionString { get; private set; }
        public TimeSpan Timeout { get; set; }

        public DbConnection(string connectionstring)
        {
            if (connectionstring is null)
            {
                throw new ArgumentNullException(nameof(connectionstring));
            }
            else
            {
                ConnectionString = connectionstring;
            }
        }
       
        
        public abstract void OpenConnection();

        public abstract void CloseConnection();
       
    }
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
