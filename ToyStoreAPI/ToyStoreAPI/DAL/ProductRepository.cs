using System.Data;
using System.Data.SqlClient;
using ToyStoreAPI.Models;

namespace ToyStoreAPI.DAL
{
    public class ProductRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ProductRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            string query = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.CategoryId, 
                            c.Name as CategoryName, p.StockQuantity, p.ImageUrl, p.AgeRange, p.CreatedAt
                            FROM Products p
                            INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                            ORDER BY p.CreatedAt DESC";

            var table = await _dbHelper.ExecuteQueryAsync(query);
            var products = new List<Product>();

            foreach (DataRow row in table.Rows)
            {
                products.Add(MapRowToProduct(row));
            }

            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            string query = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.CategoryId, 
                            c.Name as CategoryName, p.StockQuantity, p.ImageUrl, p.AgeRange, p.CreatedAt
                            FROM Products p
                            INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                            WHERE p.CategoryId = @CategoryId
                            ORDER BY p.CreatedAt DESC";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryId", categoryId)
            };

            var table = await _dbHelper.ExecuteQueryAsync(query, parameters);
            var products = new List<Product>();

            foreach (DataRow row in table.Rows)
            {
                products.Add(MapRowToProduct(row));
            }

            return products;
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            string query = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.CategoryId, 
                            c.Name as CategoryName, p.StockQuantity, p.ImageUrl, p.AgeRange, p.CreatedAt
                            FROM Products p
                            INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                            WHERE p.ProductId = @ProductId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId", productId)
            };

            var table = await _dbHelper.ExecuteQueryAsync(query, parameters);
            if (table.Rows.Count == 0)
                return null;

            return MapRowToProduct(table.Rows[0]);
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            string query = @"INSERT INTO Products (Name, Description, Price, CategoryId, StockQuantity, ImageUrl, AgeRange, CreatedAt)
                           VALUES (@Name, @Description, @Price, @CategoryId, @StockQuantity, @ImageUrl, @AgeRange, GETDATE());
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@CategoryId", product.CategoryId),
                new SqlParameter("@StockQuantity", product.StockQuantity),
                new SqlParameter("@ImageUrl", product.ImageUrl),
                new SqlParameter("@AgeRange", product.AgeRange)
            };

            var result = await _dbHelper.ExecuteScalarAsync(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            string query = @"UPDATE Products SET 
                           Name = @Name, Description = @Description, Price = @Price, 
                           CategoryId = @CategoryId, StockQuantity = @StockQuantity, 
                           ImageUrl = @ImageUrl, AgeRange = @AgeRange
                           WHERE ProductId = @ProductId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId", product.ProductId),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@CategoryId", product.CategoryId),
                new SqlParameter("@StockQuantity", product.StockQuantity),
                new SqlParameter("@ImageUrl", product.ImageUrl),
                new SqlParameter("@AgeRange", product.AgeRange)
            };

            return await _dbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            string query = "DELETE FROM Products WHERE ProductId = @ProductId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId", productId)
            };

            return await _dbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        private Product MapRowToProduct(DataRow row)
        {
            return new Product
            {
                ProductId = Convert.ToInt32(row["ProductId"]),
                Name = row["Name"].ToString() ?? "",
                Description = row["Description"].ToString() ?? "",
                Price = Convert.ToDecimal(row["Price"]),
                CategoryId = Convert.ToInt32(row["CategoryId"]),
                CategoryName = row["CategoryName"].ToString() ?? "",
                StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                ImageUrl = row["ImageUrl"].ToString() ?? "",
                AgeRange = row["AgeRange"].ToString() ?? "",
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }
    }
}
