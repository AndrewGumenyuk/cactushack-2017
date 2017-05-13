import { Injectable } from '@angular/core';
import { Article } from '../models/article';

@Injectable()
export class NewsService {
    private news:Array<Article> = [
        new Article("url", "Name1", "Descr"),
        new Article("url", "Name2", "Descr"),
        new Article("url", "Name3", "Descr"),
        new Article("url", "Name4", "Descr")
    ];

    constructor() { }

    getNews() {
        return this.news;
    }
}