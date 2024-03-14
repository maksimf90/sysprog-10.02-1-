using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace sysprog_10._02_1_
{
    public class DB
    {
        NpgsqlConnection connection;
        Product product;

        public DB(string qwe)
        {
            connection = new NpgsqlConnection(qwe);
        }

        public NpgsqlConnection getConnection()
        {
            return connection;
        }


        public List<Product> getProduct()
        {
            List<Product> result = new List<Product>();

            connection.Open();
            string commandString = "SELECT * FROM product";
            var command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            
            while ( reader.Read() )
            {
                result.Add(new Product(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
            }
            connection.Close();
            return result;
        }
    }

}
