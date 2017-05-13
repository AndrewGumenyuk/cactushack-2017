import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product-service';
import { Product } from '../models/product';

@Component({
    selector: 'products',
    templateUrl: './app/products/components/products.html',
    providers: [ProductService]
})

export class ProductsComponent implements OnInit {
    constructor(private _productService:ProductService) {
        this.products = _productService.getProducts();
     }

     products:Array<Product>;

    ngOnInit() { }
}