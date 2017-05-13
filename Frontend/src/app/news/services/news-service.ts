import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class NewsService {
    private newsUrl: string = 'http://localhost:2514/api/recipenews';

    private news: Array<Article> = [
        new Article("url", "Name1", "Descr"),
        new Article("url", "Name2", "Descr"),
        new Article("url", "Name3", "Descr"),
        new Article("url", "Name4", "Descr")
    ];

    constructor(private http: Http) { }

    getNews() : Observable<Article[]> {
        return this.http.get(this.newsUrl).map(response => response.json() as Article[]);
    }
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}