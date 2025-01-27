using EL.Entities;
using Microsoft.Data.SqlClient;
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
                    Id = Guid.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString()           
                };

                users.Add(user);
            }
            return users;
        }

        public bool Create(User user) 
        {
            string sql = @"
                INSERT INTO [User] (Name,Email,PasswordHash,RoleId,IsActive,CreatedAt)
                VALUES (@Name,@Email,@PasswordHash,@RoleId,@IsActive,GETUTDATE());
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name",user.Name),
                new SqlParameter("@Email",user.Email),
                new SqlParameter("@PasswordHash",user.PasswordHash),
                new SqlParameter("@RoleId",user.RoleId),
                new SqlParameter("@IsActive",user.IsActive),
            };

            int rowsAffected = _connection.ExecuteNonQuery(sql, parameters);
            return rowsAffected > 0;
        }
    }
}
