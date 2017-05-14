import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Http, Response, RequestOptions, URLSearchParams  } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class SettingsService {
    private profileUrl = 'http://localhost:2514/api/profile';
    private setProfileUrl = 'http://localhost:2514/api/profile/UpdateProfile';

    constructor(private http: Http) { }

    private user: User = new User(34, 0, 80, 180, 2);

    public getUser() {
        return this.http.get(this.profileUrl).map(response => response.json() as User);
    }

    setUser(user:User) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('activity', String(user.activity));
        params.set('age', String(user.age));
        params.set('height', String(user.height));
        params.set('sex', String(user.sex));
        params.set('weight', String(user.weight));
        let requestOptions = new RequestOptions();
        requestOptions.search = params;
        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open( "GET",
        "http://localhost:2514/api/values?age=" + user.age + "&height=" + user.height +
        "&sex=" + user.sex + "&weight=" + user.weight,
        false ); // false for synchronous request
        xmlHttp.send( null );
        console.log(xmlHttp.responseText);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}