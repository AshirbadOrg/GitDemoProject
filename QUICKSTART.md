# Quick Start Guide - Kids Toy Store

This guide will help you get the application up and running quickly.

## ⚡ Quick Setup (5 minutes)

### Step 1: Database Setup (1 minute)

```bash
# Option 1: Using sqlcmd (if installed)
sqlcmd -S localhost -E -i Database/CreateDatabase.sql

# Option 2: Using SQL Server Management Studio
# Open Database/CreateDatabase.sql and execute it
```

### Step 2: Backend Setup (2 minutes)

```bash
# Navigate to API directory
cd ToyStoreAPI/ToyStoreAPI

# Update connection string in appsettings.json if needed
# Default: "Server=localhost;Database=ToyStoreDB;User Id=sa;Password=YourPassword123!;TrustServerCertificate=True;"

# Run the API (it will be available at http://localhost:5000)
dotnet run
```

Keep this terminal open!

### Step 3: Frontend Setup (2 minutes)

Open a new terminal:

```bash
# Navigate to frontend directory
cd ToyStoreFrontend

# Install dependencies (first time only)
npm install

# Start the development server (will be available at http://localhost:4200)
npm start
```

### Step 4: Access the Application

1. Open your browser and go to: `http://localhost:4200`
2. You'll be redirected to the login page

### 🔑 Test Accounts

#### Admin Account (Full Access)
- **Username:** admin
- **Password:** Admin123!

#### Customer Account (Browse Only)
- **Username:** customer
- **Password:** Customer123!

## 🎯 What You Can Do

### As Customer:
- ✅ Browse products
- ✅ Filter by category
- ✅ Search products
- ✅ View product details

### As Admin:
- ✅ All customer features
- ✅ Access admin panel
- ✅ Add new products
- ✅ Edit existing products
- ✅ Delete products

## 🔧 Common Issues

### Issue: API won't start
**Solution:** Check if port 5000 is available. Change port in `Properties/launchSettings.json` if needed.

### Issue: Database connection failed
**Solution:** 
1. Verify SQL Server is running
2. Check connection string in `appsettings.json`
3. Ensure database was created successfully

### Issue: Frontend shows CORS error
**Solution:** 
1. Ensure backend is running on port 5000
2. Check API URLs in Angular services match your backend URL

### Issue: Login doesn't work
**Solution:**
1. Check browser console for errors
2. Verify backend API is running
3. Check network tab to see API response

## 📊 Sample Data

The database includes:
- **8 Categories** of toys
- **24 Sample Products** with images
- **2 User Accounts** (admin and customer)
- Price range: $11.99 - $49.99
- Age ranges: 2-14 years

## 🌐 URLs

- Frontend: `http://localhost:4200`
- Backend API: `http://localhost:5000`
- Swagger UI: `http://localhost:5000/swagger` (in development mode)

## 📁 Project Structure

```
GitDemoProject/
├── ToyStoreAPI/              # Backend (.NET Core)
│   └── ToyStoreAPI/
│       ├── Controllers/      # API endpoints
│       ├── Models/          # Data models
│       ├── DAL/             # Database access
│       ├── Services/        # Business logic
│       └── DTOs/            # Data transfer objects
│
├── ToyStoreFrontend/        # Frontend (Angular)
│   └── src/app/
│       ├── components/      # UI components
│       ├── services/        # HTTP services
│       └── models/          # TypeScript models
│
└── Database/                # SQL scripts
    └── CreateDatabase.sql  # Complete DB setup
```

## 🚀 Next Steps

1. **Explore the UI**: Login and browse products
2. **Try Admin Features**: Login as admin and manage products
3. **Check the Code**: Review the clean architecture
4. **Customize**: Modify categories, products, or UI to your needs

## 💡 Tips

- Use browser DevTools to inspect API calls
- Check `README.md` for detailed documentation
- All passwords are hashed using SHA256
- JWT tokens expire after 24 hours

## 🆘 Need Help?

Check the full README.md for:
- Detailed setup instructions
- Complete API documentation
- Architecture overview
- Troubleshooting guide

---

**Enjoy building with the Kids Toy Store application! 🎮🧸🎨**
