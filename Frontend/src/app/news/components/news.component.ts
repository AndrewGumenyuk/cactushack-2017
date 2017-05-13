import { Component, OnInit, AfterViewInit  } from '@angular/core';
import { NewsService } from '../services/news-service';
import { Article } from '../models/article';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'news',
    templateUrl: './app/news/components/news.html',
    providers: [NewsService],
})

export class NewsComponent implements OnInit, AfterViewInit  {
    news: Article[];
    currentArticle: Article;

    constructor(private _newsService: NewsService) { }

    ngOnInit() {
        var data = this._newsService.getNews()
            .subscribe(
             value => { this.news = value; this.currentArticle = this.news[0]; });
    }
    ngAfterViewInit(): void { }
}