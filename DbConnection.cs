using System;

namespace MultipleDBConnectionAbstractClassesPractice
{
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
}
