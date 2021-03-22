using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject_Part1
{
    public class FlightsCenterSystem
    {
        //singleton
        //GetFacade

        private Queue<NpgsqlConnection> m_connections;
        public const int max_connections = 10;
        // TODO: change this! should come from config file!
        private static string conn_string = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
        private object key = new object();
        private static FlightsCenterSystem instance = null;
        private static object key_singleton = new object();
        UpdateHistoryOfTicketsAndFlights uh;

        
        public static FlightsCenterSystem Instance
        {
            get 
            { 
                if (instance == null)
                {
                    lock (key_singleton)
                    {
                        if (instance==null)
                        {
                            instance = new FlightsCenterSystem();
                        }
                    }  
                }
                return instance; 
            }
        }

        private FlightsCenterSystem()
        {
            m_connections = new Queue<NpgsqlConnection>(max_connections);

            for (int i = 0; i < max_connections; i++)
            {
                m_connections.Enqueue(new NpgsqlConnection(conn_string));
            }

            //Thread t1 = new Thread(new ThreadStart(UpdateHistoryOfTicketsAndFlights.UpdateHistory));
            //t1.Start();
            //Task.Run(() => UpdateHistoryOfTicketsAndFlights.UpdateHistory());

            Task.Factory.StartNew(() =>
            {
                UpdateHistoryOfTicketsAndFlights.UpdateHistory();
            }, TaskCreationOptions.LongRunning);
        }

        public NpgsqlConnection GetConnection()
        {
            lock (key)
            {
                while (m_connections.Count == 0)
                {
                    Monitor.Wait(key);
                }
                NpgsqlConnection result = m_connections.Dequeue();
                //result.Open(); // check if not failed, if so create new connection
                result = new NpgsqlConnection(conn_string); // is this better?
                result.Open();
                return result;
            }
        }

        //public MyDbConnection GetConnection()
        //{
        //    try
        //    {
        //        Monitor.Enter(key);
        //        while (m_connections.Count == 0)
        //        {
        //            Monitor.Wait(key);
        //        }
        //        var conn = m_connections.Dequeue();
        //        return conn;
        //    }
        //    finally
        //    {
        //        Monitor.Exit(key);
        //    }
        //}

        public void ReturnConnection(NpgsqlConnection conn)
        {
            lock (key)
            {
                //conn.Close(); // here? or maybe somewhere else?
                m_connections.Enqueue(conn);
                Monitor.Pulse(key);
            }

            
        }

        //public void RestoreConnection(MyDbConnection conn)
        //{
        //    try
        //    {
        //        Monitor.Enter(key);
        //        m_connections.Enqueue(conn);
        //    }
        //    finally
        //    {
        //        Monitor.Exit(key);
        //    }
        //}


        //ConnectionPool.DbConnection

        //public FacadeBase GetFacade()
        //{

        //    LoginService
        //}

        public FacadeBase GetFacade<T>(LoginToken<T> token) where T : IUser
        {
            if (typeof(T) == typeof(Administrator))
                return new LoggedInAdministratorFacade();
            if (typeof(T) == typeof(AirlineCompany))
                return new LoggedInAirlineFacade();
            if (typeof(T) == typeof(Customer))
                return new LoggedInCustomerFacade();
            else
                return new AnonymousUserFacade();
        }
    }
}
