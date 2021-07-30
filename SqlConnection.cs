using System;

namespace MultipleDBConnectionAbstractClassesPractice
{
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
}
