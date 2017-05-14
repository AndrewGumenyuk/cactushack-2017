import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product-service';
import { Product } from '../models/product';

@Component({
    selector: 'products',
    host: {"class": "col-sm-12 products"},
    templateUrl: './app/products/components/products.html',
    providers: [ProductService]
})

export class ProductsComponent implements OnInit {
    constructor(private _productService:ProductService) { }

     products:Array<Product>;

     ngOnInit() {
         var data = this._productService.getProducts()
             .subscribe(
             value => { this.products = value; });
     }
}