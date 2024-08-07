using System.Data.SqlClient;
using GestioneHotelApp.Models;

namespace GestioneHotelApp.Data
{
    public class UserDao
    {
        private readonly string _connectionString;

        public UserDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Users WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                PasswordSalt = reader.GetString(reader.GetOrdinal("PasswordSalt"))
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}
