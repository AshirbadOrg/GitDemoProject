-- Kids Toy Store Database Schema
-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ToyStoreDB')
BEGIN
    CREATE DATABASE ToyStoreDB;
END
GO

USE ToyStoreDB;
GO

-- Drop existing tables if they exist
IF OBJECT_ID('OrderDetails', 'U') IS NOT NULL DROP TABLE OrderDetails;
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Categories', 'U') IS NOT NULL DROP TABLE Categories;
IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;
GO

-- Create Users Table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT 'Customer',
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Create Categories Table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500)
);
GO

-- Create Products Table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000),
    Price DECIMAL(10,2) NOT NULL,
    CategoryId INT NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    ImageUrl NVARCHAR(500),
    AgeRange NVARCHAR(50),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
GO

-- Create Orders Table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO

-- Create OrderDetails Table
CREATE TABLE OrderDetails (
    OrderDetailId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

-- Insert Sample Categories
INSERT INTO Categories (Name, Description) VALUES
('Action Figures', 'Action figures and superhero toys for imaginative play'),
('Educational Toys', 'Learning toys that promote cognitive development'),
('Dolls & Stuffed Animals', 'Soft toys, dolls, and plush animals'),
('Building Blocks', 'Construction toys and building sets'),
('Board Games', 'Fun board games for family entertainment'),
('Outdoor Toys', 'Toys for outdoor play and activities'),
('Puzzles', 'Jigsaw puzzles and brain teasers'),
('Arts & Crafts', 'Creative art supplies and craft kits'),
('Remote Control Toys', 'RC cars, drones, and remote-controlled vehicles');
GO

-- Insert Sample Products
INSERT INTO Products (Name, Description, Price, CategoryId, StockQuantity, ImageUrl, AgeRange) VALUES
-- Action Figures
('Superhero Action Set', 'Set of 5 popular superhero action figures', 29.99, 1, 50, 'https://via.placeholder.com/300?text=Superhero+Set', '5-12 years'),
('Space Warrior Figure', 'Articulated space warrior with accessories', 15.99, 1, 75, 'https://via.placeholder.com/300?text=Space+Warrior', '6-10 years'),
('Robot Transformer', 'Transforming robot toy with lights', 24.99, 1, 40, 'https://via.placeholder.com/300?text=Robot+Transformer', '7-14 years'),

-- Educational Toys
('STEM Learning Kit', 'Science and engineering learning set', 39.99, 2, 80, 'https://via.placeholder.com/300?text=STEM+Kit', '8-12 years'),
('Alphabet Learning Blocks', 'Colorful blocks with letters and numbers', 18.99, 2, 100, 'https://via.placeholder.com/300?text=Learning+Blocks', '2-5 years'),
('Electronic Learning Tablet', 'Interactive tablet for early learning', 34.99, 2, 85, 'https://via.placeholder.com/300?text=Learning+Tablet', '3-7 years'),

-- Dolls & Stuffed Animals
('Princess Doll Collection', 'Beautiful princess dolls with outfits', 22.99, 3, 55, 'https://via.placeholder.com/300?text=Princess+Dolls', '4-10 years'),
('Giant Teddy Bear', 'Soft and cuddly giant teddy bear', 49.99, 3, 25, 'https://via.placeholder.com/300?text=Teddy+Bear', '3+ years'),
('Unicorn Plush Toy', 'Magical unicorn stuffed animal', 19.99, 3, 70, 'https://via.placeholder.com/300?text=Unicorn', '3-8 years'),

-- Building Blocks
('Mega Building Set 500pcs', 'Large building block set with 500 pieces', 44.99, 4, 35, 'https://via.placeholder.com/300?text=Building+Set', '4-12 years'),
('Castle Construction Kit', 'Medieval castle building kit', 32.99, 4, 40, 'https://via.placeholder.com/300?text=Castle+Kit', '5-10 years'),
('Vehicle Builder Set', 'Create cars, trucks, and more', 27.99, 4, 50, 'https://via.placeholder.com/300?text=Vehicle+Set', '6-12 years'),

-- Board Games
('Family Adventure Game', 'Exciting adventure board game for families', 25.99, 5, 90, 'https://via.placeholder.com/300?text=Adventure+Game', '8+ years'),
('Memory Match Game', 'Classic memory matching card game', 12.99, 5, 120, 'https://via.placeholder.com/300?text=Memory+Game', '4+ years'),
('Strategy Challenge', 'Strategic thinking board game', 29.99, 5, 75, 'https://via.placeholder.com/300?text=Strategy+Game', '10+ years'),

-- Outdoor Toys (OUT OF STOCK - Restocking in 15 days)
('Flying Disc Set', 'Colorful flying discs for outdoor fun', 14.99, 6, 0, 'https://via.placeholder.com/300?text=Flying+Disc', '6+ years'),
('Bubble Machine Deluxe', 'Automatic bubble blowing machine', 22.99, 6, 0, 'https://via.placeholder.com/300?text=Bubble+Machine', '3+ years'),
('Jump Rope with Counter', 'Digital counting jump rope', 11.99, 6, 0, 'https://via.placeholder.com/300?text=Jump+Rope', '5+ years'),

-- Puzzles
('1000 Piece Jigsaw Puzzle', 'Challenging landscape puzzle', 17.99, 7, 50, 'https://via.placeholder.com/300?text=Jigsaw+Puzzle', '10+ years'),
('3D Crystal Puzzle', 'Beautiful 3D crystal puzzle', 14.99, 7, 45, 'https://via.placeholder.com/300?text=3D+Puzzle', '12+ years'),
('Wooden Shape Sorter', 'Educational shape sorting puzzle', 11.99, 7, 70, 'https://via.placeholder.com/300?text=Shape+Sorter', '2-4 years'),

-- Arts & Crafts
('Deluxe Art Set', 'Complete art supplies set with 150 pieces', 34.99, 8, 40, 'https://via.placeholder.com/300?text=Art+Set', '6+ years'),
('Jewelry Making Kit', 'Create your own jewelry', 21.99, 8, 55, 'https://via.placeholder.com/300?text=Jewelry+Kit', '8+ years'),
('Paint by Numbers', 'Beautiful paint by numbers art kit', 17.99, 8, 60, 'https://via.placeholder.com/300?text=Paint+Kit', '7+ years'),

-- Remote Control Toys
('RC Racing Car', 'High-speed remote control racing car', 39.99, 9, 45, 'https://via.placeholder.com/300?text=RC+Car', '8+ years'),
('Drone with Camera', 'Quadcopter drone with HD camera', 89.99, 9, 20, 'https://via.placeholder.com/300?text=Drone', '12+ years'),
('RC Monster Truck', 'All-terrain remote control monster truck', 49.99, 9, 30, 'https://via.placeholder.com/300?text=Monster+Truck', '8+ years');
GO

-- Insert Sample Admin User (password: Admin123!)
-- Password hash for "Admin123!" using SHA256
INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES
('admin', 'admin@toystore.com', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=', 'Admin');
GO

-- Insert Sample Customer User (password: Customer123!)
-- Password hash for "Customer123!" using SHA256
INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES
('customer', 'customer@toystore.com', 'JI3/ruSOaDmPTpAU4F8iKMcUh7UkuFKx6rPjhHXEvpw=', 'Customer');
GO

PRINT 'Database schema created successfully!';
PRINT 'Sample data inserted successfully!';
PRINT '';
PRINT 'Default Admin Account:';
PRINT '  Username: admin';
PRINT '  Password: Admin123!';
PRINT '';
PRINT 'Default Customer Account:';
PRINT '  Username: customer';
PRINT '  Password: Customer123!';
GO
