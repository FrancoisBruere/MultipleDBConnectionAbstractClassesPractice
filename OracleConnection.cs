using System;

namespace MultipleDBConnectionAbstractClassesPractice
{
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
}
