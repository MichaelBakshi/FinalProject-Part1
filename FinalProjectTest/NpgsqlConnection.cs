namespace FinalProjectTest
{
    internal class NpgsqlConnection
    {
        private object m_conn_string;

        public NpgsqlConnection(object m_conn_string)
        {
            this.m_conn_string = m_conn_string;
        }
    }
}