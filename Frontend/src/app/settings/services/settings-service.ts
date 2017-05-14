import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class SettingsService {
    private profileUrl = 'http://localhost:2514/api/profile';

    constructor(private http: Http) { }

    private user: User = new User(34, "male", 80, 180, "active");

    public getUser() {
        return this.http.get(this.profileUrl).map(response => response.json() as User);
    }

    setUser() { }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}