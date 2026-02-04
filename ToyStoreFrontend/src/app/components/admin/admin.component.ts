import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { AuthService } from '../../services/auth.service';
import { Product, Category } from '../../models/product.model';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  showForm = false;
  editMode = false;
  currentProduct: Product = this.getEmptyProduct();

  constructor(
    private productService: ProductService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (!this.authService.isAdmin()) {
      this.router.navigate(['/products']);
      return;
    }
    this.loadProducts();
    this.loadCategories();
  }

  loadProducts(): void {
    this.productService.getAllProducts().subscribe({
      next: (products) => {
        this.products = products;
      },
      error: (error) => {
        console.error('Error loading products:', error);
      }
    });
  }

  loadCategories(): void {
    this.productService.getAllCategories().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (error) => {
        console.error('Error loading categories:', error);
      }
    });
  }

  showAddForm(): void {
    this.editMode = false;
    this.currentProduct = this.getEmptyProduct();
    this.showForm = true;
  }

  editProduct(product: Product): void {
    this.editMode = true;
    this.currentProduct = { ...product };
    this.showForm = true;
  }

  saveProduct(): void {
    if (this.editMode) {
      this.productService.updateProduct(this.currentProduct.productId, this.currentProduct).subscribe({
        next: () => {
          this.loadProducts();
          this.cancelForm();
        },
        error: (error) => {
          console.error('Error updating product:', error);
        }
      });
    } else {
      this.productService.createProduct(this.currentProduct).subscribe({
        next: () => {
          this.loadProducts();
          this.cancelForm();
        },
        error: (error) => {
          console.error('Error creating product:', error);
        }
      });
    }
  }

  deleteProduct(productId: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(productId).subscribe({
        next: () => {
          this.loadProducts();
        },
        error: (error) => {
          console.error('Error deleting product:', error);
        }
      });
    }
  }

  cancelForm(): void {
    this.showForm = false;
    this.currentProduct = this.getEmptyProduct();
  }

  goBack(): void {
    this.router.navigate(['/products']);
  }

  private getEmptyProduct(): Product {
    return {
      productId: 0,
      name: '',
      description: '',
      price: 0,
      categoryId: 0,
      categoryName: '',
      stockQuantity: 0,
      imageUrl: 'https://via.placeholder.com/300?text=Product+Image',
      ageRange: '',
      createdAt: new Date()
    };
  }
}
