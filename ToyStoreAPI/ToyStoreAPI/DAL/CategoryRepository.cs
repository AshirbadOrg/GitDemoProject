using System.Data;
using System.Data.SqlClient;
using ToyStoreAPI.Models;

namespace ToyStoreAPI.DAL
{
    public class CategoryRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public CategoryRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            string query = "SELECT CategoryId, Name, Description FROM Categories ORDER BY Name";
            var table = await _dbHelper.ExecuteQueryAsync(query);
            var categories = new List<Category>();

            foreach (DataRow row in table.Rows)
            {
                categories.Add(new Category
                {
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    Name = row["Name"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? ""
                });
            }

            return categories;
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            string query = "SELECT CategoryId, Name, Description FROM Categories WHERE CategoryId = @CategoryId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryId", categoryId)
            };

            var table = await _dbHelper.ExecuteQueryAsync(query, parameters);
            if (table.Rows.Count == 0)
                return null;

            var row = table.Rows[0];
            return new Category
            {
                CategoryId = Convert.ToInt32(row["CategoryId"]),
                Name = row["Name"].ToString() ?? "",
                Description = row["Description"].ToString() ?? ""
            };
        }
    }
}
