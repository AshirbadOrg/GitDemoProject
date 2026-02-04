export interface Product {
  productId: number;
  name: string;
  description: string;
  price: number;
  categoryId: number;
  categoryName: string;
  stockQuantity: number;
  imageUrl: string;
  ageRange: string;
  createdAt: Date;
}

export interface Category {
  categoryId: number;
  name: string;
  description: string;
}
