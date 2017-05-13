import { Injectable } from '@angular/core';
import { Product } from '../models/product';

@Injectable()
export class ProductService {
    private products:Array<Product> = [
        new Product("Name1", 34, 35, 36, 37, 38),
        new Product("Name2", 34, 35, 36, 37, 38),
        new Product("Name3", 34, 35, 36, 37, 38),
        new Product("Name4", 34, 35, 36, 37, 38),
        new Product("Name5", 34, 35, 36, 37, 38),
    ];

    constructor() {}

    getProducts() {
        return this.products;
    }
}