import { Injectable } from '@angular/core';
import { Stats } from '../models/stats';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class StatsService {
    private newsUrl: string = 'http://localhost:2514/api/user_statistics';

    constructor(private http: Http) { }

    private stats: Stats = new Stats(34, 35, 36, 37);

    getStats(): Observable<Stats> {
        return this.http.get(this.newsUrl).map(response => response.json() as Stats);
    }
}