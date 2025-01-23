using EL.Entities;
using System.Data;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseConnection _connection;
        public UserRepository(DatabaseConnection connection) {
            _connection = connection;
        }

        public List<User> GetAll()
        {
            string sql = "SELECT Id,Name,Email FROM [User]";

            DataTable dataTable = _connection.ExecuteQuery(sql);

            List<User> users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString()           
                };

                users.Add(user);
            }
            return users;
        }
    }
}
