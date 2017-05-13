import { Component, OnInit } from '@angular/core';
import { NewsService } from '../services/news-service';
import { Article } from '../models/article';

@Component({
    selector: 'news',
    templateUrl: './app/news/components/news.html',
    providers: [NewsService]
})

export class NewsComponent implements OnInit {
    constructor(private _newsService: NewsService) {
        this.news = _newsService.getNews();
    }

    news: Array<Article>;

    ngOnInit() { }
}