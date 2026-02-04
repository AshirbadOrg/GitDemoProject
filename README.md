# Kids Toy Store - Full Stack Application

A complete full-stack web application for a kids toy retail store featuring .NET Core Web API backend, Angular 20+ frontend, ADO.NET for database operations, and SQL Server database with JWT authentication.

## 🎯 Features

### Frontend (Angular 20+)
- User authentication (Login/Register)
- Product browsing with category filters
- Product search functionality
- Detailed product views
- Admin panel for product management (CRUD operations)
- Responsive design with modern UI

### Backend (.NET Core Web API)
- RESTful API architecture
- JWT token-based authentication
- ADO.NET for direct database operations
- Role-based authorization (Admin/Customer)
- CORS enabled for frontend integration

### Database (SQL Server)
- Normalized database schema
- Sample data with 8 categories and 24 products
- Users with hashed passwords
- Order management structure
- Stored procedures ready structure

## 🏗️ Architecture

```
GitDemoProject/
├── ToyStoreAPI/              # .NET Core Web API Backend
│   └── ToyStoreAPI/
│       ├── Controllers/      # API Controllers (Auth, Products, Categories)
│       ├── Models/          # Domain models (User, Product, Category, Order)
│       ├── DAL/             # Data Access Layer with ADO.NET
│       ├── DTOs/            # Data Transfer Objects
│       └── Services/        # Business logic (AuthService)
├── ToyStoreFrontend/        # Angular 20+ Frontend
│   └── src/
│       └── app/
│           ├── components/  # UI Components
│           ├── models/      # TypeScript interfaces
│           └── services/    # HTTP services
└── Database/                # SQL Server Scripts
    └── CreateDatabase.sql  # Complete database setup script
```

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Node.js 20.x or later
- SQL Server (LocalDB, Express, or Full)
- Angular CLI (`npm install -g @angular/cli`)

### Database Setup

1. **Create the database:**
   ```bash
   # Using SQL Server Management Studio or sqlcmd
   sqlcmd -S localhost -i Database/CreateDatabase.sql
   ```

2. **Update connection string in `ToyStoreAPI/ToyStoreAPI/appsettings.json`:**
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=ToyStoreDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
   }
   ```

### Backend Setup

1. **Navigate to API directory:**
   ```bash
   cd ToyStoreAPI/ToyStoreAPI
   ```

2. **Restore packages:**
   ```bash
   dotnet restore
   ```

3. **Run the API:**
   ```bash
   dotnet run
   ```
   
   The API will be available at `http://localhost:5000` or `https://localhost:5001`

### Frontend Setup

1. **Navigate to frontend directory:**
   ```bash
   cd ToyStoreFrontend
   ```

2. **Install dependencies:**
   ```bash
   npm install
   ```

3. **Update API URL in services if needed:**
   - Edit `src/app/services/auth.service.ts`
   - Edit `src/app/services/product.service.ts`
   - Change `apiUrl` to match your backend URL

4. **Run the development server:**
   ```bash
   npm start
   # or
   ng serve
   ```
   
   The application will be available at `http://localhost:4200`

## 👤 Default User Accounts

The database comes with two pre-configured accounts:

### Admin Account
- **Username:** `admin`
- **Password:** `Admin123!`
- **Access:** Full product management capabilities

### Customer Account
- **Username:** `customer`
- **Password:** `Customer123!`
- **Access:** Browse and view products

## 📊 Database Schema

### Tables
- **Users** - User accounts with authentication details
- **Categories** - Product categories (8 categories)
- **Products** - Toy products with details (24 sample products)
- **Orders** - Customer orders
- **OrderDetails** - Order line items

### Sample Categories
1. Action Figures
2. Educational Toys
3. Dolls & Stuffed Animals
4. Building Blocks
5. Board Games
6. Outdoor Toys
7. Puzzles
8. Arts & Crafts

## 🔐 Authentication

The application uses JWT (JSON Web Token) authentication:
- Tokens are generated upon successful login/registration
- Tokens are stored in localStorage
- Authorization header is included in protected API calls
- Admin-only routes are protected with role-based authorization

> **⚠️ Security Note:** This demo uses SHA256 for password hashing for simplicity. For production applications, use a secure password hashing algorithm like BCrypt, Argon2, or PBKDF2 with proper salting.

## 🎨 UI Features

### Product List Page
- Grid layout of all products
- Category filter dropdown
- Search functionality
- Product cards with image, price, and stock info
- Responsive design

### Product Detail Page
- Large product image
- Full product description
- Price and availability
- Category and age range badges

### Admin Panel
- Add new products
- Edit existing products
- Delete products
- Product management table
- Form validation

## 🛠️ Technologies Used

### Backend
- .NET Core 8.0
- ASP.NET Core Web API
- ADO.NET (System.Data.SqlClient)
- JWT Authentication (Microsoft.AspNetCore.Authentication.JwtBearer)
- System.IdentityModel.Tokens.Jwt

### Frontend
- Angular 21 (latest version)
- TypeScript
- RxJS
- HttpClient
- Router
- Forms Module

### Database
- SQL Server
- T-SQL

## 📝 API Endpoints

### Authentication
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - Login user

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `GET /api/products/category/{categoryId}` - Get products by category
- `POST /api/products` - Create product (Admin only)
- `PUT /api/products/{id}` - Update product (Admin only)
- `DELETE /api/products/{id}` - Delete product (Admin only)

### Categories
- `GET /api/categories` - Get all categories
- `GET /api/categories/{id}` - Get category by ID

## 🔒 Security Features

- Password hashing using SHA256
- JWT token-based authentication
- Role-based authorization
- CORS configuration
- HTTPS support

## 📦 NuGet Packages

- Microsoft.AspNetCore.Authentication.JwtBearer (8.0.0)
- System.Data.SqlClient (4.8.6)
- System.IdentityModel.Tokens.Jwt (8.0.0)

## 🌐 CORS Configuration

The API is configured to allow all origins for development. For production, update the CORS policy in `Program.cs` to specify allowed origins.

## 📱 Responsive Design

The frontend is fully responsive and works on:
- Desktop browsers
- Tablets
- Mobile devices

## 🚧 Future Enhancements

- Shopping cart functionality
- Order placement and tracking
- Payment integration
- Product reviews and ratings
- Wishlist feature
- Email notifications
- Product image upload
- Inventory management
- Sales analytics dashboard

## 📋 Project Planning Resources

### Capacity Planner

A lightweight capacity planning template to help teams manage resource allocation and sprint planning:

- **[Capacity Planner Documentation](docs/capacity-planner.md)** - Comprehensive guide with usage instructions, examples, and best practices
- **[Capacity Planner CSV Template](templates/capacity-planner.csv)** - Import into Excel, Google Sheets, or any spreadsheet application

The capacity planner includes:
- Team member resource tracking
- Sprint/week allocation planning
- Capacity utilization calculations
- Example data with realistic scenarios
- Weekly update workflow guidance

Perfect for agile teams needing to track availability, allocations, and remaining capacity across sprints.

## 🐛 Troubleshooting

### Database Connection Issues
- Verify SQL Server is running
- Check connection string in `appsettings.json`
- Ensure TrustServerCertificate=True for local development

### CORS Errors
- Ensure backend is running on port 5000
- Check CORS configuration in `Program.cs`
- Verify API URLs in Angular services

### Build Errors
- Run `dotnet restore` for backend
- Run `npm install` for frontend
- Clear build artifacts: `dotnet clean` and delete `node_modules`

## 📄 License

This project is created for demonstration purposes.

## 👨‍💻 Development

For development questions or contributions, please refer to the issue tracker or documentation.
