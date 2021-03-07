using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class ConnectionPool
    {
        public class DbConnection
        {

        }
        
        private const int max_connections = 10;
        private List<DbConnection> my_connections;
        private object conn_key = new object();

        public DbConnection GetConnection()
        {
            lock (conn_key)
            {
                if (my_connections.Count > 0)
                {
                    DbConnection result = my_connections[my_connections.Count - 1];
                    my_connections.RemoveAt(my_connections.Count - 1);
                    return result;
                }
            }
            return null;
        }
        public void ReturnConnection(DbConnection conn)
        {
            lock (conn_key)
            {
                my_connections.Add(conn);
            }
        }
        private ConnectionPool()
        {
            my_connections = new List<DbConnection>();
            for (int i = 0; i < max_connections; i++)
            {
                my_connections.Add(new DbConnection());
            }
        }
    }
    
}
