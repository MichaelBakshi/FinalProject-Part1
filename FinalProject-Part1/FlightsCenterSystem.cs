using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class FlightsCenterSystem
    {
        //singleton
        //GetFacade

        private object key = new object();
        private static FlightsCenterSystem instance = null;
        private static object key_singleton = new object();
        public const int max_connections = 10;
        //private FlightsCenterSystem() { }
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
        public void DoSomething ()
        {
            Console.WriteLine("Hello from singleton!");
        }

        private FlightsCenterSystem ()
        {
            for (int i = 0; i < max_connections; i++)
            {
                //m_connections.Enqueue(new MyDbConnection());
            }

        }



        //public FacadeBase facade ()
    }
}
