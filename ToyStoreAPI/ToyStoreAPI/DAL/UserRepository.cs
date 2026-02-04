using System.Data;
using System.Data.SqlClient;
using ToyStoreAPI.Models;

namespace ToyStoreAPI.DAL
{
    public class UserRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public UserRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            string query = "SELECT UserId, Username, Email, PasswordHash, Role, CreatedAt FROM Users WHERE Username = @Username";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username)
            };

            var table = await _dbHelper.ExecuteQueryAsync(query, parameters);
            if (table.Rows.Count == 0)
                return null;

            var row = table.Rows[0];
            return new User
            {
                UserId = Convert.ToInt32(row["UserId"]),
                Username = row["Username"].ToString() ?? "",
                Email = row["Email"].ToString() ?? "",
                PasswordHash = row["PasswordHash"].ToString() ?? "",
                Role = row["Role"].ToString() ?? "",
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            string query = "SELECT UserId, Username, Email, PasswordHash, Role, CreatedAt FROM Users WHERE Email = @Email";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", email)
            };

            var table = await _dbHelper.ExecuteQueryAsync(query, parameters);
            if (table.Rows.Count == 0)
                return null;

            var row = table.Rows[0];
            return new User
            {
                UserId = Convert.ToInt32(row["UserId"]),
                Username = row["Username"].ToString() ?? "",
                Email = row["Email"].ToString() ?? "",
                PasswordHash = row["PasswordHash"].ToString() ?? "",
                Role = row["Role"].ToString() ?? "",
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }

        public async Task<int> CreateUserAsync(string username, string email, string passwordHash)
        {
            string query = @"INSERT INTO Users (Username, Email, PasswordHash, Role, CreatedAt) 
                           VALUES (@Username, @Email, @PasswordHash, 'Customer', GETDATE());
                           SELECT CAST(SCOPE_IDENTITY() as int)";
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email),
                new SqlParameter("@PasswordHash", passwordHash)
            };

            var result = await _dbHelper.ExecuteScalarAsync(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}
