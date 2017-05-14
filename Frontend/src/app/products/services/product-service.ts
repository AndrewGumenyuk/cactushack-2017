import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ProductService {
     private productUrl: string = 'http://localhost:2514/api/products';

    private products:Array<Product> = [
        new Product("Name1", 34, 35, 36, 37, 38),
        new Product("Name2", 34, 35, 36, 37, 38),
        new Product("Name3", 34, 35, 36, 37, 38),
        new Product("Name4", 34, 35, 36, 37, 38),
        new Product("Name5", 34, 35, 36, 37, 38),
    ];

    constructor(private http: Http) {}

    getProducts() {
        return this.http.get(this.productUrl).map(response => response.json() as Product[]);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}