using System;
using System.Data;
using System.Dynamic;
using System.Net.NetworkInformation;

namespace Utility.Data
{
    public class MySqlConnection : IDisposable
    {
        public static MySqlConnection Create(IDbConnection connection)
        {
            if (connection == null)
                return null;

            connection.Open();
            return new MySqlConnection(connection);
        }

        public void Dispose()
        {
            if (m_connection != null)
            {
                m_connection.Close();
                m_connection = null;
            }
        }

        private MySqlConnection(IDbConnection connection)
        {
            m_connection = connection;
        }

        private IDbConnection m_connection;
    }
}
